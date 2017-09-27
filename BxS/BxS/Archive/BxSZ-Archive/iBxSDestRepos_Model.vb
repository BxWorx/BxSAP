'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Destination.Repository

	Friend	Interface	iBxSDestRepos_Model

		#Region "Properties"

			ReadOnly	Property	ConnectionCount		As Integer
			ReadOnly	Property	ConnectionList		As List(Of BxSDestRepos_ConnectionDTO)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function	ModifyConnection(ByVal	DTO	As BxSDestRepos_ConnectionDTO)		As Boolean
			Function	RemoveConnection(ByVal	id	As String)												As Boolean

			Function	Save()																												As Boolean
			Sub	Reset()

		#End Region

	End Interface

End Namespace