Imports SAPNCO = SAP.Middleware.Connector

Imports BxS.API.Destination
Imports BxS.API.SAPFunctions.ZDTON
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Friend Interface iBxS_ZDTON_Profile

							Property	NoofConsumers			As Integer
		'ReadOnly  Property	GetDTO						As iBxS_ZDTON_DTO
		ReadOnly	Property	SAPrfcDestination	As SAPNCO.RfcCustomDestination
		ReadOnly	Property	rfcDestination		As iBxSDestination

	End Interface

End Namespace