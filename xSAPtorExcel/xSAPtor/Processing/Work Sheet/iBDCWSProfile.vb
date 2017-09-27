Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Imports BxS.API.BDC
Imports BxS.API.SAPFunctions.ZDTON

Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.Services.UI
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.BDCWorksheet

	Friend Interface iBDCWSProfile

		#Region "Properties"

			ReadOnly Property		WBookID						As	String
			ReadOnly Property		WSheetID					As	String
			ReadOnly Property		WSheetNo					As	UShort
			'....................................................
			ReadOnly Property		ExcelWSProfile		As	iExcelWSProfileDTO
			ReadOnly Property		WSHeader					As	iBDCWSHeader
			ReadOnly Property		WSData						As	iBDCWSData
			ReadOnly Property		BDCTransactions		As	List(Of iBxS_BDCTran_Tran)
			ReadOnly Property		BDCMessages				As	ConcurrentDictionary(Of Integer, List(Of iBxS_BDCTran_Msg))
			'....................................................
			ReadOnly Property		TranCount					As	Integer
								Property	ProcessedCount		As	Integer
								Property	AsTest						As	Boolean
			'....................................................
			ReadOnly	Property	SAPUser   				As	String
			ReadOnly	Property	SAPTrnCode				As	String
			ReadOnly	Property	SAPSessionID			As	String
			ReadOnly	Property	CTUParameters			As	iBxS_BDC_CTUParameters

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Sub UpdateWSMessages(ByVal Messages	As Dictionary(Of Integer, String))

			Sub FetchMessages(				ByVal Messages	As ConcurrentDictionary(Of Integer, List(Of iBxS_BDCTran_Msg)),
											 Optional	ByVal Reset			As Boolean	= False)
			Function LoadDataAsync(ByVal i_CT		As CancellationToken)							As Task(Of Boolean)
			Function CompileTransactionsAsync(ByVal i_CT	As CancellationToken)		As Task(Of Boolean)

		#End Region

	End Interface

End Namespace