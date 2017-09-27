Imports System.Threading
Imports System.Threading.Tasks
Imports xSAPtorExcel.Services.UI
'================================================
Friend Class PayLoad
              Implements iPayload

  Dim co_Worksheet    As iWorkSheet
  '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Friend Async Function ProcessAsync( ByVal i_Progress  As IProgress(Of iPBarData),
                                      ByVal i_ct        As CancellationToken,
                                      ByVal i_WBookID   As String,
                                      ByVal i_WSIndex   As UShort) As Task(Of Boolean) Implements iPayload.ProcessAsync

    Dim lb_Return As Boolean = False

    Me.co_Worksheet  = New xWorkSheet(i_WBName := i_WBookID,
                                     i_WSIndex:= i_WSIndex)

    If Await me.co_Worksheet.LoadAsync(i_Progress := i_Progress,
                                       i_ct       := i_ct)

      If Await Me.co_Worksheet.TransactionsAsync(i_Progress := i_Progress,
                                                 i_ct       := i_ct)
        lb_Return = True
      End If

    End If

    Return lb_Return

  End Function

End Class
