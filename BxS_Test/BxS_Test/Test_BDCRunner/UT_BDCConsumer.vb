Imports SAPNCO	= SAP.Middleware.Connector
Imports BxSNCO	= BxS.API.Destination
Imports						BxS.API.SAPFunctions.Helpers

Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Collections.Concurrent
Imports System.Threading
Imports BxS.API.SAPFunctions.BDCTransaction
Imports BxS.API.SAPFunctions.BDCRunner
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
<TestClass()>
Public Class UT_BDCConsumer

	Private testContextInstance As TestContext

	Private	Shared	co_BxSDestCntlr		As BxSNCO.iBxSDestinationController
	'Private	Shared	co_BxSDestHelper	As BxSNCO.iBxSDestinationHelper
	Private	Shared	co_Dest						As SAPNCO.RfcCustomDestination

	Private cn_cnt	As Integer
	Private	ct_Res	As ConcurrentQueue(Of iBxS_BDCTran_Task)

	Private	co_Q				As BlockingCollection(Of iBxS_BDCTran_Task)
	Private	co_CTS			As CancellationTokenSource
	Private	co_Prg			As IProgress(Of iBxS_BDCTran_Task)

	Private	co_BDCDest	As iBxS_BDCTran_Destination
	Private	co_CTU			As iBxS_BDC_CTUParameters
	Private	co_BDCTran	As iBxS_BDCTran_Caller
	Private	co_Cons			As iBxS_BDCRun_Consumer

	Private	co_PrgHndlr	As Action(Of iBxS_BDCTran_Task)

	'''<summary>
	'''Gets or sets the test context which provides
	'''information about and functionality for the current test run.
	'''</summary>
	Public Property TestContext() As TestContext
		Get
			Return testContextInstance
		End Get
		Set(ByVal value As TestContext)
			testContextInstance = Value
		End Set
	End Property

#Region "Additional test attributes"
	'
	' You can use the following additional attributes as you write your tests:
	'
	' Use ClassInitialize to run code before running the first test in the class
	<ClassInitialize()> _
		Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)

			Dim lc_DestID		As String

			co_BxSDestCntlr		= BxSNCO.BxSDestinationController.GetInstance()
			'co_BxSDestHelper	= BxSNCO.BxSDestinationHelper.GetInstance()

			lc_DestID	= Array.Find(co_BxSDestCntlr.Create_SAPIni_DestinationConfig().GetEntries(), Function(key) key.Contains("00.96") )
			co_Dest		= co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="500", user:="DERRICKBINGH", password:="M@@n0987")

			'lc_DestID	= Array.Find(co_BxSDestHelper.GetDestConfiguration(preloadSAPini:=True).GetEntries(), Function(key) key.Contains("05.01") )
			'co_Dest		= co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="100", user:="DERRICKB", password:="moon123", useSAPGUI:=False)

		End Sub
	'
	' Use ClassCleanup to run code after all tests in a class have run
	' <ClassCleanup()> Public Shared Sub MyClassCleanup()
	' End Sub
	'
	' Use TestInitialize to run code before running each test
	<TestInitialize()> _
		Public Sub MyTestInitialize()

			Me.ct_Res				= New ConcurrentQueue(Of iBxS_BDCTran_Task)

			Me.co_Q					= New BlockingCollection(Of iBxS_BDCTran_Task)
			Me.co_CTS				= New CancellationTokenSource
			Me.co_Prg				= New Progress(Of iBxS_BDCTran_Task)

			Me.co_BDCDest		= New BxS_BDCTran_Destination(co_Dest)
			Me.co_CTU				= New BxS_BDC_CTUParameters
			Me.co_BDCTran		= New BxS_BDCTran_Caller(Me.co_BDCDest,co_CTU)

			Me.co_PrgHndlr	= AddressOf Me.ProgressHandler
			Me.co_Prg				= New Progress(Of iBxS_BDCTran_Task)(co_PrgHndlr)

			Me.co_Cons			= New BxS_BDCRun_Consumer(Me.co_Q, Me.co_Prg, Me.co_CTS.Token, Me.co_BDCTran)

		End Sub
	'
	' Use TestCleanup to run code after each test has run
	' <TestCleanup()> Public Sub MyTestCleanup()
	' End Sub
	'
#End Region

	<TestMethod()>
		Public Async Function UT_BDCConsumer_WithBDCData() As Task

			Dim ln_Cnt	As Integer

			'Me.co_CTU.DisMode	= "A"

			Me.Producer(10,True)

			

			ln_Cnt = Await Me.co_Cons.StartAsync()

			Thread.Sleep(200)

			Assert.AreEqual(ln_Cnt, Me.ct_Res.Count)

		End Function

	'<ExpectedException(GetType(DivideByZeroException))>
	<TestMethod()>
		Public Async Function UT_BDCConsumer_NoBDCData() As Task

			Dim ln_Cnt	As Integer

			Me.Producer(10)

			ln_Cnt = Await Me.co_Cons.StartAsync()

			Thread.Sleep(200)

			Assert.AreEqual(ln_Cnt, Me.ct_Res.Count)

		End Function


		Private Sub Producer(ByVal howmany As Integer, Optional ByVal withdata As Boolean = False)

			For ln_Loop As Integer = 1 To howmany

				Dim lo_Task			As iBxS_BDCTran_Task
				Dim lo_BDCEntry	As iBxS_BDC_Entry

				If withdata

					lo_Task	= New BxS_BDCTran_Task("","",CUInt(ln_Loop))

					lo_Task.SAPTCode	= "VA02"

					lo_BDCEntry	= New BxS_BDC_Entry
					lo_BDCEntry.Program_Name	= "SAPMV45A"
					lo_BDCEntry.Dynpro_Number = "0102"
					lo_BDCEntry.Dynpro_Begin	= "X"
					lo_Task.BDC_Data.Add(lo_BDCEntry)

					lo_BDCEntry	= New BxS_BDC_Entry
					lo_BDCEntry.Field_Name		= "VBAK-VBELN"
					lo_BDCEntry.Field_Value		= "0001352123"
					lo_Task.BDC_Data.Add(lo_BDCEntry)

					lo_BDCEntry	= New BxS_BDC_Entry
					lo_BDCEntry.Field_Name		= "BDC_OKCODE"
					lo_BDCEntry.Field_Value		= "/00"
					lo_Task.BDC_Data.Add(lo_BDCEntry)

					lo_BDCEntry	= New BxS_BDC_Entry
					lo_BDCEntry.Program_Name	= "SAPMV45A"
					lo_BDCEntry.Dynpro_Number = "4001"
					lo_BDCEntry.Dynpro_Begin	= "X"
					lo_Task.BDC_Data.Add(lo_BDCEntry)

					lo_BDCEntry	= New BxS_BDC_Entry
					lo_BDCEntry.Field_Name		= "BDC_OKCODE"
					lo_BDCEntry.Field_Value		= "/12"
					lo_Task.BDC_Data.Add(lo_BDCEntry)

				Else
					lo_Task	= New BxS_BDCTran_Task("","",CUInt(ln_Loop))
				End If

				Me.co_Q.Add(lo_Task, Me.co_CTS.Token)

			Next

			Me.co_Q.CompleteAdding()

		End Sub


		Private Sub ProgressHandler(ByVal bdcTask As iBxS_BDCTran_Task)

			Me.ct_Res.Enqueue(bdcTask)

			TestContext.WriteLine(String.Format("ID:{0} Thread: {1}", bdcTask.ExcelRow.ToString, bdcTask.Info_Thread.ToString))

			For Each lo_Msg In bdcTask.BDC_Msgs

				TestContext.WriteLine(String.Format("Msg ID:{0} Msg No:{1} Msg P1:{2}{3}{4}{5}", _
																						lo_Msg.MessageId, lo_Msg.MessageNo, lo_Msg.MessageV1, lo_Msg.MessageV2, lo_Msg.MessageV3, lo_Msg.MessageV4, lo_Msg.LongText))

			Next

		End Sub

End Class
