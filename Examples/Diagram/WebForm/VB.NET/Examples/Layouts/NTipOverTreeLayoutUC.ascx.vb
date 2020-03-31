Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.ThinWeb
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NTipOverTreeLayoutUC.
	''' </summary>
	Public Partial Class NTipOverTreeLayoutUC
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

			Dim styleSheet As NStyleSheet = New NStyleSheet("orange")
			styleSheet.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
			styleSheet.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.StyleSheets.AddChild(styleSheet)

			Dim sheet As NStyleSheet = New NStyleSheet("edges")
			sheet.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			sheet.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.StyleSheets.AddChild(sheet)

			' Adjust the text properties
			document.Style.TextStyle.FontStyle = New NFontStyle("arial", 13f)

			' Create the predefined org chart
			Dim renderer As DiagramRenderer = New DiagramRenderer()
			renderer.CreatePredefinedOrgChart(document)

			' Apply the layout
			renderer.ApplyLayout(document, Nothing)

			' Resize document to fit all shapes
			document.SizeToContent()
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

				Dim renderer As DiagramRenderer = New DiagramRenderer()
				Select Case settings("command")
					Case "PredefinedOrgChart"
						renderer.CreatePredefinedOrgChart(document)
					Case "RandomTree5ColShapes"
						renderer.CreateTree(document, 5)
					Case "RandomTree7ColShapes"
						renderer.CreateTree(document, 7)
				End Select

				' Layout the diagram
				renderer.ApplyLayout(document, settings)

				' Resize document to fit all shapes
				document.SizeToContent()

				' Update the view
				diagramControl.UpdateView()
			End Sub
		End Class

		Private Class DiagramRenderer
			Public Sub CreatePredefinedOrgChart(ByVal document As NDrawingDocument)
				' Clear the document
				document.ActiveLayer.RemoveAllChildren()

				' We will be using basic shapes with default size of 120, 60
				Dim basicShapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
				basicShapesFactory.DefaultSize = New NSizeF(120, 60)

				' Create the president
				Dim president As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
				president.Text = "President"
				document.ActiveLayer.AddChild(president)

				' Create the VPs. 
				' NOTE: The child nodes of the VPs are layed out in cols
				Dim vpMarketing As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
				vpMarketing.Text = "VP Marketing"
				document.ActiveLayer.AddChild(vpMarketing)

				Dim vpSales As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
				vpSales.Text = "VP Sales"
				document.ActiveLayer.AddChild(vpSales)

				Dim vpProduction As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
				vpProduction.Text = "VP Production"
				document.ActiveLayer.AddChild(vpProduction)

				' Connect president with VP
				Dim connector As NRoutableConnector = New NRoutableConnector()
				document.ActiveLayer.AddChild(connector)
				connector.FromShape = president
				connector.ToShape = vpMarketing

				connector = New NRoutableConnector()
				document.ActiveLayer.AddChild(connector)
				connector.FromShape = president
				connector.ToShape = vpSales

				connector = New NRoutableConnector()
				document.ActiveLayer.AddChild(connector)
				connector.FromShape = president
				connector.ToShape = vpProduction

				' Create the marketing managers
				Dim marketingManager1 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
				marketingManager1.Text = "Manager1"
				document.ActiveLayer.AddChild(marketingManager1)

				Dim marketingManager2 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
				marketingManager2.Text = "Manager2"
				document.ActiveLayer.AddChild(marketingManager2)

				' Connect the marketing manager with the marketing VP
				connector = New NRoutableConnector()
				document.ActiveLayer.AddChild(connector)
				connector.FromShape = vpMarketing
				connector.ToShape = marketingManager1

				connector = New NRoutableConnector()
				document.ActiveLayer.AddChild(connector)
				connector.FromShape = vpMarketing
				connector.ToShape = marketingManager2

				' Create the sales managers
				Dim salesManager1 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
				salesManager1.Text = "Manager1"
				document.ActiveLayer.AddChild(salesManager1)

				Dim salesManager2 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
				salesManager2.Text = "Manager2"
				document.ActiveLayer.AddChild(salesManager2)

				' Connect the sales manager with the sales VP
				connector = New NRoutableConnector()
				document.ActiveLayer.AddChild(connector)
				connector.FromShape = vpSales
				connector.ToShape = salesManager1

				connector = New NRoutableConnector()
				document.ActiveLayer.AddChild(connector)
				connector.FromShape = vpSales
				connector.ToShape = salesManager2

				' Create the production managers
				Dim productionManager1 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
				productionManager1.Text = "Manager1"
				document.ActiveLayer.AddChild(productionManager1)

				Dim productionManager2 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
				productionManager2.Text = "Manager2"
				document.ActiveLayer.AddChild(productionManager2)

				' Connect the production manager with the production VP
				connector = New NRoutableConnector()
				document.ActiveLayer.AddChild(connector)
				connector.FromShape = vpProduction
				connector.ToShape = productionManager1

				connector = New NRoutableConnector()
				document.ActiveLayer.AddChild(connector)
				connector.FromShape = vpProduction
				connector.ToShape = productionManager2
			End Sub
			Public Sub CreateTree(ByVal document As NDrawingDocument, ByVal maxShapes As Integer)
				' clear the document
				document.ActiveLayer.RemoveAllChildren()

				' create a tree
				Dim tree As NGenericTreeTemplate = New NGenericTreeTemplate()
				tree.Balanced = False
				tree.Levels = 6
				tree.BranchNodes = 3
				tree.HorizontalSpacing = 10
				tree.VerticalSpacing = 10
				tree.VerticesSize = New NSizeF(50, 50)
				tree.VertexSizeDeviation = 0
				tree.EdgesStyleSheetName = "edges"
				tree.Create(document)

				' make the subtrees of maxShapes random shapes vertically arranged
				Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)
				Dim rnd As Random = New Random()
				Dim usedNumbers As List(Of Integer) = New List(Of Integer)()
				Dim i, index As Integer

				i = 0
				Do While i < maxShapes
					Do
						index = rnd.Next(shapes.Count)
					Loop While usedNumbers.Contains(index)

					usedNumbers.Add(index)
					Dim shape As NShape = CType(shapes(index), NShape)
					shape.StyleSheetName = "orange"
					shape.LayoutData.TipOverChildrenPlacement = TipOverChildrenPlacement.ColRight
					i += 1
				Loop
			End Sub
			Public Sub ApplyLayout(ByVal document As NDrawingDocument, ByVal settings As Dictionary(Of String, String))
				' Create the layout
				Dim layout As NTipOverTreeLayout = New NTipOverTreeLayout()

				' Configure the layout
				If Not settings Is Nothing Then
					Dim helper As NDrawingDocumentHelper = New NDrawingDocumentHelper(document)
					helper.ConfigureLayout(layout, settings)
				End If

				' Get the shapes to layout
				Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

				' Layout the shapes
				layout.Layout(shapes, New NDrawingLayoutContext(document))
			End Sub
		End Class

		#End Region
	End Class
End Namespace