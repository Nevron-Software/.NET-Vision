Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms

Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.Templates

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NLayersUC.
	''' </summary>
	Public Class NLayersUC
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
			Me.layersGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.editLayerShadowStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.layerVisibleCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.editLayerStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.editLayerFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.activeLayerComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.zOrderComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.shadowsZOrderCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.layersGroup.SuspendLayout()
			Me.groupBox1.SuspendLayout()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' layersGroup
			' 
			Me.layersGroup.Controls.Add(Me.groupBox1)
			Me.layersGroup.Controls.Add(Me.activeLayerComboBox)
			Me.layersGroup.Controls.Add(Me.label2)
			Me.layersGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.layersGroup.ImageIndex = 0
			Me.layersGroup.Location = New System.Drawing.Point(0, 88)
			Me.layersGroup.Name = "layersGroup"
			Me.layersGroup.Size = New System.Drawing.Size(250, 256)
			Me.layersGroup.TabIndex = 1
			Me.layersGroup.TabStop = False
			Me.layersGroup.Text = "Active layer"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.editLayerShadowStyleButton)
			Me.groupBox1.Controls.Add(Me.layerVisibleCheckBox)
			Me.groupBox1.Controls.Add(Me.editLayerStrokeStyleButton)
			Me.groupBox1.Controls.Add(Me.editLayerFillStyleButton)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(3, 93)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(244, 160)
			Me.groupBox1.TabIndex = 2
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Active layer properties"
			' 
			' editLayerShadowStyleButton
			' 
			Me.editLayerShadowStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editLayerShadowStyleButton.Location = New System.Drawing.Point(8, 120)
			Me.editLayerShadowStyleButton.Name = "editLayerShadowStyleButton"
			Me.editLayerShadowStyleButton.Size = New System.Drawing.Size(224, 23)
			Me.editLayerShadowStyleButton.TabIndex = 3
			Me.editLayerShadowStyleButton.Text = "Shadow style ..."
'			Me.editLayerShadowStyleButton.Click += New System.EventHandler(Me.editLayerShadowStyleButton_Click);
			' 
			' layerVisibleCheckBox
			' 
			Me.layerVisibleCheckBox.Checked = True
			Me.layerVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
			Me.layerVisibleCheckBox.Location = New System.Drawing.Point(8, 24)
			Me.layerVisibleCheckBox.Name = "layerVisibleCheckBox"
			Me.layerVisibleCheckBox.Size = New System.Drawing.Size(200, 24)
			Me.layerVisibleCheckBox.TabIndex = 0
			Me.layerVisibleCheckBox.Text = "Visible"
'			Me.layerVisibleCheckBox.CheckedChanged += New System.EventHandler(Me.layerVisibleCheckBox_CheckedChanged);
			' 
			' editLayerStrokeStyleButton
			' 
			Me.editLayerStrokeStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editLayerStrokeStyleButton.Location = New System.Drawing.Point(8, 88)
			Me.editLayerStrokeStyleButton.Name = "editLayerStrokeStyleButton"
			Me.editLayerStrokeStyleButton.Size = New System.Drawing.Size(224, 23)
			Me.editLayerStrokeStyleButton.TabIndex = 2
			Me.editLayerStrokeStyleButton.Text = "Stroke style ..."
'			Me.editLayerStrokeStyleButton.Click += New System.EventHandler(Me.editLayerStrokeStyleButton_Click);
			' 
			' editLayerFillStyleButton
			' 
			Me.editLayerFillStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.editLayerFillStyleButton.Location = New System.Drawing.Point(8, 56)
			Me.editLayerFillStyleButton.Name = "editLayerFillStyleButton"
			Me.editLayerFillStyleButton.Size = New System.Drawing.Size(224, 23)
			Me.editLayerFillStyleButton.TabIndex = 1
			Me.editLayerFillStyleButton.Text = "Fill style ..."
'			Me.editLayerFillStyleButton.Click += New System.EventHandler(Me.editLayerFillStyleButton_Click);
			' 
			' activeLayerComboBox
			' 
			Me.activeLayerComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.activeLayerComboBox.Location = New System.Drawing.Point(8, 56)
			Me.activeLayerComboBox.Name = "activeLayerComboBox"
			Me.activeLayerComboBox.Size = New System.Drawing.Size(234, 22)
			Me.activeLayerComboBox.TabIndex = 1
			Me.activeLayerComboBox.Text = "nComboBox1"
'			Me.activeLayerComboBox.SelectedIndexChanged += New System.EventHandler(Me.activeLayerComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 24)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(104, 23)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Select active layer:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.label1)
			Me.nGroupBox1.Controls.Add(Me.zOrderComboBox)
			Me.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(0, 0)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(250, 88)
			Me.nGroupBox1.TabIndex = 0
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Change layers Z-Order"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(112, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Predefined Z-Order:"
			' 
			' zOrderComboBox
			' 
			Me.zOrderComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.zOrderComboBox.Location = New System.Drawing.Point(8, 48)
			Me.zOrderComboBox.Name = "zOrderComboBox"
			Me.zOrderComboBox.Size = New System.Drawing.Size(234, 22)
			Me.zOrderComboBox.TabIndex = 1
			Me.zOrderComboBox.Text = "nComboBox1"
'			Me.zOrderComboBox.SelectedIndexChanged += New System.EventHandler(Me.zOrderComboBox_SelectedIndexChanged);
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.shadowsZOrderCombo)
			Me.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(0, 344)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(250, 56)
			Me.nGroupBox2.TabIndex = 3
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Shadows Z-Order"
			' 
			' shadowsZOrderCombo
			' 
			Me.shadowsZOrderCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.shadowsZOrderCombo.Location = New System.Drawing.Point(8, 24)
			Me.shadowsZOrderCombo.Name = "shadowsZOrderCombo"
			Me.shadowsZOrderCombo.Size = New System.Drawing.Size(234, 22)
			Me.shadowsZOrderCombo.TabIndex = 1
			Me.shadowsZOrderCombo.Text = "nComboBox1"
'			Me.shadowsZOrderCombo.SelectedIndexChanged += New System.EventHandler(Me.shadowsZOrderCombo_SelectedIndexChanged);
			' 
			' NLayersUC
			' 
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.layersGroup)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Name = "NLayersUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.nGroupBox1, 0)
			Me.Controls.SetChildIndex(Me.layersGroup, 0)
			Me.Controls.SetChildIndex(Me.nGroupBox2, 0)
			Me.layersGroup.ResumeLayout(False)
			Me.groupBox1.ResumeLayout(False)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

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

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			document.Layers.RemoveAllChildren()
			CreateGraphLayer()
			CreateShapesLayer()
			CreateTreeLayer()
		End Sub

		Private Sub InitFormControls()
			PauseEventsHandling()

			' init the Z Order combo
			zOrderComboBox.Items.Clear()

			zOrderComboBox.Items.Add("1.Tree - 2.Shapes - 3.Graph")
			zOrderComboBox.Items.Add("1.Shapes - 2.Graph - 3.Tree")
			zOrderComboBox.Items.Add("1.Graph - 2.Tree - 3.Shapes")

			' initially the Z order is the order of layers creation
			zOrderComboBox.SelectedIndex = 0

			' init the active layer combo
			activeLayerComboBox.Items.Clear()

			Dim layers As NNodeList = document.Layers.Children(Nothing)
			For Each layer As NLayer In layers
				activeLayerComboBox.Items.Add(layer)
			Next layer

			' initially the last added layer is the active one
			If layers.Count <> 0 Then
				activeLayerComboBox.SelectedIndex = (layers.Count - 1)
			End If

			' init the shadows Z Order combo
			shadowsZOrderCombo.FillFromEnum(GetType(ShadowsZOrder))
			shadowsZOrderCombo.SelectedIndex = CInt(Fix(document.ShadowsZOrder))

			ResumeEventsHandling()
		End Sub

		Private Sub CreateTreeLayer()
			' create the tree layer and modify its styles
			treeLayer = New NLayer()
			treeLayer.Name = "Tree Layer"

			treeLayer.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(30, 30, 0))
			treeLayer.Style.FillStyle = New NColorFillStyle(Color.FromArgb(&Haa, &Haa, 0))
			treeLayer.Style.ShadowStyle = New NShadowStyle(ShadowType.Solid, Color.FromArgb(50, 0, 0, 0), New NPointL(3, 3), 1, New NLength(1))

			' add it to the document and make it the active one
			document.Layers.AddChild(treeLayer)
			document.ActiveLayerUniqueId = treeLayer.UniqueId

			' create a tree template with pentagons in it
			Dim treeTemplate As NGenericTreeTemplate = New NGenericTreeTemplate()
			treeTemplate.VerticesShape = BasicShapes.Pentagon
			treeTemplate.Origin = New NPointF(10, 10)

			' create it
			treeTemplate.Create(document)
		End Sub

		Private Sub CreateShapesLayer()
			' create the shapes layer and modify its styles
			shapesLayer = New NLayer()
			shapesLayer.Name = "Shapes Layer"

			shapesLayer.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(&H00, &H00, &Haa))
			shapesLayer.Style.FillStyle = New NColorFillStyle(Color.FromArgb(&Haa, &Haa, &Hff))
			shapesLayer.Style.ShadowStyle = New NShadowStyle(ShadowType.Solid, Color.FromArgb(80, 0, 0, 0), New NPointL(3, 3), 1, New NLength(1))

			' add it to the document and make it the active one
			document.Layers.AddChild(shapesLayer)
			document.ActiveLayerUniqueId = shapesLayer.UniqueId

			' create two shapes in it
			Dim rect As NRectangleShape = New NRectangleShape(New NRectangleF(60, 60, 70, 70))
			shapesLayer.AddChild(rect)

			Dim ellipse As NEllipseShape = New NEllipseShape(New NRectangleF(120, 120, 70, 70))
			shapesLayer.AddChild(ellipse)
		End Sub

		Private Sub CreateGraphLayer()
			' create the graph layer and modify its styles
			graphLayer = New NLayer()
			graphLayer.Name = "Graph Layer"

			graphLayer.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(&Haa, &H00, &H00))
			graphLayer.Style.FillStyle = New NColorFillStyle(Color.FromArgb(&Hff, &H99, &H77))
			graphLayer.Style.ShadowStyle = New NShadowStyle(ShadowType.Solid, Color.FromArgb(80, 0, 0, 0), New NPointL(3, 3), 1, New NLength(1))

			' add it to the document and make it the active one
			document.Layers.AddChild(graphLayer)
			document.ActiveLayerUniqueId = graphLayer.UniqueId

			' create an elliptical grid template with pentagrams in it
			Dim ellipticalGrid As NEllipticalGridTemplate = New NEllipticalGridTemplate()
			ellipticalGrid.VerticesShape = BasicShapes.Pentagram
			ellipticalGrid.Origin = New NPointF(60, 60)

			' create it
			ellipticalGrid.Create(document)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub activeLayerComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles activeLayerComboBox.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			If activeLayerComboBox.SelectedItem Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' change the active layer
			document.ActiveLayerUniqueId = (TryCast(activeLayerComboBox.SelectedItem, NLayer)).UniqueId

			' select the selectable layer children
			view.Selection.SingleSelect(document.ActiveLayer.Children(NFilters.PermissionSelect))
			view.SmartRefresh()

			' update the layer visibility check box
			layerVisibleCheckBox.Checked = document.ActiveLayer.Visible

			ResumeEventsHandling()
		End Sub

		Private Sub layerVisibleCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles layerVisibleCheckBox.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			If activeLayerComboBox.SelectedIndex = -1 OrElse document.ActiveLayer Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' show/hide the active layer
			document.ActiveLayer.Visible = layerVisibleCheckBox.Checked
			document.SmartRefreshAllViews()

			ResumeEventsHandling()
		End Sub

		Private Sub zOrderComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles zOrderComboBox.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			If zOrderComboBox.SelectedIndex = -1 Then
				Return
			End If

			' reorder layers
			document.StartTransaction("Change layers Z Order")

			Select Case zOrderComboBox.SelectedIndex
				Case 0 ' 1.Tree - 2.Shapes - 3.Graph
					treeLayer.BringToFront()
					graphLayer.SendToBack()
				Case 1 ' 1.Shapes - 2.Graph - 3.Tree
					shapesLayer.BringToFront()
					treeLayer.SendToBack()
				Case 2 ' 1.Graph - 2.Tree - 3.Shapes
					graphLayer.BringToFront()
					shapesLayer.SendToBack()
			End Select

			document.Commit()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub shadowsZOrderCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles shadowsZOrderCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			If shadowsZOrderCombo.SelectedIndex = -1 Then
				Return
			End If

			' change the shadows ZOrder
			document.ShadowsZOrder = CType(shadowsZOrderCombo.SelectedIndex, ShadowsZOrder)
			document.SmartRefreshAllViews()
		End Sub


		Private Sub editLayerFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editLayerFillStyleButton.Click
			MyBase.ShowFillStyleEditor(document.ActiveLayer)
		End Sub

		Private Sub editLayerStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editLayerStrokeStyleButton.Click
			MyBase.ShowStrokeStyleEditor(document.ActiveLayer)
		End Sub

		Private Sub editLayerShadowStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editLayerShadowStyleButton.Click
			MyBase.ShowShadowStyleEditor(document.ActiveLayer)
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private label2 As System.Windows.Forms.Label
		Private layersGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents activeLayerComboBox As Nevron.UI.WinForm.Controls.NComboBox

		#End Region

		#Region "Fields"

		Private treeLayer As NLayer = Nothing
		Private shapesLayer As NLayer = Nothing
		Private graphLayer As NLayer = Nothing

		Private WithEvents layerVisibleCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents zOrderComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents editLayerShadowStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents editLayerStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents editLayerFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents shadowsZOrderCombo As Nevron.UI.WinForm.Controls.NComboBox

		#End Region
	End Class
End Namespace