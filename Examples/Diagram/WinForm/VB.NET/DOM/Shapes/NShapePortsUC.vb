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
	''' Summary description for NShapePortsUC.
	''' </summary>
	Public Class NShapePortsUC
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
			Me.portOperationsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.disconnectPortButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.portPropertiesGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.anchorIdComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.portOffsetYNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.portOffsetXNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.percentPositionNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.alignmentComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.dynamicPortGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.dynamicPortGlueModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.boundsPortGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.pointPortGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.customPointIndexNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.portIndexModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.logicalLinePortGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.portOperationsGroup.SuspendLayout()
			Me.portPropertiesGroup.SuspendLayout()
			CType(Me.portOffsetYNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.portOffsetXNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.percentPositionNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.dynamicPortGroup.SuspendLayout()
			Me.boundsPortGroup.SuspendLayout()
			Me.pointPortGroup.SuspendLayout()
			CType(Me.customPointIndexNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.logicalLinePortGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' portOperationsGroup
			' 
			Me.portOperationsGroup.Controls.Add(Me.disconnectPortButton)
			Me.portOperationsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.portOperationsGroup.Enabled = False
			Me.portOperationsGroup.ImageIndex = 0
			Me.portOperationsGroup.Location = New System.Drawing.Point(0, 0)
			Me.portOperationsGroup.Name = "portOperationsGroup"
			Me.portOperationsGroup.Size = New System.Drawing.Size(250, 64)
			Me.portOperationsGroup.TabIndex = 0
			Me.portOperationsGroup.TabStop = False
			Me.portOperationsGroup.Text = "Port operations"
			' 
			' disconnectPortButton
			' 
			Me.disconnectPortButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.disconnectPortButton.Location = New System.Drawing.Point(8, 24)
			Me.disconnectPortButton.Name = "disconnectPortButton"
			Me.disconnectPortButton.Size = New System.Drawing.Size(234, 24)
			Me.disconnectPortButton.TabIndex = 0
			Me.disconnectPortButton.Text = "Disconnect All Plugs"
'			Me.disconnectPortButton.Click += New System.EventHandler(Me.disconnectPortButton_Click);
			' 
			' portPropertiesGroup
			' 
			Me.portPropertiesGroup.Controls.Add(Me.label3)
			Me.portPropertiesGroup.Controls.Add(Me.anchorIdComboBox)
			Me.portPropertiesGroup.Controls.Add(Me.portOffsetYNumeric)
			Me.portPropertiesGroup.Controls.Add(Me.label7)
			Me.portPropertiesGroup.Controls.Add(Me.label8)
			Me.portPropertiesGroup.Controls.Add(Me.portOffsetXNumeric)
			Me.portPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.portPropertiesGroup.Enabled = False
			Me.portPropertiesGroup.ImageIndex = 0
			Me.portPropertiesGroup.Location = New System.Drawing.Point(0, 64)
			Me.portPropertiesGroup.Name = "portPropertiesGroup"
			Me.portPropertiesGroup.Size = New System.Drawing.Size(250, 112)
			Me.portPropertiesGroup.TabIndex = 1
			Me.portPropertiesGroup.TabStop = False
			Me.portPropertiesGroup.Text = "Common port properties"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 24)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(72, 23)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Port anchor:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' anchorIdComboBox
			' 
			Me.anchorIdComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.anchorIdComboBox.Location = New System.Drawing.Point(80, 24)
			Me.anchorIdComboBox.Name = "anchorIdComboBox"
			Me.anchorIdComboBox.Size = New System.Drawing.Size(160, 22)
			Me.anchorIdComboBox.TabIndex = 1
			Me.anchorIdComboBox.Text = "nComboBox1"
'			Me.anchorIdComboBox.SelectedIndexChanged += New System.EventHandler(Me.anchorIdComboBox_SelectedIndexChanged);
			' 
			' portOffsetYNumeric
			' 
			Me.portOffsetYNumeric.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.portOffsetYNumeric.Location = New System.Drawing.Point(150, 80)
			Me.portOffsetYNumeric.Maximum = New System.Decimal(New Integer() { 10000, 0, 0, 0})
			Me.portOffsetYNumeric.Minimum = New System.Decimal(New Integer() { 10000, 0, 0, -2147483648})
			Me.portOffsetYNumeric.Name = "portOffsetYNumeric"
			Me.portOffsetYNumeric.Size = New System.Drawing.Size(90, 22)
			Me.portOffsetYNumeric.TabIndex = 6
'			Me.portOffsetYNumeric.ValueChanged += New System.EventHandler(Me.portOffsetYNumeric_ValueChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(80, 80)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(64, 23)
			Me.label7.TabIndex = 5
			Me.label7.Text = "Offset Y:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(80, 56)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(64, 23)
			Me.label8.TabIndex = 3
			Me.label8.Text = "Offset X:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' portOffsetXNumeric
			' 
			Me.portOffsetXNumeric.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.portOffsetXNumeric.Location = New System.Drawing.Point(150, 56)
			Me.portOffsetXNumeric.Maximum = New System.Decimal(New Integer() { 10000, 0, 0, 0})
			Me.portOffsetXNumeric.Minimum = New System.Decimal(New Integer() { 10000, 0, 0, -2147483648})
			Me.portOffsetXNumeric.Name = "portOffsetXNumeric"
			Me.portOffsetXNumeric.Size = New System.Drawing.Size(90, 22)
			Me.portOffsetXNumeric.TabIndex = 4
'			Me.portOffsetXNumeric.ValueChanged += New System.EventHandler(Me.portOffsetXNumeric_ValueChanged);
			' 
			' percentPositionNumeric
			' 
			Me.percentPositionNumeric.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.percentPositionNumeric.Location = New System.Drawing.Point(112, 24)
			Me.percentPositionNumeric.Name = "percentPositionNumeric"
			Me.percentPositionNumeric.Size = New System.Drawing.Size(128, 22)
			Me.percentPositionNumeric.TabIndex = 1
'			Me.percentPositionNumeric.ValueChanged += New System.EventHandler(Me.percentPositionNumeric_ValueChanged);
			' 
			' alignmentComboBox
			' 
			Me.alignmentComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.alignmentComboBox.Location = New System.Drawing.Point(80, 24)
			Me.alignmentComboBox.Name = "alignmentComboBox"
			Me.alignmentComboBox.Size = New System.Drawing.Size(160, 22)
			Me.alignmentComboBox.TabIndex = 1
			Me.alignmentComboBox.Text = "nComboBox1"
'			Me.alignmentComboBox.SelectedIndexChanged += New System.EventHandler(Me.alignmentComboBox_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 24)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(64, 23)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Alignment:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 23)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(104, 23)
			Me.label5.TabIndex = 0
			Me.label5.Text = "Percent position:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' dynamicPortGroup
			' 
			Me.dynamicPortGroup.Controls.Add(Me.label6)
			Me.dynamicPortGroup.Controls.Add(Me.dynamicPortGlueModeCombo)
			Me.dynamicPortGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.dynamicPortGroup.ImageIndex = 0
			Me.dynamicPortGroup.Location = New System.Drawing.Point(0, 176)
			Me.dynamicPortGroup.Name = "dynamicPortGroup"
			Me.dynamicPortGroup.Size = New System.Drawing.Size(250, 64)
			Me.dynamicPortGroup.TabIndex = 2
			Me.dynamicPortGroup.TabStop = False
			Me.dynamicPortGroup.Text = "Dynamic port properties"
			Me.dynamicPortGroup.Visible = False
			' 
			' dynamicPortGlueModeCombo
			' 
			Me.dynamicPortGlueModeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.dynamicPortGlueModeCombo.Location = New System.Drawing.Point(80, 24)
			Me.dynamicPortGlueModeCombo.Name = "dynamicPortGlueModeCombo"
			Me.dynamicPortGlueModeCombo.Size = New System.Drawing.Size(160, 22)
			Me.dynamicPortGlueModeCombo.TabIndex = 1
			Me.dynamicPortGlueModeCombo.Text = "Glue To Countour"
'			Me.dynamicPortGlueModeCombo.SelectedIndexChanged += New System.EventHandler(Me.dynamicPortGlueModeCombo_SelectedIndexChanged);
			' 
			' boundsPortGroup
			' 
			Me.boundsPortGroup.Controls.Add(Me.label4)
			Me.boundsPortGroup.Controls.Add(Me.alignmentComboBox)
			Me.boundsPortGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.boundsPortGroup.ImageIndex = 0
			Me.boundsPortGroup.Location = New System.Drawing.Point(0, 240)
			Me.boundsPortGroup.Name = "boundsPortGroup"
			Me.boundsPortGroup.Size = New System.Drawing.Size(250, 64)
			Me.boundsPortGroup.TabIndex = 3
			Me.boundsPortGroup.TabStop = False
			Me.boundsPortGroup.Text = "Bounds/rotated bounds port properties"
			Me.boundsPortGroup.Visible = False
			' 
			' pointPortGroup
			' 
			Me.pointPortGroup.Controls.Add(Me.customPointIndexNumeric)
			Me.pointPortGroup.Controls.Add(Me.portIndexModeComboBox)
			Me.pointPortGroup.Controls.Add(Me.label1)
			Me.pointPortGroup.Controls.Add(Me.label2)
			Me.pointPortGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.pointPortGroup.ImageIndex = 0
			Me.pointPortGroup.Location = New System.Drawing.Point(0, 304)
			Me.pointPortGroup.Name = "pointPortGroup"
			Me.pointPortGroup.Size = New System.Drawing.Size(250, 88)
			Me.pointPortGroup.TabIndex = 4
			Me.pointPortGroup.TabStop = False
			Me.pointPortGroup.Text = "Point port properties"
			Me.pointPortGroup.Visible = False
			' 
			' customPointIndexNumeric
			' 
			Me.customPointIndexNumeric.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.customPointIndexNumeric.Location = New System.Drawing.Point(112, 56)
			Me.customPointIndexNumeric.Maximum = New System.Decimal(New Integer() { 10000, 0, 0, 0})
			Me.customPointIndexNumeric.Minimum = New System.Decimal(New Integer() { 1, 0, 0, -2147483648})
			Me.customPointIndexNumeric.Name = "customPointIndexNumeric"
			Me.customPointIndexNumeric.Size = New System.Drawing.Size(128, 22)
			Me.customPointIndexNumeric.TabIndex = 3
'			Me.customPointIndexNumeric.ValueChanged += New System.EventHandler(Me.customPointIndexNumeric_ValueChanged);
			' 
			' portIndexModeComboBox
			' 
			Me.portIndexModeComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.portIndexModeComboBox.Location = New System.Drawing.Point(112, 24)
			Me.portIndexModeComboBox.Name = "portIndexModeComboBox"
			Me.portIndexModeComboBox.Size = New System.Drawing.Size(128, 22)
			Me.portIndexModeComboBox.TabIndex = 1
			Me.portIndexModeComboBox.Text = "nComboBox1"
'			Me.portIndexModeComboBox.SelectedIndexChanged += New System.EventHandler(Me.portIndexModeComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(104, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Port index mode:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 55)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(104, 23)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Custom point index:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' logicalLinePortGroup
			' 
			Me.logicalLinePortGroup.Controls.Add(Me.percentPositionNumeric)
			Me.logicalLinePortGroup.Controls.Add(Me.label5)
			Me.logicalLinePortGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.logicalLinePortGroup.ImageIndex = 0
			Me.logicalLinePortGroup.Location = New System.Drawing.Point(0, 392)
			Me.logicalLinePortGroup.Name = "logicalLinePortGroup"
			Me.logicalLinePortGroup.Size = New System.Drawing.Size(250, 56)
			Me.logicalLinePortGroup.TabIndex = 5
			Me.logicalLinePortGroup.TabStop = False
			Me.logicalLinePortGroup.Text = "Logical line port properties"
			Me.logicalLinePortGroup.Visible = False
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 24)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(64, 23)
			Me.label6.TabIndex = 2
			Me.label6.Text = "Glue mode:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NShapePortsUC
			' 
			Me.Controls.Add(Me.logicalLinePortGroup)
			Me.Controls.Add(Me.pointPortGroup)
			Me.Controls.Add(Me.boundsPortGroup)
			Me.Controls.Add(Me.dynamicPortGroup)
			Me.Controls.Add(Me.portPropertiesGroup)
			Me.Controls.Add(Me.portOperationsGroup)
			Me.Name = "NShapePortsUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.portOperationsGroup, 0)
			Me.Controls.SetChildIndex(Me.portPropertiesGroup, 0)
			Me.Controls.SetChildIndex(Me.dynamicPortGroup, 0)
			Me.Controls.SetChildIndex(Me.boundsPortGroup, 0)
			Me.Controls.SetChildIndex(Me.pointPortGroup, 0)
			Me.Controls.SetChildIndex(Me.logicalLinePortGroup, 0)
			Me.portOperationsGroup.ResumeLayout(False)
			Me.portPropertiesGroup.ResumeLayout(False)
			CType(Me.portOffsetYNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.portOffsetXNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.percentPositionNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.dynamicPortGroup.ResumeLayout(False)
			Me.boundsPortGroup.ResumeLayout(False)
			Me.pointPortGroup.ResumeLayout(False)
			CType(Me.customPointIndexNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.logicalLinePortGroup.ResumeLayout(False)
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

			Dim handlesSize As NSizeF = New NSizeF(5, 5)
			view.TrackersAppearance.RotatedBoundsHandlesStyle.Size = handlesSize
			view.TrackersAppearance.RotatorHandlesStyle.Size = handlesSize
			view.TrackersAppearance.PinHandlesStyle.Size = handlesSize
			view.TrackersAppearance.GeometryBasePointHandlesStyle.Size = handlesSize
			view.TrackersAppearance.GeometryMidPointHandlesStyle.Size = handlesSize
			view.TrackersAppearance.ShapeControlPointHandlesStyle.Size = handlesSize
			view.TrackersAppearance.ShapeStartPlugHandlesStyle.Size = handlesSize
			view.TrackersAppearance.ShapeEndPlugHandlesStyle.Size = handlesSize

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

			alignmentComboBox.FillFromEnum(GetType(ContentAlignment))
			alignmentComboBox.SelectedItem = ContentAlignment.TopLeft

			portIndexModeComboBox.FillFromEnum(GetType(PointIndexMode))
			portIndexModeComboBox.SelectedItem = PointIndexMode.First

			dynamicPortGlueModeCombo.FillFromEnum(GetType(DynamicPortGlueMode))
			dynamicPortGlueModeCombo.SelectedItem = DynamicPortGlueMode.GlueToContour

			ResumeEventsHandling()
		End Sub

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
			CreateCenterShape()
			CreateShapeWithDynamicPort()
			CreateShapeWithBoundsPort()
			CreateShapeWithRotatedBoundsPort()
			CreateShapeWithPointPort()
			CreateShapeWithLogicalLinePort()
			CreateArrowShapeWithLogicalLinePort()
		End Sub


		Private Sub CreateCenterShape()
			' create the center shape to which all other shapes connect
			Dim cell As NRectangleF = MyBase.GetGridCell(3, 0)
			cell.Inflate(-5, -5)

			Dim shape As NEllipseShape = New NEllipseShape(cell)
			shape.Name = "Center shape"

			shape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, 0, &Hbb, 0))
			shape.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(0, &Hbb, 0))

			shape.CreateShapeElements(ShapeElementsMask.Ports)

			Dim port As NDynamicPort = New NDynamicPort(shape.UniqueId, ContentAlignment.MiddleCenter, DynamicPortGlueMode.GlueToContour)
			shape.Ports.AddChild(port)
			shape.Ports.DefaultInwardPortUniqueId = port.UniqueId

			' add it to the active layer and store for reuse
			document.ActiveLayer.AddChild(shape)
			centerShape = shape
		End Sub

		Private Sub CreateShapeWithDynamicPort()
			' NOTE: the triangle shape is by default created with one dynamic port (the default one) and 
			' three rotated bounds ports located at the triangle vertices).
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(BasicShapes.Triangle)))
			shape.Name = "Shape with Dynamic Port"
			shape.Bounds = MyBase.GetGridCell(0, 1)

			' connect it with the center shape
			document.ActiveLayer.AddChild(shape)
			ConnectShapes(centerShape, shape)

			' describe it
			Dim text As NTextShape = New NTextShape("Shape with Dynamic Port", MyBase.GetGridCell(0, 2, 0, 1))
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateShapeWithBoundsPort()
			' create a shape with one bounds port
			Dim shape As NRectangleShape = New NRectangleShape(MyBase.GetGridCell(1, 1))
			shape.Name = "Shape with Bounds Port"

			shape.CreateShapeElements(ShapeElementsMask.Ports)

			Dim port As NBoundsPort = New NBoundsPort(shape.UniqueId, ContentAlignment.TopLeft)
			shape.Ports.AddChild(port)
			shape.Ports.DefaultInwardPortUniqueId = port.UniqueId

			' connect it with the center shape
			document.ActiveLayer.AddChild(shape)
			ConnectShapes(centerShape, shape)

			' describe it
			Dim text As NTextShape = New NTextShape("Shape with Bounds Port", MyBase.GetGridCell(1, 2, 0, 1))
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateShapeWithRotatedBoundsPort()
			' create a shape with one rotated bounds port
			Dim shape As NRectangleShape = New NRectangleShape(MyBase.GetGridCell(2, 1))
			shape.Name = "Shape with Rotated Bounds Port"

			shape.CreateShapeElements(ShapeElementsMask.Ports)

			Dim port As NRotatedBoundsPort = New NRotatedBoundsPort(shape.UniqueId, ContentAlignment.TopLeft)
			shape.Ports.AddChild(port)
			shape.Ports.DefaultInwardPortUniqueId = port.UniqueId

			' connect it with the center shape
			document.ActiveLayer.AddChild(shape)
			ConnectShapes(centerShape, shape)

			' describe it
			Dim text As NTextShape = New NTextShape("Shape with Rotated Bounds Port", MyBase.GetGridCell(2, 2, 0, 1))
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateShapeWithPointPort()
			' create a shape with one point port
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(BasicShapes.Pentagram)))

			shape.Name = "Shape with a Point Port"
			shape.Bounds = MyBase.GetGridCell(4, 1)

			Dim port As NPointPort = New NPointPort(shape.UniqueId, PointIndexMode.Second, -1)

			shape.Ports.RemoveAllChildren()
			shape.Ports.AddChild(port)
			shape.Ports.DefaultInwardPortUniqueId = port.UniqueId

			' connect it with the center shape
			document.ActiveLayer.AddChild(shape)
			ConnectShapes(centerShape, shape)

			' describe it
			Dim text As NTextShape = New NTextShape("Shape with Point Port", MyBase.GetGridCell(4, 2, 0, 1))
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateShapeWithLogicalLinePort()
			Dim points As NPointF() = New NPointF(){ New NPointF(151, 291), New NPointF(151, 316), New NPointF(123, 336), New NPointF(151, 350), New NPointF(158, 319), New NPointF(180, 312)}

			' create a polyline shape with a logical line port
			Dim shape As NPolylineShape = New NPolylineShape(points)
			shape.Name = "Shape with a Logical Line Port"
			shape.Bounds = MyBase.GetGridCell(5, 1)

			' create the ports
			shape.CreateShapeElements(ShapeElementsMask.Ports)

			Dim port As NLogicalLinePort = New NLogicalLinePort(shape.UniqueId, 30)
			shape.Ports.RemoveAllChildren()
			shape.Ports.AddChild(port)
			shape.Ports.DefaultInwardPortUniqueId = port.UniqueId

			' connect it with the center shape
			document.ActiveLayer.AddChild(shape)
			ConnectShapes(centerShape, shape)

			' descibte it
			Dim text As NTextShape = New NTextShape("Shape with Logical Line Port", MyBase.GetGridCell(5, 2, 0, 1))
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateArrowShapeWithLogicalLinePort()
			' create a filled graph connector with one logical line port
			Dim shape As NArrowShape = New NArrowShape(ArrowType.DoubleArrow, New NPointF(15, 380), New NPointF(55, 420), 10, 45, 30)
			shape.Bounds = MyBase.GetGridCell(6, 1)
			shape.Name = "Filled shape with Stroke Port"

			' create the ports
			shape.CreateShapeElements(ShapeElementsMask.Ports)

			Dim port As NLogicalLinePort = New NLogicalLinePort(shape.UniqueId, 30)
			shape.Ports.RemoveAllChildren()
			shape.Ports.AddChild(port)
			shape.Ports.DefaultInwardPortUniqueId = port.UniqueId

			' connect it with the center shape
			document.ActiveLayer.AddChild(shape)
			ConnectShapes(centerShape, shape)

			' descibte it
			Dim text As NTextShape = New NTextShape("Shape with Logical Line Port", MyBase.GetGridCell(6, 2, 0, 1))
			document.ActiveLayer.AddChild(text)
		End Sub


		Private Sub ConnectShapes(ByVal shape1 As NShape, ByVal shape2 As NShape)
			Dim connector As NStep2Connector = New NStep2Connector(True)
			connector.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector)

			connector.FromShape = shape1
			connector.ToShape = shape2
		End Sub

		Private Sub UpdateControlsState()
			' only single selection is processed
			If view.Selection.Nodes.Count <> 1 Then
				DisablePortControls()
				Return
			End If

			' check to see if the selected node is a shape and its defualt port is valid
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing OrElse shape.Ports Is Nothing OrElse shape.Ports.DefaultInwardPort Is Nothing Then
				DisablePortControls()
				Return
			End If

			' enable the common operations and properties groups
			portOperationsGroup.Enabled = True
			portPropertiesGroup.Enabled = True

			' get the shape default port
			Dim defaultPort As NPort = shape.Ports.DefaultInwardPort

			' update the general port properties
			UpdatePortGeneralPropertiesControls(defaultPort)

			' update dynamic port specific
			If TypeOf defaultPort Is NDynamicPort Then
				dynamicPortGroup.Visible = True
				Dim port As NDynamicPort = TryCast(defaultPort, NDynamicPort)
				dynamicPortGlueModeCombo.SelectedItem = port.GlueMode
			Else
				dynamicPortGroup.Visible = False
			End If

			' update bounds port specific
			If TypeOf defaultPort Is NBoundsPort OrElse TypeOf defaultPort Is NRotatedBoundsPort Then
				boundsPortGroup.Visible = True
				If TypeOf defaultPort Is NBoundsPort Then
					alignmentComboBox.SelectedItem = (TryCast(defaultPort, NBoundsPort)).Alignment
				Else
					alignmentComboBox.SelectedItem = (TryCast(defaultPort, NRotatedBoundsPort)).Alignment
				End If
			Else
				boundsPortGroup.Visible = False
			End If

			' update point port specific
			If TypeOf defaultPort Is NPointPort Then
				pointPortGroup.Visible = True
				portIndexModeComboBox.SelectedItem = (TryCast(defaultPort, NPointPort)).PointIndexMode
				customPointIndexNumeric.Value = (TryCast(defaultPort, NPointPort)).CustomPointIndex
			Else
				pointPortGroup.Visible = False
			End If

			' update logical line port specific
			If TypeOf defaultPort Is NLogicalLinePort Then
				logicalLinePortGroup.Visible = True
				percentPositionNumeric.Value = CDec((TryCast(defaultPort, NLogicalLinePort)).Percent)
			Else
				logicalLinePortGroup.Visible = False
			End If
		End Sub

		Private Sub UpdatePortGeneralPropertiesControls(ByVal port As NPort)
			' can only disconnect the port if it is connected to any plugs
			disconnectPortButton.Enabled = (port.Plugs.Count <> 0)

			' update port offset
			Dim offset As NSizeF = port.Offset
			portOffsetXNumeric.Value = CDec(offset.Width)
			portOffsetYNumeric.Value = CDec(offset.Height)

			' populate the combo with available anchors
			Dim searchRoot As INDiagramElementContainer = port.GetRootForReferenceProperty("AnchorUniqueId")
			Dim filter As NFilter = port.GetFilterForReferenceProperty("AnchorUniqueId")

			Dim anchors As NNodeList = searchRoot.Descendants(Nothing, -1)
			anchors.Insert(0, searchRoot)
			anchors = anchors.Filter(filter)

			anchorIdComboBox.Items.Clear()
			anchorIdComboBox.Items.AddRange(CType(anchors.ToArray(GetType(Object)), Object()))

			' select the currently chosen anchor
			Dim i As Integer = 0
			Do While i < anchorIdComboBox.Items.Count
				Dim elemendGuid As Guid = (TryCast(anchorIdComboBox.Items(i).Tag, INDiagramElement)).UniqueId
				If elemendGuid.Equals(port.AnchorUniqueId) Then
					anchorIdComboBox.SelectedIndex = i
					Exit Do
				End If
				i += 1
			Loop
		End Sub

		Private Sub DisablePortControls()
			portOperationsGroup.Enabled = False
			portPropertiesGroup.Enabled = False

			dynamicPortGroup.Visible = False
			boundsPortGroup.Visible = False
			logicalLinePortGroup.Visible = False
			pointPortGroup.Visible = False
		End Sub


		#End Region

		#Region "Form Event Handlers"

		Private Sub disconnectPortButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles disconnectPortButton.Click
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected shape
			Dim shape As NShape = TryCast(view.Selection.AnchorNode, NShape)
			If shape Is Nothing OrElse shape.Ports Is Nothing OrElse shape.Ports.DefaultInwardPort Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' disconnect the default port
			shape.Ports.DefaultInwardPort.Disconnect()
			disconnectPortButton.Enabled = False

			ResumeEventsHandling()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub anchorIdComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles anchorIdComboBox.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected shape
			Dim shape As NShape = TryCast(view.Selection.AnchorNode, NShape)
			If shape Is Nothing OrElse shape.Ports Is Nothing OrElse shape.Ports.DefaultInwardPort Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' anchor the default port to the selected element
			Dim port As NPort = TryCast(shape.Ports.DefaultInwardPort, NPort)
			If anchorIdComboBox.SelectedIndex = -1 Then
				port.AnchorUniqueId = Guid.Empty
			Else
				port.AnchorUniqueId = (TryCast(anchorIdComboBox.SelectedItem, NDiagramElement)).UniqueId
			End If

			ResumeEventsHandling()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub portOffsetXNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles portOffsetXNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected shape
			Dim shape As NShape = TryCast(view.Selection.AnchorNode, NShape)
			If shape Is Nothing OrElse shape.Ports Is Nothing OrElse shape.Ports.DefaultInwardPort Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' change the port X offset
			Dim port As NPort = TryCast(shape.Ports.DefaultInwardPort, NPort)
			port.Offset = New NSizeF(CSng(portOffsetXNumeric.Value), port.Offset.Height)

			ResumeEventsHandling()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub portOffsetYNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles portOffsetYNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected shape
			Dim shape As NShape = TryCast(view.Selection.AnchorNode, NShape)
			If shape Is Nothing OrElse shape.Ports Is Nothing OrElse shape.Ports.DefaultInwardPort Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' change the port Y offset
			Dim port As NPort = TryCast(shape.Ports.DefaultInwardPort, NPort)
			port.Offset = New NSizeF(port.Offset.Width, CSng(portOffsetYNumeric.Value))

			ResumeEventsHandling()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub dynamicPortGlueModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dynamicPortGlueModeCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected shape
			Dim shape As NShape = TryCast(view.Selection.AnchorNode, NShape)
			If shape Is Nothing OrElse shape.Ports Is Nothing Then
				Return
			End If

			' get a dynamic port
			Dim port As NDynamicPort = TryCast(shape.Ports.DefaultInwardPort, NDynamicPort)
			If port Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' change the port glue mode
			port.GlueMode = CType(dynamicPortGlueModeCombo.SelectedItem, DynamicPortGlueMode)

			ResumeEventsHandling()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub alignmentComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles alignmentComboBox.SelectedIndexChanged
			If alignmentComboBox.SelectedItem Is Nothing Then
				Return
			End If

			If EventsHandlingPaused Then
				Return
			End If

			' get the selected shape
			Dim shape As NShape = TryCast(view.Selection.AnchorNode, NShape)
			If shape Is Nothing OrElse shape.Ports Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' alter the alignment of a bounds or rotated bounds port
			Dim boundsPort As NBoundsPort = TryCast(shape.Ports.DefaultInwardPort, NBoundsPort)
			If Not boundsPort Is Nothing Then
				boundsPort.Alignment = New NContentAlignment(CType(alignmentComboBox.SelectedItem, ContentAlignment))
			Else
				Dim rotatedBoundsPort As NRotatedBoundsPort = (TryCast(shape.Ports.DefaultInwardPort, NRotatedBoundsPort))
				If Not rotatedBoundsPort Is Nothing Then
					rotatedBoundsPort.Alignment = New NContentAlignment(CType(alignmentComboBox.SelectedItem, ContentAlignment))
				End If
			End If

			ResumeEventsHandling()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub portIndexModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles portIndexModeComboBox.SelectedIndexChanged
			If portIndexModeComboBox.SelectedItem Is Nothing Then
				Return
			End If

			If EventsHandlingPaused Then
				Return
			End If

			' get the selected shape
			Dim shape As NShape = TryCast(view.Selection.AnchorNode, NShape)
			If shape Is Nothing OrElse shape.Ports Is Nothing Then
				Return
			End If

			' get a point port
			Dim port As NPointPort = (TryCast(shape.Ports.DefaultInwardPort, NPointPort))
			If port Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' change the point index mode of a point port
			port.PointIndexMode = CType(portIndexModeComboBox.SelectedItem, PointIndexMode)

			ResumeEventsHandling()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub customPointIndexNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles customPointIndexNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			If EventsHandlingPaused Then
				Return
			End If

			' get the selected shape
			Dim shape As NShape = TryCast(view.Selection.AnchorNode, NShape)
			If shape Is Nothing OrElse shape.Ports Is Nothing Then
				Return
			End If

			' get a point port
			Dim port As NPointPort = (TryCast(shape.Ports.DefaultInwardPort, NPointPort))
			If port Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' change the custom point index of a point port
			port.CustomPointIndex = CInt(Fix(customPointIndexNumeric.Value))

			ResumeEventsHandling()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub percentPositionNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles percentPositionNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected shape
			Dim shape As NShape = TryCast(view.Selection.AnchorNode, NShape)
			If shape Is Nothing OrElse shape.Ports Is Nothing Then
				Return
			End If

			' get a logical line port
			Dim port As NLogicalLinePort = (TryCast(shape.Ports.DefaultInwardPort, NLogicalLinePort))
			If port Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' change the percent position of a logical line port
			port.Percent = CSng(percentPositionNumeric.Value)

			ResumeEventsHandling()
			document.SmartRefreshAllViews()
		End Sub


		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()
			UpdateControlsState()
			ResumeEventsHandling()
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()
			UpdateControlsState()
			ResumeEventsHandling()
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label

		Private WithEvents disconnectPortButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents customPointIndexNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents percentPositionNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents dynamicPortGlueModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents portIndexModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents anchorIdComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents alignmentComboBox As Nevron.UI.WinForm.Controls.NComboBox

		Private dynamicPortGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private boundsPortGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private pointPortGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private logicalLinePortGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private portOperationsGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private portPropertiesGroup As Nevron.UI.WinForm.Controls.NGroupBox

		Private WithEvents portOffsetYNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents portOffsetXNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label6 As System.Windows.Forms.Label

		#End Region

		#Region "Fields"

		Private centerShape As NShape = Nothing

		#End Region
	End Class
End Namespace