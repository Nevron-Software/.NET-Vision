Imports Microsoft.VisualBasic
Imports System
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
	''' Summary description for NPrimitive1DShapesUC.
	''' </summary>
	Public Class NPrimitive1DShapesUC
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
			Me.randomEllipticalArcButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.pointsCountNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.randomLineButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.randomCircularArcButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.randomPolylineButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.randomBezierButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.randomCurveButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.selectedShapeStyleGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.editStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.editStartArrowheadButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.editEndArrowheadButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.documentStylesGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.editDocumentShadowStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.editDocumentStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.editDocumentStartArrowheadStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.editDocumentEndArrowheadStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.addRandomGroupBox.SuspendLayout()
			CType(Me.pointsCountNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.selectedShapeStyleGroup.SuspendLayout()
			Me.documentStylesGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' addRandomGroupBox
			' 
			Me.addRandomGroupBox.Controls.Add(Me.randomEllipticalArcButton)
			Me.addRandomGroupBox.Controls.Add(Me.nGroupBox1)
			Me.addRandomGroupBox.Controls.Add(Me.label2)
			Me.addRandomGroupBox.Controls.Add(Me.pointsCountNumericUpDown)
			Me.addRandomGroupBox.Controls.Add(Me.randomLineButton)
			Me.addRandomGroupBox.Controls.Add(Me.randomCircularArcButton)
			Me.addRandomGroupBox.Controls.Add(Me.randomPolylineButton)
			Me.addRandomGroupBox.Controls.Add(Me.randomBezierButton)
			Me.addRandomGroupBox.Controls.Add(Me.randomCurveButton)
			Me.addRandomGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.addRandomGroupBox.ImageIndex = 0
			Me.addRandomGroupBox.Location = New System.Drawing.Point(0, 0)
			Me.addRandomGroupBox.Name = "addRandomGroupBox"
			Me.addRandomGroupBox.Size = New System.Drawing.Size(250, 240)
			Me.addRandomGroupBox.TabIndex = 0
			Me.addRandomGroupBox.TabStop = False
			Me.addRandomGroupBox.Text = "Add Random Strokes"
			' 
			' randomEllipticalArcButton
			' 
			Me.randomEllipticalArcButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.randomEllipticalArcButton.Location = New System.Drawing.Point(104, 88)
			Me.randomEllipticalArcButton.Name = "randomEllipticalArcButton"
			Me.randomEllipticalArcButton.Size = New System.Drawing.Size(138, 23)
			Me.randomEllipticalArcButton.TabIndex = 2
			Me.randomEllipticalArcButton.Text = "Random Elliptical Arc"
'			Me.randomEllipticalArcButton.Click += New System.EventHandler(Me.randomEllipticalArcButton_Click);
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 152)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(232, 8)
			Me.nGroupBox1.TabIndex = 4
			Me.nGroupBox1.TabStop = False
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 168)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(80, 23)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Points count:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' pointsCountNumericUpDown
			' 
			Me.pointsCountNumericUpDown.Location = New System.Drawing.Point(8, 200)
			Me.pointsCountNumericUpDown.Name = "pointsCountNumericUpDown"
			Me.pointsCountNumericUpDown.Size = New System.Drawing.Size(80, 22)
			Me.pointsCountNumericUpDown.TabIndex = 6
			Me.pointsCountNumericUpDown.Value = New System.Decimal(New Integer() { 5, 0, 0, 0})
			' 
			' randomLineButton
			' 
			Me.randomLineButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.randomLineButton.Location = New System.Drawing.Point(104, 24)
			Me.randomLineButton.Name = "randomLineButton"
			Me.randomLineButton.Size = New System.Drawing.Size(138, 23)
			Me.randomLineButton.TabIndex = 0
			Me.randomLineButton.Text = "Random Line"
'			Me.randomLineButton.Click += New System.EventHandler(Me.randomLineButton_Click);
			' 
			' randomCircularArcButton
			' 
			Me.randomCircularArcButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.randomCircularArcButton.Location = New System.Drawing.Point(104, 56)
			Me.randomCircularArcButton.Name = "randomCircularArcButton"
			Me.randomCircularArcButton.Size = New System.Drawing.Size(138, 23)
			Me.randomCircularArcButton.TabIndex = 1
			Me.randomCircularArcButton.Text = "Random Circular Arc"
'			Me.randomCircularArcButton.Click += New System.EventHandler(Me.randomCircularArcButton_Click);
			' 
			' randomPolylineButton
			' 
			Me.randomPolylineButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.randomPolylineButton.Location = New System.Drawing.Point(104, 168)
			Me.randomPolylineButton.Name = "randomPolylineButton"
			Me.randomPolylineButton.Size = New System.Drawing.Size(138, 23)
			Me.randomPolylineButton.TabIndex = 7
			Me.randomPolylineButton.Text = "Random Polyline"
'			Me.randomPolylineButton.Click += New System.EventHandler(Me.randomPolylineButton_Click);
			' 
			' randomBezierButton
			' 
			Me.randomBezierButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.randomBezierButton.Location = New System.Drawing.Point(104, 120)
			Me.randomBezierButton.Name = "randomBezierButton"
			Me.randomBezierButton.Size = New System.Drawing.Size(138, 23)
			Me.randomBezierButton.TabIndex = 3
			Me.randomBezierButton.Text = "Random Bezier"
'			Me.randomBezierButton.Click += New System.EventHandler(Me.randomBezierButton_Click);
			' 
			' randomCurveButton
			' 
			Me.randomCurveButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.randomCurveButton.Location = New System.Drawing.Point(104, 200)
			Me.randomCurveButton.Name = "randomCurveButton"
			Me.randomCurveButton.Size = New System.Drawing.Size(138, 23)
			Me.randomCurveButton.TabIndex = 8
			Me.randomCurveButton.Text = "Random Curve"
'			Me.randomCurveButton.Click += New System.EventHandler(Me.randomCurveButton_Click);
			' 
			' selectedShapeStyleGroup
			' 
			Me.selectedShapeStyleGroup.Controls.Add(Me.editStrokeStyleButton)
			Me.selectedShapeStyleGroup.Controls.Add(Me.editStartArrowheadButton)
			Me.selectedShapeStyleGroup.Controls.Add(Me.editEndArrowheadButton)
			Me.selectedShapeStyleGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.selectedShapeStyleGroup.Enabled = False
			Me.selectedShapeStyleGroup.ImageIndex = 0
			Me.selectedShapeStyleGroup.Location = New System.Drawing.Point(0, 240)
			Me.selectedShapeStyleGroup.Name = "selectedShapeStyleGroup"
			Me.selectedShapeStyleGroup.Size = New System.Drawing.Size(250, 128)
			Me.selectedShapeStyleGroup.TabIndex = 1
			Me.selectedShapeStyleGroup.TabStop = False
			Me.selectedShapeStyleGroup.Text = "Selected Shape Styles"
			' 
			' editStrokeStyleButton
			' 
			Me.editStrokeStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editStrokeStyleButton.Location = New System.Drawing.Point(8, 88)
			Me.editStrokeStyleButton.Name = "editStrokeStyleButton"
			Me.editStrokeStyleButton.Size = New System.Drawing.Size(234, 23)
			Me.editStrokeStyleButton.TabIndex = 2
			Me.editStrokeStyleButton.Text = "Stroke Style ..."
'			Me.editStrokeStyleButton.Click += New System.EventHandler(Me.editStrokeStyleButton_Click);
			' 
			' editStartArrowheadButton
			' 
			Me.editStartArrowheadButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editStartArrowheadButton.Location = New System.Drawing.Point(8, 24)
			Me.editStartArrowheadButton.Name = "editStartArrowheadButton"
			Me.editStartArrowheadButton.Size = New System.Drawing.Size(234, 23)
			Me.editStartArrowheadButton.TabIndex = 0
			Me.editStartArrowheadButton.Text = "Start Arrowhead Style..."
'			Me.editStartArrowheadButton.Click += New System.EventHandler(Me.editStartArrowheadButton_Click);
			' 
			' editEndArrowheadButton
			' 
			Me.editEndArrowheadButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editEndArrowheadButton.Location = New System.Drawing.Point(8, 56)
			Me.editEndArrowheadButton.Name = "editEndArrowheadButton"
			Me.editEndArrowheadButton.Size = New System.Drawing.Size(234, 23)
			Me.editEndArrowheadButton.TabIndex = 1
			Me.editEndArrowheadButton.Text = "End Arrowhead Style..."
'			Me.editEndArrowheadButton.Click += New System.EventHandler(Me.editEndArrowheadButton_Click);
			' 
			' documentStylesGroupBox
			' 
			Me.documentStylesGroupBox.Controls.Add(Me.editDocumentShadowStyleButton)
			Me.documentStylesGroupBox.Controls.Add(Me.editDocumentStrokeStyleButton)
			Me.documentStylesGroupBox.Controls.Add(Me.editDocumentStartArrowheadStyleButton)
			Me.documentStylesGroupBox.Controls.Add(Me.editDocumentEndArrowheadStyleButton)
			Me.documentStylesGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.documentStylesGroupBox.ImageIndex = 0
			Me.documentStylesGroupBox.Location = New System.Drawing.Point(0, 368)
			Me.documentStylesGroupBox.Name = "documentStylesGroupBox"
			Me.documentStylesGroupBox.Size = New System.Drawing.Size(250, 144)
			Me.documentStylesGroupBox.TabIndex = 2
			Me.documentStylesGroupBox.TabStop = False
			Me.documentStylesGroupBox.Text = "Document Styles"
			' 
			' editDocumentShadowStyleButton
			' 
			Me.editDocumentShadowStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editDocumentShadowStyleButton.Location = New System.Drawing.Point(8, 111)
			Me.editDocumentShadowStyleButton.Name = "editDocumentShadowStyleButton"
			Me.editDocumentShadowStyleButton.Size = New System.Drawing.Size(234, 23)
			Me.editDocumentShadowStyleButton.TabIndex = 3
			Me.editDocumentShadowStyleButton.Text = "Shadow Style ..."
'			Me.editDocumentShadowStyleButton.Click += New System.EventHandler(Me.editDocumentShadowStyleButton_Click);
			' 
			' editDocumentStrokeStyleButton
			' 
			Me.editDocumentStrokeStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editDocumentStrokeStyleButton.Location = New System.Drawing.Point(8, 81)
			Me.editDocumentStrokeStyleButton.Name = "editDocumentStrokeStyleButton"
			Me.editDocumentStrokeStyleButton.Size = New System.Drawing.Size(234, 23)
			Me.editDocumentStrokeStyleButton.TabIndex = 2
			Me.editDocumentStrokeStyleButton.Text = "Stroke Style ..."
'			Me.editDocumentStrokeStyleButton.Click += New System.EventHandler(Me.editDocumentStrokeStyleButton_Click);
			' 
			' editDocumentStartArrowheadStyleButton
			' 
			Me.editDocumentStartArrowheadStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editDocumentStartArrowheadStyleButton.Location = New System.Drawing.Point(8, 21)
			Me.editDocumentStartArrowheadStyleButton.Name = "editDocumentStartArrowheadStyleButton"
			Me.editDocumentStartArrowheadStyleButton.Size = New System.Drawing.Size(234, 23)
			Me.editDocumentStartArrowheadStyleButton.TabIndex = 0
			Me.editDocumentStartArrowheadStyleButton.Text = "Start Arrowhead Style..."
'			Me.editDocumentStartArrowheadStyleButton.Click += New System.EventHandler(Me.editDocumentStartArrowheadStyleButton_Click);
			' 
			' editDocumentEndArrowheadStyleButton
			' 
			Me.editDocumentEndArrowheadStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editDocumentEndArrowheadStyleButton.Location = New System.Drawing.Point(8, 51)
			Me.editDocumentEndArrowheadStyleButton.Name = "editDocumentEndArrowheadStyleButton"
			Me.editDocumentEndArrowheadStyleButton.Size = New System.Drawing.Size(234, 23)
			Me.editDocumentEndArrowheadStyleButton.TabIndex = 1
			Me.editDocumentEndArrowheadStyleButton.Text = "End Arrowhead Style..."
'			Me.editDocumentEndArrowheadStyleButton.Click += New System.EventHandler(Me.editDocumentEndArrowheadStyleButton_Click);
			' 
			' NPrimitive1DShapesUC
			' 
			Me.Controls.Add(Me.documentStylesGroupBox)
			Me.Controls.Add(Me.selectedShapeStyleGroup)
			Me.Controls.Add(Me.addRandomGroupBox)
			Me.Name = "NPrimitive1DShapesUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.addRandomGroupBox, 0)
			Me.Controls.SetChildIndex(Me.selectedShapeStyleGroup, 0)
			Me.Controls.SetChildIndex(Me.documentStylesGroupBox, 0)
			Me.addRandomGroupBox.ResumeLayout(False)
			CType(Me.pointsCountNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.selectedShapeStyleGroup.ResumeLayout(False)
			Me.documentStylesGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init view
			view.Selection.Mode = DiagramSelectionMode.Single
			view.Grid.Visible = False

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

			selectedShapeStyleGroup.Enabled = False

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			' by default display everything with shadow
			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur
			document.Style.ShadowStyle.Offset = New NPointL(5, 5)

			' by default do not display arrowheads
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.StrokeStyle.Color = Color.DarkCyan

			document.Style.TextStyle.FontStyle = New NFontStyle(New Font("Arial", 8))

			CreateLineShape(0, 0)
			CreateCircularArcShape(0, 1)
			CreateEllipticalArcShape(0, 2)
			CreatePolylineShape(2, 0)
			CreateBezierShape(2, 1)
			CreateCurveShape(2, 2)
		End Sub


		Private Sub CreateLineShape(ByVal row As Integer, ByVal col As Integer)
			' create line
			Dim cell As NRectangleF = GetGridCell(row, col)
			Dim color As Color = GetPredefinedColor(0)

			Dim line As NLineShape = New NLineShape(cell.X, cell.Y, cell.Right, cell.Bottom)

			' set stroke style
			line.Style.StrokeStyle = New NStrokeStyle(1, color, LinePattern.Dash)

			' set arrowheads style
			Dim arrowheadStyle As NArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Circle, "", New NSizeL(12, 12), New NColorFillStyle(color), New NStrokeStyle(1, Color.Black))

			line.Style.StartArrowheadStyle = arrowheadStyle

			arrowheadStyle = New NArrowheadStyle(ArrowheadShape.Arrow, "", New NSizeL(12, 12), New NColorFillStyle(color), New NStrokeStyle(1, Color.Black))

			line.Style.EndArrowheadStyle = arrowheadStyle

			' add to the active layer
			document.ActiveLayer.AddChild(line)

			' add description
			cell = GetGridCell(row + 1, col)
			Dim text As NTextShape = New NTextShape("Line with dash style and Circle and Arrow arrowheads", cell)
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateCircularArcShape(ByVal row As Integer, ByVal col As Integer)
			Dim cell As NRectangleF = GetGridCell(row, col)
			Dim color As Color = GetPredefinedColor(1)

			' create circular arc
			Dim arc As NCircularArcShape = New NCircularArcShape(New NPointF(cell.X, cell.Y), New NPointF(cell.Right, cell.Y), New NPointF(cell.Right, cell.Bottom))

			' set stroke style
			arc.Style.StrokeStyle = New NStrokeStyle(2, color, LinePattern.Dot)

			' set arrowheads style
			Dim arrowheadStyle As NArrowheadStyle = New NArrowheadStyle(ArrowheadShape.ClosedFork, "", New NSizeL(12, 12), New NColorFillStyle(color), New NStrokeStyle(1, Color.Black))
			arc.Style.StartArrowheadStyle = arrowheadStyle

			arrowheadStyle = New NArrowheadStyle(ArrowheadShape.DoubleArrow, "", New NSizeL(12, 12), New NColorFillStyle(color), New NStrokeStyle(1, Color.Black))
			arc.Style.EndArrowheadStyle = arrowheadStyle

			' add to the active layer
			document.ActiveLayer.AddChild(arc)

			' add description
			cell = GetGridCell(row + 1, col)
			Dim text As NTextShape = New NTextShape("Circular arc with dots style and ClosedFork and DoubleArrow arrowheads", cell)
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateEllipticalArcShape(ByVal row As Integer, ByVal col As Integer)
			Dim cell As NRectangleF = GetGridCell(row, col)
			Dim color As Color = GetPredefinedColor(2)

			' create arc
			Dim arc As NEllipticalArcShape = New NEllipticalArcShape(New NPointF(cell.X, cell.Y), New NPointF(cell.Right, cell.Bottom))

			' set stroke style
			arc.Style.StrokeStyle = New NStrokeStyle(2, color, LinePattern.Dot)

			' set arrowheads style
			Dim arrowheadStyle As NArrowheadStyle = New NArrowheadStyle(ArrowheadShape.ClosedFork, "", New NSizeL(12, 12), New NColorFillStyle(color), New NStrokeStyle(1, Color.Black))

			arc.Style.StartArrowheadStyle = arrowheadStyle

			arrowheadStyle = New NArrowheadStyle(ArrowheadShape.DoubleArrow, "", New NSizeL(12, 12), New NColorFillStyle(color), New NStrokeStyle(1, Color.Black))

			arc.Style.EndArrowheadStyle = arrowheadStyle

			' add to the active layer
			document.ActiveLayer.AddChild(arc)

			' add description
			cell = GetGridCell(row + 1, col)
			Dim text As NTextShape = New NTextShape("Elliptical arc with dots style and ClosedFork and DoubleArrow arrowheads", cell)
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreatePolylineShape(ByVal row As Integer, ByVal col As Integer)
			Dim cell As NRectangleF = GetGridCell(row, col)
			Dim color As Color = GetPredefinedColor(3)

			Dim xdeviation As Integer = CInt(Fix(cell.Width)) / 4
			Dim ydeviation As Integer = CInt(Fix(cell.Height)) / 4

			Dim points As NPointF() = New NPointF() { New NPointF(cell.X + Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)), New NPointF(cell.Right - Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)), New NPointF(cell.Right - Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)), New NPointF(cell.X + Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)), New NPointF(cell.X + Random.Next(CInt(Fix(cell.Width))), cell.Y + Random.Next(CInt(Fix(cell.Height)))) }

			' create polyline
			Dim polyline As NPolylineShape = New NPolylineShape(points)

			' set stroke style
			polyline.Style.StrokeStyle = New NStrokeStyle(2, color, LinePattern.DashDot)

			' set arrowheads style
			Dim arrowheadStyle As NArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Fork, "", New NSizeL(12, 12), New NColorFillStyle(color), New NStrokeStyle(1, Color.Black))

			polyline.Style.StartArrowheadStyle = arrowheadStyle

			arrowheadStyle = New NArrowheadStyle(ArrowheadShape.Losangle, "", New NSizeL(12, 12), New NColorFillStyle(color), New NStrokeStyle(1, Color.Black))

			polyline.Style.EndArrowheadStyle = arrowheadStyle

			' add to the active layer
			document.ActiveLayer.AddChild(polyline)

			' add description
			cell = GetGridCell(row + 1, col)
			Dim text As NTextShape = New NTextShape("Polyline with dash-dot style and Fork and Losangle arrowheads", cell)
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateBezierShape(ByVal row As Integer, ByVal col As Integer)
			Dim cell As NRectangleF = GetGridCell(row, col)
			Dim color As Color = GetPredefinedColor(4)

			' create bezier
			Dim bezier As NBezierCurveShape = New NBezierCurveShape(cell.Location, New NPointF(cell.Right, cell.Bottom))

			' set stroke style
			bezier.Style.StrokeStyle = New NStrokeStyle(2, color, LinePattern.Solid)

			' set arrowheads style
			Dim arrowheadStyle As NArrowheadStyle = New NArrowheadStyle(ArrowheadShape.ManyOptional, "", New NSizeL(12, 12), New NColorFillStyle(color), New NStrokeStyle(1, Color.Black))

			bezier.Style.StartArrowheadStyle = arrowheadStyle

			arrowheadStyle = New NArrowheadStyle(ArrowheadShape.Many, "", New NSizeL(12, 12), New NColorFillStyle(color), New NStrokeStyle(1, Color.Black))

			bezier.Style.EndArrowheadStyle = arrowheadStyle

			' add to the active layer
			document.ActiveLayer.AddChild(bezier)

			' add description
			cell = GetGridCell(row + 1, col)
			Dim text As NTextShape = New NTextShape("Bezier curve with solid style and ManyOptional and Many arrowheads", cell)
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateCurveShape(ByVal row As Integer, ByVal col As Integer)
			Dim cell As NRectangleF = GetGridCell(row, col)
			Dim color As Color = GetPredefinedColor(5)

			Dim xdeviation As Integer = CInt(Fix(cell.Width)) / 4
			Dim ydeviation As Integer = CInt(Fix(cell.Height)) / 4

			Dim points As NPointF() = New NPointF() { New NPointF(cell.X + Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)), New NPointF(cell.Right - Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)), New NPointF(cell.Right - Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)), New NPointF(cell.X + Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)), New NPointF(cell.X + Random.Next(CInt(Fix(cell.Width))), cell.Y + Random.Next(CInt(Fix(cell.Height)))) }

			' create curve
			Dim curve As NCurveShape = New NCurveShape(points, 1)

			' set stroke style
			curve.Style.StrokeStyle = New NStrokeStyle(2, color, LinePattern.DashDotDot)

			' set arrowheads style
			Dim arrowheadStyle As NArrowheadStyle = New NArrowheadStyle(ArrowheadShape.QuillArrow, "", New NSizeL(12, 12), New NColorFillStyle(color), New NStrokeStyle(1, Color.Black))

			curve.Style.StartArrowheadStyle = arrowheadStyle

			arrowheadStyle = New NArrowheadStyle(ArrowheadShape.SunkenArrow, "", New NSizeL(12, 12), New NColorFillStyle(color), New NStrokeStyle(1, Color.Black))

			curve.Style.EndArrowheadStyle = arrowheadStyle

			' add to the active layer
			document.ActiveLayer.AddChild(curve)

			' add description
			cell = GetGridCell(row + 1, col)
			Dim text As NTextShape = New NTextShape("Curve with dash-dot-dot style and QuillArrow and SunkenArrow arrowheads", cell)
			document.ActiveLayer.AddChild(text)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub randomLineButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles randomLineButton.Click
			' create shape
			Dim shape As NLineShape = Nothing
			Try
				shape = New NLineShape(MyBase.GetRandomPoint(view.Viewport), MyBase.GetRandomPoint(view.Viewport))
			Catch
				Return
			End Try

			' add to active layer
			document.ActiveLayer.AddChild(shape)
			document.SmartRefreshAllViews()
		End Sub

		Private Sub randomCircularArcButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles randomCircularArcButton.Click
			' create shape
			Dim start As NPointF = MyBase.GetRandomPoint(view.Viewport)
			Dim [end] As NPointF = MyBase.GetRandomPoint(view.Viewport)

			Dim shape As NEllipticalArcShape = Nothing
			Try
				shape = New NEllipticalArcShape(start, [end])
			Catch
				Return
			End Try

			' add to active layer
			document.ActiveLayer.AddChild(shape)
			document.SmartRefreshAllViews()
		End Sub

		Private Sub randomEllipticalArcButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles randomEllipticalArcButton.Click
			' create shape
			Dim start As NPointF = MyBase.GetRandomPoint(view.Viewport)
			Dim [end] As NPointF = MyBase.GetRandomPoint(view.Viewport)
			Dim control As NPointF = MyBase.GetRandomPoint(view.Viewport)

			Dim shape As NCircularArcShape = Nothing
			Try
				shape = New NCircularArcShape(start, [end], control)
			Catch
				Return
			End Try

			' add to active layer
			document.ActiveLayer.AddChild(shape)
			document.SmartRefreshAllViews()
		End Sub

		Private Sub randomPolylineButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles randomPolylineButton.Click
			' create shape
			Dim shape As NPolylineShape = Nothing
			Try
				shape = New NPolylineShape(MyBase.GetRandomPoints(view.Viewport, CInt(Fix(pointsCountNumericUpDown.Value))))
			Catch
				Return
			End Try

			' add to active layer
			document.ActiveLayer.AddChild(shape)
			document.SmartRefreshAllViews()
		End Sub

		Private Sub randomBezierButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles randomBezierButton.Click
			' create shape
			Dim start As NPointF = MyBase.GetRandomPoint(view.Viewport)
			Dim firstControl As NPointF = MyBase.GetRandomPoint(view.Viewport)
			Dim secondControl As NPointF = MyBase.GetRandomPoint(view.Viewport)
			Dim [end] As NPointF = MyBase.GetRandomPoint(view.Viewport)

			Dim shape As NBezierCurveShape = Nothing
			Try
				shape = New NBezierCurveShape(start, firstControl, secondControl, [end])
			Catch
				Return
			End Try

			' add to active layer
			document.ActiveLayer.AddChild(shape)
			document.SmartRefreshAllViews()
		End Sub

		Private Sub randomCurveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles randomCurveButton.Click
			' create shape
			Dim shape As NCurveShape = Nothing
			Try
				shape = New NCurveShape(MyBase.GetRandomPoints(view.Viewport, CInt(Fix(pointsCountNumericUpDown.Value))), 1)
			Catch
				Return
			End Try

			' add to active layer
			document.ActiveLayer.AddChild(shape)
			document.SmartRefreshAllViews()
		End Sub


		Private Sub editStartArrowheadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editStartArrowheadButton.Click
			MyBase.ShowStartArrowheadStyleEditor(TryCast(view.Selection.AnchorNode, NShape))
		End Sub

		Private Sub editEndArrowheadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editEndArrowheadButton.Click
			MyBase.ShowEndArrowheadStyleEditor(TryCast(view.Selection.AnchorNode, NShape))
		End Sub

		Private Sub editStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editStrokeStyleButton.Click
			MyBase.ShowStrokeStyleEditor(TryCast(view.Selection.AnchorNode, NShape))
		End Sub


		Private Sub editDocumentStartArrowheadStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editDocumentStartArrowheadStyleButton.Click
			MyBase.ShowStartArrowheadStyleEditor(document)
		End Sub

		Private Sub editDocumentEndArrowheadStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editDocumentEndArrowheadStyleButton.Click
			MyBase.ShowEndArrowheadStyleEditor(document)
		End Sub

		Private Sub editDocumentStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editDocumentStrokeStyleButton.Click
			MyBase.ShowStrokeStyleEditor(document)
		End Sub

		Private Sub editDocumentShadowStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editDocumentShadowStyleButton.Click
			MyBase.ShowShadowStyleEditor(document)
		End Sub

		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			If TypeOf args.Node Is NShape Then
				selectedShapeStyleGroup.Enabled = True
			End If
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			selectedShapeStyleGroup.Enabled = False
		End Sub


		#End Region

		#Region "Designer Fields"

		Private WithEvents editStartArrowheadButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents editEndArrowheadButton As Nevron.UI.WinForm.Controls.NButton
		Private addRandomGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents randomLineButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents randomPolylineButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents randomBezierButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents randomCurveButton As Nevron.UI.WinForm.Controls.NButton
		Private pointsCountNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label2 As System.Windows.Forms.Label
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents editStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents editDocumentStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents editDocumentStartArrowheadStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents editDocumentEndArrowheadStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents editDocumentShadowStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private selectedShapeStyleGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private documentStylesGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents randomCircularArcButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents randomEllipticalArcButton As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
