Imports System.Threading
Imports System.Threading.Tasks

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports xSAPtorExcel.Services.UI
Imports xSAPtorExcel.Utilities.MsgHub
Imports xSAPtorExcel.Utilities
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Selection

	Friend Class xProcessSelectionView

		#Region "Definitions"

			Private WithEvents	co_VM	As ixProcessSelectionVM
			'....................................................
			Private co_BSTaskList		As BindingSource
			Private	co_Context			As SynchronizationContext

			Private ct_NodeList			As List(Of TreeNode)
			Private ct_TaskList			As List(Of ProcessViewTaskDTO)

			Private	cn_RowIndex			As Integer
			Private	cb_KeyCntrl			As Boolean
			Private	cb_Busy					As Boolean
			'....................................................
			<Flags>
			Private	Enum ce_TLBtn
								None	= 0
								Up		= 1
								Down	= 2
							  Exec	= 4
								PBar	= 8
								Canc	= 16
								Tree	= 32
								Msgs	= 64
							End Enum

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "ToolStrip: WB/WS Tree"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xbtn_ts_Reload_Click(sender As Object,
																				e			As EventArgs) _
										Handles	xbtn_TV_Reload.Click

				Me.ct_TaskList.Clear()
				Me.Refresh_TaskList_Display()
				Me.TaskListBtnContext()
				so_MsgHub.Value.Publish(New	sV2VMcmd(VVMCommands.RefreshTree))

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "ToolStrip: TaskList"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xbtn_TL_Cancel_Click(sender As Object, e As EventArgs) _
										Handles xbtn_TL_Cancel.Click

				Me.xbtn_TL_Cancel.Enabled	= False
				'..................................................
				so_MsgHub.Value.Publish(New sV2VMcmd(VVMCommands.CancelPost))

				

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub xbtn_TL_SubmitMsgs_Click(sender As Object, e As EventArgs) _
													Handles xbtn_TL_SubmitMsgs.Click

				Me.xbtn_TL_SubmitMsgs.Enabled	= False
				'..................................................
				With Me.xpbr_TL_Upload

					.Minimum	= 0
					.Maximum	= Me.ct_TaskList.Count
					.Value		= 0

				End With

				Me.TaskListBtnSet(ce_TLBtn.PBar	Or ce_TLBtn.Canc)
				'..................................................
				Await Task.Run(
					Sub()

						Dim lo_Cmd			=	New sV2VMcmd(VVMCommands.SubmitTaskMsgs)
						lo_Cmd.Payload	= New List(Of ProcessViewTaskDTO)(Me.ct_TaskList)
						so_MsgHub.Value.Publish(lo_Cmd)

					End Sub )

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub xbtn_TL_SubmitZDton_Click(sender As Object, e As EventArgs) _
													Handles xbtn_TL_SubmitZDton.Click

				With Me.xpbr_TL_Upload

					.Minimum	= 0
					.Maximum	= Me.ct_TaskList.Count
					.Value		= 0

				End With

				Me.TaskListBtnSet(ce_TLBtn.PBar	Or ce_TLBtn.Canc)
				'..................................................
				Await Task.Run(
					Sub()

						Dim lo_Cmd			=	New sV2VMcmd(VVMCommands.SubmitTaskZDTON)
						lo_Cmd.Payload	= New List(Of ProcessViewTaskDTO)(Me.ct_TaskList)
						so_MsgHub.Value.Publish(lo_Cmd)

					End Sub )

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xdgv_TaskList_KeyDown(sender As Object, e As KeyEventArgs) _
										Handles xdgv_TaskList.KeyDown

				If e.Control	Then	Me.cb_KeyCntrl	= True

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xdgv_TaskList_KeyUp(sender As Object, e As KeyEventArgs) _
										Handles xdgv_TaskList.KeyUp

				Me.cb_KeyCntrl	= False

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xbtn_TL_Up_Click(	sender	As Object,
																		e				As EventArgs) _
										Handles xbtn_TL_Up.Click

				Me.DoUpDownMove(i_Step:= -1)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xbtn_TL_Down_Click(	sender	As Object,
																			e				As EventArgs) _
										Handles xbtn_TL_Down.Click

				Me.DoUpDownMove(i_Step:= 1)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xdgv_TaskList_DragOver(sender As Object,
																				 e			As DragEventArgs) _
										Handles xdgv_TaskList.DragOver

				e.Effect = DragDropEffects.Move

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xdgv_TaskList_MouseDown(sender	As Object,
																					e				As MouseEventArgs) _
										Handles xdgv_TaskList.MouseDown

				If Me.cb_KeyCntrl									Then	Exit	Sub
				If e.Button <> MouseButtons.Left	Then	Exit	Sub
				'..................................................
				Me.cn_RowIndex	= -1
				Me.cn_RowIndex	= Me.xdgv_TaskList.HitTest(e.X,e.Y).RowIndex

				If Me.cn_RowIndex >= 0

					Me.xdgv_TaskList.Refresh()

					DoDragDrop(	Me.xdgv_TaskList.SelectedRows,
											DragDropEffects.Move)

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xdgv_TaskList_DragDrop(sender As Object, 
																				 e			As DragEventArgs) _
										Handles xdgv_TaskList.DragDrop

				Dim lo_Pt				As Point		= Me.xdgv_TaskList.PointToClient(New Point(e.X,e.Y))
				Dim ln_RowIndex	As Integer	= Me.xdgv_TaskList.HitTest(lo_Pt.X, lo_Pt.Y).RowIndex

				If ln_RowIndex <> Me.cn_RowIndex

					Me.SwopTasks(i_SrceIndx:= Me.cn_RowIndex,
											 i_TrgtIndx:=	ln_RowIndex)

					Me.Refresh_TaskList_Display()

				End If

			End Sub
		
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Form Handling"
		
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xProcessSelectionView_Load(sender	As Object,
																										e				As EventArgs) _
										Handles Me.Load

				Me.Configure_TaskListDGV()

				Me.co_BSTaskList            = New BindingSource
				Me.co_BSTaskList.DataSource = Me.ct_TaskList
				Me.xdgv_TaskList.DataSource = Me.co_BSTaskList

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xProcessSelectionView_Closing(sender	As Object,
																								e				As CancelEventArgs) _
										Handles Me.Closing

				so_MsgHub.Value.Unsubscribe(Me.co_SubVMCmd)
				'..................................................
				so_MsgHub.Value.Publish(New	sV2VMcmd(VVMCommands.CloseView))

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub ev_FormEscape(	sender	As Object,
																	e				As KeyEventArgs) _
										Handles Me.KeyDown

				If e.KeyCode.Equals(Keys.Escape)	Then	Me.Close()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "WB/WS Tree Control"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xtvw_WBOverview_AfterCheck(sender As Object,
																						 e			As TreeViewEventArgs) _
										Handles xtvw_WBOverview.AfterCheck

				If Not e.Action.Equals(TreeViewAction.ByKeyboard) AndAlso
					 Not e.Action.Equals(TreeViewAction.ByMouse)		Then	Exit Sub
				'..................................................
				If e.Node.GetNodeCount(False) > 0

					RemoveHandler	Me.xtvw_WBOverview.AfterCheck,
												AddressOf Me.xtvw_WBOverview_AfterCheck

					For Each ls_Node As TreeNode In e.Node.Nodes
						ls_Node.Checked = e.Node.Checked
					Next

					AddHandler	Me.xtvw_WBOverview.AfterCheck,
											AddressOf Me.xtvw_WBOverview_AfterCheck


				End If
				'..................................................
				so_MsgHub.Value.Publish(New sVM2Vcmd(VVMCommands.Treechecked))

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function GetTreeNodes(Optional	ByVal i_InclWBNodes		As Boolean	= False	,
																		Optional	ByVal i_InclWSNodes		As Boolean	= False	,
																		Optional  ByVal i_OnlyChecked		As Boolean	= False		)	_
												As List(Of TreeNode)

				Dim lt_Nodes	= New List(Of TreeNode)
				'..................................................
				If i_InclWBNodes
					
					lt_Nodes.AddRange(
						Me.xtvw_WBOverview.FlattenTree().Where(
							Function(lo_Node)
								If lo_Node.Parent Is Nothing
									Return True
								Else
									Return False
								End If
							End Function).ToList()
						)

				End If
				'..................................................
				If i_InclWSNodes

					lt_Nodes.AddRange(
						Me.xtvw_WBOverview.FlattenTree().Where(
							Function(lo_Node)

								Dim lb_Ret	As Boolean	= False

								If lo_Node.Parent IsNot Nothing
									If i_OnlyChecked
										If lo_Node.Checked
											lb_Ret	=	True
										End If
									Else
										lb_Ret	= True
									End If
								End If
								'..........................................
								Return	lb_Ret

							End Function).ToList()
						)

				End If
				'..................................................
				Return lt_Nodes

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Refresh_WBWSTree()

				Me.co_Context.Post(
					Sub()

						Me.xtvw_WBOverview.BeginUpdate()
						Me.xtvw_WBOverview.Nodes.Clear()
						Me.xtvw_WBOverview.Nodes.AddRange(Me.ct_NodeList.ToArray)
						Me.xtvw_WBOverview.ExpandAll()
						Me.xtvw_WBOverview.EndUpdate()

					End Sub,	Nothing )

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "TaskList Control"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub SyncWorklist()

				Dim lc_Tag				As	String
				Dim lt_Split			As	String()
				Dim	lt_Tasks			As	New List(Of ProcessViewTaskDTO)
				Dim	lt_Remove			As	New List(Of Integer)

				Dim lt_WSNodes	= Me.GetTreeNodes(i_InclWSNodes:= True, i_OnlyChecked:= True)
				'..................................................
				For Each lo In	lt_WSNodes

					lc_Tag	= lo.Tag.ToString.Replace("[WB]:", "")
					lc_Tag	= lc_Tag.Replace("[WS]:", "")
					lt_Split	= Split(lc_Tag, "~")

					Dim lo_Entry	= New	ProcessViewTaskDTO

					lo_Entry.WBName	= lt_Split(0)
					lo_Entry.WSName	= lt_Split(1)

					lt_Tasks.Add(lo_Entry)

				Next
				'..................................................
				Dim	ln_Idx		As Integer

				For Each	lo In Me.ct_TaskList

					ln_Idx	=	lt_Tasks.FindIndex(	Function(t) t.WBName.Equals(lo.WBName) AndAlso t.WSName.Equals(lo.WSName) )

					If ln_Idx >= 0
						lt_Tasks.RemoveAt(ln_Idx)
					Else
						ln_Idx	= Me.ct_TaskList.FindIndex(	Function(t) t.WBName.Equals(lo.WBName) AndAlso t.WSName.Equals(lo.WSName) )
						If ln_Idx >= 0
							lt_Remove.Add(ln_Idx)
						End If
					End If

				Next

				lt_Remove.Reverse()

				For Each ln In lt_Remove
					Me.ct_TaskList.RemoveAt(ln)
				Next

				Me.ct_TaskList.AddRange(lt_Tasks)
				'..................................................
				Me.Refresh_TaskList_Display()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub DoUpDownMove(ByVal i_Step As Integer)

				If Me.xdgv_TaskList.SelectedRows.Count	= 0	Then Return

				Dim lt_Index	As List(Of Integer)	= New List(Of Integer)
				Dim lt_NIndx	As List(Of Integer)	= New List(Of Integer)

				For Each lo_Item As DataGridViewRow In Me.xdgv_TaskList.SelectedRows

					lt_Index.Add(lo_Item.Index)
					lt_NIndx.Add(lo_Item.Index + i_Step)

				Next

				lt_Index.Sort()

				If i_Step < 0
					If lt_Index(0) = 0 Then Return
				Else
					lt_Index.Reverse()
					If lt_Index(0) >= (Me.xdgv_TaskList.RowCount - 1) Then Return
				End If

				For Each ln_Index As Integer In lt_Index
					Me.SwopTasks(i_SrceIndx:= ln_Index,
											 i_TrgtIndx:=	ln_Index + i_Step)
				Next
				'..................................................
				Me.Refresh_TaskList_Display(lt_NIndx)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub SwopTasks(ByVal i_SrceIndx	As Integer,
														ByVal i_TrgtIndx	As Integer)

				If i_SrceIndx < 0 OrElse i_TrgtIndx < 0 Then Return

				Dim lo_Task	= Me.ct_TaskList.Item(i_SrceIndx)

				Me.ct_TaskList.RemoveAt(i_SrceIndx)
				Me.ct_TaskList.Insert(i_TrgtIndx, lo_Task)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Refresh_TaskList_Display(Optional ByVal _selList	As List(Of Integer) = Nothing )

				Me.co_Context.Post(
					Sub()

							Me.xdgv_TaskList.SuspendLayout()
							Me.co_BSTaskList.ResetBindings(False)
							Me.xdgv_TaskList.ClearSelection()

							If _selList IsNot Nothing
								For Each ln_Index As Integer In _selList
									Me.xdgv_TaskList.Rows(ln_Index).Selected	= True
								Next
							End If

							Me.xdgv_TaskList.ResumeLayout(False)

					End Sub,	Nothing )

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub Configure_TaskListDGV()

				Dim lo_Col		As DataGridViewTextBoxColumn
				'..................................................
				With Me.xdgv_TaskList

					.AutoGenerateColumns	= False
					.AutoSize							= False
					.RowHeadersWidth	= 20

				End With
				'----------------------------------------------------
				lo_Col	=	New DataGridViewTextBoxColumn

				With lo_Col

					.Name							= "WorkbookName"
					.HeaderText				= "Work Book"
					.DataPropertyName	= "WBName"
					.AutoSizeMode			= DataGridViewAutoSizeColumnMode.DisplayedCells
					'.Width						= 150

				End With

				Me.xdgv_TaskList.Columns.Add(lo_Col)
				'----------------------------------------------------
				lo_Col	=	New DataGridViewTextBoxColumn

				With lo_Col

					.Name							= "WorksheetName"
					.HeaderText				= "Work Sheet"
					.DataPropertyName	= "WSName"
					.AutoSizeMode			= DataGridViewAutoSizeColumnMode.Fill

				End With

				Me.xdgv_TaskList.Columns.Add(lo_Col)

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor/Destruction: Methods & Events"

			Private	co_SubVMCmd		As	iSubscription(Of sVM2Vcmd)
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New()

				InitializeComponent()
				'..................................................
				Me.co_Context			= SynchronizationContext.Current
				Me.ct_NodeList		= New List(Of TreeNode)
				Me.ct_TaskList		= New List(Of ProcessViewTaskDTO)
				Me.cn_RowIndex		= -1
				Me.cb_KeyCntrl		= False
				'..................................................
				Me.co_SubVMCmd		= so_MsgHub.Value.Subscribe(Of	sVM2Vcmd)	(AddressOf Me.mh_VMCmds)
				
			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Message Handling"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub mh_VMCmds(ByVal _cmd	As sVM2Vcmd)

				Select Case	_cmd.Command

					Case	VVMCommands.RefreshTree		:	Me.mh_RefreshWBWSTree(_cmd)
					Case	VVMCommands.ProgressTask	: Me.mh_UpdateProgress(_cmd)
					Case	VVMCommands.Treechecked		: Me.mh_TreeChecked()

				End Select

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub mh_TreeChecked()

				Me.SyncWorklist()
				Me.TaskListBtnContext()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub mh_UpdateProgress(ByVal _cmd	As sVM2Vcmd)

				Dim lo_PBDTO	= CType(_cmd.Payload, iPBarData)
				'..................................................
				Me.co_Context.Post(
					Sub()

						If Me.xpbr_TL_Upload.Maximum <> lo_PBDTO.Total	Then	Me.xpbr_TL_Upload.Maximum	= lo_PBDTO.Total
						Me.xpbr_TL_Upload.Value	= lo_PBDTO.Complete

					End Sub ,
					Nothing )

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub mh_RefreshWBWSTree(ByVal _cmd	As sVM2Vcmd)

				Me.ct_NodeList.Clear()
				Me.ct_NodeList.AddRange(CType(_cmd.Payload, List(Of TreeNode)))
				Me.Refresh_WBWSTree()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub TaskListBtnContext()

				If			Me.ct_TaskList.Count.Equals(0)	:	Me.TaskListBtnSet(ce_TLBtn.Tree)
				ElseIf  Me.ct_TaskList.Count.Equals(1)	: Me.TaskListBtnSet(ce_TLBtn.Tree Or ce_TLBtn.Exec	Or ce_TLBtn.Msgs)
				Else																			Me.TaskListBtnSet(ce_TLBtn.Tree Or ce_TLBtn.Up Or ce_TLBtn.Down Or ce_TLBtn.Exec Or ce_TLBtn.Msgs)
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub TaskListBtnSet(ByVal _btn	As ce_TLBtn)

				Me.co_Context.Post(
					Sub()

						Me.xbtn_TV_Reload.Visible				= _btn.HasFlag(ce_TLBtn.Tree)

						Me.xbtn_TL_Up.Visible						= _btn.HasFlag(ce_TLBtn.Up)
						Me.xbtn_TL_Down.Visible					= _btn.HasFlag(ce_TLBtn.Down)
						Me.xbtn_TL_SubmitZDton.Visible	= _btn.HasFlag(ce_TLBtn.Exec)
						Me.xpbr_TL_Upload.Visible				= _btn.HasFlag(ce_TLBtn.PBar)
						Me.xbtn_TL_Cancel.Visible				= _btn.HasFlag(ce_TLBtn.Canc)
						Me.xbtn_TL_SubmitMsgs.Visible		= _btn.HasFlag(ce_TLBtn.Msgs)

					End Sub,	Nothing )

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "TO-DO:"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub xbtn_TL_SubmitRunner_Click(sender As Object, e As EventArgs) _
										Handles xbtn_TL_SubmitRunner.Click

					Await Task.Run(
						Sub()

							'Dim lo_Cmd			=	New sV2VMcmd(VVMCommands.SubmitTaskRunner)
							'lo_Cmd.Payload	= Me.ct_TaskList

							'so_MsgHub.Value.Publish(lo_Cmd)

					  End Sub )

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub EventHandler_UpdateTaskList()
			'_
			'							Handles Me.ev_WBWSSelectionChanged

				Await Task.Run(
					(	Sub()
				    End Sub)
					).ConfigureAwait(False)


				'Await Task.Run(
				'	Sub()

				'		Dim lt_TasksNew							= New List(Of ixProcessTask)
				'		Dim lt_Split		As String() = Nothing
				'		Dim ln_Index		As Integer	= 0
				'		Dim lc_Tag			As String		= Nothing

				'		For Each ls_Entry As ixProcessTask In Me.ct_TaskList
				'			ls_Entry.Checked = False
				'		Next

				'		For Each ls_Node As TreeNode In	Me.GetCheckedWSTreeNodes()

				'			lc_Tag	= ls_Node.Tag.ToString.Replace("[WB]:", "")
				'			lc_Tag	= lc_Tag.Replace("[WS]:", "")

				'			lt_Split	= Split(lc_Tag, "~")

				'			Dim lo_Task	As ixProcessTask	= Me.ct_TaskList.Find(
				'																				Function(i_Task)
				'																						If i_Task.WorkbookName.Equals(lt_Split(0))	AndAlso
				'																							 i_Task.WorksheetName.Equals(lt_Split(1))
				'																							Return True
				'																						Else
				'																							Return False
				'																						End If
				'																				End Function)

				'			If lo_Task Is Nothing

				'				lo_Task	= xProcessTask.Create()

				'				lo_Task.WorkbookName	= lt_Split(0)
				'				lo_Task.WorksheetName	= lt_Split(1)
				'				lo_Task.Synced				= False
				'				lo_Task.Checked				= True

				'				lt_TasksNew.Add(lo_Task)		

				'			Else

				'				ln_Index									= Me.ct_TaskList.IndexOf(lo_Task)
				'				lo_Task.Checked						= True
				'				Me.ct_TaskList(ln_Index)	= lo_Task

				'			End If

				'		Next

				'		' Remove/Add items
				'		'
				'		Me.ct_TaskList.RemoveAll( Function(i_Task) i_Task.Checked = False )
				'		Me.ct_TaskList.AddRange(lt_TasksNew)

				'		' update DGV list
				'		'
				'		Me.Refresh_TaskList_Display(FireEvent:= True)

					'End Sub)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub EventHandler_SyncTaskList()
			'_
			'							Handles Me.ev_TaskListChanged

				Await Task.Run(
					(	Sub()
				    End Sub)
					).ConfigureAwait(False)

				'Await Task.Run(
				'	Sub()

				'		Dim lb_Update	As Boolean	= False
				'		Dim ln_Index	As Integer	= -1

				'		For Each lo_Task As ixProcessTask In Me.ct_TaskList.Where( Function(lo_TaskFilter) lo_TaskFilter.Synced = False )

				'			lb_Update	= True
				'			ln_Index	= Me.ct_TaskList.IndexOf(lo_Task)

				'			lo_Task.Synced		= True
				'			lo_Task.Profile		= Me.co_SelectionVM.GetWorkSheetProfile(WorkBookName := lo_Task.WorkbookName,
				'																																WorkSheetName:= lo_Task.WorksheetName)
				'			lo_Task.SAPTCode	= lo_Task.Profile.BDCConfig.SAPTCode
				'			lo_Task.GUID			= lo_Task.Profile.BDCConfig.GUID
				'			lo_Task.TranCount	= 100	' TO-DO: remove (testing only)

				'		Next

				'		' update DGV list
				'		'
				'		If lb_Update
				'			Me.Refresh_TaskList_Display()
				'		End If

				'	End Sub)

			End Sub

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub RefreshNodes()

				Return

				Await Task.Run(
					Sub()

						Dim lt_OpenNodeList	= Me.co_VM.GetOpenWBWSHierarchy.Nodes
						Dim lt_WBNodeList		= Me.GetTreeNodes(i_InclWBNodes:= True)
						Dim lt_WSNodeList		= Me.GetTreeNodes(i_InclWSNodes:= True)

						Dim lo_NodeSrce	As TreeNode
						Dim lo_NodeP		As TreeNode
						Dim lo_NodeC		As TreeNode


						Me.ct_NodeList.Clear()

						For Each lo_WBNode	As TreeNode	In lt_OpenNodeList

							lo_NodeSrce	=	lt_WBNodeList.Find( Function(lo_Node)	lo_Node.Tag.ToString.Equals(lo_WBNode.Tag.ToString) )

							If lo_NodeSrce Is Nothing
								Me.ct_NodeList.Add(lo_WBNode)
							Else

								lo_NodeP	= TryCast( lo_NodeSrce.Clone(), TreeNode )
								
								If lo_NodeP	IsNot Nothing

									lo_NodeP.Nodes.Clear()

									For Each lo_WSNode As TreeNode In lo_WBNode.Nodes

										lo_NodeSrce	= lt_WSNodeList.Find( Function(lo_Node) lo_Node.Tag.ToString.Equals( lo_WSNode.Tag.ToString) )

										If lo_NodeSrce Is Nothing
											lo_NodeP.Nodes.Add(lo_WSNode)
										Else

											lo_NodeC	= TryCast( lo_NodeSrce.Clone(), TreeNode )
											lo_NodeP.Nodes.Add(lo_NodeC)

										End If

									Next

									Me.ct_NodeList.Add(lo_NodeP)

								End If

							End If

						Next

						Me.Refresh_WBWSTree()

					End Sub)

			End Sub



			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Sub xbtn_ts_SubmitTasks_Click(sender	As Object,
																									e				As EventArgs) _
										
				Await Task.Run(
					(	Sub()

				'			For Each lo_Task As ixProcessTask	In Me.ct_TaskList

				'				If Me.co_SelectionVM.SubmitTask(TaskRequest:= lo_Task)
				'				Else
				'				End If

				'			Next

				    End Sub)
					).ConfigureAwait(False)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub xbtn_ts_Refresh_Click(sender	As Object,
																				e				As EventArgs) _
										Handles xbtn_tl_Refresh.Click

					Me.RefreshNodes()
			
			End Sub

		#End Region

	End Class

End Namespace

