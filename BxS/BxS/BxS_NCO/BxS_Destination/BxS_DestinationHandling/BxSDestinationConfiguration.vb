Imports SAPNCO = SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Destination

	Friend Class BxSDestinationConfiguration
								Implements iBxSDestinationConfiguration

		Private ct_Configs	As Dictionary(Of String, SAPNCO.RfcConfigParameters)

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Public Event ConfigurationChanged As SAPNCO.RfcDestinationManager.ConfigurationChangeHandler _
									Implements SAPNCO.IDestinationConfiguration.ConfigurationChanged

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Public Function ChangeEventsSupported() As Boolean _
											Implements SAPNCO.IDestinationConfiguration.ChangeEventsSupported
			Return True
		End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Public Function DestinationCount() As Integer _
											Implements iBxSDestinationConfiguration.DestinationCount

			Return Me.ct_Configs.Count

		End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Public Function GetEntries() As List(Of String) _
											Implements iBxSDestinationConfiguration.GetEntries

			Return Me.ct_Configs.Keys.ToList

		End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Public Function GetParameters(rfcDestID As String) As SAPNCO.RfcConfigParameters _
											Implements SAPNCO.IDestinationConfiguration.GetParameters

			Dim lo_CfgParams	As SAPNCO.RfcConfigParameters	= Nothing

			Me.ct_Configs.TryGetValue(key:=rfcDestID, value:=lo_CfgParams)

			Return lo_CfgParams

		End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Public Function AddDestinationConfig(	rfcDestID					As String, _
																					rfcCfgParameters	As SAPNCO.RfcConfigParameters) As Boolean _
											Implements iBxSDestinationConfiguration.AddDestinationConfig

			If Not Me.ct_Configs.ContainsKey(rfcDestID)
				Me.ct_Configs.Add(key:=rfcDestID, value:=rfcCfgParameters)
				Return True
			Else
				Return False
			End If

		End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Public Function UpdateDestinationConfig(rfcDestID					As String, _
																						rfcCfgParameters	As SAPNCO.RfcConfigParameters) As Boolean _
											Implements iBxSDestinationConfiguration.UpdateDestinationConfig

			If Me.ct_Configs.ContainsKey(rfcDestID)
				Me.ct_Configs.Item(key:=rfcDestID) = rfcCfgParameters
			Else
				Me.ct_Configs.Add(key:=rfcDestID, value:=rfcCfgParameters)
			End If
			Return	True

		End Function
		''¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		'Public Function ModifyDestinationConfig(rfcDestID					As String, _
		'																				rfcCfgParameters	As iBxSDestParamsDTO) As Boolean _
		'									Implements iBxSDestinationConfiguration.ModifyDestinationConfig

		'	Dim lo_CfgParams	As SAPNCO.RfcConfigParameters	= Nothing
		'	Dim lb_Ret				As Boolean										= True

		'	If Me.ct_Configs.TryGetValue(key:=rfcDestID, value:=lo_CfgParams)

		'		rfcCfgParameters.GetType.GetProperties.ToList.ForEach( 
		'			Sub(x)

		'				Dim lc_Val As String = CType( x.GetValue(rfcCfgParameters), String)
		'				If Not IsNothing(lc_Val)

		'					x.GetCustomAttributesData.ToList.ForEach(
		'						Sub(y)

		'							Dim lc_ID	As String

		'							lc_ID =	y.ConstructorArguments(0).Value.ToString
		'							lo_CfgParams.Item(lc_ID) = lc_Val

		'						End Sub )

		'				End If

		'			End Sub )

		'		Me.ct_Configs.Item(key:=rfcDestID) = lo_CfgParams

		'	Else
		'		lb_Ret	= False
		'	End If

		'	Return lb_Ret

		'End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Private Function xx() As Boolean _
											Handles Me.ConfigurationChanged
			Return True
		End Function

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Public Sub New

			Me.ct_Configs	= New Dictionary(Of String, SAPNCO.RfcConfigParameters)

		End Sub

	End Class

End Namespace