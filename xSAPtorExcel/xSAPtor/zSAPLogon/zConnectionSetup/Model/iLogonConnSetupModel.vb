'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Interface	iLogonConnSetupModel
		
		#Region "Methods: Exposed"

			Function	CreateDTO()														As iLogonConnSetupDTO
			Function	Fetch()																As iLogonConnSetupDTO
			Function	Save(ByVal	DTO	As iLogonConnSetupDTO)	As Boolean

		#End Region

	End Interface

End Namespace