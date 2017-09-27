'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Services.Excel
	Friend Class ExcelMDIWBookDTO
								Implements iExcelMDIWBookDTO

		Friend Property WBName	As String												Implements iExcelMDIWBookDTO.WBName
		Friend Property	WSList	As List(Of iExcelMDIWSheetDTO)	Implements iExcelMDIWBookDTO.WSList

	End Class

End Namespace