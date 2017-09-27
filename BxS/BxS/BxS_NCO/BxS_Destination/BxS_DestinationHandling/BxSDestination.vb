Imports SAPNCO = SAP.Middleware.Connector
Imports	BxS.API.Destination
Imports	BxS.API.Destination.Monitor
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Destination

	Public Class BxSDestination
								Implements	iBxSDestination

		#Region "Properties"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	RfcUser	As String	_
																		Implements	iBxSDestination.RfcUser
				Get
					Return Me.RfcDestination.User
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	cc_DestID	As String
			Friend	ReadOnly	Property	RfcDestID	As String	_
																		Implements	iBxSDestination.RfcDestID
				Get
					Return Me.cc_DestID
				End Get
			End Property
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	ReadOnly	Property	RfcDestination()	As SAPNCO.RfcCustomDestination	_
																		Implements	iBxSDestination.RfcDestination

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Ping()	As Boolean Implements iBxSDestination.Ping

				Dim lb_Ret	As Boolean = False

				If Me.RfcDestination IsNot Nothing

					Try

							Me.RfcDestination.Ping()
							lb_Ret  = True

						Catch ex1 As Exception

							'When SAPnco.RfcAbapException           OrElse    ' if a standard ABAP exception is raised during execution of function module RFC_PING 
							'     SAPnco.RfcAbapClassException      OrElse    ' if an ABAP class exception is raised during execution of function module RFC_PING 
							'     SAPnco.RfcInvalidStateException   AndAlso   ' if an invalid state is encountered (such as using an invalid destination, for instance) 
							'     SAPnco.RfcResourceException       AndAlso   ' if a required resource cannot be allocated (e.g., a client connection) due to resource restrictions 
							'     SAPnco.RfcCommunicationException            ' if a communication error occurs 

					End Try
					
				End If

				Return lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Configure(						ByVal client		As String,
																							ByVal user			As String,
																							ByVal password	As String,
																		Optional  ByVal language	As String		= "EN",
																		Optional	ByVal	useSAPGUI	As Boolean	= False )	As Boolean _
													Implements	iBxSDestination.Configure

				Me.RfcDestination.Client		= client
				Me.RfcDestination.User			= user
				Me.RfcDestination.Password	= password
				Me.RfcDestination.Language	= language
				Me.RfcDestination.UseSAPGui	=	IIf(useSAPGUI, "X"c, " "c).ToString

				Return True

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Function	GetMonitorData()	As List(Of iBxSDestMonitorDTO) _
													Implements iBxSDestination.GetMonitorData

				Dim lt_List	As New List(Of iBxSDestMonitorDTO)

				For Each lo	In Me.RfcDestination.Monitor.GetConnectionsData

					Dim lo_DTO	As	New BxSDestMonitorDTO()

					lo_DTO.ConversationID	= lo.ConversationID
					lo_DTO.SessionID			=	lo.SessionId
					lo_DTO.SystemID				=	lo.SystemID
					lo_DTO.Type						=	lo.ConnectionType
					lo_DTO.Client					=	lo.AbapClient
					lo_DTO.Host						=	lo.AbapHost
					lo_DTO.Language				=	lo.AbapLanguage
					lo_DTO.SystemNo				=	lo.AbapSystemNumber
					lo_DTO.User						=	lo.AbapUser
					lo_DTO.FncModuleName	=	lo.FunctionModuleName

					Select Case  lo.CurrentState
						Case SAPNCO.RfcConnectionData.ConnectionStates.ACTIVE		: lo_DTO.State  = "Active"
						Case SAPNCO.RfcConnectionData.ConnectionStates.STATEFUL	: lo_DTO.State  = "Stateful"
						Case SAPNCO.RfcConnectionData.ConnectionStates.POOLED		: lo_DTO.State  = "Pooled"
						Case Else																								: lo_DTO.State  = "Unknown"
					End Select

					lt_List.Add(lo_DTO)

				Next
				
				Return lt_List

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(	ByVal	rfcDestID								As String,
											ByVal rfcCustomerDestination	As SAPNCO.RfcCustomDestination)

				Me.cc_DestID			= rfcDestID
				Me.RfcDestination	= rfcCustomerDestination

			End Sub
		
		#End Region

	End Class

End Namespace