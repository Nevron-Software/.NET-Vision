Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' The NExpandCollapseCheck class is a composite shape which displays a framed plus or minus sign
	''' </summary>
	Public Class NExpandCollapseCheck
		Inherits NCompositeShape
		Public Sub New()
			' base
			Primitives.AddChild(New NRectanglePath(-1, -1, 2, 2))

			' plus
			Dim path As GraphicsPath = New GraphicsPath()
			path.AddLine(New PointF(-1, 0), New PointF(1, 0))
			path.StartFigure()
			path.AddLine(New PointF(0, 1), New PointF(0, -1))
			Primitives.AddChild(New NCustomPath(path, PathType.OpenFigure))

			' minus
			Primitives.AddChild(New NLinePath(-1, 0, 1, 0))

			' update the model bounds to fit the primitives
			UpdateModelBounds()

			' destory all optional shape elements
			DestroyShapeElements(ShapeElementsMask.All)

			' add tooltip
			Style.InteractivityStyle = New NInteractivityStyle("Click to expand/collapse subtree", CursorType.Hand)
		End Sub
	End Class
	''' <summary>
	''' The NExpandableShape class is a group, which contains a frame rectangle shape and an expand-collapse check shape
	''' </summary>
	Public Class NExpandableShape
		Inherits NGroup
		Public Sub New()
			' add a rectangle shape as base
			Dim rect As NRectangleShape = New NRectangleShape(New NRectangleF(0, 0, 100, 100))
			rect.DestroyShapeElements(ShapeElementsMask.All)
			rect.Protection = New NAbilities(AbilitiesMask.Select Or AbilitiesMask.InplaceEdit)
			Shapes.AddChild(rect)

			' add an expand collapse shape
			Dim check As NExpandCollapseCheck = New NExpandCollapseCheck()
			check.Bounds = New NRectangleF(105, 0, 10, 10)
			check.Protection = New NAbilities(AbilitiesMask.Select Or AbilitiesMask.InplaceEdit)
			check.ResizeInAggregate = ResizeInAggregate.RepositionOnly
			Shapes.AddChild(check)

			' update the model bounds with the rectangle bounds
			UpdateModelBounds(rect.Transform.TransformBounds(rect.ModelBounds))

			' initially it is expanded
			m_bExpanded = True

			' by default the group has one dynamic port anchored to the rectangle
			CreateShapeElements(ShapeElementsMask.Ports)
			Dim port As NDynamicPort = New NDynamicPort(rect.UniqueId, ContentAlignment.MiddleCenter, DynamicPortGlueMode.GlueToContour)

			Ports.AddChild(port)
			Ports.DefaultInwardPortUniqueId = port.UniqueId

			' by default the group has one rotated bounds port anchored to the rectangle
			CreateShapeElements(ShapeElementsMask.Labels)
			Dim label As NRotatedBoundsLabel = New NRotatedBoundsLabel("", rect.UniqueId, New Nevron.Diagram.NMargins(10))

			Labels.AddChild(label)
			Labels.DefaultLabelUniqueId = label.UniqueId
		End Sub

		#Region "Overrides"

		''' <summary>
		''' 
		''' </summary>
		''' <param name="e"></param>
		Public Overrides Sub OnMouseDown(ByVal e As NMouseEventArgs)
			' handle only the left mouse down single click on the check box
			If e.Button = MouseButtons.Left OrElse e.Clicks = 1 Then
				Dim check As NExpandCollapseCheck = GetExpandCollapseCheck()

				' check to see if the hit was on some of the check box children
				If NSceneTree.IsAncestorOfNode(check, e.HitNode) Then
					Expand((Not Expanded))

					' mark as processed and return (stops event bubbling)
					e.Processed = True
					Return
				End If
			End If

			' bubble event to previous mouse event handler
			MyBase.OnMouseDown(e)
		End Sub


		#End Region

		#Region "Properties"

		''' <summary>
		''' 
		''' </summary>
		Public Property Expanded() As Boolean
			Get
				Return m_bExpanded
			End Get
			Set
				If m_bExpanded = Value Then
					Return
				End If

				If OnPropertyChanging("Expanded", Value) = False Then
					Return
				End If

				RecordProperty("Expanded")
				m_bExpanded = Value

				OnPropertyChanged("Expanded")
			End Set
		End Property


		#End Region

		#Region "Methods"

		''' <summary>
		''' 
		''' </summary>
		''' <param name="expandState"></param>
		Public Sub Expand(ByVal expandState As Boolean)
			' expand or collapse in a single transation
			If expandState Then
				StartTransaction("Expand Tree")
			Else
				StartTransaction("Collapse Tree")
			End If

			' mark shape as expanded
			Expanded = expandState

			' show/hide the plus or minus 
			Dim check As NExpandCollapseCheck = GetExpandCollapseCheck()
			CType(check.Primitives.GetChildAt(1), NPathPrimitive).Visible = Not expandState
			CType(check.Primitives.GetChildAt(2), NPathPrimitive).Visible = expandState

			' show/hide all outgoing shapes
			Dim nodes As NNodeList = GetOutgoingShapes()
			Dim i As Integer = 0
			Do While i < nodes.Count
				Dim shape As NShape = (TryCast(nodes(i), NShape))
				shape.Visible = expandState
				i += 1
			Loop

			' show/hide all destination shapes
			nodes = GetDestinationShapes()
			i = 0
			Do While i < nodes.Count
				Dim shape As NShape = (TryCast(nodes(i), NShape))
				shape.Visible = expandState
				i += 1
			Loop

			' expand/collapse the destination shapes
			i = 0
			Do While i < nodes.Count
				Dim expandableShape As NExpandableShape = (TryCast(nodes(i), NExpandableShape))
				If Not expandableShape Is Nothing Then
					expandableShape.Expand(expandState)
				End If
				i += 1
			Loop

			' commit the transaction
			Commit()
		End Sub


		#End Region

		#Region "Protected"

		''' <summary>
		''' Gets the expand/collapse check from the geometry
		''' </summary>
		''' <returns></returns>
		Protected Function GetExpandCollapseCheck() As NExpandCollapseCheck
			Return (TryCast(Shapes.GetChildAt(1), NExpandCollapseCheck))
		End Function


		#End Region

		#Region "Fields"

		Private m_bExpanded As Boolean

		#End Region
	End Class
	''' <summary>
	''' Summary description for NExplorerInteractiveDiagramUC.
	''' </summary>
	Public Class NExplorerInteractiveDiagramUC
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
			Me.SuspendLayout()
			' 
			' commonControlsPanel
			' 
			Me.commonControlsPanel.Location = New System.Drawing.Point(0, 304)
			Me.commonControlsPanel.Name = "commonControlsPanel"
			Me.commonControlsPanel.Size = New System.Drawing.Size(248, 80)
			' 
			' NExplorerInteractiveDiagramUC
			' 
			Me.Name = "NExplorerInteractiveDiagramUC"
			Me.Size = New System.Drawing.Size(248, 384)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			view.GlobalVisibility.ShowPorts = False
			view.Grid.Visible = False
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' fit document in designer
			view.DocumentPadding = New Nevron.Diagram.NMargins(10)
			view.Fit()

			' end view init
			view.EndInit()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			' all shapes will have shadow dropped below document content
			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur
			document.Style.ShadowStyle.Offset = New NPointL(5, 5)
			document.Style.ShadowStyle.FadeLength = New NLength(5)
			document.ShadowsZOrder = ShadowsZOrder.BehindDocument

			' root 
			Dim company As NExpandableShape = CreateVertex("The Company")

			' products branch
			Dim products As NExpandableShape = CreateVertex("Products and Services")
			ConnectShapes(company, products)

			Dim product1 As NExpandableShape = Me.CreateVertex("Product1")
			ConnectShapes(products, product1)

			Dim product2 As NExpandableShape = Me.CreateVertex("Product2")
			ConnectShapes(products, product2)

			' how to reach
			Dim reach As NExpandableShape = CreateVertex("How to reach")
			ConnectShapes(company, reach)

			Dim phone As NExpandableShape = Me.CreateVertex("Phone")
			ConnectShapes(reach, phone)

			Dim fax As NExpandableShape = Me.CreateVertex("Fax")
			ConnectShapes(reach, fax)

			Dim website As NExpandableShape = Me.CreateVertex("Website")
			ConnectShapes(reach, website)

			' research
			Dim research As NExpandableShape = CreateVertex("Research")
			ConnectShapes(company, research)

			Dim tech As NExpandableShape = Me.CreateVertex("Techinical")
			ConnectShapes(research, tech)

			Dim marketing As NExpandableShape = Me.CreateVertex("Marketing")
			ConnectShapes(research, marketing)

			Dim newTech As NExpandableShape = Me.CreateVertex("New Tech")
			ConnectShapes(research, newTech)

			Dim nodes As NNodeList = New NNodeList()
			nodes.Add(company)

			' create a layout context
			Dim layoutContext As NLayoutContext = New NLayoutContext()
			layoutContext.BodyAdapter = New NShapeBodyAdapter(document)
			layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(document)
			layoutContext.GraphAdapter = New NShapeGraphAdapter()

			' first apply a layered tree layout 
			' to set a start position of the shapes as a simple tree
			Dim treeLayout As NTreeLayout = New NLayeredTreeLayout()
			treeLayout.Layout(nodes, layoutContext)

			' then apply a symmetrical layout to layout them in a ring fasion
			Dim symmetricalLayout As NSymmetricalLayout = New NSymmetricalLayout()
			symmetricalLayout.DesiredDistanceForce.DesiredDistance = 100
			symmetricalLayout.Layout(nodes, layoutContext)

			' size the document to the content (note that we use irregular margins)
			document.SizeToContent(New NSizeF(100, 100), New Nevron.Diagram.NMargins(20, 20, 50, 20))

			' add title spanning the entire document width
			Dim text As NTextShape = New NTextShape("Company Structure", New NRectangleF(document.Bounds.X + 5, document.Bounds.Y + 5, document.Width - 10, 50))
			text.Style.TextStyle = New NTextStyle(New Font("Times New Roman", 23, FontStyle.Bold))
			document.ActiveLayer.AddChild(text)
		End Sub

		Protected Function CreateVertex(ByVal text As String) As NExpandableShape
			Dim vertex As NExpandableShape = New NExpandableShape()
			vertex.Width = 75
			vertex.Height = 75
			vertex.Text = text
			document.ActiveLayer.AddChild(vertex)
			Return vertex
		End Function

		Private Sub ConnectShapes(ByVal fromShape As NExpandableShape, ByVal toShape As NExpandableShape)
			Dim connector As NLineShape = New NLineShape()
			connector.StyleSheetName = NDR.NameConnectorsStyleSheet

			document.ActiveLayer.AddChild(connector)
			connector.FromShape = fromShape
			connector.ToShape = toShape
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace