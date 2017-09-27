'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Friend Class BxS_ZDTONData_ParmIndex
								Implements iBxS_ZDTONData_ParmIndex

		#Region "Properties"

			Property User			As Integer	Implements iBxS_ZDTONData_ParmIndex.User
			Property ID				As Integer	Implements iBxS_ZDTONData_ParmIndex.ID
			Property RowNo		As Integer	Implements iBxS_ZDTONData_ParmIndex.RowNo
			Property ExcelRow	As Integer	Implements iBxS_ZDTONData_ParmIndex.ExcelRow
			Property Values		As Integer	Implements iBxS_ZDTONData_ParmIndex.Values
			Property Status		As Integer	Implements iBxS_ZDTONData_ParmIndex.Status

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function ShallowCopy()	As iBxS_ZDTONData_ParmIndex _
												Implements iBxS_ZDTONData_ParmIndex.ShallowCopy

				Return CType( Me.MemberwiseClone(), iBxS_ZDTONData_ParmIndex )

			End Function

		#End Region

	End Class

End Namespace
