Imports System.Threading.Tasks
Imports xSAPtorExcel.Main.BDCProcessing
Imports xSAPtorExcel.Main.Process.Common
Imports xSAPtorExcel.Main.Process.Options
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Runner

	Friend Interface ixProcessRunnerPLC

		#Region "Properties"

			ReadOnly Property WorksheetCount()	As Integer
			ReadOnly Property TryTakeProfile()	As iBDCWSProfile

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Overloads	Sub Post(ByVal i_Requests	As List(Of ixProcessTask))
			Overloads	Sub Post(ByVal i_Request	As ixProcessTask)
			Function StartupConsumersAsync(ByVal ProcessOptions	As ixProcessOptionsDTO)	As Task(Of Integer)
			Sub Complete()
			Sub CancelProcessing()

		#End Region

	End Interface

End Namespace