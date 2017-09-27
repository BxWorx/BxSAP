Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.Services.UI
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.BDCWorksheet
	Friend Interface iBDCWSHeader

		#Region "Properties"

			ReadOnly Property IsMultiLine As Boolean
			ReadOnly Property Columns     As ConcurrentDictionary(Of Integer, iExcelColumn)
			ReadOnly Property ColumnIndex As List(Of Integer)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function LoadAsync(	ByVal i_ExcelWSProfile	As iExcelWSProfileDTO,
													ByVal i_ct							As CancellationToken)	As Task(Of Boolean)

		#End Region

	End Interface

End Namespace