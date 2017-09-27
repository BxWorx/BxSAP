Imports System.Threading
Imports xSAPtorExcel.Services.Excel
Imports xSAPtorNCO.API.SAP.System.Services
'================================================
Namespace Main.BDCProcessing
	Friend Interface iBDC_Transaction

		#Region "Properties"

			ReadOnly Property SAP_TCode As String
			ReadOnly Property ExcelRow  As Integer
			ReadOnly Property BDC_Data  As List(Of iBDC_Data)

		#End Region

		#Region "Methods"

			Function Process(ByRef i_ct         As CancellationToken,
											 ByRef i_WSProfile	As iExcelWSProfileDTO,
											 ByRef i_WSHeader   As iBDCWSHeader,
											 ByRef i_WSData     As iBDCWSData,
											 ByVal i_RowIndices As List(Of Integer) ) As ixBDCTransaction

		#End Region

	End Interface

End Namespace