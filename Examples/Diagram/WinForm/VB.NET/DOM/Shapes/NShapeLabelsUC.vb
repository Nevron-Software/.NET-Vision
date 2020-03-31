Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.Editors
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NShapeLabelsUC.
	''' </summary>
	Public Class NShapeLabelsUC
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
			Me.labelsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.selectedShapeLabelsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.boundsLabelsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.boxTextModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.marginsButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.lineLabelsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.percentPositionNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.allowDownwardCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.useLineOrientationCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.labelPropertiesGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.labelTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.textStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.visibleCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.allowDownwardCheck2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.selectedShapeLabelsGroup.SuspendLayout()
			Me.panel1.SuspendLayout()
			Me.boundsLabelsGroup.SuspendLayout()
			Me.lineLabelsGroup.SuspendLayout()
			CType(Me.percentPositionNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.labelPropertiesGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' labelsCombo
			' 
			Me.labelsCombo.Dock = System.Windows.Forms.DockStyle.Top
			Me.labelsCombo.ListProperties.CheckBoxDataMember = ""
			Me.labelsCombo.ListProperties.DataSource = Nothing
			Me.labelsCombo.ListProperties.DisplayMember = ""
			Me.labelsCombo.Location = New System.Drawing.Point(3, 16)
			Me.labelsCombo.Name = "labelsCombo"
			Me.labelsCombo.Size = New System.Drawing.Size(244, 22)
			Me.labelsCombo.TabIndex = 0
			Me.labelsCombo.Text = "nComboBox1"
'			Me.labelsCombo.SelectedIndexChanged += New System.EventHandler(Me.labelsCombo_SelectedIndexChanged);
			' 
			' selectedShapeLabelsGroup
			' 
			Me.selectedShapeLabelsGroup.Controls.Add(Me.panel1)
			Me.selectedShapeLabelsGroup.Controls.Add(Me.labelsCombo)
			Me.selectedShapeLabelsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.selectedShapeLabelsGroup.ImageIndex = 0
			Me.selectedShapeLabelsGroup.Location = New System.Drawing.Point(0, 0)
			Me.selectedShapeLabelsGroup.Name = "selectedShapeLabelsGroup"
			Me.selectedShapeLabelsGroup.Size = New System.Drawing.Size(250, 464)
			Me.selectedShapeLabelsGroup.TabIndex = 1
			Me.selectedShapeLabelsGroup.TabStop = False
			Me.selectedShapeLabelsGroup.Text = "Selected shape labels"
			' 
			' panel1
			' 
			Me.panel1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.panel1.Controls.Add(Me.boundsLabelsGroup)
			Me.panel1.Controls.Add(Me.lineLabelsGroup)
			Me.panel1.Controls.Add(Me.labelPropertiesGroup)
			Me.panel1.Location = New System.Drawing.Point(3, 56)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(244, 400)
			Me.panel1.TabIndex = 1
			' 
			' boundsLabelsGroup
			' 
			Me.boundsLabelsGroup.Controls.Add(Me.allowDownwardCheck2)
			Me.boundsLabelsGroup.Controls.Add(Me.label3)
			Me.boundsLabelsGroup.Controls.Add(Me.boxTextModeCombo)
			Me.boundsLabelsGroup.Controls.Add(Me.marginsButton)
			Me.boundsLabelsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.boundsLabelsGroup.ImageIndex = 0
			Me.boundsLabelsGroup.Location = New System.Drawing.Point(0, 296)
			Me.boundsLabelsGroup.Name = "boundsLabelsGroup"
			Me.boundsLabelsGroup.Size = New System.Drawing.Size(244, 123)
			Me.boundsLabelsGroup.TabIndex = 9
			Me.boundsLabelsGroup.TabStop = False
			Me.boundsLabelsGroup.Text = "Bounds/rotated bounds labels properties"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(16, 58)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(48, 16)
			Me.label3.TabIndex = 3
			Me.label3.Text = "Mode:"
			' 
			' boxTextModeCombo
			' 
			Me.boxTextModeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.boxTextModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.boxTextModeCombo.ListProperties.DataSource = Nothing
			Me.boxTextModeCombo.ListProperties.DisplayMember = ""
			Me.boxTextModeCombo.Location = New System.Drawing.Point(72, 56)
			Me.boxTextModeCombo.Name = "boxTextModeCombo"
			Me.boxTextModeCombo.Size = New System.Drawing.Size(160, 21)
			Me.boxTextModeCombo.TabIndex = 2
'			Me.boxTextModeCombo.SelectedIndexChanged += New System.EventHandler(Me.boxTextModeCombo_SelectedIndexChanged);
			' 
			' marginsButton
			' 
			Me.marginsButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.marginsButton.DialogResult = System.Windows.Forms.DialogResult.No
			Me.marginsButton.Location = New System.Drawing.Point(8, 16)
			Me.marginsButton.Name = "marginsButton"
			Me.marginsButton.Size = New System.Drawing.Size(224, 23)
			Me.marginsButton.TabIndex = 1
			Me.marginsButton.Text = "Margins"
'			Me.marginsButton.Click += New System.EventHandler(Me.marginsButton_Click);
			' 
			' lineLabelsGroup
			' 
			Me.lineLabelsGroup.Controls.Add(Me.percentPositionNumeric)
			Me.lineLabelsGroup.Controls.Add(Me.label2)
			Me.lineLabelsGroup.Controls.Add(Me.allowDownwardCheck)
			Me.lineLabelsGroup.Controls.Add(Me.useLineOrientationCheck)
			Me.lineLabelsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.lineLabelsGroup.ImageIndex = 0
			Me.lineLabelsGroup.Location = New System.Drawing.Point(0, 176)
			Me.lineLabelsGroup.Name = "lineLabelsGroup"
			Me.lineLabelsGroup.Size = New System.Drawing.Size(244, 120)
			Me.lineLabelsGroup.TabIndex = 10
			Me.lineLabelsGroup.TabStop = False
			Me.lineLabelsGroup.Text = "Logical line label properties"
			' 
			' percentPositionNumeric
			' 
			Me.percentPositionNumeric.Location = New System.Drawing.Point(168, 24)
			Me.percentPositionNumeric.Name = "percentPositionNumeric"
			Me.percentPositionNumeric.Size = New System.Drawing.Size(64, 20)
			Me.percentPositionNumeric.TabIndex = 1
			Me.percentPositionNumeric.Value = New Decimal(New Integer() { 50, 0, 0, 0})
'			Me.percentPositionNumeric.ValueChanged += New System.EventHandler(Me.percentPositionNumeric_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 23)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(96, 23)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Percent position:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' allowDownwardCheck
			' 
			Me.allowDownwardCheck.ButtonProperties.BorderOffset = 2
			Me.allowDownwardCheck.Location = New System.Drawing.Point(8, 80)
			Me.allowDownwardCheck.Name = "allowDownwardCheck"
			Me.allowDownwardCheck.Size = New System.Drawing.Size(168, 24)
			Me.allowDownwardCheck.TabIndex = 3
			Me.allowDownwardCheck.Text = "Allow downward orientation"
'			Me.allowDownwardCheck.CheckedChanged += New System.EventHandler(Me.allowDownwardCheck_CheckedChanged);
			' 
			' useLineOrientationCheck
			' 
			Me.useLineOrientationCheck.ButtonProperties.BorderOffset = 2
			Me.useLineOrientationCheck.Location = New System.Drawing.Point(8, 56)
			Me.useLineOrientationCheck.Name = "useLineOrientationCheck"
			Me.useLineOrientationCheck.Size = New System.Drawing.Size(168, 24)
			Me.useLineOrientationCheck.TabIndex = 2
			Me.useLineOrientationCheck.Text = "Use line percent orientation"
'			Me.useLineOrientationCheck.CheckedChanged += New System.EventHandler(Me.useLineOrientationCheck_CheckedChanged);
			' 
			' labelPropertiesGroup
			' 
			Me.labelPropertiesGroup.Controls.Add(Me.labelTextBox)
			Me.labelPropertiesGroup.Controls.Add(Me.textStyleButton)
			Me.labelPropertiesGroup.Controls.Add(Me.visibleCheck)
			Me.labelPropertiesGroup.Controls.Add(Me.label1)
			Me.labelPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.labelPropertiesGroup.ImageIndex = 0
			Me.labelPropertiesGroup.Location = New System.Drawing.Point(0, 0)
			Me.labelPropertiesGroup.Name = "labelPropertiesGroup"
			Me.labelPropertiesGroup.Size = New System.Drawing.Size(244, 176)
			Me.labelPropertiesGroup.TabIndex = 8
			Me.labelPropertiesGroup.TabStop = False
			Me.labelPropertiesGroup.Text = "General label properties"
			' 
			' labelTextBox
			' 
			Me.labelTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.labelTextBox.Location = New System.Drawing.Point(48, 40)
			Me.labelTextBox.Multiline = True
			Me.labelTextBox.Name = "labelTextBox"
			Me.labelTextBox.Size = New System.Drawing.Size(184, 88)
			Me.labelTextBox.TabIndex = 5
			Me.labelTextBox.Text = "textBox1"
'			Me.labelTextBox.TextChanged += New System.EventHandler(Me.labelTextBox_TextChanged);
			' 
			' textStyleButton
			' 
			Me.textStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.textStyleButton.Location = New System.Drawing.Point(8, 136)
			Me.textStyleButton.Name = "textStyleButton"
			Me.textStyleButton.Size = New System.Drawing.Size(224, 23)
			Me.textStyleButton.TabIndex = 4
			Me.textStyleButton.Text = "Text style..."
'			Me.textStyleButton.Click += New System.EventHandler(Me.textStyleButton_Click);
			' 
			' visibleCheck
			' 
			Me.visibleCheck.ButtonProperties.BorderOffset = 2
			Me.visibleCheck.Location = New System.Drawing.Point(8, 16)
			Me.visibleCheck.Name = "visibleCheck"
			Me.visibleCheck.Size = New System.Drawing.Size(96, 24)
			Me.visibleCheck.TabIndex = 3
			Me.visibleCheck.Text = "Visible"
'			Me.visibleCheck.CheckedChanged += New System.EventHandler(Me.visibleCheck_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 40)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(32, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Text:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' allowDownwardCheck2
			' 
			Me.allowDownwardCheck2.ButtonProperties.BorderOffset = 2
			Me.allowDownwardCheck2.Location = New System.Drawing.Point(19, 83)
			Me.allowDownwardCheck2.Name = "allowDownwardCheck2"
			Me.allowDownwardCheck2.Size = New System.Drawing.Size(168, 24)
			Me.allowDownwardCheck2.TabIndex = 4
			Me.allowDownwardCheck2.Text = "Allow downward orientation"
'			Me.allowDownwardCheck2.CheckedChanged += New System.EventHandler(Me.allowDownwardCheck2_CheckedChanged);
			' 
			' NShapeLabelsUC
			' 
			Me.Controls.Add(Me.selectedShapeLabelsGroup)
			Me.Name = "NShapeLabelsUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.selectedShapeLabelsGroup, 0)
			Me.selectedShapeLabelsGroup.ResumeLayout(False)
			Me.panel1.ResumeLayout(False)
			Me.boundsLabelsGroup.ResumeLayout(False)
			Me.lineLabelsGroup.ResumeLayout(False)
			CType(Me.percentPositionNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.labelPropertiesGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			MyBase.DefaultGridCellSize = New NSizeF(200, 100)
			MyBase.DefaultGridOrigin = New NPointF(40, 40)

			' begin view init
			view.BeginInit()

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

			boxTextModeCombo.Items.Clear()
			boxTextModeCombo.FillFromEnum(GetType(BoxTextMode))

			ResumeEventsHandling()
		End Sub
		Private Sub InitDocument()
			' create a rectangle shape with a 2 bounds label
			Dim shape As NShape = New NRectangleShape(MyBase.GetGridCell(0, 0))
			shape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, &Hcc, 0, 0))

			shape.Labels.RemoveAllChildren()

			Dim boundsLabel As NBoundsLabel = New NBoundsLabel("Label 1, Wrapped", shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 0, 50))
			shape.Labels.AddChild(boundsLabel)
			shape.Labels.DefaultLabelUniqueId = boundsLabel.UniqueId

			boundsLabel = New NBoundsLabel("Label 2, Stretched", shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 50, 0))
			boundsLabel.Mode = BoxTextMode.Stretch
			shape.Labels.AddChild(boundsLabel)

			document.ActiveLayer.AddChild(shape)

			' create a rectangle shape with a 2 rotated bounds labels
			shape = New NRectangleShape(MyBase.GetGridCell(0, 1))
			shape.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, 0, 0, &Hcc))

			shape.Labels.RemoveAllChildren()

			Dim rotatedLabel As NRotatedBoundsLabel = New NRotatedBoundsLabel("Rotated Label 1, Wrapped", shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 0, 50))
			shape.Labels.AddChild(rotatedLabel)
			shape.Labels.DefaultLabelUniqueId = rotatedLabel.UniqueId

			rotatedLabel = New NRotatedBoundsLabel("Rotated Label 2, Stretched", shape.UniqueId, New Nevron.Diagram.NMargins(0, 0, 50, 0))
			rotatedLabel.Mode = BoxTextMode.Stretch
			shape.Labels.AddChild(rotatedLabel)

			document.ActiveLayer.AddChild(shape)

			' create a polyline shape with two logical line labels
			Dim cell As NRectangleF = MyBase.GetGridCell(1, 0, 0, 1)
			shape = New NPolylineShape(New NPointF(){cell.Location, cell.RightBottom})

			shape.Labels.RemoveAllChildren()

			Dim lineLabel As NLogicalLineLabel = New NLogicalLineLabel("Line label - start", shape.UniqueId, 0, True, True)
			shape.Labels.AddChild(lineLabel)
			shape.Labels.DefaultLabelUniqueId = lineLabel.UniqueId

			' alter the start label text style
			Dim textStyle As NTextStyle = TryCast(document.Style.TextStyle.Clone(), NTextStyle)
			textStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			textStyle.Offset = New NPointL(0, -7)
			NStyle.SetTextStyle(lineLabel, textStyle)

			' add the end label
			lineLabel = New NLogicalLineLabel("Line label - end", shape.UniqueId, 100, True, True)
			shape.Labels.AddChild(lineLabel)

			' alter the end label text style
			textStyle = TryCast(document.Style.TextStyle.Clone(), NTextStyle)
			textStyle.StringFormatStyle.HorzAlign = HorzAlign.Right
			textStyle.Offset = New NPointL(0, -7)
			NStyle.SetTextStyle(lineLabel, textStyle)

			document.ActiveLayer.AddChild(shape)
		End Sub

		Private Sub UpdateControlsState()
			' only single selection is processed
			If view.Selection.Nodes.Count <> 1 Then
				selectedShapeLabelsGroup.Enabled = False
				HideLabelControls()
				Return
			End If

			' check to see if the selected node is a shape and it has lables
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing OrElse shape.Labels Is Nothing Then
				selectedShapeLabelsGroup.Enabled = False
				HideLabelControls()
				Return
			End If

			selectedShapeLabelsGroup.Enabled = True

			' get the default label
			Dim defaultLabel As NLabel = shape.Labels.DefaultLabel

			' fill the labels combo and select the default label
			labelsCombo.Items.Clear()
			For Each label As NLabel In shape.Labels.Children(Nothing)
				labelsCombo.Items.Add(label)
				If label Is defaultLabel Then
					labelsCombo.SelectedItem = label
				End If
			Next label

			' update the label controls from the default label
			If defaultLabel Is Nothing Then
				HideLabelControls()
				Return
			End If

			UpdateLabelControls(defaultLabel)
		End Sub
		Private Sub UpdateLabelControls(ByVal label As NLabel)
			' update general properties
			labelPropertiesGroup.Visible = True
			visibleCheck.Checked = label.Visible
			labelTextBox.Text = label.Text

			' bounds labels specific
			If TypeOf label Is NBoundsLabel Then
				boundsLabelsGroup.Visible = True
				boxTextModeCombo.SelectedIndex = CInt(Fix((TryCast(label, NBoundsLabel)).Mode))

				If TypeOf label Is NRotatedBoundsLabel Then
					allowDownwardCheck2.Visible = True
					allowDownwardCheck2.Checked = (TryCast(label, NRotatedBoundsLabel)).AllowDownwardOrientation
				Else
					allowDownwardCheck2.Visible = False
				End If
			Else
				boundsLabelsGroup.Visible = False
			End If

			' logical line specific
			If TypeOf label Is NLogicalLineLabel Then
				lineLabelsGroup.Visible = True
				allowDownwardCheck.Checked = (TryCast(label, NLogicalLineLabel)).AllowDownwardOrientation
				useLineOrientationCheck.Checked = (TryCast(label, NLogicalLineLabel)).UseLineOrientation
				percentPositionNumeric.Value = CDec((TryCast(label, NLogicalLineLabel)).PercentPosition)
			Else
				lineLabelsGroup.Visible = False
			End If
		End Sub
		Private Sub HideLabelControls()
			labelPropertiesGroup.Visible = False
			boundsLabelsGroup.Visible = False
			lineLabelsGroup.Visible = False
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub labelsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles labelsCombo.SelectedIndexChanged
			' get the selected label
			Dim label As NLabel = TryCast(labelsCombo.SelectedItem, NLabel)
			If label Is Nothing Then
				HideLabelControls()
				Return
			End If

			' update the label controls
			PauseEventsHandling()
			UpdateLabelControls(label)
			ResumeEventsHandling()
		End Sub
		Private Sub labelTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles labelTextBox.TextChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected label
			Dim label As NLabel = TryCast(labelsCombo.SelectedItem, NLabel)
			If label Is Nothing Then
				Return
			End If

			' update the label text
			label.Text = labelTextBox.Text
			document.SmartRefreshAllViews()
		End Sub
		Private Sub visibleCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles visibleCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected label
			Dim label As NLabel = TryCast(labelsCombo.SelectedItem, NLabel)
			If label Is Nothing Then
				Return
			End If

			' update the label visibility
			label.Visible = visibleCheck.Checked
			document.SmartRefreshAllViews()
		End Sub
		Private Sub textStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles textStyleButton.Click
			' get the selected label
			Dim label As NLabel = TryCast(labelsCombo.SelectedItem, NLabel)
			If label Is Nothing Then
				Return
			End If

			' edit the label text style
			MyBase.ShowTextStyleEditor(label)
		End Sub
		Private Sub percentPositionNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles percentPositionNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected label
			Dim label As NLogicalLineLabel = TryCast(labelsCombo.SelectedItem, NLogicalLineLabel)
			If label Is Nothing Then
				Return
			End If

			' change the logical line label percent position
			label.PercentPosition = CSng(percentPositionNumeric.Value)
			document.SmartRefreshAllViews()
		End Sub
		Private Sub useLineOrientationCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles useLineOrientationCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected label
			Dim label As NLogicalLineLabel = TryCast(labelsCombo.SelectedItem, NLogicalLineLabel)
			If label Is Nothing Then
				Return
			End If

			' specify whether the logical line label should follow the line orientation
			label.UseLineOrientation = useLineOrientationCheck.Checked
			document.SmartRefreshAllViews()
		End Sub
		Private Sub allowDownwardCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles allowDownwardCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected label
			Dim label As NLogicalLineLabel = TryCast(labelsCombo.SelectedItem, NLogicalLineLabel)
			If label Is Nothing Then
				Return
			End If

			' specify whether the logical line can have downward orientation
			label.AllowDownwardOrientation = allowDownwardCheck.Checked
			document.SmartRefreshAllViews()
		End Sub
		Private Sub allowDownwardCheck2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles allowDownwardCheck2.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected label
			Dim label As NRotatedBoundsLabel = TryCast(labelsCombo.SelectedItem, NRotatedBoundsLabel)
			If label Is Nothing Then
				Return
			End If

			' specify whether the rotated bounds label can have downward orientation
			label.AllowDownwardOrientation = allowDownwardCheck2.Checked
			document.SmartRefreshAllViews()
		End Sub
		Private Sub marginsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles marginsButton.Click
			' get the selected label
			Dim label As NBoundsLabel = TryCast(labelsCombo.SelectedItem, NBoundsLabel)
			If label Is Nothing Then
				Return
			End If

			' change the bounds label margins
			Dim margins As Nevron.Diagram.NMargins = New Nevron.Diagram.NMargins()
			If Nevron.Diagram.Editors.NMarginsTypeEditor.Edit(label.Margins, margins) = False Then
				Return
			End If

			label.Margins = margins
			document.SmartRefreshAllViews()
		End Sub
		Private Sub boxTextModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles boxTextModeCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected label
			Dim label As NBoundsLabel = TryCast(labelsCombo.SelectedItem, NBoundsLabel)
			If label Is Nothing Then
				Return
			End If

			' change the bounds label display mode
			label.Mode = CType(boxTextModeCombo.SelectedIndex, BoxTextMode)
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
		Private WithEvents labelsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private panel1 As System.Windows.Forms.Panel
		Private labelPropertiesGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents textStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents visibleCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As System.Windows.Forms.Label
		Private boundsLabelsGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents boxTextModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents marginsButton As Nevron.UI.WinForm.Controls.NButton
		Private lineLabelsGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents percentPositionNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label2 As System.Windows.Forms.Label
		Private WithEvents allowDownwardCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents useLineOrientationCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents labelTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents allowDownwardCheck2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private selectedShapeLabelsGroup As Nevron.UI.WinForm.Controls.NGroupBox

		#End Region


	End Class
End Namespace