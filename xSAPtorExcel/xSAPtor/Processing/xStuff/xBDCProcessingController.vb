Imports System.Threading
Imports System.Windows.Forms
Imports xSAPtorExcel.Main.Notification.Icon
Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.Services.UI
Imports xSAPtorNCO.API.Main
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.BDCProcessing

	Friend Class xBDCProcessingController
								Implements ixBDCProcessingController

		#Region "Process: BDC Overview"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetWBWSTree()	_
												As List(Of TreeNode) _
													Implements ixBDCProcessingController.GetWBWSTree
			
				Dim lo_ExcelHelper	As iExcelHelper									= ExcelHelper.GetInstance()
				Dim lt_List					As List(Of iExcelMDIWBookDTO)	= lo_ExcelHelper.GetWSHierarchy()
				Dim lt_Nodes				As List(Of TreeNode)						= New List(Of TreeNode)()

				For Each ls_WB As iExcelMDIWBookDTO In lt_list

					Dim lo_PNode As New TreeNode(ls_WB.WBName)

					For Each ls_WS As iExcelMDIWSheetDTO In ls_WB.WSList

						Dim lo_CNode As New TreeNode

						lo_CNode.Text	= ls_WS.WSName
						lo_CNode.Tag	= String.Concat("WB:",ls_WB.WBName,"/WS:",ls_WS.WSName)

						lo_PNode.Nodes.Add(lo_CNode)

					Next

					lt_Nodes.Add(lo_PNode)

				Next

				Return lt_Nodes

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetWorkSheetProfile(Optional ByVal WorkBookName   As String = "",
																					Optional ByVal WorkSheetName	As String = ""  ) _
												As iExcelWSProfileDTO _
													Implements ixBDCProcessingController.GetWorkSheetProfile

				Return Me.co_ExcelHelper.GetExcelWorkSheetProfile(WorkBookName	:= WorkBookName,
																										 WorkSheetName:= WorkSheetName)

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Process: Options"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend Function FetchProcessingOptions() _
			'									As iBDCProcessingOptionsDTO _
			'										Implements ixBDCProcessingController.FetchProcessingOptions

			'	Dim lo_Options	As iBDCProcessingOptionsDTO	= New BDCProcessingOptionsDTO

			'	'lo_Options.OptimiseUpload			= My.Settings.SAPSessionOptions_OptimizeUpload
			'	'lo_Options.SaveSelection			= My.Settings.SAPSessionOptions_SaveSelection
			'	lo_Options.ParallelProcesses	= My.Settings.BDCProcessingOptions_Parallel

			'	Return lo_Options

			'End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend Function SaveProcessingOptions(ByVal i_Options As iBDCProcessingOptionsDTO) _
			'									As Boolean _
			'										Implements ixBDCProcessingController.SaveProcessingOptions

			'	Dim lb_Ret  As Boolean = True

			'	Try

			'			'My.Settings.SAPSessionOptions_OptimizeUpload		= i_Options.OptimiseUpload
			'			'My.Settings.SAPSessionOptions_SaveSelection			= i_Options.SaveSelection
			'			My.Settings.BDCProcessingOptions_Parallel	= i_Options.ParallelProcesses

			'			My.Settings.Save()

			'		Catch ex As Exception
			'			lb_Ret  = False
							
			'	End Try

			'	Return lb_Ret

			'End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			Friend ReadOnly Property IsBusy()	As Boolean _
																					Implements ixBDCProcessingController.IsBusy 
				Get
					Return Me.cb_Busy
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Ribbon Event Handling"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub RibbonEventHandler(ByVal i_Tag As String) _
									Implements ixBDCProcessingController.RibbonEventHandler

				Select Case i_Tag
					Case "xtag_BDCOptions"	: Me.RibbonEventHandler_OptionsView()
					Case "xtag_BDCbgRFC"    : Me.RibbonEventHandler_WBOverviewView()
					Case "xtag_BDCGui"			: Me.RibbonEventHandler_SAPGUI
					Case "xtag_BDCTest"			: Me.RibbonEventHandler_TestMode
				End Select

			End Sub


			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_WBOverviewView()

				'If Me.co_BDCProcessWBOverviewView Is Nothing OrElse
				'	 Me.co_BDCProcessWBOverviewView.IsDisposed()

					 'Me.co_BDCProcessWBOverviewView	= xProcessSelectionView.Create(ProcessSelectionViewModel:= Me)

				'End If

				'Me.co_BDCProcessWBOverviewView.HandleVisibility()

			End Sub




			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_OptionsView()

				'If Me.co_BDCProcessOptionsView Is Nothing OrElse
				'	 Me.co_BDCProcessOptionsView.IsDisposed()

				'	 'Me.co_BDCProcessOptionsView	= xBDCProcessingOptionsView.Create(Controller:= Me)

				'End If

				'Me.co_BDCProcessOptionsView.HandleVisibility()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_SAPGUI()
			'Private Async Sub RibbonEventHandler_SAPGUI()

				If Me.co_ExcelHelper.IsInEditMode
					Me.co_CntrlNotify.SendMessage("Excel in EDIT mode, process not started..", ToolTipIcon.Error)
				Else

					'Dim lo_SAPGUI	As iBDCProcessGUI	= BDCProcessGUI.Create(i_ExcelHelper		  := Me.co_ExcelHelper,
					'																												i_ControllerNCO	  := Me.co_CntlrNCO,
					'																												i_ControllerNotify:= Me.co_CntrlNotify)

					'If Await lo_SAPGUI.ProcessAsync()
					'Else
					'End If

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_TestMode()

				If Me.co_GUIOptionsView Is Nothing OrElse
					 Me.co_GUIOptionsView.IsDisposed()

						'Dim lo_Cont As iBDCProcessRunnerController	= New BDCProcessRunnerController

					 'Me.co_GUIOptionsView	= xBDCProcessRunnerView.Create(Controller:= lo_Cont)

				End If

				Me.co_GUIOptionsView.HandleVisibility()

			End Sub

		#End Region



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
		#Region "Defintions"

			Private WithEvents	co_CntrlNotify	As ixNotificationIconViewModel

			Private co_CntlrNCO									As ixNCOController
			Private co_ExcelHelper							As iExcelHelper

			'Private co_BDCProcessWBOverviewView	As ixProcessSelectionView
			'Private co_BDCProcessOptionsView		As ixBDCProcessingOptionsView
			Private co_GUIOptionsView						As ixLogonOptionsView

			'Private co_GUIOptionsView						As ixBDCProcessGUIView

			Private cb_Busy											As Boolean

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors: Singleton"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub InjectControllers(ByVal i_ExcelHelper			As iExcelHelper,
																	 ByVal i_ControllerNCO		As ixNCOController,
																	 ByVal i_ControllerNotify	As ixNotificationIconViewModel) _
									Implements ixBDCProcessingController.InjectControllers

				Me.co_CntlrNCO		= i_ControllerNCO
				Me.co_ExcelHelper	= i_ExcelHelper
				Me.co_CntrlNotify	= i_ControllerNotify

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Shared ReadOnly _Instance As Lazy(Of ixBDCProcessingController) _
																= New Lazy(Of ixBDCProcessingController)(
																		Function()  New xBDCProcessingController(),
																								LazyThreadSafetyMode.ExecutionAndPublication )
			Public Shared ReadOnly Property GetInstance() As ixBDCProcessingController
				Get
					Return _Instance.Value
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New()
			End Sub

		#End Region

	End Class

End Namespace

