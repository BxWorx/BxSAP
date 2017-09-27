Imports System.IO
Imports System.Threading
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
Imports System.Security.AccessControl
Imports System.Security.Principal
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Services.Utilities.Generic

	Friend	Class	ServicesGeneric
									Implements iServicesGeneric

		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	UserLocalAppDataFolder()  As String _
																		Implements iServicesGeneric.UserLocalAppDataFolder
				Get
					Return	Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	UserLocalAppThisappSubFolder(	Optional	ByVal suffix	As String	= "" )	As String _
													Implements iServicesGeneric.UserLocalAppThisappSubFolder
				Get
					Return	String.Concat( Me.UserLocalAppDataFolder, "\", Me.AppName(suffix) )
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	AppName(	Optional	ByVal suffix	As String	= "" ) As String _
																		Implements iServicesGeneric.AppName
			    Get

						Dim lc_Name	As String

						If My.Application.Info.Title.Length > 0 Then
							lc_Name	= My.Application.Info.Title 
						Else
							lc_Name	= Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
						End If
				
						If suffix.Length > 0	Then	lc_Name	= String.Concat(lc_Name, suffix)

						Return	lc_Name

			    End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	UserLocalAppThisappPathName(	Optional	ByVal suffix	As String	= "",
																														Optional	ByVal ext			As String	= ".XML"	)	As String _
																		Implements iServicesGeneric.UserLocalAppThisappPathName
			    Get
						Return String.Concat(Me.UserLocalAppThisappSubFolder, "\", Me.AppName(suffix), ext)
			    End Get
			End Property

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateUserLocalThisappFolder(	Optional	ByVal suffix	As String	= "" ) As Boolean _
													Implements iServicesGeneric.CreateUserLocalThisappFolder

				Try

						Dim lc_File	= UserLocalAppThisappSubFolder()

						If Not Directory.Exists(lc_File)

							Dim securityRules As DirectorySecurity  = New DirectorySecurity()
							Dim userSid       As SecurityIdentifier = WindowsIdentity.GetCurrent().User

							securityRules.AddAccessRule(New FileSystemAccessRule(userSid,
																																		FileSystemRights.FullControl,
																																		InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit,
																																		PropagationFlags.None,
																																		AccessControlType.Allow))

							Directory.CreateDirectory(lc_File)  ', securityRules)

						End If

						Return True

					Catch ex As Exception
						Return False

				End Try

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	SerializeObjectViaDataContract2File(Of T)(ToSerialize		As T,
																																	filePathName	As String)	As Boolean _
													Implements iServicesGeneric.SerializeObjectViaDataContract2File

				Dim lb_Return As Boolean  = False

				Try

						Using lo_FSWriter	As FileStream	= File.Create(filePathName, FileMode.Create)

							Dim lo_DCSerializer	As New DataContractSerializer(GetType(T))

							lo_DCSerializer.WriteObject(lo_FSWriter, ToSerialize)

						End Using

						lb_Return = True
						
					Catch ex As Exception

				End Try

				Return lb_Return

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	DeSerializeObjectViaDataContract2File(Of T)(filePathName	As String)	As T _
													Implements iServicesGeneric.DeSerializeObjectViaDataContract2File

				Try

						Using lo_FSReader As New FileStream(filePathName, FileMode.Open, FileAccess.Read)

							Dim lo_DCSerializer As New DataContractSerializer(GetType(T))

							Return	DirectCast(lo_DCSerializer.ReadObject(lo_FSReader), T)

						End Using

					Catch ex As Exception
						Return	Nothing

				End Try

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	SerializeObjectViaDataContract(Of T)(Obj2Serialize	As T)	As String _
													Implements iServicesGeneric.SerializeObjectViaDataContract

				Using	lo_memStream	As	New MemoryStream()

					Dim lo_serializer	=	New DataContractSerializer(GetType(T))

					lo_serializer.WriteObject(lo_memStream, Obj2Serialize)

					lo_memStream.Seek(0, SeekOrigin.Begin)

					Using lo_streamReader	=	New StreamReader(lo_memStream)
						Return	lo_streamReader.ReadToEnd().ToString
					End Using

				End Using

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	DeSerializeObjectViaDataContract(Of T)(StrToDeSerialize	As String)	As T _
													Implements iServicesGeneric.DeSerializeObjectViaDataContract

				Try

						Using lo_XMLReader	As XmlReader	= XmlReader.Create(New StringReader(StrToDeSerialize))

							Dim lo_serializer	As	New DataContractSerializer(GetType(T))
							Return DirectCast(lo_serializer.ReadObject(lo_XMLReader), T)

						End Using

					Catch ex As Exception
						Return	Nothing

				End Try

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	DeSerializeObject(Of T)(ToDeSerialize As String)  As T _
													Implements iServicesGeneric.DeSerializeObject

				Dim lo_xmlSerializer As New XmlSerializer(GetType(T))

				Using	lo_TextReader	As	New StringReader(ToDeSerialize)

					Try

							Return	CType(lo_xmlSerializer.Deserialize(lo_TextReader), T)

						Catch ex As Exception

							Return	Nothing

					End Try

				End Using

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	SerializeObject(Of T)(ToSerialize As T) As String _
													Implements iServicesGeneric.SerializeObject

				Dim lo_xmlSerializer	As	New XmlSerializer(ToSerialize.[GetType]())
				Dim lo_xmlNameSpace		=		New XmlSerializerNamespaces()

				lo_xmlNameSpace.Add("", "")

				Using lo_TextWriter As New StringWriter()

					lo_xmlSerializer.Serialize(lo_TextWriter, ToSerialize, lo_xmlNameSpace)
					Return lo_TextWriter.ToString()

				End Using

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Shared	ReadOnly	_Instance	As	Lazy(Of iServicesGeneric) _
																								= New Lazy(Of iServicesGeneric)(
																										Function()	New	ServicesGeneric,
																										LazyThreadSafetyMode.ExecutionAndPublication	)
			Friend Shared ReadOnly Property ServicesGeneric	As iServicesGeneric
				Get
						Return _Instance.Value
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub New()
			End Sub

		#End Region

	End Class

End Namespace
