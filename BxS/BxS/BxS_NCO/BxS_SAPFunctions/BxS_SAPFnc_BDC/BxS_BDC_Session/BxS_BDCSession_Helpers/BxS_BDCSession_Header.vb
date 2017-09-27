Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.BDCSession

	Friend Class BxSBDCSession_Header
								Implements iBxSBDCSession_Header

		#Region "Properties"

			Property UserID           As String		Implements iBxSBDCSession_Header.UserID
			Property SessionName      As String		Implements iBxSBDCSession_Header.SessionName
			Property CreationDate     As Date			Implements iBxSBDCSession_Header.CreationDate
			Property CreationTime     As TimeSpan	Implements iBxSBDCSession_Header.CreationTime
			Property Count            As Integer	Implements iBxSBDCSession_Header.Count
			Property QID              As String		Implements iBxSBDCSession_Header.QID

		#End Region

	End Class

End Namespace
