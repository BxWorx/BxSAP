'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Destination

	Friend Interface iBxSLogonParamsDTO

		#Region "Properties"

			Property Client()			As String
			Property User()				As String
			Property Password()		As String

			Property UseSAPGUI()	As Boolean

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Construction"

			Sub Load(					ByVal client		As String,
												ByVal user			As String,
												ByVal password	As String,
							 Optional ByVal useSAPGUI	As Boolean = False)

		#End Region

	End Interface

End Namespace
