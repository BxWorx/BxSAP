Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Concurrent

Imports xSAPtorExcel.Services.UI
Imports xSAPtorExcel.Services.Excel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.BDCWorksheet
	Friend Interface iBDCWSData

		#Region "Properties"

			ReadOnly Property Rows()    As ConcurrentDictionary(Of Integer, iExcelRow)
			ReadOnly Property RowIndex  As List(Of Integer)

		# End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Sub WriteWSMessages(	ByVal ExcelWSProfile	As iExcelWSProfileDTO,
														ByVal Messages				As Dictionary(Of Integer, String) )

			Function LoadAsync(	ByVal i_ExcelWSProfile	As iExcelWSProfileDTO,
													ByVal i_ct							As CancellationToken,
								 Optional ByVal i_SearchEOT				As Boolean  = False) As Task(Of Boolean)

		#End Region

	End Interface

End Namespace