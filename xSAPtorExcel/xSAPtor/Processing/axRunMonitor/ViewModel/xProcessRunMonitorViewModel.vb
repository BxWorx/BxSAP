Imports System.Collections.Concurrent
Imports System.Diagnostics
Imports System.Threading.Tasks
Imports xSAPtorExcel.Main.Process.Common
Imports xSAPtorExcel.Main.Process.Runner
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.RunMonitor

	Friend Class xProcessRunMonitorViewModel
								Implements ixProcessRunMonitorViewModel



			Friend Sub Reset() Implements ixProcessRunMonitorViewModel.Reset
				Me.co_ProcessRunnerModel.Reset()
			End Sub





		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Process: Runner View"

			Private Event ev_ToggleVisibility() _
											Implements ixProcessRunMonitorViewModel.ev_ToggleVisibility

			Friend Event ev_RefreshView() _
										Implements ixProcessRunMonitorViewModel.ev_RefreshView
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Property ViewActive()	As Boolean	Implements ixProcessRunMonitorViewModel.ViewActive
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub ToggleView() _
									Implements ixProcessRunMonitorViewModel.ToggleView

				If Not Me.ViewActive
					Dim lo_RunnerView	As ixProcessRunMonitorView	= xProcessRunMonitorView.Create(RunMonitorViewModel:= Me)
				End If

				RaiseEvent ev_ToggleVisibility()	' Notifies any VIEWS listening (Should Only be 1)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetTaskList()	As List(Of ixProcessRunMonitorDTO) _
																Implements ixProcessRunMonitorViewModel.GetTaskList

				Dim lt_RunMonDTO = New List(Of ixProcessRunMonitorDTO)

				For Each lo_Task As KeyValuePair(Of String, ixProcessTask) In Me.co_ProcessRunnerModel.Snapshot()

					Dim lo_Entry	As ixProcessRunMonitorDTO	= New xProcessRunMonitorDTO()

					lo_Entry.GUID					= lo_Task.Value.GUID
					lo_Entry.WBookName		= lo_Task.Value.WorkbookName
					lo_Entry.WSheetName		= lo_Task.Value.WorksheetName
					lo_Entry.TranCount		= lo_Task.Value.TranCount
					lo_Entry.TranComplete	= lo_Task.Value.TranComplete
					lo_Entry.PercComplete	= lo_Task.Value.PercComplete

					lt_RunMonDTO.Add(lo_Entry)

				Next

				Return lt_RunMonDTO

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Process: Model"

			Private WithEvents	co_ProcessRunnerModel			As ixProcessRunnerModel

			Private	ct_EventTracker	As ConcurrentStack(Of Boolean)
			Private cb_BusyView			As Boolean
			Private	co_BusyLock			As New Object
			Private cn_Lapse				As Integer	= 0500		' TO-DO: get from config
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub EventHandler_ProcessRunnerModelChangedAsync()

				Me.ct_EventTracker.Push(True)
				If Me.cb_BusyView	Then Return

				Do

					SyncLock	Me.co_BusyLock
						If Not Me.cb_BusyView
							Me.cb_BusyView	= True
						Else
							Exit Do
						End If
					End SyncLock

					Dim lb_Updated	As Boolean	= Await Task.Run(
						( Function()

								Dim lo_SW			As New Stopwatch

								Dim lb_Lapsed	As Boolean	= False
								Dim lb_Ret		As Boolean	= False

								If Me.cn_Lapse > 0 Then	lo_SW.Start

								Do

									Me.ct_EventTracker.Clear()
									lb_Ret	= True

									If lo_SW.ElapsedMilliseconds > cn_Lapse	Then	lb_Lapsed	= True

								Loop While	Me.ct_EventTracker.Count > 0 AndAlso
														Not lb_Lapsed

								Return lb_Ret

							End Function)
						).ConfigureAwait(False)

					If lb_Updated
						RaiseEvent ev_RefreshView()
					End If

					SyncLock	Me.co_BusyLock

						Me.cb_BusyView	= False

						If Me.ct_EventTracker.Count = 0
							Exit Do
						End If

					End SyncLock

				Loop

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			Private Event ev_Shutdown() _
											Implements ixProcessRunMonitorViewModel.ev_Shutdown
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Shutdown()

				RemoveHandler	Me.co_ProcessRunnerModel.ev_TaskChanged,
											AddressOf Me.EventHandler_ProcessRunnerModelChangedAsync

				RemoveHandler	Globals.ThisAddIn.ev_xSAPtorShutDown,
											AddressOf Me.Shutdown

				RaiseEvent ev_Shutdown()		' Notifies any VIEWS listening

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Shared Function Create(ByVal ProcessRunnerModel	As ixProcessRunnerModel) _
															As ixProcessRunMonitorViewModel

				Return New xProcessRunMonitorViewModel(i_ProcessRunnerModel:=	ProcessRunnerModel)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_ProcessRunnerModel	As ixProcessRunnerModel)

				Me.co_ProcessRunnerModel	= i_ProcessRunnerModel
				Me.ct_EventTracker				= New ConcurrentStack(Of Boolean)

				AddHandler	Me.co_ProcessRunnerModel.ev_TaskChanged,
										AddressOf Me.EventHandler_ProcessRunnerModelChangedAsync

				AddHandler	Globals.ThisAddIn.ev_xSAPtorShutDown,
										AddressOf Me.Shutdown

			End Sub

		#End Region

	End Class
	
End Namespace