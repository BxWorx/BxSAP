'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Class	LogonSystemsModel
									Implements iLogonSystemsModel

		#Region "Definitions"

			Private	co_ReposDTO			As	iSysReposDTO
			'....................................................
			Private	cb_DirtyLang		As	Boolean
			Private	cb_DirtySyst		As	Boolean
			'....................................................

			Private cc_XMLFileName	As String
			Private cb_DirError			As Boolean

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"

			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'ReadOnly	Friend	Property	Connections	As Dictionary(Of String, iLogonConnectionDTO) _
			'										Implements	iLogonConnectionModel.Connections
			'	Get
			'		Return	Me.co_ReposDTO.ConnList
			'	End Get
			'End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend	Function	DeleteConnection(ByVal _id	As String)	As Boolean _
			'										Implements iLogonConnectionModel.DeleteConnection

			'	Return	Me.co_ReposDTO.ConnList.Remove(_id)

			'End Function
			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend	Function	CreateDTO()	As iLogonConnectionDTO _
			'										Implements iLogonConnectionModel.CreateDTO

			'	Return	New LogonConnectionDTO

			'End Function
			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend	Function	FetchRepos()	As iLogonConnReposDTO _
			'										Implements iLogonSystemsModel.FetchRepos

			'	Return	Me.co_ReposDTO

			'End Function
			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend	Function	Modify(_dto	As iLogonConnectionDTO)	As Boolean _
			'										Implements iLogonConnectionModel.Modify

			'	Try

			'		Dim	lo_DTO	= _dto.ShallowCopy()
			'		'................................................
			'		If Me.co_ReposDTO.ConnList.ContainsKey(lo_DTO.ID)
			'			Me.co_ReposDTO.ConnList(_dto.ID)	= lo_DTO
			'		Else
			'			Me.co_ReposDTO.ConnList.Add(lo_DTO.ID, lo_DTO)
			'		End If
			'		'................................................
			'		Return	True

			'		Catch ex As Exception
			'			Return	False

			'	End Try

			'End Function


			''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'Friend	Function	FetchUsers(	ByVal	_systemid	As	String	,
			'															ByVal	_clientno	As	String		)	As iSystemUsersDTO _
			'										Implements iLogonSystemsModel.FetchUsers

			'	Dim lo_TrgtDTO	As	iSystemUsersDTO		= Me.CreateUserDTO()
			'	Dim	lo_SrceDTO	As	iSystemClientsDTO	=	Me.FetchClients(_systemid)

			'	If lo_SrceDTO.Clients.ContainsKey(_clientno)

			'		lo_TrgtDTO.Users	= (	From	x	In lo_SrceDTO.Clients(_clientno).Users
			'															Select x	).ToDictionary(	Function(x) x.Key,
			'																												Function(x)	x.Value
			'																											)

			'	End If

			'	Return	lo_TrgtDTO

			'End Function




			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	SaveSystem(ByVal	_sys	As	iSysReposSystemDTO)	As	Boolean _
													Implements	iLogonSystemsModel.SaveSystem

				Dim lo_TrgtDTO	As	iSysReposSystemDTO	= Me.CreateSystemDTO()

				lo_TrgtDTO.ID				= _sys.ID
				lo_TrgtDTO.Previous	= _sys.Previous
				lo_TrgtDTO.Clients	= (	From	x In _sys.Clients
																	Select x	).ToDictionary(	Function(x) x.Key,
																														Function(x)	x.Value	)

				Me.co_ReposDTO.Systems(_sys.ID)	= lo_TrgtDTO
				Me.cb_DirtySyst	= True

				Return	True

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	FetchSystem(ByVal _systemid	As String)	As iSysReposSystemDTO _
													Implements iLogonSystemsModel.FetchSystem

				Dim lo_TrgtDTO	As	iSysReposSystemDTO	= Me.CreateSystemDTO()

				lo_TrgtDTO.ID	= _systemid

				If Me.co_ReposDTO.Systems.ContainsKey(_systemid)

					lo_TrgtDTO.Previous	= Me.co_ReposDTO.Systems(_systemid).Previous
					lo_TrgtDTO.Clients	= (	From	x In Me.co_ReposDTO.Systems(_systemid).Clients
																		Select x	).ToDictionary(	Function(x) x.Key,
																															Function(x)	x.Value	)

				End If

				Return	lo_TrgtDTO

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateLogonSysDTO()	As iLogonSystemDTO _
													Implements	iLogonSystemsModel.CreateLogonSysDTO
				
				Return	New	LogonSystemDTO()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateSystemDTO()	As iSysReposSystemDTO _
													Implements	iLogonSystemsModel.CreateSystemDTO
				
				Return	New	SysReposSystemDTO()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateClientDTO()	As iSysReposClientDTO _
													Implements	iLogonSystemsModel.CreateClientDTO
				
				Return	New	SysReposClientDTO()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateUserDTO()	As iSysReposUserDTO _
													Implements	iLogonSystemsModel.CreateUserDTO
				
				Return	New	SysReposUserDTO()

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	DeleteLanguage(ByVal	_id	As	String)	As	Boolean _
													Implements	iLogonSystemsModel.DeleteLanguage


				Dim	lb_Ret	As	Boolean	= False

				If Me.co_ReposDTO.Languages.Contains(_id)

					If Me.co_ReposDTO.Languages.Remove(_id)
						Me.cb_DirtyLang	= True
						lb_Ret					= True
					End If

				End If

				Return	lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	SaveLanguage(ByVal	_id	As	String)	As	Boolean _
													Implements	iLogonSystemsModel.SaveLanguage

				Dim	lb_Ret	As	Boolean	= True
				Dim	lc_Key	As	String	= _id.ToUpper()

				If Me.co_ReposDTO.Languages.Contains(lc_Key)
					lb_Ret	= False
				Else

					Me.co_ReposDTO.Languages.Add(lc_Key)
					Me.cb_DirtyLang	= True

				End If

				Return	lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	FetchLanguages()	As	List(Of	String) _
													Implements	iLogonSystemsModel.FetchLanguages

				Return	Me.co_ReposDTO.Languages

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	SaveRepository()	As Boolean _
													Implements iLogonSystemsModel.SaveRepository

				If	Me.cb_DirtyLang	OrElse
						Me.cb_DirtySyst

					Return	Me.SaveRepos()
				
				Else
					Return	True
				End If

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Construction"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New()

				Const	lx_Suffix	As String	= "_SAPSystems"

				Me.co_ReposDTO	= New SysReposDTO()
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

				Dim	lo_ReposXML	As	New	SysReposXML

				For Each	lo_Sys In Me.co_ReposDTO.Systems

					Dim lo_XMLSys	As	New	SysReposSystemXML

					For Each	lo_Clnt	In lo_Sys.Value.Clients

						Dim	lo_XMLClt	As	New	SysReposClientXML

						For Each	lo_Usr	In lo_Clnt.Value.Users

							Dim lo_XMLUsr	As	New	SysReposUserXML

							lo_XMLUsr.Password	= lo_Usr.Value.Password

							lo_XMLClt.Users.Add(lo_Usr.Key, lo_XMLUsr)

						Next

						lo_XMLClt.No	= lo_Clnt.Value.No
						lo_XMLSys.Clients.Add(lo_Clnt.Key,	lo_XMLClt)

					Next

					lo_XMLSys.ID	=	lo_Sys.Value.ID

					lo_XMLSys.Previous	= New	SysReposLogonXML

					lo_XMLSys.Previous.Language	=	lo_Sys.Value.Previous.Language
					lo_XMLSys.Previous.Client		=	lo_Sys.Value.Previous.Client
					lo_XMLSys.Previous.User			= lo_Sys.Value.Previous.UserName
					lo_XMLSys.Previous.Password	= lo_Sys.Value.Previous.Password

					lo_ReposXML.Systems.Add(lo_Sys.Key, lo_XMLSys)

				Next
				'..................................................
				lo_ReposXML.Languages.AddRange(Me.co_ReposDTO.Languages)
				'..................................................
				Return	so_HlprGeneric.Value.SerializeObjectViaDataContract2File(lo_ReposXML, Me.cc_XMLFileName)

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub LoadRepos()

				Dim	lo_ReposXML	As SysReposXML	= so_HlprGeneric.Value.DeSerializeObjectViaDataContract2File(Of SysReposXML)(Me.cc_XMLFileName)

				If lo_ReposXML Is Nothing
					Return
				End If
				'..................................................
				For Each	lo_XMLSys	In lo_ReposXML.Systems

					Dim	lo_System	As iSysReposSystemDTO	=	New	SysReposSystemDTO

					For Each	lo_XMLClt	In lo_XMLSys.Value.Clients

						Dim lo_Client	As iSysReposClientDTO	= New	SysReposClientDTO

						For Each lo_XMLUsr In lo_XMLClt.Value.Users

							Dim	lo_Usr	As iSysReposUserDTO	=	New	SysReposUserDTO

							lo_Usr.User			= lo_XMLUsr.Key
							lo_Usr.Password	= lo_XMLUsr.Value.Password

							lo_Client.Users.Add(lo_Usr.User,	lo_Usr)

						Next

						lo_Client.No	=	lo_XMLClt.Value.No
						lo_System.Clients.Add(lo_XMLClt.Key,	lo_Client)

					Next
					
					lo_System.ID				= lo_XMLSys.Value.ID

					If lo_XMLSys.Value.Previous IsNot Nothing

						lo_System.Previous.Language	= lo_XMLSys.Value.Previous.Language
						lo_System.Previous.Client		= lo_XMLSys.Value.Previous.Client
						lo_System.Previous.UserName	= lo_XMLSys.Value.Previous.User
						lo_System.Previous.Password	= lo_XMLSys.Value.Previous.Password

					End If

					Me.co_ReposDTO.Systems.Add(lo_XMLSys.Key, lo_System)

				Next
				'................................................
				Me.co_ReposDTO.Languages.AddRange(lo_ReposXML.Languages)

			End Sub

		#End Region

	End Class

End Namespace