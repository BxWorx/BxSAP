Imports System.IO
Imports System.Runtime.Serialization
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System.Threading
Imports xSAPtorExcel.Services.Excel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Config

	Friend Class xSAPConfigController
								Implements ixSAPConfigController

		#Region "Definitions"

			Private co_Environment  As Lazy(Of iEnvironment)  = New Lazy(Of iEnvironment)(
								Function()
										Return Environment.GetInstance()
								End Function, LazyThreadSafetyMode.ExecutionAndPublication )

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Function SaveLogonConfiguration(ByVal i_Config As xSAPLogonData) As Boolean Implements ixSAPConfigController.SaveLogonConfiguration

				Dim lb_Return As Boolean  = False

				Try

						If Me.CreatePath()
						
							Using lo_FSWriter As FileStream = File.Create(Me.CompileFullName, FileMode.Create)

								Dim lo_DCSerializer As New DataContractSerializer(i_Config.GetType())

								lo_DCSerializer.WriteObject(lo_FSWriter, i_Config)

							End Using

							lb_Return = True
						
						Else
							Return False
						End If

					Catch ex As Exception

				End Try

				Return lb_Return

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Function FetchLogonConfiguration()  As xSAPLogonData Implements ixSAPConfigController.FetchLogonConfiguration

				Dim lo_XMLConfig  As xSAPLogonData = New xSAPLogonData

				Try

						Using lo_FSReader As New FileStream(Me.CompileFullName, FileMode.Open, FileAccess.Read)

							Dim lo_DCSerializer As New DataContractSerializer(lo_XMLConfig.GetType())

							lo_XMLConfig = DirectCast(lo_DCSerializer.ReadObject(lo_FSReader), xSAPLogonData)

						End Using

					Catch ex As Exception

						lo_XMLConfig  = New xSAPLogonData 

				End Try

				Return lo_XMLConfig

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Private Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function CreatePath() As Boolean

				Try

						Dim lc_File As String = Me.CompilePathName

						If Not Directory.Exists(lc_File)

							Dim securityRules As DirectorySecurity  = New DirectorySecurity()
							Dim userSid       As SecurityIdentifier = WindowsIdentity.GetCurrent().User

							securityRules.AddAccessRule(New FileSystemAccessRule(userSid,
																																		FileSystemRights.FullControl,
																																		InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit,
																																		PropagationFlags.None,
																																		AccessControlType.Allow))

							Directory.CreateDirectory(lc_File)  ', securityRules)

						End If

						Return True

					Catch ex As Exception
						Return False

				End Try

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function CompileFullName() As String
				Return String.Concat(Me.CompilePathName, "\", Me.CompileAppName, ".xml")
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function CompilePathName() As String
				Return String.Concat(Me.co_Environment.Value.UserAppDataPath, "\", Me.CompileAppName)
			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function CompileAppName() As String

				If My.Application.Info.Title <> "" Then
					Return My.Application.Info.Title
				Else
					Return IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
				End If

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Sub New()
			End Sub

		#End Region

	End Class

End Namespace
