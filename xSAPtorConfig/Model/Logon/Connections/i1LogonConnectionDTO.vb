'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace	Model.Logon.Connections

	Public Interface iLogonConnectionDTO

		#Region "Properties"

			Property  IsNew							As Boolean
			Property	CanEdit						As Boolean
			'......................................................
			Property	ID								As String
			Property	Name							As String
			Property	AppServer					As String
			Property	InstanceNo				As Integer
			Property	SystemID					As String
			Property	RouterPath				As String
			Property	SNC_Active				As Boolean
			Property	SNC_PartnerName		As String
			Property	SNC_UsrPwd				As Boolean
			Property	SNC_QOP						As Integer
			Property	LowSpeed  				As Boolean

		#End Region

	End Interface

End Namespace