Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections.Generic

Imports Nevron.Diagram.Layout
Imports Nevron.Diagram
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Templates

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NLayeredTreeLayoutUC.
	''' </summary>
	Public Class NLayeredTreeLayoutUC
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
			Me.RandomButton2 = New Nevron.UI.WinForm.Controls.NButton()
			Me.RandomButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.propertyGrid1.Location = New System.Drawing.Point(8, 3)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.propertyGrid1.Size = New System.Drawing.Size(244, 391)
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
			' RandomButton2
			' 
			Me.RandomButton2.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.RandomButton2.Location = New System.Drawing.Point(8, 429)
			Me.RandomButton2.Name = "RandomButton2"
			Me.RandomButton2.Size = New System.Drawing.Size(244, 23)
			Me.RandomButton2.TabIndex = 6
			Me.RandomButton2.Text = "Random Tree (max 8 levels, max 2 branch nodes)"
			Me.RandomButton2.UseVisualStyleBackColor = True
'			Me.RandomButton2.Click += New System.EventHandler(Me.RandomButton2_Click);
			' 
			' RandomButton1
			' 
			Me.RandomButton1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.RandomButton1.Location = New System.Drawing.Point(8, 400)
			Me.RandomButton1.Name = "RandomButton1"
			Me.RandomButton1.Size = New System.Drawing.Size(244, 23)
			Me.RandomButton1.TabIndex = 5
			Me.RandomButton1.Text = "Random Tree (max 6 levels, max 3 branch nodes)"
			Me.RandomButton1.UseVisualStyleBackColor = True
'			Me.RandomButton1.Click += New System.EventHandler(Me.RandomButton1_Click);
			' 
			' NLayeredTreeLayoutUC
			' 
			Me.Controls.Add(Me.RandomButton2)
			Me.Controls.Add(Me.RandomButton1)
			Me.Controls.Add(Me.LayoutButton)
			Me.Controls.Add(Me.propertyGrid1)
			Me.Name = "NLayeredTreeLayoutUC"
			Me.Controls.SetChildIndex(Me.propertyGrid1, 0)
			Me.Controls.SetChildIndex(Me.LayoutButton, 0)
			Me.Controls.SetChildIndex(Me.RandomButton1, 0)
			Me.Controls.SetChildIndex(Me.RandomButton2, 0)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init form fields
			m_Layout = New NLayeredTreeLayout()

			' instruct the layout to perform HV layout of the edges 
			m_Layout.OrthogonalEdgeRouting = True

			' show the layout properties in the property grid
			propertyGrid1.SelectedObject = m_Layout

			view.BeginInit()
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.GlobalVisibility.ShowArrowheads = False
			view.ViewLayout = ViewLayout.Fit

			' init document
			document.BeginInit()
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
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

			' create a tree
			Dim tree As NGenericTreeTemplate = New NGenericTreeTemplate()
			tree.Balanced = False
			tree.Levels = 6
			tree.BranchNodes = 3
			tree.HorizontalSpacing = 10
			tree.VerticalSpacing = 10
			tree.VerticesSize = New NSizeF(50, 50)
			tree.VertexSizeDeviation = 1
			tree.Create(document)

			' resize document to fit all shapes
			LayoutButton.PerformClick()
			document.SizeToContent()
		End Sub

		Private Sub RandomButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RandomButton1.Click
			view.LockRefresh = True

			document.ActiveLayer.RemoveAllChildren()

			' create a test tree
			Dim tree As NGenericTreeTemplate = New NGenericTreeTemplate()
			tree.Balanced = False
			tree.Levels = 6
			tree.BranchNodes = 3
			tree.HorizontalSpacing = 10
			tree.VerticalSpacing = 10
			tree.VerticesSize = New NSizeF(50, 50)
			tree.VertexSizeDeviation = 1
			tree.Create(document)

			' layout the tree
			LayoutButton.PerformClick()

			view.LockRefresh = False
		End Sub

		Private Sub RandomButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RandomButton2.Click
			view.LockRefresh = True

			document.ActiveLayer.RemoveAllChildren()

			' create a test tree
			Dim tree As NGenericTreeTemplate = New NGenericTreeTemplate()
			tree.Balanced = False
			tree.Levels = 8
			tree.BranchNodes = 2
			tree.HorizontalSpacing = 10
			tree.VerticalSpacing = 10
			tree.VerticesSize = New NSizeF(50, 50)
			tree.VertexSizeDeviation = 1
			tree.Create(document)

			' layout the tree
			LayoutButton.PerformClick()

			view.LockRefresh = False
		End Sub

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

		#End Region

		#Region "Designer Fields"

		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private WithEvents LayoutButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RandomButton2 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RandomButton1 As Nevron.UI.WinForm.Controls.NButton

		#End Region

		#Region "Fields"

		Private m_Layout As NLayeredTreeLayout

		#End Region
	End Class
End Namespace