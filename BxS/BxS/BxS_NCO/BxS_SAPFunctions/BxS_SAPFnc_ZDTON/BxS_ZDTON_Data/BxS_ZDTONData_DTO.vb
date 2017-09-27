'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Public	Class	BxS_ZDTONData_DTO
									Implements iBxS_ZDTONData_DTO

		#Region "Properties"

			Friend	Property	User				As String														Implements iBxS_ZDTONData_DTO.User
			Friend	Property	SessionID		As String														Implements iBxS_ZDTONData_DTO.SessionID
			Friend	Property	RowNo				As Integer													Implements iBxS_ZDTONData_DTO.RowNo
			Friend	Property	ExcelRow		As Integer													Implements iBxS_ZDTONData_DTO.ExcelRow
			Friend	Property	DataValues	As Dictionary(Of Integer, String)		Implements iBxS_ZDTONData_DTO.DataValues

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	Reset()	Implements iBxS_ZDTONData_DTO.Reset

				Me.DataValues.Clear()

			End Sub
			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend	Function	ShallowCopy()	As iBxS_ZDTONData_DTO _
			'										Implements iBxS_ZDTONData_DTO.ShallowCopy


			'	'Dim	lo_DTO	= DirectCast(Me.MemberwiseClone(), iBxS_ZDTONData_DTO)

			'	'lo_DTO.
			'	Return	New	BxS_ZDTONData_DTO()

			'End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			Friend	Sub New()

				Me.DataValues	= New Dictionary(Of Integer, String)

			End Sub

		#End Region

	End Class

End Namespace