'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session
	Friend Class SessionSelectionDTO
								Implements iSessionSelectionDTO

		Friend Property UserName			As String	Implements iSessionSelectionDTO.UserName
		Friend Property SessionName		As String Implements iSessionSelectionDTO.SessionName
		Friend Property DateFrom			As Date		Implements iSessionSelectionDTO.DateFrom
		Friend Property DateTo				As Date		Implements iSessionSelectionDTO.DateTo

	End Class

End Namespace