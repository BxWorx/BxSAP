
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Public Class SerialisableDictionary(Of T1, T2)
              Inherits Dictionary(Of T1, T2)
                Implements IXmlSerializable

  'Private Shared lo_TypeList      As List(Of Type)
  'Private Shared lo_DCSerializer  As New DataContractSerializer(GetType(SerialisableDictionary(Of T1,T2)))

  Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
    Dim lo_DCSerializer  As New DataContractSerializer(GetType(SerialisableDictionary(Of T1,T2)))
    lo_DCSerializer.WriteObject(writer, Me)
  End Sub

  Public Sub ReadXml(reader As XmlReader)  Implements IXmlSerializable.ReadXml

    'Dim deserialised As Dictionary(Of T1, T2) = DirectCast(lo_DCSerializer.ReadObject(reader), Dictionary(Of T1, T2))

    'For Each kvp As KeyValuePair(Of T1, T2) In deserialised
    '  Add(kvp.Key, kvp.Value)
    'Next

  End Sub

  Private Function IXmlSerializable_GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
    Return Nothing
  End Function

  Public Sub New()

    'lo_TypeList = New List(Of Type)
    'lo_TypeList.Add(GetType( SerialisableDictionary(Of T1, T2) ))
    'lo_DCSerializer = New DataContractSerializer( GetType( Dictionary(Of T1, T2) ), lo_TypeList )

  End Sub

End Class



''' <summary>
''' Serializes the given object to byte stream
''' </summary>
Public NotInheritable Class Serializerxxxx
  ''' <summary>
  ''' Serializes the given object to byte stream
  ''' </summary>
  ''' <param name="objectToSeralize">Object to be serialized</param>
  ''' <returns>byte array of searialize object</returns>
  Public Shared Function Serialize(objectToSeralize As Object) As Byte()
    Dim objectBytes As Byte()
    Using stream As New MemoryStream()
      'Creating binary formatter to serialize object.
      Dim formatter As New BinaryFormatter()

      'Serializing objectToSeralize. 
      formatter.Serialize(stream, objectToSeralize)
      objectBytes = stream.ToArray()
    End Using
    Return objectBytes
  End Function
  ''' <summary>
  ''' De-Serialize the byte array to object
  ''' </summary>
  ''' <param name="arrayToDeSerialize">Byte array of Serialize object</param>
  ''' <returns>De-Serialize object</returns>
  Public Shared Function DeSerialize(arrayToDeSerialize As Byte()) As Object
    Dim serializedObject As Object
    Using stream As New MemoryStream(arrayToDeSerialize)
      'Creating binary formatter to De-Serialize string.
      Dim formatter As New BinaryFormatter()

      'De-Serializing.
      serializedObject = formatter.Deserialize(stream)
    End Using
    Return serializedObject
  End Function
End Class




      ''Dim loadObj As TestClass
      ''  Using reader As New FileStream("c:/temp/file.xml", FileMode.Open, FileAccess.Read)
	     ''   Dim ser As New DataContractSerializer(GetType(TestClass))
	     ''   loadObj = DirectCast(ser.ReadObject(reader), TestClass)
      ''  End Using


       '' Dim lb_Return     As Boolean  = False
       '' Dim lc_XmlConfig  As String '   = i_Config.xSAPSerializeObject()

       '' Dim lo_xmlSerializer As New XmlSerializer(i_config.GetType())

	      ''Using lo_textWriter As New StringWriter()
		     '' lo_xmlSerializer.Serialize(lo_textWriter, i_Config )', lo_xmlNameSpace)
		     '' lc_XmlConfig =  lo_textWriter.ToString()
	      ''End Using

        'Using lo_SW As StreamWriter = New StreamWriter(Me.CompilePathName)
        '  lo_SW.Write(lc_XmlConfig)
        'End Using









     'Private co_SourceID     As Byte
    'Private co_Destination  As Lazy(Of iDestination) = New Lazy(Of iDestination)(Function() Destination.Create())
   'Private Async Sub LoadMetaData()

    '  Dim lo_cts  = New CancellationTokenSource
    '  Dim lo_RfcFncMetadata As iRfcFunctionMetaDataLoader = RfcFunctionMetaDataLoader.Create(Globals.ThisAddIn.co_DestProfile.Value)

    '  Try

    '    If Await lo_RfcFncMetadata.LoadTransactionCallerAsync(i_ct:=lo_cts.Token)
    '      If Await lo_RfcFncMetadata.LoadSAPTableReaderAsync(i_ct:=lo_cts.Token)
    '        Dim x = 1
    '      End If
    '    End If

    '  Catch ex As Exception
    '    Dim y = 1

    '  End Try

    '  lo_cts = Nothing

    'End Sub
    '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
    'Private Sub SetDestination()

    '  'Globals.ThisAddIn.cc_DestID         = Me.xlvw_SAPSystems.SelectedItems(0).Text
    '  'Me.xtss_lbl_Selected_SAPSystem.Text = Me.xlvw_SAPSystems.SelectedItems(0).Text.Trim
    '  'Globals.ThisAddIn.cb_DestActive     = True

    '  'Dim lo_Destination  = Destination.Create()
    '  'Dim lo_RfcDest      = lo_Destination.GetDestination(Globals.ThisAddIn.cc_DestID)
    '  'Dim lo_CustDest     = lo_RfcDest.CreateCustomDestination()

    '  ''lo_CustDest.User      = "DERRICKBINGH"
    '  ''lo_CustDest.Password  = "M@@n0987"
    '  ''lo_CustDest.Client    = "500"
    '  ''lo_CustDest.UseSAPGui = SAPnco.RfcConfigParameters.RfcUseSAPGui.NotUse


    '  ''Dim ls_RfcCnfg      = lo_CustDest.Parameters()
      
    '  ''ls_RfcCnfg.Add(SAPnco.RfcConfigParameters.User      , "DERRICKBINGH")
    '  ''ls_RfcCnfg.Add(SAPnco.RfcConfigParameters.Password  , "M@@n0987")
    '  ''ls_RfcCnfg.Add(SAPnco.RfcConfigParameters.Client    , "500")
    '  ''ls_RfcCnfg.Add(SAPnco.RfcConfigParameters.UseSAPGui , SAPnco.RfcConfigParameters.RfcUseSAPGui.NotUse)
      
    '  'Globals.ThisAddIn.co_DestProfile.Value.DestinationID  = Globals.ThisAddIn.cc_DestID
    '  'Globals.ThisAddIn.co_DestProfile.Value.Destination    = lo_CustDest   '    lo_Destination.GetDestination(Globals.ThisAddIn.cc_DestID)

    'End Sub

