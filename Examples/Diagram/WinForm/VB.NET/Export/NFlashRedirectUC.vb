Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Dom
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NFlashRedirectUC.
	''' </summary>
	Public Class NFlashRedirectUC
		Inherits NExportBaseUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			btnExport.Text = "Export to SWF"
		End Sub

		#End Region

		#Region "Overrides"

		Protected Overrides Sub CreateDiagram()
			' Initialize the default document style
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant1, New NArgbColor(155, 184, 209), New NArgbColor(83, 138, 179))

			' Create the shapes
			Dim vision As NShape = CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(0, 0, 100, 50), "Nevron Vision", String.Empty)
			Dim iStyle As NInteractivityStyle = New NInteractivityStyle()
			iStyle.UrlLink = New NUrlLinkAttribute("http://www.nevron.com", True)
			NStyle.SetInteractivityStyle(vision, iStyle)

			Dim chart As NShape = CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(0, 0, 100, 50), "Nevron Chart", String.Empty)
			iStyle = New NInteractivityStyle()
			iStyle.UrlLink = New NUrlLinkAttribute("http://nevron.com/Products.ChartFor.NET.Overview.aspx", True)
			NStyle.SetInteractivityStyle(chart, iStyle)

			Dim diagram As NShape = CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(0, 0, 100, 50), "Nevron Diagram", String.Empty)
			iStyle = New NInteractivityStyle()
			iStyle.UrlLink = New NUrlLinkAttribute("http://nevron.com/Products.DiagramFor.NET.Overview.aspx", True)
			NStyle.SetInteractivityStyle(diagram, iStyle)

			Dim ui As NShape = CreateBasicShape(BasicShapes.Rectangle, New NRectangleF(0, 0, 100, 50), "Nevron User Interface", String.Empty)
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
		Protected Overrides ReadOnly Property ErrorMessage() As String
			Get
				Return "The generated SWF file failed to open. May be you do not have a Flash player installed."
			End Get
		End Property
		Protected Overrides Function Export() As String
			Dim exporter As NFlashExporter = New NFlashExporter(document)
			Dim fileName As String = Path.Combine(Application.StartupPath, "test.swf")
			exporter.SaveToFile(fileName)
			Return fileName
		End Function

		#End Region

		#Region "Implementation"

		Private Sub Connect(ByVal shape1 As NShape, ByVal shape2 As NShape)
			Dim connector As NRoutableConnector = New NRoutableConnector()
			document.ActiveLayer.AddChild(connector)
			connector.StyleSheetName = "Connectors"
			connector.FromShape = shape1
			connector.ToShape = shape2
		End Sub

		#End Region
	End Class
End Namespace