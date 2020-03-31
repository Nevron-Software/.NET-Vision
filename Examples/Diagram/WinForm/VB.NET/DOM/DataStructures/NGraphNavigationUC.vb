Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.Layout

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NGraphNavigationUC.
	''' </summary>
	Public Class NGraphNavigationUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.vertexHighlightsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.successorVerticesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.predecessorVerticesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.accessibleVerticesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.destinationVerticesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.sourceVerticesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.neighbourVerticesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.allEdgesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.outgoingEdgesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.incommingEdgesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.edgeHighlightsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.toVertexCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.fromVertexCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.graphPartCheck = New System.Windows.Forms.CheckBox()
			Me.vertexHighlightsGroup.SuspendLayout()
			Me.edgeHighlightsGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' vertexHighlightsGroup
			' 
			Me.vertexHighlightsGroup.Controls.Add(Me.successorVerticesCheck)
			Me.vertexHighlightsGroup.Controls.Add(Me.predecessorVerticesCheck)
			Me.vertexHighlightsGroup.Controls.Add(Me.accessibleVerticesCheck)
			Me.vertexHighlightsGroup.Controls.Add(Me.destinationVerticesCheck)
			Me.vertexHighlightsGroup.Controls.Add(Me.sourceVerticesCheck)
			Me.vertexHighlightsGroup.Controls.Add(Me.neighbourVerticesCheck)
			Me.vertexHighlightsGroup.Controls.Add(Me.allEdgesCheck)
			Me.vertexHighlightsGroup.Controls.Add(Me.outgoingEdgesCheck)
			Me.vertexHighlightsGroup.Controls.Add(Me.incommingEdgesCheck)
			Me.vertexHighlightsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.vertexHighlightsGroup.ImageIndex = 0
			Me.vertexHighlightsGroup.Location = New System.Drawing.Point(0, 0)
			Me.vertexHighlightsGroup.Name = "vertexHighlightsGroup"
			Me.vertexHighlightsGroup.Size = New System.Drawing.Size(248, 256)
			Me.vertexHighlightsGroup.TabIndex = 30
			Me.vertexHighlightsGroup.TabStop = False
			Me.vertexHighlightsGroup.Text = "Selected vertex highlighs"
			' 
			' successorVerticesCheck
			' 
			Me.successorVerticesCheck.Location = New System.Drawing.Point(48, 216)
			Me.successorVerticesCheck.Name = "successorVerticesCheck"
			Me.successorVerticesCheck.Size = New System.Drawing.Size(152, 16)
			Me.successorVerticesCheck.TabIndex = 8
			Me.successorVerticesCheck.Text = "Successor vertices"
'			Me.successorVerticesCheck.CheckedChanged += New System.EventHandler(Me.successorVerticesCheck_CheckedChanged);
			' 
			' predecessorVerticesCheck
			' 
			Me.predecessorVerticesCheck.Location = New System.Drawing.Point(48, 192)
			Me.predecessorVerticesCheck.Name = "predecessorVerticesCheck"
			Me.predecessorVerticesCheck.Size = New System.Drawing.Size(152, 16)
			Me.predecessorVerticesCheck.TabIndex = 7
			Me.predecessorVerticesCheck.Text = "Predecessor vertices"
'			Me.predecessorVerticesCheck.CheckedChanged += New System.EventHandler(Me.predecessorVerticesCheck_CheckedChanged);
			' 
			' accessibleVerticesCheck
			' 
			Me.accessibleVerticesCheck.Location = New System.Drawing.Point(8, 168)
			Me.accessibleVerticesCheck.Name = "accessibleVerticesCheck"
			Me.accessibleVerticesCheck.Size = New System.Drawing.Size(152, 16)
			Me.accessibleVerticesCheck.TabIndex = 6
			Me.accessibleVerticesCheck.Text = "Accessible vertices"
'			Me.accessibleVerticesCheck.CheckedChanged += New System.EventHandler(Me.accessibleVerticesCheck_CheckedChanged);
			' 
			' destinationVerticesCheck
			' 
			Me.destinationVerticesCheck.Location = New System.Drawing.Point(48, 144)
			Me.destinationVerticesCheck.Name = "destinationVerticesCheck"
			Me.destinationVerticesCheck.Size = New System.Drawing.Size(152, 16)
			Me.destinationVerticesCheck.TabIndex = 5
			Me.destinationVerticesCheck.Text = "Destination vertices"
'			Me.destinationVerticesCheck.CheckedChanged += New System.EventHandler(Me.destinationVerticesCheck_CheckedChanged);
			' 
			' sourceVerticesCheck
			' 
			Me.sourceVerticesCheck.Location = New System.Drawing.Point(48, 120)
			Me.sourceVerticesCheck.Name = "sourceVerticesCheck"
			Me.sourceVerticesCheck.Size = New System.Drawing.Size(152, 16)
			Me.sourceVerticesCheck.TabIndex = 4
			Me.sourceVerticesCheck.Text = "Source vertices"
'			Me.sourceVerticesCheck.CheckedChanged += New System.EventHandler(Me.sourceVerticesCheck_CheckedChanged);
			' 
			' neighbourVerticesCheck
			' 
			Me.neighbourVerticesCheck.Location = New System.Drawing.Point(8, 96)
			Me.neighbourVerticesCheck.Name = "neighbourVerticesCheck"
			Me.neighbourVerticesCheck.Size = New System.Drawing.Size(152, 16)
			Me.neighbourVerticesCheck.TabIndex = 3
			Me.neighbourVerticesCheck.Text = "Neighbour vertices"
'			Me.neighbourVerticesCheck.CheckedChanged += New System.EventHandler(Me.neighbourVerticesCheck_CheckedChanged);
			' 
			' allEdgesCheck
			' 
			Me.allEdgesCheck.Location = New System.Drawing.Point(8, 24)
			Me.allEdgesCheck.Name = "allEdgesCheck"
			Me.allEdgesCheck.Size = New System.Drawing.Size(152, 16)
			Me.allEdgesCheck.TabIndex = 2
			Me.allEdgesCheck.Text = "All edges"
'			Me.allEdgesCheck.CheckedChanged += New System.EventHandler(Me.allEdgesCheck_CheckedChanged);
			' 
			' outgoingEdgesCheck
			' 
			Me.outgoingEdgesCheck.Location = New System.Drawing.Point(48, 72)
			Me.outgoingEdgesCheck.Name = "outgoingEdgesCheck"
			Me.outgoingEdgesCheck.Size = New System.Drawing.Size(152, 16)
			Me.outgoingEdgesCheck.TabIndex = 1
			Me.outgoingEdgesCheck.Text = "Outgoing edges"
'			Me.outgoingEdgesCheck.CheckedChanged += New System.EventHandler(Me.outgoingEdgesCheck_CheckedChanged);
			' 
			' incommingEdgesCheck
			' 
			Me.incommingEdgesCheck.Location = New System.Drawing.Point(48, 48)
			Me.incommingEdgesCheck.Name = "incommingEdgesCheck"
			Me.incommingEdgesCheck.Size = New System.Drawing.Size(152, 16)
			Me.incommingEdgesCheck.TabIndex = 0
			Me.incommingEdgesCheck.Text = "Incomming edges"
'			Me.incommingEdgesCheck.CheckedChanged += New System.EventHandler(Me.incommingEdgesCheck_CheckedChanged);
			' 
			' edgeHighlightsGroup
			' 
			Me.edgeHighlightsGroup.Controls.Add(Me.toVertexCheck)
			Me.edgeHighlightsGroup.Controls.Add(Me.fromVertexCheck)
			Me.edgeHighlightsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.edgeHighlightsGroup.ImageIndex = 0
			Me.edgeHighlightsGroup.Location = New System.Drawing.Point(0, 256)
			Me.edgeHighlightsGroup.Name = "edgeHighlightsGroup"
			Me.edgeHighlightsGroup.Size = New System.Drawing.Size(248, 80)
			Me.edgeHighlightsGroup.TabIndex = 31
			Me.edgeHighlightsGroup.TabStop = False
			Me.edgeHighlightsGroup.Text = "Selected edge highlighs"
			' 
			' toVertexCheck
			' 
			Me.toVertexCheck.Location = New System.Drawing.Point(8, 48)
			Me.toVertexCheck.Name = "toVertexCheck"
			Me.toVertexCheck.Size = New System.Drawing.Size(152, 16)
			Me.toVertexCheck.TabIndex = 10
			Me.toVertexCheck.Text = "To vertex"
'			Me.toVertexCheck.CheckedChanged += New System.EventHandler(Me.toVertexCheck_CheckedChanged);
			' 
			' fromVertexCheck
			' 
			Me.fromVertexCheck.Location = New System.Drawing.Point(8, 24)
			Me.fromVertexCheck.Name = "fromVertexCheck"
			Me.fromVertexCheck.Size = New System.Drawing.Size(152, 16)
			Me.fromVertexCheck.TabIndex = 9
			Me.fromVertexCheck.Text = "From vertex"
'			Me.fromVertexCheck.CheckedChanged += New System.EventHandler(Me.fromVertexCheck_CheckedChanged);
			' 
			' graphPartCheck
			' 
			Me.graphPartCheck.Location = New System.Drawing.Point(8, 352)
			Me.graphPartCheck.Name = "graphPartCheck"
			Me.graphPartCheck.Size = New System.Drawing.Size(216, 24)
			Me.graphPartCheck.TabIndex = 32
			Me.graphPartCheck.Text = "Graph part"
'			Me.graphPartCheck.CheckedChanged += New System.EventHandler(Me.graphPartCheck_CheckedChanged);
			' 
			' NGraphNavigationUC
			' 
			Me.Controls.Add(Me.graphPartCheck)
			Me.Controls.Add(Me.edgeHighlightsGroup)
			Me.Controls.Add(Me.vertexHighlightsGroup)
			Me.Name = "NGraphNavigationUC"
			Me.Size = New System.Drawing.Size(248, 560)
			Me.Controls.SetChildIndex(Me.vertexHighlightsGroup, 0)
			Me.Controls.SetChildIndex(Me.edgeHighlightsGroup, 0)
			Me.Controls.SetChildIndex(Me.graphPartCheck, 0)
			Me.vertexHighlightsGroup.ResumeLayout(False)
			Me.edgeHighlightsGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init form members
			highlightFillStyle = New NColorFillStyle(Color.FromArgb(80, Color.Red))
			highlightStrokeStyle = New NStrokeStyle(2, Color.Red)

			' begin view init
			view.BeginInit()

			view.Grid.Visible = False
			view.Selection.Mode = DiagramSelectionMode.Single
			view.InteractiveAppearance.SelectedStrokeStyle = New NStrokeStyle(2, Color.Blue)
			view.InteractiveAppearance.SelectedFillStyle = New NColorFillStyle(Color.FromArgb(80, Color.Blue))

			' init document
			document.BeginInit()

			document.Style.TextStyle = New NTextStyle(New Font("Arial", 9), Color.Black)
			InitDocument()

			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub AttachToEvents()
			AddHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_OnNodeSelected
			AddHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_OnNodeDeselected

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_OnNodeSelected
			RemoveHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_OnNodeDeselected

			MyBase.DetachFromEvents()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			view.GlobalVisibility.ShowPorts = False
			incommingEdgesCheck.Checked = False
			outgoingEdgesCheck.Checked = False
			allEdgesCheck.Checked = False
			neighbourVerticesCheck.Checked = False
			sourceVerticesCheck.Checked = False
			destinationVerticesCheck.Checked = False
			accessibleVerticesCheck.Checked = False
			predecessorVerticesCheck.Checked = False
			successorVerticesCheck.Checked = False
			fromVertexCheck.Checked = False
			toVertexCheck.Checked = False
			graphPartCheck.Checked = True

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			Dim template As NGraphTemplate

			' create rectangular grid template
			template = New NRectangularGridTemplate()
			template.Origin = New NPointF(10, 23)
			template.VerticesShape = BasicShapes.Rectangle
			template.Create(document)

			' create tree template
			template = New NGenericTreeTemplate()
			template.Origin = New NPointF(250, 23)
			template.VerticesShape = BasicShapes.Triangle
			template.Create(document)

			' create elliptical grid template
			template = New NEllipticalGridTemplate()
			template.Origin = New NPointF(10, 250)
			template.VerticesShape = BasicShapes.Ellipse
			template.Create(document)
		End Sub

		Private Function GetShapesList(ByVal edges As NGraphEdgeList, ByVal map As NObjectGraphPartMap) As NNodeList
			Dim list As NNodeList = New NNodeList()
			Dim i As Integer, edgeCount As Integer = edges.Count
			i = 0
			Do While i < edgeCount
				list.Add(CType(map.GetObjectFromPart(edges(i)), NShape))
				i += 1
			Loop

			Return list
		End Function

		Private Function GetShapesList(ByVal vertices As NGraphVertexList, ByVal map As NObjectGraphPartMap) As NNodeList
			Dim list As NNodeList = New NNodeList()
			Dim i As Integer, vertexCount As Integer = vertices.Count
			i = 0
			Do While i < vertexCount
				list.Add(CType(map.GetObjectFromPart(vertices(i)), NShape))
				i += 1
			Loop

			Return list
		End Function

		Private Sub UpdateHighlights()
			ClearHighlights()

			' get the selected shape
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				document.SmartRefreshAllViews()
				Return
			End If

			' build the graph in which the shape resides
			Dim graphBuilder As NGraphBuilder = New NGraphBuilder(New NShapeGraphAdapter(), New NGraphPartFactory())

			Dim map As NObjectGraphPartMap
			Dim graph As NGraph = graphBuilder.BuildGraph(shape, map)

			If graph Is Nothing Then
				document.SmartRefreshAllViews()
				Return
			End If

			Dim shapesToHighlight As NNodeList = New NNodeList()
			Select Case shape.ShapeType
				Case ShapeType.Shape2D

					' 2D shapes are treated as graph vertices, so we must find the vertex in the graph, which 
					' represents the shape
					Dim vertex As NGraphVertex = (TryCast(map.GetPartFromObject(shape), NGraphVertex))
					If Not vertex Is Nothing Then
						' add edges
						If allEdgesCheck.Checked Then
							shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.Edges, map))
						Else
							If incommingEdgesCheck.Checked Then
								shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.IncomingEdges, map))
							End If

							If outgoingEdgesCheck.Checked Then
								shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.OutgoingEdges, map))
							End If
						End If

						' add neighbour vertices
						If neighbourVerticesCheck.Checked Then
							shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.NeighbourVertices, map))
						Else
							If sourceVerticesCheck.Checked Then
								shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.SourceVertices, map))
							End If

							If destinationVerticesCheck.Checked Then
								shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.DestinationVertices, map))
							End If
						End If

						' add accessible vertices
						If accessibleVerticesCheck.Checked Then
							shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.AccessibleVertices, map))
						Else
							If predecessorVerticesCheck.Checked Then
								shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.PredecessorVertices, map))
							End If

							If successorVerticesCheck.Checked Then
								shapesToHighlight.AddRangeNoDuplicates(GetShapesList(vertex.SuccessorVertices, map))
							End If
						End If
					End If

				Case ShapeType.Shape1D

					' 1D shapes are treated as graph edges, so we must find the edge in the graph, which 
					' represents the shape
					Dim edge As NGraphEdge = (TryCast(map.GetPartFromObject(shape), NGraphEdge))
					If Not edge Is Nothing Then
						If fromVertexCheck.Checked Then
							shapesToHighlight.AddNoDuplicates(CType(map.GetObjectFromPart(edge.FromVertex), NShape))
						End If

						If toVertexCheck.Checked Then
							shapesToHighlight.AddNoDuplicates(CType(map.GetObjectFromPart(edge.ToVertex), NShape))
						End If
					End If
			End Select

			' highlight the shapes
			For Each cur As NShape In shapesToHighlight
				cur.Style.FillStyle = (TryCast(highlightFillStyle.Clone(), NFillStyle))
				cur.Style.StrokeStyle = (TryCast(highlightStrokeStyle.Clone(), NStrokeStyle))
			Next cur

			' smart refresh all views
			document.SmartRefreshAllViews()
		End Sub

		Private Sub ClearHighlights()
			Dim en As NNodeEnumerator = document.ActiveLayer.GetEnumerator(Nothing)
			Do While en.MoveNext()
				Dim shape As NShape = (TryCast(en.Current, NShape))
				If Not shape Is Nothing Then
					shape.Style.FillStyle = Nothing
					shape.Style.StrokeStyle = Nothing
				End If
			Loop
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub EventSinkService_OnNodeSelected(ByVal args As NNodeEventArgs)
			Dim shape As NShape = (TryCast(args.Node, NShape))
			If Not shape Is Nothing Then
				MyBase.PauseEventsHandling()

				graphPartCheck.Enabled = True
				graphPartCheck.Checked = shape.GraphPart

				MyBase.ResumeEventsHandling()
			End If

			UpdateHighlights()
		End Sub

		Private Sub EventSinkService_OnNodeDeselected(ByVal args As NNodeEventArgs)
			ClearHighlights()
			graphPartCheck.Enabled = False

			document.SmartRefreshAllViews()
		End Sub


		Private Sub allEdgesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles allEdgesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()

			incommingEdgesCheck.Checked = allEdgesCheck.Checked
			outgoingEdgesCheck.Checked = allEdgesCheck.Checked

			ResumeEventsHandling()

			UpdateHighlights()
		End Sub

		Private Sub incommingEdgesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles incommingEdgesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateHighlights()
		End Sub

		Private Sub outgoingEdgesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles outgoingEdgesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateHighlights()
		End Sub

		Private Sub neighbourVerticesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles neighbourVerticesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()

			sourceVerticesCheck.Checked = neighbourVerticesCheck.Checked
			destinationVerticesCheck.Checked = neighbourVerticesCheck.Checked

			ResumeEventsHandling()

			UpdateHighlights()
		End Sub

		Private Sub sourceVerticesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sourceVerticesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateHighlights()
		End Sub

		Private Sub destinationVerticesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles destinationVerticesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateHighlights()
		End Sub

		Private Sub accessibleVerticesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles accessibleVerticesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()

			successorVerticesCheck.Checked = accessibleVerticesCheck.Checked
			predecessorVerticesCheck.Checked = accessibleVerticesCheck.Checked

			ResumeEventsHandling()

			UpdateHighlights()
		End Sub

		Private Sub predecessorVerticesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles predecessorVerticesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateHighlights()
		End Sub

		Private Sub successorVerticesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles successorVerticesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateHighlights()
		End Sub

		Private Sub fromVertexCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fromVertexCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateHighlights()
		End Sub

		Private Sub toVertexCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles toVertexCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateHighlights()
		End Sub

		Private Sub graphPartCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles graphPartCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				Return
			End If

			shape.GraphPart = graphPartCheck.Checked
			If shape.GraphPart = False Then
				shape.Text = "No"
			Else
				shape.Text = ""
			End If

			UpdateHighlights()
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region

		#Region "Fields"

		Private highlightFillStyle As NColorFillStyle = Nothing
		Private highlightStrokeStyle As NStrokeStyle = Nothing

		Private vertexHighlightsGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private edgeHighlightsGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents incommingEdgesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents outgoingEdgesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents allEdgesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents neighbourVerticesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents sourceVerticesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents destinationVerticesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents accessibleVerticesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents predecessorVerticesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents successorVerticesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents fromVertexCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents toVertexCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents graphPartCheck As System.Windows.Forms.CheckBox
		Private selectedStrokeStyle As NStrokeStyle = Nothing

		#End Region
	End Class
End Namespace