Imports xSAPtorExcel.Main.Notification.Icon
Imports xSAPtorExcel.Services.Excel

Imports BxS.API.BDC

Imports xSAPtorExcel.Main.Process.Common
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Selection

	Friend Interface ixProcessSelectionVM

		#Region "Properties"
			ReadOnly	Property	IsViewDisposed()	As	Boolean

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			Sub	Show()
			'....................................................
			Function GetOpenWBWSHierarchy()																					As ixProcessSelectionDTO






			Function GetWorkSheetProfile(ByVal WorkBookName		As String,
																	 ByVal WorkSheetName	As String)						As iExcelWSProfileDTO
			Function SubmitTask(ByVal TaskRequest As iBxS_BDCTran_Tran)	As Boolean
		
		#End Region

	End Interface

End Namespace