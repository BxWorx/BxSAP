Imports System.Runtime.Serialization
Imports	xSAPtorUtilities.Controllers
Imports xSAPtorUtilities.Convertors
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace UT_Convertors

	<TestClass()>
	Public Class UT_Convertors

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

			<TestMethod()>
			Public Sub UT_Conv_iFace2Inst()

				Dim	lo_CntlrUtil	As	iController					= Controller.Controller
				Dim lo_I2I				As	iClone	= lo_CntlrUtil.CreateCloner()

				Dim lo_iDTOemp		As	iDTO								= New DTOemp()
				Dim lo_iDTOopt		As	iDTO								= New DTOopt()
				Dim lo_cDTOemp		As	DTOemp
				Dim lo_cDTOopt		As	DTOopt

				lo_iDTOemp.DefaultLanguage	= "11"
				lo_iDTOemp.ShowPassword			= True

				lo_iDTOopt.DefaultLanguage	= "22"
				lo_iDTOopt.ShowPassword			= True

				lo_cDTOemp	= lo_I2I.iFace2Instance(Of DTOemp, iDTO)(lo_iDTOemp)
				lo_cDTOopt	= lo_I2I.iFace2Instance(Of DTOopt, iDTO)(lo_iDTOopt)

				Assert.AreEqual(lo_cDTOemp.DefaultLanguage,	lo_iDTOemp.DefaultLanguage, "Fail: Empty constructor")
				Assert.AreEqual(lo_cDTOopt.DefaultLanguage,	lo_iDTOopt.DefaultLanguage, "Fail: Optional constructor")

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			<TestMethod()>
			Public Sub UT_Conv_Inst2iFace()

				Dim	lo_CntlrUtil	As	iController					= Controller.Controller
				Dim lo_I2I				As	iClone	= lo_CntlrUtil.CreateCloner()
				Dim lo_cDTOemp		As	DTOemp							= New DTOemp()
				Dim lo_cDTOopt		As	DTOopt							= New DTOopt()
				Dim lo_iDTOemp		As	iDTO
				Dim lo_iDTOopt		As	iDTO

				lo_cDTOemp.DefaultLanguage	= "11"
				lo_cDTOemp.ShowPassword			= True

				lo_cDTOopt.DefaultLanguage	= "22"
				lo_cDTOopt.ShowPassword			= True

				lo_iDTOemp	= lo_I2I.Instance2iFace(Of DTOemp, iDTO)(lo_cDTOemp)
				lo_iDTOopt	= lo_I2I.Instance2iFace(Of DTOopt, iDTO)(lo_cDTOopt)

				Assert.AreEqual(lo_cDTOemp.DefaultLanguage,	lo_iDTOemp.DefaultLanguage, "Fail: Empty constructor")
				Assert.AreEqual(lo_cDTOopt.DefaultLanguage,	lo_iDTOopt.DefaultLanguage, "Fail: Optional constructor")

			End Sub
		'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
		Private Interface iDTO

			#Region "Properties"

				Property DefaultLanguage    As String
				Property ShowPassword       As Boolean

			#End Region

		End Interface
		'..............................................................................................
		<DataContract([Namespace]:="")> _
		Private Class DTOemp
										Implements iDTO

			#Region "Properties"

				<DataMember>	Friend Property DefaultLanguage		As String			Implements  iDTO.DefaultLanguage
				<DataMember>	Friend Property ShowPassword			As Boolean		Implements  iDTO.ShowPassword

			#End Region
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			#Region "Constructor"

				'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
				Public Sub New()

					Me.DefaultLanguage  = "EN"
					Me.ShowPassword     = False

				End Sub

			#End Region

		End Class
		'..............................................................................................
		<DataContract([Namespace]:="")> _
		Private Class DTOopt
										Implements iDTO

			#Region "Properties"

				<DataMember>	Friend Property DefaultLanguage		As String			Implements  iDTO.DefaultLanguage
				<DataMember>	Friend Property ShowPassword			As Boolean		Implements  iDTO.ShowPassword

			#End Region
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			#Region "Constructor"

				'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
				Public Sub New(	Optional	ByVal	_deflang	As String		= "EN"	,
												Optional	ByVal	_showpw		As Boolean	= False		)

					Me.DefaultLanguage  = _deflang
					Me.ShowPassword     = _showpw

				End Sub

			#End Region

		End Class

	End Class

End Namespace
