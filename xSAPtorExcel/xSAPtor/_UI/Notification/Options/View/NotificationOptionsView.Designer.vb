Namespace Main.Notification.Options

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotificationOptionsView
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
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.xchb_ShowError = New System.Windows.Forms.CheckBox()
		Me.xchb_ShowWarning = New System.Windows.Forms.CheckBox()
		Me.xchb_ShowInfo = New System.Windows.Forms.CheckBox()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.xnud_LogSize = New System.Windows.Forms.NumericUpDown()
		Me.xchb_LogError = New System.Windows.Forms.CheckBox()
		Me.xchb_LogWarn = New System.Windows.Forms.CheckBox()
		Me.xchb_LogInfo = New System.Windows.Forms.CheckBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.xchb_MsgStarted = New System.Windows.Forms.CheckBox()
		Me.xchb_ShowSyst = New System.Windows.Forms.CheckBox()
		Me.xchb_ShowTrace = New System.Windows.Forms.CheckBox()
		Me.xchb_LogSyst = New System.Windows.Forms.CheckBox()
		Me.xchb_LogTrace = New System.Windows.Forms.CheckBox()
		Me.GroupBox2.SuspendLayout
		Me.GroupBox3.SuspendLayout
		CType(Me.xnud_LogSize,System.ComponentModel.ISupportInitialize).BeginInit
		Me.GroupBox1.SuspendLayout
		Me.SuspendLayout
		'
		'GroupBox2
		'
		Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.GroupBox2.Controls.Add(Me.xchb_ShowTrace)
		Me.GroupBox2.Controls.Add(Me.xchb_ShowSyst)
		Me.GroupBox2.Controls.Add(Me.xchb_ShowError)
		Me.GroupBox2.Controls.Add(Me.xchb_ShowWarning)
		Me.GroupBox2.Controls.Add(Me.xchb_ShowInfo)
		Me.GroupBox2.Font = New System.Drawing.Font("Courier New", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GroupBox2.Location = New System.Drawing.Point(7, 8)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(147, 148)
		Me.GroupBox2.TabIndex = 5
		Me.GroupBox2.TabStop = false
		Me.GroupBox2.Text = "Display:"
		'
		'xchb_ShowError
		'
		Me.xchb_ShowError.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_ShowError.AutoSize = true
		Me.xchb_ShowError.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_ShowError.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_ShowError.Location = New System.Drawing.Point(66, 73)
		Me.xchb_ShowError.Name = "xchb_ShowError"
		Me.xchb_ShowError.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_ShowError.Size = New System.Drawing.Size(75, 19)
		Me.xchb_ShowError.TabIndex = 3
		Me.xchb_ShowError.Text = "Errors:"
		Me.xchb_ShowError.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_ShowError.UseVisualStyleBackColor = true
		'
		'xchb_ShowWarning
		'
		Me.xchb_ShowWarning.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_ShowWarning.AutoSize = true
		Me.xchb_ShowWarning.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_ShowWarning.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_ShowWarning.Location = New System.Drawing.Point(59, 48)
		Me.xchb_ShowWarning.Name = "xchb_ShowWarning"
		Me.xchb_ShowWarning.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_ShowWarning.Size = New System.Drawing.Size(82, 19)
		Me.xchb_ShowWarning.TabIndex = 2
		Me.xchb_ShowWarning.Text = "Warning:"
		Me.xchb_ShowWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_ShowWarning.UseVisualStyleBackColor = true
		'
		'xchb_ShowInfo
		'
		Me.xchb_ShowInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_ShowInfo.AutoSize = true
		Me.xchb_ShowInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_ShowInfo.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_ShowInfo.Location = New System.Drawing.Point(31, 23)
		Me.xchb_ShowInfo.Name = "xchb_ShowInfo"
		Me.xchb_ShowInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_ShowInfo.Size = New System.Drawing.Size(110, 19)
		Me.xchb_ShowInfo.TabIndex = 1
		Me.xchb_ShowInfo.Text = "Information:"
		Me.xchb_ShowInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_ShowInfo.UseVisualStyleBackColor = true
		'
		'GroupBox3
		'
		Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.GroupBox3.Controls.Add(Me.xchb_LogTrace)
		Me.GroupBox3.Controls.Add(Me.xchb_LogSyst)
		Me.GroupBox3.Controls.Add(Me.Label2)
		Me.GroupBox3.Controls.Add(Me.xnud_LogSize)
		Me.GroupBox3.Controls.Add(Me.xchb_LogError)
		Me.GroupBox3.Controls.Add(Me.xchb_LogWarn)
		Me.GroupBox3.Controls.Add(Me.xchb_LogInfo)
		Me.GroupBox3.Font = New System.Drawing.Font("Courier New", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GroupBox3.Location = New System.Drawing.Point(8, 162)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(147, 184)
		Me.GroupBox3.TabIndex = 7
		Me.GroupBox3.TabStop = false
		Me.GroupBox3.Text = "Log:"
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Location = New System.Drawing.Point(40, 154)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(48, 16)
		Me.Label2.TabIndex = 9
		Me.Label2.Text = "Size:"
		'
		'xnud_LogSize
		'
		Me.xnud_LogSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xnud_LogSize.Increment = New Decimal(New Integer() {10, 0, 0, 0})
		Me.xnud_LogSize.Location = New System.Drawing.Point(94, 152)
		Me.xnud_LogSize.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
		Me.xnud_LogSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.xnud_LogSize.Name = "xnud_LogSize"
		Me.xnud_LogSize.Size = New System.Drawing.Size(46, 22)
		Me.xnud_LogSize.TabIndex = 8
		Me.xnud_LogSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.xnud_LogSize.ThousandsSeparator = true
		Me.xnud_LogSize.Value = New Decimal(New Integer() {20, 0, 0, 0})
		'
		'xchb_LogError
		'
		Me.xchb_LogError.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_LogError.AutoSize = true
		Me.xchb_LogError.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_LogError.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_LogError.Location = New System.Drawing.Point(66, 73)
		Me.xchb_LogError.Name = "xchb_LogError"
		Me.xchb_LogError.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_LogError.Size = New System.Drawing.Size(75, 19)
		Me.xchb_LogError.TabIndex = 7
		Me.xchb_LogError.Text = "Errors:"
		Me.xchb_LogError.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_LogError.UseVisualStyleBackColor = true
		'
		'xchb_LogWarn
		'
		Me.xchb_LogWarn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_LogWarn.AutoSize = true
		Me.xchb_LogWarn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_LogWarn.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_LogWarn.Location = New System.Drawing.Point(59, 48)
		Me.xchb_LogWarn.Name = "xchb_LogWarn"
		Me.xchb_LogWarn.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_LogWarn.Size = New System.Drawing.Size(82, 19)
		Me.xchb_LogWarn.TabIndex = 6
		Me.xchb_LogWarn.Text = "Warning:"
		Me.xchb_LogWarn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_LogWarn.UseVisualStyleBackColor = true
		'
		'xchb_LogInfo
		'
		Me.xchb_LogInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_LogInfo.AutoSize = true
		Me.xchb_LogInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_LogInfo.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_LogInfo.Location = New System.Drawing.Point(31, 23)
		Me.xchb_LogInfo.Name = "xchb_LogInfo"
		Me.xchb_LogInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_LogInfo.Size = New System.Drawing.Size(110, 19)
		Me.xchb_LogInfo.TabIndex = 5
		Me.xchb_LogInfo.Text = "Information:"
		Me.xchb_LogInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_LogInfo.UseVisualStyleBackColor = true
		'
		'GroupBox1
		'
		Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.GroupBox1.Controls.Add(Me.xchb_MsgStarted)
		Me.GroupBox1.Font = New System.Drawing.Font("Courier New", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GroupBox1.Location = New System.Drawing.Point(8, 352)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(147, 51)
		Me.GroupBox1.TabIndex = 8
		Me.GroupBox1.TabStop = false
		Me.GroupBox1.Text = "General:"
		'
		'xchb_MsgStarted
		'
		Me.xchb_MsgStarted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_MsgStarted.AutoSize = true
		Me.xchb_MsgStarted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_MsgStarted.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_MsgStarted.Location = New System.Drawing.Point(10, 23)
		Me.xchb_MsgStarted.Name = "xchb_MsgStarted"
		Me.xchb_MsgStarted.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_MsgStarted.Size = New System.Drawing.Size(131, 19)
		Me.xchb_MsgStarted.TabIndex = 9
		Me.xchb_MsgStarted.Text = "Notify Started:"
		Me.xchb_MsgStarted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_MsgStarted.UseVisualStyleBackColor = true
		'
		'xchb_ShowSyst
		'
		Me.xchb_ShowSyst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_ShowSyst.AutoSize = true
		Me.xchb_ShowSyst.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_ShowSyst.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_ShowSyst.Location = New System.Drawing.Point(66, 98)
		Me.xchb_ShowSyst.Name = "xchb_ShowSyst"
		Me.xchb_ShowSyst.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_ShowSyst.Size = New System.Drawing.Size(75, 19)
		Me.xchb_ShowSyst.TabIndex = 4
		Me.xchb_ShowSyst.Text = "System:"
		Me.xchb_ShowSyst.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_ShowSyst.UseVisualStyleBackColor = true
		'
		'xchb_ShowTrace
		'
		Me.xchb_ShowTrace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_ShowTrace.AutoSize = true
		Me.xchb_ShowTrace.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_ShowTrace.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_ShowTrace.Location = New System.Drawing.Point(74, 123)
		Me.xchb_ShowTrace.Name = "xchb_ShowTrace"
		Me.xchb_ShowTrace.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_ShowTrace.Size = New System.Drawing.Size(68, 19)
		Me.xchb_ShowTrace.TabIndex = 5
		Me.xchb_ShowTrace.Text = "Trace:"
		Me.xchb_ShowTrace.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_ShowTrace.UseVisualStyleBackColor = true
		'
		'xchb_LogSyst
		'
		Me.xchb_LogSyst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_LogSyst.AutoSize = true
		Me.xchb_LogSyst.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_LogSyst.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_LogSyst.Location = New System.Drawing.Point(65, 98)
		Me.xchb_LogSyst.Name = "xchb_LogSyst"
		Me.xchb_LogSyst.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_LogSyst.Size = New System.Drawing.Size(75, 19)
		Me.xchb_LogSyst.TabIndex = 10
		Me.xchb_LogSyst.Text = "System:"
		Me.xchb_LogSyst.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_LogSyst.UseVisualStyleBackColor = true
		'
		'xchb_LogTrace
		'
		Me.xchb_LogTrace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_LogTrace.AutoSize = true
		Me.xchb_LogTrace.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_LogTrace.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_LogTrace.Location = New System.Drawing.Point(72, 123)
		Me.xchb_LogTrace.Name = "xchb_LogTrace"
		Me.xchb_LogTrace.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_LogTrace.Size = New System.Drawing.Size(68, 19)
		Me.xchb_LogTrace.TabIndex = 11
		Me.xchb_LogTrace.Text = "Trace:"
		Me.xchb_LogTrace.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_LogTrace.UseVisualStyleBackColor = true
		'
		'NotificationOptionsView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(162, 408)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.GroupBox3)
		Me.Controls.Add(Me.GroupBox2)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.Name = "NotificationOptionsView"
		Me.Padding = New System.Windows.Forms.Padding(5)
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "Notification Options:"
		Me.TopMost = true
		Me.GroupBox2.ResumeLayout(false)
		Me.GroupBox2.PerformLayout
		Me.GroupBox3.ResumeLayout(false)
		Me.GroupBox3.PerformLayout
		CType(Me.xnud_LogSize,System.ComponentModel.ISupportInitialize).EndInit
		Me.GroupBox1.ResumeLayout(false)
		Me.GroupBox1.PerformLayout
		Me.ResumeLayout(false)

End Sub
	Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
	Friend WithEvents xchb_ShowInfo As Windows.Forms.CheckBox
	Friend WithEvents xchb_ShowError As Windows.Forms.CheckBox
	Friend WithEvents xchb_ShowWarning As Windows.Forms.CheckBox
		Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
		Friend WithEvents xchb_LogError As Windows.Forms.CheckBox
		Friend WithEvents xchb_LogWarn As Windows.Forms.CheckBox
		Friend WithEvents xchb_LogInfo As Windows.Forms.CheckBox
		Friend WithEvents xnud_LogSize As Windows.Forms.NumericUpDown
		Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
		Friend WithEvents xchb_MsgStarted As Windows.Forms.CheckBox
		Friend WithEvents Label2 As Windows.Forms.Label
		Friend WithEvents xchb_ShowTrace As Windows.Forms.CheckBox
		Friend WithEvents xchb_ShowSyst As Windows.Forms.CheckBox
		Friend WithEvents xchb_LogTrace As Windows.Forms.CheckBox
		Friend WithEvents xchb_LogSyst As Windows.Forms.CheckBox
	End Class

End Namespace
