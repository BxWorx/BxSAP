Imports System.Threading
Imports BxS.API.SAPFunctions.DDIC
Imports SAPNCO	= SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.DDIC

	Friend Class BxS_DDICInfo
								Implements IBxS_DDICInfo

		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Async	Function	GetDDICInfoAsync(	ByVal _dto					As	IBxS_DDICInfo_DTO	,
																								ByVal _canceltoken	As	CancellationToken		)		As Task(Of Boolean) _
																Implements IBxS_DDICInfo.GetDDICInfoAsync

				Dim lt_Def	As	SAPNCO.IRfcTable
				Dim ls_Row	As	SAPNCO.IRfcStructure					
				Dim lb_Ret	As	Boolean	= True

				For Each lo In _dto.TableList

					If _canceltoken.IsCancellationRequested
						lb_Ret	=False
						Exit For
					End If
					'................................................
					Try

						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.TableName	, lo )

						Await Task.Run( Sub() co_rfcFnc.Value.Invoke(co_Profile.SAPrfcDestination), _canceltoken )

						If _canceltoken.IsCancellationRequested
							lb_Ret	= False
							Exit For
						End If

						lt_Def	= Me.co_rfcFnc.Value.GetTable(Me.co_Profile.RfcFncParmIndex.StructTable)
						ls_Row	= lt_Def.Metadata.LineType.CreateStructure()

						If Not lt_Def.Count.Equals(0)
							If _dto.TableDesc.ContainsKey(lo)

								Dim lt_Desc	= _dto.TableDesc.Item(lo)
								
								lt_Desc.Clear()

								For Each ls_Row	In lt_Def

									lt_Desc.Add(	ls_Row.GetValue("FIELDNAME").ToString	,
																ls_Row.GetValue("FIELDTEXT").ToString		)

								Next

							End If
						End If

						Catch ex  As Exception _
							When _
								TypeOf ex Is SAPNCO.RfcAbapException                  OrElse    ' if a standard ABAP exception is raised during execution of function module RFC_PING 
								TypeOf ex Is SAPNCO.RfcAbapClassException             OrElse    ' if an ABAP class exception is raised during execution of function module RFC_PING 
								TypeOf ex Is SAPNCO.RfcInvalidStateException          OrElse    ' if an invalid state is encountered (such as using an invalid destination, for instance) 
								TypeOf ex Is SAPNCO.RfcResourceException              OrElse    ' if a required resource cannot be allocated (e.g., a client connection) due to resource restrictions 
								TypeOf ex Is SAPNCO.RfcCommunicationException         OrElse    ' if a communication error occurs 
								TypeOf ex Is SAPNCO.RfcCommunicationCanceledException

							lb_Ret	= False

					End Try

				Next
				'..................................................
				Return	lb_Ret				

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Definitions"

			Private	co_Profile	As IBxS_DDICInfo_Profile

			Private co_rfcFnc		As Lazy(Of SAPNCO.IRfcFunction) _
															= New Lazy(Of SAPNCO.IRfcFunction)(
																	Function()	Me.co_Profile.SAPrfcDestination.Repository.CreateFunction(co_Profile.SAPRfcFncName),
																	LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(ByVal profile	As IBxS_DDICInfo_Profile)

				Me.co_Profile	= profile

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Privates"
		#End Region

	End Class

End Namespace