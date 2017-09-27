<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogonConnSetupView
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
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.xnud_ConnLimit = New System.Windows.Forms.NumericUpDown()
		Me.xnud_Idletimeout = New System.Windows.Forms.NumericUpDown()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.xnud_Idlechecktime = New System.Windows.Forms.NumericUpDown()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.xnud_Poolsize = New System.Windows.Forms.NumericUpDown()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.xchb_UseMan = New System.Windows.Forms.CheckBox()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.xbtn_FileBrowserSNC = New System.Windows.Forms.Button()
		Me.xtbx_SNCPath = New System.Windows.Forms.TextBox()
		Me.xtbx_SNC64 = New System.Windows.Forms.TextBox()
		Me.xtbx_SNC32 = New System.Windows.Forms.TextBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.TabPage3 = New System.Windows.Forms.TabPage()
		Me.xtbx_XMLNode = New System.Windows.Forms.TextBox()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.xtbx_XMLFile = New System.Windows.Forms.TextBox()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.xbtn_FileBrowserXML = New System.Windows.Forms.Button()
		Me.xtbx_XMLPath = New System.Windows.Forms.TextBox()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.xcbx_SAPGuiOnly = New System.Windows.Forms.CheckBox()
		Me.TabControl1.SuspendLayout
		Me.TabPage1.SuspendLayout
		Me.Panel1.SuspendLayout
		CType(Me.xnud_ConnLimit,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.xnud_Idletimeout,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.xnud_Idlechecktime,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.xnud_Poolsize,System.ComponentModel.ISupportInitialize).BeginInit
		Me.TabPage2.SuspendLayout
		Me.TabPage3.SuspendLayout
		Me.SuspendLayout
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.TabPage1)
		Me.TabControl1.Controls.Add(Me.TabPage2)
		Me.TabControl1.Controls.Add(Me.TabPage3)
		Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TabControl1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TabControl1.Location = New System.Drawing.Point(0, 0)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(519, 244)
		Me.TabControl1.TabIndex = 1
		'
		'TabPage1
		'
		Me.TabPage1.Controls.Add(Me.Panel1)
		Me.TabPage1.Controls.Add(Me.xchb_UseMan)
		Me.TabPage1.Controls.Add(Me.TextBox1)
		Me.TabPage1.Controls.Add(Me.Label1)
		Me.TabPage1.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TabPage1.Location = New System.Drawing.Point(4, 25)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(511, 215)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "Config"
		Me.TabPage1.UseVisualStyleBackColor = true
		'
		'Panel1
		'
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Panel1.Controls.Add(Me.Label2)
		Me.Panel1.Controls.Add(Me.xnud_ConnLimit)
		Me.Panel1.Controls.Add(Me.xnud_Idletimeout)
		Me.Panel1.Controls.Add(Me.Label3)
		Me.Panel1.Controls.Add(Me.xnud_Idlechecktime)
		Me.Panel1.Controls.Add(Me.Label4)
		Me.Panel1.Controls.Add(Me.xnud_Poolsize)
		Me.Panel1.Controls.Add(Me.Label5)
		Me.Panel1.Location = New System.Drawing.Point(18, 36)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(252, 128)
		Me.Panel1.TabIndex = 0
		'
		'Label2
		'
		Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(12, 12)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(160, 18)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "Connection Limit"
		'
		'xnud_ConnLimit
		'
		Me.xnud_ConnLimit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xnud_ConnLimit.Location = New System.Drawing.Point(178, 10)
		Me.xnud_ConnLimit.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
		Me.xnud_ConnLimit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.xnud_ConnLimit.Name = "xnud_ConnLimit"
		Me.xnud_ConnLimit.Size = New System.Drawing.Size(61, 22)
		Me.xnud_ConnLimit.TabIndex = 1
		Me.xnud_ConnLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.xnud_ConnLimit.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'xnud_Idletimeout
		'
		Me.xnud_Idletimeout.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xnud_Idletimeout.Location = New System.Drawing.Point(178, 94)
		Me.xnud_Idletimeout.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
		Me.xnud_Idletimeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.xnud_Idletimeout.Name = "xnud_Idletimeout"
		Me.xnud_Idletimeout.Size = New System.Drawing.Size(61, 22)
		Me.xnud_Idletimeout.TabIndex = 4
		Me.xnud_Idletimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.xnud_Idletimeout.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'Label3
		'
		Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label3.Location = New System.Drawing.Point(12, 40)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(160, 18)
		Me.Label3.TabIndex = 0
		Me.Label3.Text = "Pool Size"
		'
		'xnud_Idlechecktime
		'
		Me.xnud_Idlechecktime.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xnud_Idlechecktime.Location = New System.Drawing.Point(178, 66)
		Me.xnud_Idlechecktime.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
		Me.xnud_Idlechecktime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.xnud_Idlechecktime.Name = "xnud_Idlechecktime"
		Me.xnud_Idlechecktime.Size = New System.Drawing.Size(61, 22)
		Me.xnud_Idlechecktime.TabIndex = 3
		Me.xnud_Idlechecktime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.xnud_Idlechecktime.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'Label4
		'
		Me.Label4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label4.Location = New System.Drawing.Point(12, 68)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(160, 18)
		Me.Label4.TabIndex = 0
		Me.Label4.Text = "Idle Check time"
		'
		'xnud_Poolsize
		'
		Me.xnud_Poolsize.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xnud_Poolsize.Location = New System.Drawing.Point(178, 38)
		Me.xnud_Poolsize.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
		Me.xnud_Poolsize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.xnud_Poolsize.Name = "xnud_Poolsize"
		Me.xnud_Poolsize.Size = New System.Drawing.Size(61, 22)
		Me.xnud_Poolsize.TabIndex = 2
		Me.xnud_Poolsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.xnud_Poolsize.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'Label5
		'
		Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label5.Location = New System.Drawing.Point(12, 96)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(160, 18)
		Me.Label5.TabIndex = 0
		Me.Label5.Text = "Idle timeout"
		'
		'xchb_UseMan
		'
		Me.xchb_UseMan.AutoSize = true
		Me.xchb_UseMan.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_UseMan.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_UseMan.Location = New System.Drawing.Point(6, 10)
		Me.xchb_UseMan.Name = "xchb_UseMan"
		Me.xchb_UseMan.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_UseMan.Size = New System.Drawing.Size(187, 20)
		Me.xchb_UseMan.TabIndex = 5
		Me.xchb_UseMan.Text = "Use Manual Settings:"
		Me.xchb_UseMan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_UseMan.UseVisualStyleBackColor = true
		'
		'TextBox1
		'
		Me.TextBox1.AcceptsReturn = true
		Me.TextBox1.AcceptsTab = true
		Me.TextBox1.Enabled = false
		Me.TextBox1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.TextBox1.Location = New System.Drawing.Point(66, 174)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(46, 22)
		Me.TextBox1.TabIndex = 3
		Me.TextBox1.Visible = false
		Me.TextBox1.WordWrap = false
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(15, 174)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(36, 18)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "ID:"
		Me.Label1.Visible = false
		'
		'TabPage2
		'
		Me.TabPage2.Controls.Add(Me.xbtn_FileBrowserSNC)
		Me.TabPage2.Controls.Add(Me.xtbx_SNCPath)
		Me.TabPage2.Controls.Add(Me.xtbx_SNC64)
		Me.TabPage2.Controls.Add(Me.xtbx_SNC32)
		Me.TabPage2.Controls.Add(Me.Label8)
		Me.TabPage2.Controls.Add(Me.Label7)
		Me.TabPage2.Controls.Add(Me.Label6)
		Me.TabPage2.Location = New System.Drawing.Point(4, 25)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(511, 215)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "SSO"
		Me.TabPage2.UseVisualStyleBackColor = true
		'
		'xbtn_FileBrowserSNC
		'
		Me.xbtn_FileBrowserSNC.Image = Global.xSAPtorExcel.My.Resources.Resources.Pantone
		Me.xbtn_FileBrowserSNC.Location = New System.Drawing.Point(159, 74)
		Me.xbtn_FileBrowserSNC.Name = "xbtn_FileBrowserSNC"
		Me.xbtn_FileBrowserSNC.Size = New System.Drawing.Size(25, 23)
		Me.xbtn_FileBrowserSNC.TabIndex = 3
		Me.xbtn_FileBrowserSNC.Text = "Button1"
		Me.xbtn_FileBrowserSNC.UseVisualStyleBackColor = true
		'
		'xtbx_SNCPath
		'
		Me.xtbx_SNCPath.AcceptsReturn = true
		Me.xtbx_SNCPath.AcceptsTab = true
		Me.xtbx_SNCPath.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_SNCPath.Location = New System.Drawing.Point(24, 107)
		Me.xtbx_SNCPath.Name = "xtbx_SNCPath"
		Me.xtbx_SNCPath.Size = New System.Drawing.Size(479, 22)
		Me.xtbx_SNCPath.TabIndex = 4
		'
		'xtbx_SNC64
		'
		Me.xtbx_SNC64.AcceptsReturn = true
		Me.xtbx_SNC64.AcceptsTab = true
		Me.xtbx_SNC64.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_SNC64.Location = New System.Drawing.Point(159, 36)
		Me.xtbx_SNC64.Name = "xtbx_SNC64"
		Me.xtbx_SNC64.Size = New System.Drawing.Size(148, 22)
		Me.xtbx_SNC64.TabIndex = 2
		Me.xtbx_SNC64.WordWrap = false
		'
		'xtbx_SNC32
		'
		Me.xtbx_SNC32.AcceptsReturn = true
		Me.xtbx_SNC32.AcceptsTab = true
		Me.xtbx_SNC32.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_SNC32.Location = New System.Drawing.Point(159, 8)
		Me.xtbx_SNC32.Name = "xtbx_SNC32"
		Me.xtbx_SNC32.Size = New System.Drawing.Size(148, 22)
		Me.xtbx_SNC32.TabIndex = 1
		Me.xtbx_SNC32.WordWrap = false
		'
		'Label8
		'
		Me.Label8.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label8.Location = New System.Drawing.Point(8, 77)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(145, 18)
		Me.Label8.TabIndex = 0
		Me.Label8.Text = "SNC Library path:"
		'
		'Label7
		'
		Me.Label7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label7.Location = New System.Drawing.Point(8, 39)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(145, 18)
		Me.Label7.TabIndex = 0
		Me.Label7.Text = "SNC Library (64):"
		'
		'Label6
		'
		Me.Label6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label6.Location = New System.Drawing.Point(8, 11)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(145, 18)
		Me.Label6.TabIndex = 0
		Me.Label6.Text = "SNC Library (32):"
		'
		'TabPage3
		'
		Me.TabPage3.Controls.Add(Me.xcbx_SAPGuiOnly)
		Me.TabPage3.Controls.Add(Me.xtbx_XMLNode)
		Me.TabPage3.Controls.Add(Me.Label12)
		Me.TabPage3.Controls.Add(Me.Label11)
		Me.TabPage3.Controls.Add(Me.xtbx_XMLFile)
		Me.TabPage3.Controls.Add(Me.Label10)
		Me.TabPage3.Controls.Add(Me.xbtn_FileBrowserXML)
		Me.TabPage3.Controls.Add(Me.xtbx_XMLPath)
		Me.TabPage3.Controls.Add(Me.Label9)
		Me.TabPage3.Location = New System.Drawing.Point(4, 25)
		Me.TabPage3.Name = "TabPage3"
		Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage3.Size = New System.Drawing.Size(511, 215)
		Me.TabPage3.TabIndex = 2
		Me.TabPage3.Text = "SAPGUI"
		Me.TabPage3.UseVisualStyleBackColor = true
		'
		'xtbx_XMLNode
		'
		Me.xtbx_XMLNode.AcceptsReturn = true
		Me.xtbx_XMLNode.AcceptsTab = true
		Me.xtbx_XMLNode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_XMLNode.Location = New System.Drawing.Point(110, 114)
		Me.xtbx_XMLNode.Name = "xtbx_XMLNode"
		Me.xtbx_XMLNode.Size = New System.Drawing.Size(195, 22)
		Me.xtbx_XMLNode.TabIndex = 1
		'
		'Label12
		'
		Me.Label12.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label12.Location = New System.Drawing.Point(8, 117)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(96, 18)
		Me.Label12.TabIndex = 11
		Me.Label12.Text = "Start Node:"
		'
		'Label11
		'
		Me.Label11.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label11.Location = New System.Drawing.Point(8, 42)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(52, 18)
		Me.Label11.TabIndex = 10
		Me.Label11.Text = "Path:"
		'
		'xtbx_XMLFile
		'
		Me.xtbx_XMLFile.AcceptsReturn = true
		Me.xtbx_XMLFile.AcceptsTab = true
		Me.xtbx_XMLFile.Enabled = false
		Me.xtbx_XMLFile.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_XMLFile.Location = New System.Drawing.Point(66, 67)
		Me.xtbx_XMLFile.Name = "xtbx_XMLFile"
		Me.xtbx_XMLFile.Size = New System.Drawing.Size(239, 22)
		Me.xtbx_XMLFile.TabIndex = 9
		Me.xtbx_XMLFile.TabStop = false
		'
		'Label10
		'
		Me.Label10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label10.Location = New System.Drawing.Point(8, 70)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(52, 18)
		Me.Label10.TabIndex = 8
		Me.Label10.Text = "Name:"
		'
		'xbtn_FileBrowserXML
		'
		Me.xbtn_FileBrowserXML.Image = Global.xSAPtorExcel.My.Resources.Resources.Pantone
		Me.xbtn_FileBrowserXML.Location = New System.Drawing.Point(194, 10)
		Me.xbtn_FileBrowserXML.Name = "xbtn_FileBrowserXML"
		Me.xbtn_FileBrowserXML.Size = New System.Drawing.Size(25, 23)
		Me.xbtn_FileBrowserXML.TabIndex = 6
		Me.xbtn_FileBrowserXML.TabStop = false
		Me.xbtn_FileBrowserXML.Text = "Button1"
		Me.xbtn_FileBrowserXML.UseVisualStyleBackColor = true
		'
		'xtbx_XMLPath
		'
		Me.xtbx_XMLPath.AcceptsReturn = true
		Me.xtbx_XMLPath.AcceptsTab = true
		Me.xtbx_XMLPath.Enabled = false
		Me.xtbx_XMLPath.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_XMLPath.Location = New System.Drawing.Point(66, 39)
		Me.xtbx_XMLPath.Name = "xtbx_XMLPath"
		Me.xtbx_XMLPath.Size = New System.Drawing.Size(437, 22)
		Me.xtbx_XMLPath.TabIndex = 7
		Me.xtbx_XMLPath.TabStop = false
		'
		'Label9
		'
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label9.Location = New System.Drawing.Point(8, 13)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(180, 20)
		Me.Label9.TabIndex = 5
		Me.Label9.Text = "XML Config file path:"
		'
		'xcbx_SAPGuiOnly
		'
		Me.xcbx_SAPGuiOnly.AutoSize = true
		Me.xcbx_SAPGuiOnly.Checked = true
		Me.xcbx_SAPGuiOnly.CheckState = System.Windows.Forms.CheckState.Checked
		Me.xcbx_SAPGuiOnly.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xcbx_SAPGuiOnly.Location = New System.Drawing.Point(110, 151)
		Me.xcbx_SAPGuiOnly.Name = "xcbx_SAPGuiOnly"
		Me.xcbx_SAPGuiOnly.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xcbx_SAPGuiOnly.Size = New System.Drawing.Size(179, 20)
		Me.xcbx_SAPGuiOnly.TabIndex = 12
		Me.xcbx_SAPGuiOnly.Text = ": Only SAPGUI Types"
		Me.xcbx_SAPGuiOnly.UseVisualStyleBackColor = true
		'
		'LogonConnSetupView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(519, 244)
		Me.Controls.Add(Me.TabControl1)
		Me.Name = "LogonConnSetupView"
		Me.Text = "SAP Connection Setup"
		Me.TabControl1.ResumeLayout(false)
		Me.TabPage1.ResumeLayout(false)
		Me.TabPage1.PerformLayout
		Me.Panel1.ResumeLayout(false)
		CType(Me.xnud_ConnLimit,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.xnud_Idletimeout,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.xnud_Idlechecktime,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.xnud_Poolsize,System.ComponentModel.ISupportInitialize).EndInit
		Me.TabPage2.ResumeLayout(false)
		Me.TabPage2.PerformLayout
		Me.TabPage3.ResumeLayout(false)
		Me.TabPage3.PerformLayout
		Me.ResumeLayout(false)

End Sub
	Friend WithEvents TabControl1 As Windows.Forms.TabControl
	Friend WithEvents TabPage1 As Windows.Forms.TabPage
	Friend WithEvents TextBox1 As Windows.Forms.TextBox
	Friend WithEvents Label1 As Windows.Forms.Label
	Friend WithEvents xnud_ConnLimit As Windows.Forms.NumericUpDown
	Friend WithEvents Label2 As Windows.Forms.Label
	Friend WithEvents Label3 As Windows.Forms.Label
	Friend WithEvents Label5 As Windows.Forms.Label
	Friend WithEvents Label4 As Windows.Forms.Label
	Friend WithEvents xnud_Idletimeout As Windows.Forms.NumericUpDown
	Friend WithEvents xnud_Idlechecktime As Windows.Forms.NumericUpDown
	Friend WithEvents xnud_Poolsize As Windows.Forms.NumericUpDown
	Friend WithEvents Panel1 As Windows.Forms.Panel
	Friend WithEvents xchb_UseMan As Windows.Forms.CheckBox
	Friend WithEvents TabPage2 As Windows.Forms.TabPage
	Friend WithEvents xtbx_SNCPath As Windows.Forms.TextBox
	Friend WithEvents xtbx_SNC64 As Windows.Forms.TextBox
	Friend WithEvents xtbx_SNC32 As Windows.Forms.TextBox
	Friend WithEvents Label8 As Windows.Forms.Label
	Friend WithEvents Label7 As Windows.Forms.Label
	Friend WithEvents Label6 As Windows.Forms.Label
	Friend WithEvents xbtn_FileBrowserSNC As Windows.Forms.Button
	Friend WithEvents TabPage3 As Windows.Forms.TabPage
	Friend WithEvents xbtn_FileBrowserXML As Windows.Forms.Button
	Friend WithEvents xtbx_XMLPath As Windows.Forms.TextBox
	Friend WithEvents Label9 As Windows.Forms.Label
	Friend WithEvents Label11 As Windows.Forms.Label
	Friend WithEvents xtbx_XMLFile As Windows.Forms.TextBox
	Friend WithEvents Label10 As Windows.Forms.Label
	Friend WithEvents xtbx_XMLNode As Windows.Forms.TextBox
	Friend WithEvents Label12 As Windows.Forms.Label
	Friend WithEvents xcbx_SAPGuiOnly As Windows.Forms.CheckBox
End Class
