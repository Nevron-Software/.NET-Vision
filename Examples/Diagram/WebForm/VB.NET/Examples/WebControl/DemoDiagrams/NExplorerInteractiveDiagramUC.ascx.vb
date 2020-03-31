Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Nevron.Dom
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WebForm

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NExplorerInteractiveDiagramUC.
	''' </summary>
	Public Partial Class NExplorerInteractiveDiagramUC
		Inherits NDiagramExampleUC
		''' <summary>
		''' The NExpandCollapseCheck class is a composite shape which displays a framed plus or minus sign
		''' </summary>
		<Serializable> _
		Public Class NExpandCollapseCheck
			Inherits NCompositeShape
			#Region "Constructors"

			Public Sub New()
				' base
				Primitives.AddChild(New NRectanglePath(-1, -1, 2, 2))

				' plus
				Dim path As GraphicsPath = New GraphicsPath()
				path.AddLine(New PointF(-0.5f, 0), New PointF(0.5f, 0))
				path.StartFigure()
				path.AddLine(New PointF(0, 0.5f), New PointF(0, -0.5f))

				Dim customPath As NCustomPath = New NCustomPath(path, PathType.OpenFigure)
				customPath.Visible = False

				Primitives.AddChild(customPath)

				' minus
				Dim linePath As NLinePath = New NLinePath(-0.5f, 0, 0.5f, 0)

				Primitives.AddChild(linePath)

				' update the model bounds to fit the primitives
				UpdateModelBounds()

				' destory all optional shape elements
				DestroyShapeElements(ShapeElementsMask.All)

				' add interactivity
				Style.InteractivityStyle = New NInteractivityStyle(True, String.Empty, "Click to expand/collapse subtree", CursorType.Hand)
				linePath.Style = linePath.ComposeStyle()
				linePath.Style.InteractivityStyle = New NInteractivityStyle(True, String.Empty, "Click to expand/collapse subtree", CursorType.Hand)
				customPath.Style = customPath.ComposeStyle()
				customPath.Style.InteractivityStyle = New NInteractivityStyle(True, String.Empty, "Click to expand/collapse subtree", CursorType.Hand)
			End Sub

			#End Region
		End Class

		''' <summary>
		''' The NExpandableShape class is a group, which contains a frame rectangle shape and an expand-collapse check shape
		''' </summary>
		<Serializable> _
		Public Class NExpandableShape
			Inherits NGroup
			#Region "Constructors"

			Public Sub New()
				' add a rectangle shape as base
				Dim rect As NRectangleShape = New NRectangleShape(New NRectangleF(0, 0, 75, 75))
				rect.DestroyShapeElements(ShapeElementsMask.All)
				rect.Protection = New NAbilities(AbilitiesMask.Select Or AbilitiesMask.InplaceEdit)
				Shapes.AddChild(rect)

				' add an expand collapse shape
				Dim check As NExpandCollapseCheck = New NExpandCollapseCheck()
				check.Bounds = New NRectangleF(80, 0, 12, 12)
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
			''' <param name="expandShape"></param>
			Public Sub Expand(ByVal expandShape As Boolean)
				' expand or collapse in a single transation
				If expandShape Then
					StartTransaction("Expand Tree")
				Else
					StartTransaction("Collapse Tree")
				End If

				' mark shape as expanded
				Expanded = expandShape

				' show/hide the plus or minus 
				Dim check As NExpandCollapseCheck = GetExpandCollapseCheck()

				Dim pathPrimitive As NPathPrimitive
				pathPrimitive = TryCast(check.Primitives.GetChildAt(1), NPathPrimitive)
				pathPrimitive.Visible = Not expandShape

				pathPrimitive = TryCast(check.Primitives.GetChildAt(2), NPathPrimitive)
				pathPrimitive.Visible = expandShape

				' show/hide all outgoing shapes
				Dim nodes As NNodeList = GetOutgoingShapes()
				Dim i As Integer = 0
				Do While i < nodes.Count
					Dim shape As NShape = (TryCast(nodes(i), NShape))
					shape.Visible = expandShape
					i += 1
				Loop

				' show/hide all destination shapes
				nodes = GetDestinationShapes()
				i = 0
				Do While i < nodes.Count
					Dim shape As NShape = (TryCast(nodes(i), NShape))
					shape.Visible = expandShape
					i += 1
				Loop

				' expand/collapse the destination shapes
				i = 0
				Do While i < nodes.Count
					Dim expandableShape As NExpandableShape = (TryCast(nodes(i), NExpandableShape))
					If Not expandableShape Is Nothing Then
						expandableShape.Expand(expandShape)
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
			Public Function GetExpandCollapseCheck() As NExpandCollapseCheck
				Return (TryCast(Shapes.GetChildAt(1), NExpandCollapseCheck))
			End Function

			#End Region

			#Region "Fields"

			Private m_bExpanded As Boolean

			#End Region
		End Class


		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NDrawingView1.RequiresInitialization Then
				MyBase.DefaultGridOrigin = New NPointF(30, 30)
				MyBase.DefaultGridCellSize = New NSizeF(100, 50)
				MyBase.DefaultGridSpacing = New NSizeF(50, 40)

				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Fit

				If (Not IsPostBack) Then
					' init document
					NDrawingView1.Document.BeginInit()
					InitDocument()
					NDrawingView1.Document.EndInit()
				End If
			End If
		End Sub

		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			NDrawingView1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True, True))
			NDrawingView1.AjaxTools.Add(New NAjaxTooltipTool(True))
			NDrawingView1.AjaxTools.Add(New NAjaxDynamicCursorTool(True))
		End Sub

		Protected Sub NDrawingView1_AsyncClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)

			Dim nodes As NNodeList = NDrawingView1.HitTest(args)
			Dim shapes As NNodeList = nodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)
			Dim check As NExpandCollapseCheck = Nothing
			Dim length As Integer = shapes.Count
			Dim i As Integer = 0
			Do While i < length
				If TypeOf shapes(i) Is NExpandCollapseCheck Then
					check = TryCast(shapes(i), NExpandCollapseCheck)
					Exit Do
				End If
				i += 1
			Loop
			If check Is Nothing Then
				Return
			End If

			Dim shape As NExpandableShape = TryCast(check.ParentNode.ParentNode, NExpandableShape)
			shape.Expand((Not shape.Expanded))
		End Sub

		#Region "Implementation"

		Protected Sub InitDocument()
			NDrawingView1.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
			NDrawingView1.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed
			NDrawingView1.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality

			' set up visual formatting
			NDrawingView1.Document.Style.FillStyle = New NColorFillStyle(Color.Linen)

			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = False

			' all shapes will have shadow dropped below document content
			NDrawingView1.Document.Style.ShadowStyle.Type = ShadowType.GaussianBlur
			NDrawingView1.Document.Style.ShadowStyle.Offset = New NPointL(5, 5)
			NDrawingView1.Document.Style.ShadowStyle.FadeLength = New NLength(5)
			NDrawingView1.Document.ShadowsZOrder = ShadowsZOrder.BehindDocument

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
			layoutContext.BodyAdapter = New NShapeBodyAdapter(NDrawingView1.Document)
			layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(NDrawingView1.Document)
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
			NDrawingView1.Document.SizeToContent(New NSizeF(100, 100), New Nevron.Diagram.NMargins(20, 20, 100, 20))

			' add title spanning the entire document width
			Dim text As NTextShape = New NTextShape("Company Structure", New NRectangleF(5, -50, NDrawingView1.Document.Width - 5, 50))
			text.Style.TextStyle = New NTextStyle(New Font("Times New Roman", 23, FontStyle.Bold))
			text.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center
			NDrawingView1.Document.ActiveLayer.AddChild(text)
		End Sub

		Protected Function CreateVertex(ByVal text As String) As NExpandableShape
			Dim vertex As NExpandableShape = New NExpandableShape()
			vertex.Text = text
			NDrawingView1.Document.ActiveLayer.AddChild(vertex)
			Return vertex
		End Function

		Protected Sub ConnectShapes(ByVal fromShape As NExpandableShape, ByVal toShape As NExpandableShape)
			Dim connector As NLineShape = New NLineShape()
			connector.StyleSheetName = NDR.NameConnectorsStyleSheet

			NDrawingView1.Document.ActiveLayer.AddChild(connector)
			connector.FromShape = fromShape
			connector.ToShape = toShape
		End Sub

		#End Region
	End Class
End Namespace
