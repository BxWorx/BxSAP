Imports	BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace WorksheetDomain

	' Class has no interface, used purely as a DTO for Serialize/Deserialize to XML format with an
	' ( (Extension /or/ convertor class<-(Currently Used) )
	'
	Public Class BDCXMLConfig

		#Region "Properties"

			Public Property GUID						As String
			Public Property SessionID				As String
			Public Property IsActive        As String
			Public Property SAPTCode        As String
			Public Property PauseTime       As Integer
			Public Property Active_Column   As String
			Public Property Msg_Column			As String
			Public Property CTU_DisMode			As String
			Public Property CTU_UpdMode			As String
			Public Property CTU_DefSize			As String

			Public Property IsProtected			As String
			Public Property Password    		As String

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			Public Sub New()
			End Sub

		#End Region

	End Class

End Namespace