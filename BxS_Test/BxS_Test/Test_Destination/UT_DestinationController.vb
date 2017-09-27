Imports SAPNCO = SAP.Middleware.Connector
Imports BxSNCO = BxS.API.Destination
Imports BxSMain = BxS.API.Main
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
<TestClass()>
Public Class UT_DestinationController

	Private testContextInstance		As TestContext
	
	Private co_NCOCntlr						As BxSMain.ixNCOController
	Private cc_DestID							As String

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

		Me.cc_DestID		= Me.co_NCOCntlr.GetDestinationList().Find( Function(key) key.Contains("00.96") )

	End Sub
	'
	' Use TestCleanup to run code after each test has run
	' <TestCleanup()> Public Sub MyTestCleanup()
	' End Sub
	'
#End Region
'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
#Region "Tests"

	'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
	<TestMethod()>
		_
		Public Sub UT_Cntlr_StartupLite()

			Dim lo_Dest			As BxSNCO.iBxSDestination

			lo_Dest						= Me.co_NCOCntlr.GetDestination(rfcDestID:=Me.cc_DestID)
			lo_Dest.Configure("500", "DERRICKBINGH", "M@@n0987")

			lo_Dest.RfcDestination.Ping()

			Me.co_NCOCntlr.Finalise()

		End Sub
	'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
	<TestMethod()>
		_
		Public Sub UT_Cntlr_Startup()

			'Dim lc_DestID		As String
			'Dim lo_LogonDTO	As BxSNCO.iBxSLogonParamsDTO
			'Dim lo_DestCfg	As BxSNCO.iBxSDestinationConfiguration
			'Dim lo_Dest0		As SAPNCO.RfcCustomDestination
			'Dim lo_Dest1		As SAPNCO.RfcCustomDestination
			'Dim lo_Dest2		As SAPNCO.RfcCustomDestination
			'Dim lo_Dest3		As SAPNCO.RfcCustomDestination
			'Dim lo_Dest4		As SAPNCO.RfcCustomDestination
			'Dim lo_Dest5		As SAPNCO.RfcCustomDestination
			'Dim lo_Dest6		As SAPNCO.RfcCustomDestination
			'Dim lo_Dest7		As SAPNCO.RfcCustomDestination


			'lo_LogonDTO	= Me.co_BxSDestCntlr.Create_LogonDTO()
			'lo_LogonDTO.Load("100", "DERRICKB", "moon123")

			'lo_DestCfg	= Me.co_BxSDestCntlr.Create_SAPIni_DestinationConfig()
			'lc_DestID		= Array.Find(lo_DestCfg.GetEntries(), Function(key) key.Contains("00.96") )
			''lc_DestID		= Array.Find(lo_DestCfg.GetEntries(), Function(key) key.Contains("05.01") )

			''Me.co_BxSDestCntlr.Register(destinationConfiguration:=lo_DestCfg)

			''lo_Dest0	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, rfcLogonDTO:=lo_LogonDTO)

			''lo_Dest.Ping()

			''Me.co_BxSDestCntlr.UnRegister()
			''..................................................................
			'Me.co_BxSDestCntlr.Register(destinationConfiguration:=lo_DestCfg)

			'lo_Dest0	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="500", user:="DERRICKBINGH", password:="M@@n0987")
			'lo_Dest1	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="500", user:="DERRICKBINGH", password:="M@@n0987")
			'lo_Dest2	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="500", user:="DERRICKBINGH", password:="M@@n0987")
			'lo_Dest3	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="500", user:="DERRICKBINGH", password:="M@@n0987")
			'lo_Dest4	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="500", user:="DERRICKBINGH", password:="M@@n0987")
			'lo_Dest5	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="500", user:="DERRICKBINGH", password:="M@@n0987")
			'lo_Dest6	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="500", user:="DERRICKBINGH", password:="M@@n0987")
			'lo_Dest7	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="500", user:="DERRICKBINGH", password:="M@@n0987")
			''lo_Dest7	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="100", user:="DERRICKB", password:="moon123")

			'lo_Dest0.UseSAPGui	= SAPNCO.RfcConfigParameters.RfcUseSAPGui.Hidden

			'Assert.AreNotEqual(lo_Dest0.UseSAPGui,lo_Dest1.UseSAPGui)
		
			'lo_Dest0.Ping()
			'lo_Dest1.Ping()
			'lo_Dest2.Ping()
			'lo_Dest3.Ping()
			'lo_Dest4.Ping()
			'lo_Dest5.Ping()
			'lo_Dest6.Ping()
			'lo_Dest7.Ping()

			'Me.co_BxSDestCntlr.UnRegister()

		End Sub

#End Region

End Class
