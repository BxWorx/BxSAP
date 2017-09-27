Imports System.Threading

Imports xSAPtorExcel.Main
Imports xSAPtorExcel.Main.Notification.Icon
Imports xSAPtorExcel.Services.Utilities.Generic
Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.Utilities.MsgHub

Imports BxS.API.Main
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Module BxSMainShared

	#Region	"Flags: Global"

			<Flags>
				Enum LogType	As	Short
					none	= 0
					info	= 1 << 0
					warn	= 1 << 1
					err		= 1 << 2
					syst	= 1 << 3
					trce	= 1 << 4
				End Enum

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region	"Singletons: Actual"

		Friend	so_CntlrNCO				As	Lazy(Of ixNCOController) _
																		= New Lazy(Of ixNCOController) _
																					(	Function()	xNCOController.NCOController(False),
																						LazyThreadSafetyMode.ExecutionAndPublication )

		Friend	so_CntlrMain			As	Lazy(Of	iBxSMainController) _
																		= New Lazy(Of iBxSMainController) _
																					(	Function()	BxSMainController.MainController(),
																						LazyThreadSafetyMode.ExecutionAndPublication )
		
		Friend	so_HlprGeneric		As	Lazy(Of iServicesGeneric) _
																		= New	Lazy(Of iServicesGeneric) _
																				(	Function()	ServicesGeneric.ServicesGeneric(),
																					LazyThreadSafetyMode.ExecutionAndPublication )

		Friend	so_HlprExcel			As	Lazy(Of	iExcelHelper) _
																		= New Lazy(Of iExcelHelper) _
																					(	Function()	ExcelHelper.ExcelHelper(),
																						LazyThreadSafetyMode.ExecutionAndPublication )

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region	"Singletons: Psuedo"

		Friend	so_NotifyDTO			As	Lazy(Of	iNotificationMessageDTO) _
																		=	New	Lazy(Of iNotificationMessageDTO) _
																				(	Function()	New NotificationMessageDTO(),
																					LazyThreadSafetyMode.ExecutionAndPublication )

		Friend	so_CntlrNotify		As	Lazy(Of iNotificationIconVM) _
																		= New	Lazy(Of iNotificationIconVM) _
																				(	Function()	New	NotificationIconVM(),
																					LazyThreadSafetyMode.ExecutionAndPublication )

		Friend	so_MsgHub					As	Lazy(Of iMsgHub) _
																		= New	Lazy(Of iMsgHub) _
																				(	Function()	New	MsgHub(),
																					LazyThreadSafetyMode.ExecutionAndPublication )

	#End Region

End Module
