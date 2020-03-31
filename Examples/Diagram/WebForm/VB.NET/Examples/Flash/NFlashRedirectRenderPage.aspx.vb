Imports Microsoft.VisualBasic
Imports System

Imports Nevron.Diagram
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Summary description for NFlashRedirectRenderPage.
	''' </summary>
	Public Partial Class NFlashRedirectRenderPage
		Inherits NDrawingViewHostPage
		#Region "Constructors"

		''' <summary>
		''' Default constructor.
		''' </summary>
		Public Sub New()
			DrawingView = New NDrawingView()

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
			' Initialize the default document style
			document.BackgroundStyle.FrameStyle.Visible = False
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant1, New NArgbColor(155, 184, 209), New NArgbColor(83, 138, 179))

			Dim helper As NDrawingDocumentHelper = New NDrawingDocumentHelper(document)

			' Create the shapes
			Dim vision As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(0, 0, 100, 50), "Nevron Vision", String.Empty)
			Dim iStyle As NInteractivityStyle = New NInteractivityStyle()
			iStyle.UrlLink = New NUrlLinkAttribute("http://www.nevron.com", True)
			NStyle.SetInteractivityStyle(vision, iStyle)

			Dim chart As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(0, 0, 100, 50), "Nevron Chart", String.Empty)
			iStyle = New NInteractivityStyle()
			iStyle.UrlLink = New NUrlLinkAttribute("http://nevron.com/Products.ChartFor.NET.Overview.aspx", True)
			NStyle.SetInteractivityStyle(chart, iStyle)

			Dim diagram As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(0, 0, 100, 50), "Nevron Diagram", String.Empty)
			iStyle = New NInteractivityStyle()
			iStyle.UrlLink = New NUrlLinkAttribute("http://nevron.com/Products.DiagramFor.NET.Overview.aspx", True)
			NStyle.SetInteractivityStyle(diagram, iStyle)

			Dim ui As NShape = helper.CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(0, 0, 100, 50), "Nevron User Interface", String.Empty)
			iStyle = New NInteractivityStyle()
			iStyle.UrlLink = New NUrlLinkAttribute("http://nevron.com/Products.UserInterfaceFor.NET.Overview.aspx", True)
			NStyle.SetInteractivityStyle(ui, iStyle)

			' Create the connectors
			Connect(vision, chart)
			Connect(vision, diagram)
			Connect(vision, ui)

			' Layout the shapes
			Dim layout As NLayeredGraphLayout = New NLayeredGraphLayout()
			layout.Direction = LayoutDirection.LeftToRight
			Dim shapes As NNodeList = document.ActiveLayer.Children(Nothing)
			layout.Layout(shapes, New NDrawingLayoutContext(document))
		End Sub
		Private Sub Connect(ByVal shape1 As NShape, ByVal shape2 As NShape)
			Dim connector As NRoutableConnector = New NRoutableConnector()
			DrawingView.Document.ActiveLayer.AddChild(connector)
			connector.StyleSheetName = "Connectors"
			connector.FromShape = shape1
			connector.ToShape = shape2
		End Sub

		#End Region
	End Class
End Namespace