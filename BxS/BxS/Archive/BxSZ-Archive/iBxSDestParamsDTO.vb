Imports System.ComponentModel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.Destination

	Public Interface iBxSDestParamsDTO

		Property Name()			As String
		Property Host()			As String
		Property SystemID()	As String
		Property SystemNo()	As String
		Property Client()		As String
		Property User()			As String
		Property Password()	As String

		Function Clone()	As iBxSDestParamsDTO

	End Interface

End Namespace
