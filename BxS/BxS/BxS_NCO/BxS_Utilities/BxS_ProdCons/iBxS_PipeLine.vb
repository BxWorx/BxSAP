Imports System.Collections.Concurrent
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Utilities

	Friend Interface iBxS_PipeLine(Of	T)

		#Region "Properties"

								Property	NoOfConsumers		As Integer
			ReadOnly	Property Completed				As ConcurrentQueue(Of T)
			ReadOnly	Property InError   				As ConcurrentQueue(Of T)
			ReadOnly	Property NotStarted				As ConcurrentQueue(Of T)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function	Post(ByVal Tasks	As List(Of T))		As Integer
			Function	Post(ByVal Task		As T)							As Boolean
			Function	StartConsumers()										As Task(Of Integer)
			'....................................................
			Sub ProducingCompleted()

		#End Region

	End Interface

End Namespace