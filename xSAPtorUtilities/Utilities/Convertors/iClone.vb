'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Convertors
	Public Interface iClone

		#Region "Methods"

			Function iFace2Instance(Of ClassDefinition			As {Class},
																 InterfaceDefinition  As {Class})(ByVal SrceObject	As InterfaceDefinition)		As ClassDefinition
			Function Instance2iFace(Of ClassDefinition			As {Class},
																 InterfaceDefinition	As {Class})(ByVal SrceObject	As ClassDefinition)				As InterfaceDefinition

		#End Region

	End Interface

End Namespace