<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xSAPtorUC
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
    Me.xBtn_Start = New System.Windows.Forms.Button()
    Me.xBtn_Cancel = New System.Windows.Forms.Button()
    Me.xPB_Progress = New System.Windows.Forms.ProgressBar()
    Me.SuspendLayout
    '
    'xBtn_Start
    '
    Me.xBtn_Start.Location = New System.Drawing.Point(23, 19)
    Me.xBtn_Start.Name = "xBtn_Start"
    Me.xBtn_Start.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.xBtn_Start.Size = New System.Drawing.Size(75, 23)
    Me.xBtn_Start.TabIndex = 0
    Me.xBtn_Start.TabStop = false
    Me.xBtn_Start.Text = "Start"
    Me.xBtn_Start.UseVisualStyleBackColor = true
    '
    'xBtn_Cancel
    '
    Me.xBtn_Cancel.Location = New System.Drawing.Point(23, 49)
    Me.xBtn_Cancel.Name = "xBtn_Cancel"
    Me.xBtn_Cancel.Size = New System.Drawing.Size(75, 23)
    Me.xBtn_Cancel.TabIndex = 1
    Me.xBtn_Cancel.Text = "Cancel"
    Me.xBtn_Cancel.UseVisualStyleBackColor = true
    '
    'xPB_Progress
    '
    Me.xPB_Progress.Location = New System.Drawing.Point(23, 79)
    Me.xPB_Progress.Name = "xPB_Progress"
    Me.xPB_Progress.Size = New System.Drawing.Size(212, 5)
    Me.xPB_Progress.TabIndex = 2
    '
    'xSAPtorUC
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.xPB_Progress)
    Me.Controls.Add(Me.xBtn_Cancel)
    Me.Controls.Add(Me.xBtn_Start)
    Me.Name = "xSAPtorUC"
    Me.Size = New System.Drawing.Size(520, 482)
    Me.ResumeLayout(false)

End Sub

  Friend WithEvents xBtn_Start As Windows.Forms.Button
  Friend WithEvents xBtn_Cancel As Windows.Forms.Button
  Friend WithEvents xPB_Progress As Windows.Forms.ProgressBar
End Class
