Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks
Imports xSAPtorNCO.API.Main
Imports xSAPtorNCO.API.Services.RfcFunction
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Process

  Public Class xSAPProcessController
                Implements ixSAPProcessController

    #Region "Defintions"

      Private co_NCOCntlr As Lazy(Of ixNCOController) _
                = New Lazy(Of ixNCOController)(
                    Function()  xNCOController.GetInstance(),
                                LazyThreadSafetyMode.ExecutionAndPublication )

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯

    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Methods"

      Public Async Sub Process() Implements ixSAPProcessController.Process

        If Not Me.co_NCOCntlr.Value.IsDestinationConnected()
          Return
        End If

        
        Dim lt_BDCTran  As ixNCOrfcBDCTransaction = Me.co_NCOCntlr.Value.GetCallBDCTransaction()

        Return


        Dim lo_SW     As stopwatch = New Stopwatch
        Dim ln_RetTot As Integer
        Dim ln_Loops  As Integer  = 10
        Dim ln_Wrkrs  As Integer  = 10
        Dim lo_CTS    As CancellationTokenSource  = New CancellationTokenSource

        Dim lt_Tran   As List(Of xNCOrfcAppSrvrTimestamp) = Me.co_NCOCntlr.Value.GetTmestmpfnc(ln_Wrkrs)
        Dim lo_Tasks  As List(Of Task(Of Integer))        = New List(Of Task(Of Integer))


        lo_SW.Start()

        For ln As Integer = 1 To ln_Loops

            Dim lo_Tran As xNCOrfcAppSrvrTimestamp = Me.co_NCOCntlr.Value.GetrfcTimeStampCall()  '= lt_Tran.Item(ln-1)
            Dim ln_myi  As Integer = ln

            lo_Tasks.Add(Task.Run(Of Integer)(
              Function()

                lo_Tran.Invoke(DestinationProfile:= Me.co_NCOCntlr.Value.GetConnectedDestinationProfile(),
                               CancelToken       := lo_CTS.Token)

                Return ln_myi

              End Function) )


        Next

        While lo_Tasks.Count > 0

          Dim lo_DoneTask As Task(Of Integer) = Await Task.WhenAny(lo_Tasks)

          lo_Tasks.Remove(lo_DoneTask)
          ln_RetTot += 1

        End While

        lo_SW.Stop

        Dim y = lo_SW.ElapsedMilliseconds

        If ln_Loops <> ln_RetTot
          Dim z = 1
        End If

      End Sub

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Constructor"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Friend Shared Function Create() As ixSAPProcessController
        Return New xSAPProcessController()
      End Function
      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Private Sub New()
      End Sub      

    #End Region

  End Class

End Namespace