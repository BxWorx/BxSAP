Imports System.Collections.Concurrent
Imports System.Threading
Imports BxS.API.SAPFunctions.BDCTransaction
Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.BDCRunner
	Friend Class BxS_BDCRun_Consumer
								Implements iBxS_BDCRun_Consumer

		#Region "Definitions"

			Private ct_Results	As ConcurrentQueue(Of iBxS_BDCTran_Tran)
			Private co_Queue		As BlockingCollection(Of iBxS_BDCTran_Tran)
			Private co_CT				As CancellationToken
			Private co_Progress	As IProgress(Of iBxS_BDCTran_Tran)
			Private co_BDCTran	As iBxS_BDCTran_Caller

			Private cc_GUID			As Guid

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			ReadOnly Property CompletedTasks()	As ConcurrentQueue(Of iBxS_BDCTran_Tran) _
													Implements iBxS_BDCRun_Consumer.CompletedTasks
				Get
					Return Me.ct_Results
				End Get

			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function StartAsync()	As Task(Of Integer) _
									Implements iBxS_BDCRun_Consumer.StartAsync

				Dim ln_Ret	As Integer	= 0

				Try

						For Each lo_BDCTask	As iBxS_BDCTran_Tran	In Me.co_Queue.GetConsumingEnumerable(Me.co_CT)

							lo_BDCTask.info_GUIDCons	= Me.cc_GUID

							Dim lo_Res As iBxS_BDCTran_Tran	= Await Task.Run( Function()

																																	Me.co_BDCTran.Invoke(lo_BDCTask)
																																	Return lo_BDCTask

																																End Function, _
																																Me.co_CT )

							Me.ct_Results.Enqueue(lo_Res)
							ln_Ret += 1
							'...............................................................
							Me.co_Progress.Report(lo_Res)

						Next

					Catch ex As Exception

				End Try

				Return ln_Ret

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(	ByRef queue				As BlockingCollection(Of iBxS_BDCTran_Tran),
											ByRef progress		As IProgress(Of iBxS_BDCTran_Tran),
											ByRef cancelToken	As CancellationToken,
											ByRef BDCTran			As iBxS_BDCTran_Caller)

				Me.ct_Results		= New ConcurrentQueue(Of iBxS_BDCTran_Tran)
				Me.cc_GUID			= Guid.NewGuid()

				Me.co_Queue			= queue
				Me.co_CT				= cancelToken
				Me.co_Progress	= progress
				Me.co_BDCTran		= BDCTran

			End Sub

		#End Region

	End Class

End Namespace