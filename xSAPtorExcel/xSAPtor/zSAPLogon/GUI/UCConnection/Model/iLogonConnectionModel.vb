'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Interface	iLogonConnectionModel

		#Region "Properties"
			
			ReadOnly	Property	Connections		As Dictionary(Of String, iLogonConnectionDTO)
	
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			Function	CreateDTO()																As iLogonConnectionDTO
			Function	FetchRepos()															As iLogonConnReposDTO
			Function	FetchConnection(ByVal	ID	As String)			As iLogonConnectionDTO
			Function	Modify(ByVal	DTO	As iLogonConnectionDTO)	As Boolean
			Function	SaveRepository()													As Boolean
			Function	DeleteConnection(ByVal	ID	As String)		As Boolean

		#End Region

	End Interface

End Namespace