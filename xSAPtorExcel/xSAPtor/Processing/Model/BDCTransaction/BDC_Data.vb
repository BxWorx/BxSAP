Namespace Main.BDCProcessing
Friend Class BDC_Data
                  Implements iBDC_Data

  'Private ProgramName As String
  'Private DynProNo    As String
  'Private DynProBegin As String
  'Private FieldName   As String
  'Private FieldValue  As String
  '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Friend Property Program_Name()  As String   Implements iBDC_Data.Program_Name
  '  Get
  '    Return Me.ProgramName
  '  End Get
  '  Set(ByVal Value As String)
  '    Me.ProgramName = Value
  '  End Set
  'End Property
  ''¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Friend Property Dynpro_Number() As String   Implements iBDC_Data.Dynpro_Number
  '  Get
  '    Return Me.DynProNo
  '  End Get
  '  Set(ByVal Value As String)
  '    Me.DynProNo = Value
  '  End Set
  'End Property
  ''¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Friend Property Dynpro_Begin()  As String   Implements iBDC_Data.Dynpro_Begin
  '  Get
  '    Return Me.DynProBegin
  '  End Get
  '  Set(ByVal Value As String)
  '    Me.DynProBegin = Value
  '  End Set
  'End Property
  ''¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Friend Property Field_Name()    As String   Implements iBDC_Data.Field_Name
  '  Get
  '    Return Me.FieldName
  '  End Get
  '  Set(ByVal Value As String)
  '    Me.FieldName = Value
  '  End Set
  'End Property
  ''¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Friend Property Field_Value()   As String   Implements iBDC_Data.Field_Value
  '  Get
  '    Return Me.FieldValue
  '  End Get
  '  Set(ByVal Value As String)
  '    Me.FieldValue = Value
  '  End Set
  'End Property

End Class

End Namespace