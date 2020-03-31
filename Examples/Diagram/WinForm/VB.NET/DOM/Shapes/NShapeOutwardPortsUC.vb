Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.Editors
Imports Nevron.Filters
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NShapeOutwardPortsUC.
	''' </summary>
	Public Class NShapeOutwardPortsUC
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
			' NShapeOutwardPortsUC
			' 
			Me.Name = "NShapeOutwardPortsUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(70, 70)
			MyBase.DefaultGridSpacing = New NSizeF(50, 10)

			' begin view init
			view.BeginInit()

			' init view
			view.Grid.Visible = False

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
			' change the document style
			Dim style As NStyle = document.Style
			style.FillStyle = New NColorFillStyle(Color.FromArgb(50, &H66, &H66, 0))
			style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(&H11, &H11, 0))
			style.TextStyle.FontStyle = New NFontStyle(New Font("Arial", 9))
			style.TextStyle.FillStyle = New NColorFillStyle(Color.FromArgb(&H2a, &H20, &H00))
			style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			style.StartArrowheadStyle.StrokeStyle = TryCast(document.Style.StrokeStyle.Clone(), NStrokeStyle)
			style.EndArrowheadStyle.StrokeStyle = TryCast(document.Style.StrokeStyle.Clone(), NStrokeStyle)

			' create the shapes
			CreateMoveMeShape()
			CreateShapeWithAutoSideDirection()
			CreateShapeWithAutoCenterDirection()
			CreateShapeWithCustomDirection()
			CreateShapeWithAutoNextPort()
			CreateShapeWithAutoPrevPort()
			CreateShapeWithAutoLinePort()
		End Sub

		Private Sub CreateMoveMeShape()
			' create the center shape to which all other shapes connect
			Dim cell As NRectangleF = MyBase.GetGridCell(3, 0)
			cell.Inflate(-5, -5)

			Dim shape As NRectangleShape = New NRectangleShape(cell)
			shape.Name = "Move Me"
			shape.Text = "Move Me Close to Another Shape"

			shape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(247, 150, 56))
			shape.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			' create an outward port
			shape.CreateShapeElements(ShapeElementsMask.Ports)
			Dim port As NRotatedBoundsPort = New NRotatedBoundsPort(shape.UniqueId, ContentAlignment.TopCenter)
			port.Type = PortType.Outward
			shape.Ports.AddChild(port)
			shape.Ports.DefaultOutwardPortUniqueId = port.UniqueId

			' add it to the active layer and store for reuse
			document.ActiveLayer.AddChild(shape)
			centerShape = shape
		End Sub

		Private Sub CreateShapeWithAutoSideDirection()
			Dim shape As NRectangleShape = New NRectangleShape(MyBase.GetGridCell(0, 1))
			shape.Name = "Port with Auto Side direction"
			shape.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			shape.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			shape.CreateShapeElements(ShapeElementsMask.Ports)
			Dim port As NRotatedBoundsPort = New NRotatedBoundsPort(New NContentAlignment(50, 30))
			port.DirectionMode = BoundsPortDirectionMode.AutoSide
			shape.Ports.AddChild(port)

			document.ActiveLayer.AddChild(shape)

			' describe it
			Dim text As NTextShape = New NTextShape("Port with Auto Side direction", MyBase.GetGridCell(0, 2, 0, 1))
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateShapeWithAutoCenterDirection()
			Dim shape As NRectangleShape = New NRectangleShape(MyBase.GetGridCell(1, 1))
			shape.Name = "Port with Auto Center direction"
			shape.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			shape.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			shape.CreateShapeElements(ShapeElementsMask.Ports)
			Dim port As NRotatedBoundsPort = New NRotatedBoundsPort(New NContentAlignment(50, 30))
			port.DirectionMode = BoundsPortDirectionMode.AutoCenter
			shape.Ports.AddChild(port)

			document.ActiveLayer.AddChild(shape)

			' describe it
			Dim text As NTextShape = New NTextShape("Port with Auto Center direction", MyBase.GetGridCell(1, 2, 0, 1))
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateShapeWithCustomDirection()
			Dim shape As NRectangleShape = New NRectangleShape(MyBase.GetGridCell(2, 1))
			shape.Name = "Port with Custom direction"
			shape.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			shape.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			shape.CreateShapeElements(ShapeElementsMask.Ports)
			Dim port As NRotatedBoundsPort = New NRotatedBoundsPort(New NContentAlignment(50, 30))
			port.DirectionMode = BoundsPortDirectionMode.Custom
			port.CustomDirectionAngle = -30
			shape.Ports.AddChild(port)

			document.ActiveLayer.AddChild(shape)

			' describe it
			Dim text As NTextShape = New NTextShape("Port with Custom direction", MyBase.GetGridCell(2, 2, 0, 1))
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateShapeWithAutoNextPort()
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(BasicShapes.Triangle)))
			shape.Name = "Point Port with AutoNext direction"
			shape.Bounds = MyBase.GetGridCell(3, 1)
			shape.Style.FillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant4, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			shape.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			Dim port As NPointPort = New NPointPort(shape.UniqueId, PointIndexMode.Second, -1)
			port.DirectionMode = PointPortDirectionMode.AutoNext
			shape.Ports.RemoveAllChildren()
			shape.Ports.AddChild(port)

			document.ActiveLayer.AddChild(shape)

			' describe it
			Dim text As NTextShape = New NTextShape("Point Port with AutoNext direction", MyBase.GetGridCell(3, 2, 0, 1))
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateShapeWithAutoPrevPort()
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(BasicShapes.Triangle)))
			shape.Name = "Point Port with AutoPrev direction"
			shape.Bounds = MyBase.GetGridCell(4, 1)
			shape.Style.FillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant4, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			shape.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			Dim port As NPointPort = New NPointPort(shape.UniqueId, PointIndexMode.Second, -1)
			port.DirectionMode = PointPortDirectionMode.AutoPrev
			shape.Ports.RemoveAllChildren()
			shape.Ports.AddChild(port)

			document.ActiveLayer.AddChild(shape)

			' describe it
			Dim text As NTextShape = New NTextShape("Point Port with AutoPrev direction", MyBase.GetGridCell(4, 2, 0, 1))
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateShapeWithAutoLinePort()
			Dim shape As NBezierCurveShape = New NBezierCurveShape(New NPointF(0, 0), New NPointF(1, 0), New NPointF(1, 2), New NPointF(2, 2))
			shape.Name = "Line Port with AutoLine direction"
			shape.Bounds = MyBase.GetGridCell(5, 1)
			shape.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			shape.CreateShapeElements(ShapeElementsMask.Ports)
			Dim port As NLogicalLinePort = New NLogicalLinePort(shape.UniqueId, 50)
			port.DirectionMode = LogicalLinePortDirectionMode.AutoLine
			shape.Ports.AddChild(port)

			document.ActiveLayer.AddChild(shape)

			' describe it
			Dim text As NTextShape = New NTextShape("Line Port with AutoLine direction", MyBase.GetGridCell(5, 2, 0, 1))
			document.ActiveLayer.AddChild(text)
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region

		#Region "Fields"

		Private centerShape As NShape = Nothing

		#End Region
	End Class
End Namespace