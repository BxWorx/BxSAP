Imports System.Collections.Concurrent
Imports System.Threading
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Utilities

		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		Friend Delegate Function ConsumerMaker(Of T)(	ByVal queue							As BlockingCollection(Of T)	,
																									ByVal progress					As IProgress(Of Integer)		,
																									ByVal cancelToken				As CancellationToken				,
																									ByVal progressinterval	As Integer										) _
																	As iBxS_Consumer(Of T)
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯

	Friend Class BxS_PipeLine(Of T)
								Implements iBxS_PipeLine(Of T)

		#Region "Definitions"

			Private ct_Tasks			As List(Of Task(Of iBxS_Consumer(Of T)))
			Private co_Queue			As BlockingCollection(Of T)
			Private co_CT					As CancellationToken
			Private cn_Timeout		As Integer
			Private cn_ProgInt 		As Integer

			Private co_ConsMaker		As ConsumerMaker(Of T)
			Private	co_Progress		As IProgress(Of Integer)

			Private	cn_NoOfCons		As Integer

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Property	NoOfConsumers	As Integer _
													Implements iBxS_PipeLine(Of T).NoOfConsumers
				Get
					Return	Me.cn_NoOfCons
				End Get
			  Set(value As Integer)
					If			value < 1
						Me.cn_NoOfCons	= 1
					ElseIf	value > 10
						Me.cn_NoOfCons	= 10
					Else
						Me.cn_NoOfCons	= value
					End If
			  End Set
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly	Property	Completed			As ConcurrentQueue(Of T)	Implements iBxS_PipeLine(Of T).Completed
			Friend ReadOnly	Property	InError				As ConcurrentQueue(Of T)	Implements iBxS_PipeLine(Of T).InError
			Friend ReadOnly	Property	NotStarted		As ConcurrentQueue(Of T)	Implements iBxS_PipeLine(Of T).NotStarted

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function	StartConsumers()	As Task(Of Integer) _
															Implements iBxS_PipeLine(Of T).StartConsumers

				For ln_Index = 1 To Me.NoOfConsumers

					If Me.co_CT.IsCancellationRequested
						Exit For
					End If
					'...............................................................
					Dim lo_Task As Task(Of iBxS_Consumer(Of T))	= Nothing

					lo_Task	= Task.Run(
											Function()

												Dim lo_Consumer	As iBxS_Consumer(Of T)
												
												lo_Consumer	= Me.co_ConsMaker(Me.co_Queue, Me.co_Progress, Me.co_CT, Me.cn_ProgInt)
												lo_Consumer.Start

												Return lo_Consumer

											End Function,
											Me.co_CT			)

					If lo_Task IsNot Nothing
						Me.ct_Tasks.Add(lo_Task)
					End If

				Next
				'...............................................................
				' Process each task as it completes
				'
				Dim lo_DoneTask As Task(Of iBxS_Consumer(Of T))

				While Me.ct_Tasks.Count > 0

					If Me.co_CT.IsCancellationRequested
						Exit While
					End If

					lo_DoneTask = Await Task.WhenAny(Me.ct_Tasks).ConfigureAwait(continueOnCapturedContext:=False)

					Me.ct_Tasks.Remove(lo_DoneTask)

					Select Case lo_DoneTask.Status

						Case TaskStatus.RanToCompletion

							If IsNothing(lo_DoneTask.Result)
							Else

								For Each lo In lo_DoneTask.Result.Completed
									Me.Completed.Enqueue(lo)
								Next
								For Each lo In lo_DoneTask.Result.InError
									Me.InError.Enqueue(lo)
								Next

							End If

						Case TaskStatus.Faulted
							'Handle(completed.Exception.InnerException)

					End Select

				End While

				Return ( Me.Completed.Count + Me.InError.Count + Me.NotStarted.Count )

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function	Post(ByVal taskList		As	List(Of T))		As Integer _
												Implements iBxS_PipeLine(Of T).Post

				Dim ln_Ret	As Integer	= 0

				For Each lo_task	In taskList

					If Me.co_Queue.TryAdd(lo_task, Me.cn_Timeout, Me.co_CT)
						ln_Ret	+= 1
					Else
						Me.NotStarted.Enqueue(lo_task)
					End If

				Next
			
				Return ln_Ret
				
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function Post(	ByVal	task	As T)		As Boolean _
									Implements iBxS_PipeLine(Of T).Post

				Return Me.co_Queue.TryAdd(task, Me.cn_Timeout, Me.co_CT)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	ProducingCompleted() _
										Implements iBxS_PipeLine(Of T).ProducingCompleted

				Me.co_Queue.CompleteAdding()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(						ByVal _consumermaker			As ConsumerMaker(Of T)		,
																ByVal	_progress						As IProgress(Of Integer)	,
																ByVal _progressinterval		As Integer								,
																ByVal _ct									As CancellationToken			,
											Optional	ByVal _noofconsumers			As Integer = 1							)

				Me.co_ConsMaker		= _consumermaker
				Me.co_Progress		= _progress
				Me.cn_ProgInt			= _progressinterval
				Me.co_CT					= _ct
				Me.NoOfConsumers	= _noofconsumers
				'..................................................
				Me.co_Queue			= New BlockingCollection(Of T)
				Me.ct_Tasks			= New List(Of Task(Of iBxS_Consumer(Of T)))
				Me.Completed		= New ConcurrentQueue(Of T)
				Me.InError			= New ConcurrentQueue(Of T)
				Me.NotStarted		= New ConcurrentQueue(Of T)

			End Sub

		#End Region

	End Class

End Namespace