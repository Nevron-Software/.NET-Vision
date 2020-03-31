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
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NRulersUC.
	''' </summary>
	Public Class NRulersUC
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.appearanceGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.fontButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.paddingNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.sizeNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.originNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.generalGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.measurementUnitButton = New Nevron.Editors.NMeasurementUnitButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.ticksStepNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.colorsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label10 = New System.Windows.Forms.Label()
			Me.coordinateHighlightColorButton = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.label9 = New System.Windows.Forms.Label()
			Me.frameColorButton = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.label8 = New System.Windows.Forms.Label()
			Me.backColorButton = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.label7 = New System.Windows.Forms.Label()
			Me.textColorButton = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.label6 = New System.Windows.Forms.Label()
			Me.minorTicksColorButton = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.label5 = New System.Windows.Forms.Label()
			Me.majorTicksColorButton = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.highlightColorButton = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.label12 = New System.Windows.Forms.Label()
			Me.majorTicksGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.ticksStepModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.rulerPropertiesPanel = New System.Windows.Forms.Panel()
			Me.panel3 = New System.Windows.Forms.Panel()
			Me.selectRulerPanel = New System.Windows.Forms.Panel()
			Me.vRulerRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.hRulerRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.appearanceGroup.SuspendLayout()
			CType(Me.paddingNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.sizeNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.originNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.generalGroup.SuspendLayout()
			CType(Me.ticksStepNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.colorsGroup.SuspendLayout()
			Me.majorTicksGroup.SuspendLayout()
			Me.rulerPropertiesPanel.SuspendLayout()
			Me.panel3.SuspendLayout()
			Me.selectRulerPanel.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(96, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Size:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' appearanceGroup
			' 
			Me.appearanceGroup.Controls.Add(Me.fontButton)
			Me.appearanceGroup.Controls.Add(Me.paddingNumeric)
			Me.appearanceGroup.Controls.Add(Me.label2)
			Me.appearanceGroup.Controls.Add(Me.sizeNumeric)
			Me.appearanceGroup.Controls.Add(Me.label1)
			Me.appearanceGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.appearanceGroup.ImageIndex = 0
			Me.appearanceGroup.Location = New System.Drawing.Point(0, 216)
			Me.appearanceGroup.Name = "appearanceGroup"
			Me.appearanceGroup.Size = New System.Drawing.Size(248, 112)
			Me.appearanceGroup.TabIndex = 0
			Me.appearanceGroup.TabStop = False
			Me.appearanceGroup.Text = "Appearance"
			' 
			' fontButton
			' 
			Me.fontButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.fontButton.Location = New System.Drawing.Point(8, 80)
			Me.fontButton.Name = "fontButton"
			Me.fontButton.Size = New System.Drawing.Size(232, 23)
			Me.fontButton.TabIndex = 4
			Me.fontButton.Text = "Font..."
			'			Me.fontButton.Click += New System.EventHandler(Me.fontButton_Click);
			' 
			' paddingNumeric
			' 
			Me.paddingNumeric.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.paddingNumeric.Location = New System.Drawing.Point(128, 48)
			Me.paddingNumeric.Name = "paddingNumeric"
			Me.paddingNumeric.Size = New System.Drawing.Size(110, 22)
			Me.paddingNumeric.TabIndex = 3
			'			Me.paddingNumeric.ValueChanged += New System.EventHandler(Me.paddingNumeric_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 48)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(96, 23)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Padding:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' sizeNumeric
			' 
			Me.sizeNumeric.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.sizeNumeric.Location = New System.Drawing.Point(128, 24)
			Me.sizeNumeric.Name = "sizeNumeric"
			Me.sizeNumeric.Size = New System.Drawing.Size(110, 22)
			Me.sizeNumeric.TabIndex = 1
			'			Me.sizeNumeric.ValueChanged += New System.EventHandler(Me.sizeNumeric_ValueChanged);
			' 
			' originNumeric
			' 
			Me.originNumeric.Location = New System.Drawing.Point(128, 16)
			Me.originNumeric.Name = "originNumeric"
			Me.originNumeric.Size = New System.Drawing.Size(112, 22)
			Me.originNumeric.TabIndex = 1
			'			Me.originNumeric.ValueChanged += New System.EventHandler(Me.originNumeric_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 15)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(104, 23)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Origin:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' generalGroup
			' 
			Me.generalGroup.Controls.Add(Me.measurementUnitButton)
			Me.generalGroup.Controls.Add(Me.label3)
			Me.generalGroup.Controls.Add(Me.originNumeric)
			Me.generalGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.generalGroup.ImageIndex = 0
			Me.generalGroup.Location = New System.Drawing.Point(0, 416)
			Me.generalGroup.Name = "generalGroup"
			Me.generalGroup.Size = New System.Drawing.Size(248, 80)
			Me.generalGroup.TabIndex = 2
			Me.generalGroup.TabStop = False
			Me.generalGroup.Text = "General"
			' 
			' measurementUnitButton
			' 
			Me.measurementUnitButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.measurementUnitButton.ArrowClickOptions = False
			Me.measurementUnitButton.ArrowWidth = 14
			Me.measurementUnitButton.DialogResult = System.Windows.Forms.DialogResult.No
			Me.measurementUnitButton.Location = New System.Drawing.Point(8, 48)
			Me.measurementUnitButton.Name = "measurementUnitButton"
			Me.measurementUnitButton.Size = New System.Drawing.Size(230, 23)
			Me.measurementUnitButton.TabIndex = 4
			Me.measurementUnitButton.Text = "Measurement Unit"
			'			Me.measurementUnitButton.MeasurementUnitChanged += New System.EventHandler(Me.measurementUnitButton_MeasurementUnitChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 56)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(120, 23)
			Me.label4.TabIndex = 1
			Me.label4.Text = "Major ticks fixed step:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ticksStepNumeric
			' 
			Me.ticksStepNumeric.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.ticksStepNumeric.Enabled = False
			Me.ticksStepNumeric.Location = New System.Drawing.Point(128, 56)
			Me.ticksStepNumeric.Maximum = New System.Decimal(New Integer() {1000, 0, 0, 0})
			Me.ticksStepNumeric.Name = "ticksStepNumeric"
			Me.ticksStepNumeric.Size = New System.Drawing.Size(110, 22)
			Me.ticksStepNumeric.TabIndex = 2
			'			Me.ticksStepNumeric.ValueChanged += New System.EventHandler(Me.ticksStepNumeric_ValueChanged);
			' 
			' colorsGroup
			' 
			Me.colorsGroup.Controls.Add(Me.label10)
			Me.colorsGroup.Controls.Add(Me.coordinateHighlightColorButton)
			Me.colorsGroup.Controls.Add(Me.label9)
			Me.colorsGroup.Controls.Add(Me.frameColorButton)
			Me.colorsGroup.Controls.Add(Me.label8)
			Me.colorsGroup.Controls.Add(Me.backColorButton)
			Me.colorsGroup.Controls.Add(Me.label7)
			Me.colorsGroup.Controls.Add(Me.textColorButton)
			Me.colorsGroup.Controls.Add(Me.label6)
			Me.colorsGroup.Controls.Add(Me.minorTicksColorButton)
			Me.colorsGroup.Controls.Add(Me.label5)
			Me.colorsGroup.Controls.Add(Me.majorTicksColorButton)
			Me.colorsGroup.Controls.Add(Me.highlightColorButton)
			Me.colorsGroup.Controls.Add(Me.label12)
			Me.colorsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.colorsGroup.ImageIndex = 0
			Me.colorsGroup.Location = New System.Drawing.Point(0, 0)
			Me.colorsGroup.Name = "colorsGroup"
			Me.colorsGroup.Size = New System.Drawing.Size(248, 216)
			Me.colorsGroup.TabIndex = 0
			Me.colorsGroup.TabStop = False
			Me.colorsGroup.Text = "Colors"
			' 
			' label10
			' 
			Me.label10.Location = New System.Drawing.Point(8, 154)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(112, 23)
			Me.label10.TabIndex = 10
			Me.label10.Text = "Coordinate highlight:"
			Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' coordinateHighlightColorButton
			' 
			Me.coordinateHighlightColorButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.coordinateHighlightColorButton.ArrowClickOptions = False
			Me.coordinateHighlightColorButton.ArrowWidth = 14
			Me.coordinateHighlightColorButton.Location = New System.Drawing.Point(128, 154)
			Me.coordinateHighlightColorButton.Name = "coordinateHighlightColorButton"
			Me.coordinateHighlightColorButton.Size = New System.Drawing.Size(110, 22)
			Me.coordinateHighlightColorButton.TabIndex = 11
			'			Me.coordinateHighlightColorButton.ColorChanged += New System.EventHandler(Me.coordinateHighlightColorButton_ColorChanged);
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(8, 128)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(112, 23)
			Me.label9.TabIndex = 8
			Me.label9.Text = "Frame:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' frameColorButton
			' 
			Me.frameColorButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.frameColorButton.ArrowClickOptions = False
			Me.frameColorButton.ArrowWidth = 14
			Me.frameColorButton.Location = New System.Drawing.Point(128, 128)
			Me.frameColorButton.Name = "frameColorButton"
			Me.frameColorButton.Size = New System.Drawing.Size(110, 22)
			Me.frameColorButton.TabIndex = 9
			'			Me.frameColorButton.ColorChanged += New System.EventHandler(Me.frameColorButton_ColorChanged);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 102)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(112, 23)
			Me.label8.TabIndex = 6
			Me.label8.Text = "Back color:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' backColorButton
			' 
			Me.backColorButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.backColorButton.ArrowClickOptions = False
			Me.backColorButton.ArrowWidth = 14
			Me.backColorButton.Location = New System.Drawing.Point(128, 102)
			Me.backColorButton.Name = "backColorButton"
			Me.backColorButton.Size = New System.Drawing.Size(110, 22)
			Me.backColorButton.TabIndex = 7
			'			Me.backColorButton.ColorChanged += New System.EventHandler(Me.backColorButton_ColorChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 76)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(112, 23)
			Me.label7.TabIndex = 4
			Me.label7.Text = "Text:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' textColorButton
			' 
			Me.textColorButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.textColorButton.ArrowClickOptions = False
			Me.textColorButton.ArrowWidth = 14
			Me.textColorButton.Location = New System.Drawing.Point(128, 76)
			Me.textColorButton.Name = "textColorButton"
			Me.textColorButton.Size = New System.Drawing.Size(110, 22)
			Me.textColorButton.TabIndex = 5
			'			Me.textColorButton.ColorChanged += New System.EventHandler(Me.textColorButton_ColorChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 50)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(112, 23)
			Me.label6.TabIndex = 2
			Me.label6.Text = "Minor ticks:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' minorTicksColorButton
			' 
			Me.minorTicksColorButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.minorTicksColorButton.ArrowClickOptions = False
			Me.minorTicksColorButton.ArrowWidth = 14
			Me.minorTicksColorButton.Location = New System.Drawing.Point(128, 50)
			Me.minorTicksColorButton.Name = "minorTicksColorButton"
			Me.minorTicksColorButton.Size = New System.Drawing.Size(110, 22)
			Me.minorTicksColorButton.TabIndex = 3
			'			Me.minorTicksColorButton.ColorChanged += New System.EventHandler(Me.minorTicksColorButton_ColorChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 24)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(112, 23)
			Me.label5.TabIndex = 0
			Me.label5.Text = "Major ticks:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' majorTicksColorButton
			' 
			Me.majorTicksColorButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.majorTicksColorButton.ArrowClickOptions = False
			Me.majorTicksColorButton.ArrowWidth = 14
			Me.majorTicksColorButton.Location = New System.Drawing.Point(128, 24)
			Me.majorTicksColorButton.Name = "majorTicksColorButton"
			Me.majorTicksColorButton.Size = New System.Drawing.Size(110, 22)
			Me.majorTicksColorButton.TabIndex = 1
			'			Me.majorTicksColorButton.ColorChanged += New System.EventHandler(Me.majorTicksColorButton_ColorChanged);
			' 
			' highlightColorButton
			' 
			Me.highlightColorButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.highlightColorButton.ArrowClickOptions = False
			Me.highlightColorButton.ArrowWidth = 14
			Me.highlightColorButton.Location = New System.Drawing.Point(128, 180)
			Me.highlightColorButton.Name = "highlightColorButton"
			Me.highlightColorButton.Size = New System.Drawing.Size(110, 22)
			Me.highlightColorButton.TabIndex = 13
			'			Me.highlightColorButton.ColorChanged += New System.EventHandler(Me.highlightColorButton_ColorChanged);
			' 
			' label12
			' 
			Me.label12.Location = New System.Drawing.Point(8, 180)
			Me.label12.Name = "label12"
			Me.label12.Size = New System.Drawing.Size(112, 23)
			Me.label12.TabIndex = 12
			Me.label12.Text = "Range highlight:"
			Me.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' majorTicksGroup
			' 
			Me.majorTicksGroup.Controls.Add(Me.ticksStepModeComboBox)
			Me.majorTicksGroup.Controls.Add(Me.label4)
			Me.majorTicksGroup.Controls.Add(Me.ticksStepNumeric)
			Me.majorTicksGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.majorTicksGroup.ImageIndex = 0
			Me.majorTicksGroup.Location = New System.Drawing.Point(0, 328)
			Me.majorTicksGroup.Name = "majorTicksGroup"
			Me.majorTicksGroup.Size = New System.Drawing.Size(248, 88)
			Me.majorTicksGroup.TabIndex = 1
			Me.majorTicksGroup.TabStop = False
			Me.majorTicksGroup.Text = "Major ticks step mode"
			' 
			' ticksStepModeComboBox
			' 
			Me.ticksStepModeComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.ticksStepModeComboBox.Location = New System.Drawing.Point(8, 24)
			Me.ticksStepModeComboBox.Name = "ticksStepModeComboBox"
			Me.ticksStepModeComboBox.Size = New System.Drawing.Size(232, 22)
			Me.ticksStepModeComboBox.TabIndex = 0
			Me.ticksStepModeComboBox.Text = "nComboBox1"
			'			Me.ticksStepModeComboBox.SelectedIndexChanged += New System.EventHandler(Me.ticksStepModeComboBox_SelectedIndexChanged);
			' 
			' rulerPropertiesPanel
			' 
			Me.rulerPropertiesPanel.Controls.Add(Me.generalGroup)
			Me.rulerPropertiesPanel.Controls.Add(Me.majorTicksGroup)
			Me.rulerPropertiesPanel.Controls.Add(Me.appearanceGroup)
			Me.rulerPropertiesPanel.Controls.Add(Me.colorsGroup)
			Me.rulerPropertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.rulerPropertiesPanel.Location = New System.Drawing.Point(0, 40)
			Me.rulerPropertiesPanel.Name = "rulerPropertiesPanel"
			Me.rulerPropertiesPanel.Size = New System.Drawing.Size(248, 560)
			Me.rulerPropertiesPanel.TabIndex = 30
			' 
			' panel3
			' 
			Me.panel3.Controls.Add(Me.rulerPropertiesPanel)
			Me.panel3.Controls.Add(Me.selectRulerPanel)
			Me.panel3.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel3.Location = New System.Drawing.Point(0, 0)
			Me.panel3.Name = "panel3"
			Me.panel3.Size = New System.Drawing.Size(248, 600)
			Me.panel3.TabIndex = 32
			' 
			' selectRulerPanel
			' 
			Me.selectRulerPanel.Controls.Add(Me.vRulerRadioButton)
			Me.selectRulerPanel.Controls.Add(Me.hRulerRadioButton)
			Me.selectRulerPanel.Dock = System.Windows.Forms.DockStyle.Top
			Me.selectRulerPanel.Location = New System.Drawing.Point(0, 0)
			Me.selectRulerPanel.Name = "selectRulerPanel"
			Me.selectRulerPanel.Size = New System.Drawing.Size(248, 40)
			Me.selectRulerPanel.TabIndex = 0
			' 
			' vRulerRadioButton
			' 
			Me.vRulerRadioButton.Location = New System.Drawing.Point(120, 8)
			Me.vRulerRadioButton.Name = "vRulerRadioButton"
			Me.vRulerRadioButton.TabIndex = 1
			Me.vRulerRadioButton.Text = "Vertical ruler"
			'			Me.vRulerRadioButton.CheckedChanged += New System.EventHandler(Me.vRulerRadioButton_CheckedChanged);
			' 
			' hRulerRadioButton
			' 
			Me.hRulerRadioButton.Location = New System.Drawing.Point(8, 8)
			Me.hRulerRadioButton.Name = "hRulerRadioButton"
			Me.hRulerRadioButton.TabIndex = 0
			Me.hRulerRadioButton.Text = "Horizontal ruler"
			'			Me.hRulerRadioButton.CheckedChanged += New System.EventHandler(Me.hRulerRadioButton_CheckedChanged);
			' 
			' NRulersUC
			' 
			Me.Controls.Add(Me.panel3)
			Me.Name = "NRulersUC"
			Me.Size = New System.Drawing.Size(248, 700)
			Me.Controls.SetChildIndex(Me.panel3, 0)
			Me.appearanceGroup.ResumeLayout(False)
			CType(Me.paddingNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.sizeNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.originNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.generalGroup.ResumeLayout(False)
			CType(Me.ticksStepNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.colorsGroup.ResumeLayout(False)
			Me.majorTicksGroup.ResumeLayout(False)
			Me.rulerPropertiesPanel.ResumeLayout(False)
			Me.panel3.ResumeLayout(False)
			Me.selectRulerPanel.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
#End Region

#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			document.HistoryService.Pause()

			CreateDefaultFlowDiagram()
			document.HistoryService.Resume()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub ResetExample()
			view.Reset()
			MyBase.ResetExample()
		End Sub

#End Region

#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			ticksStepModeComboBox.FillFromEnum(GetType(AutoStepMode))
			ticksStepModeComboBox.SelectedItem = AutoStepMode.Normal

			hRulerRadioButton.Checked = True
			curRuler = view.HorizontalRuler
			UpdateFromRuler(curRuler)

			ResumeEventsHandling()
		End Sub

		Private Sub UpdateFromRuler(ByVal ruler As NRuler)
			PauseEventsHandling()
			Try
				originNumeric.Value = CInt(Fix(ruler.Origin))
				sizeNumeric.Value = CInt(Fix(ruler.Size))
				paddingNumeric.Value = CInt(Fix(ruler.Padding))

				ticksStepModeComboBox.SelectedItem = ruler.MajorTicksStepMode
				ticksStepNumeric.Value = CInt(Fix(ruler.FixedMajorTicksStep))

				majorTicksColorButton.Color = ruler.MajorTicksColor
				minorTicksColorButton.Color = ruler.MinorTicksColor
				textColorButton.Color = ruler.TextColor
				backColorButton.Color = ruler.BackColor
				frameColorButton.Color = ruler.FrameColor
				coordinateHighlightColorButton.Color = ruler.HighlightCoordinateColor
				highlightColorButton.Color = ruler.HighlightRangeColor

				measurementUnitButton.SetSystemManagerAndUnit(NMeasurementSystemManager.DefaultMeasurementSystemManager, ruler.MeasurementUnit)
			Finally
				ResumeEventsHandling()
			End Try
		End Sub

#End Region

#Region "Event Handlers"

		Private Sub hRulerRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hRulerRadioButton.CheckedChanged
			If (Not hRulerRadioButton.Checked) Then
				Return
			End If

			curRuler = view.HorizontalRuler
			UpdateFromRuler(curRuler)
		End Sub

		Private Sub vRulerRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vRulerRadioButton.CheckedChanged
			If (Not vRulerRadioButton.Checked) Then
				Return
			End If

			curRuler = view.VerticalRuler
			UpdateFromRuler(curRuler)
		End Sub

		Private Sub originNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles originNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			curRuler.Origin = CSng(originNumeric.Value)
			view.Refresh()
		End Sub

		Private Sub ticksStepNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ticksStepNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			curRuler.FixedMajorTicksStep = CSng(ticksStepNumeric.Value)
			view.Refresh()
		End Sub

		Private Sub sizeNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sizeNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			curRuler.Size = CInt(Fix(sizeNumeric.Value))
			view.Refresh()
		End Sub

		Private Sub paddingNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles paddingNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			curRuler.Padding = CInt(Fix(paddingNumeric.Value))
			view.Refresh()
		End Sub

		Private Sub fontButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles fontButton.Click
			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			Dim dialog As FontDialog = New FontDialog()
			dialog.Font = curRuler.TextFontStyle.CreateFont(view.MeasurementUnitConverter)
			If dialog.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If

			curRuler.TextFontStyle = New NFontStyle(dialog.Font)
			view.Refresh()
		End Sub

		Private Sub majorTicksColorButton_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles majorTicksColorButton.ColorChanged
			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			curRuler.MajorTicksColor = majorTicksColorButton.Color
			view.Refresh()
		End Sub

		Private Sub minorTicksColorButton_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles minorTicksColorButton.ColorChanged
			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			curRuler.MinorTicksColor = minorTicksColorButton.Color
			view.Refresh()
		End Sub

		Private Sub textColorButton_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textColorButton.ColorChanged
			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			curRuler.TextColor = textColorButton.Color
			view.Refresh()
		End Sub

		Private Sub backColorButton_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles backColorButton.ColorChanged
			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			curRuler.BackColor = backColorButton.Color
			view.Refresh()
		End Sub

		Private Sub frameColorButton_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles frameColorButton.ColorChanged
			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			curRuler.FrameColor = frameColorButton.Color
			view.Refresh()
		End Sub

		Private Sub coordinateHighlightColorButton_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles coordinateHighlightColorButton.ColorChanged
			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			curRuler.HighlightCoordinateColor = coordinateHighlightColorButton.Color
			view.Refresh()
		End Sub

		Private Sub highlightColorButton_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles highlightColorButton.ColorChanged
			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			curRuler.HighlightRangeColor = highlightColorButton.Color
			view.Refresh()
		End Sub

		Private Sub ticksStepModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ticksStepModeComboBox.SelectedIndexChanged
			If CType(ticksStepModeComboBox.SelectedItem, AutoStepMode) = AutoStepMode.Fixed Then
				ticksStepNumeric.Enabled = True
			Else
				ticksStepNumeric.Enabled = False
			End If

			If EventsHandlingPaused Then
				Return
			End If

			If curRuler Is Nothing Then
				Return
			End If

			If ticksStepModeComboBox.SelectedIndex = -1 Then
				Return
			End If

			curRuler.MajorTicksStepMode = CType(ticksStepModeComboBox.SelectedItem, AutoStepMode)
			If curRuler.MajorTicksStepMode = AutoStepMode.Fixed Then
				Try
					ticksStepNumeric.Value = CDec(curRuler.GetUsedMajorTickStep())
				Catch ex As Exception
					Debug.WriteLine(ex.Message)
					ticksStepNumeric.Value = ticksStepNumeric.Maximum
				End Try
			End If

			document.RefreshAllViews()
		End Sub

		Private Sub measurementUnitButton_MeasurementUnitChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles measurementUnitButton.MeasurementUnitChanged
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()
			Try
				curRuler.MeasurementUnit = measurementUnitButton.MeasurementUnit
			Finally
				ResumeEventsHandling()
			End Try

			view.SmartRefresh()
		End Sub

#End Region

#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private label12 As System.Windows.Forms.Label
		Private WithEvents coordinateHighlightColorButton As Nevron.UI.WinForm.Controls.NColorButton
		Private WithEvents highlightColorButton As Nevron.UI.WinForm.Controls.NColorButton
		Private WithEvents measurementUnitButton As Nevron.Editors.NMeasurementUnitButton
		Private WithEvents ticksStepModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents originNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ticksStepNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents fontButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents paddingNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents sizeNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents frameColorButton As Nevron.UI.WinForm.Controls.NColorButton
		Private WithEvents backColorButton As Nevron.UI.WinForm.Controls.NColorButton
		Private WithEvents textColorButton As Nevron.UI.WinForm.Controls.NColorButton
		Private WithEvents minorTicksColorButton As Nevron.UI.WinForm.Controls.NColorButton
		Private WithEvents majorTicksColorButton As Nevron.UI.WinForm.Controls.NColorButton
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private panel3 As System.Windows.Forms.Panel
		Private WithEvents vRulerRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents hRulerRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private appearanceGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private generalGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private colorsGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private majorTicksGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private selectRulerPanel As System.Windows.Forms.Panel
		Private rulerPropertiesPanel As System.Windows.Forms.Panel

#End Region

#Region "Fields"

		Private curRuler As NRuler

#End Region
	End Class
End Namespace
