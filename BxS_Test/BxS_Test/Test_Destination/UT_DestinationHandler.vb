Imports SAPNCO = SAP.Middleware.Connector
Imports BxSNCO = BxS.Destination
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
<TestClass()>
Public Class UT_DestinationHandler

	Private testContextInstance As TestContext

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
	' <TestInitialize()> Public Sub MyTestInitialize()
	' End Sub
	'
	' Use TestCleanup to run code after each test has run
	' <TestCleanup()> Public Sub MyTestCleanup()
	' End Sub
	'
#End Region
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		<TestMethod()>
		_
			Public Sub UT_BxSDestConfig()

				'Dim lo_NCODestCfg		As SAPNCO.RfcConfigParameters	= Nothing
				'Dim lo_NCODest			As SAPNCO.RfcCustomDestination
				'Dim lo_BxSDestHndlr	As BxSNCO.iBxSDestinationManager
				'Dim lo_BxSDestCfg		As BxSNCO.iBxSDestinationConfiguration
				'Dim lo_BxSDestDTO		As BxSNCO.iBxSDestParamsDTO

				'Dim lc_ID1st				As String											= String.Empty
				'Dim lc_User					As String											= "USER01"
				'Dim lc_UserChk			As String											= ""

				'lo_BxSDestHndlr	= New BxSNCO.BxSDestinationManager
				'lo_BxSDestCfg		= New BxSNCO.BxSDestinationConfiguration

				''lo_BxSDestCfg.LoadSAPIni()

				'Assert.AreNotEqual( lo_BxSDestCfg.GetEntries().Count, 0	)

				'For Each lc_ID As String In lo_BxSDestCfg.GetEntries()
				'	lo_NCODestCfg	= lo_BxSDestCfg.GetParameters(destinationName:=lc_ID)
				'	If lo_NCODestCfg.Item(SAPNCO.RfcConfigParameters.AppServerHost).Contains("172.100.8.46")
				'		lc_ID1st = lc_ID
				'		Exit For
				'	End If
				'Next

				'Assert.IsNotNull(	lo_NCODestCfg	)

				'lo_NCODestCfg.Add(SAPNCO.RfcConfigParameters.User, lc_User)
				'lo_BxSDestCfg.UpdateDestinationConfig(rfcDestID:=lc_ID1st, rfcCfgParameters:=lo_NCODestCfg)
				'lo_NCODestCfg	= lo_BxSDestCfg.GetParameters(destinationName:=lc_ID1st)
				'lc_UserChk	= lo_NCODestCfg.Item(key:=SAPNCO.RfcConfigParameters.User)

				'Assert.AreEqual(lc_UserChk, lc_User )

				'lo_BxSDestDTO						= New BxSNCO.BxSDestParamsDTO
				'lo_BxSDestDTO.Client		= "999"
				'lo_BxSDestDTO.User			= "DERRICKB"
				'lo_BxSDestDTO.Password	= "moon123"
				'lo_BxSDestCfg.ModifyDestinationConfig(rfcDestID:=lc_ID1st, rfcCfgParameters:=lo_BxSDestDTO)


				'lo_BxSDestHndlr.Register(rfcDestConfig:=lo_BxSDestCfg)

				'lo_NCODest = lo_BxSDestHndlr.GetDestination(rfcDestID:=lc_ID1st)

				'lo_BxSDestDTO					= New BxSNCO.BxSDestParamsDTO
				'lo_BxSDestDTO.Client	= "100"
				'lo_BxSDestCfg.ModifyDestinationConfig(rfcDestID:=lc_ID1st, rfcCfgParameters:=lo_BxSDestDTO)

				'lo_NCODest = lo_BxSDestHndlr.GetDestination(rfcDestID:=lc_ID1st)

				'Assert.AreEqual(lo_NCODest.Client, "999")

				''Dim lo_LogonDTO	As BxSNCO.iBxSLogonParamsDTO

				''lo_LogonDTO	= lo_BxSDestHndlr.GetLogonDTO
				''lo_LogonDTO.Client		= "100"
				''lo_LogonDTO.User			= "DERRICKB"
				''lo_LogonDTO.Password	= "moon123"

				''lo_NCODest = lo_BxSDestHndlr.GetDestination(rfcDestID:=lc_ID1st, rfcLogonDTO:=lo_LogonDTO)
				
				''Assert.AreEqual(lo_NCODest.Client, lo_LogonDTO.Client)

				''lo_NCODest.Ping()

	End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		<TestMethod()>
		_
			Public Sub UT_RegisterConfig()

				Dim lo_SAPINI				As SAPNCO.SapLogonIniConfiguration
				Dim	lo_SAPIniDest		As SAPNCO.IDestinationConfiguration

				Dim lo_BxSDestHndlr	As BxSNCO.iBxSDestinationManager

				lo_SAPINI				= SAPNCO.SapLogonIniConfiguration.Create()
				lo_SAPIniDest		= CType(lo_SAPINI, SAPNCO.IDestinationConfiguration)
				lo_BxSDestHndlr	= New BxSNCO.BxSDestinationManager

				'Assert.IsTrue(		lo_BxSDestHndlr.Register(	)	)
				'Assert.IsNotNull(	lo_BxSDestHndlr.GetDestination(	rfcDestID:=lo_SAPINI.GetEntries(1)	)	)
				'Assert.IsTrue(		lo_BxSDestHndlr.Unregister()	)

			End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		<TestMethod()>
		_
	Public Sub UT_DestHndlr()

		'Dim lo_NCODest			As SAPNCO.RfcDestination
		'Dim lo_CfgParms			As SAPNCO.RfcConfigParameters
		'Dim lo_BxSDestHndlr	As BxSNCO.iBxSDestinationManager
		'Dim lo_CfgDTO				As BxSNCO.iBxSDestParamsDTO
		'Dim lo_CfgHndlr			As BxSNCO.iBxSRfcConfigHandler
		'Dim lo_lclDTO				As lclDTO

		'lo_lclDTO				= New lclDTO
		'lo_CfgDTO				= New BxSNCO.BxSDestParamsDTO
		'lo_CfgHndlr			= New BxSNCO.BxSRfcConfigHandler
		'lo_BxSDestHndlr	= New BxSNCO.BxSDestinationManager

		'lo_lclDTO.Load(lo_CfgDTO)
		'lo_CfgParms	= lo_CfgHndlr.Create(cfgDTO:=lo_CfgDTO)

		'lo_NCODest	= lo_BxSDestHndlr.GetDestination(rfcCfgParam:=lo_CfgParms)

		'Assert.IsNotNull(value:=lo_NCODest, message:="xxx")


		'lo_CfgDTO.SystemNo	= "SNo01"
		'lo_CfgParms			= lo_CfgHndlr.Create(cfgDTO:=lo_CfgDTO)
		'lo_NCODest			= lo_BxSDestHndlr.GetDestination(rfcCfgParam:=lo_CfgParms)

		'Assert.IsNull(value:=lo_NCODest, message:="xxx")

	End Sub

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨

	<TestMethod()>
	Public Sub UT_CfgHndlr()

		'Dim lo_CfgParmsSrc	As SAPNCO.RfcConfigParameters
		'Dim lo_CfgParmsRes	As SAPNCO.RfcConfigParameters
		'Dim lo_CfgDTO				As BxSNCO.iBxSDestParamsDTO
		'Dim lo_CfgHndlr			As BxSNCO.iBxSRfcConfigHandler
		'Dim lo_lclDTO				As lclDTO

		'lo_lclDTO		= New lclDTO
		'lo_CfgHndlr	= New BxSNCO.BxSRfcConfigHandler
		'lo_CfgDTO		= New BxSNCO.BxSDestParamsDTO

		'lo_lclDTO.Load(lo_CfgDTO)

		'lo_CfgParmsSrc	= lo_CfgHndlr.Create(cfgDTO:= lo_CfgDTO)
		'lo_CfgParmsRes	= lo_CfgHndlr.Create( lo_lclDTO.Name, _
		'																			lo_lclDTO.Host, _
		'																			lo_lclDTO.SysNo, _
		'																			lo_lclDTO.SysID, _
		'																			lo_lclDTO.Client, _
		'																			lo_lclDTO.User, _
		'																			lo_lclDTO.PWrd
		'																		)

		'Assert.AreEqual(expected:=lo_CfgParmsSrc, actual:=lo_CfgParmsRes, message:="CfgHndlr: Create: 001")

	End Sub

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Class lclDTO

			Property Name()		As String
			Property Host()		As String
			Property SysID()	As String
			Property SysNo()	As String
			Property Client() As String
			Property User()		As String
			Property PWrd()		As String

			'Public Sub Load(ByRef DTO As BxSNCO.iBxSDestParamsDTO)

			'	DTO.Name			= Me.Name
			'	DTO.Host			= Me.Host
			'	DTO.SystemID	= Me.SysID
			'	DTO.SystemNo	= Me.SysNo
			'	DTO.Client		= Me.Client
			'	DTO.User			= Me.User
			'	DTO.Password	= Me.PWrd

			'End Sub

			Public Sub New()

				Me.Name		= "KMSA-DEV"
				Me.Host		= "172.100.8.46"
				Me.SysID	= "ECD"
				Me.SysNo	= "00"
				Me.Client	= "100"
				Me.User		= "DERRICKB"
				Me.PWrd		= "moon123"

			End Sub

		End Class

End Class
