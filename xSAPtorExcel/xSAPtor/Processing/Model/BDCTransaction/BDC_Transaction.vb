Imports System.Threading
Imports xSAPtorExcel.Services.Excel
Imports xSAPtorNCO.API.SAP.System.Services
'================================================
Namespace Main.BDCProcessing

	Friend Class BDC_Transaction
								Implements iBDC_Transaction

		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private cc_SAPTCode As String
			Friend ReadOnly Property SAP_TCode  As String Implements iBDC_Transaction.SAP_TCode
				Get
					Return Me.cc_SAPTCode
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private cn_ExcelRow As Integer
			Friend ReadOnly Property ExcelRow As Integer Implements iBDC_Transaction.ExcelRow
				Get
					Return Me.cn_ExcelRow
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private ct_BDCData  As List(Of iBDC_Data)
			Friend ReadOnly Property BDC_Data As List(Of iBDC_Data) Implements iBDC_Transaction.BDC_Data
				Get
					Return Me.ct_BDCData
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function Process(ByRef i_ct          As CancellationToken,
															ByRef i_WSProfile		As iExcelWSProfileDTO,
															ByRef i_WSHeader    As iBDCWSHeader,
															ByRef i_WSData      As iBDCWSData,
															ByVal i_RowIndices  As List(Of Integer))  As ixBDCTransaction  Implements iBDC_Transaction.Process

				Dim lo_BDCTran	As ixBDCTransaction = New xBDCTransaction

				Dim lo_ExcelRow As iExcelRow    = Nothing
				Dim lo_HCol     As iExcelColumn = Nothing
				Dim lc_FldName  As String       = Nothing
				Dim lc_FldVal   As String       = Nothing
				Dim lb_RowUsed  As Boolean
				Dim ln_FldIdx   As UShort
				Dim ln_CsrIdx   As UShort

				lo_BDCTran.SAP_TCode  = i_WSProfile.BDCConfig.SAPTCode
				lo_BDCTran.CTUParams  = i_WSProfile.BDCConfig.CTU_Parameters
				
				Me.cn_ExcelRow				= 0	

				For Each ln_RowIndex In i_RowIndices

					If Not i_WSData.Rows.TryGetValue(key:= ln_RowIndex, value:= lo_ExcelRow)
						Continue For ' Row Loop
					End If

					lb_RowUsed = False

					For Each ln_ColIndex In i_WSHeader.ColumnIndex

						If Not i_WSHeader.Columns.TryGetValue(key   := ln_ColIndex,
																									value := lo_HCol)
							Continue For ' Column Loop
						End If

						If Not lo_ExcelRow.Values.TryGetValue(key   := ln_ColIndex,
																									value := lc_FldVal)
							Continue For ' Column Loop
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
							lo_BDCTran.BDC_Data.Add(Me.BDC_DynPro(i_PrgName:= lo_HCol.Program_Name,
																										i_DynPro := lo_HCol.DynPro_Number) )
						End If

						' Add BDC_OKCODE, BDC_CURSOR, BDC_SUBSCR {OK code, Cursor, Sub Screen}
						'
						If Not IsNothing(lo_HCol.OKCode) AndAlso lo_HCol.OKCode.Length <> 0
							lo_BDCTran.BDC_Data.Add(Me.BDC_Field(i_FldName:= xBDC_TypePool.cz_Cmd_OKCode,
																									 i_FldVal := lo_HCol.OKCode) )
						End If
						If Not IsNothing(lo_HCol.Cursor_Before) AndAlso lo_HCol.Cursor_Before.Length <> 0
							lo_BDCTran.BDC_Data.Add(Me.BDC_Field(i_FldName:= xBDC_TypePool.cz_Cmd_Cursor,
																									 i_FldVal := lo_HCol.Cursor_Before) )
						End If
						If Not IsNothing(lo_HCol.Subscreen) AndAlso lo_HCol.Subscreen.Length <> 0
							lo_BDCTran.BDC_Data.Add(Me.BDC_Field(i_FldName:= xBDC_TypePool.cz_Cmd_SubScr,
																									 i_FldVal := lo_HCol.Subscreen) )
						End If

						' Add actual field value, If not @@ which is a Psuedo action
						' and value not @@[] which is don't skip but make SAP field blank
						'
						If lc_FldVal <> xBDC_TypePool.cz_Sym_PsuedoAction

							If lc_FldVal = xBDC_TypePool.cz_Sym_ClearFld
								lc_FldVal = ""
							End If

							lo_BDCTran.BDC_Data.Add(Me.BDC_Field(i_FldName:= lc_FldName,
																									 i_FldVal := lc_FldVal) )

						End If

						lb_RowUsed = True

					Next

					If lb_RowUsed
						Me.cn_ExcelRow  = lo_ExcelRow.RowNo()
					End If

				Next
				
				lo_BDCTran.ExcelRow	= Me.cn_ExcelRow

				Return lo_BDCTran

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function BDC_DynPro(ByVal i_PrgName As String,
														 ByVal i_DynPro  As String) As ixBDCData

				Dim lo_BDCData  As ixBDCData = New xBDCData

				lo_BDCData.Program_Name   = i_PrgName
				lo_BDCData.Dynpro_Number  = i_DynPro
				lo_BDCData.Dynpro_Begin   = xBDC_TypePool.cz_Sub_ABAPTrue

				Return lo_BDCData

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function BDC_Field(ByVal i_FldName As String, ByVal i_FldVal As String) As ixBDCData

				Dim lo_BDCData  As ixBDCData = New xBDCData

				lo_BDCData.Field_Name   = i_FldName
				lo_BDCData.Field_Value  = i_FldVal

				Return lo_BDCData

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Construction"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New()
				Me.ct_BDCData = New List(Of iBDC_Data)
			End Sub

		#End Region

	End Class

End Namespace