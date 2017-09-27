Public Class Class1

End Class

    'SAP_BDC_Upload_Header_Details
    'If gb_Status Then
    '    SAP_BDC_Upload_Column_Details
    '    If gb_Status Then
    '        SAP_BDC_Upload_Data
    '    End If
    'End If
    'If Not gb_Status Then
    '    MsgBox ("**** Errors did occur during upload. Correct and Re-Do ***")
    'End If

'Sub SAP_BDC_Upload_Header_Details()
'    gb_Status = False
'    Set go_SetFunc = go_SapFunc.Add("ZZ_DTO_SESSION_HEADER")
'    go_SetFunc.exports("USERID") = gc_UserID
'    go_SetFunc.exports("GROUPID") = gc_GroupID
'    gb_Result = go_SetFunc.Call
'    If gb_Result Then
'        gd_RetStatus = go_SetFunc.Imports("STATUS")
'        If Val(gd_RetStatus) = 0 Then gb_Status = True
'    End If
'    go_SapFunc.Remove (go_SetFunc)
'    If Not gb_Status Then
'        MsgBox ("*** Error while uploading header information. Please re-do ***")
'    End If
'End Sub


'Sub SAP_BDC_Upload_Column_Details()

'    Dim SAP_DM    As Object
'    Dim DM_Row    As Variant
'    Dim lc_String As String
'    Dim ln_Rows   As Long
    
'    gb_Status = False
'    Set go_SetFunc = go_SapFunc.Add("ZZ_DTO_SESSION_COLUMNS")
'    go_SetFunc.exports("USERID") = gc_UserID
'    go_SetFunc.exports("GROUPID") = gc_GroupID
'    Set SAP_DM = go_SetFunc.tables.Item("DATALINES")
'    SAP_DM.data = ga_PostColumns
'    gb_Result = go_SetFunc.Call
'    If gb_Result Then
'        gd_RetStatus = go_SetFunc.Imports("STATUS")
'        If Val(gd_RetStatus) = 0 Then gb_Status = True
'    End If
'    go_SapFunc.Remove (go_SetFunc)
'    If Not gb_Status Then
'        MsgBox ("*** Error while uploading column information. Please re-do ***")
'    End If
    
'End Sub



'COLUMNNO	1 Types	NUMC5	NUMC	5	0	5 Character Numeric NUMC
'PROGRAMNAME	1 Types	BDC_PROG	CHAR	40	0	BDC module pool
'SCREENNO	1 Types	BDC_DYNR	NUMC	4	0	BDC Screen number
'SCREENSTART	1 Types	BDC_START	CHAR	1	0	BDC screen start
'BDC_OKCODE	1 Types	CHAR20	CHAR	20	0	Char 20
'BDC_CURSOR	1 Types	FNAM_____4	CHAR	132	0	Field name
'BDC_SUBSCREEN	1 Types	FNAM_____4	CHAR	132	0	Field name
'FIELDNAME	1 Types	FNAM_____4	CHAR	132	0	Field name
'FIELDDESC	1 Types	FNAM_____4	CHAR	132	0	Field name
'SPECIALINSTR	1 Types	CHAR20	CHAR	20	0	Char 20




'Sub SAP_BDC_Upload_Data()

'    Dim ln_RowNo     As Long
'    Dim ln_Colno     As Long
'    Dim lo_SAP_Funct As Object
'    Dim ln_StartRow  As Long
'    Dim ln_OutLoop   As Long
'    Dim ln_InLoop    As Long
'    Dim lo_SAPTab    As Object
'    Dim ln_Errors    As Long
'    Dim lc_Msg       As String
'    Dim ln_Index     As Long
'    Dim ln_LoadRows  As Long
    
'    ln_StartRow = Range("Parameters!nm_Data_Start_Row").Value
'    Set lo_SAP_Funct = go_SapFunc.Add("ZZ_DTO_SESSION_DATA")
'    Set lo_SAPTab = lo_SAP_Funct.tables.Item("DATALINES")
    
'    Worksheets("Data Sheet").Select
'    ln_Errors = 0
'    ln_LoadRows = 0
'    For ln_OutLoop = 1 To gn_NoOfRows
'        Cells(ln_StartRow, 1).Select
'        If Not IsEmpty(ActiveCell.Value) And ActiveCell.Value <> "" Then
'            For ln_InLoop = 1 To gn_NoOfCols
'                ln_Index = ln_InLoop - 1
'                ga_PostArray(ln_Index, 0) = ln_InLoop
'                ga_PostArray(ln_Index, 1) = ActiveCell.Offset(0, ln_InLoop).Value
'            Next
'            lo_SAP_Funct.exports("EXCELROW") = ln_StartRow
'            lo_SAP_Funct.exports("ROWNO") = ln_LoadRows + 1
'            lo_SAP_Funct.exports("USERID") = gc_UserID
'            lo_SAP_Funct.exports("GROUPID") = gc_GroupID
'            lo_SAPTab.data = ga_PostArray
'            gb_Result = lo_SAP_Funct.Call
'            If gb_Result Then
'                gd_RetStatus = lo_SAP_Funct.Imports("STATUS")
'                If Val(gd_RetStatus) = 0 Then
'                    Application.StatusBar = "Uploaded Row Number:" & Str(ln_OutLoop)
'                    ln_LoadRows = ln_LoadRows + 1
'                Else
'                    ln_Errors = ln_Errors + 1
'                End If
'            Else
'                ln_Errors = ln_Errors + 1
'            End If
'        End If
'        ln_StartRow = ln_StartRow + 1
'    Next
'    go_SapFunc.Remove (lo_SAP_Funct)
'    If ln_Errors <> 0 Then
'        lc_Msg = "**** " & Str(ln_Errors) & "Errors occurred during the upload ****"
'        MsgBox (lc_Msg)
'    End If
'    gb_Status = False
    
'    gc_TranCode = Range("Parameters!nm_SAP_BDCTopLeft").Offset(0, 3).Value
    
'    Set lo_SAP_Funct = go_SapFunc.Add("ZZ_DTO_SESSION_STATS")
'    lo_SAP_Funct.exports("NOOFROWS") = ln_LoadRows
'    lo_SAP_Funct.exports("TRANCODE") = gc_TranCode
'    lo_SAP_Funct.exports("USERID") = gc_UserID
'    lo_SAP_Funct.exports("GROUPID") = gc_GroupID
'    gb_Result = lo_SAP_Funct.Call
'    If gb_Result Then
'        gd_RetStatus = lo_SAP_Funct.Imports("STATUS")
'        If Val(gd_RetStatus) = 0 Then
'            gb_Status = True
'        End If
'    End If
'    go_SapFunc.Remove (lo_SAP_Funct)
'    If Not gb_Status Then
'        MsgBox ("*** Error while Updating Statistical Information. Please re-do ***")
'    End If
'End Sub


'COLUMNNO	1 Types	NUMC5	NUMC	5	0	5 Character Numeric NUMC
'FIELDVALUE	1 Types	CHAR255	CHAR	255	0	Char255



    'Set go_SetFunc = go_SapFunc.Add("ZZ_DTO_SESSION_RETURN")
    'go_SetFunc.exports("USERID") = gc_UserID
    'go_SetFunc.exports("GROUPID") = gc_GroupID
    'gb_Result = go_SetFunc.Call
    'If gb_Result Then
    '    gd_RetStatus = go_SetFunc.Imports("STATUS")
    '    If Val(gd_RetStatus) = 0 Then
    '        Set SAP_DM = go_SetFunc.tables.Item("DATALINE")
    '        Worksheets("Data Sheet").Select
    '        For Each DM_Row In SAP_DM.Rows
    '            ln_Row = Val(DM_Row("EXCELROW"))
    '            lc_String = DM_Row("MESSAGE")
    '            Cells(ln_Row, gn_NoOfCols + 2).Value = "'" & lc_String
    '        Next
    '        Set SAP_DM = Nothing
    '    End If
    'End If
    'go_SapFunc.Remove (go_SetFunc)

'*"----------------------------------------------------------------------
'*"*"Local Interface:
'*"  IMPORTING
'*"     VALUE(USERID) TYPE  APQI-USERID OPTIONAL
'*"     VALUE(GROUPID) TYPE  APQI-GROUPID OPTIONAL
'*"  EXPORTING
'*"     VALUE(STATUS) TYPE  APQI-QATTRIB
'*"  TABLES
'*"      DATALINE STRUCTURE  ZZDTO_ROWSRET OPTIONAL


'ROWNO	1 Types	NUMC5	NUMC	5	0	5 Character Numeric NUMC
'STATUS	1 Types	CHAR2	CHAR	2	0	Version Number Component
'MESSAGE	1 Types	CHAR255	CHAR	255	0	Char255
'EXCELROW	1 Types	NUMC5	NUMC	5	0	5 Character Numeric NUMC
'MESSDATE	1 Types	DATUM	DATS	8	0	Date
'MESSTIME	1 Types	UZEIT	TIMS	6	0	Time
