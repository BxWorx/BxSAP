Imports System.Threading.Tasks
Imports System.Collections.Concurrent
'================================================
Friend Class ExcelRow
							Implements iExcelRow

	#Region "Definitions"

		Private ct_ColIndex As List(Of Integer)

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Properties"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cn_IndexNo  As Integer
		Friend	ReadOnly	Property	IndexNo	As Integer	Implements	iExcelRow.IndexNo
			Get
				Return Me.cn_IndexNo
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cn_RowNo  As Integer
		Friend ReadOnly Property RowNo  As Integer Implements iExcelRow.RowNo
			Get
				Return Me.cn_RowNo
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private cb_Terminated As Boolean
		Friend ReadOnly Property IsTerminated As Boolean  Implements iExcelRow.IsTerminated
			Get
				Return Me.cb_Terminated
			End Get
		End Property
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private ct_Values As New ConcurrentDictionary(Of Integer, String)
		Friend ReadOnly Property Values As ConcurrentDictionary(Of Integer, String)  Implements iExcelRow.Values
			Get
				Return Me.ct_Values
			End Get
		End Property

	#End Region
	'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
	#Region "Constructor"

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		' SearctEOT: Search for END-OF-TRANSACTION.  Depends on if HEADER section picked up a @@POST
		' indicator
		Friend Sub New(					ByVal indexNo			As Integer				,
														ByVal i_RowNo     As Integer				,
														ByVal i_Data      As Object(,)			,
									 Optional ByVal i_SearchEOT As Boolean = False	)

			Me.cn_IndexNo	= indexNo
			Me.cn_RowNo		= i_RowNo

			If i_SearchEOT

				Me.cb_Terminated = False

				For ln_Index = 1 To i_Data.Length

					If Not IsNothing(i_Data(1, ln_Index))
						If Me.ct_Values.TryAdd(ln_Index, i_Data(1, ln_Index).ToString)
							If i_Data(1, ln_Index).ToString.Contains("@@EXEC")
								Me.cb_Terminated = True
							End If
						End If
					End If

				Next

			Else

				Me.cb_Terminated = True

				For ln_Index = 1 To i_Data.Length

					If Not IsNothing(i_Data(1, ln_Index))
						If Me.ct_Values.TryAdd(ln_Index, i_Data(1, ln_Index).ToString)
						End If
					End If

				Next

			End If

			Me.ct_ColIndex = Me.ct_Values.Keys.ToList()
			Me.ct_ColIndex.Sort()

		End Sub

	#End Region

End Class
