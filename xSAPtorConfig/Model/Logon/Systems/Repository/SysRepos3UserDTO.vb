Imports System.Runtime.Serialization
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Model.Logon.Systems

	<DataContract([Namespace]:="")> _
	Friend	Class SysReposUserDTO
									Implements	iSysReposUserDTO

		#Region "Properties"

			<DataMember>	Friend Property		User				As String		Implements	iSysReposUserDTO.User
			<DataMember>	Friend Property		Password		As String		Implements	iSysReposUserDTO.Password

		#End Region

	End Class

End Namespace