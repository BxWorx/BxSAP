Imports Microsoft.Office.Tools
'================================================
Namespace Services.Excel

  Public Interface iCTPHandler

    #Region "Excel Event Handlers"

      Sub OnWindowActivate(ByVal i_WBookName  As String,
                           ByVal i_WHnd       As String)

    #End Region

    #Region "Methods"

      Sub ClearOnWBookClose(ByVal i_WBookName As String)

    #End Region

    #Region "My Events"

      Event CTPVisibilityChanged()

    #End Region

    #Region "Properties"

      Property Visible()                                    As Boolean
      ReadOnly Property Contains(ByVal i_WBName As String)  As Boolean
      ReadOnly Property CTP(ByVal i_WBName      As String)  As CustomTaskPane

    #End Region

  End Interface

End Namespace