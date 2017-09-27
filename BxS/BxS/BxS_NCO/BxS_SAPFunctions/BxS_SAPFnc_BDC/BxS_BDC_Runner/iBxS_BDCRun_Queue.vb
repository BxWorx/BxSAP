Imports System.Collections.Concurrent
Imports System.Threading
Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.BDCRunner

	Friend Interface iBxS_BDCRun_Queue

		#Region "Properties"
			ReadOnly Property Queue()						As BlockingCollection(Of iBxS_BDCTran_Task)
			ReadOnly Property CancelToken()			As CancellationToken
			ReadOnly Property CompletedResults	As List(Of iBxS_BDCTran_Task)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function	Post(ByVal i_TaskList	As List(Of iBxS_BDCTran_Task))	As Boolean
			Function	Post(ByVal i_Task			As iBxS_BDCTran_Task)						As Boolean
			Function	StartConsumers(ByVal noofConsumers As Integer)				As Task(Of Integer)

			Sub Complete()
			Sub Cancel()

		#End Region

	End Interface

End Namespace