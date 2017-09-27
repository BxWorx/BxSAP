'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.RunMonitor
	Friend Class xProcessRunMonitorDTO
								Implements ixProcessRunMonitorDTO

		#Region "Properties"

			Property GUID							As String		Implements ixProcessRunMonitorDTO.GUID
			Property WBookName				As String		Implements ixProcessRunMonitorDTO.WBookName
			Property WSheetName				As String		Implements ixProcessRunMonitorDTO.WSheetName
			Property TranCount				As Integer	Implements ixProcessRunMonitorDTO.TranCount
			Property TranComplete			As Integer	Implements ixProcessRunMonitorDTO.TranComplete
			Property PercComplete			As Integer	Implements ixProcessRunMonitorDTO.PercComplete

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Friend Function ShallowCopy() _
												As ixProcessRunMonitorDTO _
													Implements ixProcessRunMonitorDTO.ShallowCopy

				Return DirectCast(Me.MemberwiseClone(), ixProcessRunMonitorDTO)

			End Function

		#End Region

	End Class

End Namespace