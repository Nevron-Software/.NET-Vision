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

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NGraphTraversalUC.
	''' </summary>
	Public Class NGraphTraversalUC
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
			Me.graphPartCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.directedGraphRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.undirectedGraphRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.traversalMethodComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' graphPartCheck
			' 
			Me.graphPartCheck.Location = New System.Drawing.Point(8, 144)
			Me.graphPartCheck.Name = "graphPartCheck"
			Me.graphPartCheck.Size = New System.Drawing.Size(216, 24)
			Me.graphPartCheck.TabIndex = 32
			Me.graphPartCheck.Text = "Graph part"
'			Me.graphPartCheck.CheckedChanged += New System.EventHandler(Me.graphPartCheck_CheckedChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.directedGraphRadioButton)
			Me.groupBox1.Controls.Add(Me.undirectedGraphRadioButton)
			Me.groupBox1.Controls.Add(Me.traversalMethodComboBox)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(248, 136)
			Me.groupBox1.TabIndex = 33
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Graph traversal"
			' 
			' directedGraphRadioButton
			' 
			Me.directedGraphRadioButton.Location = New System.Drawing.Point(8, 104)
			Me.directedGraphRadioButton.Name = "directedGraphRadioButton"
			Me.directedGraphRadioButton.TabIndex = 3
			Me.directedGraphRadioButton.Text = "Directed graph"
'			Me.directedGraphRadioButton.CheckedChanged += New System.EventHandler(Me.directedGraphRadioButton_CheckedChanged);
			' 
			' undirectedGraphRadioButton
			' 
			Me.undirectedGraphRadioButton.Location = New System.Drawing.Point(8, 80)
			Me.undirectedGraphRadioButton.Name = "undirectedGraphRadioButton"
			Me.undirectedGraphRadioButton.Size = New System.Drawing.Size(136, 24)
			Me.undirectedGraphRadioButton.TabIndex = 2
			Me.undirectedGraphRadioButton.Text = "Undirected graph"
'			Me.undirectedGraphRadioButton.CheckedChanged += New System.EventHandler(Me.undirectedGraphRadioButton_CheckedChanged);
			' 
			' traversalMethodComboBox
			' 
			Me.traversalMethodComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.traversalMethodComboBox.Location = New System.Drawing.Point(8, 48)
			Me.traversalMethodComboBox.Name = "traversalMethodComboBox"
			Me.traversalMethodComboBox.Size = New System.Drawing.Size(232, 21)
			Me.traversalMethodComboBox.TabIndex = 1
'			Me.traversalMethodComboBox.SelectedIndexChanged += New System.EventHandler(Me.traversalMethodComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Traversal method:"
			' 
			' NGraphTraversalUC
			' 
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.graphPartCheck)
			Me.Name = "NGraphTraversalUC"
			Me.Size = New System.Drawing.Size(248, 560)
			Me.Controls.SetChildIndex(Me.graphPartCheck, 0)
			Me.Controls.SetChildIndex(Me.groupBox1, 0)
			Me.groupBox1.ResumeLayout(False)
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
			traversalMethodComboBox.Items.Clear()
			traversalMethodComboBox.Items.Add("Depth First Traversal")
			traversalMethodComboBox.Items.Add("Breadth First Traversal")
			traversalMethodComboBox.Items.Add("Topological Order Traversal")
			traversalMethodComboBox.SelectedIndex = 0
			undirectedGraphRadioButton.Checked = True

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

		Private Sub UpdateHighlights()
			ClearHighlights()

			' get the selected shape
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				document.SmartRefreshAllViews()
				Return
			End If

			' get the graph in which the shape resides
			Dim graphBuilder As NGraphBuilder = New NGraphBuilder(New NShapeGraphAdapter(), New NGraphPartFactory())

			Dim map As NObjectGraphPartMap
			Dim graph As NGraph = graphBuilder.BuildGraph(shape, map)
			If graph Is Nothing Then
				document.SmartRefreshAllViews()
				Return
			End If

			' get the vertex which represents the shape in the graph
			Dim vertex As NGraphVertex = (TryCast(map.GetPartFromObject(shape), NGraphVertex))
			If vertex Is Nothing Then
				Return
			End If

			' create a visitor which will visit and highlight the graph parts
			Dim visitor As NHighlightingVisitor = New NHighlightingVisitor(Me)
			visitor.objectMap = map
			Dim graphType As GraphType
			If undirectedGraphRadioButton.Checked Then
				graphType = (GraphType.Undirected)
			Else
				graphType = (GraphType.Directed)
			End If

			Select Case traversalMethodComboBox.SelectedIndex
				Case 0 ' Depth First Traversal
					graph.DepthFirstTraversal(graphType, visitor, vertex)

				Case 1 ' Breadth First Traversal
					graph.BreadthFirstTraversal(graphType, visitor, vertex)

				Case 2 ' Topological Order Traversal (applicable for directed graphs only)
					graph.TopologicalOrderTraversal(visitor)
			End Select

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
					shape.Text = ""
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


		Private Sub directedGraphRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles directedGraphRadioButton.CheckedChanged
			UpdateHighlights()
		End Sub

		Private Sub undirectedGraphRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles undirectedGraphRadioButton.CheckedChanged
			UpdateHighlights()
		End Sub

		Private Sub traversalMethodComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles traversalMethodComboBox.SelectedIndexChanged
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

		Friend highlightFillStyle As NColorFillStyle = Nothing
		Friend highlightStrokeStyle As NStrokeStyle = Nothing

		Private WithEvents graphPartCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents traversalMethodComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents undirectedGraphRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents directedGraphRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private selectedStrokeStyle As NStrokeStyle = Nothing

		#End Region
	End Class

	''' <summary>
	''' The NHighlightingVisitor class is used to highlight the visited graph parts 
	''' </summary>
	Public Class NHighlightingVisitor
		Inherits NGraphPartVisitor
		#Region "Constructors"

		''' <summary>
		''' 
		''' </summary>
		''' <param name="uc"></param>
		Public Sub New(ByVal uc As NGraphTraversalUC)
			userControl = uc
			vertexCounter = 0
		End Sub


		#End Region

		#Region "Overrides"

		''' <summary>
		''' Overriden to highlight the graph part
		''' </summary>
		''' <param name="part"></param>
		''' <returns>true if visiting must continue, otherwise false</returns>
		Public Overrides Function Visit(ByVal part As NGraphPart) As Boolean
			If TypeOf part Is NGraphVertex Then
				Dim shape As NShape = CType(objectMap.GetObjectFromPart(part), NShape)
				shape.Text = vertexCounter.ToString()
				shape.Style.FillStyle = CType(userControl.highlightFillStyle.Clone(), NFillStyle)
				shape.Style.StrokeStyle = CType(userControl.highlightStrokeStyle.Clone(), NStrokeStyle)
				vertexCounter += 1
			End If

			Return True
		End Function

		#End Region

		#Region "Fields"

		Private vertexCounter As Integer
		Private userControl As NGraphTraversalUC
		Friend objectMap As NObjectGraphPartMap

		#End Region
	End Class
End Namespace