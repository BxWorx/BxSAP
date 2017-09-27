Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Concurrent

Imports xSAPtorExcel.Services.Excel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.BDCWorksheet
	Friend Class BDCWSData
								Implements iBDCWSData

		#Region "Methods"

			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend Async Function LoadAsync(					ByVal _wsprofile		As iExcelWSProfileDTO				,
																								ByVal _ct						As CancellationToken				,
																			Optional  ByVal _SearchEOT		As Boolean  = False						) As Task(Of Boolean) _
															Implements iBDCWSData.LoadAsync

				Dim lo_Tasks          As List(Of Task(Of iExcelRow))  = New List(Of Task(Of iExcelRow))
				Dim ln_OffSet					As Integer	= _wsprofile.HeaderArea.tlColumnNo - 1
				Dim lc_RowTemplate    As String		= _wsprofile.RowTemplate
				Dim lt_ActiveRowData  As Object(,)

				lt_ActiveRowData	=	Me.co_ExcelHlper.GetData(	i_WBName	:= _wsprofile.WBookName					,
																											i_WSIndex	:= _wsprofile.WSheetIndex				,
																											i_Address	:= _wsprofile.SelectArea.Address	)

				Me.Reset()

				For ln_Index As Integer = 1 To lt_ActiveRowData.Length


					If _ct.IsCancellationRequested
						Me.ct_Rows.Clear()
						_ct.ThrowIfCancellationRequested()
					End If

					If Not IsNothing(lt_ActiveRowData(ln_Index, 1)) AndAlso
													 lt_ActiveRowData(ln_Index, 1).ToString.ToUpper.Equals(xBDC_TypePool.cz_Sub_ABAPTrue)

						Dim ln_Idx				As Integer	= ln_Index
						Dim ln_RowNo      As Integer  = ln_Index + _wsprofile.SelectArea.tlRowNo - 1
						Dim lc_RowAddr    As String   = lc_RowTemplate.Replace(xBDC_TypePool.cz_Sub_Token, CStr(ln_RowNo))
						Dim lo_RowData(,) As Object   =	Me.co_ExcelHlper.GetData(	i_WBName := _wsprofile.WBookName,
																																			i_WSIndex:= _wsprofile.WSheetIndex,
																																			i_Address:= lc_RowAddr)

						lo_RowData(1,_wsprofile.SelectColumnNo	- ln_OffSet)	= Nothing
						lo_RowData(1,_wsprofile.MessageColumnNo	- ln_OffSet)	= Nothing

						lo_Tasks.Add( Task.Factory.StartNew(Of iExcelRow)(
														Function()
															Return New ExcelRow(	indexNo			:=	ln_Idx		,
																										i_RowNo     := ln_RowNo		,
																										i_Data      := lo_RowData	,
																										i_SearchEOT	:= _SearchEOT	)
														End Function,
														_ct	)
												)

					End If

				Next

				While lo_Tasks.Count > 0

					If _ct.IsCancellationRequested
						Me.ct_Rows.Clear()
						_ct.ThrowIfCancellationRequested()
					End If

					Dim lo_DoneTask As Task(Of iExcelRow) = Await Task.WhenAny(lo_Tasks)

					lo_Tasks.Remove(lo_DoneTask)

					Select Case lo_DoneTask.Status

						Case TaskStatus.RanToCompletion

							If lo_DoneTask.Result.Values.Count > 0
								If Not Me.ct_Rows.TryAdd(lo_DoneTask.Result.RowNo, lo_DoneTask.Result)
									'Handle(completed.Exception.InnerException)
								End If
							End If

						Case TaskStatus.Faulted
							'Handle(completed.Exception.InnerException)

					End Select

				End While

				If Me.ct_Rows.Count = 0

					so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone(String.Format("No items selected (Column:[{0}])", _wsprofile.SelectArea.tlColumnID)))
					Return False

				Else

					Me.ct_RowIndex = Me.ct_Rows.Keys.ToList()
					Me.ct_RowIndex.Sort()

					Return True

				End If

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub	WriteWSMessages(ByVal	_excelwsprofile	As iExcelWSProfileDTO,
																	ByVal _messages				As Dictionary(Of Integer, String) ) _
										Implements	iBDCWSData.WriteWSMessages

				Dim lo_Arr		As Array			= Array.CreateInstance( GetType(Object), _messages.Count - 1 ,1 )
				Dim lt_Data		As Object(,)	= CType(lo_Arr, Object(,))

				For Each lo In _messages.Where(Function(x) Not x.Key.Equals(0) )
					lt_Data(lo.Key - 1, 0)	= lo.Value
				Next

				Me.co_ExcelHlper.PutData(	_excelwsprofile.WBookName		, 
																	_excelwsprofile.WSheetName	, 
																	_excelwsprofile.MessageArea	,
																  lt_Data	)

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Reset()

				Me.ct_Rows.Clear()
				Me.ct_RowIndex.Clear()
		
			End Sub  

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"
	
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private ct_Rows As New ConcurrentDictionary(Of Integer, iExcelRow)
			Friend ReadOnly Property Rows() As ConcurrentDictionary(Of Integer, iExcelRow) Implements iBDCWSData.Rows
				Get
					Return Me.ct_Rows
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private ct_RowIndex As New List(Of Integer)
			Friend ReadOnly Property RowIndex() As List(Of Integer) Implements iBDCWSData.RowIndex
				Get
					Return Me.ct_RowIndex
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