<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCParametersView
	Inherits System.Windows.Forms.UserControl

	'UserControl overrides dispose to clean up the component list.
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
		Me.xlbl_Clnt = New System.Windows.Forms.Label()
		Me.xlbl_User = New System.Windows.Forms.Label()
		Me.xlbl_Pwrd = New System.Windows.Forms.Label()
		Me.xlbl_Lang = New System.Windows.Forms.Label()
		Me.xcbx_Clnt = New System.Windows.Forms.ComboBox()
		Me.xcbx_Lang = New System.Windows.Forms.ComboBox()
		Me.xcbx_User = New System.Windows.Forms.ComboBox()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.xcbx_Pwrd = New System.Windows.Forms.ComboBox()
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.xbtn_ts_Edit = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_ts_Save = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_ts_Delete = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_ts_Cancel = New System.Windows.Forms.ToolStripButton()
		Me.Panel1.SuspendLayout
		Me.ToolStrip1.SuspendLayout
		Me.SuspendLayout
		'
		'xlbl_Clnt
		'
		Me.xlbl_Clnt.BackColor = System.Drawing.SystemColors.ControlLight
		Me.xlbl_Clnt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xlbl_Clnt.Location = New System.Drawing.Point(8, 43)
		Me.xlbl_Clnt.Name = "xlbl_Clnt"
		Me.xlbl_Clnt.Size = New System.Drawing.Size(84, 23)
		Me.xlbl_Clnt.TabIndex = 0
		Me.xlbl_Clnt.Text = "Client:"
		Me.xlbl_Clnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xlbl_Clnt.Visible = false
		'
		'xlbl_User
		'
		Me.xlbl_User.BackColor = System.Drawing.SystemColors.ControlLight
		Me.xlbl_User.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xlbl_User.Location = New System.Drawing.Point(8, 84)
		Me.xlbl_User.Name = "xlbl_User"
		Me.xlbl_User.Size = New System.Drawing.Size(84, 23)
		Me.xlbl_User.TabIndex = 0
		Me.xlbl_User.Text = "User:"
		Me.xlbl_User.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xlbl_User.Visible = false
		'
		'xlbl_Pwrd
		'
		Me.xlbl_Pwrd.BackColor = System.Drawing.SystemColors.ControlLight
		Me.xlbl_Pwrd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xlbl_Pwrd.Location = New System.Drawing.Point(8, 116)
		Me.xlbl_Pwrd.Name = "xlbl_Pwrd"
		Me.xlbl_Pwrd.Size = New System.Drawing.Size(84, 23)
		Me.xlbl_Pwrd.TabIndex = 0
		Me.xlbl_Pwrd.Text = "Password:"
		Me.xlbl_Pwrd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xlbl_Pwrd.Visible = false
		'
		'xlbl_Lang
		'
		Me.xlbl_Lang.BackColor = System.Drawing.SystemColors.ControlLight
		Me.xlbl_Lang.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xlbl_Lang.Location = New System.Drawing.Point(8, 7)
		Me.xlbl_Lang.Name = "xlbl_Lang"
		Me.xlbl_Lang.Size = New System.Drawing.Size(84, 23)
		Me.xlbl_Lang.TabIndex = 0
		Me.xlbl_Lang.Text = "Language:"
		Me.xlbl_Lang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xlbl_Lang.Visible = false
		'
		'xcbx_Clnt
		'
		Me.xcbx_Clnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.xcbx_Clnt.Enabled = false
		Me.xcbx_Clnt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xcbx_Clnt.FormattingEnabled = true
		Me.xcbx_Clnt.Location = New System.Drawing.Point(100, 44)
		Me.xcbx_Clnt.MaxLength = 3
		Me.xcbx_Clnt.Name = "xcbx_Clnt"
		Me.xcbx_Clnt.Size = New System.Drawing.Size(85, 24)
		Me.xcbx_Clnt.Sorted = true
		Me.xcbx_Clnt.TabIndex = 2
		Me.xcbx_Clnt.Tag = "xtag_Clt"
		Me.xcbx_Clnt.Visible = false
		'
		'xcbx_Lang
		'
		Me.xcbx_Lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.xcbx_Lang.Enabled = false
		Me.xcbx_Lang.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xcbx_Lang.FormattingEnabled = true
		Me.xcbx_Lang.Location = New System.Drawing.Point(100, 7)
		Me.xcbx_Lang.MaxLength = 2
		Me.xcbx_Lang.Name = "xcbx_Lang"
		Me.xcbx_Lang.Size = New System.Drawing.Size(63, 24)
		Me.xcbx_Lang.TabIndex = 1
		Me.xcbx_Lang.Tag = "xtag_Lng"
		Me.xcbx_Lang.Visible = false
		'
		'xcbx_User
		'
		Me.xcbx_User.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.xcbx_User.Enabled = false
		Me.xcbx_User.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xcbx_User.FormattingEnabled = true
		Me.xcbx_User.Location = New System.Drawing.Point(100, 85)
		Me.xcbx_User.MaxLength = 12
		Me.xcbx_User.Name = "xcbx_User"
		Me.xcbx_User.Size = New System.Drawing.Size(172, 24)
		Me.xcbx_User.Sorted = true
		Me.xcbx_User.TabIndex = 3
		Me.xcbx_User.Tag = "xtag_Usr"
		Me.xcbx_User.Visible = false
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.xcbx_Pwrd)
		Me.Panel1.Controls.Add(Me.xlbl_Clnt)
		Me.Panel1.Controls.Add(Me.xcbx_User)
		Me.Panel1.Controls.Add(Me.xlbl_User)
		Me.Panel1.Controls.Add(Me.xcbx_Lang)
		Me.Panel1.Controls.Add(Me.xlbl_Pwrd)
		Me.Panel1.Controls.Add(Me.xlbl_Lang)
		Me.Panel1.Controls.Add(Me.xcbx_Clnt)
		Me.Panel1.Location = New System.Drawing.Point(6, 31)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
		Me.Panel1.Size = New System.Drawing.Size(277, 148)
		Me.Panel1.TabIndex = 9
		'
		'xcbx_Pwrd
		'
		Me.xcbx_Pwrd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.xcbx_Pwrd.Enabled = false
		Me.xcbx_Pwrd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xcbx_Pwrd.ForeColor = System.Drawing.SystemColors.Window
		Me.xcbx_Pwrd.FormattingEnabled = true
		Me.xcbx_Pwrd.Location = New System.Drawing.Point(100, 115)
		Me.xcbx_Pwrd.MaxDropDownItems = 1
		Me.xcbx_Pwrd.MaxLength = 32
		Me.xcbx_Pwrd.Name = "xcbx_Pwrd"
		Me.xcbx_Pwrd.Size = New System.Drawing.Size(172, 24)
		Me.xcbx_Pwrd.Sorted = true
		Me.xcbx_Pwrd.TabIndex = 4
		Me.xcbx_Pwrd.Tag = "xtag_Pwd"
		Me.xcbx_Pwrd.Visible = false
		'
		'ToolStrip1
		'
		Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.xbtn_ts_Edit, Me.xbtn_ts_Save, Me.xbtn_ts_Delete, Me.xbtn_ts_Cancel})
		Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(1)
		Me.ToolStrip1.Size = New System.Drawing.Size(284, 25)
		Me.ToolStrip1.Stretch = true
		Me.ToolStrip1.TabIndex = 0
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'xbtn_ts_Edit
		'
		Me.xbtn_ts_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_Edit.Image = Global.xSAPtorExcel.My.Resources.Resources.Edit
		Me.xbtn_ts_Edit.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_Edit.Name = "xbtn_ts_Edit"
		Me.xbtn_ts_Edit.Size = New System.Drawing.Size(23, 20)
		Me.xbtn_ts_Edit.Tag = "xtag_Edit"
		Me.xbtn_ts_Edit.Text = "Edit"
		Me.xbtn_ts_Edit.ToolTipText = "Edit Mode"
		'
		'xbtn_ts_Save
		'
		Me.xbtn_ts_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_Save.Image = Global.xSAPtorExcel.My.Resources.Resources.Save
		Me.xbtn_ts_Save.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_Save.Name = "xbtn_ts_Save"
		Me.xbtn_ts_Save.Size = New System.Drawing.Size(23, 20)
		Me.xbtn_ts_Save.Tag = "xtag_Save"
		Me.xbtn_ts_Save.Text = "Save"
		Me.xbtn_ts_Save.ToolTipText = "Save changed"
		Me.xbtn_ts_Save.Visible = false
		'
		'xbtn_ts_Delete
		'
		Me.xbtn_ts_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_Delete.Image = Global.xSAPtorExcel.My.Resources.Resources.Delete
		Me.xbtn_ts_Delete.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_Delete.Name = "xbtn_ts_Delete"
		Me.xbtn_ts_Delete.Size = New System.Drawing.Size(23, 20)
		Me.xbtn_ts_Delete.Tag = "xtag_Delete"
		Me.xbtn_ts_Delete.Text = "Delete"
		Me.xbtn_ts_Delete.ToolTipText = "Delete current"
		'
		'xbtn_ts_Cancel
		'
		Me.xbtn_ts_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_Cancel.Image = Global.xSAPtorExcel.My.Resources.Resources.Cancel
		Me.xbtn_ts_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_Cancel.Name = "xbtn_ts_Cancel"
		Me.xbtn_ts_Cancel.Size = New System.Drawing.Size(23, 20)
		Me.xbtn_ts_Cancel.Tag = "xtag_Cancel"
		Me.xbtn_ts_Cancel.Text = "Cancel"
		Me.xbtn_ts_Cancel.ToolTipText = "Cancel changes"
		Me.xbtn_ts_Cancel.Visible = false
		'
		'UCParametersView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.ToolStrip1)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "UCParametersView"
		Me.Padding = New System.Windows.Forms.Padding(3)
		Me.Size = New System.Drawing.Size(290, 187)
		Me.Panel1.ResumeLayout(false)
		Me.ToolStrip1.ResumeLayout(false)
		Me.ToolStrip1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

	Friend WithEvents xlbl_Clnt As Windows.Forms.Label
	Friend WithEvents xlbl_User As Windows.Forms.Label
	Friend WithEvents xlbl_Pwrd As Windows.Forms.Label
	Friend WithEvents xlbl_Lang As Windows.Forms.Label
	Friend WithEvents xcbx_Clnt As Windows.Forms.ComboBox
	Friend WithEvents xcbx_Lang As Windows.Forms.ComboBox
	Friend WithEvents xcbx_User As Windows.Forms.ComboBox
	Friend WithEvents Panel1 As Windows.Forms.Panel
	Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
	Friend WithEvents xbtn_ts_Save As Windows.Forms.ToolStripButton
	Friend WithEvents xbtn_ts_Cancel As Windows.Forms.ToolStripButton
	Friend WithEvents xbtn_ts_Delete As Windows.Forms.ToolStripButton
	Friend WithEvents xbtn_ts_Edit As Windows.Forms.ToolStripButton
	Friend WithEvents xcbx_Pwrd As Windows.Forms.ComboBox
End Class
