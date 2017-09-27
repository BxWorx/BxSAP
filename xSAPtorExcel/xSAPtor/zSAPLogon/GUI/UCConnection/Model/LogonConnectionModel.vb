'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Class	LogonConnectionModel
									Implements iLogonConnectionModel

		#Region "Definitions"

			Private	co_ReposDTO			As iLogonConnReposDTO
			Private cc_XMLFileName	As String
			Private cb_DirError			As Boolean

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			ReadOnly	Friend	Property	Connections	As Dictionary(Of String, iLogonConnectionDTO) _
													Implements	iLogonConnectionModel.Connections
				Get
					Return	Me.co_ReposDTO.ConnList
				End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	DeleteConnection(ByVal _id	As String)	As Boolean _
													Implements iLogonConnectionModel.DeleteConnection

				Return	Me.co_ReposDTO.ConnList.Remove(_id)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	SaveRepository()	As Boolean _
													Implements iLogonConnectionModel.SaveRepository

				Return	Me.SaveRepos()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateDTO()	As iLogonConnectionDTO _
													Implements iLogonConnectionModel.CreateDTO

				Return	New LogonConnectionDTO

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	FetchRepos()	As iLogonConnReposDTO _
													Implements iLogonConnectionModel.FetchRepos

				Return	Me.co_ReposDTO

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	FetchConnection(ByVal	_id	As String)	As iLogonConnectionDTO _
													Implements iLogonConnectionModel.FetchConnection

				Dim	lo_DTO	= Me.CreateDTO()

				If Me.Connections.TryGetValue(_id,	lo_DTO)
					Return	lo_DTO.ShallowCopy()
				Else
					Return	lo_DTO
				End If

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Modify(_dto	As iLogonConnectionDTO)	As Boolean _
													Implements iLogonConnectionModel.Modify

				Try

					Dim	lo_DTO	= _dto.ShallowCopy()
					'................................................
					If Me.co_ReposDTO.ConnList.ContainsKey(lo_DTO.ID)
						Me.co_ReposDTO.ConnList(_dto.ID)	= lo_DTO
					Else
						Me.co_ReposDTO.ConnList.Add(lo_DTO.ID, lo_DTO)
					End If
					'................................................
					Return	True

					Catch ex As Exception
						Return	False

				End Try

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Construction"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New()

				Const	lx_Suffix	As String	= "_SAPConnections"

				Me.co_ReposDTO	= New LogonConnReposDTO()
				'..................................................
				If so_HlprGeneric.Value.CreateUserLocalThisappFolder(lx_Suffix)

					Me.cb_DirError		= False
					Me.cc_XMLFileName	= so_HlprGeneric.Value.UserLocalAppThisappPathName(lx_Suffix)
					Me.LoadRepos()

				Else
					Me.cb_DirError	= True
				End If

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Function	SaveRepos()	As Boolean

				Dim	lo_ReposXML	As	New	LogonConnReposXML
				
				For Each lo	In Me.co_ReposDTO.ConnList

					Dim	lo_DTO	As	New	LogonConnEntryXML

					lo_DTO.ID								= lo.Value.ID
					lo_DTO.Name							= lo.Value.Name
					lo_DTO.AppServer				= lo.Value.AppServer
					lo_DTO.InstanceNo				= lo.Value.InstanceNo
					lo_DTO.SystemID					= lo.Value.SystemID
					lo_DTO.RouterPath				= lo.Value.RouterPath
					lo_DTO.SNC_Active				= lo.Value.SNC_Active
					lo_DTO.SNC_PartnerName	= lo.Value.SNC_PartnerName
					lo_DTO.SNC_UsrPwd				= lo.Value.SNC_UsrPwd
					lo_DTO.SNC_QOP					= lo.Value.SNC_QOP
					lo_DTO.LowSpeed					= lo.Value.LowSpeed

					lo_ReposXML.ConnList.Add(lo.Key, lo_DTO)

				Next
				'..................................................
				Return	so_HlprGeneric.Value.SerializeObjectViaDataContract2File(lo_ReposXML, Me.cc_XMLFileName)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub LoadRepos()

				Dim	lo_ReposXML	As LogonConnReposXML	= so_HlprGeneric.Value.DeSerializeObjectViaDataContract2File(Of LogonConnReposXML)(Me.cc_XMLFileName)

				If lo_ReposXML IsNot Nothing

					For Each lo	In lo_ReposXML.ConnList

						Dim	lo_DTO	As iLogonConnectionDTO	= New	LogonConnectionDTO

						lo_DTO.ID								= lo.Value.ID
						lo_DTO.Name							= lo.Value.Name
						lo_DTO.AppServer				= lo.Value.AppServer
						lo_DTO.InstanceNo				= lo.Value.InstanceNo
						lo_DTO.SystemID					= lo.Value.SystemID
						lo_DTO.RouterPath				= lo.Value.RouterPath
						lo_DTO.SNC_Active				= lo.Value.SNC_Active
						lo_DTO.SNC_PartnerName	= lo.Value.SNC_PartnerName
						lo_DTO.SNC_UsrPwd				= lo.Value.SNC_UsrPwd
						lo_DTO.SNC_QOP					= lo.Value.SNC_QOP
						lo_DTO.LowSpeed					= lo.Value.LowSpeed

						Me.co_ReposDTO.ConnList.Add(lo.Key, lo_DTO)

					Next

				End If

			End Sub

		#End Region

	End Class

End Namespace