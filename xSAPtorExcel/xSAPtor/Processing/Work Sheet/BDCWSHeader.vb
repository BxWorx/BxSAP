Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.Services.UI
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.BDCWorksheet

	Friend Class BDCWSHeader
								Implements iBDCWSHeader

		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function LoadAsync(ByVal i_ExcelWSProfile	As iExcelWSProfileDTO,
																			ByVal i_ct							As CancellationToken) _
															As Task(Of Boolean) _
																Implements iBDCWSHeader.LoadAsync

				Dim lt_Data		As Object(,)		=	Me.co_ExcelHlper.GetData(	i_WBName := i_ExcelWSProfile.WBookName,
																																	i_WSIndex:= i_ExcelWSProfile.WSheetIndex,
																																	i_Address:= i_ExcelWSProfile.HeaderArea.Address)
				Dim lo_Tasks	As New List(Of Task(Of iExcelColumn))
				Dim ln_OffSet	As Integer	= i_ExcelWSProfile.HeaderArea.tlColumnNo - 1

				Me.Reset()

				For ln_ColIdx As Integer = 1 To i_ExcelWSProfile.HeaderArea.ColCount

					If i_ct.IsCancellationRequested
						Me.Reset()
						i_ct.ThrowIfCancellationRequested()
					End If
					'................................................
					If	ln_ColIdx.Equals(i_ExcelWSProfile.MessageColumnNo - ln_OffSet)		OrElse
							ln_ColIdx.Equals(i_ExcelWSProfile.SelectColumnNo	- ln_OffSet)
						Continue For
					End If
					'................................................
					Dim lo_ColData  As Object() = New Object(i_ExcelWSProfile.HeaderArea.RowCount){}
				
					lo_ColData(xBDC_TypePool.BDC_RowType.ColumnNo) = ln_ColIdx

					For ln_RowIdx As Integer = 1 To i_ExcelWSProfile.HeaderArea.RowCount
						If Not IsNothing(lt_Data(ln_RowIdx, ln_ColIdx))
							lo_ColData(ln_RowIdx) = lt_Data(ln_RowIdx, ln_ColIdx)
						End If
					Next

					Dim lo_Task As Task(Of iExcelColumn) = Task.Factory.StartNew(Of iExcelColumn)(
							Function()

								Dim lo_BDCCol As iExcelColumn = New ExcelColumn(i_ColData:=lo_ColData)

								If lo_BDCCol.Utilized
									Return lo_BDCCol
								Else
									Return Nothing
								End If

							End Function	,
								i_ct				,
								TaskCreationOptions.PreferFairness)

					lo_Tasks.Add(lo_Task)

				Next

				Dim lc_Value  As String   = ""
				Dim ln_Count  As Integer  = 0

				While lo_Tasks.Count > 0

					If i_ct.IsCancellationRequested
						Me.ct_Columns.Clear()
						i_ct.ThrowIfCancellationRequested()
					End If

					Dim lo_DoneTask As Task(Of iExcelColumn) = Await Task.WhenAny(lo_Tasks)

					lo_Tasks.Remove(lo_DoneTask)

					Select Case lo_DoneTask.Status
						Case TaskStatus.RanToCompletion
							If Not IsNothing(lo_DoneTask.Result)

								If Me.ct_Columns.TryAdd(lo_DoneTask.Result.Column_No, lo_DoneTask.Result)
								End If
								'For Each lc_Cmd In lo_DoneTask.Result.Commands
								'	Select Case lc_Cmd.Key

								'		Case xTypePool_Commands.cz_SAPTCode   : Me.cc_SAPTCode  = lc_Cmd.Value
								'		Case xTypePool_Commands.cz_ActiveCol  : Me.cn_ActiveCol = CUShort(lc_Cmd.Value)
								'		Case xTypePool_Commands.cz_PauseSec   : Me.cn_Pause     = CUShort(lc_Cmd.Value)

								'		Case xTypePool_Commands.cz_CTUDefsz   : Me.co_CTUParms.DefSize = CChar(lc_Cmd.Value)
								'		Case xTypePool_Commands.cz_CTUDispm   : Me.co_CTUParms.DisMode = CChar(lc_Cmd.Value)
								'		Case xTypePool_Commands.cz_CTUUpdte   : Me.co_CTUParms.UpdMode = CChar(lc_Cmd.Value)

								'		Case xTypePool_Commands.cz_ExecTran   : Me.cb_MultiLine = True

								'	End Select
								'Next

							End If

						Case TaskStatus.Faulted
							'Handle(completed.Exception.InnerException)

					End Select

				End While

				If Me.ct_Columns.Count = 0
					Return False
				Else

					Me.ct_ColIndex = Me.ct_Columns.Keys.ToList()
					Me.ct_ColIndex.Sort()

					Return True

				End If

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private Methods"

			Private Sub Reset()

				Me.ct_Columns.Clear()
				Me.ct_ColIndex.Clear()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private ct_ColIndex As New List(Of Integer)
			Friend ReadOnly Property ColumnIndex()  As List(Of Integer) Implements iBDCWSHeader.ColumnIndex
				Get
					Return Me.ct_ColIndex
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private ct_Columns  As New concurrentDictionary(Of Integer, iExcelColumn)
			Friend ReadOnly Property Columns()  As concurrentDictionary(Of Integer, iExcelColumn) Implements iBDCWSHeader.Columns
				Get
					Return Me.ct_Columns
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private cb_MultiLine  As Boolean
			Friend ReadOnly Property IsMultiLine  As Boolean Implements iBDCWSHeader.IsMultiLine
				Get
					Return Me.cb_MultiLine
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Definitions"

			Private	co_ExcelHlper	As iExcelHelper

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(ByVal	excelhelper	As iExcelHelper)

				Me.co_ExcelHlper	= excelhelper

			End Sub

		#End Region

	End Class

End Namespace