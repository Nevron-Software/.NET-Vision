Imports Microsoft.VisualBasic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Layout
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Diagram.WinForm
	Public Class NGroupLayoutUC
		Inherits NDiagramExampleUC
		 #Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer generated code"

		Private Sub InitializeComponent()
			Me.btnLayoutGroupA = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnLayoutGroupB = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' btnLayoutGroupA
			' 
			Me.btnLayoutGroupA.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnLayoutGroupA.Location = New System.Drawing.Point(8, 15)
			Me.btnLayoutGroupA.Name = "btnLayoutGroupA"
			Me.btnLayoutGroupA.Size = New System.Drawing.Size(244, 23)
			Me.btnLayoutGroupA.TabIndex = 1
			Me.btnLayoutGroupA.Text = "Layout Group A"
			Me.btnLayoutGroupA.UseVisualStyleBackColor = True
'			Me.btnLayoutGroupA.Click += New System.EventHandler(Me.btnLayoutGroupA_Click);
			' 
			' btnLayoutGroupB
			' 
			Me.btnLayoutGroupB.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnLayoutGroupB.Location = New System.Drawing.Point(8, 44)
			Me.btnLayoutGroupB.Name = "btnLayoutGroupB"
			Me.btnLayoutGroupB.Size = New System.Drawing.Size(244, 23)
			Me.btnLayoutGroupB.TabIndex = 2
			Me.btnLayoutGroupB.Text = "Layout Group B"
			Me.btnLayoutGroupB.UseVisualStyleBackColor = True
'			Me.btnLayoutGroupB.Click += New System.EventHandler(Me.btnLayoutGroupB_Click);
			' 
			' NGroupLayoutUC
			' 
			Me.Controls.Add(Me.btnLayoutGroupA)
			Me.Controls.Add(Me.btnLayoutGroupB)
			Me.Name = "NGroupLayoutUC"
			Me.Controls.SetChildIndex(Me.btnLayoutGroupB, 0)
			Me.Controls.SetChildIndex(Me.btnLayoutGroupA, 0)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "Overrides NDiagramExampleUC"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init view
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			' create the groups
			Group1 = CreateGroup("A")
			Group2 = CreateGroup("B")

			' apply default styles
			Group1.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, 204, 0, 0))
			Group2.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, 0, 204, 0))

			' create the root shape
			Dim root As NShape = New NRectangleShape(0, 0, 40, 40)
			root.Name = "treeRoot"
			root.Text = "0"
			document.ActiveLayer.AddChild(root)
			CreateShapePorts(root)

			Dim connector As NRoutableConnector = New NRoutableConnector(RoutableConnectorType.DynamicPolyline)
			document.ActiveLayer.AddChild(connector)
			connector.Name = "leftEdge"
			connector.FromShape = root
			connector.ToShape = Group1

			connector = New NRoutableConnector(RoutableConnectorType.DynamicPolyline)
			connector.Name = "rightEdge"
			document.ActiveLayer.AddChild(connector)
			connector.FromShape = root
			connector.ToShape = Group2

			' do layout
			LayoutGroups()
			Group1.UpdateModelBounds()
			Group2.UpdateModelBounds()
		End Sub
		Private Sub CreateShapePorts(ByVal shape As NShape)
			shape.CreateShapeElements(ShapeElementsMask.Ports)

			' create a dynamic port anchored to the center of the shape
			Dim port As NDynamicPort = New NDynamicPort(New NContentAlignment(ContentAlignment.MiddleCenter), DynamicPortGlueMode.GlueToContour)
			port.Name = "port"
			shape.Ports.AddChild(port)
		End Sub
		Private Sub CreateTree(ByVal group As NGroup)
			Dim shape1 As NRectangleShape = New NRectangleShape(50, 0, 40, 40)
			Dim shape2 As NRectangleShape = New NRectangleShape(0, 0, 40, 40)
			Dim shape3 As NRectangleShape = New NRectangleShape(50, 50, 40, 40)
			Dim shape4 As NRectangleShape = New NRectangleShape(100, 0, 40, 40)
			shape1.Name = "root"

			CreateShapePorts(shape1)
			CreateShapePorts(shape2)
			CreateShapePorts(shape3)
			CreateShapePorts(shape4)

			group.Shapes.AddChild(shape1)
			group.Shapes.AddChild(shape2)
			group.Shapes.AddChild(shape3)
			group.Shapes.AddChild(shape4)

			shape1.Name = group.Name
			shape1.Text = shape1.Name

			shape2.Name = group.Name & "1"
			shape2.Text = shape2.Name

			shape3.Name = group.Name & "2"
			shape3.Text = shape3.Name

			shape4.Name = group.Name & "3"
			shape4.Text = shape4.Name

			Dim connector As NRoutableConnector = New NRoutableConnector(RoutableConnectorType.DynamicPolyline)
			group.Shapes.AddChild(connector)
			connector.FromShape = shape1
			connector.ToShape = shape2

			connector = New NRoutableConnector(RoutableConnectorType.DynamicPolyline)
			group.Shapes.AddChild(connector)
			connector.FromShape = shape1
			connector.ToShape = shape3

			connector = New NRoutableConnector(RoutableConnectorType.DynamicPolyline)
			group.Shapes.AddChild(connector)
			connector.FromShape = shape1
			connector.ToShape = shape4
		End Sub
		Private Function CreateGroup(ByVal name As String) As NGroup
			Dim group As NGroup = New NGroup()
			group.Name = name
			document.ActiveLayer.AddChild(group)
			CreateTree(group)
			CreateGroupPorts(group)
			group.UpdateModelBounds()

			Return group
		End Function
		Private Sub CreateGroupPorts(ByVal group As NGroup)
			group.CreateShapeElements(ShapeElementsMask.Ports)

			' create a dynamic port anchored to the center of the shape
			Dim port As NRotatedBoundsPort = New NRotatedBoundsPort(New NContentAlignment(ContentAlignment.TopCenter))
			port.Name = "port"
			group.Ports.AddChild(port)
		End Sub
		Private Sub LayoutGroups()
			Dim layout As NLayeredTreeLayout = New NLayeredTreeLayout()
			layout.PlugSpacing.Mode = PlugSpacingMode.None

			Dim shapes As NNodeList = New NNodeList()
			shapes.Add(document.ActiveLayer.GetChildByName("treeRoot"))
			shapes.Add(document.ActiveLayer.GetChildByName("leftEdge"))
			shapes.Add(document.ActiveLayer.GetChildByName("rightEdge"))
			shapes.Add(Group1)
			shapes.Add(Group2)

			layout.Layout(shapes, New NDrawingLayoutContext(document, shapes))
			Group1.UpdateModelBounds()
			Group2.UpdateModelBounds()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub btnLayoutGroupA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLayoutGroupA.Click
			Dim layout As NLayeredTreeLayout = New NLayeredTreeLayout()
			layout.PlugSpacing.Mode = PlugSpacingMode.None
			layout.Layout(Group1.Shapes.Children(Nothing), New NDrawingLayoutContext(document, Group1))
			Group1.UpdateModelBounds()
			LayoutGroups()
		End Sub
		Private Sub btnLayoutGroupB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLayoutGroupB.Click
			Dim layout As NLayeredTreeLayout = New NLayeredTreeLayout()
			layout.PlugSpacing.Mode = PlugSpacingMode.None
			layout.Layout(Group2.Shapes.Children(Nothing), New NDrawingLayoutContext(document, Group2))
			Group2.UpdateModelBounds()
			LayoutGroups()
		End Sub

		#End Region

		#Region "Designer Fields"

		Private WithEvents btnLayoutGroupA As NButton
		Private WithEvents btnLayoutGroupB As NButton

		#End Region

		#Region "Fields"

		Private Group1 As NGroup
		Private Group2 As NGroup

		#End Region
	End Class
End Namespace