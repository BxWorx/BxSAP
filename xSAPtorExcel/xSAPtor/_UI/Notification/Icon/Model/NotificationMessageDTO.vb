Imports	System.Threading
Imports System.Windows.Forms
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Notification.Icon

	Friend Class NotificationMessageDTO
								Implements iNotificationMessageDTO

		#Region "Properties"

			Friend	Property	Type				As LogType			Implements iNotificationMessageDTO.Type
			Friend	Property	Title				As String				Implements iNotificationMessageDTO.Title
			Friend	Property	Text				As String				Implements iNotificationMessageDTO.Text
			Friend	Property	Timestamp		As Date					Implements iNotificationMessageDTO.Timestamp
			Friend	Property	ExecThread	As Integer			Implements iNotificationMessageDTO.ExecThread

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Clone(Optional ByVal _text	As	String	= Nothing)	As iNotificationMessageDTO _
													Implements iNotificationMessageDTO.Clone

				Dim lo_DTO	= DirectCast(Me.MemberwiseClone(), iNotificationMessageDTO)

				lo_DTO.Timestamp	= Date.UtcNow
				lo_DTO.ExecThread	= Thread.CurrentThread.ManagedThreadId
				'...................................................
				If _text IsNot Nothing
					lo_DTO.Text	= _text
				End If
				'...................................................
				Return	lo_DTO

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(Optional ByVal _text	As	String	= Nothing)

				Me.Type				= LogType.info
				Me.Title			= "xSAPtor"
				Me.Timestamp	= Date.UtcNow
				Me.ExecThread	=	Thread.CurrentThread.ManagedThreadId
				'...................................................
				If _text IsNot Nothing
					Me.Text	= _text
				End If

			End Sub

		#End Region

	End Class

End Namespace