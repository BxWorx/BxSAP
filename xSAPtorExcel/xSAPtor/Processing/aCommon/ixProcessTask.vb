Imports xSAPtorExcel.Services.Excel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Common

	Friend Interface ixProcessTask

		#Region "Properties"

			Property WorkbookName		As String
			Property WorksheetName	As String
			Property Checked				As Boolean
			Property Synced					As Boolean
			Property Profile				As iExcelWSProfileDTO
			Property SAPTCode				As String
			Property GUID						As String
			Property TranCount			As Integer
			Property TranComplete		As Integer
			Property PercComplete		As Integer
			Property StatusDone			As Boolean
			Property Timestamp			As DateTime

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function ShallowCopy()	As ixProcessTask

		#End Region

	End Interface

End Namespace
