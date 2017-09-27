Imports SAPNCO = SAP.Middleware.Connector

Imports BxS.API.Destination
Imports BxS.API.SAPFunctions.ZDTON
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Friend Interface iBxS_DDICInfo_Profile

		ReadOnly	Property SAPrfcDestination	As SAPNCO.RfcCustomDestination
		ReadOnly	Property rfcDestination			As iBxSDestination

	End Interface

End Namespace