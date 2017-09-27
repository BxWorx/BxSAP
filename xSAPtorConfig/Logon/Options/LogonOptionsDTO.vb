'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Config.SAPLogon

  Friend Class LogonOptionsDTO
                Implements iLogonOptionsDTO

    #Region "Properties"

      Friend Property DefaultLanguage     As String   Implements  iLogonOptionsDTO.DefaultLanguage
      Friend Property ShowPassword        As Boolean  Implements  iLogonOptionsDTO.ShowPassword
      Friend Property SavePassword        As Boolean  Implements  iLogonOptionsDTO.SavePassword
      Friend Property AutoSave            As Boolean  Implements  iLogonOptionsDTO.AutoSave
      Friend Property ConfigViewerActive  As Boolean  Implements  iLogonOptionsDTO.ConfigViewerActive
      Friend Property AutoConnect         As Boolean  Implements  iLogonOptionsDTO.AutoConnect

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Constructor"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Public Sub New()

        Me.DefaultLanguage  = "EN"
        Me.ShowPassword     = False
        Me.SavePassword     = False
        Me.AutoSave         = True
        Me.SavePassword     = False
        Me.AutoConnect      = False

      End Sub

    #End Region

  End Class

End Namespace