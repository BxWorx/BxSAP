'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

  Public Class LogonSystemsXML

    #Region "Properties"

      <DataMember>  Public Property SAPSystems  As Dictionary(Of String, LogonClientsXML)
      <DataMember>  Public Property Languages   As List(Of String)

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Methods"

      Public Function Remove(Optional ByVal i_SAPID     As String = "",
                             Optional ByVal i_Client    As String = "",
                             Optional ByVal i_UserName  As String = "",
                             Optional ByVal i_Language  As String = "") As Boolean

        If i_Language.Length > 0
          If Me.Languages.Contains(i_Language)
            Me.Languages.Remove(i_Language)
          End If
        End If

        If i_SAPID.Length > 0

          If i_Client.Length > 0

            Dim lo_Clients  As LogonClientsXML  = Nothing

            If Me.SAPSystems.TryGetValue(i_SAPID, lo_Clients)
              lo_Clients.Remove(i_Client, i_UserName)
            Else
              If Not Me.SAPSystems.Remove(i_SAPID)
                ' some message
              End If
            End If
            
          Else
            If Not Me.SAPSystems.Remove(i_SAPID)
              ' some message
            End If
          End If

        End If

        Return True

      End Function
      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Public Function Add(ByVal i_SAPID     As String,
                          ByVal i_Client    As String,
                          ByVal i_UserName  As String,
                          ByVal i_PassWord  As String,
                          ByVal i_Language  As String) As Boolean

        If i_SAPID IsNot Nothing AndAlso i_SAPID.Length > 0

          Dim lo_Clients  As LogonClientsXML  = Nothing

          If i_Language IsNot Nothing AndAlso i_Language.Length > 0
            If Not Me.Languages.Contains(i_Language)
              Me.Languages.Add(i_Language)
            End If
          End If

          If Not Me.SAPSystems.TryGetValue(i_SAPID, lo_Clients)
            lo_Clients  = New LogonClientsXML
            Me.SAPSystems.Add(i_SAPID, lo_Clients)
          End If

          Return lo_Clients.Add(i_Client, i_UserName, i_PassWord, i_Language)

        Else
          Return False
        End If

      End Function

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Constructor"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Public Sub New()

        Me.SAPSystems = New Dictionary(Of String, LogonClientsXML)
        Me.Languages  = New List(Of String)

      End Sub

    #End Region

  End Class
  '••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
  Public Class LogonClientsXML

    #Region "Properties"

      <DataMember>  Public Property Clients As Dictionary(Of String, LogonUsersXML)

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Methods"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Public Function Remove(ByVal i_Client    As String,
                             ByVal i_UserName  As String) As Boolean

        If i_UserName.Length > 0
        
          Dim lo_Users  As LogonUsersXML  = Nothing

          If Me.Clients.TryGetValue(i_Client, lo_Users)
            Return lo_Users.Remove(i_UserName)
          Else
            Return Me.Clients.Remove(i_Client)
          End If

        Else
          Return Me.Clients.Remove(i_Client)
        End If

      End Function
      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Public Function Add(ByVal i_Client    As String,
                          ByVal i_UserName  As String,
                          ByVal i_PassWord  As String,
                          ByVal i_Language  As String) As Boolean

        Dim lo_Users  As LogonUsersXML  = Nothing

        If Not Me.Clients.TryGetValue(i_Client, lo_Users)
          lo_Users = New LogonUsersXML
          Me.Clients.Add(i_Client, lo_Users)
        End If

        Return lo_Users.Add(i_UserName, i_PassWord, i_Language)

      End Function

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Constructor"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Public Sub New()
        Clients = New Dictionary(Of String, LogonUsersXML)
      End Sub

    #End Region

  End Class
  '••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
  Public Class LogonUsersXML

    #Region "Properties"

      <DataMember>  Public Property Users As Dictionary(Of String, LogonUserDataXML)

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Methods"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Public Function Remove(ByVal i_UserName  As String) As Boolean

        Return Me.Users.Remove(i_UserName)

      End Function
      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Public Function Add(ByVal i_UserName As String,
                          ByVal i_PassWord As String,
                          ByVal i_Language As String) As Boolean

        Dim lo_UserData As LogonUserDataXML = Nothing

        If Not Me.Users.TryGetValue(i_UserName, lo_UserData)
          lo_UserData = New LogonUserDataXML
          Me.Users.Add(i_UserName, lo_UserData)
        End If

        Return lo_UserData.SetValues(i_PassWord, i_Language)

      End Function

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Constructor"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Public Sub New()
        Users = New Dictionary(Of String, LogonUserDataXML)
      End Sub

    #End Region

  End Class
  '••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
  Public Class LogonUserDataXML

    #Region "Properties"

      <DataMember>  Public Property Password  As String
      <DataMember>  Public Property Language  As String

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Methods"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Public Function SetValues(ByVal i_PassWord As String,
                                ByVal i_Language As String) As Boolean

        Me.Password = i_PassWord
        Me.Language = i_Language

        Return True

      End Function

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Constructor"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Public Sub New()
      End Sub

    #End Region

  End Class

End Namespace