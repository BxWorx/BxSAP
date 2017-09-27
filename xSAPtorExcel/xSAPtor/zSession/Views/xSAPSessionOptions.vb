Imports System.ComponentModel
Imports System.Windows.Forms
Imports xSAPtorExcel.Main.Session
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Friend Class xSAPSessionOptions
							Implements ixSAPSessionOptions

	#Region "Definitions"

		Private WithEvents	co_Cntlr				As ixSessionController
		Private							co_InfoProvider	As iSessionOptionsDTO
		Private							cb_Changed			As Boolean

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Constructor/Destruction: Methods & Events"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Shared Function Create(ByVal Controller As ixSessionController) _
														As ixSAPSessionOptions

			Return New xSAPSessionOptions(i_Controller:= Controller)

		End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub New(ByVal i_Controller As ixSessionController)

			InitializeComponent()

			Me.co_Cntlr		= i_Controller
			Me.cb_Changed	= False

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xSessionOptions_Load(sender As Object,
																		 e      As EventArgs) _
									Handles Me.Load

			Me.co_InfoProvider = Me.co_Cntlr.FetchSessionOptions()

			Me.xchb_OptimizeUpload.Checked  = Me.co_InfoProvider.OptimiseUpload
			Me.xchb_SaveSelection.Checked		= Me.co_InfoProvider.SaveSelection
			Me.xnud_NoOfProcesses.Value     = CDec( Me.co_InfoProvider.ParallelProcesses )

			AddHandler xchb_OptimizeUpload.CheckedChanged,	AddressOf CheckStateChanged
			AddHandler xchb_SaveSelection.CheckedChanged,		AddressOf CheckStateChanged
			AddHandler xnud_NoOfProcesses.TextChanged,			AddressOf CheckStateChanged

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xSessionOptions_Closing(sender  As Object,
																				e       As CancelEventArgs) _
									Handles Me.Closing

			If Me.cb_Changed

				If Me.co_InfoProvider.OptimiseUpload		<> Me.xchb_OptimizeUpload.Checked OrElse
					Me.co_InfoProvider.SaveSelection			<> Me.xchb_SaveSelection.Checked	OrElse
					Me.co_InfoProvider.ParallelProcesses	<>	CInt( Me.xnud_NoOfProcesses.Value )

					Me.co_InfoProvider.OptimiseUpload     = Me.xchb_OptimizeUpload.Checked
					Me.co_InfoProvider.SaveSelection			= Me.xchb_SaveSelection.Checked
					Me.co_InfoProvider.ParallelProcesses  = CInt( Me.xnud_NoOfProcesses.Value )
	
					If Me.co_Cntlr.SaveSessionOptions(i_Options:= Me.co_InfoProvider)
						'TO-DO: write to log
					End If

				End If

			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub ev_FormEscape(	sender	As Object,
																e				As KeyEventArgs) _
									Handles Me.KeyDown

			If e.KeyCode.Equals(Keys.Escape)	Then	Me.Close()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub CheckStateChanged(sender As Object, e As EventArgs)

			Me.cb_Changed	= True

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Overloads ReadOnly Property IsDisposed() As Boolean Implements ixSAPSessionOptions.IsDisposed
			Get
				Return MyBase.IsDisposed()
			End Get
		End Property

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Sub HandleVisibility() _
								Implements ixSAPSessionOptions.HandleVisibility

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

	#End Region

End Class
