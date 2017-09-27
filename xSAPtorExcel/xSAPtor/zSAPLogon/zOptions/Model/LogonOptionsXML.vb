Imports System.Runtime.Serialization
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	<DataContract([Namespace]:="")> _
	Friend	Class LogonOptionsXML

		#Region "Properties"

			<DataMember>	Friend Property DefaultLanguage     As String
			<DataMember>	Friend Property ShowPassword        As Boolean
			<DataMember>	Friend Property SavePassword        As Boolean
			<DataMember>	Friend Property AutoSave            As Boolean
			<DataMember>	Friend Property ConfigViewerActive  As Boolean
			<DataMember>	Friend Property AutoConnect         As Boolean

		#End Region

	End Class

End Namespace