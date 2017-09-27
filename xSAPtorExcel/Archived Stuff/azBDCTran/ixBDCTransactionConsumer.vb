Imports System.Collections.Concurrent
Imports xSAPtorNCO.API.SAP.System.Services
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.BDCTransactionx

	Friend Interface ixBDCTransactionConsumer

		Function Start()	As ConcurrentDictionary(Of Integer, List(Of ixBDCMessage))

	End Interface

End Namespace