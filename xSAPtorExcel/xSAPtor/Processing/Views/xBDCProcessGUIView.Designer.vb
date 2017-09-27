<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xBDCProcessGUIView
	Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.xrbtn_PM_All = New System.Windows.Forms.RadioButton()
		Me.xrbtn_PM_Errors = New System.Windows.Forms.RadioButton()
		Me.xrbtn_PM_BGrnd = New System.Windows.Forms.RadioButton()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.xrbtn_UM_Sync = New System.Windows.Forms.RadioButton()
		Me.xrbtn_UM_ASync = New System.Windows.Forms.RadioButton()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.xcbx_DefSize = New System.Windows.Forms.CheckBox()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.xlbl_GUID = New System.Windows.Forms.Label()
		Me.xbtn_ConfigAddr = New System.Windows.Forms.Button()
		Me.xlbl_ConfigAddr = New System.Windows.Forms.Label()
		Me.xcbx_WSActive = New System.Windows.Forms.CheckBox()
		Me.xtbx_SAPTCode = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.GroupBox5 = New System.Windows.Forms.GroupBox()
		Me.xlbl_ActiveColAddress = New System.Windows.Forms.Label()
		Me.xBtn_ActiveColAddress = New System.Windows.Forms.Button()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.xcbo_IntervalPause = New System.Windows.Forms.ComboBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.xtsb_Fetch = New System.Windows.Forms.ToolStripButton()
		Me.xtsb_Save = New System.Windows.Forms.ToolStripButton()
		Me.xtsb_Revert = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.xtsb_Cancel = New System.Windows.Forms.ToolStripButton()
		Me.GroupBox1.SuspendLayout
		Me.GroupBox2.SuspendLayout
		Me.GroupBox3.SuspendLayout
		Me.GroupBox4.SuspendLayout
		Me.GroupBox5.SuspendLayout
		Me.ToolStrip1.SuspendLayout
		Me.SuspendLayout
		'
		'xrbtn_PM_All
		'
		Me.xrbtn_PM_All.AutoSize = true
		Me.xrbtn_PM_All.Location = New System.Drawing.Point(6, 31)
		Me.xrbtn_PM_All.Name = "xrbtn_PM_All"
		Me.xrbtn_PM_All.Size = New System.Drawing.Size(162, 20)
		Me.xrbtn_PM_All.TabIndex = 0
		Me.xrbtn_PM_All.Text = "Shows All screens"
		Me.xrbtn_PM_All.UseVisualStyleBackColor = true
		'
		'xrbtn_PM_Errors
		'
		Me.xrbtn_PM_Errors.AutoSize = true
		Me.xrbtn_PM_Errors.Location = New System.Drawing.Point(6, 54)
		Me.xrbtn_PM_Errors.Name = "xrbtn_PM_Errors"
		Me.xrbtn_PM_Errors.Size = New System.Drawing.Size(154, 20)
		Me.xrbtn_PM_Errors.TabIndex = 1
		Me.xrbtn_PM_Errors.Text = "Show only errors"
		Me.xrbtn_PM_Errors.UseVisualStyleBackColor = true
		'
		'xrbtn_PM_BGrnd
		'
		Me.xrbtn_PM_BGrnd.AutoSize = true
		Me.xrbtn_PM_BGrnd.Checked = true
		Me.xrbtn_PM_BGrnd.Location = New System.Drawing.Point(6, 77)
		Me.xrbtn_PM_BGrnd.Name = "xrbtn_PM_BGrnd"
		Me.xrbtn_PM_BGrnd.Size = New System.Drawing.Size(194, 20)
		Me.xrbtn_PM_BGrnd.TabIndex = 2
		Me.xrbtn_PM_BGrnd.TabStop = true
		Me.xrbtn_PM_BGrnd.Text = "Background Processing"
		Me.xrbtn_PM_BGrnd.UseVisualStyleBackColor = true
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.xrbtn_UM_Sync)
		Me.GroupBox1.Controls.Add(Me.xrbtn_UM_ASync)
		Me.GroupBox1.Location = New System.Drawing.Point(216, 23)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(148, 106)
		Me.GroupBox1.TabIndex = 3
		Me.GroupBox1.TabStop = false
		Me.GroupBox1.Text = "Update Mode"
		'
		'xrbtn_UM_Sync
		'
		Me.xrbtn_UM_Sync.AutoSize = true
		Me.xrbtn_UM_Sync.Location = New System.Drawing.Point(19, 54)
		Me.xrbtn_UM_Sync.Name = "xrbtn_UM_Sync"
		Me.xrbtn_UM_Sync.Size = New System.Drawing.Size(114, 20)
		Me.xrbtn_UM_Sync.TabIndex = 1
		Me.xrbtn_UM_Sync.Text = "Synchronous"
		Me.xrbtn_UM_Sync.UseVisualStyleBackColor = true
		'
		'xrbtn_UM_ASync
		'
		Me.xrbtn_UM_ASync.AutoSize = true
		Me.xrbtn_UM_ASync.Checked = true
		Me.xrbtn_UM_ASync.Location = New System.Drawing.Point(19, 32)
		Me.xrbtn_UM_ASync.Name = "xrbtn_UM_ASync"
		Me.xrbtn_UM_ASync.Size = New System.Drawing.Size(122, 20)
		Me.xrbtn_UM_ASync.TabIndex = 0
		Me.xrbtn_UM_ASync.TabStop = true
		Me.xrbtn_UM_ASync.Text = "Asynchronous"
		Me.xrbtn_UM_ASync.UseVisualStyleBackColor = true
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.xrbtn_PM_BGrnd)
		Me.GroupBox2.Controls.Add(Me.xrbtn_PM_All)
		Me.GroupBox2.Controls.Add(Me.xrbtn_PM_Errors)
		Me.GroupBox2.Location = New System.Drawing.Point(8, 23)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(201, 106)
		Me.GroupBox2.TabIndex = 2
		Me.GroupBox2.TabStop = false
		Me.GroupBox2.Text = "Processing Mode"
		'
		'xcbx_DefSize
		'
		Me.xcbx_DefSize.AutoSize = true
		Me.xcbx_DefSize.Checked = true
		Me.xcbx_DefSize.CheckState = System.Windows.Forms.CheckState.Checked
		Me.xcbx_DefSize.Location = New System.Drawing.Point(14, 135)
		Me.xcbx_DefSize.Name = "xcbx_DefSize"
		Me.xcbx_DefSize.Size = New System.Drawing.Size(155, 20)
		Me.xcbx_DefSize.TabIndex = 4
		Me.xcbx_DefSize.Text = "Use Default Size"
		Me.xcbx_DefSize.UseVisualStyleBackColor = true
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.Label5)
		Me.GroupBox3.Controls.Add(Me.xlbl_GUID)
		Me.GroupBox3.Controls.Add(Me.xbtn_ConfigAddr)
		Me.GroupBox3.Controls.Add(Me.xlbl_ConfigAddr)
		Me.GroupBox3.Controls.Add(Me.xcbx_WSActive)
		Me.GroupBox3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox3.Location = New System.Drawing.Point(12, 28)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Padding = New System.Windows.Forms.Padding(5)
		Me.GroupBox3.Size = New System.Drawing.Size(372, 85)
		Me.GroupBox3.TabIndex = 1
		Me.GroupBox3.TabStop = false
		Me.GroupBox3.Text = "Config Directives:"
		'
		'Label5
		'
		Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.Location = New System.Drawing.Point(8, 20)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(54, 23)
		Me.Label5.TabIndex = 7
		Me.Label5.Text = "ID:"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'xlbl_GUID
		'
		Me.xlbl_GUID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.xlbl_GUID.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.xlbl_GUID.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.xlbl_GUID.Location = New System.Drawing.Point(68, 20)
		Me.xlbl_GUID.Name = "xlbl_GUID"
		Me.xlbl_GUID.Size = New System.Drawing.Size(296, 23)
		Me.xlbl_GUID.TabIndex = 6
		Me.xlbl_GUID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'xbtn_ConfigAddr
		'
		Me.xbtn_ConfigAddr.Image = Global.xSAPtorExcel.My.Resources.Resources.Bitmap_editor
		Me.xbtn_ConfigAddr.Location = New System.Drawing.Point(341, 50)
		Me.xbtn_ConfigAddr.Name = "xbtn_ConfigAddr"
		Me.xbtn_ConfigAddr.Size = New System.Drawing.Size(23, 23)
		Me.xbtn_ConfigAddr.TabIndex = 0
		Me.xbtn_ConfigAddr.TabStop = false
		Me.xbtn_ConfigAddr.UseVisualStyleBackColor = true
		'
		'xlbl_ConfigAddr
		'
		Me.xlbl_ConfigAddr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.xlbl_ConfigAddr.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.xlbl_ConfigAddr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.xlbl_ConfigAddr.Location = New System.Drawing.Point(234, 50)
		Me.xlbl_ConfigAddr.Name = "xlbl_ConfigAddr"
		Me.xlbl_ConfigAddr.Size = New System.Drawing.Size(100, 23)
		Me.xlbl_ConfigAddr.TabIndex = 0
		Me.xlbl_ConfigAddr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'xcbx_WSActive
		'
		Me.xcbx_WSActive.AutoSize = true
		Me.xcbx_WSActive.Location = New System.Drawing.Point(68, 52)
		Me.xcbx_WSActive.Name = "xcbx_WSActive"
		Me.xcbx_WSActive.Size = New System.Drawing.Size(75, 20)
		Me.xcbx_WSActive.TabIndex = 5
		Me.xcbx_WSActive.Text = "Active"
		Me.xcbx_WSActive.UseVisualStyleBackColor = true
		'
		'xtbx_SAPTCode
		'
		Me.xtbx_SAPTCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.xtbx_SAPTCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.xtbx_SAPTCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.xtbx_SAPTCode.Location = New System.Drawing.Point(235, 23)
		Me.xtbx_SAPTCode.MaxLength = 30
		Me.xtbx_SAPTCode.Name = "xtbx_SAPTCode"
		Me.xtbx_SAPTCode.Size = New System.Drawing.Size(129, 22)
		Me.xtbx_SAPTCode.TabIndex = 1
		Me.xtbx_SAPTCode.WordWrap = false
		'
		'Label1
		'
		Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(14, 23)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(215, 23)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "SAP Transaction Code:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.xcbx_DefSize)
		Me.GroupBox4.Controls.Add(Me.GroupBox1)
		Me.GroupBox4.Controls.Add(Me.GroupBox2)
		Me.GroupBox4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox4.Location = New System.Drawing.Point(12, 119)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Padding = New System.Windows.Forms.Padding(5)
		Me.GroupBox4.Size = New System.Drawing.Size(372, 163)
		Me.GroupBox4.TabIndex = 2
		Me.GroupBox4.TabStop = false
		Me.GroupBox4.Text = "BDC Directives:"
		'
		'GroupBox5
		'
		Me.GroupBox5.Controls.Add(Me.xlbl_ActiveColAddress)
		Me.GroupBox5.Controls.Add(Me.xBtn_ActiveColAddress)
		Me.GroupBox5.Controls.Add(Me.Label3)
		Me.GroupBox5.Controls.Add(Me.xtbx_SAPTCode)
		Me.GroupBox5.Controls.Add(Me.Label1)
		Me.GroupBox5.Controls.Add(Me.xcbo_IntervalPause)
		Me.GroupBox5.Controls.Add(Me.Label2)
		Me.GroupBox5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox5.Location = New System.Drawing.Point(12, 288)
		Me.GroupBox5.Name = "GroupBox5"
		Me.GroupBox5.Padding = New System.Windows.Forms.Padding(5)
		Me.GroupBox5.Size = New System.Drawing.Size(372, 127)
		Me.GroupBox5.TabIndex = 3
		Me.GroupBox5.TabStop = false
		Me.GroupBox5.Text = "Processing Directives:"
		'
		'xlbl_ActiveColAddress
		'
		Me.xlbl_ActiveColAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.xlbl_ActiveColAddress.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.xlbl_ActiveColAddress.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.xlbl_ActiveColAddress.Location = New System.Drawing.Point(235, 85)
		Me.xlbl_ActiveColAddress.Name = "xlbl_ActiveColAddress"
		Me.xlbl_ActiveColAddress.Size = New System.Drawing.Size(100, 23)
		Me.xlbl_ActiveColAddress.TabIndex = 7
		Me.xlbl_ActiveColAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'xBtn_ActiveColAddress
		'
		Me.xBtn_ActiveColAddress.Image = Global.xSAPtorExcel.My.Resources.Resources.Bitmap_editor
		Me.xBtn_ActiveColAddress.Location = New System.Drawing.Point(341, 85)
		Me.xBtn_ActiveColAddress.Name = "xBtn_ActiveColAddress"
		Me.xBtn_ActiveColAddress.Size = New System.Drawing.Size(23, 23)
		Me.xBtn_ActiveColAddress.TabIndex = 4
		Me.xBtn_ActiveColAddress.UseVisualStyleBackColor = true
		'
		'Label3
		'
		Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(8, 85)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(221, 23)
		Me.Label3.TabIndex = 6
		Me.Label3.Text = "Active Column Address:"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'xcbo_IntervalPause
		'
		Me.xcbo_IntervalPause.FormatString = "N0"
		Me.xcbo_IntervalPause.FormattingEnabled = true
		Me.xcbo_IntervalPause.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
		Me.xcbo_IntervalPause.Location = New System.Drawing.Point(235, 51)
		Me.xcbo_IntervalPause.MaxDropDownItems = 10
		Me.xcbo_IntervalPause.MaxLength = 1
		Me.xcbo_IntervalPause.Name = "xcbo_IntervalPause"
		Me.xcbo_IntervalPause.Size = New System.Drawing.Size(44, 24)
		Me.xcbo_IntervalPause.TabIndex = 5
		Me.xcbo_IntervalPause.Text = "0"
		'
		'Label2
		'
		Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(11, 51)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(218, 23)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "Interval Pause:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'ToolStrip1
		'
		Me.ToolStrip1.CanOverflow = false
		Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.xtsb_Fetch, Me.xtsb_Save, Me.xtsb_Revert, Me.ToolStripSeparator1, Me.xtsb_Cancel})
		Me.ToolStrip1.Location = New System.Drawing.Point(1, 1)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(1)
		Me.ToolStrip1.Size = New System.Drawing.Size(391, 25)
		Me.ToolStrip1.TabIndex = 0
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'xtsb_Fetch
		'
		Me.xtsb_Fetch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xtsb_Fetch.Image = Global.xSAPtorExcel.My.Resources.Resources.Synchronize
		Me.xtsb_Fetch.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xtsb_Fetch.Name = "xtsb_Fetch"
		Me.xtsb_Fetch.Size = New System.Drawing.Size(23, 20)
		Me.xtsb_Fetch.Text = "Fetch Active Sheet Config"
		'
		'xtsb_Save
		'
		Me.xtsb_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xtsb_Save.Image = Global.xSAPtorExcel.My.Resources.Resources.Save
		Me.xtsb_Save.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xtsb_Save.Name = "xtsb_Save"
		Me.xtsb_Save.Size = New System.Drawing.Size(23, 20)
		Me.xtsb_Save.Text = "Save To Sheet"
		'
		'xtsb_Revert
		'
		Me.xtsb_Revert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xtsb_Revert.Image = Global.xSAPtorExcel.My.Resources.Resources.Revert
		Me.xtsb_Revert.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xtsb_Revert.Name = "xtsb_Revert"
		Me.xtsb_Revert.Size = New System.Drawing.Size(23, 20)
		Me.xtsb_Revert.Text = "Reverse All Changes"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
		'
		'xtsb_Cancel
		'
		Me.xtsb_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xtsb_Cancel.Image = Global.xSAPtorExcel.My.Resources.Resources.Cancel
		Me.xtsb_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xtsb_Cancel.Name = "xtsb_Cancel"
		Me.xtsb_Cancel.Size = New System.Drawing.Size(23, 20)
		Me.xtsb_Cancel.Text = "ToolStripButton1"
		'
		'xSAPBDCConfig
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(393, 423)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Controls.Add(Me.GroupBox5)
		Me.Controls.Add(Me.GroupBox4)
		Me.Controls.Add(Me.GroupBox3)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		Me.HelpButton = true
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "xSAPBDCConfig"
		Me.Padding = New System.Windows.Forms.Padding(1)
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "Configure Sheet"
		Me.TopMost = true
		Me.GroupBox1.ResumeLayout(false)
		Me.GroupBox1.PerformLayout
		Me.GroupBox2.ResumeLayout(false)
		Me.GroupBox2.PerformLayout
		Me.GroupBox3.ResumeLayout(false)
		Me.GroupBox3.PerformLayout
		Me.GroupBox4.ResumeLayout(false)
		Me.GroupBox4.PerformLayout
		Me.GroupBox5.ResumeLayout(false)
		Me.GroupBox5.PerformLayout
		Me.ToolStrip1.ResumeLayout(false)
		Me.ToolStrip1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout

	End Sub
	Friend WithEvents xrbtn_PM_BGrnd As Windows.Forms.RadioButton
	Friend WithEvents xrbtn_PM_Errors As Windows.Forms.RadioButton
	Friend WithEvents xrbtn_PM_All As Windows.Forms.RadioButton
	Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
	Friend WithEvents xrbtn_UM_Sync As Windows.Forms.RadioButton
	Friend WithEvents xrbtn_UM_ASync As Windows.Forms.RadioButton
	Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
	Friend WithEvents xcbx_DefSize As Windows.Forms.CheckBox
	Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
	Friend WithEvents xtbx_SAPTCode As Windows.Forms.TextBox
	Friend WithEvents Label1 As Windows.Forms.Label
	Friend WithEvents GroupBox4 As Windows.Forms.GroupBox
	Friend WithEvents GroupBox5 As Windows.Forms.GroupBox
	Friend WithEvents Label2 As Windows.Forms.Label
	Friend WithEvents xcbo_IntervalPause As Windows.Forms.ComboBox
	Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
	Friend WithEvents xtsb_Save As Windows.Forms.ToolStripButton
	Friend WithEvents xtsb_Revert As Windows.Forms.ToolStripButton
	Friend WithEvents xtsb_Fetch As Windows.Forms.ToolStripButton
	Friend WithEvents xBtn_ActiveColAddress As Windows.Forms.Button
	Friend WithEvents Label3 As Windows.Forms.Label
	Friend WithEvents xlbl_ActiveColAddress As Windows.Forms.Label
	Friend WithEvents xbtn_ConfigAddr As Windows.Forms.Button
	Friend WithEvents xlbl_ConfigAddr As Windows.Forms.Label
	Friend WithEvents xcbx_WSActive As Windows.Forms.CheckBox
	Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
	Friend WithEvents xtsb_Cancel As Windows.Forms.ToolStripButton
	Friend WithEvents Label5 As Windows.Forms.Label
	Friend WithEvents xlbl_GUID As Windows.Forms.Label
End Class
