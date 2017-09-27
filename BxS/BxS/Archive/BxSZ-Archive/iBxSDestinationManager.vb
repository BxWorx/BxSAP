Imports SAPNCO = SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace	Destination

	Public Interface iBxSDestinationManager

							Function GetDestinationList()																									As List(Of String)

		'Overloads Function Register(ByRef rfcDestConfig As iBxSDestinationConfiguration)				As Boolean
							Function Unregister()																													As Boolean

		Overloads Function GetDestination(ByVal rfcDestID	As String)														As SAPNCO.RfcCustomDestination
		'Overloads Function GetDestination(ByVal rfcDestID	As String, _
		'																	ByVal rfcLogonDTO As iBxSLogonParamsDTO)							As SAPNCO.RfcCustomDestination
		Overloads	Function GetDestination(ByRef rfcCfgParam As SAPNCO.RfcConfigParameters)			As SAPNCO.RfcCustomDestination

	End Interface

End Namespace
