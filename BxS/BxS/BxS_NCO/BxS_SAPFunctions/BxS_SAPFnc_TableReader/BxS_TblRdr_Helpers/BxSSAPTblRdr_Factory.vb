Imports SAPNCO = SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.Tablereader

	Friend Class BxSSAPTblRdr_Factory
								Implements iBxSSAPTblRdr_Factory

		#Region "Definitions"

			Private Const cx_SAPFncName	As String = "/BODS/RFC_READ_TABLE2"

			Private co_RfcDest					As SAPNCO.RfcCustomDestination

			Private co_rfcFncMetaData   As Lazy(Of SAPnco.RfcFunctionMetadata) _
								= New Lazy(Of SAPNCO.RfcFunctionMetadata)(
										Function()

											Try
													Return Me.co_RfcDest.Repository.GetFunctionMetadata(cx_SAPFncName)
												Catch ex As Exception
													Return Nothing
											End Try
																																									
										End Function )

			Private co_rfcFncParmIndex  As Lazy(Of iBxSSAPTblRdr_ParmIndex) _
								= New Lazy(Of iBxSSAPTblRdr_ParmIndex)(
										Function()	
											Return Me.CreateParmIndex()
										End Function )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function CreateTableReader(ByVal tableName	As String) As iBxSSAPTblRdr_Reader _
												Implements iBxSSAPTblRdr_Factory.CreateTableReader

				Dim lo_TblProfile	As iBxSSAPTblRdr_Profile	= New BxSSAPTblRdr_Profile

				With lo_TblProfile
					.SAPFncName	= cx_SAPFncName
					.TableName	= tableName
				End With

				Return	New BxSSAPTblRdr_Reader(destination:=		Me.co_RfcDest, 
																				tblrdrParmIdx:=	Me.co_rfcFncParmIndex.Value.Clone(),
																				tblrdrProfile:=	lo_TblProfile )

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(ByRef destination As SAPNCO.RfcCustomDestination)

				Me.co_RfcDest	= destination

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Privates"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function CreateParmIndex() As iBxSSAPTblRdr_ParmIndex

				Const cz_QryTable     As String = "QUERY_TABLE"
				Const cz_Delimeter    As String = "DELIMITER"
				Const cz_NoData       As String = "NO_DATA"
				Const cz_SkipRows     As String = "ROWSKIPS"
				Const cz_RowsCount    As String = "ROWCOUNT"
				Const cz_Options      As String = "OPTIONS"
				Const cz_Fields       As String = "FIELDS"
				Const cz_OutTable     As String = "OUT_TABLE"
				Const cz_OutTab128    As String = "TBLOUT128"
				Const cz_OutTab512    As String = "TBLOUT512"
				Const cz_OutTab2048   As String = "TBLOUT2048"
				Const cz_OutTab8192   As String = "TBLOUT8192"
				Const cz_OutTab30000  As String = "TBLOUT30000"

				Dim lo_ParamIndex			As iBxSSAPTblRdr_ParmIndex	= New BxSSAPTblRdr_ParmIndex

				lo_ParamIndex.QueryTable		= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_QryTable)
				lo_ParamIndex.Delimiter			= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_Delimeter)
				lo_ParamIndex.NoData				= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_NoData)
				lo_ParamIndex.SkipRows			= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_SkipRows)
				lo_ParamIndex.RowCount			= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_RowsCount)
				lo_ParamIndex.Options				= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_Options)
				lo_ParamIndex.Fields				= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_Fields)

				lo_ParamIndex.OutTableName	= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_OutTable)

				lo_ParamIndex.OutTable128   = Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_OutTab128)
				lo_ParamIndex.OutTable512   = Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_OutTab512)
				lo_ParamIndex.OutTable2048  = Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_OutTab2048)
				lo_ParamIndex.OutTable8192  = Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_OutTab8192)
				lo_ParamIndex.OutTable30000	= Me.co_rfcFncMetaData.Value.TryNameToIndex(cz_OutTab30000)

				Return lo_ParamIndex

			End Function

		#End Region

	End Class

End Namespace