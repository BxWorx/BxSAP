Imports SAPNCO = SAP.Middleware.Connector
Imports BxS.API.Destination
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Friend Interface iBxS_ZDTONMsgs_Profile

			ReadOnly	Property	SAPRfcFncName				As	String
			ReadOnly	Property	SAPrfcDestination		As	SAPNCO.RfcCustomDestination
			ReadOnly	Property	rfcDestination			As	iBxSDestination
			ReadOnly	Property	RfcFncParmIndex			As	iBxS_ZDTONMsgs_ParmIndex

			Function	CreateDTO()		As	iBxS_ZDTONMsgs_DTO

	End Interface

End Namespace