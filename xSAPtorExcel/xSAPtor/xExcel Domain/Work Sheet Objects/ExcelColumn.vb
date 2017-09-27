Imports System.Text.RegularExpressions
'================================================
Friend Class ExcelColumn
							Implements iExcelColumn

	#Region "Propeties"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cn_ColumnNo As Integer
		Friend ReadOnly Property Column_No            As Integer  Implements iExcelColumn.Column_No
			Get
				Return Me.cn_ColumnNo
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cc_ProgramName  As String
		Friend ReadOnly Property Program_Name         As String   Implements iExcelColumn.Program_Name
			Get
				Return Me.cc_ProgramName
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cn_DynProNo As String
		Friend ReadOnly Property Dynpro_Number()      As String   Implements iExcelColumn.DynPro_Number
			Get
				Return Me.cn_DynProNo
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cb_DynProBegin  As String
		Friend ReadOnly Property Dynpro_Begin()       As String  Implements iExcelColumn.DynPro_Begin
			Get
				Return Me.cb_DynProBegin
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cc_OKCode As String
		Friend ReadOnly Property OKCode()             As String   Implements iExcelColumn.OKCode
			Get
				Return Me.cc_OKCode
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cc_CursorBefore As String
		Friend ReadOnly Property Cursor_Before()      As String   Implements iExcelColumn.Cursor_Before
			Get
				Return Me.cc_CursorBefore
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cc_SubScreen  As String
		Friend ReadOnly Property SubScreen()          As String   Implements iExcelColumn.Subscreen
			Get
				Return Me.cc_SubScreen
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cc_FieldName  As String
		Friend ReadOnly Property Field_Name()         As String   Implements iExcelColumn.Field_Name
			Get
				Return Me.cc_FieldName
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cc_Description  As String
		Friend ReadOnly Property Description()        As String   Implements iExcelColumn.Description
			Get
				Return Me.cc_Description
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cc_Instructions As String
		Friend ReadOnly Property Instructions()       As String   Implements iExcelColumn.Instructions
			Get
				Return Me.cc_Instructions
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private ct_Commands As New Dictionary(Of String, String)
		Friend ReadOnly Property Commands()           As Dictionary(Of String, String)  Implements iExcelColumn.Commands
			Get
				Return Me.ct_Commands
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cb_DoIf As Boolean
		Friend ReadOnly Property DoIFHasValue         As Boolean  Implements iExcelColumn.DoIFHasValue
			Get
				Return Me.cb_DoIf
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cb_DoFldIdx As Boolean
		Friend ReadOnly Property DoFieldIndex         As Boolean  Implements iExcelColumn.DoFieldIndex
			Get
				Return Me.cb_DoFldIdx
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cb_DoCsrIdx As Boolean
		Friend ReadOnly Property DoCursorIndex        As Boolean  Implements iExcelColumn.DoCursorIndex
			Get
				Return Me.cb_DoCsrIdx
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cb_FldIdxCol As Boolean
		Friend ReadOnly Property IsFieldIndexColumn   As Boolean  Implements iExcelColumn.IsFieldIndexColumn
			Get
				Return Me.cb_FldIdxCol
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cb_CsrIdxCol As Boolean
		Friend ReadOnly Property IsCursorIndexColumn  As Boolean  Implements iExcelColumn.IsCursorIndexColumn
			Get
				Return Me.cb_CsrIdxCol
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cb_Utilized As Boolean
		Friend ReadOnly Property Utilized  As Boolean  Implements iExcelColumn.Utilized
			Get
				Return Me.cb_Utilized
			End Get
		End Property

	#End Region

	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Constructor"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Sub New (ByVal i_ColData As Object() )
			
			Me.ct_Commands.Clear
			'....................................................
			Me.cn_ColumnNo      = CInt(Me.Decipher(i_ColData(xBDC_TypePool.BDC_RowType.ColumnNo)))

			Me.cb_Utilized			= False

			Me.cc_ProgramName   = Me.Decipher(i_ColData(xBDC_TypePool.BDC_RowType.ProgName))
			Me.cn_DynProNo      = Me.Decipher(i_ColData(xBDC_TypePool.BDC_RowType.DynProNo))
			Me.cc_FieldName     = Me.Decipher(i_ColData(xBDC_TypePool.BDC_RowType.FieldName))
			Me.cc_OKCode        = Me.Decipher(i_ColData(xBDC_TypePool.BDC_RowType.OKCode))
			Me.cc_CursorBefore  = Me.Decipher(i_ColData(xBDC_TypePool.BDC_RowType.Cursor))
			Me.cc_SubScreen     = Me.Decipher(i_ColData(xBDC_TypePool.BDC_RowType.SubScreen))
			Me.cc_Description   = Me.Decipher(i_ColData(xBDC_TypePool.BDC_RowType.Description))
			Me.cc_Instructions  = Me.Decipher(i_ColData(xBDC_TypePool.BDC_RowType.Instructions))

			If Me.Decipher(i_ColData(xBDC_TypePool.BDC_RowType.DynBegin)).ToUpper() = xBDC_TypePool.cz_Sub_ABAPTrue
				Me.cb_DynProBegin = xBDC_TypePool.cz_Sub_ABAPTrue
			Else
				Me.cb_DynProBegin = ""
			End If

		End Sub

	#End Region

	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Private Methods"

		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		Private Function Decipher(ByRef i_Data As Object) As String

			Dim lc_Data     As String
			Dim lt_Parts    As IEnumerable(Of String)
			Dim lt_Commands As IEnumerable(Of String)

			If IsNothing(i_Data)
				Return ""
			End If

			lc_Data = i_Data.ToString().Trim()

			If lc_Data.Length.Equals(0)
				Return ""
			ElseIf lc_Data.Contains(xBDC_TypePool.cz_Cmd_Prefix) OrElse
						 lc_Data.Contains(xBDC_TypePool.cz_Cmd_Delim)

				lt_Commands = lc_Data.Split(xBDC_TypePool.cz_Cmd_Delim).Where(Function(Cmd)
																																				Return CBool(IIf(Cmd.Trim().Length > 0, True, False))
																																			End Function)

				For Each lo_Cmd As String In lt_Commands

					If lo_Cmd.Contains(xBDC_TypePool.cz_Cmd_Prefix)

						lt_Parts = lo_Cmd.Split(xBDC_TypePool.cz_Cmd_PartDelim).Where(Function(Part)
																																						Return CBool(IIf(Part.Length.Equals(0), False, True))
																																					End Function)

						If lt_Parts.Count.Equals(0)
						Else

							Select Case lt_Parts(0).Trim().ToUpper()

								Case xBDC_TypePool.cz_Cmd_DoIf      : Me.cb_DoIf      = True
								Case xBDC_TypePool.cz_Cmd_ValFldIdx : Me.cb_FldIdxCol = True
								Case xBDC_TypePool.cz_Cmd_ValCsrIdx : Me.cb_CsrIdxCol = True

								Case xBDC_TypePool.cz_Cmd_SubFldIdx : Me.SubstituteIndex(Me.cc_FieldName,     Me.cb_DoFldIdx)
								Case xBDC_TypePool.cz_Cmd_SubCsrIdx : Me.SubstituteIndex(Me.cc_CursorBefore,  Me.cb_DoCsrIdx)

								Case Else

									If lt_Parts.Count.Equals(1)  
										Me.ct_Commands.Add(lt_Parts(0).ToUpper, "")
									Else
										Me.ct_Commands.Add(lt_Parts(0).ToUpper, lt_Parts(1))
									End If

							End Select

						End If

					Else
						lc_Data = lo_Cmd.Trim()
					End If

				Next

			End If

			Me.cb_Utilized  = True
			Return lc_Data

		End Function
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		Private Sub SubstituteIndex(ByRef i_Fld As String, ByRef i_Active As Boolean)
			If i_Fld.Contains("(") AndAlso i_Fld.Contains(")")
				i_Fld     = Regex.Replace(i_Fld, "\((.*?)\)", xBDC_TypePool.cz_Sub_Token)
				i_Active  = True
			Else
				i_Active  = False
			End If
		End Sub

	#End Region

End Class
