Imports SAPNCO = SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.Tablereader

	Friend Interface iBxSSAPTblRdr_Reader

		#Region "Properties"

			ReadOnly Property Profile()							As iBxSSAPTblRdr_Profile
			ReadOnly Property DataTableStructure()	As SAPNCO.IRfcStructure
			ReadOnly Property DataTable()						As SAPNCO.IRfcTable
			ReadOnly Property DataTableFields()			As SAPNCO.IRfcTable
			ReadOnly Property RowCount()						As Integer

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Sub Add_Field(ByVal i_FieldName	As String, Optional i_Reset	As Boolean = False)
			Sub Add_Filter(ByVal i_Filter		As String, Optional i_Reset As Boolean = False)

			Sub Invoke()
			Sub Reset()

		#End Region

	End Interface

End Namespace