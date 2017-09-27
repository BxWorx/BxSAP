Imports xSAPtorExcel.WorksheetDomain
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Services.Excel

	Friend Class ExcelWSProfileDTO
								Implements iExcelWSProfileDTO

		#Region "Properties"

			Property WBookName					As String             Implements iExcelWSProfileDTO.WBookName
			Property WSheetName					As String             Implements iExcelWSProfileDTO.WSheetName
			Property WSheetIndex				As Integer            Implements iExcelWSProfileDTO.WSheetIndex
			Property UsedArea						As iExcelAddress      Implements iExcelWSProfileDTO.UsedArea
			Property HeaderArea					As iExcelAddress      Implements iExcelWSProfileDTO.HeaderArea
			Property DataArea						As iExcelAddress      Implements iExcelWSProfileDTO.DataArea
			Property SelectArea					As iExcelAddress      Implements iExcelWSProfileDTO.SelectArea
			Property MessageArea				As iExcelAddress      Implements iExcelWSProfileDTO.MessageArea
			Property RowTemplate				As String							Implements iExcelWSProfileDTO.RowTemplate
			Property XMLConfigAddress		As iExcelAddress      Implements iExcelWSProfileDTO.XMLConfigAddress
			Property BDCConfig					As iBDCConfiguration	Implements iExcelWSProfileDTO.BDCConfig
			Property SelectColumnNo			As Integer            Implements iExcelWSProfileDTO.SelectColumnNo
			Property MessageColumnNo		As Integer            Implements iExcelWSProfileDTO.MessageColumnNo

			Property	IsSAPtor					As	Boolean						Implements iExcelWSProfileDTO.IsSAPtor
			Property	IsProtected				As	Boolean						Implements iExcelWSProfileDTO.IsProtected
			Property	Password     			As	String						Implements iExcelWSProfileDTO.Password

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New()

				Me.BDCConfig        = New BDCConfiguration()
				Me.XMLConfigAddress = New ExcelAddress("$A$1")  ' implement via defaults

				Me.IsSAPtor					= True
				Me.IsProtected			= False

			End Sub      

		#End Region

	End Class

End Namespace