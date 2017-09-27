Imports xSAPtorExcel.Services.Excel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Common

	Friend Class xProcessTask
								Implements ixProcessTask

    #Region "Properties"

			Friend Property WorkbookName	As String								Implements ixProcessTask.WorkbookName
			Friend Property WorksheetName	As String								Implements ixProcessTask.WorksheetName
			Friend Property Checked				As Boolean							Implements ixProcessTask.Checked
			Friend Property Synced				As Boolean							Implements ixProcessTask.Synced
			Friend Property Profile				As iExcelWSProfileDTO		Implements ixProcessTask.Profile
			Friend Property SAPTCode			As String								Implements ixProcessTask.SAPTCode
			Friend Property GUID					As String								Implements ixProcessTask.GUID
			Friend Property TranCount			As Integer							Implements ixProcessTask.TranCount
			Friend Property TranComplete	As Integer							Implements ixProcessTask.TranComplete
			Friend Property PercComplete	As Integer							Implements ixProcessTask.PercComplete
			Friend Property StatusDone		As Boolean							Implements ixProcessTask.StatusDone
			Friend Property Timestamp			As DateTime							Implements ixProcessTask.Timestamp

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Friend Function ShallowCopy() _
												As ixProcessTask _
													Implements ixProcessTask.ShallowCopy

				Return DirectCast(	Me.MemberwiseClone(),
														ixProcessTask)

			End Function

		#End Region		
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Shared Function Create(ByVal WorkbookName	As String,
																		ByVal WorksheetName	As String) _
															As ixProcessTask

				Return New xProcessTask(i_WBName:= WorkbookName,
																i_WSName:= WorksheetName)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Shared Function Create() _
															As ixProcessTask

				Return New xProcessTask()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New()

				Me.Synced		= False
				Me.Checked	= True

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_WBName	As String,
											ByVal i_WSName	As String)

				Me.WorkbookName		= i_WBName
				Me.WorksheetName	= i_WSName

				Me.Synced		= False
				Me.Checked	= True

			End Sub

		#End Region

	End Class

End Namespace