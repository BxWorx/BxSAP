Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
Imports xSAPtorExcel.Main.BDCProcessing
Imports xSAPtorExcel.Main.Process.Common
Imports xSAPtorExcel.Main.Process.Options
Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.Services.UI
Imports xSAPtorNCO.API.Main
Imports xSAPtorNCO.API.SAP.System.Services
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Runner

	Friend Class xProcessRunnerPLC
								Implements ixProcessRunnerPLC

		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Definitions"

			Private co_ExcelHelper	As iExcelHelper
			Private co_NCO					As ixNCOController
			Private co_BC						As BlockingCollection(Of ixProcessTask)
			Private co_CTS					As CancellationTokenSource
			Private co_CT						As CancellationToken
			Private co_PBar					As IProgress(Of iPBarData)
			Private co_PBData				As iPBarData = New PBarData

			Private ct_Tasks				As List( Of Task(Of List(Of iBDCWSProfile)) )
			Private ct_Result				As ConcurrentBag(Of iBDCWSProfile)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property WorksheetCount()	As Integer	Implements ixProcessRunnerPLC.WorksheetCount
				Get
					Return Me.ct_Result.Count
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property TryTakeProfile()	As iBDCWSProfile	Implements ixProcessRunnerPLC.TryTakeProfile
				Get

					Dim lo_WSProfile	As iBDCWSProfile = Nothing
					Me.ct_Result.TryTake(lo_WSProfile)
					Return lo_WSProfile

				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub CancelProcessing() _
									Implements ixProcessRunnerPLC.CancelProcessing

				If Me.co_CTS IsNot Nothing
					Me.co_CTS.Cancel()
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub Complete() _
									Implements ixProcessRunnerPLC.Complete

				Me.co_BC.CompleteAdding()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Overloads Sub Post(ByVal i_Requests As List(Of ixProcessTask)) _
														Implements ixProcessRunnerPLC.Post

				For Each lo_Req As ixProcessTask In i_Requests
					Me.co_BC.Add(item:= lo_Req.ShallowCopy())
				Next

				Me.co_PBData.Total = Me.co_BC.Count

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Overloads Sub Post(ByVal i_Request	As ixProcessTask) _
														Implements ixProcessRunnerPLC.Post

				Me.co_BC.Add(item:= i_Request.ShallowCopy())
				Me.co_PBData.Total = Me.co_BC.Count

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function StartupConsumersAsync(ByVal ProcessOptions	As ixProcessOptionsDTO) _
															As Task(Of Integer) _
																implements ixProcessRunnerPLC.StartupConsumersAsync

				Me.ct_Tasks	= New List(Of Task(Of List(Of iBDCWSProfile)))

				' Fire up Consumers
				'
				For ln_Loop As UInteger = 1 To ProcessOptions.ParallelProcessesWB

					Dim lo_Task As Task(Of List(Of iBDCWSProfile)) _
								= New Task(Of List(Of iBDCWSProfile)) _
										( Function()

												Dim lo_BDCTranPLC	As ixBDCTransactionPLC	= Me.co_NCO.GetBDCTransactionPLC()

												If lo_BDCTranPLC IsNot Nothing

													Dim lo_Consumer As ixProcessRunnerConsumer _
																= xProcessRunnerConsumer.Create(BCProcessTasks	 := Me.co_BC,
																																BDCTransactionPLC:= lo_BDCTranPLC,
																																ExcelHelper			 := Me.co_ExcelHelper)

													If lo_Consumer.StartupAsync(CancelToken		:= Me.co_CT,
																											ProcessOptions:= ProcessOptions).Result() > 0

														Return lo_Consumer.WSProcessed()

													Else
														Return Nothing
													End If

												Else
													Return Nothing
												End If

											End Function,
											Me.co_CT,
											TaskCreationOptions.PreferFairness)

					Me.ct_Tasks.Add(lo_Task)
					lo_Task.Start()

				Next

				' Process each task as they complete
				'
				Dim lo_DoneTask As Task(Of List(Of iBDCWSProfile))

				While Me.ct_Tasks.Count > 0

					If Me.co_CT.IsCancellationRequested
						Exit While
					End If

					lo_DoneTask = Await Task.WhenAny(Me.ct_Tasks).ConfigureAwait(continueOnCapturedContext:=False)

					Me.ct_Tasks.Remove(lo_DoneTask)

					Select Case lo_DoneTask.Status

						Case TaskStatus.RanToCompletion

							If Not IsNothing(lo_DoneTask.Result)

								For Each lo_WSProfile As iBDCWSProfile In lo_DoneTask.Result
									Me.ct_Result.Add(lo_WSProfile)
								Next

								'Me.co_PBData.Complete += lo_DoneTask.Result.Count
								'Me.co_PBar.Report(Me.co_PBData)
							End If

						Case TaskStatus.Faulted
							'Handle(completed.Exception.InnerException)

					End Select

				End While

				Return Me.ct_Result.Count

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Shared Function Create(ByVal NCOController	As ixNCOController,
																		ByVal ExcelHelper		As iExcelHelper,
																		ByVal CancelToken		As CancellationToken,
																		ByVal ProgressBar		As IProgress(Of iPBarData)) _
															As ixProcessRunnerPLC

				Return New xProcessRunnerPLC(i_NCOController:=NCOController,
																		 i_ExcelHelper	:= ExcelHelper,
																		 i_CancelToken	:=CancelToken,
																		 i_PBar					:=ProgressBar)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_NCOController	As ixNCOController,
											ByVal i_ExcelHelper		As iExcelHelper,
											ByVal i_CancelToken		As CancellationToken,
											ByVal i_PBar					As IProgress(Of iPBarData))

				Me.co_NCO					= i_NCOController
				Me.co_CT					= i_CancelToken
				Me.co_PBar				= i_PBar
				Me.co_ExcelHelper	= i_ExcelHelper

				Me.co_BC			= New BlockingCollection(Of ixProcessTask)
				Me.ct_Result	= New ConcurrentBag(Of iBDCWSProfile)

			End Sub

		#End Region

	End Class

End Namespace
