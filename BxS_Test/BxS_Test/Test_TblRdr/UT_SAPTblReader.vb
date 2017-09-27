Imports SAPNCO		= SAP.Middleware.Connector
Imports BxSNCO		= BxS.API.Destination
Imports BxSTblRdr	= BxS.API.SAPFunctions.Tablereader
Imports BxSMain		= BxS.API.Main

Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
<TestClass()>
Public Class UT_TblRdr_Basic

	Private testContextInstance		As TestContext

	Private co_NCOCntlr						As BxSMain.ixNCOController
	Private co_Dest								As SAPNCO.RfcCustomDestination
	Private cc_DestID							As String


	Private Const cx_SAPFncName		As String = "/BODS/RFC_READ_TABLE2"

	'Private	co_BxSDestCntlr				As BxSNCO.iBxSDestinationController
	'Private	co_BxSDestHelper			As BxSNCO.iBxSDestinationHelper

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

		Me.co_NCOCntlr	= BxSMain.xNCOController.NCOController()
		Me.co_NCOCntlr.Configure_for_SAPIni()

		Me.cc_DestID		= Me.co_NCOCntlr.GetDestinationList().Find( Function(key) key.Contains("05.01") )
		Me.cc_DestID		= Me.co_NCOCntlr.GetDestinationList().Find( Function(key) key.Contains("05.01") )

		Dim lc_DestID		As String

		Me.co_BxSDestCntlr	= BxSNCO.BxSDestinationController.GetInstance()
		'Me.co_BxSDestHelper	= BxSNCO.BxSDestinationHelper.GetInstance()

		lc_DestID		= Array.Find(Me.co_BxSDestCntlr.Create_SAPIni_DestinationConfig().GetEntries(), Function(key) key.Contains("00.96") )
		Me.co_Dest	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="500", user:="DERRICKBINGH", password:="M@@n0987")

	End Sub
	'
	' Use TestCleanup to run code after each test has run
	<TestCleanup()> _
		Public Sub MyTestCleanup()

			Me.co_BxSDestCntlr.UnRegister()

		End Sub

#End Region
'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
	#Region "Tests"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		<TestMethod()>
		_
		Public Sub UT_TblRdr_Factory()

			Dim lo_TblRdrFactory	As BxSTblRdr.iBxSSAPTblRdr_Factory = New BxSTblRdr.BxSSAPTblRdr_Factory(destination:=Me.co_Dest)
			Dim	lo_tblRdr1				As BxSTblRdr.iBxSSAPTblRdr_Reader
			Dim	lo_tblRdr2				As BxSTblRdr.iBxSSAPTblRdr_Reader

			lo_tblRdr1	= lo_TblRdrFactory.CreateTableReader(tableName:="ZBMA_DOMAIN")
			lo_tblRdr2	= lo_TblRdrFactory.CreateTableReader(tableName:="ZBMA_DOMAIN")

			Assert.IsNotNull(lo_tblRdr1)
			Assert.IsNotNull(lo_tblRdr2)

			With lo_tblRdr1

				.Profile.Add_Option("  BMADOMAIN EQ 'CONTRACTS'")
				.Invoke()

				Assert.AreNotEqual(0,.RowCount)

			End With

			With lo_tblRdr2

				.Profile.Add_Option("  BMADOMAIN LIKE 'HO%'")
				.Invoke()

				Assert.AreNotEqual(0,.RowCount)

			End With

		End Sub

	#End Region

End Class
