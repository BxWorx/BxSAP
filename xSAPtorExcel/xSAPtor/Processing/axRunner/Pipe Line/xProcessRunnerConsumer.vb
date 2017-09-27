Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
Imports xSAPtorExcel.Main.BDCProcessing
Imports xSAPtorExcel.Main.Process.Common
Imports xSAPtorExcel.Main.Process.Options
Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.Services.UI
Imports xSAPtorNCO.API.SAP.System.Services
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Runner

	Friend Class xProcessRunnerConsumer
								Implements ixProcessRunnerConsumer

		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	ct_WSProcessed	As New List(Of iBDCWSProfile)
			Friend ReadOnly Property WSProcessed() As List(Of iBDCWSProfile) Implements ixProcessRunnerConsumer.WSProcessed
				Get
					Return Me.ct_WSProcessed
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function StartupAsync(ByVal i_CT									As CancellationToken,
																				 ByVal i_Options						As ixProcessOptionsDTO) _
															As Task(Of Integer) _
																Implements ixProcessRunnerConsumer.StartupAsync

				Dim lo_ProgressHandler	As Action(Of iPBarData)			= AddressOf Me.xPBarHandler
				Dim lo_Progress					As IProgress(Of iPBarData)	= New Progress(Of iPBarData)(lo_ProgressHandler)

				Me.ct_WSProcessed	= New List(Of iBDCWSProfile)

				For Each lo_Request As ixProcessTask In co_BC.GetConsumingEnumerable()

					If i_CT.IsCancellationRequested
						Exit For
					End If

					Dim lo_WSProfileDTO		As iExcelWSProfileDTO	= Me.co_ExcelHelper.GetExcelWorkSheetProfile(WorkBookName	:= lo_Request.WorkbookName,
																																																	 WorkSheetName:= lo_Request.WorksheetName)

					Dim lo_BDCWSProfile		As iBDCWSProfile			= New BDCWSProfile(i_ExcelWSProfile:= lo_WSProfileDTO,
																																				 i_ExcelHelper	 := Me.co_ExcelHelper)

					
					If Await lo_BDCWSProfile.LoadDataAsync(i_Progress:= lo_Progress,
																								 i_CT			 := i_CT)

						If Await lo_BDCWSProfile.CompileTransactionsAsync(i_Progress:= lo_Progress,
																															i_CT			:= i_CT)

							Me.co_PLCBDCTran.Post(i_TransactionList:= lo_BDCWSProfile.BDCTransactions)
							Me.co_PLCBDCTran.Complete

							lo_BDCWSProfile.ProcessedCount	= Await Me.co_PLCBDCTran.StartupConsumersAsync(i_ConcurrentProcesses:= i_Options.ParallelProcessesTran)

							Do While Me.co_PLCBDCTran.MessageCount > 0
								lo_BDCWSProfile.LoadMessages(Messages:= Me.co_PLCBDCTran.TryTakeMessages())
							Loop

						End If
					End If

					Me.ct_WSProcessed.Add(lo_BDCWSProfile)

				Next

				Return Me.ct_WSProcessed.Count

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xPBarHandler(ByVal i_PBarData As iPBarData)
			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors: Singleton"

			Private co_PLCBDCTran		As ixBDCTransactionPLC
			Private co_BC						As BlockingCollection(Of ixProcessTask)
			Private co_ExcelHelper	As iExcelHelper
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Shared Function Create(ByVal BCProcessTasks		As BlockingCollection(Of ixProcessTask),
																		ByVal BDCTransactionPLC	As ixBDCTransactionPLC,
																		ByVal ExcelHelper				As iExcelHelper) _
															As xProcessRunnerConsumer

				Return New xProcessRunnerConsumer(i_BC				 := BCProcessTasks,
																					i_BDCTranPLC :=	BDCTransactionPLC,
																					i_ExcelHelper:= ExcelHelper)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_BC					As BlockingCollection(Of ixProcessTask),
											ByVal i_BDCTranPLC	As ixBDCTransactionPLC,
											ByVal i_ExcelHelper	As iExcelHelper)

				Me.co_BC					= i_BC
				Me.co_PLCBDCTran	= i_BDCTranPLC
				Me.co_ExcelHelper	= i_ExcelHelper

			End Sub

		#End Region

	End Class

End Namespace