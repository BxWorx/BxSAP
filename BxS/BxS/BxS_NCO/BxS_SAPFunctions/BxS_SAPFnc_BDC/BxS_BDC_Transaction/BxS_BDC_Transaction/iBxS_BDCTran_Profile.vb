Imports SAPNCO = SAP.Middleware.Connector
Imports BxS.API.Destination
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.BDCTransaction

	Friend Interface iBxS_BDCTran_Profile

		ReadOnly	Property	SAPRfcFncName			As String
		ReadOnly	Property	SAPrfcDestination	As SAPNCO.RfcCustomDestination
		ReadOnly	Property	rfcDestination		As iBxSDestination
		ReadOnly	Property	RfcFncParmIndex		As iBxS_BDCTran_ParmIndex

	End Interface

End Namespace