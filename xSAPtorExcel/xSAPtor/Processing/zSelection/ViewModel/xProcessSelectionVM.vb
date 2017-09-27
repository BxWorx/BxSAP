Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Imports xSAPtorExcel.Main.Process.Controller
Imports xSAPtorExcel.Services.UI
Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.Utilities.MsgHub
Imports xSAPtorExcel.Main.Process.Runner.ViaZDTON

Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Selection

	Friend Class xProcessSelectionVM
								Implements ixProcessSelectionVM

		#Region "Process: Selection View"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetWorkSheetProfile(ByVal WorkBookName	As String,
																					ByVal WorkSheetName	As String) _
												As iExcelWSProfileDTO _
													Implements ixProcessSelectionVM.GetWorkSheetProfile

				Return Me.co_Model.GetWorkSheetProfile(	WorkBookName := WorkBookName,
																								WorkSheetName:= WorkSheetName)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function SubmitTask(ByVal TaskRequest	As iBxS_BDCTran_Tran) _
												As Boolean _
													Implements ixProcessSelectionVM.SubmitTask

				Dim lb_Ret				As Boolean									= True
				'Dim lo_NotifyDTO	As iNotificationMessageDTO

			'Dim lc_RetSubmit	As Byte											= Me.co_RunnerModel.SubmitTask(TaskRequest:= TaskRequest)


			'lo_NotifyDTO = Me.co_NotifyDTO.ShallowCopy()
			'lo_NotifyDTO.Text = String.Concat("Task Submit: [", TaskRequest.ExcelWBName, "/", TaskRequest.ExcelWSName, "]: ")

			'Select Case lc_RetSubmit

			'    Case	Me.co_RunnerModel.SubmitFailed		:	lo_NotifyDTO.Text	= String.Concat(lo_NotifyDTO.Text, "Failed")
			'																							lo_NotifyDTO.Type	= lo_NotifyDTO.TypeError
			'																							lb_Ret						= False

			'		Case	Me.co_RunnerModel.SubmitStale			:	lo_NotifyDTO.Text	= String.Concat(lo_NotifyDTO.Text, "Stale")
			'																							lo_NotifyDTO.Type	= lo_NotifyDTO.TypeWarn

			'		Case	Me.co_RunnerModel.SubmitOK				:	lo_NotifyDTO.Text	= String.Concat(lo_NotifyDTO.Text, "Submitted")
			'		Case	Me.co_RunnerModel.SubmitRunning		:	lo_NotifyDTO.Text	= String.Concat(lo_NotifyDTO.Text, "Running")
			'		Case	Me.co_RunnerModel.SubmitRestarted	:	lo_NotifyDTO.Text	= String.Concat(lo_NotifyDTO.Text, "Complete, Re-started")
			'		Case	Me.co_RunnerModel.SubmitCompleted	: lo_NotifyDTO.Text	= String.Concat(lo_NotifyDTO.Text, "Complete, Not Re-started")

			'End Select

				'RaiseEvent ev_Notification(lo_NotifyDTO)

				Return lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend Property ViewActive()	As Boolean	Implements ixProcessSelectionVM.ViewActive

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			ReadOnly	Property	IsViewDisposed()	As	Boolean _
														Implements	ixProcessSelectionVM.IsViewDisposed
				Get
					Return	(IsNothing(Me.co_View) OrElse Me.co_View.IsDisposed)
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Definitions"

			Private co_Cntlr			As	iBxSProcessController
			'....................................................
			Private	WithEvents co_View		As xProcessSelectionView
			'....................................................
			Private	co_Model			As	ixProcessSelectionModel
			Private	co_Parent			As	IWin32Window
			Private	co_CTS				As	CancellationTokenSource
			Private	co_LckObj			As	Object
			'....................................................
			Private	co_SubStSt		As	iSubscription(Of sMsgStartupShutdown)
			Private	co_SubVCmd		As	iSubscription(Of sV2VMcmd)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	New(					ByVal	_controller		As iBxSProcessController	,
											Optional	ByVal	_parent				As IWin32Window	= Nothing		)

				Me.co_Cntlr		= _controller
				Me.co_Parent	= _parent
				'..................................................
				Me.co_Model		= Me.co_Cntlr.GetSelectionModel()
				'..................................................
				Me.co_LckObj	= New	Object


			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetOpenWBWSHierarchy() _
												As ixProcessSelectionDTO _
													Implements ixProcessSelectionVM.GetOpenWBWSHierarchy

				Return Me.co_Model.GetOpenWBWSItems()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub Show()	_
										Implements ixProcessSelectionVM.Show
			
				If Me.IsViewDisposed	Then	Me.PrepareView()
				'..................................................
				If Me.co_View.Visible
					If Me.co_View.WindowState = FormWindowState.Minimized
						Me.co_View.WindowState = FormWindowState.Normal
					Else
						Me.co_View.Hide()
					End If
				Else
					If Me.co_Parent Is Nothing
						Me.co_View.Show()
					Else
						Me.co_View.Show(Me.co_Parent)
					End If
				End If

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub mh_ViewCmds(ByVal _msg	As sV2VMcmd)

				Select Case	_msg.Command

					Case VVMCommands.CancelPost					: CancelTaskProcessing()
					Case VVMCommands.SubmitTaskZDTON		: ProcessViaZDTON(_msg.Payload)
					Case VVMCommands.SubmitTaskMsgs			: ProcessMsgs(_msg.Payload)
					Case VVMCommands.SubmitTaskRunner		: ProcessViaRunner(_msg.Payload)
					Case VVMCommands.RefreshTree				:	LoadWBWSTreeData()
					Case VVMCommands.CloseView					:	CloseView()

				End Select

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub ProcessMsgs(ByVal	_tasks	As Object)

				Dim	lt_TaskList		As List(Of ProcessViewTaskDTO)	= CType(_tasks, List(Of ProcessViewTaskDTO))

				If lt_TaskList.Count = 0	Then	Exit Sub
				'..................................................
				Dim lo_Runner			As iBxSRunnerViaZDTON				= Me.co_Cntlr.Create_BDCRunnerViaZDTON()
				Dim lo_ProgTask		As IProgress(Of iPBarData)	= New Progress(Of iPBarData)	(AddressOf Me.ev_ProgressHandler)

				Me.co_CTS	= New	CancellationTokenSource

				If Await lo_Runner.FetchMessagesAsync(lt_TaskList, lo_ProgTask, Me.co_CTS.Token)
				Else
				End If

				so_MsgHub.Value.Publish(New sVM2Vcmd(VVMCommands.Treechecked))

				Me.co_CTS	= Nothing

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub ProcessViaZDTON(ByVal	_tasks	As Object)


				'If so_CntlrMain.Value.DestinationSelected
				'Else
				'	so_MsgHub.Value.Publish( so_NotifyDTO.Value.ShallowCopy("Process Tasklist: No Destination selected") )
				'End If



				Dim	lt_TaskList		As List(Of ProcessViewTaskDTO)	= CType(_tasks, List(Of ProcessViewTaskDTO))

				If lt_TaskList.Count = 0	Then	Exit Sub
				'..................................................
				Dim lo_Runner			As iBxSRunnerViaZDTON				= Me.co_Cntlr.Create_BDCRunnerViaZDTON()
				Dim lo_ProgTask		As IProgress(Of iPBarData)	= New Progress(Of iPBarData)	(AddressOf Me.ev_ProgressHandler)
				Dim lo_ProgTran		As IProgress(Of iPBarData)	= New Progress(Of iPBarData)	(AddressOf Me.ev_ProgHndlrTran)

				Me.co_CTS	= New	CancellationTokenSource

				If Await lo_Runner.StartPostAsync(lt_TaskList, lo_ProgTask, lo_ProgTran, Me.co_CTS.Token)
				Else
				End If

				so_MsgHub.Value.Publish(New sVM2Vcmd(VVMCommands.Treechecked))

				Me.co_CTS	= Nothing

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub ProcessViaRunner(ByVal _tasks	As Object)

				Dim	lt_TaskList	As	New List(Of ProcessViewTaskDTO)	( CType(_tasks, List(Of ProcessViewTaskDTO)) )

				Me.co_CTS	= New	CancellationTokenSource


				Me.co_CTS	= Nothing

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub mh_StartupShutdown(ByVal _msg As sMsgStartupShutdown)

				If _msg.IsShutdown
					If Not Me.IsViewDisposed
						Me.co_View.Close()
					End If
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub PrepareView()

				Me.co_View	= New xProcessSelectionView()
				Me.LoadWBWSTreeData()
				Me.co_SubStSt	=	so_MsgHub.Value.Subscribe(Of sMsgStartupShutdown)	(AddressOf	Me.mh_StartupShutdown)
				Me.co_SubVCmd	=	so_MsgHub.Value.Subscribe(Of sV2VMcmd)								(AddressOf	Me.mh_ViewCmds)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub CloseView()

				so_MsgHub.Value.Unsubscribe(Me.co_SubVCmd)
				so_MsgHub.Value.Unsubscribe(Me.co_SubStSt)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub LoadWBWSTreeData()

				Dim lo_Cmd			=	New sVM2Vcmd(VVMCommands.RefreshTree)
				lo_Cmd.Payload	= Me.co_Model.GetOpenWBWSItems().Nodes

				so_MsgHub.Value.Publish(lo_Cmd)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub CancelTaskProcessing()

				If Not IsNothing(Me.co_CTS)
					SyncLock	Me.co_LckObj
						If Not Me.co_CTS.IsCancellationRequested
							Me.co_CTS.Cancel
						End If
					End SyncLock
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub ev_ProgressHandler(ByVal _dto	As iPBarData)

				Dim lo_Cmd			=	New sVM2Vcmd(VVMCommands.ProgressTask)
				lo_Cmd.Payload	= _dto

				so_MsgHub.Value.Publish(lo_Cmd)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub ev_ProgHndlrTran(ByVal _dto	As iPBarData)

				Dim lo_Cmd			=	New sVM2Vcmd(VVMCommands.ProgressTran)
				lo_Cmd.Payload	= _dto

				so_MsgHub.Value.Publish(lo_Cmd)

			End Sub

		#End Region

	End Class

End Namespace
