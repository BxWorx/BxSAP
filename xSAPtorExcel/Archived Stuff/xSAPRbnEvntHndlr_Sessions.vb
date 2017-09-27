Imports System.Threading
Imports xSAPtorExcel.Main.Session
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace UI.Ribbon

	Friend Class xSAPRbnEvntHndlr_Sessions
								Inherits    xSAPRibbonEvntHndlr_Base
								Implements  ixSAPRibbonEventHandling

		#Region "Defintions"

			Private co_CntlrSession	As Lazy(Of ixSessionController)	_
								= New Lazy(Of ixSessionController)(
										Function()	xSessionController.GetInstance(),
																LazyThreadSafetyMode.ExecutionAndPublication )


			Private WithEvents co_SessionForm   As Lazy(Of xSAPSessions)
			Private WithEvents co_OptionsForm   As Lazy(Of xSAPSessionOptions)
			Private WithEvents co_ConfigForm    As Lazy(Of xSAPBDCConfig)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub EventHandler(ByVal i_Tag As String) _
									Implements ixSAPRibbonEventHandling.EventHandler

				Select Case i_Tag
					Case "xtag_SessionSAP"        : Me.SessionForm_EventHandler()
					Case "xtag_SessionOptions"    : Me.Options_EventHandler
					Case "xtag_SessionConfigure"  : Me.Config_EventHandler
				End Select

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Config_EventHandler()

				If Me.co_ConfigForm Is Nothing OrElse
					 Me.co_ConfigForm.Value.IsDisposed()

					'Me.co_ConfigForm = New Lazy(Of xSAPBDCConfig)(
					'                          Function()  Me.co_xSAPCntlrMain.Value.GetSessionConfigForm(),
					'                                      LazyThreadSafetyMode.ExecutionAndPublication )

				End If

				Me.HandleVisibility(i_Form:= Me.co_ConfigForm.Value)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Options_EventHandler()

				If Me.co_OptionsForm Is Nothing OrElse
					 Me.co_OptionsForm.Value.IsDisposed()

					'Me.co_OptionsForm = New Lazy(Of xSAPSessionOptions)(
					'                          Function()  Me.co_xSAPCntlrMain.Value.GetSessionOptionsForm(),
					'                                      LazyThreadSafetyMode.ExecutionAndPublication )

				End If

				Me.HandleVisibility(i_Form:= Me.co_OptionsForm.Value)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub SessionForm_EventHandler()

				If Me.co_SessionForm Is Nothing OrElse
					 Me.co_SessionForm.Value.IsDisposed()

					'Me.co_SessionForm = New Lazy(Of xSAPSessions)(
					'                          Function()  Me.co_xSAPCntlrMain.Value.GetSessionSelectionForm(),
					'                                      LazyThreadSafetyMode.ExecutionAndPublication )

				End If

				Me.HandleVisibility(i_Form:= Me.co_SessionForm.Value)

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors: Singleton"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Shared ReadOnly _Instance As Lazy(Of ixSAPRibbonEventHandling) _
																= New Lazy(Of ixSAPRibbonEventHandling)(
																		Function()  New xSAPRbnEvntHndlr_Sessions,
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