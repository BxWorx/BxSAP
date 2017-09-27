Imports SAPNCO = SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace	API.Destination

	Public Interface iBxSDestination

		#Region "Properties"

			ReadOnly	Property	RfcDestID						As	String
			ReadOnly	Property	RfcDestination()		As	SAPNCO.RfcCustomDestination
			ReadOnly	Property	RfcUser							As	String

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function	GetMonitorData()		As List(Of iBxSDestMonitorDTO)
			Function	Ping()							As Boolean
			Function	Configure(					ByVal Client			As String,
																		ByVal User				As String,
																		ByVal Password		As String,
													Optional  ByVal Langauge		As String		= "EN",
													Optional	ByVal	useSAPGUI		As Boolean	= False )		As Boolean

		#End Region

	End Interface

End Namespace
