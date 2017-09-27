Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports	xSAPtorExcel.Main
Imports	xSAPtorExcel.Services.Utilities.Generic
Imports	xSAPtorExcel.UI

<TestClass()>
Public Class UT_SAPLogon_Favourites

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

	Private Shared co_Cntlr	As iBxSMainController

	<ClassInitialize()>
		Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)

			co_Cntlr	=	BxSMainController.MainController()

		End Sub
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
		Public Sub UT_SAPLogonFav_Model()

			'Dim lo_Services	As iServicesGeneric		= co_Cntlr.GetServicesGeneric
			Dim lo_Model		As iSAPFavoritesModel	= New SAPFavoritesModel()
			Dim lo_DTO			As iSAPFavoriteDTO

			lo_Model.Reset()

			lo_Model.Capacity = 3	
			lo_DTO	= lo_Model.CreateDTO()

			lo_DTO.Client			= "100"
			lo_DTO.User					= "GTD"
			lo_DTO.RfcDestID	= "XXXX"

			lo_Model.Register(lo_DTO)
			lo_Model.Register(lo_DTO)

			lo_DTO	= lo_Model.CreateDTO()
			lo_DTO.User					= "GTD"
			lo_DTO.RfcDestID	= "XXXX"
			lo_DTO.Client			= "200"
			lo_Model.Register(lo_DTO)

			lo_DTO	= lo_Model.CreateDTO()
			lo_DTO.User					= "GTD"
			lo_DTO.RfcDestID	= "XXXX"
			lo_DTO.Client			= "300"
			lo_Model.Register(lo_DTO)

			lo_DTO	= lo_Model.CreateDTO()
			lo_DTO.User					= "GTD"
			lo_DTO.RfcDestID	= "XXXX"
			lo_DTO.Client			= "400"
			lo_Model.Register(lo_DTO)

			lo_DTO	= lo_Model.CreateDTO()
			lo_DTO.User					= "GTD"
			lo_DTO.RfcDestID	= "XXXX"
			lo_DTO.Client			= "300"
			lo_Model.Register(lo_DTO)

			lo_Model.Save()

			Dim y = lo_Model.List

			lo_Model	= New SAPFavoritesModel()
			Dim z = lo_Model.List


			If y.Count.Equals(z.Count)
				Dim a = 1				
			End If

		End Sub

End Class
