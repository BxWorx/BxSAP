Imports System.Threading
Imports System.Threading.Tasks
Imports xSAPtorExcel.Services.UI
'================================================
Friend Interface iPayload

  Function ProcessAsync(ByVal i_Progress  As IProgress(Of iPBarData),
                        ByVal i_ct        As CancellationToken,
                        ByVal i_WBookID   As String,
                        ByVal i_WSIndex   As UShort) As Task(Of Boolean)

End Interface
