Imports System.Threading
Imports System.Windows.Forms
Imports xSAPtorExcel.Main
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace UI.Ribbon

  Friend MustInherit Class xSAPRibbonEvntHndlr_Base

    #Region "Defintions"

      Protected WithEvents co_xSAPCntlrMain As Lazy(Of ixSAPMainController) _
                            = New Lazy(Of ixSAPMainController)(
                                Function() xSAPMainController.GetInstance(),
                                           LazyThreadSafetyMode.ExecutionAndPublication )

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Methods: Base"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Protected Sub HandleVisibility(ByRef i_Form As Form)

        If i_Form.Visible
          If i_Form.WindowState = FormWindowState.Minimized
            i_Form.WindowState = FormWindowState.Normal
          Else
            i_Form.Hide()
          End If
        Else
          i_Form.Show()
        End If

      End Sub

    #End Region

  End Class

End Namespace