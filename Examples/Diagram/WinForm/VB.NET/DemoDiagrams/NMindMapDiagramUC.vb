Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Dom
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NMindMapDiagramUC.
	''' </summary>
	Public Class NMindMapDiagramUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
			timer = New Timer()
			timer.Interval = 10
			AddHandler timer.Tick, AddressOf OnTimerTick
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
			' NSimpleStateDiagramUC
			' 
			Me.Name = "NSimpleStateDiagramUC"
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
			view.ViewLayout = ViewLayout.Normal
			view.DocumentPadding = New Nevron.Diagram.NMargins(10)

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub
		Protected Overrides Sub AttachToEvents()
			MyBase.AttachToEvents()
			AddHandler document.EventSinkService.NodePropertyChanged, AddressOf EventSinkService_NodePropertyChanged
		End Sub
		Protected Overrides Sub DetachFromEvents()
			MyBase.DetachFromEvents()
			RemoveHandler document.EventSinkService.NodePropertyChanged, AddressOf EventSinkService_NodePropertyChanged
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
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
			document.ActiveLayer.AddChild(group)

			' Create the ellipse shape
			Dim ellipseShape As NShape = New NEllipseShape(0, 0, 1, 1)
			group.Shapes.AddChild(ellipseShape)
			ellipseShape.Text = text
			ellipseShape.SizeToText(New NMarginsF(100, 18, 10, 18))
			ellipseShape.Location = New NPointF(0, 0)

			' Create the check shape
			Dim brainstormingFactory As NBrainstormingShapesFactory = New NBrainstormingShapesFactory(document)
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
			document.ActiveLayer.AddChild(group)

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
			document.ActiveLayer.AddChild(line)

			Dim fromPort As NPort = CType(from.Ports.GetChildByName("RightPort"), NPort)
			Dim toPort As NPort = CType([to].Ports.GetChildByName("LeftPort"), NPort)

			line.StartPlug.Connect(fromPort)
			line.EndPlug.Connect(toPort)

			Return line
		End Function
		Private Sub DoLayout()
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

		Private Sub EventSinkService_NodePropertyChanged(ByVal args As NNodePropertyEventArgs)
			If args.PropertyName = "Visible" AndAlso TypeOf args.Node Is NShape Then
				timer.Start()
				If view.LockRefresh = False Then
					view.LockRefresh = True
				End If
			End If
		End Sub
		Private Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
			timer.Stop()
			DoLayout()
			If view.LockRefresh Then
				view.LockRefresh = False
			End If
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private timer As Timer

		#End Region
	End Class
End Namespace