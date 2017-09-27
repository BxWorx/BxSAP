Imports System.Threading
Imports SAPNCO = SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.Tablereader

	Friend Class BxSSAPTblRdr_Reader
								Implements iBxSSAPTblRdr_Reader

		#Region "Definitions"

			Private co_RfcDest				As SAPNCO.RfcCustomDestination

			Private co_TblParmIdx			As iBxSSAPTblRdr_ParmIndex
			Private co_Profile        As iBxSSAPTblRdr_Profile

			Private cn_DataTblIndex		As Integer

			Private co_rfcFnc         As Lazy(Of SAPNCO.IRfcFunction) _
																		= New Lazy(Of SAPNCO.IRfcFunction)(
																				Function()	Me.co_RfcDest.Repository.CreateFunction(Me.co_Profile.SAPFncName),
																										LazyThreadSafetyMode.ExecutionAndPublication )

			Private	co_TabOptions			As Lazy(Of SAPNCO.IRfcTable) _
																		= New Lazy(Of SAPNCO.IRfcTable)(
																				Function()	Me.co_rfcFnc.Value.GetTable(Me.co_TblParmIdx.Options),
																										LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_StrOptions			As Lazy(Of SAPNCO.IRfcStructure) _
																		= New Lazy(Of SAPNCO.IRfcStructure)(
																				Function()	Me.co_TabOptions.Value.Metadata.LineType.CreateStructure(),
																										LazyThreadSafetyMode.ExecutionAndPublication )

			Private	co_TabFields			As Lazy(Of SAPNCO.IRfcTable) _
																		= New Lazy(Of SAPNCO.IRfcTable)(
																				Function()	Me.co_rfcFnc.Value.GetTable(Me.co_TblParmIdx.Fields),
																										LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_StrFields			As Lazy(Of SAPNCO.IRfcStructure) _
																		= New Lazy(Of SAPNCO.IRfcStructure)(
																				Function()	Me.co_TabFields.Value.Metadata.LineType.CreateStructure(),
																										LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			ReadOnly Property Profile As iBxSSAPTblRdr_Profile Implements iBxSSAPTblRdr_Reader.Profile
				Get
					Return Me.co_Profile
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private co_DataTbl As SAPNCO.IRfcTable
			Public ReadOnly Property DataTable() As SAPNCO.IRfcTable Implements iBxSSAPTblRdr_Reader.DataTable
				Get
					Return Me.co_DataTbl
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private co_DataTblFields As SAPNCO.IRfcTable
			Public ReadOnly Property DataTableFields() As SAPNCO.IRfcTable Implements iBxSSAPTblRdr_Reader.DataTableFields
				Get
					Return Me.co_DataTblFields
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private co_DataTblStruct As SAPNCO.IRfcStructure
			Public ReadOnly Property DataTableStructure()  As SAPNCO.IRfcStructure Implements iBxSSAPTblRdr_Reader.DataTableStructure
				Get
					Return Me.co_DataTblStruct
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public ReadOnly Property RowCount() As Integer Implements iBxSSAPTblRdr_Reader.RowCount
				Get
					Return Me.co_DataTbl.RowCount
				End Get
			End Property
		
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub Add_Field(					ByVal i_FieldName	As String, _
													 Optional	ByVal i_Reset			As Boolean = False) _
									Implements iBxSSAPTblRdr_Reader.Add_Field

				If i_Reset Then me.co_Profile.Reset(i_Fields:=i_Reset)
				Me.co_Profile.Add_Field(i_FieldName)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub Add_Filter(					ByVal i_Filter	As String, _
														Optional	ByVal i_Reset		As Boolean = False) _
									Implements iBxSSAPTblRdr_Reader.Add_Filter

				If i_Reset Then me.co_Profile.Reset(i_Options:=i_Reset)
				Me.co_Profile.Add_Option(i_Filter)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub Reset() _
									Implements iBxSSAPTblRdr_Reader.Reset

				Dim lo_DataTbl As SAPNCO.IRfcTable

				lo_DataTbl = Me.co_rfcFnc.Value.GetTable(Me.co_TblParmIdx.OutTable128)   : lo_DataTbl.Clear()
				lo_DataTbl = Me.co_rfcFnc.Value.GetTable(Me.co_TblParmIdx.OutTable512)   : lo_DataTbl.Clear()
				lo_DataTbl = Me.co_rfcFnc.Value.GetTable(Me.co_TblParmIdx.OutTable2048)  : lo_DataTbl.Clear()
				lo_DataTbl = Me.co_rfcFnc.Value.GetTable(Me.co_TblParmIdx.OutTable8192)  : lo_DataTbl.Clear()
				lo_DataTbl = Me.co_rfcFnc.Value.GetTable(Me.co_TblParmIdx.OutTable30000) : lo_DataTbl.Clear()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub Invoke() _
									Implements iBxSSAPTblRdr_Reader.Invoke

				Me.Load_Imports()
				Me.Load_Options()
				Me.Load_Fields()

				Try

						Me.Reset()
						Me.co_rfcFnc.Value.Invoke(Me.co_RfcDest)
						Me.SetOutTableIndex()
						Me.co_DataTbl       = Me.co_rfcFnc.Value.GetTable(Me.cn_DataTblIndex)
						Me.co_DataTblStruct	= Me.co_DataTbl.Metadata.LineType.CreateStructure()

					Catch ex  As SAPnco.RfcAbapException
					Catch ex1 As SAPnco.RfcAbapRuntimeException

				End Try

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub SetOutTableIndex()

				Const cz_OutTab128    As String = "TBLOUT128"
				Const cz_OutTab512    As String = "TBLOUT512"
				Const cz_OutTab2048   As String = "TBLOUT2048"
				Const cz_OutTab8192   As String = "TBLOUT8192"
				Const cz_OutTab30000  As String = "TBLOUT30000"

				Dim lc_OutTableName = Me.co_rfcFnc.Value.GetString(Me.co_TblParmIdx.OutTableName)
				
				Select Case lc_OutTableName
						Case cz_OutTab128   : Me.cn_DataTblIndex = Me.co_TblParmIdx.OutTable128
						Case cz_OutTab512   : Me.cn_DataTblIndex = Me.co_TblParmIdx.OutTable512
						Case cz_OutTab2048  : Me.cn_DataTblIndex = Me.co_TblParmIdx.OutTable2048
						Case cz_OutTab8192  : Me.cn_DataTblIndex = Me.co_TblParmIdx.OutTable8192
						Case cz_OutTab30000 : Me.cn_DataTblIndex = Me.co_TblParmIdx.OutTable30000
				End Select

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Load_Imports

				Me.co_rfcFnc.Value.SetValue(Me.co_TblParmIdx.QueryTable , Me.co_Profile.TableName)
				Me.co_rfcFnc.Value.SetValue(Me.co_TblParmIdx.Delimiter  , Me.co_Profile.Delimeter)
				Me.co_rfcFnc.Value.SetValue(Me.co_TblParmIdx.SkipRows   , Me.co_Profile.SkipRows )
				Me.co_rfcFnc.Value.SetValue(Me.co_TblParmIdx.RowCount   , Me.co_Profile.RowCount )

				Me.co_rfcFnc.Value.SetValue(Me.co_TblParmIdx.NoData     , IIf(Me.co_Profile.NoData,"X","") )

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Load_Options()
				
				Me.co_TabOptions.Value.Clear()

				For Each lc_Option In Me.co_Profile.Options

					Dim lo_Row As SAPNCO.IRfcStructure	= CType( Me.co_StrOptions.Value.Clone(), SAPNCO.IRfcStructure)

					lo_Row.SetValue(0 , lc_Option)
					Me.co_TabOptions.Value.Append(lo_Row)

				Next

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Load_Fields()
				
				Me.co_TabFields.Value.Clear()

				For Each lc_Field In Me.co_Profile.FieldList

					Dim lo_Row	As SAPNCO.IRfcStructure	= CType(Me.co_StrFields.Value.Clone(), SAPNCO.IRfcStructure)

					lo_Row.SetValue(0, lc_Field)
					Me.co_TabFields.Value.Append(lo_Row)

				Next

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(ByRef destination		As SAPNCO.RfcCustomDestination, _
										 ByVal tblrdrParmIdx	As iBxSSAPTblRdr_ParmIndex, _
										 ByVal tblrdrProfile	As iBxSSAPTblRdr_Profile)

				Me.co_RfcDest			= destination
				Me.co_TblParmIdx	= tblrdrParmIdx
				Me.co_Profile     = tblrdrProfile

			End Sub

		#End Region

	End Class

End Namespace