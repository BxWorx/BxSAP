Imports xSAPtorExcel.Main.Notification.Icon
Imports xSAPtorExcel.Main.Process.Common
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Controller

	Friend Interface ixProcessControllerViaGUI

		Event	ev_Completed()


		#Region "Methods"

			Function Startup()				As Boolean

			Function SubmitRequest(ByVal ProcessRequest	As ixProcessRequestDTO)	As iNotificationMessageDTO

		#End Region

	End Interface

End Namespace