'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Public Interface iBxS_ZDTONMsgs_DTO

		#Region "Properties"

			Property	Rowno				As Integer
			Property	Status			As String
			Property	Message			As String
			Property	ExcelRow		As Integer
			Property	MsgDate			As String
			Property	MsgTime			As String

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function ShallowCopy()	As iBxS_ZDTONMsgs_DTO

		#End Region

	End Interface

End Namespace