Imports xSAPtorConfig.Model.Logon.Options
Imports xSAPtorConfig.Model.Logon.ConnectionSetup
Imports xSAPtorConfig.Model.Logon.Connections
Imports xSAPtorConfig.Model.Logon.Systems
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Controllers

	Public Interface iController

		#Region "Section: Controllers"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Function	SetLocation(ByVal	Name	As String)	As	Boolean
			Function	Save()															As	Boolean
			Function	Load()															As	Boolean

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Section: System: Logons"

			Function	GetSystemLogonRepository()																							As	iSysLogonRepositoryDTO
			Function	UpdateSystemLogonRepository(ByVal Systems As iSysLogonRepositoryDTO)		As	Boolean
			Function	CreateSystemLogonEntry()																								As	iSysLogonDTO

			Event     ev_SystemLogonRepositoryChanged()

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Section: System: Repository"

			Function	GetSystemRepository()																		As	iSysReposDTO
			Function	UpdateSystemRepository(ByVal Systems As iSysReposDTO)		As	Boolean
			Function	CreateSysReposSystemEntry()															As	iSysReposSystemDTO
			Function	CreateSysReposClientEntry()															As	iSysReposClientDTO
			Function	CreateSysReposUserEntry()																As	iSysReposUserDTO

			Event     ev_SystemRepositoryChanged()

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Section: System: Languages"

			Function	GetSystemLanguages()																						As	iSystemLanguagesDTO
			Function	UpdateSystemLanguages(ByVal Languages	As iSystemLanguagesDTO)		As	Boolean

			Event     ev_SystemLanguagesChanged()

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Section: Logon: Connections Repository"

			Function	CreateLogonConnectionsRepositoryConnection()										As	iLogonConnectionDTO
			Function	UpdateLogonConnectionsRepository(DTO	As iLogonConnReposDTO)		As	Boolean
			Function	GetLogonConnectionsRepository()																	As	iLogonConnReposDTO

			Event     ev_LogonConnectionsRepositoryChanged()

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Section: Logon: Connection Setup"

			Function	UpdateLogonConnectionSetup(DTO	As iLogonConnSetupDTO)		As	Boolean
			Function	GetLogonConnectionSetup()																	As	iLogonConnSetupDTO

			Event     ev_LogonConnectionSetupChanged()

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Section: Logon: Options"

			Function	GetLogonOptions()																														As	iLogonOptionsDTO
			Function	UpdateLogonOptions(ByVal	DTO	As iLogonOptionsDTO)													As	Boolean

			Event			ev_LogonOptionsChanged()

		#End Region

	End Interface

End Namespace
