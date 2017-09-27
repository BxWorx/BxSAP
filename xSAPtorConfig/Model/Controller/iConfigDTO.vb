Imports xSAPtorConfig.Model.Logon.Options
Imports xSAPtorConfig.Model.Logon.ConnectionSetup
Imports xSAPtorConfig.Model.Logon.Connections
Imports xSAPtorConfig.Model.Logon.Systems
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Model.Controller.Config

	Public Interface iConfigDTO

		#Region "Properties"

			Property LogonOptionsDTO()									As iLogonOptionsDTO
			Property LogonConnectionSetupDTO()					As iLogonConnSetupDTO
			Property LogonConnectionsRepositoryDTO()		As iLogonConnReposDTO
			'....................................................
			Property SystemLanguagesDTO()					As iSystemLanguagesDTO
			Property SystemRepositoryDTO()				As iSysReposDTO
			Property SystemLogonRepositoryDTO()		As iSysLogonRepositoryDTO

		#End Region

	End Interface

End Namespace