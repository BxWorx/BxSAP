'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Public	Class	BxS_ZDTONMsgs_DTO
									Implements iBxS_ZDTONMsgs_DTO

		#Region "Properties"

			Friend	Property	Rowno				As Integer		Implements iBxS_ZDTONMsgs_DTO.Rowno
			Friend	Property	Status			As String			Implements iBxS_ZDTONMsgs_DTO.Status
			Friend	Property	Message			As String			Implements iBxS_ZDTONMsgs_DTO.Message
			Friend	Property	ExcelRow		As Integer		Implements iBxS_ZDTONMsgs_DTO.ExcelRow
			Friend	Property	MsgDate			As String			Implements iBxS_ZDTONMsgs_DTO.MsgDate
			Friend	Property	MsgTime			As String			Implements iBxS_ZDTONMsgs_DTO.MsgTime

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	ShallowCopy()	As iBxS_ZDTONMsgs_DTO _
													Implements iBxS_ZDTONMsgs_DTO.ShallowCopy

				Return DirectCast( Me.MemberwiseClone(),	iBxS_ZDTONMsgs_DTO )

			End Function

		#End Region

	End Class

End Namespace