Imports SAPNCO = SAP.Middleware.Connector

Imports BxS.API.Destination
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.DDIC

	Friend Interface IBxS_DDICInfo_Profile

		ReadOnly	Property	SAPRfcFncName				As	String
		ReadOnly	Property	SAPrfcDestination		As	SAPNCO.RfcCustomDestination
		ReadOnly	Property	RfcDestination			As	iBxSDestination
		ReadOnly	Property	RfcFncParmIndex			As	IBxS_DDICInfo_ParmIndex

	End Interface

End Namespace