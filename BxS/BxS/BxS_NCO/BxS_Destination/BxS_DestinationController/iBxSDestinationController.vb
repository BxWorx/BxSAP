Imports SAPNCO = SAP.Middleware.Connector
Imports BxS.API.Destination
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace	Destination

	Friend Interface iBxSDestinationController

		Function Create_LogonDTO()																																			As iBxSLogonParamsDTO
		Function CreateDestinationConfig_FromSAPIni(ByRef SAPLogonIni	As SAPNCO.SapLogonIniConfiguration)	As iBxSDestinationConfiguration
		'................................................................
		Function GetDestinationList()																						As List(Of String)
		Function GetDestination(ByVal rfcDestID		As String)										As iBxSDestination
		'................................................................
		Sub Register(ByVal destinationConfiguration As iBxSDestinationConfiguration)
		Sub UnRegister()

		Function ModifyRfcConfig(	ByVal	rfcDestID					As String, _
															ByVal rfcCfgParameters	As SAPNCO.RfcConfigParameters)	As Boolean
		Function	CreateDestinationConfig()		As iBxSDestinationConfiguration
		Function	CreateRfcConfigParameters()	As	SAPNCO.RfcConfigParameters

	End Interface

End Namespace

