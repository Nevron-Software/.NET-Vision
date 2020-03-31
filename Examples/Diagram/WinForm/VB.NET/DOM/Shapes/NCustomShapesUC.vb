Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NSymbolsUC.
	''' </summary>
	Public Class NCustomShapesUC
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
			Me.addRandomGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.addShapeButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.addRandomGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' commonControlsPanel
			' 
			Me.commonControlsPanel.Name = "commonControlsPanel"
			Me.commonControlsPanel.Size = New System.Drawing.Size(250, 80)
			' 
			' addRandomGroupBox
			' 
			Me.addRandomGroupBox.Controls.Add(Me.addShapeButton)
			Me.addRandomGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.addRandomGroupBox.ImageIndex = 0
			Me.addRandomGroupBox.Location = New System.Drawing.Point(0, 0)
			Me.addRandomGroupBox.Name = "addRandomGroupBox"
			Me.addRandomGroupBox.Size = New System.Drawing.Size(250, 64)
			Me.addRandomGroupBox.TabIndex = 31
			Me.addRandomGroupBox.TabStop = False
			Me.addRandomGroupBox.Text = "Add custom shapes"
			' 
			' addShapeButton
			' 
			Me.addShapeButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.addShapeButton.Location = New System.Drawing.Point(16, 24)
			Me.addShapeButton.Name = "addShapeButton"
			Me.addShapeButton.Size = New System.Drawing.Size(224, 24)
			Me.addShapeButton.TabIndex = 20
			Me.addShapeButton.Text = "Add Coffee Cup"
'			Me.addShapeButton.Click += New System.EventHandler(Me.addShapeButton_Click);
			' 
			' NCustomShapesUC
			' 
			Me.Controls.Add(Me.addRandomGroupBox)
			Me.Name = "NCustomShapesUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.commonControlsPanel, 0)
			Me.Controls.SetChildIndex(Me.addRandomGroupBox, 0)
			Me.addRandomGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()
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
			document.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.BurlyWood, New NPointL(4, 4), 1, New NLength(2))

			document.ShadowsZOrder = ShadowsZOrder.BehindLayer

			Dim coffeeCup1 As NCompositeShape = CreateCoffeeCupShape(New NPointF(10, 10), 0.5f)
			Dim coffeeCup2 As NCompositeShape = CreateCoffeeCupShape(New NPointF(200, 10), 0.75f)
			Dim coffeeCup3 As NCompositeShape = CreateCoffeeCupShape(New NPointF(400, 10), 1f)

			document.ActiveLayer.AddChild(coffeeCup1)
			document.ActiveLayer.AddChild(coffeeCup2)
			document.ActiveLayer.AddChild(coffeeCup3)

			ConnectCoffeeCups(TryCast(coffeeCup1.Ports.GetChildAt(1), NPort), TryCast(coffeeCup2.Ports.GetChildAt(0), NPort))
			ConnectCoffeeCups(TryCast(coffeeCup2.Ports.GetChildAt(1), NPort), TryCast(coffeeCup3.Ports.GetChildAt(0), NPort))
		End Sub

		Protected Function CreateCoffeeCupShape(ByVal location As NPointF, ByVal scale As Single) As NCompositeShape
			Dim shape As NCompositeShape = New NCompositeShape()

			' create the cup as a polygon path
			Dim cup As NPolygonPath = New NPolygonPath(New NPointF(){ New NPointF(45, 268), New NPointF(63, 331), New NPointF(121, 331), New NPointF(140, 268)})
			shape.Primitives.AddChild(cup)

			' create the cup hangle as a closed curve path
			Dim handle As NClosedCurvePath = New NClosedCurvePath(New NPointF(){ New NPointF(175, 295), New NPointF(171, 278), New NPointF(140, 283), New NPointF(170, 290), New NPointF(128, 323)}, 1)
			NStyle.SetFillStyle(handle, New NColorFillStyle(Color.LightSalmon))
			shape.Primitives.AddChild(handle)

			' create the steam as a custom filled path
			Dim path As GraphicsPath = New GraphicsPath()
			path.AddBeziers(New PointF(){ New PointF(92, 258), New PointF(53, 163), New PointF(145, 160), New PointF(86, 50), New PointF(138, 194), New PointF(45, 145), New PointF(92, 258)})
			path.CloseAllFigures()

			Dim steam As NCustomPath = New NCustomPath(path, PathType.ClosedFigure)
			NStyle.SetFillStyle(steam, New NColorFillStyle(Color.FromArgb(50, 122, 122, 122)))
			shape.Primitives.AddChild(steam)

			' update the shape model bounds to fit the primitives it contains
			shape.UpdateModelBounds()

			' create the shape ports
			shape.CreateShapeElements(ShapeElementsMask.Ports)

			' create dynamic port anchored to the cup center
			Dim dynamicPort As NDynamicPort = New NDynamicPort(cup.UniqueId, ContentAlignment.MiddleCenter, DynamicPortGlueMode.GlueToContour)
			shape.Ports.AddChild(dynamicPort)

			' create rotated bounds port anchored to the middle right side of the handle
			Dim rotatedBoundsPort As NRotatedBoundsPort = New NRotatedBoundsPort(handle.UniqueId, ContentAlignment.MiddleRight)
			shape.Ports.AddChild(rotatedBoundsPort)

			' apply style to the shape
			shape.Style.FillStyle = New NColorFillStyle(Color.LightCoral)

			' position it and scale the shape
			shape.Location = location
			shape.Width = shape.Width * scale
			shape.Height = shape.Height * scale

			Return shape
		End Function

		Private Sub ConnectCoffeeCups(ByVal port1 As NPort, ByVal port2 As NPort)
			Dim line As NLineShape = New NLineShape()
			document.ActiveLayer.AddChild(line)

			line.StartPlug.Connect(port1)
			line.EndPlug.Connect(port2)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub addShapeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addShapeButton.Click
			' create a coffee cup with random location and scale
			Dim coffeeCup As NCompositeShape = CreateCoffeeCupShape(MyBase.GetRandomPoint(view.Viewport), CSng(Random.NextDouble()) + 0.1f)

			' add to active layer and smart refresh all views
			document.ActiveLayer.AddChild(coffeeCup)
			document.SmartRefreshAllViews()
		End Sub

		#End Region

		#Region "Designer Fields"

		Private addRandomGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents addShapeButton As Nevron.UI.WinForm.Controls.NButton

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
