Namespace Main.Process.Selection

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xProcessSelectionView
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
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.xbtn_TV_Reload = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_tl_Refresh = New System.Windows.Forms.ToolStripButton()
		Me.xtvw_WBOverview = New System.Windows.Forms.TreeView()
		Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
		Me.xbtn_TL_Up = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_TL_Down = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.xbtn_TL_SubmitRunner = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_TL_SubmitZDton = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_TL_SubmitMsgs = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.xpbr_TL_Upload = New System.Windows.Forms.ToolStripProgressBar()
		Me.xbtn_TL_Cancel = New System.Windows.Forms.ToolStripButton()
		Me.xdgv_TaskList = New System.Windows.Forms.DataGridView()
		Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
		Me.ToolStrip1.SuspendLayout
		Me.ToolStrip2.SuspendLayout
		CType(Me.xdgv_TaskList,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SplitContainer2.Panel1.SuspendLayout
		Me.SplitContainer2.Panel2.SuspendLayout
		Me.SplitContainer2.SuspendLayout
		Me.SuspendLayout
		'
		'ToolStrip1
		'
		Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.xbtn_TV_Reload, Me.xbtn_tl_Refresh})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(668, 25)
		Me.ToolStrip1.TabIndex = 0
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'xbtn_TV_Reload
		'
		Me.xbtn_TV_Reload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_TV_Reload.Image = Global.xSAPtorExcel.My.Resources.Resources.Revert
		Me.xbtn_TV_Reload.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_TV_Reload.Name = "xbtn_TV_Reload"
		Me.xbtn_TV_Reload.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_TV_Reload.Text = "Re-Load Workbook/Worksheet Tree"
		'
		'xbtn_tl_Refresh
		'
		Me.xbtn_tl_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_tl_Refresh.Image = Global.xSAPtorExcel.My.Resources.Resources.Refresh
		Me.xbtn_tl_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_tl_Refresh.Name = "xbtn_tl_Refresh"
		Me.xbtn_tl_Refresh.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_tl_Refresh.Text = "Refresh Workbook/Worksheet tree"
		Me.xbtn_tl_Refresh.Visible = false
		'
		'xtvw_WBOverview
		'
		Me.xtvw_WBOverview.CheckBoxes = true
		Me.xtvw_WBOverview.Dock = System.Windows.Forms.DockStyle.Fill
		Me.xtvw_WBOverview.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtvw_WBOverview.Location = New System.Drawing.Point(0, 0)
		Me.xtvw_WBOverview.Name = "xtvw_WBOverview"
		Me.xtvw_WBOverview.Size = New System.Drawing.Size(222, 298)
		Me.xtvw_WBOverview.TabIndex = 1
		'
		'ToolStrip2
		'
		Me.ToolStrip2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.xbtn_TL_Up, Me.xbtn_TL_Down, Me.ToolStripSeparator1, Me.xbtn_TL_SubmitRunner, Me.xbtn_TL_SubmitZDton, Me.xbtn_TL_SubmitMsgs, Me.ToolStripSeparator3, Me.xpbr_TL_Upload, Me.xbtn_TL_Cancel})
		Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip2.Name = "ToolStrip2"
		Me.ToolStrip2.ShowItemToolTips = false
		Me.ToolStrip2.Size = New System.Drawing.Size(442, 25)
		Me.ToolStrip2.TabIndex = 0
		Me.ToolStrip2.Text = "Navigator"
		'
		'xbtn_TL_Up
		'
		Me.xbtn_TL_Up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_TL_Up.Image = Global.xSAPtorExcel.My.Resources.Resources.Up
		Me.xbtn_TL_Up.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_TL_Up.Name = "xbtn_TL_Up"
		Me.xbtn_TL_Up.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_TL_Up.Tag = "xtag_tst_Up"
		Me.xbtn_TL_Up.Text = "Move selected UP"
		Me.xbtn_TL_Up.Visible = false
		'
		'xbtn_TL_Down
		'
		Me.xbtn_TL_Down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_TL_Down.Image = Global.xSAPtorExcel.My.Resources.Resources.Down
		Me.xbtn_TL_Down.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_TL_Down.Name = "xbtn_TL_Down"
		Me.xbtn_TL_Down.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_TL_Down.Tag = "xtag_tst_Down"
		Me.xbtn_TL_Down.Text = "Move selected DOWN"
		Me.xbtn_TL_Down.Visible = false
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
		Me.ToolStripSeparator1.Visible = false
		'
		'xbtn_TL_SubmitRunner
		'
		Me.xbtn_TL_SubmitRunner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_TL_SubmitRunner.Image = Global.xSAPtorExcel.My.Resources.Resources.Pinion
		Me.xbtn_TL_SubmitRunner.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_TL_SubmitRunner.Name = "xbtn_TL_SubmitRunner"
		Me.xbtn_TL_SubmitRunner.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_TL_SubmitRunner.Text = "Start selected tasks in background Runner"
		Me.xbtn_TL_SubmitRunner.Visible = false
		'
		'xbtn_TL_SubmitZDton
		'
		Me.xbtn_TL_SubmitZDton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_TL_SubmitZDton.Image = Global.xSAPtorExcel.My.Resources.Resources.Color_balance
		Me.xbtn_TL_SubmitZDton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_TL_SubmitZDton.Name = "xbtn_TL_SubmitZDton"
		Me.xbtn_TL_SubmitZDton.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_TL_SubmitZDton.Text = "Start selected tasks in ZDTON Runner"
		Me.xbtn_TL_SubmitZDton.Visible = false
		'
		'xbtn_TL_SubmitMsgs
		'
		Me.xbtn_TL_SubmitMsgs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_TL_SubmitMsgs.Image = Global.xSAPtorExcel.My.Resources.Resources.Synchronize
		Me.xbtn_TL_SubmitMsgs.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_TL_SubmitMsgs.Name = "xbtn_TL_SubmitMsgs"
		Me.xbtn_TL_SubmitMsgs.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_TL_SubmitMsgs.Text = "Fetch selected tasks ZDTON messages"
		Me.xbtn_TL_SubmitMsgs.ToolTipText = "Fetch processing messages"
		Me.xbtn_TL_SubmitMsgs.Visible = false
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
		Me.ToolStripSeparator3.Visible = false
		'
		'xpbr_TL_Upload
		'
		Me.xpbr_TL_Upload.Name = "xpbr_TL_Upload"
		Me.xpbr_TL_Upload.Size = New System.Drawing.Size(150, 22)
		Me.xpbr_TL_Upload.Visible = false
		'
		'xbtn_TL_Cancel
		'
		Me.xbtn_TL_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_TL_Cancel.Image = Global.xSAPtorExcel.My.Resources.Resources.Cancel
		Me.xbtn_TL_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_TL_Cancel.Name = "xbtn_TL_Cancel"
		Me.xbtn_TL_Cancel.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_TL_Cancel.Text = "ToolStripButton1"
		Me.xbtn_TL_Cancel.Visible = false
		'
		'xdgv_TaskList
		'
		Me.xdgv_TaskList.AllowDrop = true
		Me.xdgv_TaskList.AllowUserToAddRows = false
		Me.xdgv_TaskList.AllowUserToDeleteRows = false
		Me.xdgv_TaskList.AllowUserToResizeRows = false
		Me.xdgv_TaskList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.xdgv_TaskList.Dock = System.Windows.Forms.DockStyle.Fill
		Me.xdgv_TaskList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
		Me.xdgv_TaskList.GridColor = System.Drawing.SystemColors.ControlLightLight
		Me.xdgv_TaskList.Location = New System.Drawing.Point(0, 25)
		Me.xdgv_TaskList.Name = "xdgv_TaskList"
		Me.xdgv_TaskList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.xdgv_TaskList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.xdgv_TaskList.Size = New System.Drawing.Size(442, 273)
		Me.xdgv_TaskList.StandardTab = true
		Me.xdgv_TaskList.TabIndex = 2
		'
		'SplitContainer2
		'
		Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer2.Location = New System.Drawing.Point(0, 25)
		Me.SplitContainer2.Name = "SplitContainer2"
		'
		'SplitContainer2.Panel1
		'
		Me.SplitContainer2.Panel1.Controls.Add(Me.xtvw_WBOverview)
		'
		'SplitContainer2.Panel2
		'
		Me.SplitContainer2.Panel2.Controls.Add(Me.xdgv_TaskList)
		Me.SplitContainer2.Panel2.Controls.Add(Me.ToolStrip2)
		Me.SplitContainer2.Size = New System.Drawing.Size(668, 298)
		Me.SplitContainer2.SplitterDistance = 222
		Me.SplitContainer2.TabIndex = 2
		'
		'xProcessSelectionView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(668, 323)
		Me.Controls.Add(Me.SplitContainer2)
		Me.Controls.Add(Me.ToolStrip1)
		Me.KeyPreview = true
		Me.Name = "xProcessSelectionView"
		Me.Text = "Processing Selection View"
		Me.TopMost = true
		Me.ToolStrip1.ResumeLayout(false)
		Me.ToolStrip1.PerformLayout
		Me.ToolStrip2.ResumeLayout(false)
		Me.ToolStrip2.PerformLayout
		CType(Me.xdgv_TaskList,System.ComponentModel.ISupportInitialize).EndInit
		Me.SplitContainer2.Panel1.ResumeLayout(false)
		Me.SplitContainer2.Panel2.ResumeLayout(false)
		Me.SplitContainer2.Panel2.PerformLayout
		CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).EndInit
		Me.SplitContainer2.ResumeLayout(false)
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

	Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
	Friend WithEvents xtvw_WBOverview As Windows.Forms.TreeView
	Friend WithEvents xbtn_tl_Refresh As Windows.Forms.ToolStripButton
	Friend WithEvents xdgv_TaskList As Windows.Forms.DataGridView
	Friend WithEvents ToolStrip2 As Windows.Forms.ToolStrip
	Friend WithEvents xbtn_TL_Up As Windows.Forms.ToolStripButton
	Friend WithEvents xbtn_TL_Down As Windows.Forms.ToolStripButton
		Friend WithEvents xbtn_TV_Reload As Windows.Forms.ToolStripButton
		Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
		Friend WithEvents xbtn_TL_SubmitRunner As Windows.Forms.ToolStripButton
		Friend WithEvents xbtn_TL_SubmitZDton As Windows.Forms.ToolStripButton
		Friend WithEvents SplitContainer2 As Windows.Forms.SplitContainer
		Friend WithEvents ToolStripSeparator3 As Windows.Forms.ToolStripSeparator
		Friend WithEvents xpbr_TL_Upload As Windows.Forms.ToolStripProgressBar
		Friend WithEvents xbtn_TL_Cancel As Windows.Forms.ToolStripButton
		Friend WithEvents xbtn_TL_SubmitMsgs As Windows.Forms.ToolStripButton
	End Class

End Namespace