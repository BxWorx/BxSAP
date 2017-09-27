Imports System.Threading
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session
	Friend Interface iSessionProfileHandler


		Event ev_TaskCompleted



		#Region "Methods"

      Function FetchSessionProfiles(ByVal i_Requests	As List(Of iSessionCreateRequest),
																		ByVal i_CT				As CancellationToken)	As Boolean								' As List(Of iSessionCreateRequest)
		
		#End Region

	End Interface

End Namespace