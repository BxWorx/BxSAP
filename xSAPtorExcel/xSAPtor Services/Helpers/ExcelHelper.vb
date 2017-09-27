Imports System.Threading

Imports Microsoft.Office.Interop.Excel

Imports xSAPtorExcel.WorksheetDomain
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Services.Excel

	Friend Class ExcelHelper
								Implements iExcelHelper

		#Region "Definitions"

			Private Const cz_SplitAddr  As Char = CChar(":")
			Private Const cz_SplitRefr  As Char = CChar("$")

			Private co_WSServices	As Lazy(Of iWSServices)	= New Lazy(Of iWSServices)(Function() WSServices.GetInstance() )
	
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function SetWSProtection(					ByVal	_wbname			As String						,
																								ByVal _wsname			As String						,
																								ByVal _pwrd				As String						,
																			Optional	ByVal _unprotect	As Boolean	= False		) _
												As Boolean _
													Implements	iExcelHelper.SetWSProtection

				Dim lb_Ret	= False
				Dim lo_WS		= Me.GetWSheet(_wbname, _wsname)
				'..................................................
				If Not IsNothing(lo_WS)

					If _unprotect
						lo_WS.Unprotect(_pwrd)
					Else
						lo_WS.Protect(Password:= _pwrd, UserInterfaceOnly			:=	True	,
																						AllowDeletingRows			:=	True	,
																						AllowFiltering				:=	True	,
																						AllowFormattingCells	:=	True	,
																						AllowFormattingRows		:=	True	,
																						AllowInsertingRows		:=	True	,
																						AllowSorting					:=	True		)
					End If

					lb_Ret	= True

				End If
				'..................................................
				Return	lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function ObscureCellContent(	ByVal	_wbname		As String	,
																					ByVal _wsname		As String	,
																					ByVal _address	As String		) _
												As Boolean _
													Implements	iExcelHelper.ObscureCellContent

				Dim lb_Ret		= False
				Dim lo_Range	= Me.GetRange(_wbname, _wsname, _address)
				'..................................................
				If Not IsNothing(lo_Range)
					lo_Range.Font.ColorIndex	= lo_Range.Interior.ColorIndex
					lb_Ret	= True
				End If
				'..................................................
				Return	lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetSetScreenUpdating(ByVal NewSetting	As Boolean)	_
												As Boolean _
													Implements iExcelHelper.GetSetScreenUpdating

				Dim lb_Ret	As Boolean	= Globals.ThisAddIn.Application.ScreenUpdating

				Globals.ThisAddIn.Application.ScreenUpdating	= NewSetting

				Return lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetExcelWSProfileDTO(	Optional	ByVal	_wbname		As String = "",
																							Optional	ByVal _wsname		As String	= ""  ) _
													As iExcelWSProfileDTO _
														Implements iExcelHelper.GetExcelWSProfileDTO

				Dim lo_CfgRng As Range  
				Dim lc_String As String

				Dim lo_WSProfileDTO	As iExcelWSProfileDTO	= New	ExcelWSProfileDTO()

				If _wbname.Length.Equals(0)
					lo_WSProfileDTO.WBookName  = Me.GetActiveWBookName()
				Else
					lo_WSProfileDTO.WBookName  = _wbname
				End If
				
				If _wsname.Length.Equals(0)
					lo_WSProfileDTO.WSheetName = Me.GetActiveWSName()
				Else
					lo_WSProfileDTO.WSheetName = _wsname
				End If

				lo_WSProfileDTO.WSheetIndex  = Me.GetWSheetIndex(	i_WBName:= lo_WSProfileDTO.WBookName,
																													i_WSName:= lo_WSProfileDTO.WSheetName)

				lo_WSProfileDTO.UsedArea     = New ExcelAddress(i_WBName := lo_WSProfileDTO.WBookName,
																												i_WSName := lo_WSProfileDTO.WSheetName,
																												i_Address:= Me.GetWSheetUsedAddress(i_WBName := lo_WSProfileDTO.WBookName,
																																														i_WSIndex:= lo_WSProfileDTO.WSheetIndex) )

				lo_WSProfileDTO.HeaderArea	= Me.co_WSServices.Value.ExtractHeaderAddress(i_WSUsedAddress:= lo_WSProfileDTO.UsedArea)
				lo_WSProfileDTO.DataArea		= Me.co_WSServices.Value.ExtractDataAddress(i_WSUsedAddress:= lo_WSProfileDTO.UsedArea)
				lo_WSProfileDTO.RowTemplate	= Me.co_WSServices.Value.GetRowTemplate(i_ExcelAddress:= lo_WSProfileDTO.DataArea)

				lo_CfgRng = Me.FindValue(i_WBName := lo_WSProfileDTO.WBookName,
																 i_WSIndex:= lo_WSProfileDTO.WSheetIndex,
																 i_Address:= lo_WSProfileDTO.HeaderArea.Address,
																 i_LookFor:= GetType(BDCXMLConfig).Name )

				If lo_CfgRng Is Nothing
					lc_String = "$A$1"
					lo_WSProfileDTO.IsSAPtor	= False
				Else
					lc_String = lo_CfgRng.Address
					lo_WSProfileDTO.IsSAPtor	= True
				End If

				lo_WSProfileDTO.XMLConfigAddress = New ExcelAddress(i_WBName := lo_WSProfileDTO.WBookName,
																														i_WSName := lo_WSProfileDTO.WSheetName,
																														i_Address:= lc_String)

				lo_CfgRng = Me.GetRange(i_WBName := lo_WSProfileDTO.WBookName,
																i_WSIndex:= lo_WSProfileDTO.WSheetIndex,
																i_Address:= lo_WSProfileDTO.XMLConfigAddress.Address)

				If lo_CfgRng.Value IsNot Nothing

					lc_String = CStr(lo_CfgRng.Value)        

					If lc_String.Contains(GetType(BDCXMLConfig).Name)

						Dim lo_XMLCfg = Me.co_WSServices.Value.DeSerializeObject(Of BDCXMLConfig)(lc_String)
				
						If lo_XMLCfg IsNot Nothing

							lo_WSProfileDTO.BDCConfig.IsActive							= lo_XMLCfg.IsActive
							lo_WSProfileDTO.BDCConfig.SAPTCode							= lo_XMLCfg.SAPTCode
							lo_WSProfileDTO.BDCConfig.Active_Column_Address	= lo_XMLCfg.Active_Column
							lo_WSProfileDTO.BDCConfig.MessageColumnAddress	= lo_XMLCfg.Msg_Column
							lo_WSProfileDTO.BDCConfig.PauseTime							= lo_XMLCfg.PauseTime
							lo_WSProfileDTO.BDCConfig.GUID									= lo_XMLCfg.GUID
							lo_WSProfileDTO.BDCConfig.SessionID							= lo_XMLCfg.SessionID

							lo_WSProfileDTO.BDCConfig.CTU_Parameters.DisMode	= lo_XMLCfg.CTU_DisMode
							lo_WSProfileDTO.BDCConfig.CTU_Parameters.UpdMode	= lo_XMLCfg.CTU_UpdMode
							lo_WSProfileDTO.BDCConfig.CTU_Parameters.DefSize	= lo_XMLCfg.CTU_DefSize

							lo_WSProfileDTO.BDCConfig.IsProtected	= lo_XMLCfg.IsProtected
							lo_WSProfileDTO.BDCConfig.Password		= lo_XMLCfg.Password

						End If

					End If

					Dim lc_ColIDAct As String	= Me.GetAddressConstituent(lo_WSProfileDTO.BDCConfig.Active_Column_Address)
					Dim lc_ColIDMsg As String	= Me.GetAddressConstituent(lo_WSProfileDTO.BDCConfig.MessageColumnAddress)

					lo_WSProfileDTO.SelectArea	= New ExcelAddress(Me.co_WSServices.Value.GetActiveColumnAddress(	i_ExcelAddress	:= lo_WSProfileDTO.DataArea,
																																																				i_ActiveColID		:= lc_ColIDAct,
																																																				i_UseAddressRows:= True) )

					lo_WSProfileDTO.MessageArea	= New ExcelAddress(Me.co_WSServices.Value.GetActiveColumnAddress(	i_ExcelAddress	:= lo_WSProfileDTO.DataArea,
																																																				i_ActiveColID		:= lc_ColIDMsg,
																																																				i_UseAddressRows:= True) )

					If lc_ColIDMsg.Equals("$")
						lo_WSProfileDTO.SelectColumnNo		= 2
					Else
						lo_WSProfileDTO.SelectColumnNo		=	Me.ColumnIDToNo(lc_ColIDAct)
					End If

					If lc_ColIDMsg.Equals("$")
						lo_WSProfileDTO.MessageColumnNo		= 1
					Else
						lo_WSProfileDTO.MessageColumnNo		= Me.ColumnIDToNo(lc_ColIDMsg)
					End If

				End If

				If lo_WSProfileDTO.BDCConfig.IsProtected.Equals("X")	Then	lo_WSProfileDTO.IsProtected	= True
				lo_WSProfileDTO.Password	= lo_WSProfileDTO.BDCConfig.Password

				Return lo_WSProfileDTO

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetWSHierarchy(Optional ByVal ExcludeNonBDC As Boolean = True)	_
												As List(Of iExcelMDIWBookDTO) _
													Implements	iExcelHelper.GetWSHierarchy

				Dim lt_List			As New List(Of iExcelMDIWBookDTO)()
				Dim lc_ID				As String
				Dim lo_Config		As Range

				For Each lo_WB As Workbook In Globals.ThisAddIn.Application.Workbooks

					Dim lo_WBDTO	As iExcelMDIWBookDTO	= New ExcelMDIWBookDTO

					lo_WBDTO.WBName	= lo_WB.Name
					lo_WBDTO.WSList	= New List(Of iExcelMDIWSheetDTO)

					For Each lo_WS As Worksheet In lo_WB.Worksheets

						lo_Config	= lo_WS.UsedRange.Find(What       := "<BDCXMLConfig>",
																						 SearchOrder:= XlSearchOrder.xlByColumns,
																						 MatchCase  := False,
																						 LookAt     := XlLookAt.xlPart)

						If lo_Config Is Nothing AndAlso ExcludeNonBDC	Then Continue For

						Dim lo_WSDTO	As iExcelMDIWSheetDTO	= New ExcelMDIWSheetDTO

						If lo_Config Is Nothing
							lo_WSDTO.IsBDCType				= False
						Else

							lo_WSDTO.IsBDCType				= True
							lo_WSDTO.BDCConfigAddress	= lo_Config.Address
							lo_WSDTO.BDCConfigXML			= lo_Config.Value.ToString

						End If

						lc_ID	= String.Concat(lo_WB.Name,"/",lo_WS.Name)
					
						lo_WSDTO.WSName			= lo_WS.Name
						lo_WSDTO.WSIndex		= lo_WS.Index
						lo_WSDTO.BDCActive	= False
						lo_WSDTO.ParentID		= lo_WB.Name

						lo_WBDTO.WSList.Add(lo_WSDTO)

					Next

					If lo_WBDTO.WSList.Count > 0
						lt_List.Add(lo_WBDTO)
					End If

				Next

				Return lt_List

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Sub PutData(ByVal _wbname				As String					,
									ByVal _wsname				As String					,
									ByVal	_exceltarget	As iExcelAddress	,
									ByVal	_targetdata		As Object(,)				)	Implements iExcelHelper.PutData

				Dim lo_Range  As Range = Nothing

				lo_Range  = Me.GetRange(_wbname, _wsname, _exceltarget.Address)

				If IsNothing(lo_Range)	Then Exit Sub
				'..................................................
				lo_Range.Value	= _targetdata

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function FindValue(ByVal i_WBName  As String,
																ByVal i_WSIndex As Integer,
																ByVal i_Address As String,
																ByVal i_LookFor As String) As Range  Implements iExcelHelper.FindValue

				Dim lo_Range  As Range = Nothing

				lo_Range  = Me.GetRange(i_WBName := i_WBName,
																i_WSIndex:= i_WSIndex,
																i_Address:= i_Address)

				If Not IsNothing(lo_Range)

					lo_Range = lo_Range.Find(What       := i_LookFor									,
																	 SearchOrder:= XlSearchOrder.xlByColumns	,
																	 MatchCase  := False											,
																	 LookAt     := XlLookAt.xlPart						,
																	 LookIn			:= XlFindLookIn.xlValues				)

				End If

				Return lo_Range

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetCurrentCell() As Range Implements iExcelHelper.GetCurrentCell

				Return Globals.ThisAddIn.Application.ActiveCell()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetWSheetUsedAddress(ByVal i_WBName   As String,
																					 ByVal i_WSIndex  As Integer) As String Implements iExcelHelper.GetWSheetUsedAddress

				Return CType(Globals.ThisAddIn.Application.Workbooks().Item(Index:= i_WBName).Worksheets().Item(Index:= i_WSIndex),
										 Worksheet).UsedRange.Address

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetWSheetIndex(ByVal i_WBName As String,
																		 ByVal i_WSName As String)  As Integer  Implements iExcelHelper.GetWSheetIndex

				Return CType(Globals.ThisAddIn.Application.Workbooks().Item(Index:= i_WBName).Worksheets().Item(Index:= i_WSName),
										 Worksheet).Index

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetActiveWBookName()  As String Implements iExcelHelper.GetActiveWBookName
				Return Globals.ThisAddIn.Application.ActiveWorkbook.Name
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetActiveWSIndex() As Integer Implements iExcelHelper.GetActiveWSIndex
				Return CUShort(CType(Globals.ThisAddIn.Application.ActiveSheet,
														 Worksheet).Index)
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetActiveWSName() As String Implements iExcelHelper.GetActiveWSName
				Return  CType(Globals.ThisAddIn.Application.ActiveSheet,
											Worksheet).Name
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetWSheet(ByVal i_WBName	As String,
																ByVal i_WSName	As String) _
												As Worksheet _
													Implements iExcelHelper.GetWSheet

				Return CType(Globals.ThisAddIn.Application.Workbooks().Item(Index:=i_WBName).Worksheets().Item(Index:=i_WSName),
										 Worksheet)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetRange(ByRef _wbname		As String,
															 ByRef _wsname		As String,
															 ByRef _address		As String)  As Range  Implements iExcelHelper.GetRange

				Return CType(Globals.ThisAddIn.Application.Workbooks().Item(_wbname).Worksheets().Item(_wsname),
										 Worksheet).Range(_address)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetRange(ByRef i_WBName   As String,
															 ByRef i_WSIndex  As Integer,
															 ByRef i_Address  As String)  As Range  Implements iExcelHelper.GetRange

				Return CType(Globals.ThisAddIn.Application.Workbooks().Item(Index:=i_WBName).Worksheets().Item(Index:=i_WSIndex),
										 Worksheet).Range(Cell1:= i_Address)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetData(ByRef i_WBName   As String,
															ByRef i_WSIndex  As Integer,
															ByRef i_Address  As String) As Object(,)  Implements iExcelHelper.GetData

				Try

						Dim lo_Rng  As Range = CType(Globals.ThisAddIn.Application.Workbooks().Item(Index:=i_WBName).Worksheets().Item(Index:=i_WSIndex),
																				 Worksheet).Range(Cell1:= i_Address)

						If lo_Rng.Count = 1

							Dim lo_Arr As Array = Array.CreateInstance( GetType(Object), New Integer(1) {1,1}, New Integer(1) {1,1})
							Dim lo_Obj          = CType(lo_Arr, Object(,))

							lo_Obj(1,1) = lo_Rng.Value
							Return lo_Obj

						Else
							Return CType(lo_Rng.Value, Object(,))
						End If

					Catch ex As Exception

							Dim lo_Arr As Array = Array.CreateInstance( GetType(Object), New Integer(1) {1,1}, New Integer(1) {1,1})
							Dim lo_Obj          = CType(lo_Arr, Object(,))

							Return lo_Obj
		
				End Try

			End Function
		 '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function ColumnNoToID(ByRef i_ColNo As UShort) As String Implements iExcelHelper.ColumnNoToID

				Dim ln_Div  As Integer  = CInt(i_ColNo)
				Dim lc_Col  As String   = [String].Empty
				Dim ln_Mod  As Integer

				While ln_Div > 0
					ln_Mod = (ln_Div - 1) Mod 26
					lc_Col = Convert.ToChar(65 + ln_Mod).ToString() & lc_Col
					ln_Div = CInt((ln_Div - ln_Mod) / 26)
				End While

				Return lc_Col

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function ColumnIDToNo(ByRef i_ColID As String) As Integer  Implements iExcelHelper.ColumnIDToNo

				Dim ln_Sub  As Integer  = Asc("A"c) - 1

				Return i_ColID.ToCharArray().[Select](
																	Function(c)
																			Return Asc(c) - ln_Sub
																	End Function).Reverse().[Select](Function(v, i) v * CInt(Math.Pow(26, i))).Sum()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function IsInEditMode As Boolean Implements iExcelHelper.IsInEditMode
				Try
					Globals.ThisAddIn.Application.Interactive = Globals.ThisAddIn.Application.Interactive
					Return False
				Catch ex As Exception
					Return True
				End Try
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function IsMDIExcelVersion() As Boolean Implements iExcelHelper.IsMDIExcelVersion
					Return True
					'Return CBool(IIf(Double.Parse(Globals.ThisAddIn.Application.Version) >= 14, True, False))
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetActiveWindowHandle() As Integer  Implements iExcelHelper.GetActiveWindowHandle
					Return Globals.ThisAddIn.Application.ActiveWindow.Hwnd
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetAddressConstituent(					ByRef i_Address		As String, 
																						Optional	ByVal i_ReturnRow	As Boolean = False) _
												As String _
													Implements iExcelHelper.GetAddressConstituent

					If IsNothing(i_Address)					Then	Return "$"
					If i_Address.Length.Equals(0)		Then	Return "#"
					'................................................
					Dim lt() = Split(i_Address, "$")

					If i_ReturnRow
						Return lt(2)
					Else
						Return lt(1)
					End If

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Shared ReadOnly _Instance As Lazy(Of iExcelHelper) _
																= New Lazy(Of iExcelHelper)(
																		Function()	New ExcelHelper,
																								LazyThreadSafetyMode.ExecutionAndPublication )
			Friend Shared ReadOnly Property ExcelHelper() As iExcelHelper
				Get
					Return _Instance.Value
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New()
			End Sub

		#End Region

	End Class

End Namespace

