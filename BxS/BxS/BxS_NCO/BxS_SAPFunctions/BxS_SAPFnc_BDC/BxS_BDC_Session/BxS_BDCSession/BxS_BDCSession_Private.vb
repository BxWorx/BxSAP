Imports System.Globalization
Imports BxS.API.SAPFunctions.Tablereader
Imports BxS.API.SAPFunctions.Helpers
Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.BDCSession

	Friend Partial Class BxS_BDCSession

		#Region "Private Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function FetchSAPBDCSession(ByVal i_SessionName		As String,
																					ByVal i_QID           As String)	As iBxSBDCSession_Profile

				Dim lo_BDCProfile As iBxSBDCSession_Profile	= New BxSBDCSession_Profile()

				lo_BDCProfile.SessionName = i_SessionName

				If Not String.IsNullOrEmpty(i_QID.Trim)

					Me.co_TblRdr_Data.Value.Add_Filter("    TRANS EQ '1'", True)
					Me.co_TblRdr_Data.Value.Add_Filter(String.Concat(" AND QID EQ ",
																													 "'",
																													 i_QID.ToUpper(),
																													 "'" )
																													 )
					'......................................................................
					Me.co_TblRdr_Data.Value.Invoke()
					'......................................................................
					Me.ProcessBDCDataRaw(lo_BDCProfile)
					Me.co_TblRdr_Data.Value.Reset()

				End If

				Return lo_BDCProfile

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub ProcessBDCDataRaw(lo_BDCProfile As iBxSBDCSession_Profile)

				Dim lq_Query As IEnumerable(Of BxSBDCSession_Raw) _
												= From lc_Row In Me.co_TblRdr_Data.Value.DataTable
													Let lt_Fields = lc_Row.GetString(0).Split("|"c)
													Let lt_Split  = lt_Fields(6).Split(CType(vbNullChar, Char())).ToList()
														Select New BxSBDCSession_Raw With {
															.BlockCount = CLng(lt_Fields(2)),
															.SegmentNo  = CInt(lt_Fields(3)),
															.BDCList    = lt_Split
															}

				Dim lt_RawDataList  As List(Of BxSBDCSession_Raw) = lq_Query.OrderBy(Function(x) x.BlockCount).ToList

				lo_BDCProfile.SAPTCode  = Me.Setup_Transaction(lt_RawDataList(0).BDCList(0))
				lo_BDCProfile.CTUParams = Me.Setup_CTUParams(lt_RawDataList(0).BDCList(0))

				For ln_Raw As Integer = 1 To lt_RawDataList.Count - 1

					If lt_RawDataList(ln_Raw).BDCList(0).Substring(0,1) = "M"c

						lo_BDCProfile.BDCDataList.Add(Me.Add_Dynpro(lt_RawDataList(ln_Raw).BDCList(21)))

						For ln_Data As Integer = 23 To lt_RawDataList(ln_Raw).BDCList.Count - 1 Step 2

							If Not String.IsNullOrWhiteSpace( lt_RawDataList(ln_Raw).BDCList(ln_Data) )
								lo_BDCProfile.BDCDataList.Add(Me.Add_Field( lt_RawDataList(ln_Raw).BDCList(ln_Data),
																														lt_RawDataList(ln_Raw).BDCList(ln_Data+1) ))
							End If

						Next

					End If

				Next

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function Setup_Transaction(i_RawData As String) As String

				Try
						Return i_RawData.Substring(2,20).Trim
					Catch ex As Exception
						Return "*****"

				End Try

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function Setup_CTUParams(i_RawData As String) As iBxS_BDC_CTUParameters

				Const lx_Dismode	As Integer	= 24
				Const lx_Updmode	As Integer	= 25
				Const lx_Catmode	As Integer	= 26
				Const lx_Defsize	As Integer	= 27
				Const lx_RACommt	As Integer	= 28
				Const lx_NoBInpt	As Integer	= 29
				Const lx_NoBIEnd	As Integer	= 30


				Dim lo_CTUParams	As iBxS_BDC_CTUParameters	= New BxS_BDC_CTUParameters

				Try

						With lo_CTUParams
							.DisMode	= i_RawData.Chars(lx_Dismode)
							.UpdMode	= i_RawData.Chars(lx_Updmode)
							.CattMode	= i_RawData.Chars(lx_Catmode)
							.DefSize	= i_RawData.Chars(lx_Defsize)
							.RACommit	= i_RawData.Chars(lx_RACommt)
							.NoBInpt	= i_RawData.Chars(lx_NoBInpt)
							.NoBIEnd	= i_RawData.Chars(lx_NoBIEnd)
						End With

					Catch ex As Exception

				End Try
			
				Return lo_CTUParams

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function Add_Field(i_Field As String, i_Value As String) As iBxS_BDC_Entry

				Dim lo_Data As iBxS_BDC_Entry  = New BxS_BDC_Entry

				lo_Data.Field_Name  = i_Field
				lo_Data.Field_Value = i_Value

				Return lo_Data

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function Add_Dynpro(i_RawData As String) As iBxS_BDC_Entry

				Dim lo_Data As iBxS_BDC_Entry  = New BxS_BDC_Entry

				lo_Data.Program_Name  = i_RawData.Substring(0,40).Trim
				lo_Data.Dynpro_Number = i_RawData.Substring(40,4).Trim
				lo_Data.Dynpro_Begin  = "X"c

				Return lo_Data

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function FetchSAPBDCHeaderList(i_UserId        As String, _
																						 i_SessionName   As String, _
																						 i_DateFrom      As Date, _
																						 i_DateTo        As Date )	As List(Of iBxSBDCSession_Header)

				Const lx_Idx_Usr	As Integer	= 0
				Const lx_Idx_Nme	As Integer	= 1
				Const lx_Idx_Dte	As Integer	= 2
				Const lx_Idx_Tme	As Integer	= 3
				Const lx_Idx_Cnt  As Integer	= 4
				Const lx_Idx_QID  As Integer	= 5

				Dim lt_List	= New List(Of iBxSBDCSession_Header) 
			
				Me.co_TblRdr_Hdr.Value.Add_Filter("    DESTSYS EQ SPACE", True)
				Me.co_TblRdr_Hdr.Value.Add_Filter("AND DESTAPP EQ SPACE")
				Me.co_TblRdr_Hdr.Value.Add_Filter("AND FORMID  EQ SPACE")
				Me.co_TblRdr_Hdr.Value.Add_Filter("AND QATTRIB EQ SPACE")
				Me.co_TblRdr_Hdr.Value.Add_Filter("AND MANDANT EQ SY-MANDT")
				Me.co_TblRdr_Hdr.Value.Add_Filter("AND DATATYP EQ '%BDC'")

				If Not i_UserId.Length.Equals(0) AndAlso Not i_UserId.Equals("*"c)
					Me.co_TblRdr_Hdr.Value.Add_Filter(String.Concat(" AND CREATOR LIKE ", 
																													"'", 
																													i_UserId.Replace("*"c,"%"c).ToUpper(),
																													"'" ) )
				End If

				If Not i_SessionName.Length.Equals(0) AndAlso Not i_SessionName.Equals("*"c)
					Me.co_TblRdr_Hdr.Value.Add_Filter(String.Concat(" AND GROUPID LIKE ",
																													"'", 
																													i_SessionName.Replace("*"c,"%"c).ToUpper(), 
																													"'" ) )
				End If

				Me.co_TblRdr_Hdr.Value.Add_Filter(String.Concat(" AND CREDATE BETWEEN ",
																												"'", 
																												i_DateFrom.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
																												"'",
																												" AND ",
																												"'", 
																												i_DateTo.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
																												"'" ) )
				'......................................................................
				Me.co_TblRdr_Hdr.Value.Invoke()
				'......................................................................
				Dim lq_Query As IEnumerable(Of iBxSBDCSession_Header) _
								=	From lc_Row In Me.co_TblRdr_Hdr.Value.DataTable
									Let lt_Fields = lc_Row.GetString(0).Split("|"c)
										Select New BxSBDCSession_Header With {
											.UserID       = lt_Fields(lx_Idx_Usr).Trim,
											.SessionName  = lt_Fields(lx_Idx_Nme).Trim,
											.CreationDate = Date.ParseExact(lt_Fields(lx_Idx_Dte), "yyyyMMdd",CultureInfo.InvariantCulture),
											.CreationTime = TimeSpan.ParseExact(lt_Fields(lx_Idx_Tme), "hhmmss",CultureInfo.InvariantCulture),
											.Count        = CInt(lt_Fields(lx_Idx_Cnt)),
											.QID          = lt_Fields(lx_Idx_QID)
											}

				lt_List.AddRange( lq_Query.ToList() )
				'......................................................................
				Me.co_TblRdr_Hdr.Value.Reset()

				Return lt_List

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function Create_TblRdr_Header()	As iBxSSAPTblRdr_Reader

				Dim lo_TblRdr	As iBxSSAPTblRdr_Reader
			
				lo_TblRdr	= New BxSSAPTblRdr_Factory(destination:=Me.co_rfcDest).CreateTableReader(tableName:="APQI")

				lo_TblRdr.Add_Field("USERID", True)
				lo_TblRdr.Add_Field("GROUPID"			)
				lo_TblRdr.Add_Field("CREDATE"			)
				lo_TblRdr.Add_Field("CRETIME"			)
				lo_TblRdr.Add_Field("TRANSCNT"		)
				lo_TblRdr.Add_Field("QID"					)

				Return lo_TblRdr

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function Create_TblRdr_Data()	As iBxSSAPTblRdr_Reader

				Return New BxSSAPTblRdr_Factory(destination:=Me.co_rfcDest).CreateTableReader(tableName:="APQD")

			End Function

		#End Region

	End Class
	'°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°
	Friend Partial Class BxS_BDCSession

		Private Class BxSBDCSession_Raw

			#Region "Properties"

				Protected Friend Property Blockcount  As Long
				Protected Friend Property SegmentNo   As Integer
				Protected Friend Property BDCList     As List(Of String)

			#End Region

		End Class

	End Class

End Namespace