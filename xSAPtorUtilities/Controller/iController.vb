Imports	xSAPtorUtilities.Serialization
Imports	xSAPtorUtilities.Convertors
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Controllers
	Public Interface iController

		#Region "Section: Factory"

			Function CreateCloner()				As iClone
			Function CreateSerialiser()		As iSerialiser

		#End Region

	End Interface

End Namespace