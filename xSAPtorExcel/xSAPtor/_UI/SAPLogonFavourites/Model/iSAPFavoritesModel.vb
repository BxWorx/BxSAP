'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace UI

	Friend	Interface	iSAPFavoritesModel

		#Region "Properties"

			ReadOnly	Property	Count				As Integer
			ReadOnly	Property	List				As List(Of iSAPFavoriteDTO)
								Property	Capacity		As Integer

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			Function	GetSAPFavDTO(ByVal Index	As Integer)					As	iSAPFavoriteDTO
			Function	CreateDTO()																		As	iSAPFavoriteDTO
			Function	Register(ByVal	Entry	As iSAPFavoriteDTO)			As	Boolean
			Function	Deregister(ByVal	Entry	As iSAPFavoriteDTO)		As	Boolean
			Function	Save()																				As	Boolean
			Sub	Reset()

		#End Region

	End Interface

End Namespace