Imports System.Threading

Imports xSAPtorExcel.Main.Notification.Icon
Imports xSAPtorExcel.Main.Process.Options
Imports xSAPtorExcel.Main.Process.Selection
Imports xSAPtorExcel.Main.Process.BDCWorksheet
Imports xSAPtorExcel.Main.Process.Runner.Viatest
Imports xSAPtorExcel.Main.Process.Runner.ViaZDTON

Imports xSAPtorExcel.Services.UI
Imports xSAPtorExcel.Utilities.MsgHub

Imports BxS.API.Main
Imports BxS.API.SAPFunctions.BDCTransaction
Imports BxS.API.SAPFunctions.ZDTON
Imports BxS.API.BDC

'Imports xSAPtorExcel.Services.Excel
'Imports xSAPtorExcel.Main.BDCProcessing
'Imports xSAPtorExcel.Main.Process.Common
'Imports xSAPtorExcel.Main.Process.Overview
'Imports xSAPtorExcel.Main.Process.RunMonitor
'Imports xSAPtorExcel.Main.Process.Runner
'Imports xSAPtorExcel.Main.Process.ViaGUI
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Controller

	Friend Class BxSProcessController
								Implements iBxSProcessController

		#Region "Definitions"

			Private	WithEvents	co_CntlrMain		As	iBxSMainController

			Private WithEvents	co_CntlrNCO			As	Lazy(Of ixNCOController) _
														=	New	Lazy(Of ixNCOController)(
																Function()	Me.co_CntlrMain.GetNCOController(),
																LazyThreadSafetyMode.ExecutionAndPublication )

			Private	WithEvents	co_SelectionVM	As	Lazy(Of ixProcessSelectionVM) _
														= New	Lazy(Of ixProcessSelectionVM)(
																Function()	New xProcessSelectionVM(Me),
																LazyThreadSafetyMode.ExecutionAndPublication )

			Private	WithEvents	co_OptionsVM		As Lazy(Of ixProcessOptionsVM) _
														= New Lazy(Of ixProcessOptionsVM)(
																Function()	New xProcessOptionsVM(Me),
																LazyThreadSafetyMode.ExecutionAndPublication )
			'....................................................
			Private	co_NotifyDTO	As	Lazy(Of iNotificationMessageDTO) _
																	= New Lazy(Of iNotificationMessageDTO)(
																			Function()	New NotificationMessageDTO,
																			LazyThreadSafetyMode.ExecutionAndPublication )

			Private cb_Busy				As	Boolean

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	ActiveDestinationID()	As String _
																		Implements	iBxSProcessController.ActiveDestinationID
				Get
					Return	Me.co_CntlrMain.ActiveDestinationID
				End Get
			End Property				
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	IsDestinationSet()	As Boolean _
																		Implements	iBxSProcessController.IsDestinationSet
				Get
					Return	Me.co_CntlrMain.DestinationSelected
				End Get
			End Property				
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property IsBusy()	As Boolean _
																					Implements iBxSProcessController.IsBusy 
				Get
					Return	Me.cb_Busy
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: General"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Create_BDCRunnerViaZDTON()	As iBxSRunnerViaZDTON _
													Implements iBxSProcessController.Create_BDCRunnerViaZDTON

				Return	New BxSRunnerViaZDTON(Me)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetNotifyDTO() As iNotificationMessageDTO _
													Implements iBxSProcessController.GetNotifyDTO

				Return Me.co_NotifyDTO.Value.Clone()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetMsgHub() As iMsgHub _
													Implements iBxSProcessController.GetMsgHub

				Return	New	MsgHub()

			End Function

#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Processing"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetBDCZDTON()	As iBxS_ZDTON _
													Implements iBxSProcessController.GetBDCZDTON

				Return Me.co_CntlrNCO.Value.GetZDTONTransaction(Me.co_CntlrMain.ActiveDestinationID)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetBDCTransaction()	As iBxS_BDCTran_Caller _
													Implements iBxSProcessController.GetBDCTransaction

				Return Me.co_CntlrNCO.Value.GetBDCTransactionCaller(Me.co_CntlrMain.ActiveDestinationID)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetBDCWSProfile(	Optional	ByVal	workbookName	As String	= "",
																					Optional	ByVal	worksheetName	As String	= ""	)		As iBDCWSProfile _
													Implements iBxSProcessController.GetBDCWSProfile

					Dim lo_WSProfileDTO	= Me.co_CntlrMain.GetExcelHelper().GetExcelWSProfileDTO(	WorkBookName	:= workbookName,
																																												WorkSheetName	:= worksheetName)

					Dim lo_BDCWSHeader	As iBDCWSHeader				=	New BDCWSHeader(Me.co_CntlrMain.GetExcelHelper())
					Dim lo_BDCWSData		As iBDCWSData					= New BDCWSData(Me.co_CntlrMain.GetExcelHelper())
					Dim lo_BDCTran			As iBxS_BDCTran_Tran	= Me.co_CntlrMain.GetNCOController.GetBDCTransactionJob()
					Dim lo_BDCEntry			As iBxS_BDC_Entry			= Me.co_CntlrMain.GetNCOController.GetBDCTransactionEntry()

					Dim lo_BDCWSProfile	= New BDCWSProfile( excelWSProfileDTO	:=	lo_WSProfileDTO,
																									bdcWSHeader				:=	lo_BDCWSHeader,
																									bdcWSData					:=	lo_BDCWSData,
																									bdcTran						:=	lo_BDCTran,
																									bdcEntry					:=	lo_BDCEntry,
																									sapuser						:=	Me.co_CntlrMain.ActiveUserID)

					Return	lo_BDCWSProfile

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Selection"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_SelectionView()

				Me.co_SelectionVM.Value.Show()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetSelectionModel() As ixProcessSelectionModel _
													Implements iBxSProcessController.GetSelectionModel

				Return	New xProcessSelectionModel(Me.co_CntlrMain.GetExcelHelper())

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Options"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetOptionModel() As ixProcessOptionsModel _
													Implements iBxSProcessController.GetOptionModel

				Return New xProcessOptionsModel

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Ribbon Event Handling"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub RibbonEventHandler(ByVal i_Tag As String) _
									Implements iBxSProcessController.RibbonEventHandler

				Select Case i_Tag
					Case "xtag_BDCOptions"				: Me.RibbonEventHandler_OptionsView()
					Case "xtag_ProcessSelection"	: Me.RibbonEventHandler_SelectionView()
					Case "xtag_ProcessRunner"			: Me.RibbonEventHandler_ProcessRunnerView()
					Case "xtag_BDCTest"						: Me.RibbonEventHandler_TestMode
				End Select

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_OptionsView()

				If Me.co_OptionsVM.Value.ToggleView()

					AddHandler	co_OptionsVM.Value.ev_Notification,
											AddressOf Me.EventHandler_Notifications

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_ProcessRunnerView()

				'Me.co_ProcessRunMonitorVM.Value.ToggleView()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub RibbonEventHandler_TestMode()

					Dim lo_Runner	As	iBxSRunnerViaTest	= New BxSRunnerViaTest(Me)
					Dim x = Await lo_Runner.StartAsync()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub EventHandler_Notifications(ByRef DTO	As iNotificationMessageDTO)
				'Globals.Ribbons.xSAPtorRB.SendMessage(DTO)
				'Me.co_NotifyVM.SendMessage(DTO)

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(ByVal	controller	As iBxSMainController)

				Me.co_CntlrMain	= controller

				Me.co_CTS	= New CancellationTokenSource

			End Sub

		#End Region



			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		

			Private							co_CTS					As CancellationTokenSource





			Private WithEvents	co_NCOCntlr			As ixNCOController

			'Private	WithEvents	co_RunnerModel	As Lazy(Of ixProcessRunnerModel) _
			'											= New Lazy(Of ixProcessRunnerModel)(
			'													Function()

			'														Dim lo_RunnerModel	As ixProcessRunnerModel	= xProcessRunnerModel.Create()

			'														Return lo_RunnerModel

			'													End Function,
			'													LazyThreadSafetyMode.ExecutionAndPublication )

			'Private	WithEvents	co_SelectionVM	As Lazy(Of ixProcessSelectionViewModel) _
			'											= New Lazy(Of ixProcessSelectionViewModel)(
			'													Function()
																
			'														Dim lo_SelectionModel	As ixProcessSelectionModel	= xProcessSelectionModel.Create(ExcelHelper:= Me.co_ExcelHelper)

			'														Me.co_ProcessRunner.Value.StartUp()

			'														Return xProcessSelectionViewModel.Create(SelectionModel		 := lo_SelectionModel,
			'																																		 ProcessRunnerModel:= Me.co_RunnerModel.Value,
			'																																		 NotifyVM					 := Me.co_NotifyVM)

			'													End Function,
			'													LazyThreadSafetyMode.ExecutionAndPublication )
			
			'Private	WithEvents	co_ProcessRunMonitorVM	As Lazy(Of ixProcessRunMonitorViewModel) _
			'											= New Lazy(Of ixProcessRunMonitorViewModel)(
			'													Function()

			'														Return xProcessRunMonitorViewModel.Create(ProcessRunnerModel:= Me.co_RunnerModel.Value)

			'													End Function,
			'													LazyThreadSafetyMode.ExecutionAndPublication )

			'Private WithEvents	co_ProcessRunner	As Lazy(Of ixProcessRunnerController) _
			'											= New Lazy(Of ixProcessRunnerController)(
			'													Function()

			'														Dim lo_PBar							As IProgress(Of iPBarData)	= Nothing
			'														Dim lo_OptionsDTO				As ixProcessOptionsDTO			= xProcessOptionsModel.Create().FetchOptions()

			'														Dim lo_ProcessRunnerPLC	As ixProcessRunnerPLC				= xProcessRunnerPLC.Create(NCOController:= Me.co_NCOCntlr,
			'																																																					 ExcelHelper	:= Me.co_ExcelHelper,
			'																																																					 CancelToken	:= Me.co_CTS.Token,
			'																																																					 ProgressBar	:= lo_PBar)

			'														Return xProcessRunnerController.Create(ProcessRunnerPLC	 := lo_ProcessRunnerPLC,
			'																																	 ProcessRunnerModel:= Me.co_RunnerModel.Value,
			'																																	 ProcessOptions		 := lo_OptionsDTO,
			'																																	 ExcelHelper			 := Me.co_ExcelHelper,
			'																																	 NotifyVM					 := Me.co_NotifyVM)

			'													End Function,
			'													LazyThreadSafetyMode.ExecutionAndPublication )

			'Private	WithEvents	co_ProcessViaGUICntlr	As Lazy(Of ixProcessControllerViaGUI) _
			'											= New Lazy(Of ixProcessControllerViaGUI)(
			'													Function()

			'														Return xProcessControllerViaGUI.Create(NCOController:= Me.co_NCOCntlr,
			'																																	 ExcelHelper	:= Me.co_ExcelHelper,
			'																																	 NotifyVM			:= Me.co_NotifyVM)

			'													End Function,
			'													LazyThreadSafetyMode.ExecutionAndPublication )



			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_SAPGUIRunner()

				''Dim lo_NotifyDTO	As iNotificationMessageDTO	= New NotificationMessageDTO
				''Dim lc_Text				As String


				'If Not Me.co_ProcessViaGUICntlr.IsValueCreated
				'	Me.co_ProcessViaGUICntlr.Value.Startup()
				'End If

				'Dim lo_RequestDTO	As ixProcessRequestDTO	= xProcessRequestDTO.Create(WorkbookName := Me.co_ExcelHelper.GetActiveWBookName(),
				'																																			WorksheetName:= Me.co_ExcelHelper.GetActiveWSName() )

				''If Me.co_ProcessViaGUICntlr.Value.SubmitRequest(ProcessRequest:= lo_RequestDTO)
				''	lc_Text	= "Successful"
				''Else
				''	lc_Text	= "FAILED"
				''	lo_NotifyDTO.Type = lo_NotifyDTO.TypeError
				''End If

				''lo_NotifyDTO.Text	= String.Format("Submit: {0}/{1}: {2}", lo_RequestDTO.WBookName, lo_RequestDTO.WSheetName,  lc_Text)

				'Me.co_NotifyVM.SendMessage(Notification:= Me.co_ProcessViaGUICntlr.Value.SubmitRequest(ProcessRequest:= lo_RequestDTO))

			End Sub



			'Private WithEvents	co_ProcessViaGUI	As Lazy(Of ixProcessViaGUI) _
			'											= New Lazy(Of ixProcessViaGUI)(
			'													Function()

			'														Dim lo_WSProfileDTO		As iExcelWSProfileDTO		= Me.co_ExcelHelper.GetExcelWorkSheetProfile()

			'														If lo_WSProfileDTO Is Nothing
			'															Return Nothing
			'														Else

			'															Dim lo_BDCWSProfile		As iBDCWSProfile				= New BDCWSProfile(i_ExcelWSProfile:= lo_WSProfileDTO,
			'																																															 i_ExcelHelper	 := Me.co_ExcelHelper)

			'															Dim lo_OptionsModel	As ixProcessOptionsModel	= xProcessOptionsModel.Create()

			'															Return xProcessViaGUI.Create(ExcelHelper			 := Me.co_ExcelHelper,
			'																													 CancelToken			 := Me.co_CTS.Token,
			'																													 WSProfile				 := lo_BDCWSProfile,
			'																													 PLCBDCTransactions:= Me.co_NCOCntlr.GetBDCTransactionPLC(),
			'																													 ProcessOptions		 := lo_OptionsModel.FetchOptions(),
			'																													 NotifyVM					 := Me.co_NotifyVM)

			'														End If

			'													End Function,
			'													LazyThreadSafetyMode.ExecutionAndPublication )


			'Private Async Sub RibbonEventHandler_SAPGUI()

			'	Dim lo_ViaGUICntlr	As ixProcessControllerViaGUI = Nothing
			
			''= xProcessControllerViaGUI.Create(ExcelHelper:= Me.co_ExcelHelper,
			''																																											NotifyVM	 := Me.co_NotifyVM)

			'	If lo_ViaGUICntlr.Startup()
			'	Else
					
			'	End If


			'	Dim lo_NotifyDTO	As iNotificationMessageDTO	= New NotificationMessageDTO
			'	Dim lc_Text				As String
			'	Dim ln_Status			As UInteger

			'	'If Me.co_ExcelHelper.IsInEditMode
			'	'	lb_Ret	= Me.StatusInExcel
			'	'Else
				


			'	ln_Status	= Await Me.co_ProcessViaGUI.Value.StartAsync()



			'	Select Case ln_Status
			'	    Case Me.co_ProcessViaGUI.Value.StatusOk	: lc_Text	=  "Started: OK"
			'			Case Else																: lc_Text	=  "Not started: "

			'				Select Case ln_Status
			'				    Case Me.co_ProcessViaGUI.Value.StatusInExcel					:	lc_Text += "Excel in Editmode"
			'						Case Me.co_ProcessViaGUI.Value.StatusInExcelMsgUpdate	: lc_Text += "Excel in Editmode, Messages not updated"
			'						Case Me.co_ProcessViaGUI.Value.StatusNoTransactions		: lc_Text += "No transactions found"
			'						Case Me.co_ProcessViaGUI.Value.StatusWSProfile				: lc_Text += "Could not obtain worksheet profile"
			'				End Select

			'	End Select

			'	lo_NotifyDTO.Text	= String.Concat("Via GUI: ", lc_Text)
			'	Me.co_NotifyVM.SendMessage(Notification:= lo_NotifyDTO)

			'End Sub


		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xPBarHandler(ByVal i_PBarData As iPBarData)

			'Me.co_Context.Post(
			'	Sub()
			'		If i_PBarData.Complete = 0 Or i_PBarData.Total = 0
			'			Me.xpbr_tss_PBar.Value = 0
			'		Else
			'			Me.xpbr_tss_PBar.Value = CInt((i_PBarData.Complete / i_PBarData.Total) * 100)
			'		End If
			'	End Sub,  Nothing)
		
		End Sub

		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private"
		#End Region




		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯



	End Class

End Namespace

