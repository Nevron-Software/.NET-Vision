Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Drawing

Imports Nevron.Editors
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NGroupBehaviourUC.
	''' </summary>
	Public Class NGroupResizeUC
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
			Me.groupPropertiesGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.updateModelBoundsButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.autoUpdateModelBoundsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.shapePropertiesGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.resizeInAggregateComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.resizeAggregatedModelsComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.groupPropertiesGroup.SuspendLayout()
			Me.shapePropertiesGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupPropertiesGroup
			' 
			Me.groupPropertiesGroup.Controls.Add(Me.label2)
			Me.groupPropertiesGroup.Controls.Add(Me.updateModelBoundsButton)
			Me.groupPropertiesGroup.Controls.Add(Me.autoUpdateModelBoundsCheckBox)
			Me.groupPropertiesGroup.Controls.Add(Me.resizeAggregatedModelsComboBox)
			Me.groupPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupPropertiesGroup.Enabled = False
			Me.groupPropertiesGroup.ImageIndex = 0
			Me.groupPropertiesGroup.Location = New System.Drawing.Point(0, 88)
			Me.groupPropertiesGroup.Name = "groupPropertiesGroup"
			Me.groupPropertiesGroup.Size = New System.Drawing.Size(250, 144)
			Me.groupPropertiesGroup.TabIndex = 1
			Me.groupPropertiesGroup.TabStop = False
			Me.groupPropertiesGroup.Text = "Selected group properties"
			' 
			' updateModelBoundsButton
			' 
			Me.updateModelBoundsButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.updateModelBoundsButton.Location = New System.Drawing.Point(8, 112)
			Me.updateModelBoundsButton.Name = "updateModelBoundsButton"
			Me.updateModelBoundsButton.Size = New System.Drawing.Size(234, 23)
			Me.updateModelBoundsButton.TabIndex = 3
			Me.updateModelBoundsButton.Text = "Update model bounds manually"
'			Me.updateModelBoundsButton.Click += New System.EventHandler(Me.updateModelBoundsButton_Click);
			' 
			' autoUpdateModelBoundsCheckBox
			' 
			Me.autoUpdateModelBoundsCheckBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.autoUpdateModelBoundsCheckBox.Location = New System.Drawing.Point(8, 80)
			Me.autoUpdateModelBoundsCheckBox.Name = "autoUpdateModelBoundsCheckBox"
			Me.autoUpdateModelBoundsCheckBox.Size = New System.Drawing.Size(234, 24)
			Me.autoUpdateModelBoundsCheckBox.TabIndex = 2
			Me.autoUpdateModelBoundsCheckBox.Text = "Auto update model bounds"
'			Me.autoUpdateModelBoundsCheckBox.CheckedChanged += New System.EventHandler(Me.autoUpdateModelBoundsCheckBox_CheckedChanged);
			' 
			' shapePropertiesGroup
			' 
			Me.shapePropertiesGroup.Controls.Add(Me.resizeInAggregateComboBox)
			Me.shapePropertiesGroup.Controls.Add(Me.label1)
			Me.shapePropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.shapePropertiesGroup.Enabled = False
			Me.shapePropertiesGroup.ImageIndex = 0
			Me.shapePropertiesGroup.Location = New System.Drawing.Point(0, 0)
			Me.shapePropertiesGroup.Name = "shapePropertiesGroup"
			Me.shapePropertiesGroup.Size = New System.Drawing.Size(250, 88)
			Me.shapePropertiesGroup.TabIndex = 0
			Me.shapePropertiesGroup.TabStop = False
			Me.shapePropertiesGroup.Text = "Selected shape properties"
			' 
			' resizeInAggregateComboBox
			' 
			Me.resizeInAggregateComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.resizeInAggregateComboBox.Location = New System.Drawing.Point(8, 48)
			Me.resizeInAggregateComboBox.Name = "resizeInAggregateComboBox"
			Me.resizeInAggregateComboBox.Size = New System.Drawing.Size(234, 22)
			Me.resizeInAggregateComboBox.TabIndex = 1
			Me.resizeInAggregateComboBox.Text = "nComboBox1"
'			Me.resizeInAggregateComboBox.SelectedIndexChanged += New System.EventHandler(Me.resizeInAggregateComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(234, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Resize in group:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 24)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(100, 16)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Resize shapes:"
			' 
			' resizeAggregatedModelsComboBox
			' 
			Me.resizeAggregatedModelsComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.resizeAggregatedModelsComboBox.Location = New System.Drawing.Point(8, 48)
			Me.resizeAggregatedModelsComboBox.Name = "resizeAggregatedModelsComboBox"
			Me.resizeAggregatedModelsComboBox.Size = New System.Drawing.Size(234, 22)
			Me.resizeAggregatedModelsComboBox.TabIndex = 1
			Me.resizeAggregatedModelsComboBox.Text = "nComboBox1"
'			Me.resizeAggregatedModelsComboBox.SelectedIndexChanged += New System.EventHandler(Me.resizeAggregatedModelsComboBox_SelectedIndexChanged);
			' 
			' NGroupResizeUC
			' 
			Me.Controls.Add(Me.groupPropertiesGroup)
			Me.Controls.Add(Me.shapePropertiesGroup)
			Me.Name = "NGroupResizeUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.shapePropertiesGroup, 0)
			Me.Controls.SetChildIndex(Me.groupPropertiesGroup, 0)
			Me.groupPropertiesGroup.ResumeLayout(False)
			Me.shapePropertiesGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Overrides NDiagramExampleUC"

		Protected Overrides Sub LoadExample()
			MyBase.DefaultGridOrigin = New NPointF(40, 40)
			MyBase.DefaultGridCellSize = New NSizeF(70, 60)

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

			UpdateControlsState()
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

			resizeInAggregateComboBox.FillFromEnum(GetType(ResizeInAggregate))
			resizeAggregatedModelsComboBox.FillFromEnum(GetType(ResizeAggregatedModels))

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			' create the groups
			Dim group1 As NGroup = CreateAffineScaleGroup()
			Dim group2 As NGroup = CreateCartesianScaleGroup()
			Dim group3 As NGroup = CreateReposionGroup()
			Dim group4 As NGroup = CreateScale1DGroup()

			' apply default styles
			group1.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, 204, 0, 0))
			group2.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, 0, 204, 0))
			group3.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, 0, 0, 204))
			group4.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, 255, 255, 0))

			' layout the groups in 2 cols
			Dim layout As NTableLayout = New NTableLayout()

			' setup table layout
			layout.Direction = LayoutDirection.LeftToRight
			layout.ConstrainMode = CellConstrainMode.Ordinal
			layout.MaxOrdinal = 2
			layout.VerticalSpacing = 20
			layout.HorizontalSpacing = 20

			' create a list of shapes to layout
			Dim groups As NNodeList = New NNodeList()
			groups.Add(group1)
			groups.Add(group2)
			groups.Add(group3)
			groups.Add(group4)

			' create a layout context
			Dim layoutContext As NLayoutContext = New NLayoutContext()
			layoutContext.GraphAdapter = New NShapeGraphAdapter()
			layoutContext.BodyAdapter = New NShapeBodyAdapter(document)
			layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(document)

			' do layout
			layout.Layout(groups, layoutContext)
		End Sub

		Protected Function CreateAffineScaleGroup() As NGroup
			Dim group As NGroup = New NGroup()

			' rect 1 uses affine scaling
			Dim rect1 As NRectangleShape = New NRectangleShape(0, 0, 75, 75)
			rect1.Rotate(CoordinateSystem.Scene, 45, rect1.PinPoint)
			rect1.ResizeInAggregate = ResizeInAggregate.AffineScale
			rect1.Text = "Affine Scale"
			group.Shapes.AddChild(rect1)

			' rect 2 uses affine X scaling and Y reposition
			Dim rect2 As NRectangleShape = New NRectangleShape(150, 0, 75, 75)
			rect2.Rotate(CoordinateSystem.Scene, 45, rect2.PinPoint)
			rect2.ResizeInAggregate = ResizeInAggregate.AffineScaleXRepositionY
			rect2.Text = "Affine Scale X and Reposition Y"
			group.Shapes.AddChild(rect2)

			' rect 3 uses affine Y scaling and X reposition
			Dim rect3 As NRectangleShape = New NRectangleShape(0, 150, 75, 75)
			rect3.Rotate(CoordinateSystem.Scene, 45, rect3.PinPoint)
			rect3.ResizeInAggregate = ResizeInAggregate.AffineScaleYRepositionX
			rect3.Text = "Affine Scale Y and Reposition X"
			group.Shapes.AddChild(rect3)

			' update the group model bounds
			group.UpdateModelBounds()

			' in order to demonstrate the reposition, all shapes 
			' are pinned to the bottom rigth corner of the group
			Dim pin As NPointF = New NPointF(group.Bounds.Right, group.Bounds.Bottom)
			For Each shape As NShape In group.Shapes
				shape.PinPoint = pin
			Next shape

			' add the group to the active layer
			document.ActiveLayer.AddChild(group)
			Return group
		End Function

		Protected Function CreateCartesianScaleGroup() As NGroup
			Dim group As NGroup = New NGroup()

			' rect 1 uses cartesian scaling
			Dim rect1 As NRectangleShape = New NRectangleShape(0, 0, 75, 75)
			rect1.Rotate(CoordinateSystem.Scene, 45, rect1.PinPoint)
			rect1.ResizeInAggregate = ResizeInAggregate.CartesianScale
			rect1.Text = "Cartesian Scale"
			group.Shapes.AddChild(rect1)

			' rect 2 uses cartesian X scaling and Y reposition
			Dim rect2 As NRectangleShape = New NRectangleShape(150, 0, 75, 75)
			rect2.Rotate(CoordinateSystem.Scene, 45, rect2.PinPoint)
			rect2.ResizeInAggregate = ResizeInAggregate.CartesianScaleXRepositionY
			rect2.Text = "Cartesian Scale X and Reposition Y"
			group.Shapes.AddChild(rect2)

			' rect 3 uses cartesian Y scaling and X reposition
			Dim rect3 As NRectangleShape = New NRectangleShape(0, 150, 75, 75)
			rect3.Rotate(CoordinateSystem.Scene, 45, rect3.PinPoint)
			rect3.ResizeInAggregate = ResizeInAggregate.CartesianScaleYRepositionX
			rect3.Text = "Cartesian Scale Y and Reposition X"
			group.Shapes.AddChild(rect3)

			' rect 4 uses cartesian scale and reposition
			Dim rect4 As NRectangleShape = New NRectangleShape(150, 150, 75, 75)
			rect4.Rotate(CoordinateSystem.Scene, 45, rect4.PinPoint)
			rect4.ResizeInAggregate = ResizeInAggregate.CartesianScaleAndReposition
			rect4.Text = "Cartesian Scale and Reposition"
			group.Shapes.AddChild(rect4)

			' update the group model bounds
			group.UpdateModelBounds()

			' in order to demonstrate the reposition, all shapes 
			' are pinned to the bottom rigth corner of the group
			Dim pin As NPointF = New NPointF(group.Bounds.Right, group.Bounds.Bottom)
			For Each shape As NShape In group.Shapes
				shape.PinPoint = pin
			Next shape

			' add the group to the active layer
			document.ActiveLayer.AddChild(group)
			Return group
		End Function

		Protected Function CreateReposionGroup() As NGroup
			Dim group As NGroup = New NGroup()

			' rect 1 uses repositon only
			Dim rect1 As NRectangleShape = New NRectangleShape(0, 0, 75, 75)
			rect1.Rotate(CoordinateSystem.Scene, 45, rect1.PinPoint)
			rect1.ResizeInAggregate = ResizeInAggregate.RepositionOnly
			rect1.Text = "Reposition only"
			group.Shapes.AddChild(rect1)

			' rect 2 uses repositon X only
			Dim rect2 As NRectangleShape = New NRectangleShape(150, 0, 75, 75)
			rect2.Rotate(CoordinateSystem.Scene, 45, rect2.PinPoint)
			rect2.ResizeInAggregate = ResizeInAggregate.RepositionXOnly
			rect2.Text = "Reposition X only"
			group.Shapes.AddChild(rect2)

			' rect 3 uses repositon Y only
			Dim rect3 As NRectangleShape = New NRectangleShape(0, 150, 75, 75)
			rect3.Rotate(CoordinateSystem.Scene, 45, rect3.PinPoint)
			rect3.ResizeInAggregate = ResizeInAggregate.RepositionYOnly
			rect3.Text = "Reposition Y only"
			group.Shapes.AddChild(rect3)

			' update the group model bounds
			group.UpdateModelBounds()

			' in order to demonstrate the reposition, all shapes 
			' are pinned to the bottom rigth corner of the group
			Dim pin As NPointF = New NPointF(group.Bounds.Right, group.Bounds.Bottom)
			For Each shape As NShape In group.Shapes
				shape.PinPoint = pin
			Next shape

			' add the group to the active layer
			document.ActiveLayer.AddChild(group)
			Return group

		End Function

		Protected Function CreateScale1DGroup() As NGroup
			Dim group As NGroup = New NGroup()

			' arrow 
			Dim arrow As NArrowShape = New NArrowShape(ArrowType.SingleArrow, New NPointF(0, 0), New NPointF(75, 75), 10, 45, 30)
			arrow.ResizeInAggregate = ResizeInAggregate.Scale1D
			arrow.Text = "Scale 1D"
			group.Shapes.AddChild(arrow)

			' line 
			Dim line As NLineShape = New NLineShape(New NPointF(150, 0), New NPointF(150 + 100, 100))
			line.StyleSheetName = NDR.NameConnectorsStyleSheet
			line.ResizeInAggregate = ResizeInAggregate.Scale1D
			line.Text = "Scale 1D"
			group.Shapes.AddChild(line)

			' polyline 
			Dim polyline As NPolylineShape = New NPolylineShape(MyBase.GetRandomPoints(New NRectangleF(0, 150, 100, 100), 3))
			polyline.StyleSheetName = NDR.NameConnectorsStyleSheet
			polyline.ResizeInAggregate = ResizeInAggregate.Scale1D
			polyline.Text = "Scale 1D"
			group.Shapes.AddChild(polyline)

			' rect 
			Dim rect As NRectangleShape = New NRectangleShape(150, 150, 75, 75)
			rect.Rotate(CoordinateSystem.Scene, 45, rect.PinPoint)
			rect.ResizeInAggregate = ResizeInAggregate.Scale1D
			rect.Text = "Scale 1D"
			group.Shapes.AddChild(rect)

			' update the group model bounds
			group.UpdateModelBounds()

			' add the group to the active layer
			document.ActiveLayer.AddChild(group)
			Return group

		End Function


		Private Sub UpdateControlsState()
			' handle single selected node only
			If view.Selection.NodesCount <> 1 Then
				groupPropertiesGroup.Enabled = False
				shapePropertiesGroup.Enabled = False
				Return
			End If

			' if the selected node is a group -> update group controls
			Dim group As NGroup = (TryCast(view.Selection.AnchorNode, NGroup))
			If Not group Is Nothing Then
				groupPropertiesGroup.Enabled = True
				shapePropertiesGroup.Enabled = False
				autoUpdateModelBoundsCheckBox.Checked = group.AutoUpdateModelBounds
				resizeAggregatedModelsComboBox.SelectedItem = group.ResizeAggregatedModels
				Return
			End If

			' if the selected node is a simple shape -> update shape controls
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If Not shape Is Nothing Then
				groupPropertiesGroup.Enabled = False
				shapePropertiesGroup.Enabled = True
				resizeInAggregateComboBox.SelectedItem = shape.ResizeInAggregate
				Return
			End If
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub autoUpdateModelBoundsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles autoUpdateModelBoundsCheckBox.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim group As NGroup = TryCast(view.Selection.AnchorNode, NGroup)
			If group Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			group.AutoUpdateModelBounds = autoUpdateModelBoundsCheckBox.Checked
			document.SmartRefreshAllViews()

			ResumeEventsHandling()
		End Sub

		Private Sub resizeAggregatedModelsComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles resizeAggregatedModelsComboBox.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim group As NGroup = (TryCast(view.Selection.AnchorNode, NGroup))
			If group Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			group.ResizeAggregatedModels = CType(resizeAggregatedModelsComboBox.SelectedItem, ResizeAggregatedModels)
			document.SmartRefreshAllViews()

			ResumeEventsHandling()
		End Sub

		Private Sub resizeInAggregateComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles resizeInAggregateComboBox.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			shape.ResizeInAggregate = CType(resizeInAggregateComboBox.SelectedItem, ResizeInAggregate)
			document.SmartRefreshAllViews()

			ResumeEventsHandling()
		End Sub

		Private Sub updateModelBoundsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles updateModelBoundsButton.Click
			If EventsHandlingPaused Then
				Return
			End If

			Dim group As NGroup = TryCast(view.Selection.AnchorNode, NGroup)
			If group Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			group.UpdateModelBounds()
			document.SmartRefreshAllViews()

			ResumeEventsHandling()
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

		Private groupPropertiesGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents autoUpdateModelBoundsCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents resizeInAggregateComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private shapePropertiesGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents updateModelBoundsButton As Nevron.UI.WinForm.Controls.NButton

		#End Region

		#Region "Fields"

		Private groupNodes As NNodeList = Nothing
		Private label2 As System.Windows.Forms.Label
		Private WithEvents resizeAggregatedModelsComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private group As NGroup = Nothing

		#End Region
	End Class
End Namespace