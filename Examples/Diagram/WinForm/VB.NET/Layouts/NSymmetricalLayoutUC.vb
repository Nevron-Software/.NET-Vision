Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.Generic

Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Filters

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NSymmetricalLayout.
	''' </summary>
	Public Class NSymmetricalLayoutUC
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
			Me.UpdateDrawingWhileLayouting = New System.Windows.Forms.CheckBox()
			Me.Tree2Button = New Nevron.UI.WinForm.Controls.NButton()
			Me.Tree1Button = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.propertyGrid1.Location = New System.Drawing.Point(8, 3)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.propertyGrid1.Size = New System.Drawing.Size(244, 364)
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
			' UpdateDrawingWhileLayouting
			' 
			Me.UpdateDrawingWhileLayouting.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.UpdateDrawingWhileLayouting.Location = New System.Drawing.Point(8, 456)
			Me.UpdateDrawingWhileLayouting.Name = "UpdateDrawingWhileLayouting"
			Me.UpdateDrawingWhileLayouting.Size = New System.Drawing.Size(244, 17)
			Me.UpdateDrawingWhileLayouting.TabIndex = 8
			Me.UpdateDrawingWhileLayouting.Text = "Update drawing while layouting"
			Me.UpdateDrawingWhileLayouting.UseVisualStyleBackColor = True
			' 
			' Tree2Button
			' 
			Me.Tree2Button.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.Tree2Button.Location = New System.Drawing.Point(8, 402)
			Me.Tree2Button.Name = "Tree2Button"
			Me.Tree2Button.Size = New System.Drawing.Size(244, 23)
			Me.Tree2Button.TabIndex = 9
			Me.Tree2Button.Text = "Tree 2(levels 5, degree 2)"
			Me.Tree2Button.UseVisualStyleBackColor = True
'			Me.Tree2Button.Click += New System.EventHandler(Me.TreeButton2_Click);
			' 
			' Tree1Button
			' 
			Me.Tree1Button.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.Tree1Button.Location = New System.Drawing.Point(8, 373)
			Me.Tree1Button.Name = "Tree1Button"
			Me.Tree1Button.Size = New System.Drawing.Size(244, 23)
			Me.Tree1Button.TabIndex = 10
			Me.Tree1Button.Text = "Tree 1(levels 4, degree 3)"
			Me.Tree1Button.UseVisualStyleBackColor = True
'			Me.Tree1Button.Click += New System.EventHandler(Me.TreeButton1_Click);
			' 
			' NSymmetricalLayoutUC
			' 
			Me.Controls.Add(Me.Tree1Button)
			Me.Controls.Add(Me.Tree2Button)
			Me.Controls.Add(Me.UpdateDrawingWhileLayouting)
			Me.Controls.Add(Me.LayoutButton)
			Me.Controls.Add(Me.propertyGrid1)
			Me.Name = "NSymmetricalLayoutUC"
			Me.Controls.SetChildIndex(Me.propertyGrid1, 0)
			Me.Controls.SetChildIndex(Me.LayoutButton, 0)
			Me.Controls.SetChildIndex(Me.UpdateDrawingWhileLayouting, 0)
			Me.Controls.SetChildIndex(Me.Tree2Button, 0)
			Me.Controls.SetChildIndex(Me.Tree1Button, 0)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' create and configure the spring layout
			m_Layout = New NSymmetricalLayout()

			' hook the iteration completed event
			AddHandler m_Layout.IterationCompleted, AddressOf OnLayoutIterationCompleted

			' select it in the property grid
			propertyGrid1.SelectedObject = m_Layout

			view.BeginInit()
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.GlobalVisibility.ShowArrowheads = False
			view.ViewLayout = ViewLayout.Fit

			' init document
			document.BeginInit()
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			InitDocument()
			document.EndInit()

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

		''' <summary>
		''' Creates a balanced tree diagram with the specified levels and degree
		''' </summary>
		''' <param name="levels"></param>
		''' <param name="branchNodes"></param>
		Private Sub CreateTree(ByVal levels As Integer, ByVal branchNodes As Integer)
			' clean up the active layer
			document.ActiveLayer.RemoveAllChildren()

			' we will be using basic shapes with 40, 40 size
			Dim basicShapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
			basicShapesFactory.DefaultSize = New NSizeF(40, 40)

			Dim cur As NShape = Nothing
			Dim edge As NShape = Nothing

			Dim curRowNodes As List(Of NShape) = Nothing
			Dim prevRowNodes As List(Of NShape) = Nothing

			Dim i, level, levelNodesCount As Integer
			Dim rnd As Random = New Random()

			level = 1
			Do While level <= levels
				curRowNodes = New List(Of NShape)()

				'Create a balanced tree
				levelNodesCount = CInt(Fix(Math.Pow(branchNodes, level - 1)))
				i = 0
				Do While i < levelNodesCount
					' create the cur node
					cur = basicShapesFactory.CreateShape(BasicShapes.Circle)
					CType(cur.Ports.GetChildByName("Center", -1), NDynamicPort).GlueMode = DynamicPortGlueMode.GlueToLocation
					document.ActiveLayer.AddChild(cur)

					' connect with ancestor
					If level > 1 Then
						edge = New NLineShape()
						document.ActiveLayer.AddChild(edge)

						Dim parentIndex As Integer = CInt(Fix(Math.Floor(CDbl(i / branchNodes))))
						edge.FromShape = prevRowNodes(parentIndex)
						edge.ToShape = cur
					End If

					curRowNodes.Add(cur)
					i += 1
				Loop

				prevRowNodes = curRowNodes
				level += 1
			Loop

			' send links to back
			Dim batchReorder As NBatchReorder = New NBatchReorder(document)
			batchReorder.Build(document.ActiveLayer.Children(NFilters.Shape1D))
			batchReorder.SendToBack(False)
		End Sub

		Private Sub InitDocument()
			' create a tree with 4 levels and 3 branch nodes
			CreateTree(4, 3)

			' resize document to fit all shapes
			LayoutButton.PerformClick()
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

		''' <summary>
		''' Invoked on each successfully completed iteration of the layout
		''' </summary>
		''' <param name="args"></param>
		Private Sub OnLayoutIterationCompleted(ByVal args As NGraphLayoutCancelEventArguments)
			If UpdateDrawingWhileLayouting.Checked Then
				Dim refreshLocked As Boolean = view.LockRefresh
				If refreshLocked Then
					view.LockRefresh = False
				End If

				Dim shapeBodyAdaptor As NShapeBodyAdapter = New NShapeBodyAdapter(document)

				Dim en As IEnumerator(Of NGraphPart) = args.Graph.GetPartsEnumerator()
				Do While en.MoveNext()
					Dim vertex As NGraphVertex = TryCast(en.Current, NGraphVertex)
					If Not vertex Is Nothing Then
						Dim body As NBody2D = TryCast(vertex.Tag, NBody2D)
						shapeBodyAdaptor.UpdateObjectFromBody2D(body)
					End If
				Loop

				document.SizeToContent()

				view.Invalidate()
				view.Update()

				If refreshLocked Then
					view.LockRefresh = True
				End If

				Application.DoEvents()
			End If
		End Sub

		Private Sub TreeButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Tree1Button.Click
			view.LockRefresh = True

			' create a random tree
			CreateTree(4, 3)

			' lay it out
			LayoutButton.PerformClick()

			view.LockRefresh = False
		End Sub

		Private Sub TreeButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Tree2Button.Click
			view.LockRefresh = True

			' create a random tree
			CreateTree(5, 2)

			' lay it out
			LayoutButton.PerformClick()

			view.LockRefresh = False
		End Sub

		#End Region

		#Region "Designer Fields"

		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private WithEvents LayoutButton As Nevron.UI.WinForm.Controls.NButton
		Private UpdateDrawingWhileLayouting As System.Windows.Forms.CheckBox
		Private WithEvents Tree2Button As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Tree1Button As Nevron.UI.WinForm.Controls.NButton

		#End Region

		#Region "Fields"

		Private m_Layout As NSymmetricalLayout

		#End Region
	End Class
End Namespace