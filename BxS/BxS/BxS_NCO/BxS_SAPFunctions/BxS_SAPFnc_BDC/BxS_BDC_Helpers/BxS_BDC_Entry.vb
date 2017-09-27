Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.Helpers

	Friend Class BxS_BDC_Entry
								Implements iBxS_BDC_Entry

		#Region "Properties"

			Property Program_Name()		As String	Implements iBxS_BDC_Entry.Program_Name
			Property Dynpro_Number()  As String	Implements iBxS_BDC_Entry.Dynpro_Number
			Property Dynpro_Begin()   As String	Implements iBxS_BDC_Entry.Dynpro_Begin
			Property Field_Name()     As String	Implements iBxS_BDC_Entry.Field_Name
			Property Field_Value()    As String	Implements iBxS_BDC_Entry.Field_Value
			Property Field_Descr()    As String	Implements iBxS_BDC_Entry.Field_Descr

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function ShallowCopy() _
												As iBxS_BDC_Entry _
													Implements iBxS_BDC_Entry.ShallowCopy

				Dim lo_Entry	= DirectCast(Me.MemberwiseClone(), iBxS_BDC_Entry)
				Return	lo_Entry


			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			Public Sub New()

				Me.Program_Name		= ""
				Me.Dynpro_Number	= ""
				Me.Dynpro_Begin		= ""
				Me.Field_Name			=	""
				Me.Field_Value		= ""
				Me.Field_Descr		= ""

			End Sub

		#End Region

	End Class

End Namespace