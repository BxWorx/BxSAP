Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Utilities.DGV

	Friend Class xgdvProgressCell
								Inherits DataGridViewImageCell

		'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
		Protected Overrides Function GetFormattedValue(ByVal value												As Object,
																									 ByVal rowIndex											As Integer,
																									 ByRef cellStyle										As DataGridViewCellStyle,
																									 ByVal valueTypeConverter						As TypeConverter,
																									 ByVal formattedValueTypeConverter	As TypeConverter,
																									 ByVal context											As DataGridViewDataErrorContexts) _
																	As Object


			Dim lo As DataGridViewCell = Me.DataGridView.Rows(rowIndex).Cells(Me.ColumnIndex)

			Dim lo_bmp As Bitmap = New Bitmap(lo.Size.Width,
																				lo.Size.Height)

			Using lo_Graphics As Graphics = Graphics.FromImage(lo_bmp)

				Dim ln_Perc As Double = 0
				Double.TryParse(value.ToString(), ln_Perc)
				Dim lc_Text As String = ln_Perc.ToString()		'+ " %"

				' Get width and height of text
				'
				Dim lo_F	As Font			= New Font("Courier New", 10, FontStyle.Regular)
				Dim lo_W	As Integer	= CInt(lo_Graphics.MeasureString(lc_Text, lo_F).Width)
				Dim lo_H	As Integer	= CInt(lo_Graphics.MeasureString(lc_Text, lo_F).Height)

				' Draw pile
				'
				lo_Graphics.DrawRectangle(Pens.Black, 2, 2, lo.Size.Width - 6, lo.Size.Height - 6)
				lo_Graphics.FillRectangle(Brushes.Blue, 3, 3, CInt((lo.Size.Width - 6) * ln_Perc / 100), CInt(lo.Size.Height - 7))

				Dim lo_Rect	As RectangleF		= New RectangleF(0, 2, lo_bmp.Width, lo_bmp.Height)
				Dim lo_sf		As StringFormat	= New StringFormat()

				lo_sf.Alignment = StringAlignment.Center
				lo_Graphics.DrawString(lc_Text, lo_F, Brushes.Red, lo_Rect, lo_sf)

			End Using

			Return lo_bmp

		End Function

	End Class

End Namespace