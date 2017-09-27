Imports System.Runtime.Serialization
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	<DataContract([Namespace]:="")> _
	Friend	Class	LogonConnSetupXML

		#Region "Properties"

			<DataMember>	Friend	Property  DestinationID					As String
			<DataMember>	Friend	Property	PeakConnectionLimit		As Integer
			<DataMember>	Friend	Property	PoolSize							As Integer
			<DataMember>	Friend	Property	IdleCheckTime					As Integer
			<DataMember>	Friend	Property	ConnectionIdleTimeout	As Integer
			<DataMember>	Friend	Property	UseManual							As Boolean

			<DataMember>	Friend	Property	SNC_Lib32							As String
			<DataMember>	Friend	Property	SNC_Lib64							As String
			<DataMember>	Friend	Property	SNC_LibPath						As String

			<DataMember>	Friend	Property	XML_Node  						As String
			<DataMember>	Friend	Property	XML_FileName					As String
			<DataMember>	Friend	Property	XML_Path   						As String
			<DataMember>	Friend	Property	XML_OnlyGui						As Boolean

		#End Region

	End Class

End Namespace