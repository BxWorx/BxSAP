Imports System.Threading
Imports System.Threading.Tasks

'Imports xSAPtorExcel.Main.Config
Imports xSAPtorExcel.Main.Notification.Icon
Imports xSAPtorExcel.Services.Utilities.Generic

Imports	BxS.API.Main
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	'°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°
	#Region "Project Wide Definitions"

		Friend Delegate Sub EventHandler_SysIDSelected(ByVal sender As Object,
																									 ByVal e      As xSAPLogonUserEventArgs)

	#End Region
	'°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°
	Friend Class xSAPLogonController
								Implements ixSAPLogonController

		#Region "Defintions"

			'Private	co_CntlrMain		As	iBxSMainController

			'Private	co_CntlrNotify	As	Lazy(Of ixNotificationIconVM) _
			'															= New Lazy(Of ixNotificationIconVM)(
			'																	Function()	Me.co_CntlrMain.GetNotificationController(),
			'																	LazyThreadSafetyMode.ExecutionAndPublication	)


			'Private	co_Services			As	Lazy(Of iServicesGeneric) _
			'															= New Lazy(Of iServicesGeneric)(
			'																	Function()	Me.co_CntlrMain.GetServicesGeneric(),
			'																	LazyThreadSafetyMode.ExecutionAndPublication	)





			'Private	WithEvents	co_CntlrNCO			As	Lazy(Of ixNCOController) _
			'																					= New Lazy(Of ixNCOController)(
			'																							Function()	Me.co_CntlrMain.GetNCOController(),
			'																							LazyThreadSafetyMode.ExecutionAndPublication)
					
			'Private	WithEvents	co_CntlrCfg			As	Lazy(Of ixSAPConfigController) _
			'																					= New Lazy(Of ixSAPConfigController)(
			'																							Function()	Me.co_CntlrMain.GetConfigController(),
			'																							LazyThreadSafetyMode.ExecutionAndPublication)

			Private	WithEvents	co_LogonGUIVM		As	Lazy(Of iLogonGUIVM) _
																								= New Lazy(Of iLogonGUIVM)(
																										Function()	New	LogonGUIVM(),
																										LazyThreadSafetyMode.ExecutionAndPublication)

			Private	Event	ev_SAPSystemSelected	As EventHandler_SysIDSelected

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Events"

			Friend	Event	ev_SAPSystemSelectedx(	ByVal	eventArgs	As xSAPLogonUserEventArgs)	Implements ixSAPLogonController.ev_SAPSystemSelected
			Friend	Event ev_ConnectionStatus(	ByVal status	As Boolean	)										Implements ixSAPLogonController.ev_ConnectionStatus

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Destination"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetDestinationList() _
												As List(Of String) _
													Implements ixSAPLogonController.GetDestinationList

				Dim lt_List As List(Of String)  = so_CntlrNCO.Value.GetDestinationList()

				Return lt_List

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetDestinationParameters(ByVal DestinationID As String) _
												As Dictionary(Of String, String) _
													Implements ixSAPLogonController.GetDestinationParameters

				Return so_CntlrNCO.Value.GetDestinationParameters(DestinationID)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetDestinationSSO(ByVal DestinationID As String) _
												As Boolean _
													Implements ixSAPLogonController.GetDestinationSSO

				Return so_CntlrNCO.Value.GetDestinationSSOStatus(DestinationID)

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Connection Setup"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Options"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Logon"


			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function CreateLogonSysDTO()		As iLogonSystemDTO _
												Implements	ixSAPLogonController.CreateLogonSysDTO

				Return	Me.co_LogonGUIVM.Value.CreateLogonSysDTO()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function SetSAPLogonSystem(ByVal	_sysdto	as iLogonSystemDTO)		As Task(Of Boolean) _
															Implements	ixSAPLogonController.SetSAPLogonSystem

				Return	Await	Me.co_LogonGUIVM.Value.SetSAPLogonSystemAsync(_sysdto)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function FetchLogonConfig() _
												As iSysReposDTO _
													Implements ixSAPLogonController.FetchLogonConfig

				'Return Me.co_CntlrCfg.Value.FetchLogonConfiguration()
				Return	Nothing
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function SaveLogonConfig(ByVal i_SAPLogonConfig As iSysReposDTO) _
												As Boolean _
													Implements ixSAPLogonController.SaveLogonConfig

				'Return Me.co_CntlrCfg.Value.SaveLogonConfiguration(i_SAPLogonConfig)
				Return	Nothing
			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: General"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function CreateSapGuiXMLModel()	As iSapGuiXmlModel _
												Implements	ixSAPLogonController.CreateSapGuiXMLModel

				Return	New SAPGuiXmlModel

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function ActiveSystem()	As String _
												Implements	ixSAPLogonController.ActiveSystem

				Return	Me.co_LogonGUIVM.Value.ActiveSAPSystemID

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function IsSystemSelected()	As Boolean _
												Implements	ixSAPLogonController.IsSystemSelected

				Return	String.IsNullOrEmpty(Me.co_LogonGUIVM.Value.ActiveSAPSystemID)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub SAPSystemSelected_EventHandler(ByVal sender As Object,
																								ByVal e      As xSAPLogonUserEventArgs) _
									Implements ixSAPLogonController.SAPSystemSelected_EventHandler

				RaiseEvent	ev_SAPSystemSelectedx(e)

					'RaiseEvent  ev_SAPSystemSelected(sender := Me,
					'																 e      := e)

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"




			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend Async Function LoadFunctionMetaDataAsync(Optional ByVal i_NameList As List(Of String) = Nothing)  _
			'												As Task(Of Boolean) _
			'													Implements ixSAPLogonController.LoadFunctionMetaDataAsync

				'Return	Await Task.Run(Of Boolean)(
				'								Function()
				'									Return Me.co_CntlrNCO.LoadFunctionMetaData(i_NameList:=i_NameList)
				'								End Function)

			'End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend Async Function ConnectToDestAsync() _
			'												As Task(Of Boolean) _
			'													Implements ixSAPLogonController.ConnectToDestAsync

			'	Dim lo_Notify		As iNotificationMessageDTO	= New NotificationMessageDTO

			'	Dim lc_Msg			As String
			'	Dim	lb_Ret			As Boolean
				'Dim lo_DestCfg	As ixSAPDestinationConfig

				'lb_Ret					= Await Task.Run(Of Boolean)(
				'										Function()
				'											Return Me.co_CntlrNCO.ConnectToDest()
				'										End Function)

				'lo_DestCfg			= Me.co_CntlrNCO.GetDestinationLastRequested()

				'If lb_Ret

				'	lo_Notify.Type	= lo_Notify.TypeInfo
				'	lc_Msg					= "Successfully logged onto"

				'Else

				'	lo_Notify.Type	= lo_Notify.TypeError
				'	lc_Msg					= "Could not logon to"

				'End If

				'lo_Notify.Title	= "SAP Logon"
				'lo_Notify.Text	= String.Format("{0}: {1}\{2}", lc_Msg, lo_DestCfg.Client, lo_DestCfg.UserName )

				'Me.co_CntrlNotify.SendMessage(Notification:= lo_Notify)

			'	Return lb_Ret
				
			'End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend Function SetDestinationConfig(ByVal i_SAPLogonEventArgs  As xSAPLogonUserEventArgs) _
			'									As Boolean _
			'										Implements ixSAPLogonController.SetDestinationConfig

				'Dim lo_DestCfg As ixSAPDestinationConfig  = New xSAPDestinationConfig

				'lo_DestCfg.DestinationID = i_SAPLogonEventArgs.SAPSystemID
				'lo_DestCfg.Client        = i_SAPLogonEventArgs.ClientNo
				'lo_DestCfg.UserName      = i_SAPLogonEventArgs.UserName
				'lo_DestCfg.Password      = i_SAPLogonEventArgs.Password
				'lo_DestCfg.Language      = i_SAPLogonEventArgs.Language

				'Return Me.co_CntlrNCO.SetDestinationConfig(Config:= lo_DestCfg)

			'End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Private Sub SysIDSelected_EventHandler(	ByVal sender As Object,
			'																				ByVal e      As xSAPLogonUserEventArgs)

			'	Dim lo_LogonCfg	As iLogonSystemDTO					= New LogonSystemDTO()
			'	Dim lo_Notify		As iNotificationMessageDTO	= so_NotifyDTO.Value.ShallowCopy()

			'	lo_LogonCfg.DestinationID	= e.SAPSystemID
			'	lo_LogonCfg.Client				= e.ClientNo
			'	lo_LogonCfg.UserName			= e.UserName
			'	lo_LogonCfg.Password			= e.Password
			'	lo_LogonCfg.Language			= e.Language

			'	If so_CntlrMain.Value.SetActiveDestination(lo_LogonCfg)
			'		lo_Notify.Title = "(Active)"
			'	Else
			'		lo_Notify.Title = "(Not-Active)"
			'	End If

			'	lo_Notify.Title	= "SAP Logon" & lo_Notify.Title
			'	lo_Notify.Text	= String.Format("{0}: {1}\{2}", lo_LogonCfg.DestinationID, lo_LogonCfg.Client, lo_LogonCfg.UserName)

			'	so_MsgHub.Value.Publish(lo_Notify)



			'If Me.SetDestinationConfig(i_SAPLogonEventArgs:= e)

			'	If Await Me.ConnectToDestAsync()

			'		If Await Me.LoadFunctionMetaDataAsync()
			'			'TO-DO: Log entry
			'		Else
			'			'TO-DO: Log entry
			'		End If

			'	Else
			'		'TO-DO: Log entry
			'	End If

			'End If

		'End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Ribbon Event Handling"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub RibbonEventHandler(ByVal i_Tag As String) _
									Implements ixSAPLogonController.RibbonEventHandler

				Select Case i_Tag

					Case "xtag_SelectSAP"		: Me.RibbonEventHandler_SAPLogonView()
					Case "xtag_SAPConnect"	:	Me.RibbonEventHandler_LogonConnect()

				End Select

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_SAPLogonView()

				Me.co_LogonGUIVM.Value.Show()
				
			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub RibbonEventHandler_LogonConnect()

				If Await Me.co_LogonGUIVM.Value.CheckSAPConnectivityAsync()

				End If

				'Dim lo_Notify		= so_NotifyDTO.Value.ShallowCopy()

				'If Me.IsSystemSelected
				'	If Await so_CntlrMain.Value.IsConnectedAsync()
				'		lo_Notify.Text = "(Active)"
				'	Else
				'		lo_Notify.Text = "(Not-Active)"
				'	End If
				'Else
				'	lo_Notify.Text = "(Not-Active)"
				'End If
				''..................................................
				'lo_Notify.Title	= "SAP Ping... "
				'so_MsgHub.Value.Publish(lo_Notify)

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub	New()

				'Me.co_CntlrMain	= controller

				'AddHandler  Me.ev_SAPSystemSelected,
				'						AddressOf Me.SysIDSelected_EventHandler

			End Sub

		#End Region

	End Class

End Namespace