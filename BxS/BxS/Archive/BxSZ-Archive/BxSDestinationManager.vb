Imports SAPNCO = SAP.Middleware.Connector
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Destination

	Public Class BxSDestinationManager
		Implements iBxSDestinationManager

		Private co_SAPIni				As Lazy(Of SAPNCO.SapLogonIniConfiguration) _
																= New Lazy(Of SAPNCO.SapLogonIniConfiguration) _
																		( Function() SAPNCO.SapLogonIniConfiguration.Create()	)

		Private co_DstCfg				As iBxSDestinationConfiguration
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Public Function GetDestinationList() As List(Of String) _
											Implements iBxSDestinationManager.GetDestinationList

			Dim la_List	As List(Of String)	= New List(Of String)()

			If SAPNCO.RfcDestinationManager.IsDestinationConfigurationRegistered()
				For Each lc_ID In	Me.co_SAPIni.Value.GetEntries
					la_List.Add(lc_ID)
				Next
			End If

			Return la_List

		End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Public Function GetDestination(rfcDestID As String) As SAPNCO.RfcCustomDestination _
											Implements iBxSDestinationManager.GetDestination

			Try
					
					Return SAPNCO.RfcDestinationManager.GetDestination(destinationName:=rfcDestID).CreateCustomDestination()

				Catch ex As Exception _
					When			TypeOf	ex Is SAPNCO.RfcInvalidStateException _
						OrElse	TypeOf	ex Is SAPNCO.RfcInvalidParameterException

					Return Nothing

			End Try

		End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		'Public Function GetDestination(rfcDestID		As String, _
		'															 rfcLogonDTO	As iBxSLogonParamsDTO) As SAPNCO.RfcCustomDestination _
		'									Implements iBxSDestinationManager.GetDestination

		'	Try
					
		'			Dim lo_Dest	As SAPNCO.RfcCustomDestination
				
		'			lo_Dest						= SAPNCO.RfcDestinationManager.GetDestination(destinationName:=rfcDestID).CreateCustomDestination()
		'			lo_Dest.Client		= rfcLogonDTO.Client
		'			lo_Dest.User			= rfcLogonDTO.User
		'			lo_Dest.Password	= rfcLogonDTO.Password

		'			Return lo_Dest

		'		Catch ex As Exception _
		'			When			TypeOf	ex Is SAPNCO.RfcInvalidStateException _
		'				OrElse	TypeOf	ex Is SAPNCO.RfcInvalidParameterException

		'			Return Nothing

		'	End Try
		'End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Public Function GetDestination(ByRef rfcCfgParam As SAPNCO.RfcConfigParameters) As SAPNCO.RfcCustomDestination _
											Implements iBxSDestinationManager.GetDestination

			Try

					Return SAPNCO.RfcDestinationManager.GetDestination(parameters:=rfcCfgParam).CreateCustomDestination()

				Catch ex As Exception _
					When			TypeOf	ex Is SAPNCO.RfcInvalidStateException _
						OrElse	TypeOf	ex Is SAPNCO.RfcInvalidParameterException _
						OrElse	TypeOf	ex Is SAPNCO.RfcConfigurationException

					Return Nothing

			End Try

		End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		'Public Function Register(ByRef rfcDestConfig As iBxSDestinationConfiguration) As Boolean _
		'									Implements iBxSDestinationManager.Register

		'	Try

		'			SAPNCO.RfcDestinationManager.RegisterDestinationConfiguration(config:=rfcDestConfig)
		'			Me.co_DstCfg	= rfcDestConfig
		'			Return True

		'		Catch ex As Exception _
		'			When			TypeOf	ex Is SAPNCO.RfcInvalidStateException _
		'				OrElse	TypeOf	ex Is SAPNCO.RfcInvalidParameterException

		'			Return False

		'	End Try

		'End Function
		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Public Function Unregister() As Boolean _
											Implements iBxSDestinationManager.Unregister

			Try

					SAPNCO.RfcDestinationManager.UnregisterDestinationConfiguration(config:=Me.co_DstCfg)
					Return True

				Catch ex As Exception _
					When			TypeOf	ex Is SAPNCO.RfcInvalidStateException _
						OrElse	TypeOf	ex Is SAPNCO.RfcInvalidParameterException

					Return False

			End Try

		End Function

	End Class

	'RfcInvalidStateException:			if a configuration is registered 
	'RfcInvalidParameterException:	if destination name/alias is null or not available (see Name) 
	'																if the reserved destination name BACK is used 
	'RfcConfigurationException:			Configuration value invalid

End Namespace
