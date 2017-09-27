Imports System.Runtime.Serialization
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace UI

	<DataContract([Namespace]:="")> _
	Public	Class	SAPFavoriteDTO
									Implements	iSAPFavoriteDTO

		#Region "Properties"

			<DataMember>	Friend	Property	SeqNo				As Integer		Implements	iSAPFavoriteDTO.SeqNo
			<DataMember>	Friend	Property	RfcDestID		As String			Implements	iSAPFavoriteDTO.RfcDestID
			<DataMember>	Friend	Property	Language		As String			Implements	iSAPFavoriteDTO.Language
			<DataMember>	Friend	Property	Client			As String			Implements	iSAPFavoriteDTO.Client
			<DataMember>	Friend	Property  User				As String			Implements	iSAPFavoriteDTO.User
			<DataMember>	Friend	Property	Password		As String			Implements	iSAPFavoriteDTO.Password
			<DataMember>	Friend	Property	SystemID		As String			Implements	iSAPFavoriteDTO.SystemID

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Clone()	As iSAPFavoriteDTO _
													Implements iSAPFavoriteDTO.Clone

				Return DirectCast( Me.MemberwiseClone(), iSAPFavoriteDTO )

			End Function

		#End Region

	End Class

End Namespace