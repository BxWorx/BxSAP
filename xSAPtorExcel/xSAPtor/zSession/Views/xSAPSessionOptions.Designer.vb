<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xSAPSessionOptions
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
		Me.xchb_OptimizeUpload = New System.Windows.Forms.CheckBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.xnud_NoOfProcesses = New System.Windows.Forms.NumericUpDown()
		Me.xchb_SaveSelection = New System.Windows.Forms.CheckBox()
		Me.GroupBox2.SuspendLayout
		Me.GroupBox1.SuspendLayout
		CType(Me.xnud_NoOfProcesses,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'GroupBox2
		'
		Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.GroupBox2.Controls.Add(Me.xchb_SaveSelection)
		Me.GroupBox2.Controls.Add(Me.xchb_OptimizeUpload)
		Me.GroupBox2.Font = New System.Drawing.Font("Courier New", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GroupBox2.Location = New System.Drawing.Point(7, 8)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(207, 76)
		Me.GroupBox2.TabIndex = 5
		Me.GroupBox2.TabStop = false
		Me.GroupBox2.Text = "General:"
		'
		'xchb_OptimizeUpload
		'
		Me.xchb_OptimizeUpload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_OptimizeUpload.AutoSize = true
		Me.xchb_OptimizeUpload.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_OptimizeUpload.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_OptimizeUpload.Location = New System.Drawing.Point(35, 23)
		Me.xchb_OptimizeUpload.Name = "xchb_OptimizeUpload"
		Me.xchb_OptimizeUpload.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_OptimizeUpload.Size = New System.Drawing.Size(166, 19)
		Me.xchb_OptimizeUpload.TabIndex = 1
		Me.xchb_OptimizeUpload.Text = "Optimize SAP Upload:"
		Me.xchb_OptimizeUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_OptimizeUpload.UseVisualStyleBackColor = true
		'
		'GroupBox1
		'
		Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.xnud_NoOfProcesses)
		Me.GroupBox1.Font = New System.Drawing.Font("Courier New", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GroupBox1.Location = New System.Drawing.Point(8, 90)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(206, 57)
		Me.GroupBox1.TabIndex = 6
		Me.GroupBox1.TabStop = false
		Me.GroupBox1.Text = "Processing:"
		'
		'Label1
		'
		Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Label1.CausesValidation = false
		Me.Label1.Location = New System.Drawing.Point(15, 26)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(135, 17)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Parallel Units:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'xnud_NoOfProcesses
		'
		Me.xnud_NoOfProcesses.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xnud_NoOfProcesses.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.xnud_NoOfProcesses.Location = New System.Drawing.Point(156, 27)
		Me.xnud_NoOfProcesses.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
		Me.xnud_NoOfProcesses.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.xnud_NoOfProcesses.Name = "xnud_NoOfProcesses"
		Me.xnud_NoOfProcesses.Size = New System.Drawing.Size(44, 18)
		Me.xnud_NoOfProcesses.TabIndex = 2
		Me.xnud_NoOfProcesses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.xnud_NoOfProcesses.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'xchb_SaveSelection
		'
		Me.xchb_SaveSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_SaveSelection.AutoSize = true
		Me.xchb_SaveSelection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_SaveSelection.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_SaveSelection.Location = New System.Drawing.Point(14, 48)
		Me.xchb_SaveSelection.Name = "xchb_SaveSelection"
		Me.xchb_SaveSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_SaveSelection.Size = New System.Drawing.Size(187, 19)
		Me.xchb_SaveSelection.TabIndex = 4
		Me.xchb_SaveSelection.Text = "Save Selection Criteria"
		Me.xchb_SaveSelection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_SaveSelection.UseVisualStyleBackColor = true
		'
		'xSAPSessionOptions
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(222, 155)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.GroupBox2)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.Name = "xSAPSessionOptions"
		Me.Padding = New System.Windows.Forms.Padding(5)
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "Session Options"
		Me.TopMost = true
		Me.GroupBox2.ResumeLayout(false)
		Me.GroupBox2.PerformLayout
		Me.GroupBox1.ResumeLayout(false)
		CType(Me.xnud_NoOfProcesses,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)

End Sub
  Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
  Friend WithEvents xchb_OptimizeUpload As Windows.Forms.CheckBox
  Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
  Friend WithEvents Label1 As Windows.Forms.Label
  Friend WithEvents xnud_NoOfProcesses As Windows.Forms.NumericUpDown
	Friend WithEvents xchb_SaveSelection As Windows.Forms.CheckBox
End Class
