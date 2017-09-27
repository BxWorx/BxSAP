Namespace Main.Process.RunMonitor

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xProcessRunMonitorView
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
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(xProcessRunMonitorView))
		Me.xtss_Main = New System.Windows.Forms.ToolStrip()
		Me.xbtn_ts_Start = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_ts_Reset = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
		Me.xdgv_Processing = New System.Windows.Forms.DataGridView()
		Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.HelloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.xtss_Main.SuspendLayout
		CType(Me.xdgv_Processing,System.ComponentModel.ISupportInitialize).BeginInit
		Me.ContextMenuStrip1.SuspendLayout
		Me.SuspendLayout
		'
		'xtss_Main
		'
		Me.xtss_Main.CanOverflow = false
		Me.xtss_Main.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtss_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.xbtn_ts_Start, Me.xbtn_ts_Reset, Me.ToolStripButton3})
		Me.xtss_Main.Location = New System.Drawing.Point(0, 0)
		Me.xtss_Main.Name = "xtss_Main"
		Me.xtss_Main.Padding = New System.Windows.Forms.Padding(2)
		Me.xtss_Main.Size = New System.Drawing.Size(673, 27)
		Me.xtss_Main.Stretch = true
		Me.xtss_Main.TabIndex = 0
		Me.xtss_Main.Text = "ToolStrip1"
		'
		'xbtn_ts_Start
		'
		Me.xbtn_ts_Start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_Start.Image = Global.xSAPtorExcel.My.Resources.Resources.Synchronize
		Me.xbtn_ts_Start.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_Start.Name = "xbtn_ts_Start"
		Me.xbtn_ts_Start.Size = New System.Drawing.Size(23, 20)
		Me.xbtn_ts_Start.Text = "Start Processing Runner"
		'
		'xbtn_ts_Reset
		'
		Me.xbtn_ts_Reset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_Reset.Image = Global.xSAPtorExcel.My.Resources.Resources.Revert
		Me.xbtn_ts_Reset.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_Reset.Name = "xbtn_ts_Reset"
		Me.xbtn_ts_Reset.Size = New System.Drawing.Size(23, 20)
		Me.xbtn_ts_Reset.Text = "ToolStripButton2"
		'
		'ToolStripButton3
		'
		Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"),System.Drawing.Image)
		Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripButton3.Name = "ToolStripButton3"
		Me.ToolStripButton3.Size = New System.Drawing.Size(23, 20)
		Me.ToolStripButton3.Text = "ToolStripButton3"
		'
		'xdgv_Processing
		'
		Me.xdgv_Processing.AllowUserToAddRows = false
		Me.xdgv_Processing.AllowUserToDeleteRows = false
		Me.xdgv_Processing.AllowUserToOrderColumns = true
		Me.xdgv_Processing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.xdgv_Processing.ContextMenuStrip = Me.ContextMenuStrip1
		Me.xdgv_Processing.Dock = System.Windows.Forms.DockStyle.Fill
		Me.xdgv_Processing.Location = New System.Drawing.Point(0, 27)
		Me.xdgv_Processing.MultiSelect = false
		Me.xdgv_Processing.Name = "xdgv_Processing"
		Me.xdgv_Processing.ReadOnly = true
		Me.xdgv_Processing.Size = New System.Drawing.Size(673, 430)
		Me.xdgv_Processing.TabIndex = 1
		'
		'ContextMenuStrip1
		'
		Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelloToolStripMenuItem})
		Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
		Me.ContextMenuStrip1.Size = New System.Drawing.Size(103, 26)
		'
		'HelloToolStripMenuItem
		'
		Me.HelloToolStripMenuItem.Name = "HelloToolStripMenuItem"
		Me.HelloToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
		Me.HelloToolStripMenuItem.Text = "Hello"
		'
		'xProcessRunMonitorView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(673, 457)
		Me.Controls.Add(Me.xdgv_Processing)
		Me.Controls.Add(Me.xtss_Main)
		Me.KeyPreview = true
		Me.Name = "xProcessRunMonitorView"
		Me.Text = "Process Runner Monitor"
		Me.xtss_Main.ResumeLayout(false)
		Me.xtss_Main.PerformLayout
		CType(Me.xdgv_Processing,System.ComponentModel.ISupportInitialize).EndInit
		Me.ContextMenuStrip1.ResumeLayout(false)
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

	Friend WithEvents xtss_Main As Windows.Forms.ToolStrip
	Friend WithEvents xbtn_ts_Start As Windows.Forms.ToolStripButton
	Friend WithEvents xbtn_ts_Reset As Windows.Forms.ToolStripButton
	Friend WithEvents ToolStripButton3 As Windows.Forms.ToolStripButton
	Friend WithEvents xdgv_Processing As Windows.Forms.DataGridView
	Friend WithEvents ContextMenuStrip1 As Windows.Forms.ContextMenuStrip
	Friend WithEvents HelloToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class

End Namespace