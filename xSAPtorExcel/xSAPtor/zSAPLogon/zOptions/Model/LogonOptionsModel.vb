'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Class	LogonOptionsModel
									Implements iLogonOptionsModel

		#Region "Definitions"

			Private	co_DTO		As iLogonOptionsDTO

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function CreateDTO()	As iLogonOptionsDTO _
												Implements iLogonOptionsModel.CreateDTO

				Return	New LogonOptionsDTO

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function Fetch()	As iLogonOptionsDTO _
												Implements iLogonOptionsModel.Fetch

				Dim	lo_CfgOpt	= so_HlprGeneric.Value.DeSerializeObjectViaDataContract(Of LogonOptionsXML)(My.Settings.SAPLogon_OptionsXML)
				Me.co_DTO			= Me.CreateDTO()

				If lo_CfgOpt IsNot Nothing

					Me.co_DTO.DefaultLanguage			=	lo_CfgOpt.DefaultLanguage
					Me.co_DTO.ShowPassword				= lo_CfgOpt.ShowPassword
					Me.co_DTO.AutoSave						= lo_CfgOpt.AutoSave
					Me.co_DTO.SavePassword				= lo_CfgOpt.SavePassword
					Me.co_DTO.AutoConnect					= lo_CfgOpt.AutoConnect
					Me.co_DTO.ConfigViewerActive	= lo_CfgOpt.ConfigViewerActive

				End If

				Return	Me.co_DTO

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function	Save(ByVal _dto	As iLogonOptionsDTO)	As Boolean _
												Implements iLogonOptionsModel.Save

				If	Me.co_DTO.DefaultLanguage			<> _dto.DefaultLanguage			OrElse
						Me.co_DTO.AutoSave						<> _dto.AutoSave						OrElse
						Me.co_DTO.ShowPassword				<> _dto.ShowPassword				OrElse
						Me.co_DTO.SavePassword				<> _dto.SavePassword				OrElse
						Me.co_DTO.AutoConnect					<> _dto.AutoConnect					OrElse
						Me.co_DTO.ConfigViewerActive	<> _dto.ConfigViewerActive

					Dim	lo_CfgOpt	= New LogonOptionsXML()

					lo_CfgOpt.DefaultLanguage			= _dto.DefaultLanguage
					lo_CfgOpt.ShowPassword				= _dto.ShowPassword
					lo_CfgOpt.AutoSave						= _dto.AutoSave
					lo_CfgOpt.SavePassword				= _dto.SavePassword
					lo_CfgOpt.AutoConnect					= _dto.AutoConnect
					lo_CfgOpt.ConfigViewerActive	= _dto.ConfigViewerActive

					My.Settings.SAPLogon_OptionsXML	= so_HlprGeneric.Value.SerializeObjectViaDataContract(lo_CfgOpt)
					My.Settings.Save()

					Return	True

				Else
					Return	False
				End If

			End Function

		#End Region

	End Class

End Namespace