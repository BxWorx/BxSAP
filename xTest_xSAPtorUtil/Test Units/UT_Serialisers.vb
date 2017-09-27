Imports System.Runtime.Serialization
Imports	xSAPtorUtilities.Controllers
Imports xSAPtorUtilities.Serialization
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace UT_Serialisers

	<TestClass()>
	Public Class UT_Serialisers

		<TestMethod()>
		Public Sub UT_SerViaDC_Class()

			Dim	lo_CntlrUtil	As	iController		= Controller.Controller
			Dim lo_Ser				As	iSerialiser		= lo_CntlrUtil.CreateSerialiser()
			Dim lo_ObjS				As	DTOxml				= New DTOxml("XX", True)
			Dim lo_ObjT				As	DTOxml				= Nothing
			Dim lc_DTO				As	String				= Nothing
			
			lc_DTO	= lo_Ser.SerializeObjectViaDataContract(lo_ObjS)
			lo_ObjT	= lo_Ser.DeSerializeObjectViaDataContract(Of DTOxml)(lc_DTO)

			Assert.IsInstanceOfType(lo_ObjT, GetType( DTOxml ), "Failed")
			Assert.AreEqual(lo_ObjT.DefaultLanguage	,	lo_ObjS.DefaultLanguage)
			Assert.AreEqual(lo_ObjT.ShowPassword		,	lo_ObjS.ShowPassword)

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		<TestMethod()>
		Public Sub UT_SerViaDC_iFace()

			Dim	lo_CntlrUtil	As	iController		= Controller.Controller
			Dim lo_Ser				As	iSerialiser		= lo_CntlrUtil.CreateSerialiser()
			Dim lo_ObjS				As	DTO						= New DTO("XX", True)
			Dim lo_ObjT				As	DTO						= Nothing
			Dim lo_ObjI				As	iDTO					= Nothing
			Dim lc_DTO				As	String				= Nothing
			
			lc_DTO	= lo_Ser.SerializeObjectViaDataContract(lo_ObjS)
			lo_ObjT	= lo_Ser.DeSerializeObjectViaDataContract(Of DTO)(lc_DTO)

			Assert.IsInstanceOfType(lo_ObjT, GetType( DTO ), "Failed")
			Assert.AreEqual(lo_ObjT.DefaultLanguage	,	lo_ObjS.DefaultLanguage)
			Assert.AreEqual(lo_ObjT.ShowPassword		,	lo_ObjS.ShowPassword)

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
		Private Class DTO
										Implements iDTO

			#Region "Properties"

				<DataMember>	Friend Property DefaultLanguage     As String   Implements  iDTO.DefaultLanguage
				<DataMember>	Friend Property ShowPassword        As Boolean  Implements  iDTO.ShowPassword

			#End Region
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			#Region "Constructor"

				'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
				Public Sub New(	Optional	ByVal	_deflang			As String		= "EN"	,
												Optional	ByVal	_showpw				As Boolean	= False		)

					Me.DefaultLanguage  = _deflang
					Me.ShowPassword     = _showpw

				End Sub

			#End Region

		End Class
		'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
		<DataContract([Namespace]:="")> _
		Private	Class DTOxml

			#Region "Properties"

				<DataMember>	Public	Property DefaultLanguage     As String
				<DataMember>	Public	Property ShowPassword        As Boolean

			#End Region
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			#Region "Constructors"

				'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
				Public Sub New(	Optional	ByVal	_deflang	As String		= "EN"	,
												Optional	ByVal	_showpw		As Boolean	=	False		)

					Me.DefaultLanguage	= _deflang
					Me.ShowPassword			= _showpw

				End Sub

			#End Region

		End Class

	End Class

End Namespace
