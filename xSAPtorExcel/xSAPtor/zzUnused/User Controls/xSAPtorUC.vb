Imports System.Threading
Imports xSAPtorExcel.Services.UI
Imports xSAPtorExcel.Services.Excel
'================================================
Friend Class xSAPtorUC

  'Dim co_PayLoad      As iPayload
  Dim co_ExcelHelper  As iExcelHelper
  Dim co_cts          As CancellationTokenSource

  Private cb_xBtnEnable_Start   As Boolean
  Private cb_xBtnEnable_Cancel  As Boolean

  Private co_xBtnHndlr_Start    As xBtnDelegate_Start     = AddressOf Me.xBtnHandler_Start
  Private co_xBtnHndlr_Cancel   As xBtnDelegate_Cancel    = AddressOf Me.xBtnHandler_Cancel

  Private co_progressHandler    As Action(Of iPBarData)     = AddressOf Me.xPBarHandler
  Private co_Progress           As IProgress(Of iPBarData)  = New Progress(Of iPBarData)(me.co_progressHandler)
  '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Private Delegate Sub xBtnDelegate_Start
  Private Delegate Sub xBtnDelegate_Cancel
  '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

    Me.xBtnSet(i_CancelBias:=False)

    'Me.co_PayLoad     = New PayLoad
    Me.co_ExcelHelper = ExcelHelper.GetInstance()

  End Sub
  '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Private Sub xBtn_Cancel_Click(sender As Object, e As EventArgs) Handles xBtn_Cancel.Click

    If Not IsNothing(Me.co_cts)
      Me.co_cts.Cancel()
    End If

  End Sub
  '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Private  Sub xBtn_Process_Click(sender As Object, e As EventArgs) Handles xBtn_Start.Click
    
		'Async

    If Me.co_ExcelHelper.IsInEditMode
      Return
    End If

    Me.xBtnSet(i_CancelBias:=True)

    Me.co_cts = New CancellationTokenSource
    Me.xPB_Progress.Value = 0

    Try

			'PAYLOAD REMOVED, look under BDC processing

      'Dim lb_ok As Boolean = Await Me.co_PayLoad.ProcessAsync(i_Progress:= Me.co_Progress,
      '                                                        i_ct      := Me.co_cts.Token,
      '                                                        i_WBookID := Me.co_ExcelHelper.GetActiveWBookName(),
      '                                                        i_WSIndex := CUShort(Me.co_ExcelHelper.GetActiveWSIndex())
      '                                                        )

    Catch ex As Exception
      Dim x = 1
    End Try

    Me.co_cts = Nothing
    Me.xBtnSet(i_CancelBias:=False)

  End Sub
  '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Private Sub xBtnSet(ByRef i_CancelBias As Boolean)

    If i_CancelBias
      Me.cb_xBtnEnable_Start = False
      Me.cb_xBtnEnable_Cancel = True
    Else
      Me.cb_xBtnEnable_Start = True
      Me.cb_xBtnEnable_Cancel = False
    End If

    Me.xBtnHandler_Start()
    Me.xBtnHandler_Cancel()

  End Sub
  '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Private Sub xBtnHandler_Start()

    If Me.xBtn_Start.InvokeRequired
      Me.Invoke(Me.co_xBtnHndlr_Start)
    Else
      Me.xBtn_Start.Enabled = Me.cb_xBtnEnable_Start
    End If

  End Sub
  '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Private Sub xBtnHandler_Cancel()

    If Me.xBtn_Cancel.InvokeRequired
      Me.Invoke(Me.co_xBtnHndlr_Cancel)
    Else
      Me.xBtn_Cancel.Enabled = Me.cb_xBtnEnable_Cancel
    End If

  End Sub
  '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Private Sub xPBarHandler(ByVal i_UIData As iPBarData)

    If Me.xPB_Progress.InvokeRequired
      Me.Invoke(me.co_progressHandler, New Object() {i_UIData})
    Else
      If i_UIData.Complete = 0 Or i_UIData.Total = 0
        Me.xPB_Progress.Value = 0
      Else
        Me.xPB_Progress.Value = CInt((i_UIData.Complete / i_UIData.Total) * 100)
      End If
    End If

  End Sub

End Class
