'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Interface	iLogonOptionsModel
		
		#Region "Methods: Exposed"

			Function	CreateDTO()														As iLogonOptionsDTO
			Function	Fetch()																As iLogonOptionsDTO
			Function	Save(ByVal	DTO	As iLogonOptionsDTO)	As Boolean

		#End Region

	End Interface

End Namespace