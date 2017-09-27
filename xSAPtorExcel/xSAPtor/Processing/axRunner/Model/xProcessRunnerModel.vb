Imports System.Collections.Concurrent
Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks
Imports xSAPtorExcel.Main.Process.Common
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Runner

	Friend Class xProcessRunnerModel
								Implements ixProcessRunnerModel






			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function Reset() As Boolean Implements ixProcessRunnerModel.Reset

				Dim lb_Ret	As Boolean				= True

				Me.ct_TaskList.Clear()
				
				RaiseEvent ev_TaskChanged()

				Return lb_Ret

			End Function












		#Region "Definitions"

			Private	ct_ProcessQueue	As ConcurrentQueue(Of ixProcessTask)

			Private	ct_TaskList			As ConcurrentDictionary(Of String, ixProcessTask)
			Private	ct_UpdateQueue	As ConcurrentQueue(Of ixProcessRunnerUpdateDTO)
			Private cb_Busy					As Boolean
			Private	co_LockBusy			As Object

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Events"

			Friend Event ev_TaskChanged() _
										Implements ixProcessRunnerModel.ev_TaskChanged

			Friend Event ev_TaskSubmitted() _
										Implements ixProcessRunnerModel.ev_TaskSubmitted

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property SubmitOK()	As Byte _
																Implements ixProcessRunnerModel.SubmitOK
				Get
					Return 1
				End Get

			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property SubmitFailed()	As Byte _
																Implements ixProcessRunnerModel.SubmitFailed
				Get
					Return 2
				End Get

			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property SubmitRunning()	As Byte _
																Implements ixProcessRunnerModel.SubmitRunning
				Get
					Return 4
				End Get

			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property SubmitRestarted()	As Byte _
																Implements ixProcessRunnerModel.SubmitRestarted
				Get
					Return 8
				End Get

			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property SubmitCompleted()	As Byte _
																Implements ixProcessRunnerModel.SubmitCompleted
				Get
					Return 16
				End Get

			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property SubmitStale()	As Byte _
																Implements ixProcessRunnerModel.SubmitStale
				Get
					Return 32
				End Get

			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property Count()	As Integer _
																Implements ixProcessRunnerModel.Count
				Get
					Return Me.ct_TaskList.Count()
				End Get

			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property QueueCount()	As Integer _
																Implements ixProcessRunnerModel.QueueCount
				Get
					Return Me.ct_ProcessQueue.Count()
				End Get

			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function Dequeue(ByRef TaskOut As ixProcessTask) _
												As Boolean _
													Implements ixProcessRunnerModel.Dequeue

				Return Me.ct_ProcessQueue.TryDequeue(result:= TaskOut)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function Snapshot(Optional ByVal OnlyNew	As Boolean = False) _
												As List(Of KeyValuePair(Of String, ixProcessTask)) _
													Implements ixProcessRunnerModel.Snapshot

				If OnlyNew
					
					Dim lt_List	As New List(Of KeyValuePair(Of String, ixProcessTask))

					For Each lo_Entry In Me.ct_TaskList.Where( Function(lo) lo.Value.TranComplete = 0)
						lt_List.Add(lo_Entry)
					Next

					Return lt_List

				Else
					Return Me.ct_TaskList.ToList()
				End If

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function SubmitTask(					ByVal TaskRequest As ixProcessTask,
																 Optional	ByVal WithRestart	As Boolean = False) _
												As Byte _
													Implements ixProcessRunnerModel.SubmitTask

				Const	cz_loop		As Byte						= 255

				Dim lb_Ret			As Byte						= cz_loop
				Dim lo_TaskCur	As ixProcessTask	= Nothing
				Dim lo_TaskNew	As ixProcessTask	= Nothing
				
				Do

					If Me.ct_TaskList.TryGetValue(key	 := TaskRequest.GUID,
																				value:=	lo_TaskCur)

						If lo_TaskCur.Timestamp > TaskRequest.Timestamp
							lb_Ret	= Me.SubmitStale
						Else

							If lo_TaskCur.StatusDone
								If WithRestart

									lo_TaskNew						= TaskRequest.ShallowCopy()
									lo_TaskNew.Timestamp	= TaskRequest.Timestamp

									If Me.ct_TaskList.TryUpdate(key						 := lo_TaskCur.GUID,
																							newValue			 :=	lo_TaskNew,
																							comparisonValue:=	lo_TaskCur)

										lb_Ret	= Me.SubmitRestarted
										Me.ct_ProcessQueue.Enqueue(item:= lo_TaskNew)

									End If

								Else
									lb_Ret	= Me.SubmitCompleted
								End If
							Else
								lb_Ret	= Me.SubmitRunning
							End If

						End If

					Else

						lo_TaskNew	= TaskRequest.ShallowCopy()

						If Me.ct_TaskList.TryAdd(key	:= lo_TaskNew.GUID,
																		 value:= lo_TaskNew)

							lb_Ret	= Me.SubmitOK
							Me.ct_ProcessQueue.Enqueue(item:= lo_TaskNew)

						Else
							' Add failed so will just loop again and try to update next time
						End If

					End If

				Loop While lb_Ret	= cz_loop

				If lb_Ret = Me.SubmitOK					OrElse
					 lb_Ret = Me.SubmitRestarted

					RaiseEvent ev_TaskSubmitted()		' For: Process Runners
					RaiseEvent ev_TaskChanged()			' For: Process Monitors

				End If

				Return lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Sub UpdateTask(					ByVal TaskUpdate	As ixProcessRunnerUpdateDTO,
																	Optional	ByVal LapseLimit	As Integer	= 0) _
												Implements ixProcessRunnerModel.UpdateTask

				Me.ct_UpdateQueue.Enqueue(TaskUpdate)
				If Me.cb_Busy	Then Return

				Dim ln_LapseLimit	As Integer

				Do

					SyncLock	Me.co_LockBusy
						If Me.cb_Busy
							Exit Do
						Else
							Me.cb_Busy		= True
							ln_LapseLimit	= LapseLimit
						End If
					End SyncLock

					Dim lb_Updated	As Boolean	= Await Task.Run(
						( Function()

								Dim lo_SW				As New Stopwatch

								Dim lo_TaskUpd	As ixProcessRunnerUpdateDTO	= Nothing
								Dim lo_TaskCur	As ixProcessTask						= Nothing
								Dim lo_TaskNew	As ixProcessTask						= Nothing
								Dim lb_Ret			As Boolean									= False
								Dim lb_Lapsed		As Boolean									= False

								If ln_LapseLimit	> 0	Then	lo_SW.Start

								Do

									If Me.ct_UpdateQueue.TryDequeue(result:= lo_TaskUpd)

										If Me.ct_TaskList.TryGetValue(key	 := lo_TaskUpd.TaskID,
																									value:=	lo_TaskCur)

											If Not lo_TaskCur.StatusDone

												lo_TaskNew								= lo_TaskCur.ShallowCopy()
												lo_TaskNew.TranComplete	 += lo_TaskUpd.Count
												lo_TaskNew.PercComplete		= CInt( Math.Round( (( lo_TaskNew.TranComplete / lo_TaskNew.TranCount ) * 100),0 ) )
												lo_TaskNew.Timestamp			= Now()

												If lo_TaskNew.TranComplete >= lo_TaskNew.TranCount
													lo_TaskNew.StatusDone	= True
												End If

												If Me.ct_TaskList.TryUpdate(key						 := lo_TaskCur.GUID,
																										newValue			 :=	lo_TaskNew,
																										comparisonValue:=	lo_TaskCur)

													lb_Ret	= True

												End If

											End If

										End If

									End If

									If lo_SW.ElapsedMilliseconds > ln_LapseLimit	Then lb_Lapsed	= True

								Loop While  Me.ct_UpdateQueue.Count > 0		AndAlso
														Not lb_Lapsed

								Return lb_Ret

							End Function)
						).ConfigureAwait(False)

					If lb_Updated
						RaiseEvent ev_TaskChanged()
					End If

					SyncLock	Me.co_LockBusy

						Me.cb_Busy	= False

						If Me.ct_UpdateQueue.Count = 0
							Exit Do
						End If

					End SyncLock

				Loop

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors: Singleton"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Shared Function Create() _
															As ixProcessRunnerModel

				Return New xProcessRunnerModel()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New()

				Me.ct_TaskList			= New ConcurrentDictionary(Of String, ixProcessTask)
				Me.ct_UpdateQueue		= New	ConcurrentQueue(Of ixProcessRunnerUpdateDTO)
				Me.ct_ProcessQueue	= New	ConcurrentQueue(Of ixProcessTask)

				Me.cb_Busy			= False
				Me.co_LockBusy	= New Object

			End Sub

		#End Region

	End Class

End Namespace