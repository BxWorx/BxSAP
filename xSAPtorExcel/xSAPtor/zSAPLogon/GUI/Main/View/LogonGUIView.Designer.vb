<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogonGUIView
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogonGUIView))
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.xdgv_SAPSys = New System.Windows.Forms.DataGridView()
		Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
		Me.xpnl_User = New System.Windows.Forms.Panel()
		Me.xpnl_System = New System.Windows.Forms.Panel()
		Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.xbtn_ts_ConnSetup = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_ts_Options = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.xbtn_ts_LoadXML = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.xbtn_ts_SAPSysSelect = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_ts_SAPSysPing = New System.Windows.Forms.ToolStripButton()
		Me.xtbx_ts_SAPSys = New System.Windows.Forms.ToolStripTextBox()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.SID = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.SystemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.SystemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
		CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SplitContainer1.Panel1.SuspendLayout
		Me.SplitContainer1.Panel2.SuspendLayout
		Me.SplitContainer1.SuspendLayout
		Me.Panel1.SuspendLayout
		CType(Me.xdgv_SAPSys,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SplitContainer2.Panel1.SuspendLayout
		Me.SplitContainer2.Panel2.SuspendLayout
		Me.SplitContainer2.SuspendLayout
		Me.ToolStripContainer1.ContentPanel.SuspendLayout
		Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout
		Me.ToolStripContainer1.SuspendLayout
		Me.ToolStrip1.SuspendLayout
		Me.SuspendLayout
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(10, 5, 10, 3)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
		Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(3)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
		Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(5)
		Me.SplitContainer1.Size = New System.Drawing.Size(828, 484)
		Me.SplitContainer1.SplitterDistance = 340
		Me.SplitContainer1.TabIndex = 1
		Me.SplitContainer1.TabStop = false
		'
		'Panel1
		'
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Panel1.Controls.Add(Me.xdgv_SAPSys)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel1.Location = New System.Drawing.Point(3, 3)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(334, 478)
		Me.Panel1.TabIndex = 0
		'
		'xdgv_SAPSys
		'
		Me.xdgv_SAPSys.AllowUserToAddRows = false
		Me.xdgv_SAPSys.AllowUserToDeleteRows = false
		Me.xdgv_SAPSys.AllowUserToResizeRows = false
		Me.xdgv_SAPSys.BackgroundColor = System.Drawing.SystemColors.ControlLight
		Me.xdgv_SAPSys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.xdgv_SAPSys.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SID, Me.SystemName, Me.SystemID})
		Me.xdgv_SAPSys.Dock = System.Windows.Forms.DockStyle.Fill
		Me.xdgv_SAPSys.GridColor = System.Drawing.SystemColors.Control
		Me.xdgv_SAPSys.Location = New System.Drawing.Point(0, 0)
		Me.xdgv_SAPSys.MultiSelect = false
		Me.xdgv_SAPSys.Name = "xdgv_SAPSys"
		Me.xdgv_SAPSys.ReadOnly = true
		Me.xdgv_SAPSys.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.xdgv_SAPSys.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.xdgv_SAPSys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.xdgv_SAPSys.Size = New System.Drawing.Size(330, 474)
		Me.xdgv_SAPSys.TabIndex = 1
		'
		'SplitContainer2
		'
		Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer2.Location = New System.Drawing.Point(5, 5)
		Me.SplitContainer2.Name = "SplitContainer2"
		Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer2.Panel1
		'
		Me.SplitContainer2.Panel1.Controls.Add(Me.xpnl_User)
		'
		'SplitContainer2.Panel2
		'
		Me.SplitContainer2.Panel2.Controls.Add(Me.xpnl_System)
		Me.SplitContainer2.Size = New System.Drawing.Size(474, 474)
		Me.SplitContainer2.SplitterDistance = 202
		Me.SplitContainer2.SplitterWidth = 5
		Me.SplitContainer2.TabIndex = 0
		Me.SplitContainer2.TabStop = false
		'
		'xpnl_User
		'
		Me.xpnl_User.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.xpnl_User.Dock = System.Windows.Forms.DockStyle.Fill
		Me.xpnl_User.Location = New System.Drawing.Point(0, 0)
		Me.xpnl_User.Name = "xpnl_User"
		Me.xpnl_User.Size = New System.Drawing.Size(474, 202)
		Me.xpnl_User.TabIndex = 0
		'
		'xpnl_System
		'
		Me.xpnl_System.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.xpnl_System.Dock = System.Windows.Forms.DockStyle.Fill
		Me.xpnl_System.Location = New System.Drawing.Point(0, 0)
		Me.xpnl_System.Name = "xpnl_System"
		Me.xpnl_System.Size = New System.Drawing.Size(474, 267)
		Me.xpnl_System.TabIndex = 0
		'
		'ToolStripContainer1
		'
		Me.ToolStripContainer1.BottomToolStripPanelVisible = false
		'
		'ToolStripContainer1.ContentPanel
		'
		Me.ToolStripContainer1.ContentPanel.AutoScroll = true
		Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer1)
		Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(828, 484)
		Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ToolStripContainer1.LeftToolStripPanelVisible = false
		Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStripContainer1.Name = "ToolStripContainer1"
		Me.ToolStripContainer1.RightToolStripPanelVisible = false
		Me.ToolStripContainer1.Size = New System.Drawing.Size(828, 509)
		Me.ToolStripContainer1.TabIndex = 1
		Me.ToolStripContainer1.Text = "ToolStripContainer1"
		'
		'ToolStripContainer1.TopToolStripPanel
		'
		Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
		Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.xbtn_ts_ConnSetup, Me.xbtn_ts_Options, Me.ToolStripSeparator3, Me.xbtn_ts_LoadXML, Me.ToolStripSeparator1, Me.xbtn_ts_SAPSysSelect, Me.xbtn_ts_SAPSysPing, Me.xtbx_ts_SAPSys, Me.ToolStripSeparator2})
		Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(338, 25)
		Me.ToolStrip1.TabIndex = 0
		'
		'xbtn_ts_ConnSetup
		'
		Me.xbtn_ts_ConnSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_ConnSetup.Image = Global.xSAPtorExcel.My.Resources.Resources.Bitmap_editor
		Me.xbtn_ts_ConnSetup.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_ConnSetup.Name = "xbtn_ts_ConnSetup"
		Me.xbtn_ts_ConnSetup.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_ConnSetup.Text = "Connection Setup"
		Me.xbtn_ts_ConnSetup.ToolTipText = "Configure SAP connection setup"
		'
		'xbtn_ts_Options
		'
		Me.xbtn_ts_Options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_Options.Image = Global.xSAPtorExcel.My.Resources.Resources.Pantone
		Me.xbtn_ts_Options.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_Options.Name = "xbtn_ts_Options"
		Me.xbtn_ts_Options.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_Options.Tag = "xtag_LogonOptions"
		Me.xbtn_ts_Options.Text = "Logon Options"
		Me.xbtn_ts_Options.ToolTipText = "Configure SAP Logon Options"
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
		'
		'xbtn_ts_LoadXML
		'
		Me.xbtn_ts_LoadXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_LoadXML.Image = Global.xSAPtorExcel.My.Resources.Resources._2000px_SAP_2011_logo_svg
		Me.xbtn_ts_LoadXML.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_LoadXML.Name = "xbtn_ts_LoadXML"
		Me.xbtn_ts_LoadXML.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_LoadXML.Tag = "xtag_ts_LoadXML"
		Me.xbtn_ts_LoadXML.Text = "Load From SAPGUI"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
		'
		'xbtn_ts_SAPSysSelect
		'
		Me.xbtn_ts_SAPSysSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_SAPSysSelect.Image = Global.xSAPtorExcel.My.Resources.Resources.Select_gpadient
		Me.xbtn_ts_SAPSysSelect.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_SAPSysSelect.Name = "xbtn_ts_SAPSysSelect"
		Me.xbtn_ts_SAPSysSelect.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_SAPSysSelect.Tag = "xtag_SAPSel"
		Me.xbtn_ts_SAPSysSelect.Text = "Select System"
		Me.xbtn_ts_SAPSysSelect.ToolTipText = "Set selected SAP system as active"
		'
		'xbtn_ts_SAPSysPing
		'
		Me.xbtn_ts_SAPSysPing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_SAPSysPing.Image = Global.xSAPtorExcel.My.Resources.Resources.Test_line
		Me.xbtn_ts_SAPSysPing.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_SAPSysPing.Name = "xbtn_ts_SAPSysPing"
		Me.xbtn_ts_SAPSysPing.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_SAPSysPing.Tag = "xtag_SAPPing"
		Me.xbtn_ts_SAPSysPing.Text = "Ping SAP"
		Me.xbtn_ts_SAPSysPing.ToolTipText = "Ping SAP to test connectivity"
		'
		'xtbx_ts_SAPSys
		'
		Me.xtbx_ts_SAPSys.Name = "xtbx_ts_SAPSys"
		Me.xtbx_ts_SAPSys.ReadOnly = true
		Me.xtbx_ts_SAPSys.Size = New System.Drawing.Size(200, 25)
		Me.xtbx_ts_SAPSys.Text = "No SAP System selected ..."
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
		'
		'SID
		'
		Me.SID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
		Me.SID.DataPropertyName = "SAPID"
		Me.SID.HeaderText = "SID"
		Me.SID.Name = "SID"
		Me.SID.ReadOnly = true
		Me.SID.Width = 50
		'
		'SystemName
		'
		Me.SystemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.SystemName.DataPropertyName = "NAME"
		Me.SystemName.DividerWidth = 2
		Me.SystemName.HeaderText = "SAP System Name"
		Me.SystemName.Name = "SystemName"
		Me.SystemName.ReadOnly = true
		'
		'SystemID
		'
		Me.SystemID.DataPropertyName = "ID"
		Me.SystemID.HeaderText = "Column1"
		Me.SystemID.Name = "SystemID"
		Me.SystemID.ReadOnly = true
		Me.SystemID.Visible = false
		'
		'LogonGUIView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(828, 509)
		Me.Controls.Add(Me.ToolStripContainer1)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.Name = "LogonGUIView"
		Me.Text = "SAP Systems"
		Me.SplitContainer1.Panel1.ResumeLayout(false)
		Me.SplitContainer1.Panel2.ResumeLayout(false)
		CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
		Me.SplitContainer1.ResumeLayout(false)
		Me.Panel1.ResumeLayout(false)
		CType(Me.xdgv_SAPSys,System.ComponentModel.ISupportInitialize).EndInit
		Me.SplitContainer2.Panel1.ResumeLayout(false)
		Me.SplitContainer2.Panel2.ResumeLayout(false)
		CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).EndInit
		Me.SplitContainer2.ResumeLayout(false)
		Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
		Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false)
		Me.ToolStripContainer1.TopToolStripPanel.PerformLayout
		Me.ToolStripContainer1.ResumeLayout(false)
		Me.ToolStripContainer1.PerformLayout
		Me.ToolStrip1.ResumeLayout(false)
		Me.ToolStrip1.PerformLayout
		Me.ResumeLayout(false)

End Sub
  Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
	Friend WithEvents ToolStripContainer1 As Windows.Forms.ToolStripContainer
	Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
	Friend WithEvents xbtn_ts_ConnSetup As Windows.Forms.ToolStripButton
	Friend WithEvents xbtn_ts_Options As Windows.Forms.ToolStripButton
	Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
	Friend WithEvents xtbx_ts_SAPSys As Windows.Forms.ToolStripTextBox
	Friend WithEvents xbtn_ts_SAPSysSelect As Windows.Forms.ToolStripButton
	Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
	Friend WithEvents SplitContainer2 As Windows.Forms.SplitContainer
	Friend WithEvents Panel1 As Windows.Forms.Panel
	Friend WithEvents xpnl_User As Windows.Forms.Panel
	Friend WithEvents xpnl_System As Windows.Forms.Panel
	Friend WithEvents xdgv_SAPSys As Windows.Forms.DataGridView
	Friend WithEvents xbtn_ts_SAPSysPing As Windows.Forms.ToolStripButton
	Friend WithEvents ToolStripSeparator3 As Windows.Forms.ToolStripSeparator
	Friend WithEvents xbtn_ts_LoadXML As Windows.Forms.ToolStripButton
	Friend WithEvents SID As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents SystemName As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents SystemID As Windows.Forms.DataGridViewTextBoxColumn
End Class
