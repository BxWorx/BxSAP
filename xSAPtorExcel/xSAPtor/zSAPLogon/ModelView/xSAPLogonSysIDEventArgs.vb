'Imports xSAPtorExcel.Main.Config
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

  Friend Class xSAPLogonSysIDEventArgs
                Inherits System.EventArgs

    Friend Property SAPSystemID     As String
    Friend Property IsSSO           As Boolean
    Friend Property SAPLogonClients As iSysReposSystemDTO

  End Class

End Namespace
