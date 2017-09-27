'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SAPFunctions.MsgComposer

	Friend Class BxS_MsgComposer_ParmIndex
								Implements iBxS_MsgComposer_ParmIndex

		#Region "Properties"

			Property Lang	As Integer	Implements	iBxS_MsgComposer_ParmIndex.Lang
			Property ID		As Integer	Implements	iBxS_MsgComposer_ParmIndex.ID
			Property No		As Integer	Implements	iBxS_MsgComposer_ParmIndex.No
			Property V1		As Integer	Implements	iBxS_MsgComposer_ParmIndex.V1
			Property V2		As Integer	Implements	iBxS_MsgComposer_ParmIndex.V2
			Property V3		As Integer	Implements	iBxS_MsgComposer_ParmIndex.V3
			Property V4		As Integer	Implements	iBxS_MsgComposer_ParmIndex.V4
			Property Text	As Integer	Implements	iBxS_MsgComposer_ParmIndex.Text
			Property LTxt	As Integer	Implements	iBxS_MsgComposer_ParmIndex.LTxt

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function ShallowCopy()	As iBxS_MsgComposer_ParmIndex _
												Implements iBxS_MsgComposer_ParmIndex.ShallowCopy

				Return CType( Me.MemberwiseClone(), iBxS_MsgComposer_ParmIndex )

			End Function

		#End Region

	End Class

End Namespace
