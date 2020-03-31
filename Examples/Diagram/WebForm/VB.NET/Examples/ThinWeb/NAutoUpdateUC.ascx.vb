Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NThinWebGeneral.
	''' </summary>
	Public Partial Class NAutoUpdateUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' begin view init
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			If (Not NThinDiagramControl1.Initialized) Then
				' begin view init
				NThinDiagramControl1.View.Layout = CanvasLayout.Fit

				' init document
				NThinDiagramControl1.Document.BeginInit()
				InitDocument()
				NThinDiagramControl1.Document.EndInit()

				' register the auto update callback
				NThinDiagramControl1.AutoUpdateCallback = New NAutoUpdateCallback()

				NThinDiagramControl1.ServerSettings.AutoUpdateInterval = 200
				NThinDiagramControl1.ServerSettings.EnableAutoUpdate = True
			End If
		End Sub

		#Region "Nested Classes"

		<Serializable> _
		Public Class NAutoUpdateCallback
			Implements INAutoUpdateCallback
			#Region "INAutoUpdateCallback Members"

			Private Sub OnAutoUpdate(ByVal control As NAspNetThinWebControl) Implements INAutoUpdateCallback.OnAutoUpdate
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)

				Dim document As NDrawingDocument = diagramControl.Document

				Dim rotatingEllipse As NEllipseShape = TryCast(document.ActiveLayer.GetChildByName("RotatingEllipse", 0), NEllipseShape)
				If rotatingEllipse Is Nothing Then
					Return
				End If

				Dim rotatingEllipse2 As NEllipseShape = TryCast(document.ActiveLayer.GetChildByName("RotatingEllipse2", 0), NEllipseShape)
				If rotatingEllipse2 Is Nothing Then
					Return
				End If

				rotatingEllipse.Rotate(CoordinateSystem.Scene, 7, rotatingEllipse.PinPoint)
				rotatingEllipse2.Rotate(CoordinateSystem.Scene, -4, rotatingEllipse2.PinPoint)

				diagramControl.UpdateView()
			End Sub

			Private Sub OnAutoUpdateStateChanged(ByVal control As NAspNetThinWebControl) Implements INAutoUpdateCallback.OnAutoUpdateStateChanged
				Throw New NotImplementedException()
			End Sub

			#End Region
		End Class

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			' modify the connectors style sheet
			Dim styleSheet As NStyleSheet = (TryCast(NThinDiagramControl1.Document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1), NStyleSheet))

			Dim textStyle As NTextStyle = New NTextStyle()
			textStyle.BackplaneStyle.Visible = True
			textStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = New NLength(0)
			textStyle.BackplaneStyle.FillStyle = New NColorFillStyle(Color.FromArgb(200, Color.White))
			styleSheet.Style.TextStyle = textStyle

			styleSheet.Style.StrokeStyle = New NStrokeStyle(1, Color.Black)
			styleSheet.Style.StartArrowheadStyle.StrokeStyle = New NStrokeStyle(Color.FromArgb(0, Color.Black))
			styleSheet.Style.StartArrowheadStyle.FillStyle = New NColorFillStyle(Color.FromArgb(0, Color.White))
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = New NStrokeStyle(1, Color.Black)

			' modify default stroke style
			NThinDiagramControl1.Document.Style.StrokeStyle = New NStrokeStyle(Color.FromArgb(0, Color.Black))

			' configure the document
			NThinDiagramControl1.Document.Bounds = New NRectangleF(0, 0, 420, 320)
			NThinDiagramControl1.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
			NThinDiagramControl1.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
			NThinDiagramControl1.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
			NThinDiagramControl1.Document.MeasurementUnit = NGraphicsUnit.Pixel
			NThinDiagramControl1.Document.DrawingScaleMode = DrawingScaleMode.NoScale

			NThinDiagramControl1.Document.BackgroundStyle.FrameStyle.Visible = False

			'	predefined styles
			Dim ag1 As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			ag1.BackgroundColor = Color.Navy
			ag1.Points.Add(New NAdvancedGradientPoint(Color.SkyBlue, 50, 50, 0, 79, AGPointShape.Circle))

			Dim ag2 As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			ag2.BackgroundColor = Color.DarkRed
			ag2.Points.Add(New NAdvancedGradientPoint(Color.Red, 50, 50, 0, 71, AGPointShape.Circle))

			Dim ag3 As NAdvancedGradientFillStyle = New NAdvancedGradientFillStyle()
			ag3.BackgroundColor = Color.Orange
			ag3.Points.Add(New NAdvancedGradientPoint(Color.Yellow, 50, 50, 0, 50, AGPointShape.Circle))

			'	shapes
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(NThinDiagramControl1.Document)

			Dim centerEllipse As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			centerEllipse.Name = "CenterEllipse"
			centerEllipse.Width = 50f
			centerEllipse.Height = 50f
			centerEllipse.Center = New NPointF(210, 160)
			centerEllipse.Style.StrokeStyle = Nothing
			centerEllipse.Style.FillStyle = ag3

			Dim rotatingEllipse As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			rotatingEllipse.Name = "RotatingEllipse"
			rotatingEllipse.Width = 35f
			rotatingEllipse.Height = 35f
			rotatingEllipse.Center = New NPointF(centerEllipse.Bounds.X - 100, centerEllipse.Center.Y)
			rotatingEllipse.Style.StrokeStyle = Nothing
			rotatingEllipse.Style.FillStyle = ag1
			rotatingEllipse.PinPoint = New NPointF(centerEllipse.Center.X, centerEllipse.Center.Y)

			Dim rotatingEllipse2 As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			rotatingEllipse2.Name = "RotatingEllipse2"
			rotatingEllipse2.Width = 15f
			rotatingEllipse2.Height = 15f
			rotatingEllipse2.Center = New NPointF(centerEllipse.Bounds.Right + 30, centerEllipse.Center.Y)
			rotatingEllipse2.Style.StrokeStyle = Nothing
			rotatingEllipse2.Style.FillStyle = ag2
			rotatingEllipse2.PinPoint = New NPointF(centerEllipse.Center.X, centerEllipse.Center.Y)

			Dim orbit1 As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			orbit1.Name = "orbit1"
			orbit1.Width = 2 * (centerEllipse.Center.X - rotatingEllipse.Center.X)
			orbit1.Height = orbit1.Width
			orbit1.Center = New NPointF(centerEllipse.Center.X, centerEllipse.Center.Y)
			orbit1.Style.StrokeStyle = New NStrokeStyle(Color.Black)
			orbit1.Style.StrokeStyle.Pattern = LinePattern.Dot
			orbit1.Style.StrokeStyle.Factor = 2
			orbit1.Style.FillStyle = New NColorFillStyle(Color.FromArgb(0, Color.White))

			Dim orbit2 As NEllipseShape = TryCast(factory.CreateShape(CInt(Fix(BasicShapes.Ellipse))), NEllipseShape)
			orbit2.Name = "orbit2"
			orbit2.Width = 2 * (centerEllipse.Center.X - rotatingEllipse2.Center.X)
			orbit2.Height = orbit2.Width
			orbit2.Center = New NPointF(centerEllipse.Center.X, centerEllipse.Center.Y)
			orbit2.Style.StrokeStyle = New NStrokeStyle(Color.Black)
			orbit2.Style.StrokeStyle.Pattern = LinePattern.Dot
			orbit2.Style.StrokeStyle.Factor = 2
			orbit2.Style.FillStyle = New NColorFillStyle(Color.FromArgb(0, Color.White))

			NThinDiagramControl1.Document.ActiveLayer.AddChild(orbit1)
			NThinDiagramControl1.Document.ActiveLayer.AddChild(orbit2)
			NThinDiagramControl1.Document.ActiveLayer.AddChild(centerEllipse)
			NThinDiagramControl1.Document.ActiveLayer.AddChild(rotatingEllipse)
			NThinDiagramControl1.Document.ActiveLayer.AddChild(rotatingEllipse2)

			' some shapes need to have extra ports
			Dim port As NRotatedBoundsPort = New NRotatedBoundsPort(centerEllipse.UniqueId, ContentAlignment.MiddleCenter)
			port.Name = "MiddleCenter"
			centerEllipse.Ports.AddChild(port)

			port = New NRotatedBoundsPort(rotatingEllipse.UniqueId, ContentAlignment.MiddleCenter)
			port.Name = "MiddleCenter"
			rotatingEllipse.Ports.AddChild(port)

			' connect shapes in levels
			MyBase.CreateConnector(NThinDiagramControl1.Document, centerEllipse, "MiddleCenter", rotatingEllipse, "MiddleCenter", ConnectorType.Line, "Radius")
		End Sub

		#End Region
	End Class
End Namespace