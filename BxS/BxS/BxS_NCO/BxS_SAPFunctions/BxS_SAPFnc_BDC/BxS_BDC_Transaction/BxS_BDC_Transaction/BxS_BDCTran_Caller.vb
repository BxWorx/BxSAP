Imports System.Threading

Imports SAPNCO = SAP.Middleware.Connector

Imports BxS.API.SAPFunctions.BDCTransaction
Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.BDCTransaction

	Friend Class BxS_BDCTran_Caller
								Implements iBxS_BDCTran_Caller

		#Region "Definitions"

			Private	co_Profile	As iBxS_BDCTran_Profile

			Private co_rfcFnc		As Lazy(Of SAPNCO.IRfcFunction) _
															= New Lazy(Of SAPNCO.IRfcFunction)(
																	Function()	Me.co_Profile.SAPrfcDestination.Repository.CreateFunction(co_Profile.SAPRfcFncName),
																	LazyThreadSafetyMode.ExecutionAndPublication )




			'Private Const cx_SAPFncName	As String = "ABAP4_CALL_TRANSACTION"

			'Private co_BxSDest				As iBxS_BDCTran_Destination

			'Private co_CTUParms				As iBxS_BDC_CTUParameters

			'Private co_rfcFnc         As Lazy(Of SAPNCO.IRfcFunction) _
			'															= New Lazy(Of SAPNCO.IRfcFunction)(
			'																	Function()	Me.co_BxSDest.SAPrfcDestination.Repository.CreateFunction(cx_SAPFncName),
			'																							LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_BDCDataTab			As	Lazy(Of SAPNCO.IRfcTable) _
																		= New Lazy(Of SAPNCO.IRfcTable)(
																				Function()	Me.co_rfcFnc.Value.GetTable(Me.co_Profile.RfcFncParmIndex.BDCData),
																										LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_BDCMsgsTab			As	Lazy(Of SAPNCO.IRfcTable) _
																		= New Lazy(Of SAPNCO.IRfcTable)(
																				Function()	Me.co_rfcFnc.Value.GetTable(Me.co_Profile.RfcFncParmIndex.Msgs),
																										LazyThreadSafetyMode.ExecutionAndPublication )
			
			Private co_BDCDataStr			As Lazy(Of SAPNCO.IRfcStructure) _
																		= New Lazy(Of SAPNCO.IRfcStructure)(
																				Function()	Me.co_BDCDataTab.Value.Metadata.LineType.CreateStructure(),
																										LazyThreadSafetyMode.ExecutionAndPublication )

			'Private co_ParmIndx   		As Lazy(Of iBxS_BDCTran_ParmIndex) _
			'															= New Lazy(Of iBxS_BDCTran_ParmIndex)(
			'																	Function()	Me.co_BxSDest.RfcFncParmIndex(cx_SAPFncName),
			'																							LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_Exception			As	SAPNCO.RfcAbapClassicException

			Private cb_OptionsLoaded	As Boolean
			Private cc_GUID						As Guid

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Property CTUParameters()	As iBxS_BDC_CTUParameters	Implements iBxS_BDCTran_Caller.CTUParameters

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub SetSAPGUIasVisible() _
									Implements iBxS_BDCTran_Caller.SetSAPGUIasVisible

				Me.co_Profile.SAPrfcDestination.UseSAPGui	= SAPNCO.RfcConfigParameters.RfcUseSAPGui.Use

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub SetGUIasHidden() _
									Implements iBxS_BDCTran_Caller.SetGUIasHidden

				Me.co_Profile.SAPrfcDestination.UseSAPGui	= SAPNCO.RfcConfigParameters.RfcUseSAPGui.Hidden

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub Invoke(ByRef BDCTask As iBxS_BDCTran_Tran) _
						Implements iBxS_BDCTran_Caller.Invoke

				BDCTask.BDC_Msgs.Clear()

				If BDCTask.BDC_Data.Count.Equals(0)

					Dim lo_Msg As iBxS_BDCTran_Msg = New BxS_BDCTran_Msg

					lo_Msg.MessageType	= "W"
					lo_Msg.MessageId		= "BxS"
					lo_Msg.MessageNo		= "100"
					lo_Msg.LongText			= "No BDC Data in task"

					BDCTask.BDC_Msgs.Add(lo_Msg)

				Else

					Me.Load_Options()
					'...............................................................
					Me.Load_Base(BDCTask)
					Me.Load_BDCData(BDCTask)
					'...............................................................
					Try

							Me.co_RfcFnc.Value.Invoke(Me.co_Profile.SAPrfcDestination)

						Catch ex  As Exception _
							When _
								TypeOf ex Is SAPNCO.RfcAbapException                  OrElse    ' if a standard ABAP exception is raised during execution of function module RFC_PING 
								TypeOf ex Is SAPNCO.RfcAbapClassException             OrElse    ' if an ABAP class exception is raised during execution of function module RFC_PING 
								TypeOf ex Is SAPNCO.RfcInvalidStateException          OrElse    ' if an invalid state is encountered (such as using an invalid destination, for instance) 
								TypeOf ex Is SAPNCO.RfcResourceException              OrElse    ' if a required resource cannot be allocated (e.g., a client connection) due to resource restrictions 
								TypeOf ex Is SAPNCO.RfcCommunicationException         OrElse    ' if a communication error occurs 
								TypeOf ex Is SAPNCO.RfcCommunicationCanceledException

							Me.co_Exception	= CType(ex, SAPNCO.RfcAbapClassicException)

							Me.LoadMsgOffException(BDCTask.BDC_Msgs)

					End Try

					Me.LoadMsgOfRfc(BDCTask.BDC_Msgs)

				End If
				'................................................................
				BDCTask.Info_Thread		= CUInt(Thread.CurrentThread.ManagedThreadId)
				BDCTask.Info_GUIDTran	= Me.cc_GUID

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Sub Reset() _
						Implements iBxS_BDCTran_Caller.Reset

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(ByVal profile	As iBxS_BDCTran_Profile)

				Me.co_Profile				= profile
				Me.cb_OptionsLoaded	= False
				Me.cc_GUID					= Guid.NewGuid()

				Me.SetGUIasHidden()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private Methods"

			Private Sub LoadMsgOffException(ByRef bdcMsg As List(Of iBxS_BDCTran_Msg))

				Dim lo_Msg	As iBxS_BDCTran_Msg	= New BxS_BDCTran_Msg

				lo_Msg.MessageType	= Me.co_Exception.AbapMessageType
				lo_Msg.MessageId		= Me.co_Exception.AbapMessageClass
				lo_Msg.MessageNo		= Me.co_Exception.AbapMessageNumber

				lo_Msg.MessageV1		= Me.co_Exception.AbapMessageParameters(0)
				lo_Msg.MessageV2		= Me.co_Exception.AbapMessageParameters(1)
				lo_Msg.MessageV3		= Me.co_Exception.AbapMessageParameters(2)
				lo_Msg.MessageV4		= Me.co_Exception.AbapMessageParameters(3)

				bdcMsg.Add(lo_Msg)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub LoadMsgOfRfc(ByRef bdcMsg As List(Of iBxS_BDCTran_Msg))

				For Each ls_Msg As SAPNCO.IRfcStructure In Me.co_BDCMsgsTab.Value

					Dim lo_Msg As iBxS_BDCTran_Msg = New BxS_BDCTran_Msg

					With lo_Msg

						.TransactionCode	= ls_Msg.GetValue("TCODE").ToString
						.ModuleName				= ls_Msg.GetValue("DYNAME").ToString
						.ScreenNo					= ls_Msg.GetValue("DYNUMB").ToString
						.MessageType			= ls_Msg.GetValue("MSGTYP").ToString
						.LanguageID				= ls_Msg.GetValue("MSGSPRA").ToString
						.MessageId				= ls_Msg.GetValue("MSGID").ToString
						.MessageNo				= ls_Msg.GetValue("MSGNR").ToString
						.MessageV1				= ls_Msg.GetValue("MSGV1").ToString
						.MessageV2				= ls_Msg.GetValue("MSGV2").ToString
						.MessageV3				= ls_Msg.GetValue("MSGV3").ToString
						.MessageV4				= ls_Msg.GetValue("MSGV4").ToString
						.Activity					= ls_Msg.GetValue("ENV").ToString
						.FieldName				= ls_Msg.GetValue("FLDNAME").ToString

					End With

					bdcMsg.Add(lo_Msg)

				Next

		End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Load_BDCData(ByRef BDCTask As iBxS_BDCTran_Tran)

				Me.co_BDCDataTab.Value.Clear()

				For Each lo_BDCIn As iBxS_BDC_Entry In BDCTask.BDC_Data.Values.ToList

					Dim lo_BDCOut	= CType(Me.co_BDCDataStr.Value.Clone(), SAPNCO.IRfcStructure)

					lo_BDCOut.SetValue("PROGRAM"  , lo_BDCIn.Program_Name   )
					lo_BDCOut.SetValue("DYNPRO"   , lo_BDCIn.Dynpro_Number  )
					lo_BDCOut.SetValue("DYNBEGIN" , lo_BDCIn.Dynpro_Begin   )
					lo_BDCOut.SetValue("FNAM"     , lo_BDCIn.Field_Name     )
					lo_BDCOut.SetValue("FVAL"     , lo_BDCIn.Field_Value    )

					Me.co_BDCDataTab.Value.Append(lo_BDCOut)

				Next
				
			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Load_Options()

				If Me.cb_OptionsLoaded	Then Return

				Me.co_rfcFnc.Value.SetValue(Me.co_Profile.RfcFncParmIndex.ModeDsp	, Me.CTUParameters.DisMode)
				Me.co_rfcFnc.Value.SetValue(Me.co_Profile.RfcFncParmIndex.ModeUpd	, Me.CTUParameters.UpdMode)

				Me.cb_OptionsLoaded	= True

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Load_Base(ByRef BDCTask As iBxS_BDCTran_Tran)

				Me.co_BDCMsgsTab.Value.Clear()

				Me.co_rfcFnc.Value.SetValue(Me.co_Profile.RfcFncParmIndex.TCode		, BDCTask.SAPTCode)
				Me.co_rfcFnc.Value.SetValue(Me.co_Profile.RfcFncParmIndex.Skip1st	, IIf(BDCTask.Skip1st, "X"c, " "c) )

			End Sub
		
		#End Region

	End Class

End Namespace