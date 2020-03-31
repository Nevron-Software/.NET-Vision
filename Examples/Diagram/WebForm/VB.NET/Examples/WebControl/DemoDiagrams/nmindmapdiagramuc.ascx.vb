Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Imports Nevron.Diagram
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Dom
Imports Nevron.Filters
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NMindMapDiagramUC.
	''' </summary>
	Public Partial Class NMindMapDiagramUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' begin view init
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			' begin view init
			NDrawingView1.ViewLayout = CanvasLayout.Normal
			NDrawingView1.ScaleX = 0.75f
			NDrawingView1.ScaleY = 0.75f

			' init document
			NDrawingView1.Document.BeginInit()
			InitDocument()
			NDrawingView1.Document.EndInit()
		End Sub

		#Region "Implementation"

		Private Sub InitDocument()
			Dim document As NDrawingDocument = NDrawingView1.Document

			document.GraphicsSettings.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			document.GraphicsSettings.SmoothingMode = SmoothingMode.HighQuality
			document.GraphicsSettings.PixelOffsetMode = PixelOffsetMode.HighQuality

			' set up visual formatting
			document.Style.FillStyle = New NColorFillStyle(Color.Linen)
			document.BackgroundStyle.FrameStyle.Visible = False

			' Create the shapes
			Dim startElement As NGroup = CreateStartElement("Alcohol Induced Persisting Dementia")
			Dim element1 As NGroup = CreateElement("Prevalence: 7% with ETOH Dependence")
			Dim element2 As NGroup = CreateElement("Presentation")
			Dim element3 As NGroup = CreateElement("Physical Etiology")

			Dim element21 As NGroup = CreateElement("Less likely to demonstrate aphasia")
			Dim element22 As NGroup = CreateElement("Visuospatial Deficits")
			Dim element23 As NGroup = CreateElement("Executive Dysfunction")
			Dim element24 As NGroup = CreateElement("Memory impairment")
			Dim element25 As NGroup = CreateElement("Similar to Dementia due to GMC")

			Dim element31 As NGroup = CreateElement("liver cirrhosis")
			Dim element32 As NGroup = CreateElement("Wernicke's Encephalopathy")
			Dim element33 As NGroup = CreateElement("Trauma (head trauma)")
			Dim element34 As NGroup = CreateElement("vitamin deficiency (Thiamine)")
			Dim element35 As NGroup = CreateElement("malnutrition")
			Dim element36 As NGroup = CreateElement("Frontal lobe atrophy")

			' Connect the shapes
			ConnectElements(startElement, element1)
			ConnectElements(startElement, element2)
			ConnectElements(startElement, element3)

			ConnectElements(element2, element21)
			ConnectElements(element2, element22)
			ConnectElements(element2, element23)
			ConnectElements(element2, element24)
			ConnectElements(element2, element25)
			AddShowHideSubtree(element2)

			ConnectElements(element3, element31)
			ConnectElements(element3, element32)
			ConnectElements(element3, element33)
			ConnectElements(element3, element34)
			ConnectElements(element3, element35)
			ConnectElements(element3, element36)
			AddShowHideSubtree(element3)

			' Layout the shapes
			DoLayout()
		End Sub

		Private Sub SetProtections(ByVal group As NGroup)
			' Set the protections of the group
			Dim protection As NAbilities = group.Protection
			protection.Ungroup = True
			group.Protection = protection

			' Get all shapes in the group
			Dim shapes As NNodeList = group.Shapes.Children(Nothing)

			' Set the protections of the shapes
			Dim i As Integer = 0
			Dim count As Integer = shapes.Count
			Do While i < count
				Dim shape As NShape = CType(shapes(i), NShape)
				protection = shape.Protection
				protection.Select = True
				protection.InplaceEdit = True
				shape.Protection = protection
				i += 1
			Loop
		End Sub
		Private Sub CreatePorts(ByVal group As NGroup, ByVal anchorShape As NShape)
			group.CreateShapeElements(ShapeElementsMask.Ports)
			Dim leftPort As NDynamicPort = New NDynamicPort(New NContentAlignment(ContentAlignment.MiddleLeft), DynamicPortGlueMode.GlueToLocation)
			leftPort.AnchorUniqueId = anchorShape.UniqueId
			leftPort.Name = "LeftPort"
			group.Ports.AddChild(leftPort)

			group.CreateShapeElements(ShapeElementsMask.Ports)
			Dim rightPort As NDynamicPort = New NDynamicPort(New NContentAlignment(ContentAlignment.MiddleRight), DynamicPortGlueMode.GlueToLocation)
			rightPort.AnchorUniqueId = anchorShape.UniqueId
			rightPort.Name = "RightPort"
			group.Ports.AddChild(rightPort)
		End Sub

		Private Function CreateStartElement(ByVal text As String) As NGroup
			Dim group As NGroup = New NGroup()
			NDrawingView1.Document.ActiveLayer.AddChild(group)

			' Create the ellipse shape
			Dim ellipseShape As NShape = New NEllipseShape(0, 0, 1, 1)
			group.Shapes.AddChild(ellipseShape)
			ellipseShape.Text = text
			ellipseShape.SizeToText(New NMarginsF(100, 18, 10, 18))
			ellipseShape.Location = New NPointF(0, 0)

			' Create the check shape
			Dim brainstormingFactory As NBrainstormingShapesFactory = New NBrainstormingShapesFactory(NDrawingView1.Document)
			Dim checkShape As NShape = brainstormingFactory.CreateShape(BrainstormingShapes.Check)
			checkShape.Bounds = New NRectangleF(26, 12, 24, 23)
			group.Shapes.AddChild(checkShape)

			' Create the ports
			CreatePorts(group, ellipseShape)

			' Set the protections
			SetProtections(group)
			group.UpdateModelBounds()

			Return group
		End Function
		Private Function CreateElement(ByVal text As String) As NGroup
			Dim group As NGroup = New NGroup()
			NDrawingView1.Document.ActiveLayer.AddChild(group)

			' Create the text shape
			Dim textShape As NTextShape = New NTextShape(text, 0, 0, 1, 1)
			group.Shapes.AddChild(textShape)
			textShape.SizeToText(New NMarginsF(10, 2, 10, 2))

			' Create the line shape under the text
			Dim rect As NRectangleF = textShape.Bounds
			Dim lineShape As NLineShape = New NLineShape(rect.X, rect.Bottom, rect.Right, rect.Bottom)
			group.Shapes.AddChild(lineShape)

			' Create the ports
			CreatePorts(group, lineShape)

			' Set the protections
			SetProtections(group)
			group.UpdateModelBounds()

			Return group
		End Function
		Private Sub AddShowHideSubtree(ByVal group As NGroup)
			group.CreateShapeElements(ShapeElementsMask.Decorators)
			Dim decorator As NShowHideSubtreeDecorator = New NShowHideSubtreeDecorator()
			decorator.Offset = New NSizeF(group.Width - decorator.Size.Width / 2, -group.Height / 2)
			decorator.Background.Shape = ToggleDecoratorBackgroundShape.Ellipse
			group.Decorators.AddChild(decorator)
		End Sub

		Private Function ConnectElements(ByVal from As NGroup, ByVal [to] As NGroup) As NRoutableConnector
			Dim line As NRoutableConnector = New NRoutableConnector()
			NDrawingView1.Document.ActiveLayer.AddChild(line)

			Dim fromPort As NPort = CType(from.Ports.GetChildByName("RightPort"), NPort)
			Dim toPort As NPort = CType([to].Ports.GetChildByName("LeftPort"), NPort)

			line.StartPlug.Connect(fromPort)
			line.EndPlug.Connect(toPort)

			Return line
		End Function
		Private Sub DoLayout()
			Dim document As NDrawingDocument = NDrawingView1.Document

			Dim context As NLayoutContext = New NLayoutContext()
			context.GraphAdapter = New NShapeGraphAdapter(True)
			context.BodyAdapter = New NShapeBodyAdapter(document)
			context.BodyContainerAdapter = New NDrawingBodyContainerAdapter(document)

			Dim layout As NLayeredGraphLayout = New NLayeredGraphLayout()
			layout.Direction = LayoutDirection.LeftToRight
			layout.EdgeRouting = LayeredLayoutEdgeRouting.Polyline
			layout.PlugSpacing.Mode = PlugSpacingMode.None

			Dim shapesToLayout As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)
			layout.Layout(shapesToLayout, context)

			' size to visible shapes
			document.SizeToContent(document.AutoBoundsMinSize, document.AutoBoundsPadding, NFilters.Visible)
		End Sub

		#End Region

		#Region "Event Handlers"

		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			NDrawingView1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True))
		End Sub
		Protected Sub NDrawingView1_AsyncClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)

			Dim nodes As NNodeList = NDrawingView1.HitTest(args)
			Dim decorators As NNodeList = nodes.Filter(DECORATOR_FILTER)
			If decorators.Count > 0 Then
				CType(decorators(0), NShowHideSubtreeDecorator).ToggleState()
				DoLayout()
			End If
		End Sub

		#End Region

		#Region "Static"

		Private Shared ReadOnly GROUP_FILTER As NFilter = New NInstanceOfTypeFilter(GetType(NGroup))
		Private Shared ReadOnly DECORATOR_FILTER As NFilter = New NInstanceOfTypeFilter(GetType(NShowHideSubtreeDecorator))

		#End Region
	End Class
End Namespace