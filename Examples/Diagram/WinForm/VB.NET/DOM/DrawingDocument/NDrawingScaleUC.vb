Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NDrawingScaleUC.
	''' </summary>
	Public Class NDrawingScaleUC
		Inherits NDiagramExampleUC
		#Region "Constructors"
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
			Me.drawingScaleTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.drawingScaleSystemComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.drawingScaleComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.drawingScaleGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label10 = New System.Windows.Forms.Label()
			Me.label11 = New System.Windows.Forms.Label()
			Me.documentMeasurementUnitTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.worldMeasurmentUnitTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.selectionBoundsGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.selectionWidthTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.selectionHeightTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.selectionTopTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.selectionLeftTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.scaleSystemsGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label9 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.documentSizeGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label15 = New System.Windows.Forms.Label()
			Me.documentWidthTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.documentHeightTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label16 = New System.Windows.Forms.Label()
			Me.drawingScaleGroupBox.SuspendLayout()
			Me.selectionBoundsGroupBox.SuspendLayout()
			Me.scaleSystemsGroupBox.SuspendLayout()
			Me.documentSizeGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' drawingScaleTextBox
			' 
			Me.drawingScaleTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.drawingScaleTextBox.ErrorMessage = Nothing
			Me.drawingScaleTextBox.Location = New System.Drawing.Point(112, 72)
			Me.drawingScaleTextBox.Name = "drawingScaleTextBox"
			Me.drawingScaleTextBox.ReadOnly = True
			Me.drawingScaleTextBox.Size = New System.Drawing.Size(120, 20)
			Me.drawingScaleTextBox.TabIndex = 5
			Me.drawingScaleTextBox.Text = "1"
			' 
			' drawingScaleSystemComboBox
			' 
			Me.drawingScaleSystemComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.drawingScaleSystemComboBox.Location = New System.Drawing.Point(64, 24)
			Me.drawingScaleSystemComboBox.Name = "drawingScaleSystemComboBox"
			Me.drawingScaleSystemComboBox.Size = New System.Drawing.Size(176, 22)
			Me.drawingScaleSystemComboBox.TabIndex = 0
			Me.drawingScaleSystemComboBox.Text = "nComboBox1"
'			Me.drawingScaleSystemComboBox.SelectedIndexChanged += New System.EventHandler(Me.drawingScaleSystemComboBox_SelectedIndexChanged);
			' 
			' drawingScaleComboBox
			' 
			Me.drawingScaleComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.drawingScaleComboBox.Location = New System.Drawing.Point(64, 56)
			Me.drawingScaleComboBox.Name = "drawingScaleComboBox"
			Me.drawingScaleComboBox.Size = New System.Drawing.Size(176, 22)
			Me.drawingScaleComboBox.TabIndex = 1
			Me.drawingScaleComboBox.Text = "nComboBox1"
'			Me.drawingScaleComboBox.SelectedIndexChanged += New System.EventHandler(Me.drawingScaleComboBox_SelectedIndexChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 72)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(96, 24)
			Me.label7.TabIndex = 4
			Me.label7.Text = "Drawing scale:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' drawingScaleGroupBox
			' 
			Me.drawingScaleGroupBox.Controls.Add(Me.label10)
			Me.drawingScaleGroupBox.Controls.Add(Me.label11)
			Me.drawingScaleGroupBox.Controls.Add(Me.label7)
			Me.drawingScaleGroupBox.Controls.Add(Me.drawingScaleTextBox)
			Me.drawingScaleGroupBox.Controls.Add(Me.documentMeasurementUnitTextBox)
			Me.drawingScaleGroupBox.Controls.Add(Me.worldMeasurmentUnitTextBox)
			Me.drawingScaleGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.drawingScaleGroupBox.ImageIndex = 0
			Me.drawingScaleGroupBox.Location = New System.Drawing.Point(0, 96)
			Me.drawingScaleGroupBox.Name = "drawingScaleGroupBox"
			Me.drawingScaleGroupBox.Size = New System.Drawing.Size(250, 104)
			Me.drawingScaleGroupBox.TabIndex = 1
			Me.drawingScaleGroupBox.TabStop = False
			Me.drawingScaleGroupBox.Text = "Measurement units and scale"
			' 
			' label10
			' 
			Me.label10.Location = New System.Drawing.Point(8, 24)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(96, 24)
			Me.label10.TabIndex = 0
			Me.label10.Text = "Logical MU:"
			Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label11
			' 
			Me.label11.Location = New System.Drawing.Point(8, 48)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(96, 24)
			Me.label11.TabIndex = 2
			Me.label11.Text = "World MU:"
			Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' documentMeasurementUnitTextBox
			' 
			Me.documentMeasurementUnitTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.documentMeasurementUnitTextBox.ErrorMessage = Nothing
			Me.documentMeasurementUnitTextBox.Location = New System.Drawing.Point(112, 24)
			Me.documentMeasurementUnitTextBox.Name = "documentMeasurementUnitTextBox"
			Me.documentMeasurementUnitTextBox.ReadOnly = True
			Me.documentMeasurementUnitTextBox.Size = New System.Drawing.Size(120, 20)
			Me.documentMeasurementUnitTextBox.TabIndex = 1
			' 
			' worldMeasurmentUnitTextBox
			' 
			Me.worldMeasurmentUnitTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.worldMeasurmentUnitTextBox.ErrorMessage = Nothing
			Me.worldMeasurmentUnitTextBox.Location = New System.Drawing.Point(112, 48)
			Me.worldMeasurmentUnitTextBox.Name = "worldMeasurmentUnitTextBox"
			Me.worldMeasurmentUnitTextBox.ReadOnly = True
			Me.worldMeasurmentUnitTextBox.Size = New System.Drawing.Size(120, 20)
			Me.worldMeasurmentUnitTextBox.TabIndex = 3
			' 
			' selectionBoundsGroupBox
			' 
			Me.selectionBoundsGroupBox.Controls.Add(Me.label3)
			Me.selectionBoundsGroupBox.Controls.Add(Me.label4)
			Me.selectionBoundsGroupBox.Controls.Add(Me.label5)
			Me.selectionBoundsGroupBox.Controls.Add(Me.label6)
			Me.selectionBoundsGroupBox.Controls.Add(Me.selectionLeftTextBox)
			Me.selectionBoundsGroupBox.Controls.Add(Me.selectionTopTextBox)
			Me.selectionBoundsGroupBox.Controls.Add(Me.selectionWidthTextBox)
			Me.selectionBoundsGroupBox.Controls.Add(Me.selectionHeightTextBox)
			Me.selectionBoundsGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.selectionBoundsGroupBox.ImageIndex = 0
			Me.selectionBoundsGroupBox.Location = New System.Drawing.Point(0, 200)
			Me.selectionBoundsGroupBox.Name = "selectionBoundsGroupBox"
			Me.selectionBoundsGroupBox.Size = New System.Drawing.Size(250, 128)
			Me.selectionBoundsGroupBox.TabIndex = 2
			Me.selectionBoundsGroupBox.TabStop = False
			Me.selectionBoundsGroupBox.Text = "Selection bounds"
			Me.selectionBoundsGroupBox.Visible = False
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 48)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(96, 23)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Top:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 24)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(96, 23)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Left:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 96)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(96, 23)
			Me.label5.TabIndex = 6
			Me.label5.Text = "Height:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 72)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(96, 23)
			Me.label6.TabIndex = 4
			Me.label6.Text = "Width:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' selectionWidthTextBox
			' 
			Me.selectionWidthTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.selectionWidthTextBox.ErrorMessage = Nothing
			Me.selectionWidthTextBox.Location = New System.Drawing.Point(112, 72)
			Me.selectionWidthTextBox.Name = "selectionWidthTextBox"
			Me.selectionWidthTextBox.ReadOnly = True
			Me.selectionWidthTextBox.Size = New System.Drawing.Size(120, 20)
			Me.selectionWidthTextBox.TabIndex = 5
			' 
			' selectionHeightTextBox
			' 
			Me.selectionHeightTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.selectionHeightTextBox.ErrorMessage = Nothing
			Me.selectionHeightTextBox.Location = New System.Drawing.Point(112, 96)
			Me.selectionHeightTextBox.Name = "selectionHeightTextBox"
			Me.selectionHeightTextBox.ReadOnly = True
			Me.selectionHeightTextBox.Size = New System.Drawing.Size(120, 20)
			Me.selectionHeightTextBox.TabIndex = 7
			' 
			' selectionTopTextBox
			' 
			Me.selectionTopTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.selectionTopTextBox.ErrorMessage = Nothing
			Me.selectionTopTextBox.Location = New System.Drawing.Point(112, 48)
			Me.selectionTopTextBox.Name = "selectionTopTextBox"
			Me.selectionTopTextBox.ReadOnly = True
			Me.selectionTopTextBox.Size = New System.Drawing.Size(120, 20)
			Me.selectionTopTextBox.TabIndex = 3
			' 
			' selectionLeftTextBox
			' 
			Me.selectionLeftTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.selectionLeftTextBox.ErrorMessage = Nothing
			Me.selectionLeftTextBox.Location = New System.Drawing.Point(112, 24)
			Me.selectionLeftTextBox.Name = "selectionLeftTextBox"
			Me.selectionLeftTextBox.ReadOnly = True
			Me.selectionLeftTextBox.Size = New System.Drawing.Size(120, 20)
			Me.selectionLeftTextBox.TabIndex = 1
			' 
			' scaleSystemsGroupBox
			' 
			Me.scaleSystemsGroupBox.Controls.Add(Me.label9)
			Me.scaleSystemsGroupBox.Controls.Add(Me.label8)
			Me.scaleSystemsGroupBox.Controls.Add(Me.drawingScaleComboBox)
			Me.scaleSystemsGroupBox.Controls.Add(Me.drawingScaleSystemComboBox)
			Me.scaleSystemsGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.scaleSystemsGroupBox.ImageIndex = 0
			Me.scaleSystemsGroupBox.Location = New System.Drawing.Point(0, 0)
			Me.scaleSystemsGroupBox.Name = "scaleSystemsGroupBox"
			Me.scaleSystemsGroupBox.Size = New System.Drawing.Size(250, 96)
			Me.scaleSystemsGroupBox.TabIndex = 0
			Me.scaleSystemsGroupBox.TabStop = False
			Me.scaleSystemsGroupBox.Text = "Predefined drawing scale systems"
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(8, 56)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(48, 23)
			Me.label9.TabIndex = 3
			Me.label9.Text = "Ratio:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 24)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(48, 23)
			Me.label8.TabIndex = 2
			Me.label8.Text = "System:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' documentSizeGroupBox
			' 
			Me.documentSizeGroupBox.Controls.Add(Me.label1)
			Me.documentSizeGroupBox.Controls.Add(Me.label15)
			Me.documentSizeGroupBox.Controls.Add(Me.documentHeightTextBox)
			Me.documentSizeGroupBox.Controls.Add(Me.documentWidthTextBox)
			Me.documentSizeGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.documentSizeGroupBox.ImageIndex = 0
			Me.documentSizeGroupBox.Location = New System.Drawing.Point(0, 328)
			Me.documentSizeGroupBox.Name = "documentSizeGroupBox"
			Me.documentSizeGroupBox.Size = New System.Drawing.Size(250, 80)
			Me.documentSizeGroupBox.TabIndex = 3
			Me.documentSizeGroupBox.TabStop = False
			Me.documentSizeGroupBox.Text = "Document size in Logical MU"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(96, 23)
			Me.label1.TabIndex = 8
			Me.label1.Text = "Width:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label15
			' 
			Me.label15.Location = New System.Drawing.Point(8, 48)
			Me.label15.Name = "label15"
			Me.label15.Size = New System.Drawing.Size(96, 23)
			Me.label15.TabIndex = 6
			Me.label15.Text = "Height:"
			Me.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' documentWidthTextBox
			' 
			Me.documentWidthTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.documentWidthTextBox.ErrorMessage = Nothing
			Me.documentWidthTextBox.Location = New System.Drawing.Point(112, 24)
			Me.documentWidthTextBox.Name = "documentWidthTextBox"
			Me.documentWidthTextBox.ReadOnly = True
			Me.documentWidthTextBox.Size = New System.Drawing.Size(120, 20)
			Me.documentWidthTextBox.TabIndex = 5
			' 
			' documentHeightTextBox
			' 
			Me.documentHeightTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.documentHeightTextBox.ErrorMessage = Nothing
			Me.documentHeightTextBox.Location = New System.Drawing.Point(112, 48)
			Me.documentHeightTextBox.Name = "documentHeightTextBox"
			Me.documentHeightTextBox.ReadOnly = True
			Me.documentHeightTextBox.Size = New System.Drawing.Size(120, 20)
			Me.documentHeightTextBox.TabIndex = 7
			' 
			' label16
			' 
			Me.label16.Location = New System.Drawing.Point(0, 0)
			Me.label16.Name = "label16"
			Me.label16.TabIndex = 0
			' 
			' NDrawingScaleUC
			' 
			Me.Controls.Add(Me.documentSizeGroupBox)
			Me.Controls.Add(Me.selectionBoundsGroupBox)
			Me.Controls.Add(Me.drawingScaleGroupBox)
			Me.Controls.Add(Me.scaleSystemsGroupBox)
			Me.Name = "NDrawingScaleUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.scaleSystemsGroupBox, 0)
			Me.Controls.SetChildIndex(Me.drawingScaleGroupBox, 0)
			Me.Controls.SetChildIndex(Me.selectionBoundsGroupBox, 0)
			Me.Controls.SetChildIndex(Me.documentSizeGroupBox, 0)
			Me.drawingScaleGroupBox.ResumeLayout(False)
			Me.selectionBoundsGroupBox.ResumeLayout(False)
			Me.scaleSystemsGroupBox.ResumeLayout(False)
			Me.documentSizeGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init view
			view.GlobalVisibility.ShowPorts = False

			' init form controls
			drawingScaleSystemComboBox.Items.Add(New NDrawingScaleSystem(DrawingScaleSystemType.Architectural))
			drawingScaleSystemComboBox.Items.Add(New NDrawingScaleSystem(DrawingScaleSystemType.CivilEngineering))
			drawingScaleSystemComboBox.Items.Add(New NDrawingScaleSystem(DrawingScaleSystemType.Metric))
			drawingScaleSystemComboBox.Items.Add(New NDrawingScaleSystem(DrawingScaleSystemType.MechanicalEngineering))

			' by default select the Architectural system
			drawingScaleSystemComboBox.SelectedIndex = 0
		End Sub

		Protected Overrides Sub AttachToEvents()
			AddHandler document.EventSinkService.NodeBoundsChanged, AddressOf EventSinkService_NodeBoundsChanged

			AddHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			AddHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler document.EventSinkService.NodeBoundsChanged, AddressOf EventSinkService_NodeBoundsChanged

			RemoveHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			RemoveHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.DetachFromEvents()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub CreateSampleDocument(ByVal system As NDrawingScaleSystem, ByVal scale As NDrawingScale)
			' begin init
			document.Reset()
			document.BeginInit()

			' setup drawing scale
			document.DrawingScaleMode = DrawingScaleMode.CustomScale
			document.MeasurementUnit = scale.MeasurementUnit
			document.CustomWorldMeasurementUnit = scale.WorldMeasurementUnit
			document.CustomScale = scale.ScaleFactor

			' create drawing content
			Select Case system.Type
				Case DrawingScaleSystemType.Architectural
					CreateArchitecturalDocument()

				Case DrawingScaleSystemType.CivilEngineering
					CreateCivilEngineeringDocument()

				Case DrawingScaleSystemType.Metric
					CreateMetricDocument()

				Case DrawingScaleSystemType.MechanicalEngineering
					CreateMechanicalEngineeringDocument()

				Case Else
					Debug.Assert(False, "New drawing scale system?")
			End Select

			' end init
			document.EndInit()
			document.UpdateAllViews()
		End Sub


		Private Sub UpdateDocumentBoundsTextBoxes()
			Dim logicalUnit As NMeasurementUnit = document.MeasurementUnit
			Dim displayUnit As NMeasurementUnit = document.CustomWorldMeasurementUnit

			documentWidthTextBox.Text = document.Width.ToString() & " " & logicalUnit.Abbreviation
			documentHeightTextBox.Text = document.Height.ToString() & " " & logicalUnit.Abbreviation
			documentMeasurementUnitTextBox.Text = logicalUnit.Name

			worldMeasurmentUnitTextBox.Text = displayUnit.Name
			drawingScaleTextBox.Text = document.CustomScale.ToString()
		End Sub

		Private Sub UpdateSelectionBoundsTextBoxes()
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))

			If shape Is Nothing Then
				selectionBoundsGroupBox.Visible = False
				selectionWidthTextBox.Text = ""
				selectionHeightTextBox.Text = ""
				selectionTopTextBox.Text = ""
				selectionLeftTextBox.Text = ""
				Return
			End If

			Dim abbreviation As String = document.MeasurementUnit.Abbreviation

			selectionBoundsGroupBox.Visible = True
			selectionWidthTextBox.Text = shape.Width & " " & abbreviation
			selectionHeightTextBox.Text = shape.Height & " " & abbreviation
			selectionTopTextBox.Text = shape.Location.Y & " " & abbreviation
			selectionLeftTextBox.Text = shape.Location.X & " " & abbreviation
		End Sub


		Private Sub CreateArchitecturalDocument()
			' set global document styles
			document.Style.TextStyle = New NTextStyle(New Font("Arial", 8.25f))
			document.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center
			document.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Center

			' create the rim rect
			Dim rimRect As NRectangleShape = New NRectangleShape(New NRectangleF(0, 0, 5, 7))
			rimRect.Style.FillStyle = New NColorFillStyle(Color.FromArgb(0, Color.White))
			document.ActiveLayer.AddChild(rimRect)

			' create the room rects
			Dim roomRect1 As NRectangleShape = New NRectangleShape(New NRectangleF(0, 0, 2, 3))
			roomRect1.Text = "Room 1"
			document.ActiveLayer.AddChild(roomRect1)

			Dim roomRect2 As NRectangleShape = New NRectangleShape(New NRectangleF(3, 0, 2, 3))
			roomRect2.Text = "Room 2"
			document.ActiveLayer.AddChild(roomRect2)

			Dim roomRect3 As NRectangleShape = New NRectangleShape(New NRectangleF(0, 4, 2, 3))
			roomRect3.Text = "Room 3"
			document.ActiveLayer.AddChild(roomRect3)

			' create the stairs case
			Dim stairCase As NCompositeShape = New NCompositeShape()

			Dim stepXSize As Single = 0.7f
			Dim stepYSize As Single = 0.25f
			For i As Integer = 0 To 8
				Dim [step] As NRectanglePath = New NRectanglePath(0, stepYSize * i, stepXSize, stepYSize)
				stairCase.Primitives.AddChild([step])
			Next i

			stairCase.UpdateModelBounds()
			stairCase.Bounds = New NRectangleF(4, 4, 1, 3)

			stairCase.Text = "Stairs"
			Dim textStyle As NTextStyle = (TryCast(document.Style.TextStyle.Clone(), NTextStyle))
			textStyle.Orientation = 90
			stairCase.Style.TextStyle = textStyle

			document.ActiveLayer.AddChild(stairCase)

			' update the drawing bounds to size to content with some margins
			document.AutoBoundsMinSize = New NSizeF(1, 1)
			document.AutoBoundsPadding = New Nevron.Diagram.NMargins(0.5f)
			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent
		End Sub

		Private Sub CreateCivilEngineeringDocument()
			' set global document styles
			document.Style.TextStyle = New NTextStyle(New Font("Arial", 8.25f))
			document.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center
			document.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Center

			' create the rim rect
			Dim rimRect As NRectangleShape = New NRectangleShape(0, 0, 150, 90)
			rimRect.Style.FillStyle = New NColorFillStyle(Color.Green)
			document.ActiveLayer.AddChild(rimRect)

			' create house rect
			Dim houseRect As NRectangleShape = New NRectangleShape(3, 3, 52, 32)
			houseRect.Style.FillStyle = New NColorFillStyle(Color.Firebrick)
			houseRect.Text = "House"
			document.ActiveLayer.AddChild(houseRect)

			' create garage rect
			Dim garageRect As NRectangleShape = New NRectangleShape(New NRectangleF(3, 35, 26, 13))
			garageRect.Style.FillStyle = New NColorFillStyle(Color.Firebrick)
			garageRect.Text = "Garage"
			document.ActiveLayer.AddChild(garageRect)

			' create the pool ellipse
			Dim poolEllipse As NEllipseShape = New NEllipseShape(New NRectangleF(60, 3, 75, 75))
			poolEllipse.Style.FillStyle = New NColorFillStyle(Color.LightBlue)
			poolEllipse.Labels.DefaultLabel.Text = "Pool"
			document.ActiveLayer.AddChild(poolEllipse)

			' update the drawing bounds to size to content with some margins
			document.AutoBoundsMinSize = New NSizeF(1, 1)
			document.AutoBoundsPadding = New Nevron.Diagram.NMargins(1.5f)
			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent
		End Sub

		Private Sub CreateMetricDocument()
			' set global document styles
			document.Style.TextStyle = New NTextStyle(New Font("Arial", 8.25f))
			document.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center
			document.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Center

			' create the rim rect
			Dim rimRect As NRectangleShape = New NRectangleShape(0, 0, 140, 140)
			rimRect.Style.FillStyle = New NColorFillStyle(Color.Gray)
			document.ActiveLayer.AddChild(rimRect)

			' create block 1
			Dim block1 As NRectangleShape = New NRectangleShape(New NRectangleF(0, 0, 68, 68))
			block1.Style.FillStyle = New NColorFillStyle(Color.Firebrick)
			block1.Text = "Block 1"
			document.ActiveLayer.AddChild(block1)

			' create block 2
			Dim block2 As NRectangleShape = New NRectangleShape(New NRectangleF(72, 0, 68, 68))
			block2.Style.FillStyle = New NColorFillStyle(Color.Firebrick)
			block2.Text = "Block 2"
			document.ActiveLayer.AddChild(block2)

			' create block 3
			Dim block3 As NRectangleShape = New NRectangleShape(New NRectangleF(0, 72, 68, 68))
			block3.Style.FillStyle = New NColorFillStyle(Color.Firebrick)
			block3.Text = "Block 3"
			document.ActiveLayer.AddChild(block3)

			' create block 3
			Dim block4 As NRectangleShape = New NRectangleShape(New NRectangleF(72, 72, 68, 68))
			block4.Style.FillStyle = New NColorFillStyle(Color.Firebrick)
			block4.Text = "Block 4"
			document.ActiveLayer.AddChild(block4)

			' update the drawing bounds to size to content with some margins
			document.AutoBoundsMinSize = New NSizeF(1, 1)
			document.AutoBoundsPadding = New Nevron.Diagram.NMargins(5f)
			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent
		End Sub

		Private Sub CreateMechanicalEngineeringDocument()
			' create the key shape
			Dim key As NCompositeShape = New NCompositeShape()

			Dim keyRect As NRectanglePath = New NRectanglePath(New NRectangleF(12.5f, 30, 5f, 50))
			key.Primitives.AddChild(keyRect)

			Dim keyCircle As NEllipsePath = New NEllipsePath(New NRectangleF(0, 0, 30, 30))
			key.Primitives.AddChild(keyCircle)

			Dim keyHole As NEllipsePath = New NEllipsePath(New NRectangleF(13f, 2f, 4f, 4f))
			NStyle.SetFillStyle(keyHole, New NColorFillStyle(Color.White))
			NStyle.SetStrokeStyle(keyHole, New NStrokeStyle(0, Color.Black))
			key.Primitives.AddChild(keyHole)

			key.UpdateModelBounds()
			key.Style.FillStyle = New NColorFillStyle(Color.DarkGray)
			key.Style.StrokeStyle = New NStrokeStyle(0, Color.Black)

			document.ActiveLayer.AddChild(key)

			' create the octagram
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim octagram As NShape = factory.CreateShape(CInt(Fix(BasicShapes.Octagram)))

			octagram.Bounds = New NRectangleF(40, 0, 40, 40)
			octagram.Style.FillStyle = New NColorFillStyle(Color.DarkGray)
			octagram.Style.StrokeStyle = New NStrokeStyle(0, Color.Black)

			document.ActiveLayer.AddChild(octagram)

			' update the drawing bounds to size to content with some margins
			document.AutoBoundsMinSize = New NSizeF(1, 1)
			document.AutoBoundsPadding = New Nevron.Diagram.NMargins(5f)
			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub drawingScaleSystemComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drawingScaleSystemComboBox.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()

			' get the current system
			Dim system As NDrawingScaleSystem = (TryCast(drawingScaleSystemComboBox.SelectedItem, NDrawingScaleSystem))

			' refill the drawing scale combo
			drawingScaleComboBox.Items.Clear()
			For Each drawingScale As NDrawingScale In system.DrawingScales
				drawingScaleComboBox.Items.Add(drawingScale)
			Next drawingScale

			' select the default drawing scale
			Dim scale As NDrawingScale = system.DefaultDrawingScale
			drawingScaleComboBox.SelectedItem = scale

			' create sample document
			view.Selection.DeselectAll()
			CreateSampleDocument(system, scale)

			' update the document bounds text boxes
			UpdateDocumentBoundsTextBoxes()

			' update the selection bounds text boxes
			UpdateSelectionBoundsTextBoxes()

			ResumeEventsHandling()
		End Sub

		Private Sub drawingScaleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drawingScaleComboBox.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()

			Dim scale As NDrawingScale = (TryCast(drawingScaleComboBox.SelectedItem, NDrawingScale))

			' update the drawing scale
			document.MeasurementUnit = scale.MeasurementUnit
			document.CustomWorldMeasurementUnit = scale.WorldMeasurementUnit
			document.CustomScale = scale.ScaleFactor

			' update the document bounds text boxes
			UpdateDocumentBoundsTextBoxes()

			' update the selection bounds text boxes
			UpdateSelectionBoundsTextBoxes()

			ResumeEventsHandling()
		End Sub


		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			UpdateSelectionBoundsTextBoxes()
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			UpdateSelectionBoundsTextBoxes()
		End Sub

		Private Sub EventSinkService_NodeBoundsChanged(ByVal args As NNodeEventArgs)
			UpdateSelectionBoundsTextBoxes()
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private label7 As System.Windows.Forms.Label
		Private drawingScaleTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents drawingScaleSystemComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents drawingScaleComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private selectionWidthTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private selectionHeightTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private selectionTopTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private selectionLeftTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private documentMeasurementUnitTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private worldMeasurmentUnitTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label10 As System.Windows.Forms.Label
		Private label11 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private documentWidthTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private documentHeightTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label15 As System.Windows.Forms.Label
		Private label16 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private drawingScaleGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private selectionBoundsGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private scaleSystemsGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private documentSizeGroupBox As Nevron.UI.WinForm.Controls.NGroupBox

		#End Region
	End Class

	''' <summary>
	''' Enumerates the predefined drawing scale systems
	''' </summary>
	Public Enum DrawingScaleSystemType
		Architectural
		CivilEngineering
		Metric
		MechanicalEngineering
	End Enum

	''' <summary>
	''' Summary description for NDrawingScaleSystem.
	''' </summary>
	Public Class NDrawingScaleSystem
		#Region "Constructors"

		''' <summary>
		''' Initializer constructor
		''' </summary>
		''' <param name="system"></param>
		Public Sub New(ByVal systemType As DrawingScaleSystemType)
			Type = systemType

			Select Case systemType
				Case DrawingScaleSystemType.Architectural
					InitArchitectural()

				Case DrawingScaleSystemType.CivilEngineering
					InitCivilEngineering()

				Case DrawingScaleSystemType.Metric
					InitMetric()

				Case DrawingScaleSystemType.MechanicalEngineering
					InitMechanicalEngineering()

				Case Else
					Debug.Assert(False, "New drawing scale system?")
			End Select
		End Sub


		#End Region

		#Region "Protected"

		Private Sub InitArchitectural()
			Name = "Architectural"

			DrawingScales = New NDrawingScale() { New NDrawingScale("3/32"" = 1'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.09375f, False), New NDrawingScale("1/8"" = 1'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.125f, False), New NDrawingScale("3/16"" = 1'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.1875f, False), New NDrawingScale("1/4"" = 1'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.25f, False), New NDrawingScale("3/8"" = 1'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.375f, False), New NDrawingScale("1/2"" = 1'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.5f, True), New NDrawingScale("3/4"" = 1'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.75f, False), New NDrawingScale("1"" = 1'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 1f, False), New NDrawingScale("1 1/2"" = 1'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 1.5f, False), New NDrawingScale("3"" = 1'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 3f, False), New NDrawingScale("1' = 1'0""", NEnglishUnit.Foot, NEnglishUnit.Foot, 1f, False) }
		End Sub

		Private Sub InitCivilEngineering()
			Name = "Civil Engineering"

			DrawingScales = New NDrawingScale() { New NDrawingScale("1"" = 100'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.01f, False), New NDrawingScale("1"" = 90'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.0111111111f, False), New NDrawingScale("1"" = 80'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.0125f, False), New NDrawingScale("1"" = 70'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.0142857143f, False), New NDrawingScale("1"" = 60'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.01666666667f, False), New NDrawingScale("1"" = 50'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.02f, False), New NDrawingScale("1"" = 40'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.025f, False), New NDrawingScale("1"" = 30'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.03333333333f, True), New NDrawingScale("1"" = 20'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.05f, False), New NDrawingScale("1"" = 10'0""", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.1f, False), New NDrawingScale("1"" = 1""", NEnglishUnit.Inch, NEnglishUnit.Foot, 12, False) }
		End Sub

		Private Sub InitMetric()
			Name = "Metric"

			DrawingScales = New NDrawingScale() { New NDrawingScale("1:1000", NMetricUnit.Millimeter, NMetricUnit.Meter, 1f, True), New NDrawingScale("1:500", NMetricUnit.Millimeter, NMetricUnit.Meter, 2f, False), New NDrawingScale("1:200", NMetricUnit.Millimeter, NMetricUnit.Meter, 5f, False), New NDrawingScale("1:100", NMetricUnit.Centimeter, NMetricUnit.Meter, 1f, False), New NDrawingScale("1:50", NMetricUnit.Centimeter, NMetricUnit.Meter, 2f, False), New NDrawingScale("1:25", NMetricUnit.Centimeter, NMetricUnit.Meter, 4f, False), New NDrawingScale("1:20", NMetricUnit.Centimeter, NMetricUnit.Meter, 5f, False), New NDrawingScale("1:10", NMetricUnit.Centimeter, NMetricUnit.Meter, 10f, False), New NDrawingScale("1:5", NMetricUnit.Centimeter, NMetricUnit.Meter, 20f, False), New NDrawingScale("1:2.5", NMetricUnit.Centimeter, NMetricUnit.Meter, 40f, False), New NDrawingScale("1:2", NMetricUnit.Centimeter, NMetricUnit.Meter, 50f, False), New NDrawingScale("1:1", NMetricUnit.Meter, NMetricUnit.Meter, 1f, False), New NDrawingScale("10:1", NMetricUnit.Meter, NMetricUnit.Meter, 10f, False), New NDrawingScale("20:1", NMetricUnit.Meter, NMetricUnit.Meter, 20f, False), New NDrawingScale("50:1", NMetricUnit.Meter, NMetricUnit.Meter, 50f, False), New NDrawingScale("100:1", NMetricUnit.Meter, NMetricUnit.Meter, 100f, False) }
		End Sub

		Private Sub InitMechanicalEngineering()
			Name = "Mechanical Engineering"

			DrawingScales = New NDrawingScale() { New NDrawingScale("1/32:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 0.03125f, False), New NDrawingScale("1/16:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 0.0625f, False), New NDrawingScale("1/8:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 0.125f, False), New NDrawingScale("1/4:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 0.25f, False), New NDrawingScale("1/2:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 0.5f, False), New NDrawingScale("1:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 1.0f, True), New NDrawingScale("2:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 2.0f, False), New NDrawingScale("4:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 4.0f, False), New NDrawingScale("6:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 6.0f, False), New NDrawingScale("8:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 8.0f, False), New NDrawingScale("10:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 10.0f, False) }
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides Function ToString() As String
			Return Name
		End Function

		#End Region

		#Region "Properties"

		''' <summary>
		''' Gets the default drawing scale for this system
		''' </summary>
		Public ReadOnly Property DefaultDrawingScale() As NDrawingScale
			Get
				Dim i As Integer = 0
				Do While i < DrawingScales.Length
					Dim drawingScale As NDrawingScale = DrawingScales(i)
					If drawingScale.IsDefault Then
						Return drawingScale
					End If
					i += 1
				Loop

				Return DrawingScales(0)
			End Get
		End Property


		#End Region

		#Region "Fields"

		''' <summary>
		''' System type
		''' </summary>
		Public Type As DrawingScaleSystemType
		''' <summary>
		''' System name
		''' </summary>
		Public Name As String
		''' <summary>
		''' Drawing scales
		''' </summary>
		Public DrawingScales As NDrawingScale()

		#End Region
	End Class

	''' <summary>
	''' The NDrawingScale class represents a drawing scale in the context of a predefined drawing scale system
	''' </summary>
	Public Class NDrawingScale
		#Region "Constructors"

		''' <summary>
		''' Initializer constructor
		''' </summary>
		''' <param name="name"></param>
		''' <param name="worldMeasurementUnit"></param>
		''' <param name="measurementUnit"></param>
		''' <param name="factor"></param>
		''' <param name="isDefault"></param>
'INSTANT VB NOTE: The parameter name was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter worldMeasurementUnit was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter measurementUnit was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter isDefault was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
		Public Sub New(ByVal name_Renamed As String, ByVal worldMeasurementUnit_Renamed As NMeasurementUnit, ByVal measurementUnit_Renamed As NMeasurementUnit, ByVal factor As Single, ByVal isDefault_Renamed As Boolean)
			Name = name_Renamed
			MeasurementUnit = measurementUnit_Renamed
			WorldMeasurementUnit = worldMeasurementUnit_Renamed
			ScaleFactor = factor
			IsDefault = isDefault_Renamed
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides Function ToString() As String
			Return Name
		End Function


		#End Region

		#Region "Fields"

		''' <summary>
		''' Name
		''' </summary>
		Public Name As String
		''' <summary>
		''' Logical measurement unit
		''' </summary>
		Public MeasurementUnit As NMeasurementUnit
		''' <summary>
		''' Display measurement unit
		''' </summary>
		Public WorldMeasurementUnit As NMeasurementUnit
		''' <summary>
		''' Scale factor (ratio between logical and display units)
		''' </summary>
		Public ScaleFactor As Single
		''' <summary>
		''' Whether this is the default scale for the system in which the scale resides
		''' </summary>
		Public IsDefault As Boolean

		#End Region
	End Class
End Namespace
