Imports System.IO
Imports System.Threading
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
Imports System.Xml
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Utilities.Generic

	Friend	Class	ServicesGeneric
									Implements iServicesGeneric

		#Region "Definitions"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

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
