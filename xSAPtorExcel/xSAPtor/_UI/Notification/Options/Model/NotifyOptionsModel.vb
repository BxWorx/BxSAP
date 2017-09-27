Imports System.Threading
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Notification.Options

	Friend Class NotifyOptionsModel
								Implements iNotifyOptionsModel

		#Region "Definitions"

			Private	co_DTO	As iNotifyOptionsDTO

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateDTO(Optional	ByVal	_usedef	As	Boolean	=	False)	As iNotifyOptionsDTO _
													Implements iNotifyOptionsModel.CreateDTO

				Return	New NotifyOptionsDTO(_usedef)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Fetch()	As	iNotifyOptionsDTO	_
									Implements iNotifyOptionsModel.Fetch

				Dim	lo_CfgOpt	= so_HlprGeneric.Value.DeSerializeObjectViaDataContract(Of NotifyOptionsXML)(My.Settings.Notify_OptionsXML)
				Me.co_DTO			= Me.CreateDTO(True)

				If lo_CfgOpt IsNot Nothing

					Me.co_DTO.ShowInformation	=	lo_CfgOpt.ShowInformation
					Me.co_DTO.ShowWarning			=	lo_CfgOpt.ShowWarning
					Me.co_DTO.ShowError				=	lo_CfgOpt.ShowError
					Me.co_DTO.ShowSystem			=	lo_CfgOpt.ShowSystem
					Me.co_DTO.ShowTrace				=	lo_CfgOpt.ShowTrace

					Me.co_DTO.LogInformation	=	lo_CfgOpt.LogInformation
					Me.co_DTO.LogWarning			=	lo_CfgOpt.LogWarning
					Me.co_DTO.LogError				=	lo_CfgOpt.LogError
					Me.co_DTO.LogSystem				=	lo_CfgOpt.LogSystem
					Me.co_DTO.LogTrace				=	lo_CfgOpt.LogTrace
					Me.co_DTO.LogSize					=	lo_CfgOpt.LogSize

					Me.co_DTO.MsgStarted			=	lo_CfgOpt.MsgStarted
					'................................................
					If	Me.co_DTO.LogSize	< 1		OrElse
							Me.co_DTO.LogSize	> 100
						Me.co_DTO.LogSize	= 20
					End If

				End If

				Return	Me.co_DTO

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function	Save(ByVal _dto	As	iNotifyOptionsDTO)	As Boolean _
												Implements iNotifyOptionsModel.Save

				If	Me.co_DTO.ShowInformation		<>	_dto.ShowInformation		OrElse
						Me.co_DTO.ShowWarning				<>	_dto.ShowWarning				OrElse
						Me.co_DTO.ShowError					<>	_dto.ShowError					OrElse
						Me.co_DTO.ShowSystem				<>	_dto.ShowSystem					OrElse
						Me.co_DTO.ShowTrace					<>	_dto.ShowTrace					OrElse
						Me.co_DTO.LogInformation		<>	_dto.LogInformation			OrElse
						Me.co_DTO.LogWarning				<>	_dto.LogWarning					OrElse
						Me.co_DTO.LogError					<>	_dto.LogError						OrElse
						Me.co_DTO.LogSystem					<>	_dto.LogSystem					OrElse
						Me.co_DTO.LogTrace					<>	_dto.LogTrace						OrElse
						Me.co_DTO.LogSize						<>	_dto.LogSize						OrElse
						Me.co_DTO.MsgStarted				<>	_dto.MsgStarted

					Dim	lo_CfgOpt	=	New	NotifyOptionsXML()

					lo_CfgOpt.ShowInformation	=	_dto.ShowInformation
					lo_CfgOpt.ShowWarning			=	_dto.ShowWarning
					lo_CfgOpt.ShowError				=	_dto.ShowError
					lo_CfgOpt.ShowSystem			=	_dto.ShowSystem
					lo_CfgOpt.ShowTrace				=	_dto.ShowTrace

					lo_CfgOpt.LogInformation	=	_dto.LogInformation
					lo_CfgOpt.LogWarning			=	_dto.LogWarning
					lo_CfgOpt.LogError				=	_dto.LogError
					lo_CfgOpt.LogSystem				=	_dto.LogSystem
					lo_CfgOpt.LogTrace				=	_dto.LogTrace
					lo_CfgOpt.LogSize					=	_dto.LogSize

					lo_CfgOpt.MsgStarted			=	_dto.MsgStarted
					'................................................
					My.Settings.Notify_OptionsXML	= so_HlprGeneric.Value.SerializeObjectViaDataContract(lo_CfgOpt)
					My.Settings.Save()

					Return	True

				Else
					Return	False
				End If

			End Function

		#End Region

	End Class

End Namespace
