﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On



<Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
 Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0"),  _
 Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
Partial Friend NotInheritable Class MySettings
    Inherits Global.System.Configuration.ApplicationSettingsBase
    
    Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
    
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
    
    Public Shared ReadOnly Property [Default]() As MySettings
        Get
            
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
            Return defaultInstance
        End Get
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property SAPSessionOptions_OptimizeUpload() As Boolean
        Get
            Return CType(Me("SAPSessionOptions_OptimizeUpload"),Boolean)
        End Get
        Set
            Me("SAPSessionOptions_OptimizeUpload") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("2")>  _
    Public Property SAPSessionOptions_ParallelProcesses() As Integer
        Get
            Return CType(Me("SAPSessionOptions_ParallelProcesses"),Integer)
        End Get
        Set
            Me("SAPSessionOptions_ParallelProcesses") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property SAPSessionOptions_SaveSelection() As Boolean
        Get
            Return CType(Me("SAPSessionOptions_SaveSelection"),Boolean)
        End Get
        Set
            Me("SAPSessionOptions_SaveSelection") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("*")>  _
    Public Property SAPSessionSelect_User() As String
        Get
            Return CType(Me("SAPSessionSelect_User"),String)
        End Get
        Set
            Me("SAPSessionSelect_User") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("*")>  _
    Public Property SAPSessionSelect_Name() As String
        Get
            Return CType(Me("SAPSessionSelect_Name"),String)
        End Get
        Set
            Me("SAPSessionSelect_Name") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("2010-01-01")>  _
    Public Property SAPSessionSelect_DateFrom() As Date
        Get
            Return CType(Me("SAPSessionSelect_DateFrom"),Date)
        End Get
        Set
            Me("SAPSessionSelect_DateFrom") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("2020-12-31")>  _
    Public Property SAPSessionSelect_DateTo() As Date
        Get
            Return CType(Me("SAPSessionSelect_DateTo"),Date)
        End Get
        Set
            Me("SAPSessionSelect_DateTo") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("2")>  _
    Public Property xSAPProcessOptions_Run_Parallel() As Integer
        Get
            Return CType(Me("xSAPProcessOptions_Run_Parallel"),Integer)
        End Get
        Set
            Me("xSAPProcessOptions_Run_Parallel") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
    Public Property xSAPProcessOptions_Run_MonAutoStart() As Boolean
        Get
            Return CType(Me("xSAPProcessOptions_Run_MonAutoStart"),Boolean)
        End Get
        Set
            Me("xSAPProcessOptions_Run_MonAutoStart") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("0.5")>  _
    Public Property xSAPProcessOptions_Run_MonRefreshRate() As Single
        Get
            Return CType(Me("xSAPProcessOptions_Run_MonRefreshRate"),Single)
        End Get
        Set
            Me("xSAPProcessOptions_Run_MonRefreshRate") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("5")>  _
    Public Property xSAPDestMonOptions_RefreshRate() As UInteger
        Get
            Return CType(Me("xSAPDestMonOptions_RefreshRate"),UInteger)
        End Get
        Set
            Me("xSAPDestMonOptions_RefreshRate") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("2")>  _
    Public Property xSAPProcessOptions_Run_NoParallel() As UInteger
        Get
            Return CType(Me("xSAPProcessOptions_Run_NoParallel"),UInteger)
        End Get
        Set
            Me("xSAPProcessOptions_Run_NoParallel") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property SAPLogon_FavouritesXML() As String
        Get
            Return CType(Me("SAPLogon_FavouritesXML"),String)
        End Get
        Set
            Me("SAPLogon_FavouritesXML") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property SAPLogon_ConnSetupXML() As String
        Get
            Return CType(Me("SAPLogon_ConnSetupXML"),String)
        End Get
        Set
            Me("SAPLogon_ConnSetupXML") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property SAPLogon_OptionsXML() As String
        Get
            Return CType(Me("SAPLogon_OptionsXML"),String)
        End Get
        Set
            Me("SAPLogon_OptionsXML") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property Notify_OptionsXML() As String
        Get
            Return CType(Me("Notify_OptionsXML"),String)
        End Get
        Set
            Me("Notify_OptionsXML") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property xSAPtor_DefaultsXML() As String
        Get
            Return CType(Me("xSAPtor_DefaultsXML"),String)
        End Get
        Set
            Me("xSAPtor_DefaultsXML") = value
        End Set
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public ReadOnly Property xSAPtor_App() As String
        Get
            Return CType(Me("xSAPtor_App"),String)
        End Get
    End Property
End Class

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.xSAPtorExcel.MySettings
            Get
                Return Global.xSAPtorExcel.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
