Imports BxS.API.SAPFunctions.Xtra
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session

  Public Interface iSessionData

    #Region "Properties"

      <xNCOAttributeRFCParameter(TechID:= "Program_Name")>    Property Program_Name()   As String
      <xNCOAttributeRFCParameter(TechID:= "Dynpro_Number")>   Property Dynpro_Number()  As String
      <xNCOAttributeRFCParameter(TechID:= "Dynpro_Begin")>    Property Dynpro_Begin()   As String
      <xNCOAttributeRFCParameter(TechID:= "Field_Name")>      Property Field_Name()     As String
      <xNCOAttributeRFCParameter(TechID:= "Field_Value")>     Property Field_Value()    As String
      <xNCOAttributeRFCParameter(TechID:= "Field_Descr")>     Property Field_Descr()    As String

    #End Region

    End Interface

End Namespace