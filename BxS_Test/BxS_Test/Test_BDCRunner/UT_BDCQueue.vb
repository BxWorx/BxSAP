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
Public Class UT_BDCQueue

	Private testContextInstance As TestContext

	Private	Shared	co_BxSDestCntlr		As BxSNCO.iBxSDestinationController
	'Private	Shared	co_BxSDestHelper	As BxSNCO.iBxSDestinationHelper
	Private	Shared	co_Dest						As SAPNCO.RfcCustomDestination

	Private	ct_Res			As ConcurrentQueue(Of iBxS_BDCTran_Task)

	Private	co_BDCDest	As iBxS_BDCTran_Destination
	Private	co_CTU			As iBxS_BDC_CTUParameters
	Private	co_Prg			As IProgress(Of iBxS_BDCTran_Task)

	Private	co_PrgHndlr	As Action(Of iBxS_BDCTran_Task)
	Private	co_Queue		As iBxS_BDCRun_Queue

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

			Me.co_BDCDest		= New BxS_BDCTran_Destination(co_Dest)
			Me.co_CTU				= New BxS_BDC_CTUParameters
			Me.co_PrgHndlr	= AddressOf Me.ProgressHandler
			Me.co_Prg				= New Progress(Of iBxS_BDCTran_Task)(co_PrgHndlr)

			Me.co_Queue			= New BxS_BDCRun_Queue(	bdcDestination:=	Me.co_BDCDest,
																							ctuParameters:=		Me.co_CTU,
																							progress:=				Me.co_Prg)

			Me.ct_Res				= New ConcurrentQueue(Of iBxS_BDCTran_Task)

		End Sub
	'
	' Use TestCleanup to run code after each test has run
	' <TestCleanup()> Public Sub MyTestCleanup()
	' End Sub
	'
#End Region

	<TestMethod()>
		Public Async Function UT_BDCQueue_WithBDCData() As Task

			
			Dim ln_Cnt	As Integer

			'Me.co_CTU.DisMode	= "A"

			Me.co_Queue.Post(Me.Producer(30,True))

			Me.co_Queue.Complete()

			ln_Cnt = Await Me.co_Queue.StartConsumers(3)

			Thread.Sleep(200)

			Assert.AreEqual(ln_Cnt, Me.ct_Res.Count)

			Me.WriteResults()


		End Function

	'<ExpectedException(GetType(DivideByZeroException))>
	<TestMethod()>
		Public Async Function UT_BDCQueue_NoBDCData() As Task

			Dim ln_Cnt	As Integer

			Me.co_Queue.Post(Me.Producer(100,False))

			Me.co_Queue.Complete()

			ln_Cnt = Await Me.co_Queue.StartConsumers(5)

			Thread.Sleep(200)

			Assert.AreEqual(ln_Cnt, Me.ct_Res.Count)

			Me.WriteResults()

		End Function


		Private Function Producer(ByVal howmany As UInteger, Optional ByVal withdata As Boolean = False) _
											As List(Of iBxS_BDCTran_Task)

			Dim lt_List	As List(Of iBxS_BDCTran_Task)	= New List(Of iBxS_BDCTran_Task)

			For ln_Loop As UInteger = 1 To howmany

				Dim lo_BDCTask	As iBxS_BDCTran_Task	= New BxS_BDCTran_Task("Excelpath",	"GUID", ln_Loop)

				If withdata

						Dim lo_BDCEntry As iBxS_BDC_Entry
						Dim lc_str			As String
						Dim lc_No				As String

						lc_str	= String.Format("DBP: {0}", ln_Loop.ToString)

						Select Case CInt(ln_Loop)

							Case 01,16:	lc_No = "0001352100"
							Case 02,17:	lc_No = "0001352101"
							Case 03,18:	lc_No = "0001352107"
							Case 04,19:	lc_No = "0001352108"
							Case 05,20:	lc_No = "0001352109"
							Case 06,21:	lc_No = "0001352110"
							Case 07,22:	lc_No = "0001352111"
							Case 08,23:	lc_No = "0001352112"
							Case 09,24:	lc_No = "0001352113"
							Case 10,25:	lc_No = "0001352114"
							Case 11,26:	lc_No = "0001352115"
							Case 12,27:	lc_No = "0001352116"
							Case 13,28:	lc_No = "0001352119"
							Case 14,29:	lc_No = "0001352120"
							Case 15,30:	lc_No = "0001352121"

							Case Else:	lc_No = "0001352123"

						End Select

						lo_BDCTask.SAPTCode	= "VA02"

						lo_BDCEntry	= New BxS_BDC_Entry
						lo_BDCEntry.Program_Name = "SAPMV45A"
						lo_BDCEntry.Dynpro_Number = "0102"
						lo_BDCEntry.Dynpro_Begin = "X"
						lo_BDCTask.BDC_Data.Add(lo_BDCEntry)

						lo_BDCEntry = New BxS_BDC_Entry
						lo_BDCEntry.Field_Name = "VBAK-VBELN"
						lo_BDCEntry.Field_Value = lc_No
						lo_BDCTask.BDC_Data.Add(lo_BDCEntry)

						lo_BDCEntry = New BxS_BDC_Entry
						lo_BDCEntry.Field_Name = "BDC_OKCODE"
						lo_BDCEntry.Field_Value = "/00"
						lo_BDCTask.BDC_Data.Add(lo_BDCEntry)

						lo_BDCEntry = New BxS_BDC_Entry
						lo_BDCEntry.Program_Name = "SAPMV45A"
						lo_BDCEntry.Dynpro_Number = "4001"
						lo_BDCEntry.Dynpro_Begin = "X"
						lo_BDCTask.BDC_Data.Add(lo_BDCEntry)

						lo_BDCEntry = New BxS_BDC_Entry
						lo_BDCEntry.Field_Name = "VBKD-BSTKD"
						lo_BDCEntry.Field_Value = lc_str
						lo_BDCTask.BDC_Data.Add(lo_BDCEntry)

						lo_BDCEntry = New BxS_BDC_Entry
						lo_BDCEntry.Field_Name = "BDC_OKCODE"
						lo_BDCEntry.Field_Value = "SICH"
						lo_BDCTask.BDC_Data.Add(lo_BDCEntry)

				End If

				lt_List.Add(lo_BDCTask)

			Next

			Return lt_List

		End Function


		Private Sub ProgressHandler(ByVal bdcTask As iBxS_BDCTran_Task)

			Me.ct_Res.Enqueue(bdcTask)

		End Sub

		Private Sub WriteResults()

			For Each bdcTask In Me.co_Queue.CompletedResults

				TestContext.WriteLine(	String.Format("Con GUID:{0} / Trn GUID:{1} / Task ID:{2} / Thread:{3}", Strings.Right( bdcTask.info_GUIDCons.ToString, 4 ), 
																																																				Strings.Right( bdcTask.Info_GUIDTran.ToString, 4 ), 
																																																				bdcTask.ExcelRow.ToString, 
																																																				bdcTask.Info_Thread.ToString) )

				For Each lo_Msg In bdcTask.BDC_Msgs

					TestContext.WriteLine(String.Format("ID:{0} No:{1} Txt:{6} V1-4:[{2}]/[{3}]/[{4}]/[{5}]", _
																							lo_Msg.MessageId, 
																							lo_Msg.MessageNo, 
																							lo_Msg.MessageV1, 
																							lo_Msg.MessageV2, 
																							lo_Msg.MessageV3, 
																							lo_Msg.MessageV4, 
																							lo_Msg.LongText))

				Next

			Next

	End Sub

End Class
