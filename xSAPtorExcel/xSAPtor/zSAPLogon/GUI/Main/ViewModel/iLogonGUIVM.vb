Imports System.Threading.Tasks
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Interface iLogonGUIVM

		#Region	"Properties"

			ReadOnly Property	ActiveSAPSystemID		As String

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			Function	CreateLogonSysDTO()																								As	iLogonSystemDTO
			Function	SetSAPLogonSystemAsync(ByVal LogonSystemDTO	As iLogonSystemDTO)		As	Task(Of Boolean)
			Function	CheckSAPConnectivityAsync()																				As	Task(Of Boolean)
			'....................................................
			Sub	Show()

		#End Region

	End Interface

End Namespace
