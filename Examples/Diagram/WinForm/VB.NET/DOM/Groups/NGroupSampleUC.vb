Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.WinForm.Commands

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NGroupSampleUC.
	''' </summary>
	Public Class NGroupSampleUC
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
			' 
			' NGroupSampleUC
			' 
			Me.Name = "NGroupSampleUC"
			Me.Size = New System.Drawing.Size(248, 456)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			m_NodeSize = New NSizeF(25, 25)
			m_Layout = New NSpringLayout()

			' begin view init
			view.BeginInit()

			view.Grid.Visible = False
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False

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
			' create networks
			Dim network1 As NGroup = CreateNetwork(New NPointF(200, 20), "Network 1")
			Dim network2 As NGroup = CreateNetwork(New NPointF(400, 250), "Network 2")
			Dim network3 As NGroup = CreateNetwork(New NPointF(20, 250), "Network 3")
			Dim network4 As NGroup = CreateNetwork(New NPointF(200, 400), "Network 4")

			' connect networks
			ConnectNetworks(network1, network2)
			ConnectNetworks(network1, network3)
			ConnectNetworks(network1, network4)
		End Sub

		Protected Function CreateNetwork(ByVal location As NPointF, ByVal labelText As String) As NGroup
			Dim group As NGroup = New NGroup()
			document.ActiveLayer.AddChild(group)

			' create computer1
			Dim computer1 As NCompositeShape = CreateComputer()
			computer1.Location = New NPointF(0, 0)
			group.Shapes.AddChild(computer1)

			' create computer2
			Dim computer2 As NCompositeShape = CreateComputer()
			computer2.Location = New NPointF(200, 0)
			group.Shapes.AddChild(computer2)

			' create computer3
			Dim computer3 As NCompositeShape = CreateComputer()
			computer3.Location = New NPointF(100, 180)
			group.Shapes.AddChild(computer3)

			' connect the computers in the network
			ConnectComputers(computer1, computer2, group)
			ConnectComputers(computer2, computer3, group)
			ConnectComputers(computer3, computer1, group)

			' update the group model bounds
			group.UpdateModelBounds()

			' insert a frame
			Dim frame As NRectangleShape = New NRectangleShape(group.ModelBounds)
			frame.Protection = New NAbilities(AbilitiesMask.Select Or AbilitiesMask.InplaceEdit)
			group.Shapes.InsertChild(0, frame)

			' change group fill style
			group.Style.FillStyle = New NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant2, Color.Gainsboro, Color.White)

			' reposition and resize the group
			group.Location = location
			group.Width = 155
			group.Height = 155

			' add a dynamic port to the group
			group.CreateShapeElements(ShapeElementsMask.Ports)

			Dim port As NDynamicPort = New NDynamicPort(group.UniqueId, ContentAlignment.MiddleCenter, DynamicPortGlueMode.GlueToContour)
			group.Ports.AddChild(port)
			group.Ports.DefaultInwardPortUniqueId = port.UniqueId

			' modify the margins and text of the default label
			group.CreateShapeElements(ShapeElementsMask.Labels)

			Dim label As NRotatedBoundsLabel = New NRotatedBoundsLabel(labelText, group.UniqueId, New Nevron.Diagram.NMargins(0, 0, -10, 100))
			group.Labels.AddChild(label)
			group.Labels.DefaultLabelUniqueId = label.UniqueId

			Return group
		End Function

		Protected Function CreateComputer() As NCompositeShape
			Dim computer As NCompositeShape = New NCompositeShape()

			' create the frame
			Dim frame As NEllipsePath = New NEllipsePath(-28, -28, 140, 140)
			NStyle.SetFillStyle(frame, New NColorFillStyle(Color.WhiteSmoke))
			computer.Primitives.AddChild(frame)

			' create display 1
			computer.Primitives.AddChild(New NRectanglePath(0, 0, 57, 47))

			' create display 2
			computer.Primitives.AddChild(New NRectanglePath(6, 4, 47, 39))

			' create the keyboard
			computer.Primitives.AddChild(New NRectanglePath(-21, 53, 60, 14))

			' create the tower case
			computer.Primitives.AddChild(New NRectanglePath(65, 0, 32, 66))

			' create floppy 1
			computer.Primitives.AddChild(New NRectanglePath(70, 5, 20, 3.75f))

			' create floppy 2
			computer.Primitives.AddChild(New NRectanglePath(70, 15, 20, 3.75f))

			' create floppy 3
			computer.Primitives.AddChild(New NRectanglePath(70, 25, 20, 3.75f))

			' create the mouse tail
			computer.Primitives.AddChild(New NBezierCurvePath(New NPointF(38, 82), New NPointF(61, 74), New NPointF(27, 57), New NPointF(63, 54)))

			' create the mouse
			Dim mouse As NEllipsePath = New NEllipsePath(26, 79, 11, 19)
			mouse.Rotate(CoordinateSystem.Scene, 42, New NPointF(36.5f, 88.5f))
			computer.Primitives.AddChild(mouse)

			' update the model bounds to fit the primitives
			computer.UpdateModelBounds()

			' the default fill style is dold
			computer.Style.FillStyle = New NColorFillStyle(Color.Gold)

			' create the computer ports
			computer.CreateShapeElements(ShapeElementsMask.Ports)

			' create a dynamic port anchored to the center of the frame
			Dim port As NDynamicPort = New NDynamicPort(frame.UniqueId, ContentAlignment.MiddleCenter, DynamicPortGlueMode.GlueToContour)
			port.Name = "port"

			' make the new port the one and default port of the computer
			computer.Ports.RemoveAllChildren()
			computer.Ports.AddChild(port)
			computer.Ports.DefaultInwardPortUniqueId = port.UniqueId

			Return computer
		End Function


		Private Sub ConnectNetworks(ByVal fromNetwork As NGroup, ByVal toNetwork As NGroup)
			Dim line As NLineShape = New NLineShape()
			document.ActiveLayer.AddChild(line)

			line.FromShape = fromNetwork
			line.ToShape = toNetwork
		End Sub

		Private Sub ConnectComputers(ByVal fromComputer As NShape, ByVal toComputer As NShape, ByVal group As NGroup)
			Dim line As NLineShape = New NLineShape()
			group.Shapes.AddChild(line)

			line.FromShape = fromComputer
			line.ToShape = toComputer
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region

		#Region "Fields"

		Private m_NodeSize As NSizeF
		Private m_Layout As NForceDirectedLayout

		#End Region
	End Class
End Namespace
