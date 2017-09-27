Imports System.Windows.Forms
Imports xSAPtorExcel.Services.Excel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Selection

	Friend Class xProcessSelectionModel
								Implements ixProcessSelectionModel

		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetWorkSheetProfile(ByVal WorkBookName  As String,
																					ByVal WorkSheetName	As String) _
												As iExcelWSProfileDTO _
													Implements ixProcessSelectionModel.GetWorkSheetProfile

				Return Me.co_ExcelHelper.GetExcelWSProfileDTO(WorkBookName := WorkBookName,
																											WorkSheetName:= WorkSheetName)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetOpenWBWSItems() _
												As ixProcessSelectionDTO _
													Implements ixProcessSelectionModel.GetOpenWBWSItems
			
				Dim lo_DTO	As ixProcessSelectionDTO			= New xProcessSelectionDTO
				Dim lt_List	As List(Of iExcelMDIWBookDTO)	= me.co_ExcelHelper.GetWSHierarchy()

				For Each ls_WB As iExcelMDIWBookDTO In lt_list

					Dim lo_PNode As New TreeNode(ls_WB.WBName)

					lo_PNode.Tag	= String.Concat("[WB]:", ls_WB.WBName)

					For Each ls_WS As iExcelMDIWSheetDTO In ls_WB.WSList

						Dim lo_CNode As New TreeNode

						lo_CNode.Text	= ls_WS.WSName
						lo_CNode.Tag	= String.Concat("[WS]:", ls_WB.WBName, "~", ls_WS.WSName)

						lo_PNode.Nodes.Add(lo_CNode)

					Next

					lo_DTO.Nodes.Add(lo_PNode)

				Next

				Return lo_DTO

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			Private co_ExcelHelper	As iExcelHelper

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(ByVal i_ExcelHelper	As iExcelHelper)

				Me.co_ExcelHelper	= i_ExcelHelper

			End Sub

		#End Region

	End Class

End Namespace
