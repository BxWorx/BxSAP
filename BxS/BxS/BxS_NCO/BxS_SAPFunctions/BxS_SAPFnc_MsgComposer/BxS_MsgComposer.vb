Imports System.Threading

Imports BxS.API.BDC
Imports BxS.API.SAPFunctions.MsgComposer
Imports BxS.API.SAPFunctions.BDCTransaction

Imports SAPNCO	= SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.MsgComposer
	Friend Class BxS_MsgComposer
								Implements iBxS_SAPMsgComposer

		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async	Function	GetMsgAsync(	ByVal MsgID	As String,
																						ByVal MsgNo	As String,
																						ByVal MsgV1	As String,
																						ByVal MsgV2	As String,
																						ByVal MsgV3	As String,
																						ByVal MsgV4	As String) As Task(Of String) _
																Implements iBxS_SAPMsgComposer.GetMsgAsync

				Dim lo_Exception	As SAPNCO.RfcAbapClassicException	= Nothing
				Dim lo_DTO				As iBxS_BDCTran_Msg								= New BxS_BDCTran_Msg
				Dim lc_MsgTxt			As String = ""
				Dim lo_CTS				As New CancellationTokenSource
				Try

						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.Lang	, lo_DTO.LanguageID	)

						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.ID		, lo_DTO.MessageId	)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.No		, lo_DTO.MessageNo	)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.V1		, lo_DTO.MessageV1	)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.V2		, lo_DTO.MessageV2	)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.V3		, lo_DTO.MessageV3	)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.V4		, lo_DTO.MessageV4	)

						Dim lb_Res	As Boolean	= False

						lb_Res = Await Task.Factory.StartNew(	Function()
																							Dim lb	As Boolean
																							Me.co_RfcFnc.Value.Invoke(Me.co_Profile.SAPrfcDestination)
																							Return LB
																						End Function,	lo_CTS.Token,
																						TaskCreationOptions.PreferFairness,
																						TaskScheduler.Default)

						lc_MsgTxt = Me.co_RfcFnc.Value.GetValue(Me.co_Profile.RfcFncParmIndex.Text).ToString

					Catch ex  As Exception _
						When _
							TypeOf ex Is SAPNCO.RfcAbapException                  OrElse    ' if a standard ABAP exception is raised during execution of function module RFC_PING 
							TypeOf ex Is SAPNCO.RfcAbapClassException             OrElse    ' if an ABAP class exception is raised during execution of function module RFC_PING 
							TypeOf ex Is SAPNCO.RfcInvalidStateException          OrElse    ' if an invalid state is encountered (such as using an invalid destination, for instance) 
							TypeOf ex Is SAPNCO.RfcResourceException              OrElse    ' if a required resource cannot be allocated (e.g., a client connection) due to resource restrictions 
							TypeOf ex Is SAPNCO.RfcCommunicationException         OrElse    ' if a communication error occurs 
							TypeOf ex Is SAPNCO.RfcCommunicationCanceledException

							lc_MsgTxt	= "ERROR"

						'lo_Exception	= CType(ex, RfcAbapClassicException)

							' TO-DO: Log error

				End Try

				Return lc_MsgTxt


			End Function

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async	Function	GetMsgAsync(ByVal	MsgDTO	As iBxS_BDCTran_Msg) As Task(Of String) _
																Implements iBxS_SAPMsgComposer.GetMsgAsync

				Dim lo_Exception	As SAPNCO.RfcAbapClassicException	= Nothing
				Dim lc_MsgTxt			As String = ""
				Dim lo_CTS				As New CancellationTokenSource
				Try

						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.Lang	, MsgDTO.LanguageID	)

						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.ID		, MsgDTO.MessageId	)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.No		, MsgDTO.MessageNo	)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.V1		, MsgDTO.MessageV1	)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.V2		, MsgDTO.MessageV2	)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.V3		, MsgDTO.MessageV3	)
						Me.co_rfcFnc.Value.SetValue(	Me.co_Profile.RfcFncParmIndex.V4		, MsgDTO.MessageV4	)

						Dim lb_Res	As Boolean	= False

						lb_Res = Await Task.Factory.StartNew(	Function()
																							Dim lb	As Boolean
																							Me.co_RfcFnc.Value.Invoke(Me.co_Profile.SAPrfcDestination)
																							Return LB
																						End Function,	lo_CTS.Token,
																						TaskCreationOptions.PreferFairness,
																						TaskScheduler.Default)

						lc_MsgTxt = Me.co_RfcFnc.Value.GetValue(Me.co_Profile.RfcFncParmIndex.Text).ToString

					Catch ex  As Exception _
						When _
							TypeOf ex Is SAPNCO.RfcAbapException                  OrElse    ' if a standard ABAP exception is raised during execution of function module RFC_PING 
							TypeOf ex Is SAPNCO.RfcAbapClassException             OrElse    ' if an ABAP class exception is raised during execution of function module RFC_PING 
							TypeOf ex Is SAPNCO.RfcInvalidStateException          OrElse    ' if an invalid state is encountered (such as using an invalid destination, for instance) 
							TypeOf ex Is SAPNCO.RfcResourceException              OrElse    ' if a required resource cannot be allocated (e.g., a client connection) due to resource restrictions 
							TypeOf ex Is SAPNCO.RfcCommunicationException         OrElse    ' if a communication error occurs 
							TypeOf ex Is SAPNCO.RfcCommunicationCanceledException

							lc_MsgTxt	= "ERROR"

						'lo_Exception	= CType(ex, RfcAbapClassicException)

							' TO-DO: Log error

				End Try

				Return lc_MsgTxt

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Definitions"

			Private	co_Profile	As iBxS_MsgComposer_Profile

			Private co_rfcFnc		As Lazy(Of SAPNCO.IRfcFunction) _
															= New Lazy(Of SAPNCO.IRfcFunction)(
																	Function()	Me.co_Profile.SAPrfcDestination.Repository.CreateFunction(co_Profile.SAPRfcFncName),
																	LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(ByVal profile	As iBxS_MsgComposer_Profile)

				Me.co_Profile	= profile

			End Sub

		#End Region

	End Class

End Namespace