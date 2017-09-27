'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Interface	iLogonSystemsModel

		#Region "Properties"
			
			'ReadOnly	Property	Systems		As Dictionary(Of String, iSystemsDTO)
	
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'Function	FetchRepos()															As iLogonConnReposDTO
			'Function	Modify(ByVal	DTO	As iLogonConnectionDTO)	As Boolean
			'Function	DeleteConnection(ByVal	ID	As String)		As Boolean
			'Function	FetchUsers(ByVal	SystemID	As	String	,
			'										 ByVal	ClientNo	As	String		)		As	iSystemUsersDTO


			Function	CreateSystemDTO()			As	iSysReposSystemDTO
			Function	CreateClientDTO()			As	iSysReposClientDTO
			Function	CreateUserDTO()				As	iSysReposUserDTO
			Function	CreateLogonSysDTO()		As	iLogonSystemDTO
			'.......................................................
			Function	SaveSystem(ByVal	System	As	iSysReposSystemDTO)		As Boolean
			Function	FetchSystem(ByVal	ID	As String)										As	iSysReposSystemDTO
			'.......................................................
			Function	DeleteLanguage(ByVal	Language	As	String)		As	Boolean
			Function	SaveLanguage(ByVal	Language	As	String)			As	Boolean
			Function	FetchLanguages()															As	List(Of	String)
			'.......................................................
			Function	SaveRepository()	As Boolean

		#End Region

	End Interface

End Namespace