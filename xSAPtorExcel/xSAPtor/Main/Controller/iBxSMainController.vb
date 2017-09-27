Imports System.Threading.Tasks

Imports xSAPtorExcel.UI
Imports xSAPtorExcel.Main.About
'Imports xSAPtorExcel.Main.Config
Imports xSAPtorExcel.Main.Notification.Icon
Imports xSAPtorExcel.Main.SAPLogon
Imports xSAPtorExcel.Main.Session
Imports xSAPtorExcel.Main.Services
Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.Services.Utilities.Generic
Imports xSAPtorExcel.Main.Process.Controller

Imports BxS.API.Main
Imports BxS.API.Destination
Imports BxS.API.About
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main

	Friend Interface iBxSMainController

		#Region "Methods: Get Controllers"

			Function GetAboutController()					As ixSAPAboutController
			Function GetSAPLogonController()			As ixSAPLogonController
			Function GetSessionController()				As ixSessionController
			Function GetServicesController()			As ixServicesController
			'Function GetConfigController()				As ixSAPConfigController
			Function GetNCOController()						As ixNCOController
			Function GetNotificationController()	As iNotificationIconVM
			Function GetProcessController()				As iBxSProcessController

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: General"

			Function GetSAPFavouritesVM()		As iSAPFavoritesVM
			Function GetServicesGeneric()		As iServicesGeneric
			Function GetExcelHelper()				As iExcelHelper

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Events"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			ReadOnly	Property	NCOAboutInfo()						As iBxSNCOAboutInfo
			ReadOnly	Property	ActiveDestination()				As iBxSDestination
			ReadOnly	Property	ActiveDestinationID()			As String
			ReadOnly	Property	ActiveUserID()						As String
			ReadOnly	Property	DestinationSelected()			As Boolean

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Destination"

			Function	IsConnectedAsync()																					As Task(of Boolean)
			Function	SetActiveDestination(ByRef logonConfig As iLogonSystemDTO)	As Boolean
			Function	GetDestMonitorDataAsync()																		As Task(Of List(Of iBxSDestMonitorDTO))

		#End Region

	End Interface

End Namespace