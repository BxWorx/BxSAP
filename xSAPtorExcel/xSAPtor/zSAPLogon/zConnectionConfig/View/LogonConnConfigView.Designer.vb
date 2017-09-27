<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogonConnConfigView
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
		Me.xlvw_SapConfig = New System.Windows.Forms.ListView()
		Me.ParamID = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
		Me.ParamValue = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
		Me.SuspendLayout
		'
		'xlvw_SapConfig
		'
		Me.xlvw_SapConfig.AutoArrange = false
		Me.xlvw_SapConfig.CausesValidation = false
		Me.xlvw_SapConfig.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ParamID, Me.ParamValue})
		Me.xlvw_SapConfig.Dock = System.Windows.Forms.DockStyle.Fill
		Me.xlvw_SapConfig.GridLines = true
		Me.xlvw_SapConfig.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
		Me.xlvw_SapConfig.Location = New System.Drawing.Point(0, 0)
		Me.xlvw_SapConfig.MultiSelect = false
		Me.xlvw_SapConfig.Name = "xlvw_SapConfig"
		Me.xlvw_SapConfig.Size = New System.Drawing.Size(499, 304)
		Me.xlvw_SapConfig.Sorting = System.Windows.Forms.SortOrder.Ascending
		Me.xlvw_SapConfig.TabIndex = 0
		Me.xlvw_SapConfig.UseCompatibleStateImageBehavior = false
		Me.xlvw_SapConfig.View = System.Windows.Forms.View.Details
		'
		'ParamID
		'
		Me.ParamID.Text = "Parameter"
		Me.ParamID.Width = 187
		'
		'ParamValue
		'
		Me.ParamValue.Text = "Setting"
		Me.ParamValue.Width = 306
		'
		'LogonConnConfigView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CausesValidation = false
		Me.ClientSize = New System.Drawing.Size(499, 304)
		Me.ControlBox = false
		Me.Controls.Add(Me.xlvw_SapConfig)
		Me.Name = "LogonConnConfigView"
		Me.ShowInTaskbar = false
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.Text = "xSAPLogonDetails"
		Me.ResumeLayout(false)

End Sub

  Friend WithEvents xlvw_SapConfig As Windows.Forms.ListView
  Friend WithEvents ParamID As Windows.Forms.ColumnHeader
  Friend WithEvents ParamValue As Windows.Forms.ColumnHeader
End Class
