Namespace Main.Process.Options

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xProcessOptionsView
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
		Me.xchb_SaveSelection = New System.Windows.Forms.CheckBox()
		Me.xchb_OptimizeUpload = New System.Windows.Forms.CheckBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.xnud_NoOfProcesses = New System.Windows.Forms.NumericUpDown()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.xchb_RunMonAutoOpen = New System.Windows.Forms.CheckBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.xnud_RunMonRate = New System.Windows.Forms.NumericUpDown()
		Me.GroupBox2.SuspendLayout
		Me.GroupBox1.SuspendLayout
		CType(Me.xnud_NoOfProcesses,System.ComponentModel.ISupportInitialize).BeginInit
		Me.GroupBox3.SuspendLayout
		CType(Me.xnud_RunMonRate,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'GroupBox2
		'
		Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.GroupBox2.Controls.Add(Me.xchb_SaveSelection)
		Me.GroupBox2.Controls.Add(Me.xchb_OptimizeUpload)
		Me.GroupBox2.Font = New System.Drawing.Font("Courier New", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GroupBox2.Location = New System.Drawing.Point(9, 184)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(238, 76)
		Me.GroupBox2.TabIndex = 5
		Me.GroupBox2.TabStop = false
		Me.GroupBox2.Text = "General:"
		Me.GroupBox2.Visible = false
		'
		'xchb_SaveSelection
		'
		Me.xchb_SaveSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_SaveSelection.AutoSize = true
		Me.xchb_SaveSelection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_SaveSelection.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_SaveSelection.Location = New System.Drawing.Point(21, 48)
		Me.xchb_SaveSelection.Name = "xchb_SaveSelection"
		Me.xchb_SaveSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_SaveSelection.Size = New System.Drawing.Size(211, 21)
		Me.xchb_SaveSelection.TabIndex = 5
		Me.xchb_SaveSelection.Text = "Save Selection Criteria"
		Me.xchb_SaveSelection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_SaveSelection.UseVisualStyleBackColor = true
		'
		'xchb_OptimizeUpload
		'
		Me.xchb_OptimizeUpload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_OptimizeUpload.AutoSize = true
		Me.xchb_OptimizeUpload.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_OptimizeUpload.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_OptimizeUpload.Location = New System.Drawing.Point(45, 23)
		Me.xchb_OptimizeUpload.Name = "xchb_OptimizeUpload"
		Me.xchb_OptimizeUpload.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_OptimizeUpload.Size = New System.Drawing.Size(187, 21)
		Me.xchb_OptimizeUpload.TabIndex = 4
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
		Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(237, 64)
		Me.GroupBox1.TabIndex = 6
		Me.GroupBox1.TabStop = false
		Me.GroupBox1.Text = "Processing:"
		'
		'Label1
		'
		Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Label1.CausesValidation = false
		Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label1.Location = New System.Drawing.Point(46, 26)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(135, 17)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Parallel Units:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'xnud_NoOfProcesses
		'
		Me.xnud_NoOfProcesses.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xnud_NoOfProcesses.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.xnud_NoOfProcesses.Location = New System.Drawing.Point(187, 27)
		Me.xnud_NoOfProcesses.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
		Me.xnud_NoOfProcesses.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.xnud_NoOfProcesses.Name = "xnud_NoOfProcesses"
		Me.xnud_NoOfProcesses.Size = New System.Drawing.Size(44, 18)
		Me.xnud_NoOfProcesses.TabIndex = 1
		Me.xnud_NoOfProcesses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.xnud_NoOfProcesses.Value = New Decimal(New Integer() {2, 0, 0, 0})
		'
		'GroupBox3
		'
		Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.GroupBox3.Controls.Add(Me.xchb_RunMonAutoOpen)
		Me.GroupBox3.Controls.Add(Me.Label2)
		Me.GroupBox3.Controls.Add(Me.xnud_RunMonRate)
		Me.GroupBox3.Font = New System.Drawing.Font("Courier New", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.GroupBox3.Location = New System.Drawing.Point(9, 78)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(237, 100)
		Me.GroupBox3.TabIndex = 7
		Me.GroupBox3.TabStop = false
		Me.GroupBox3.Text = "Run Monitor"
		'
		'xchb_RunMonAutoOpen
		'
		Me.xchb_RunMonAutoOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xchb_RunMonAutoOpen.AutoSize = true
		Me.xchb_RunMonAutoOpen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_RunMonAutoOpen.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xchb_RunMonAutoOpen.Location = New System.Drawing.Point(115, 61)
		Me.xchb_RunMonAutoOpen.Name = "xchb_RunMonAutoOpen"
		Me.xchb_RunMonAutoOpen.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.xchb_RunMonAutoOpen.Size = New System.Drawing.Size(115, 21)
		Me.xchb_RunMonAutoOpen.TabIndex = 3
		Me.xchb_RunMonAutoOpen.Text = "Auto start:"
		Me.xchb_RunMonAutoOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.xchb_RunMonAutoOpen.UseVisualStyleBackColor = true
		'
		'Label2
		'
		Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.Label2.CausesValidation = false
		Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Label2.Location = New System.Drawing.Point(18, 26)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(135, 17)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "Refresh Rate:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'xnud_RunMonRate
		'
		Me.xnud_RunMonRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xnud_RunMonRate.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.xnud_RunMonRate.DecimalPlaces = 1
		Me.xnud_RunMonRate.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
		Me.xnud_RunMonRate.Location = New System.Drawing.Point(159, 27)
		Me.xnud_RunMonRate.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
		Me.xnud_RunMonRate.Name = "xnud_RunMonRate"
		Me.xnud_RunMonRate.Size = New System.Drawing.Size(72, 18)
		Me.xnud_RunMonRate.TabIndex = 2
		Me.xnud_RunMonRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.xnud_RunMonRate.Value = New Decimal(New Integer() {5, 0, 0, 0})
		'
		'xProcessOptionsView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(253, 266)
		Me.Controls.Add(Me.GroupBox3)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.GroupBox2)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.Name = "xProcessOptionsView"
		Me.Padding = New System.Windows.Forms.Padding(5)
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "BDC Processing Options"
		Me.TopMost = true
		Me.GroupBox2.ResumeLayout(false)
		Me.GroupBox2.PerformLayout
		Me.GroupBox1.ResumeLayout(false)
		CType(Me.xnud_NoOfProcesses,System.ComponentModel.ISupportInitialize).EndInit
		Me.GroupBox3.ResumeLayout(false)
		Me.GroupBox3.PerformLayout
		CType(Me.xnud_RunMonRate,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)

End Sub
	Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
	Friend WithEvents xchb_OptimizeUpload As Windows.Forms.CheckBox
	Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
	Friend WithEvents Label1 As Windows.Forms.Label
	Friend WithEvents xnud_NoOfProcesses As Windows.Forms.NumericUpDown
	Friend WithEvents xchb_SaveSelection As Windows.Forms.CheckBox
		Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
		Friend WithEvents Label2 As Windows.Forms.Label
		Friend WithEvents xnud_RunMonRate As Windows.Forms.NumericUpDown
		Friend WithEvents xchb_RunMonAutoOpen As Windows.Forms.CheckBox
	End Class

End Namespace