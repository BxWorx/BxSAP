Imports BxSNCO	= BxS.API.Destination

Imports BxS.API.Main
Imports BxS.API.BDC

Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
<TestClass()>
Public Class UT_BDCSession

	Private testContextInstance		As TestContext

	Private co_NCOCntlr						As ixNCOController
	Private cc_DestID							As String
	Private	co_Dest								As BxSNCO.iBxSDestination


	'Private Const cx_SAPFncName		As String = "/BODS/RFC_READ_TABLE2"

	'Private	co_BxSDestCntlr				As BxSNCO.iBxSDestinationController
	'Private	co_BxSDestHelper			As BxSNCO.iBxSDestinationHelper
	'Private	co_Dest								As SAPNCO.RfcCustomDestination

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

	End Sub
	'
	' Use ClassCleanup to run code after all tests in a class have run
	' <ClassCleanup()> Public Shared Sub MyClassCleanup()
	' End Sub
	'
	' Use TestInitialize to run code before running each test
	<TestInitialize()> _
	Public Sub MyTestInitialize()

		Me.co_NCOCntlr	= xNCOController.NCOController()
		Me.co_NCOCntlr.Configure_for_SAPIni()

		Me.cc_DestID	= Me.co_NCOCntlr.GetDestinationList().Find( Function(key) key.Contains("00.96") )
		Me.co_Dest		= Me.co_NCOCntlr.GetDestination(rfcDestID:=Me.cc_DestID)

		Me.co_Dest.Configure("500", "DERRICKBINGH", "M@@n0987")

	End Sub

	'
	' Use TestCleanup to run code after each test has run
	<TestCleanup()> _
		Public Sub MyTestCleanup()

			'Me.co_BxSDestCntlr.UnRegister()

		End Sub

#End Region
'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
	#Region "Tests"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		<TestMethod()>
		_
		Public Sub UT_BDCSession_Basic()

			Dim	lt_List		As List(Of iBxSBDCSession_Header)
			Dim lo_BDCPrf	As iBxSBDCSession_Profile

			lt_List		= Me.co_NCOCntlr.SessionList(Me.co_Dest)
			lo_BDCPrf	= Me.co_NCOCntlr.SessionProfile(Me.co_Dest,lt_List(0).SessionName, lt_List(0).QID)

		End Sub

	#End Region

End Class
