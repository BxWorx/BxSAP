Imports System.Collections.Concurrent
'================================================
Friend Interface iExcelRow

	#Region "Properties"
	
		ReadOnly	Property	IndexNo				As Integer
		ReadOnly	Property	RowNo         As Integer
		ReadOnly	Property	IsTerminated	As Boolean
		ReadOnly	Property	Values        As ConcurrentDictionary(Of Integer, String)

	#End Region

End Interface
