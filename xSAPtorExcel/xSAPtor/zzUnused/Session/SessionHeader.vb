'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session

    Public Class SessionHeader
                Implements iSessionHeader

      #Region "Properties"

        Public Property CreationDate  As Date     Implements iSessionHeader.CreationDate
        Public Property CreationTime  As TimeSpan Implements iSessionHeader.CreationTime
        Public Property SessionName   As String   Implements iSessionHeader.SessionName
        Public Property Count         As Integer  Implements iSessionHeader.Count
        Public Property UserID        As String   Implements iSessionHeader.UserID
        Public Property QID           As String   Implements iSessionHeader.QID

      #End Region

    End Class

End Namespace