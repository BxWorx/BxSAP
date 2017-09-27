Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports	System.ComponentModel

Imports xSAPtorExcel.UI
Imports xSAPtorExcel.Utilities.MsgHub
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Class	LogonGUIVM
									Implements	iLogonGUIVM

		#Region "Definitions"

			Private	WithEvents	co_View						As LogonGUIView
			Private	WithEvents	co_UCParmVM				As iUCParametersVM
			Private	WithEvents	co_UCConnVM				As iUCConnectionVM

			Private	WithEvents	co_OptionsVM			As	Lazy(Of	iLogonOptionsVM) _
																									= New	Lazy(Of iLogonOptionsVM)(
																											Function()	New LogonOptionsVM()	,
																											LazyThreadSafetyMode.ExecutionAndPublication	)

			Private	WithEvents	co_ConnSetupVM		As	Lazy(Of	iLogonConnSetupVM) _
																									= New	Lazy(Of iLogonConnSetupVM)(
																											Function()	New LogonConnSetupVM()	,
																											LazyThreadSafetyMode.ExecutionAndPublication	)

			Private	WithEvents	co_ConnConfigVM		As	Lazy(Of	iLogonConnConfigVM) _
																									= New	Lazy(Of iLogonConnConfigVM)(
																											Function()	New LogonConnConfigVM()	,
																											LazyThreadSafetyMode.ExecutionAndPublication	)

			Private	WithEvents	co_SapGuiXmlVM		As	Lazy(Of	iSapGuiXmlVM) _
																									= New	Lazy(Of iSapGuiXmlVM)(
																											Function()

																												Dim	lo_Model			As iSapGuiXmlModel				= New SAPGuiXmlModel
																												Dim	lo_ModelConn	As iLogonConnectionModel	= New LogonConnectionModel
																												Dim lo_ConnSetup	As iLogonConnSetupDTO			= Me.co_ConnSetupVM.Value.GetConnSetupDTO

																											  Return New SapGuiXmlVM(	lo_ConnSetup	,
																																								lo_Model			,
																																								lo_ModelConn		)

																											End Function,
																											LazyThreadSafetyMode.ExecutionAndPublication	)

			Private	co_LogonOptionsDTO						As	Lazy(Of	iLogonOptionsDTO) _
																									= New	Lazy(Of iLogonOptionsDTO)(
																											Function()	Me.co_OptionsVM.Value.GetOptionsDTO()	,
																											LazyThreadSafetyMode.ExecutionAndPublication				)
			'....................................................
			Private cc_ActiveSAPID		As String
			Private	co_Context				As SynchronizationContext

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property	ActiveSAPSystemID		As String _
																	Implements	iLogonGUIVM.ActiveSAPSystemID
				Get
					Return	Me.cc_ActiveSAPID
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Async	Function	CheckSAPConnectivityAsync()	As Task(Of Boolean) _
																Implements	iLogonGUIVM.CheckSAPConnectivityAsync

				Dim lo_Notify		= so_NotifyDTO.Value.Clone()
				Dim	lb_Ret			=	Await so_CntlrMain.Value.IsConnectedAsync()
				'..................................................
				If lb_Ret
					lo_Notify.Text = "(Successful)"
				Else
					lo_Notify.Text = "(NOT successful)"
				End If

				lo_Notify.Title	= "SAP Ping... "
				so_MsgHub.Value.Publish(lo_Notify)
				
				Return	lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function CreateLogonSysDTO()		As iLogonSystemDTO _
												Implements	iLogonGUIVM.CreateLogonSysDTO
				Return	Me.co_UCParmVM.CreateLogonSysDTO()
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function SetSAPLogonSystemAsync(ByVal	_sysdto	as iLogonSystemDTO)		As Task(Of Boolean) _
															Implements	iLogonGUIVM.SetSAPLogonSystemAsync

				Dim	lb_Ret	As Boolean	= False

				If Me.RegisterRfcDestConfig(_sysdto.DestinationID)
					If Me.SetActiveDestination(_sysdto)
						If Me.co_LogonOptionsDTO.Value.AutoConnect
							If Await Me.CheckSAPConnectivityAsync()
								' cancellation token
							End If
						End If
					End If
				End If
				'..................................................
				Return	lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub Show()	_
										Implements iLogonGUIVM.Show
			
				If Me.co_View.IsDisposed
					Me.PrepareView()
				End If	
				'..................................................
				If Me.co_View.Visible
					If Me.co_View.WindowState = FormWindowState.Minimized
						Me.co_View.WindowState = FormWindowState.Normal
					Else
						Me.co_View.Hide()
					End If
				Else
					If Me.co_Parent Is Nothing
						Me.co_View.Show()
					Else
						Me.co_View.Show(Me.co_Parent)
					End If
				End If

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Construction"

			Private	co_SubStartStop		As	iSubscription(Of sMsgStartupShutdown)
			Private	co_SubSAPFavSel		As	iSubscription(Of iSAPFavoriteDTO)

			Private	co_Parent					As	IWin32Window
			Private	co_BSSystems			As	BindingSource
			Private	ct_List						As	BindingList(Of SAPSystem)
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub New(Optional _parent	As IWin32Window	= Nothing)

				Me.co_Parent	= _parent
				'..................................................
				Me.PrepareView()
				Me.PrepareOps()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub PrepareOps()

				Me.cc_ActiveSAPID						= ""
				Me.ct_List									=	New	BindingList(Of SAPSystem)
				Me.co_BSSystems							= New BindingSource
				Me.co_BSSystems.DataSource	= Me.ct_List
				'..................................................
				Me.co_SubSAPFavSel	= so_MsgHub.Value.Subscribe(Of iSAPFavoriteDTO)				(AddressOf	Me.mh_SAPLogonFavouriteSelected	, True)
				Me.co_SubStartStop	= so_MsgHub.Value.Subscribe(Of sMsgStartupShutdown)		(AddressOf	Me.mh_StartupShutdown						, True)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub PrepareView()

				Me.co_View	= New LogonGUIView()
				Me.co_Context	= SynchronizationContext.Current

				If Me.co_LogonOptionsDTO.Value.ConfigViewerActive
					Me.co_ConnConfigVM.Value.Show()
				End If

				Me.co_UCParmVM	= New UCParametersVM(Me.co_LogonOptionsDTO.Value)
				Me.co_UCConnVM	= New	UCConnectionVM()

				Me.co_View.xpnl_User.Controls.Add(Me.co_UCParmVM.GetUserControl())
				Me.co_View.xpnl_System.Controls.Add(Me.co_UCConnVM.GetUserControl())

				Me.PrepEventHandlers_Form()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub PrepEventHandlers_Form(	Optional	ByVal	_remove	As	Boolean	= False)

				If _remove

					RemoveHandler	Me.co_View.Load																	,	AddressOf	Me.eh_FormLoad
					RemoveHandler	Me.co_View.FormClosing													,	AddressOf	Me.eh_FormClosing
					RemoveHandler	Me.co_View.KeyDown															,	AddressOf	Me.eh_FormKeydown

				Else

					AddHandler	Me.co_View.Load																	,	AddressOf	Me.eh_FormLoad
					AddHandler	Me.co_View.FormClosing													,	AddressOf	Me.eh_FormClosing
					AddHandler	Me.co_View.KeyDown															,	AddressOf	Me.eh_FormKeydown

				End If

			End Sub

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub PrepEventHandlers_Ops(	Optional	ByVal	_remove	As	Boolean	= False)

				If _remove

					RemoveHandler	Me.co_View.xbtn_ts_SAPSysSelect.Click						,	AddressOf	Me.eh_LogonSystemSelected
					RemoveHandler	Me.co_View.xbtn_ts_SAPSysPing.Click							,	AddressOf	Me.eh_LogonSystemPing
					RemoveHandler	Me.co_View.xbtn_ts_Options.Click								,	AddressOf	Me.eh_OptionsView
					RemoveHandler	Me.co_View.xbtn_ts_ConnSetup.Click							,	AddressOf	Me.eh_ConnectionSetupView
					RemoveHandler	Me.co_View.xbtn_ts_LoadXML.Click								,	AddressOf	Me.eh_SapGuiXMLView
					RemoveHandler	Me.co_View.xdgv_SAPSys.SelectionChanged					,	AddressOf	Me.eh_SelectedSAPSystemChanged

					RemoveHandler	Me.co_UCConnVM.ev_DataChanged										,	AddressOf	Me.eh_ConnectionDataChanged

				Else

					AddHandler	Me.co_View.xbtn_ts_SAPSysSelect.Click						,	AddressOf	Me.eh_LogonSystemSelected
					AddHandler	Me.co_View.xbtn_ts_SAPSysPing.Click							,	AddressOf	Me.eh_LogonSystemPing
					AddHandler	Me.co_View.xbtn_ts_Options.Click								,	AddressOf	Me.eh_OptionsView
					AddHandler	Me.co_View.xbtn_ts_ConnSetup.Click							,	AddressOf	Me.eh_ConnectionSetupView
					AddHandler	Me.co_View.xbtn_ts_LoadXML.Click								,	AddressOf	Me.eh_SapGuiXMLView
					AddHandler	Me.co_View.xdgv_SAPSys.SelectionChanged					,	AddressOf	Me.eh_SelectedSAPSystemChanged

					AddHandler	Me.co_UCConnVM.ev_DataChanged										,	AddressOf	Me.eh_ConnectionDataChanged

				End If

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub mh_StartupShutdown(ByVal _msg As sMsgStartupShutdown)

				If _msg.IsShutdown

					Me.co_Context.Post(
						Sub()

							Me.co_View.Close()
							Me.co_View.Dispose()

						End Sub,	Nothing )
					'................................................
					so_MsgHub.Value.Publish(New mMvvMMsg(MvvMCmd.CloseView))
					so_MsgHub.Value.Unsubscribe(Me.co_SubSAPFavSel)

				Else
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub Notify(ByVal	_saved	As Boolean )

				Dim lo_DTO	= so_NotifyDTO.Value.Clone()

				lo_DTO.Title	= "SAP GUI: Connection setup"
				lo_DTO.Text		= "Changes saved: "

				If _saved
						lo_DTO.Text	+= "OK"
				Else
						lo_DTO.Text	+= "Error"
				End If

				so_MsgHub.Value.Publish(lo_DTO)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub LoadDGVData()

				Me.co_View.SuspendLayout

				Me.ct_List.Clear()

				For Each lo In Me.co_UCConnVM.GetDTOList

					Dim lox	As New SAPSystem

					lox.SAPID	= lo.SystemID
					lox.ID		= lo.ID
					lox.NAME	= lo.Name

					Me.ct_List.Add(lox)

				Next

				Me.co_View.ResumeLayout

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	SetupScreenFromSelection()

				Dim	ln_Row	As	Integer	= -1

				If Me.co_View.xdgv_SAPSys.CurrentRow IsNot Nothing
					ln_Row =	Me.co_View.xdgv_SAPSys.CurrentRow.Index
				End If

				If ln_Row >= 0

					Me.cc_ActiveSAPID = Me.co_View.xdgv_SAPSys.Item(2,ln_Row).Value.ToString

					Me.co_UCConnVM.LoadConnection(Me.cc_ActiveSAPID)
					Me.co_UCParmVM.SetConnection(Me.co_UCConnVM.Datacontext_DTO)
					Me.co_UCParmVM.LoadSystem(Me.cc_ActiveSAPID)

				Else
					Me.cc_ActiveSAPID	= ""
				End If

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Event Handlers"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub mh_SAPLogonFavouriteSelected(ByVal _msg	As iSAPFavoriteDTO)

				If Me.cc_ActiveSAPID	= _msg.RfcDestID

				Else

					Dim lo_SysDTO	= Me.CreateLogonSysDTO()

					lo_SysDTO.DestinationID	= _msg.RfcDestID
					lo_SysDTO.Language			= _msg.Language
					lo_SysDTO.Client				= _msg.Client
					lo_SysDTO.UserName			= _msg.User
					lo_SysDTO.Password			= _msg.Password

					If Me.RegisterRfcDestConfig(lo_SysDTO.DestinationID)
						If Me.SetActiveDestination(lo_SysDTO)

							Me.cc_ActiveSAPID	= _msg.RfcDestID

							If Me.co_LogonOptionsDTO.Value.AutoConnect
								If Await Me.CheckSAPConnectivityAsync()
									' cancellation token
								End If
							End If

						End If
					End If

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Async	Sub	eh_LogonSystemPing(	_sender	As Object	,	_e	As EventArgs)

				If Await Me.CheckSAPConnectivityAsync()
					' cancellation token
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async	Sub	eh_LogonSystemSelected(	_sender	As Object,	_e	As	EventArgs)
				
				Dim lo_ConnDTO	=	Me.co_UCConnVM.GetConnectionDTO(Me.cc_ActiveSAPID)
				Dim	lo_UserDTO	= Me.co_UCParmVM.GetCurrentLogonParameters()

				lo_UserDTO.SystemID		= lo_ConnDTO.SystemID
				lo_UserDTO.SystemName	= lo_ConnDTO.Name

				If Me.RegisterRfcDestConfig(Me.cc_ActiveSAPID)
					If Me.SetActiveDestination(lo_UserDTO)

						Me.co_View.xtbx_ts_SAPSys.Text	=	String.Format("{0}/{1}: {2}", lo_ConnDTO.SystemID, lo_UserDTO.Client.ToString, lo_UserDTO.UserName)

						If Me.co_LogonOptionsDTO.Value.AutoConnect
							If Await Me.CheckSAPConnectivityAsync()
								' cancellation token
							End If
						End If
					End If
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Function SetActiveDestination(ByVal _rfcparm	As	iLogonSystemDTO)	As Boolean

				Dim lo_Notify		= so_NotifyDTO.Value.Clone()
				Dim lb_Ret			= so_CntlrMain.Value.SetActiveDestination(_rfcparm)

				If lb_Ret

					lo_Notify.Title	= "(Active)"
					so_MsgHub.Value.Publish(_rfcparm)

				Else
					lo_Notify.Title = "(Not-Active)"
				End If

				lo_Notify.Title	= "SAP Logon" & lo_Notify.Title
				lo_Notify.Text	= String.Format("{0}: {1}\{2}", _rfcparm.SystemName, _rfcparm.Client, _rfcparm.UserName)

				so_MsgHub.Value.Publish(lo_Notify)
				'..................................................
				Return	lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Function	RegisterRfcDestConfig(ByVal	_id	As	String)		As Boolean

				'// connection string with SNC parameters and debug
				'string ConnStr = "ashost=pcintel11 client=000 snc_mode=1 sysnr=00 type=3 user=SAPDOTNET snc_partnername=\"p:SAPServiceCS2@nt5.sap-ag.de\";

				Dim lo_ConnDTO		= Me.co_UCConnVM.GetConnectionDTO(_id)

				If IsNothing(lo_ConnDTO)	Then	Return	False

				Dim	lb_Ret				= False
				Dim lo_RfcSetup		= Me.co_ConnSetupVM.Value.GetConnSetupDTO()
				Dim lo_RfcCfg			=	so_CntlrNCO.Value.CreateRfcConfig()
				Dim lc_SSO				= "0"
				Dim lc_SNC				= "0"
				'..................................................
				lo_RfcCfg.ID		=	_id

				If lo_ConnDTO.SNC_Active

					lc_SNC	= "1"

					If Not lo_ConnDTO.SNC_UsrPwd
						lc_SSO	= "1"
					End If

				End If
				'..................................................
				lo_RfcCfg.ModifyParameter(	lo_RfcCfg.AppServerHost		,	lo_ConnDTO.AppServer	)
				lo_RfcCfg.ModifyParameter(	lo_RfcCfg.SAPRouter				,	lo_ConnDTO.RouterPath	)
				lo_RfcCfg.ModifyParameter(	lo_RfcCfg.SystemNo				,	lo_ConnDTO.InstanceNo.ToString	)
				lo_RfcCfg.ModifyParameter(	lo_RfcCfg.SystemID				,	lo_ConnDTO.SystemID	)

				If lo_ConnDTO.SNC_Active

					lo_RfcCfg.ModifyParameter(	lo_RfcCfg.SNCPartnerName	,	lo_ConnDTO.SNC_PartnerName	)

					lo_RfcCfg.ModifyParameter(	lo_RfcCfg.SNCMode					,	lc_SNC	)
					lo_RfcCfg.ModifyParameter(	lo_RfcCfg.SNCSSO					,	lc_SSO	)
					lo_RfcCfg.ModifyParameter(	lo_RfcCfg.SNCQOP					,	lo_ConnDTO.SNC_QOP.ToString	)

					Dim lc_SNCLibPath As String	= ""

					If Environment.Is64BitProcess
						lc_SNCLibPath = System.IO.Path.Combine(lo_RfcSetup.SNC_LibPath, lo_RfcSetup.SNC_LibName64)
					Else
						lc_SNCLibPath = System.IO.Path.Combine(lo_RfcSetup.SNC_LibPath, lo_RfcSetup.SNC_LibName32)
					End If

					lo_RfcCfg.ModifyParameter( lo_RfcCfg.SNCLibraryPath	, lc_SNCLibPath )
		
				End If
				'..................................................
				If lo_RfcSetup.UseManual

					lo_RfcCfg.ModifyParameter(	lo_RfcCfg.ConnectionIdleTimeout	,	lo_RfcSetup.ConnectionIdleTimeout.ToString	)
					lo_RfcCfg.ModifyParameter(	lo_RfcCfg.IdleCheckTime					,	lo_RfcSetup.IdleCheckTime.ToString	)
					lo_RfcCfg.ModifyParameter(	lo_RfcCfg.PeakConnectionLimit		,	lo_RfcSetup.PeakConnectionLimit.ToString	)
					lo_RfcCfg.ModifyParameter(	lo_RfcCfg.PoolSize							,	lo_RfcSetup.PoolSize.ToString	)

				End If
				'..................................................
				'..................................................
				If lo_RfcCfg IsNot Nothing
					If so_CntlrNCO.Value.AddRfcConfig(lo_RfcCfg)
						so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone(String.Format("[{0}] System registered", lo_RfcCfg.ID)))
						lb_Ret	= True
					Else
						so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone(String.Format("[{0}] System FAILED registration", lo_RfcCfg.ID)))
					End If
				Else
					so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone(String.Format("[{0}] System Added", lo_RfcCfg.ID)))
				End If
				'..................................................
				Return	lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	eh_ConnectionDataChanged()
				Me.LoadDGVData()
			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub eh_SelectedSAPSystemChanged(_sender As Object,	_e	As EventArgs)
				Me.SetupScreenFromSelection()
			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	eh_SapGuiXMLView(sender As Object, e As EventArgs)
				Me.co_SapGuiXmlVM.Value.Show()
			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub eh_OptionsView(sender As Object, e As EventArgs)
				Me.co_OptionsVM.Value.Show()
			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub eh_ConnectionSetupView(sender As Object, e As EventArgs) 
				Me.co_ConnSetupVM.Value.Show()
			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub eh_FormKeydown(	sender As Object,	e	As KeyEventArgs)
				If e.KeyCode.Equals(Keys.Escape)	Then	Me.co_View.Close()
			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub eh_FormLoad(	sender As Object,	e	As EventArgs)

				Me.co_View.xdgv_SAPSys.AutoGenerateColumns	= False
				Me.co_View.xdgv_SAPSys.DataSource						= Me.co_BSSystems

				Me.LoadDGVData()
				Me.PrepEventHandlers_Ops()
				Me.SetupScreenFromSelection()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub eh_FormClosing(	sender As Object,	e	As EventArgs)

				so_MsgHub.Value.Unsubscribe(Me.co_SubStartStop)
				Me.PrepEventHandlers_Ops(True)
				so_MsgHub.Value.Publish(New mMvvMMsg(MvvMCmd.CloseView))
				
				If Me.co_OptionsVM.IsValueCreated
					Me.co_OptionsVM.Value.Shutdown()
				End If
				'..................................................
				If Me.co_ConnSetupVM.IsValueCreated
					Me.co_ConnSetupVM.Value.Shutdown()
				End If
				'..................................................
				If Me.co_ConnConfigVM.IsValueCreated
					Me.co_ConnConfigVM.Value.Shutdown()
				End If
				'..................................................
				Me.co_UCConnVM.Shutdown()
				Me.co_UCParmVM.Shutdown()

				Me.PrepEventHandlers_Form(True)

			End Sub

		#End Region

		'°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°
		'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••

		#Region "Private Classes"

			Private	Class	SAPSystem

				Public	Property	ID()			As String
				Public	Property	SAPID()		As	String
				Public  Property  NAME()		As String

			End Class

		#End Region

	End Class

End Namespace

