Imports System.Runtime.Serialization
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Model.Logon.Systems

	<DataContract([Namespace]:="")> _
	Friend Class SysLogonDTO
								Implements	iSysLogonDTO

		#Region "Properties"

			<DataMember>	Property DestinationID		As String		Implements iSysLogonDTO.DestinationID
			<DataMember>	Property Language					As String		Implements iSysLogonDTO.Language
			<DataMember>	Property Client						As String		Implements iSysLogonDTO.Client
			<DataMember>	Property UserName					As String		Implements iSysLogonDTO.UserName
			<DataMember>	Property Password					As String		Implements iSysLogonDTO.Password
			<DataMember>	Property SystemID					As String		Implements iSysLogonDTO.SystemID
			<DataMember>	Property SystemName				As String		Implements iSysLogonDTO.SystemName

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New()

				Me.DestinationID	= ""
				Me.Language				= ""
				Me.Client					= ""
				Me.UserName				= ""
				Me.Password				= ""
				Me.SystemID				= ""
				Me.SystemName			= ""

			End Sub

		#End Region

	End Class

End Namespace