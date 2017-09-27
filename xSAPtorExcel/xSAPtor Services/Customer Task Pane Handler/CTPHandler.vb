Imports Microsoft.Office.Tools
'================================================
Namespace Services.Excel

  Friend NotInheritable Class CTPHandler
                                Implements iCTPHandler

    #Region "Definitions"

      Friend Event CTPVisibilityChanged() Implements iCTPHandler.CTPVisibilityChanged

      Private WithEvents co_CTPActive As CustomTaskPane

      Private co_ExcelHelper    As iExcelHelper
      Private ct_CTPs           As Dictionary(Of String, CustomTaskPane)
      Private ct_WB2WHnd        As Dictionary(Of String, String)
      Private co_UserControl    As System.Type
      Private cc_CTPTitle       As String
      Private cn_CTPPosition    As Microsoft.Office.Core.MsoCTPDockPosition
      Private cb_IsMDIExcel     As Boolean
      Private cb_InBackStage    As Boolean

      Private Const cz_SDIWHnd  As String = "[SDI_WHND]"

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Excel Event Handlers"

      '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
      Friend Sub OnWindowActivate(ByVal i_WBName  As String,
                                  ByVal i_WHnd    As String) Implements iCTPHandler.OnWindowActivate

        If Not Me.ct_CTPs.TryGetValue(key   := Me.GetWHnd(i_WHnd:= GetWHnd(i_WHnd:= i_WHnd)),
                                      value := Me.co_CTPActive)
          Me.co_CTPActive = Nothing
        End If

        RaiseEvent CTPVisibilityChanged()

      End Sub

    #End Region

    #Region "Properties"

      '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
      Public Property Visible() As Boolean Implements iCTPHandler.Visible
        Get
          If IsNothing(Me.co_CTPActive)
            Return False
          Else
            Return Me.co_CTPActive.Visible
          End If
        End Get
        Set(value As Boolean)
          If value
            Me.ShowCTP()
          Else
            Me.HideCTP()
          End If
        End Set
      End Property
      '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
      Public ReadOnly Property Contains(ByVal i_WBName As String) As Boolean Implements iCTPHandler.Contains
        Get
          Return Me.ct_CTPs.ContainsKey(key:= GetWHnd(i_WHnd:= i_WBName))
        End Get
      End Property
      '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
      Public ReadOnly Property CTP(ByVal i_WBName As String)  As CustomTaskPane Implements iCTPHandler.CTP
        Get
          Return Me.ct_CTPs.Item(key:= GetWHnd(i_WHnd:= i_WBName))
        End Get
      End Property

    #End Region

    #Region "Methods"

      Friend Sub ClearOnWBookClose(ByVal i_WBookName As String) Implements iCTPHandler.ClearOnWBookClose

        Dim lt_CTPDel = (From ls_CTP In Me.ct_WB2WHnd
                          Where ls_CTP.Value = i_WBookName
                            Select ls_CTP).ToList()

        For Each ls_CTP As KeyValuePair(Of String, String) In lt_CTPDel

          ' Remove the CTP's as this may have been closed by BACKSTAGE so need to tidy up
          ' Only if last workbook else the CTP is refreshed
          '
          If Globals.ThisAddIn.Application.Workbooks.Count = 1
            If Me.ct_CTPs.TryGetValue(ls_CTP.Key,Me.co_CTPActive)
              Globals.ThisAddIn.CustomTaskPanes.Remove(co_CTPActive)
              'Globals.Ribbons.xSAPtorRB.xBtn_Toggle_CTP.Checked = False
              Me.co_CTPActive = Nothing
          End If
          End If

          Me.ct_CTPs.Remove(key:=ls_CTP.Key)
          Me.ct_WB2WHnd.Remove(key:=ls_CTP.Key)

        Next

      End Sub

    #End Region

    #Region "Private Methods"

      '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
      Private Function GetWHnd(Optional ByRef i_WHnd As String = Nothing) As String

        If Me.cb_IsMDIExcel
          If IsNothing(i_WHnd)
            Return CStr(Me.co_ExcelHelper.GetActiveWindowHandle)
          Else
            Return i_WHnd
          End If
        Else
          Return cz_SDIWHnd
        End If

      End Function
      '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
      Private Sub CreateCTP()

        Dim lo_UC   As Windows.Forms.UserControl
    
        lo_UC = CType(Activator.CreateInstance(type:= Me.co_UserControl), Windows.Forms.UserControl)

        If Me.cb_IsMDIExcel
          Me.co_CTPActive = Globals.ThisAddIn.CustomTaskPanes.Add(control:= lo_UC,
                                                                  title  := Me.cc_CTPTitle,
                                                                  window := Globals.ThisAddIn.Application.ActiveWindow
                                                                  )
        Else
          Me.co_CTPActive = Globals.ThisAddIn.CustomTaskPanes.Add(control:= lo_UC,
                                                                  title  := Me.cc_CTPTitle
                                                                  )
        End If

        With Me.co_CTPActive
          .DockPosition = Me.cn_CTPPosition
          .Width        = .Control.Width + 200
        End With

      End Sub
      '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
      Private Sub ShowCTP()

        Dim lc_WHnd As String = Me.GetWHnd()

        IF Not Me.ct_CTPs.TryGetValue(key   := lc_WHnd,
                                      value := Me.co_CTPActive)
          Me.CreateCTP()
          Me.ct_CTPs.Add(key  := lc_WHnd,
                         value:= Me.co_CTPActive
                         )

          Dim lc_WBName As String = Me.co_ExcelHelper.GetActiveWBookName()

          Me.ct_WB2WHnd.Add(key   := lc_WHnd,
                            value := lc_WBName
                            )

        End If

        If Not IsNothing(Me.co_CTPActive)
          With Me.co_CTPActive
            .Visible = True
          End With
        End If

      End Sub
      '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
      Private Sub HideCTP()

        If Not IsNothing(Me.co_CTPActive)
          With Me.co_CTPActive
            .Visible = False
          End With
        End If

      End Sub

    #End Region

    #Region "co_CTPActive Event Handlers"

      '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
      Private Sub CTP_VisibiltyChanged(sender As Object, e As EventArgs) Handles co_CTPActive.VisibleChanged
        RaiseEvent CTPVisibilityChanged()
      End Sub

    #End Region

    #Region "Constructor"

      '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
      Friend Sub New(ByRef i_UserControl  As System.Type, 
                     ByRef i_Title        As String, 
                     ByRef i_Position     As Integer)

        Me.co_UserControl = i_UserControl
        Me.cc_CTPTitle    = i_Title
        Me.cn_CTPPosition = CType(i_Position, Microsoft.Office.Core.MsoCTPDockPosition)

        Me.co_ExcelHelper = ExcelHelper.GetInstance()
        Me.ct_CTPs        = New Dictionary(Of String, CustomTaskPane)
        Me.ct_WB2WHnd     = New Dictionary(Of String, String)

        Me.cb_IsMDIExcel  = me.co_ExcelHelper.IsMDIExcelVersion()

      End Sub

    #End Region

  End Class

End Namespace