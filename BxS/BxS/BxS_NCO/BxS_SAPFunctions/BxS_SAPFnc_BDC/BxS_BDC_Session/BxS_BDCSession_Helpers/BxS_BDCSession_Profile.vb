Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.BDCSession

	Friend Class BxSBDCSession_Profile
								Implements iBxSBDCSession_Profile

		#Region "Properties"

			Property SessionName  As String										Implements iBxSBDCSession_Profile.SessionName
			Property SAPTCode     As String										Implements iBxSBDCSession_Profile.SAPTCode
			Property CTUParams    As iBxS_BDC_CTUParameters		Implements iBxSBDCSession_Profile.CTUParams
			Property BDCDataList  As List(Of iBxS_BDC_Entry)	Implements iBxSBDCSession_Profile.BDCDataList

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New()
				Me.BDCDataList = New List(Of iBxS_BDC_Entry)
			End Sub

		#End Region

	End Class

End Namespace