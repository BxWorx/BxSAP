Imports System.Windows.Forms
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Notification.Options

	Friend Class NotificationOptionsView

		#Region "Definitions"

			Private	cb_Changed		As Boolean

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Form Handling"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	Changed	As Boolean
				Get
					Return	Me.cb_Changed
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	LoadData(ByVal _dto	As iNotifyOptionsDTO)

				Me.xchb_ShowInfo.Checked		= _dto.ShowInformation
				Me.xchb_ShowWarning.Checked = _dto.ShowWarning
				Me.xchb_ShowError.Checked		= _dto.ShowError
				Me.xchb_ShowSyst.Checked		= _dto.ShowSystem
				Me.xchb_ShowTrace.Checked		= _dto.ShowTrace

				Me.xchb_LogInfo.Checked			= _dto.LogInformation
				Me.xchb_LogWarn.Checked			= _dto.LogWarning
				Me.xchb_LogError.Checked		= _dto.LogError
				Me.xchb_LogSyst.Checked		= _dto.LogSystem
				Me.xchb_LogTrace.Checked		= _dto.LogTrace
				Me.xnud_LogSize.Value				= CDec( _dto.LogSize )

				Me.xchb_MsgStarted.Checked	= _dto.MsgStarted

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub UpdatedData(ByRef	_dto	As iNotifyOptionsDTO)

				_dto.ShowInformation	= Me.xchb_ShowInfo.Checked
				_dto.ShowWarning			= Me.xchb_ShowWarning.Checked
				_dto.ShowError				= Me.xchb_ShowError.Checked
				_dto.ShowSystem				= Me.xchb_ShowSyst.Checked
				_dto.ShowTrace				= Me.xchb_ShowTrace.Checked

				_dto.LogInformation		= Me.xchb_LogInfo.Checked
				_dto.LogWarning				= Me.xchb_LogWarn.Checked
				_dto.LogError					= Me.xchb_LogError.Checked
				_dto.LogSystem				= Me.xchb_LogSyst.Checked
				_dto.LogTrace					= Me.xchb_LogTrace.Checked
				_dto.LogSize					= CInt( Me.xnud_LogSize.Value )

				_dto.MsgStarted				=	Me.xchb_MsgStarted.Checked

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub ev_FormEscape(	sender	As Object,
																	e				As KeyEventArgs) _
										Handles Me.KeyDown

				If e.KeyCode.Equals(Keys.Escape)	Then	Me.Close()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub SetStateChanged(sender As Object,	e	As EventArgs) _
										Handles	xchb_ShowError.CheckedChanged,
														xchb_ShowInfo.CheckedChanged,
														xchb_ShowWarning.CheckedChanged,
														xchb_ShowSyst.CheckedChanged,
														xchb_ShowTrace.CheckedChanged,
														xchb_LogInfo.CheckedChanged,
														xchb_LogWarn.CheckedChanged,
														xchb_LogError.CheckedChanged,
														xchb_LogSyst.CheckedChanged,
														xchb_LogTrace.CheckedChanged,
														xchb_MsgStarted.CheckedChanged,
														xnud_LogSize.ValueChanged

				Me.cb_Changed	= True

			End Sub
										
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor/Destruction: Methods & Events"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New()

				InitializeComponent()

				Me.cb_Changed	= False

			End Sub

		#End Region

	End Class

End Namespace