Imports System.Threading
Imports SAPNCO = SAP.Middleware.Connector
Imports BxS.API.Destination
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.MsgComposer

	Friend Class BxS_MsgComposer_Profile
								Implements iBxS_MsgComposer_Profile

		#Region "Definitions"

			Private Const cx_SAPFncName	As String	=	"RPY_MESSAGE_COMPOSE"
			'............................................................
			Private co_RfcDest					As iBxSDestination

			Private co_rfcFncMetaData   As Lazy(Of SAPnco.RfcFunctionMetadata) _
																			= New Lazy(Of SAPNCO.RfcFunctionMetadata)(
																					Function()

																						Try
																								Return Me.co_RfcDest.RfcDestination.Repository.GetFunctionMetadata(cx_SAPFncName)
																							Catch ex As Exception
																								Return Nothing
																						End Try
																																									
																					End Function,
																					LazyThreadSafetyMode.ExecutionAndPublication )


			Private co_rfcFncParmIndex  As Lazy(Of iBxS_MsgComposer_ParmIndex) _
																			= New Lazy(Of iBxS_MsgComposer_ParmIndex)(
																					Function()	Me.CreateParmIndex(),
																					LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"
			
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	SAPRfcFncName	As String _
																		Implements	iBxS_MsgComposer_Profile.SAPRfcFncName
				Get
					Return cx_SAPFncName
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property SAPrfcDestination()	As SAPNCO.RfcCustomDestination _
																Implements	iBxS_MsgComposer_Profile.SAPrfcDestination
				Get
					Return Me.co_RfcDest.RfcDestination
				End Get

			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property rfcDestination()	As iBxSDestination _
																Implements	iBxS_MsgComposer_Profile.rfcDestination
				Get
					Return Me.co_RfcDest
				End Get

			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property RfcFncParmIndex()	As iBxS_MsgComposer_ParmIndex _
																Implements	iBxS_MsgComposer_Profile.RfcFncParmIndex
				Get
					Return Me.co_rfcFncParmIndex.Value
				End Get

			End Property

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
			Private Function CreateParmIndex() As iBxS_MsgComposer_ParmIndex

				Const cz_Lang	As String = "LANGUAGE"
				Const cz_ID		As String = "MESSAGE_ID"
				Const cz_No		As String = "MESSAGE_NUMBER"
				Const cz_V1		As String = "MESSAGE_VAR1"
				Const cz_V2		As String = "MESSAGE_VAR2"
				Const cz_V3		As String = "MESSAGE_VAR3"
				Const cz_V4		As String = "MESSAGE_VAR4"
				Const cz_Text	As String = "MESSAGE_TEXT"
				Const cz_LTxt	As String = "LONGTEXT"

				Dim lo_ParamIndex	As iBxS_MsgComposer_ParmIndex	= New BxS_MsgComposer_ParmIndex

				lo_ParamIndex.Lang	= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_Lang)
				lo_ParamIndex.ID		= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_ID)
				lo_ParamIndex.No		= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_No)
				lo_ParamIndex.V1		= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_V1)
				lo_ParamIndex.V2		= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_V2)
				lo_ParamIndex.V3		= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_V3)
				lo_ParamIndex.V4		= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_V4)
				lo_ParamIndex.Text	= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_Text)
				lo_ParamIndex.LTxt	= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_LTxt)

				Return lo_ParamIndex

			End Function

		#End Region

	End Class

End Namespace