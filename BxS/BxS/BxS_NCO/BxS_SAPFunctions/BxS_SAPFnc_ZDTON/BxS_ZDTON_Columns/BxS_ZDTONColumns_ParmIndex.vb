'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Friend Class BxS_ZDTONColumns_ParmIndex
								Implements iBxS_ZDTONColumns_ParmIndex

		#Region "Properties"

			Property User			As Integer	Implements	iBxS_ZDTONColumns_ParmIndex.User
			Property ID				As Integer	Implements	iBxS_ZDTONColumns_ParmIndex.ID
			Property Columns	As Integer	Implements	iBxS_ZDTONColumns_ParmIndex.Columns
			Property Status		As Integer	Implements	iBxS_ZDTONColumns_ParmIndex.Status

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function ShallowCopy()	As iBxS_ZDTONColumns_ParmIndex _
												Implements iBxS_ZDTONColumns_ParmIndex.ShallowCopy

				Return CType( Me.MemberwiseClone(), iBxS_ZDTONColumns_ParmIndex )

			End Function

		#End Region

	End Class

End Namespace
