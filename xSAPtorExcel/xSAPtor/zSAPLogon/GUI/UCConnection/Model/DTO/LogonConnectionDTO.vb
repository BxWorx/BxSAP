'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace	Main.SAPLogon

	Friend	Class	LogonConnectionDTO
									Implements iLogonConnectionDTO

		#Region "Properties"

			Friend	Property	IsNew						As Boolean	Implements iLogonConnectionDTO.IsNew
			Friend	Property	CanEdit					As Boolean	Implements iLogonConnectionDTO.CanEdit
			'......................................................
			Friend	Property	ID							As String		Implements iLogonConnectionDTO.ID
			Public	Property	Name						As String		Implements iLogonConnectionDTO.Name
			Friend	Property	AppServer				As String		Implements iLogonConnectionDTO.AppServer
			Friend	Property	InstanceNo			As Integer	Implements iLogonConnectionDTO.InstanceNo
			Friend	Property	SystemID				As String		Implements iLogonConnectionDTO.SystemID
			Friend	Property	RouterPath			As String		Implements iLogonConnectionDTO.RouterPath
			Friend	Property	SNC_Active			As Boolean	Implements iLogonConnectionDTO.SNC_Active
			Friend	Property	SNC_PartnerName	As String		Implements iLogonConnectionDTO.SNC_PartnerName
			Friend	Property	SNC_UsrPwd			As Boolean	Implements iLogonConnectionDTO.SNC_UsrPwd
			Friend	Property	SNC_QOP					As Integer	Implements iLogonConnectionDTO.SNC_QOP
			Friend	Property	LowSpeed				As Boolean	Implements iLogonConnectionDTO.LowSpeed

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function ShallowCopy()	As iLogonConnectionDTO _
													Implements iLogonConnectionDTO.ShallowCopy

				Return	DirectCast(Me.MemberwiseClone(), iLogonConnectionDTO)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub Reset(Optional	ByVal	_isnew		As	Boolean	=	False	,
												Optional	ByVal	_canedit	As	Boolean	=	False		)	Implements	iLogonConnectionDTO.Reset

				Me.IsNew		=	_isnew
				Me.CanEdit	= _canedit
				'......................................................
				Me.ID								= ""
				Me.Name							= ""
				Me.AppServer				= ""
				Me.SystemID					= ""
				Me.RouterPath				= ""
				Me.SNC_PartnerName	= ""

				Me.InstanceNo				= 0
				Me.SNC_Active				= False
				Me.SNC_UsrPwd				= False
				Me.SNC_QOP					= 0
				Me.LowSpeed					= False

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Construction"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub New()
				Me.Reset()
			End Sub

		#End Region

	End Class

End Namespace