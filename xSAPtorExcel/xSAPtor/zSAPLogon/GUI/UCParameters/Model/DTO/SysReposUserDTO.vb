'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Class SysReposUserDTO
									Implements	iSysReposUserDTO

		#Region "Properties"

			Friend	Property	User			As String	Implements	iSysReposUserDTO.User
			Friend	Property	Password  As String	Implements	iSysReposUserDTO.Password

		#End Region

	End Class

End Namespace