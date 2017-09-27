Imports BxS.SAPFunctions.ZDTON
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.DDIC

	Public Interface iBxS_DDICInfoFields_DTO

		#Region "Properties"
		
			' property <NAME> is used as reference to extract from SAP Data
			' so must match fieldname in SAP structure DFIES

			Property	TabName			As String
			Property  FieldName		As String
			Property  FieldText		As String
			Property	RepText			As String
			Property	ScrText_S		As String
			Property  ScrText_M		As String
			Property	ScrText_L		As String
			Property  LowerCase		As Boolean

		#End Region

	End Interface

End Namespace