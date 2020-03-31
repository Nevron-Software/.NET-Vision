Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.UI.WebForm.Controls
Imports Nevron.Examples.Framework.WebForm

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NBasicSVGDiagram.
	''' </summary>
	Public Partial Class NBasicSVGDiagram
		Inherits NDiagramExampleUC
		Protected Document As NDrawingDocument
		Protected DocumentHelper As NDrawingDocumentHelper

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = False

			NDrawingView1.ViewLayout = CanvasLayout.Normal
			NDrawingView1.DocumentPadding = New Nevron.Diagram.NMargins(10)

			' start document initialization
			Document = NDrawingView1.Document
			Document.BeginInit()

			Document.Bounds = New NRectangleF(0, 0, 344, 540)
			Document.MeasurementUnit = NGraphicsUnit.Pixel
			Document.DrawingScaleMode = DrawingScaleMode.NoScale

			DocumentHelper = New NDrawingDocumentHelper(Document)
			DocumentHelper.DefaultGridCellSize = New NSizeF(120, 80)
			DocumentHelper.DefaultGridSpacing = New NSizeF(10, 10)

			Document.Style.TextStyle.FontStyle = New NFontStyle(New Font("Arial", 8))
			Document.Style.ShadowStyle.Type = ShadowType.GaussianBlur
			Document.Style.ShadowStyle.Offset = New Nevron.GraphicsCore.NPointL(5, 5)

			CreateRect()
			CreateEllipse()
			CreatePolygon()
			CreateClosedCurve()
			CreateSingleArrow()
			CreateDoubleArrow()

			' end document initialization
			Document.EndInit()

			' change the response type to SVG
			Dim response As NImageResponse = New NImageResponse()
			response.ImageFormat = New NSvgImageFormat()
			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = response
			NDrawingView1.SizeToContent()
		End Sub

		#Region "Implementation"

		Public Sub CreateRect()
			' create rect
			Dim cell As NRectangleF = Me.DocumentHelper.GetGridCell(0, 0)
			Dim rect As NRectangleShape = New NRectangleShape(cell)

			' set fill and stroke styles
			rect.Style.FillStyle = New NColorFillStyle(Color.Magenta)
			rect.Style.StrokeStyle = New NStrokeStyle(1, Color.Black)

			' add to active layer
			Document.ActiveLayer.AddChild(rect)

			' add description
			cell = Me.DocumentHelper.GetGridCell(1, 0)
			Dim text As NTextShape = New NTextShape("Rectangle with color fill style and solid stroke style", cell)
			Document.ActiveLayer.AddChild(text)
		End Sub

		Public Sub CreateEllipse()
			' create ellipse
			Dim cell As NRectangleF = Me.DocumentHelper.GetGridCell(0, 1)
			Dim ellipse As NEllipseShape = New NEllipseShape(cell)

			' set fill and stroke styles
			ellipse.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Magenta, Color.LightGreen)
			ellipse.Style.StrokeStyle = New NStrokeStyle(1, Color.Black, LinePattern.Dash)

			' add to active layer
			Document.ActiveLayer.AddChild(ellipse)

			' add description
			cell = Me.DocumentHelper.GetGridCell(1, 1)
			Dim text As NTextShape = New NTextShape("Ellipse with gradient fill style and dash stroke style", cell)
			Document.ActiveLayer.AddChild(text)
		End Sub

		Public Sub CreatePolygon()
			' create polygon
			Dim cell As NRectangleF = Me.DocumentHelper.GetGridCell(0, 2)
			Dim xdeviation As Integer = CInt(Fix(cell.Width)) / 4
			Dim ydeviation As Integer = CInt(Fix(cell.Height)) / 4

			Dim points As NPointF() = New NPointF() { New NPointF(cell.X + Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)), New NPointF(cell.Right - Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)), New NPointF(cell.Right - Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)), New NPointF(cell.X + Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)), New NPointF(cell.X + Random.Next(CInt(Fix(cell.Width))), cell.Y + Random.Next(CInt(Fix(cell.Height)))) }

			Dim polygon As NPolygonShape = New NPolygonShape(points)

			' set fill and stroke styles
			polygon.Style.FillStyle = New NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.Green, Color.Yellow)
			polygon.Style.StrokeStyle = New NStrokeStyle(1, Color.Black, LinePattern.DashDot)

			' add to active layer
			Document.ActiveLayer.AddChild(polygon)

			' add description
			cell = Me.DocumentHelper.GetGridCell(1, 2)
			Dim text As NTextShape = New NTextShape("Polygon with gradient fill style and dash-dot stroke style", cell)
			Document.ActiveLayer.AddChild(text)
		End Sub

		Public Sub CreateClosedCurve()
			' create curve
			Dim cell As NRectangleF = Me.DocumentHelper.GetGridCell(0, 3)
			Dim xdeviation As Integer = CInt(Fix(cell.Width)) / 4
			Dim ydeviation As Integer = CInt(Fix(cell.Height)) / 4

			Dim points As NPointF() = New NPointF() { New NPointF(cell.X + Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)), New NPointF(cell.Right - Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)), New NPointF(cell.Right - Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)), New NPointF(cell.X + Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)), New NPointF(cell.X + Random.Next(CInt(Fix(cell.Width))), cell.Y + Random.Next(CInt(Fix(cell.Height)))) }

			Dim curve As NClosedCurveShape = New NClosedCurveShape(points, 1)

			' set fill and stroke styles
			curve.Style.FillStyle = New NHatchFillStyle(HatchStyle.SmallGrid, Color.LightSalmon, Color.Chocolate)
			curve.Style.StrokeStyle = New NStrokeStyle(1, Color.Black, LinePattern.DashDotDot)

			' add to active layer
			Document.ActiveLayer.AddChild(curve)

			' add description
			cell = Me.DocumentHelper.GetGridCell(1, 3)
			Dim text As NTextShape = New NTextShape("Closed curve with hatch fill style and dash-dot-dot stroke style", cell)
			Document.ActiveLayer.AddChild(text)
		End Sub

		Public Sub CreateSingleArrow()
			' create single arrow
			Dim cell As NRectangleF = Me.DocumentHelper.GetGridCell(2, 0)
			Dim startPoint As NPointF = New NPointF(cell.X, cell.Y + cell.Height / 2)
			Dim endPoint As NPointF = New NPointF(cell.Right, cell.Y + cell.Height / 2)

			Dim arrow As NArrowShape = New NArrowShape(ArrowType.SingleArrow, startPoint, endPoint, 20, 45, 60)

			' set styles
			arrow.Style.FillStyle = New NHatchFillStyle(HatchStyle.SmallGrid, Color.Yellow, Color.Coral)
			arrow.Style.StrokeStyle = New NStrokeStyle(1, Color.Black, LinePattern.Dot)

			' add to the active layer
			Document.ActiveLayer.AddChild(arrow)

			' add description
			cell = Me.DocumentHelper.GetGridCell(3, 0)
			Dim text As NTextShape = New NTextShape("Single arrow with hatch fill style and dot stroke style", cell)
			Document.ActiveLayer.AddChild(text)
		End Sub

		Public Sub CreateDoubleArrow()
			' create double arrow
			Dim cell As NRectangleF = Me.DocumentHelper.GetGridCell(2, 1)
			Dim startPoint As NPointF = New NPointF(cell.X, cell.Y + cell.Height / 2)
			Dim endPoint As NPointF = New NPointF(cell.Right, cell.Y + cell.Height / 2)

			Dim arrow As NArrowShape = New NArrowShape(ArrowType.DoubleArrow, startPoint, endPoint, 20, 45, 60)

			' set styles
			Try
				Dim bmp As Bitmap = New Bitmap(Me.MapPathSecure(Me.TemplateSourceDirectory & "\..\Images\ConceptCar2.png"))
				arrow.Style.FillStyle = New NImageFillStyle(bmp, 125)
			Catch ex As Exception
				Debug.WriteLine("Failed to load concept car resource. Exception was: " & ex.Message)
			End Try

			arrow.Style.StrokeStyle = New NStrokeStyle(1, Color.Black, LinePattern.Solid)

			' add to the active layer
			Document.ActiveLayer.AddChild(arrow)

			' add description
			cell = Me.DocumentHelper.GetGridCell(3, 1)
			Dim text As NTextShape = New NTextShape("Single arrow with semi transparent image fill style and solid stroke style", cell)
			Document.ActiveLayer.AddChild(text)
		End Sub

		#End Region
	End Class
End Namespace
