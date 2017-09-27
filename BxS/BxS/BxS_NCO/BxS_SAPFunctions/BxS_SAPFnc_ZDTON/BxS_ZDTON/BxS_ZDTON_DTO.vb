Imports BxS.SAPFunctions.ZDTON
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.ZDTON

	Friend	Class	BxS_ZDTON_DTO
									Implements 	iBxS_ZDTON_DTO

		#Region "Definitions"

			'Private	co_ColDTO		As iBxS_ZDTONColumns_DTO
			'Private	co_DataDTO	As iBxS_ZDTONData_DTO

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			Friend	Property	User			As String																				Implements iBxS_ZDTON_DTO.User
			Friend	Property	SessionID	As String																				Implements iBxS_ZDTON_DTO.SessionID
			Friend	Property	SAPTCode	As String																				Implements iBxS_ZDTON_DTO.SAPTCode
			Friend	Property	Tally			As Integer																			Implements iBxS_ZDTON_DTO.Tally
			Friend	Property  Columns() As List(Of iBxS_ZDTONColumns_DTO)								Implements iBxS_ZDTON_DTO.Columns
			Friend	Property  Data()		As Dictionary(Of Integer, iBxS_ZDTONData_DTO)		Implements iBxS_ZDTON_DTO.Data
			Friend	Property  Msgs()		As Dictionary(Of Integer, iBxS_ZDTONMsgs_DTO)		Implements iBxS_ZDTON_DTO.Msgs

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend  Sub	Reset() Implements iBxS_ZDTON_DTO.Reset
				
				Me.Columns.Clear()
				Me.Data.Clear()
				Me.Msgs.Clear()

				Me.Tally			= 0
				Me.User				= ""
				Me.SessionID	= ""
				Me.SAPTCode		= ""

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateColumnDTO()	As iBxS_ZDTONColumns_DTO _
													Implements iBxS_ZDTON_DTO.CreateColumnDTO

				Return	New	BxS_ZDTONColumns_DTO()
				'Return	Me.co_ColDTO.ShallowCopy()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateDataDTO()		As iBxS_ZDTONData_DTO _
													Implements iBxS_ZDTON_DTO.CreateDataDTO

				Return	New	BxS_ZDTONData_DTO()
				'Return	Me.co_DataDTO.ShallowCopy()

			End Function
			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend	Function	ShallowCopy()		As iBxS_ZDTON_DTO _
			'										Implements iBxS_ZDTON_DTO.ShallowCopy

			'	Return DirectCast(Me.MemberwiseClone(), iBxS_ZDTON_DTO)

			'End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"
			
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	New()

				Me.Columns		= New List(Of iBxS_ZDTONColumns_DTO)
				Me.Data				=	New Dictionary(Of Integer, iBxS_ZDTONData_DTO)
				Me.Msgs				=	New Dictionary(Of Integer, iBxS_ZDTONMsgs_DTO)

				'Me.co_ColDTO	= New	BxS_ZDTONColumns_DTO
				'Me.co_DataDTO	= New	BxS_ZDTONData_DTO

				Me.Reset()

			End Sub

		#End Region

	End Class

End Namespace