'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace	API.Destination
	Public Interface iBxSDestConfig

		#Region "Properties"

			ReadOnly	Property	AppServerHost()					As	String
			ReadOnly	Property	SAPRouter()							As	String
			ReadOnly	Property	SystemID()							As	String
			ReadOnly	Property	SystemNo()							As	String
			ReadOnly	Property	SNCLibraryPath()				As	String
			ReadOnly	Property	SNCMode()								As	String
			ReadOnly	Property	SNCMyName()							As	String
			ReadOnly	Property	SNCPartnerName()				As	String
			ReadOnly	Property	SNCQOP()								As	String
			ReadOnly	Property	SNCSSO()								As	String

			ReadOnly	Property	PeakConnectionLimit			As	String
			ReadOnly	Property	PoolSize								As	String
			ReadOnly	Property	IdleCheckTime						As	String
			ReadOnly	Property  ConnectionIdleTimeout		As	String
			'....................................................
								Property	ID											As	String
			ReadOnly	Property	Parameters()						As	Dictionary(Of	String, String)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function	ModifyParameter(ByVal	ID			As String	,
																ByVal	Value		As String		)		As	Boolean

		#End Region

	End Interface

End Namespace