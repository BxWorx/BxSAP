Imports System.Threading

Imports SAPNCO	= SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON
	Friend Class BxS_ZDTONMsgs
								Implements iBxS_ZDTONMsgs

		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Invoke(	ByVal user	As String	,
																ByVal id		As String		)	As List(Of iBxS_ZDTONMsgs_DTO) _
													Implements iBxS_ZDTONMsgs.Invoke

				Dim lc_Ret		As	String
				Dim lo_Msgs		As	SAPNCO.IRfcTable
				Dim lo_Row		As	SAPNCO.IRfcStructure					
				Dim lt_Msgs		As	List(Of iBxS_ZDTONMsgs_DTO)	= New List(Of iBxS_ZDTONMsgs_DTO)

				Try

						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.User	, user	)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.ID		, id		)

						Me.co_RfcFnc.Value.Invoke(Me.co_Profile.SAPrfcDestination)
						lc_Ret = Me.co_RfcFnc.Value.GetValue(Me.co_Profile.RfcFncParmIndex.Status).ToString

						If lc_Ret.Length.Equals(0)

							lo_Msgs	= Me.co_rfcFnc.Value.GetTable(Me.co_Profile.RfcFncParmIndex.MsgTable)
							lo_Row	= lo_Msgs.Metadata.LineType.CreateStructure()

							For Each lo_Row	In lo_Msgs

								Dim lo_Msg	= Me.co_Profile.CreateDTO()
							
								lo_Msg.Rowno		= CInt(lo_Row.GetValue(0))
								lo_Msg.Status		= CStr(lo_Row.GetValue(1))
								lo_Msg.Message	= CStr(lo_Row.GetValue(2))
								lo_Msg.ExcelRow	= CInt(lo_Row.GetValue(3))
								lo_Msg.MsgDate	= CStr(lo_Row.GetValue(4))
								lo_Msg.MsgTime	= CStr(lo_Row.GetValue(5))

								lt_Msgs.Add(lo_Msg)

							Next

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

				Return	lt_Msgs

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Definitions"

			Private	co_Profile	As iBxS_ZDTONMsgs_Profile

			Private co_rfcFnc		As Lazy(Of SAPNCO.IRfcFunction) _
															= New Lazy(Of SAPNCO.IRfcFunction)(
																	Function()	Me.co_Profile.SAPrfcDestination.Repository.CreateFunction(co_Profile.SAPRfcFncName),
																	LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(ByVal profile	As iBxS_ZDTONMsgs_Profile)

				Me.co_Profile	= profile

			End Sub

		#End Region

	End Class

End Namespace