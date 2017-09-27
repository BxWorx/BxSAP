Imports System.Runtime.Serialization
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Model.Logon.Options

	<DataContract([Namespace]:="")> _
	Public Class LogonOptionsDTO
								Implements iLogonOptionsDTO

		#Region "Properties"

			<DataMember>	Friend Property DefaultLanguage				As String			Implements  iLogonOptionsDTO.DefaultLanguage
			<DataMember>	Friend Property ShowPassword					As Boolean		Implements  iLogonOptionsDTO.ShowPassword
			<DataMember>	Friend Property SavePassword					As Boolean		Implements  iLogonOptionsDTO.SavePassword
			<DataMember>	Friend Property AutoSave							As Boolean		Implements  iLogonOptionsDTO.AutoSave
			<DataMember>	Friend Property ConfigViewerActive		As Boolean		Implements  iLogonOptionsDTO.ConfigViewerActive
			<DataMember>	Friend Property AutoConnect						As Boolean		Implements  iLogonOptionsDTO.AutoConnect

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(	Optional	ByVal	_deflang			As String		= "EN"	,
											Optional	ByVal	_showpw				As Boolean	= False	,
											Optional	ByVal	_savepw				As Boolean	= False	,
											Optional	ByVal	_autosave			As Boolean	= True	,
											Optional	ByVal	_autoconnect	As Boolean	= False		)

				Me.DefaultLanguage  = _deflang
				Me.ShowPassword     = _showpw
				Me.SavePassword     = _savepw
				Me.AutoSave         = _autosave
				Me.AutoConnect      = _autoconnect

			End Sub

		#End Region

	End Class

End Namespace