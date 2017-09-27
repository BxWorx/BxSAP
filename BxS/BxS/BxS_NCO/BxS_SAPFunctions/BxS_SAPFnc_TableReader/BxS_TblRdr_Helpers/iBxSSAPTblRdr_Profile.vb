'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.Tablereader

	Friend Interface iBxSSAPTblRdr_Profile

		#Region "Properties"

								Property SAPFncName	As String
								Property TableName  As String
								Property Delimeter  As Char
								Property NoData     As Boolean
								Property SkipRows   As Long
								Property RowCount   As Long

			ReadOnly	Property FieldList  As List(Of String)
			ReadOnly	Property Options    As List(Of String)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Sub Add_Field(ByVal i_FieldName	As String)
			Sub Add_Option(ByVal i_Option		As String)
			Sub Reset(Optional ByVal i_Fields   As Boolean = False,
								Optional ByVal i_Options  As Boolean = False,
								Optional ByVal i_SkipRows As Boolean = False,
								Optional ByVal i_RowCount As Boolean = False,
								Optional ByVal i_NoData   As Boolean = False)
			Sub Reset()

		#End Region

	End Interface

End Namespace