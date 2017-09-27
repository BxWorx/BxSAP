Imports SAPNCO = SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.BDCTransaction

	Friend Class BxS_BDCTran_Destination
								Implements iBxS_BDCTran_Destination

		#Region "Definitions"

			Private co_RfcDest					As SAPNCO.RfcCustomDestination

			Private co_rfcFncMetaData   As Lazy(Of SAPnco.RfcFunctionMetadata) _
								= New Lazy(Of SAPNCO.RfcFunctionMetadata)(
										Function()

											Try
													Return Me.co_RfcDest.Repository.GetFunctionMetadata(Me.cc_SAPFncName)
												Catch ex As Exception
													Return Nothing
											End Try
																																									
										End Function )

			Private co_rfcFncParmIndex  As Lazy(Of iBxS_BDCTran_ParmIndex) _
								= New Lazy(Of iBxS_BDCTran_ParmIndex)(
										Function()	
											Return Me.CreateParmIndex()
										End Function )

			Private cc_SAPFncName				As String

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"
			
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property SAPrfcDestination()	As SAPNCO.RfcCustomDestination _
																Implements	iBxS_BDCTran_Destination.SAPrfcDestination
				Get
					Return Me.co_RfcDest
				End Get

			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property RfcFncParmIndex(ByVal SAPrfcFncName	As String)	As iBxS_BDCTran_ParmIndex _
																Implements	iBxS_BDCTran_Destination.RfcFncParmIndex
				Get

					Me.cc_SAPFncName	= SAPrfcFncName
					Return Me.CreateParmIndex()

				End Get

			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(ByRef destination As SAPNCO.RfcCustomDestination)

				Me.co_RfcDest	= destination

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Privates"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function CreateParmIndex() As iBxS_BDCTran_ParmIndex

				Const cz_TCode				As String = "TCODE"
				Const cz_Skip1st			As String = "SKIP_SCREEN"
				Const cz_ModeDsp      As String = "MODE_VAL"
				Const cz_ModeUpd      As String = "UPDATE_VAL"
				Const cz_Subrc        As String = "SUBRC"
				Const cz_BDCData      As String = "USING_TAB"
				Const cz_SetGet       As String = "SPAGPA_TAB"
				Const cz_Msgs         As String = "MESS_TAB"

				Dim lo_ParamIndex			As iBxS_BDCTran_ParmIndex	= New BxS_BDCTran_ParmIndex

				lo_ParamIndex.TCode		= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_TCode)
				lo_ParamIndex.Skip1st	= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_Skip1st)
				lo_ParamIndex.ModeDsp	= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_ModeDsp)
				lo_ParamIndex.ModeUpd	= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_ModeUpd)
				lo_ParamIndex.Subrc		= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_Subrc)
				lo_ParamIndex.BDCData	= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_BDCData)
				lo_ParamIndex.SpaGpa	= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_SetGet)
				lo_ParamIndex.Msgs		= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_Msgs)

				Return lo_ParamIndex

			End Function

		#End Region

	End Class

End Namespace