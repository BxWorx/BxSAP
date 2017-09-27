Imports System.Runtime.Serialization
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace	Main.SAPLogon

	<DataContract([Namespace]:="")> _
	Friend	Class	LogonConnReposXML

		#Region "Properties"

			<DataMember>	Friend	Property	ConnList	As Dictionary(Of String, LogonConnEntryXML)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Construction"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub New()

				Me.ConnList	= New	Dictionary(Of String, LogonConnEntryXML)

			End Sub

		#End Region

	End Class
	'°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°
	<DataContract([Namespace]:="")> _
	Friend	Class	LogonConnEntryXML

		#Region "Properties"

			<DataMember>	Friend	Property	ID							As String
			<DataMember>	Friend	Property	Name						As String
			<DataMember>	Friend	Property	AppServer				As String
			<DataMember>	Friend	Property	InstanceNo			As Integer
			<DataMember>	Friend	Property	SystemID				As String
			<DataMember>	Friend	Property	RouterPath			As String
			<DataMember>	Friend	Property	SNC_Active			As Boolean
			<DataMember>	Friend	Property	SNC_PartnerName	As String
			<DataMember>	Friend	Property	SNC_UsrPwd			As Boolean
			<DataMember>	Friend	Property	SNC_QOP   			As Integer
			<DataMember>	Friend	Property	LowSpeed  			As Boolean

		#End Region

	End Class

End Namespace