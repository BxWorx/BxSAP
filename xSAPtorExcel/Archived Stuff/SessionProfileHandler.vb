Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
Imports xSAPtorNCO.API.Main
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session
	Friend Class SessionProfileHandler
								Implements iSessionProfileHandler


		Friend Event ev_TaskCompleted Implements iSessionProfileHandler.ev_TaskCompleted

		#Region "Definitions"

			Private co_NCOCntlr			As ixNCOController
			Private co_Options			As iSessionOptionsDTO

			Private ct_Profiles			As Lazy(Of ConcurrentQueue(Of iSessionProfile))	= New Lazy(Of ConcurrentQueue(Of iSessionProfile))(Function() New ConcurrentQueue(Of iSessionProfile))
			Private ct_Processed		As Lazy(Of List(Of iSessionCreateRequest))			= New Lazy(Of List(Of iSessionCreateRequest))(Function() New List(Of iSessionCreateRequest))
			Private co_AsyncWorker	As Func(Of iSessionCreateRequest, Task )				= New Func(Of iSessionCreateRequest, Task)(AddressOf CollectSessionProfile)
			Private co_AsyncCaller	As AsyncCall(Of iSessionCreateRequest)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Function FetchSessionProfiles(ByVal i_Requests	As List(Of iSessionCreateRequest),
																		ByVal i_CT				As CancellationToken) _
								As	Boolean _
									Implements iSessionProfileHandler.FetchSessionProfiles
			
				For Each lo_Request	As iSessionCreateRequest In i_Requests
					Me.co_AsyncCaller.Post(lo_Request)
				Next

				Return True

				'Return Me.ct_Processed.Value
		' List(Of iSessionCreateRequest) _
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private  Function CollectSessionProfile(ByVal i_Request As iSessionCreateRequest) As Task

				Dim lo_Task As Task	= Task.Run(
							Sub()

								Dim lo_Profile	As iSessionProfile	= Me.co_NCOCntlr.GetSessionProfile(Of	iSessionProfile   , SessionProfile,
																																													iSessionData      , SessionData,
																																													iSessionCTUParams , SessionCTUParams)(i_SessionName:= i_Request.SessionName,
																																																																i_QID        := i_Request.QID)

								Me.ct_Profiles.Value.Enqueue(lo_Profile)
								Me.ct_Processed.Value.Add(i_Request)
								
								RaiseEvent ev_TaskCompleted

							End Sub)

				Return lo_Task

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors/Constructor Events; Destructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Shared Function Create(ByVal i_NCOCntlr	As ixNCOController,
																		ByVal i_Options		As iSessionOptionsDTO) _
															As iSessionProfileHandler

				Return New SessionProfileHandler(i_NCOCntlr:= i_NCOCntlr,
																				i_Options	 := i_Options)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_NCOCntlr	As ixNCOController,
											ByVal i_Options		As iSessionOptionsDTO)

				Me.co_NCOCntlr		= i_NCOCntlr
				Me.co_Options			= i_Options

				Me.co_AsyncCaller	= AsyncCall.Create(Of iSessionCreateRequest)(	functionHandler				:= Me.co_AsyncWorker,
																																				maxDegreeOfParallelism:= Me.co_Options.ParallelProcesses)

			End Sub

		#End Region

	End Class

End Namespace