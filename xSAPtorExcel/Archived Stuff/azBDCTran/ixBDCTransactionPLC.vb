Imports System.Collections.Concurrent
Imports System.Threading.Tasks
Imports xSAPtorNCO.API.SAP.System.Services
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.BDCTransactionx

	Friend Interface ixBDCTransactionPLC

		#Region "Properties"

			ReadOnly Property MessageCount()		As Integer
			ReadOnly Property TryTakeMessages() As ConcurrentDictionary(Of Integer, List(Of ixBDCMessage))

		#End Region

		#Region "Methods"
			Overloads	Sub Post(ByVal i_TransactionList	As List(Of ixBDCTransaction))
			Overloads	Sub Post(ByVal i_Transaction			As ixBDCTransaction)
			Sub Complete()
			Function StartupConsumersAsync(ByVal i_NoOfConsumers	As Integer)	As Task(Of Integer)

		#End Region

	End Interface

End Namespace