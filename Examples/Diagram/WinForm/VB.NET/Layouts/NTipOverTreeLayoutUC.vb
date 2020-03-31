Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Templates
Imports Nevron.Dom
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NTipOverTreeLayoutUC.
	''' </summary>
	Public Class NTipOverTreeLayoutUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer Generated Code"

		Private Sub InitializeComponent()
			Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid()
			Me.LayoutButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PredefinedOrgChartButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.RandomTreeButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.RandomTreeButton2 = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.propertyGrid1.Location = New System.Drawing.Point(8, 3)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.propertyGrid1.Size = New System.Drawing.Size(244, 379)
			Me.propertyGrid1.TabIndex = 1
			' 
			' LayoutButton
			' 
			Me.LayoutButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.LayoutButton.Location = New System.Drawing.Point(8, 491)
			Me.LayoutButton.Name = "LayoutButton"
			Me.LayoutButton.Size = New System.Drawing.Size(244, 23)
			Me.LayoutButton.TabIndex = 2
			Me.LayoutButton.Text = "Layout"
			Me.LayoutButton.UseVisualStyleBackColor = True
'			Me.LayoutButton.Click += New System.EventHandler(Me.LayoutButton_Click);
			' 
			' PredefinedOrgChartButton
			' 
			Me.PredefinedOrgChartButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.PredefinedOrgChartButton.Location = New System.Drawing.Point(8, 388)
			Me.PredefinedOrgChartButton.Name = "PredefinedOrgChartButton"
			Me.PredefinedOrgChartButton.Size = New System.Drawing.Size(244, 23)
			Me.PredefinedOrgChartButton.TabIndex = 3
			Me.PredefinedOrgChartButton.Text = "Predefined Org Chart"
			Me.PredefinedOrgChartButton.UseVisualStyleBackColor = True
'			Me.PredefinedOrgChartButton.Click += New System.EventHandler(Me.PredefinedOrgChartButton_Click);
			' 
			' RandomTreeButton1
			' 
			Me.RandomTreeButton1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.RandomTreeButton1.Location = New System.Drawing.Point(8, 417)
			Me.RandomTreeButton1.Name = "RandomTreeButton1"
			Me.RandomTreeButton1.Size = New System.Drawing.Size(244, 23)
			Me.RandomTreeButton1.TabIndex = 4
			Me.RandomTreeButton1.Text = "Random Tree (5 col shapes)"
			Me.RandomTreeButton1.UseVisualStyleBackColor = True
'			Me.RandomTreeButton1.Click += New System.EventHandler(Me.RandomTreeButton1_Click);
			' 
			' RandomTreeButton2
			' 
			Me.RandomTreeButton2.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.RandomTreeButton2.Location = New System.Drawing.Point(8, 446)
			Me.RandomTreeButton2.Name = "RandomTreeButton2"
			Me.RandomTreeButton2.Size = New System.Drawing.Size(244, 23)
			Me.RandomTreeButton2.TabIndex = 5
			Me.RandomTreeButton2.Text = "Random Tree (7 col shapes)"
			Me.RandomTreeButton2.UseVisualStyleBackColor = True
'			Me.RandomTreeButton2.Click += New System.EventHandler(Me.RandomTreeButton2_Click);
			' 
			' NTipOverTreeLayoutUC
			' 
			Me.Controls.Add(Me.RandomTreeButton2)
			Me.Controls.Add(Me.RandomTreeButton1)
			Me.Controls.Add(Me.PredefinedOrgChartButton)
			Me.Controls.Add(Me.LayoutButton)
			Me.Controls.Add(Me.propertyGrid1)
			Me.Name = "NTipOverTreeLayoutUC"
			Me.Controls.SetChildIndex(Me.propertyGrid1, 0)
			Me.Controls.SetChildIndex(Me.LayoutButton, 0)
			Me.Controls.SetChildIndex(Me.PredefinedOrgChartButton, 0)
			Me.Controls.SetChildIndex(Me.RandomTreeButton1, 0)
			Me.Controls.SetChildIndex(Me.RandomTreeButton2, 0)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init form fields
			m_Layout = New NTipOverTreeLayout()
			propertyGrid1.SelectedObject = m_Layout

			view.BeginInit()
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.GlobalVisibility.ShowArrowheads = False
			view.ViewLayout = ViewLayout.Fit

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub
		Protected Overrides Sub AttachToEvents()
			MyBase.AttachToEvents()
		End Sub
		Protected Overrides Sub DetachFromEvents()
			MyBase.DetachFromEvents()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()
			ResumeEventsHandling()
		End Sub
		Private Sub InitDocument()
			' we do not need history for this example
			document.HistoryService.Pause()

			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			Dim styleSheet As NStyleSheet = New NStyleSheet("orange")
			styleSheet.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
			styleSheet.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.StyleSheets.AddChild(styleSheet)

			CreatePredefinedOrgChart()

			' resize document to fit all shapes
			LayoutButton.PerformClick()
		End Sub
		Private Sub CreatePredefinedOrgChart()
			' we will be using basic shapes with default size of 120, 60
			Dim basicShapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
			basicShapesFactory.DefaultSize = New NSizeF(120, 60)

			' create the president
			Dim president As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			president.Text = "President"
			document.ActiveLayer.AddChild(president)

			' create the VPs. 
			' NOTE: The child nodes of the VPs are layed out in cols
			Dim vpMarketing As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			vpMarketing.Text = "VP Marketing"
			vpMarketing.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.ActiveLayer.AddChild(vpMarketing)

			Dim vpSales As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			vpSales.Text = "VP Sales"
			vpSales.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.ActiveLayer.AddChild(vpSales)

			Dim vpProduction As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			vpProduction.Text = "VP Production"
			vpProduction.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.ActiveLayer.AddChild(vpProduction)

			' connect president with VP
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

			' crete the marketing managers
			Dim marketingManager1 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			marketingManager1.Text = "Manager1"
			document.ActiveLayer.AddChild(marketingManager1)

			Dim marketingManager2 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			marketingManager2.Text = "Manager2"
			document.ActiveLayer.AddChild(marketingManager2)

			' connect the marketing manager with the marketing VP
			connector = New NRoutableConnector()
			document.ActiveLayer.AddChild(connector)
			connector.FromShape = vpMarketing
			connector.ToShape = marketingManager1

			connector = New NRoutableConnector()
			document.ActiveLayer.AddChild(connector)
			connector.FromShape = vpMarketing
			connector.ToShape = marketingManager2

			' crete the sales managers
			Dim salesManager1 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			salesManager1.Text = "Manager1"
			document.ActiveLayer.AddChild(salesManager1)

			Dim salesManager2 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			salesManager2.Text = "Manager2"
			document.ActiveLayer.AddChild(salesManager2)

			' connect the sales manager with the sales VP
			connector = New NRoutableConnector()
			document.ActiveLayer.AddChild(connector)
			connector.FromShape = vpSales
			connector.ToShape = salesManager1

			connector = New NRoutableConnector()
			document.ActiveLayer.AddChild(connector)
			connector.FromShape = vpSales
			connector.ToShape = salesManager2

			' crete the production managers
			Dim productionManager1 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			productionManager1.Text = "Manager1"
			document.ActiveLayer.AddChild(productionManager1)

			Dim productionManager2 As NShape = basicShapesFactory.CreateShape(BasicShapes.Rectangle)
			productionManager2.Text = "Manager2"
			document.ActiveLayer.AddChild(productionManager2)

			' connect the production manager with the production VP
			connector = New NRoutableConnector()
			document.ActiveLayer.AddChild(connector)
			connector.FromShape = vpProduction
			connector.ToShape = productionManager1

			connector = New NRoutableConnector()
			document.ActiveLayer.AddChild(connector)
			connector.FromShape = vpProduction
			connector.ToShape = productionManager2
		End Sub
		Private Sub CreateTree(ByVal maxShapes As Integer)
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

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub LayoutButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LayoutButton.Click
			' get the shapes to layout
			Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

			' create a layout context
			Dim layoutContext As NLayoutContext = New NLayoutContext()
			layoutContext.GraphAdapter = New NShapeGraphAdapter()
			layoutContext.BodyAdapter = New NShapeBodyAdapter(document)
			layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(document)

			' layout the shapes
			If Not m_Layout Is Nothing Then
				m_Layout.Layout(shapes, layoutContext)
			End If

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub
		Private Sub PredefinedOrgChartButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PredefinedOrgChartButton.Click
			view.LockRefresh = True
			document.ActiveLayer.RemoveAllChildren()

			' create the predefined org chart tree
			CreatePredefinedOrgChart()

			' layout the tree
			LayoutButton.PerformClick()
			view.LockRefresh = False
		End Sub
		Private Sub RandomTreeButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RandomTreeButton1.Click
			view.LockRefresh = True
			CreateTree(5)
			LayoutButton.PerformClick()
			view.LockRefresh = False

		End Sub
		Private Sub RandomTreeButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RandomTreeButton2.Click
			view.LockRefresh = True
			CreateTree(7)
			LayoutButton.PerformClick()
			view.LockRefresh = False
		End Sub

		#End Region

		#Region "Designer Fields"

		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private WithEvents LayoutButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PredefinedOrgChartButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RandomTreeButton1 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RandomTreeButton2 As Nevron.UI.WinForm.Controls.NButton

		#End Region

		#Region "Fields"

		Private m_Layout As NTipOverTreeLayout

		#End Region
	End Class
End Namespace