Imports System.Collections.Concurrent
Imports xSAPtorExcel.Main.BDCProcessing
Imports xSAPtorExcel.Main.Notification.Icon
Imports xSAPtorExcel.Main.Process.Common
Imports xSAPtorExcel.Main.Process.Options
Imports xSAPtorExcel.Services.Excel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Runner

	Friend Class xProcessRunnerController
								Implements ixProcessRunnerController


			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function Reset()	As Boolean Implements ixProcessRunnerController.Reset
				Return Me.co_ProcessRunnerModel.Reset()
			End Function



		#Region "Events"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub StartUp() _
									Implements ixProcessRunnerController.StartUp
				
			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Process: Model"

			Private WithEvents	co_ProcessRunnerPLC		As ixProcessRunnerPLC
			Private WithEvents	co_ProcessRunnerModel	As ixProcessRunnerModel

			Private	ct_EventTracker	As ConcurrentStack(Of Boolean)
			Private cb_Busy					As Boolean
			Private	co_LockBusy			As New Object

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub EventHandler_ProcessRunnerModelTaskSubmitted()

				Me.ct_EventTracker.Push(True)

				If Me.cb_Busy	Then Return

				Do

					SyncLock	Me.co_LockBusy
						If Me.cb_Busy
							Exit Do
						Else
							Me.cb_Busy	= True
						End If
					End SyncLock

					Do While Me.co_ProcessRunnerModel.QueueCount > 0

						Dim lo_Task	As ixProcessTask	= Nothing

						If Me.co_ProcessRunnerModel.Dequeue(TaskOut:= lo_Task)
							Me.co_ProcessRunnerPLC.Post(i_Request:= lo_Task)
						End If

					Loop

					Me.co_ProcessRunnerPLC.Complete()

					Dim ln_WSCount	= Await Me.co_ProcessRunnerPLC.StartupConsumersAsync(ProcessOptions:= Me.co_Options)

					Do While Me.co_ProcessRunnerPLC.WorksheetCount > 0

						Dim lo_WSProfile	As iBDCWSProfile	= Me.co_ProcessRunnerPLC.TryTakeProfile()

						If lo_WSProfile IsNot Nothing

							' TO-DO: remove create from here, must redesign for DI

							Dim lo_MsgHandler	As ixProcessMessageHandler	= xProcessMessageHandler.Create(ExcelHelper		 := Me.co_ExcelHelper,
																																														WorkbookName	 := lo_WSProfile.ExcelWSProfile.WBookName,
																																														WorksheetName	 := lo_WSProfile.ExcelWSProfile.WSheetName,
																																														MessageColumnID:= lo_WSProfile.ExcelWSProfile.BDCConfig.MessageColumnAddress)

							lo_MsgHandler.LoadMessages(WSProfile:= lo_WSProfile)
							lo_MsgHandler.Update()



							Dim lo_TaskUpd	As ixProcessRunnerUpdateDTO	= New xProcessRunnerUpdateDTO

							lo_TaskUpd.TaskID			= lo_WSProfile.ExcelWSProfile.BDCConfig.GUID
							lo_TaskUpd.Count			= lo_WSProfile.ProcessedCount

							Me.co_ProcessRunnerModel.UpdateTask(TaskUpdate:= lo_TaskUpd)

						End If

					Loop

					Me.ct_EventTracker.Clear()

					SyncLock	Me.co_LockBusy

						Me.cb_Busy	= False

						If Me.ct_EventTracker.Count = 0
							Exit Do
						End If

					End SyncLock

				Loop

			End Sub

		#End Region







		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			Private WithEvents	co_NotifyVM			As ixNotificationIconViewModel

			Private Event				ev_Shutdown()		Implements ixProcessRunnerController.ev_Shutdown

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub EventHandler_Shutdown()

				RemoveHandler	Me.co_ProcessRunnerModel.ev_TaskSubmitted,
											AddressOf Me.EventHandler_ProcessRunnerModelTaskSubmitted

				RemoveHandler	Globals.ThisAddIn.ev_xSAPtorShutDown,
											AddressOf Me.EventHandler_Shutdown

				RaiseEvent ev_Shutdown()		' Notifies any VIEWS listening

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			Private co_Options			As ixProcessOptionsDTO
			Private	co_ExcelHelper	As iExcelHelper

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Shared Function Create(ByVal ProcessRunnerPLC		As ixProcessRunnerPLC,
																		ByVal ProcessRunnerModel	As ixProcessRunnerModel,
																		ByVal ProcessOptions			As ixProcessOptionsDTO,
																		ByVal ExcelHelper					As iExcelHelper,
																		ByVal NotifyVM						As ixNotificationIconViewModel) _
															As ixProcessRunnerController

				Return New xProcessRunnerController(i_RunnerPLC					:= ProcessRunnerPLC,
																						i_ProcessRunnerModel:= ProcessRunnerModel,
																						i_ProcessOptions		:= ProcessOptions,
																						i_ExcelHelper				:= ExcelHelper,
																						i_NotifyVM					:= NotifyVM)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_RunnerPLC						As ixProcessRunnerPLC,
											ByVal i_ProcessRunnerModel	As ixProcessRunnerModel,
											ByVal i_ProcessOptions			As ixProcessOptionsDTO,
											ByVal i_ExcelHelper					As iExcelHelper,
											ByVal	i_NotifyVM						As ixNotificationIconViewModel)

				Me.co_ProcessRunnerPLC		= i_RunnerPLC
				Me.co_ProcessRunnerModel	= i_ProcessRunnerModel
				Me.co_Options							= i_ProcessOptions
				Me.co_ExcelHelper					= i_ExcelHelper
				Me.co_NotifyVM						= i_NotifyVM

				Me.cb_Busy								= False
				Me.ct_EventTracker				= New ConcurrentStack(Of Boolean)

				AddHandler	Me.co_ProcessRunnerModel.ev_TaskSubmitted,
										AddressOf Me.EventHandler_ProcessRunnerModelTaskSubmitted

				AddHandler	Globals.ThisAddIn.ev_xSAPtorShutDown,
										AddressOf Me.EventHandler_Shutdown

			End Sub

		#End Region

	End Class

End Namespace