'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session

  Public Class SessionData
                Implements iSessionData

    #Region "Properties"

      Property Program_Name()   As String Implements iSessionData.Program_Name
      Property Dynpro_Number()  As String Implements iSessionData.Dynpro_Number
      Property Dynpro_Begin()   As String Implements iSessionData.Dynpro_Begin
      Property Field_Name()     As String Implements iSessionData.Field_Name
      Property Field_Value()    As String Implements iSessionData.Field_Value
      Property Field_Descr()    As String Implements iSessionData.Field_Descr

    #End Region

  End Class

End Namespace