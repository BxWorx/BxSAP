Imports SAPNCO = SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.BDCTransaction

	Friend Interface iBxS_BDCTran_Destination

		ReadOnly	Property SAPrfcDestination																As SAPNCO.RfcCustomDestination
		ReadOnly	Property RfcFncParmIndex(ByVal SAPRfcFncName	As String)	As iBxS_BDCTran_ParmIndex

	End Interface

End Namespace