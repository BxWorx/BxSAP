Imports System.Windows.Forms

Public Class SAPSessionPwrd

	Private cc_pwrd As String

	Friend Sub New(ByVal _pwrd As String)

		InitializeComponent()
		'......................................................
		Me.cc_pwrd = _pwrd

	End Sub

	Private Sub xbtn_Ok_Click(sender As Object, e As EventArgs) Handles xbtn_OK.Click
		If Me.xtbx_Pwrd.Text.Equals(Me.cc_pwrd)
			Me.DialogResult = DialogResult.OK
			Me.Close()
		End If
	End Sub

	Private Sub xbtn_Canc_Click(sender As Object, e As EventArgs) Handles xbtn_Canc.Click
		Me.DialogResult = DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub xbtn_PwdShow_MouseDown(sender As Object, e As MouseEventArgs) Handles xbtn_PwdShow.MouseDown
		Me.xtbx_Pwrd.UseSystemPasswordChar	= False
	End Sub

	Private Sub xbtn_PwdShow_MouseUp(sender As Object, e As MouseEventArgs) Handles xbtn_PwdShow.MouseUp
		Me.xtbx_Pwrd.UseSystemPasswordChar	= True
	End Sub

End Class