Namespace Services.Excel

  Friend NotInheritable Partial Class WBookCloseHandler
                                        Implements iWBookCloseHandler

    #Region "Definitions"

      Private co_Application    As Microsoft.Office.Interop.Excel.Application
      Private co_PendingRequest As CloseRequest

      Friend Event ce_WorkbookClosed  As EventHandler(Of iWBookCloseEventArgs) Implements iWBookCloseHandler.ce_WorkbookClosed

    #End Region

    #Region "Methods"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Private Sub OnWorkbookClosed(e As iWBookCloseEventArgs)
        RaiseEvent ce_WorkbookClosed(Me, e)
      End Sub

    #End Region

    #Region "Event Handlers"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Private Sub Application_WorkbookActivate(wb As Microsoft.Office.Interop.Excel.Workbook)

        Dim lb_wasClosed As Boolean
      
        ' A workbook was closed if a request is pending and the workbook count decreased as this
        ' is called when focus moves to the next workbook
        '
        lb_wasClosed  = True                            AndAlso
                        Me.co_PendingRequest IsNot Nothing AndAlso
                        Me.co_Application.Workbooks.Count < Me.co_PendingRequest.WorkbookCount

        If lb_wasClosed Then

          Dim args As iWBookCloseEventArgs = New WBookCloseEventArgs(Me.co_PendingRequest.WorkbookName)
          Me.OnWorkbookClosed(args)

        End If

        Me.co_PendingRequest = Nothing

      End Sub
      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Private Sub Application_WorkbookDeactivate(wb As Microsoft.Office.Interop.Excel.Workbook)
        If Me.co_Application.Workbooks.Count = 1
          Me.co_PendingRequest = Nothing
          Me.OnWorkbookClosed(New WBookCloseEventArgs(wb.Name))
        End If
      End Sub
      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Private Sub Application_WorkbookBeforeClose(      wb      As Microsoft.Office.Interop.Excel.Workbook,
                                                  ByRef cancel  As Boolean)
        If Not cancel
          Me.co_PendingRequest = New CloseRequest(wb.Name, Me.co_Application.Workbooks.Count)
        End If
      End Sub

    #End Region
    
    #Region "Constructor"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Friend Sub New(i_Application As Microsoft.Office.Interop.Excel.Application)

        Me.co_Application = i_Application

        AddHandler Me.co_Application.WorkbookActivate,     AddressOf Me.Application_WorkbookActivate
        AddHandler Me.co_Application.WorkbookBeforeClose,  AddressOf Me.Application_WorkbookBeforeClose
        AddHandler Me.co_Application.WorkbookDeactivate,   AddressOf Me.Application_WorkbookDeactivate

      End Sub

    #End Region

  End Class

End Namespace

