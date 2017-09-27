Namespace Main.Services.DestinationMonitor

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xSAPConnectionMonitorView
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
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.xbtn_ts_Refresh = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.xcbx_RefreshDelay = New System.Windows.Forms.ToolStripComboBox()
		Me.xdgv_ConnMonitor = New System.Windows.Forms.DataGridView()
		Me.ToolStrip1.SuspendLayout
		CType(Me.xdgv_ConnMonitor,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'ToolStrip1
		'
		Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.xbtn_ts_Refresh, Me.ToolStripSeparator1, Me.xcbx_RefreshDelay})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(665, 25)
		Me.ToolStrip1.TabIndex = 0
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'xbtn_ts_Refresh
		'
		Me.xbtn_ts_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_Refresh.Image = Global.xSAPtorExcel.My.Resources.Resources.Refresh
		Me.xbtn_ts_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_Refresh.Name = "xbtn_ts_Refresh"
		Me.xbtn_ts_Refresh.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_Refresh.Text = "ToolStripButton1"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
		'
		'xcbx_RefreshDelay
		'
		Me.xcbx_RefreshDelay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
		Me.xcbx_RefreshDelay.AutoSize = false
		Me.xcbx_RefreshDelay.DropDownWidth = 50
		Me.xcbx_RefreshDelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.xcbx_RefreshDelay.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
		Me.xcbx_RefreshDelay.MaxLength = 1
		Me.xcbx_RefreshDelay.Name = "xcbx_RefreshDelay"
		Me.xcbx_RefreshDelay.Size = New System.Drawing.Size(30, 23)
		Me.xcbx_RefreshDelay.Sorted = true
		Me.xcbx_RefreshDelay.Text = "0"
		'
		'xdgv_ConnMonitor
		'
		Me.xdgv_ConnMonitor.AllowUserToAddRows = false
		Me.xdgv_ConnMonitor.AllowUserToDeleteRows = false
		Me.xdgv_ConnMonitor.AllowUserToOrderColumns = true
		Me.xdgv_ConnMonitor.AllowUserToResizeRows = false
		DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
		Me.xdgv_ConnMonitor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.xdgv_ConnMonitor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 9!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.xdgv_ConnMonitor.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
		Me.xdgv_ConnMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.xdgv_ConnMonitor.DefaultCellStyle = DataGridViewCellStyle3
		Me.xdgv_ConnMonitor.Dock = System.Windows.Forms.DockStyle.Fill
		Me.xdgv_ConnMonitor.Location = New System.Drawing.Point(0, 25)
		Me.xdgv_ConnMonitor.MultiSelect = false
		Me.xdgv_ConnMonitor.Name = "xdgv_ConnMonitor"
		Me.xdgv_ConnMonitor.ReadOnly = true
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle4.Font = New System.Drawing.Font("Courier New", 9!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.xdgv_ConnMonitor.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
		Me.xdgv_ConnMonitor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.xdgv_ConnMonitor.Size = New System.Drawing.Size(665, 187)
		Me.xdgv_ConnMonitor.TabIndex = 1
		'
		'xSAPConnectionMonitorView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(665, 212)
		Me.Controls.Add(Me.xdgv_ConnMonitor)
		Me.Controls.Add(Me.ToolStrip1)
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.Name = "xSAPConnectionMonitorView"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "SAP Connection Monitor"
		Me.TopMost = true
		Me.ToolStrip1.ResumeLayout(false)
		Me.ToolStrip1.PerformLayout
		CType(Me.xdgv_ConnMonitor,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

  Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
  Friend WithEvents xdgv_ConnMonitor As Windows.Forms.DataGridView
  Friend WithEvents xbtn_ts_Refresh As Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
  Friend WithEvents xcbx_RefreshDelay As Windows.Forms.ToolStripComboBox
End Class

End Namespace