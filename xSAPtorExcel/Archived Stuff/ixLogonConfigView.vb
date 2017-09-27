Imports System.Windows.Forms
Imports xSAPtorExcel.Main.SAPLogon
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Friend Interface ixLogonConfigView

	#Region "Properties"

		ReadOnly	Property IsDisposed()	As Boolean
							Property Visible()		As Boolean

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods"

		Sub EventHandler_SysIDChanged(ByVal sender As Object,
																	ByVal e      As xSAPLogonSysIDEventArgs)
		Sub RefreshList(ByVal SAPSystemID As String)
		Sub Show(ByVal i_Owner As IWin32Window)
		Sub HandleVisibility()

	#End Region

End Interface
