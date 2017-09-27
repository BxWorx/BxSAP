Imports System.Threading
Imports SAPNCO = SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.Servertime

	Friend Class BxS_SAPServerTime
								Implements iBxS_SAPServerTime

		#Region "Definitions"

			Private Const cx_SAPFncName	As String	=	"SXMS_GET_TIME_STAMP_APP_SERVER"
			'............................................................
			Private co_RfcDest		As SAPNCO.RfcCustomDestination

			Private co_rfcFnc			As Lazy(Of SAPNCO.IRfcFunction) _
															= New Lazy(Of SAPNCO.IRfcFunction)(
																	Function()	Me.co_RfcDest.Repository.CreateFunction(cx_SAPFncName),
																	LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_FncParmIdx	As Lazy(Of ParameterIndex) _
															= New Lazy(Of ParameterIndex)(
																	Function()  New ParameterIndex(Me.co_rfcFnc.Value.Metadata),
																	LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_CT					As CancellationToken

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			ReadOnly Property ServerTime()	As DateTime	_
													Implements iBxS_SAPServerTime.ServerTime
				Get

					Dim	ld_DateTime	As DateTime	= Nothing

					Try

							Dim lc_DteTme	As String

							Me.co_rfcFnc.Value.Invoke(Me.co_RfcDest)

							lc_DteTme		= Me.co_rfcFnc.Value.GetValue(Me.co_FncParmIdx.Value.Time).ToString

							ld_DateTime	= New DateTime(	CInt(Strings.Mid(lc_DteTme,01,4)),
																					CInt(Strings.Mid(lc_DteTme,05,2)),
																					CInt(Strings.Mid(lc_DteTme,07,2)),
																					CInt(Strings.Mid(lc_DteTme,09,2)),
																					CInt(Strings.Mid(lc_DteTme,11,2)),
																					CInt(Strings.Mid(lc_DteTme,13,2)),
																					CInt(Strings.Mid(lc_DteTme,16,3))
																				)


						Catch ex  As SAPnco.RfcAbapException
							ld_DateTime	= Now()

						Catch ex1 As SAPnco.RfcAbapRuntimeException
							ld_DateTime	= Now()

					End Try

					Return ld_DateTime

				End Get

			End Property
		
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Friend Async Function ServerTimeAsync() As Task(Of DateTime) _
															Implements iBxS_SAPServerTime.ServerTimeAsync

				Dim lo_Res As DateTime	= Nothing

				Try

					lo_Res = Await Task.Run( Function()

																			Dim	ld_DateTime	As DateTime	= Nothing

																			Me.co_rfcFnc.Value.Invoke(Me.co_RfcDest)
																			Return ld_DateTime

																		End Function, _
																		Me.co_CT )

					Catch ex As Exception

				End Try

				Return lo_Res

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private Methods"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(ByRef destination	As SAPNCO.RfcCustomDestination,
										 ByRef cancelToken	As CancellationToken)

				Me.co_RfcDest	= destination
				Me.co_CT			= cancelToken

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		Private Class ParameterIndex
			ReadOnly Property Time	As Integer

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Sub New(ByRef fncMetaData	As SAPNCO.RfcFunctionMetadata)

				Const lx_TimeStmp	As String	= "TIME_STAMP"

				Me.Time	= fncMetaData.TryNameToIndex(lx_TimeStmp)

			End Sub

		End Class

	End Class

End Namespace