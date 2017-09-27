'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Public	Class	BxS_ZDTONColumns_DTO
									Implements iBxS_ZDTONColumns_DTO

		#Region "Properties"

			Friend	Property	Columno				As Integer	Implements iBxS_ZDTONColumns_DTO.Columno
			Friend	Property	ProgName			As String		Implements iBxS_ZDTONColumns_DTO.ProgName
			Friend	Property	ScreenNo			As Integer	Implements iBxS_ZDTONColumns_DTO.ScreenNo
			Friend	Property	DynproStart		As String		Implements iBxS_ZDTONColumns_DTO.DynproStart
			Friend	Property	BDCOKCode			As String		Implements iBxS_ZDTONColumns_DTO.BDCOKCode
			Friend	Property	BDCCursor			As String		Implements iBxS_ZDTONColumns_DTO.BDCCursor
			Friend	Property  BDCSubScreen	As String		Implements iBxS_ZDTONColumns_DTO.BDCSubScreen
			Friend	Property	FieldName			As String		Implements iBxS_ZDTONColumns_DTO.FieldName
			Friend	Property	FieldDesc			As String		Implements iBxS_ZDTONColumns_DTO.FieldDesc
			Friend	Property	SpecInstr			As String		Implements iBxS_ZDTONColumns_DTO.SpecInstr

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend	Function	ShallowCopy()	As iBxS_ZDTONColumns_DTO _
			'										Implements iBxS_ZDTONColumns_DTO.ShallowCopy

			'	Return	New	BxS_ZDTONColumns_DTO()

			'	'Return DirectCast(Me.MemberwiseClone(), iBxS_ZDTONColumns_DTO)

			'End Function

		#End Region

	End Class

End Namespace