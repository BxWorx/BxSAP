Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports SAPNCO	= SAP.Middleware.Connector
Imports BxSNCO	= BxS.API.Destination
Imports BxSFNC	= BxS.API.SAPFunctions.Servertime
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
<TestClass()>
Public Class UT_SAPFnc

	Private testContextInstance		As TestContext

	Private Shared	co_BxSDestCntlr	As BxSNCO.iBxSDestinationController
	Private					co_Dest					As SAPNCO.RfcCustomDestination

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

			co_BxSDestCntlr	= BxSNCO.BxSDestinationController.GetInstance()

		End Sub
	'
	' Use ClassCleanup to run code after all tests in a class have run
	' <ClassCleanup()> Public Shared Sub MyClassCleanup()
	' End Sub
	'
	' Use TestInitialize to run code before running each test
	<TestInitialize()> _
		Public Sub MyTestInitialize()

			Dim lc_DestID		As String

			lc_DestID		= Array.Find(co_BxSDestCntlr.Create_SAPIni_DestinationConfig().GetEntries(), Function(key) key.Contains("00.96") )
			Me.co_Dest	= co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="500", user:="DERRICKBINGH", password:="M@@n0987")

		End Sub
	'
	' Use TestCleanup to run code after each test has run
	' <TestCleanup()> Public Sub MyTestCleanup()
	' End Sub
	'
#End Region

	<TestMethod()>
		Public Sub UT_SAPFnc_ServerTime()

			Dim lo_SrvTme	As BxSFNC.iBxS_SAPServerTime
			Dim lc_dte1		As DateTime
			Dim lc_dte2		As DateTime

			lo_SrvTme	= New BxSFNC.BxS_SAPServerTime(destination:=Me.co_Dest)
			lc_dte1		= lo_SrvTme.ServerTime
			lc_dte2		= lo_SrvTme.ServerTime

			Dim lc1 As String = lc_dte1.ToString("MM/dd/yyyy HH:mm:ss.fff")
			Dim lc2 As String = lc_dte2.ToString("MM/dd/yyyy hh:mm:ss.fff tt")

			lo_SrvTme	= Nothing

		End Sub

End Class
