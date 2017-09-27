Imports System.Windows.Forms
Imports System.Collections.Specialized
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Class	UCParametersVM
									Implements	iUCParametersVM

		#Region "Definitions"

			Private	cc_ID						As	String

			Private	cc_Lang					As	String
			Private	cc_Clnt					As	String
			Private	cc_User					As	String
			Private	cc_PWrd					As	String

			Private	co_ConnDTO			As	iLogonConnectionDTO
			Private	co_SystDTO			As	iSysReposSystemDTO
			Private	co_ClntDTO			As	iSysReposClientDTO
			Private	co_UserDTO			As	iSysReposUserDTO

			Private	cb_RepDirty			As	Boolean
			Private	cb_RepSave			As	Boolean

			Private	cb_IsVisible		As	Boolean
			Private	cb_IsVisibleSSO	As	Boolean
			Private	cb_InEditMode		As	Boolean

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	IsVisibleSSO			As	Boolean _
																		Implements	iUCParametersVM.IsVisibleSSO
				Get
					Return	Me.cb_IsVisibleSSO
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	InEditmode				As	Boolean _
																		Implements	iUCParametersVM.InEditmode
				Get
					Return	Me.cb_InEditMode
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property  IsVisible					As	Boolean	_
																		Implements	iUCParametersVM.IsVisible
				Get
					Return	Me.cb_IsVisible
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			ReadOnly	Friend	Property	LogonOptions			As	iLogonOptionsDTO _
													Implements	iUCParametersVM.LogonOptions
				Get
					Return	Me.co_Options
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	ReadOnly	Property	Context_Btn		As	BitVector32	_
																		Implements	iUCParametersVM.Context_Btn
				Get
					Return	Me.cv_Btns
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	ReadOnly	Property	BS_Langs		As	BindingSource	_
																		Implements	iUCParametersVM.BS_Langs
				Get
					Return	Me.co_BSLang
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	ReadOnly	Property	BS_Clnts	As	BindingSource	_
																		Implements	iUCParametersVM.BS_Clnts
				Get
					Return	Me.co_BSClnt
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	ReadOnly	Property	BS_Users		As	BindingSource	_
																		Implements	iUCParametersVM.BS_Users
				Get
					Return	Me.co_BSUser
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	ReadOnly	Property	BS_Pwrds		As	BindingSource	_
																		Implements	iUCParametersVM.BS_Pwrds
				Get
					Return	Me.co_BSPwrd
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateLogonSysDTO()		As iLogonSystemDTO _
													Implements	iUCParametersVM.CreateLogonSysDTO
				
				Return	Me.co_Model.CreateLogonSysDTO()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetCurrentLogonParameters()		As iLogonSystemDTO	_
													Implements	iUCParametersVM.GetCurrentLogonParameters
				
				Dim	lo_DTO	As	iLogonSystemDTO	=	New	LogonSystemDTO

				lo_DTO.DestinationID	=	Me.co_SystDTO.ID
				lo_DTO.Language				= Me.co_UCView.xcbx_Lang.Text.ToUpper
				lo_DTO.Client					=	Me.cc_Clnt
				lo_DTO.UserName				= Me.cc_User
				lo_DTO.Password				= Me.cc_PWrd

				Return	lo_DTO

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub SetConnection(ByVal _conndto As iLogonConnectionDTO) _
									Implements	iUCParametersVM.SetConnection

				Me.co_ConnDTO	= _conndto
				'..................................................
				Me.cb_IsVisible			= True
				Me.cb_IsVisibleSSO	= Not	Me.co_ConnDTO.SNC_Active

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	LoadSystem(ByVal _id	As String)	As Boolean _
													Implements	iUCParametersVM.LoadSystem

				Me.cc_ID	= _id

				'If Me.cb_InEditMode
				'	Return	False
				'Else
				'End If
				'..................................................
				If Me.cb_RepDirty

					Me.cb_RepSave		=	Me.co_Model.SaveSystem(Me.co_SystDTO)
					Me.cb_RepDirty	= False

				End If
				'................................................
				Me.co_SystDTO	= Me.co_Model.FetchSystem(_id)
				'................................................
				If Me.co_SystDTO IsNot Nothing

					Me.PrepareDataReset()
					Me.ConfigureStartupData()
					Me.LoadPrevious()
					Me.cv_Btns.Item( UCParametersView.ce_Btns.btnEdit )	= True
					Me.co_UCView.ResfreshEnv()
					'...............................................
					Return	True

				Else
					Return	False
				End If

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub LoadPrevious()

				If Me.co_SystDTO.Previous	IsNot Nothing

					If	Me.co_SystDTO.Previous.Language IsNot Nothing AndAlso
							Me.co_SystDTO.Previous.Language.Length <> 0

						Me.co_UCView.xcbx_Lang.SelectedIndex	= Me.co_UCView.xcbx_Lang.FindStringExact( Me.co_SystDTO.Previous.Language)

					End If

					If	Me.co_SystDTO.Previous.Client IsNot	Nothing	AndAlso
							Me.co_SystDTO.Previous.Client.Length <> 0

						Me.PrepClients()
						Me.co_UCView.xcbx_Clnt.SelectedIndex	= Me.co_UCView.xcbx_Clnt.FindStringExact( Me.co_SystDTO.Previous.Client )

						If Me.co_UCView.xcbx_Clnt.SelectedIndex >= 0

							Me.cc_Clnt	= Me.co_SystDTO.Previous.Client
							If Me.co_SystDTO.Clients.TryGetValue(Me.cc_Clnt, Me.co_ClntDTO)

								If	Me.co_SystDTO.Previous.UserName  IsNot Nothing AndAlso
										Me.co_SystDTO.Previous.UserName.Length <> 0

									Me.Prep_Users()
									Me.co_UCView.xcbx_User.SelectedIndex	= Me.co_UCView.xcbx_User.FindStringExact( Me.co_SystDTO.Previous.UserName )

									If Me.co_UCView.xcbx_User.SelectedIndex >= 0

										Me.cc_User	= Me.co_SystDTO.Previous.UserName
										If Me.co_ClntDTO.Users.TryGetValue(Me.cc_User, Me.co_UserDTO)

											If	Me.co_SystDTO.Previous.Password  IsNot Nothing	AndAlso
													Me.co_SystDTO.Previous.Password.Length <> 0

													Me.Prep_PWrds()
													Me.co_UCView.xcbx_Pwrd.SelectedIndex	=	Me.co_UCView.xcbx_Pwrd.FindStringExact( Me.co_SystDTO.Previous.Password )

													If Me.co_UCView.xcbx_Pwrd.SelectedIndex >= 0

														Me.cc_PWrd	= Me.co_SystDTO.Previous.Password

													End If

											End If

										End If

									End If

								End If

							End If

						End If

					End If
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	Cancel()

				Me.cb_RepDirty		= False
				Me.cb_InEditMode	= False
				'..................................................
				Me.LoadSystem(Me.cc_ID)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	EditMode()

				If Me.cb_InEditMode
					If Me.cb_RepDirty

						Me.cb_RepSave		=	Me.co_Model.SaveSystem(Me.co_SystDTO)
						Me.cb_RepDirty	= False

					End If
				End If
				'..................................................
				Me.PrepareDataReset()
				Me.cb_InEditMode	=	Not	Me.cb_InEditMode
				Me.ConfigureStartupData()

				If Me.cb_InEditMode
					Me.cv_Btns.Item( UCParametersView.ce_Btns.btnSave	+
													 UCParametersView.ce_Btns.btnDele	+
													 UCParametersView.ce_Btns.btnCanc		)	= True
				Else
					Me.cv_Btns.Item( UCParametersView.ce_Btns.btnEdit )	= True
				End If
				'..................................................
				Me.co_UCView.ResfreshEnv()

			End Sub			
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub EventHandler_TSBtnClick(_sender	As Object, 
																					_e			As EventArgs)

				Dim lc_Tag	= TryCast(_sender, ToolStripButton).Tag

				If lc_Tag IsNot Nothing

					Select Case lc_Tag.ToString
						Case "xtag_Edit"		:	Me.EditMode()
						Case "xtag_Save"		:	Me.EditMode()
						Case "xtag_Cancel"	:	Me.Cancel()
						'Case "xtag_Delete"	:	Me.DeleteConnection()
					End Select

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	Combobox_ClntChange(ByVal _text As String)

				Dim	lc_Key	=	_text.ToUpper

				If Me.cc_Clnt.Equals(lc_Key)	Then	Exit Sub
				'......................................................
				Me.cc_Clnt	= lc_Key

				Me.ct_User.Clear()
				Me.ct_PWrd.Clear()
				Me.cc_User		= ""
				Me.cc_PWrd		= ""
				Me.cb_DDwnUsr	= False
				Me.cb_DDwnPwd	= False
				'......................................................
				If Me.co_SystDTO.Clients.TryGetValue(Me.cc_Clnt, Me.co_ClntDTO)

					If Me.co_SystDTO.Previous.Client <> Me.cc_Clnt

						Me.co_SystDTO.Previous.Client		= Me.cc_Clnt
						Me.co_SystDTO.Previous.UserName	= ""
						Me.co_SystDTO.Previous.Password	= ""
						Me.cb_RepDirty	= True

					End If

				End If
				'......................................................
				Me.ResetBindings(False, False, True, True)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	Combobox_UserChange(ByVal _text As String)

				Dim	lc_Key	=	_text.ToUpper

				If Me.cc_User.Equals(lc_Key)	Then	Exit Sub
				'......................................................
				Me.cc_User	= lc_Key
				Me.ct_PWrd.Clear()
				Me.cc_PWrd		= ""
				Me.cb_DDwnPwd	= False

				If Me.co_ClntDTO.Users.TryGetValue(Me.cc_User, Me.co_UserDTO)

					If Me.co_SystDTO.Previous.UserName <> Me.cc_User

						Me.co_SystDTO.Previous.UserName	= Me.cc_User
						Me.co_SystDTO.Previous.Password	= ""
						Me.cb_RepDirty	= True

					End If

				End If
				Me.ResetBindings(False, False, False, True)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	Combobox_PWrdChange(ByVal _text As String)

				If Me.cc_PWrd.Equals(_text)	Then	Exit Sub
				'......................................................
				Me.cc_PWrd	= _text
				Me.co_UserDTO.Password	= _text

				If Me.co_SystDTO.Previous.Password <> Me.cc_PWrd

					Me.co_SystDTO.Previous.Password	= Me.cc_PWrd
					Me.cb_RepDirty	= True

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	Combobox_LangChange(ByVal _text As String)

				If Me.cc_Lang.Equals(_text.ToUpper)	Then	Exit Sub
				'......................................................
				Me.cc_Lang	= _text.ToUpper
				Me.co_SystDTO.Previous.Language	= Me.cc_Lang
				Me.cb_RepDirty	= True

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	Combobox_LanguageNew( ByVal _text As String)

				If Me.co_Model.SaveLanguage(_text)

					Me.LoadLanguages()
					Me.ResetBindings(True, False, False, False)

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	Combobox_ClientNew(ByVal _text As String)

				Dim	lo_DTO	As	iSysReposClientDTO	=	Me.co_Model.CreateClientDTO()

				lo_DTO.No	= _text.ToUpper

				If Me.co_SystDTO.AddClient(lo_DTO)

					Me.LoadClients()
					Me.ResetBindings(False, True, False, False)
					Me.cb_RepDirty	= True

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	Combobox_UserNew(ByVal _text As String)

				Dim	lo_DTO	As	iSysReposUserDTO	=	Me.co_Model.CreateUserDTO

				lo_DTO.User	= _text.ToUpper

				If Me.co_ClntDTO.AddUser(lo_DTO)

					Me.LoadUsers()
					Me.ResetBindings(False, False, True, False)
					Me.cb_RepDirty	= True

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	Combobox_PWrdNew(ByVal _text As String)

				Me.co_UserDTO.Password	= _text

				Me.LoadPasswords()
				Me.ResetBindings(False, False, False, True)
				Me.cb_RepDirty	= True

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub EventHandler_DrpdwnClnt(	_sender	As Object, 
																						_e			As EventArgs	)

				Me.PrepClients()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub EventHandler_DrpdwnUser(	_sender	As Object, 
																						_e			As EventArgs	)
				
				Me.Prep_Users()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub EventHandler_DrpdwnPwrd(	_sender	As Object, 
																						_e			As EventArgs	)

				Me.Prep_PWrds()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	LoadLanguages()

				Me.ct_Lang.Clear()
				Me.ct_Lang.AddRange(Me.co_Model.FetchLanguages())
				If Me.ct_Lang.Count.Equals(0)
					If Me.co_Model.SaveLanguage(Me.co_Options.DefaultLanguage)
						Me.ct_Lang.AddRange(Me.co_Model.FetchLanguages())
					End If
				End If
				'..................................................
				If Me.InEditmode	Then	Me.ct_Lang.Add(cx_New)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	LoadClients()

				Me.ct_Clnt.Clear()
				Me.ct_Clnt.AddRange(Me.co_SystDTO.Clients.Keys.ToList())
				'..................................................
				If Me.InEditmode	Then	Me.ct_Clnt.Add(cx_New)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	LoadUsers()

				Me.ct_User.Clear()
				Me.ct_User.AddRange(Me.co_ClntDTO.Users.Keys.ToList())
				'..................................................
				If Me.InEditmode	Then	Me.ct_User.Add(cx_New)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	LoadPasswords()

				Me.ct_PWrd.Clear()
				If Me.co_UserDTO.Password IsNot Nothing
					Me.ct_PWrd.Add(Me.co_UserDTO.Password)
				End If
				'..................................................
				If Me.InEditmode	Then	Me.ct_PWrd.Add(cx_New)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub EventHandler_Combobox(	_sender	As Object, 
																					_e			As EventArgs	)

				Dim	lo_Box	As	ComboBox	= TryCast(	_sender, ComboBox	)

				If lo_Box Is Nothing	Then Exit	Sub
				'......................................................
				If lo_Box.DropDownStyle.Equals(ComboBoxStyle.Simple)

					If lo_Box.Text.Count > 0
						If Not lo_Box.Text.Equals(cx_New)

							Select Case lo_Box.Tag.ToString
								Case "xtag_Lng"	:	Combobox_LanguageNew(lo_Box.Text)
								Case "xtag_Clt"	:	Combobox_ClientNew(lo_Box.Text)
								Case "xtag_Usr"	:	Combobox_UserNew(lo_Box.Text)
								Case "xtag_Pwd"	:	Combobox_PWrdNew(lo_Box.Text)
							End Select

						End If
					End If

					lo_Box.DropDownStyle = ComboBoxStyle.DropDownList

				Else
					If lo_Box.SelectedItem.ToString.Equals(cx_New)
						lo_Box.DropDownStyle = ComboBoxStyle.Simple
					Else

						Select Case lo_Box.Tag.ToString
							Case "xtag_Lng"	:	Combobox_LangChange(lo_Box.Text)
							Case "xtag_Clt"	:	Combobox_ClntChange(lo_Box.Text)
							Case "xtag_Usr"	:	Combobox_UserChange(lo_Box.Text)
							Case "xtag_Pwd"	:	Combobox_PWrdChange(lo_Box.Text)
						End Select

					End If
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub PrepClients()

				If Me.cb_DDwnClt	Then	Exit	Sub
				'..................................................
				LoadClients()
				Me.ResetBindings(False, True, False, False)
				Me.cb_DDwnClt	= True

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub Prep_Users()

				If Me.cb_DDwnUsr	Then	Exit	Sub
				'..................................................
				LoadUsers()
				Me.ResetBindings(False, False, True, False)
				Me.cb_DDwnUsr	= True

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub Prep_PWrds()

				If Me.cb_DDwnPwd	Then	Exit	Sub
				'..................................................
				LoadPasswords()
				Me.ResetBindings(False, False, False, True)
				Me.cb_DDwnPwd	= True

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Base"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetUserControl()	As	UCParametersView _
													Implements	iUCParametersVM.GetUserControl

				Return	Me.co_UCView

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	Shutdown() _
										Implements	iUCParametersVM.Shutdown

				If Me.cb_RepDirty
					If Me.co_Options.AutoSave
						Me.cb_RepSave	=	Me.co_Model.SaveSystem(Me.co_SystDTO)
					End If
				End If
				'..................................................
				If Me.cb_RepSave
					If Me.co_Model.SaveRepository()
					End If
				End If
				'..................................................
				Me.ConfigureHandlers(True)

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Construction"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Const	cx_New	As	String	=	"..."

			Private	WithEvents	co_UCView	As	UCParametersView

			Private	co_Model		As	iLogonSystemsModel
			Private	co_Options	As	iLogonOptionsDTO

			Private	cv_Btns			As	BitVector32

			Private co_BSLang		As	BindingSource
			Private co_BSClnt		As	BindingSource
			Private co_BSUser		As	BindingSource
			Private co_BSPwrd		As	BindingSource

			Private	ct_Lang			As	List(Of String)
			Private	ct_Clnt			As	List(Of String)
			Private	ct_User			As	List(Of String)
			Private	ct_PWrd			As	List(Of String)

			Private	cb_DDwnClt	As	Boolean
			Private	cb_DDwnUsr	As	Boolean
			Private	cb_DDwnPwd	As	Boolean

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub New(ByVal	_options	As iLogonOptionsDTO)

				Me.co_Options	= _options
				'..................................................
				Me.ConfigureBindings()
				Me.PrepareDataReset()
				Me.ConfigureModel()
				Me.ConfigureControl()
				Me.ConfigureHandlers()
				Me.ConfigureStartupData()
				'..................................................
				Me.co_UCView.ResfreshEnv()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub ConfigureBindings()

				Me.ct_Lang	=	New	List(Of String)
				Me.ct_Clnt	= New List(Of String)
				Me.ct_User	= New List(Of String)
				Me.ct_PWrd	= New List(Of String)
				'..................................................
				Me.co_BSLang						= New BindingSource
				Me.co_BSLang.DataSource	= Me.ct_Lang

				Me.co_BSClnt						= New BindingSource
				Me.co_BSClnt.DataSource	= Me.ct_Clnt

				Me.co_BSUser						= New BindingSource
				Me.co_BSUser.DataSource	= Me.ct_User

				Me.co_BSPwrd						= New BindingSource
				Me.co_BSPwrd.DataSource	= Me.ct_PWrd

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub ConfigureModel()

				Me.co_Model		= New	LogonSystemsModel()
				'..................................................
				Me.co_SystDTO	=	Me.co_Model.CreateSystemDTO()
				Me.co_ClntDTO	= Me.co_Model.CreateClientDTO()
				Me.co_UserDTO	= Me.co_Model.CreateUserDTO()
				'..................................................
				Me.cb_InEditMode	= False
				Me.cb_RepSave			= False

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub PrepareDataReset()

				Me.cv_Btns	= New BitVector32(0)
				'..................................................
				Me.ct_Lang.Clear()
				Me.ct_Clnt.Clear()
				Me.ct_User.Clear()
				Me.ct_PWrd.Clear()
				'..................................................
				Me.cc_Lang	= ""
				Me.cc_Clnt	= ""
				Me.cc_User	= ""
				Me.cc_PWrd	= ""

				Me.cb_RepDirty	= False

				Me.cb_DDwnClt	= False
				Me.cb_DDwnUsr	= False
				Me.cb_DDwnPwd	= False

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub ConfigureControl()

				Me.co_UCView						= New UCParametersView(Me)

				Me.co_UCView.Dock				= DockStyle.Fill
				Me.co_UCView.Location		= New Drawing.Point(5, 5)
				Me.co_UCView.Padding		= New Padding(2)
				Me.co_UCView.TabIndex		= 0

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub ConfigureHandlers(Optional ByVal _remove As Boolean	= False)

				If _remove

					RemoveHandler	Me.co_UCView.xbtn_ts_Edit.Click		,	AddressOf	Me.EventHandler_TSBtnClick
					RemoveHandler	Me.co_UCView.xbtn_ts_Save.Click		,	AddressOf	Me.EventHandler_TSBtnClick
					RemoveHandler	Me.co_UCView.xbtn_ts_Delete.Click	,	AddressOf	Me.EventHandler_TSBtnClick
					RemoveHandler	Me.co_UCView.xbtn_ts_Cancel.Click	,	AddressOf	Me.EventHandler_TSBtnClick

					RemoveHandler	Me.co_UCView.xcbx_Lang.SelectionChangeCommitted	, AddressOf Me.EventHandler_Combobox
					RemoveHandler	Me.co_UCView.xcbx_Clnt.SelectionChangeCommitted	, AddressOf Me.EventHandler_Combobox
					RemoveHandler	Me.co_UCView.xcbx_User.SelectionChangeCommitted	, AddressOf Me.EventHandler_Combobox
					RemoveHandler	Me.co_UCView.xcbx_Pwrd.SelectionChangeCommitted	, AddressOf Me.EventHandler_Combobox

					RemoveHandler	Me.co_UCView.xcbx_Clnt.DropDown	,	AddressOf Me.EventHandler_DrpdwnClnt
					RemoveHandler	Me.co_UCView.xcbx_User.DropDown	,	AddressOf Me.EventHandler_DrpdwnUser
					RemoveHandler	Me.co_UCView.xcbx_Pwrd.DropDown	,	AddressOf Me.EventHandler_DrpdwnPwrd

				Else

					AddHandler	Me.co_UCView.xbtn_ts_Edit.Click		,	AddressOf	Me.EventHandler_TSBtnClick
					AddHandler	Me.co_UCView.xbtn_ts_Save.Click		,	AddressOf	Me.EventHandler_TSBtnClick
					AddHandler	Me.co_UCView.xbtn_ts_Delete.Click	,	AddressOf	Me.EventHandler_TSBtnClick
					AddHandler	Me.co_UCView.xbtn_ts_Cancel.Click	,	AddressOf	Me.EventHandler_TSBtnClick

					AddHandler	Me.co_UCView.xcbx_Lang.SelectionChangeCommitted	, AddressOf Me.EventHandler_Combobox
					AddHandler	Me.co_UCView.xcbx_Clnt.SelectionChangeCommitted	, AddressOf Me.EventHandler_Combobox
					AddHandler	Me.co_UCView.xcbx_User.SelectionChangeCommitted	, AddressOf Me.EventHandler_Combobox
					AddHandler	Me.co_UCView.xcbx_Pwrd.SelectionChangeCommitted	, AddressOf Me.EventHandler_Combobox

					AddHandler	Me.co_UCView.xcbx_Clnt.DropDown	,	AddressOf Me.EventHandler_DrpdwnClnt
					AddHandler	Me.co_UCView.xcbx_User.DropDown	,	AddressOf Me.EventHandler_DrpdwnUser
					AddHandler	Me.co_UCView.xcbx_Pwrd.DropDown	,	AddressOf Me.EventHandler_DrpdwnPwrd

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub ConfigureStartupData()

				Me.LoadLanguages()
				Me.ResetBindings(True, True, True, True)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	ResetBindings(Optional	ByVal	_lang		As	Boolean	=	False	,
																Optional	ByVal	_clnt		As	Boolean	= False	,
																Optional	ByVal	_user		As	Boolean	= False	,
																Optional	ByVal	_pwrd		As	Boolean	= False		)

				If _lang	Then	Me.co_BSLang.ResetBindings(False)
				If _clnt	Then	Me.co_BSClnt.ResetBindings(False)
				If _user	Then	Me.co_BSUser.ResetBindings(False)
				If _pwrd	Then	Me.co_BSPwrd.ResetBindings(False)

			End Sub

		#End Region

	End Class

End Namespace
