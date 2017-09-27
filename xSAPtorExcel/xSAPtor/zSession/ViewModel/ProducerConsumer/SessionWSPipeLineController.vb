Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
Imports xSAPtorExcel.Services.UI
Imports BxS.API.Main
Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session

	Friend Class SessionWSPipeLineController
								Implements iSessionWSPipeLineController

		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Definitions"

			Private	co_CntlrMain	As iBxSMainController
			Private co_BC					As BlockingCollection(Of iSessionRequestDTO)
			Private co_CT					As CancellationToken
			Private co_NCO				As ixNCOController
			Private co_PBar				As IProgress(Of iPBarData)
			Private co_PBData			As iPBarData	= New PBarData

			Private	ct_Tasks			As List(Of Task(Of List(Of iBxSBDCSession_Profile)))
			Private ct_Result			As ConcurrentBag(Of iBxSBDCSession_Profile)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub Complete() _
									Implements iSessionWSPipeLineController.Complete

				Me.co_BC.CompleteAdding()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub Post(ByVal i_List As List(Of iSessionRequestDTO)) _
									Implements iSessionWSPipeLineController.Post

				For Each lo_Req As iSessionRequestDTO In i_List
					Me.co_BC.Add(lo_Req)
				Next

				Me.co_PBData.Total	= Me.co_BC.Count

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function StartupConsumersAsync(ByVal i_NoOfConsumers	As Integer) _
															As Task(Of Integer) _
																implements iSessionWSPipeLineController.StartupConsumersAsync

				' Fireup consumers
				'
				For ln	= 1 To i_NoOfConsumers

					Dim lo_Task As Task(Of List(Of iBxSBDCSession_Profile))

					lo_Task = Task.Factory.StartNew(Of List(Of iBxSBDCSession_Profile))(
								Function()

									Dim lo_Consumer As iSessionRequestConsumer _
												=	New SessionRequestConsumer(	i_CntlrMain	:=	Me.co_CntlrMain,
																											i_BC				:=	Me.co_BC,
																											i_Controller:=	Me.co_NCO,
																											i_CT				:=	Me.co_CT)

									Dim lt_List	As List(Of iBxSBDCSession_Profile)	=	lo_Consumer.Start()

									Return lt_List

								End Function, 
									Me.co_CT,
									TaskCreationOptions.PreferFairness,
									TaskScheduler.Default)

					Me.ct_Tasks.Add(lo_Task)

				Next

				' Process each task as it completes
				'
				Dim lo_DoneTask	As Task(Of List(Of iBxSBDCSession_Profile)) 

				While Me.ct_Tasks.Count > 0

					If Me.co_CT.IsCancellationRequested
						Exit While
					End If

					lo_DoneTask = Await Task.WhenAny(Me.ct_Tasks).ConfigureAwait(continueOnCapturedContext:= False)

					Me.ct_Tasks.Remove(lo_DoneTask)

					Select Case lo_DoneTask.Status

						Case TaskStatus.RanToCompletion

							If Not IsNothing(lo_DoneTask.Result)

								For Each lx As iBxSBDCSession_Profile In lo_DoneTask.Result
									Me.ct_Result.Add(lx)
								Next

								Me.co_PBData.Complete	+= lo_DoneTask.Result.Count
								Me.co_PBar.Report(Me.co_PBData)

							End If

						Case TaskStatus.Faulted
							'Handle(completed.Exception.InnerException)

					End Select

				End While

				Return Me.ct_Result.Count

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function TryTakeProfile(ByRef profile	As iBxSBDCSession_Profile) As Boolean _
																Implements iSessionWSPipeLineController.TryTakeProfile

				Try

						Return Me.ct_Result.TryTake(Profile)

					Catch ex As Exception
						Return False

				End Try

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(	ByVal	i_CntlrMain			As iBxSMainController,
											ByVal i_NCOController	As ixNCOController,
											ByVal i_CancelToken		As CancellationToken,
											ByVal i_PBar					As IProgress(Of iPBarData))

				Me.co_CntlrMain	= i_CntlrMain
				Me.co_NCO				= i_NCOController
				Me.co_CT				= i_CancelToken
				Me.co_PBar			= i_PBar

				Me.co_BC			= New BlockingCollection(Of iSessionRequestDTO)()
				Me.ct_Tasks		= New List(Of Task(Of List(Of iBxSBDCSession_Profile)))()
				Me.ct_Result	= New ConcurrentBag(Of iBxSBDCSession_Profile)()

			End Sub

		#End Region

	End Class

End Namespace
