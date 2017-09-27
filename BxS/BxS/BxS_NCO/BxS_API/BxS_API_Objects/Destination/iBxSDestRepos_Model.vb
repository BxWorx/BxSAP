'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.Destination.Repository

	Public	Interface	iBxSDestRepository

		#Region "Properties"

			ReadOnly	Property	Count		As Integer
			ReadOnly	Property	List		As List(Of BxSDestRepos_ConnectionDTO)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function	CreateConnectionEntry()																				As BxSDestRepos_ConnectionDTO
			Function	GetConnection(ByVal	id	As String)														As BxSDestRepos_ConnectionDTO
			Function	ModifyConnection(ByVal	DTO	As BxSDestRepos_ConnectionDTO)		As Boolean
			Function	RemoveConnection(ByVal	id	As String)												As Boolean

			Function	Save()																												As Boolean
			Sub	Reset()

		#End Region

	End Interface

End Namespace