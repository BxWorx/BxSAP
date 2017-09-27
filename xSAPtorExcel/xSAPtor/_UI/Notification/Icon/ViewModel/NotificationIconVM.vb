Imports System.Threading
Imports System.Windows.Forms

Imports xSAPtorExcel.Main.Notification.Log
Imports xSAPtorExcel.Main.Notification.Options
Imports xSAPtorExcel.Utilities.MsgHub
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Notification.Icon

	Friend Class NotificationIconVM
								Implements iNotificationIconVM

		#Region "Definitions"

			Private	co_Parent										As	IWin32Window
			Private co_ModelLog									As	iNotificationLogModel

			Private	co_Settings									As	iNotifyOptionsDTO
			Private	co_SubStartStop							As	iSubscription(Of sMsgStartupShutdown)
			Private	co_SubNotify   							As	iSubscription(Of iNotificationMessageDTO)
			Private	co_ContextMenu							As	ContextMenu

			Private	WithEvents	co_View					As	NotificationIconView

			Private	WithEvents	co_OptionsVM		As	Lazy(Of iNotificationOptionsVM) _
																								= New Lazy(Of iNotificationOptionsVM)(
																										Function()	New NotificationOptionsVM(),
																										LazyThreadSafetyMode.ExecutionAndPublication )

			Private	WithEvents	co_LogVM				As	Lazy(Of iNotificationLogVM) _
																								= New Lazy(Of iNotificationLogVM)(
																										Function()	New NotificationLogVM(),
																										LazyThreadSafetyMode.ExecutionAndPublication )

			Private	cf_FlagsNot		As	LogType
			Private	cf_FlagsLog		As	LogType

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Poperties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	ShowStartupMsg	As Boolean _
																		Implements iNotificationIconVM.ShowStartupMg
				Get
					Return	Me.co_Settings.MsgStarted
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Process: Context Menu"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub ev_ContextMenu_Click_EventHandler(sender	As Object, e	As EventArgs)

				Select Case CType(System.Enum.Parse(GetType(iNotificationIconVM.en_NotificationMenuType), CType(sender, MenuItem).Text), iNotificationIconVM.en_NotificationMenuType)

					Case iNotificationIconVM.en_NotificationMenuType.Options		: ContextMenuClickEventHandler_Options()
					Case iNotificationIconVM.en_NotificationMenuType.Log				: ContextMenuClickEventHandler_Log()
					Case iNotificationIconVM.en_NotificationMenuType.Monitor		:
					Case iNotificationIconVM.en_NotificationMenuType.Runner		:

				End Select

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub ContextMenuClickEventHandler_Options()

				Me.co_OptionsVM.Value.Show()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub ContextMenuClickEventHandler_Log()

				Me.co_LogVM.Value.Show()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub ShowNotificationOptions() _
												Implements	iNotificationIconVM.ShowNotificationOptions

				Me.co_OptionsVM.Value.Show()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub ShowNotificationLog() _
												Implements	iNotificationIconVM.ShowNotificationLog

				Me.co_LogVM.Value.Show()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateLogModel()	As iNotificationLogModel _
													Implements iNotificationIconVM.CreateLogModel

				Return	NotificationLogModel.NotificationLogModel()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetSettings()	As iNotifyOptionsDTO _
													Implements iNotificationIconVM.GetSettings

				Return	Me.co_Settings

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateDTO(Optional ByVal _text	As	String	= Nothing)	As iNotificationMessageDTO _
													Implements iNotificationIconVM.CreateDTO

				Return	New	NotificationMessageDTO(_text)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub	AddMenuItem(					ByVal	_type			As iNotificationIconVM.en_NotificationMenuType	,
															Optional	ByVal	_upddisp	As	Boolean	=	False)	_
										Implements iNotificationIconVM.AddMenuItem

				If Me.co_ContextMenu.MenuItems.ContainsKey(_type.ToString)	Then	Exit	Sub
				'..................................................
				Dim lc_Text	As String	= Nothing

				Select Case _type

					Case iNotificationIconVM.en_NotificationMenuType.Log
						If	Me.co_Settings.LogInformation	OrElse
								Me.co_Settings.LogWarning			OrElse
								Me.co_Settings.LogError
							
							lc_Text	= "Show Log"

						End If

					Case iNotificationIconVM.en_NotificationMenuType.Options	: lc_Text	= "Options"
					Case iNotificationIconVM.en_NotificationMenuType.Monitor	: lc_Text	= "Show Process Monitor"
					Case iNotificationIconVM.en_NotificationMenuType.Runner	:	lc_Text	= "Show Background Runner"

					Case Else																									:	lc_Text	= Nothing

				End Select
				
				If lc_Text Is Nothing	Then	Exit	Sub
				'..................................................
				Dim lo_Item As New MenuItem(_type.ToString, AddressOf	ev_ContextMenu_Click_EventHandler)

				Me.co_ContextMenu.MenuItems.Add(lo_Item)
				'..................................................
				If _upddisp

					Me.co_View.SuspendLayout()
					Me.co_View.xnot_Handler.ContextMenu = Me.co_ContextMenu
					Me.co_View.ResumeLayout

				End If

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(Optional	_parent	As IWin32Window	= Nothing)

				Me.co_Parent	= _parent
				'..................................................
				Me.co_ModelLog	= NotificationLogModel.NotificationLogModel()
				Me.co_Settings	= Me.co_OptionsVM.Value.GetOptions()
				'..................................................
				Me.PrepareView()
				Me.PrepareOps()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub PrepareOps()

				Me.cf_FlagsNot	= Me.cf_FlagsNot	Or	CType(IIf(Me.co_Settings.ShowInformation	,	LogType.info	, LogType.none)	,	LogType)
				Me.cf_FlagsNot	= Me.cf_FlagsNot	Or	CType(IIf(Me.co_Settings.ShowWarning			,	LogType.warn	, LogType.none)	,	LogType)
				Me.cf_FlagsNot	= Me.cf_FlagsNot	Or	CType(IIf(Me.co_Settings.ShowError				,	LogType.err		, LogType.none)	,	LogType)
				Me.cf_FlagsNot	= Me.cf_FlagsNot	Or	CType(IIf(Me.co_Settings.ShowSystem				,	LogType.syst	, LogType.none)	,	LogType)
				Me.cf_FlagsNot	= Me.cf_FlagsNot	Or	CType(IIf(Me.co_Settings.ShowTrace				,	LogType.trce	, LogType.none)	,	LogType)
				'..................................................
				Me.cf_FlagsLog	= Me.cf_FlagsLog	Or	CType(IIf(Me.co_Settings.LogInformation		,	LogType.info	, LogType.none)	,	LogType)
				Me.cf_FlagsLog	= Me.cf_FlagsLog	Or	CType(IIf(Me.co_Settings.LogWarning				,	LogType.warn	, LogType.none)	,	LogType)
				Me.cf_FlagsLog	= Me.cf_FlagsLog	Or	CType(IIf(Me.co_Settings.LogError					,	LogType.err		, LogType.none)	,	LogType)
				Me.cf_FlagsLog	= Me.cf_FlagsLog	Or	CType(IIf(Me.co_Settings.LogSystem				,	LogType.syst	, LogType.none)	,	LogType)
				Me.cf_FlagsLog	= Me.cf_FlagsLog	Or	CType(IIf(Me.co_Settings.LogTrace					,	LogType.trce	, LogType.none)	,	LogType)
				'..................................................
				Me.co_SubStartStop	= so_MsgHub.Value.Subscribe(Of sMsgStartupShutdown)			(AddressOf	Me.mh_StartupShutdown)
				Me.co_SubNotify			= so_MsgHub.Value.Subscribe(Of iNotificationMessageDTO)	(AddressOf	Me.ShowNotification)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub PrepareView()

				Me.co_View										= New NotificationIconView()
				Me.co_ContextMenu							= New ContextMenu

				Me.AddMenuItem(iNotificationIconVM.en_NotificationMenuType.Options	, False	)
				Me.AddMenuItem(iNotificationIconVM.en_NotificationMenuType.Log			, True	)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub ShowNotification(ByVal _dto	As iNotificationMessageDTO)

				If Me.cf_FlagsNot.HasFlag(_dto.Type)

					If			_dto.Type.Equals(LogType.info)	:	Me.co_View.xnot_Handler.BalloonTipIcon	= ToolTipIcon.Info
					ElseIf	_dto.Type.Equals(LogType.warn)	:	Me.co_View.xnot_Handler.BalloonTipIcon	= ToolTipIcon.Warning
					ElseIf	_dto.Type.Equals(LogType.err)		:	Me.co_View.xnot_Handler.BalloonTipIcon	= ToolTipIcon.Error
					ElseIf	_dto.Type.Equals(LogType.syst)	:	Me.co_View.xnot_Handler.BalloonTipIcon	= ToolTipIcon.Error
					ElseIf	_dto.Type.Equals(LogType.trce)	:	Me.co_View.xnot_Handler.BalloonTipIcon	= ToolTipIcon.Info
					Else																		:	Me.co_View.xnot_Handler.BalloonTipIcon	= ToolTipIcon.None
					End If

					Me.co_View.xnot_Handler.BalloonTipTitle	= _dto.Title

					If	_dto.Text Is Nothing				OrElse
							_dto.Text.Length.Equals(0)
						Me.co_View.xnot_Handler.BalloonTipText	= "..."
					Else
						Me.co_View.xnot_Handler.BalloonTipText	= _dto.Text
					End If

					Me.co_View.xnot_Handler.ShowBalloonTip(0)

				End If
				'..................................................
				If Me.cf_FlagsLog.HasFlag(_dto.Type)
					If Me.co_ModelLog.Log(_dto)
						so_MsgHub.Value.Publish(New sMsgLogView())
					End If
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub mh_StartupShutdown(ByVal _msg As sMsgStartupShutdown)

				Dim lo_DTO	As	iNotificationMessageDTO

				If _msg.IsShutdown
					
					so_MsgHub.Value.Unsubscribe(Me.co_SubStartStop)
					'................................................
					If Me.ShowStartupMsg

						lo_DTO	=	Me.CreateDTO("Shutdown")
						so_MsgHub.Value.Publish(lo_DTO)

					End If

					If Me.co_OptionsVM.IsValueCreated	Then	Me.co_OptionsVM.Value.Shutdown()
					'................................................
					so_MsgHub.Value.Unsubscribe(Me.co_SubNotify)
					'................................................
					Me.co_View.Close()
					Me.co_View.Dispose()

				Else

					If Me.ShowStartupMsg

						lo_DTO	=	Me.CreateDTO("Started")
						so_MsgHub.Value.Publish(lo_DTO)

					End If

				End If

			End Sub

		#End Region

	End Class

End Namespace