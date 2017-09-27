Imports BxS.API.Destination
Imports BxS.API.Main
Imports BxS.API.BDC
Imports BxS.API.SAPFunctions.MsgComposer
Imports	BxS.API.SAPFunctions.BDCTransaction

Imports System.Threading

Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
<TestClass()>
Public Class UT_SAPFnc_MsgComposer

	Private testContextInstance As TestContext

	Private co_NCOCntlr	As ixNCOController
	Private	Co_Dest			As iBxSDestination
	Private cc_DestID		As String

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
	' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
	' End Sub
	'
	' Use ClassCleanup to run code after all tests in a class have run
	' <ClassCleanup()> Public Shared Sub MyClassCleanup()
	' End Sub
	'
	' Use TestInitialize to run code before running each test
	<TestInitialize()>
		Public Sub MyTestInitialize()

			Me.co_NCOCntlr	= xNCOController.NCOController()
			Me.co_NCOCntlr.Configure_for_SAPIni()

			Me.cc_DestID	= Me.co_NCOCntlr.GetDestinationList().Find( Function(key) key.Contains("00.96") )
			Me.Co_Dest		= Me.co_NCOCntlr.GetDestination(Me.cc_DestID)

			Me.Co_Dest.Configure("500", "DERRICKBINGH", "M@@n0987")

		End Sub

	'
	' Use TestCleanup to run code after each test has run
	<TestCleanup()>
		Public Sub MyTestCleanup()

			Me.co_NCOCntlr.Finalise()
			
		End Sub
	'
#End Region

	<TestMethod()>
		Public Async Function UT_SAPFnc_MsgComBasic() As Task

			Dim lo_MsgCom	As iBxS_SAPMsgComposer	= Me.co_NCOCntlr.GetMsgComposer(Me.cc_DestID)
			Dim lo_MsgDTO	As iBxS_BDCTran_Msg			= New BxS_BDCTran_Msg

			lo_MsgDTO.MessageId	= "/ISDFPS/MISC"
			lo_MsgDTO.MessageNo	= "002"
			lo_MsgDTO.MessageV1	= "XXXX"

			Dim x = Await lo_MsgCom.GetMsgAsync(lo_MsgDTO)
		
			'Thread.Sleep(200)

			Assert.IsNotNull(x)
			
		
		' TODO: Add test logic here
		End Function

End Class
