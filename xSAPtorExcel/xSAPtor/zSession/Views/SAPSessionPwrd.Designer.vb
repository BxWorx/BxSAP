<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAPSessionPwrd
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
		Me.xtbx_Pwrd = New System.Windows.Forms.TextBox()
		Me.xbtn_PwdShow = New System.Windows.Forms.Button()
		Me.xbtn_OK = New System.Windows.Forms.Button()
		Me.xbtn_Canc = New System.Windows.Forms.Button()
		Me.SuspendLayout
		'
		'xtbx_Pwrd
		'
		Me.xtbx_Pwrd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xtbx_Pwrd.Location = New System.Drawing.Point(14, 7)
		Me.xtbx_Pwrd.MaxLength = 30
		Me.xtbx_Pwrd.Name = "xtbx_Pwrd"
		Me.xtbx_Pwrd.Size = New System.Drawing.Size(152, 22)
		Me.xtbx_Pwrd.TabIndex = 11
		Me.xtbx_Pwrd.UseSystemPasswordChar = true
		Me.xtbx_Pwrd.WordWrap = false
		'
		'xbtn_PwdShow
		'
		Me.xbtn_PwdShow.Image = Global.xSAPtorExcel.My.Resources.Resources.Show
		Me.xbtn_PwdShow.Location = New System.Drawing.Point(70, 35)
		Me.xbtn_PwdShow.Name = "xbtn_PwdShow"
		Me.xbtn_PwdShow.Size = New System.Drawing.Size(23, 23)
		Me.xbtn_PwdShow.TabIndex = 13
		Me.xbtn_PwdShow.TabStop = false
		Me.xbtn_PwdShow.UseVisualStyleBackColor = true
		'
		'Button1
		'
		Me.xbtn_OK.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
		Me.xbtn_OK.Location = New System.Drawing.Point(12, 35)
		Me.xbtn_OK.Name = "Button1"
		Me.xbtn_OK.Size = New System.Drawing.Size(34, 23)
		Me.xbtn_OK.TabIndex = 14
		Me.xbtn_OK.Text = "Ok"
		Me.xbtn_OK.UseVisualStyleBackColor = false
		'
		'Button2
		'
		Me.xbtn_Canc.BackColor = System.Drawing.Color.Red
		Me.xbtn_Canc.Location = New System.Drawing.Point(113, 35)
		Me.xbtn_Canc.Name = "Button2"
		Me.xbtn_Canc.Size = New System.Drawing.Size(51, 23)
		Me.xbtn_Canc.TabIndex = 15
		Me.xbtn_Canc.Text = "Cancel"
		Me.xbtn_Canc.UseVisualStyleBackColor = false
		'
		'BDCSessionPassword
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(176, 65)
		Me.ControlBox = false
		Me.Controls.Add(Me.xbtn_Canc)
		Me.Controls.Add(Me.xbtn_OK)
		Me.Controls.Add(Me.xbtn_PwdShow)
		Me.Controls.Add(Me.xtbx_Pwrd)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "BDCSessionPassword"
		Me.ShowIcon = false
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "Password"
		Me.TopMost = true
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

	Friend WithEvents xtbx_Pwrd As Windows.Forms.TextBox
	Friend WithEvents xbtn_PwdShow As Windows.Forms.Button
	Friend WithEvents xbtn_OK As Windows.Forms.Button
	Friend WithEvents xbtn_Canc As Windows.Forms.Button

End Class
