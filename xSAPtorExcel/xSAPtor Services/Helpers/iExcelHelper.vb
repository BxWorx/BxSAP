Imports Microsoft.Office.Interop.Excel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Services.Excel
	Friend Interface iExcelHelper

		#Region "Methods"

			Function SetWSProtection(						ByVal WorkBookName		As String						,
																					ByVal WorkSheetName		As String						,
																					ByVal Password				As String						,
																Optional	ByVal	Unprotect				As Boolean	= False		)		As Boolean
			Function ObscureCellContent(ByVal WorkBookName		As String	,
																	ByVal WorkSheetName		As String ,
																	ByVal RangeAddress		As String		)		As Boolean

			Sub PutData(ByVal WBName				As String,
									ByVal WSName				As String,
									ByVal	ExcelTarget		As iExcelAddress	,
									ByVal	TargetData		As Object(,)				)

			Function GetSetScreenUpdating(ByVal NewSetting	As Boolean)	As Boolean

			Function GetAddressConstituent(					ByRef i_Address		As String, 
																		 Optional	ByVal i_ReturnRow	As Boolean = False)		As String

			Function GetExcelWSProfileDTO(Optional ByVal WorkBookName  As String = ""	,
																		Optional ByVal WorkSheetName As String = ""		)		As iExcelWSProfileDTO

			Function GetWSHierarchy(Optional ByVal ExcludeNonBDC As Boolean = True)					As List(Of iExcelMDIWBookDTO)

			Function IsInEditMode                                     As Boolean
			Function IsMDIExcelVersion                                As Boolean
			Function ColumnIDToNo(ByRef i_ColID As String)            As Integer
			Function ColumnNoToID(ByRef i_ColNo As UShort)            As String
			Function GetData(ByRef i_WBName   As String,
											 ByRef i_WSIndex  As Integer,
											 ByRef i_Address  As String)              As Object(,)
			Function GetRange(ByRef i_WBName  As String,
												ByRef i_WSIndex As Integer,
												ByRef i_Address As String)              As Range
			Function GetRange(ByRef i_WBName  As String,
												ByRef i_WSName	As String,
												ByRef i_Address As String)              As Range
			Function GetWSheet(ByVal i_WBName	As String,
												 ByVal i_WSName	As String)							As Worksheet
			Function GetActiveWBookName()                             As String
			Function GetActiveWSIndex()                               As Integer
			Function GetActiveWSName()                                As String
			Function GetWSheetIndex(ByVal i_WBName  As String,
															ByVal i_WSName  As String)        As Integer
			Function GetWSheetUsedAddress(ByVal i_WBName  As String,
																		ByVal i_WSIndex As Integer) As String
			
			Function GetCurrentCell()                                 As Range

			Function GetActiveWindowHandle()                          As Integer

			Function FindValue(ByVal i_WBName   As String,
												 ByVal i_WSIndex  As Integer,
												 ByVal i_Address  As String,
												 ByVal i_LookFor  As String)            As Range

		#End Region

	End Interface

End Namespace
