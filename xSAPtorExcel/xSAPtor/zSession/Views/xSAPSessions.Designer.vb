<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xSAPSessions
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
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.xdtp_To = New System.Windows.Forms.DateTimePicker()
		Me.xdtp_From = New System.Windows.Forms.DateTimePicker()
		Me.xdgv_Sessions = New System.Windows.Forms.DataGridView()
		Me.xtbx_UserName = New System.Windows.Forms.TextBox()
		Me.xtbx_SessionID = New System.Windows.Forms.TextBox()
		Me.xlbl_UserName = New System.Windows.Forms.Label()
		Me.xlbl_SessionID = New System.Windows.Forms.Label()
		Me.xlbl_DateFrom = New System.Windows.Forms.Label()
		Me.xlbl_DateTo = New System.Windows.Forms.Label()
		Me.xtss_StatusBar = New System.Windows.Forms.StatusStrip()
		Me.xtss_lbl_Status = New System.Windows.Forms.ToolStripStatusLabel()
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
		Me.xbtn_tss_ResetSelection = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_tss_FetchSAP = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.xbtn_tss_CreateWS = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_tss_Cancel = New System.Windows.Forms.ToolStripButton()
		Me.xpbr_tss_PBar = New System.Windows.Forms.ToolStripProgressBar()
		CType(Me.xdgv_Sessions,System.ComponentModel.ISupportInitialize).BeginInit
		Me.xtss_StatusBar.SuspendLayout
		CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SplitContainer1.Panel1.SuspendLayout
		Me.SplitContainer1.Panel2.SuspendLayout
		Me.SplitContainer1.SuspendLayout
		Me.Panel1.SuspendLayout
		Me.ToolStrip2.SuspendLayout
		Me.SuspendLayout
		'
		'xdtp_To
		'
		Me.xdtp_To.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xdtp_To.Location = New System.Drawing.Point(328, 33)
		Me.xdtp_To.MaxDate = New Date(2200, 12, 31, 0, 0, 0, 0)
		Me.xdtp_To.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
		Me.xdtp_To.Name = "xdtp_To"
		Me.xdtp_To.Size = New System.Drawing.Size(180, 22)
		Me.xdtp_To.TabIndex = 4
		'
		'xdtp_From
		'
		Me.xdtp_From.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xdtp_From.Location = New System.Drawing.Point(328, 5)
		Me.xdtp_From.MaxDate = New Date(2200, 12, 31, 0, 0, 0, 0)
		Me.xdtp_From.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
		Me.xdtp_From.Name = "xdtp_From"
		Me.xdtp_From.Size = New System.Drawing.Size(180, 22)
		Me.xdtp_From.TabIndex = 3
		'
		'xdgv_Sessions
		'
		Me.xdgv_Sessions.AllowUserToAddRows = false
		Me.xdgv_Sessions.AllowUserToDeleteRows = false
		Me.xdgv_Sessions.AllowUserToOrderColumns = true
		Me.xdgv_Sessions.AllowUserToResizeRows = false
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(192,Byte),Integer))
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
		Me.xdgv_Sessions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.xdgv_Sessions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.xdgv_Sessions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.xdgv_Sessions.CausesValidation = false
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 9!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.xdgv_Sessions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
		Me.xdgv_Sessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.xdgv_Sessions.Dock = System.Windows.Forms.DockStyle.Fill
		Me.xdgv_Sessions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
		Me.xdgv_Sessions.Location = New System.Drawing.Point(5, 5)
		Me.xdgv_Sessions.Name = "xdgv_Sessions"
		Me.xdgv_Sessions.ReadOnly = true
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.xdgv_Sessions.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
		Me.xdgv_Sessions.RowHeadersWidth = 20
		DataGridViewCellStyle4.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xdgv_Sessions.RowsDefaultCellStyle = DataGridViewCellStyle4
		Me.xdgv_Sessions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.xdgv_Sessions.ShowCellErrors = false
		Me.xdgv_Sessions.ShowCellToolTips = false
		Me.xdgv_Sessions.ShowEditingIcon = false
		Me.xdgv_Sessions.ShowRowErrors = false
		Me.xdgv_Sessions.Size = New System.Drawing.Size(519, 273)
		Me.xdgv_Sessions.StandardTab = true
		Me.xdgv_Sessions.TabIndex = 5
		'
		'xtbx_UserName
		'
		Me.xtbx_UserName.Location = New System.Drawing.Point(129, 5)
		Me.xtbx_UserName.Name = "xtbx_UserName"
		Me.xtbx_UserName.Size = New System.Drawing.Size(100, 22)
		Me.xtbx_UserName.TabIndex = 1
		'
		'xtbx_SessionID
		'
		Me.xtbx_SessionID.Location = New System.Drawing.Point(129, 33)
		Me.xtbx_SessionID.Name = "xtbx_SessionID"
		Me.xtbx_SessionID.Size = New System.Drawing.Size(100, 22)
		Me.xtbx_SessionID.TabIndex = 2
		'
		'xlbl_UserName
		'
		Me.xlbl_UserName.BackColor = System.Drawing.SystemColors.Control
		Me.xlbl_UserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.xlbl_UserName.CausesValidation = false
		Me.xlbl_UserName.Location = New System.Drawing.Point(4, 5)
		Me.xlbl_UserName.Margin = New System.Windows.Forms.Padding(2)
		Me.xlbl_UserName.MaximumSize = New System.Drawing.Size(130, 22)
		Me.xlbl_UserName.Name = "xlbl_UserName"
		Me.xlbl_UserName.Padding = New System.Windows.Forms.Padding(1)
		Me.xlbl_UserName.Size = New System.Drawing.Size(120, 22)
		Me.xlbl_UserName.TabIndex = 0
		Me.xlbl_UserName.Text = "UserName:"
		Me.xlbl_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'xlbl_SessionID
		'
		Me.xlbl_SessionID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.xlbl_SessionID.CausesValidation = false
		Me.xlbl_SessionID.Location = New System.Drawing.Point(2, 33)
		Me.xlbl_SessionID.Margin = New System.Windows.Forms.Padding(2)
		Me.xlbl_SessionID.MaximumSize = New System.Drawing.Size(130, 22)
		Me.xlbl_SessionID.Name = "xlbl_SessionID"
		Me.xlbl_SessionID.Padding = New System.Windows.Forms.Padding(1)
		Me.xlbl_SessionID.Size = New System.Drawing.Size(122, 22)
		Me.xlbl_SessionID.TabIndex = 7
		Me.xlbl_SessionID.Text = "Session ID:"
		Me.xlbl_SessionID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'xlbl_DateFrom
		'
		Me.xlbl_DateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xlbl_DateFrom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.xlbl_DateFrom.CausesValidation = false
		Me.xlbl_DateFrom.Location = New System.Drawing.Point(253, 5)
		Me.xlbl_DateFrom.Margin = New System.Windows.Forms.Padding(2)
		Me.xlbl_DateFrom.MaximumSize = New System.Drawing.Size(130, 22)
		Me.xlbl_DateFrom.Name = "xlbl_DateFrom"
		Me.xlbl_DateFrom.Padding = New System.Windows.Forms.Padding(1)
		Me.xlbl_DateFrom.Size = New System.Drawing.Size(67, 22)
		Me.xlbl_DateFrom.TabIndex = 0
		Me.xlbl_DateFrom.Text = "From:"
		Me.xlbl_DateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'xlbl_DateTo
		'
		Me.xlbl_DateTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xlbl_DateTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.xlbl_DateTo.CausesValidation = false
		Me.xlbl_DateTo.Location = New System.Drawing.Point(253, 33)
		Me.xlbl_DateTo.Margin = New System.Windows.Forms.Padding(2)
		Me.xlbl_DateTo.MaximumSize = New System.Drawing.Size(130, 22)
		Me.xlbl_DateTo.Name = "xlbl_DateTo"
		Me.xlbl_DateTo.Padding = New System.Windows.Forms.Padding(1)
		Me.xlbl_DateTo.Size = New System.Drawing.Size(67, 22)
		Me.xlbl_DateTo.TabIndex = 0
		Me.xlbl_DateTo.Text = "To:"
		Me.xlbl_DateTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'xtss_StatusBar
		'
		Me.xtss_StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.xtss_lbl_Status})
		Me.xtss_StatusBar.Location = New System.Drawing.Point(0, 404)
		Me.xtss_StatusBar.Name = "xtss_StatusBar"
		Me.xtss_StatusBar.Size = New System.Drawing.Size(529, 22)
		Me.xtss_StatusBar.TabIndex = 9
		Me.xtss_StatusBar.Text = "StatusStrip1"
		'
		'xtss_lbl_Status
		'
		Me.xtss_lbl_Status.Name = "xtss_lbl_Status"
		Me.xtss_lbl_Status.Size = New System.Drawing.Size(131, 17)
		Me.xtss_lbl_Status.Text = "Set Criteria and Fetch...."
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 41)
		Me.SplitContainer1.Name = "SplitContainer1"
		Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
		Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(5, 5, 5, 0)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.xdgv_Sessions)
		Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(5)
		Me.SplitContainer1.Size = New System.Drawing.Size(529, 363)
		Me.SplitContainer1.SplitterDistance = 76
		Me.SplitContainer1.TabIndex = 10
		'
		'Panel1
		'
		Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Panel1.Controls.Add(Me.xdtp_From)
		Me.Panel1.Controls.Add(Me.xdtp_To)
		Me.Panel1.Controls.Add(Me.xlbl_UserName)
		Me.Panel1.Controls.Add(Me.xlbl_DateFrom)
		Me.Panel1.Controls.Add(Me.xlbl_DateTo)
		Me.Panel1.Controls.Add(Me.xlbl_SessionID)
		Me.Panel1.Controls.Add(Me.xtbx_UserName)
		Me.Panel1.Controls.Add(Me.xtbx_SessionID)
		Me.Panel1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Panel1.Location = New System.Drawing.Point(11, 7)
		Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Padding = New System.Windows.Forms.Padding(2)
		Me.Panel1.Size = New System.Drawing.Size(513, 63)
		Me.Panel1.TabIndex = 11
		'
		'ToolStrip2
		'
		Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(30, 30)
		Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.xbtn_tss_ResetSelection, Me.xbtn_tss_FetchSAP, Me.ToolStripSeparator2, Me.xbtn_tss_CreateWS, Me.xbtn_tss_Cancel, Me.xpbr_tss_PBar})
		Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip2.Name = "ToolStrip2"
		Me.ToolStrip2.Padding = New System.Windows.Forms.Padding(2)
		Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
		Me.ToolStrip2.Size = New System.Drawing.Size(529, 41)
		Me.ToolStrip2.TabIndex = 12
		'
		'xbtn_tss_ResetSelection
		'
		Me.xbtn_tss_ResetSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_tss_ResetSelection.Image = Global.xSAPtorExcel.My.Resources.Resources.Revert
		Me.xbtn_tss_ResetSelection.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_tss_ResetSelection.Name = "xbtn_tss_ResetSelection"
		Me.xbtn_tss_ResetSelection.Size = New System.Drawing.Size(34, 34)
		Me.xbtn_tss_ResetSelection.Text = "Reset all selections"
		'
		'xbtn_tss_FetchSAP
		'
		Me.xbtn_tss_FetchSAP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_tss_FetchSAP.Image = Global.xSAPtorExcel.My.Resources.Resources.Synchronize
		Me.xbtn_tss_FetchSAP.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_tss_FetchSAP.Name = "xbtn_tss_FetchSAP"
		Me.xbtn_tss_FetchSAP.Size = New System.Drawing.Size(34, 34)
		Me.xbtn_tss_FetchSAP.Text = "Collection sessions from SAP"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 37)
		'
		'xbtn_tss_CreateWS
		'
		Me.xbtn_tss_CreateWS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_tss_CreateWS.Image = Global.xSAPtorExcel.My.Resources.Resources.Registry
		Me.xbtn_tss_CreateWS.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_tss_CreateWS.Name = "xbtn_tss_CreateWS"
		Me.xbtn_tss_CreateWS.Size = New System.Drawing.Size(34, 34)
		Me.xbtn_tss_CreateWS.Text = "Build worksheet templates"
		'
		'xbtn_tss_Cancel
		'
		Me.xbtn_tss_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_tss_Cancel.Image = Global.xSAPtorExcel.My.Resources.Resources.Cancel
		Me.xbtn_tss_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_tss_Cancel.Name = "xbtn_tss_Cancel"
		Me.xbtn_tss_Cancel.Size = New System.Drawing.Size(34, 34)
		Me.xbtn_tss_Cancel.Text = "Stop Build processing"
		Me.xbtn_tss_Cancel.Visible = false
		'
		'xpbr_tss_PBar
		'
		Me.xpbr_tss_PBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.xpbr_tss_PBar.CausesValidation = false
		Me.xpbr_tss_PBar.Name = "xpbr_tss_PBar"
		Me.xpbr_tss_PBar.Padding = New System.Windows.Forms.Padding(2)
		Me.xpbr_tss_PBar.Size = New System.Drawing.Size(104, 34)
		Me.xpbr_tss_PBar.Visible = false
		'
		'xSAPSessions
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(529, 426)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.ToolStrip2)
		Me.Controls.Add(Me.xtss_StatusBar)
		Me.KeyPreview = true
		Me.Name = "xSAPSessions"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Sessions"
		Me.TopMost = true
		CType(Me.xdgv_Sessions,System.ComponentModel.ISupportInitialize).EndInit
		Me.xtss_StatusBar.ResumeLayout(false)
		Me.xtss_StatusBar.PerformLayout
		Me.SplitContainer1.Panel1.ResumeLayout(false)
		Me.SplitContainer1.Panel2.ResumeLayout(false)
		CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
		Me.SplitContainer1.ResumeLayout(false)
		Me.Panel1.ResumeLayout(false)
		Me.Panel1.PerformLayout
		Me.ToolStrip2.ResumeLayout(false)
		Me.ToolStrip2.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

  Friend WithEvents xdtp_To As Windows.Forms.DateTimePicker
  Friend WithEvents xdtp_From As Windows.Forms.DateTimePicker
  Friend WithEvents xdgv_Sessions As Windows.Forms.DataGridView
  Friend WithEvents xtbx_UserName As Windows.Forms.TextBox
  Friend WithEvents xtbx_SessionID As Windows.Forms.TextBox
  Friend WithEvents xlbl_UserName As Windows.Forms.Label
  Friend WithEvents xlbl_SessionID As Windows.Forms.Label
  Friend WithEvents xlbl_DateFrom As Windows.Forms.Label
  Friend WithEvents xlbl_DateTo As Windows.Forms.Label
  Friend WithEvents xtss_StatusBar As Windows.Forms.StatusStrip
  Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
  Friend WithEvents Panel1 As Windows.Forms.Panel
  Friend WithEvents xtss_lbl_Status As Windows.Forms.ToolStripStatusLabel
  Friend WithEvents ToolStrip2 As Windows.Forms.ToolStrip
  Friend WithEvents xbtn_tss_ResetSelection As Windows.Forms.ToolStripButton
  Friend WithEvents xbtn_tss_FetchSAP As Windows.Forms.ToolStripButton
  Friend WithEvents xbtn_tss_CreateWS As Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
  Friend WithEvents xbtn_tss_Cancel As Windows.Forms.ToolStripButton
	Friend WithEvents xpbr_tss_PBar As Windows.Forms.ToolStripProgressBar
End Class
