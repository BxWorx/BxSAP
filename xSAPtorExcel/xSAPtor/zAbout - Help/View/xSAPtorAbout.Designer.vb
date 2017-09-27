<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xSAPtorAbout
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
  Friend WithEvents ApplicationTitle As System.Windows.Forms.Label
  Friend WithEvents Version As System.Windows.Forms.Label
  Friend WithEvents Copyright As System.Windows.Forms.Label
  Friend WithEvents MainLayoutPanel As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents DetailsLayoutPanel As System.Windows.Forms.TableLayoutPanel

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(xSAPtorAbout))
		Me.MainLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
		Me.DetailsLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
		Me.AppDir = New System.Windows.Forms.Label()
		Me.Copyright = New System.Windows.Forms.Label()
		Me.Version = New System.Windows.Forms.Label()
		Me.ApplicationTitle = New System.Windows.Forms.Label()
		Me.MainLayoutPanel.SuspendLayout
		Me.DetailsLayoutPanel.SuspendLayout
		Me.SuspendLayout
		'
		'MainLayoutPanel
		'
		Me.MainLayoutPanel.BackgroundImage = CType(resources.GetObject("MainLayoutPanel.BackgroundImage"),System.Drawing.Image)
		Me.MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.MainLayoutPanel.ColumnCount = 2
		Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198!))
		Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145!))
		Me.MainLayoutPanel.Controls.Add(Me.DetailsLayoutPanel, 1, 1)
		Me.MainLayoutPanel.Controls.Add(Me.ApplicationTitle, 1, 0)
		Me.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.MainLayoutPanel.Location = New System.Drawing.Point(0, 0)
		Me.MainLayoutPanel.Name = "MainLayoutPanel"
		Me.MainLayoutPanel.RowCount = 1
		Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40!))
		Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100!))
		Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40!))
		Me.MainLayoutPanel.Size = New System.Drawing.Size(813, 402)
		Me.MainLayoutPanel.TabIndex = 0
		'
		'DetailsLayoutPanel
		'
		Me.DetailsLayoutPanel.BackColor = System.Drawing.Color.Transparent
		Me.DetailsLayoutPanel.ColumnCount = 1
		Me.DetailsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 609!))
		Me.DetailsLayoutPanel.Controls.Add(Me.AppDir, 0, 2)
		Me.DetailsLayoutPanel.Controls.Add(Me.Copyright, 0, 0)
		Me.DetailsLayoutPanel.Controls.Add(Me.Version, 0, 2)
		Me.DetailsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DetailsLayoutPanel.Location = New System.Drawing.Point(201, 43)
		Me.DetailsLayoutPanel.Name = "DetailsLayoutPanel"
		Me.DetailsLayoutPanel.RowCount = 3
		Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.DetailsLayoutPanel.Size = New System.Drawing.Size(609, 356)
		Me.DetailsLayoutPanel.TabIndex = 1
		'
		'AppDir
		'
		Me.AppDir.BackColor = System.Drawing.Color.Transparent
		Me.AppDir.Dock = System.Windows.Forms.DockStyle.Top
		Me.AppDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.AppDir.Location = New System.Drawing.Point(3, 40)
		Me.AppDir.Name = "AppDir"
		Me.AppDir.Size = New System.Drawing.Size(603, 20)
		Me.AppDir.TabIndex = 3
		Me.AppDir.Text = "Label1"
		'
		'Copyright
		'
		Me.Copyright.BackColor = System.Drawing.Color.Transparent
		Me.Copyright.Dock = System.Windows.Forms.DockStyle.Top
		Me.Copyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Copyright.Location = New System.Drawing.Point(3, 0)
		Me.Copyright.Name = "Copyright"
		Me.Copyright.Size = New System.Drawing.Size(603, 20)
		Me.Copyright.TabIndex = 2
		Me.Copyright.Text = "Copyright"
		'
		'Version
		'
		Me.Version.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Version.BackColor = System.Drawing.Color.Transparent
		Me.Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.Version.Location = New System.Drawing.Point(184, 20)
		Me.Version.Name = "Version"
		Me.Version.Size = New System.Drawing.Size(241, 20)
		Me.Version.TabIndex = 1
		Me.Version.Text = "Version {0}.{1:00}"
		'
		'ApplicationTitle
		'
		Me.ApplicationTitle.BackColor = System.Drawing.Color.Transparent
		Me.ApplicationTitle.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ApplicationTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ApplicationTitle.Location = New System.Drawing.Point(201, 0)
		Me.ApplicationTitle.Name = "ApplicationTitle"
		Me.ApplicationTitle.Size = New System.Drawing.Size(609, 40)
		Me.ApplicationTitle.TabIndex = 0
		Me.ApplicationTitle.Text = "Application Title"
		Me.ApplicationTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
		'
		'xSAPtorAbout
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(813, 402)
		Me.Controls.Add(Me.MainLayoutPanel)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "xSAPtorAbout"
		Me.ShowIcon = false
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.MainLayoutPanel.ResumeLayout(false)
		Me.DetailsLayoutPanel.ResumeLayout(false)
		Me.ResumeLayout(false)

End Sub

	Friend WithEvents AppDir As Windows.Forms.Label
End Class
