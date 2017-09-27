Imports System.Windows.Forms
Imports xSAPtorExcel.Main.About
Imports	BxS.API.About
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Friend NotInheritable Class xSAPtorNCOSplash
															Implements ixSAPtorNCOAbout

	#Region "Definitions"

		Friend WithEvents co_Cntlr	As ixSAPAboutController

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods: Form Handling"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Overloads ReadOnly Property IsDisposed() _
							As Boolean _
								Implements ixSAPtorNCOAbout.IsDisposed
			Get
				Return MyBase.IsDisposed()
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Sub HandleVisibility() _
								Implements ixSAPtorNCOAbout.HandleVisibility

			If Me.Visible
				If Me.WindowState = FormWindowState.Minimized
					Me.WindowState = FormWindowState.Normal
				Else
					Me.Hide()
				End If
			Else
				Me.Show()
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xSAPtorNCOSplash_Load(ByVal sender  As Object,
																			ByVal e       As System.EventArgs) _
									Handles Me.Load

			Dim lo_InfoProvider As iBxSNCOAboutInfo	= Me.co_Cntlr.GetNCOAboutInfo()

			ApplicationTitle.Text     = lo_InfoProvider.Title

			xlbl_OSVersion.Text       = String.Format(xlbl_OSVersion.Text       , lo_InfoProvider.OS)
			xlbl_NCOVersion.Text      = String.Format(xlbl_NCOVersion.Text      , lo_InfoProvider.NCOVersion)
			xlbl_CLRVersion.Text      = String.Format(xlbl_CLRVersion.Text      , lo_InfoProvider.CLRVersion)
			xlbl_HostName.Text        = String.Format(xlbl_HostName.Text        , lo_InfoProvider.HostName)
			xlbl_IPV4.Text            = String.Format(xlbl_IPV4.Text            , lo_InfoProvider.IPV4)
			xlbl_SAPKnlRelease.Text   = String.Format(xlbl_SAPKnlRelease.Text   , lo_InfoProvider.KernelRelease)
			xlbl_SAPKnlPatchLev.Text  = String.Format(xlbl_SAPKnlPatchLev.Text  , lo_InfoProvider.KernelPatchLevel)
			xlbl_SAPRelease.Text      = String.Format(xlbl_SAPRelease.Text      , lo_InfoProvider.SAPRelease)

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xSAPtorNCOSplash_LostFocus(sender As Object, e As EventArgs) _
									Handles Me.LostFocus

			Me.Close()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub ev_FormEscape(	sender	As Object,
																e				As KeyEventArgs) _
									Handles Me.KeyDown

			If e.KeyCode.Equals(Keys.Escape)	Then	Me.Close()

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Constructors"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Sub New(ByVal i_Controller As ixSAPAboutController)

			InitializeComponent()

			Me.co_Cntlr	= i_Controller

		End Sub

	#End Region

End Class
