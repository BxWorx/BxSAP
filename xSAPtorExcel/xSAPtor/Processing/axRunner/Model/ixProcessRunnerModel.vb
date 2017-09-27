Imports xSAPtorExcel.Main.Process.Common
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Runner

	Friend Interface ixProcessRunnerModel

		#Region "Events"

			Event ev_TaskChanged()		' Broadcast to listeners, should be PROCESS MONITORS
			Event ev_TaskSubmitted()	' Broadcast to listeners, should be PROCESS RUNNERS

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			ReadOnly	Property SubmitFailed()			As Byte
			ReadOnly	Property SubmitOK()					As Byte
			ReadOnly	Property SubmitRunning()		As Byte
			ReadOnly	Property SubmitRestarted()	As Byte
			ReadOnly	Property SubmitCompleted()	As Byte
			ReadOnly	Property SubmitStale()			As Byte

			ReadOnly	Property Count()						As Integer
			ReadOnly	Property QueueCount()				As Integer

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function Snapshot(Optional ByVal OnlyNew	As Boolean = False)					As List(Of KeyValuePair(Of String, ixProcessTask))
			Function Dequeue(ByRef TaskOut As ixProcessTask)											As Boolean
			Function SubmitTask(					ByVal TaskRequest As ixProcessTask,
													Optional	ByVal WithRestart	As Boolean = False)		As Byte
			Sub UpdateTask(					ByVal	TaskUpdate	As ixProcessRunnerUpdateDTO,
										 Optional ByVal LapseLimit	As Integer	= 0)











			Function Reset()	As Boolean





		#End Region

	End Interface

End Namespace