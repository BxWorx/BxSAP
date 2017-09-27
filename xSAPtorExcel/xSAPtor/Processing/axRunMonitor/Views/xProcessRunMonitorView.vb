Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles
Imports xSAPtorExcel.Utilities.DGV
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.RunMonitor

	Friend Class xProcessRunMonitorView
								Implements ixProcessRunMonitorView

		#Region "Definitions"

			Private WithEvents	co_RunMonitorVM		As ixProcessRunMonitorViewModel

			Private	co_Context		As SynchronizationContext
			Private	co_BSTaskList	As BindingSource
			Private	ct_TaskList		As List(Of ixProcessRunMonitorDTO)
			Private	cn_PBColIndex	As Integer

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Form Handling"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
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
			Private Sub EventHandler_Shutdown()

				Me.Close()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xProcessRunnerView_Load(sender	As Object,
																					e				As EventArgs) _
										Handles Me.Load

				Me.Configure_DGVLayout()

				Me.co_BSTaskList							= New BindingSource
				Me.co_BSTaskList.DataSource		=	Me.ct_TaskList
				Me.xdgv_Processing.DataSource	=	Me.co_BSTaskList

				Me.co_RunMonitorVM.ViewActive	= True

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xProcessRunnerView_Closing(sender	As Object,
																								e				As CancelEventArgs) _
										Handles Me.Closing

				RemoveHandler	co_RunMonitorVM.ev_ToggleVisibility,
											AddressOf	Me.HandleVisibility

				RemoveHandler	co_RunMonitorVM.ev_RefreshView,
											AddressOf Me.RefreshDisplay

				RemoveHandler	co_RunMonitorVM.ev_Shutdown,
											AddressOf	Me.EventHandler_Shutdown

				Me.co_RunMonitorVM.ViewActive	= False

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub ev_FormEscape(	sender	As Object,
																	e				As KeyEventArgs) _
										Handles Me.KeyDown

				If e.KeyCode.Equals(Keys.Escape)	Then	Me.Close()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub RefreshDisplay()

				Me.ct_TaskList.Clear()
				Me.ct_TaskList.AddRange(Me.co_RunMonitorVM.GetTaskList())

				Me.co_Context.Post(
					Sub()

						Me.xdgv_Processing.SuspendLayout()
						Me.co_BSTaskList.ResetBindings(False)
						Me.xdgv_Processing.ResumeLayout(False)

					End Sub,	Nothing )
		
			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Configure_DGVLayout()

				With Me.xdgv_Processing

					.AutoGenerateColumns	= False
					.AutoSize							= False
					.RowHeadersWidth	= 20

				End With
				'----------------------------------------------------
				Dim lo_ColBt As New xDGVImageButtonActionColumn

				With lo_ColBt
					.Name		= "Activate"
					.Width	= 20
				End With
				'----------------------------------------------------
				Dim lo_ColID		As New DataGridViewTextBoxColumn

				With lo_ColID
					.Name							= "GUID"
					.HeaderText				= "Unique ID"
					.DataPropertyName	= "GUID"
					.Width						= 100
				End With
				'----------------------------------------------------
				Dim lo_ColWB		As New DataGridViewTextBoxColumn

				With lo_ColWB
					.Name							= "Work Book"
					.DataPropertyName	= "WBookName"
					.Width						= 100
				End With
				'----------------------------------------------------
				Dim lo_ColWS		As New DataGridViewTextBoxColumn

				With lo_ColWS
					.Name							= "Work Sheet"
					.DataPropertyName	= "WSheetName"
					.Width						= 100
				End With
				'----------------------------------------------------
				Dim lo_ColPB	As New xdgvProgressColumn

				With lo_ColPB
					.Name							= "% Complete"
					.DataPropertyName	= "PercComplete"
					.Width						= 100
				End With
				'----------------------------------------------------
				Me.cn_PBColIndex	= Me.xdgv_Processing.Columns.Add(lo_ColBt)

				Me.xdgv_Processing.Columns.Add(lo_ColID)
				Me.xdgv_Processing.Columns.Add(lo_ColWB)
				Me.xdgv_Processing.Columns.Add(lo_ColWS)
				Me.xdgv_Processing.Columns.Add(lo_ColPB)

			End Sub
	
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors/Destructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Shared Function Create(ByVal RunMonitorViewModel As ixProcessRunMonitorViewModel) _
															As ixProcessRunMonitorView
			
				Return New xProcessRunMonitorView(i_RunnerVM:= RunMonitorViewModel)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_RunnerVM As ixProcessRunMonitorViewModel)

				InitializeComponent()

				Me.co_RunMonitorVM	= i_RunnerVM

				Me.co_Context				= SynchronizationContext.Current
				Me.ct_TaskList			= New List(Of ixProcessRunMonitorDTO)

				AddHandler	co_RunMonitorVM.ev_ToggleVisibility,
										AddressOf	Me.HandleVisibility

				AddHandler	co_RunMonitorVM.ev_RefreshView,
										AddressOf Me.RefreshDisplay

				AddHandler	co_RunMonitorVM.ev_Shutdown,
										AddressOf	Me.EventHandler_Shutdown

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯





		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		Private Sub xbtn_ts_Start_Click(sender As Object, e As EventArgs) Handles xbtn_ts_Start.Click

			Me.co_RunMonitorVM.Reset()

		End Sub

		Private Sub xdgv_Processing_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles xdgv_Processing.CellMouseEnter
			If e.ColumnIndex = Me.cn_PBColIndex
				SetGridButtonState(Me.xdgv_Processing,e.RowIndex,e.ColumnIndex,PushButtonState.Hot)
			End If
		End Sub

		Private Sub xdgv_Processing_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles xdgv_Processing.CellMouseLeave
			If e.ColumnIndex = Me.cn_PBColIndex
				SetGridButtonState(Me.xdgv_Processing,e.RowIndex,e.ColumnIndex,PushButtonState.Normal)
			End If
		End Sub



		Private Sub SetGridButtonState(dgv							As DataGridView,
																	 rowIndex					As Integer,
																	 columnIndex			As Integer,
																	 pushButtonState	As PushButtonState)

			If (rowIndex > -1) AndAlso (columnIndex > -1) Then
				If (dgv.Columns(columnIndex).[GetType]().Equals(GetType(xDGVImageButtonActionColumn)))

					Dim buttonCell As xDGVImageButtonCell	= DirectCast(dgv.Rows(rowIndex).Cells(columnIndex), xDGVImageButtonCell)

					If buttonCell.Enabled Then

						If buttonCell.ButtonState <> pushButtonState
							buttonCell.ButtonState = pushButtonState
						End If
					End If

				End If
			End If

		End Sub

	End Class

End Namespace