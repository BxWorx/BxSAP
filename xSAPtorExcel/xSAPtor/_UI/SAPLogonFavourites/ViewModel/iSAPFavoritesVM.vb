'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace UI

	Friend	Interface	iSAPFavoritesVM

		#Region "Properties"

			ReadOnly	Property	Count					As UShort
			ReadOnly	Property	FavouriteList	As List(Of iSAPFavoriteDTO)

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			Sub	Reset()
			Function	Save()																					As	Boolean
			Function	CreateDTO()																			As	iSAPFavoriteDTO
			Function	Register(ByVal	Entry	As	iSAPFavoriteDTO)			As	Boolean
			Function  Deregister(ByVal	Entry	As	iSAPFavoriteDTO)		As	Boolean
			Function	GetSAPFavDTO(ByVal Index	As Integer)						As	iSAPFavoriteDTO

		#End Region

	End Interface

End Namespace