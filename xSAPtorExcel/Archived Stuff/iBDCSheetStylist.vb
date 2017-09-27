Public Interface iBDCSheetStylist

  ReadOnly Property Program As Excel.Style
  ReadOnly Property Dynpro  As Excel.Style

  Sub SetStyle(ByRef i_Range As Excel.Range)


End Interface
