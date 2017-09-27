Partial Class BxSToolbar
	Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

	<System.Diagnostics.DebuggerNonUserCode()> _
	Public Sub New(ByVal container As System.ComponentModel.IContainer)
		MyClass.New()

		'Required for Windows.Forms Class Composition Designer support
		If (container IsNot Nothing) Then
			container.Add(Me)
		End If

	End Sub

	<System.Diagnostics.DebuggerNonUserCode()> _
	Public Sub New()
		MyBase.New(Globals.Factory.GetRibbonFactory())

		'This call is required by the Component Designer.
		InitializeComponent()

	End Sub

	'Component overrides dispose to clean up the component list.
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

	'Required by the Component Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Component Designer
	'It can be modified using the Component Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BxSToolbar))
		Me.Tab1 = Me.Factory.CreateRibbonTab
		Me.Group1 = Me.Factory.CreateRibbonGroup
		Me.Button1 = Me.Factory.CreateRibbonButton
		Me.Tab1.SuspendLayout
		Me.Group1.SuspendLayout
		Me.SuspendLayout
		'
		'Tab1
		'
		Me.Tab1.Groups.Add(Me.Group1)
		resources.ApplyResources(Me.Tab1, "Tab1")
		Me.Tab1.Name = "Tab1"
		'
		'Group1
		'
		Me.Group1.Items.Add(Me.Button1)
		resources.ApplyResources(Me.Group1, "Group1")
		Me.Group1.Name = "Group1"
		'
		'Button1
		'
		resources.ApplyResources(Me.Button1, "Button1")
		Me.Button1.Name = "Button1"
		'
		'BxSToolbar
		'
		Me.Name = "BxSToolbar"
		Me.RibbonType = "Microsoft.Excel.Workbook"
		Me.Tabs.Add(Me.Tab1)
		Me.Tab1.ResumeLayout(false)
		Me.Tab1.PerformLayout
		Me.Group1.ResumeLayout(false)
		Me.Group1.PerformLayout
		Me.ResumeLayout(false)

End Sub

	Friend WithEvents Tab1 As Microsoft.Office.Tools.Ribbon.RibbonTab
	Friend WithEvents Group1 As Microsoft.Office.Tools.Ribbon.RibbonGroup
	Friend WithEvents Button1 As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

	<System.Diagnostics.DebuggerNonUserCode()> _
	Friend ReadOnly Property BxSToolbar() As BxSToolbar
		Get
			Return Me.GetRibbon(Of BxSToolbar)()
		End Get
	End Property
End Class
