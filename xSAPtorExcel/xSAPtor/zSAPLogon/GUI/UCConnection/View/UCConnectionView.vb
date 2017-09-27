Imports	xSAPtorExcel.Main.SAPLogon
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Friend Class UCConnectionView

	#Region "Definitions"

		Private	co_VM		As iUCConnectionVM
		'......................................................
		Friend	Enum	ce_Btns		As Integer
			btnNew	= 1
			btnEdit	= 2
			btnSave	= 4
			btnDele	= 8
			btnCanc	= 16
		End Enum

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods: Exposed"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend  Sub	UpdateDatacontext()

			Me.co_VM.Datacontext_DTO.Name							= Me.xtbx_Name.Text
			Me.co_VM.Datacontext_DTO.AppServer				= Me.xtbx_AppSrvr.Text
			Me.co_VM.Datacontext_DTO.InstanceNo				=	CInt( Me.xtbx_InsNo.Text )
			Me.co_VM.Datacontext_DTO.SystemID					= Me.xtbx_SysID.Text
			Me.co_VM.Datacontext_DTO.RouterPath				= Me.xtbx_Router.Text
			Me.co_VM.Datacontext_DTO.SNC_Active				= Me.xcbx_SNCActive.Checked
			Me.co_VM.Datacontext_DTO.SNC_PartnerName	= Me.xtbx_SNCName.Text
			Me.co_VM.Datacontext_DTO.SNC_UsrPwd				= Me.xcbx_SNCUsrPwd.Checked
			Me.co_VM.Datacontext_DTO.SNC_QOP					=	CInt( Me.xnud_SNCQOP.Value )
			Me.co_VM.Datacontext_DTO.LowSpeed					= Me.xcbx_Speed.Checked
			'....................................................
			Me.co_VM.Datacontext_DTO.ID	= Me.co_VM.Datacontext_DTO.Name

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend	Sub	ResfreshEnv()

			Me.SuspendLayout
			Me.SetValues()
			Me.SetStatusFields()
			Me.SetStatusButtons()
			Me.ResumeLayout

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods: Private"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private	Sub EventHandler_NameChanges() _
									Handles	xtbx_Name.TextChanged

			If Me.xtbx_Name.Text.Length.Equals(0)
				If Me.xbtn_ts_Save.Visible
					Me.xbtn_ts_Save.Visible	= False
				End If
			Else
				If Not Me.xbtn_ts_Save.Visible
					Me.xbtn_ts_Save.Visible	= True
				End If
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private	Sub	EventHandler_SNCChecked()	_
									Handles	xcbx_SNCActive.CheckedChanged

			If Me.xcbx_SNCActive.Checked

				Me.xtbx_SNCName.Enabled		= Me.co_VM.Datacontext_DTO.CanEdit
				Me.xcbx_SNCUsrPwd.Enabled	= Me.co_VM.Datacontext_DTO.CanEdit
				Me.xnud_SNCQOP.Enabled		= Me.co_VM.Datacontext_DTO.CanEdit

			Else

				Me.xtbx_SNCName.Enabled		= False
				Me.xcbx_SNCUsrPwd.Enabled	= False
				Me.xnud_SNCQOP.Enabled		= False

			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private	Sub	SetStatusFields()

			If Me.co_VM.Datacontext_DTO.IsNew
				Me.xtbx_Name.Enabled	= True
			Else
				Me.xtbx_Name.Enabled	= False
			End If
			'....................................................
			Me.xtbx_AppSrvr.Enabled		= Me.co_VM.Datacontext_DTO.CanEdit
			Me.xtbx_InsNo.Enabled			= Me.co_VM.Datacontext_DTO.CanEdit
			Me.xtbx_SysID.Enabled			= Me.co_VM.Datacontext_DTO.CanEdit
			Me.xtbx_Router.Enabled		= Me.co_VM.Datacontext_DTO.CanEdit
			Me.xcbx_SNCActive.Enabled	= Me.co_VM.Datacontext_DTO.CanEdit
			Me.xcbx_Speed.Enabled			= Me.co_VM.Datacontext_DTO.CanEdit
			'....................................................
			If Me.xcbx_SNCActive.Checked

				Me.xtbx_SNCName.Enabled		= Me.co_VM.Datacontext_DTO.CanEdit
				Me.xcbx_SNCUsrPwd.Enabled	= Me.co_VM.Datacontext_DTO.CanEdit
				Me.xnud_SNCQOP.Enabled		= Me.co_VM.Datacontext_DTO.CanEdit

			Else

				Me.xtbx_SNCName.Enabled		= False
				Me.xcbx_SNCUsrPwd.Enabled	= False
				Me.xnud_SNCQOP.Enabled		= False

			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private	Sub	SetValues()

			Me.xtbx_Name.Text					= Me.co_VM.Datacontext_DTO.Name
			Me.xtbx_AppSrvr.Text			= Me.co_VM.Datacontext_DTO.AppServer
			Me.xtbx_InsNo.Text				= Me.co_VM.Datacontext_DTO.InstanceNo.ToString
			Me.xtbx_SysID.Text				= Me.co_VM.Datacontext_DTO.SystemID
			Me.xtbx_Router.Text				= Me.co_VM.Datacontext_DTO.RouterPath
			Me.xcbx_SNCActive.Checked	= Me.co_VM.Datacontext_DTO.SNC_Active
			Me.xtbx_SNCName.Text			= Me.co_VM.Datacontext_DTO.SNC_PartnerName
			Me.xcbx_SNCUsrPwd.Checked	= Me.co_VM.Datacontext_DTO.SNC_UsrPwd
			Me.xnud_SNCQOP.Value			= Me.co_VM.Datacontext_DTO.SNC_QOP
			Me.xcbx_Speed.Checked			= Me.co_VM.Datacontext_DTO.LowSpeed

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private	Sub	SetStatusButtons()

			Me.xbtn_ts_New.Visible		=	Me.co_VM.Datacontext_Btn(ce_Btns.btnNew)
			Me.xbtn_ts_Edit.Visible		=	Me.co_VM.Datacontext_Btn(ce_Btns.btnEdit)
			Me.xbtn_ts_Save.Visible		=	Me.co_VM.Datacontext_Btn(ce_Btns.btnSave)
			Me.xbtn_ts_Delete.Visible	=	Me.co_VM.Datacontext_Btn(ce_Btns.btnDele)
			Me.xbtn_ts_Cancel.Visible	=	Me.co_VM.Datacontext_Btn(ce_Btns.btnCanc)

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Constructor"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Sub New(ByVal _vm	As	iUCConnectionVM)

			InitializeComponent()
			'....................................................
			Me.co_VM	= _vm

		End Sub

	#End Region

End Class
