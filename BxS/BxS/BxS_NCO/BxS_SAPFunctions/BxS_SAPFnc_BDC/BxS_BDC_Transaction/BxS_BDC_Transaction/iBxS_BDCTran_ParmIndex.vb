'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.BDCTransaction

	Friend Interface iBxS_BDCTran_ParmIndex

		#Region "Properties"

			Property TCode    As Integer
			Property Skip1st  As Integer
			Property ModeDsp	As Integer
			Property ModeUpd	As Integer
			Property Subrc		As Integer
			Property BDCData  As Integer
			Property Msgs			As Integer
			Property SpaGpa		As Integer

			Property Options  As Integer

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Function Clone()	As iBxS_BDCTran_ParmIndex

		#End Region

	End Interface

End Namespace
