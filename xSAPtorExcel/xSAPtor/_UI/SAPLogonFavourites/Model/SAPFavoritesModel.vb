'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace UI

	Friend	Class	SAPFavoritesModel
									Implements iSAPFavoritesModel

		#Region "Definitions"

			Private	cn_Capacity			As	Integer
			Private	ct_FavList			As	SortedList(Of Integer, iSAPFavoriteDTO)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	Count	As Integer									Implements iSAPFavoritesModel.Count
				Get
					Return	Me.ct_FavList.Count
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	List	As List(Of iSAPFavoriteDTO)	Implements iSAPFavoritesModel.List
				Get
					Return	Me.ct_FavList.Values.ToList
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Property	Capacity	As Integer	Implements iSAPFavoritesModel.Capacity
				Get
					Return	Me.ct_FavList.Capacity
				End Get
			  Set(value As Integer)
					If value > 10
						Me.ct_FavList.Capacity	= 10
					ElseIf	value <= 0
						Me.ct_FavList.Capacity	= 1
					Else
						Me.ct_FavList.Capacity	= value
					End If
			  End Set
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	New()

				Dim	lo_SAPFavs	= so_HlprGeneric.Value.DeSerializeObjectViaDataContract(Of SAPFavoritesXML)(My.Settings.SAPLogon_FavouritesXML)

				Me.ct_FavList		= New	SortedList(Of Integer, iSAPFavoriteDTO)

				If IsNothing(lo_SAPFavs)
					Me.cn_Capacity	= 5
				Else

					Me.cn_Capacity	= lo_SAPFavs.Capacity
					
					For Each	lo	In lo_SAPFavs.List.Where( Function(o)
																									If	o.Value.Client IsNot Nothing	AndAlso
																											o.Value.Client.Length > 0
																										Return	True
																									Else
																										Return	False
																									End If
						           	                        End Function)
						Me.ct_FavList.Add(lo.Key, lo.Value)
					Next

				End If

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function GetSAPFavDTO(ByVal _index	As Integer)		As iSAPFavoriteDTO _
												Implements	iSAPFavoritesModel.GetSAPFavDTO

				Dim lo_DTO	= Me.CreateDTO()

				If Me.ct_FavList.TryGetValue(_index, lo_DTO)
					Return	lo_DTO
				Else
					Return	Me.CreateDTO()
				End If

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function CreateDTO()		As iSAPFavoriteDTO _
												Implements	iSAPFavoritesModel.CreateDTO

				Return	New	SAPFavoriteDTO

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	Reset()	_
										Implements	iSAPFavoritesModel.Reset

				Me.cn_Capacity	= 5
				Me.ct_FavList.Clear()

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function Deregister(ByVal _dto	As iSAPFavoriteDTO)	As Boolean _
												Implements	iSAPFavoritesModel.Deregister

				Dim	ln_Indx	= Me.CheckExists(_dto)
				'..................................................
				If ln_Indx.Equals(-1)
					Return	False
				Else
					Me.ct_FavList.RemoveAt(ln_Indx)
					Return	True
				End If

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Register(ByVal	_dto	As iSAPFavoriteDTO)	As Boolean _
													Implements	iSAPFavoritesModel.Register

				If Me.ct_FavList.Count	= 0
					_dto.SeqNo	= 1
					Me.ct_FavList.Add(1, _dto)
					Return	True
				End If
				'..................................................
				Dim	ln_Indx	= Me.CheckExists(_dto)
				'..................................................
				If ln_Indx.Equals(0)	Then	Return	False
				'..................................................
				If ln_Indx.Equals(-1)
					If Me.ct_FavList.Count >= Me.cn_Capacity
						Me.ct_FavList.RemoveAt(Me.ct_FavList.Count - 1)
					End If
				Else
					Me.ct_FavList.RemoveAt(ln_Indx)
				End If
				'..................................................
				Dim lt_Cont								= New	SortedList(Of	Integer, iSAPFavoriteDTO)(Me.cn_Capacity)
				Dim ln_Index	As Integer	= 1

				lt_Cont.Add(1, _dto)
				
				For Each	lo	In Me.ct_FavList

					ln_Index	+= 1
					lo.Value.SeqNo	= ln_Index
					lt_Cont.Add(ln_Index, lo.Value)

				Next

				Me.ct_FavList	= lt_Cont
				'..................................................
				Return True

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Save()	As Boolean _
													Implements iSAPFavoritesModel.Save

				Try

						Dim	lo_SAPFavs	= New	SAPFavoritesXML

						lo_SAPFavs.Capacity	= Me.cn_Capacity

						For Each lo	In Me.ct_FavList.Where( Function(o)
																									If	o.Value.Client IsNot Nothing	AndAlso 
																											o.Value.Client.Length > 0
																										Return	True
																									Else
																										Return	False
																									End If
						           	                        End Function)

							lo_SAPFavs.List.Add( lo.Key, CType(lo.Value.Clone(), SAPFavoriteDTO))

						Next

						My.Settings.SAPLogon_FavouritesXML	= so_HlprGeneric.Value.SerializeObjectViaDataContract(lo_SAPFavs)
						My.Settings.Save()

						Return	True

					Catch ex As Exception

						Return	False

				End Try

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub	ResizeList()

				Dim	lt_List	=	New	SortedList(Of	Integer, iSAPFavoriteDTO)(Me.cn_Capacity)
				'..................................................
				For Each lo In Me.ct_FavList

					lt_List.Add(lo.Key,lo.Value)
					If lt_List.Count >= Me.cn_Capacity
						Exit For
					End If

				Next
				'..................................................
				Me.ct_FavList	= lt_List

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Function	CheckExists(ByVal DTO	As iSAPFavoriteDTO)	As Integer

				Dim ln_Ret	As Integer = -1
				'..................................................
				For Each	lo	In Me.ct_FavList

					If	lo.Value.Client IsNot Nothing	AndAlso
							lo.Value.User		IsNot Nothing

						If	lo.Value.Client.Equals(	DTO.Client)	AndAlso
								lo.Value.User.Equals(DTO.User)

							ln_Ret	=	Me.ct_FavList.IndexOfKey(lo.Key)
							Exit	For

						End If

					End If

				Next
				'..................................................
				Return	ln_Ret

			End Function

		#End Region

	End Class

End Namespace