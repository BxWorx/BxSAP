'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SapGuiXmlView
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
		Me.xtsb_SAPGUI = New System.Windows.Forms.ToolStrip()
		Me.xbtn_ts_ResetSel = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_ts_AddSel = New System.Windows.Forms.ToolStripButton()
		Me.xtvw_SAPSystems = New System.Windows.Forms.TreeView()
		Me.xtsb_SAPGUI.SuspendLayout
		Me.SuspendLayout
		'
		'xtsb_SAPGUI
		'
		Me.xtsb_SAPGUI.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.xbtn_ts_ResetSel, Me.xbtn_ts_AddSel})
		Me.xtsb_SAPGUI.Location = New System.Drawing.Point(0, 0)
		Me.xtsb_SAPGUI.Name = "xtsb_SAPGUI"
		Me.xtsb_SAPGUI.Size = New System.Drawing.Size(457, 25)
		Me.xtsb_SAPGUI.TabIndex = 0
		Me.xtsb_SAPGUI.Text = "ToolStrip1"
		'
		'xbtn_ts_ResetSel
		'
		Me.xbtn_ts_ResetSel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_ResetSel.Image = Global.xSAPtorExcel.My.Resources.Resources.Synchronize
		Me.xbtn_ts_ResetSel.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_ResetSel.Name = "xbtn_ts_ResetSel"
		Me.xbtn_ts_ResetSel.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_ResetSel.Text = "Reset to selected"
		'
		'xbtn_ts_AddSel
		'
		Me.xbtn_ts_AddSel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_AddSel.Enabled = false
		Me.xbtn_ts_AddSel.Image = Global.xSAPtorExcel.My.Resources.Resources.Add
		Me.xbtn_ts_AddSel.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_AddSel.Name = "xbtn_ts_AddSel"
		Me.xbtn_ts_AddSel.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_AddSel.Text = "Add to selected"
		Me.xbtn_ts_AddSel.Visible = false
		'
		'xtvw_SAPSystems
		'
		Me.xtvw_SAPSystems.CheckBoxes = true
		Me.xtvw_SAPSystems.Dock = System.Windows.Forms.DockStyle.Fill
		Me.xtvw_SAPSystems.FullRowSelect = true
		Me.xtvw_SAPSystems.Location = New System.Drawing.Point(0, 25)
		Me.xtvw_SAPSystems.Name = "xtvw_SAPSystems"
		Me.xtvw_SAPSystems.Size = New System.Drawing.Size(457, 506)
		Me.xtvw_SAPSystems.TabIndex = 1
		'
		'SapGuiXmlView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(457, 531)
		Me.Controls.Add(Me.xtvw_SAPSystems)
		Me.Controls.Add(Me.xtsb_SAPGUI)
		Me.KeyPreview = true
		Me.Name = "SapGuiXmlView"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "SAPGUI System Selection"
		Me.xtsb_SAPGUI.ResumeLayout(false)
		Me.xtsb_SAPGUI.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

	Friend WithEvents xtsb_SAPGUI As Windows.Forms.ToolStrip
	Friend WithEvents xtvw_SAPSystems As Windows.Forms.TreeView
		Friend WithEvents xbtn_ts_ResetSel As Windows.Forms.ToolStripButton
		Friend WithEvents xbtn_ts_AddSel As Windows.Forms.ToolStripButton
	End Class

End Namespace
