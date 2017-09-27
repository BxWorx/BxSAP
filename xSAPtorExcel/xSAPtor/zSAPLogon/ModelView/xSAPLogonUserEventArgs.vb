'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

  Friend Class xSAPLogonUserEventArgs
                Inherits System.EventArgs

    Friend Property ActionIsDelete  As Boolean
    Friend Property SAPSystemID     As String
    Friend Property ClientNo        As String
    Friend Property UserName        As String
    Friend Property Password        As String
    Friend Property Language        As String

  End Class

End Namespace
