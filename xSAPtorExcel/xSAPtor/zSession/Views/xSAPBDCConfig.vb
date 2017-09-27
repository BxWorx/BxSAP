Imports System.Windows.Forms
Imports xSAPtorExcel.Main.Session
Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.WorksheetDomain
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Public Class xSAPBDCConfig
							Implements ixSAPSessionConfig

	#Region "Definitions"

		Private WithEvents	co_Cntlr			As ixSessionController
		Private WithEvents	co_FormPwrd		As SAPSessionPwrd
		Private							co_WSProfile  As iExcelWSProfileDTO
		Private							co_DPOriginal	As iBDCConfiguration
		Private							co_DPCurrent  As iBDCConfiguration

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Events: Controls"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xbtn_PwdShow_MouseUp(sender As Object, e As MouseEventArgs) Handles xbtn_PwdShow.MouseUp
			Me.xtbx_Pwrd.UseSystemPasswordChar = True
		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xbtn_PwdShow_MouseDown(sender As Object, e As MouseEventArgs) Handles xbtn_PwdShow.MouseDown
			Me.xtbx_Pwrd.UseSystemPasswordChar = False
		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xBtn_MsgColAddress_Click(sender  As Object,
																						e       As EventArgs) _
									Handles xBtn_MsgColAddress.Click

			Dim lo_ExcelHelp  = ExcelHelper.ExcelHelper()
			
			Me.xlbl_MsgColAddress.Text						= lo_ExcelHelp.GetCurrentCell().Address
			Me.co_DPCurrent.MessageColumnAddress	= Me.xlbl_MsgColAddress.Text

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xBtn_ActiveColAddress_Click(sender  As Object,
																						e       As EventArgs) _
									Handles xBtn_ActiveColAddress.Click

			Dim lo_ExcelHelp  = ExcelHelper.ExcelHelper()
			
			Me.xlbl_ActiveColAddress.Text						= lo_ExcelHelp.GetCurrentCell().Address
			Me.co_DPCurrent.Active_Column_Address		= Me.xlbl_ActiveColAddress.Text

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xbtn_ConfigAddr_Click(sender  As Object,
																						e       As EventArgs) _
									Handles xbtn_ConfigAddr.Click

			Dim lo_ExcelHelp  = ExcelHelper.ExcelHelper()
			
			Me.xlbl_ConfigAddr.Text = lo_ExcelHelp.GetCurrentCell().Address

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xcbx_WSProtect_CheckedChanged(sender  As Object,
																							e       As EventArgs) _
									Handles xcbx_WSProtect.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				Me.co_DPCurrent.IsProtected  = CStr(IIf(CType(sender, CheckBox).Checked, "X"c, " "c))
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xcbx_WSActive_CheckedChanged(sender  As Object,
																						e       As EventArgs) _
									Handles xcbx_WSActive.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				Me.co_DPCurrent.IsActive  = CStr(IIf(CType(sender, CheckBox).Checked, "X"c, " "c))
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xcbo_IntervalPause_TextChanged(sender As Object,
																							 e      As EventArgs) _
									Handles xcbo_IntervalPause.TextChanged

			If Not IsNothing(Me.co_DPCurrent)
				Me.co_DPCurrent.PauseTime = CInt(CType(sender, ComboBox).Text)
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xtbx_SAPTCode_TextChanged(sender  As Object,
																					e       As EventArgs) _
									Handles xtbx_SAPTCode.TextChanged

			If Not IsNothing(Me.co_DPCurrent)
				Me.co_DPCurrent.SAPTCode = CType(sender, TextBox).Text
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xtbx_Pwrd_TextChanged(sender  As Object,
																					e       As EventArgs) _
									Handles xtbx_Pwrd.TextChanged

			If Not IsNothing(Me.co_DPCurrent)
				Me.co_DPCurrent.Password = CType(sender, TextBox).Text
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xtbx_SAPSessionID_TextChanged(sender  As Object,
																							e       As EventArgs) _
									Handles xtbx_SAPSessionID.TextChanged

			If Not IsNothing(Me.co_DPCurrent)
				Me.co_DPCurrent.SessionID = CType(sender, TextBox).Text
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xcbx_DefSize_CheckedChanged(sender  As Object,
																						e       As EventArgs) _
									Handles xcbx_DefSize.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				Me.co_DPCurrent.CTU_Parameters.DefSize  = CStr(IIf(CType(sender, CheckBox).Checked, "X"c, " "c))
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xrbtn_PM_All_CheckedChanged(sender  As Object,
																						e       As EventArgs) _
									Handles xrbtn_PM_All.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				If CType(sender, RadioButton).Checked
					Me.co_DPCurrent.CTU_Parameters.DisMode  = "A"
				End If
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xrbtn_PM_BGrnd_CheckedChanged(sender  As Object,
																							e       As EventArgs) _
									Handles xrbtn_PM_BGrnd.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				If CType(sender, RadioButton).Checked
					Me.co_DPCurrent.CTU_Parameters.DisMode  = "N"
				End If
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xrbtn_PM_Errors_CheckedChanged(sender As Object,
																							 e      As EventArgs) _
									Handles xrbtn_PM_Errors.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				If CType(sender, RadioButton).Checked
					Me.co_DPCurrent.CTU_Parameters.DisMode  = "E"
				End If
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xrbtn_UM_ASync_CheckedChanged(sender  As Object,
																							e       As EventArgs) _
									Handles xrbtn_UM_ASync.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				If CType(sender, RadioButton).Checked
					Me.co_DPCurrent.CTU_Parameters.UpdMode  = "A"
				End If
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xrbtn_UM_Sync_CheckedChanged(sender As Object,
																						 e      As EventArgs) _
									Handles xrbtn_UM_Sync.CheckedChanged

			If Not IsNothing(Me.co_DPCurrent)
				If CType(sender, RadioButton).Checked
					Me.co_DPCurrent.CTU_Parameters.UpdMode  = "S"
				End If
			End If

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Events: Form"

		Friend ReadOnly Property IsProtected	As Boolean Implements	ixSAPSessionConfig.IsProtected
			Get
				Return	Me.co_WSProfile.IsProtected
			End Get
		End Property

		Friend ReadOnly Property Password	As String Implements	ixSAPSessionConfig.Password
			Get
				Return	Me.co_WSProfile.Password
			End Get
		End Property


		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xSAPtorBDCConfig_Load(sender  As Object,
																			e       As EventArgs) _
									Handles Me.Load

			Me.co_DPOriginal  = Me.co_WSProfile.BDCConfig
			Me.co_DPCurrent   = Me.co_DPOriginal
			Me.Configloaded   = True

			Me.UpdateView()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub ev_FormEscape(	sender	As Object,
																e				As KeyEventArgs) _
									Handles Me.KeyDown

			If e.KeyCode.Equals(Keys.Escape)	Then	Me.Close()

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Events: ToolStrip"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xtsb_Revert_Click(sender  As Object,
																	e       As EventArgs) _
									Handles xtsb_Revert.Click

			Me.co_DPCurrent = Me.co_DPOriginal
			Me.UpdateView()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xtsb_Save_Click(sender  As Object,
																e       As EventArgs) _
									Handles xtsb_Save.Click

			Dim lc_Msg	= "Worksheet:"
			Dim lc_Sub	= "Protection:"
			Dim lc_Addr	= Me.xlbl_ConfigAddr.Text.Trim
			'....................................................
			If lc_Addr.Length.Equals(0)
				so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone(String.Format("{0} CONFIG: Set address where to save", lc_Msg)))
				Exit Sub
			End If
			'....................................................
			If Not Me.co_Cntlr.WriteBDCConfigToWSheet(lc_Addr, Me.co_DPCurrent)
				so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone(String.Format("{0} CONFIG: Unable to write to sheet", lc_Msg)))
				Exit Sub
			End If
			'....................................................
			If CBool(IIf(Me.co_DPCurrent.IsProtected.Equals("X"), True, False))

				If so_HlprExcel.Value.ObscureCellContent(Me.co_WSProfile.WBookName, Me.co_WSProfile.WSheetName,	lc_Addr)

					If so_HlprExcel.Value.SetWSProtection(Me.co_WSProfile.WBookName, Me.co_WSProfile.WSheetName, Me.co_DPCurrent.Password)
						so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone(String.Format("{0} {1} On", lc_Msg, lc_Sub)))
					Else
						so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone(String.Format("{0} {1} Failed to protect", lc_Msg, lc_Sub)))
					End If

				End If

			Else

					If so_HlprExcel.Value.SetWSProtection(Me.co_WSProfile.WBookName, Me.co_WSProfile.WSheetName, Me.co_DPCurrent.Password,True)
						so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone(String.Format("{0} {1} Off", lc_Msg, lc_Sub)))
					Else
						so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone(String.Format("{0} {1} Failed to unprotect", lc_Msg, lc_Sub)))
					End If

			End If
			'....................................................
			Me.Close()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xtsb_Fetch_Click(sender  As Object,
																 e       As EventArgs) _
									Handles xtsb_Fetch.Click

			Me.co_WSProfile   = Me.co_Cntlr.GetWorkSheetProfile()
			Me.co_DPOriginal  = co_WSProfile.BDCConfig
			Me.co_DPCurrent   = Me.co_DPOriginal
			Me.Configloaded   = True

			Me.UpdateView()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xtsb_Cancel_Click(sender  As Object,
																 e       As EventArgs) _
									Handles xtsb_Cancel.Click

			Me.Close()

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Properties: Exposed"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Overloads ReadOnly Property IsDisposed() _
																				As Boolean _
																					Implements ixSAPSessionConfig.IsDisposed
			Get
				Return MyBase.IsDisposed()
			End Get
		End Property

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods: Exposed"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Sub HandleVisibility() _
								Implements ixSAPSessionConfig.HandleVisibility

			If Me.Visible
				If Me.WindowState = FormWindowState.Minimized
					Me.WindowState = FormWindowState.Normal
				Else
					Me.Hide()
				End If
			Else
				If Not Me.IsDisposed
					Me.Show()
				End If
			End If

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Private Properties"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cb_CfgLoaded  As Boolean

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

			'Me.xtsb_Fetch.Enabled   = Not Me.cb_CfgLoaded

			'Me.xtsb_Revert.Enabled  = Me.cb_CfgLoaded
			'Me.xtsb_Save.Enabled    = Me.cb_CfgLoaded

			'Me.xtsb_Cancel.Enabled  = True

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub UpdateView()

			Me.xcbx_DefSize.Checked       = CBool(IIf(CStr(Me.co_DPCurrent.CTU_Parameters.DefSize).ToUpperInvariant = "X"c, True, False ))
			Me.xcbx_WSActive.Checked      = CBool(IIf(CStr(Me.co_DPCurrent.IsActive).ToUpperInvariant = "X"c, True, False ))

			If IsNothing(Me.co_DPCurrent.IsProtected)
				Me.xcbx_WSProtect.Checked	= False
			Else
				Me.xcbx_WSProtect.Checked	= CBool(IIf(CStr(Me.co_DPCurrent.IsProtected).ToUpperInvariant = "X"c, True, False ))
			End If

			Me.xcbo_IntervalPause.Text    = CStr(Me.co_DPCurrent.PauseTime)

			Me.xlbl_ConfigAddr.Text       = Me.co_WSProfile.XMLConfigAddress.Address

			Me.xtbx_SAPTCode.Text         = Me.co_DPCurrent.SAPTCode
			Me.xtbx_SAPSessionID.Text			= Me.co_DPCurrent.SessionID

			If IsNothing(Me.co_DPCurrent.Password)
				Me.xtbx_Pwrd.Text	= ""
			Else
				Me.xtbx_Pwrd.Text	= Me.co_DPCurrent.Password
			End If

			Me.xlbl_ActiveColAddress.Text = Me.co_DPCurrent.Active_Column_Address
			Me.xlbl_MsgColAddress.Text		= Me.co_DPCurrent.MessageColumnAddress
			Me.xlbl_GUID.Text							= Me.co_DPCurrent.GUID

			Select Case Me.co_DPCurrent.CTU_Parameters.DisMode
					Case "A"c : Me.xrbtn_PM_All.Checked     = True
					Case "E"c : Me.xrbtn_PM_Errors.Checked  = True
					Case "N"c : Me.xrbtn_PM_BGrnd.Checked   = True
					Case Else : Me.xrbtn_PM_BGrnd.Checked   = True
			End Select

			Select Case Me.co_DPCurrent.CTU_Parameters.UpdMode
					Case "S"c : Me.xrbtn_UM_Sync.Checked  = True
					Case "A"c : Me.xrbtn_UM_ASync.Checked = True
					Case Else : Me.xrbtn_UM_ASync.Checked = True
			End Select

		End Sub
	
	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Constructors"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Sub New(ByVal controller As ixSessionController)

			InitializeComponent()

			Me.co_Cntlr	= controller

			Me.co_WSProfile   = Me.co_Cntlr.GetWorkSheetProfile()

			If IsNothing( Me.co_WSProfile.BDCConfig.CTU_Parameters.DefSize )
				Me.co_WSProfile.BDCConfig.CTU_Parameters.DefSize	= "X"
			End If

		End Sub

	#End Region

End Class