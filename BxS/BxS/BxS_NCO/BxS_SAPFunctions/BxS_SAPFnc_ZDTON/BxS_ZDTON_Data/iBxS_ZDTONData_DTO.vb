'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Public Interface iBxS_ZDTONData_DTO

		#Region "Properties"

			Property	User				As String
			Property  SessionID		As String
			Property	RowNo				As Integer
			Property	ExcelRow		As Integer
			Property	DataValues	As Dictionary(Of Integer, String)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Sub Reset()

			'Function ShallowCopy()	As iBxS_ZDTONData_DTO

		#End Region

	End Interface

End Namespace