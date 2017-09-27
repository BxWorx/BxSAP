'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Serialization

	Public Interface iSerialiser

		#Region "Methods"

			Function	SerializeObjectViaDataContract2File(Of T)(ObjectToSerialize	As T, 
																													FullName					As String)	As Boolean
			Function	DeSerializeObjectViaDataContract2File(Of T)(FullName	As String)				As T
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Function	SerializeObjectViaDataContract(Of T)(ObjectToSerialize			As T)				As String
			Function	DeSerializeObjectViaDataContract(Of T)(ObjectToDeSerialize	As String)	As T
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			' These use non-interface classes with public properties only.
			'
			Function	SerializeObject(Of T)(ObjectToSerialize			As T)				As String
			Function	DeSerializeObject(Of T)(ObjectToDeSerialize	As String)	As T

		#End Region

	End Interface

End Namespace