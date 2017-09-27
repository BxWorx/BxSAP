'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Services.Excel
	Friend Class ExcelMDIWSheetDTO
								Implements iExcelMDIWSheetDTO

		Friend Property WSName						As String		Implements iExcelMDIWSheetDTO.WSName
		Friend Property WSIndex						As Integer	Implements iExcelMDIWSheetDTO.WSIndex
		Friend Property IsBDCType					As Boolean	Implements iExcelMDIWSheetDTO.IsBDCType
		Friend Property BDCActive					As Boolean	Implements iExcelMDIWSheetDTO.BDCActive
		Friend Property	BDCConfigAddress	As String		Implements iExcelMDIWSheetDTO.BDCConfigAddress
		Friend Property	BDCConfigXML			As String		Implements iExcelMDIWSheetDTO.BDCConfigXML
		Friend Property ParentID					As String		Implements iExcelMDIWSheetDTO.ParentID

	End Class

End Namespace