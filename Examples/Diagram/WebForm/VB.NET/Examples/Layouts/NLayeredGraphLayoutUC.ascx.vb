Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.ThinWeb
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NLayeredGraphLayoutUC.
	''' </summary>
	Public Partial Class NLayeredGraphLayoutUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NThinDiagramControl1.Initialized Then
				Return
			End If

			' Init the diagram control
			NThinDiagramControl1.StateId = "Diagram1"
			NThinDiagramControl1.CustomRequestCallback = New CustomRequestCallback()

			' Init the view
			NThinDiagramControl1.View.Layout = CanvasLayout.Fit

			' Init the document
			Dim document As NDrawingDocument = NThinDiagramControl1.Document
			document.BeginInit()
			InitDocument(document)
			document.EndInit()
		End Sub

		#Region "Implementation"

		Private Sub InitDocument(ByVal document As NDrawingDocument)
			' Remove the standard frame
			document.BackgroundStyle.FrameStyle.Visible = False

			' Adjust the graphics quality
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed

			' Set up visual formatting
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			document.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)

			' Create a graph
			CreateGraph(document)

			' Create the layout
			Dim layout As NLayeredGraphLayout = New NLayeredGraphLayout()

			' Get the shapes to layout
			Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

			' Layout the shapes
			layout.Layout(shapes, New NDrawingLayoutContext(document))

			' Resize document to fit all shapes
			document.SizeToContent()
		End Sub
		Private Sub CreateGraph(ByVal document As NDrawingDocument)
			Const width As Integer = 40, height As Integer = 40, distance As Integer = 80
			Dim f As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim edge As NRoutableConnector
			Dim from As Integer() = New Integer() { 1, 1, 1, 2, 2, 3, 3, 4, 4, 5, 6 }
			Dim [to] As Integer() = New Integer() { 2, 3, 4, 4, 5, 6, 7, 5, 9, 8, 9 }
			Dim shapes As NShape() = New NShape(8){}
			Dim vertexCount As Integer = shapes.Length, edgeCount As Integer = from.Length
			Dim i As Integer, j As Integer, count As Integer = vertexCount + edgeCount

			i = 0
			Do While i < count
				If i < vertexCount Then
					If vertexCount Mod 2 = 0 Then
						j = i
					Else
						j = i + 1
					End If
					shapes(i) = f.CreateShape(CInt(Fix(BasicShapes.Rectangle)))

					If vertexCount Mod 2 <> 0 AndAlso i = 0 Then
						shapes(i).Bounds = New NRectangleF(CInt(Fix(width + (distance * 1.5))) / 2, distance + (j / 2) * CInt(Fix(distance * 1.5)), width, height)
					Else
						shapes(i).Bounds = New NRectangleF(width / 2 + (j Mod 2) * CInt(Fix(distance * 1.5)), height + (j / 2) * CInt(Fix(distance * 1.5)), width, height)
					End If

					document.ActiveLayer.AddChild(shapes(i))
				Else
					edge = New NRoutableConnector()
					edge.ConnectorType = RoutableConnectorType.DynamicPolyline
					edge.StyleSheetName = "CustomConnectors"
					document.ActiveLayer.AddChild(edge)
					edge.FromShape = shapes(from(i - vertexCount) - 1)
					edge.ToShape = shapes([to](i - vertexCount) - 1)
				End If
				i += 1
			Loop
		End Sub

		#End Region

		#Region "Nested Types"

		<Serializable> _
		Private Class CustomRequestCallback
			Implements INCustomRequestCallback
			Private Sub OnCustomRequestCallback(ByVal control As NAspNetThinWebControl, ByVal context As NRequestContext, ByVal argument As String) Implements INCustomRequestCallback.OnCustomRequestCallback
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim document As NDrawingDocument = diagramControl.Document

				Dim helper As NDrawingDocumentHelper = New NDrawingDocumentHelper(document)
				Dim settings As Dictionary(Of String, String) = helper.ParseSettings(argument)

				' Create and configure the layout
				Dim layout As NLayeredGraphLayout = New NLayeredGraphLayout()
				helper.ConfigureLayout(layout, settings)

				' Get the shapes to layout
				Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

				' Layout the shapes
				layout.Layout(shapes, New NDrawingLayoutContext(document))

				' Resize document to fit all shapes
				document.SizeToContent()

				' Update the view
				diagramControl.UpdateView()
			End Sub
		End Class

		#End Region
	End Class
End Namespace