Imports SAPNCO = SAP.Middleware.Connector

Imports BxS.API.SAPFunctions.Helpers
Imports	BxS.API.SAPFunctions.ZDTON
Imports	BxS.API.SAPFunctions.BDCTransaction
Imports BxS.API.SAPFunctions.MsgComposer
Imports BxS.API.SAPFunctions.Servertime
Imports BxS.API.SAPFunctions.BDCSession
Imports BxS.API.Destination.Repository
Imports BxS.API.Destination
Imports BxS.API.BDC
Imports BxS.API.About

Imports BxS.Destination.Repository
Imports BxS.Destination
Imports BxS.SAPFunctions
Imports BxS.Utilities.Generic

Imports System.Threading
Imports System.Collections.Concurrent

Imports System.Reflection
'Imports xSAPtorNCO.API.Destination
'Imports xSAPtorNCO.API.Destination.Monitor
'Imports xSAPtorNCO.API.SAP.System.Services
'Imports xSAPtorNCO.API.SAP.System.Services.BDCSession
'Imports xSAPtorNCO.API.Services.RfcFunction
'Imports xSAPtorNCO.Internal.BDCTransactionCaller
'Imports xSAPtorNCO.Internal.MessageComposer
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.Main

	Public Class xNCOController
								Implements ixNCOController

		#Region "Definitions"

			Private	ct_SAPFncCntlrs			As	Lazy(Of ConcurrentDictionary(Of String, iBxS_SAPFnc_Controller)) _
																				= New Lazy(Of ConcurrentDictionary(Of String, iBxS_SAPFnc_Controller)) _
																						( Function()	New ConcurrentDictionary(Of String, iBxS_SAPFnc_Controller),
																							LazyThreadSafetyMode.ExecutionAndPublication )

			Private ct_SAPDestinations	As	Lazy(Of ConcurrentDictionary(Of String, iBxSDestination)) _
																				= New Lazy(Of ConcurrentDictionary(Of String, iBxSDestination)) _
																						( Function()	New ConcurrentDictionary(Of String, iBxSDestination),
																							LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_DestCntlr				As Lazy(Of iBxSDestinationController) _
																				= New Lazy(Of iBxSDestinationController) _
																						( Function()	BxSDestinationController.DestinationController(),
																							LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_BxSDestConfig		As iBxSDestinationConfiguration

			Private co_CT								As CancellationToken

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub Finalise() _
									Implements ixNCOController.Finalise

				If Me.co_DestCntlr.IsValueCreated

					Me.co_DestCntlr.Value.UnRegister()
					Me.co_DestCntlr	= Nothing

				End If

			End Sub
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend	Function	AddRfcConfig(ByVal	rfcCfgParameters	As iBxSDestConfig)		As Boolean _
													Implements	ixNCOController.AddRfcConfig

				Dim	lo_RfcCfg	As	SAPNCO.RfcConfigParameters	=	Me.co_DestCntlr.Value.CreateRfcConfigParameters()

				For Each	lo	In	rfcCfgParameters.Parameters
					lo_RfcCfg.Item(lo.Key)	=	lo.Value
				Next

				Return	Me.co_DestCntlr.Value.ModifyRfcConfig(rfcCfgParameters.ID, lo_RfcCfg)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	CreateRfcConfig()	As	iBxSDestConfig _
													Implements	ixNCOController.CreateRfcConfig

				Return	New	BxSDestConfig()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function ConfigureDestinationController(Optional ByVal _fromSAPIni	As Boolean	= True) As Boolean _
												Implements ixNCOController.ConfigureDestinationController

				Dim lb_Ret	As Boolean	= True

				If Me.co_BxSDestConfig Is Nothing
					If _fromSAPIni
						Me.co_BxSDestConfig	= Me.co_DestCntlr.Value.CreateDestinationConfig_FromSAPIni( 
																		SAPNCO.SapLogonIniConfiguration.Create()	)
					Else
						Me.co_BxSDestConfig	= Me.co_DestCntlr.Value.CreateDestinationConfig()
					End If
				End If
				'............................................................
				Try

						Me.co_DestCntlr.Value.Register(Me.co_BxSDestConfig)

					Catch ex As Exception

						lb_Ret	= False		

				End Try

				Return lb_Ret

			End Function


			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function Create_SAPRfcFnc_ServerTime(ByRef destination	As SAPNCO.RfcCustomDestination) _
												As iBxS_SAPServerTime _
													Implements ixNCOController.Create_SAPRfcFnc_ServerTime

				Return New BxS_SAPServerTime(destination:=destination, cancelToken:=Me.co_CT)

			End Function






			'Function GetTmestmpfnc(ByVal Qty As Integer) As List(Of xNCOrfcAppSrvrTimestamp) Implements ixNCOController.GetTmestmpfnc

			'	Dim lt_Tran  As List(Of xNCOrfcAppSrvrTimestamp)  = New List(Of xNCOrfcAppSrvrTimestamp)(capacity:=Qty)

			'	For ln = 1 To Qty

			'		Dim lo_Tran As xNCOrfcAppSrvrTimestamp

			'		lo_Tran = xNCOrfcAppSrvrTimestamp.Create(FunctionName:= xNCOFunctionNames.RfcAppServerTimestamp,
			'																						 RfcFunction := Me.co_SAPDestHndlr.Value.CreateRfcFunction(
			'																														SAPFunctionName:= xNCOFunctionNames.RfcAppServerTimestamp) )
					
			'		lt_Tran.Add(lo_Tran)

			'	Next

			'	Return lt_Tran

			'End Function


			'Function GetBDCTran(ByVal Qty As Integer) As List(Of ixNCOrfcBDCTransaction) Implements ixNCOController.GetBDCTran

			'	Dim lo_RfcParmIdx As iBDCTranCallerParmIndex  = Me.co_SAPDestHndlr.Value.GetRfcParameterIndex(Of BDCTranCallerParmIndex,
			'																																																	 iBDCTranCallerParmIndex)(SAPFunctionName:= xNCOFunctionNames.RfcBDCTranCaller)

			'	Dim lt_Tran  As List(Of ixNCOrfcBDCTransaction)  = New List(Of ixNCOrfcBDCTransaction)(capacity:=Qty)

			'	For ln = 1 To Qty

			'		Dim lo_Tran As ixNCOrfcBDCTransaction	= Nothing

			'		'lo_Tran = xNCOrfcBDCTransaction.Create(FunctionName := xNCOFunctionNames.RfcTransactionCaller,
			'		'																			 RfcParamIndex:= lo_RfcParmIdx,
			'		'																			 RfcFunction  := Me.co_SAPDestHndlr.Value.CreateRfcFunction(
			'		'																														FunctionName:= xNCOFunctionNames.RfcTransactionCaller) )

			'		If lo_Tran IsNot Nothing	
			'			lt_Tran.Add(lo_Tran)
			'		End If

			'	Next

			'	Return lt_Tran

			'End Function









		#End Region


		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: ZDTON"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	GetZDTONTransaction(ByVal rfcDestID	As String) As iBxS_ZDTON _
													Implements ixNCOController.GetZDTONTransaction
			
				Return	Me.GetSAPFncController(rfcDestID).GetZDTON

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: BDC Transaction Handling"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function GetBDCCTU_Parameters()	As iBxS_BDC_CTUParameters _
												Implements ixNCOController.GetBDCCTU_Parameters

				Return New BxS_BDC_CTUParameters()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function GetBDCTransactionJob()	As iBxS_BDCTran_Tran _
												Implements ixNCOController.GetBDCTransactionJob

				Return New BxS_BDCTran_Tran()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function GetBDCTransactionEntry()	As iBxS_BDC_Entry _
												Implements ixNCOController.GetBDCTransactionEntry

				Return New BxS_BDC_Entry()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	GetBDCTransactionCaller(ByVal rfcDestID	As String) As iBxS_BDCTran_Caller _
													Implements ixNCOController.GetBDCTransactionCaller

				Dim lo_BDCTran	As iBxS_BDCTran_Caller	= Me.GetSAPFncController(rfcDestID).GetBDCTransaction()

				lo_BDCTran.CTUParameters	= Me.GetBDCCTU_Parameters()

				Return lo_BDCTran

			End Function





			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Public Function GetBDCTransactionPLC() _
			'									As ixBDCTransactionPLC _
			'										Implements ixNCOController.GetBDCTransactionPLC

			'	Dim lo_NCODestProfile	As ixSAPDestinationProfile	= Me.GetConnectedDestinationProfile()

			'	If lo_NCODestProfile Is Nothing
			'		Return Nothing
			'	Else

			'		lo_NCODestProfile.CreateCustomDestination()

			'		Return xBDCTransactionPLC.Create(NCOController	:= Me,
			'																		 NCODestProfile:= lo_NCODestProfile)

			'	End If
				
			'End Function
			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Public Function GetCallBDCTransaction() _
			'									As ixNCOrfcBDCTransaction _
			'										Implements ixNCOController.GetCallBDCTransaction

			'	Return	xNCOrfcBDCTransaction.Create(	FunctionName	:= xNCOFunctionNames.RfcBDCTranCaller,
			'																				RfcParamIndex	:= Me.co_RfcParmIdxBDCCallTran.Value,
			'																				RfcFunction		:= Me.co_SAPDestHndlr.Value.CreateRfcFunction(SAPFunctionName:= xNCOFunctionNames.RfcBDCTranCaller),
			'																				RfcMsgComposer:= Me.GetMessageComposer()
			'																			)

			'End Function

			'Private co_RfcParmIdxBDCCallTran As Lazy(Of iBDCTranCallerParmIndex) _
			'					= New Lazy(Of iBDCTranCallerParmIndex)(
			'							Function()  Me.co_SAPDestHndlr.Value.GetRfcParameterIndex(Of	BDCTranCallerParmIndex,
			'																																						iBDCTranCallerParmIndex)(SAPFunctionName:= xNCOFunctionNames.RfcBDCTranCaller),
			'													LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region








		#Region "Definitions"

			'Private co_SAPDestHndlr As Lazy(Of ixSAPDestinationHandler) _
			'					= New Lazy(Of ixSAPDestinationHandler)(
			'							Function()  xSAPDestinationHandler.Create(),
			'													LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Session handling"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	SessionList(					ByRef	i_Destination	As iBxSDestination,
																		Optional	ByVal i_UserId      As String  = "*"c,
																		Optional	ByVal i_SessionName	As String  = "*"c,
																		Optional	ByVal i_DateFrom		As Date    = #1999-01-01#,
																		Optional	ByVal i_DateTo			As Date    = #2999-12-31#	) _
													As List(Of iBxSBDCSession_Header)	Implements ixNCOController.SessionList

				Dim lo_BDCSession	As iBxS_BDCSession	= New BxS_BDCSession(i_Destination.RfcDestination)

				Return lo_BDCSession.BDCSessionList(	i_UserId:=			i_UserId,
																							i_SessionName:=	i_SessionName,
																							i_DateFrom:=		i_DateFrom,
																							i_DateTo:=			i_DateTo	)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	SessionProfile(						ByRef	i_Destination	As iBxSDestination,
																									ByVal	i_SessionName	As String,
																									ByVal i_QID					As String,
																				Optional	ByVal	i_OnlyHeader	As Boolean = False	) _
													As iBxSBDCSession_Profile	Implements ixNCOController.SessionProfile

				Dim lo_BDCSession	As iBxS_BDCSession	= New BxS_BDCSession(i_Destination.RfcDestination)

				Return lo_BDCSession.BDCSession(	i_SessionName:=	i_SessionName,
																					i_QID:=					i_QID,
																					i_OnlyHeader:=	i_OnlyHeader	)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function GetSessionProfile()	As iBxSBDCSession_Profile _
												Implements ixNCOController.GetSessionProfile

				Return New BxSBDCSession_Profile

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Destination Handling"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	ConfigureDestination(ByVal config	As iBxSDestConnConfigDTO) _
													As Boolean _
														Implements ixNCOController.ConfigureDestination

				Dim lb_Ret	As Boolean	= False

				

				Return	lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	GetNewConfigDTO(	Optional	ByVal	rfcDestID	As String	= "") _
													As iBxSDestConnConfigDTO _
														Implements ixNCOController.GetNewConfigDTO

				Return	New BxSDestConnConfigDTO(rfcDestID)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function GetDestinationList() _
												As List(Of String) _
													Implements ixNCOController.GetDestinationList

				Return Me.co_DestCntlr.Value.GetDestinationList()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function GetDestination(ByVal rfcDestID	As String) _
												As iBxSDestination _
													Implements ixNCOController.GetDestination

				Dim lo_BxSDest	As iBxSDestination	= Nothing

				If Not Me.ct_SAPDestinations.Value.TryGetValue(rfcDestID, lo_BxSDest)

					lo_BxSDest	= Me.co_DestCntlr.Value.GetDestination(rfcDestID)

					If Not Me.ct_SAPDestinations.Value.TryAdd(rfcDestID, lo_BxSDest)

					End If
				End If

				Return lo_BxSDest

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function GetDestinationParameters(ByVal rfcDestID	As String) _
												As Dictionary(Of String, String) _
													Implements ixNCOController.GetDestinationParameters

				Dim lt_List		As Dictionary(Of String, String)	= New Dictionary(Of String, String)
			
				Try

						If rfcDestID IsNot Nothing

							Dim lo_RfcCng	As SAPNCO.RfcConfigParameters	=	Me.GetDestination(rfcDestID).RfcDestination.Parameters

							For Each lo As KeyValuePair(Of String, String) In lo_RfcCng
								lt_List.Add(lo.Key, lo.Value)					
							Next

						End If

					Catch ex As Exception

				End Try

				Return lt_List

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function GetDestinationSSOStatus(ByVal rfcDestID	As String) _
												As Boolean _
													Implements ixNCOController.GetDestinationSSOStatus

				Dim lb_Ret	As Boolean	= False

				Try

						If rfcDestID IsNot Nothing

							Dim lo_RfcCng	As SAPNCO.RfcConfigParameters	=	Me.GetDestination(rfcDestID).RfcDestination.Parameters

							If lo_RfcCng(SAPNCO.RfcConfigParameters.SncSSO).Equals("1")
								lb_Ret	= True
							End If

						End If

					Catch ex As Exception

				End Try

				Return lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function GetDestinationRepositoryVM() _
												As iBxSDestRepository _
													Implements ixNCOController.GetDestinationRepositoryVM

				Dim lo_Services	As iServicesGeneric	= ServicesGeneric.ServicesGeneric

				Return	New	BxSDestRepository(lo_Services)

			End Function




			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Public Function IsDestinationConnected() _
			'									As Boolean _
			'										Implements ixNCOController.IsDestinationConnected

			'	Return Me.co_SAPDestHndlr.Value.IsConnected()

			'End Function
			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Public Function GetConnectedDestinationProfile() _
			'									As ixSAPDestinationProfile _
			'										Implements ixNCOController.GetConnectedDestinationProfile

			'	Return Me.co_SAPDestHndlr.Value.GetDestinationProfile()

			'End Function
			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Public Function GetDestinationDetails(ByVal DestinationID As String) _
			'									As ixSAPDestinationDetails _
			'										Implements ixNCOController.GetDestinationDetails

			'	Return Me.co_SAPDestHndlr.Value.GetDestinationDetails(DestinationID)

			'End Function
			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Public Function LoadFunctionMetaData(Optional ByVal i_NameList As List(Of String) = Nothing)  _
			'									As Boolean _
			'										Implements ixNCOController.LoadFunctionMetaData

			'	Return Me.co_SAPDestHndlr.Value.PreLoadMetaData(IncludeTableReader   := True,
			'																									IncludeRfcTransaction:= True)

			'End Function
			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Public Function ConnectToDest() _
			'												As Boolean _
			'													Implements ixNCOController.ConnectToDest

			'	If Me.co_SAPDestHndlr.Value.Connect()
			'		Return Me.co_SAPDestHndlr.Value.Ping()
			'	Else
			'		Return False
			'	End If

			'End Function
			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Public Function SetDestinationConfig(ByVal Config  As ixSAPDestinationConfig) _
			'									As Boolean _
			'										Implements ixNCOController.SetDestinationConfig

			'	Return Me.co_SAPDestHndlr.Value.Configure(DestinationConfig:= Config)

			'End Function
			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Public Function GetDestinationLastRequested() _
			'									As ixSAPDestinationConfig _
			'										Implements ixNCOController.GetDestinationLastRequested
			'	Return Me.co_SAPDestHndlr.Value.DestinationRequested()
			'End Function
		
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Other"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function GetMsgComposer(ByVal rfcDestID	As String) _
												As iBxS_SAPMsgComposer _
													Implements ixNCOController.GetMsgComposer

				Return	Me.GetSAPFncController(rfcDestID).GetMsgCompser()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function Get_About()	As iBxSNCOAboutInfo _
												Implements ixNCOController.Get_About

				Return New BxSNCOAboutInfo

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Function	GetSAPFncController(ByVal ID As String)	As iBxS_SAPFnc_Controller

				Dim lo_FncCntlr	As iBxS_SAPFnc_Controller	= Nothing

				If Not Me.ct_SAPFncCntlrs.Value.TryGetValue(ID, lo_FncCntlr)

					lo_FncCntlr	= New BxS_SAPFnc_Controller(Me.GetDestination(ID))

					If Not Me.ct_SAPFncCntlrs.Value.TryAdd(ID, lo_FncCntlr)

					End If

				End If

				Return lo_FncCntlr

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors: Singleton"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Shared ReadOnly _Instance As Lazy(Of ixNCOController) _
																= New Lazy(Of ixNCOController)(
																		Function()  New xNCOController,
																								LazyThreadSafetyMode.ExecutionAndPublication )
			Public	Shared	ReadOnly	Property	NCOController(	Optional	ByVal	useSAPIni	As Boolean	= True) _
																						As ixNCOController
				Get
					If Not _Instance.Value.ConfigureDestinationController(useSAPIni)
					End If
					'................................................
					Return _Instance.Value
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New()
			End Sub

		#End Region

	End Class

End Namespace
