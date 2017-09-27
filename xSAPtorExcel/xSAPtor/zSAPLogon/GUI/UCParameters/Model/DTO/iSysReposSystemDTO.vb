'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Interface	iSysReposSystemDTO

		#Region "Properties"

			Property	ID				As	String
			Property	Previous	As	iLogonSystemDTO
			Property	Clients		As	Dictionary(Of String, iSysReposClientDTO)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			Function	AddClient(ByVal	Client	As	iSysReposClientDTO)		As	Boolean
			Sub	Reset()

		#End Region

	End Interface

End Namespace