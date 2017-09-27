Imports BxS.API.SAPFunctions.Xtra
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session

  Public Interface iSessionCTUParams

    #Region "Properties"

      <xNCOAttributeRFCParameter(TechID:= "DisMode")>   Property DisMode  As String

      <xNCOAttributeRFCParameter(TechID:= "UpdMode")>   Property UpdMode  As String

      <xNCOAttributeRFCParameter(TechID:= "CattMode")>  Property CattMode As String

      <xNCOAttributeRFCParameter(TechID:= "DefSize")>   Property DefSize  As String

      <xNCOAttributeRFCParameter(TechID:= "RACommit")>  Property RACommit As String

      <xNCOAttributeRFCParameter(TechID:= "NoBInpt")>   Property NoBInpt  As String

      <xNCOAttributeRFCParameter(TechID:= "NoBIEnd")>   Property NoBIEnd  As String

    #End Region

  End Interface

End Namespace