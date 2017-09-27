Imports System.Threading
Imports System.Threading.Tasks
'================================================

Imports Microsoft.Office.Interop.Excel




'form process-data-line using lc_post.

'  data: lc_doifchek(01) type c.
'  data: lc_linemode(10) type c.
'  data: lc_headmode(10) type c.
'  data: lc_subscrip(04) type c.
'  data: ln_subscrip(02) type n.
'  data: lc_oldsubsc(40) type c.
'  data: ln_subscpos     type i.

'  data: lt_instructions                     type  table of string.
'  data: lc_instruction                      type  string.
'  data: lc_docontinue(001)                  type  c.


'  loop at gs_coldata.

'    if gs_coldata-specialinstr is initial and sy-tabix = 1.
'      lc_post = 'X'.
'    endif.

'    lc_doifchek = ' '.

'    read table gs_linedata index gs_coldata-columnno.
'    check sy-subrc eq 0.


'*   cater for multiple special instructions

'    clear: lc_docontinue.

'    split gs_coldata-specialinstr
'      at ';'
'        into table lt_instructions.


'    loop at lt_instructions into lc_instruction.

'      case lc_instruction+00(02).

'        when '@@'.


'          case lc_instruction.


'            when '@@MODE'.
'              lc_linemode = gs_linedata-fieldvalue.
'              lc_docontinue = 'X'.
'              continue.

''''            when '@@INDX'.
''''              clear: lc_subscrip.
''''              condense gs_linedata-fieldvalue.
''''              move     gs_linedata-fieldvalue to   ln_subscrip.
''''              if ln_subscrip > 0.
''''                concatenate '(' ln_subscrip ')' into lc_subscrip.
''''              endif.
''''              lc_docontinue = 'X'.
''''              continue.

''''            when '@@SUBF'.
''''              if not lc_subscrip is initial.
''''                search gs_coldata-fieldname for '('.
''''                if sy-subrc eq 0.
''''                  condense gs_coldata-fieldname no-gaps.
''''                  ln_subscpos = strlen( gs_coldata-fieldname ) - 4.
''''                  lc_oldsubsc = gs_coldata-fieldname+00(ln_subscpos).
''''                  concatenate lc_oldsubsc lc_subscrip
''''                         into gs_coldata-fieldname.
''''                endif.
''''              endif.

''''            when '@@SUBC'.
''''              if not lc_subscrip is initial.
''''                search gs_coldata-bdc_cursor for '('.
''''                if sy-subrc eq 0.
''''                  condense gs_coldata-bdc_cursor no-gaps.
''''                  ln_subscpos = strlen( gs_coldata-bdc_cursor ) - 4.
''''                  lc_oldsubsc = gs_coldata-bdc_cursor+00(ln_subscpos).
''''                  concatenate lc_oldsubsc lc_subscrip
''''                         into gs_coldata-bdc_cursor.
''''                endif.
''''              endif.

'            when '@@EXEC'.
'              if gs_linedata-fieldvalue ne '@@EXEC'.
'                lc_docontinue = 'X'.
'                continue.
'              else.
'                clear: gs_linedata-fieldvalue.
'              endif.

'            when '@@POST'.
'              if gs_linedata-fieldvalue eq '@@POST'.
'                lc_post = 'X'.
'              endif.
'              lc_docontinue = 'X'.
'              continue.

''''            when '@@DOIF'.
''''              lc_doifchek = 'X'.

'          endcase.

'        when '@<'.
'          lc_headmode = gs_coldata-specialinstr.
'          lc_docontinue = 'X'.
'          continue.

'      endcase.

'    endloop.

'    check lc_docontinue is initial.


'    if lc_linemode is not initial.
'      check lc_headmode = lc_linemode.
'    endif.

''''    if lc_doifchek = 'X'.
''''      if gs_linedata-fieldvalue is initial.
''''        continue.
''''      endif.
''''    endif.

''''    if not gs_coldata-screenstart is initial.
''''      perform bdc_dynpro using gs_coldata-programname
''''                               gs_coldata-screenno.
''''    endif.
''''    if not gs_coldata-bdc_okcode is initial.
''''      perform bdc_field using 'BDC_OKCODE'
''''                              gs_coldata-bdc_okcode.
''''    endif.
''''    if not gs_coldata-bdc_cursor is initial.
''''      perform bdc_field using 'BDC_CURSOR'
''''                              gs_coldata-bdc_cursor.
''''    endif.
''''    if not gs_coldata-bdc_subscreen is initial.
''''      perform bdc_field using 'BDC_SUBSCR'
''''                              gs_coldata-bdc_subscreen.
''''    endif.

''''    if gs_linedata-fieldvalue ne '@@'.

''''      if gs_linedata-fieldvalue eq '@@[]'.
''''        clear: gs_linedata-fieldvalue.
''''      endif.

''''      perform bdc_field using gs_coldata-fieldname
''''                              gs_linedata-fieldvalue.
''''    endif.

'  endloop.

'endform.                    "process-data-line



Public Class DataCollector
  Implements iDataCollector

  Public Function GetRange() As Range Implements iDataCollector.GetRange

    Dim lo_worksheet As Excel.Worksheet = CType(Globals.ThisAddIn.Application.ActiveSheet, Excel.Worksheet)

    Dim lo_rngu As String = lo_worksheet.UsedRange().Address

    Dim lo_rng As Range = lo_worksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing)

    lo_rng.Activate()



    Return lo_rng

  End Function


Public Class Ref(Of T)
	Public Sub New()
	End Sub
	Public Sub New(value__1 As T)
		Value = value__1
	End Sub

  Public Property Value() As T
		Get
			Return m_Value
		End Get
		Set
			m_Value = Value
		End Set
	End Property
	Private m_Value As T

	Public Overrides Function ToString() As String
		Dim value__1 As T = Value
		Return If(value__1 Is Nothing, "", value__1.ToString())
	End Function
	Public Shared Widening Operator CType(r As Ref(Of T)) As T
		Return r.Value
	End Operator
	Public Shared Widening Operator CType(value As T) As Ref(Of T)
		Return New Ref(Of T)(value)
	End Operator
End Class



'Private Async Sub btnFilesStats_Click(sender As Object, e As EventArgs)
'	Dim count = New Ref(Of iWSHeader)()
'	Dim size  = New Ref(Of ULong)()
'	'Await GetFileStats(tbPath.Text, count, size)
'	'txtFileStats.Text = String.Format("{0} files ({1} bytes)", count, size)
'End Sub

'Private Async Function GetFileStats(path As String, totalCount As Ref(Of Integer), totalSize As Ref(Of ULong)) As Task
'	'Dim folder = Await StorageFolder.GetFolderFromPathAsync(path)
'	'For Each f As var In Await folder.GetFilesAsync()
'	'	totalCount.Value += 1
'	'	Dim props = Await f.GetBasicPropertiesAsync()
'	'	totalSize.Value += props.Size
'	'Next
'	'For Each f As var In Await folder.GetFoldersAsync()
'	'	Await GetFilesCountAndSize(f, totalCount, totalSize)
'	'Next
'End Function




  Sub xx

    Dim lo_Tasks = New List(Of Task(Of Integer))()

    'Dim lo_Cont As Action(Of Task) = Sub(x As Integer)
    '                                    Dim y = x + 1
    '                                 End Sub


    'For Each t As Task(Of Integer) In lo_Tasks

    '  't.ContinueWith(lo_Cont)
  
    'Next

'      t.ContinueWith(Function(completed) 
'	Select Case completed.Status
'		Case TaskStatus.RanToCompletion
'			Process(completed.Result)
'			Exit Select
'		Case TaskStatus.Faulted
'			Handle(completed.Exception.InnerException)
'			Exit Select
'	End Select

'End Function, TaskScheduler.[Default])
'Next

  End Sub


  Function MyFunc(t As Integer) As Integer
    Return 1
  End Function



'Dim tasks As IEnumerable(Of Task(Of T)) = New List(Of Task) () {Task.Delay(3000).ContinueWith(Function() 3), Task.Delay(1000).ContinueWith(Function(_) 1), Task.Delay(2000).ContinueWith(Function(_) 2), Task.Delay(5000).ContinueWith(Function(_) 5), Task.Delay(4000).ContinueWith(Function(_) 4)}

'  For Each bucket As var In Interleaved(tasks)
'	Dim t = Await bucket
'	Dim result As Integer = Await t
'	Console.WriteLine("{0}: {1}", DateTime.Now, result)
'Next


  'Public Shared Function Interleaved(Of T)(tasks As IEnumerable(Of Task(Of T))) As Task(Of Task(Of T))()
  '  Dim inputTasks = tasks.ToList()

  '  Dim buckets = New TaskCompletionSource(Of Task(Of T))(inputTasks.Count - 1) {}
  '  Dim results = New Task(Of Task(Of T))(buckets.Length - 1) {}
  '  For i As Integer = 0 To buckets.Length - 1
  '    buckets(i) = New TaskCompletionSource(Of Task(Of T))()
  '    results(i) = buckets(i).Task
  '  Next

  '  Dim nextTaskIndex As Integer = -1
  '  Dim continuation As Action(Of Task(Of T)) = Function(completed As task(Of t))
  '                                                Dim bucket = buckets(Interlocked.Increment(nextTaskIndex))
  '                                                bucket.TrySetResult(completed)

  '                                              End Function

  '  For Each inputTask As var In inputTasks
  '    inputTask.ContinueWith(continuation, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.[Default])
  '  Next

  '  Return results
  'End Function



End Class




