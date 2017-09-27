Imports BxS.SAPFunctions.ZDTON
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.ZDTON

	Public Interface iBxS_ZDTON_DTO

		#Region "Properties"

			Property	User				As String
			Property	SessionID		As String
			Property	SAPTCode		As String
			Property  Tally				As Integer
			Property  Columns()		As List(Of iBxS_ZDTONColumns_DTO)
			Property  Data()			As Dictionary(Of Integer, iBxS_ZDTONData_DTO)
			Property  Msgs()			As Dictionary(Of Integer, iBxS_ZDTONMsgs_DTO)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Sub	Reset()
			Function	CreateColumnDTO()		As iBxS_ZDTONColumns_DTO
			Function	CreateDataDTO()			As iBxS_ZDTONData_DTO

		#End Region

	End Interface

End Namespace