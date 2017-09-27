Imports xSAPtorExcel.Utilities.MsgHub
Imports xSAPtorExcel.Services.Excel

Imports Microsoft.Office.Interop.Excel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Public	Class	ThisAddIn

	'Private	co_XMLConfig	As iExcelWSProfileDTO	= Nothing


	#Region "Event Handlers"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub ThisAddIn_Startup(sender	As Object,
																	e				As EventArgs) _
									Handles Me.Startup

			If so_CntlrNotify.Value.ShowStartupMg
				so_MsgHub.Value.Publish(New	sMsgStartupShutdown(False))
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub ThisAddIn_Shutdown(sender	As Object,
																	 e			As EventArgs) _
									Handles Me.Shutdown

			so_MsgHub.Value.Publish(New	sMsgStartupShutdown(True))

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub Application_SheetDeactivate(Sh As Object) Handles Application.SheetDeactivate

			'Me.co_XMLConfig	= Nothing

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub Application_SheetActivate(Sh As Object) Handles Application.SheetActivate

			'Me.co_XMLConfig	= so_HlprExcel.Value.GetExcelWSProfileDTO()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub Application_SheetChange(Sh As Object, Target As Range) Handles Application.SheetChange

			'If IsNothing(Me.co_XMLConfig)				Then	Me.co_XMLConfig	= so_HlprExcel.Value.GetExcelWSProfileDTO()
			'If Not Me.co_XMLConfig.IsSAPtor			Then	Exit Sub
			'If Not Me.co_XMLConfig.IsProtected	Then	Exit Sub
			''....................................................
			'Application.EnableEvents	=	False
			'Application.Undo
			'Application.EnableEvents	= True

		End Sub

	#End Region

End Class
