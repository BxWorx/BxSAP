Imports	BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace WorksheetDomain

	Friend Interface iBDCConfiguration

		#Region "Properties"

			Property GUID										As String
			Property SessionID							As String
			Property IsActive               As String
			Property SAPTCode               As String
			Property PauseTime              As Integer
			Property Active_Column_Address  As String
			Property MessageColumnAddress		As String
			Property CTU_Parameters         As iBxS_BDC_CTUParameters

			Property IsProtected						As String
			Property Password								As String

		#End Region

	End Interface

End Namespace