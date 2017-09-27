Imports System.Collections.Concurrent
Imports System.Threading
Imports BxS.API.SAPFunctions.BDCTransaction
Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.BDCRunner

	Friend Class BxS_BDCRun_Queue
								Implements iBxS_BDCRun_Queue

		#Region "Definitions"

			Private ct_Tasks		As List(Of Task(Of ConcurrentQueue(Of iBxS_BDCTran_Task)))
			Private ct_Results	As ConcurrentQueue(Of iBxS_BDCTran_Task)

			Private co_Queue		As BlockingCollection(Of iBxS_BDCTran_Task)
			Private co_CTS			As CancellationTokenSource
			Private cn_Timeout	As Integer

			Private	co_Progress	As IProgress(Of iBxS_BDCTran_Task)
			Private	co_BDCDest	As iBxS_BDCTran_Destination
			Private	co_CTU			As iBxS_BDC_CTUParameters

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property CompletedResults()	As List(Of iBxS_BDCTran_Task) _
																Implements iBxS_BDCRun_Queue.CompletedResults
				Get
					Return Me.ct_Results.ToList
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property Queue()	As BlockingCollection(Of iBxS_BDCTran_Task) _
																Implements iBxS_BDCRun_Queue.Queue
				Get
					Return Me.co_Queue
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property CancelToken()	As CancellationToken _
																Implements iBxS_BDCRun_Queue.CancelToken
				Get
					Return Me.co_CTS.Token
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function StartConsumers(ByVal noofConsumers As Integer) As Task(Of Integer) _
						Implements iBxS_BDCRun_Queue.StartConsumers

				' Fireup consumers
				'
				For ln_Index As Integer = 1 To noofConsumers

					Dim lo_Task As Task(Of ConcurrentQueue(Of iBxS_BDCTran_Task))

					lo_Task	=	Task.Factory.StartNew(Of Task(Of ConcurrentQueue(Of iBxS_BDCTran_Task)))(
											Async	Function()

												Dim lo_BDCTran	As iBxS_BDCTran_Caller
												Dim lo_Consumer	As iBxS_BDCRun_Consumer
												Dim ln_Count		As Integer

												lo_BDCTran	= New BxS_BDCTran_Caller(Me.co_BDCDest, co_CTU)

												lo_Consumer	= New BxS_BDCRun_Consumer(queue:=				Me.co_Queue,
																															progress:=		Me.co_Progress,
																															cancelToken:=	Me.co_CTS.Token,
																															BDCTran:=			lo_BDCTran)

												ln_Count = Await	lo_Consumer.StartAsync()

												If ln_Count.Equals(0)
													Return New ConcurrentQueue(Of iBxS_BDCTran_Task)
												Else
													Return lo_Consumer.CompletedTasks()
												End If

											End Function,	Me.co_CTS.Token,
																		TaskCreationOptions.PreferFairness,
																		TaskScheduler.Default).Unwrap()

					Me.ct_Tasks.Add(lo_Task)

				Next

				' Process each task as it completes
				'
				Dim lo_DoneTask As Task(Of ConcurrentQueue(Of iBxS_BDCTran_Task))

				While Me.ct_Tasks.Count > 0

					If Me.co_CTS.IsCancellationRequested
						Exit While
					End If

					lo_DoneTask = Await Task.WhenAny(Me.ct_Tasks).ConfigureAwait(continueOnCapturedContext:=False)

					Me.ct_Tasks.Remove(lo_DoneTask)

					Select Case lo_DoneTask.Status

						Case TaskStatus.RanToCompletion

							If Not IsNothing(lo_DoneTask.Result)
								For Each lo In lo_DoneTask.Result
									Me.ct_Results.Enqueue(lo)
								Next
							End If

						Case TaskStatus.Faulted
							'Handle(completed.Exception.InnerException)

					End Select

				End While

				Return Me.ct_Results.Count

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Function	Post(ByVal i_BDCTranTaskList	As List(Of iBxS_BDCTran_Task))	As Boolean _
									Implements iBxS_BDCRun_Queue.Post

				Dim lb_Ret	As Boolean	= True

				For Each lo_Profile In i_BDCTranTaskList

					If Not Me.co_Queue.TryAdd(lo_Profile, Me.cn_Timeout, Me.co_CTS.Token)
						lb_Ret = False
						Exit For
					End If

				Next
			
				Return lb_Ret
				
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Function	Post(ByVal i_BDCTranTask	As iBxS_BDCTran_Task)	As Boolean _
									Implements iBxS_BDCRun_Queue.Post

				Return Me.co_Queue.TryAdd(i_BDCTranTask, Me.cn_Timeout, Me.co_CTS.Token)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub Cancel() _
									Implements iBxS_BDCRun_Queue.Cancel
			
				If Me.co_CTS IsNot Nothing
					Me.co_CTS.Cancel()
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub Complete() _
									Implements iBxS_BDCRun_Queue.Complete

				Me.co_Queue.CompleteAdding()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(	ByRef	bdcDestination	As iBxS_BDCTran_Destination,
											ByRef ctuParameters		As iBxS_BDC_CTUParameters,
											ByRef progress				As IProgress(Of iBxS_BDCTran_Task))

				Me.co_BDCDest		= bdcDestination
				Me.co_Progress	= progress
				Me.co_CTU				= ctuParameters

				Me.co_Queue			= New BlockingCollection(Of iBxS_BDCTran_Task)
				Me.co_CTS				= New CancellationTokenSource
				Me.ct_Tasks			= New List(Of Task(Of ConcurrentQueue(Of iBxS_BDCTran_Task)))
				Me.ct_Results		= New ConcurrentQueue(Of iBxS_BDCTran_Task)

			End Sub

		#End Region

	End Class

End Namespace