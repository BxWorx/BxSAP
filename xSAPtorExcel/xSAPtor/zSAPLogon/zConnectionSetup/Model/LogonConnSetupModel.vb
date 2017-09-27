'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Class	LogonConnSetupModel
									Implements iLogonConnSetupModel

		#Region "Definitions"

			Private	co_DTO				As iLogonConnSetupDTO

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateDTO()	As iLogonConnSetupDTO _
													Implements iLogonConnSetupModel.CreateDTO

				Return	New LogonConnSetupDTO

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Fetch()	As iLogonConnSetupDTO _
													Implements iLogonConnSetupModel.Fetch

				Dim	lo_CfgConn	= so_HlprGeneric.Value.DeSerializeObjectViaDataContract(Of LogonConnSetupXML)(My.Settings.SAPLogon_ConnSetupXML)
				Me.co_DTO				= Me.CreateDTO()

				If lo_CfgConn IsNot Nothing

					Me.co_DTO.ConnectionIdleTimeout	= lo_CfgConn.ConnectionIdleTimeout
					Me.co_DTO.DestinationID					= lo_CfgConn.DestinationID
					Me.co_DTO.IdleCheckTime					= lo_CfgConn.IdleCheckTime
					Me.co_DTO.PeakConnectionLimit		= lo_CfgConn.PeakConnectionLimit
					Me.co_DTO.PoolSize							= lo_CfgConn.PoolSize
					Me.co_DTO.UseManual							= lo_CfgConn.UseManual

					Me.co_DTO.SNC_LibName32					= lo_CfgConn.SNC_Lib32
					Me.co_DTO.SNC_LibName64					= lo_CfgConn.SNC_Lib64
					Me.co_DTO.SNC_LibPath						= lo_CfgConn.SNC_LibPath

					Me.co_DTO.XML_Node							= lo_CfgConn.XML_Node
					Me.co_DTO.XML_Path							= lo_CfgConn.XML_Path
					Me.co_DTO.XML_FileName					= lo_CfgConn.XML_FileName
					Me.co_DTO.XML_OnlyGUI						= lo_CfgConn.XML_OnlyGui

				End If

				Return	Me.co_DTO

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Save(DTO As iLogonConnSetupDTO)	As Boolean _
													Implements iLogonConnSetupModel.Save

				If	Me.co_DTO.PeakConnectionLimit		<>	DTO.PeakConnectionLimit		OrElse
						Me.co_DTO.PoolSize							<>	DTO.PoolSize							OrElse
						Me.co_DTO.IdleCheckTime					<>	DTO.IdleCheckTime					OrElse
						Me.co_DTO.ConnectionIdleTimeout	<>	DTO.ConnectionIdleTimeout	OrElse
						Me.co_DTO.UseManual							<>	DTO.UseManual							OrElse
						Me.co_DTO.SNC_LibName32					<>	DTO.SNC_LibName32					OrElse
						Me.co_DTO.SNC_LibName64					<>	DTO.SNC_LibName64					OrElse
						Me.co_DTO.SNC_LibPath						<>	DTO.SNC_LibPath						OrElse
						Me.co_DTO.XML_Node							<>	DTO.XML_Node							OrElse
						Me.co_DTO.XML_Path							<>	DTO.XML_Path							OrElse
						Me.co_DTO.XML_FileName					<>	DTO.XML_FileName					OrElse
						Me.co_DTO.XML_OnlyGUI						<>	DTO.XML_OnlyGUI

					Dim	lo_CfgConn	= New LogonConnSetupXML()

					lo_CfgConn.ConnectionIdleTimeout	=	DTO.ConnectionIdleTimeout
					lo_CfgConn.DestinationID					= DTO.DestinationID
					lo_CfgConn.IdleCheckTime					= DTO.IdleCheckTime
					lo_CfgConn.PeakConnectionLimit		= DTO.PeakConnectionLimit
					lo_CfgConn.PoolSize								= DTO.PoolSize
					lo_CfgConn.UseManual							= DTO.UseManual

					lo_CfgConn.SNC_Lib32							= DTO.SNC_LibName32
					lo_CfgConn.SNC_Lib64							= DTO.SNC_LibName64
					lo_CfgConn.SNC_LibPath						= DTO.SNC_LibPath

					lo_CfgConn.XML_Node								= DTO.XML_Node
					lo_CfgConn.XML_Path								= DTO.XML_Path
					lo_CfgConn.XML_FileName						= DTO.XML_FileName
					lo_CfgConn.XML_OnlyGui						= DTO.XML_OnlyGUI

					My.Settings.SAPLogon_ConnSetupXML	= so_HlprGeneric.Value.SerializeObjectViaDataContract(lo_CfgConn)
					My.Settings.Save()

					Return	True

				Else
					Return	False
				End If

			End Function

		#End Region

	End Class

End Namespace