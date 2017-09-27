Imports SAPNCO = SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace	Destination

	Friend Interface iBxSDestinationConfiguration
					Inherits SAPNCO.IDestinationConfiguration

		Function DestinationCount()																																As Integer
		Function GetEntries()																																			As List(Of String)
		Function AddDestinationConfig(ByVal rfcDestID							As String, _
																	ByVal rfcCfgParameters			As SAPNCO.RfcConfigParameters)	As Boolean
		Function UpdateDestinationConfig(ByVal rfcDestID					As String, _
																		 ByVal rfcCfgParameters		As SAPNCO.RfcConfigParameters)	As Boolean

		'Function ModifyDestinationConfig(ByVal rfcDestID					As String, _
		'																 ByVal rfcCfgParameters		As iBxSDestParamsDTO)						As Boolean

	End Interface

End Namespace
