Imports System.Windows.Forms
Imports xSAPtorExcel.Main.SAPLogon
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Friend Class UCParametersView

	#Region "Definitions"

		Private	co_VM		As iUCParametersVM
		'......................................................
		Friend	Enum	ce_Btns		As Integer
			btnEdit	= 1
			btnSave	= 2
			btnDele	= 4
			btnCanc	= 8
		End Enum
		
	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods: Exposed"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend	Sub	ResfreshEnv()

			Me.SuspendLayout

			Me.xcbx_Lang.DropDownStyle	= ComboBoxStyle.DropDownList
			Me.xcbx_Clnt.DropDownStyle	= ComboBoxStyle.DropDownList
			Me.xcbx_User.DropDownStyle	= ComboBoxStyle.DropDownList
			Me.xcbx_Pwrd.DropDownStyle	= ComboBoxStyle.DropDownList

			Me.SetStatus_OnFields()
			Me.SetStatus_OnButtons()

			Me.ResumeLayout

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Constructor"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Sub New(ByVal _vm	As	iUCParametersVM)

			' This call is required by the designer.

			InitializeComponent()

			' Add any initialization after the InitializeComponent() call.
			
			Me.co_VM	= _vm
			'....................................................
			Me.Configure_Bindings()
			Me.Configure_Env()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub Configure_Bindings()

			' Configure Language section
			'
			Me.xcbx_Lang.DisplayMember  = "Key"
			Me.xcbx_Lang.ValueMember    = "Key"
			Me.xcbx_Lang.DataSource     = Me.co_VM.BS_Langs

			' Configure Client Section
			'
			Me.xcbx_Clnt.DisplayMember	= "Key"
			Me.xcbx_Clnt.ValueMember    = "Key"
			Me.xcbx_Clnt.DataSource     = Me.co_VM.BS_Clnts

			' Configure Users
			'
			Me.xcbx_User.DisplayMember  = "Key"
			Me.xcbx_User.ValueMember    = "Key"
			Me.xcbx_User.DataSource     = Me.co_VM.BS_Users

			' Configure Password
			'
			Me.xcbx_Pwrd.DisplayMember  = "Key"
			Me.xcbx_Pwrd.ValueMember    = "Key"
			Me.xcbx_Pwrd.DataSource     = Me.co_VM.BS_Pwrds

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub Configure_Env()

			'If Not Me.co_VM.LogonOptions.ShowPassword
			'	Me.xcbx_Pwrd .ForeColor	= Me.xcbx_Pwrd.BackColor
			'End If

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods: Private"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private	Sub	SetStatus_OnFields()

			Me.xlbl_Lang.Visible	= Me.co_VM.IsVisible
			Me.xlbl_Clnt.Visible	= Me.co_VM.IsVisible
			Me.xlbl_User.Visible	= Me.co_VM.IsVisible

			Me.xcbx_Lang.Visible	=	Me.co_VM.IsVisible
			Me.xcbx_Clnt.Visible	= Me.co_VM.IsVisible
			Me.xcbx_User.Visible	= Me.co_VM.IsVisible
			'....................................................
			Me.xlbl_Pwrd.Visible	= Me.co_VM.IsVisibleSSO

			Me.xcbx_Pwrd.Visible	= Me.co_VM.IsVisibleSSO
			'....................................................
			Me.xcbx_Lang.Enabled	=	True
			Me.xcbx_Clnt.Enabled	= True
			Me.xcbx_User.Enabled	= True
			Me.xcbx_Pwrd.Enabled	= True

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private	Sub	SetStatus_OnButtons()

			Me.xbtn_ts_Edit.Visible		=	Me.co_VM.Context_Btn(ce_Btns.btnEdit)
			Me.xbtn_ts_Save.Visible		=	Me.co_VM.Context_Btn(ce_Btns.btnSave)
			Me.xbtn_ts_Delete.Visible	=	Me.co_VM.Context_Btn(ce_Btns.btnDele)
			Me.xbtn_ts_Cancel.Visible	=	Me.co_VM.Context_Btn(ce_Btns.btnCanc)

		End Sub

	#End Region

End Class
