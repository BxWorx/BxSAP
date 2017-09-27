Imports xSAPtorExcel.Services.Excel

Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
	Friend Class BDCDataSheet
								Implements iBDCDataSheet

		#Region "Definitions"

				Enum le_Row As UShort
					PrgNme = 0
					DynNum = 1
					DynBeg = 2
					BDCOk  = 3
					BDCCur = 4
					BDCScr = 5
					FldNme = 6
					Descr  = 7
					SpcIns = 8
					Value  = 9
				End Enum

			Private co_SessionProfile	As iBxSBDCSession_Profile
			Private co_WSheet         As Excel.Worksheet
			Private co_ExcelHelper    As iExcelHelper
			Private co_ExcelAddrHndlr As iExcelAddress

			Private ct_Data						As Object(,)
			Private cc_XMLConfig			As String
			Private cc_RngDat					As String
			Private cc_RngFmt					As String

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub Process() Implements iBDCDataSheet.Process

				Me.CompileWSData()

				If Me.CreateWSheet()

					Me.FormatHeader()
					Me.PasteData()
					Me.FinaliseFormat()

				End If

		End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub FinaliseFormat()

				Dim	lb_State		As Boolean
				Dim lo_RngCfg		As Excel.Range
				Dim lo_RngTrg		As Excel.Range
				'..................................................
				lo_RngCfg	= Me.co_WSheet.Range("A:A")
				lo_RngCfg.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove)
				'..................................................
				lo_RngCfg	= Me.co_WSheet.Range("A:A")
				lo_RngCfg.ColumnWidth	= 0.5
				lo_RngCfg.Copy()

				lo_RngCfg.Copy()
				lo_RngTrg	= Me.co_WSheet.Range("C:C")
				lo_RngTrg.Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
				lo_RngCfg.Copy()
				lo_RngTrg	= Me.co_WSheet.Range("E:E")
				lo_RngTrg.Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
				Me.co_WSheet.Range("F10").Select
				'..................................................
				Dim la_Rngs()	= {"B1:B10","D1:D10","F1:F10"}
				
				lb_State	= False
				For Each lo In la_Rngs

					lo_RngCfg	= Me.co_WSheet.Range(lo)

					With lo_RngCfg

						With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
							.LineStyle	= Excel.XlLineStyle.xlContinuous
							.Weight			= Excel.XlBorderWeight.xlThin
						End With

						With .Borders(Excel.XlBordersIndex.xlEdgeRight)
							If lb_State
								.LineStyle	= Excel.XlLineStyle.xlDouble
							Else
								.LineStyle	= Excel.XlLineStyle.xlContinuous
							End If
							.Weight				= Excel.XlBorderWeight.xlThin
						End With

					End With
				
					lb_State	= Not lb_State

				Next
				'..................................................
				lo_RngCfg	= Me.co_WSheet.Range("10:10")
				lo_RngTrg	= Me.co_WSheet.Range(lo_RngCfg, lo_RngCfg.End(Microsoft.Office.Interop.Excel.XlDirection.xlDown))

				With lo_RngTrg
					.Locked					= False
					.FormulaHidden	= False
				End With
				'..................................................
				Me.co_WSheet.Range("F10").Select
				Me.co_WSheet.Application.ActiveWindow.FreezePanes = True
				'..................................................
				lo_RngCfg				= Me.co_WSheet.Range("C1")
				lo_RngCfg.Value	= " "

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub CompileWSData()

				Dim lt_Row(le_Row.Value)  As String
				Dim lt_Col                As List(Of Object) = New List(Of Object)
				Dim lb_Add                As Boolean

				For Each lo In Me.co_SessionProfile.BDCDataList

					If Not IsNothing(lo.Program_Name) AndAlso lo.Program_Name.Trim.Length > 0

						lt_Row(le_Row.PrgNme) = lo.Program_Name
						lt_Row(le_Row.DynNum) = String.Concat("'", CUShort(lo.Dynpro_Number).ToString("0000") )
						lt_Row(le_Row.DynBeg) = lo.Dynpro_Begin

					ElseIf Not IsNothing(lo.Field_Name)
						
						If lo.Field_Name.Trim.Substring(0,4).ToUpper.Equals("BDC_")

							Select Case lo.Field_Name.Trim
								Case "BDC_OKCODE" : lt_Row(le_Row.BDCOk)  = String.Concat("'", lo.Field_Value.Trim)
								Case "BDC_SUBSCR" : lt_Row(le_Row.BDCScr) = lo.Field_Value.Trim
								Case "BDC_CURSOR" : lt_Row(le_Row.BDCCur) = lo.Field_Value.Trim
							End Select

						Else

							lt_Row(le_Row.FldNme) = lo.Field_Name
							lt_Row(le_Row.Value)  = lo.Field_Value
							lt_Row(le_Row.Descr)  = lo.Field_Descr
							lb_Add  = True

						End If

					End If

					If lb_Add

						Dim lt_Ins = lt_Row.Clone()

						lt_Col.Add(lt_Ins)

						lt_Row(le_Row.DynBeg) = String.Empty
						lt_Row(le_Row.BDCOk)  = String.Empty
						lt_Row(le_Row.BDCScr) = String.Empty
						lt_Row(le_Row.BDCCur) = String.Empty

						lb_Add = False

					End If

				Next

				Me.ct_Data = New Object(9,lt_Col.Count-1){}

				For ln_Col As Integer = 0 To lt_Col.Count - 1

					lt_Row = CType(lt_Col(ln_Col), String())

					For ln_Row As Integer = 0 To le_Row.Value
						Me.ct_Data(ln_Row, ln_Col) = CType(lt_Row(ln_Row), Object)
					Next

				Next

				Me.cc_RngFmt  = String.Concat("$B$1:$", Me.co_ExcelHelper.ColumnNoToID(CUShort(lt_Col.Count+2)), "$10")
				Me.cc_RngDat  = String.Concat("$C$1:$", Me.co_ExcelHelper.ColumnNoToID(CUShort(lt_Col.Count+2)), "$10")

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub PasteData()

				Dim lo_RngData  As Excel.Range = Me.co_WSheet.Range(Me.cc_RngDat)

				lo_RngData.Value = Me.ct_Data

				lo_RngData.Columns.AutoFit()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub FormatHeader()

				Dim lo_RngCfg		As Excel.Range  = Me.co_WSheet.Range("A1:A1")
				Dim lo_RngSrce  As Excel.Range  = Me.co_WSheet.Range("A1:A10")
				Dim lo_RngFrmt  As Excel.Range  = Me.co_WSheet.Range(Me.cc_RngFmt)

				Dim lt_Text			As Object(,)

				For Each lo_Cell As Excel.Range in lo_RngSrce

					Select Case (lo_Cell.Row - 1)

							Case le_Row.PrgNme  : lo_Cell.Style = "20% - Accent1"
							Case le_Row.DynNum  : lo_Cell.Style = "20% - Accent2"
							Case le_Row.DynBeg  : lo_Cell.Style = "20% - Accent3"
							Case le_Row.BDCOk   : lo_Cell.Style = "20% - Accent4"
							Case le_Row.BDCCur  : lo_Cell.Style = "20% - Accent5"
							Case le_Row.BDCScr  : lo_Cell.Style = "20% - Accent6"
							Case le_Row.FldNme  : lo_Cell.Style = "40% - Accent1"
							Case le_Row.Descr   : lo_Cell.Style = "40% - Accent2"

							Case le_Row.SpcIns  :

								With lo_Cell
									.Style = "60% - Accent6"
									With .Borders(Excel.XlBordersIndex.xlEdgeTop)
										.LineStyle = Excel.XlLineStyle.xlDash
									End With
									With .Borders(Excel.XlBordersIndex.xlEdgeBottom)
										.LineStyle = Excel.XlLineStyle.xlDouble
									End With
								End With

							Case le_Row.Value   : lo_Cell.Style = "Note"

					End Select
					
				Next

				With lo_RngSrce
					With .Borders(Excel.XlBordersIndex.xlEdgeRight)
					.LineStyle = Excel.XlLineStyle.xlContinuous
					End With
					.Locked					= True
					.FormulaHidden	= True
				End With

				lo_RngSrce.Copy
				lo_RngFrmt.PasteSpecial( Excel.XlPasteType.xlPasteFormats )
				
				With lo_RngSrce.Offset(,1)
					With .Borders(Excel.XlBordersIndex.xlEdgeRight)
						.LineStyle = Excel.XlLineStyle.xlDouble
					End With
					.HorizontalAlignment	= Excel.XlHAlign.xlHAlignRight
					.VerticalAlignment		=	Excel.XlVAlign.xlVAlignCenter
				End With

				lt_Text = New Object(0,0){}
				lt_Text(le_Row.PrgNme,0)	= Me.cc_XMLConfig
				lo_RngCfg.Value			= lt_Text
				lo_RngCfg.WrapText	= False

				lt_Text = New Object(le_Row.Value,0){}

				lt_Text(le_Row.PrgNme,0) = "Program Name: "
				lt_Text(le_Row.DynNum,0) = "Screen Number: "
				lt_Text(le_Row.DynBeg,0) = "Screen Start: "
				lt_Text(le_Row.BDCOk,0)  = "BDC OK Code: "
				lt_Text(le_Row.BDCCur,0) = "BDC Cursor: "
				lt_Text(le_Row.BDCScr,0) = "BDC Subscreen: "
				lt_Text(le_Row.FldNme,0) = "Field Name: "
				lt_Text(le_Row.Descr,0)  = "Description: "
				lt_Text(le_Row.SpcIns,0) = "Instructions: "
				lt_Text(le_Row.Value,0)  = "X"

				lo_RngSrce.Offset(,1).Value = lt_Text
				lo_RngSrce.Columns.Offset(,1).AutoFit()
				'..................................................
				lo_RngSrce	= Me.co_WSheet.Range("B10:B10")

				With lo_RngSrce
					.HorizontalAlignment	= Excel.XlHAlign.xlHAlignCenter
					.VerticalAlignment		=	Excel.XlVAlign.xlVAlignCenter
				End With

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function CreateWSheet() As Boolean

				Dim lc_WSName As String
				Dim ln_No     As Integer
				Dim lb_Ret    As Boolean  = False

				If Not IsNothing(Me.co_SessionProfile.SessionName)
					lc_WSName = Me.co_SessionProfile.SessionName.Trim
				ElseIf Not IsNothing(Me.co_SessionProfile.SAPTCode)
					lc_WSName = Me.co_SessionProfile.SAPTCode.Trim
				Else
					lc_WSName = My.Application.Info.ProductName
				End If

				Do

					Try
							Dim lo_WS = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets(lc_WSName)
							lc_WSName = String.Concat(Me.co_SessionProfile.SessionName.Trim, "_", ln_No.ToString("00"))
							ln_No += 1
						Catch ex As Exception
							Exit Do
					End Try

				Loop

				Try
						Me.co_WSheet      = CType(Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Add(), Excel.Worksheet)
						Me.co_WSheet.Name = lc_WSName
						lb_Ret = True

				Catch ex As Exception

				End Try

				Return lb_Ret

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(	ByRef i_ExcelHelper     As iExcelHelper,
											ByRef i_ExcelAddrHndlr  As iExcelAddress,
											ByVal i_SessionProfile	As iBxSBDCSession_Profile,
											ByVal i_XMLConfig				As String)

				Me.co_ExcelHelper     = i_ExcelHelper
				Me.co_ExcelAddrHndlr  = i_ExcelAddrHndlr
				Me.co_SessionProfile	= i_SessionProfile
				Me.cc_XMLConfig				= i_XMLConfig

			End Sub

		#End Region

	End Class
