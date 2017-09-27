Imports System.Threading
Imports BxS.API.Destination
Imports	BxS.SAPFunctions.MsgComposer
Imports	BxS.SAPFunctions.BDCTransaction
Imports	BxS.SAPFunctions.ZDTON
Imports	BxS.API.SAPFunctions.MsgComposer
Imports	BxS.API.SAPFunctions.BDCTransaction
Imports	BxS.API.SAPFunctions.ZDTON
Imports BxS.Utilities
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace	SAPFunctions

	Friend	Class	BxS_SAPFnc_Controller
									Implements iBxS_SAPFnc_Controller

		#Region "Definitions"

			Private co_BxSDest							As iBxSDestination

			Private	co_MsgComposer_Profile	As	Lazy(Of iBxS_MsgComposer_Profile) _
																						= New Lazy(Of iBxS_MsgComposer_Profile)(
																								Function()	New	BxS_MsgComposer_Profile(Me.co_BxSDest),
																								LazyThreadSafetyMode.ExecutionAndPublication )

			Private	co_BDCTran_Profile			As	Lazy(Of iBxS_BDCTran_Profile) _
																						= New Lazy(Of iBxS_BDCTran_Profile)(
																								Function()	New	BxS_BDCTran_Profile(Me.co_BxSDest),
																								LazyThreadSafetyMode.ExecutionAndPublication )
			'............................................................................................
			Private	co_ZDTOHed_Profile			As	Lazy(Of iBxS_ZDTONHeader_Profile) _
																						= New	Lazy(Of iBxS_ZDTONHeader_Profile)(
																								Function()	New	BxS_ZDTONHeader_Profile(Me.co_BxSDest),
																								LazyThreadSafetyMode.ExecutionAndPublication )

			Private	co_ZDTOCol_Profile			As	Lazy(Of iBxS_ZDTONColumns_Profile) _
																						= New Lazy(Of iBxS_ZDTONColumns_Profile)(
																								Function()	New	BxS_ZDTONColumns_Profile(Me.co_BxSDest),
																								LazyThreadSafetyMode.ExecutionAndPublication )

			Private	co_ZDTODat_Profile			As	Lazy(Of iBxS_ZDTONData_Profile) _
																						= New Lazy(Of iBxS_ZDTONData_Profile)(
																								Function()	New	BxS_ZDTONData_Profile(Me.co_BxSDest),
																								LazyThreadSafetyMode.ExecutionAndPublication )

			Private	co_ZDTOSts_Profile			As	Lazy(Of iBxS_ZDTONStats_Profile) _
																						= New Lazy(Of iBxS_ZDTONStats_Profile)(
																								Function()	New	BxS_ZDTONStats_Profile(Me.co_BxSDest),
																								LazyThreadSafetyMode.ExecutionAndPublication )

			Private	co_ZDTOMsg_Profile			As	Lazy(Of iBxS_ZDTONMsgs_Profile) _
																						= New Lazy(Of iBxS_ZDTONMsgs_Profile)(
																								Function()	New	BxS_ZDTONMsgs_Profile(Me.co_BxSDest),
																								LazyThreadSafetyMode.ExecutionAndPublication )

			Private	co_ZDTOCtl_Profile			As	Lazy(Of iBxS_ZDTON_Profile) _
																						= New Lazy(Of iBxS_ZDTON_Profile)(
																								Function()	New BxS_ZDTON_Profile(Me.co_BxSDest),
																								LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend	Function	GetZDTONProfile() As iBxS_ZDTON_Profile _
													Implements iBxS_SAPFnc_Controller.GetZDTONProfile

				Return	Me.co_ZDTOCtl_Profile.Value

			End Function
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend	Function	GetZDTONHeader() As iBxS_ZDTONHeader _
													Implements iBxS_SAPFnc_Controller.GetZDTONHeader

				Return	New BxS_ZDTONHeader(Me.co_ZDTOHed_Profile.Value)

			End Function
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend	Function	GetZDTONColumns() As iBxS_ZDTONColumns _
													Implements iBxS_SAPFnc_Controller.GetZDTONColumns

				Return	New BxS_ZDTONColumns(Me.co_ZDTOCol_Profile.Value)

			End Function
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend	Function	GetZDTONData() As iBxS_ZDTONData _
													Implements iBxS_SAPFnc_Controller.GetZDTONData

				Return	New BxS_ZDTONData(Me.co_ZDTODat_Profile.Value)

			End Function
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend	Function	GetZDTONDataExec() As iBxS_Executioner(Of iBxS_ZDTONData_DTO) _
													Implements iBxS_SAPFnc_Controller.GetZDTONDataExec

				Return	New BxS_ZDTONData_Executioner(Me)

			End Function
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend	Function	GetZDTONStats() As iBxS_ZDTONStats _
													Implements iBxS_SAPFnc_Controller.GetZDTONStats

				Return	New BxS_ZDTONStats(Me.co_ZDTOSts_Profile.Value)

			End Function
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend	Function	GetZDTONMsgs() As iBxS_ZDTONMsgs _
													Implements iBxS_SAPFnc_Controller.GetZDTONMsgs

				Return	New BxS_ZDTONMsgs(Me.co_ZDTOMsg_Profile.Value)

			End Function
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend	Function	GetZDTON() As iBxS_ZDTON _
													Implements iBxS_SAPFnc_Controller.GetZDTON

				Return	New BxS_ZDTON(Me)

			End Function
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend	Function	CreateZDTONDTO() As iBxS_ZDTON_DTO _
													Implements iBxS_SAPFnc_Controller.CreateZDTONDTO

				Return	New BxS_ZDTON_DTO()

			End Function
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend	Function	GetBDCTransaction() As iBxS_BDCTran_Caller _
													Implements iBxS_SAPFnc_Controller.GetBDCTransaction

				Return New BxS_BDCTran_Caller(Me.co_BDCTran_Profile.Value)

			End Function
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			Friend	Function	GetMsgCompser() As iBxS_SAPMsgComposer _
													Implements iBxS_SAPFnc_Controller.GetMsgCompser

				Return New BxS_MsgComposer(Me.co_MsgComposer_Profile.Value)

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(ByVal destination As iBxSDestination)

				Me.co_BxSDest	= destination

			End Sub

		#End Region

	End Class

End Namespace