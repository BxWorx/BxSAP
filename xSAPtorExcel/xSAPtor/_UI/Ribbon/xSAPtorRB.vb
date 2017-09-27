Imports System.Threading
Imports System.Threading.Tasks

Imports Microsoft.Office.Tools.Ribbon

Imports xSAPtorExcel.Main.About
Imports xSAPtorExcel.Main.SAPLogon
Imports xSAPtorExcel.Main.Session
Imports xSAPtorExcel.Main.Services
Imports xSAPtorExcel.Main.Process.Controller

Imports xSAPtorExcel.UI
Imports xSAPtorExcel.Utilities.MsgHub
Imports System.IO
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Friend Class xSAPtorRB

	#Region "Definitions"

		Private	WithEvents	co_CntlrSAPLogon	As Lazy(Of ixSAPLogonController) _
													= New Lazy(Of ixSAPLogonController) _
																(	Function()	so_CntlrMain.Value.GetSAPLogonController(),
																							LazyThreadSafetyMode.ExecutionAndPublication )

		Private	WithEvents	co_CntlrSessions	As Lazy(Of ixSessionController) _
													= New Lazy(Of ixSessionController) _
																(	Function()	so_CntlrMain.Value.GetSessionController(),
																							LazyThreadSafetyMode.ExecutionAndPublication )

		Private	WithEvents	co_CntlrServices	As Lazy(Of ixServicesController) _
													= New Lazy(Of ixServicesController) _
																(	Function()	so_CntlrMain.Value.GetServicesController(),
																							LazyThreadSafetyMode.ExecutionAndPublication)

		Private	WithEvents	co_CntlrProcess		As Lazy(Of iBxSProcessController) _
													= New Lazy(Of iBxSProcessController) _
																(	Function()	so_CntlrMain.Value.GetProcessController(),
																							LazyThreadSafetyMode.ExecutionAndPublication )

		Private	WithEvents	co_CntlrSAPFav		As Lazy(Of iSAPFavoritesVM) _
													= New Lazy(Of iSAPFavoritesVM) _
																(	Function()	so_CntlrMain.Value.GetSAPFavouritesVM(),
																							LazyThreadSafetyMode.ExecutionAndPublication )
		'......................................................
		Private	co_SubSAPFavUpd		As	iSubscription(Of sMsgSAPFavUpd)

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Section: Favourites"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub eh_GroupSAPLogonFavSelect(	sender  As Object,
																						e       As RibbonControlEventArgs	) _
									Handles	xddn_SAPFavourites.SelectionChanged

			Dim lo_DDwn	= TryCast(sender, RibbonDropDown)

			If lo_DDwn Is Nothing	Then	Exit Sub
			'..................................................
			Me.ProcessSelectedFavItem()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub eh_GroupSAPLogonFavButton(	sender  As Object,
																						e       As RibbonControlEventArgs	) _
									Handles	xddn_SAPFavourites.ButtonClick

			Dim lo_Button = TryCast(sender, RibbonButton)

			If lo_Button Is Nothing	Then	Exit Sub
			'..................................................
			Select Case	lo_Button.Tag.ToString

					'................................................
			    Case "xtag_SAPFavDel"

						Dim lo_FavDTO	= Me.co_CntlrSAPFav.Value.GetSAPFavDTO(CInt(Me.xddn_SAPFavourites.SelectedItem.Tag))

						If	Me.co_CntlrSAPFav.Value.Deregister(lo_FavDTO)
							Me.LoadSAPFavouritesItems(Me.co_CntlrSAPFav.Value.FavouriteList())
						End If

					'................................................
					Case "xtag_SAPFavClr"

						Me.co_CntlrSAPFav.Value.Reset()
						Me.LoadSAPFavouritesItems(Me.co_CntlrSAPFav.Value.FavouriteList())

			End Select

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private	Sub	ProcessSelectedFavItem()

			Dim lo_FavDTO	= Me.co_CntlrSAPFav.Value.GetSAPFavDTO(CInt(Me.xddn_SAPFavourites.SelectedItem.Tag))
			'....................................................
			If Me.co_CntlrSAPLogon.Value.ActiveSystem <> lo_FavDTO.RfcDestID
				so_MsgHub.Value.Publish(lo_FavDTO)
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private	Sub	LoadSAPFavouritesItems(ByVal items	As	List(Of iSAPFavoriteDTO))

			Me.xddn_SAPFavourites.SuspendLayout

			Me.xddn_SAPFavourites.Items.Clear()

			For Each lo In items.Where( Function(p)

																		If	p.Client IsNot Nothing	AndAlso
																				p.Client.Length > 0
																			Return	True
																		Else
																			Return	False
																		End If

			                            End Function)

				Dim lo_DDI		= Me.Factory.CreateRibbonDropDownItem()

				lo_DDI.Label	= String.Format("{0}/{1}: {2}", lo.SystemID, lo.Client.ToString, lo.User)
				lo_DDI.Tag		= lo.SeqNo

				Me.xddn_SAPFavourites.Items.Add(lo_DDI)

			Next

			Me.xddn_SAPFavourites.ResumeLayout

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Event Handlers: Private"
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub GroupAboutHelp_EventHandler(sender  As Object,
																						e       As RibbonControlEventArgs	) _
										Handles xgal_About.Click

				Dim lo_RbnGallery As RibbonGallery  = TryCast(sender, RibbonGallery)

				If lo_RbnGallery IsNot Nothing

					Dim lo_CntlrAbout	As ixSAPAboutController	= so_CntlrMain.Value.GetAboutController()

					lo_CntlrAbout.RibbonEventHandler(lo_RbnGallery.SelectedItem.Tag.ToString)

				Else
				End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub GroupSAPLogon_EventHandler(	sender  As Object,
																						e       As RibbonControlEventArgs	) _
									Handles xbtn_SAPSelect.Click,
													xbtn_SAPConnect.Click

				Dim lo_Button As RibbonButton = TryCast(sender, RibbonButton)

				If lo_Button IsNot Nothing
					If lo_Button.Tag IsNot Nothing
						Me.co_CntlrSAPLogon.Value.RibbonEventHandler(lo_Button.Tag.ToString)
					End If
				End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub GroupSession_EventHandler(sender  As Object,
																					e       As RibbonControlEventArgs) _
									Handles xbtn_SessionOptions.Click		,
													xbtn_SessionConfigure.Click	,
													xbtn_SessionSelect.Click		,
													xbtn_SessionBlank.Click

				Dim lo_Button As RibbonButton = TryCast(sender, RibbonButton)

				If lo_Button IsNot Nothing
					Me.co_CntlrSessions.Value.RibbonEventHandler(lo_Button.Tag.ToString)
				End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub GroupServices_EventHandler(sender  As Object,
																						e       As RibbonControlEventArgs) _
									Handles xgal_Services.Click

			Dim lo_RbnGallery As RibbonGallery  = TryCast(sender, RibbonGallery)

			If lo_RbnGallery IsNot Nothing
				Me.co_CntlrServices.Value.RibbonEventHandler(lo_RbnGallery.SelectedItem.Tag.ToString)
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub GroupProcessing_EventHandler(sender  As Object,
																								e       As RibbonControlEventArgs) _
									Handles xbtn_BDCOptions.Click,
													xbtn_ProcessSelection.Click,
													xbtn_ProcessRunner.Click,
													xbtn_BDCTest.Click

			Dim lo_Button As RibbonButton = TryCast(sender, RibbonButton)

			If lo_Button IsNot Nothing
				Me.co_CntlrProcess.Value.RibbonEventHandler(lo_Button.Tag.ToString)
			End If

		End Sub
	
	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Message Handlers"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub mh_SAPSysSelected(ByVal _msg As sMsgSAPFavUpd)

			If Me.co_CntlrSAPFav.Value.Count > 0
				Me.LoadSAPFavouritesItems(Me.co_CntlrSAPFav.Value.FavouriteList())
			End If

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Constructor/Destructor: Methods/Events"
		
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xSAPtorRB_Close() _
									Handles MyBase.Close

			so_MsgHub.Value.Unsubscribe(Me.co_SubSAPFavUpd)

			Me.co_CntlrSAPFav.Value.Save()
			'....................................................
			so_MsgHub.Value.UnsubscribeAll()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xSAPtorRB_Load(ByVal sender As Object,
															 ByVal e      As RibbonUIEventArgs) _
									Handles MyBase.Load
			
			If Me.co_CntlrSAPFav.Value.Count > 0

				Me.LoadSAPFavouritesItems(Me.co_CntlrSAPFav.Value.FavouriteList())
				Me.ProcessSelectedFavItem()

			End If
			'....................................................
			Me.co_SubSAPFavUpd	= so_MsgHub.Value.Subscribe(Of sMsgSAPFavUpd)	(AddressOf	Me.mh_SAPSysSelected)

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "TO-DO"

	'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
	'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
	'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
	'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
	'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨

		'Private co_ExcelHelper As Lazy(Of iExcelHelper) = New Lazy(Of iExcelHelper)(Function() ExcelHelper.GetInstance())
		'Private co_cts As CancellationTokenSource

		'Private co_progressHandler As Action(Of iPBarData) = AddressOf Me.xPBarHandler
		'Private co_Progress As IProgress(Of iPBarData) = New Progress(Of iPBarData)(me.co_progressHandler)

	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯

	Private Async Sub xBtn_CntrlPnl_Create_Click(sender As Object, e As RibbonControlEventArgs) 

		'Me.xBtn_CntrlPnl_Create.Enabled = False
		Await Task.Run(Of Boolean)( Function()
																	'Globals.ThisAddIn.co_xSAPCntrlrProcess.Value.Process() 
																	Return True
																End Function)
		'Me.xBtn_CntrlPnl_Create.Enabled = True

	End Sub



	Private  Sub xbtn_Action_Click(sender As Object, e As RibbonControlEventArgs) 

		'Async

		'Dim lo_BDCWSheet As iWSProfile

		'If Me.co_ExcelHelper.Value.IsInEditMode
		'	Return
		'End If

		Try

			'Me.co_cts = New CancellationTokenSource


			Dim lb_Return As Boolean = False

			'lo_BDCWSheet = New WSProfile(i_WBName:=Me.co_ExcelHelper.Value.GetActiveWBookName(),
			'															i_WSIndex:= CUShort(Me.co_ExcelHelper.Value.GetActiveWSIndex()))

			'If Await lo_BDCWSheet.LoadAsync(i_Progress:=Me.co_Progress,
			'																i_ct:=Me.co_cts.Token)

			'	If Await lo_BDCWSheet.TransactionsAsync(i_Progress:=Me.co_Progress,
			'																					i_ct:=Me.co_cts.Token)

			'		For Each lo_tran In lo_BDCWSheet.BDCTransactions

						'Dim lo_CallTran As iBDCCallTransaction = BDCCallTransaction.Create(Globals.ThisAddIn.co_DestProfile.Value)

						'If Await lo_CallTran.InvokeAsync(i_BDCTransaction:=lo_tran, i_ct:=Me.co_cts.Token)
						'  Dim X = lo_CallTran.Messages
						'End If

			'		Next

			'		lb_Return = True
			'	End If

			'End If

		Catch ex As Exception
			Dim x = 1

		End Try

		'Me.co_cts = Nothing

	End Sub
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	Private Sub xBtn_Toggle_CTP_Click(sender As Object,
																		e As RibbonControlEventArgs) 

		' DO NOT DELETE !!!!!

		If Globals.ThisAddIn.Application.Workbooks.Count > 0
			'Globals.ThisAddIn.co_CTPHandler.Visible = TryCast(sender, RibbonToggleButton).Checked
		Else
			TryCast(sender, RibbonToggleButton).Checked = False
		End If

	End Sub

	Private Sub xbtn_SAPGUIConnect_Click(sender As Object, e As RibbonControlEventArgs) 

	End Sub
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯

	Private Sub handleStat(ByVal status As Boolean)

		If status
				Me.xbtn_SAPConnectStatus.Image = My.Resources.connect_icon
				'Me.co_CntlrNotify.Value.SendMessage("Connected to SAP")
			Else
				Me.xbtn_SAPConnectStatus.Image = My.Resources.disconnect_icon
				'Me.co_CntlrNotify.Value.SendMessage("Could NOT connect to SAP")
		End If

	End Sub

	Private Sub xbtn_SAPConnectStatus_Click(sender As Object, e As RibbonControlEventArgs) Handles xbtn_SAPConnectStatus.Click

		Dim lo_XML				As iSapGuiXmlModel						= New SAPGuiXmlModel
		Dim lo_Mod				As iLogonConnSetupModel	= New LogonConnSetupModel()
		Dim lo_ConnSetup	As iLogonConnSetupDTO		= lo_Mod.Fetch()

		Dim lc_Path = lo_ConnSetup.XML_Path
		Dim lc_File = lo_ConnSetup.XML_FileName
		Dim lc_Name	= Path.Combine(lc_Path, lc_File)

		Dim lo_tree	=	lo_XML.GetSapGuiXmlTree(lc_Name)

	End Sub

	#End Region

End Class




