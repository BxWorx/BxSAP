Imports System.IO
Imports System.Threading
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Serialization

	Public	Class	Serialiser
									Implements iSerialiser

		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	SerializeObjectViaDataContract2File(Of T)(_obj2ser	As T,
																																	_name			As String)	As Boolean _
													Implements iSerialiser.SerializeObjectViaDataContract2File

				Dim lb_Return As Boolean  = False

				Try

						Using lo_FSWriter	As FileStream	= File.Create(_name, FileMode.Create)

							Dim lo_DCSerializer	As New DataContractSerializer(GetType(T))

							lo_DCSerializer.WriteObject(lo_FSWriter, _obj2ser)

						End Using

						lb_Return = True
						
					Catch ex As Exception

				End Try

				Return lb_Return

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	DeSerializeObjectViaDataContract2File(Of T)(_name	As String)	As T _
													Implements iSerialiser.DeSerializeObjectViaDataContract2File

				Try

						Using lo_FSReader As New FileStream(_name, FileMode.Open, FileAccess.Read)

							Dim lo_DCSerializer As New DataContractSerializer(GetType(T))

							Return	DirectCast(lo_DCSerializer.ReadObject(lo_FSReader), T)

						End Using

					Catch ex As Exception
						Return	Nothing

				End Try

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	SerializeObjectViaDataContract(Of T)(_obj2ser	As T)	As String _
													Implements iSerialiser.SerializeObjectViaDataContract

				Using	lo_memStream	As	New MemoryStream()

					Dim lo_serializer	=	New DataContractSerializer(GetType(T))

					lo_serializer.WriteObject(lo_memStream, _obj2ser)

					lo_memStream.Seek(0, SeekOrigin.Begin)

					Using lo_streamReader	=	New StreamReader(lo_memStream)
						Return	lo_streamReader.ReadToEnd().ToString
					End Using

				End Using

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	DeSerializeObjectViaDataContract(Of T)(_string	As String)	As T _
													Implements iSerialiser.DeSerializeObjectViaDataContract

				Try

						Using lo_XMLReader	As XmlReader	= XmlReader.Create(New StringReader(_string))

							Dim lo_serializer	As	New DataContractSerializer(GetType(T))
							Return DirectCast(lo_serializer.ReadObject(lo_XMLReader), T)

						End Using

					Catch ex As Exception
						Return	Nothing

				End Try

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	DeSerializeObject(Of T)(_string	As String)  As T _
													Implements iSerialiser.DeSerializeObject

				Dim lo_xmlSerializer As New XmlSerializer(GetType(T))

				Using	lo_TextReader	As	New StringReader(_string)

					Try

							Return	CType(lo_xmlSerializer.Deserialize(lo_TextReader), T)

						Catch ex As Exception

							Return	Nothing

					End Try

				End Using

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	SerializeObject(Of T)(_obj2ser	As T) As String _
													Implements iSerialiser.SerializeObject

				Dim lo_xmlSerializer	As	New XmlSerializer(_obj2ser.[GetType]())
				Dim lo_xmlNameSpace		=		New XmlSerializerNamespaces()

				lo_xmlNameSpace.Add("", "")

				Using lo_TextWriter As New StringWriter()

					lo_xmlSerializer.Serialize(lo_TextWriter, _obj2ser, lo_xmlNameSpace)
					Return lo_TextWriter.ToString()

				End Using

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New()
			End Sub

		#End Region

	End Class

End Namespace
