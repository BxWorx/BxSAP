Imports System.Windows.Forms
Imports xSAPtorExcel.Main.Session
Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.WorksheetDomain
Imports xSAPtorExcel.Main.BDCProcessing
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Public Class xBDCProcessGUIView
							Implements ixBDCProcessGUIView

	#Region "Definitions"

		Private WithEvents	co_Cntlr			As ixBDCProcessingController
		Private							co_WSProfile	As iExcelWSProfileDTO
		Private							co_DPOriginal As iBDCConfiguration
		Private							co_DPCurrent	As iBDCConfiguration

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Events: Controls"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xBtn_ActiveColAddress_Click(sender As Object,
																						e As EventArgs) _
									Handles xBtn_ActiveColAddress.Click

			Dim lo_ExcelHelp = ExcelHelper.GetInstance()

			Me.xlbl_ActiveColAddress.Text = lo_ExcelHelp.GetCurrentCell().Address
			Me.co_DPCurrent.Active_Column_Address = Me.xlbl_ActiveColAddress.Text

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xbtn_ConfigAddr_Click(sender As Object,
																						e As EventArgs) _
									Handles xbtn_ConfigAddr.Click

			Dim lo_ExcelHelp = ExcelHelper.GetInstance()

			Me.xlbl_ConfigAddr.Text = lo_ExcelHelp.GetCurrentCell().Address

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xcbx_WSActive_CheckedChanged(sender As Object,
																						e As EventArgs) _
									Handles xcbx_WSActive.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				Me.co_DPCurrent.IsActive = CStr(IIf(CType(sender, CheckBox).Checked, "X"c, " "c))
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xcbo_IntervalPause_TextChanged(sender As Object,
																							 e As EventArgs) _
									Handles xcbo_IntervalPause.TextChanged

			If Not IsNothing(Me.co_DPCurrent)
				Me.co_DPCurrent.PauseTime = CInt(CType(sender, ComboBox).Text)
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xtbx_SAPTCode_TextChanged(sender As Object,
																					e As EventArgs) _
									Handles xtbx_SAPTCode.TextChanged

			If Not IsNothing(Me.co_DPCurrent)
				Me.co_DPCurrent.SAPTCode = CType(sender, TextBox).Text
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xcbx_DefSize_CheckedChanged(sender As Object,
																						e As EventArgs) _
									Handles xcbx_DefSize.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				Me.co_DPCurrent.CTU_Parameters.DefSize = CStr(IIf(CType(sender, CheckBox).Checked, "X"c, " "c))
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xrbtn_PM_All_CheckedChanged(sender As Object,
																						e As EventArgs) _
									Handles xrbtn_PM_All.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				If CType(sender, RadioButton).Checked
					Me.co_DPCurrent.CTU_Parameters.DisMode = "A"
				End If
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xrbtn_PM_BGrnd_CheckedChanged(sender As Object,
																							e As EventArgs) _
									Handles xrbtn_PM_BGrnd.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				If CType(sender, RadioButton).Checked
					Me.co_DPCurrent.CTU_Parameters.DisMode = "N"
				End If
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xrbtn_PM_Errors_CheckedChanged(sender As Object,
																							 e As EventArgs) _
									Handles xrbtn_PM_Errors.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				If CType(sender, RadioButton).Checked
					Me.co_DPCurrent.CTU_Parameters.DisMode = "E"
				End If
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xrbtn_UM_ASync_CheckedChanged(sender As Object,
																							e As EventArgs) _
									Handles xrbtn_UM_ASync.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				If CType(sender, RadioButton).Checked
					Me.co_DPCurrent.CTU_Parameters.UpdMode = "A"
				End If
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xrbtn_UM_Sync_CheckedChanged(sender As Object,
																						 e As EventArgs) _
									Handles xrbtn_UM_Sync.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				If CType(sender, RadioButton).Checked
					Me.co_DPCurrent.CTU_Parameters.UpdMode = "S"
				End If
			End If

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Events: Form"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xSAPtorBDCConfig_Load(sender As Object,
																			e As EventArgs) _
									Handles Me.Load

			Me.co_WSProfile = Me.co_Cntlr.GetWorkSheetProfile()
			Me.co_DPOriginal = co_WSProfile.BDCConfig
			Me.co_DPCurrent = Me.co_DPOriginal
			Me.Configloaded = True

			Me.UpdateView()

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Events: ToolStrip"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xtsb_Revert_Click(sender As Object,
																	e As EventArgs) _
									Handles xtsb_Revert.Click

			Me.co_DPCurrent = Me.co_DPOriginal
			Me.UpdateView()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xtsb_Save_Click(sender As Object,
																e As EventArgs) _
									Handles xtsb_Save.Click

			If Me.xlbl_ConfigAddr.Text.Length > 0
				'If Not Me.co_Cntlr.WriteBDCConfigToWSheet(i_Address:=Me.xlbl_ConfigAddr.Text.Trim,
				'																					i_BDCConfig:=Me.co_DPCurrent)

				'End If
			End If

			Me.Configloaded = False

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xtsb_Fetch_Click(sender As Object,
																 e As EventArgs) _
									Handles xtsb_Fetch.Click

			Me.co_WSProfile		= Me.co_Cntlr.GetWorkSheetProfile()
			Me.co_DPOriginal	= co_WSProfile.BDCConfig
			Me.co_DPCurrent		= Me.co_DPOriginal
			Me.Configloaded		= True

			Me.UpdateView()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xtsb_Cancel_Click(sender As Object,
																 e As EventArgs) _
									Handles xtsb_Cancel.Click

			Me.Close()

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Properties: Exposed"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Overloads ReadOnly Property IsDisposed() _
																				As Boolean _
																					Implements ixBDCProcessGUIView.IsDisposed
			Get
				Return MyBase.IsDisposed()
			End Get
		End Property

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods: Exposed"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Sub HandleVisibility() _
								Implements ixBDCProcessGUIView.HandleVisibility

			If Me.Visible
				If Me.WindowState = FormWindowState.Minimized
					Me.WindowState = FormWindowState.Normal
				Else
					Me.Hide()
				End If
			Else
				Me.Show()
			End If

		End Sub

	#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Private Properties"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cb_CfgLoaded As Boolean

		Private WriteOnly Property Configloaded() As Boolean
			Set(value As Boolean)
				Me.cb_CfgLoaded = value
				Me.ConfigureButtons()
			End Set
		End Property

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Private Methods"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub ConfigureButtons()

			Me.xtsb_Fetch.Enabled = Not Me.cb_CfgLoaded

			Me.xtsb_Revert.Enabled = Me.cb_CfgLoaded
			Me.xtsb_Save.Enabled = Me.cb_CfgLoaded

			Me.xtsb_Cancel.Enabled = True

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub UpdateView()

			Me.xcbx_DefSize.Checked = CBool(IIf(CStr(Me.co_DPCurrent.CTU_Parameters.DefSize).ToUpperInvariant = "X"c, True, False))
			Me.xcbx_WSActive.Checked = CBool(IIf(CStr(Me.co_DPCurrent.IsActive).ToUpperInvariant = "X"c, True, False))

			Me.xcbo_IntervalPause.Text = CStr(Me.co_DPCurrent.PauseTime)
			Me.xtbx_SAPTCode.Text = Me.co_DPCurrent.SAPTCode
			Me.xlbl_ConfigAddr.Text = Me.co_WSProfile.XMLConfigAddress.Address
			Me.xlbl_ActiveColAddress.Text = Me.co_DPCurrent.Active_Column_Address
			Me.xlbl_GUID.Text = Me.co_DPCurrent.GUID

			Select Case Me.co_DPCurrent.CTU_Parameters.DisMode
				Case "A"c : Me.xrbtn_PM_All.Checked = True
				Case "E"c : Me.xrbtn_PM_Errors.Checked = True
				Case "N"c : Me.xrbtn_PM_BGrnd.Checked = True
				Case Else : Me.xrbtn_PM_BGrnd.Checked = True
			End Select

			Select Case Me.co_DPCurrent.CTU_Parameters.UpdMode
				Case "S"c : Me.xrbtn_UM_Sync.Checked = True
				Case "A"c : Me.xrbtn_UM_ASync.Checked = True
				Case Else : Me.xrbtn_UM_ASync.Checked = True
			End Select

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Constructors"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Shared Function Create(ByVal Controller As ixBDCProcessingController) _
														As ixBDCProcessGUIView

			Return New xBDCProcessGUIView(i_Controller:=Controller)

		End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub New(ByVal i_Controller As ixBDCProcessingController)

			InitializeComponent()

			Me.co_Cntlr = i_Controller

		End Sub

	#End Region

End Class