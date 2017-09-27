'Imports System.Threading
''¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
Friend Class xBDC_TypePool

  Friend Enum BDC_RowType As UShort
                ColumnNo      = 0
                ProgName      = 1
                DynProNo      = 2
                DynBegin      = 3
                OKCode        = 4
                Cursor        = 5
                SubScreen     = 6
                FieldName     = 7
                Description   = 8
                Instructions  = 9
         End Enum

  Friend Const cz_Cmd_Prefix        As String = "@@"
  Friend Const cz_Cmd_Delim         As Char   = CChar(";")
  Friend Const cz_Cmd_PartDelim     As Char   = CChar(":")

  Friend Const cz_Sub_Token         As String = "<<@>>"
  Friend Const cz_Sub_ABAPTrue      As String = "X"

  Friend Const cz_Cmd_OKCode        As String = "BDC_OKCODE"
  Friend Const cz_Cmd_Cursor        As String = "BDC_CURSOR"
  Friend Const cz_Cmd_SubScr        As String = "BDC_SUBSCR"

  Friend Const cz_Sym_PsuedoAction  As String = "@@"
  Friend Const cz_Sym_ClearFld      As String = "@@[]"

  Friend Const cz_Cmd_DoIf          As String = "@@DOIF"
  Friend Const cz_Cmd_SubFldIdx     As String = "@@SUBF"
  Friend Const cz_Cmd_SubCsrIdx     As String = "@@SUBC"
  Friend Const cz_Cmd_ValFldIdx     As String = "@@INDEX"
  Friend Const cz_Cmd_ValCsrIdx     As String = "@@CSRIDX"

  '#Region "Singleton"

  '  '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
  '  Private Shared ReadOnly _Instance As Lazy(Of xBDC_TypePool) _
  '                                         = New Lazy(Of xBDC_TypePool)(Function() New xBDC_TypePool, LazyThreadSafetyMode.ExecutionAndPublication)
  '  Friend Shared ReadOnly Property GetInstance() As xBDC_TypePool
  '    Get
  '      Return _Instance.Value
  '    End Get
  '  End Property
  '  '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
  '  Private Sub New()
  '  End Sub

  '#End Region

End Class
