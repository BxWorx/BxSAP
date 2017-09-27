Imports System.Runtime.Serialization
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Notification.Options

	<DataContract([Namespace]:="")> _
	Friend	Class NotifyOptionsXML

		#Region "Properties"

			<DataMember>	Friend	Property	ShowInformation()		As Boolean
			<DataMember>	Friend	Property	ShowWarning()				As Boolean
			<DataMember>	Friend	Property	ShowError()					As Boolean
			<DataMember>	Friend	Property	ShowSystem()				As Boolean
			<DataMember>	Friend	Property	ShowTrace()					As Boolean

			<DataMember>	Friend	Property	LogInformation()		As Boolean
			<DataMember>	Friend	Property	LogWarning()				As Boolean
			<DataMember>	Friend	Property	LogError()					As Boolean
			<DataMember>	Friend	Property	LogSystem()					As Boolean
			<DataMember>	Friend	Property	LogTrace()					As Boolean
			<DataMember>	Friend	Property	LogSize()						As Integer

			<DataMember>	Friend	Property	MsgStarted()				As Boolean

		#End Region

	End Class

End Namespace