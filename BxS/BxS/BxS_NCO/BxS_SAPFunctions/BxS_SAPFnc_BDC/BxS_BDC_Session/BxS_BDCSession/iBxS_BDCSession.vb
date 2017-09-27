Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.BDCSession

	Friend Interface iBxS_BDCSession


		#Region "Methods"

			Function BDCSessionList(Optional ByVal i_UserId         As String  = "*"c,
															Optional ByVal i_SessionName    As String  = "*"c,
															Optional ByVal i_DateFrom       As Date    = #1999-01-01#,
															Optional ByVal i_DateTo         As Date    = #2999-12-31# ) As List(Of iBxSBDCSession_Header)

			Function BDCSession(					ByVal i_SessionName As String,
																		ByVal i_QID         As String,
													Optional	ByVal i_OnlyHeader  As Boolean = False ) As iBxSBDCSession_Profile
			


		#End Region

	End Interface

End Namespace