Imports System.Collections.Concurrent
Imports System.Threading
Imports BxS.API.Main
Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session

	Friend Class SessionRequestConsumer
								Implements iSessionRequestConsumer

		#Region "Definitions"

			Private	co_CntlrMain	As iBxSMainController
			Private co_NCO				As ixNCOController
			Private co_BC					As BlockingCollection(Of iSessionRequestDTO)
			Private co_CT					As CancellationToken

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function Start() _
												As List(Of iBxSBDCSession_Profile) _
													Implements iSessionRequestConsumer.Start

				Dim lt_Processed	As New List(Of iSessionRequestDTO)
				Dim	lt_Profiles		As New List(Of iBxSBDCSession_Profile)

				For Each lo_Request As iSessionRequestDTO In co_BC.GetConsumingEnumerable()

					If Me.co_CT.IsCancellationRequested
						Exit For
					End If

					Dim lo_SessProfile	As iBxSBDCSession_Profile

					lo_SessProfile	= Me.co_NCO.SessionProfile(	i_Destination:=	co_CntlrMain.ActiveDestination,
																											i_SessionName:= lo_Request.SessionName,
																											i_QID        := lo_Request.QID)

					lt_Profiles.Add(lo_SessProfile)
					lt_Processed.Add(lo_Request)

				Next

				Return lt_Profiles

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors: Singleton"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(	ByVal	i_CntlrMain			As iBxSMainController,
												ByVal i_BC					As BlockingCollection(Of iSessionRequestDTO),
												ByVal i_Controller	As ixNCOController,
												ByVal i_CT					As CancellationToken)

				Me.co_CntlrMain	= i_CntlrMain
				Me.co_BC				= i_BC
				Me.co_NCO				= i_Controller
				Me.co_CT				= i_CT

			End Sub

		#End Region

	End Class

End Namespace