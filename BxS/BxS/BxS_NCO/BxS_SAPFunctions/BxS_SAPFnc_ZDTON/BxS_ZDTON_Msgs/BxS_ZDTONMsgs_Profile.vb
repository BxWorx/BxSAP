Imports System.Threading
Imports SAPNCO = SAP.Middleware.Connector
Imports BxS.API.Destination
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Friend Class BxS_ZDTONMsgs_Profile
								Implements iBxS_ZDTONMsgs_Profile

		#Region "Definitions"

			Private Const cx_SAPFncName	As String	=	"ZZ_DTO_SESSION_RETURN"
			'............................................................
			Private co_RfcDest					As	iBxSDestination

			Private co_rfcFncMetaData		As	Lazy(Of SAPNCO.RfcFunctionMetadata) _
																				= New Lazy(Of SAPNCO.RfcFunctionMetadata)(
																						Function()

																							Try
																									Return Me.co_RfcDest.RfcDestination.Repository.GetFunctionMetadata(cx_SAPFncName)
																								Catch ex As Exception
																									Return Nothing
																							End Try
																																									
																						End Function,
																						LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_rfcFncParmIndex  As	Lazy(Of iBxS_ZDTONMsgs_ParmIndex) _
																				= New Lazy(Of iBxS_ZDTONMsgs_ParmIndex)(
																						Function()	Me.CreateParmIndex(),
																						LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_MsgDTO						As	Lazy(Of iBxS_ZDTONMsgs_DTO) _
																				= New Lazy(Of iBxS_ZDTONMsgs_DTO)(
																						Function()	New BxS_ZDTONMsgs_DTO(),
																					LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"
			
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	SAPRfcFncName	As String _
																		Implements	iBxS_ZDTONMsgs_Profile.SAPRfcFncName
				Get
					Return cx_SAPFncName
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property SAPrfcDestination()	As SAPNCO.RfcCustomDestination _
																Implements	iBxS_ZDTONMsgs_Profile.SAPrfcDestination
				Get
					Return Me.co_RfcDest.RfcDestination
				End Get

			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property rfcDestination()	As iBxSDestination _
																Implements	iBxS_ZDTONMsgs_Profile.rfcDestination
				Get
					Return Me.co_RfcDest
				End Get

			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property RfcFncParmIndex()	As iBxS_ZDTONMsgs_ParmIndex _
																Implements	iBxS_ZDTONMsgs_Profile.RfcFncParmIndex
				Get
					Return Me.co_rfcFncParmIndex.Value
				End Get

			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function CreateDTO()	As iBxS_ZDTONMsgs_DTO _
												Implements	iBxS_ZDTONMsgs_Profile.CreateDTO

				Return	Me.co_MsgDTO.Value.ShallowCopy()

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(ByRef destination As iBxSDestination)

				Me.co_RfcDest	= destination

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Privates"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function CreateParmIndex() As iBxS_ZDTONMsgs_ParmIndex

				Const cz_User			As String = "USERID"
				Const cz_ID				As String = "GROUPID"
				Const cz_Status		As String = "STATUS"
				Const cz_Msgs			As String = "DATALINE"

				Dim lo_ParamIndex	As iBxS_ZDTONMsgs_ParmIndex	= New BxS_ZDTONMsgs_ParmIndex

				lo_ParamIndex.User			= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_User)
				lo_ParamIndex.ID				= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_ID)
				lo_ParamIndex.Status		= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_Status)
				lo_ParamIndex.MsgTable	= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_Msgs)

				Return lo_ParamIndex

			End Function

		#End Region

	End Class

End Namespace