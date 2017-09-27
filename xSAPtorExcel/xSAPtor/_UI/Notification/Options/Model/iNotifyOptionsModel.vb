'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Notification.Options

	Friend Interface iNotifyOptionsModel

		#Region "Methods"

			Function	CreateDTO(Optional	ByVal	UseDefaults	As	Boolean	=	False)		As	iNotifyOptionsDTO
			Function	Fetch()																												As	iNotifyOptionsDTO
			Function	Save(ByVal	DTO	As iNotifyOptionsDTO)													As	Boolean

		#End Region

	End Interface

End Namespace