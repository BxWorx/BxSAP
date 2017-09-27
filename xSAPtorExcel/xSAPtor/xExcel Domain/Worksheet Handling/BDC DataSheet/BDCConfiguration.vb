Imports	BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace WorksheetDomain

	Friend Class BDCConfiguration
								Implements iBDCConfiguration

		#Region "Properties"

			Friend Property GUID                  As String									Implements iBDCConfiguration.GUID
			Friend Property SessionID							As String									Implements iBDCConfiguration.SessionID
			Friend Property IsActive              As String									Implements iBDCConfiguration.IsActive
			Friend Property SAPTCode              As String									Implements iBDCConfiguration.SAPTCode
			Friend Property PauseTime             As Integer								Implements iBDCConfiguration.PauseTime
			Friend Property Active_Column_Address As String									Implements iBDCConfiguration.Active_Column_Address
			Friend Property MessageColumnAddress	As String									Implements iBDCConfiguration.MessageColumnAddress
			Friend Property CTU_Parameters        As iBxS_BDC_CTUParameters	Implements iBDCConfiguration.CTU_Parameters

			Friend Property IsProtected						As String									Implements iBDCConfiguration.IsProtected
			Friend Property Password							As String									Implements iBDCConfiguration.Password

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			Public Sub New()

				Me.IsActive               = ""
				Me.IsProtected            = ""
				Me.Password								= "xSAPtor"
				Me.SAPTCode               = ""
				Me.PauseTime              = 0
				Me.Active_Column_Address  = "$B$1"
				Me.MessageColumnAddress		= "$A$1"
				Me.SessionID							= "xSAPtor"

				Me.GUID										= System.Guid.NewGuid.ToString()
				Me.CTU_Parameters         = New BxS_BDC_CTUParameters()

			End Sub

		#End Region

	End Class

End Namespace