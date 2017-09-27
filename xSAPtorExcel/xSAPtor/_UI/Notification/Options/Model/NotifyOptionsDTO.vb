'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Notification.Options

	Friend Class NotifyOptionsDTO
								Implements iNotifyOptionsDTO

		#Region "Properties"

			Friend	Property	ShowInformation()		As	Boolean		Implements iNotifyOptionsDTO.ShowInformation
			Friend	Property	ShowWarning()				As	Boolean		Implements iNotifyOptionsDTO.ShowWarning
			Friend	Property	ShowError()					As	Boolean		Implements iNotifyOptionsDTO.ShowError
			Friend	Property	ShowTrace()					As	Boolean		Implements iNotifyOptionsDTO.ShowTrace
			Friend	Property	ShowSystem()				As	Boolean		Implements iNotifyOptionsDTO.ShowSystem

			Friend	Property	LogInformation()		As	Boolean		Implements iNotifyOptionsDTO.LogInformation
			Friend	Property	LogWarning()				As	Boolean		Implements iNotifyOptionsDTO.LogWarning
			Friend	Property	LogError()					As	Boolean		Implements iNotifyOptionsDTO.LogError
			Friend	Property	LogTrace()					As	Boolean		Implements iNotifyOptionsDTO.LogTrace
			Friend	Property	LogSystem()					As	Boolean		Implements iNotifyOptionsDTO.LogSystem
			Friend	Property	LogSize()						As	Integer		Implements iNotifyOptionsDTO.LogSize

			Friend	Property	MsgStarted()				As	Boolean		Implements iNotifyOptionsDTO.MsgStarted

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(Optional WithDefaults As Boolean	= False)

				If WithDefaults

					Me.ShowInformation	= True
					Me.ShowWarning			= True
					Me.ShowError				= True
					Me.ShowSystem				= True
					Me.ShowTrace				= True

					Me.LogInformation		= True
					Me.LogWarning				= True
					Me.LogError					= True
					Me.LogSystem				= True
					Me.LogTrace					= True
					Me.LogSize					= 20

					Me.MsgStarted				= True

				End If
				
			End Sub

		#End Region

	End Class

End Namespace
