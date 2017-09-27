<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCConnectionView
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
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.xbtn_ts_New = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_ts_Edit = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_ts_Save = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_ts_Delete = New System.Windows.Forms.ToolStripButton()
		Me.xbtn_ts_Cancel = New System.Windows.Forms.ToolStripButton()
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.xtbx_Router = New System.Windows.Forms.TextBox()
		Me.xtbx_SysID = New System.Windows.Forms.TextBox()
		Me.xtbx_InsNo = New System.Windows.Forms.TextBox()
		Me.xtbx_AppSrvr = New System.Windows.Forms.TextBox()
		Me.xtbx_Name = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.xnud_SNCQOP = New System.Windows.Forms.NumericUpDown()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.xcbx_SNCActive = New System.Windows.Forms.CheckBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.xcbx_SNCUsrPwd = New System.Windows.Forms.CheckBox()
		Me.xtbx_SNCName = New System.Windows.Forms.TextBox()
		Me.xcbx_Speed = New System.Windows.Forms.CheckBox()
		Me.TabPage3 = New System.Windows.Forms.TabPage()
		Me.ToolStrip1.SuspendLayout
		Me.TabControl1.SuspendLayout
		Me.TabPage1.SuspendLayout
		Me.TabPage2.SuspendLayout
		Me.Panel1.SuspendLayout
		CType(Me.xnud_SNCQOP,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'ToolStrip1
		'
		Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.xbtn_ts_New, Me.xbtn_ts_Edit, Me.xbtn_ts_Save, Me.xbtn_ts_Delete, Me.xbtn_ts_Cancel})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(455, 25)
		Me.ToolStrip1.TabIndex = 0
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'xbtn_ts_New
		'
		Me.xbtn_ts_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_New.Image = Global.xSAPtorExcel.My.Resources.Resources.Registry
		Me.xbtn_ts_New.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_New.Name = "xbtn_ts_New"
		Me.xbtn_ts_New.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_New.Tag = "xtag_New"
		Me.xbtn_ts_New.Text = "Create"
		Me.xbtn_ts_New.ToolTipText = "Create new connection"
		Me.xbtn_ts_New.Visible = false
		'
		'xbtn_ts_Edit
		'
		Me.xbtn_ts_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_Edit.Image = Global.xSAPtorExcel.My.Resources.Resources.Edit
		Me.xbtn_ts_Edit.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_Edit.Name = "xbtn_ts_Edit"
		Me.xbtn_ts_Edit.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_Edit.Tag = "xtag_Edit"
		Me.xbtn_ts_Edit.Text = "Edit"
		Me.xbtn_ts_Edit.ToolTipText = "Edit connection"
		Me.xbtn_ts_Edit.Visible = false
		'
		'xbtn_ts_Save
		'
		Me.xbtn_ts_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_Save.Image = Global.xSAPtorExcel.My.Resources.Resources.Save
		Me.xbtn_ts_Save.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_Save.Name = "xbtn_ts_Save"
		Me.xbtn_ts_Save.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_Save.Tag = "xtag_Save"
		Me.xbtn_ts_Save.Text = "Save"
		Me.xbtn_ts_Save.ToolTipText = "Save Connection"
		Me.xbtn_ts_Save.Visible = false
		'
		'xbtn_ts_Delete
		'
		Me.xbtn_ts_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_Delete.Image = Global.xSAPtorExcel.My.Resources.Resources.Delete
		Me.xbtn_ts_Delete.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_Delete.Name = "xbtn_ts_Delete"
		Me.xbtn_ts_Delete.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_Delete.Tag = "xtag_Delete"
		Me.xbtn_ts_Delete.Text = "Delete"
		Me.xbtn_ts_Delete.ToolTipText = "Delete Connection"
		Me.xbtn_ts_Delete.Visible = false
		'
		'xbtn_ts_Cancel
		'
		Me.xbtn_ts_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.xbtn_ts_Cancel.Image = Global.xSAPtorExcel.My.Resources.Resources.Cancel
		Me.xbtn_ts_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.xbtn_ts_Cancel.Name = "xbtn_ts_Cancel"
		Me.xbtn_ts_Cancel.Size = New System.Drawing.Size(23, 22)
		Me.xbtn_ts_Cancel.Tag = "xtag_Cancel"
		Me.xbtn_ts_Cancel.Text = "Cancel"
		Me.xbtn_ts_Cancel.Visible = false
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.TabPage1)
		Me.TabControl1.Controls.Add(Me.TabPage2)
		Me.TabControl1.Controls.Add(Me.TabPage3)
		Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TabControl1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TabControl1.Location = New System.Drawing.Point(0, 25)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(455, 178)
		Me.TabControl1.TabIndex = 1
		'
		'TabPage1
		'
		Me.TabPage1.Controls.Add(Me.xtbx_Router)
		Me.TabPage1.Controls.Add(Me.xtbx_SysID)
		Me.TabPage1.Controls.Add(Me.xtbx_InsNo)
		Me.TabPage1.Controls.Add(Me.xtbx_AppSrvr)
		Me.TabPage1.Controls.Add(Me.xtbx_Name)
		Me.TabPage1.Controls.Add(Me.Label5)
		Me.TabPage1.Controls.Add(Me.Label4)
		Me.TabPage1.Controls.Add(Me.Label3)
		Me.TabPage1.Controls.Add(Me.Label2)
		Me.TabPage1.Controls.Add(Me.Label1)
		Me.TabPage1.Location = New System.Drawing.Point(4, 25)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(447, 149)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "Connection"
		Me.TabPage1.UseVisualStyleBackColor = true
		'
		'xtbx_Router
		'
		Me.xtbx_Router.AcceptsReturn = true
		Me.xtbx_Router.AcceptsTab = true
		Me.xtbx_Router.Enabled = false
		Me.xtbx_Router.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_Router.Location = New System.Drawing.Point(167, 118)
		Me.xtbx_Router.Name = "xtbx_Router"
		Me.xtbx_Router.Size = New System.Drawing.Size(271, 22)
		Me.xtbx_Router.TabIndex = 5
		Me.xtbx_Router.WordWrap = false
		'
		'xtbx_SysID
		'
		Me.xtbx_SysID.AcceptsReturn = true
		Me.xtbx_SysID.AcceptsTab = true
		Me.xtbx_SysID.Enabled = false
		Me.xtbx_SysID.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_SysID.Location = New System.Drawing.Point(167, 90)
		Me.xtbx_SysID.Name = "xtbx_SysID"
		Me.xtbx_SysID.Size = New System.Drawing.Size(40, 22)
		Me.xtbx_SysID.TabIndex = 4
		Me.xtbx_SysID.WordWrap = false
		'
		'xtbx_InsNo
		'
		Me.xtbx_InsNo.AcceptsReturn = true
		Me.xtbx_InsNo.AcceptsTab = true
		Me.xtbx_InsNo.Enabled = false
		Me.xtbx_InsNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_InsNo.Location = New System.Drawing.Point(167, 62)
		Me.xtbx_InsNo.MaxLength = 2
		Me.xtbx_InsNo.Name = "xtbx_InsNo"
		Me.xtbx_InsNo.Size = New System.Drawing.Size(40, 22)
		Me.xtbx_InsNo.TabIndex = 3
		Me.xtbx_InsNo.WordWrap = false
		'
		'xtbx_AppSrvr
		'
		Me.xtbx_AppSrvr.AcceptsReturn = true
		Me.xtbx_AppSrvr.AcceptsTab = true
		Me.xtbx_AppSrvr.Enabled = false
		Me.xtbx_AppSrvr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_AppSrvr.Location = New System.Drawing.Point(167, 34)
		Me.xtbx_AppSrvr.Name = "xtbx_AppSrvr"
		Me.xtbx_AppSrvr.Size = New System.Drawing.Size(271, 22)
		Me.xtbx_AppSrvr.TabIndex = 2
		Me.xtbx_AppSrvr.WordWrap = false
		'
		'xtbx_Name
		'
		Me.xtbx_Name.AcceptsReturn = true
		Me.xtbx_Name.AcceptsTab = true
		Me.xtbx_Name.Enabled = false
		Me.xtbx_Name.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_Name.Location = New System.Drawing.Point(167, 6)
		Me.xtbx_Name.Name = "xtbx_Name"
		Me.xtbx_Name.Size = New System.Drawing.Size(271, 22)
		Me.xtbx_Name.TabIndex = 1
		Me.xtbx_Name.WordWrap = false
		'
		'Label5
		'
		Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label5.Location = New System.Drawing.Point(10, 121)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(108, 18)
		Me.Label5.TabIndex = 0
		Me.Label5.Text = "SAP Router"
		'
		'Label4
		'
		Me.Label4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label4.Location = New System.Drawing.Point(10, 93)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(98, 18)
		Me.Label4.TabIndex = 0
		Me.Label4.Text = "System ID"
		'
		'Label3
		'
		Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label3.Location = New System.Drawing.Point(10, 65)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(158, 18)
		Me.Label3.TabIndex = 0
		Me.Label3.Text = "Instance Number"
		'
		'Label2
		'
		Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(10, 37)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(188, 18)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "Application Server"
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(8, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(118, 18)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Description"
		'
		'TabPage2
		'
		Me.TabPage2.Controls.Add(Me.Panel1)
		Me.TabPage2.Controls.Add(Me.xcbx_Speed)
		Me.TabPage2.Location = New System.Drawing.Point(4, 25)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(447, 149)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "Network"
		Me.TabPage2.UseVisualStyleBackColor = true
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.xnud_SNCQOP)
		Me.Panel1.Controls.Add(Me.Label7)
		Me.Panel1.Controls.Add(Me.xcbx_SNCActive)
		Me.Panel1.Controls.Add(Me.Label6)
		Me.Panel1.Controls.Add(Me.xcbx_SNCUsrPwd)
		Me.Panel1.Controls.Add(Me.xtbx_SNCName)
		Me.Panel1.Location = New System.Drawing.Point(10, 15)
		Me.Panel1.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(393, 102)
		Me.Panel1.TabIndex = 7
		'
		'xnud_SNCQOP
		'
		Me.xnud_SNCQOP.Location = New System.Drawing.Point(111, 72)
		Me.xnud_SNCQOP.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
		Me.xnud_SNCQOP.Name = "xnud_SNCQOP"
		Me.xnud_SNCQOP.Size = New System.Drawing.Size(47, 22)
		Me.xnud_SNCQOP.TabIndex = 9
		'
		'Label7
		'
		Me.Label7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label7.Location = New System.Drawing.Point(23, 74)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(82, 18)
		Me.Label7.TabIndex = 7
		Me.Label7.Text = "SNC QOP:"
		'
		'xcbx_SNCActive
		'
		Me.xcbx_SNCActive.AutoSize = true
		Me.xcbx_SNCActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xcbx_SNCActive.Enabled = false
		Me.xcbx_SNCActive.Location = New System.Drawing.Point(10, 10)
		Me.xcbx_SNCActive.Margin = New System.Windows.Forms.Padding(10, 10, 3, 3)
		Me.xcbx_SNCActive.Name = "xcbx_SNCActive"
		Me.xcbx_SNCActive.Size = New System.Drawing.Size(115, 20)
		Me.xcbx_SNCActive.TabIndex = 4
		Me.xcbx_SNCActive.Text = "SNC Active:"
		Me.xcbx_SNCActive.UseVisualStyleBackColor = true
		'
		'Label6
		'
		Me.Label6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label6.Location = New System.Drawing.Point(23, 40)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(82, 18)
		Me.Label6.TabIndex = 2
		Me.Label6.Text = "SNC Name:"
		'
		'xcbx_SNCUsrPwd
		'
		Me.xcbx_SNCUsrPwd.AutoSize = true
		Me.xcbx_SNCUsrPwd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xcbx_SNCUsrPwd.Enabled = false
		Me.xcbx_SNCUsrPwd.Location = New System.Drawing.Point(186, 73)
		Me.xcbx_SNCUsrPwd.Name = "xcbx_SNCUsrPwd"
		Me.xcbx_SNCUsrPwd.Size = New System.Drawing.Size(179, 20)
		Me.xcbx_SNCUsrPwd.TabIndex = 5
		Me.xcbx_SNCUsrPwd.Text = "Logon User/Password"
		Me.xcbx_SNCUsrPwd.UseVisualStyleBackColor = true
		'
		'xtbx_SNCName
		'
		Me.xtbx_SNCName.AcceptsReturn = true
		Me.xtbx_SNCName.AcceptsTab = true
		Me.xtbx_SNCName.Enabled = false
		Me.xtbx_SNCName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_SNCName.Location = New System.Drawing.Point(111, 37)
		Me.xtbx_SNCName.Name = "xtbx_SNCName"
		Me.xtbx_SNCName.Size = New System.Drawing.Size(254, 22)
		Me.xtbx_SNCName.TabIndex = 3
		Me.xtbx_SNCName.WordWrap = false
		'
		'xcbx_Speed
		'
		Me.xcbx_Speed.AutoSize = true
		Me.xcbx_Speed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xcbx_Speed.Enabled = false
		Me.xcbx_Speed.Location = New System.Drawing.Point(10, 123)
		Me.xcbx_Speed.Name = "xcbx_Speed"
		Me.xcbx_Speed.Size = New System.Drawing.Size(187, 20)
		Me.xcbx_Speed.TabIndex = 6
		Me.xcbx_Speed.Text = "Low Speed Connection"
		Me.xcbx_Speed.UseVisualStyleBackColor = true
		'
		'TabPage3
		'
		Me.TabPage3.Location = New System.Drawing.Point(4, 25)
		Me.TabPage3.Name = "TabPage3"
		Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage3.Size = New System.Drawing.Size(447, 209)
		Me.TabPage3.TabIndex = 2
		Me.TabPage3.Text = "CodePage"
		Me.TabPage3.UseVisualStyleBackColor = true
		'
		'UCConnectionView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.TabControl1)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Name = "UCConnectionView"
		Me.Size = New System.Drawing.Size(455, 203)
		Me.ToolStrip1.ResumeLayout(false)
		Me.ToolStrip1.PerformLayout
		Me.TabControl1.ResumeLayout(false)
		Me.TabPage1.ResumeLayout(false)
		Me.TabPage1.PerformLayout
		Me.TabPage2.ResumeLayout(false)
		Me.TabPage2.PerformLayout
		Me.Panel1.ResumeLayout(false)
		Me.Panel1.PerformLayout
		CType(Me.xnud_SNCQOP,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

	Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
	Friend WithEvents xbtn_ts_Edit As Windows.Forms.ToolStripButton
	Friend WithEvents xbtn_ts_Save As Windows.Forms.ToolStripButton
	Friend WithEvents xbtn_ts_Delete As Windows.Forms.ToolStripButton
	Friend WithEvents TabControl1 As Windows.Forms.TabControl
	Friend WithEvents TabPage1 As Windows.Forms.TabPage
	Friend WithEvents xtbx_Router As Windows.Forms.TextBox
	Friend WithEvents xtbx_SysID As Windows.Forms.TextBox
	Friend WithEvents xtbx_InsNo As Windows.Forms.TextBox
	Friend WithEvents xtbx_AppSrvr As Windows.Forms.TextBox
	Friend WithEvents xtbx_Name As Windows.Forms.TextBox
	Friend WithEvents Label5 As Windows.Forms.Label
	Friend WithEvents Label4 As Windows.Forms.Label
	Friend WithEvents Label3 As Windows.Forms.Label
	Friend WithEvents Label2 As Windows.Forms.Label
	Friend WithEvents Label1 As Windows.Forms.Label
	Friend WithEvents TabPage2 As Windows.Forms.TabPage
	Friend WithEvents TabPage3 As Windows.Forms.TabPage
	Friend WithEvents xtbx_SNCName As Windows.Forms.TextBox
	Friend WithEvents Label6 As Windows.Forms.Label
	Friend WithEvents xcbx_SNCActive As Windows.Forms.CheckBox
	Friend WithEvents xcbx_Speed As Windows.Forms.CheckBox
	Friend WithEvents xcbx_SNCUsrPwd As Windows.Forms.CheckBox
	Friend WithEvents xbtn_ts_Cancel As Windows.Forms.ToolStripButton
	Friend WithEvents xbtn_ts_New As Windows.Forms.ToolStripButton
	Friend WithEvents Panel1 As Windows.Forms.Panel
	Friend WithEvents Label7 As Windows.Forms.Label
	Friend WithEvents xnud_SNCQOP As Windows.Forms.NumericUpDown
End Class
