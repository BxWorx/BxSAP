Imports xSAPtorExcel.Services.Excel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Selection

	Friend Interface ixProcessSelectionModel

		#Region "Methods"

			Function GetOpenWBWSItems()																		As ixProcessSelectionDTO
			Function GetWorkSheetProfile(ByVal WorkBookName		As String,
																	 ByVal WorkSheetName	As String)	As iExcelWSProfileDTO

		#End Region

	End Interface

End Namespace
