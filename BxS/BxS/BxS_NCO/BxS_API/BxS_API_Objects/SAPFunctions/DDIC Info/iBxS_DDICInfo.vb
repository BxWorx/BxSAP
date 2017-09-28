Imports System.Threading
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.DDIC

	Public Interface IBxS_DDICInfo

		#Region "Methods"

			Function BuildDTO()	As IBxS_DDICInfo_DTO

			Function GetDDICInfo(	ByVal DTO						As	IBxS_DDICInfo_DTO	,
														ByVal CancelToken		As	CancellationToken		)		As Task(Of Boolean )
			'....................................................
			Sub Reset()

		#End Region

	End Interface

End Namespace