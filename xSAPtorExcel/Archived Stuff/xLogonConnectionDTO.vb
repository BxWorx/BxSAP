Imports System.Runtime.Serialization
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace	API.Destination.Repository

	<DataContract>
	Public	Class	BxSDestRepos_ConnectionDTO

		<DataMember>	Friend	Property	ID							As String
		<DataMember>	Friend	Property	Name						As String
		<DataMember>	Friend	Property	AppServer				As String
		<DataMember>	Friend	Property	InstanceNo			As Integer
		<DataMember>	Friend	Property	SystemID				As String
		<DataMember>	Friend	Property	RouterPath			As String
		<DataMember>	Friend	Property	SNC_Active			As Boolean
		<DataMember>	Friend	Property	SNC_PartnerName	As String

	End Class

End Namespace