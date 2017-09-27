Imports System.Windows.Forms
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Utilities.DGV

	Friend Class xDGVImageButtonActionCell
								Inherits xDGVImageButtonCell

		Public Overrides Sub LoadButtonImages()

			Me._ButtonImageDisabled	= My.Resources.Test_line
			Me._ButtonImageHot			= My.Resources.Spiral
			Me._ButtonImageNormal		= My.Resources.Show
			Me._ButtonImagePressed	= My.Resources.Save

		End Sub

	End Class

End Namespace