'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.Tablereader

	Friend Class BxSSAPTblRdr_ParmIndex
								Implements iBxSSAPTblRdr_ParmIndex

			Property QueryTable			As Integer	Implements iBxSSAPTblRdr_ParmIndex.QueryTable
			Property Delimiter			As Integer	Implements iBxSSAPTblRdr_ParmIndex.Delimiter
			Property NoData					As Integer	Implements iBxSSAPTblRdr_ParmIndex.NoData
			Property SkipRows				As Integer	Implements iBxSSAPTblRdr_ParmIndex.SkipRows
			Property RowCount				As Integer	Implements iBxSSAPTblRdr_ParmIndex.RowCount
			Property Options				As Integer	Implements iBxSSAPTblRdr_ParmIndex.Options
			Property Fields					As Integer	Implements iBxSSAPTblRdr_ParmIndex.Fields
			Property OutTableName		As Integer	Implements iBxSSAPTblRdr_ParmIndex.OutTableName
			Property OutTable128		As Integer	Implements iBxSSAPTblRdr_ParmIndex.OutTable128
			Property OutTable512		As Integer	Implements iBxSSAPTblRdr_ParmIndex.OutTable512
			Property OutTable2048		As Integer	Implements iBxSSAPTblRdr_ParmIndex.OutTable2048
			Property OutTable8192		As Integer	Implements iBxSSAPTblRdr_ParmIndex.OutTable8192
			Property OutTable30000	As Integer	Implements iBxSSAPTblRdr_ParmIndex.OutTable30000

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function Clone() As iBxSSAPTblRdr_ParmIndex _
												Implements iBxSSAPTblRdr_ParmIndex.Clone

				Return CType( Me.MemberwiseClone(), iBxSSAPTblRdr_ParmIndex )

			End Function

	End Class

End Namespace