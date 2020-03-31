Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls
Imports Nevron.Diagram.Extensions

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Summary description for NWorldCup2006RenderPage.
	''' </summary>
	Public Partial Class NPuzzleAnimationRenderPage
		Inherits NDrawingViewHostPage
		#Region "Constructors"

		''' <summary>
		''' Default constructor.
		''' </summary>
		Public Sub New()
			DrawingView = New NDrawingView()
			DrawingView.ViewLayout = CanvasLayout.Stretch

			Dim swfResponse As NImageResponse = New NImageResponse()
			swfResponse.ImageFormat = New NSwfImageFormat()
			swfResponse.StreamImageToBrowser = True
			DrawingView.ServerSettings.BrowserResponseSettings.DefaultResponse = swfResponse

			' init document
			CreateScene()

			Me.DrawingView.SizeToContent()
		End Sub

		#End Region

		#Region "Private Methods"

		Private Sub CreateScene()
			Dim manager As NPersistencyManager = New NPersistencyManager()
			Dim document As NDrawingDocument = manager.LoadDrawingFromFile(Server.MapPath("~\App_Data\FlowDiagram.ndx"))

			DrawingView.Document = document
			document.BeginInit()
			CreateAnimatedGrid(5, 5, 1)
			document.EndInit()
		End Sub
		Private Sub CreateAnimatedGrid(ByVal rows As Integer, ByVal columns As Integer, ByVal cellFadeDuration As Single)
			Dim document As NDrawingDocument = DrawingView.Document

			' Create the grid layer
			Dim grid As NLayer = New NLayer()
			grid.Name = "grid"
			document.Layers.AddChild(grid)

			' Create the cells style sheet
			Dim style As NStyleSheet = New NStyleSheet("gridCell")
			NStyle.SetFillStyle(style, New NColorFillStyle(KnownArgbColorValue.White))
			NStyle.SetStrokeStyle(style, New NStrokeStyle(1, KnownArgbColorValue.Black))
			document.StyleSheets.AddChild(style)

			Dim i, j, count As Integer
			Dim x As Single, y As Single, time As Single = 0
			Dim cellWidth As Single = document.Width / rows
			Dim cellHeight As Single = document.Height / columns

			Dim fade As NFadeAnimation
			Dim rect As NRectangleShape
			Dim cells As List(Of NRectangleShape) = New List(Of NRectangleShape)()

			' Create the shapes
			i = 0
			y = 0
			Do While i < rows
				j = 0
				x = 0
				Do While j < columns
					rect = New NRectangleShape(x, y, cellWidth, cellHeight)
					cells.Add(rect)
					grid.AddChild(rect)
					rect.StyleSheetName = style.Name
					j += 1
					x += cellWidth
				Loop
				i += 1
				y += cellHeight
			Loop

			' Create the fade animations
			count = cells.Count
			Dim random As Random = New Random()

			Dim counter As Integer = 1
			Do While count > 0
				i = random.Next(count)
				rect = cells(i)
				rect.Style.AnimationsStyle = New NAnimationsStyle()

				If time > 0 Then
					fade = New NFadeAnimation(0, time)
					fade.StartAlpha = 1
					fade.EndAlpha = 1
					rect.Style.AnimationsStyle.AddAnimation(fade)
				End If

				fade = New NFadeAnimation(time, cellFadeDuration)
				fade.StartAlpha = 1
				fade.EndAlpha = 0
				rect.Style.AnimationsStyle.AddAnimation(fade)

				If counter = 3 Then
					' Show 3 cells at a time
					time += cellFadeDuration
					counter = 1
				Else
					counter += 1
				End If

				cells.RemoveAt(i)
				count -= 1
			Loop
		End Sub

		#End Region
	End Class
End Namespace