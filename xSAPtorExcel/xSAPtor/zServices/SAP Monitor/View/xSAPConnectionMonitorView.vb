Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Services.DestinationMonitor

	Friend Class xSAPConnectionMonitorView
								Implements ixSAPConnectionMonitorView

		#Region "Definitions"

			Private WithEvents	co_VM										As ixSAPDestMonitorViewModel
			Private Event				ev_DGVDataSourceChanged As EventHandler

			Private co_Context				As SynchronizationContext
			Private co_BSConnMonitor	As BindingSource
			Private ct_ConnList				As List(Of ixSAPDestMonitorDTO)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Events"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xbtn_ts_Refresh_Click(sender  As Object,
																				e       As EventArgs) _
													Handles xbtn_ts_Refresh.Click

				Me.co_VM.Refresh()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Form Handling"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xSAPConnectionMonitorView_Load(sender As Object,
																											 e      As EventArgs) _
													Handles Me.Load

				Me.Configure_DGVLayout()

				Me.co_BSConnMonitor							= New BindingSource
				Me.co_BSConnMonitor.DataSource	= Me.ct_ConnList
				Me.xdgv_ConnMonitor.DataSource	= Me.co_BSConnMonitor

				Me.co_VM.ViewActive	=	True
				Me.xcbx_RefreshDelay.Text		= Me.co_VM.RefreshRate().ToString

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xSAPConnectionMonitorView_Closing(sender	As Object,
																										e				As CancelEventArgs) _
										Handles Me.Closing

				RemoveHandler	co_VM.ev_ToggleViewVisibility,
											AddressOf	Me.HandleVisibility

				RemoveHandler	co_VM.ev_ShutdownView,
											AddressOf	Me.Shutdown

				Me.co_VM.ViewActive	= False

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub HandleVisibility()

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
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Shutdown()

				Me.Close()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub ev_FormEscape(	sender	As Object,
																	e				As KeyEventArgs) _
										Handles Me.KeyDown

				If e.KeyCode.Equals(Keys.Escape)	Then	Me.Close()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xcbx_RefreshDelay_TextChanged(sender  As Object,
																								e       As EventArgs) _
										Handles xcbx_RefreshDelay.TextChanged

				If Me.co_VM IsNot Nothing
					Me.co_VM.RefreshRate	= CUInt(Me.xcbx_RefreshDelay.Text)
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RefreshDisplay()

				Me.ct_ConnList.Clear()
				Me.ct_ConnList.AddRange(Me.co_VM.GetMonitorList())

				Try

						Me.co_Context.Post(
							Sub()

								Me.xdgv_ConnMonitor.SuspendLayout()
								Me.co_BSConnMonitor.ResetBindings(False)
								Me.xdgv_ConnMonitor.ResumeLayout(False)

							End Sub,	Nothing )

					Catch ex As Exception

				End Try

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Configure_DGVLayout()

				With Me.xdgv_ConnMonitor

					.AutoGenerateColumns	= False
					.AutoSize							= False
					.RowHeadersWidth	= 20

				End With
				'----------------------------------------------------
				Dim lo_ColID			As New DataGridViewTextBoxColumn

				With lo_ColID
					.Name							= "ID"
					.HeaderText				= "ID"
					.DataPropertyName	= "ConversationID"
					.Width						= 120
				End With
				'----------------------------------------------------
				Dim lo_ColState		As New DataGridViewTextBoxColumn

				With lo_ColState
					.Name							= "STATE"
					.HeaderText				= "State"
					.DataPropertyName	= "State"
					.Width						= 100
				End With
				'----------------------------------------------------
				Dim lo_ColSysID		As New DataGridViewTextBoxColumn

				With lo_ColSysID
					.Name							= "SYSID"
					.HeaderText				= "System"
					.DataPropertyName	= "SystemID"
					.Width						= 100
				End With
				'----------------------------------------------------
				Dim lo_ColUser 		As New DataGridViewTextBoxColumn

				With lo_ColUser
					.Name							= "USER"
					.HeaderText				= "User"
					.DataPropertyName	= "User"
					.Width						= 100
				End With
				'----------------------------------------------------
				Dim lo_ColClient	As New DataGridViewTextBoxColumn

				With lo_ColClient
					.Name							= "CLIENT"
					.HeaderText				= "Client"
					.DataPropertyName	= "Client"
					.Width						= 100
				End With
				'----------------------------------------------------
				Dim lo_ColFnc  		As New DataGridViewTextBoxColumn

				With lo_ColFnc
					.Name							= "FNC"
					.HeaderText				= "Function"
					.DataPropertyName	= "FncModuleName"
					.Width						= 200
				End With
				'----------------------------------------------------
				Me.xdgv_ConnMonitor.Columns.Add(lo_ColID)
				Me.xdgv_ConnMonitor.Columns.Add(lo_ColState)
				Me.xdgv_ConnMonitor.Columns.Add(lo_ColSysID)
				Me.xdgv_ConnMonitor.Columns.Add(lo_ColUser)
				Me.xdgv_ConnMonitor.Columns.Add(lo_ColClient)
				Me.xdgv_ConnMonitor.Columns.Add(lo_ColFnc)

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors/Constructor Events; Destructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(ByVal i_VM As ixSAPDestMonitorViewModel)

				InitializeComponent()

				Me.co_VM	= i_VM

				Me.co_Context		= SynchronizationContext.Current
				Me.ct_ConnList	= New List(Of ixSAPDestMonitorDTO)

				AddHandler	co_VM.ev_ToggleViewVisibility,
										AddressOf	Me.HandleVisibility

				AddHandler	co_VM.ev_RefreshView,
										AddressOf Me.RefreshDisplay

				AddHandler	co_VM.ev_ShutdownView,
										AddressOf	Me.Shutdown

			End Sub

		#End Region

	End Class

End Namespace