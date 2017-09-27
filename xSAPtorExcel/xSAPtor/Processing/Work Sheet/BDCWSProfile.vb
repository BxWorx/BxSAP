Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Concurrent

Imports xSAPtorExcel.Services.UI
Imports xSAPtorExcel.Services.Excel

Imports BxS.API.SAPFunctions.ZDTON
Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.BDCWorksheet
	Friend Class BDCWSProfile
								Implements iBDCWSProfile

		#Region "Definitions"

			Private ct_RowIndexGroups		As Dictionary(Of Integer, List(Of Integer))

			Private co_BDCTran					As iBxS_BDCTran_Tran
			Private co_BDCEntry					As iBxS_BDC_Entry

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private cc_WBName  As String
			Friend ReadOnly Property WBookID As String  Implements iBDCWSProfile.WBookID
				Get
					Return Me.cc_WBName
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private cc_WSName  As String
			Friend ReadOnly Property WSheetID As String  Implements iBDCWSProfile.WSheetID
				Get
					Return Me.cc_WSName
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private cn_WSIndex As UShort
			Friend ReadOnly Property WSheetNo As UShort Implements iBDCWSProfile.WSheetNo
				Get
					Return Me.cn_WSIndex
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private co_ExcelWSProfileDTO	As iExcelWSProfileDTO
			Friend ReadOnly Property ExcelWSProfile As iExcelWSProfileDTO	Implements iBDCWSProfile.ExcelWSProfile
				Get
					Return Me.co_ExcelWSProfileDTO
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private co_WSData As iBDCWSData
			Friend ReadOnly Property WSData As iBDCWSData Implements iBDCWSProfile.WSData
				Get
					Return Me.co_WSData
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private co_WSHeader As iBDCWSHeader
			Friend ReadOnly Property WSHeader As iBDCWSHeader Implements iBDCWSProfile.WSHeader
				Get
					Return Me.co_WSHeader
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private ct_BDCTrans As List(Of iBxS_BDCTran_Tran)
			Friend ReadOnly Property BDCTransactions  As List(Of iBxS_BDCTran_Tran)  Implements iBDCWSProfile.BDCTransactions
				Get
					Return Me.ct_BDCTrans
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private ct_BDCMsgs	As ConcurrentDictionary(Of Integer, List(Of iBxS_BDCTran_Msg))
			Friend ReadOnly Property BDCMessages	As ConcurrentDictionary(Of Integer, List(Of iBxS_BDCTran_Msg))	Implements iBDCWSProfile.BDCMessages
				Get
					Return Me.ct_BDCMsgs
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property TranCount As Integer	Implements iBDCWSProfile.TranCount
				Get
					Return Me.ct_BDCTrans.Count
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Property	ProcessedCount	As Integer								Implements iBDCWSProfile.ProcessedCount
			Friend	Property	AsTest					As Boolean								Implements iBDCWSProfile.AsTest

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	SAPSessionID	As String	_
																		Implements iBDCWSProfile.SAPSessionID
				Get
					Return	Me.co_ExcelWSProfileDTO.BDCConfig.SessionID
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	SAPTrnCode		As String	_
																		Implements iBDCWSProfile.SAPTrnCode
				Get
					Return	Me.co_ExcelWSProfileDTO.BDCConfig.SAPTCode
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	cc_SAPUser	As String
			Friend ReadOnly	Property  SAPUser	As String	_
																	Implements	iBDCWSProfile.SAPUser
				Get
					Return	Me.cc_SAPUser
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	CTUParameters	As iBxS_BDC_CTUParameters	_
																		Implements iBDCWSProfile.CTUParameters
				Get
					Return	Me.co_ExcelWSProfileDTO.BDCConfig.CTU_Parameters
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub	UpdateWSMessages(ByVal _messages	As Dictionary(Of Integer, String))	_
										Implements	iBDCWSProfile.UpdateWSMessages
				
				Me.co_WSData.WriteWSMessages(Me.co_ExcelWSProfileDTO, _messages)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function CompileTransactionsAsync(ByVal i_ct	As CancellationToken) _
															As Task(Of Boolean) _
																Implements iBDCWSProfile.CompileTransactionsAsync

				Dim lt_Tasks    As New List(Of Task(Of iBxS_BDCTran_Tran))
				Dim lb_Return   As Boolean  = False

				Me.ct_BDCTrans.Clear()

				' Process each group of EXCEL rows as these indicies are handed over to the Transaction
				' processor
				'
				Me.CompileRowIndexGroups()

				' Process each row group = SAP Transaction
				'
				For Each lo_IndexGroup In me.ct_RowIndexGroups

					Dim lt_RowIndices = lo_IndexGroup.Value
					Dim lo_Task	As Task(Of iBxS_BDCTran_Tran)

					lo_Task	= Task.Factory.StartNew(Of iBxS_BDCTran_Tran)(	Function() Me.CreateBDCTransaction(lt_RowIndices))
					lt_Tasks.Add(lo_Task)

				Next

				' Process each task as they complete until all done
				'
				While lt_Tasks.Count > 0

					If i_ct.IsCancellationRequested
						Me.ct_BDCTrans.Clear()
						i_ct.ThrowIfCancellationRequested()
					End If

					Dim lo_DoneTask As Task(Of iBxS_BDCTran_Tran) = Await Task.WhenAny(lt_Tasks)

					lt_Tasks.Remove(lo_DoneTask)

					Select Case lo_DoneTask.Status
						Case TaskStatus.RanToCompletion
							If Not IsNothing(lo_DoneTask.Result)
								Me.ct_BDCTrans.Add(lo_DoneTask.Result)
							End If
					End Select

				End While

				If Me.ct_BDCTrans.Count > 0
					lb_Return = True
				End If

				Return lb_Return
			
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function LoadDataAsync(ByVal i_ct	As CancellationToken) _
															As Task(Of Boolean) _
																Implements iBDCWSProfile.LoadDataAsync

				Dim lb_Return As Boolean  = False

				If Await Me.co_WSHeader.LoadAsync(i_ExcelWSProfile:= Me.co_ExcelWSProfileDTO,
																					i_ct						:= i_ct )

					If Not i_ct.IsCancellationRequested

						If Await Me.co_WSData.LoadAsync(i_ExcelWSProfile:= Me.co_ExcelWSProfileDTO,
																						i_ct						:= i_ct,
																						i_SearchEOT			:= Me.co_WSHeader.IsMultiLine() )

							If Not i_ct.IsCancellationRequested

								If	Me.co_WSHeader.Columns.Count	<> 0	AndAlso
										Me.co_WSData.Rows.Count				<> 0
									lb_Return = True
								End If

							End If

						End If

					End If

				End If

				Return lb_Return

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub FetchMessages(					ByVal Messages	As ConcurrentDictionary(Of Integer, List(Of iBxS_BDCTran_Msg)),
															Optional	ByVal Reset			As Boolean	= False) _
									Implements iBDCWSProfile.FetchMessages

				If Reset
					Me.ct_BDCMsgs.Clear
				End If
				
				For Each ls_Msg In Messages
					Me.ct_BDCMsgs.TryAdd(key:= ls_Msg.Key, value:= ls_Msg.Value)
				Next

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Function	CreateBDCTransaction(ByVal	rowList	As List(Of Integer)) As iBxS_BDCTran_Tran

				Dim lo_ExcelRow As iExcelRow    = Nothing
				Dim lo_HCol     As iExcelColumn = Nothing
				Dim lc_FldName  As String       = Nothing
				Dim lc_FldVal   As String       = Nothing
				Dim lb_RowUsed  As Boolean
				Dim ln_FldIdx   As UShort
				Dim ln_CsrIdx   As UShort
				Dim ln_ExcelRow	As Integer
				Dim ln_Key			As Integer

				Dim lo_BDCTran	As iBxS_BDCTran_Tran = Me.co_BDCTran.ShallowCopy()

				ln_ExcelRow							= 0
				lo_BDCTran.SAPTCode			= Me.SAPTrnCode
				lo_BDCTran.SAPSessionID	= Me.SAPSessionID

				For Each ln_RowIndex In rowList

					If Not Me.co_WSData.Rows.TryGetValue(key:= ln_RowIndex, value:= lo_ExcelRow)
						Continue For
					End If

					lb_RowUsed = False

					For Each ln_ColIndex In Me.co_WSHeader.ColumnIndex

						If Not Me.co_WSHeader.Columns.TryGetValue(	key   := ln_ColIndex,
																												value	:= lo_HCol)
							Continue For
						End If

						If Not lo_ExcelRow.Values.TryGetValue(key   := ln_ColIndex,
																									value := lc_FldVal)
							Continue For
						End If

						If lo_HCol.IsFieldIndexColumn OrElse lo_HCol.IsCursorIndexColumn
							If lo_HCol.IsFieldIndexColumn
								ln_FldIdx = CUShort(lc_FldVal)
							Else
								ln_CsrIdx = CUShort(lc_FldVal)
							End If
							Continue For ' Column Loop
						End If

						If lo_HCol.DoIFHasValue  AndAlso
							 lc_FldVal.Equals(0)
							Continue For ' Column Loop
						End If

						If lo_HCol.DoFieldIndex OrElse lo_HCol.DoCursorIndex

							If    lo_HCol.DoFieldIndex
								lc_FldName  = lo_HCol.Field_Name.Replace(xBDC_TypePool.cz_Sub_Token, 
																												 String.Concat( "(", ln_FldIdx.ToString, ")")
																												 )
							Else
								lc_FldName  = lo_HCol.Field_Name.Replace(xBDC_TypePool.cz_Sub_Token, 
																												 String.Concat( "(", ln_CsrIdx.ToString, ")")
																												 )
							End If

						Else
							lc_FldName  = lo_HCol.Field_Name
						End If

						' Start of DYNPRO screen
						'
						If lo_HCol.DynPro_Begin.Length <> 0
							ln_Key	+= 1
							lo_BDCTran.BDC_Data.TryAdd(ln_Key,  Me.BDC_DynPro(	i_PrgName:= lo_HCol.Program_Name,
																																	i_DynPro := lo_HCol.DynPro_Number) )
						End If

						' Add BDC_OKCODE, BDC_CURSOR, BDC_SUBSCR {OK code, Cursor, Sub Screen}
						'
						If Not IsNothing(lo_HCol.OKCode) AndAlso lo_HCol.OKCode.Length <> 0
							ln_Key	+= 1
							lo_BDCTran.BDC_Data.TryAdd(ln_Key,  Me.BDC_Field(	i_FldName:= xBDC_TypePool.cz_Cmd_OKCode,
																																i_FldVal := lo_HCol.OKCode) )
						End If
						If Not IsNothing(lo_HCol.Cursor_Before) AndAlso lo_HCol.Cursor_Before.Length <> 0
							ln_Key	+= 1
							lo_BDCTran.BDC_Data.TryAdd(ln_Key,  Me.BDC_Field(	i_FldName:= xBDC_TypePool.cz_Cmd_Cursor,
																																i_FldVal := lo_HCol.Cursor_Before) )
						End If
						If Not IsNothing(lo_HCol.Subscreen) AndAlso lo_HCol.Subscreen.Length <> 0
							ln_Key	+= 1
							lo_BDCTran.BDC_Data.TryAdd(ln_Key,  Me.BDC_Field(	i_FldName:= xBDC_TypePool.cz_Cmd_SubScr,
																																i_FldVal := lo_HCol.Subscreen) )
						End If

						' Add actual field value, If not @@ which is a Psuedo action
						' and value not @@[] which is don't skip but make SAP field blank
						'
						If lc_FldVal <> xBDC_TypePool.cz_Sym_PsuedoAction

							If lc_FldVal = xBDC_TypePool.cz_Sym_ClearFld
								lc_FldVal = ""
							End If

							ln_Key	+= 1
							lo_BDCTran.BDC_Data.TryAdd(ln_Key,  Me.BDC_Field(	i_FldName:= lc_FldName,
																																i_FldVal := lc_FldVal) )

						End If

						lb_RowUsed = True

					Next

					If lb_RowUsed
						ln_ExcelRow  = lo_ExcelRow.RowNo()
					End If

				Next
				
				lo_BDCTran.ExcelRow	= CUInt(ln_ExcelRow)

				Return lo_BDCTran

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function	BDC_DynPro(	ByVal	i_PrgName	As String,
																		ByVal i_DynPro  As String)	As iBxS_BDC_Entry

				Dim lo_BDCData  As iBxS_BDC_Entry = Me.co_BDCEntry.ShallowCopy()

				lo_BDCData.Program_Name   = i_PrgName
				lo_BDCData.Dynpro_Number  = i_DynPro
				lo_BDCData.Dynpro_Begin   = xBDC_TypePool.cz_Sub_ABAPTrue

				Return lo_BDCData

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Function	BDC_Field(ByVal	i_FldName As String,
																	ByVal i_FldVal	As String)	As iBxS_BDC_Entry

				Dim lo_BDCData  As iBxS_BDC_Entry = Me.co_BDCEntry.ShallowCopy()

				lo_BDCData.Field_Name   = i_FldName
				lo_BDCData.Field_Value  = i_FldVal

				Return lo_BDCData

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub CompileRowIndexGroups()

				Dim ln_TranNo   As Integer          = 0
				Dim ln_IndexNo  As Integer          = 0
				Dim lo_WSRow    As iExcelRow        = Nothing
				Dim lb_New      As Boolean          = True
				Dim lt_Group    As List(Of Integer) = Nothing

				Me.ct_RowIndexGroups.Clear()

				Do

					If Me.co_WSData.Rows.TryGetValue(key  := Me.co_WSData.RowIndex(ln_IndexNo),
																					 value:= lo_WSRow)

						If lb_New

							ln_TranNo += 1
							lt_Group = New List(Of Integer)
							Me.ct_RowIndexGroups.Add(key:= ln_TranNo, value:= lt_Group )

						Else
							Me.ct_RowIndexGroups.TryGetValue(ln_TranNo, lt_Group)
						End If

						lt_Group.Add(Me.co_WSData.RowIndex(ln_IndexNo))

						lb_New = lo_WSRow.IsTerminated

						If lb_New	AndAlso Me.AsTest
							Exit Do
						End If

					End If

					ln_IndexNo += 1

				Loop While ln_IndexNo < Me.co_WSData.RowIndex.Count

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(	ByVal excelWSProfileDTO		As	iExcelWSProfileDTO	,
											ByVal bdcWSHeader					As	iBDCWSHeader				,
											ByVal	bdcWSData						As	iBDCWSData					,
											ByVal bdcTran							As	iBxS_BDCTran_Tran		,
											ByVal bdcEntry						As	iBxS_BDC_Entry			,
											ByVal	sapuser							As	String								)

				Me.co_ExcelWSProfileDTO	= excelWSProfileDTO
				Me.co_WSHeader					= bdcWSHeader
				Me.co_WSData						= bdcWSData
				Me.co_BDCTran						= bdcTran
				Me.co_BDCEntry					= bdcEntry

				Me.cc_SAPUser						= sapuser

				Me.ct_RowIndexGroups  = New Dictionary(Of Integer, List(Of Integer))
				Me.ct_BDCTrans        = New List(Of iBxS_BDCTran_Tran)
				Me.ct_BDCMsgs					= New ConcurrentDictionary(Of Integer, List(Of iBxS_BDCTran_Msg))

			End Sub

		#End Region

	End Class

End Namespace