Imports System.Threading

Imports SAPNCO	= SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON
	Friend Class BxS_ZDTONData
								Implements iBxS_ZDTONData

		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Invoke(	ByVal DTO	As iBxS_ZDTONData_DTO	)	As Boolean _
													Implements iBxS_ZDTONData.Invoke

				Dim lc_Ret	As String								= ""
				Dim lb_Ret	As Boolean							= True
				Dim ln_Cnt	As Integer							= 0
				Dim ls_Row	As SAPNCO.IRfcStructure	= Nothing

				Try

							Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.User			, DTO.User			)
							Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.ID				,	DTO.SessionID			)
							Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.RowNo			, DTO.RowNo)
							Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.ExcelRow	,	DTO.ExcelRow )

							Me.ct_Data.Value.Clear()

							For Each lc In	DTO.DataValues

								ls_Row	= CType( Me.cs_Row.Value.Clone(), SAPNCO.IRfcStructure)

								ls_Row.SetValue("COLUMNNO"	, lc.Key)
								ls_Row.SetValue("FIELDVALUE", lc.Value)

								Me.ct_Data.Value.Append(ls_Row)

							Next
			
							Me.co_RfcFnc.Value.Invoke(Me.co_Profile.SAPrfcDestination)

							lc_Ret = Me.co_RfcFnc.Value.GetValue(Me.co_Profile.RfcFncParmIndex.Status).ToString

							If lc_Ret.Equals("")
								ln_Cnt += 1
							Else
								lb_Ret	= False
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

			Private	co_Profile	As iBxS_ZDTONData_Profile
			'........................................................................
			Private co_rfcFnc		As	Lazy(Of SAPNCO.IRfcFunction) _
																= New Lazy(Of SAPNCO.IRfcFunction)(
																		Function()	Me.co_Profile.SAPrfcDestination.Repository.CreateFunction(co_Profile.SAPRfcFncName),
																		LazyThreadSafetyMode.ExecutionAndPublication )

			Private	ct_Data			As	Lazy(Of SAPNCO.IRfcTable) _
																= New Lazy(Of SAPNCO.IRfcTable)(
																		Function()	Me.co_rfcFnc.Value.GetTable(Me.co_Profile.RfcFncParmIndex.Values),
																		LazyThreadSafetyMode.ExecutionAndPublication )

			Private	cs_Row 			As	Lazy(Of SAPNCO.IRfcStructure) _
																= New Lazy(Of SAPNCO.IRfcStructure)(
																		Function()	Me.ct_Data.Value.Metadata.LineType.CreateStructure(),
																		LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(ByVal profile	As iBxS_ZDTONData_Profile)

				Me.co_Profile	= profile

			End Sub

		#End Region

	End Class

End Namespace