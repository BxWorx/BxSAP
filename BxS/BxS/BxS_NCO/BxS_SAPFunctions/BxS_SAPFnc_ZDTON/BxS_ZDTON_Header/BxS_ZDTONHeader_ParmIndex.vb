'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Friend Class BxS_ZDTONHeader_ParmIndex
								Implements iBxS_ZDTONHeader_ParmIndex

		#Region "Properties"

			Property User		As Integer	Implements	iBxS_ZDTONHeader_ParmIndex.User
			Property ID			As Integer	Implements	iBxS_ZDTONHeader_ParmIndex.ID
			Property Status	As Integer	Implements	iBxS_ZDTONHeader_ParmIndex.Status

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function ShallowCopy()	As iBxS_ZDTONHeader_ParmIndex _
												Implements iBxS_ZDTONHeader_ParmIndex.ShallowCopy

				Return CType( Me.MemberwiseClone(), iBxS_ZDTONHeader_ParmIndex )

			End Function

		#End Region

	End Class

End Namespace
