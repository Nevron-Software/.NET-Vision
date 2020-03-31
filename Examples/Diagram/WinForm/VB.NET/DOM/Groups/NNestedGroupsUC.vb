Imports Microsoft.VisualBasic
Imports System
Imports Nevron.Diagram
Imports Nevron.Filters
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	Public Class NNestedGroupsUC
		Inherits NDiagramExampleUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			view.Grid.Visible = False
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False
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
			' Create the A group
			Dim groupA As NGroup = CreateGroup("A")
			groupA.Location = New NPointF(10, 10)
			document.ActiveLayer.AddChild(groupA)

			' Create the B group
			Dim groupB As NGroup = CreateGroup("B")
			groupB.Location = New NPointF(10, 350)
			document.ActiveLayer.AddChild(groupB)

			' Connect some shapes
			Dim subgroupA1 As NGroup = CType(groupA.Shapes.GetChildAt(0), NGroup)
			Dim shapeA1a As NShape = CType(subgroupA1.Shapes.GetChildAt(0), NShape)
			Dim subgroupA2 As NGroup = CType(groupA.Shapes.GetChildAt(1), NGroup)
			Dim shapeA2a As NShape = CType(subgroupA2.Shapes.GetChildAt(0), NShape)
			Connect(shapeA1a, shapeA2a)

			Dim subgroupB2 As NGroup = CType(groupB.Shapes.GetChildAt(1), NGroup)
			Dim shapeB2a As NShape = CType(subgroupB2.Shapes.GetChildAt(0), NShape)
			Connect(shapeA2a, shapeB2a)
		End Sub

		Private Function CreateGroup(ByVal name As String) As NGroup
			Dim group As NGroup = New NGroup()
			group.Name = name

			' Create 2 subgroups
			Dim subGroup1 As NGroup = CreateSubgroup(name & "1")
			subGroup1.Location = New NPointF(20, 0)
			group.Shapes.AddChild(subGroup1)

			Dim subGroup2 As NGroup = CreateSubgroup(name & "2")
			subGroup2.Location = New NPointF(260, 0)
			group.Shapes.AddChild(subGroup2)

			' Create the decorators
			CreateDecorators(group, group.Name & " Group")

			' Update the model bounds so that the subgroups are inside the specified padding
			group.Padding = New Nevron.Diagram.NMargins(5, 5, 30, 5)
			group.UpdateModelBounds()
			group.AutoUpdateModelBounds = True

			ApplyProtections(group, True, False)
			Return group
		End Function
		Private Function CreateSubgroup(ByVal name As String) As NGroup
			Dim subgroup As NGroup = New NGroup()
			subgroup.Name = name

			' Create 2 shapes
			Dim shape1 As NShape = CreateShape(name & "a")
			shape1.Location = New NPointF(0, 0)
			subgroup.Shapes.AddChild(shape1)

			Dim shape2 As NShape = CreateShape(name & "b")
			shape2.Location = New NPointF(110, 110)
			subgroup.Shapes.AddChild(shape2)

			' Create the decorators
			CreateDecorators(subgroup, subgroup.Name & " Subgroup")

			' Update the model bounds so that the shapes are inside the specified padding
			subgroup.Padding = New Nevron.Diagram.NMargins(5, 5, 30, 5)
			subgroup.UpdateModelBounds()

			ApplyProtections(subgroup, True, True)
			Return subgroup
		End Function
		Private Function CreateShape(ByVal name As String) As NShape
			Dim shape As NShape = New NRectangleShape(0, 0, 100, 100)
			shape.Name = name
			shape.Text = name & " Node"

			' Create a center port
			shape.CreateShapeElements(ShapeElementsMask.Ports)
			Dim port As NDynamicPort = New NDynamicPort(New NContentAlignment(0, 0), DynamicPortGlueMode.GlueToContour)
			shape.Ports.AddChild(port)

			ApplyProtections(shape, True, True)
			Return shape
		End Function
		Private Sub CreateDecorators(ByVal shape As NShape, ByVal decoratorText As String)
			' Create the decorators
			shape.CreateShapeElements(ShapeElementsMask.Decorators)

			' Create a frame decorator
			' We want the user to be able to select the shape when the frame is hit
			Dim frameDecorator As NFrameDecorator = New NFrameDecorator()
			frameDecorator.ShapeHitTestable = True
			frameDecorator.Header.Margins = New Nevron.Diagram.NMargins(20, 0, 0, 0)
			frameDecorator.Header.Text = decoratorText
			shape.Decorators.AddChild(frameDecorator)

			' Create an expand/collapse decorator
			Dim decorator As NExpandCollapseDecorator = New NExpandCollapseDecorator()
			shape.Decorators.AddChild(decorator)
		End Sub
		Private Sub Connect(ByVal shape1 As NShape, ByVal shape2 As NShape)
			Dim line As NLineShape = New NLineShape()
			document.ActiveLayer.AddChild(line)
			line.StyleSheetName = "Connectors"
			line.FromShape = shape1
			line.ToShape = shape2
		End Sub

		Private Sub ApplyProtections(ByVal shape As NShape, ByVal trackersEdit As Boolean, ByVal move As Boolean)
			Dim protection As NAbilities = shape.Protection
			protection.TrackersEdit = trackersEdit
			protection.MoveX = move
			protection.MoveY = move
			shape.Protection = protection
		End Sub

		#End Region

		#Region "Constants"

		Private Shared ReadOnly ExpandCollapseDecoratorFilter As NFilter = New NInstanceOfTypeFilter(GetType(NExpandCollapseDecorator))

		#End Region
	End Class
End Namespace