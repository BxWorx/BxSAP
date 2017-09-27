Imports System.Collections.Concurrent
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.BDC

	Public Interface iBxS_BDCTran_Tran

		#Region "Properties"
			
			ReadOnly	Property ExcelPathName	As String
			ReadOnly	Property ExcelWBName		As String
			ReadOnly	Property ExcelWSName		As String
								Property	ExcelRow			As UInteger
			ReadOnly	Property ExcelGUID			As String
								Property Skip1st				As Boolean
								Property SAPTCode				As String
								Property SAPSessionID		As String
								Property BDC_Data				As ConcurrentDictionary(Of Integer, iBxS_BDC_Entry)
								Property BDC_Msgs				As List(Of iBxS_BDCTran_Msg)
								Property Info_Thread		As UInteger
								Property Info_GUIDTran	As Guid
								Property info_GUIDCons	As Guid

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function ShallowCopy()	As iBxS_BDCTran_Tran

		#End Region

	End Interface

End Namespace