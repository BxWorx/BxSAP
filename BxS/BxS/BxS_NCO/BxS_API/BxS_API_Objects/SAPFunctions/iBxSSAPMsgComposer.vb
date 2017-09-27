Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.MsgComposer

	Public Interface iBxS_SAPMsgComposer

		#Region "Properties"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function GetMsgAsync(	ByVal	MsgDTO	As iBxS_BDCTran_Msg)	As Task(Of String)

			Function GetMsgAsync(	ByVal MsgID	As String,
														ByVal MsgNo	As String,
														ByVal MsgV1	As String,
														ByVal MsgV2	As String,
														ByVal MsgV3	As String,
														ByVal MsgV4	As String)							As Task(Of String)

		#End Region

	End Interface

End Namespace