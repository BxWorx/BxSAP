Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports xSAPtorExcel.Main.BDCProcessing
Imports xSAPtorExcel.Main.Notification.Icon
Imports xSAPtorExcel.Main.Process.Options
Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.Services.UI
'Imports xSAPtorNCO.API.SAP.System.Services
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.ViaGUI

	Friend Class xProcessViaGUI
								Implements ixProcessViaGUI


			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property StatusOk								As UInteger		Implements ixProcessViaGUI.StatusOk
				Get
					Return 0
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property StatusInExcel					As UInteger		Implements ixProcessViaGUI.StatusInExcel
				Get
					Return 1
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property StatusInExcelMsgUpdate	As UInteger		Implements ixProcessViaGUI.StatusInExcelMsgUpdate
				Get
					Return 2
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property StatusNoTransactions		As UInteger		Implements ixProcessViaGUI.StatusNoTransactions
				Get
					Return 4
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property StatusWSProfile				As UInteger		Implements ixProcessViaGUI.StatusWSProfile
				Get
					Return 8
				End Get
			End Property


			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function StartAsync() _
															As Task(Of UInteger) _
																Implements ixProcessViaGUI.StartAsync

				Dim lb_Ret	As UInteger	= Me.StatusOk

				If Me.co_ExcelHelper.IsInEditMode
					lb_Ret	= Me.StatusInExcel
				Else

					Dim ln_TranCount	As Integer

					Me.co_WSProfileDTO	= Me.co_ExcelHelper.GetExcelWorkSheetProfile()

					If Me.co_WSProfileDTO IsNot Nothing

						ln_TranCount	= Await Me.ProcessAsync()

						If ln_TranCount > 0

							If Me.co_ExcelHelper.IsInEditMode
								lb_Ret	= Me.StatusInExcelMsgUpdate
							Else
								Me.UpdateMessages()
							End If

						Else
							lb_Ret	= Me.StatusNoTransactions
						End If

					Else
						lb_Ret	= Me.StatusWSProfile
					End If

				End If

				Return lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function UpdateMessages() _
												As Boolean _
													Implements ixProcessViaGUI.UpdateMessages

				Dim lb_Ret				As Boolean									= True
				'Dim lo_NotifyDTO	As iNotificationMessageDTO	= New NotificationMessageDTO
				
				If Me.co_PLCBDCTran.MessageCount = 0
					'lo_NotifyDTO.Text	= "Process BDC Transaction: No messages ..."
					lb_Ret						= False
				Else

					''Dim lc_Address	As String
					''Dim lc_CellVal	As String
					Dim lb_ScrnUpd	As Boolean
					Dim lo_WS				As Excel.Worksheet

					lb_ScrnUpd	=	Me.co_ExcelHelper.GetSetScreenUpdating(False)
					lo_WS				= Me.co_ExcelHelper.GetWSheet(i_WBName:=	Me.OnWorkBook,
																										i_WSName:=  Me.OnWorkSheet)
	
					Do While Me.co_PLCBDCTran.MessageCount > 0

						'For Each ls_Msg As KeyValuePair(Of Integer, List(Of ixBDCMessage)) In Me.co_PLCBDCTran.TryTakeMessages()

						'	lc_Address	= String.Concat("$A$", ls_Msg.Key.ToString)
						'	lc_CellVal	= ""

						'	For Each lc_Msg As ixBDCMessage In ls_Msg.Value
						'		lc_CellVal	= String.Concat(lc_CellVal, lc_Msg.LongText,";")
						'	Next

						'	lo_WS.Range(lc_Address).Value	= lc_CellVal

						'Next

					Loop

					Me.co_ExcelHelper.GetSetScreenUpdating(lb_ScrnUpd)
									
				End If

				Return lb_Ret

			End Function











		#Region "Defintions"

			Private WithEvents	co_NotifyVM		As ixNotificationIconViewModel

			Private	co_ExcelHelper		As iExcelHelper
			Private co_CT							As CancellationToken
			Private co_WSProfileDTO		As iExcelWSProfileDTO
			Private co_Options				As ixProcessOptionsDTO
			Private co_PLCBDCTran			As ixBDCTransactionPLC

			Private co_BDCWSProfile		As iBDCWSProfile

			Private ct_Msgs						As ConcurrentDictionary(Of Integer, List(Of ixBDCMessage))

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property OnWorkBook _
																As String _
																	Implements ixProcessViaGUI.OnWorkBook
				Get
					Return	Me.co_WSProfileDTO.WBookName
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property OnWorkSheet _
																As String _
																	Implements ixProcessViaGUI.OnWorkSheet
				Get
					Return Me.co_WSProfileDTO.WSheetName
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function ProcessAsync() _
															As Task(Of Integer) _
																Implements ixProcessViaGUI.ProcessAsync

				Dim lo_NotifyDTO				As iNotificationMessageDTO	= New NotificationMessageDTO
				Dim lo_ProgressHandler	As Action(Of iPBarData)			= AddressOf Me.xPBarHandler
				Dim lo_Progress					As IProgress(Of iPBarData)	= New Progress(Of iPBarData)(lo_ProgressHandler)
				Dim lb_Ret							As Integer									= 0

				Try

					'Dim lo_BDCWSProfile		As iBDCWSProfile			= New BDCWSProfile(i_ExcelWSProfile:= Me.co_WSProfileDTO,
					'																															 i_ExcelHelper	 := Me.co_ExcelHelper)

					If Await Me.co_BDCWSProfile.LoadDataAsync(i_Progress:= lo_Progress,
																										i_CT			 := Me.co_CT)

						If Await Me.co_BDCWSProfile.CompileTransactionsAsync(i_Progress:= lo_Progress,
																																 i_CT			:= Me.co_CT)

							''Me.co_PLCBDCTran.Post(i_TransactionList:= Me.co_BDCWSProfile.BDCTransactions)
							''Me.co_PLCBDCTran.Complete

							''lb_Ret	= Await Me.co_PLCBDCTran.StartupConsumersAsync(i_ConcurrentProcesses:= Me.co_Options.ParallelProcessesTran)



							'Dim ln_Failed		As Integer	= 0
							'Dim ln_OK     	As Integer	= 0

							'Me.ct_Msgs.Clear()

							'Await Task.Run(
							'	(	Sub()

							'			For Each lo_BDCTran As iBDCTransaction In lo_BDCWSProfile.BDCTransactions

							'				If Me.co_RfcBDCTran.LoadTransactionData(BDCTransaction:= lo_BDCTran)

							'					If Me.co_RfcBDCTran.Invoke()
							'						ln_OK			+= 1
							'					Else
							'						ln_Failed += 1
							'					End If

							'				End If

							'				Dim lt_Msgs	As List(Of ixBDCMessage)	 = New List(Of ixBDCMessage)

							'				lt_Msgs.AddRange(Me.co_RfcBDCTran.Messages())
							'				Me.ct_Msgs.TryAdd(key	 := Me.co_RfcBDCTran.ExcelRow,
							'													value:= lt_Msgs)

							'				For Each ls_Msg As ixBDCMessage In Me.co_RfcBDCTran.Messages()

							'					Select Case ls_Msg.MessageType
							'							Case "S"	: lo_NotifyDTO.Type	= lo_NotifyDTO.TypeInfo
							'							Case "I"	: lo_NotifyDTO.Type	= lo_NotifyDTO.TypeInfo
							'							Case "E"	: lo_NotifyDTO.Type	= lo_NotifyDTO.TypeError
							'							Case "A"	: lo_NotifyDTO.Type	= lo_NotifyDTO.TypeError
							'							Case "W"	: lo_NotifyDTO.Type	= lo_NotifyDTO.TypeWarn
							'					End Select
							
							'					lo_NotifyDTO.Text				= ls_Msg.LongText
							'					lo_NotifyDTO.Timestamp	= Date.UtcNow

							'					Me.co_NotifyVM.SendMessage(Notification:= lo_NotifyDTO)

							'				Next

							'			Next

							'	End Sub)
							'	).ConfigureAwait(False)

							'If ln_Failed > 0
							'	Me.co_NotifyVM.SendMessage( String.Format("SAP GUI: Invoke/Run Failed({0}) ...", ln_Failed ), ToolTipIcon.Error)
							'End If
							'If ln_OK > 0
							'	Me.co_NotifyVM.SendMessage(String.Format("SAP GUI: Invoke/Run OK ({0}) ...", ln_OK ), ToolTipIcon.Info)
							'End If

						Else
							Me.co_NotifyVM.SendMessage("SAP GUI: Compile transactions Failed ...", ToolTipIcon.Error)
						End If

					Else
						Me.co_NotifyVM.SendMessage("SAP GUI: Load Data Failed ...", ToolTipIcon.Error)
					End If

					Catch ex As Exception
						Dim x = 1

				End Try

				Me.co_CT = Nothing

				Return lb_ret

			End Function
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

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors: Singleton"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Shared Function Create(ByVal ExcelHelper					As iExcelHelper,
																		ByVal CancelToken					As CancellationToken,
																		ByVal WSProfile						As iBDCWSProfile,
																		ByVal PLCBDCTransactions	As ixBDCTransactionPLC,
																		ByVal ProcessOptions			As ixProcessOptionsDTO,
																	  ByVal NotifyVM						As ixNotificationIconViewModel) _
															As ixProcessViaGUI

				Return New xProcessViaGUI(i_ExcelHelper		:= ExcelHelper,
																	i_CT						:= CancelToken,
																	i_WSProfile			:= WSProfile,
																	i_PLCBDCTran		:= PLCBDCTransactions,
																	i_ProcessOptions:= ProcessOptions,
																	i_NotifyVM			:= NotifyVM)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_ExcelHelper			As iExcelHelper,
											ByVal i_CT							As CancellationToken,
											ByVal i_WSProfile				As iBDCWSProfile,
											ByVal i_PLCBDCTran			As ixBDCTransactionPLC,
											ByVal i_ProcessOptions	As ixProcessOptionsDTO,
											ByVal i_NotifyVM				As ixNotificationIconViewModel)

				Me.co_ExcelHelper		= i_ExcelHelper
				Me.co_CT						= i_CT
				Me.co_BDCWSProfile	= i_WSProfile
				Me.co_PLCBDCTran		= i_PLCBDCTran
				Me.co_NotifyVM			= i_NotifyVM

				Me.ct_Msgs	= New ConcurrentDictionary(Of Integer, List(Of ixBDCMessage))

			End Sub

		#End Region

	End Class

	Public Interface ixBDCTransactionPLC

		Property MessageCount() As Integer

	End Interface

	Public Interface ixBDCMessage

	End Interface


End Namespace