Imports System.Threading
Imports System.Windows.Forms
Imports xSAPtorExcel.Main.Session
Imports xSAPtorExcel.Services.UI

Imports BxS.API.BDC
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Friend Class xSAPSessions
							Implements ixSAPSessions

	#Region "Definitions"

		Private WithEvents co_Cntlr	As ixSessionController

		Private co_cts							As CancellationTokenSource
		Private co_Context					As SynchronizationContext
		Private co_BSSessions				As BindingSource
		Private co_Selection				As iSessionSelectionDTO

		Private cb_SaveSelection		As Boolean
		Private cb_Busy							As Boolean

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods: My.Event Handling"

		Private Event ev_IsBusy()

		Private				cc_ActiveTaskID		As String
		Private				cc_ActiveTaskDesc	As String
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub ev_IsBusy_EventHandler() _
									Handles Me.ev_IsBusy

			Me.xtss_lbl_Status.Text = String.Format("Process {0} is busy...", Me.cc_ActiveTaskDesc)

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Process: Cancel"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xbtn_tss_Cancel_Click(sender	As Object,
																			e				As EventArgs) _
									Handles xbtn_tss_Cancel.Click

			If Me.co_cts IsNot Nothing
				Me.co_cts.Cancel()
			End If

		End Sub
	
	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Process: Session Reset"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xbtn_tss_ResetSelection_Click(sender  As Object,
																							e       As EventArgs) _
									Handles xbtn_tss_ResetSelection.Click

			If Me.CanExecute()
				Me.Reset()
				Me.ct_SessionList.Value.Clear()
				RaiseEvent ev_DGVSessionListChanged(Nothing, Nothing)
			End If

		End Sub
	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Process: Session Templates"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Async Sub xbtn_tss_CreateWS_Click(sender  As Object,
																							e       As EventArgs) _
												Handles xbtn_tss_CreateWS.Click

			If Not Me.CanExecute() Then Exit Sub
		
			Dim ln_Count						As Integer
			Dim lo_progressHandler	As Action(Of iPBarData)     = AddressOf Me.xPBarHandler
			Dim lo_Progress					As iProgress(Of iPBarData)	= New Progress(Of iPBarData)(lo_progressHandler)

			Me.cb_Busy								= True
			Me.co_cts									= New CancellationTokenSource
			Me.xpbr_tss_PBar.Value		= 0
			Me.BusyStatus()

			Try

					ln_Count	= Await Me.co_Cntlr.CreateWSFromSessionAsync(i_PB:= lo_Progress).ConfigureAwait(continueOnCapturedContext:= False)

				Catch ex As Exception

			End Try

			Me.co_Context.Post(
				Sub()

					Me.xtss_lbl_Status.Text = String.Format("{0} Session profiles processed...", ln_Count)
					Me.cb_Busy	= False
					Me.BusyStatus()

				End Sub, Nothing )

			Me.co_cts = Nothing

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Function GetSelectedList() _
											As List(Of iSessionRequestDTO) _
												Implements ixSAPSessions.GetSelectedList

			Dim ln_ColIdxQID  As Integer												= Me.xdgv_Sessions.Columns("QID").Index
			Dim ln_ColIdxSNme As Integer												= Me.xdgv_Sessions.Columns("SESSIONNAME").Index
			Dim lt_Requests		As List(Of iSessionRequestDTO) = New List(Of iSessionRequestDTO)


			For Each lo_Row As DataGridViewRow In Me.xdgv_Sessions.SelectedRows

				Dim lo_Request As iSessionRequestDTO = New SessionRequestDTO

				lo_Request.QID          = lo_Row.Cells(ln_ColIdxQID).FormattedValue.ToString()
				lo_Request.SessionName  = lo_Row.Cells(ln_ColIdxSNme).FormattedValue.ToString()

				lt_Requests.Add(lo_Request)

			Next

			Return lt_Requests

		End Function

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Process: Session List"

		Private ct_SessionList	As Lazy( Of List(Of iBxSBDCSession_Header) )	= New Lazy( Of List(Of iBxSBDCSession_Header) )

		Private Event ev_DGVSessionListChanged	As EventHandler
		
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Async Sub xbtn_tss_FetchSAP_Click(sender  As Object,
																							e       As EventArgs) _
												Handles xbtn_tss_FetchSAP.Click

			Dim lt_List	As List(Of iBxSBDCSession_Header)

			If Not Me.CanExecute()
				Exit Sub
			End If

			If Not Me.co_Cntlr.IsDestinationSet()
				Exit Sub
			End If

			Me.cb_Busy	= True
			Me.co_cts		= New CancellationTokenSource

			Me.BusyStatus()
			Me.ct_SessionList.Value.Clear()

			lt_List = Await Me.co_Cntlr.GetSessionListAsync(	i_UserId:=			Me.xtbx_UserName.Text.Trim,
																												i_SessionName:=	Me.xtbx_SessionID.Text.Trim,
																												i_DateFrom:=		Me.xdtp_From.Value,
																												i_DateTo:=			Me.xdtp_To.Value	)

			If lt_List.Count > 0
				Me.ct_SessionList.Value.AddRange( lt_List	)
			End If

			Me.co_Context.Post( Sub()	RaiseEvent	ev_DGVSessionListChanged(Nothing, Nothing),
																						Nothing )
			Me.co_cts = Nothing

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub ev_DGVSessionListChanged_EventHandler() _
									Handles Me.ev_DGVSessionListChanged

			Me.co_BSSessions.ResetBindings(False)
			Me.xdgv_Sessions.Refresh
			
			Me.xtss_lbl_Status.Text = String.Format("{0} Rows collected...", Me.ct_SessionList.Value.Count)
			Me.cb_Busy	= False
			Me.BusyStatus()

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods: Private"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xPBarHandler(ByVal i_PBarData As iPBarData)

			Me.co_Context.Post(
				Sub()
					If i_PBarData.Complete = 0 Or i_PBarData.Total = 0
						Me.xpbr_tss_PBar.Value = 0
					Else
						Me.xpbr_tss_PBar.Value = CInt((i_PBarData.Complete / i_PBarData.Total) * 100)
					End If
				End Sub,  Nothing)
		
		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub Reset()

			Dim ld_From As DateTime = Today.AddDays(-200)

			Me.xtbx_SessionID.Clear()
			Me.xtbx_UserName.Clear()
			Me.xdtp_From.Value = New Date(ld_From.Year, ld_From.Month, ld_From.Day)
			Me.xdtp_To.ResetText()

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Function CanExecute() _
											As Boolean

			Dim lb_Ret	As Boolean = False

			If Me.cb_Busy OrElse Me.co_Cntlr.IsBusy
				RaiseEvent ev_IsBusy()
			Else
				lb_Ret	= True
			End If

			Return lb_Ret

		End Function

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Methods: Form Handling"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub BusyStatus()

			Me.xbtn_tss_ResetSelection.Enabled	= Not Me.cb_Busy
			Me.xbtn_tss_FetchSAP.Enabled				= Not Me.cb_Busy
			Me.xbtn_tss_CreateWS.Enabled				= Not Me.cb_Busy

			Me.xbtn_tss_Cancel.Enabled					= Me.cb_Busy
			Me.xbtn_tss_Cancel.Visible					= Me.cb_Busy

			Me.xpbr_tss_PBar.Visible						= Me.cb_Busy

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Overloads ReadOnly Property IsDisposed() _
							As Boolean _
								Implements ixSAPSessions.IsDisposed
			Get
				Return MyBase.IsDisposed()
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Sub HandleVisibility() _
								Implements ixSAPSessions.HandleVisibility

			If Me.Visible
				If Me.WindowState = FormWindowState.Minimized
					Me.WindowState = FormWindowState.Normal
				Else
					Me.Hide()
				End If
			Else
				Me.Show()
			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xSAPtorSessions_Load(sender As Object,
																		 e      As EventArgs) _
									Handles Me.Load

			Me.Reset()

			Me.cb_SaveSelection	= Me.co_Cntlr.FetchSessionOptions().SaveSelection

			If Me.cb_SaveSelection

				Me.co_Selection					= Me.co_Cntlr.FetchSessionSelection()

				Me.xtbx_UserName.Text		= Me.co_Selection.UserName
				Me.xtbx_SessionID.Text	= Me.co_Selection.SessionName
				Me.xdtp_From.Value			= Me.co_Selection.DateFrom
				Me.xdtp_To.Value				= Me.co_Selection.DateTo

			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub xSAPtorSessions_Closing(sender As Object,
																				e      As EventArgs) _
									Handles Me.Closing

			If Me.cb_SaveSelection

				Me.co_Selection.UserName		= Me.xtbx_UserName.Text.Trim
				Me.co_Selection.SessionName	= Me.xtbx_SessionID.Text.Trim
				Me.co_Selection.DateFrom		= Me.xdtp_From.Value
				Me.co_Selection.DateTo			= Me.xdtp_To.Value

				Me.co_Cntlr.SaveSessionSelection(i_Selection:= Me.co_Selection)

			End If

		End Sub
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Sub ev_FormEscape(	sender	As Object,
																e				As KeyEventArgs) _
									Handles Me.KeyDown

			If e.KeyCode.Equals(Keys.Escape)	Then	Me.Close()

		End Sub

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Constructors/Destructors"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Friend Sub New(ByVal i_Controller As ixSessionController)

			InitializeComponent()

			Me.cb_Busy                  = False
			Me.co_Context               = SynchronizationContext.Current
			Me.co_BSSessions            = New BindingSource
			Me.co_BSSessions.DataSource = Me.ct_SessionList.Value
			Me.xdgv_Sessions.DataSource = Me.co_BSSessions

			Me.co_Cntlr									= i_Controller

		End Sub

	#End Region

End Class
