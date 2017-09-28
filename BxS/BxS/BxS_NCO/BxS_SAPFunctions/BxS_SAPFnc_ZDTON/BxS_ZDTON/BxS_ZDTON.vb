Imports System.Threading
Imports System.Collections.Concurrent

Imports BxS.API.SAPFunctions.ZDTON

Imports BxS.Utilities
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Friend Class BxS_ZDTON
								Implements iBxS_ZDTON

		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	SetNoOfParallelProcesses(	ByVal	No	As Integer)	Implements	iBxS_ZDTON.SetNoOfParallelProcesses
				
				Me.co_Profile.Value.NoofConsumers	= No

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	Reset()	Implements	iBxS_ZDTON.Reset
				
			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend  Function	GetDTO()	As iBxS_ZDTON_DTO _
													Implements iBxS_ZDTON.GetDTO

				Return	Me.co_CntlrSAPFnc.CreateZDTONDTO()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Async	Function	GetPostMessages(	ByVal _dto					As	iBxS_ZDTON_DTO		,
																								ByVal _canceltoken	As	CancellationToken		)		As Task(Of Boolean) _
																Implements iBxS_ZDTON.GetPostMessages

				Dim lb_Ret	As Boolean	= False
				Dim	lt_Msgs	As New List(Of iBxS_ZDTONMsgs_DTO)

				lt_Msgs	=	Await Task(Of List(Of iBxS_ZDTONMsgs_DTO)).Factory.StartNew(
												Function()	Me.co_RfcMsgs.Value.Invoke(_dto.User, _dto.SessionID),
												_canceltoken )

				_dto.Msgs.Clear

				If lt_Msgs.Count > 0

					For Each lo In lt_Msgs
						_dto.Msgs.Add(lo.Rowno, lo)
					Next

					lb_Ret	= True

				End If

				Return	lb_Ret				

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function PostDataAsync(ByVal _dto				As	iBxS_ZDTON_DTO				,
																					ByVal _progress		As  IProgress(Of Integer)	,
																					ByVal _ct					As	CancellationToken				)		As Task(Of Boolean) _
															Implements iBxS_ZDTON.PostDataAsync
		
				Dim ln_ConsCnt		As Integer	= 0
				Dim lb_Ret				As Boolean	= False
				Dim ln_ProgInt		As Integer	= 1
				Dim lo_PipeLine		As iBxS_PipeLine(Of iBxS_ZDTONData_DTO)
				Dim lo_ConsMaker	As ConsumerMaker(Of iBxS_ZDTONData_DTO)		= AddressOf	Me.ConsumerMaker
				'..................................................
				If _dto.Data.Count > cn_ProgPrc
					ln_ProgInt	= _dto.Data.Count \ cn_ProgPrc
				End If

				lo_PipeLine	=	New	BxS_PipeLine(Of iBxS_ZDTONData_DTO) _
														(lo_ConsMaker, _progress, ln_ProgInt, _ct, Me.co_Profile.Value.NoofConsumers)
				'..................................................
				Me.cn_ProgTot	= 0

				If Me.co_RfcHead.Value.Invoke(_dto)
					If Me.co_RfcColumns.Value.Invoke(_dto)

						Me.cn_ProgTot	= lo_PipeLine.Post(_dto.Data.Values.ToList())
						lo_PipeLine.ProducingCompleted()

						ln_ConsCnt	= Await lo_PipeLine.StartConsumers()
						_dto.Tally	= lo_PipeLine.Completed.Count

						If Me.co_RfcStats.Value.Invoke(_dto)
							lb_Ret	= True
						End If

					End If
				End If
				'..................................................
				Return	lb_Ret

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Definitions"

			Private	cn_ProgTot				As	Integer
			Private cn_ProgPrc				As	Integer
			'........................................................................
			Private co_CntlrSAPFnc		As	iBxS_SAPFnc_Controller
			'........................................................................
			Private	co_Profile				As	Lazy(Of iBxS_ZDTON_Profile)	_
																			= New	Lazy(Of iBxS_ZDTON_Profile)(
																					Function()	Me.co_CntlrSAPFnc.GetZDTONProfile(),
																					LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_RfcHead				As	Lazy(Of iBxS_ZDTONHeader)	_
																			= New	Lazy(Of iBxS_ZDTONHeader)(
																					Function()	Me.co_CntlrSAPFnc.GetZDTONHeader,
																					LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_RfcColumns			As	Lazy(Of iBxS_ZDTONColumns)	_
																			= New	Lazy(Of iBxS_ZDTONColumns)(
																					Function()	Me.co_CntlrSAPFnc.GetZDTONColumns,
																					LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_RfcStats				As	Lazy(Of iBxS_ZDTONStats)	_
																			= New	Lazy(Of iBxS_ZDTONStats)(
																					Function()	Me.co_CntlrSAPFnc.GetZDTONStats,
																					LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_RfcMsgs				As	Lazy(Of iBxS_ZDTONMsgs)	_
																			= New	Lazy(Of iBxS_ZDTONMsgs)(
																					Function()	Me.co_CntlrSAPFnc.GetZDTONMsgs,
																					LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(	ByVal	_controller	As iBxS_SAPFnc_Controller)

				Me.co_CntlrSAPFnc	= _controller
				'..................................................
				Me.cn_ProgPrc	= 10

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Privates"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Function	ConsumerMaker(	ByVal	_queue							As BlockingCollection(Of iBxS_ZDTONData_DTO)	,
																				ByVal _progress						As IProgress(Of Integer)											,
																				ByVal _ct									As CancellationToken													,
																				ByVal _progressinterval		As Integer															)	_
													As iBxS_Consumer(Of iBxS_ZDTONData_DTO)

				Dim lo_Execute		As	iBxS_Executioner(Of iBxS_ZDTONData_DTO)	= Me.co_CntlrSAPFnc.GetZDTONDataExec()
				Dim lo_Consumer		As	iBxS_Consumer(Of iBxS_ZDTONData_DTO)

				lo_Consumer	= New	BxS_Consumer(Of iBxS_ZDTONData_DTO) _
														(	_queue, _progress, _ct, lo_Execute, _progressinterval) 

				Return	lo_Consumer

			End Function

		#End Region

	End Class

End Namespace