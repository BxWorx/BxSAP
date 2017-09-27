Imports System.ComponentModel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.Destination

	Public Interface iBxSDestMonitorDTO

		#Region "Properties"

			' TO-DO: Get these attributes to work so that one can do a find on them
			<DisplayName("Conversation ID")>  Property ConversationID As String
			<DisplayName("Current State")>    Property State          As String
			<DisplayName("SAP System ID")>    Property SystemID       As String
			<DisplayName("SAP User")>         Property User           As String
			<DisplayName("Client Number")>    Property Client         As String
			<DisplayName("Function Module")>  Property FncModuleName  As String

																				Property Type       As String
																				Property Host       As String
																				Property SystemNo   As String
																				Property Language   As String
																				Property SessionID  As String

		#End Region

	End Interface

End Namespace