Imports BxS.API.BDC
Imports BxS.API.SAPFunctions.Tablereader
Imports SAPNCO = SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace API.SAPFunctions.BDCSession

	Friend Class BxS_BDCSession
								Implements iBxS_BDCSession

		#Region "Definitions"

			Private co_rfcDest			As SAPNCO.RfcCustomDestination

			Private co_TblRdr_Hdr		As Lazy(Of iBxSSAPTblRdr_Reader) _
								= New Lazy(Of iBxSSAPTblRdr_Reader)(
										Function()
											Return Me.Create_TblRdr_Header()
										End Function) 

			Private co_TblRdr_Data	As Lazy(Of iBxSSAPTblRdr_Reader) _
								= New Lazy(Of iBxSSAPTblRdr_Reader)(
										Function()
											Return Me.Create_TblRdr_Data
										End Function)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function BDCSessionList(Optional	ByVal	i_UserId			As String = "*",
																		 Optional ByVal	i_SessionName	As String = "*",
																		 Optional ByVal	i_DateFrom		As Date   = #1999-01-01#,
																		 Optional ByVal	i_DateTo			As Date   = #2999-12-31#)	As List(Of iBxSBDCSession_Header) _
												Implements iBxS_BDCSession.BDCSessionList

				Return me.FetchSAPBDCHeaderList(i_UserId:=			i_UserId,
																				i_SessionName:=	i_SessionName,
																				i_DateFrom:=		i_DateFrom,
																				i_DateTo:=			i_DateTo)

			End Function

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function BDCSession(						ByVal	i_SessionName	As String,
																						ByVal	i_QID					As String,
																	Optional	ByVal	i_OnlyHeader	As Boolean	= False)	As iBxSBDCSession_Profile _
												Implements iBxS_BDCSession.BDCSession

				Return me.FetchSAPBDCSession(	i_SessionName:=	i_SessionName,
																			i_QID:=					i_QID)

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New(ByRef destination As SAPNCO.RfcCustomDestination)
				Me.co_rfcDest	= destination
			End Sub

		#End Region

	End Class

End Namespace