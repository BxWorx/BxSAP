Imports System.Threading

Imports BxS.SAPFunctions.ZDTON
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.ZDTON

	Public Interface iBxS_ZDTON

		#Region "Methods"

			Function GetDTO()																															As iBxS_ZDTON_DTO
			Function PostDataAsync(	ByVal DTO								As	iBxS_ZDTON_DTO					,
															ByVal Progress					As  IProgress(Of Integer)	,
															ByVal CancelToken				As	CancellationToken				)		As Task(Of Boolean)
			Function GetPostMessages(	ByVal DTO						As iBxS_ZDTON_DTO			,
																ByVal CancelToken		As	CancellationToken		)				As Task(Of Boolean )
			'....................................................
			Sub	SetNoOfParallelProcesses(ByVal No	As Integer)
			Sub Reset()

		#End Region

	End Interface

End Namespace