Imports xSAPtorExcel.Main.BDCProcessing
Imports xSAPtorExcel.Services.Excel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Process.Runner

	Friend Class xProcessMessageHandler
								Implements ixProcessMessageHandler

		#Region "Definitions"

			Private ct_Msgs				As Dictionary(Of Integer, String)
			Private ct_MsgBlocks	As List(Of MessageBlock)
			Private cc_WBName			As String
			Private cc_WSName			As String
			Private cc_MsgColID		As String

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub Update() _
									Implements ixProcessMessageHandler.Update

				Me.CreateMessageBlocks()
				Me.UpdateWorkSheet()

				Me.Reset()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Overloads Sub LoadMessages(ByVal WSProfile As iBDCWSProfile) _
														Implements ixProcessMessageHandler.LoadMessages

				For Each ls_Entry	In WSProfile.BDCMessages

					Dim lt_Msgs	As New List(Of String)

					For Each lo_BDCMsg In ls_Entry.Value
						lt_Msgs.Add(item:= lo_BDCMsg.LongText)
					Next

					If lt_Msgs.Count > 0
						Me.LoadMessages(ExcelRow:= ls_Entry.Key,
														Messages:= lt_Msgs)
					End If

				Next

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Overloads Sub LoadMessages(ByVal ExcelRow	As Integer,
																				ByVal Messages	As List(Of String)) _
														Implements ixProcessMessageHandler.LoadMessages

				Dim lc_MsgSrce	As String	= ""

				For Each lc_Msg	In Messages.Where( Function(Msg) Msg.Length > 0)
					If lc_MsgSrce.Length	= 0
						lc_MsgSrce	= lc_Msg
					Else
						lc_MsgSrce	= String.Concat(lc_MsgSrce, ";", lc_Msg)
					End If
				Next

				If lc_MsgSrce.Length > 0
					Me.LoadMessages(ExcelRow:= ExcelRow,
													Message	:= lc_MsgSrce)
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Overloads Sub LoadMessages(ByVal ExcelRow	As Integer,
																				ByVal Message		As String) _
														Implements ixProcessMessageHandler.LoadMessages
			
				If Me.ct_Msgs.ContainsKey(key:= ExcelRow)
					Me.ct_Msgs.Item(key:= ExcelRow)	= Message
				Else
					Me.ct_Msgs.Add(key	:= ExcelRow, 
												 value:= Message)
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub Reset() _
									Implements ixProcessMessageHandler.Reset

				Me.ct_Msgs.Clear()
				Me.ct_MsgBlocks.Clear()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub CreateMessageBlocks()

				Dim ln_KeyCur		As Integer
				Dim ln_KeyNxt		As Integer
				Dim ln_IndxSrce	As Integer
				Dim lb_More			As Boolean

				Dim lt_KeysSrce	As List(Of Integer)
				Dim lt_KeysBlck	As List(Of Integer)

				Me.ct_MsgBlocks.Clear()
				If Me.ct_Msgs.Count = 0
					Return
				Else
					lb_More	= True
				End If

				lt_KeysSrce	= Me.ct_Msgs.Keys.ToList()
				lt_KeysSrce.Sort()

				ln_IndxSrce	= 0
				ln_KeyCur		= lt_KeysSrce(ln_IndxSrce)

				Do

					lt_KeysBlck	= New List(Of Integer)
					
					Do

						lt_KeysBlck.Add(ln_KeyCur)
						ln_IndxSrce	+= 1

						If ln_IndxSrce >= lt_KeysSrce.Count

							lb_More	= False
							Exit Do

						Else

							ln_KeyNxt = ln_KeyCur + 1
							ln_KeyCur	= lt_KeysSrce(ln_IndxSrce)

							If ln_KeyCur <> ln_KeyNxt
								Exit Do
							End If

						End If

					Loop

					Dim lo_Msg = New MessageBlock(ExcelStartRow:= lt_KeysBlck(0),
																				BlockSize		 := lt_KeysBlck.Count)

					For Each ln_Indx In lt_KeysBlck
						lo_Msg.AddMessage(Msg:= Me.ct_Msgs(ln_Indx))
					Next

					Me.ct_MsgBlocks.Add(lo_Msg)

				Loop While lb_More

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub UpdateWorkSheet()

				Dim	 lo_WS			= Me.co_ExcelHelper.GetWSheet(i_WBName:= Me.cc_WBName,
																											i_WSName:= Me.cc_WSName)
				Dim lb_ScrnUpd	=	Me.co_ExcelHelper.GetSetScreenUpdating(False)


				For Each lo_Block	As MessageBlock	In Me.ct_MsgBlocks

					Dim lc_AddressTL	As String	= String.Concat("$"	, Me.cc_MsgColID, "$", lo_Block.StartRow.ToString,
																											":$", Me.cc_MsgColID, "$", (lo_Block.StartRow + lo_Block.RowDepth - 1).ToString)

					lo_WS.Range(lc_AddressTL).Value	= lo_Block.DataBlock

				Next

				Me.co_ExcelHelper.GetSetScreenUpdating(lb_ScrnUpd)

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			Private co_ExcelHelper	As iExcelHelper
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Shared Function Create(ByVal ExcelHelper			As iExcelHelper,
																		ByVal WorkbookName		As String,
																		ByVal WorksheetName		As String,
																		ByVal MessageColumnID	As String) _
															As ixProcessMessageHandler

				Return New xProcessMessageHandler(i_ExcelHelper:= ExcelHelper,
																					i_WBName		 := WorkbookName,
																					i_WSName		 := WorksheetName,
																					i_MsgColID	 := MessageColumnID)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New(ByVal i_ExcelHelper		As iExcelHelper,
											ByVal i_WBName		As String,
											ByVal i_WSName		As String,
											ByVal i_MsgColID	As String) _

				Me.co_ExcelHelper	= i_ExcelHelper
				Me.cc_WBName			= i_WBName
				Me.cc_WSName			= i_WSName
				Me.cc_MsgColID		= i_MsgColID

				Me.ct_Msgs				= New Dictionary(Of Integer, String)
				Me.ct_MsgBlocks		= New List(Of MessageBlock)

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Classes: Private"

			Private Class MessageBlock

				#Region "Definitions"

					Private cn_ExcelStartRow	As Integer
					Private ct_DataBlock			As Object(,)
					Private cn_NextIndex			As Integer

				#End Region
				'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
				#Region "Properties"

					'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
					Public ReadOnly Property StartRow	As Integer
						Get
							Return Me.cn_ExcelStartRow
						End Get
					End Property
					'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
					Public ReadOnly Property RowDepth			As Integer
						Get
							Return Me.ct_DataBlock.Length
						End Get
					End Property
					'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
					Public ReadOnly Property DataBlock		As Object(,)
						Get
							Return Me.ct_DataBlock
						End Get
					End Property

				#End Region
				'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
				#Region "Methods"

					'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
					Public Sub AddMessage(ByVal Msg	As String)

						Me.ct_DataBlock(Me.cn_NextIndex,0)	= CObj(Msg)
						Me.cn_NextIndex	+= 1
					
					End Sub

				#End Region
				'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
				#Region "Constructors"

					'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
					Public Sub New(ByVal ExcelStartRow	As Integer,
												 ByVal BlockSize			As Integer)

						Me.cn_ExcelStartRow	= ExcelStartRow
						Me.ct_DataBlock			= New Object(BlockSize - 1,0){}
						Me.cn_NextIndex			= 0

					End Sub

				#End Region

			End Class

		#End Region

	End Class

End Namespace