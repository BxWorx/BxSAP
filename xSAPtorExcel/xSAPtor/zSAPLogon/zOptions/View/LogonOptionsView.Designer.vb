<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogonOptionsView
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
		Me.xchb_AutoSave = New System.Windows.Forms.CheckBox()
		Me.xchb_SavePWrds = New System.Windows.Forms.CheckBox()
		Me.xtbx_DefLang = New System.Windows.Forms.TextBox()
		Me.xchb_HidePassword = New System.Windows.Forms.CheckBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.xchb_AutoConnect = New System.Windows.Forms.CheckBox()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.xchb_ConfigViewerActive = New System.Windows.Forms.CheckBox()
		Me.GroupBox1.SuspendLayout
		Me.GroupBox2.SuspendLayout
		Me.SuspendLayout
		'
		'xchb_AutoSave
		'
		Me.xchb_AutoSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_AutoSave.AutoSize = true
		Me.xchb_AutoSave.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_AutoSave.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_AutoSave.Location = New System.Drawing.Point(167, 49)
		Me.xchb_AutoSave.Name = "xchb_AutoSave"
		Me.xchb_AutoSave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_AutoSave.Size = New System.Drawing.Size(107, 20)
		Me.xchb_AutoSave.TabIndex = 1
		Me.xchb_AutoSave.Text = "Auto Save:"
		Me.xchb_AutoSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_AutoSave.UseVisualStyleBackColor = true
		'
		'xchb_SavePWrds
		'
		Me.xchb_SavePWrds.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_SavePWrds.AutoSize = true
		Me.xchb_SavePWrds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_SavePWrds.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_SavePWrds.Location = New System.Drawing.Point(127, 75)
		Me.xchb_SavePWrds.Name = "xchb_SavePWrds"
		Me.xchb_SavePWrds.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_SavePWrds.Size = New System.Drawing.Size(147, 20)
		Me.xchb_SavePWrds.TabIndex = 2
		Me.xchb_SavePWrds.Text = "Save passwords:"
		Me.xchb_SavePWrds.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_SavePWrds.UseVisualStyleBackColor = true
		'
		'xtbx_DefLang
		'
		Me.xtbx_DefLang.AutoCompleteCustomSource.AddRange(New String() {"EN", "DE"})
		Me.xtbx_DefLang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
		Me.xtbx_DefLang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
		Me.xtbx_DefLang.CausesValidation = false
		Me.xtbx_DefLang.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_DefLang.Location = New System.Drawing.Point(174, 18)
		Me.xtbx_DefLang.MaxLength = 2
		Me.xtbx_DefLang.Name = "xtbx_DefLang"
		Me.xtbx_DefLang.Size = New System.Drawing.Size(100, 22)
		Me.xtbx_DefLang.TabIndex = 1
		Me.xtbx_DefLang.TabStop = false
		'
		'xchb_HidePassword
		'
		Me.xchb_HidePassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_HidePassword.AutoSize = true
		Me.xchb_HidePassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_HidePassword.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_HidePassword.Location = New System.Drawing.Point(135, 101)
		Me.xchb_HidePassword.Name = "xchb_HidePassword"
		Me.xchb_HidePassword.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_HidePassword.Size = New System.Drawing.Size(139, 20)
		Me.xchb_HidePassword.TabIndex = 3
		Me.xchb_HidePassword.Text = "Show Password:"
		Me.xchb_HidePassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_HidePassword.UseVisualStyleBackColor = true
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(15, 17)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(153, 23)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Default Language:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.xchb_AutoConnect)
		Me.GroupBox1.Controls.Add(Me.xchb_AutoSave)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.xchb_SavePWrds)
		Me.GroupBox1.Controls.Add(Me.xchb_HidePassword)
		Me.GroupBox1.Controls.Add(Me.xtbx_DefLang)
		Me.GroupBox1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(296, 159)
		Me.GroupBox1.TabIndex = 4
		Me.GroupBox1.TabStop = false
		Me.GroupBox1.Text = "Logon:"
		'
		'xchb_AutoConnect
		'
		Me.xchb_AutoConnect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_AutoConnect.AutoSize = true
		Me.xchb_AutoConnect.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_AutoConnect.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_AutoConnect.Location = New System.Drawing.Point(55, 127)
		Me.xchb_AutoConnect.Name = "xchb_AutoConnect"
		Me.xchb_AutoConnect.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_AutoConnect.Size = New System.Drawing.Size(219, 20)
		Me.xchb_AutoConnect.TabIndex = 4
		Me.xchb_AutoConnect.Text = "Try Connect at Selection"
		Me.xchb_AutoConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_AutoConnect.UseVisualStyleBackColor = true
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.xchb_ConfigViewerActive)
		Me.GroupBox2.Location = New System.Drawing.Point(8, 173)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(296, 50)
		Me.GroupBox2.TabIndex = 5
		Me.GroupBox2.TabStop = false
		Me.GroupBox2.Text = "SAP GUI"
		'
		'xchb_ConfigViewerActive
		'
		Me.xchb_ConfigViewerActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_ConfigViewerActive.AutoSize = true
		Me.xchb_ConfigViewerActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_ConfigViewerActive.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_ConfigViewerActive.Location = New System.Drawing.Point(79, 19)
		Me.xchb_ConfigViewerActive.Name = "xchb_ConfigViewerActive"
		Me.xchb_ConfigViewerActive.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_ConfigViewerActive.Size = New System.Drawing.Size(195, 20)
		Me.xchb_ConfigViewerActive.TabIndex = 5
		Me.xchb_ConfigViewerActive.Text = "Config Viewer Active:"
		Me.xchb_ConfigViewerActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_ConfigViewerActive.UseVisualStyleBackColor = true
		'
		'xSAPLogonOptions
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(311, 232)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.KeyPreview = true
		Me.Name = "xSAPLogonOptions"
		Me.Padding = New System.Windows.Forms.Padding(5)
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "Logon Options"
		Me.TopMost = true
		Me.GroupBox1.ResumeLayout(false)
		Me.GroupBox1.PerformLayout
		Me.GroupBox2.ResumeLayout(false)
		Me.GroupBox2.PerformLayout
		Me.ResumeLayout(false)

End Sub

  Friend WithEvents xchb_AutoSave As Windows.Forms.CheckBox
  Friend WithEvents xchb_SavePWrds As Windows.Forms.CheckBox
  Friend WithEvents xtbx_DefLang As Windows.Forms.TextBox
  Friend WithEvents xchb_HidePassword As Windows.Forms.CheckBox
  Friend WithEvents Label1 As Windows.Forms.Label
  Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
  Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
  Friend WithEvents xchb_ConfigViewerActive As Windows.Forms.CheckBox
  Friend WithEvents xchb_AutoConnect As Windows.Forms.CheckBox
End Class
