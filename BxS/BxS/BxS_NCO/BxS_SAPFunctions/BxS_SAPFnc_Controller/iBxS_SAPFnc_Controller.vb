Imports	BxS.API.SAPFunctions.MsgComposer
Imports	BxS.API.SAPFunctions.BDCTransaction
Imports	BxS.API.SAPFunctions.ZDTON
Imports BxS.SAPFunctions.ZDTON
Imports BxS.Utilities
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace	SAPFunctions

	Friend Interface iBxS_SAPFnc_Controller

		Function	GetZDTON()					As iBxS_ZDTON
		Function	GetZDTONProfile()		As iBxS_ZDTON_Profile
		Function	GetZDTONHeader()		As iBxS_ZDTONHeader
		Function	GetZDTONColumns()		As iBxS_ZDTONColumns
		Function	GetZDTONData()			As iBxS_ZDTONData
		Function	GetZDTONDataExec()	As iBxS_Executioner(Of iBxS_ZDTONData_DTO)
		Function	GetZDTONStats()			As iBxS_ZDTONStats
		Function	GetZDTONMsgs()			As iBxS_ZDTONMsgs
		Function	CreateZDTONDTO()		As	iBxS_ZDTON_DTO
		'..........................................................................
		Function	GetBDCTransaction()	As iBxS_BDCTran_Caller
		Function	GetMsgCompser()			As iBxS_SAPMsgComposer

	End Interface

End Namespace