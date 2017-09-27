Imports System.Threading
Imports System.Threading.Tasks
Imports xSAPtorExcel.Main.BDCProcessing
Imports xSAPtorExcel.Main.Process.Options
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Runner

	Friend Interface ixProcessRunnerConsumer

		#Region "Properties"

			ReadOnly Property WSProcessed()	As List(Of iBDCWSProfile)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function StartupAsync(ByVal CancelToken			As CancellationToken,
														ByVal ProcessOptions	As ixProcessOptionsDTO)	As Task(Of Integer)

		#End Region

	End Interface

End Namespace