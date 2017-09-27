Imports SAPNCO = SAP.Middleware.Connector

Namespace API.Destination
	Public Class BxSNCO
		Implements iBxSNCO

		Private co_NCODest					As SAPNCO.RfcDestination
		Private co_NCOCfgParams			As SAPNCO.RfcConfigParameters

		Public Function Ping() As Boolean _
											Implements iBxSNCO.Ping

			Try

					Me.co_NCODest.Ping
					Return True

				Catch ex As Exception _
					When			TypeOf ex Is	SAPNCO.RfcAbapException	_
						OrElse	TypeOf ex	Is	SAPNCO.RfcAbapClassException	_
						OrElse	TypeOf ex Is	SAPNCO.RfcInvalidStateException	_
						OrElse	TypeOf ex Is	SAPNCO.RfcResourceException	_
						OrElse	TypeOf ex Is	SAPNCO.RfcCommunicationException

					Return False
				
			End Try

			'RfcAbapException:					if a standard ABAP exception is raised during execution of function module RFC_PING 
			'RfcAbapClassException:			if an ABAP class exception is raised during execution of function module RFC_PING 
			'RfcInvalidStateException:	if an invalid state is encountered (such as using an invalid destination, for instance) 
			'RfcResourceException:			if a required resource cannot be allocated (e.g., a client connection) due to resource restrictions 
			'RfcCommunicationException:	if a communication error occurs 

		End Function

		Public Function Connect() As Boolean _
											Implements iBxSNCO.Connect

			Try

					Me.co_NCODest = SAPNCO.RfcDestinationManager.GetDestination(parameters:=co_NCOCfgParams)
					Return True

				Catch ex As Exception
					Return False

			End Try

		End Function

		Public Sub New(ByRef _Dest As iBxSDestParamsDTO)

			Me.LoadConfig(_Dest:= _Dest)

		End Sub

		Private Sub LoadConfig(ByRef _Dest As iBxSDestParamsDTO)

			Me.co_NCOCfgParams	= New SAPNCO.RfcConfigParameters()

			Me.co_NCOCfgParams.Add( SAPNCO.RfcConfigParameters.Name						,_Dest.Name	)
			Me.co_NCOCfgParams.Add(	SAPNCO.RfcConfigParameters.User						,_Dest.User	)
			Me.co_NCOCfgParams.Add(	SAPNCO.RfcConfigParameters.Password				,_Dest.Password	)
			Me.co_NCOCfgParams.Add(	SAPNCO.RfcConfigParameters.AppServerHost	,_Dest.Host	)
			Me.co_NCOCfgParams.Add(	SAPNCO.RfcConfigParameters.Client					,_Dest.Client	)
			Me.co_NCOCfgParams.Add( SAPNCO.RfcConfigParameters.SystemID				,_Dest.SystemID	)
			Me.co_NCOCfgParams.Add( SAPNCO.RfcConfigParameters.SystemNumber		,_Dest.SystemNo	)

		End Sub

	End Class

End Namespace