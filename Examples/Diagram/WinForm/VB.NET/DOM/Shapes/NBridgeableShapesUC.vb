Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Editors
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NBridgeableStrokeShapesUC.
	''' </summary>
	Public Class NBridgeableShapesUC
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
			Me.pointsCountNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.addRandomPolylineButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.bridgeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.randomNodesGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.addLineButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.selectedBridgeableStrokeGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.bridgeTargetsComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.enableBridgeManagerCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			CType(Me.pointsCountNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.randomNodesGroup.SuspendLayout()
			Me.selectedBridgeableStrokeGroup.SuspendLayout()
			Me.nGroupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' pointsCountNumeric
			' 
			Me.pointsCountNumeric.Location = New System.Drawing.Point(8, 57)
			Me.pointsCountNumeric.Minimum = New System.Decimal(New Integer() { 2, 0, 0, 0})
			Me.pointsCountNumeric.Name = "pointsCountNumeric"
			Me.pointsCountNumeric.Size = New System.Drawing.Size(72, 22)
			Me.pointsCountNumeric.TabIndex = 23
			Me.pointsCountNumeric.Value = New System.Decimal(New Integer() { 3, 0, 0, 0})
			' 
			' addRandomPolylineButton
			' 
			Me.addRandomPolylineButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.addRandomPolylineButton.Location = New System.Drawing.Point(104, 24)
			Me.addRandomPolylineButton.Name = "addRandomPolylineButton"
			Me.addRandomPolylineButton.Size = New System.Drawing.Size(138, 23)
			Me.addRandomPolylineButton.TabIndex = 20
			Me.addRandomPolylineButton.Text = "Add Polyline"
'			Me.addRandomPolylineButton.Click += New System.EventHandler(Me.addRandomPolylineButton_Click);
			' 
			' bridgeStyleButton
			' 
			Me.bridgeStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.bridgeStyleButton.Location = New System.Drawing.Point(8, 64)
			Me.bridgeStyleButton.Name = "bridgeStyleButton"
			Me.bridgeStyleButton.Size = New System.Drawing.Size(234, 23)
			Me.bridgeStyleButton.TabIndex = 26
			Me.bridgeStyleButton.Text = "Bridge Style..."
'			Me.bridgeStyleButton.Click += New System.EventHandler(Me.bridgeStyleButton_Click);
			' 
			' randomNodesGroup
			' 
			Me.randomNodesGroup.Controls.Add(Me.label1)
			Me.randomNodesGroup.Controls.Add(Me.pointsCountNumeric)
			Me.randomNodesGroup.Controls.Add(Me.addRandomPolylineButton)
			Me.randomNodesGroup.Controls.Add(Me.addLineButton)
			Me.randomNodesGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.randomNodesGroup.ImageIndex = 0
			Me.randomNodesGroup.Location = New System.Drawing.Point(0, 0)
			Me.randomNodesGroup.Name = "randomNodesGroup"
			Me.randomNodesGroup.Size = New System.Drawing.Size(250, 96)
			Me.randomNodesGroup.TabIndex = 28
			Me.randomNodesGroup.TabStop = False
			Me.randomNodesGroup.Text = "Add Random Bridgeable Shape"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(72, 23)
			Me.label1.TabIndex = 24
			Me.label1.Text = "Points count:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' addLineButton
			' 
			Me.addLineButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.addLineButton.Location = New System.Drawing.Point(104, 56)
			Me.addLineButton.Name = "addLineButton"
			Me.addLineButton.Size = New System.Drawing.Size(138, 23)
			Me.addLineButton.TabIndex = 22
			Me.addLineButton.Text = "Add Line"
'			Me.addLineButton.Click += New System.EventHandler(Me.addLineButton_Click);
			' 
			' selectedBridgeableStrokeGroup
			' 
			Me.selectedBridgeableStrokeGroup.Controls.Add(Me.bridgeTargetsComboBox)
			Me.selectedBridgeableStrokeGroup.Controls.Add(Me.label2)
			Me.selectedBridgeableStrokeGroup.Controls.Add(Me.bridgeStyleButton)
			Me.selectedBridgeableStrokeGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.selectedBridgeableStrokeGroup.Enabled = False
			Me.selectedBridgeableStrokeGroup.ImageIndex = 0
			Me.selectedBridgeableStrokeGroup.Location = New System.Drawing.Point(0, 96)
			Me.selectedBridgeableStrokeGroup.Name = "selectedBridgeableStrokeGroup"
			Me.selectedBridgeableStrokeGroup.Size = New System.Drawing.Size(250, 96)
			Me.selectedBridgeableStrokeGroup.TabIndex = 29
			Me.selectedBridgeableStrokeGroup.TabStop = False
			Me.selectedBridgeableStrokeGroup.Text = "Selected Bridgeable Shape"
			' 
			' bridgeTargetsComboBox
			' 
			Me.bridgeTargetsComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.bridgeTargetsComboBox.Location = New System.Drawing.Point(104, 29)
			Me.bridgeTargetsComboBox.Name = "bridgeTargetsComboBox"
			Me.bridgeTargetsComboBox.Size = New System.Drawing.Size(138, 22)
			Me.bridgeTargetsComboBox.TabIndex = 28
			Me.bridgeTargetsComboBox.Text = "nComboBox1"
'			Me.bridgeTargetsComboBox.SelectedIndexChanged += New System.EventHandler(Me.bridgeTargetsComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 32)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(88, 16)
			Me.label2.TabIndex = 27
			Me.label2.Text = "Bridge Targets:"
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.enableBridgeManagerCheckBox)
			Me.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(0, 192)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(250, 64)
			Me.nGroupBox1.TabIndex = 30
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Bridge Manager"
			' 
			' enableBridgeManagerCheckBox
			' 
			Me.enableBridgeManagerCheckBox.Location = New System.Drawing.Point(8, 24)
			Me.enableBridgeManagerCheckBox.Name = "enableBridgeManagerCheckBox"
			Me.enableBridgeManagerCheckBox.TabIndex = 0
			Me.enableBridgeManagerCheckBox.Text = "Enabled"
'			Me.enableBridgeManagerCheckBox.CheckedChanged += New System.EventHandler(Me.enableBridgeManagerCheckBox_CheckedChanged);
			' 
			' NBridgeableShapesUC
			' 
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.selectedBridgeableStrokeGroup)
			Me.Controls.Add(Me.randomNodesGroup)
			Me.Name = "NBridgeableShapesUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.randomNodesGroup, 0)
			Me.Controls.SetChildIndex(Me.selectedBridgeableStrokeGroup, 0)
			Me.Controls.SetChildIndex(Me.nGroupBox1, 0)
			CType(Me.pointsCountNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.randomNodesGroup.ResumeLayout(False)
			Me.selectedBridgeableStrokeGroup.ResumeLayout(False)
			Me.nGroupBox1.ResumeLayout(False)
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

			selectedBridgeableStrokeGroup.Enabled = False
			bridgeTargetsComboBox.FillFromEnum(GetType(BridgeTargets))
			bridgeTargetsComboBox.SelectedItem = BridgeTargets.SelfAndOther
			enableBridgeManagerCheckBox.Checked = document.BridgeManager.Enabled

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			' change the document shadow 
			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur
			document.Style.ShadowStyle.Offset = New NPointL(5, 5)

			' change the document bridge style
			document.Style.BridgeStyle = New NBridgeStyle(BridgeShape.Arc, New NSizeL(5, 5))

			' create the bridgeable shapes
			CreateSampleLine1()
			CreateSamplePolyline1()
			CreateSamplePolyline2()
			CreateSampleLine2()
			CreateSampleLineDoubleBridge()
		End Sub

		Private Sub CreateSampleLine1()
			Dim line As NLineShape = New NLineShape(New NPointF(10, 130), New NPointF(250, 130))
			document.ActiveLayer.AddChild(line)

			line.Style = TryCast(line.ComposeStyle().Clone(), NStyle)
			line.Style.StrokeStyle.Color = Color.BlueViolet
			line.Style.StartArrowheadStyle.StrokeStyle.Color = Color.BlueViolet
			line.Style.EndArrowheadStyle.StrokeStyle.Color = Color.BlueViolet
			line.Style.BridgeStyle.Shape = BridgeShape.Square
		End Sub

		Private Sub CreateSampleLine2()
			Dim line As NLineShape = New NLineShape(New NPointF(10, 75), New NPointF(280, 75))
			document.ActiveLayer.AddChild(line)

			line.Style = TryCast(line.ComposeStyle().Clone(), NStyle)
			line.Style.StrokeStyle.Color = Color.Orange
			line.Style.StartArrowheadStyle.StrokeStyle.Color = Color.Orange
			line.Style.EndArrowheadStyle.StrokeStyle.Color = Color.Orange
			line.Style.BridgeStyle.Shape = BridgeShape.Square
		End Sub

		Private Sub CreateSamplePolyline1()
			Dim points As NPointF() = New NPointF() { New NPointF(10, 210), New NPointF(75, 10), New NPointF(75, 10), New NPointF(75, 175), New NPointF(145, 175), New NPointF(145, 10), New NPointF(210, 75), New NPointF(210, 210), New NPointF(105, 210), New NPointF(105, 105) }

			Dim line As NPolylineShape = New NPolylineShape(points)
			line.BridgeTargets = BridgeTargets.Self
			document.ActiveLayer.AddChild(line)
		End Sub

		Private Sub CreateSamplePolyline2()
			Dim points As NPointF() = New NPointF() { New NPointF(212, 250), New NPointF(174, 250), New NPointF(174, 169), New NPointF(242, 169), New NPointF(242, 208) }

			Dim hvPolyline As NPolylineShape = New NPolylineShape(points)
			document.ActiveLayer.AddChild(hvPolyline)

			hvPolyline.Style = TryCast(hvPolyline.ComposeStyle().Clone(), NStyle)
			hvPolyline.Style.StrokeStyle.Color = Color.OrangeRed
			hvPolyline.Style.StartArrowheadStyle.StrokeStyle.Color = Color.OrangeRed
			hvPolyline.Style.EndArrowheadStyle.StrokeStyle.Color = Color.OrangeRed
			hvPolyline.Style.BridgeStyle.Shape = BridgeShape.Sides2
		End Sub

		Private Sub CreateSampleLineDoubleBridge()
			Dim line As NLineShape = New NLineShape(New NPointF(50, 300), New NPointF(206, 14))
			document.ActiveLayer.AddChild(line)

			line.Style = TryCast(line.ComposeStyle().Clone(), NStyle)
			line.Style.StrokeStyle.Color = Color.Green
			line.Style.StartArrowheadStyle.StrokeStyle.Color = Color.Green
			line.Style.EndArrowheadStyle.StrokeStyle.Color = Color.Green
			line.Style.BridgeStyle.Shape = BridgeShape.Sides3
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub addRandomPolylineButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addRandomPolylineButton.Click
			Dim bounds As NRectangleF = view.Viewport
			Dim count As Integer = CInt(Fix(pointsCountNumeric.Value))

			Dim path As NPolylineShape = New NPolylineShape(MyBase.GetRandomPoints(bounds, count))
			document.ActiveLayer.AddChild(path)

			path.Style = TryCast(path.ComposeStyle().Clone(), NStyle)
			path.Style.StrokeStyle.Color = Color.DarkCyan
			path.Style.StartArrowheadStyle.StrokeStyle.Color = Color.DarkCyan
			path.Style.EndArrowheadStyle.StrokeStyle.Color = Color.DarkCyan

			view.Selection.SingleSelect(path)

			view.SmartRefresh()
		End Sub

		Private Sub addLineButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addLineButton.Click
			Dim bounds As NRectangleF = view.Viewport

			Dim points As NPointF() = MyBase.GetRandomPoints(bounds, 2)
			Dim path As NLineShape = New NLineShape(points(0), points(1))

			document.ActiveLayer.AddChild(path)

			path.Style = TryCast(path.ComposeStyle().Clone(), NStyle)
			path.Style.StrokeStyle.Color = Color.DarkCyan
			path.Style.StartArrowheadStyle.StrokeStyle.Color = Color.DarkCyan
			path.Style.EndArrowheadStyle.StrokeStyle.Color = Color.DarkCyan

			view.Selection.SingleSelect(path)

			view.SmartRefresh()
		End Sub

		Private Sub bridgeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bridgeStyleButton.Click
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				Return
			End If

			MyBase.ShowBridgeStyleEditor(shape)
		End Sub

		Private Sub bridgeTargetsComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles bridgeTargetsComboBox.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			If bridgeTargetsComboBox.SelectedIndex = -1 Then
				Return
			End If

			' get the selection anchor as bridgeable
			Dim bridgeable As INBridgeableShape = (TryCast(view.Selection.AnchorNode, INBridgeableShape))
			If bridgeable Is Nothing Then
				Return
			End If

			' change the bridge targes
			bridgeable.BridgeTargets = CType(bridgeTargetsComboBox.SelectedItem, BridgeTargets)

			' refresh the document views
			document.SmartRefreshAllViews()
		End Sub

		Private Sub enableBridgeManagerCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles enableBridgeManagerCheckBox.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			document.BridgeManager.Enabled = enableBridgeManagerCheckBox.Checked

			' refresh the document views
			document.SmartRefreshAllViews()
		End Sub

		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			Dim bridgeable As INBridgeableShape = (TryCast(args.Node, INBridgeableShape))
			If bridgeable Is Nothing Then
				Return
			End If

			selectedBridgeableStrokeGroup.Enabled = True
			bridgeTargetsComboBox.SelectedItem = bridgeable.BridgeTargets
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			selectedBridgeableStrokeGroup.Enabled = False
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents addLineButton As Nevron.UI.WinForm.Controls.NButton
		Private label2 As System.Windows.Forms.Label
		Private WithEvents bridgeTargetsComboBox As Nevron.UI.WinForm.Controls.NComboBox

		Private randomNodesGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents addRandomPolylineButton As Nevron.UI.WinForm.Controls.NButton
		Private selectedBridgeableStrokeGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private pointsCountNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label1 As System.Windows.Forms.Label
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents enableBridgeManagerCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents bridgeStyleButton As Nevron.UI.WinForm.Controls.NButton

		#End Region
	End Class
End Namespace
