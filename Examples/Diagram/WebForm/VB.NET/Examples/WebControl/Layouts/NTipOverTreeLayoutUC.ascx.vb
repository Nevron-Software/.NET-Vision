Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Windows.Forms

Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NTipOverTreeLayoutUC.
	''' </summary>
	Public Partial Class NTipOverTreeLayoutUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NDrawingView1.RequiresInitialization Then
				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Fit

				' init document
				NDrawingView1.Document.HistoryService.Stop()
				NDrawingView1.Document.BeginInit()
				InitDocument()
				NDrawingView1.Document.EndInit()
			End If
		End Sub

		#Region "Implementation"

		Private Sub InitDocument()
			Dim document As NDrawingDocument = NDrawingView1.Document

			' remove the standard frame
			document.BackgroundStyle.FrameStyle.Visible = False

			' adjust the graphics quality
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed

			' set up visual formatting
			NDrawingView1.Document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			NDrawingView1.Document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			Dim styleSheet As NStyleSheet = New NStyleSheet("orange")
			styleSheet.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
			styleSheet.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.StyleSheets.AddChild(styleSheet)

			Dim sheet As NStyleSheet = New NStyleSheet("edges")
			sheet.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			sheet.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.StyleSheets.AddChild(sheet)

			' adjust the text properties
			NDrawingView1.Document.Style.TextStyle.FontStyle = New NFontStyle("arial", 13f)

			' create the predefined org chart
			CreatePredefinedOrgChart()

			' perform the layout
			PerformLayout(Nothing)
		End Sub
		Private Sub PerformLayout(ByVal args As Hashtable)
			' Create the layout
			Dim layout As NTipOverTreeLayout = New NTipOverTreeLayout()

			' Configure the layout
			NLayoutsHelper.ConfigureLayout(layout, args)

			' Get the shapes to layout
			Dim shapes As NNodeList = NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape2D)

			' Layout the shapes
			layout.Layout(shapes, New NDrawingLayoutContext(NDrawingView1.Document))

			' Resize document to fit all shapes
			NDrawingView1.Document.SizeToContent()

		End Sub
		Private Sub CreatePredefinedOrgChart()
			' clear the document
			NDrawingView1.Document.ActiveLayer.RemoveAllChildren()

			' we will be using basic shapes with default size of 120, 60
			Dim basicShapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
			basicShapesFactory.DefaultSize = New NSizeF(120, 60)

			' create the president
			Dim president As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			president.Text = "President"
			NDrawingView1.Document.ActiveLayer.AddChild(president)

			' create the VPs. 
			' NOTE: The child nodes of the VPs are layed out in cols
			Dim vpMarketing As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			vpMarketing.Text = "VP Marketing"
			NDrawingView1.Document.ActiveLayer.AddChild(vpMarketing)

			Dim vpSales As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			vpSales.Text = "VP Sales"
			NDrawingView1.Document.ActiveLayer.AddChild(vpSales)

			Dim vpProduction As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			vpProduction.Text = "VP Production"
			NDrawingView1.Document.ActiveLayer.AddChild(vpProduction)

			' connect president with VP
			Dim connector As NRoutableConnector = New NRoutableConnector()
			NDrawingView1.Document.ActiveLayer.AddChild(connector)
			connector.FromShape = president
			connector.ToShape = vpMarketing

			connector = New NRoutableConnector()
			NDrawingView1.Document.ActiveLayer.AddChild(connector)
			connector.FromShape = president
			connector.ToShape = vpSales

			connector = New NRoutableConnector()
			NDrawingView1.Document.ActiveLayer.AddChild(connector)
			connector.FromShape = president
			connector.ToShape = vpProduction

			' crete the marketing managers
			Dim marketingManager1 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			marketingManager1.Text = "Manager1"
			NDrawingView1.Document.ActiveLayer.AddChild(marketingManager1)

			Dim marketingManager2 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			marketingManager2.Text = "Manager2"
			NDrawingView1.Document.ActiveLayer.AddChild(marketingManager2)

			' connect the marketing manager with the marketing VP
			connector = New NRoutableConnector()
			NDrawingView1.Document.ActiveLayer.AddChild(connector)
			connector.FromShape = vpMarketing
			connector.ToShape = marketingManager1

			connector = New NRoutableConnector()
			NDrawingView1.Document.ActiveLayer.AddChild(connector)
			connector.FromShape = vpMarketing
			connector.ToShape = marketingManager2

			' crete the sales managers
			Dim salesManager1 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			salesManager1.Text = "Manager1"
			NDrawingView1.Document.ActiveLayer.AddChild(salesManager1)

			Dim salesManager2 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			salesManager2.Text = "Manager2"
			NDrawingView1.Document.ActiveLayer.AddChild(salesManager2)

			' connect the sales manager with the sales VP
			connector = New NRoutableConnector()
			NDrawingView1.Document.ActiveLayer.AddChild(connector)
			connector.FromShape = vpSales
			connector.ToShape = salesManager1

			connector = New NRoutableConnector()
			NDrawingView1.Document.ActiveLayer.AddChild(connector)
			connector.FromShape = vpSales
			connector.ToShape = salesManager2

			' create the production managers
			Dim productionManager1 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			productionManager1.Text = "Manager1"
			NDrawingView1.Document.ActiveLayer.AddChild(productionManager1)

			Dim productionManager2 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			productionManager2.Text = "Manager2"
			NDrawingView1.Document.ActiveLayer.AddChild(productionManager2)

			' connect the production manager with the production VP
			connector = New NRoutableConnector()
			NDrawingView1.Document.ActiveLayer.AddChild(connector)
			connector.FromShape = vpProduction
			connector.ToShape = productionManager1

			connector = New NRoutableConnector()
			NDrawingView1.Document.ActiveLayer.AddChild(connector)
			connector.FromShape = vpProduction
			connector.ToShape = productionManager2
		End Sub
		Private Sub CreateTree(ByVal maxShapes As Integer)
			' clear the document
			NDrawingView1.Document.ActiveLayer.RemoveAllChildren()

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
			tree.Create(NDrawingView1.Document)

			' make the subtrees of maxShapes random shapes vertically arranged
			Dim shapes As NNodeList = NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape2D)
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

			' resize document to fit all shapes
			NDrawingView1.Document.SizeToContent()
		End Sub

		#End Region

		#Region "Event Handlers"

		Protected Sub NDrawingView1_AsyncCustomCommand(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackCustomCommandArgs = TryCast(e, NCallbackCustomCommandArgs)
			Select Case args.Command.Name
				Case "btn1"
					CreatePredefinedOrgChart()

				Case "btn2"
					CreateTree(5)

				Case "btn3"
					CreateTree(7)
			End Select

			PerformLayout(args.Command.Arguments)
			m_bClientSideRedrawRequired = True
		End Sub
		Protected Sub NDrawingView1_AsyncQueryCommandResult(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackQueryCommandResultArgs = TryCast(e, NCallbackQueryCommandResultArgs)
			Dim resultBuilder As NAjaxXmlTransportBuilder = args.ResultBuilder
			If m_bClientSideRedrawRequired AndAlso (Not resultBuilder.ContainsRedrawDataSection()) Then
				resultBuilder.AddRedrawDataSection(NDrawingView1)
			End If
		End Sub

		#End Region

		#Region "Fields"

		Private m_bClientSideRedrawRequired As Boolean = False

		#End Region
	End Class
End Namespace