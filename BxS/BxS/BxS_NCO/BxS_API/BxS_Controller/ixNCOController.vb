Imports SAPNCO = SAP.Middleware.Connector

Imports	BxS.API.SAPFunctions.ZDTON
Imports	BxS.API.SAPFunctions.BDCTransaction
Imports BxS.API.SAPFunctions.MsgComposer
Imports BxS.API.SAPFunctions.Servertime
Imports BxS.API.Destination.Repository
Imports BxS.API.Destination
Imports BxS.API.About
Imports BxS.API.BDC

'Imports xSAPtorNCO.API.Destination.Monitor
'Imports xSAPtorNCO.API.SAP.System.Services
'Imports xSAPtorNCO.API.Services.RfcFunction
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.Main

	Public Interface ixNCOController

		Sub Finalise()

		Function Create_SAPRfcFnc_ServerTime(ByRef destination	As SAPNCO.RfcCustomDestination)	As iBxS_SAPServerTime

		'Function GetBDCTran(ByVal Qty As Integer)     As List(Of ixNCOrfcBDCTransaction)
		'Function GetTmestmpfnc(ByVal Qty As Integer)  As List(Of xNCOrfcAppSrvrTimestamp)




		#Region "Methods: ZDTON"

			Function	GetZDTONTransaction(ByVal rfcDestID	As String)	As iBxS_ZDTON

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: BDC Transaction Handling"

			'Function GetBDCTransactionPLC()		As ixBDCTransactionPLC

			Function	GetBDCTransactionEntry()														As iBxS_BDC_Entry
			Function	GetBDCTransactionJob()															As iBxS_BDCTran_Tran
			Function	GetBDCTransactionCaller(ByVal rfcDestID	As String)	As iBxS_BDCTran_Caller
			Function	GetBDCCTU_Parameters()															As iBxS_BDC_CTUParameters

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Session Handling"

			Function	SessionList(						ByRef	i_Destination	As iBxSDestination,
															Optional	ByVal i_UserId      As String  = "*"c,
															Optional	ByVal i_SessionName	As String  = "*"c,
															Optional	ByVal i_DateFrom		As Date    = #1999-01-01#,
															Optional	ByVal i_DateTo			As Date    = #2999-12-31# )	As List(Of iBxSBDCSession_Header)

			Function	SessionProfile(						ByRef	i_Destination	As iBxSDestination,
																					ByVal	i_SessionName	As String,
																					ByVal i_QID					As String,
																Optional	ByVal	i_OnlyHeader	As Boolean = False	) As iBxSBDCSession_Profile

			Function GetSessionProfile()	As iBxSBDCSession_Profile

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Destination Handling"

			'Function IsDestinationConnected()                                                     As Boolean
			'Function GetConnectedDestinationProfile()                                             As ixSAPDestinationProfile
			'Function LoadFunctionMetaData(Optional ByVal i_NameList As List(Of String) = Nothing) As Boolean
			'Function ConnectToDest()                                                              As Boolean
			'Function SetDestinationConfig(ByVal Config  As ixSAPDestinationConfig)                As Boolean
			'Function GetDestinationDetails(ByVal DestinationID As String)                         As ixSAPDestinationDetails
			'Function GetDestinationLastRequested()																								As ixSAPDestinationConfig



			Function	GetDestinationRepositoryVM()															As iBxSDestRepository

			Function GetNewConfigDTO(	Optional	ByVal	rfcDestID	As String = "")	As iBxSDestConnConfigDTO
			Function ConfigureDestination(ByVal	config	As iBxSDestConnConfigDTO)					As Boolean
			Function ConfigureDestinationController(Optional ByVal FromSAPini	As Boolean	= True)		As Boolean
			Function GetDestinationList()																				As List(Of String)
			Function GetDestination(ByVal rfcDestID	As String)									As iBxSDestination
			Function GetDestinationParameters(ByVal rfcDestID	As String)				As Dictionary(Of String, String)
			Function GetDestinationSSOStatus(ByVal rfcDestID	As String)				As Boolean


			Function	AddRfcConfig(ByVal	rfcCfgParameters	As	iBxSDestConfig)	As Boolean
			Function	CreateRfcConfig()																					As	iBxSDestConfig

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Other"

			Function GetMsgComposer(ByVal rfcDestID	As String)						As iBxS_SAPMsgComposer
			Function Get_About()						As iBxSNCOAboutInfo

		#End Region

	End Interface

End Namespace