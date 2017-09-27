Imports System.Collections.Concurrent
Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.BDCTransaction

	Friend Class BxS_BDCTran_Tran
								Implements iBxS_BDCTran_Tran

		#Region "Properties"

			Friend	ReadOnly	Property	ExcelPathName			As String										Implements iBxS_BDCTran_Tran.ExcelPathName
			Friend	ReadOnly	Property	ExcelWBName				As String										Implements iBxS_BDCTran_Tran.ExcelWBName
			Friend	ReadOnly	Property	ExcelWSName				As String										Implements iBxS_BDCTran_Tran.ExcelWSName
			Friend	ReadOnly	Property	ExcelGUID				As String											Implements iBxS_BDCTran_Tran.ExcelGUID

			Friend						Property	ExcelRow				As UInteger										Implements iBxS_BDCTran_Tran.ExcelRow
			Friend						Property	SAPTCode				As String											Implements iBxS_BDCTran_Tran.SAPTCode
			Friend						Property	SAPSessionID		As String											Implements iBxS_BDCTran_Tran.SAPSessionID
			Friend						Property	Skip1st					As Boolean										Implements iBxS_BDCTran_Tran.Skip1st
			Friend						Property	BDC_Data				As ConcurrentDictionary(Of	Integer, iBxS_BDC_Entry)	Implements iBxS_BDCTran_Tran.BDC_Data
			Friend						Property	BDC_Msgs				As List(Of iBxS_BDCTran_Msg)													Implements iBxS_BDCTran_Tran.BDC_Msgs
			Friend						Property	Info_Thread			As UInteger										Implements iBxS_BDCTran_Tran.Info_Thread
			Friend						Property	Info_GUIDTran		As Guid												Implements iBxS_BDCTran_Tran.Info_GUIDTran
			Friend						Property	Info_GUIDCons		As Guid    										Implements iBxS_BDCTran_Tran.info_GUIDCons

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Friend Function ShallowCopy() _
												As iBxS_BDCTran_Tran _
													Implements iBxS_BDCTran_Tran.ShallowCopy

				Dim lo_Tran	= DirectCast(Me.MemberwiseClone(), iBxS_BDCTran_Tran)

				Me.BDC_Data	= New ConcurrentDictionary(Of Integer, iBxS_BDC_Entry)
				Me.BDC_Msgs	= New List(Of iBxS_BDCTran_Msg)

				Return lo_Tran

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Construction"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New()

				Me.BDC_Data	= New ConcurrentDictionary(Of Integer, iBxS_BDC_Entry)
				Me.BDC_Msgs	= New List(Of iBxS_BDCTran_Msg)

				Me.Skip1st	= False
				Me.SAPTCode	= "Not Assigned"

			End Sub

		#End Region

	End Class

End Namespace