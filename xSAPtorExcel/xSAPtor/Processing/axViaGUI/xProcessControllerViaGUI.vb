Imports System.Threading
Imports xSAPtorExcel.Main.Notification.Icon
Imports xSAPtorExcel.Main.Process.Common
Imports xSAPtorExcel.Main.Process.Options
Imports xSAPtorExcel.Main.Process.RunMonitor
Imports xSAPtorExcel.Main.Process.Runner
Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.Services.UI
Imports xSAPtorNCO.API.Main
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Controller

	Friend Class xProcessControllerViaGUI
								Implements ixProcessControllerViaGUI


			Friend Event ev_Completed() Implements ixProcessControllerViaGUI.ev_Completed

			Private co_CTS	As New CancellationTokenSource


		#Region "Definitions"

			Private	WithEvents	co_RunnerModel	As Lazy(Of ixProcessRunnerModel) _
														= New Lazy(Of ixProcessRunnerModel)(
																Function()

																	Dim lo_RunnerModel	As ixProcessRunnerModel	= xProcessRunnerModel.Create()

																	Return lo_RunnerModel

																End Function,
																LazyThreadSafetyMode.ExecutionAndPublication )
			
			Private WithEvents	co_RunnerCntlr	As Lazy(Of ixProcessRunnerController) _
														= New Lazy(Of ixProcessRunnerController)(
																Function()

																	Dim lo_PBar							As IProgress(Of iPBarData)	= Nothing
																	Dim lo_OptionsDTO				As ixProcessOptionsDTO			= xProcessOptionsModel.Create().FetchOptions()

																	Dim lo_ProcessRunnerPLC	As ixProcessRunnerPLC				= xProcessRunnerPLC.Create(NCOController:= Me.co_NCOCntlr,
																																																								 ExcelHelper	:= Me.co_ExcelHelper,
																																																								 CancelToken	:= Me.co_CTS.Token,
																																																								 ProgressBar	:= lo_PBar)

																	Return xProcessRunnerController.Create(ProcessRunnerPLC	 := lo_ProcessRunnerPLC,
																																				 ProcessRunnerModel:= Me.co_RunnerModel.Value,
																																				 ProcessOptions		 := lo_OptionsDTO,
																																				 ExcelHelper			 := Me.co_ExcelHelper,
																																				 NotifyVM					 := Me.co_NotifyVM)

																End Function,
																LazyThreadSafetyMode.ExecutionAndPublication )

			Private	WithEvents	co_ProcessRunMonitorVM	As Lazy(Of ixProcessRunMonitorViewModel) _
														= New Lazy(Of ixProcessRunMonitorViewModel)(
																Function()

																	Return xProcessRunMonitorViewModel.Create(ProcessRunnerModel:= Me.co_RunnerModel.Value)

																End Function,
																LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function Startup()	_
												As Boolean _
													Implements ixProcessControllerViaGUI.Startup

				Dim lb_Ret	As Boolean	= True

				Try

						Me.co_RunnerCntlr.Value.StartUp()
						'Me.co_ProcessRunMonitorVM.Value.ToggleView()

					Catch ex As Exception
						lb_Ret	= False

				End Try

				Return lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		  Friend Function SubmitRequest(ByVal ProcessRequest	As ixProcessRequestDTO) _
												As iNotificationMessageDTO _
													Implements ixProcessControllerViaGUI.SubmitRequest

				Dim lo_NotifyDTO	As iNotificationMessageDTO	= New NotificationMessageDTO
				Dim lc_Text				As String


				Dim lo_ProcessTask	As ixProcessTask	= xProcessTask.Create(WorkbookName := ProcessRequest.WBookName,
																																		WorksheetName:= ProcessRequest.WSheetName)

				lo_ProcessTask.Synced			= True
				lo_ProcessTask.Profile		= Me.co_ExcelHelper.GetExcelWorkSheetProfile(WorkBookName := lo_ProcessTask.WorkbookName,
																																							 WorkSheetName:= lo_ProcessTask.WorksheetName)
				lo_ProcessTask.SAPTCode		= lo_ProcessTask.Profile.BDCConfig.SAPTCode
				lo_ProcessTask.GUID				= lo_ProcessTask.Profile.BDCConfig.GUID
				lo_ProcessTask.TranCount	= 100				' TO-DO: Correct

				Dim ln_Res	As Byte	= Me.co_RunnerModel.Value.SubmitTask(TaskRequest:= lo_ProcessTask,
																																 WithRestart:= True)

				Select Case ln_Res
					Case	Me.co_RunnerModel.Value.SubmitOK
						lc_Text	= "Successful"

					Case	Me.co_RunnerModel.Value.SubmitRestarted
						lc_Text	= "Restarted"

					Case	Me.co_RunnerModel.Value.SubmitStale
						lc_Text	= "Stale"

					Case	Me.co_RunnerModel.Value.SubmitCompleted
						lc_Text	= "Completed"

					Case	Me.co_RunnerModel.Value.SubmitRunning
						lc_Text						= "Still Running"
						lo_NotifyDTO.Type = lo_NotifyDTO.TypeWarn

					Case	Me.co_RunnerModel.Value.SubmitFailed
						lc_Text						= "FAILED"
						lo_NotifyDTO.Type = lo_NotifyDTO.TypeError

					Case Else
						lc_Text						= String.Format("FAILED [{0}]", ln_Res.ToString)
						lo_NotifyDTO.Type = lo_NotifyDTO.TypeError

				End Select

				lo_NotifyDTO.Text	= String.Format("Submit: {0}/{1}: {2}", ProcessRequest.WBookName, ProcessRequest.WSheetName,  lc_Text)

				Return lo_NotifyDTO

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			Private WithEvents	co_NCOCntlr			As ixNCOController
			Private WithEvents	co_NotifyVM			As ixNotificationIconViewModel
			Private							co_ExcelHelper	As iExcelHelper
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Shared Function Create(ByVal NCOController	As ixNCOController,
																		ByVal ExcelHelper		As iExcelHelper,
																		ByVal NotifyVM			As ixNotificationIconViewModel) _
															As ixProcessControllerViaGUI

				Return New xProcessControllerViaGUI(i_NCOCntlr	 := NCOController,
																						i_ExcelHelper:= ExcelHelper,
																						i_NotifyVM	 := NotifyVM)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_NCOCntlr		As ixNCOController,
											ByVal i_ExcelHelper	As iExcelHelper,
											ByVal	i_NotifyVM		As ixNotificationIconViewModel)

				Me.co_NCOCntlr		= i_NCOCntlr
				Me.co_ExcelHelper	= i_ExcelHelper
				Me.co_NotifyVM		= i_NotifyVM

			End Sub

		#End Region

	End Class

End Namespace