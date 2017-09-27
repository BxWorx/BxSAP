Imports System.Threading.Tasks
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.ViaGUI

	Friend Interface ixProcessViaGUI

		#Region "Properties"

			ReadOnly Property StatusOk								As UInteger
			ReadOnly Property StatusInExcel						As UInteger
			ReadOnly Property StatusInExcelMsgUpdate	As UInteger
			ReadOnly Property StatusNoTransactions		As UInteger
			ReadOnly Property StatusWSProfile					As UInteger

			ReadOnly Property OnWorkBook	As String
			ReadOnly Property OnWorkSheet	As String

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function StartAsync()			As Task(Of UInteger)
			Function UpdateMessages()	As Boolean


			Function ProcessAsync()	As Task(Of Integer)

		#End Region

	End Interface

End Namespace