<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class xSAPtorNCOSplash
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
  Friend WithEvents xlbl_OSVersion As System.Windows.Forms.Label
  Friend WithEvents xlbl_NCOVersion As System.Windows.Forms.Label
  Friend WithEvents MainLayoutPanel As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents DetailsLayoutPanel As System.Windows.Forms.TableLayoutPanel

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(xSAPtorNCOSplash))
		Me.MainLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
		Me.DetailsLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
		Me.xlbl_SAPRelease = New System.Windows.Forms.Label()
		Me.xlbl_SAPKnlPatchLev = New System.Windows.Forms.Label()
		Me.xlbl_SAPKnlRelease = New System.Windows.Forms.Label()
		Me.xlbl_IPV4 = New System.Windows.Forms.Label()
		Me.xlbl_HostName = New System.Windows.Forms.Label()
		Me.xlbl_CLRVersion = New System.Windows.Forms.Label()
		Me.xlbl_OSVersion = New System.Windows.Forms.Label()
		Me.xlbl_NCOVersion = New System.Windows.Forms.Label()
		Me.ApplicationTitle = New System.Windows.Forms.Label()
		Me.MainLayoutPanel.SuspendLayout
		Me.DetailsLayoutPanel.SuspendLayout
		Me.SuspendLayout
		'
		'MainLayoutPanel
		'
		Me.MainLayoutPanel.BackgroundImage = Global.xSAPtorExcel.My.Resources.Resources.Bitmap_editor
		Me.MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.MainLayoutPanel.ColumnCount = 1
		Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
		Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
		Me.MainLayoutPanel.Controls.Add(Me.DetailsLayoutPanel, 0, 1)
		Me.MainLayoutPanel.Controls.Add(Me.ApplicationTitle, 0, 0)
		Me.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.MainLayoutPanel.Location = New System.Drawing.Point(0, 0)
		Me.MainLayoutPanel.Name = "MainLayoutPanel"
		Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36!))
		Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220!))
		Me.MainLayoutPanel.Size = New System.Drawing.Size(461, 332)
		Me.MainLayoutPanel.TabIndex = 0
		'
		'DetailsLayoutPanel
		'
		Me.DetailsLayoutPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.DetailsLayoutPanel.BackColor = System.Drawing.Color.Transparent
		Me.DetailsLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
		Me.DetailsLayoutPanel.ColumnCount = 1
		Me.DetailsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 461!))
		Me.DetailsLayoutPanel.Controls.Add(Me.xlbl_SAPRelease, 0, 7)
		Me.DetailsLayoutPanel.Controls.Add(Me.xlbl_SAPKnlPatchLev, 0, 6)
		Me.DetailsLayoutPanel.Controls.Add(Me.xlbl_SAPKnlRelease, 0, 5)
		Me.DetailsLayoutPanel.Controls.Add(Me.xlbl_IPV4, 0, 4)
		Me.DetailsLayoutPanel.Controls.Add(Me.xlbl_HostName, 0, 3)
		Me.DetailsLayoutPanel.Controls.Add(Me.xlbl_CLRVersion, 0, 2)
		Me.DetailsLayoutPanel.Controls.Add(Me.xlbl_OSVersion, 0, 0)
		Me.DetailsLayoutPanel.Controls.Add(Me.xlbl_NCOVersion, 0, 1)
		Me.DetailsLayoutPanel.Location = New System.Drawing.Point(3, 39)
		Me.DetailsLayoutPanel.Name = "DetailsLayoutPanel"
		Me.DetailsLayoutPanel.RowCount = 8
		Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.DetailsLayoutPanel.Size = New System.Drawing.Size(455, 290)
		Me.DetailsLayoutPanel.TabIndex = 1
		'
		'xlbl_SAPRelease
		'
		Me.xlbl_SAPRelease.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xlbl_SAPRelease.BackColor = System.Drawing.Color.Transparent
		Me.xlbl_SAPRelease.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xlbl_SAPRelease.Location = New System.Drawing.Point(6, 253)
		Me.xlbl_SAPRelease.Name = "xlbl_SAPRelease"
		Me.xlbl_SAPRelease.Size = New System.Drawing.Size(455, 34)
		Me.xlbl_SAPRelease.TabIndex = 8
		Me.xlbl_SAPRelease.Text = "SAP Release:         {0}"
		Me.xlbl_SAPRelease.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'xlbl_SAPKnlPatchLev
		'
		Me.xlbl_SAPKnlPatchLev.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xlbl_SAPKnlPatchLev.BackColor = System.Drawing.Color.Transparent
		Me.xlbl_SAPKnlPatchLev.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xlbl_SAPKnlPatchLev.Location = New System.Drawing.Point(6, 217)
		Me.xlbl_SAPKnlPatchLev.Name = "xlbl_SAPKnlPatchLev"
		Me.xlbl_SAPKnlPatchLev.Size = New System.Drawing.Size(455, 33)
		Me.xlbl_SAPKnlPatchLev.TabIndex = 7
		Me.xlbl_SAPKnlPatchLev.Text = "SAP Kernel Patch:    {0}"
		Me.xlbl_SAPKnlPatchLev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'xlbl_SAPKnlRelease
		'
		Me.xlbl_SAPKnlRelease.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xlbl_SAPKnlRelease.BackColor = System.Drawing.Color.Transparent
		Me.xlbl_SAPKnlRelease.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xlbl_SAPKnlRelease.Location = New System.Drawing.Point(6, 181)
		Me.xlbl_SAPKnlRelease.Name = "xlbl_SAPKnlRelease"
		Me.xlbl_SAPKnlRelease.Size = New System.Drawing.Size(455, 33)
		Me.xlbl_SAPKnlRelease.TabIndex = 6
		Me.xlbl_SAPKnlRelease.Text = "SAP Kernel Release:  {0}"
		Me.xlbl_SAPKnlRelease.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'xlbl_IPV4
		'
		Me.xlbl_IPV4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xlbl_IPV4.BackColor = System.Drawing.Color.Transparent
		Me.xlbl_IPV4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xlbl_IPV4.Location = New System.Drawing.Point(6, 145)
		Me.xlbl_IPV4.Name = "xlbl_IPV4"
		Me.xlbl_IPV4.Size = New System.Drawing.Size(455, 33)
		Me.xlbl_IPV4.TabIndex = 5
		Me.xlbl_IPV4.Text = "IPV-4:               {0}"
		Me.xlbl_IPV4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'xlbl_HostName
		'
		Me.xlbl_HostName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xlbl_HostName.BackColor = System.Drawing.Color.Transparent
		Me.xlbl_HostName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xlbl_HostName.Location = New System.Drawing.Point(6, 109)
		Me.xlbl_HostName.Name = "xlbl_HostName"
		Me.xlbl_HostName.Size = New System.Drawing.Size(455, 33)
		Me.xlbl_HostName.TabIndex = 4
		Me.xlbl_HostName.Text = "Host:                {0}"
		Me.xlbl_HostName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'xlbl_CLRVersion
		'
		Me.xlbl_CLRVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xlbl_CLRVersion.BackColor = System.Drawing.Color.Transparent
		Me.xlbl_CLRVersion.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xlbl_CLRVersion.Location = New System.Drawing.Point(6, 73)
		Me.xlbl_CLRVersion.Name = "xlbl_CLRVersion"
		Me.xlbl_CLRVersion.Size = New System.Drawing.Size(455, 33)
		Me.xlbl_CLRVersion.TabIndex = 3
		Me.xlbl_CLRVersion.Text = "CLR Version:         {0}"
		Me.xlbl_CLRVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'xlbl_OSVersion
		'
		Me.xlbl_OSVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xlbl_OSVersion.BackColor = System.Drawing.Color.Transparent
		Me.xlbl_OSVersion.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xlbl_OSVersion.Location = New System.Drawing.Point(6, 3)
		Me.xlbl_OSVersion.Name = "xlbl_OSVersion"
		Me.xlbl_OSVersion.Size = New System.Drawing.Size(455, 31)
		Me.xlbl_OSVersion.TabIndex = 1
		Me.xlbl_OSVersion.Text = "OS Version:         {0}"
		Me.xlbl_OSVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'xlbl_NCOVersion
		'
		Me.xlbl_NCOVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.xlbl_NCOVersion.BackColor = System.Drawing.Color.Transparent
		Me.xlbl_NCOVersion.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.xlbl_NCOVersion.Location = New System.Drawing.Point(6, 37)
		Me.xlbl_NCOVersion.Name = "xlbl_NCOVersion"
		Me.xlbl_NCOVersion.Size = New System.Drawing.Size(455, 33)
		Me.xlbl_NCOVersion.TabIndex = 2
		Me.xlbl_NCOVersion.Text = "NCO Version:         {0}"
		Me.xlbl_NCOVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'ApplicationTitle
		'
		Me.ApplicationTitle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.ApplicationTitle.AutoSize = true
		Me.ApplicationTitle.BackColor = System.Drawing.Color.Transparent
		Me.ApplicationTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.ApplicationTitle.Location = New System.Drawing.Point(3, 0)
		Me.ApplicationTitle.Name = "ApplicationTitle"
		Me.ApplicationTitle.Size = New System.Drawing.Size(455, 36)
		Me.ApplicationTitle.TabIndex = 0
		Me.ApplicationTitle.Text = "Application Title"
		Me.ApplicationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'xSAPtorNCOSplash
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(461, 332)
		Me.Controls.Add(Me.MainLayoutPanel)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "xSAPtorNCOSplash"
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.MainLayoutPanel.ResumeLayout(false)
		Me.MainLayoutPanel.PerformLayout
		Me.DetailsLayoutPanel.ResumeLayout(false)
		Me.ResumeLayout(false)

End Sub

  Friend WithEvents xlbl_CLRVersion As Windows.Forms.Label
  Friend WithEvents xlbl_SAPRelease As Windows.Forms.Label
  Friend WithEvents xlbl_SAPKnlPatchLev As Windows.Forms.Label
  Friend WithEvents xlbl_SAPKnlRelease As Windows.Forms.Label
  Friend WithEvents xlbl_IPV4 As Windows.Forms.Label
  Friend WithEvents xlbl_HostName As Windows.Forms.Label
End Class
