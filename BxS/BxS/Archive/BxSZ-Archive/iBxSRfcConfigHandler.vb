Imports SAPNCO = SAP.Middleware.Connector

Namespace API.Destination

	Public Interface iBxSRfcConfigHandler
		
		Overloads Function Create(ByVal cfgDTO As iBxSDestParamsDTO)	As SAPNCO.RfcConfigParameters
		Overloads Function Create(ByVal cfgName		As String,	_
															ByVal cfgHost		As String,	_
															ByVal cfgSysNo	As String,	_
															ByVal cfgSysID	As String,	_
															ByVal cfgClient	As String,	_
															ByVal cfgUser		As String,	_
															ByVal cfgPWrd		As String		_
															)																		As SAPNCO.RfcConfigParameters

	End Interface

End Namespace