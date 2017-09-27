Imports System.Threading
Imports System.Threading.Tasks

Imports xSAPtorExcel.Services.Excel
Imports xSAPtorExcel.Services.UI
Imports xSAPtorExcel.WorksheetDomain

Imports BxS.API.Main
Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session

	Friend Class xSessionController
								Implements ixSessionController

		#Region "Methods: Session UI: List"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function GetSessionListAsync(	Optional	ByVal i_UserId      As String  = "*"c,
																									Optional	ByVal i_SessionName As String  = "*"c,
																									Optional	ByVal i_DateFrom    As Date    = #1999-01-01#,
																									Optional	ByVal i_DateTo      As Date    = #2999-12-31# ) _
												As Task(Of List(Of iBxSBDCSession_Header) ) _
													Implements ixSessionController.GetSessionListAsync

				Dim lt_Sessions	As List(Of iBxSBDCSession_Header)	= New List(Of iBxSBDCSession_Header)

				Me.co_CTS	= New CancellationTokenSource

				lt_Sessions	= Await Task.Run(	Function()
				           	                 		Return Me.co_CntlrNCO.Value.SessionList(	i_Destination:=	Me.co_CntlrMain.ActiveDestination,
																																									i_UserId     := i_UserId,
																																									i_SessionName:= i_SessionName,
																																									i_DateFrom   := i_DateFrom,
																																									i_DateTo     := i_DateTo  )
				           	                 	End Function,
																			Me.co_CTS.Token).ConfigureAwait(False)

				Me.co_CTS	= Nothing

				Return lt_Sessions

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Session: WSheet Template: Create"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function CreateWSEmpty()	As Boolean _
												Implements	ixSessionController.CreateWSEmpty

				Dim lb_Ret							As Boolean
				Dim lb_ScrnUpd					As Boolean
				Dim lc_XMLConfig				As String
				Dim lo_BDCDataSheet			As iBDCDataSheet
				Dim lo_BDCEntry					As iBxS_BDC_Entry						= so_CntlrNCO.Value.GetBDCTransactionEntry
				Dim lo_ExcelAddress			As iExcelAddress						=	New ExcelAddress
				Dim lo_BDCctu						As iBxS_BDC_CTUParameters		= so_CntlrNCO.Value.GetBDCCTU_Parameters
				Dim lo_SessionProfile		As iBxSBDCSession_Profile		= so_CntlrNCO.Value.GetSessionProfile()
				'..................................................
				Try

						lo_SessionProfile.SAPTCode		= "xSAPtor"	
						lo_SessionProfile.SessionName	= "xSAPtor"
						lo_SessionProfile.CTUParams		= lo_BDCctu

						lo_BDCEntry	= so_CntlrNCO.Value.GetBDCTransactionEntry

						lo_BDCEntry.Program_Name	= "xSAPtor"
						lo_BDCEntry.Dynpro_Number	= "0999"
						lo_BDCEntry.Dynpro_Begin	= "X"
	
						lo_SessionProfile.BDCDataList.Add(lo_BDCEntry)

						lo_BDCEntry	= so_CntlrNCO.Value.GetBDCTransactionEntry

						lo_BDCEntry.Field_Value		= "xSAPtor"
						lo_BDCEntry.Field_Name		= "xSAPtor"
						lo_BDCEntry.Field_Descr		= "xSAPtor"

						lo_SessionProfile.BDCDataList.Add(lo_BDCEntry)

						lc_XMLConfig		= Me.CreateXMLConfig(lo_SessionProfile)
						lo_BDCDataSheet	= New BDCDataSheet(	i_ExcelHelper		:= Me.co_ExcelHelper.Value,
																								i_ExcelAddrHndlr:= lo_ExcelAddress,
																								i_SessionProfile:= lo_SessionProfile,
																								i_XMLConfig			:= lc_XMLConfig)

						lb_ScrnUpd	=	Me.co_ExcelHelper.Value.GetSetScreenUpdating(False)

						lo_BDCDataSheet.Process()

						lb_Ret	= True

					Catch ex As Exception

					Finally

						Me.co_ExcelHelper.Value.GetSetScreenUpdating(lb_ScrnUpd)
						
				End Try
				'..................................................
				Return	lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Function CreateWSFromSessionAsync(ByVal i_PB	As IProgress(Of iPBarData)) _
															As Task(Of Integer) _
																Implements ixSessionController.CreateWSFromSessionAsync

				Dim lo_ExcelAddress	As iExcelAddress	= New ExcelAddress

				Dim lo_ProdCons			As iSessionWSPipeLineController
				Dim lt_Selection		As List(Of iSessionRequestDTO)
				Dim ln_Count				As Integer

				Me.co_CTS	= New CancellationTokenSource

				lt_Selection	= Me.co_SessionForm.GetSelectedList()
				If lt_Selection.Count.Equals(0)	Then	Return lt_Selection.Count

				lo_ProdCons	= New	SessionWSPipeLineController(	i_CntlrMain:=			Me.co_CntlrMain,
																												i_NCOController:=	Me.co_CntlrNCO.Value,
																												i_CancelToken:=		Me.co_CTS.Token,
																												i_PBar:=					i_PB)

				lo_ProdCons.Post(lt_Selection)
				lo_ProdCons.Complete()

				ln_Count	=	Await lo_ProdCons.StartupConsumersAsync(Me.FetchSessionOptions().ParallelProcesses)

				If ln_Count > 0

					' Create actual Excel Worksheets
					'
					Dim lb_ScrnUpd				As Boolean

					lb_ScrnUpd	=	Me.co_ExcelHelper.Value.GetSetScreenUpdating(NewSetting:= False)

					Do

						Dim lo_SessionProfile	As iBxSBDCSession_Profile	= Me.co_CntlrNCO.Value.GetSessionProfile()
						
						If lo_ProdCons.TryTakeProfile(lo_SessionProfile)

							Dim lc_XMLConfig		As String					= Me.CreateXMLConfig(i_SessionProfile:= lo_SessionProfile)

							Dim lo_BDCDataSheet	As iBDCDataSheet	=	New BDCDataSheet(	i_ExcelHelper		:= Me.co_ExcelHelper.Value,
																																				i_ExcelAddrHndlr:= lo_ExcelAddress,
																																				i_SessionProfile:= lo_SessionProfile,
																																				i_XMLConfig			:= lc_XMLConfig)

							lo_BDCDataSheet.Process()

						Else
							Exit Do
						End If

					Loop

					Me.co_ExcelHelper.Value.GetSetScreenUpdating(NewSetting:= lb_ScrnUpd)

				End If

				Me.co_CTS.Dispose()

				Return ln_Count

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Function CreateXMLConfig(ByVal i_SessionProfile As iBxSBDCSession_Profile) _
												As String

				Dim lo_BDCConfig	As iBDCConfiguration	= New BDCConfiguration

				lo_BDCConfig.SAPTCode								=	i_SessionProfile.SAPTCode
				lo_BDCConfig.Active_Column_Address	=	"$B$9"
				lo_BDCConfig.PauseTime							= 0
				lo_BDCConfig.IsActive								= "X"

				lo_BDCConfig.CTU_Parameters.DisMode	= i_SessionProfile.CTUParams.DisMode
				lo_BDCConfig.CTU_Parameters.UpdMode	= i_SessionProfile.CTUParams.UpdMode
				lo_BDCConfig.CTU_Parameters.DefSize	= i_SessionProfile.CTUParams.DefSize

				Return Me.ConfigToXMLString(i_BDCConfig:= lo_BDCConfig)

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Session: WSheet Template: Config"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetWorkSheetProfile(Optional ByVal WorkBookName   As String = "",
																					Optional ByVal WorkSheetName	As String = ""  ) _
												As iExcelWSProfileDTO _
													Implements ixSessionController.GetWorkSheetProfile

				Return Me.co_ExcelHelper.Value.GetExcelWSProfileDTO(WorkBookName	:= WorkBookName,
																														WorkSheetName	:= WorkSheetName)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function WriteBDCConfigToWSheet(ByVal i_Address   As String,
																						 ByVal i_BDCConfig As iBDCConfiguration) _
												As Boolean _
													Implements ixSessionController.WriteBDCConfigToWSheet

				Try

						' TO-DO: Get active WS from excelhelper
						'
						Dim lo_WS   As Excel.Worksheet	= CType(Globals.ThisAddIn.Application.ActiveSheet, Excel.Worksheet)
						Dim lo_Rng	As Excel.Range      = lo_WS.Range(i_Address)
				
						lo_Rng.Value		= Me.ConfigToXMLString(i_BDCConfig:= i_BDCConfig)
						lo_Rng.WrapText	= False

						Return True

					Catch ex As Exception
						Return False

				End Try

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function ConfigToXMLString(ByVal i_BDCConfig	As iBDCConfiguration) _
								As String _
									Implements ixSessionController.ConfigToXMLString

				Dim lo_WSServices As iWSServices  = WSServices.GetInstance()
				Dim lo_XMLCfg     As BDCXMLConfig	= New BDCXMLConfig
				
				lo_XMLCfg.IsActive        = i_BDCConfig.IsActive
				lo_XMLCfg.SAPTCode        = i_BDCConfig.SAPTCode
				lo_XMLCfg.Active_Column   = i_BDCConfig.Active_Column_Address
				lo_XMLCfg.Msg_Column			= i_BDCConfig.MessageColumnAddress
				lo_XMLCfg.PauseTime       = i_BDCConfig.PauseTime
				lo_XMLCfg.GUID						= i_BDCConfig.GUID
				lo_XMLCfg.SessionID				= i_BDCConfig.SessionID

				lo_XMLCfg.CTU_DisMode			= i_BDCConfig.CTU_Parameters.DisMode
				lo_XMLCfg.CTU_UpdMode			= i_BDCConfig.CTU_Parameters.UpdMode
				lo_XMLCfg.CTU_DefSize			= i_BDCConfig.CTU_Parameters.DefSize

				lo_XMLCfg.IsProtected			= i_BDCConfig.IsProtected
				lo_XMLCfg.Password				= i_BDCConfig.Password

				Return lo_WSServices.SerializeObject(lo_XMLCfg)

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Session: Selection"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function FetchSessionSelection() _
												As iSessionSelectionDTO _
													Implements ixSessionController.FetchSessionSelection

				Dim lo_Selection	As iSessionSelectionDTO	= New SessionSelectionDTO

				lo_Selection.UserName			= My.Settings.SAPSessionSelect_User
				lo_Selection.SessionName	= My.Settings.SAPSessionSelect_Name
				lo_Selection.DateFrom			= My.Settings.SAPSessionSelect_DateFrom
				lo_Selection.DateTo				= My.Settings.SAPSessionSelect_DateTo

				Return lo_Selection

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function SaveSessionSelection(ByVal i_Selection As iSessionSelectionDTO) _
												As Boolean _
													Implements ixSessionController.SaveSessionSelection

				Dim lb_Ret	As Boolean = True

				Try

						My.Settings.SAPSessionSelect_User			= i_Selection.UserName
						My.Settings.SAPSessionSelect_Name			= i_Selection.SessionName
						My.Settings.SAPSessionSelect_DateFrom	= i_Selection.DateFrom
						My.Settings.SAPSessionSelect_DateTo		= i_Selection.DateTo

						My.Settings.Save()

					Catch ex As Exception
						lb_Ret  = False
							
				End Try

				Return lb_Ret

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Session: Options"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function FetchSessionOptions() _
												As iSessionOptionsDTO _
													Implements ixSessionController.FetchSessionOptions

				Dim lo_Options	As iSessionOptionsDTO	= New SessionOptionsDTO

				lo_Options.OptimiseUpload			= My.Settings.SAPSessionOptions_OptimizeUpload
				lo_Options.SaveSelection			= My.Settings.SAPSessionOptions_SaveSelection
				lo_Options.ParallelProcesses	= My.Settings.SAPSessionOptions_ParallelProcesses

				Return lo_Options

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function SaveSessionOptions(ByVal i_Options As iSessionOptionsDTO) _
												As Boolean _
													Implements ixSessionController.SaveSessionOptions

				Dim lb_Ret  As Boolean = True

				Try

						My.Settings.SAPSessionOptions_OptimizeUpload		= i_Options.OptimiseUpload
						My.Settings.SAPSessionOptions_SaveSelection			= i_Options.SaveSelection
						My.Settings.SAPSessionOptions_ParallelProcesses	= i_Options.ParallelProcesses

						My.Settings.Save()

						so_MsgHub.Value.Publish(so_NotifyDTO.Value.Clone("Session Options Saved"))

					Catch ex As Exception
						lb_Ret  = False
							
				End Try

				Return lb_Ret

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	IsDestinationSet()	As Boolean _
																		Implements	ixSessionController.IsDestinationSet
				Get
					Return	Me.co_CntlrMain.DestinationSelected
				End Get
			End Property				
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend ReadOnly Property IsBusy()	As Boolean _
																					Implements ixSessionController.IsBusy 
				Get
					Return Me.cb_Busy
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Ribbon Event Handling"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub RibbonEventHandler(ByVal i_Tag As String) _
									Implements ixSessionController.RibbonEventHandler

				Select Case i_Tag
					Case "xtag_SessionSAP"        : Me.RibbonEventHandler_Session()
					Case "xtag_SessionOptions"    : Me.RibbonEventHandler_Options()
					Case "xtag_SessionConfigure"  : Me.RibbonEventHandler_Config()
					Case "xtag_SessionBlank"			: Me.RibbonEventHandler_Blank()
				End Select

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_Session()

				If Me.IsDestinationSet

					If Me.co_SessionForm Is Nothing OrElse
						 Me.co_SessionForm.IsDisposed()

							Me.co_SessionForm	= New xSAPSessions(Me)

					End If

					Me.co_SessionForm.HandleVisibility()

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_Options()

				If Me.co_SessionOptions Is Nothing OrElse
					 Me.co_SessionOptions.IsDisposed()

					 Me.co_SessionOptions	= xSAPSessionOptions.Create(Controller:= Me)

				End If

				Me.co_SessionOptions.HandleVisibility()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_Config()

				If Me.co_SessionConfig Is Nothing OrElse
					 Me.co_SessionConfig.IsDisposed()

					 Me.co_SessionConfig	= New xSAPBDCConfig(Me)
					
					If Me.co_SessionConfig.IsProtected
						Dim	lo_FormPwrd		As SAPSessionPwrd	= New SAPSessionPwrd(Me.co_SessionConfig.Password)
						If lo_FormPwrd.ShowDialog().Equals(Windows.Forms.DialogResult.Cancel)
							Me.co_SessionConfig	= Nothing
							Exit Sub
						End If
					End If

				End If

				Me.co_SessionConfig.HandleVisibility()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RibbonEventHandler_Blank()

				Me.CreateWSEmpty()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Defintions"

			Private							co_CntlrMain		As iBxSMainController

			Private	WithEvents	co_CntlrNCO			As	Lazy(Of ixNCOController) _
														= New Lazy(Of ixNCOController)(
																Function()	Me.co_CntlrMain.GetNCOController(),
																LazyThreadSafetyMode.ExecutionAndPublication )

			Private	WithEvents	co_ExcelHelper	As Lazy(Of iExcelHelper) _
														= New Lazy(Of iExcelHelper)(
																Function()	Me.co_CntlrMain.GetExcelHelper(),
																LazyThreadSafetyMode.ExecutionAndPublication )

			'Private WithEvents	co_CntrlNotify	As Lazy(Of iNotificationIconVM) _
			'											= New Lazy(Of iNotificationIconVM)(
			'													Function()	Me.co_CntlrMain.GetNotificationController(),
			'													LazyThreadSafetyMode.ExecutionAndPublication )

			Private co_SessionForm		As ixSAPSessions
			Private co_SessionOptions	As ixSAPSessionOptions
			Private co_SessionConfig	As ixSAPSessionConfig

			Private co_CTS						As CancellationTokenSource

			Private cb_Busy						As Boolean

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub	New(	ByVal	controllerMain		As iBxSMainController)

				Me.co_CntlrMain		= controllerMain

			End Sub

		#End Region

	End Class

End Namespace

