Imports System.Windows.Forms
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Utilities.DGV

	Friend NotInheritable Class xDGVImageButtonActionColumn
																Inherits DataGridViewButtonColumn

		Friend Sub New()

			Me.CellTemplate	= New xDGVImageButtonActionCell
			Me.Width				= 22
			Me.Resizable		= DataGridViewTriState.False

		End Sub

	End Class

End Namespace