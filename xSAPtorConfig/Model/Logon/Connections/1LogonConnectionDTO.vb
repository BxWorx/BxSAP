Imports System.Runtime.Serialization
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace	Model.Logon.Connections

	<DataContract([Namespace]:="")> _
	Public	Class	LogonConnectionDTO
									Implements iLogonConnectionDTO

		#Region "Properties"

			<DataMember> Friend	Property	IsNew							As Boolean	Implements iLogonConnectionDTO.IsNew
			<DataMember> Friend	Property	CanEdit						As Boolean	Implements iLogonConnectionDTO.CanEdit
			'......................................................
			<DataMember> Friend	Property	ID								As String		Implements iLogonConnectionDTO.ID
			<DataMember> Public	Property	Name							As String		Implements iLogonConnectionDTO.Name
			<DataMember> Friend	Property	AppServer					As String		Implements iLogonConnectionDTO.AppServer
			<DataMember> Friend	Property	InstanceNo				As Integer	Implements iLogonConnectionDTO.InstanceNo
			<DataMember> Friend	Property	SystemID					As String		Implements iLogonConnectionDTO.SystemID
			<DataMember> Friend	Property	RouterPath				As String		Implements iLogonConnectionDTO.RouterPath
			<DataMember> Friend	Property	SNC_Active				As Boolean	Implements iLogonConnectionDTO.SNC_Active
			<DataMember> Friend	Property	SNC_PartnerName		As String		Implements iLogonConnectionDTO.SNC_PartnerName
			<DataMember> Friend	Property	SNC_UsrPwd				As Boolean	Implements iLogonConnectionDTO.SNC_UsrPwd
			<DataMember> Friend	Property	SNC_QOP						As Integer	Implements iLogonConnectionDTO.SNC_QOP
			<DataMember> Friend	Property	LowSpeed					As Boolean	Implements iLogonConnectionDTO.LowSpeed

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Construction"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub New()

				Me.IsNew						=	True
				Me.CanEdit					= True
				'......................................................
				Me.ID								= ""
				Me.Name							= ""
				Me.AppServer				= ""
				Me.SystemID					= ""
				Me.RouterPath				= ""
				Me.SNC_PartnerName	= ""

				Me.InstanceNo				= 0
				Me.SNC_Active				= False
				Me.SNC_UsrPwd				= False
				Me.SNC_QOP					= 0
				Me.LowSpeed					= False

			End Sub

		#End Region

	End Class

End Namespace