Imports System.Collections.Concurrent
Imports System.Threading
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Utilities
	Friend Class BxS_Consumer(Of T)
								Implements iBxS_Consumer(Of T)

		#Region "Definitions"

			Private co_Queue				As	BlockingCollection(Of T)
			Private co_CT						As	CancellationToken
			Private co_Progress			As	IProgress(Of Integer)
			Private co_Executioner	As	iBxS_Executioner(Of T)

			Private	cn_ProgInt			As	Integer

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			ReadOnly	Property	Completed()	As ConcurrentQueue(Of T)	Implements iBxS_Consumer(Of T).Completed
			ReadOnly	Property	InError()		As ConcurrentQueue(Of T)	Implements iBxS_Consumer(Of T).InError

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	Start()	Implements iBxS_Consumer(Of T).Start

				Dim ln_Cnt	As Integer	= 0
				Dim ln_Sub	As Integer	= 0
				Dim lb_Ret	As Boolean	= False

				Try

						For Each lo_Task In Me.co_Queue.GetConsumingEnumerable(Me.co_CT)

							lb_Ret	= Me.co_Executioner.Execute(lo_Task)
							'............................................
							If lb_Ret
								Me.Completed.Enqueue(lo_Task)
							Else
								Me.InError.Enqueue(lo_Task)
							End If
							'............................................
							ln_Cnt	+= 1
							ln_Sub	+= 1

							If ln_Sub >= Me.cn_ProgInt

								ln_Sub	= 0
								Me.co_Progress.Report(ln_Cnt)

							End If

						Next
						'..............................................
						If ln_Sub >= 0	Then	Me.co_Progress.Report(ln_Cnt)

					Catch ex As Exception

				End Try

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(						ByRef _queue							As BlockingCollection(Of T)	,
																ByRef _progress						As IProgress(Of Integer)		,
																ByRef _ct									As CancellationToken				,
																ByRef _executioner				As iBxS_Executioner(Of T)		,
											Optional	ByVal _progressinterval		As Integer	= 10							)

				Me.co_Queue				= _queue
				Me.co_CT					= _ct
				Me.co_Progress		= _progress
				Me.co_Executioner	= _executioner
				Me.cn_ProgInt			= _progressinterval
				'..................................................
				Me.Completed	= New ConcurrentQueue(Of T)
				Me.InError		= New ConcurrentQueue(Of T)

			End Sub

		#End Region

	End Class

End Namespace