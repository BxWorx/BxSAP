'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.ZDTON

	Friend Class BxS_ZDTONMsgs_ParmIndex
								Implements iBxS_ZDTONMsgs_ParmIndex

		#Region "Properties"

			Property User				As Integer	Implements	iBxS_ZDTONMsgs_ParmIndex.User
			Property ID					As Integer	Implements	iBxS_ZDTONMsgs_ParmIndex.ID
			Property Status			As Integer	Implements	iBxS_ZDTONMsgs_ParmIndex.Status
			Property MsgTable		As Integer	Implements	iBxS_ZDTONMsgs_ParmIndex.MsgTable

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function ShallowCopy()	As iBxS_ZDTONMsgs_ParmIndex _
												Implements iBxS_ZDTONMsgs_ParmIndex.ShallowCopy

				Return CType( Me.MemberwiseClone(), iBxS_ZDTONMsgs_ParmIndex )

			End Function

		#End Region

	End Class

End Namespace
