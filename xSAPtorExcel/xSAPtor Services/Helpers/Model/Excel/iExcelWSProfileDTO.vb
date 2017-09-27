Imports xSAPtorExcel.WorksheetDomain
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Services.Excel

	Friend Interface iExcelWSProfileDTO

		#Region "Properties"

			Property WBookName        As	String
			Property WSheetName       As	String
			Property WSheetIndex      As	Integer
			Property UsedArea         As	iExcelAddress
			Property HeaderArea       As	iExcelAddress
			Property DataArea         As	iExcelAddress
			Property SelectArea				As	iExcelAddress
			Property MessageArea			As	iExcelAddress

			Property SelectColumnNo		As	Integer
			Property MessageColumnNo	As	Integer

			Property RowTemplate			As	String
			Property XMLConfigAddress As	iExcelAddress
			Property BDCConfig        As	iBDCConfiguration

			Property	IsSAPtor				As	Boolean
			Property	IsProtected			As	Boolean
			Property	Password     		As	String

		#End Region

	End Interface

End Namespace
