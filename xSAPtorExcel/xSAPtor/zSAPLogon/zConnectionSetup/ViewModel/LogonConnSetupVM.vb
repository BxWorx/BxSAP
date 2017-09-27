Imports System.Windows.Forms
Imports	System.IO
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend	Class	LogonConnSetupVM
									Implements	iLogonConnSetupVM

		#Region "Definitions"

			Private	WithEvents	co_View		As LogonConnSetupView
			Private							co_Model	As iLogonConnSetupModel
			Private							co_Parent	As IWin32Window

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub Shutdown() _
										Implements	iLogonConnSetupVM.Shutdown
				
				Me.co_View.Close()
				
			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub Show()	_
										Implements iLogonConnSetupVM.Show
			
				If Me.co_View.IsDisposed
					Me.PrepareView()
				End If	

				If Me.co_View.Visible
					If Me.co_View.WindowState = FormWindowState.Minimized
						Me.co_View.WindowState = FormWindowState.Normal
					Else
						Me.co_View.Hide()
					End If
				Else
					If Me.co_Parent Is Nothing
						Me.co_View.Show()
					Else
						Me.co_View.Show(Me.co_Parent)
					End If
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	GetConnSetupDTO()	As	iLogonConnSetupDTO _
													Implements	iLogonConnSetupVM.GetConnSetupDTO

				Return	Me.co_Model.Fetch()

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Construction"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub New(Optional	parent	As IWin32Window	= Nothing)

				Me.co_Model		= New LogonConnSetupModel()
				Me.co_Parent	= parent

				Me.PrepareView()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub Notify(ByVal	_saved	As Boolean )

				Dim lo_DTO	= so_NotifyDTO.Value.Clone()

				lo_DTO.Title	= "SAP GUI: Connection setup"
				lo_DTO.Text		= "Changes saved: "

				If _saved
						lo_DTO.Text	+= "OK"
				Else
						lo_DTO.Text	+= "Error"
				End If

				so_MsgHub.Value.Publish(lo_DTO)

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub eh_FormClosing(	sender As Object,	e	As EventArgs)

				RemoveHandler	Me.co_View.FormClosing								,	AddressOf	Me.eh_FormClosing
				RemoveHandler	Me.co_View.xbtn_FileBrowserSNC.Click	,	AddressOf	Me.eh_FolderBrowser
				RemoveHandler	Me.co_View.xbtn_FileBrowserXML.Click	,	AddressOf	Me.eh_FileBrowser

				If Me.co_View.Changed

					Dim lo_DTO	= Me.co_Model.CreateDTO()

					Me.co_View.UpdatedData(lo_DTO)

					If Me.co_Model.Save(lo_DTO)
						Me.Notify(True)
					Else
					End If

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub eh_FileBrowser(	sender As Object,	e	As EventArgs)

				Dim lo_Dialog		As New OpenFileDialog()
				'..................................................
				lo_Dialog.Title		= "Select SAPGUI xml file"
				lo_Dialog.Filter	= "SAP Config|*.xml"
				'..................................................
				If Me.co_View.xtbx_XMLPath.Text.Length.Equals(0)
					lo_Dialog.InitialDirectory	= String.Format("{0}\SAP", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData))
				Else
					lo_Dialog.InitialDirectory	= Me.co_View.xtbx_XMLPath.Text
				End If
				'..................................................
				If lo_Dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
					Me.co_View.xtbx_XMLPath.Text	= Path.GetDirectoryName(lo_Dialog.FileName)
					Me.co_View.xtbx_XMLFile.Text	= Path.GetFileName(lo_Dialog.FileName)
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub eh_FolderBrowser(	sender As Object,	e	As EventArgs)

				Dim lo_Dialog As New FolderBrowserDialog()

				lo_Dialog.RootFolder		= Environment.SpecialFolder.Desktop
				lo_Dialog.SelectedPath	= Application.StartupPath
				lo_Dialog.Description		= "Select library Path"

				If lo_Dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
					Me.co_View.xtbx_SNCPath.Text	= lo_Dialog.SelectedPath
				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Sub PrepareView()

				Me.co_View	= New LogonConnSetupView()
				Me.co_View.LoadData(Me.co_Model.Fetch())

				AddHandler	Me.co_View.FormClosing								,	AddressOf	Me.eh_FormClosing
				AddHandler	Me.co_View.xbtn_FileBrowserSNC.Click	,	AddressOf	Me.eh_FolderBrowser
				AddHandler	Me.co_View.xbtn_FileBrowserXML.Click	,	AddressOf	Me.eh_FileBrowser

			End Sub

		#End Region

	End Class

End Namespace

