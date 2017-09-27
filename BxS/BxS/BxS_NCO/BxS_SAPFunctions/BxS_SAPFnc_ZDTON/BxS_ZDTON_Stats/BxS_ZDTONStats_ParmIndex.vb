'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Friend Class BxS_ZDTONStats_ParmIndex
								Implements iBxS_ZDTONStats_ParmIndex

		#Region "Properties"

			Property User			As Integer	Implements iBxS_ZDTONStats_ParmIndex.User
			Property ID				As Integer	Implements iBxS_ZDTONStats_ParmIndex.ID
			Property RowTally	As Integer	Implements iBxS_ZDTONStats_ParmIndex.RowTally
			Property SAPTcode	As Integer	Implements iBxS_ZDTONStats_ParmIndex.SAPTcode
			Property Status		As Integer	Implements iBxS_ZDTONStats_ParmIndex.Status

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function ShallowCopy()	As iBxS_ZDTONStats_ParmIndex _
												Implements iBxS_ZDTONStats_ParmIndex.ShallowCopy

				Return CType( Me.MemberwiseClone(), iBxS_ZDTONStats_ParmIndex )

			End Function

		#End Region

	End Class

End Namespace
