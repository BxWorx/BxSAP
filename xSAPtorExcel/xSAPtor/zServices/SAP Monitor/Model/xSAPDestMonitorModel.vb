Imports System.Threading.Tasks
Imports BxS.API.Destination
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Services.DestinationMonitor

	Friend Class xSAPDestMonitorModel
								Implements ixSAPDestMonitorModel

		#Region "Events"

			Friend Event ev_Changed() Implements ixSAPDestMonitorModel.ev_Changed

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Async Function GetMonitorData() _
												As Task(Of List(Of ixSAPDestMonitorDTO)) _
													Implements ixSAPDestMonitorModel.GetMonitorData

				Dim lt_Srce	As List(Of iBxSDestMonitorDTO)
				Dim lt_Trgt	As New List(Of ixSAPDestMonitorDTO)
			
				lt_Srce = Await Me.co_Cntlr.GetDestMonitorDataAsync()

				For Each lo	In lt_Srce

					Dim lo_NewEntry As ixSAPDestMonitorDTO = New xSAPDestMonitorDTO

					lo_NewEntry.ConversationID	= lo.ConversationID
					lo_NewEntry.State						= lo.State
					lo_NewEntry.SystemID				= lo.SystemID
					lo_NewEntry.User						= lo.User
					lo_NewEntry.Client					= lo.Client
					lo_NewEntry.FncModuleName		= lo.FncModuleName

					lt_Trgt.Add(lo_NewEntry)

				Next

				Return lt_Trgt

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Function FetchOptions() _
												As ixSAPDestMonOptionsDTO _
													Implements ixSAPDestMonitorModel.FetchOptions

				Dim lo_Options	As ixSAPDestMonOptionsDTO	= New xSAPDestMonOptionsDTO

				lo_Options.RefreshRate	= My.Settings.xSAPDestMonOptions_RefreshRate

				Return lo_Options

			End Function

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		 Friend	Function SaveOptions(ByVal Options As ixSAPDestMonOptionsDTO)	_
											As Boolean _
												Implements ixSAPDestMonitorModel.SaveOptions

				Dim lb_Ret	As Boolean	= True

				My.Settings.xSAPDestMonOptions_RefreshRate	= Options.RefreshRate

				Try

						My.Settings.Save()

					Catch ex As Exception

						lb_Ret	= False

				End Try

				Return lb_Ret

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			Private co_Cntlr	As ixServicesController
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New(ByVal i_Cntlr	As ixServicesController)

				Me.co_Cntlr	= i_Cntlr

			End Sub

		#End Region

	End Class


End Namespace