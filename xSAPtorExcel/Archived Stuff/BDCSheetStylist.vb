Imports Microsoft.Office.Interop.Excel
Imports xSAPtorExcel

Public Class BDCSheetStylist
  Implements iBDCSheetStylist

  Public ReadOnly Property Dynpro As Style Implements iBDCSheetStylist.Dynpro
    Get
      'Dim lo_Style As Excel.Style = New Excel.Style
      'lo_Style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray)
      'Return lo_Style
      Throw New NotImplementedException()
    End Get
  End Property

  Public ReadOnly Property Program As Style Implements iBDCSheetStylist.Program
    Get
      Throw New NotImplementedException()
    End Get
  End Property

  Friend Sub SetStyle(ByRef i_Range As Excel.Range) Implements iBDCSheetStylist.SetStyle
    'i_Range.Style = "20% - Accent1"

  End Sub


End Class
