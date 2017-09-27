Imports BxS.API.SAPFunctions.Xtra
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session

  Public Interface iSessionProfile

    #Region "Properties"

      <xNCOAttributeRFCParameter(TechID:= "SessionName")>   Property SessionName  As String
      <xNCOAttributeRFCParameter(TechID:= "SAPTCode")>      Property SAPTCode     As String
      <xNCOAttributeRFCParameter(TechID:= "CTUParams")>     Property CTUParams    As iSessionCTUParams
      <xNCOAttributeRFCParameter(TechID:= "BDCData")>       Property BDCDataList  As List(Of iSessionData)

    #End Region

  End Interface

End Namespace