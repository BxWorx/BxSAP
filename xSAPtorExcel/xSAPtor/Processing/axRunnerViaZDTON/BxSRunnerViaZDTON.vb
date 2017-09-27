Imports System.Threading
Imports	System.Threading.Tasks

Imports xSAPtorExcel.Main.Process.Controller
Imports	xSAPtorExcel.Main.Process.Selection
Imports xSAPtorExcel.Main.Process.BDCWorksheet

Imports	xSAPtorExcel.Services.UI

Imports BxS.API.SAPFunctions.ZDTON
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Runner.ViaZDTON
	Friend Class	BxSRunnerViaZDTON
									Implements iBxSRunnerViaZDTON

		#Region "Definitions"

			Private	WithEvents	co_Cntlr		As	iBxSProcessController
			'....................................................
			Private	co_SAPFnc		As	iBxS_ZDTON

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	Reset() _
										Implements iBxSRunnerViaZDTON.Reset

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function	FetchMessagesAsync(	ByVal _taskList		As	List(Of ProcessViewTaskDTO)	,
																								ByVal _progtask		As	IProgress(Of iPBarData)			,
																								ByVal _cancel			As	CancellationToken							)		As Task(Of Boolean) _
															Implements iBxSRunnerViaZDTON.FetchMessagesAsync

				Dim lb_Ret				As	Boolean		= True
				Dim	ln_Cnt				As	Integer		= 0
				Dim	lo_PBarTask		As	iPBarData
				'..................................................
				lo_PBarTask	= New PBarData(_taskList.Count)
				_progtask.Report(lo_PBarTask)
				'..................................................
				so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone("ZDTON Messages: Processing initiated") )

				For Each lo_WBWS In _taskList

					Try

							If _cancel.IsCancellationRequested
								_cancel.ThrowIfCancellationRequested()
							End If
							'................................................
							Dim lc_Msg				= String.Format("WB:{0} / WS:{1}:", lo_WBWS.WBName, lo_WBWS.WSName)
							Dim lo_WSProfile	= Me.co_Cntlr.GetBDCWSProfile(lo_WBWS.WBName, lo_WBWS.WSName)

							so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone(String.Format("{0} Started", lc_Msg)) )
							'................................................
							Dim lo_DTO				=	Me.co_SAPFnc.GetDTO()

							lo_DTO.User				= lo_WSProfile.SAPUser
							lo_DTO.SessionID	= lo_WSProfile.SAPSessionID
							lo_DTO.SAPTCode		= lo_WSProfile.SAPTrnCode

							If Await	Me.co_SAPFnc.GetPostMessages(lo_DTO, _cancel)

								Dim lt_Msgs	As New Dictionary(Of Integer, String)

								For Each lo In lo_DTO.Msgs
									lt_Msgs.Add(lo.Key, lo.Value.Message)
								Next

								lo_WSProfile.UpdateWSMessages(lt_Msgs)

								lo_PBarTask.Complete	+= 1
								_progtask.Report(lo_PBarTask)

								so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone(String.Format("{0} Completed", lc_Msg)) )

							Else
								so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone(String.Format("{0} No messages", lc_Msg)) )
							End If

						Catch ex As Exception

							' implement session removal from sap

							so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone("ZDTON Process: Cancelled") )
							lb_Ret	= False
							Exit For

					End Try

				Next
				'..................................................
				If lb_Ret
					so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone("ZDTON Process: Processing done") )
				End If
				'..................................................
				Return lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function	StartPostAsync(	ByVal _taskList		As	List(Of ProcessViewTaskDTO)	,
																						ByVal _progtask		As	IProgress(Of iPBarData)			,
																						ByVal _progtran		As	IProgress(Of iPBarData)			,
																						ByVal _ct					As	CancellationToken							)		As Task(Of Boolean) _
															Implements iBxSRunnerViaZDTON.StartPostAsync

				Dim	lo_Progress		As	IProgress(Of Integer)	= New Progress(Of Integer)	(AddressOf Me.Handler_Progress)
				Dim lb_Ret				As	Boolean		= True
				Dim	ln_Cnt				As	Integer		= 0
				Dim	lo_PBarTask		As	iPBarData
				'..................................................
				lo_PBarTask	= New PBarData(_taskList.Count)
				_progtask.Report(lo_PBarTask)
				'..................................................
				so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone("ZDTON Post: Processing initiated") )

				For Each lo_WBWS In _taskList

					Try

							If _ct.IsCancellationRequested
								_ct.ThrowIfCancellationRequested()
							End If
							'................................................
							Dim lc_Msg				= String.Format("WB:{0} / WS:{1}:", lo_WBWS.WBName, lo_WBWS.WSName)
							Dim lo_WSProfile	= Me.co_Cntlr.GetBDCWSProfile(lo_WBWS.WBName, lo_WBWS.WSName)

							so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone(String.Format("{0} Started", lc_Msg)) )
							'................................................
							If Await Me.LoadWSDataAsync( lo_WSProfile, _ct )

								so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone(String.Format("{0} WS Data loaded", lc_Msg)) )

								Dim lo_DTO				=	Me.co_SAPFnc.GetDTO()

								lo_DTO.User				= lo_WSProfile.SAPUser
								lo_DTO.SessionID	= lo_WSProfile.SAPSessionID
								lo_DTO.SAPTCode		= lo_WSProfile.SAPTrnCode
								'..................................................
								Me.CompileZDTONData(lo_WSProfile, lo_DTO)
								so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone(String.Format("{0} WS ZDTON Data compiled", lc_Msg)) )
								'..................................................
								If Await Me.co_SAPFnc.PostDataAsync(lo_DTO, lo_Progress, _ct)

									lo_PBarTask.Complete	+= 1
									_progtask.Report(lo_PBarTask)

									so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone(String.Format("{0} Completed", lc_Msg)) )

								Else
									so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone(String.Format("{0} SAP data upload failed", lc_Msg)) )
								End If
							Else
								so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone(String.Format("{0} Excel data load failed", lc_Msg)) )
							End If

						Catch ex As Exception

							' implement session removal from sap

							so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone("ZDTON Process: Cancelled") )
							lb_Ret	= False
							Exit For

					End Try

				Next
				'..................................................
				If lb_Ret
					so_MsgHub.Value.Publish( so_NotifyDTO.Value.Clone("ZDTON Process: Processing done") )
				End If
				'..................................................
				Return lb_Ret

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Async Function LoadWSDataAsync(	ByVal _wsprofile	As ibdcwsprofile						,
																							ByVal _ct					As CancellationToken					)	As Task(Of Boolean)

				If Await _wsprofile.LoadDataAsync(_ct)
					If Not _ct.IsCancellationRequested
						If Await _wsprofile.CompileTransactionsAsync(_ct)
							If Not _ct.IsCancellationRequested
								Return	True
							End If
						End If
					End If
				End If
				'..................................................
				Return	False

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub CompileZDTONData(ByRef _wsprofile		As ibdcwsprofile	,
																	 ByRef _zdtondto		As iBxS_ZDTON_DTO		)

				Dim ln_ColIdx	As Integer

				ln_ColIdx	= 0

				For Each lo_Col In _wsprofile.WSHeader.Columns

					Dim lo_ColDTO	= _zdtondto.CreateColumnDTO

					ln_ColIdx	+= 1

					lo_ColDTO.Columno				=	ln_ColIdx	'	lo_Col.Value.Column_No
					lo_ColDTO.ProgName			= lo_Col.Value.Program_Name
					lo_ColDTO.DynproStart		= lo_Col.Value.DynPro_Begin
					lo_ColDTO.BDCSubScreen	= lo_Col.Value.Subscreen
					lo_ColDTO.BDCOKCode			= lo_Col.Value.OKCode
					lo_ColDTO.BDCCursor			= lo_Col.Value.Cursor_Before
					lo_ColDTO.FieldName			= lo_Col.Value.Field_Name
					lo_ColDTO.SpecInstr			= lo_Col.Value.Instructions

					If Not Integer.TryParse(lo_Col.Value.DynPro_Number, lo_ColDTO.ScreenNo)
						lo_ColDTO.ScreenNo	= CInt("9999")
					End If

					_zdtondto.Columns.Add(lo_ColDTO)

				Next
				'..................................................
				For Each lo_Row In _wsprofile.WSData.Rows

					Dim lo_RowDTO		= _zdtondto.CreateDataDTO

					lo_RowDTO.Reset()

					lo_RowDTO.User				= _zdtondto.User
					lo_RowDTO.SessionID		= _zdtondto.SessionID
					lo_RowDTO.RowNo				= lo_Row.Value.IndexNo
					lo_RowDTO.ExcelRow		= lo_Row.Value.RowNo

					ln_ColIdx	= 0

					For Each lc In lo_Row.Value.Values

						ln_ColIdx	+= 1
						lo_RowDTO.DataValues.Add(ln_ColIdx, lc.Value)	'lc.Key

					Next

					_zdtondto.Data.Add(lo_Row.Key, lo_RowDTO)

				Next

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Handler_Progress(	ByVal counter	As Integer)

				Dim x = 1

			'	SyncLock	Me.co_LckObj
			'		Me.cn_ProgCnt	+= 1
			'		Me.cn_ProgInc += 1

			'		If Me.cn_ProgInc >= Me.cn_ProgSub
			'			Me.cn_ProgInc	= 0
						
			'		End If


			'	End SyncLock

			'	Interlocked.Increment(Me.cn_ProgCnt)

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(ByVal _controller	As iBxSProcessController)
			
				Me.co_Cntlr		= _controller
				Me.co_SAPFnc	= Me.co_Cntlr.GetBDCZDTON()
				'..................................................
				Me.co_SAPFnc.SetNoOfParallelProcesses( CInt( Me.co_Cntlr.GetOptionModel.FetchOptions().ParallelProcessesTran ) )

			End Sub

		#End Region

	End Class

End Namespace