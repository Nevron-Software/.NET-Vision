Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.Editors
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NPrimitive2DShapesUC.
	''' </summary>
	Public Class NPrimitive2DShapesUC
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
			Me.selectedShapeStylesGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.editStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.editFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.addRandomGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.pointsCountNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.randomRectButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.randomEllipseButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.randomPolygonButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.randomClosedCurveButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.documentStylesGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.editDocumentShadowStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.editDocumentStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.editDocumentFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.selectedShapeStylesGroup.SuspendLayout()
			Me.addRandomGroupBox.SuspendLayout()
			CType(Me.pointsCountNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.documentStylesGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' selectedShapeStylesGroup
			' 
			Me.selectedShapeStylesGroup.Controls.Add(Me.editStrokeStyleButton)
			Me.selectedShapeStylesGroup.Controls.Add(Me.editFillStyleButton)
			Me.selectedShapeStylesGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.selectedShapeStylesGroup.Enabled = False
			Me.selectedShapeStylesGroup.ImageIndex = 0
			Me.selectedShapeStylesGroup.Location = New System.Drawing.Point(0, 176)
			Me.selectedShapeStylesGroup.Name = "selectedShapeStylesGroup"
			Me.selectedShapeStylesGroup.Size = New System.Drawing.Size(250, 96)
			Me.selectedShapeStylesGroup.TabIndex = 34
			Me.selectedShapeStylesGroup.TabStop = False
			Me.selectedShapeStylesGroup.Text = "Selected Shape Styles"
			' 
			' editStrokeStyleButton
			' 
			Me.editStrokeStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editStrokeStyleButton.Location = New System.Drawing.Point(8, 24)
			Me.editStrokeStyleButton.Name = "editStrokeStyleButton"
			Me.editStrokeStyleButton.Size = New System.Drawing.Size(234, 23)
			Me.editStrokeStyleButton.TabIndex = 13
			Me.editStrokeStyleButton.Text = "Stroke Style ..."
'			Me.editStrokeStyleButton.Click += New System.EventHandler(Me.editStrokeStyleButton_Click);
			' 
			' editFillStyleButton
			' 
			Me.editFillStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editFillStyleButton.Location = New System.Drawing.Point(8, 56)
			Me.editFillStyleButton.Name = "editFillStyleButton"
			Me.editFillStyleButton.Size = New System.Drawing.Size(234, 23)
			Me.editFillStyleButton.TabIndex = 12
			Me.editFillStyleButton.Text = "Fill Style ..."
'			Me.editFillStyleButton.Click += New System.EventHandler(Me.editFillStyleButton_Click);
			' 
			' addRandomGroupBox
			' 
			Me.addRandomGroupBox.Controls.Add(Me.nGroupBox1)
			Me.addRandomGroupBox.Controls.Add(Me.label2)
			Me.addRandomGroupBox.Controls.Add(Me.pointsCountNumericUpDown)
			Me.addRandomGroupBox.Controls.Add(Me.randomRectButton)
			Me.addRandomGroupBox.Controls.Add(Me.randomEllipseButton)
			Me.addRandomGroupBox.Controls.Add(Me.randomPolygonButton)
			Me.addRandomGroupBox.Controls.Add(Me.randomClosedCurveButton)
			Me.addRandomGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.addRandomGroupBox.ImageIndex = 0
			Me.addRandomGroupBox.Location = New System.Drawing.Point(0, 0)
			Me.addRandomGroupBox.Name = "addRandomGroupBox"
			Me.addRandomGroupBox.Size = New System.Drawing.Size(250, 176)
			Me.addRandomGroupBox.TabIndex = 33
			Me.addRandomGroupBox.TabStop = False
			Me.addRandomGroupBox.Text = "Add Random 2D Shapes"
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 88)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(234, 8)
			Me.nGroupBox1.TabIndex = 31
			Me.nGroupBox1.TabStop = False
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 104)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(96, 23)
			Me.label2.TabIndex = 28
			Me.label2.Text = "Points count:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' pointsCountNumericUpDown
			' 
			Me.pointsCountNumericUpDown.Location = New System.Drawing.Point(8, 136)
			Me.pointsCountNumericUpDown.Name = "pointsCountNumericUpDown"
			Me.pointsCountNumericUpDown.Size = New System.Drawing.Size(80, 22)
			Me.pointsCountNumericUpDown.TabIndex = 13
			Me.pointsCountNumericUpDown.Value = New System.Decimal(New Integer() { 5, 0, 0, 0})
			' 
			' randomRectButton
			' 
			Me.randomRectButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.randomRectButton.Location = New System.Drawing.Point(104, 24)
			Me.randomRectButton.Name = "randomRectButton"
			Me.randomRectButton.Size = New System.Drawing.Size(138, 23)
			Me.randomRectButton.TabIndex = 12
			Me.randomRectButton.Text = "Random Rectangle"
'			Me.randomRectButton.Click += New System.EventHandler(Me.randomRectButton_Click);
			' 
			' randomEllipseButton
			' 
			Me.randomEllipseButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.randomEllipseButton.Location = New System.Drawing.Point(104, 56)
			Me.randomEllipseButton.Name = "randomEllipseButton"
			Me.randomEllipseButton.Size = New System.Drawing.Size(138, 23)
			Me.randomEllipseButton.TabIndex = 12
			Me.randomEllipseButton.Text = "Random Ellipse"
'			Me.randomEllipseButton.Click += New System.EventHandler(Me.randomEllipseButton_Click);
			' 
			' randomPolygonButton
			' 
			Me.randomPolygonButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.randomPolygonButton.Location = New System.Drawing.Point(104, 136)
			Me.randomPolygonButton.Name = "randomPolygonButton"
			Me.randomPolygonButton.Size = New System.Drawing.Size(138, 23)
			Me.randomPolygonButton.TabIndex = 12
			Me.randomPolygonButton.Text = "Random Polygon"
'			Me.randomPolygonButton.Click += New System.EventHandler(Me.randomPolygonButton_Click);
			' 
			' randomClosedCurveButton
			' 
			Me.randomClosedCurveButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.randomClosedCurveButton.Location = New System.Drawing.Point(104, 104)
			Me.randomClosedCurveButton.Name = "randomClosedCurveButton"
			Me.randomClosedCurveButton.Size = New System.Drawing.Size(138, 23)
			Me.randomClosedCurveButton.TabIndex = 12
			Me.randomClosedCurveButton.Text = "Random Closed Curve"
'			Me.randomClosedCurveButton.Click += New System.EventHandler(Me.randomClosedCurveButton_Click);
			' 
			' documentStylesGroupBox
			' 
			Me.documentStylesGroupBox.Controls.Add(Me.editDocumentShadowStyleButton)
			Me.documentStylesGroupBox.Controls.Add(Me.editDocumentStrokeStyleButton)
			Me.documentStylesGroupBox.Controls.Add(Me.editDocumentFillStyleButton)
			Me.documentStylesGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.documentStylesGroupBox.ImageIndex = 0
			Me.documentStylesGroupBox.Location = New System.Drawing.Point(0, 272)
			Me.documentStylesGroupBox.Name = "documentStylesGroupBox"
			Me.documentStylesGroupBox.Size = New System.Drawing.Size(250, 120)
			Me.documentStylesGroupBox.TabIndex = 35
			Me.documentStylesGroupBox.TabStop = False
			Me.documentStylesGroupBox.Text = "Document Styles"
			' 
			' editDocumentShadowStyleButton
			' 
			Me.editDocumentShadowStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editDocumentShadowStyleButton.Location = New System.Drawing.Point(8, 88)
			Me.editDocumentShadowStyleButton.Name = "editDocumentShadowStyleButton"
			Me.editDocumentShadowStyleButton.Size = New System.Drawing.Size(234, 23)
			Me.editDocumentShadowStyleButton.TabIndex = 3
			Me.editDocumentShadowStyleButton.Text = "Shadow Style ..."
'			Me.editDocumentShadowStyleButton.Click += New System.EventHandler(Me.editDocumentShadowStyleButton_Click);
			' 
			' editDocumentStrokeStyleButton
			' 
			Me.editDocumentStrokeStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editDocumentStrokeStyleButton.Location = New System.Drawing.Point(8, 56)
			Me.editDocumentStrokeStyleButton.Name = "editDocumentStrokeStyleButton"
			Me.editDocumentStrokeStyleButton.Size = New System.Drawing.Size(234, 23)
			Me.editDocumentStrokeStyleButton.TabIndex = 2
			Me.editDocumentStrokeStyleButton.Text = "Stroke Style ..."
'			Me.editDocumentStrokeStyleButton.Click += New System.EventHandler(Me.editDocumentStrokeStyleButton_Click);
			' 
			' editDocumentFillStyleButton
			' 
			Me.editDocumentFillStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editDocumentFillStyleButton.Location = New System.Drawing.Point(8, 24)
			Me.editDocumentFillStyleButton.Name = "editDocumentFillStyleButton"
			Me.editDocumentFillStyleButton.Size = New System.Drawing.Size(234, 23)
			Me.editDocumentFillStyleButton.TabIndex = 1
			Me.editDocumentFillStyleButton.Text = "Fill Style..."
'			Me.editDocumentFillStyleButton.Click += New System.EventHandler(Me.editDocumentFillStyleButton_Click);
			' 
			' NPrimitive2DShapesUC
			' 
			Me.Controls.Add(Me.documentStylesGroupBox)
			Me.Controls.Add(Me.selectedShapeStylesGroup)
			Me.Controls.Add(Me.addRandomGroupBox)
			Me.Name = "NPrimitive2DShapesUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.addRandomGroupBox, 0)
			Me.Controls.SetChildIndex(Me.selectedShapeStylesGroup, 0)
			Me.Controls.SetChildIndex(Me.documentStylesGroupBox, 0)
			Me.selectedShapeStylesGroup.ResumeLayout(False)
			Me.addRandomGroupBox.ResumeLayout(False)
			CType(Me.pointsCountNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.documentStylesGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init view
			view.Grid.Visible = False
			view.Selection.Mode = DiagramSelectionMode.Single

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub AttachToEvents()
			AddHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			AddHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			RemoveHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.DetachFromEvents()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			selectedShapeStylesGroup.Enabled = False

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			document.Style.TextStyle.FontStyle = New NFontStyle(New Font("Arial", 8))
			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur
			document.Style.ShadowStyle.Offset = New NPointL(5, 5)

			CreateRect()
			CreateEllipse()
			CreatePolygon()
			CreateClosedCurve()
		End Sub

		Private Sub CreateRect()
			' create rect
			Dim cell As NRectangleF = GetGridCell(0, 0)
			Dim rect As NRectangleShape = New NRectangleShape(cell)

			' set fill and stroke styles
			rect.Style.FillStyle = New NColorFillStyle(GetPredefinedColor(0))
			rect.Style.StrokeStyle = New NStrokeStyle(1, Color.Black)

			' add to active layer
			document.ActiveLayer.AddChild(rect)

			' add description
			cell = GetGridCell(1, 0)
			Dim text As NTextShape = New NTextShape("Rectangle with color fill style and solid stroke style", cell)
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateEllipse()
			' create ellipse
			Dim cell As NRectangleF = GetGridCell(0, 1)
			Dim ellipse As NEllipseShape = New NEllipseShape(cell)

			' set fill and stroke styles
			ellipse.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, GetPredefinedColor(1), Color.LightGreen)
			ellipse.Style.StrokeStyle = New NStrokeStyle(1, Color.Black, LinePattern.Dash)

			' add to active layer
			document.ActiveLayer.AddChild(ellipse)

			' add description
			cell = GetGridCell(1, 1)
			Dim text As NTextShape = New NTextShape("Ellipse with gradient fill style and dash stroke style", cell)
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreatePolygon()
			' create polygon
			Dim cell As NRectangleF = GetGridCell(0, 2)
			Dim xdeviation As Integer = CInt(Fix(cell.Width)) / 4
			Dim ydeviation As Integer = CInt(Fix(cell.Height)) / 4

			Dim points As NPointF() = New NPointF() { New NPointF(cell.X + Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)), New NPointF(cell.Right - Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)), New NPointF(cell.Right - Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)), New NPointF(cell.X + Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)), New NPointF(cell.X + Random.Next(CInt(Fix(cell.Width))), cell.Y + Random.Next(CInt(Fix(cell.Height)))) }

			Dim polygon As NPolygonShape = New NPolygonShape(points)

			' set fill and stroke styles
			polygon.Style.FillStyle = New NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, GetPredefinedColor(2), Color.Yellow)
			polygon.Style.StrokeStyle = New NStrokeStyle(1, Color.Black, LinePattern.DashDot)

			' add to active layer
			document.ActiveLayer.AddChild(polygon)

			' add description
			cell = GetGridCell(1, 2)
			Dim text As NTextShape = New NTextShape("Polygon with gradient fill style and dash-dot stroke style", cell)
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateClosedCurve()
			' create curve
			Dim cell As NRectangleF = GetGridCell(0, 3)
			Dim xdeviation As Integer = CInt(Fix(cell.Width)) / 4
			Dim ydeviation As Integer = CInt(Fix(cell.Height)) / 4

			Dim points As NPointF() = New NPointF() { New NPointF(cell.X + Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)), New NPointF(cell.Right - Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)), New NPointF(cell.Right - Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)), New NPointF(cell.X + Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)), New NPointF(cell.X + Random.Next(CInt(Fix(cell.Width))), cell.Y + Random.Next(CInt(Fix(cell.Height)))) }

			Dim curve As NClosedCurveShape = New NClosedCurveShape(points, 1)

			' set fill and stroke styles
			curve.Style.FillStyle = New NHatchFillStyle(HatchStyle.SmallGrid, Color.LightSalmon, GetPredefinedColor(3))
			curve.Style.StrokeStyle = New NStrokeStyle(1, Color.Black, LinePattern.DashDotDot)

			' add to active layer
			document.ActiveLayer.AddChild(curve)

			' add description
			cell = GetGridCell(1, 3)
			Dim text As NTextShape = New NTextShape("Closed curve with hatch fill style and dash-dot-dot stroke style", cell)
			document.ActiveLayer.AddChild(text)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub randomRectButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles randomRectButton.Click
			' create shape
			Dim shape As NRectangleShape = Nothing
			Try
				shape = New NRectangleShape(MyBase.GetRandomPoint(view.Viewport), MyBase.GetRandomPoint(view.Viewport))
			Catch
				Return
			End Try

			' add to active layer
			document.ActiveLayer.AddChild(shape)
			document.SmartRefreshAllViews()
		End Sub

		Private Sub randomEllipseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles randomEllipseButton.Click
			' create shape
			Dim shape As NEllipseShape = Nothing

			Try
				shape = New NEllipseShape(MyBase.GetRandomPoint(view.Viewport), MyBase.GetRandomPoint(view.Viewport))
			Catch
				Return
			End Try

			' add to active layer
			document.ActiveLayer.AddChild(shape)
			document.SmartRefreshAllViews()
		End Sub

		Private Sub randomPolygonButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles randomPolygonButton.Click
			' create shape
			Dim shape As NPolygonShape = Nothing
			Try
				shape = New NPolygonShape(MyBase.GetRandomPoints(view.Viewport, CInt(Fix(pointsCountNumericUpDown.Value))))
			Catch
				Return
			End Try

			' add to active layer
			document.ActiveLayer.AddChild(shape)
			document.SmartRefreshAllViews()
		End Sub

		Private Sub randomClosedCurveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles randomClosedCurveButton.Click
			' create shape
			Dim shape As NClosedCurveShape = Nothing
			Try
				shape = New NClosedCurveShape(MyBase.GetRandomPoints(view.Viewport, CInt(Fix(pointsCountNumericUpDown.Value))), 1)
			Catch
				Return
			End Try

			' add to active layer
			document.ActiveLayer.AddChild(shape)
			document.SmartRefreshAllViews()
		End Sub


		Private Sub editFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editFillStyleButton.Click
			MyBase.ShowFillStyleEditor(TryCast(view.Selection.AnchorNode, NShape))
		End Sub

		Private Sub editStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editStrokeStyleButton.Click
			MyBase.ShowFillStyleEditor(TryCast(view.Selection.AnchorNode, NShape))
		End Sub


		Private Sub editDocumentFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editDocumentFillStyleButton.Click
			MyBase.ShowFillStyleEditor(document)
		End Sub

		Private Sub editDocumentStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editDocumentStrokeStyleButton.Click
			MyBase.ShowStrokeStyleEditor(document)
		End Sub

		Private Sub editDocumentShadowStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editDocumentShadowStyleButton.Click
			MyBase.ShowShadowStyleEditor(document)
		End Sub

		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			If TypeOf args.Node Is NShape Then
				selectedShapeStylesGroup.Enabled = True
			End If
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			selectedShapeStylesGroup.Enabled = False
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private addRandomGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private pointsCountNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents randomRectButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents randomEllipseButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents randomPolygonButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents randomClosedCurveButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents editFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label2 As System.Windows.Forms.Label
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private documentStylesGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents editDocumentShadowStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents editDocumentStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private selectedShapeStylesGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents editDocumentFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents editStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton

		#End Region
	End Class
End Namespace