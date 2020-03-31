Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Summary description for NWorldCup2006RenderPage.
	''' </summary>
	Public Partial Class NWorldCup2006RenderPage
		Inherits NDrawingViewHostPage
		#Region "Constructors"

		''' <summary>
		''' Default constructor.
		''' </summary>
		Public Sub New()
			FLAGS = Nothing
			InitImages()

			DrawingView = New NDrawingView()
			DrawingView.ViewLayout = CanvasLayout.Stretch

			Dim swfResponse As NImageResponse = New NImageResponse()
			swfResponse.ImageFormat = New NSwfImageFormat()
			swfResponse.StreamImageToBrowser = True
			DrawingView.ServerSettings.BrowserResponseSettings.DefaultResponse = swfResponse

			' init document
			Dim document As NDrawingDocument = DrawingView.Document
			document.BeginInit()
			CreateScene(document)
			document.EndInit()

			DrawingView.SizeToContent()
		End Sub

		#End Region

		#Region "Private Methods"

		Private Sub CreateScene(ByVal document As NDrawingDocument)
			document.BackgroundStyle.FrameStyle.Visible = False

			' change default document styles
			document.Style.TextStyle.TextFormat = TextFormat.XML
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant1, New NArgbColor(155, 184, 209), New NArgbColor(83, 138, 179))

			' the fill style for the cells
			Dim transparent As NStyleSheet = New NStyleSheet("transparent")
			NStyle.SetFillStyle(transparent, New NColorFillStyle(KnownArgbColorValue.Transparent))
			document.StyleSheets.AddChild(transparent)

			Dim shapes As NNodeList = New NNodeList()
			Dim shape1 As NShape, shape2 As NShape, winner As NShape = Nothing
			Dim i As Integer, depth As Integer = 0
			Dim count As Integer = MATCHES.Length

			i = 0
			Do While i < count
				winner = CreateShape(MATCHES(i))
				shapes.Add(winner)

				If i >= 8 Then
					If i < 12 Then
						depth = 0
						shape1 = CType(shapes((i - 8) * 2), NShape)
						shape2 = CType(shapes((i - 8) * 2 + 1), NShape)
					ElseIf i < 14 Then
						depth = 2
						shape1 = CType(shapes(8 + (i - 12) * 2), NShape)
						shape2 = CType(shapes(8 + (i - 12) * 2 + 1), NShape)
					Else
						depth = 4
						shape1 = CType(shapes(12), NShape)
						shape2 = CType(shapes(13), NShape)
					End If

					SetAnimationsStyle(shape1, depth)
					SetAnimationsStyle(shape2, depth)

					ConnectShapes(shape1, shape2, winner, depth + 1)
				End If
				i += 1
			Loop

			SetAnimationsStyle(winner, depth + 2)

			Dim layout As NLayeredGraphLayout = New NLayeredGraphLayout()
			layout.Direction = LayoutDirection.LeftToRight
			layout.Layout(shapes, New NDrawingLayoutContext(document))

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub
		Private Sub ConnectShapes(ByVal shape1 As NShape, ByVal shape2 As NShape, ByVal winner As NShape, ByVal depth As Integer)
			Dim document As NDrawingDocument = DrawingView.Document
			Dim port As NPort = CType(winner.Ports.GetChildByName("Left"), NPort)

			Dim connector As NRoutableConnector = New NRoutableConnector()
			document.ActiveLayer.AddChild(connector)
			connector.FromShape = shape2
			connector.EndPlug.Connect(port)
			SetAnimationsStyle(connector, depth)

			connector = New NRoutableConnector()
			document.ActiveLayer.AddChild(connector)
			connector.FromShape = shape1
			connector.EndPlug.Connect(port)
			SetAnimationsStyle(connector, depth)
		End Sub
		Private Function CreateShape(ByVal m As Match) As NTableShape
			Dim document As NDrawingDocument = DrawingView.Document
			Dim table As NTableShape = New NTableShape()
			document.ActiveLayer.AddChild(table)

			table.InitTable(3, 2)
			table.BeginUpdate()

			table.CellPadding = New Nevron.Diagram.NMargins(2)
			table.ShowGrid = False

			Dim column As NTableColumn = CType(table.Columns.GetChildAt(1), NTableColumn)
			column.SizeMode = TableColumnSizeMode.Fixed
			column.Width = 90

			table(0, 0).Bitmap = FLAGS(m.team1)
			table(1, 0).Text = m.team1
			table(2, 0).Text = m.score1.ToString()

			table(0, 1).Bitmap = FLAGS(m.team2)
			table(1, 1).Text = m.team2
			table(2, 1).Text = m.score2.ToString()

			' write the winner in bold
			If m.score1 > m.score2 Then
				table(1, 0).Text = "<b>" & table(1, 0).Text & "</b>"
				table(2, 0).Text = "<b>" & table(2, 0).Text & "</b>"
			Else
				table(1, 1).Text = "<b>" & table(1, 1).Text & "</b>"
				table(2, 1).Text = "<b>" & table(2, 1).Text & "</b>"
			End If

			' make all cells transparent so that the background of the table is visible
			Dim i, j As Integer
			Dim rowCount As Integer = table.RowCount, colCount As Integer = table.ColumnCount
			i = 0
			Do While i < rowCount
				j = 0
				Do While j < colCount
					table(j, i).StyleSheetName = "transparent"
					j += 1
				Loop
				i += 1
			Loop

			table.EndUpdate()
			table.Ports.DefaultInwardPortUniqueId = (CType(table.Ports.GetChildByName("Right"), NPort)).UniqueId

			Return table
		End Function
		Private Sub SetAnimationsStyle(ByVal shape As NShape, ByVal depth As Integer)
			shape.Style.AnimationsStyle = New NAnimationsStyle()

			If depth > 0 Then
				Dim fade As NFadeAnimation = New NFadeAnimation(0, depth * ANIMATION_DURATION)
				fade.EndAlpha = 0
				shape.Style.AnimationsStyle.Animations.Add(fade)
			End If

			shape.Style.AnimationsStyle.Animations.Add(New NFadeAnimation(depth * ANIMATION_DURATION, ANIMATION_DURATION))
		End Sub

		Private Sub InitImages()
			If Not FLAGS Is Nothing Then
				Return
			End If

			FLAGS = New Dictionary(Of String, Bitmap)()
			Dim flagBounds As Rectangle = New Rectangle(0, 0, 24, 16)
			Using allFlags As Bitmap = New Bitmap(Server.MapPath("~\Images\flags.png"))
				Dim x As Integer = 0, y As Integer = 0

				For i As Integer = 0 To 7
					' create flag for team1
					CreateFlagForTeam(allFlags, x, y, MATCHES(i).team1)

					' advance coordinates
					y += 16

					' create flag for team2
					CreateFlagForTeam(allFlags, x, y, MATCHES(i).team2)
					y += 16

					If i = 3 Then
						x = 24
						y = 0
					End If
				Next i
			End Using
		End Sub
		Private Sub CreateFlagForTeam(ByVal allFlags As Bitmap, ByVal x As Integer, ByVal y As Integer, ByVal name As String)
			Dim flag As Bitmap = New Bitmap(24, 16)

			Using gr As Graphics = Graphics.FromImage(flag)
				gr.Clear(Color.White)
				gr.DrawImage(allFlags, New Rectangle(0, 0, 24, 16), x, y, 24, 16, GraphicsUnit.Pixel)
			End Using

			FLAGS.Add(name, flag)
		End Sub

		#End Region

		#Region "Fields"

		Private FLAGS As Dictionary(Of String, Bitmap)

		#End Region

		#Region "Static"

		Private Const ANIMATION_DURATION As Single = 1.0f
		Private Shared ReadOnly FLAG_SIZE As NSize = New NSize(48, 32)
			' Round of 16
			' Quarter finals
			' Semi finals
			' Final
		Private Shared ReadOnly MATCHES As Match() = New Match(){ New Match("Germany", "Sweden", 2, 0), New Match("Argentina", "Mexico", 2, 1), New Match("Italy", "Australia", 1, 0), New Match("Switzerland", "Ukraine", 0, 3), New Match("England", "Ecuador", 1, 0), New Match("Portugal", "Netherlands", 1, 0), New Match("Brazil", "Ghana", 3, 0), New Match("Spain", "France", 1, 3), New Match("Argentina", "Germany", 2, 4), New Match("Italy", "Ukraine", 3, 0), New Match("England", "Portugal", 1, 3), New Match("Brazil", "France", 0, 1), New Match("Italy", "Germany", 2, 0), New Match("Portugal", "France", 0, 1), New Match("France", "Italy", 3, 5) }

		#End Region

		#Region "NestedTypes"

		Private Structure Match
			Public team1 As String
			Public team2 As String
			Public score1 As Integer
			Public score2 As Integer

			Public Sub New(ByVal team1 As String, ByVal team2 As String, ByVal score1 As Integer, ByVal score2 As Integer)
				Me.team1 = team1
				Me.team2 = team2
				Me.score1 = score1
				Me.score2 = score2
			End Sub
		End Structure

		#End Region
	End Class
End Namespace