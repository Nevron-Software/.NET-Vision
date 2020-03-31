Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NGridUC.
	''' </summary>
	Public Class NGridUC
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
			Me.horzStripesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.measurementUnitButton = New Nevron.Editors.NMeasurementUnitButton()
			Me.visibleCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.originYNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.originXNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			Me.showOriginCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.cellHeightNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.cellWidthNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.minorLinesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.majorLinesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.vertStripesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.gridStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.cellSizeModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox1.SuspendLayout()
			CType(Me.originYNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.originXNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cellHeightNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cellWidthNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' horzStripesButton
			' 
			Me.horzStripesButton.Location = New System.Drawing.Point(8, 55)
			Me.horzStripesButton.Name = "horzStripesButton"
			Me.horzStripesButton.Size = New System.Drawing.Size(112, 23)
			Me.horzStripesButton.TabIndex = 2
			Me.horzStripesButton.Text = "Horizontal stripes..."
'			Me.horzStripesButton.Click += New System.EventHandler(Me.horzStripesButton_Click);
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.measurementUnitButton)
			Me.nGroupBox1.Controls.Add(Me.visibleCheck)
			Me.nGroupBox1.Controls.Add(Me.originYNumeric)
			Me.nGroupBox1.Controls.Add(Me.label4)
			Me.nGroupBox1.Controls.Add(Me.originXNumeric)
			Me.nGroupBox1.Controls.Add(Me.label5)
			Me.nGroupBox1.Controls.Add(Me.showOriginCheck)
			Me.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(0, 0)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(256, 184)
			Me.nGroupBox1.TabIndex = 0
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "General"
			' 
			' measurementUnitButton
			' 
			Me.measurementUnitButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.measurementUnitButton.ArrowClickOptions = False
			Me.measurementUnitButton.ArrowWidth = 14
			Me.measurementUnitButton.DialogResult = System.Windows.Forms.DialogResult.No
			Me.measurementUnitButton.Location = New System.Drawing.Point(8, 144)
			Me.measurementUnitButton.Name = "measurementUnitButton"
			Me.measurementUnitButton.Size = New System.Drawing.Size(240, 23)
			Me.measurementUnitButton.TabIndex = 6
			Me.measurementUnitButton.Text = "Measurement Unit"
'			Me.measurementUnitButton.MeasurementUnitChanged += New System.EventHandler(Me.measurementUnitButton_MeasurementUnitChanged);
			' 
			' visibleCheck
			' 
			Me.visibleCheck.Location = New System.Drawing.Point(16, 16)
			Me.visibleCheck.Name = "visibleCheck"
			Me.visibleCheck.Size = New System.Drawing.Size(80, 24)
			Me.visibleCheck.TabIndex = 0
			Me.visibleCheck.Text = "Visible"
'			Me.visibleCheck.CheckedChanged += New System.EventHandler(Me.visibleCheck_CheckedChanged);
			' 
			' originYNumeric
			' 
			Me.originYNumeric.Location = New System.Drawing.Point(88, 110)
			Me.originYNumeric.Minimum = New System.Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.originYNumeric.Name = "originYNumeric"
			Me.originYNumeric.Size = New System.Drawing.Size(64, 22)
			Me.originYNumeric.TabIndex = 5
'			Me.originYNumeric.ValueChanged += New System.EventHandler(Me.originYNumeric_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(16, 112)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(64, 19)
			Me.label4.TabIndex = 4
			Me.label4.Text = "OriginY:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' originXNumeric
			' 
			Me.originXNumeric.Location = New System.Drawing.Point(88, 80)
			Me.originXNumeric.Minimum = New System.Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.originXNumeric.Name = "originXNumeric"
			Me.originXNumeric.Size = New System.Drawing.Size(64, 22)
			Me.originXNumeric.TabIndex = 3
'			Me.originXNumeric.ValueChanged += New System.EventHandler(Me.originXNumeric_ValueChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(16, 82)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(64, 19)
			Me.label5.TabIndex = 2
			Me.label5.Text = "OriginX:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' showOriginCheck
			' 
			Me.showOriginCheck.Location = New System.Drawing.Point(16, 48)
			Me.showOriginCheck.Name = "showOriginCheck"
			Me.showOriginCheck.Size = New System.Drawing.Size(80, 24)
			Me.showOriginCheck.TabIndex = 1
			Me.showOriginCheck.Text = "Show origin"
'			Me.showOriginCheck.CheckedChanged += New System.EventHandler(Me.showOriginCheck_CheckedChanged);
			' 
			' cellHeightNumeric
			' 
			Me.cellHeightNumeric.Enabled = False
			Me.cellHeightNumeric.Location = New System.Drawing.Point(88, 84)
			Me.cellHeightNumeric.Maximum = New System.Decimal(New Integer() { 1000, 0, 0, 0})
			Me.cellHeightNumeric.Name = "cellHeightNumeric"
			Me.cellHeightNumeric.Size = New System.Drawing.Size(64, 22)
			Me.cellHeightNumeric.TabIndex = 5
'			Me.cellHeightNumeric.ValueChanged += New System.EventHandler(Me.cellHeightNumeric_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(16, 83)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(64, 24)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Cell height:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' cellWidthNumeric
			' 
			Me.cellWidthNumeric.Enabled = False
			Me.cellWidthNumeric.Location = New System.Drawing.Point(88, 54)
			Me.cellWidthNumeric.Maximum = New System.Decimal(New Integer() { 1000, 0, 0, 0})
			Me.cellWidthNumeric.Name = "cellWidthNumeric"
			Me.cellWidthNumeric.Size = New System.Drawing.Size(64, 22)
			Me.cellWidthNumeric.TabIndex = 3
'			Me.cellWidthNumeric.ValueChanged += New System.EventHandler(Me.cellWidthNumeric_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(16, 53)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(64, 24)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Cell width:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.minorLinesButton)
			Me.nGroupBox2.Controls.Add(Me.majorLinesButton)
			Me.nGroupBox2.Controls.Add(Me.vertStripesButton)
			Me.nGroupBox2.Controls.Add(Me.gridStyleCombo)
			Me.nGroupBox2.Controls.Add(Me.label1)
			Me.nGroupBox2.Controls.Add(Me.horzStripesButton)
			Me.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(0, 184)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(256, 128)
			Me.nGroupBox2.TabIndex = 1
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Appearance"
			' 
			' minorLinesButton
			' 
			Me.minorLinesButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.minorLinesButton.Location = New System.Drawing.Point(128, 87)
			Me.minorLinesButton.Name = "minorLinesButton"
			Me.minorLinesButton.Size = New System.Drawing.Size(120, 23)
			Me.minorLinesButton.TabIndex = 5
			Me.minorLinesButton.Text = "Minor lines..."
'			Me.minorLinesButton.Click += New System.EventHandler(Me.minorLinesButton_Click);
			' 
			' majorLinesButton
			' 
			Me.majorLinesButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.majorLinesButton.Location = New System.Drawing.Point(128, 55)
			Me.majorLinesButton.Name = "majorLinesButton"
			Me.majorLinesButton.Size = New System.Drawing.Size(120, 23)
			Me.majorLinesButton.TabIndex = 4
			Me.majorLinesButton.Text = "Major lines..."
'			Me.majorLinesButton.Click += New System.EventHandler(Me.majorLinesButton_Click);
			' 
			' vertStripesButton
			' 
			Me.vertStripesButton.Location = New System.Drawing.Point(8, 87)
			Me.vertStripesButton.Name = "vertStripesButton"
			Me.vertStripesButton.Size = New System.Drawing.Size(112, 23)
			Me.vertStripesButton.TabIndex = 3
			Me.vertStripesButton.Text = "Vertical stripes..."
'			Me.vertStripesButton.Click += New System.EventHandler(Me.vertStripesButton_Click);
			' 
			' gridStyleCombo
			' 
			Me.gridStyleCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.gridStyleCombo.Location = New System.Drawing.Point(88, 24)
			Me.gridStyleCombo.Name = "gridStyleCombo"
			Me.gridStyleCombo.Size = New System.Drawing.Size(160, 22)
			Me.gridStyleCombo.TabIndex = 1
			Me.gridStyleCombo.Text = "nComboBox1"
'			Me.gridStyleCombo.SelectedIndexChanged += New System.EventHandler(Me.gridStyleCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(16, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(56, 24)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Grid style:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.Controls.Add(Me.label6)
			Me.nGroupBox3.Controls.Add(Me.cellHeightNumeric)
			Me.nGroupBox3.Controls.Add(Me.cellWidthNumeric)
			Me.nGroupBox3.Controls.Add(Me.label2)
			Me.nGroupBox3.Controls.Add(Me.label3)
			Me.nGroupBox3.Controls.Add(Me.cellSizeModeComboBox)
			Me.nGroupBox3.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox3.ImageIndex = 0
			Me.nGroupBox3.Location = New System.Drawing.Point(0, 312)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(256, 120)
			Me.nGroupBox3.TabIndex = 2
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "Cell sizing"
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(16, 27)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(64, 16)
			Me.label6.TabIndex = 0
			Me.label6.Text = "Mode:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' cellSizeModeComboBox
			' 
			Me.cellSizeModeComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cellSizeModeComboBox.Location = New System.Drawing.Point(88, 24)
			Me.cellSizeModeComboBox.Name = "cellSizeModeComboBox"
			Me.cellSizeModeComboBox.Size = New System.Drawing.Size(160, 22)
			Me.cellSizeModeComboBox.TabIndex = 1
			Me.cellSizeModeComboBox.Text = "nComboBox1"
'			Me.cellSizeModeComboBox.SelectedIndexChanged += New System.EventHandler(Me.cellSizeModeComboBox_SelectedIndexChanged);
			' 
			' NGridUC
			' 
			Me.Controls.Add(Me.nGroupBox3)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Name = "NGridUC"
			Me.Size = New System.Drawing.Size(256, 624)
			Me.Controls.SetChildIndex(Me.nGroupBox1, 0)
			Me.Controls.SetChildIndex(Me.nGroupBox2, 0)
			Me.Controls.SetChildIndex(Me.nGroupBox3, 0)
			Me.nGroupBox1.ResumeLayout(False)
			CType(Me.originYNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.originXNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cellHeightNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cellWidthNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init document
			document.BeginInit()
			CreateDefaultFlowDiagram()
			document.EndInit()

			' update the form from the grid
			UpdateFromGrid()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub ResetExample()
			view.Reset()
			MyBase.ResetExample()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub UpdateFromGrid()
			PauseEventsHandling()

			showOriginCheck.Checked = view.Grid.ShowOrigin
			visibleCheck.Checked = view.Grid.Visible

			originXNumeric.Value = CDec(view.Grid.Origin.X)
			originYNumeric.Value = CDec(view.Grid.Origin.Y)

			measurementUnitButton.SetSystemManagerAndUnit(NMeasurementSystemManager.DefaultMeasurementSystemManager, view.Grid.MeasurementUnit)

			cellSizeModeComboBox.FillFromEnum(GetType(AutoStepMode))
			cellSizeModeComboBox.SelectedItem = view.Grid.CellSizeMode

			cellWidthNumeric.Value = CDec(view.Grid.FixedCellSize.Width)
			cellHeightNumeric.Value = CDec(view.Grid.FixedCellSize.Height)

			gridStyleCombo.FillFromEnum(GetType(GridStyle))
			gridStyleCombo.SelectedItem = view.Grid.GridStyle

			ResumeEventsHandling()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub cellWidthNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cellWidthNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim width As Single = CSng(cellWidthNumeric.Value)
			Dim height As Single = CSng(view.Grid.GetUsedCellSize().Height)
			view.Grid.FixedCellSize = New NSizeF(width, height)

			view.SmartRefresh()
		End Sub

		Private Sub cellHeightNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cellHeightNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim width As Single = CSng(view.Grid.GetUsedCellSize().Width)
			Dim height As Single = CSng(cellHeightNumeric.Value)
			view.Grid.FixedCellSize = New NSizeF(width, height)

			view.SmartRefresh()
		End Sub

		Private Sub originXNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles originXNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim x As Single = CSng(originXNumeric.Value)
			Dim y As Single = view.Grid.Origin.Y
			view.Grid.Origin = New NPointF(x, y)

			view.SmartRefresh()
		End Sub

		Private Sub originYNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles originYNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim x As Single = CSng(view.Grid.Origin.X)
			Dim y As Single = CSng(originYNumeric.Value)
			view.Grid.Origin = New NPointF(x, y)

			view.SmartRefresh()
		End Sub

		Private Sub showOriginCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles showOriginCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			view.Grid.ShowOrigin = showOriginCheck.Checked
			view.SmartRefresh()
		End Sub

		Private Sub gridStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridStyleCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim style As GridStyle = CType(gridStyleCombo.SelectedItem, GridStyle)
			view.Grid.GridStyle = style
			view.SmartRefresh()
		End Sub

		Private Sub horzStripesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles horzStripesButton.Click
			Dim style As NFillStyle = view.Grid.HorizontalStripesFillStyle
			If (Not NFillStyleTypeEditor.Edit(style, style)) Then
				Return
			End If

			view.Grid.HorizontalStripesFillStyle = style
			view.SmartRefresh()
		End Sub

		Private Sub vertStripesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles vertStripesButton.Click
			Dim style As NFillStyle = view.Grid.VerticalStripesFillStyle
			If (Not NFillStyleTypeEditor.Edit(style, style)) Then
				Return
			End If

			view.Grid.VerticalStripesFillStyle = style
			view.SmartRefresh()
		End Sub

		Private Sub majorLinesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles majorLinesButton.Click
			Dim style As NStrokeStyle = view.Grid.MajorLinesStrokeStyle
			If (Not NStrokeStyleTypeEditor.Edit(style, style)) Then
				Return
			End If

			view.Grid.MajorLinesStrokeStyle = style
			view.SmartRefresh()
		End Sub

		Private Sub minorLinesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles minorLinesButton.Click
			Dim style As NStrokeStyle = view.Grid.MinorLinesStrokeStyle
			If (Not NStrokeStyleTypeEditor.Edit(style, style)) Then
				Return
			End If

			view.Grid.MinorLinesStrokeStyle = style
			view.SmartRefresh()
		End Sub

		Private Sub visibleCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles visibleCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			view.Grid.Visible = visibleCheck.Checked
			view.SmartRefresh()
		End Sub

		Private Sub cellSizeModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cellSizeModeComboBox.SelectedIndexChanged
			If cellSizeModeComboBox.SelectedIndex = -1 Then
				Return
			End If

			view.Grid.CellSizeMode = CType(cellSizeModeComboBox.SelectedItem, AutoStepMode)
			If view.Grid.CellSizeMode = AutoStepMode.Fixed Then
				Try
					cellWidthNumeric.Value = CDec(view.Grid.GetUsedCellSize().Width)
					cellHeightNumeric.Value = CDec(view.Grid.GetUsedCellSize().Height)
				Catch ex As Exception
					Debug.WriteLine(ex.Message)
					cellWidthNumeric.Value = cellWidthNumeric.Maximum
					cellHeightNumeric.Value = cellHeightNumeric.Maximum
				End Try

				Me.cellWidthNumeric.Enabled = True
				Me.cellHeightNumeric.Enabled = True
			Else
				Me.cellWidthNumeric.Enabled = False
				Me.cellHeightNumeric.Enabled = False
			End If

			document.RefreshAllViews()
		End Sub

		Private Sub measurementUnitButton_MeasurementUnitChanged(ByVal sender As Object, ByVal e As EventArgs) Handles measurementUnitButton.MeasurementUnitChanged
			If EventsHandlingPaused Then
				Return
			End If

			view.Grid.MeasurementUnit = measurementUnitButton.MeasurementUnit
			UpdateFromGrid()
		End Sub


		#End Region

		#Region "Designer Fields"

		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents cellSizeModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents gridStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents visibleCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents originYNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents originXNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents cellHeightNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents cellWidthNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents showOriginCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents horzStripesButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents vertStripesButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents minorLinesButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents majorLinesButton As Nevron.UI.WinForm.Controls.NButton
		Private label6 As System.Windows.Forms.Label
		Private WithEvents measurementUnitButton As Nevron.Editors.NMeasurementUnitButton
		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace