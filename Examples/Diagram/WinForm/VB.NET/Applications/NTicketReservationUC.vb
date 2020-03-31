Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Diagram.WinForm
	Public Class NTicketReservationUC
		Inherits NDiagramExampleUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			m_nFreeSeats = 0
			m_nReservedSeats = 0
			m_nRevenue = 0

			view.BeginInit()
			view.GlobalVisibility.ShowPorts = False
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False
			view.ScrollBars = ScrollBars.None
			view.Grid.Visible = False

			document.BeginInit()
			InitDocument()
			document.EndInit()

			view.EndInit()

			' Init controls
			Dim button As NButton = New NButton()
			button.Text = "Clear Reservations"
			button.SetBounds(5, 5, commonControlsPanel.Width - 10, 20)
			button.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
			AddHandler button.Click, AddressOf OnClearAllButtonClick
			Me.Controls.Add(button)
		End Sub
		Protected Overrides Sub AttachToEvents()
			MyBase.AttachToEvents()

			AddHandler document.EventSinkService.NodeMouseDown, AddressOf OnNodeMouseDown
		End Sub
		Protected Overrides Sub DetachFromEvents()
			MyBase.DetachFromEvents()

			RemoveHandler document.EventSinkService.NodeMouseDown, AddressOf OnNodeMouseDown
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			Dim bitmap As Bitmap = NResourceHelper.BitmapFromResource(Me.GetType(), "Airplane.png", "Nevron.Examples.Diagram.WinForm.Resources")
			document.Width = bitmap.Width
			document.Height = bitmap.Height + 62

			document.BackgroundStyle.FillStyle = New NImageFillStyle(bitmap)

			' Create the style sheets
			Dim free As NStyleSheet = New NStyleSheet("free")
			NStyle.SetInteractivityStyle(free, New NInteractivityStyle(String.Empty, CursorType.Hand))
			NStyle.SetFillStyle(free, New NColorFillStyle(SEAT_COLOR))
			NStyle.SetStrokeStyle(free, New NStrokeStyle(1, Color.Black))
			NStyle.SetTextStyle(free, New NTextStyle(New Font(view.Font, FontStyle.Bold), Color.Blue))
			document.StyleSheets.AddChild(free)

			Dim reserved As NStyleSheet = New NStyleSheet("reserved")
			Dim hatch As NHatchFillStyle = New NHatchFillStyle(HatchStyle.LightUpwardDiagonal, Color.Red, SEAT_COLOR)
			hatch.TextureMappingStyle.MapMode = MapMode.RelativeToViewer
			NStyle.SetFillStyle(reserved, hatch)
			NStyle.SetStrokeStyle(reserved, New NStrokeStyle(1, Color.Black))
			document.StyleSheets.AddChild(reserved)

			Dim x, y As Single
'INSTANT VB NOTE: The local variable distance was renamed since Visual Basic will not uniquely identify class members when local variables have the same name:
			Dim distance_Renamed As Single = DISTANCE
			Dim shape As NShape
			Dim startPoint As Point = LINE1_LEFT
			m_Seats = New List(Of NShape)()

			' Draw the seats
			For y = LINE1_LEFT.Y To 349 Step SEAT_SIZE.Height
				If y > 260 AndAlso y < LINE2_LEFT.Y Then
					y = LINE2_LEFT.Y
					startPoint = LINE2_LEFT
				End If

				If y >= LINE2_LEFT.Y Then
					distance_Renamed = 5.25f
				End If

				For x = startPoint.X To 969 Step SEAT_SIZE.Width + distance_Renamed
					If x > 460 AndAlso x < LINE1_RIGHT.X Then
						x = LINE1_RIGHT.X
						distance_Renamed = DISTANCE
					End If

					m_nFreeSeats += 1
					shape = New NRectangleShape(x, y, SEAT_SIZE.Width, SEAT_SIZE.Height)
					shape.StyleSheetName = "free"
					SetProtections(shape)
					document.ActiveLayer.AddChild(shape)
					m_Seats.Add(shape)
				Next x
			Next y

			' Free seats
			shape = New NRectangleShape(MARGINS, MARGINS, SEAT_SIZE.Width, SEAT_SIZE.Height)
			shape.StyleSheetName = "free"
			SetProtections(shape)
			document.ActiveLayer.AddChild(shape)

			CreateTextShape(m_FreeSeats)
			m_FreeSeats.Location = New NPointF(shape.Bounds.Right + MARGINS, shape.Bounds.Y)

			' Reserved seats
			shape = New NRectangleShape(MARGINS, 2 * MARGINS + SEAT_SIZE.Height, SEAT_SIZE.Width, SEAT_SIZE.Height)
			shape.StyleSheetName = "reserved"
			SetProtections(shape)
			document.ActiveLayer.AddChild(shape)

			CreateTextShape(m_ReservedSeats)
			m_ReservedSeats.Location = New NPointF(shape.Bounds.Right + MARGINS, shape.Bounds.Y)

			' Total revenue
			CreateTextShape(m_Revenue)
			m_Revenue.Location = New NPointF(shape.Bounds.Right + MARGINS, shape.Bounds.Bottom + MARGINS)
			m_Revenue.Style.TextStyle.FontStyle.Style = FontStyle.Bold
			m_Revenue.Style.TextStyle.FillStyle = New NColorFillStyle(Color.MediumBlue)

			UpdateTexts()
		End Sub
		Private Sub SetProtections(ByVal shape As NShape)
			Dim protection As NAbilities = shape.Protection
			protection.ResizeX = True
			protection.ResizeY = True
			protection.Rotate = True
			protection.InplaceEdit = True
			protection.TrackersEdit = True
			protection.MoveX = True
			protection.MoveY = True
			protection.Select = True
			shape.Protection = protection
		End Sub
		Private Sub CreateTextShape(ByRef shape As NShape)
			shape = New NRectangleShape(0, 0, SEAT_SIZE.Width * 10, SEAT_SIZE.Height)
			NStyle.SetFillStyle(shape, New NColorFillStyle(Color.White))
			NStyle.SetStrokeStyle(shape, New NStrokeStyle(0, Color.White))
			NStyle.SetTextStyle(shape, New NTextStyle())
			shape.Style.TextStyle.StringFormatStyle = New NStringFormatStyle(StringFormatType.GenericTypographic, HorzAlign.Left, VertAlign.Center)
			SetProtections(shape)
			document.ActiveLayer.AddChild(shape)
		End Sub
		Private Sub UpdateTexts()
			m_FreeSeats.Text = String.Format(FREE_SEATS, m_nFreeSeats)
			m_ReservedSeats.Text = String.Format(RESERVED_SEATS, m_nReservedSeats)
			m_Revenue.Text = String.Format(REVENUE, m_nRevenue)
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub OnNodeMouseDown(ByVal args As NNodeMouseEventArgs)
			Dim shape As NShape = TryCast(args.Node, NShape)
			If shape Is Nothing Then
				Return
			End If

			If shape.StyleSheetName = "reserved" Then
				shape.Tag = False
				shape.StyleSheetName = "free"
				m_nFreeSeats += 1
				m_nReservedSeats -= 1
				m_nRevenue -= 50
			Else
				shape.StyleSheetName = "reserved"
				m_nFreeSeats -= 1
				m_nReservedSeats += 1
				m_nRevenue += 50
			End If

			UpdateTexts()
			view.Refresh()
		End Sub
		Private Sub OnClearAllButtonClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim i As Integer, seatCount As Integer = m_Seats.Count
			i = 0
			Do While i < seatCount
				Dim shape As NShape = m_Seats(i)
				If shape.StyleSheetName = "reserved" Then
					shape.StyleSheetName = "free"
				End If
				i += 1
			Loop

			m_nFreeSeats += m_nReservedSeats
			m_nReservedSeats = 0
			m_nRevenue = 0
			UpdateTexts()
			view.Refresh()
		End Sub

		#End Region

		#Region "Fields"

		Private m_FreeSeats As NShape
		Private m_ReservedSeats As NShape
		Private m_Revenue As NShape
		Private m_Seats As List(Of NShape)

		Private m_nFreeSeats As Integer
		Private m_nReservedSeats As Integer
		Private m_nRevenue As Integer

		#End Region

		#Region "Constants"

		Private Const MARGINS As Integer = 5
		Private Const DISTANCE As Single = 4.25f
		Private Shared ReadOnly SEAT_COLOR As Color = Color.LemonChiffon
		Private Shared ReadOnly SEAT_SIZE As Size = New Size(21, 22)
		Private Shared ReadOnly LINE1_LEFT As Point = New Point(299, 209)
		Private Shared ReadOnly LINE1_RIGHT As Point = New Point(587, 209)
		Private Shared ReadOnly LINE2_LEFT As Point = New Point(291, 296)
		Private Shared ReadOnly LINE2_RIGHT As Point = New Point(587, 296)

		Private Const FREE_SEATS As String = "Free seats: {0}"
		Private Const RESERVED_SEATS As String = "Reserved seats: {0}"
		Private Const REVENUE As String = "Total revenue: ${0}"

		#End Region
	End Class
End Namespace