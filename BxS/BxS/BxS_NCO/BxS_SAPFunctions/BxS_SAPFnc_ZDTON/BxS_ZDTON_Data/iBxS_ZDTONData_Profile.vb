Imports SAPNCO = SAP.Middleware.Connector
Imports BxS.API.Destination
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Friend Interface iBxS_ZDTONData_Profile

		ReadOnly	Property	SAPRfcFncName			As String
		ReadOnly	Property	SAPrfcDestination	As SAPNCO.RfcCustomDestination
		ReadOnly	Property	rfcDestination		As iBxSDestination
		ReadOnly	Property	RfcFncParmIndex		As iBxS_ZDTONData_ParmIndex

	End Interface

End Namespace