Imports SAPNCO	= SAP.Middleware.Connector
Imports BxSNCO	= BxS.API.Destination
Imports BxSBDC	= BxS.API.SAPFunctions.BDCTransaction
Imports BxSHlp	= BxS.API.SAPFunctions.Helpers

Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
<TestClass()>
Public Class UT_BDCTransaction

	Private testContextInstance		As TestContext

	Private	co_BxSDestCntlr				As BxSNCO.iBxSDestinationController
	'Private	co_BxSDestHelper			As BxSNCO.iBxSDestinationHelper
	Private	co_Dest								As SAPNCO.RfcCustomDestination

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

		Dim lc_DestID		As String

		Me.co_BxSDestCntlr	= BxSNCO.BxSDestinationController.GetInstance()
		'Me.co_BxSDestHelper	= BxSNCO.BxSDestinationHelper.GetInstance()

		lc_DestID		= Array.Find(Me.co_BxSDestCntlr.Create_SAPIni_DestinationConfig().GetEntries(), Function(key) key.Contains("00.96") )
		Me.co_Dest	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="500", user:="DERRICKBINGH", password:="M@@n0987")

		'lc_DestID		= Array.Find(Me.co_BxSDestCntlr.Create_SAPIni_DestinationConfig().GetEntries(), Function(key) key.Contains("05.01") )
		'Me.co_Dest	= Me.co_BxSDestCntlr.GetDestination(rfcDestID:=lc_DestID, client:="100", user:="DERRICKB", password:="moon123")

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
		Public Sub UT_BDCTran_Factory()

			Dim lo_Factory	As BxSBDC.iBxS_BDCTran_Factory
			Dim	lo_BDCRun1	As BxSBDC.iBxS_BDCTran_Caller
			Dim	lo_BDCRun2	As BxSBDC.iBxS_BDCTran_Caller

			lo_Factory	= New BxSBDC.BxS_BDCTran_Factory(destination:=Me.co_Dest)
			lo_BDCRun1	= lo_Factory.CreateBDCTranCaller()
			lo_BDCRun2	= lo_Factory.CreateBDCTranCaller()

			Assert.IsNotNull(lo_BDCRun1)
			Assert.IsNotNull(lo_BDCRun2)

			'With lo_BDCRun1

			'	.Profile.Add_Option("  BMADOMAIN EQ 'CONTRACTS'")
			'	.Invoke()

			'	Assert.AreNotEqual(0,.RowCount)

			'End With

			'With lo_BDCRun2

			'	.Profile.Add_Option("  BMADOMAIN LIKE 'HO%'")
			'	.Invoke()

			'	Assert.AreNotEqual(0,.RowCount)

			'End With


		End Sub

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		<TestMethod()>
		_
		Public Sub UT_BDCTran_Run()

		Dim lo_Factory	As BxSBDC.iBxS_BDCTran_Factory
		Dim	lo_BDCRun1	As BxSBDC.iBxS_BDCTran_Caller
		Dim lo_BDCEntry	As BxSHlp.iBxS_BDC_Entry

		lo_Factory	= New BxSBDC.BxS_BDCTran_Factory(destination:=Me.co_Dest)
		lo_BDCRun1	= lo_Factory.CreateBDCTranCaller()

		'lo_BDCRun1.CTUParameters.SAPTCode						= "VA03"

		'lo_BDCRun1.CTUParameters.CTUParams.DefSize	= "X"
		'lo_BDCRun1.CTUParameters.CTUParams.DisMode	= "A"
		'lo_BDCRun1.CTUParameters.CTUParams.UpdMode	= "A"

		lo_BDCEntry								= New BxSHlp.BxS_BDC_Entry
		'lo_BDCEntry.Program_Name	= "SAPMV45A"
		'lo_BDCEntry.Dynpro_Number	= "0102"
		'lo_BDCEntry.Dynpro_Begin	= "X"
		'lo_BDCRun1.CTUParameters.BDC_Data.Add(lo_BDCEntry)

		'lo_BDCEntry								= New BxSHlp.BxS_BDC_Entry
		'lo_BDCEntry.Field_Name		= "VBAK-VBELN"
		'lo_BDCEntry.Field_Value		= "0001352123"
		'lo_BDCRun1.CTUParameters.BDC_Data.Add(lo_BDCEntry)

		'lo_BDCEntry								= New BxSHlp.BxS_BDC_Entry
		'lo_BDCEntry.Field_Name		= "BDC_OKCODE"
		'lo_BDCEntry.Field_Value		= "/00"
		'lo_BDCRun1.CTUParameters.BDC_Data.Add(lo_BDCEntry)

		'lo_BDCEntry								= New BxSHlp.BxS_BDC_Entry
		'lo_BDCEntry.Program_Name	= "SAPMV45A"
		'lo_BDCEntry.Dynpro_Number	= "4001"
		'lo_BDCEntry.Dynpro_Begin	= "X"
		'lo_BDCRun1.CTUParameters.BDC_Data.Add(lo_BDCEntry)

		'lo_BDCEntry								= New BxSHlp.BxS_BDC_Entry
		'lo_BDCEntry.Field_Name		= "BDC_OKCODE"
		'lo_BDCEntry.Field_Value		= "/12"
		'lo_BDCRun1.CTUParameters.BDC_Data.Add(lo_BDCEntry)


		'lo_BDCRun1.SetSAPGUIasVisible

		'lo_BDCRun1.Invoke()

	End Sub

	#End Region

End Class

		'Dim lo_BDCSsn		As BxSSes.iBxS_BDCSession
		'Dim lt_List			As List(Of BxSSes.iBxSBDCSession_Header)
		'Dim lo_BDCPrf		As BxSSes.iBxSBDCSession_Profile
		'Dim lo_BDCHed		As BxSSes.iBxSBDCSession_Header

		'lo_BDCSsn = New BxSSes.BxS_BDCSession(Me.co_Dest)
		'lt_List		= lo_BDCSsn.BDCSessionList(i_UserId:="DERRICKB")
		'lo_BDCHed = lt_List(0)

		'lo_BDCPrf = lo_BDCSsn.BDCSession(i_SessionName:=lo_BDCHed.SessionName,
		'																 i_QID:=lo_BDCHed.QID)

		'lo_BDCRun1.Profile.SAPTCode		= lo_BDCPrf.SAPTCode
		'lo_BDCRun1.Profile.CTUParams	= lo_BDCPrf.CTUParams
		'lo_BDCRun1.Profile.BDC_Data		= lo_BDCPrf.BDCDataList

