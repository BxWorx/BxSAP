'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.BDCTransaction

	Friend Class BxS_BDCTran_ParmIndex
								Implements iBxS_BDCTran_ParmIndex

		#Region "Properties"

			Friend	Property TCode    As Integer	Implements iBxS_BDCTran_ParmIndex.TCode
			Friend	Property Skip1st  As Integer	Implements iBxS_BDCTran_ParmIndex.Skip1st
			Friend	Property ModeDsp	As Integer	Implements iBxS_BDCTran_ParmIndex.ModeDsp
			Friend	Property ModeUpd	As Integer	Implements iBxS_BDCTran_ParmIndex.ModeUpd
			Friend	Property Subrc		As Integer	Implements iBxS_BDCTran_ParmIndex.Subrc
			Friend	Property BDCData  As Integer	Implements iBxS_BDCTran_ParmIndex.BDCData
			Friend	Property Msgs			As Integer	Implements iBxS_BDCTran_ParmIndex.Msgs
			Friend	Property SpaGpa		As Integer	Implements iBxS_BDCTran_ParmIndex.SpaGpa

			Friend	Property Options  As Integer	Implements iBxS_BDCTran_ParmIndex.Options

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function Clone()	As iBxS_BDCTran_ParmIndex _
												Implements iBxS_BDCTran_ParmIndex.Clone

				Return CType( Me.MemberwiseClone(), iBxS_BDCTran_ParmIndex )

			End Function

		#End Region

	End Class

End Namespace
