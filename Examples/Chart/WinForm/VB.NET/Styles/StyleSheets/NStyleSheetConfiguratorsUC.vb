Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStyleSheetConfiguratorsUC
		Inherits NExampleBaseUC

		Public Sub New()
			InitializeComponent()
		End Sub

		Private label2 As Label
		Private label3 As Label
		Private label4 As Label
		Private label5 As Label
		Private label6 As Label
		Private label7 As Label
		Private label8 As Label
		Private label9 As Label
		Private label10 As Label
		Private WithEvents MultiColorSeriesCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BackgroundFillTemplateComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents LabelsFillTemplateComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents WallsFillTemplateComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents SeriesFillTemplateComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents IndicatorsFillTemplateComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private groupBox1 As GroupBox
		Private groupBox2 As GroupBox
		Private WithEvents LabelsStrokeTemplateComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents IndicatorsStrokeTemplateComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents MultiColorSeriesStrokeCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RulerStrokeTemplateComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents SeriesStrokeTemplateComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ApplyToDataLabelsCheckBox As Nevron.UI.WinForm.Controls.NCheckBox

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing



		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.PaletteComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.MultiColorSeriesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.BackgroundFillTemplateComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.LabelsFillTemplateComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.WallsFillTemplateComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.SeriesFillTemplateComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.IndicatorsFillTemplateComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.ApplyToDataLabelsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LabelsStrokeTemplateComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.IndicatorsStrokeTemplateComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.MultiColorSeriesStrokeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.RulerStrokeTemplateComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label9 = New System.Windows.Forms.Label()
			Me.SeriesStrokeTemplateComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label10 = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' PaletteComboBox
			' 
			Me.PaletteComboBox.Location = New System.Drawing.Point(12, 29)
			Me.PaletteComboBox.Name = "PaletteComboBox"
			Me.PaletteComboBox.Size = New System.Drawing.Size(181, 21)
			Me.PaletteComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PaletteComboBox.SelectedIndexChanged += new System.EventHandler(this.PaletteComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(9, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(43, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Palette:"
			' 
			' MultiColorSeriesCheckBox
			' 
			Me.MultiColorSeriesCheckBox.AutoSize = True
			Me.MultiColorSeriesCheckBox.ButtonProperties.BorderOffset = 2
			Me.MultiColorSeriesCheckBox.Location = New System.Drawing.Point(15, 189)
			Me.MultiColorSeriesCheckBox.Name = "MultiColorSeriesCheckBox"
			Me.MultiColorSeriesCheckBox.Size = New System.Drawing.Size(107, 17)
			Me.MultiColorSeriesCheckBox.TabIndex = 8
			Me.MultiColorSeriesCheckBox.Text = "Multi Color Series"
			Me.MultiColorSeriesCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MultiColorSeriesCheckBox.CheckedChanged += new System.EventHandler(this.MultiColorSeriesCheckBox_CheckedChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(15, 24)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(112, 13)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Background Template"
			' 
			' BackgroundFillTemplateComboBox
			' 
			Me.BackgroundFillTemplateComboBox.Location = New System.Drawing.Point(15, 41)
			Me.BackgroundFillTemplateComboBox.Name = "BackgroundFillTemplateComboBox"
			Me.BackgroundFillTemplateComboBox.Size = New System.Drawing.Size(149, 21)
			Me.BackgroundFillTemplateComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BackgroundFillTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.BackgroundFillTemplateComboBox_SelectedIndexChanged);
			' 
			' LabelsFillTemplateComboBox
			' 
			Me.LabelsFillTemplateComboBox.Location = New System.Drawing.Point(15, 82)
			Me.LabelsFillTemplateComboBox.Name = "LabelsFillTemplateComboBox"
			Me.LabelsFillTemplateComboBox.Size = New System.Drawing.Size(149, 21)
			Me.LabelsFillTemplateComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelsFillTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelsFillTemplateComboBox_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(15, 65)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(85, 13)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Labels Template"
			' 
			' WallsFillTemplateComboBox
			' 
			Me.WallsFillTemplateComboBox.Location = New System.Drawing.Point(15, 123)
			Me.WallsFillTemplateComboBox.Name = "WallsFillTemplateComboBox"
			Me.WallsFillTemplateComboBox.Size = New System.Drawing.Size(149, 21)
			Me.WallsFillTemplateComboBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WallsFillTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.WallsFillTemplateComboBox_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(15, 106)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(80, 13)
			Me.label4.TabIndex = 4
			Me.label4.Text = "Walls Template"
			' 
			' SeriesFillTemplateComboBox
			' 
			Me.SeriesFillTemplateComboBox.Location = New System.Drawing.Point(15, 164)
			Me.SeriesFillTemplateComboBox.Name = "SeriesFillTemplateComboBox"
			Me.SeriesFillTemplateComboBox.Size = New System.Drawing.Size(149, 21)
			Me.SeriesFillTemplateComboBox.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SeriesFillTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.SeriesFillTemplateComboBox_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(15, 147)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(83, 13)
			Me.label5.TabIndex = 6
			Me.label5.Text = "Series Template"
			' 
			' IndicatorsFillTemplateComboBox
			' 
			Me.IndicatorsFillTemplateComboBox.Location = New System.Drawing.Point(15, 226)
			Me.IndicatorsFillTemplateComboBox.Name = "IndicatorsFillTemplateComboBox"
			Me.IndicatorsFillTemplateComboBox.Size = New System.Drawing.Size(149, 21)
			Me.IndicatorsFillTemplateComboBox.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.IndicatorsFillTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.IndicatorsFillTemplateComboBox_SelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(15, 209)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(100, 13)
			Me.label6.TabIndex = 9
			Me.label6.Text = "Indicators Template"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.LabelsFillTemplateComboBox)
			Me.groupBox1.Controls.Add(Me.IndicatorsFillTemplateComboBox)
			Me.groupBox1.Controls.Add(Me.label5)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.MultiColorSeriesCheckBox)
			Me.groupBox1.Controls.Add(Me.BackgroundFillTemplateComboBox)
			Me.groupBox1.Controls.Add(Me.WallsFillTemplateComboBox)
			Me.groupBox1.Controls.Add(Me.label6)
			Me.groupBox1.Controls.Add(Me.SeriesFillTemplateComboBox)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Location = New System.Drawing.Point(12, 56)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(181, 271)
			Me.groupBox1.TabIndex = 2
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Fill Style Sheet"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.ApplyToDataLabelsCheckBox)
			Me.groupBox2.Controls.Add(Me.LabelsStrokeTemplateComboBox)
			Me.groupBox2.Controls.Add(Me.IndicatorsStrokeTemplateComboBox)
			Me.groupBox2.Controls.Add(Me.label7)
			Me.groupBox2.Controls.Add(Me.label8)
			Me.groupBox2.Controls.Add(Me.MultiColorSeriesStrokeCheckBox)
			Me.groupBox2.Controls.Add(Me.RulerStrokeTemplateComboBox)
			Me.groupBox2.Controls.Add(Me.label9)
			Me.groupBox2.Controls.Add(Me.SeriesStrokeTemplateComboBox)
			Me.groupBox2.Controls.Add(Me.label10)
			Me.groupBox2.Location = New System.Drawing.Point(12, 333)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(181, 246)
			Me.groupBox2.TabIndex = 3
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Stroke Style Sheet"
			' 
			' ApplyToDataLabelsCheckBox
			' 
			Me.ApplyToDataLabelsCheckBox.AutoSize = True
			Me.ApplyToDataLabelsCheckBox.ButtonProperties.BorderOffset = 2
			Me.ApplyToDataLabelsCheckBox.Location = New System.Drawing.Point(15, 152)
			Me.ApplyToDataLabelsCheckBox.Name = "ApplyToDataLabelsCheckBox"
			Me.ApplyToDataLabelsCheckBox.Size = New System.Drawing.Size(124, 17)
			Me.ApplyToDataLabelsCheckBox.TabIndex = 7
			Me.ApplyToDataLabelsCheckBox.Text = "Apply to Data Labels"
			Me.ApplyToDataLabelsCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ApplyToDataLabelsCheckBox.CheckedChanged += new System.EventHandler(this.ApplyToDataLabelsCheckBox_CheckedChanged);
			' 
			' LabelsStrokeTemplateComboBox
			' 
			Me.LabelsStrokeTemplateComboBox.Location = New System.Drawing.Point(15, 41)
			Me.LabelsStrokeTemplateComboBox.Name = "LabelsStrokeTemplateComboBox"
			Me.LabelsStrokeTemplateComboBox.Size = New System.Drawing.Size(149, 21)
			Me.LabelsStrokeTemplateComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelsStrokeTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelsStrokeTemplateComboBox_SelectedIndexChanged);
			' 
			' IndicatorsStrokeTemplateComboBox
			' 
			Me.IndicatorsStrokeTemplateComboBox.Location = New System.Drawing.Point(15, 211)
			Me.IndicatorsStrokeTemplateComboBox.Name = "IndicatorsStrokeTemplateComboBox"
			Me.IndicatorsStrokeTemplateComboBox.Size = New System.Drawing.Size(149, 21)
			Me.IndicatorsStrokeTemplateComboBox.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.IndicatorsStrokeTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.IndicatorsStrokeTemplateComboBox_SelectedIndexChanged);
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(15, 106)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(83, 13)
			Me.label7.TabIndex = 4
			Me.label7.Text = "Series Template"
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(15, 24)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(85, 13)
			Me.label8.TabIndex = 0
			Me.label8.Text = "Labels Template"
			' 
			' MultiColorSeriesStrokeCheckBox
			' 
			Me.MultiColorSeriesStrokeCheckBox.AutoSize = True
			Me.MultiColorSeriesStrokeCheckBox.ButtonProperties.BorderOffset = 2
			Me.MultiColorSeriesStrokeCheckBox.Location = New System.Drawing.Point(15, 175)
			Me.MultiColorSeriesStrokeCheckBox.Name = "MultiColorSeriesStrokeCheckBox"
			Me.MultiColorSeriesStrokeCheckBox.Size = New System.Drawing.Size(107, 17)
			Me.MultiColorSeriesStrokeCheckBox.TabIndex = 8
			Me.MultiColorSeriesStrokeCheckBox.Text = "Multi Color Series"
			Me.MultiColorSeriesStrokeCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MultiColorSeriesStrokeCheckBox.CheckedChanged += new System.EventHandler(this.MultiColorSeriesStrokeCheckBox_CheckedChanged);
			' 
			' RulerStrokeTemplateComboBox
			' 
			Me.RulerStrokeTemplateComboBox.Location = New System.Drawing.Point(15, 82)
			Me.RulerStrokeTemplateComboBox.Name = "RulerStrokeTemplateComboBox"
			Me.RulerStrokeTemplateComboBox.Size = New System.Drawing.Size(149, 21)
			Me.RulerStrokeTemplateComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RulerStrokeTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.RulerStrokeTemplateComboBox_SelectedIndexChanged);
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Location = New System.Drawing.Point(15, 194)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(100, 13)
			Me.label9.TabIndex = 9
			Me.label9.Text = "Indicators Template"
			' 
			' SeriesStrokeTemplateComboBox
			' 
			Me.SeriesStrokeTemplateComboBox.Location = New System.Drawing.Point(15, 123)
			Me.SeriesStrokeTemplateComboBox.Name = "SeriesStrokeTemplateComboBox"
			Me.SeriesStrokeTemplateComboBox.Size = New System.Drawing.Size(149, 21)
			Me.SeriesStrokeTemplateComboBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SeriesStrokeTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.SeriesStrokeTemplateComboBox_SelectedIndexChanged);
			' 
			' label10
			' 
			Me.label10.AutoSize = True
			Me.label10.Location = New System.Drawing.Point(15, 65)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(79, 13)
			Me.label10.TabIndex = 2
			Me.label10.Text = "Ruler Template"
			' 
			' NStyleSheetConfiguratorsUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.PaletteComboBox)
			Me.Name = "NStyleSheetConfiguratorsUC"
			Me.Size = New System.Drawing.Size(202, 611)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents PaletteComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label


		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' configure device and interactivity
			nChartControl1.Panels.Clear()
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Style Sheet Configurators")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.FitAlignment = ContentAlignment.MiddleLeft
			title.Margins = New NMarginsL(10, 10, 0, 0)
			title.DockMode = PanelDockMode.Top

			Dim dockPanel As New NDockPanel()
			dockPanel.DockMode = PanelDockMode.Fill
			dockPanel.DockMargins = New NMarginsL(20, 5, 15, 10)
			dockPanel.PositionChildPanelsInContentBounds = True
			nChartControl1.Panels.Add(dockPanel)

			Dim chart As NChart = CreateBarChart()
			chart.Enable3D = True
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(5, 0)
			chart.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))

			dockPanel.ChildPanels.Add(chart)
			Dim gauge As NRadialGaugePanel = CreateRadialGauge()
			dockPanel.ChildPanels.Add(gauge)
			gauge.Location = New NPointL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			gauge.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(40, NRelativeUnit.ParentPercentage))

			gauge = CreateRadialGauge()
			dockPanel.ChildPanels.Add(gauge)
			gauge.Location = New NPointL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			gauge.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(40, NRelativeUnit.ParentPercentage))

			' init form controls
			PaletteComboBox.FillFromEnum(GetType(ChartPredefinedPalette))
			PaletteComboBox.SelectedIndex = 0

			' init form controls
			PopulateFillTemplateCombo(BackgroundFillTemplateComboBox)
			PopulateFillTemplateCombo(LabelsFillTemplateComboBox)
			PopulateFillTemplateCombo(WallsFillTemplateComboBox)
			PopulateFillTemplateCombo(SeriesFillTemplateComboBox)
			PopulateFillTemplateCombo(IndicatorsFillTemplateComboBox)

			PopulateStrokeTemplateCombo(LabelsStrokeTemplateComboBox, 0)
			PopulateStrokeTemplateCombo(IndicatorsStrokeTemplateComboBox)
			PopulateStrokeTemplateCombo(RulerStrokeTemplateComboBox)
			PopulateStrokeTemplateCombo(SeriesStrokeTemplateComboBox)
		End Sub

		Private Function CreateBarChart() As NChart
			' setup chart
			Dim chart As NChart = New NCartesianChart()
			chart.Width = 60
			chart.Height = 25
			chart.Depth = 45
			chart.BoundsMode = BoundsMode.Fit
			chart.ContentAlignment = ContentAlignment.BottomRight
			chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.Projection.Elevation += 10

			' add axis labels
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)

			ordinalScale = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add the first bar
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.MultiBarMode = MultiBarMode.Series
			bar1.Name = "Bar1"
			bar1.DataLabelStyle.Visible = True
			bar1.DataLabelStyle.Format = "<value>"
			bar1.FillStyle = New NColorFillStyle(Color.FromArgb(56, 89, 150))
			bar1.BorderStyle.Color = Color.FromArgb(210, 210, 255)

			' add the second bar
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.MultiBarMode = MultiBarMode.Series
			bar2.Name = "Bar2"
			bar2.DataLabelStyle.Visible = True
			bar2.DataLabelStyle.Format = "<value>"
			bar2.FillStyle = New NColorFillStyle(Color.DarkGreen)
			bar2.BorderStyle.Color = Color.FromArgb(210, 255, 210)

			' add the third bar
			Dim bar3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar3.MultiBarMode = MultiBarMode.Series
			bar3.Name = "Bar3"
			bar3.DataLabelStyle.Visible = True
			bar3.DataLabelStyle.Format = "<value>"
			bar3.FillStyle = New NColorFillStyle(Color.DarkGoldenrod)
			bar3.BorderStyle.Color = Color.FromArgb(255, 255, 210)

			' fill with random data
			Dim barCount As Integer = 6
			bar1.Values.FillRandomRange(Random, barCount, 10, 40)
			bar2.Values.FillRandomRange(Random, barCount, 30, 60)
			bar3.Values.FillRandomRange(Random, barCount, 50, 80)

			Return chart
		End Function



		Private Function CreateRadialGauge() As NRadialGaugePanel
			' create the radial gauge
			Dim radialGauge As New NRadialGaugePanel()
			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.ContentAlignment = ContentAlignment.BottomCenter

			Dim axis As NGaugeAxis = DirectCast(radialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 250)

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			scale_Renamed.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation)
			scale_Renamed.MinorTickCount = 4
			scale_Renamed.RulerStyle.BorderStyle.Width = New NLength(0)
			scale_Renamed.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkGray)

			Dim scaleSection As New NScaleSectionStyle()
			scaleSection.Range = New NRange1DD(220, 260)
			scaleSection.MajorTickStrokeStyle = New NStrokeStyle(Color.Red)
			scaleSection.MinorTickStrokeStyle = New NStrokeStyle(1, Color.Red, LinePattern.Dot, 0, 2)

			Dim labelStyle As New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(Color.Red, Color.DarkRed)
			labelStyle.FontStyle.Style = FontStyle.Bold
			scaleSection.LabelTextStyle = labelStyle

			scale_Renamed.Sections.Add(scaleSection)

			Dim rangeIndicator As New NRangeIndicator()
			rangeIndicator.Value = 220
			rangeIndicator.OriginMode = OriginMode.ScaleMax
			rangeIndicator.FillStyle = New NColorFillStyle(Color.Red)
			rangeIndicator.StrokeStyle.Width = New NLength(0)
			rangeIndicator.BeginWidth = New NLength(-2)
			rangeIndicator.EndWidth = New NLength(-10)
			radialGauge.Indicators.Add(rangeIndicator)

			Dim markerIndicator As New NMarkerValueIndicator()
			markerIndicator.Value = 90
			radialGauge.Indicators.Add(markerIndicator)

			Dim needleIndictor As New NNeedleValueIndicator()
			needleIndictor.Value = 0
			needleIndictor.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			needleIndictor.Shape.StrokeStyle.Color = Color.Red
			radialGauge.Indicators.Add(needleIndictor)

			radialGauge.BeginAngle = -240
			radialGauge.SweepAngle = 300

			Return radialGauge
		End Function

		Private Sub UpdateSheet()
			Dim fillStyleSheet As New NFillStyleSheetConfigurator()
			fillStyleSheet.Palette.SetPredefinedPalette(CType(PaletteComboBox.SelectedIndex, ChartPredefinedPalette))

			fillStyleSheet.ControlBackgroundFillTemplate = CreateFillTemplateFromCombo(BackgroundFillTemplateComboBox)
			fillStyleSheet.LabelFillTemplate = CreateFillTemplateFromCombo(LabelsFillTemplateComboBox)
			fillStyleSheet.WallFillTemplate = CreateFillTemplateFromCombo(WallsFillTemplateComboBox)
			fillStyleSheet.SeriesFillTemplate = CreateFillTemplateFromCombo(SeriesFillTemplateComboBox)
			fillStyleSheet.IndicatorFillTemplate = CreateFillTemplateFromCombo(IndicatorsFillTemplateComboBox)
			fillStyleSheet.MultiColorSeries = MultiColorSeriesCheckBox.Checked

			Dim strokeStyleSheet As New NStrokeStyleSheetConfigurator()
			strokeStyleSheet.Palette.SetPredefinedPalette(CType(PaletteComboBox.SelectedIndex, ChartPredefinedPalette))

			strokeStyleSheet.LabelStrokeTemplate = CreateStrokeTemplateFromCombo(LabelsStrokeTemplateComboBox)
			strokeStyleSheet.IndicatorStrokeTemplate = CreateStrokeTemplateFromCombo(IndicatorsStrokeTemplateComboBox)
			strokeStyleSheet.MultiColorSeries= MultiColorSeriesStrokeCheckBox.Checked
			strokeStyleSheet.RulerStrokeTemplate = CreateStrokeTemplateFromCombo(RulerStrokeTemplateComboBox)
			strokeStyleSheet.SeriesStrokeTemplate = CreateStrokeTemplateFromCombo(SeriesStrokeTemplateComboBox)
			strokeStyleSheet.ApplyToDataLabels = ApplyToDataLabelsCheckBox.Checked

			Dim sheet As New NStyleSheet()
			fillStyleSheet.ConfigureSheet(sheet)
			strokeStyleSheet.ConfigureSheet(sheet)

			sheet.Apply(nChartControl1.Document)

			nChartControl1.Refresh()
		End Sub

		Private Shared Function CreateFillTemplateFromCombo(ByVal comboBox As Nevron.UI.WinForm.Controls.NComboBox) As NFillStyleTemplate
			Select Case comboBox.SelectedIndex
				Case 0
					Return Nothing
				Case 1
					Return New NColorFillStyleTemplate()
				Case 2
					Return New NGradientFillStyleTemplate()
				Case 3
					Return New NHatchFillStyleTemplate()
			End Select

			Return Nothing
		End Function

		Private Shared Function CreateStrokeTemplateFromCombo(ByVal comboBox As Nevron.UI.WinForm.Controls.NComboBox) As NStrokeStyleTemplate
			Select Case comboBox.SelectedIndex
				Case 0
					Return New NStrokeStyleTemplate(New NLength(0), LinePattern.Solid)
				Case 1
					Return New NStrokeStyleTemplate(New NLength(1.0F), LinePattern.Solid)
				Case 2
					Return New NStrokeStyleTemplate(New NLength(1.0F), LinePattern.Dash)
				Case 3
					Return New NStrokeStyleTemplate(New NLength(2), LinePattern.Solid)
				Case 4
					Return New NStrokeStyleTemplate(New NLength(2), LinePattern.Dash)
			End Select

			Return Nothing
		End Function

		Private Shared Sub PopulateFillTemplateCombo(ByVal comboBox As Nevron.UI.WinForm.Controls.NComboBox)
			comboBox.Items.Add("None")
			comboBox.Items.Add("Solid Fill")
			comboBox.Items.Add("Gradient Fill")
			comboBox.Items.Add("Hatch Fill")
			comboBox.SelectedIndex = 1
		End Sub

		Private Shared Sub PopulateStrokeTemplateCombo(ByVal comboBox As Nevron.UI.WinForm.Controls.NComboBox, ByVal selectedIndex As Integer)
			comboBox.Items.Add("None")
			comboBox.Items.Add("Solid Stroke")
			comboBox.Items.Add("Dash Stroke")
			comboBox.Items.Add("Solid Stroke 2pt")
			comboBox.Items.Add("Dash Stroke 2pt")
			comboBox.SelectedIndex = selectedIndex
		End Sub

		Private Shared Sub PopulateStrokeTemplateCombo(ByVal comboBox As Nevron.UI.WinForm.Controls.NComboBox)
			PopulateStrokeTemplateCombo(comboBox, 0)
		End Sub

		Private Sub PaletteComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PaletteComboBox.SelectedIndexChanged
			UpdateSheet()
		End Sub

		Private Sub BackgroundFillTemplateComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BackgroundFillTemplateComboBox.SelectedIndexChanged
			UpdateSheet()
		End Sub

		Private Sub LabelsFillTemplateComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LabelsFillTemplateComboBox.SelectedIndexChanged
			UpdateSheet()
		End Sub

		Private Sub WallsFillTemplateComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles WallsFillTemplateComboBox.SelectedIndexChanged
			UpdateSheet()
		End Sub

		Private Sub SeriesFillTemplateComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SeriesFillTemplateComboBox.SelectedIndexChanged
			UpdateSheet()
		End Sub

		Private Sub MultiColorSeriesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MultiColorSeriesCheckBox.CheckedChanged
			UpdateSheet()
		End Sub

		Private Sub IndicatorsFillTemplateComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles IndicatorsFillTemplateComboBox.SelectedIndexChanged
			UpdateSheet()
		End Sub

		Private Sub LabelsStrokeTemplateComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LabelsStrokeTemplateComboBox.SelectedIndexChanged
			UpdateSheet()
		End Sub

		Private Sub RulerStrokeTemplateComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RulerStrokeTemplateComboBox.SelectedIndexChanged
			UpdateSheet()
		End Sub

		Private Sub SeriesStrokeTemplateComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SeriesStrokeTemplateComboBox.SelectedIndexChanged
			UpdateSheet()
		End Sub

		Private Sub ApplyToDataLabelsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ApplyToDataLabelsCheckBox.CheckedChanged
			UpdateSheet()
		End Sub

		Private Sub MultiColorSeriesStrokeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MultiColorSeriesStrokeCheckBox.CheckedChanged
			UpdateSheet()
		End Sub

		Private Sub IndicatorsStrokeTemplateComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles IndicatorsStrokeTemplateComboBox.SelectedIndexChanged
			UpdateSheet()
		End Sub
	End Class
End Namespace
