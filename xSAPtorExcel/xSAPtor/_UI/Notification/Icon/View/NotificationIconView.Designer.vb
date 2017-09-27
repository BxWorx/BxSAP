Namespace Main.Notification.Icon

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotificationIconView
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
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotificationIconView))
		Me.xnot_Handler = New System.Windows.Forms.NotifyIcon(Me.components)
		Me.xcms_Main = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.SuspendLayout
		'
		'xnot_Handler
		'
		Me.xnot_Handler.ContextMenuStrip = Me.xcms_Main
		Me.xnot_Handler.Icon = CType(resources.GetObject("xnot_Handler.Icon"),System.Drawing.Icon)
		Me.xnot_Handler.Text = "xSAPtor Notifications"
		Me.xnot_Handler.Visible = true
		'
		'xcms_Main
		'
		Me.xcms_Main.Name = "ContextMenuStrip1"
		Me.xcms_Main.Size = New System.Drawing.Size(153, 26)
		'
		'xNotificationIconView
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(197, 79)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "xNotificationIconView"
		Me.Opacity = 0R
		Me.ShowInTaskbar = false
		Me.Text = "Notification"
		Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
		Me.ResumeLayout(false)

End Sub

	Friend WithEvents xnot_Handler	As Windows.Forms.NotifyIcon
	Friend WithEvents xcms_Main			As Windows.Forms.ContextMenuStrip

End Class

End Namespace