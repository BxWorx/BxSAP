Imports System.Threading

Imports BxS.API.SAPFunctions.ZDTON

Imports SAPNCO	= SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON
	Friend Class BxS_ZDTONStats
								Implements iBxS_ZDTONStats

		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Invoke(ByVal DTO	As iBxS_ZDTON_DTO)	As Boolean _
													Implements iBxS_ZDTONStats.Invoke

				Dim lc_Ret	As String
				Dim lb_Ret	As Boolean	= False

				Try

						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.User			,	DTO.User				)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.ID				, DTO.SessionID		)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.RowTally	, DTO.Tally				)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.SAPTcode	, DTO.SAPTCode		)
			
						Me.co_RfcFnc.Value.Invoke(Me.co_Profile.SAPrfcDestination)

						lc_Ret = Me.co_RfcFnc.Value.GetValue(Me.co_Profile.RfcFncParmIndex.Status).ToString

						If lc_Ret.Equals("")
							lb_Ret	= True
						Else
							Dim X =1 
						End If
				
					Catch ex  As Exception _
						When _
							TypeOf ex Is SAPNCO.RfcAbapException                  OrElse    ' if a standard ABAP exception is raised during execution of function module RFC_PING 
							TypeOf ex Is SAPNCO.RfcAbapClassException             OrElse    ' if an ABAP class exception is raised during execution of function module RFC_PING 
							TypeOf ex Is SAPNCO.RfcInvalidStateException          OrElse    ' if an invalid state is encountered (such as using an invalid destination, for instance) 
							TypeOf ex Is SAPNCO.RfcResourceException              OrElse    ' if a required resource cannot be allocated (e.g., a client connection) due to resource restrictions 
							TypeOf ex Is SAPNCO.RfcCommunicationException         OrElse    ' if a communication error occurs 
							TypeOf ex Is SAPNCO.RfcCommunicationCanceledException

						'lo_Exception	= CType(ex, RfcAbapClassicException)

							' TO-DO: Log error

				End Try

				Return	lb_Ret

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Definitions"

			Private	co_Profile	As iBxS_ZDTONStats_Profile

			Private co_rfcFnc		As Lazy(Of SAPNCO.IRfcFunction) _
															= New Lazy(Of SAPNCO.IRfcFunction)(
																	Function()	Me.co_Profile.SAPrfcDestination.Repository.CreateFunction(co_Profile.SAPRfcFncName),
																	LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(ByVal profile	As iBxS_ZDTONStats_Profile)

				Me.co_Profile	= profile

			End Sub

		#End Region

	End Class

End Namespace