Imports System.Windows.Forms

Imports xSAPtorExcel.Main.SAPLogon
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Friend	Class LogonConnSetupView

	#Region "Definitions"

		Private	cb_Changed			As Boolean

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods: Form Handling"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend	ReadOnly	Property	Changed	As Boolean
			Get
				Return	Me.cb_Changed
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend	Sub	LoadData(ByVal _dto	As iLogonConnSetupDTO)

			Me.xchb_UseMan.Checked			= _dto.UseManual
			Me.xnud_ConnLimit.Value			= _dto.PeakConnectionLimit
			Me.xnud_Poolsize.Value			= _dto.PoolSize
			Me.xnud_Idlechecktime.Value	= _dto.IdleCheckTime
			Me.xnud_Idletimeout.Value		= _dto.ConnectionIdleTimeout

			Me.xtbx_SNC32.Text					= _dto.SNC_LibName32
			Me.xtbx_SNC64.Text					= _dto.SNC_LibName64
			Me.xtbx_SNCPath.Text				= _dto.SNC_LibPath

			Me.xtbx_XMLNode.Text				= _dto.XML_Node
			Me.xtbx_XMLPath.Text				= _dto.XML_Path
			Me.xtbx_XMLFile.Text				= _dto.XML_FileName
			Me.xcbx_SAPGuiOnly.Checked	= _dto.XML_OnlyGUI

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend	Sub UpdatedData(ByRef	DTO	As iLogonConnSetupDTO)

			DTO.UseManual							= Me.xchb_UseMan.Checked
			DTO.PeakConnectionLimit		=	CInt( Me.xnud_ConnLimit.Value )
			DTO.PoolSize							= CInt( Me.xnud_Poolsize.Value )
			DTO.IdleCheckTime					= CInt( Me.xnud_Idlechecktime.Value )
			DTO.ConnectionIdleTimeout	= CInt( Me.xnud_Idletimeout.Value )

			DTO.SNC_LibName32					= Me.xtbx_SNC32.Text
			DTO.SNC_LibName64					= Me.xtbx_SNC64.Text
			DTO.SNC_LibPath						= Me.xtbx_SNCPath.Text

			DTO.XML_Node							= Me.xtbx_XMLNode.Text
			DTO.XML_Path							= Me.xtbx_XMLPath.Text
			DTO.XML_FileName					= Me.xtbx_XMLFile.Text
			DTO.XML_OnlyGUI						= Me.xcbx_SAPGuiOnly.Checked

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods: Private"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub ev_FormEscape(	sender	As Object,
																e				As KeyEventArgs) _
									Handles Me.KeyDown

			If e.KeyCode.Equals(Keys.Escape)	Then	Me.Close()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub SetStateChanged(sender As Object,	e	As EventArgs) _
									Handles	xnud_ConnLimit.ValueChanged			,
													xnud_Poolsize.ValueChanged			,
													xnud_Idlechecktime.ValueChanged	,
													xnud_Idletimeout.ValueChanged		,
													xtbx_SNC32.TextChanged					,
													xtbx_SNC64.TextChanged					,
													xtbx_SNCPath.TextChanged				,
													xtbx_XMLNode.TextChanged				,
													xtbx_XMLPath.TextChanged				,
													xtbx_XMLFile.TextChanged				,
													xcbx_SAPGuiOnly.CheckedChanged

			Me.cb_Changed	= True

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Constructors & Constructor Events"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Sub New()

			InitializeComponent()

			Me.cb_Changed	= False

		End Sub

	#End Region

End Class