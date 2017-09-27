Imports System.Threading
Imports xSAPtorExcel.Main
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace UI.Ribbon

  Friend Class xSAPRbnEvntHndlr_SAPLogon
                Inherits    xSAPRibbonEvntHndlr_Base
                Implements  ixSAPRibbonEventHandling

    #Region "Defintions"

      Private WithEvents co_SAPGUI      As Lazy(Of xSAPLogonGui)
      Private WithEvents co_OptionsForm As Lazy(Of xSAPLogonOptions)

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Methods"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Friend Sub EventHandler(ByVal i_Tag As String) _
                  Implements ixSAPRibbonEventHandling.EventHandler

        Select Case i_Tag
          Case "xtag_SelectSAP"       : Me.SAPLogonForm_EventHandler()
          Case "xtag_SAPGUIOptions"   : Me.Options_EventHandler()
        End Select

      End Sub

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Methods: Private"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Private Sub Options_EventHandler()

        If Me.co_OptionsForm Is Nothing OrElse
           Me.co_OptionsForm.Value.IsDisposed()

          Me.co_OptionsForm = New Lazy(Of xSAPLogonOptions)(
                                    Function()  Me.co_xSAPCntlrMain.Value.GetSAPLogonOptionsForm(),
                                                LazyThreadSafetyMode.ExecutionAndPublication )

        End If

        Me.HandleVisibility(i_Form:= Me.co_OptionsForm.Value)

      End Sub
      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Private Sub SAPLogonForm_EventHandler()

        If Me.co_SAPGUI Is Nothing OrElse
           Me.co_SAPGUI.Value.IsDisposed()

          Me.co_SAPGUI = New Lazy(Of xSAPLogonGui)(
                                    Function()  Me.co_xSAPCntlrMain.Value.GetSAPLogonGUIForm(),
                                                LazyThreadSafetyMode.ExecutionAndPublication )

        End If

        Me.HandleVisibility(i_Form:= Me.co_SAPGUI.Value)

      End Sub

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Constructors: Singleton"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Private Shared ReadOnly _Instance As Lazy(Of ixSAPRibbonEventHandling) _
                                = New Lazy(Of ixSAPRibbonEventHandling)(
                                    Function()  New xSAPRbnEvntHndlr_SAPLogon,
                                                LazyThreadSafetyMode.ExecutionAndPublication )
      Public Shared ReadOnly Property GetInstance() As ixSAPRibbonEventHandling
        Get
          Return _Instance.Value
        End Get
      End Property
      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Private Sub New()
      End Sub

    #End Region

  End Class

End Namespace