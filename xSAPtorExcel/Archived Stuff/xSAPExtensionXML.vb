Imports System.Xml.Serialization
Imports System.IO
Imports System.Runtime.CompilerServices
'================================================
Namespace Services.Excel
  Module xSAPExtensionXML

    '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
    <Extension> _
    Friend Function xSAPSerializeObject(Of T)(ToSerialize As T) As String

	    Dim lo_xmlSerializer As New XmlSerializer(ToSerialize.[GetType]())
      Dim lo_xmlNameSpace = New XmlSerializerNamespaces()

      lo_xmlNameSpace.Add("", "")

	    Using lo_textWriter As New StringWriter()
		    lo_xmlSerializer.Serialize(lo_textWriter, ToSerialize, lo_xmlNameSpace)
		    Return lo_textWriter.ToString()
	    End Using

    End Function    
    '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
    <Extension> _
    Friend Function xSAPDeSerializeObject(Of T)(ToDeSerialize As String) As T

	    Dim lo_xmlSerializer As New XmlSerializer(GetType(T))

	    Using lo_textReader As New StringReader(ToDeSerialize)
        Return CType(lo_xmlSerializer.Deserialize(lo_textReader), T)
	    End Using

    End Function

  End Module

End Namespace