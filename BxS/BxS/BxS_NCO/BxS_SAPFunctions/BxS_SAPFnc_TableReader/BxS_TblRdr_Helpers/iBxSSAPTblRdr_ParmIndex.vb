'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.Tablereader

	Friend Interface iBxSSAPTblRdr_ParmIndex

		Property QueryTable     As Integer
		Property Delimiter      As Integer
		Property NoData         As Integer
		Property SkipRows       As Integer
		Property RowCount       As Integer
		Property Options        As Integer
		Property Fields         As Integer
		Property OutTableName   As Integer
		Property OutTable128    As Integer
		Property OutTable512    As Integer
		Property OutTable2048   As Integer
		Property OutTable8192   As Integer
		Property OutTable30000  As Integer

		Function Clone()	As iBxSSAPTblRdr_ParmIndex

	End Interface

End Namespace