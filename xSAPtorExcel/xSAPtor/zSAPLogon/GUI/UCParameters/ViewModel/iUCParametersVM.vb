Imports System.Windows.Forms
Imports System.Collections.Specialized
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Interface iUCParametersVM

		#Region "Properties"

			ReadOnly	Property	LogonOptions	As	iLogonOptionsDTO
			ReadOnly	Property	IsVisibleSSO	As	Boolean
			ReadOnly	Property	InEditmode		As	Boolean
			ReadOnly	Property  IsVisible			As	Boolean
			'.......................................................
			ReadOnly	Property	BS_Langs			As	BindingSource
			ReadOnly	Property	BS_Clnts			As	BindingSource
			ReadOnly	Property	BS_Users			As	BindingSource
			ReadOnly	Property	BS_Pwrds			As	BindingSource
			'.......................................................
			ReadOnly	Property	Context_Btn		As	BitVector32

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			Function	CreateLogonSysDTO()							As	iLogonSystemDTO
			'....................................................
			Function	GetUserControl()								As	UCParametersView
			'....................................................
			Function	LoadSystem(ByVal ID As String)	As	Boolean
			Sub	SetConnection(ByVal	ConnectionDTO			As	iLogonConnectionDTO)
			Function	GetCurrentLogonParameters()			As	iLogonSystemDTO
			'....................................................
			Sub	Shutdown()

		#End Region

	End Interface

End Namespace
