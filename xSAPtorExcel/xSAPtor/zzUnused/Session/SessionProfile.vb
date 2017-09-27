'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session
  Public Class SessionProfile
                Implements iSessionProfile

    #Region "Properties"

      Public Property SAPTCode    As String                 Implements iSessionProfile.SAPTCode
      Public Property SessionName As String                 Implements iSessionProfile.SessionName
      Public Property CTUParams   As iSessionCTUParams      Implements iSessionProfile.CTUParams
      Public Property BDCData     As List(Of iSessionData)  Implements iSessionProfile.BDCDataList

    #End Region

  End Class

End Namespace