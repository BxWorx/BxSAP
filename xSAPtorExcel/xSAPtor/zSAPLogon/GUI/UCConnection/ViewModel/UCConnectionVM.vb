Imports System.Windows.Forms
Imports System.Collections.Specialized
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Class	UCConnectionVM
									Implements	iUCConnectionVM

		#Region "Definitions"

			Private	WithEvents	co_UCView		As	UCConnectionView
			Private							co_Model		As	iLogonConnectionModel

			Private	co_DTO					As	iLogonConnectionDTO
			Private	cv_Btns					As	BitVector32
			Private	cb_ReposDirty		As	Boolean
			Private	cc_SysID				As	String

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Events"

			Friend	Event	ev_DataChanged()	Implements	iUCConnectionVM.ev_DataChanged

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"
			
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Property	Datacontext_DTO	As	iLogonConnectionDTO	_
													Implements	iUCConnectionVM.Datacontext_DTO
				Get
					Return	Me.co_DTO
				End Get
			  Set(value As	iLogonConnectionDTO)
					Me.co_DTO	= value
			  End Set
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	ReadOnly	Property	Datacontext_Btn	As	BitVector32	_
																		Implements	iUCConnectionVM.Datacontext_Btn
				Get
					Return	Me.cv_Btns
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	Shutdown() _
										Implements	iUCConnectionVM.Shutdown

				If Me.cb_ReposDirty	Then	Me.co_Model.SaveRepository
				'..................................................
				RemoveHandler	Me.co_UCView.xbtn_ts_New.Click		,	AddressOf	Me.EventHandler_TSBtnClick
				RemoveHandler	Me.co_UCView.xbtn_ts_Save.Click		,	AddressOf	Me.EventHandler_TSBtnClick
				RemoveHandler	Me.co_UCView.xbtn_ts_Edit.Click		,	AddressOf	Me.EventHandler_TSBtnClick
				RemoveHandler	Me.co_UCView.xbtn_ts_Delete.Click	,	AddressOf	Me.EventHandler_TSBtnClick
				RemoveHandler	Me.co_UCView.xbtn_ts_Cancel.Click	,	AddressOf	Me.EventHandler_TSBtnClick

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetConnectionDTO(ByVal _id	As String)	As iLogonConnectionDTO _
													Implements	iUCConnectionVM.GetConnectionDTO

				Return	Me.co_Model.FetchConnection(_id)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	LoadConnection(ByVal _id	As String)	As Boolean _
													Implements	iUCConnectionVM.LoadConnection

				Me.cc_SysID	= _id
				Me.co_DTO		= Me.GetConnectionDTO(Me.cc_SysID)

				Me.cv_Btns	= New BitVector32(0)
				Me.cv_Btns.Item(	UCConnectionView.ce_Btns.btnNew		+
													UCConnectionView.ce_Btns.btnEdit	+
													UCConnectionView.ce_Btns.btnDele		)	= True

				Me.co_DTO.IsNew		=	False
				Me.co_DTO.CanEdit	= False
				'..................................................
				Me.co_UCView.ResfreshEnv()

				Return	True

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetDTOList()	As List(Of iLogonConnectionDTO) _
													Implements	iUCConnectionVM.GetDTOList

				Return	Me.co_Model.Connections.Values.ToList()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetConnectionList()	As List(Of String) _
													Implements	iUCConnectionVM.GetConnectionList

				Return	Me.co_Model.Connections.Keys.ToList()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetUserControl()	As UCConnectionView _
													Implements	iUCConnectionVM.GetUserControl

				Return	Me.co_UCView

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Construction"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub New()

				Me.co_Model		= New LogonConnectionModel()
				Me.co_UCView	= New UCConnectionView(Me)
				'..................................................
				Me.co_DTO		=	Me.co_Model.CreateDTO()
				Me.cv_Btns	= New BitVector32(0)
				'..................................................
				Me.PrepareControl()
				Me.AddHandlers()
				Me.IdleConnection()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Cancel()

				If Me.co_DTO.IsNew
					Me.NewConnection()
				Else
					Me.LoadConnection(Me.cc_SysID)
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub EditConnection()

				Me.cv_Btns	= New BitVector32(0)
				Me.cv_Btns.Item(	UCConnectionView.ce_Btns.btnSave	+
													UCConnectionView.ce_Btns.btnCanc		)	= True
				Me.co_DTO.IsNew		= False
				Me.co_DTO.CanEdit	= True
				'..................................................
				Me.co_UCView.ResfreshEnv()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub DeleteConnection()

				If Me.co_Model.DeleteConnection(Me.co_DTO.ID)

					Me.IdleConnection()
					Me.cb_ReposDirty	= True
					so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone("Connection: Deleted"))
					RaiseEvent	ev_DataChanged

				Else
					so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone("Connection: NOT Deleted"))
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub SaveConnection()

				Dim	lb_Ret	As Boolean

				Me.co_UCView.UpdateDatacontext()
				lb_Ret	= Me.co_Model.Modify(Me.co_DTO)

				If lb_Ret

					Me.cb_ReposDirty	= True
					so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone("Connection: Saved"))
					RaiseEvent	ev_DataChanged
					'..................................................
					Me.cv_Btns	= New BitVector32(0)

					If Me.co_DTO.IsNew

						Me.cv_Btns.Item( UCConnectionView.ce_Btns.btnNew )	= True
						Me.co_DTO.Reset( False, False )

					Else

						Me.cv_Btns.Item(	UCConnectionView.ce_Btns.btnNew		+
															UCConnectionView.ce_Btns.btnEdit	+
															UCConnectionView.ce_Btns.btnDele		)	= True

						Me.co_DTO.CanEdit	= False

					End If

					Me.co_UCView.ResfreshEnv()

				Else
					so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone("Connection: NOT Saved"))
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub IdleConnection()

				Me.cv_Btns	= New BitVector32(0)
				Me.cv_Btns.Item( UCConnectionView.ce_Btns.btnNew )	= True
				Me.co_DTO.Reset( False, False )
				Me.co_UCView.ResfreshEnv()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub NewConnection()

				Me.cv_Btns	= New BitVector32(0)
				Me.cv_Btns.Item( UCConnectionView.ce_Btns.btnCanc )	= True
				Me.co_DTO.Reset( True, True )
				Me.co_UCView.ResfreshEnv()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub EventHandler_TSBtnClick(_sender	As Object,
																					_e			As EventArgs)

				Dim lc_Tag	= TryCast(_sender, ToolStripButton).Tag

				If lc_Tag IsNot Nothing

					Select Case lc_Tag.ToString
						Case "xtag_New"			:	Me.NewConnection()
						Case "xtag_Edit"		:	Me.EditConnection()
						Case "xtag_Save"		:	Me.SaveConnection()
						Case "xtag_Delete"	:	Me.DeleteConnection()
						Case "xtag_Cancel"	:	Me.Cancel()
					End Select

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub PrepareControl()

				Me.co_UCView.Dock				= DockStyle.Fill
				Me.co_UCView.Location		= New Drawing.Point(5, 5)
				Me.co_UCView.Padding		= New Padding(2)
				Me.co_UCView.TabIndex		= 0

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub AddHandlers()

				AddHandler	Me.co_UCView.xbtn_ts_New.Click		,	AddressOf	Me.EventHandler_TSBtnClick
				AddHandler	Me.co_UCView.xbtn_ts_Save.Click		,	AddressOf	Me.EventHandler_TSBtnClick
				AddHandler	Me.co_UCView.xbtn_ts_Edit.Click		,	AddressOf	Me.EventHandler_TSBtnClick
				AddHandler	Me.co_UCView.xbtn_ts_Delete.Click	,	AddressOf	Me.EventHandler_TSBtnClick
				AddHandler	Me.co_UCView.xbtn_ts_Cancel.Click	,	AddressOf	Me.EventHandler_TSBtnClick

			End Sub

		#End Region

	End Class

End Namespace
