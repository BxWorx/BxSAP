Imports System.ComponentModel
Imports BxS.API.SAPFunctions.Xtra
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session

  Public Interface iSessionHeader

    #Region "Properties"

      <xNCOAttributeRFCParameter(TechID:= "UserID")>				<DisplayName("User Name")>
        Property UserID           As String

      <xNCOAttributeRFCParameter(TechID:= "SessionName")>		<DisplayName("Session Name")>
        Property SessionName      As String

      <xNCOAttributeRFCParameter(TechID:= "CreationDate")>	<DisplayName("Creation Date")>
        Property CreationDate     As Date

      <xNCOAttributeRFCParameter(TechID:= "CreationTime")>	<DisplayName("Creation Time")>
        Property CreationTime     As TimeSpan

      <xNCOAttributeRFCParameter(TechID:= "Count")>					<DisplayName("Transaction Count")>
        Property Count            As Integer

      <xNCOAttributeRFCParameter(TechID:= "QID")>						<DisplayName("Identifier")>
        Property QID              As String

    #End Region

  End Interface

End Namespace
