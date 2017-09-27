Imports System.Drawing
Imports System.Windows.Forms
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Utilities.DGV

	Friend MustInherit Class xDGVImageButtonCell
														Inherits DataGridViewButtonCell

		Protected Sub New()

			FlatStyle = FlatStyle.Flat

			' Default behaviour is enabled
			Me._ButtonEnabled	= True
			Me._ButtonState		= VisualStyles.PushButtonState.Normal

			' Changing this value affects the appearance of the image on the button.
			Me._ButtonImageOffset = 2I

			' Because this is MustInherit, the designer decides which buttons are used where
			Me.LoadButtonImages()

		End Sub


		Private _ButtonEnabled	As Boolean
		Private _ButtonState		As VisualStyles.PushButtonState

		Protected _ButtonImageHot				As Image
		Protected _ButtonImageNormal		As Image
		Protected _ButtonImageDisabled	As Image
		Protected _ButtonImagePressed		As Image
		Private		_ButtonImageOffset		As Integer
		Private		_Loading							As Boolean	= True


			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub DisposeAndDestroyImageFiles()

				Try

					Me._ButtonImageDisabled.Dispose()
					Me._ButtonImageHot.Dispose()
					Me._ButtonImageNormal.Dispose()
					Me._ButtonImagePressed.Dispose()

				Finally

					Me._ButtonImageDisabled = Nothing
					Me._ButtonImageHot			= Nothing
					Me._ButtonImageNormal		= Nothing
					Me._ButtonImagePressed	= Nothing

				End Try

			End Sub


			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Protected Overrides Sub Paint(graphics						As Graphics,
																		clipBounds					As Rectangle,
																		cellBounds					As Rectangle,
																		rowIndex						As Integer,
																		elementState				As DataGridViewElementStates,
																		value								As Object,
																		formattedValue			As Object,
																		errorText						As String,
																		cellStyle						As DataGridViewCellStyle,
																		advancedBorderStyle	As DataGridViewAdvancedBorderStyle,
																		paintParts					As DataGridViewPaintParts)

				'MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)

				If (paintParts And DataGridViewPaintParts.Background).Equals(DataGridViewPaintParts.Background) Then
					Using CellBackground As New SolidBrush(cellStyle.BackColor)
						graphics.FillRectangle(CellBackground, cellBounds)
					End Using
				End If

				If (paintParts And DataGridViewPaintParts.Border).Equals(DataGridViewPaintParts.Border) Then
					PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle)
				End If

				' Because the area in which to draw the button needs to be known,
				' start with the current bounds of the cell and the rectangle
				' representing the borders (DataGridViewAdvancedBorderStyle)

				Dim ButtonArea						As Rectangle = cellBounds
				Dim ButtonBorderAllowance As Rectangle = BorderWidths(advancedBorderStyle)

				' Because there are some adjustments to be made
				Dim ImageHeight	As Integer	= Math.Min(ButtonArea.Height,	If(Me.ButtonImage Is Nothing, 9999I, Me.ButtonImage.Size.Height))
				Dim ImageWidth	As Integer	= Math.Min(ButtonArea.Width,	If(Me.ButtonImage Is Nothing, 9999I, Me.ButtonImage.Width))
				Dim WidthDiff		As Integer	= CInt((cellBounds.Width	- Math.Min(32I, ImageWidth))	/ 2I) - ButtonBorderAllowance.Width
				Dim HeightDiff	As Integer	= CInt((cellBounds.Height - Math.Min(32I, ImageHeight)) / 2I) - ButtonBorderAllowance.Height

				' Because, now the borders are known, the area needs to be amended. Moving the
				' (X,Y) in and down allows for the top and left borders while shrinking height
				' and width allows for bottom and right

				With ButtonArea
					.X			+= ButtonBorderAllowance.X
					.Y			+= ButtonBorderAllowance.Y
					.Height -= ( ButtonBorderAllowance.Height * 2 )
					.Width	-= ( ButtonBorderAllowance.Width	* 2 )
				End With

				' Because this is where the image will be drawn
				Dim ImageArea As New Rectangle(ButtonArea.X + WidthDiff, ButtonArea.Y + HeightDiff, ImageWidth, ImageHeight)

				' Because the last step is to paint the button image
				ButtonRenderer.DrawButton(graphics, ButtonArea, Me.ButtonImage, ImageArea, False, Me.ButtonState)

			End Sub


		Friend Property Enabled() As Boolean
			Get
				Return _ButtonEnabled
			End Get

			Set(value As Boolean)
				_ButtonEnabled	= value
				_ButtonState		= If(value, VisualStyles.PushButtonState.Normal, VisualStyles.PushButtonState.Disabled)
			End Set
		End Property

		Friend Property ButtonState() As VisualStyles.PushButtonState
			Get
				Return _ButtonState
			End Get
			Set(value As VisualStyles.PushButtonState)
				_ButtonState = value
			End Set
		End Property

		Public ReadOnly Property ButtonImage() As Image
			Get
				Select Case _ButtonState
					Case VisualStyles.PushButtonState.Disabled	:	Return _ButtonImageDisabled
					Case VisualStyles.PushButtonState.Hot				:	Return _ButtonImageHot
					Case VisualStyles.PushButtonState.Normal		:	Return _ButtonImageNormal
					Case VisualStyles.PushButtonState.Pressed		:	Return _ButtonImagePressed
					Case VisualStyles.PushButtonState.[Default]	:	Return _ButtonImageNormal
					Case Else																		:	Return _ButtonImageNormal
				End Select
			End Get
		End Property


		Friend Sub SetButtonStateImage(ByVal buttonState As VisualStyles.PushButtonState,
																	 ByVal buttonImage As Bitmap)

			' NOTE WELL: [Default] image is [Normal] and anything outside the known values is ignored
			Select Case buttonState
				Case	VisualStyles.PushButtonState.Disabled
					Me._ButtonImageDisabled.Dispose()
					Me._ButtonImageDisabled = buttonImage

				Case	VisualStyles.PushButtonState.Hot
					Me._ButtonImageHot.Dispose()
					Me._ButtonImageHot = buttonImage

				Case	VisualStyles.PushButtonState.Normal,
							VisualStyles.PushButtonState.Default
					Me._ButtonImageNormal.Dispose()
					Me._ButtonImageNormal = buttonImage

				Case	VisualStyles.PushButtonState.Pressed
					Me._ButtonImagePressed.Dispose()
					Me._ButtonImagePressed = buttonImage

			End Select

		End Sub

		Public Overloads Sub Dispose()
			MyBase.Dispose(True)
			Me.DisposeAndDestroyImageFiles()
		End Sub

		Public MustOverride Sub LoadButtonImages()

	End Class

End Namespace