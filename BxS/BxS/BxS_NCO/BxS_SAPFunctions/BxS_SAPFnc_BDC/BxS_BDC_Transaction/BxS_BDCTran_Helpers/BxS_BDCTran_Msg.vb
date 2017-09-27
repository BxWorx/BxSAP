Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.BDCTransaction

	Friend Class BxS_BDCTran_Msg
								Implements iBxS_BDCTran_Msg

		#Region "Properties"

			Property TransactionCode  As String	Implements iBxS_BDCTran_Msg.TransactionCode
			Property ModuleName       As String	Implements iBxS_BDCTran_Msg.ModuleName
			Property ScreenNo         As String	Implements iBxS_BDCTran_Msg.ScreenNo
			Property MessageType      As String	Implements iBxS_BDCTran_Msg.MessageType
			Property LanguageID       As String	Implements iBxS_BDCTran_Msg.LanguageID
			Property MessageId        As String	Implements iBxS_BDCTran_Msg.MessageId
			Property MessageNo        As String	Implements iBxS_BDCTran_Msg.MessageNo
			Property MessageV1        As String	Implements iBxS_BDCTran_Msg.MessageV1
			Property MessageV2        As String	Implements iBxS_BDCTran_Msg.MessageV2
			Property MessageV3        As String	Implements iBxS_BDCTran_Msg.MessageV3
			Property MessageV4        As String	Implements iBxS_BDCTran_Msg.MessageV4
			Property Activity         As String	Implements iBxS_BDCTran_Msg.Activity
			Property FieldName        As String	Implements iBxS_BDCTran_Msg.FieldName
			Property LongText					As String	Implements iBxS_BDCTran_Msg.LongText

		#End Region

	End Class

End Namespace
