'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.BDC

	Public Interface iBxSBDCSession_Profile

		#Region "Properties"

			Property SessionName  As String
			Property SAPTCode     As String
			Property CTUParams    As	iBxS_BDC_CTUParameters
			Property BDCDataList  As List(Of iBxS_BDC_Entry)

		#End Region

	End Interface

End Namespace