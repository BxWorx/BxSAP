Imports xSAPtorExcel.Main.BDCProcessing
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Runner

	Friend Interface ixProcessMessageHandler

		#Region "Methods"

			Sub Reset()
			Sub Update()

			Overloads	Sub LoadMessages(ByVal WSProfile As iBDCWSProfile)
			Overloads	Sub LoadMessages(ByVal ExcelRow	As Integer, ByVal Messages	As List(Of String) )
			Overloads	Sub LoadMessages(ByVal ExcelRow	As Integer, ByVal Message		As String )

		#End Region

	End Interface

End Namespace