Friend Interface iExcelColumn

  #Region "Properties"

    ReadOnly Property Column_No           As Integer

    ReadOnly Property Program_Name        As String
    ReadOnly Property DynPro_Number       As String
    ReadOnly Property DynPro_Begin        As String
    ReadOnly Property OKCode              As String
    ReadOnly Property Cursor_Before       As String
    ReadOnly Property Subscreen           As String
    ReadOnly Property Field_Name          As String
    ReadOnly Property Description         As String
    ReadOnly Property Instructions        As String
    ReadOnly Property DoIFHasValue        As Boolean
    ReadOnly Property DoFieldIndex        As Boolean
    ReadOnly Property DoCursorIndex       As Boolean
    ReadOnly Property IsFieldIndexColumn  As Boolean
    ReadOnly Property IsCursorIndexColumn As Boolean
    ReadOnly Property Utilized            As Boolean
    ReadOnly Property Commands            As Dictionary(Of String, String)

  #End Region

End Interface
