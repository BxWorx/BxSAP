Partial Class xSAPtorRB
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(xSAPtorRB))
		Dim RibbonDropDownItemImpl1 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
		Dim RibbonDropDownItemImpl2 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
		Dim RibbonDropDownItemImpl3 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
		Dim RibbonDropDownItemImpl4 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
		Dim RibbonDropDownItemImpl5 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
		Me.xTab_SAPtor = Me.Factory.CreateRibbonTab
		Me.xGrp_SAP = Me.Factory.CreateRibbonGroup
		Me.xbtn_SAPSelect = Me.Factory.CreateRibbonButton
		Me.xddn_SAPFavourites = Me.Factory.CreateRibbonDropDown
		Me.xbtn_SAPFavDel = Me.Factory.CreateRibbonButton
		Me.xbtn_SAPFavClr = Me.Factory.CreateRibbonButton
		Me.xbtn_SAPConnect = Me.Factory.CreateRibbonButton
		Me.xgrp_Session = Me.Factory.CreateRibbonGroup
		Me.xbtn_SessionSelect = Me.Factory.CreateRibbonButton
		Me.xbtn_SessionOptions = Me.Factory.CreateRibbonButton
		Me.xbtn_SessionConfigure = Me.Factory.CreateRibbonButton
		Me.xbtn_SessionBlank = Me.Factory.CreateRibbonButton
		Me.xgrp_Process = Me.Factory.CreateRibbonGroup
		Me.xbtn_ProcessSelection = Me.Factory.CreateRibbonButton
		Me.xbtn_BDCOptions = Me.Factory.CreateRibbonButton
		Me.xbtn_BDCTest = Me.Factory.CreateRibbonButton
		Me.xbtn_ProcessRunner = Me.Factory.CreateRibbonButton
		Me.xgrp_Services = Me.Factory.CreateRibbonGroup
		Me.xgal_Services = Me.Factory.CreateRibbonGallery
		Me.xgal_About = Me.Factory.CreateRibbonGallery
		Me.xGrp_AboutHelp = Me.Factory.CreateRibbonGroup
		Me.xbtn_SAPGUIOptions = Me.Factory.CreateRibbonButton
		Me.xbtn_SAPConnectStatus = Me.Factory.CreateRibbonButton
		Me.xbtn_ServicesOptions = Me.Factory.CreateRibbonButton
		Me.xTab_SAPtor.SuspendLayout
		Me.xGrp_SAP.SuspendLayout
		Me.xgrp_Session.SuspendLayout
		Me.xgrp_Process.SuspendLayout
		Me.xgrp_Services.SuspendLayout
		Me.xGrp_AboutHelp.SuspendLayout
		Me.SuspendLayout
		'
		'xTab_SAPtor
		'
		Me.xTab_SAPtor.Groups.Add(Me.xGrp_SAP)
		Me.xTab_SAPtor.Groups.Add(Me.xgrp_Session)
		Me.xTab_SAPtor.Groups.Add(Me.xgrp_Process)
		Me.xTab_SAPtor.Groups.Add(Me.xgrp_Services)
		Me.xTab_SAPtor.Groups.Add(Me.xGrp_AboutHelp)
		resources.ApplyResources(Me.xTab_SAPtor, "xTab_SAPtor")
		Me.xTab_SAPtor.Name = "xTab_SAPtor"
		'
		'xGrp_SAP
		'
		Me.xGrp_SAP.Items.Add(Me.xbtn_SAPSelect)
		Me.xGrp_SAP.Items.Add(Me.xddn_SAPFavourites)
		Me.xGrp_SAP.Items.Add(Me.xbtn_SAPConnect)
		resources.ApplyResources(Me.xGrp_SAP, "xGrp_SAP")
		Me.xGrp_SAP.Name = "xGrp_SAP"
		'
		'xbtn_SAPSelect
		'
		Me.xbtn_SAPSelect.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
		Me.xbtn_SAPSelect.Image = Global.xSAPtorExcel.My.Resources.Resources._2000px_SAP_2011_logo_svg
		resources.ApplyResources(Me.xbtn_SAPSelect, "xbtn_SAPSelect")
		Me.xbtn_SAPSelect.Name = "xbtn_SAPSelect"
		Me.xbtn_SAPSelect.ShowImage = true
		'
		'xddn_SAPFavourites
		'
		Me.xddn_SAPFavourites.Buttons.Add(Me.xbtn_SAPFavDel)
		Me.xddn_SAPFavourites.Buttons.Add(Me.xbtn_SAPFavClr)
		resources.ApplyResources(Me.xddn_SAPFavourites, "xddn_SAPFavourites")
		Me.xddn_SAPFavourites.Name = "xddn_SAPFavourites"
		Me.xddn_SAPFavourites.ShowImage = true
		Me.xddn_SAPFavourites.ShowLabel = false
		'
		'xbtn_SAPFavDel
		'
		Me.xbtn_SAPFavDel.Image = Global.xSAPtorExcel.My.Resources.Resources.Delete
		resources.ApplyResources(Me.xbtn_SAPFavDel, "xbtn_SAPFavDel")
		Me.xbtn_SAPFavDel.Name = "xbtn_SAPFavDel"
		Me.xbtn_SAPFavDel.ShowImage = true
		Me.xbtn_SAPFavDel.ShowLabel = false
		'
		'xbtn_SAPFavClr
		'
		Me.xbtn_SAPFavClr.Image = Global.xSAPtorExcel.My.Resources.Resources.Revert
		resources.ApplyResources(Me.xbtn_SAPFavClr, "xbtn_SAPFavClr")
		Me.xbtn_SAPFavClr.Name = "xbtn_SAPFavClr"
		Me.xbtn_SAPFavClr.ShowImage = true
		Me.xbtn_SAPFavClr.ShowLabel = false
		'
		'xbtn_SAPConnect
		'
		Me.xbtn_SAPConnect.Image = Global.xSAPtorExcel.My.Resources.Resources.disconnect_icon
		resources.ApplyResources(Me.xbtn_SAPConnect, "xbtn_SAPConnect")
		Me.xbtn_SAPConnect.Name = "xbtn_SAPConnect"
		Me.xbtn_SAPConnect.ShowImage = true
		'
		'xgrp_Session
		'
		Me.xgrp_Session.Items.Add(Me.xbtn_SessionSelect)
		Me.xgrp_Session.Items.Add(Me.xbtn_SessionOptions)
		Me.xgrp_Session.Items.Add(Me.xbtn_SessionConfigure)
		Me.xgrp_Session.Items.Add(Me.xbtn_SessionBlank)
		resources.ApplyResources(Me.xgrp_Session, "xgrp_Session")
		Me.xgrp_Session.Name = "xgrp_Session"
		'
		'xbtn_SessionSelect
		'
		Me.xbtn_SessionSelect.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
		Me.xbtn_SessionSelect.Image = Global.xSAPtorExcel.My.Resources.Resources.Pantone
		resources.ApplyResources(Me.xbtn_SessionSelect, "xbtn_SessionSelect")
		Me.xbtn_SessionSelect.Name = "xbtn_SessionSelect"
		Me.xbtn_SessionSelect.ShowImage = true
		'
		'xbtn_SessionOptions
		'
		Me.xbtn_SessionOptions.Image = Global.xSAPtorExcel.My.Resources.Resources.Bitmap_editor
		resources.ApplyResources(Me.xbtn_SessionOptions, "xbtn_SessionOptions")
		Me.xbtn_SessionOptions.Name = "xbtn_SessionOptions"
		Me.xbtn_SessionOptions.ShowImage = true
		'
		'xbtn_SessionConfigure
		'
		Me.xbtn_SessionConfigure.Image = Global.xSAPtorExcel.My.Resources.Resources.Registry
		resources.ApplyResources(Me.xbtn_SessionConfigure, "xbtn_SessionConfigure")
		Me.xbtn_SessionConfigure.Name = "xbtn_SessionConfigure"
		Me.xbtn_SessionConfigure.ShowImage = true
		'
		'xbtn_SessionBlank
		'
		Me.xbtn_SessionBlank.Image = Global.xSAPtorExcel.My.Resources.Resources.Add
		resources.ApplyResources(Me.xbtn_SessionBlank, "xbtn_SessionBlank")
		Me.xbtn_SessionBlank.Name = "xbtn_SessionBlank"
		Me.xbtn_SessionBlank.ShowImage = true
		'
		'xgrp_Process
		'
		Me.xgrp_Process.Items.Add(Me.xbtn_ProcessSelection)
		Me.xgrp_Process.Items.Add(Me.xbtn_BDCOptions)
		Me.xgrp_Process.Items.Add(Me.xbtn_BDCTest)
		Me.xgrp_Process.Items.Add(Me.xbtn_ProcessRunner)
		resources.ApplyResources(Me.xgrp_Process, "xgrp_Process")
		Me.xgrp_Process.Name = "xgrp_Process"
		'
		'xbtn_ProcessSelection
		'
		Me.xbtn_ProcessSelection.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
		Me.xbtn_ProcessSelection.Image = Global.xSAPtorExcel.My.Resources.Resources.Synchronize
		resources.ApplyResources(Me.xbtn_ProcessSelection, "xbtn_ProcessSelection")
		Me.xbtn_ProcessSelection.Name = "xbtn_ProcessSelection"
		Me.xbtn_ProcessSelection.ShowImage = true
		'
		'xbtn_BDCOptions
		'
		Me.xbtn_BDCOptions.Image = Global.xSAPtorExcel.My.Resources.Resources.Bitmap_editor
		resources.ApplyResources(Me.xbtn_BDCOptions, "xbtn_BDCOptions")
		Me.xbtn_BDCOptions.Name = "xbtn_BDCOptions"
		Me.xbtn_BDCOptions.ShowImage = true
		'
		'xbtn_BDCTest
		'
		Me.xbtn_BDCTest.Image = Global.xSAPtorExcel.My.Resources.Resources.Target1
		resources.ApplyResources(Me.xbtn_BDCTest, "xbtn_BDCTest")
		Me.xbtn_BDCTest.Name = "xbtn_BDCTest"
		Me.xbtn_BDCTest.ShowImage = true
		'
		'xbtn_ProcessRunner
		'
		Me.xbtn_ProcessRunner.Image = Global.xSAPtorExcel.My.Resources.Resources.Pinion
		resources.ApplyResources(Me.xbtn_ProcessRunner, "xbtn_ProcessRunner")
		Me.xbtn_ProcessRunner.Name = "xbtn_ProcessRunner"
		Me.xbtn_ProcessRunner.ShowImage = true
		'
		'xgrp_Services
		'
		Me.xgrp_Services.Items.Add(Me.xgal_Services)
		Me.xgrp_Services.Items.Add(Me.xgal_About)
		resources.ApplyResources(Me.xgrp_Services, "xgrp_Services")
		Me.xgrp_Services.Name = "xgrp_Services"
		'
		'xgal_Services
		'
		Me.xgal_Services.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
		Me.xgal_Services.Image = Global.xSAPtorExcel.My.Resources.Resources.Spiral
		Me.xgal_Services.ItemImageSize = New System.Drawing.Size(16, 16)
		RibbonDropDownItemImpl1.Image = Global.xSAPtorExcel.My.Resources.Resources.Test_line
		resources.ApplyResources(RibbonDropDownItemImpl1, "RibbonDropDownItemImpl1")
		RibbonDropDownItemImpl1.Tag = "xtag_SrvConMon"
		RibbonDropDownItemImpl2.Image = Global.xSAPtorExcel.My.Resources.Resources.Show
		resources.ApplyResources(RibbonDropDownItemImpl2, "RibbonDropDownItemImpl2")
		RibbonDropDownItemImpl2.Tag = "xtag_SrvLog"
		RibbonDropDownItemImpl3.Image = Global.xSAPtorExcel.My.Resources.Resources.Bitmap_editor
		resources.ApplyResources(RibbonDropDownItemImpl3, "RibbonDropDownItemImpl3")
		RibbonDropDownItemImpl3.Tag = "xtag_SrvOpt"
		Me.xgal_Services.Items.Add(RibbonDropDownItemImpl1)
		Me.xgal_Services.Items.Add(RibbonDropDownItemImpl2)
		Me.xgal_Services.Items.Add(RibbonDropDownItemImpl3)
		resources.ApplyResources(Me.xgal_Services, "xgal_Services")
		Me.xgal_Services.Name = "xgal_Services"
		Me.xgal_Services.ShowImage = true
		'
		'xgal_About
		'
		Me.xgal_About.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
		Me.xgal_About.Image = Global.xSAPtorExcel.My.Resources.Resources.Select_gpadient
		RibbonDropDownItemImpl4.Image = Global.xSAPtorExcel.My.Resources.Resources.Info
		resources.ApplyResources(RibbonDropDownItemImpl4, "RibbonDropDownItemImpl4")
		RibbonDropDownItemImpl4.Tag = "xtag_SAP"
		RibbonDropDownItemImpl5.Image = Global.xSAPtorExcel.My.Resources.Resources.Info
		resources.ApplyResources(RibbonDropDownItemImpl5, "RibbonDropDownItemImpl5")
		RibbonDropDownItemImpl5.Tag = "xtag_NCO"
		Me.xgal_About.Items.Add(RibbonDropDownItemImpl4)
		Me.xgal_About.Items.Add(RibbonDropDownItemImpl5)
		resources.ApplyResources(Me.xgal_About, "xgal_About")
		Me.xgal_About.Name = "xgal_About"
		Me.xgal_About.ShowImage = true
		'
		'xGrp_AboutHelp
		'
		Me.xGrp_AboutHelp.Items.Add(Me.xbtn_SAPGUIOptions)
		Me.xGrp_AboutHelp.Items.Add(Me.xbtn_SAPConnectStatus)
		Me.xGrp_AboutHelp.Items.Add(Me.xbtn_ServicesOptions)
		resources.ApplyResources(Me.xGrp_AboutHelp, "xGrp_AboutHelp")
		Me.xGrp_AboutHelp.Name = "xGrp_AboutHelp"
		'
		'xbtn_SAPGUIOptions
		'
		resources.ApplyResources(Me.xbtn_SAPGUIOptions, "xbtn_SAPGUIOptions")
		Me.xbtn_SAPGUIOptions.Image = Global.xSAPtorExcel.My.Resources.Resources.Bitmap_editor
		Me.xbtn_SAPGUIOptions.Name = "xbtn_SAPGUIOptions"
		Me.xbtn_SAPGUIOptions.ShowImage = true
		'
		'xbtn_SAPConnectStatus
		'
		Me.xbtn_SAPConnectStatus.Image = Global.xSAPtorExcel.My.Resources.Resources.No
		resources.ApplyResources(Me.xbtn_SAPConnectStatus, "xbtn_SAPConnectStatus")
		Me.xbtn_SAPConnectStatus.Name = "xbtn_SAPConnectStatus"
		Me.xbtn_SAPConnectStatus.ShowImage = true
		Me.xbtn_SAPConnectStatus.ShowLabel = false
		'
		'xbtn_ServicesOptions
		'
		resources.ApplyResources(Me.xbtn_ServicesOptions, "xbtn_ServicesOptions")
		Me.xbtn_ServicesOptions.Image = Global.xSAPtorExcel.My.Resources.Resources.Bitmap_editor
		Me.xbtn_ServicesOptions.Name = "xbtn_ServicesOptions"
		Me.xbtn_ServicesOptions.ShowImage = true
		'
		'xSAPtorRB
		'
		Me.Name = "xSAPtorRB"
		Me.RibbonType = "Microsoft.Excel.Workbook"
		Me.Tabs.Add(Me.xTab_SAPtor)
		Me.xTab_SAPtor.ResumeLayout(false)
		Me.xTab_SAPtor.PerformLayout
		Me.xGrp_SAP.ResumeLayout(false)
		Me.xGrp_SAP.PerformLayout
		Me.xgrp_Session.ResumeLayout(false)
		Me.xgrp_Session.PerformLayout
		Me.xgrp_Process.ResumeLayout(false)
		Me.xgrp_Process.PerformLayout
		Me.xgrp_Services.ResumeLayout(false)
		Me.xgrp_Services.PerformLayout
		Me.xGrp_AboutHelp.ResumeLayout(false)
		Me.xGrp_AboutHelp.PerformLayout
		Me.ResumeLayout(false)

End Sub

	Friend WithEvents xTab_SAPtor As Microsoft.Office.Tools.Ribbon.RibbonTab
	Friend WithEvents xGrp_SAP As Microsoft.Office.Tools.Ribbon.RibbonGroup
	Friend WithEvents xgrp_Session As Microsoft.Office.Tools.Ribbon.RibbonGroup
	Friend WithEvents xGrp_AboutHelp As Microsoft.Office.Tools.Ribbon.RibbonGroup
	Friend WithEvents xgal_About As Microsoft.Office.Tools.Ribbon.RibbonGallery
	Friend WithEvents xbtn_SessionOptions As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xbtn_SAPGUIOptions As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xgrp_Process As Microsoft.Office.Tools.Ribbon.RibbonGroup
	Friend WithEvents xbtn_BDCOptions As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xgrp_Services As Microsoft.Office.Tools.Ribbon.RibbonGroup
	Friend WithEvents xgal_Services As Microsoft.Office.Tools.Ribbon.RibbonGallery
	Friend WithEvents xbtn_SessionSelect As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xbtn_SessionConfigure As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xbtn_ProcessSelection As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xbtn_BDCTest As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xbtn_ServicesOptions As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xbtn_ProcessRunner As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xbtn_SAPConnectStatus As Microsoft.Office.Tools.Ribbon.RibbonButton
	Private WithEvents xbtn_SAPSelect As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xddn_SAPFavourites As Microsoft.Office.Tools.Ribbon.RibbonDropDown
	Friend WithEvents xbtn_SAPFavDel As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xbtn_SAPFavClr As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xbtn_SAPConnect As Microsoft.Office.Tools.Ribbon.RibbonButton
	Friend WithEvents xbtn_SessionBlank As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

	<System.Diagnostics.DebuggerNonUserCode()> _
	Friend ReadOnly Property xSAPtorRB() As xSAPtorRB
		Get
			Return Me.GetRibbon(Of xSAPtorRB)()
		End Get
	End Property
End Class
