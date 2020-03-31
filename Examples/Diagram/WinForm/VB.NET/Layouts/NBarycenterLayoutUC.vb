Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections.Generic

Imports Nevron.Diagram.Layout
Imports Nevron.Diagram
Imports Nevron.Diagram.Batches
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Filters

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NBarycenterLayoutUC.
	''' </summary>
	Public Class NBarycenterLayoutUC
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
			Me.TriangularGridButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.TriangularGridButton2 = New Nevron.UI.WinForm.Controls.NButton()
			Me.Random1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.Random2 = New Nevron.UI.WinForm.Controls.NButton()
			Me.UpdateDrawingWhileLayouting = New System.Windows.Forms.CheckBox()
			Me.SuspendLayout()
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.propertyGrid1.Location = New System.Drawing.Point(8, 3)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.propertyGrid1.Size = New System.Drawing.Size(244, 327)
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
			' TriangularGridButton1
			' 
			Me.TriangularGridButton1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.TriangularGridButton1.Location = New System.Drawing.Point(8, 339)
			Me.TriangularGridButton1.Name = "TriangularGridButton1"
			Me.TriangularGridButton1.Size = New System.Drawing.Size(244, 23)
			Me.TriangularGridButton1.TabIndex = 3
			Me.TriangularGridButton1.Text = "Triangular Grid (levels 6)"
			Me.TriangularGridButton1.UseVisualStyleBackColor = True
'			Me.TriangularGridButton1.Click += New System.EventHandler(Me.TriangularGridButton1_Click);
			' 
			' TriangularGridButton2
			' 
			Me.TriangularGridButton2.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.TriangularGridButton2.Location = New System.Drawing.Point(8, 368)
			Me.TriangularGridButton2.Name = "TriangularGridButton2"
			Me.TriangularGridButton2.Size = New System.Drawing.Size(244, 23)
			Me.TriangularGridButton2.TabIndex = 4
			Me.TriangularGridButton2.Text = "Triangular Grid (levels 8)"
			Me.TriangularGridButton2.UseVisualStyleBackColor = True
'			Me.TriangularGridButton2.Click += New System.EventHandler(Me.TriangularGridButton2_Click);
			' 
			' Random1
			' 
			Me.Random1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.Random1.Location = New System.Drawing.Point(8, 397)
			Me.Random1.Name = "Random1"
			Me.Random1.Size = New System.Drawing.Size(244, 23)
			Me.Random1.TabIndex = 5
			Me.Random1.Text = "Random (fixed 10, free 10)"
			Me.Random1.UseVisualStyleBackColor = True
'			Me.Random1.Click += New System.EventHandler(Me.Random1_Click);
			' 
			' Random2
			' 
			Me.Random2.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.Random2.Location = New System.Drawing.Point(8, 426)
			Me.Random2.Name = "Random2"
			Me.Random2.Size = New System.Drawing.Size(244, 23)
			Me.Random2.TabIndex = 6
			Me.Random2.Text = "Random (fixed 15, free 15)"
			Me.Random2.UseVisualStyleBackColor = True
'			Me.Random2.Click += New System.EventHandler(Me.Random2_Click);
			' 
			' UpdateDrawingWhileLayouting
			' 
			Me.UpdateDrawingWhileLayouting.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.UpdateDrawingWhileLayouting.Location = New System.Drawing.Point(8, 455)
			Me.UpdateDrawingWhileLayouting.Name = "UpdateDrawingWhileLayouting"
			Me.UpdateDrawingWhileLayouting.Size = New System.Drawing.Size(244, 17)
			Me.UpdateDrawingWhileLayouting.TabIndex = 7
			Me.UpdateDrawingWhileLayouting.Text = "Update drawing while layouting"
			Me.UpdateDrawingWhileLayouting.UseVisualStyleBackColor = True
'			Me.UpdateDrawingWhileLayouting.CheckedChanged += New System.EventHandler(Me.UpdateDrawingWhileLayouting_CheckedChanged);
			' 
			' NBarycenterLayoutUC
			' 
			Me.Controls.Add(Me.UpdateDrawingWhileLayouting)
			Me.Controls.Add(Me.Random2)
			Me.Controls.Add(Me.Random1)
			Me.Controls.Add(Me.TriangularGridButton2)
			Me.Controls.Add(Me.TriangularGridButton1)
			Me.Controls.Add(Me.LayoutButton)
			Me.Controls.Add(Me.propertyGrid1)
			Me.Name = "NBarycenterLayoutUC"
			Me.Controls.SetChildIndex(Me.propertyGrid1, 0)
			Me.Controls.SetChildIndex(Me.LayoutButton, 0)
			Me.Controls.SetChildIndex(Me.TriangularGridButton1, 0)
			Me.Controls.SetChildIndex(Me.TriangularGridButton2, 0)
			Me.Controls.SetChildIndex(Me.Random1, 0)
			Me.Controls.SetChildIndex(Me.Random2, 0)
			Me.Controls.SetChildIndex(Me.UpdateDrawingWhileLayouting, 0)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' create the barycenter layout
			m_Layout = New NBarycenterLayout()

			' free vertices are placed in the fixed vertices barycenter
			m_Layout.FreeVertexPlacement.Mode = FreeVertexPlacementMode.FixedBarycenter

			' fixed vertices are placed on the rim of the specified ellipse
			m_Layout.FixedVertexPlacement.Mode = FixedVertexPlacementMode.PredefinedEllipseRim
			m_Layout.FixedVertexPlacement.PredefinedEllipseBounds = New NRectangleF(0, 0, 700, 700)

			' hook the iteration completed event
			AddHandler m_Layout.IterationCompleted, AddressOf layout_IterationCompleted

			' select the layout for edit in the property grid
			propertyGrid1.SelectedObject = m_Layout

			view.BeginInit()

			' init view
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.TrackersManager.ShowRotatatedBoundsTrackers = False
			view.TrackersManager.ShowPinPointTrackers = False
			view.TrackersManager.ShowRotationTrackers = False
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

		#End Region

		#Region "Event Handlers"

		Private Sub TriangularGridButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TriangularGridButton1.Click
			view.LockRefresh = True

			CreateTriangularGridDiagram(6)
			LayoutButton.PerformClick()

			view.LockRefresh = False
		End Sub

		Private Sub TriangularGridButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TriangularGridButton2.Click
			view.LockRefresh = True

			CreateTriangularGridDiagram(8)
			LayoutButton.PerformClick()

			view.LockRefresh = False
		End Sub

		Private Sub Random1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Random1.Click
			view.LockRefresh = True

			CreateRandomDiagram(10, 10)
			LayoutButton.PerformClick()

			view.LockRefresh = False
		End Sub

		Private Sub Random2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Random2.Click
			view.LockRefresh = True

			CreateRandomDiagram(15, 15)
			LayoutButton.PerformClick()

			view.LockRefresh = False
		End Sub

		''' <summary>
		''' Invoked on each successfully completed iteration of the layout
		''' </summary>
		''' <param name="args"></param>
		Private Sub layout_IterationCompleted(ByVal args As NGraphLayoutCancelEventArguments)
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

			document.SizeToContent()
		End Sub

		Private Sub UpdateDrawingWhileLayouting_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles UpdateDrawingWhileLayouting.CheckedChanged
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()
			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			' disable history
			document.HistoryService.Pause()

			' create a random diagram
			CreateRandomDiagram(15, 15)

			' do the layout
			LayoutButton.PerformClick()
		End Sub

		''' <summary>
		''' Creates a random barycenter diagram with the specified settings
		''' </summary>
		''' <param name="fixedCount">number of fixed vertices (must be larger than 3)</param>
		''' <param name="freeCount">number of free vertices</param>
		Private Sub CreateRandomDiagram(ByVal fixedCount As Integer, ByVal freeCount As Integer)
			If fixedCount < 3 Then
				Throw New ArgumentException("Needs at least three fixed vertices")
			End If

			' clean up the layers
			document.ActiveLayer.RemoveAllChildren()

			' we will be using basic circle shapes with default size of (30, 30)
			Dim basicShapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
			basicShapesFactory.DefaultSize = New NSizeF(30, 30)

			' create the fixed vertices
			Dim fixedShapes As NShape() = New NShape(fixedCount - 1){}

			Dim i As Integer = 0
			Do While i < fixedCount
				fixedShapes(i) = basicShapesFactory.CreateShape(BasicShapes.Circle)
				CType(fixedShapes(i).Ports.GetChildByName("Center", -1), NDynamicPort).GlueMode = DynamicPortGlueMode.GlueToLocation
				fixedShapes(i).Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
				fixedShapes(i).Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

				' setting the ForceXMoveable and ForceYMoveable properties to false
				' specifies that the layout cannot move the shape in both X and Y directions
				fixedShapes(i).LayoutData.ForceXMoveable = False
				fixedShapes(i).LayoutData.ForceYMoveable = False

				document.ActiveLayer.AddChild(fixedShapes(i))
				i += 1
			Loop

			' create the free vertices
			Dim freeShapes As NShape() = New NShape(freeCount - 1){}
			i = 0
			Do While i < freeCount
				freeShapes(i) = basicShapesFactory.CreateShape(BasicShapes.Circle)
				CType(freeShapes(i).Ports.GetChildByName("Center", - 1), NDynamicPort).GlueMode = DynamicPortGlueMode.GlueToLocation
				freeShapes(i).Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
				freeShapes(i).Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
				document.ActiveLayer.AddChild(freeShapes(i))
				i += 1
			Loop

			' link the fixed shapes in a circle
			i = 0
			Do While i < fixedCount
				Dim lineShape As NLineShape = New NLineShape()
				document.ActiveLayer.AddChild(lineShape)

				If i = 0 Then
					lineShape.FromShape = fixedShapes(fixedCount - 1)
					lineShape.ToShape = fixedShapes(0)
				Else
					lineShape.FromShape = fixedShapes(i - 1)
					lineShape.ToShape = fixedShapes(i)
				End If
				i += 1
			Loop

			' link each free shape with two different random fixed shapes
			Dim rnd As Random = New Random()
			i = 0
			Do While i < freeCount
				Dim firstFixed As Integer = rnd.Next(fixedCount)
				Dim secondFixed As Integer = (firstFixed + rnd.Next(fixedCount / 3) + 1) Mod fixedCount

				' link with first fixed
				Dim lineShape As NLineShape = New NLineShape()
				document.ActiveLayer.AddChild(lineShape)

				lineShape.FromShape = freeShapes(i)
				lineShape.ToShape = fixedShapes(firstFixed)

				' link with second fixed
				lineShape = New NLineShape()
				document.ActiveLayer.AddChild(lineShape)

				lineShape.FromShape = freeShapes(i)
				lineShape.ToShape = fixedShapes(secondFixed)
				i += 1
			Loop

			' link each free shape with another free shape
			i = 1
			Do While i < freeCount
				Dim lineShape As NLineShape = New NLineShape()
				document.ActiveLayer.AddChild(lineShape)

				lineShape.FromShape = freeShapes(i - 1)
				lineShape.ToShape = freeShapes(i)
				i += 1
			Loop

			Dim batchReorder As NBatchReorder = New NBatchReorder(document)
			batchReorder.Build(document.ActiveLayer.Children(NFilters.Shape1D))
			batchReorder.SendToBack(False)
		End Sub
		''' <summary>
		''' Creates a triangular grid diagram with the specified count of levels
		''' </summary>
		''' <param name="levels"></param>
		Private Sub CreateTriangularGridDiagram(ByVal levels As Integer)
			' clean up the active layer 
			document.ActiveLayer.RemoveAllChildren()

			' we will be using basic circle shapes with default size of (30, 30)
			Dim basicShapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
			basicShapesFactory.DefaultSize = New NSizeF(30, 30)

			Dim cur As NShape = Nothing, prev As NShape = Nothing
			Dim edge As NShape = Nothing
			Dim curRowShapes As List(Of NShape) = Nothing
			Dim prevRowShapes As List(Of NShape) = Nothing

			Dim level As Integer = 1
			Do While level < levels
				curRowShapes = New List(Of NShape)()

				Dim i As Integer = 0
				Do While i < level
					cur = basicShapesFactory.CreateShape(BasicShapes.Circle)
					CType(cur.Ports.GetChildByName("Center", -1), NDynamicPort).GlueMode = DynamicPortGlueMode.GlueToLocation
					cur.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
					cur.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
					document.ActiveLayer.AddChild(cur)

					' connect with prev
					If i > 0 Then
						edge = New NLineShape()
						document.ActiveLayer.AddChild(edge)

						edge.FromShape = prev
						edge.ToShape = cur
					End If

					' connect with ancestors
					If level > 1 Then
						If i < prevRowShapes.Count Then
							edge = New NLineShape()
							document.ActiveLayer.AddChild(edge)

							edge.FromShape = prevRowShapes(i)
							edge.ToShape = cur
						End If

						If i > 0 Then
							edge = New NLineShape()
							document.ActiveLayer.AddChild(edge)

							edge.FromShape = prevRowShapes(i - 1)
							edge.ToShape = cur
						End If
					End If

					' fix the three corner vertices
					If level = 1 OrElse (level = levels - 1 AndAlso (i = 0 OrElse i = level - 1)) Then
						cur.LayoutData.ForceXMoveable = False
						cur.LayoutData.ForceYMoveable = False
						cur.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
						cur.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
					End If

					curRowShapes.Add(cur)
					prev = cur
					i += 1
				Loop

				prevRowShapes = curRowShapes
				level += 1
			Loop

			Dim batchReorder As NBatchReorder = New NBatchReorder(document)
			batchReorder.Build(document.ActiveLayer.Children(NFilters.Shape1D))
			batchReorder.SendToBack(False)
		End Sub

		#End Region

		#Region "Designer Fields"

		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private WithEvents LayoutButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents TriangularGridButton1 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents TriangularGridButton2 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Random1 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Random2 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents UpdateDrawingWhileLayouting As System.Windows.Forms.CheckBox

		#End Region

		#Region "Fields"

		Private m_Layout As NBarycenterLayout

		#End Region
	End Class
End Namespace