Imports System.Collections.Concurrent
Imports System.Threading.Tasks
Imports System.Timers
Imports xSAPtorExcel.Utilities.MsgHub
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Services.DestinationMonitor

	Friend Class xSAPDestMonitorViewModel
								Implements ixSAPDestMonitorViewModel


		#Region "Process: View"


			Private Event ev_ToggleViewVisibility() _
											Implements ixSAPDestMonitorViewModel.ev_ToggleViewVisibility

			Private Event ev_RefreshView _
											Implements ixSAPDestMonitorViewModel.ev_RefreshView
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private cb_ViewActive	As Boolean
			Friend Property ViewActive()	As Boolean	Implements ixSAPDestMonitorViewModel.ViewActive
				Get
					Return Me.cb_ViewActive
				End Get
			  Set(value As Boolean)

					Me.cb_ViewActive	= value

					If Not Me.cb_ViewActive
						Me.SetTimer(i_RefreshRate:= 0)
					End If

			  End Set
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Property RefreshRate()	As UInteger	Implements ixSAPDestMonitorViewModel.RefreshRate
				Get
					Return Me.co_Options.RefreshRate
				End Get
			  Set(value As UInteger)

					Me.co_Options.RefreshRate	= value

					Me.co_MonitorModel.SaveOptions(Options:= Me.co_Options)
					Me.SetTimer(i_RefreshRate:= value)

			  End Set
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub ToggleView() _
									Implements ixSAPDestMonitorViewModel.ToggleView

				If Not Me.ViewActive

					Dim lo_MonitorView	As ixSAPConnectionMonitorView	= New xSAPConnectionMonitorView(Me)

				End If

				RaiseEvent ev_ToggleViewVisibility()	' Notifies any VIEWS listening (Should Only be 1)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub Refresh() _
									Implements ixSAPDestMonitorViewModel.Refresh

				Me.LoadViewDataAsync()
				
			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetMonitorList() _
												As List(Of ixSAPDestMonitorDTO) _
													Implements ixSAPDestMonitorViewModel.GetMonitorList
				
				Return Me.ct_ConnList

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Process: Model"

			Private WithEvents	co_MonitorModel	As ixSAPDestMonitorModel

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub EventHandler_MonitorModelChanged()

				Me.LoadViewDataAsync()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			Private co_Timer				As Timer
			Private co_Options			As ixSAPDestMonOptionsDTO
			Private ct_ConnList			As List(Of ixSAPDestMonitorDTO)
			Private	ct_EventTracker	As ConcurrentStack(Of Boolean)
			Private cb_BusyView			As Boolean
			Private	co_BusyLock			As New Object
			Private	co_SubStartStop						As	iSubscription(Of sMsgStartupShutdown)
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Event ev_ShutdownView() _
											Implements ixSAPDestMonitorViewModel.ev_ShutdownView
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub EventHandler_TimerLapsed(source As Object,
																					 e			As ElapsedEventArgs)

				Me.LoadViewDataAsync()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub EventHandler_GlobalShutdown()

				Me.SetTimer(i_RefreshRate:= 0)

				RemoveHandler	Me.co_MonitorModel.ev_Changed,
											AddressOf Me.EventHandler_MonitorModelChanged

				'RemoveHandler	Globals.ThisAddIn.ev_xSAPtorShutDown,
				'							AddressOf Me.EventHandler_GlobalShutdown
				
				Me.co_Timer.Close()
				Me.co_Timer.Dispose()

				RaiseEvent ev_ShutdownView()		' Notifies any VIEWS listening

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub SetTimer(ByVal i_RefreshRate As UInteger)

				Me.co_Timer.Stop()
				Me.co_Timer.Enabled	= False

				RemoveHandler	Me.co_Timer.Elapsed,
											AddressOf Me.EventHandler_TimerLapsed

				If i_RefreshRate > 0

					AddHandler	Me.co_Timer.Elapsed,
											AddressOf Me.EventHandler_TimerLapsed

					Me.co_Timer.Enabled		= True
					Me.co_Timer.AutoReset	= True
					Me.co_Timer.Interval	= i_RefreshRate * 1000
					Me.co_Timer.Start()

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub LoadViewDataAsync()

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

					Dim lt_List	As List(Of ixSAPDestMonitorDTO)
				
					lt_List	=	Await Task.Run(	Function()
					       	 	               	    Return Me.co_MonitorModel.GetMonitorData()
					       	 	               	End Function
																		).ConfigureAwait(continueOnCapturedContext:=False)

					Me.ct_ConnList.Clear()
					Me.ct_ConnList.AddRange(lt_List)
					
					Me.ct_EventTracker.Clear()

					RaiseEvent ev_RefreshView()

					SyncLock	Me.co_BusyLock

						Me.cb_BusyView	= False

						If Me.ct_EventTracker.Count = 0
							Exit Do
						End If

					End SyncLock

				Loop

			End Sub

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub MsgHndlr_StartupShutdown(ByVal _msg As sMsgStartupShutdown)

				If _msg.IsShutdown
					so_MsgHub.Value.Unsubscribe(Me.co_SubStartStop)
				Else
				End If

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Shared Function Create(ByVal MonitorModel	As ixSAPDestMonitorModel) _
															As ixSAPDestMonitorViewModel

				Return New xSAPDestMonitorViewModel(i_MonitorModel:= MonitorModel)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_MonitorModel	As ixSAPDestMonitorModel)

				Me.co_MonitorModel	= i_MonitorModel

				AddHandler	Me.co_MonitorModel.ev_Changed,
										AddressOf Me.EventHandler_MonitorModelChanged
					
				Me.co_Timer					= New Timer
				Me.co_Options				= Me.co_MonitorModel.FetchOptions()
				Me.ct_ConnList			= New List(Of ixSAPDestMonitorDTO)
				Me.ct_EventTracker	= New ConcurrentStack(Of Boolean)

				Me.co_SubStartStop	= so_MsgHub.Value.Subscribe(Of sMsgStartupShutdown)	(AddressOf	Me.MsgHndlr_StartupShutdown, True)

			End Sub

		#End Region

	End Class

End Namespace









