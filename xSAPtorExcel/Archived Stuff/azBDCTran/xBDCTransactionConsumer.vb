Imports System.Collections.Concurrent
Imports System.Threading
Imports xSAPtorNCO.API.SAP.System.Services
Imports xSAPtorNCO.API.Services.RfcFunction
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.BDCTransactionx

	Friend Class xBDCTransactionConsumer
								Implements ixBDCTransactionConsumer

		#Region "Definitions"

			Private co_BC					As BlockingCollection(Of ixBDCTransaction)
			Private co_CT					As CancellationToken
			Private co_RfcBDCTran	As ixNCOrfcBDCTransaction

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function Start() _
												As ConcurrentDictionary(Of Integer, List(Of ixBDCMessage)) _
													Implements ixBDCTransactionConsumer.Start

				Dim lt_Msgs	As New ConcurrentDictionary(Of Integer, List(Of ixBDCMessage))

				For Each lo_BDCTran As ixBDCTransaction In co_BC.GetConsumingEnumerable()

					If Me.co_CT.IsCancellationRequested
						Exit For
					End If

					If Me.co_RfcBDCTran.LoadTransactionData(BDCTransaction:= lo_BDCTran)

						If Me.co_CT.IsCancellationRequested
							Exit For
						Else

							If Me.co_RfcBDCTran.Invoke()
							Else
							End If

						End If

					End If

					Dim lt_TranMsgs	As List(Of ixBDCMessage)	= New List(Of ixBDCMessage)

					lt_TranMsgs.AddRange(Me.co_RfcBDCTran.Messages())

					lt_Msgs.TryAdd(key	 := Me.co_RfcBDCTran.ExcelRow,
														value:= lt_TranMsgs)

				Next

				Return lt_Msgs

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors: Singleton"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Shared Function Create(ByVal BCofBDCTran	As BlockingCollection(Of ixBDCTransaction),
																		ByVal RfcBDCTran	As ixNCOrfcBDCTransaction,
																		ByVal CancelToken	As CancellationToken) _
															As ixBDCTransactionConsumer

				Return New xBDCTransactionConsumer(i_BC				 := BCofBDCTran,
																					 i_RfcBDCTran:= RfcBDCTran,
																					 i_CT				 := CancelToken)

			End Function

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_BC					As BlockingCollection(Of ixBDCTransaction),
											ByVal i_RfcBDCTran	As ixNCOrfcBDCTransaction,
											ByVal i_CT					As CancellationToken)

				Me.co_BC					= i_BC
				Me.co_RfcBDCTran	= i_RfcBDCTran
				Me.co_CT					= i_CT

			End Sub

		#End Region

	End Class

End Namespace