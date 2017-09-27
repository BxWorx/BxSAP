Imports System.ComponentModel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.Destination

	Public Class BxSDestParamsDTO
		Implements iBxSDestParamsDTO

																		Public Property Name			As String Implements iBxSDestParamsDTO.Name

		<DisplayName("AppServerHost")>	Public Property Host			As String Implements iBxSDestParamsDTO.Host
		<DisplayName("SystemID")>				Public Property SystemID	As String Implements iBxSDestParamsDTO.SystemID
		<DisplayName("SystemNumber")>		Public Property SystemNo	As String Implements iBxSDestParamsDTO.SystemNo
		<DisplayName("CLIENT")>					Public Property Client		As String Implements iBxSDestParamsDTO.Client
		<DisplayName("User")>						Public Property User			As String Implements iBxSDestParamsDTO.User
		<DisplayName("Password")>				Public Property Password	As String Implements iBxSDestParamsDTO.Password

		Public Function Clone() As iBxSDestParamsDTO Implements iBxSDestParamsDTO.Clone
			Return CType( Me.MemberwiseClone(), iBxSDestParamsDTO )
		End Function

	End Class

End Namespace