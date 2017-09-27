Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
'Imports xSAPtorExcel.Services.UI
Imports xSAPtorNCO.API.Destination
Imports xSAPtorNCO.API.Main
Imports xSAPtorNCO.API.SAP.System.Services
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.BDCTransactionx

	Friend Class xBDCTransactionPLC
								Implements ixBDCTransactionPLC

		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Definitions"

			Private co_BC							As BlockingCollection(Of ixBDCTransaction)
			Private co_CT							As CancellationToken
			Private co_NCOCntlr				As ixNCOController
			'Private co_PBar						As IProgress(Of iPBarData)
			'Private co_PBData					As iPBarData
			Private	co_NCODestProfile	As ixSAPDestinationProfile

			Private ct_Tasks	As List(Of Task(Of ConcurrentDictionary(Of Integer, List(Of ixBDCMessage))))
			Private ct_Result	As ConcurrentBag(Of ConcurrentDictionary(Of Integer, List(Of ixBDCMessage)) )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property MessageCount()	As Integer Implements ixBDCTransactionPLC.MessageCount
				Get
					Return Me.ct_Result.Count()
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property TryTakeMessages() As ConcurrentDictionary(Of Integer, List(Of ixBDCMessage)) _
																Implements ixBDCTransactionPLC.TryTakeMessages

				Get

					Dim lo_Profile As ConcurrentDictionary(Of Integer, List(Of ixBDCMessage))	= Nothing
					Me.ct_Result.TryTake(lo_Profile)
					Return lo_Profile

				End Get

			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub Complete() _
									Implements ixBDCTransactionPLC.Complete

				Me.co_BC.CompleteAdding()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Overloads Sub Post(ByVal i_TransactionList As List(Of ixBDCTransaction)) _
														Implements ixBDCTransactionPLC.Post

				For Each lo_Req As ixBDCTransaction In i_TransactionList
					Me.co_BC.Add(lo_Req)
				Next

				'Me.co_PBData.Total = Me.co_BC.Count

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Overloads Sub Post(ByVal i_Transaction As ixBDCTransaction) _
														Implements ixBDCTransactionPLC.Post

				Me.co_BC.Add(i_Transaction)
				'Me.co_PBData.Total = Me.co_BC.Count

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function StartupConsumersAsync(ByVal i_NoOfConsumers As Integer) _
															As Task(Of Integer) _
																implements ixBDCTransactionPLC.StartupConsumersAsync

				' Fireup consumers
				'
				For ln = 1 To i_NoOfConsumers

					Dim lo_Task As Task(Of ConcurrentDictionary(Of Integer, List(Of ixBDCMessage))) _
								= New Task(Of ConcurrentDictionary(Of Integer, List(Of ixBDCMessage))) _
									(	Function()

											Dim lo_RfcBDCTran	= Me.co_NCOCntlr.GetCallBDCTransaction()

											lo_RfcBDCTran.Configure(DestinationProfile	:= Me.co_NCODestProfile,
																							CancelToken					:= Me.co_CT,
																							UseCustomDestination:= True)

											Dim lo_Consumer As ixBDCTransactionConsumer	= xBDCTransactionConsumer.Create(BCofBDCTran:= Me.co_BC,
																																																	 CancelToken:= Me.co_CT,
																																																	 RfcBDCTran := lo_RfcBDCTran)

											Return lo_Consumer.Start()

										End Function,
										Me.co_CT,
										TaskCreationOptions.PreferFairness)

					Me.ct_Tasks.Add(lo_Task)
					lo_Task.Start()

				Next

				' Process each task as it completes
				'
				Dim lo_DoneTask As Task( Of ConcurrentDictionary(Of Integer, List(Of ixBDCMessage)) )

				While Me.ct_Tasks.Count > 0

					If Me.co_CT.IsCancellationRequested
						Exit While
					End If

					lo_DoneTask = Await Task.WhenAny(Me.ct_Tasks).ConfigureAwait(continueOnCapturedContext:=False)

					Me.ct_Tasks.Remove(lo_DoneTask)

					Select Case lo_DoneTask.Status

						Case TaskStatus.RanToCompletion

							If Not IsNothing(lo_DoneTask.Result)

								Me.ct_Result.Add(lo_DoneTask.Result)
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
			Friend Shared Function Create(ByVal NCOController		As ixNCOController,
																		ByVal NCODestProfile	As ixSAPDestinationProfile,
																		ByVal CancelToken			As CancellationToken) _
															As ixBDCTransactionPLC

				Return New xBDCTransactionPLC(i_NCOController	:= NCOController,
																			i_NCODestProfile:= NCODestProfile,
																			i_CancelToken		:= CancelToken)

',
'																			i_PBar					:= PBar
			',
			'															ByVal PBar						As IProgress(Of iPBarData)) _

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_NCOController		As ixNCOController,
											ByVal i_NCODestProfile	As ixSAPDestinationProfile,
											ByVal i_CancelToken			As CancellationToken)

',
'											ByVal i_PBar						As IProgress(Of iPBarData)
				Me.co_NCOCntlr				= i_NCOController
				Me.co_NCODestProfile	= i_NCODestProfile
				Me.co_CT							= i_CancelToken
				'Me.co_PBar						= i_PBar

				Me.co_BC			= New BlockingCollection(Of ixBDCTransaction)
				Me.ct_Result	= New ConcurrentBag(Of ConcurrentDictionary(Of Integer, List(Of ixBDCMessage)) )
				Me.ct_Tasks		= New List(Of Task(Of ConcurrentDictionary(Of Integer, List(Of ixBDCMessage))))

				'Me.co_PBData	= New PBarData

			End Sub

		#End Region

	End Class

End Namespace
