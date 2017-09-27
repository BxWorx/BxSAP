Imports SAPNCO = SAP.Middleware.Connector

Namespace API.Destination

	Public Class BxSRfcConfigHandler
		Implements iBxSRfcConfigHandler


		Public Function Create(cfgDTO As iBxSDestParamsDTO) As SAPNCO.RfcConfigParameters _
						Implements iBxSRfcConfigHandler.Create

			Return Me.Create( cfgName:=		cfgDTO.Name, _
												cfgHost:=		cfgDTO.Host, _
												cfgSysID:=	cfgDTO.SystemID, _
												cfgSysNo:=	cfgDTO.SystemNo, _
												cfgClient:= cfgDTO.Client, _
												cfgUser:=		cfgDTO.User, _
												cfgPWrd:=		cfgDTO.Password )

		End Function

		Public Function Create(	cfgName		As String, _
														cfgHost		As String, _
														cfgSysNo	As String, _
														cfgSysID	As String, _
														cfgClient	As String, _
														cfgUser		As String, _
														cfgPWrd		As String) As SAPNCO.RfcConfigParameters _
						Implements iBxSRfcConfigHandler.Create

			Dim lo_Cfg	As SAPNCO.RfcConfigParameters	= New SAPNCO.RfcConfigParameters

			lo_Cfg.Add( SAPNCO.RfcConfigParameters.Name						,cfgName		)
			lo_Cfg.Add(	SAPNCO.RfcConfigParameters.AppServerHost	,cfgHost		)
			lo_Cfg.Add( SAPNCO.RfcConfigParameters.SystemID				,cfgSysID		)
			lo_Cfg.Add( SAPNCO.RfcConfigParameters.SystemNumber		,cfgSysNo		)
			lo_Cfg.Add(	SAPNCO.RfcConfigParameters.Client					,cfgClient	)
			lo_Cfg.Add(	SAPNCO.RfcConfigParameters.User						,cfgUser		)
			lo_Cfg.Add(	SAPNCO.RfcConfigParameters.Password				,cfgPWrd		)

			Return lo_Cfg

		End Function

	End Class

End Namespace