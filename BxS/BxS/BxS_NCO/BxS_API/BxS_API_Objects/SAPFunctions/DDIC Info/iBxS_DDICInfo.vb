Imports System.Threading

Imports BxS.SAPFunctions.DDIC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.ZDTON

	Public Interface iBxS_DDICInfo

		#Region "Methods"

			Function GetDTO()																															As iBxS_DDICInfo_DTO
			Function GetDDICInfo(	ByVal DTO						As iBxS_ZDTON_DTO			,
																ByVal CancelToken		As	CancellationToken		)				As Task(Of Boolean )
			'....................................................
			Sub Reset()

		#End Region

	End Interface

End Namespace