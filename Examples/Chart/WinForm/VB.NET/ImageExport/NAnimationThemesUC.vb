Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Data
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports System.IO


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAnimationThemesUC
		Inherits NExampleBaseUC

		#Region "Constructors"

		Public Sub New()
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.GenerateNewDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label5 = New System.Windows.Forms.Label()
			Me.ChartTypeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.AggregationComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.btnExportToSwf = New Nevron.UI.WinForm.Controls.NButton()
			Me.AnimateSeriesSequentiallyCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AnimateDataPointsSequentiallyCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SeriesAnimationDurationUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label9 = New System.Windows.Forms.Label()
			Me.WallsAnimationDurationUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.AxesAnimationDurationUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.IndicatorsAnimationDurationUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.AnimateGaugesSequentiallyCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AnimatePanelsSequentiallyCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AnimateChartsSequentiallyCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.AnimationThemeTypeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.btnExportToXaml = New Nevron.UI.WinForm.Controls.NButton()
			DirectCast(Me.SeriesAnimationDurationUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.WallsAnimationDurationUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.AxesAnimationDurationUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox1.SuspendLayout()
			DirectCast(Me.IndicatorsAnimationDurationUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' GenerateNewDataButton
			' 
			Me.GenerateNewDataButton.Location = New System.Drawing.Point(4, 98)
			Me.GenerateNewDataButton.Name = "GenerateNewDataButton"
			Me.GenerateNewDataButton.Size = New System.Drawing.Size(168, 32)
			Me.GenerateNewDataButton.TabIndex = 4
			Me.GenerateNewDataButton.Text = "Generate New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateNewDataButton.Click += new System.EventHandler(this.GenerateNewDataButton_Click);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(4, 5)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(168, 16)
			Me.label5.TabIndex = 0
			Me.label5.Text = "Chart Type:"
			' 
			' ChartTypeCombo
			' 
			Me.ChartTypeCombo.ListProperties.CheckBoxDataMember = ""
			Me.ChartTypeCombo.ListProperties.DataSource = Nothing
			Me.ChartTypeCombo.ListProperties.DisplayMember = ""
			Me.ChartTypeCombo.Location = New System.Drawing.Point(4, 24)
			Me.ChartTypeCombo.Name = "ChartTypeCombo"
			Me.ChartTypeCombo.Size = New System.Drawing.Size(168, 21)
			Me.ChartTypeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChartTypeCombo.SelectedIndexChanged += new System.EventHandler(this.ChartTypeCombo_SelectedIndexChanged);
			' 
			' AggregationComboBox
			' 
			Me.AggregationComboBox.ListProperties.CheckBoxDataMember = ""
			Me.AggregationComboBox.ListProperties.DataSource = Nothing
			Me.AggregationComboBox.ListProperties.DisplayMember = ""
			Me.AggregationComboBox.Location = New System.Drawing.Point(4, 67)
			Me.AggregationComboBox.Name = "AggregationComboBox"
			Me.AggregationComboBox.Size = New System.Drawing.Size(168, 21)
			Me.AggregationComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AggregationComboBox.SelectedIndexChanged += new System.EventHandler(this.AggregationComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 48)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(168, 16)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Aggregation Mode:"
			' 
			' btnExportToSwf
			' 
			Me.btnExportToSwf.Location = New System.Drawing.Point(7, 536)
			Me.btnExportToSwf.Name = "btnExportToSwf"
			Me.btnExportToSwf.Size = New System.Drawing.Size(168, 32)
			Me.btnExportToSwf.TabIndex = 8
			Me.btnExportToSwf.Text = "Export to SWF..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnExportToSwf.Click += new System.EventHandler(this.ExportButton_Click);
			' 
			' AnimateSeriesSequentiallyCheck
			' 
			Me.AnimateSeriesSequentiallyCheck.ButtonProperties.BorderOffset = 2
			Me.AnimateSeriesSequentiallyCheck.Location = New System.Drawing.Point(2, 63)
			Me.AnimateSeriesSequentiallyCheck.Name = "AnimateSeriesSequentiallyCheck"
			Me.AnimateSeriesSequentiallyCheck.Size = New System.Drawing.Size(154, 21)
			Me.AnimateSeriesSequentiallyCheck.TabIndex = 2
			Me.AnimateSeriesSequentiallyCheck.Text = "Sequential Series"
			' 
			' AnimateDataPointsSequentiallyCheckBox
			' 
			Me.AnimateDataPointsSequentiallyCheckBox.ButtonProperties.BorderOffset = 2
			Me.AnimateDataPointsSequentiallyCheckBox.Location = New System.Drawing.Point(2, 83)
			Me.AnimateDataPointsSequentiallyCheckBox.Name = "AnimateDataPointsSequentiallyCheckBox"
			Me.AnimateDataPointsSequentiallyCheckBox.Size = New System.Drawing.Size(154, 21)
			Me.AnimateDataPointsSequentiallyCheckBox.TabIndex = 3
			Me.AnimateDataPointsSequentiallyCheckBox.Text = "Sequential DataPoints"
			' 
			' SeriesAnimationDurationUpDown
			' 
			Me.SeriesAnimationDurationUpDown.Location = New System.Drawing.Point(67, 69)
			Me.SeriesAnimationDurationUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.SeriesAnimationDurationUpDown.Name = "SeriesAnimationDurationUpDown"
			Me.SeriesAnimationDurationUpDown.Size = New System.Drawing.Size(93, 20)
			Me.SeriesAnimationDurationUpDown.TabIndex = 5
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(4, 69)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(47, 20)
			Me.label9.TabIndex = 4
			Me.label9.Text = "Series:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' WallsAnimationDurationUpDown
			' 
			Me.WallsAnimationDurationUpDown.Location = New System.Drawing.Point(67, 45)
			Me.WallsAnimationDurationUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.WallsAnimationDurationUpDown.Name = "WallsAnimationDurationUpDown"
			Me.WallsAnimationDurationUpDown.Size = New System.Drawing.Size(93, 20)
			Me.WallsAnimationDurationUpDown.TabIndex = 3
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(4, 45)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(49, 20)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Walls:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' AxesAnimationDurationUpDown
			' 
			Me.AxesAnimationDurationUpDown.Location = New System.Drawing.Point(67, 21)
			Me.AxesAnimationDurationUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.AxesAnimationDurationUpDown.Name = "AxesAnimationDurationUpDown"
			Me.AxesAnimationDurationUpDown.Size = New System.Drawing.Size(93, 20)
			Me.AxesAnimationDurationUpDown.TabIndex = 1
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(4, 21)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(47, 20)
			Me.label7.TabIndex = 0
			Me.label7.Text = "Axes:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.IndicatorsAnimationDurationUpDown)
			Me.groupBox1.Controls.Add(Me.AxesAnimationDurationUpDown)
			Me.groupBox1.Controls.Add(Me.label9)
			Me.groupBox1.Controls.Add(Me.SeriesAnimationDurationUpDown)
			Me.groupBox1.Controls.Add(Me.label7)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Controls.Add(Me.WallsAnimationDurationUpDown)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(7, 261)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(168, 126)
			Me.groupBox1.TabIndex = 6
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Animations Duration (seconds)"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(4, 93)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(59, 20)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Indicators:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' IndicatorsAnimationDurationUpDown
			' 
			Me.IndicatorsAnimationDurationUpDown.Location = New System.Drawing.Point(67, 93)
			Me.IndicatorsAnimationDurationUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.IndicatorsAnimationDurationUpDown.Name = "IndicatorsAnimationDurationUpDown"
			Me.IndicatorsAnimationDurationUpDown.Size = New System.Drawing.Size(93, 20)
			Me.IndicatorsAnimationDurationUpDown.TabIndex = 7
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.AnimateGaugesSequentiallyCheckBox)
			Me.nGroupBox1.Controls.Add(Me.AnimatePanelsSequentiallyCheckBox)
			Me.nGroupBox1.Controls.Add(Me.AnimateChartsSequentiallyCheckBox)
			Me.nGroupBox1.Controls.Add(Me.AnimateSeriesSequentiallyCheck)
			Me.nGroupBox1.Controls.Add(Me.AnimateDataPointsSequentiallyCheckBox)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(7, 393)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(168, 137)
			Me.nGroupBox1.TabIndex = 7
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Animations Sequence"
			' 
			' AnimateGaugesSequentiallyCheckBox
			' 
			Me.AnimateGaugesSequentiallyCheckBox.ButtonProperties.BorderOffset = 2
			Me.AnimateGaugesSequentiallyCheckBox.Location = New System.Drawing.Point(2, 103)
			Me.AnimateGaugesSequentiallyCheckBox.Name = "AnimateGaugesSequentiallyCheckBox"
			Me.AnimateGaugesSequentiallyCheckBox.Size = New System.Drawing.Size(154, 21)
			Me.AnimateGaugesSequentiallyCheckBox.TabIndex = 4
			Me.AnimateGaugesSequentiallyCheckBox.Text = "Sequential Gauges"
			' 
			' AnimatePanelsSequentiallyCheckBox
			' 
			Me.AnimatePanelsSequentiallyCheckBox.ButtonProperties.BorderOffset = 2
			Me.AnimatePanelsSequentiallyCheckBox.Location = New System.Drawing.Point(2, 23)
			Me.AnimatePanelsSequentiallyCheckBox.Name = "AnimatePanelsSequentiallyCheckBox"
			Me.AnimatePanelsSequentiallyCheckBox.Size = New System.Drawing.Size(154, 21)
			Me.AnimatePanelsSequentiallyCheckBox.TabIndex = 0
			Me.AnimatePanelsSequentiallyCheckBox.Text = "Sequential Panels"
			' 
			' AnimateChartsSequentiallyCheckBox
			' 
			Me.AnimateChartsSequentiallyCheckBox.ButtonProperties.BorderOffset = 2
			Me.AnimateChartsSequentiallyCheckBox.Location = New System.Drawing.Point(2, 43)
			Me.AnimateChartsSequentiallyCheckBox.Name = "AnimateChartsSequentiallyCheckBox"
			Me.AnimateChartsSequentiallyCheckBox.Size = New System.Drawing.Size(154, 21)
			Me.AnimateChartsSequentiallyCheckBox.TabIndex = 1
			Me.AnimateChartsSequentiallyCheckBox.Text = "Sequential Charts"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(7, 206)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(168, 16)
			Me.label3.TabIndex = 9
			Me.label3.Text = "Animations Theme Type:"
			' 
			' AnimationThemeTypeComboBox
			' 
			Me.AnimationThemeTypeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.AnimationThemeTypeComboBox.ListProperties.DataSource = Nothing
			Me.AnimationThemeTypeComboBox.ListProperties.DisplayMember = ""
			Me.AnimationThemeTypeComboBox.Location = New System.Drawing.Point(7, 225)
			Me.AnimationThemeTypeComboBox.Name = "AnimationThemeTypeComboBox"
			Me.AnimationThemeTypeComboBox.Size = New System.Drawing.Size(168, 21)
			Me.AnimationThemeTypeComboBox.TabIndex = 10
			' 
			' btnExportToXaml
			' 
			Me.btnExportToXaml.Location = New System.Drawing.Point(7, 574)
			Me.btnExportToXaml.Name = "btnExportToXaml"
			Me.btnExportToXaml.Size = New System.Drawing.Size(168, 32)
			Me.btnExportToXaml.TabIndex = 11
			Me.btnExportToXaml.Text = "Export to XAML..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnExportToXaml.Click += new System.EventHandler(this.ExportButton_Click);
			' 
			' NAnimationThemesUC
			' 
			Me.Controls.Add(Me.btnExportToXaml)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.AnimationThemeTypeComboBox)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.btnExportToSwf)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.AggregationComboBox)
			Me.Controls.Add(Me.ChartTypeCombo)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.GenerateNewDataButton)
			Me.Name = "NAnimationThemesUC"
			Me.Size = New System.Drawing.Size(180, 794)
			DirectCast(Me.SeriesAnimationDurationUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.WallsAnimationDurationUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.AxesAnimationDurationUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox1.ResumeLayout(False)
			DirectCast(Me.IndicatorsAnimationDurationUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "Overrides"

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub
		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As New NLabel("Animation Themes")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(0, 10, 0, 0)
			nChartControl1.Panels.Add(title)

			Dim contentPanel As New NDockPanel()
			nChartControl1.Panels.Add(contentPanel)

			contentPanel.DockMode = PanelDockMode.Fill

			' configure the chart
			Dim chart As New NCartesianChart()
			contentPanel.ChildPanels.Add(chart)
			chart.Location = New NPointL(0, 0)
			chart.Size = New NSizeL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(60, NRelativeUnit.ParentPercentage))
			chart.Enable3D = False
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)
			chart.Margins = New NMarginsL(10, 10, 10, 10)
			chart.BoundsMode = BoundsMode.Stretch
			chart.DockMode = PanelDockMode.Top

			' configure the legend
			Dim legend As New NLegend()
			chart.ChildPanels.Add(legend)
			chart.DisplayOnLegend = legend
			chart.PositionChildPanelsInContentBounds = True
			legend.DockMode = PanelDockMode.Top
			legend.FitAlignment = ContentAlignment.BottomRight
			legend.Location = New NPointL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(0))
			legend.Margins = New NMarginsL(0, 5, 5, 0)
			legend.OuterLeftBorderStyle.Width = New NLength(0)
			legend.OuterRightBorderStyle.Width = New NLength(0)
			legend.OuterTopBorderStyle.Width = New NLength(0)
			legend.OuterBottomBorderStyle.Width = New NLength(0)
			legend.VerticalBorderStyle.Width = New NLength(0)
			legend.FillStyle.SetTransparencyPercent(50)

			' configure axes
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.AutoLabels = False
			ordinalScale.Labels.Add("2004")
			ordinalScale.Labels.Add("2005")
			ordinalScale.Labels.Add("2006")
			ordinalScale.Labels.Add("2007")
			ordinalScale.Labels.Add("2008")
			ordinalScale.Labels.Add("2009")

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.Title.Text = "Sales in Thousands USD"
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			Dim gaugesPanel As New NDockPanel()
			gaugesPanel.DockMode = PanelDockMode.Fill
			gaugesPanel.Margins = New NMarginsL(20, 0, 10, 0)
			gaugesPanel.PositionChildPanelsInContentBounds = True
			contentPanel.ChildPanels.Add(gaugesPanel)

			Dim companyNames() As String = { "Company A", "Company B", "Company C" }

			For i As Integer = 0 To 2
				Dim gaugeContainer As New NDockPanel()
				gaugeContainer.Location = New NPointL(New NLength(i * 35, NRelativeUnit.ParentPercentage), New NLength(0))
				gaugeContainer.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))

				gaugeContainer.ChildPanels.Add(CreateGaugeLabel(companyNames(i)))
				gaugeContainer.ChildPanels.Add(CreateGauge())

				gaugesPanel.ChildPanels.Add(gaugeContainer)
			Next i

			' init form controls
			ChartTypeCombo.Items.Add("Bar")
			ChartTypeCombo.Items.Add("Line")
			ChartTypeCombo.Items.Add("Area")
			ChartTypeCombo.SelectedIndex = 0

			AggregationComboBox.Items.Add("None")
			AggregationComboBox.Items.Add("Stacked")
			AggregationComboBox.Items.Add("Clustered")
			AggregationComboBox.SelectedIndex = 1

			AnimationThemeTypeComboBox.FillFromEnum(GetType(AnimationThemeType))
			AnimationThemeTypeComboBox.SelectedIndex = CInt(AnimationThemeType.ScaleAndFade)

			AxesAnimationDurationUpDown.Value = CDec(3)
			WallsAnimationDurationUpDown.Value = CDec(3)
			SeriesAnimationDurationUpDown.Value = CDec(3)
			IndicatorsAnimationDurationUpDown.Value = CDec(3)

			GenerateNewDataButton_Click(Nothing, Nothing)

			CalculateIndicatorValues()
		End Sub

		#End Region

		#Region "Private Methods"

		Private Function CreateGauge() As NRadialGaugePanel
			Dim radialGauge As New NRadialGaugePanel()

			' create gauge panel
			radialGauge.AutoBorder = RadialGaugeAutoBorder.Circle
			radialGauge.BeginAngle = 130
			radialGauge.SweepAngle = 280
			radialGauge.DockMode = PanelDockMode.Fill

			' apply paint effects
			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)

			' Configure the axis
			Dim axis As NGaugeAxis = DirectCast(radialGauge.Axes(0), NGaugeAxis)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			scale_Renamed.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation)
			scale_Renamed.LabelFitModes = New LabelFitMode(){}
			scale_Renamed.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0, False)
			scale_Renamed.MinorTickCount = 2
			scale_Renamed.RulerStyle.BorderStyle.Width = New NLength(0)
			scale_Renamed.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.LightGray))
			scale_Renamed.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)

			' add needle value indicator
			radialGauge.Indicators.Add(New NNeedleValueIndicator())

			Return radialGauge
		End Function
		Private Function CreateGaugeLabel(ByVal text As String) As NLabel
			Dim label As New NLabel(text)

			label.DockMode = PanelDockMode.Bottom
			label.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			label.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			label.ContentAlignment = ContentAlignment.TopCenter
			label.BoundsMode = BoundsMode.None
			label.Padding = New NMarginsL(2, 2, 2, 10)
			label.BackgroundFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.White))

			Return label
		End Function
		Private Function CalculateIndicatorValue(ByVal series As NSeries) As Double
			Dim sum As Double = 0
			Dim total As Double = 0

			For i As Integer = 0 To series.Values.Count - 1
				sum += DirectCast(series.Values(i), Double)
				total += 100
			Next i

			Return (sum / total) * 100
		End Function
		Private Sub CalculateIndicatorValue(ByVal gauge As NGaugePanel, ByVal series As NSeries)
			Dim needle As NNeedleValueIndicator = TryCast(gauge.Indicators(0), NNeedleValueIndicator)
			needle.Value = 50 ' CalculateIndicatorValue(series);
		End Sub
		Private Sub CalculateIndicatorValues()
			CalculateIndicatorValue(nChartControl1.Gauges(0), m_Series1)
			CalculateIndicatorValue(nChartControl1.Gauges(1), m_Series2)
			CalculateIndicatorValue(nChartControl1.Gauges(2), m_Series2)

		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub GenerateNewDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateNewDataButton.Click
			m_Series1.Values.FillRandomRange(Random, categoriesCount, 10, 100)
			m_Series2.Values.FillRandomRange(Random, categoriesCount, 10, 100)
			m_Series3.Values.FillRandomRange(Random, categoriesCount, 10, 100)

			CalculateIndicatorValues()

			nChartControl1.Refresh()
		End Sub
		Private Sub AggregationComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AggregationComboBox.SelectedIndexChanged
			Select Case ChartTypeCombo.SelectedIndex
				Case 0 ' Bar
					Select Case AggregationComboBox.SelectedIndex
						Case 0 ' None
							CType(m_Series1, NBarSeries).MultiBarMode = MultiBarMode.Series
							CType(m_Series2, NBarSeries).MultiBarMode = MultiBarMode.Series
							CType(m_Series3, NBarSeries).MultiBarMode = MultiBarMode.Series
						Case 1 ' Stacked
							CType(m_Series1, NBarSeries).MultiBarMode = MultiBarMode.Stacked
							CType(m_Series2, NBarSeries).MultiBarMode = MultiBarMode.Stacked
							CType(m_Series3, NBarSeries).MultiBarMode = MultiBarMode.Stacked
						Case 2 ' Cluster
							CType(m_Series1, NBarSeries).MultiBarMode = MultiBarMode.Clustered
							CType(m_Series2, NBarSeries).MultiBarMode = MultiBarMode.Clustered
							CType(m_Series3, NBarSeries).MultiBarMode = MultiBarMode.Clustered
					End Select
				Case 1 ' Line
					Select Case AggregationComboBox.SelectedIndex
						Case 0 ' None
							CType(m_Series1, NLineSeries).MultiLineMode = MultiLineMode.Series
							CType(m_Series2, NLineSeries).MultiLineMode = MultiLineMode.Series
							CType(m_Series3, NLineSeries).MultiLineMode = MultiLineMode.Series
						Case 1 ' Stacked
							CType(m_Series1, NLineSeries).MultiLineMode = MultiLineMode.Stacked
							CType(m_Series2, NLineSeries).MultiLineMode = MultiLineMode.Stacked
							CType(m_Series3, NLineSeries).MultiLineMode = MultiLineMode.Stacked
					End Select
				Case 2 ' Area
					Select Case AggregationComboBox.SelectedIndex
						Case 0 ' None
							CType(m_Series1, NAreaSeries).MultiAreaMode = MultiAreaMode.Series
							CType(m_Series2, NAreaSeries).MultiAreaMode = MultiAreaMode.Series
							CType(m_Series3, NAreaSeries).MultiAreaMode = MultiAreaMode.Series
						Case 1 ' Stacked
							CType(m_Series1, NAreaSeries).MultiAreaMode = MultiAreaMode.Stacked
							CType(m_Series2, NAreaSeries).MultiAreaMode = MultiAreaMode.Stacked
							CType(m_Series3, NAreaSeries).MultiAreaMode = MultiAreaMode.Stacked
					End Select
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub ChartTypeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChartTypeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series.Clear()

			Dim seriesType As SeriesType = Nevron.Chart.SeriesType.Bar
			Select Case ChartTypeCombo.SelectedIndex
				Case 0 ' Bar
					seriesType = Nevron.Chart.SeriesType.Bar
				Case 1 ' Line
					seriesType = Nevron.Chart.SeriesType.Line
				Case 2 ' Area
					seriesType = Nevron.Chart.SeriesType.Area
			End Select

			' add the first bar
			m_Series1 = CType(chart.Series.Add(seriesType), NSeries)
			m_Series1.Name = "Company A"
			m_Series1.DataLabelStyle.Visible = False

			' add the second bar
			m_Series2 = CType(chart.Series.Add(seriesType), NSeries)
			m_Series2.Name = "Company B"
			m_Series2.DataLabelStyle.Visible = False

			' add the third bar
			m_Series3 = CType(chart.Series.Add(seriesType), NSeries)
			m_Series3.Name = "Company C"
			m_Series3.DataLabelStyle.Visible = False

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply image filters
			Dim filter1 As New NBevelAndEmbossImageFilter()
			filter1.Depth = New NLength(2)
			m_Series1.FillStyle.ImageFiltersStyle.Filters.Add(filter1)

			Dim filter2 As New NBevelAndEmbossImageFilter()
			filter2.Depth = New NLength(2)
			m_Series2.FillStyle.ImageFiltersStyle.Filters.Add(filter2)

			Dim filter3 As New NBevelAndEmbossImageFilter()
			filter3.Depth = New NLength(2)
			m_Series3.FillStyle.ImageFiltersStyle.Filters.Add(filter3)

			GenerateNewDataButton_Click(Nothing, Nothing)
			AggregationComboBox_SelectedIndexChanged(Nothing, Nothing)
		End Sub
		Private Sub ExportButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExportToSwf.Click, btnExportToXaml.Click
			Try
				Dim path As String
				Dim imageFormat As NImageFormat

				If sender Is btnExportToSwf Then
					path = System.IO.Path.Combine(Application.StartupPath, "ChartExport.swf")
					imageFormat = New NSwfImageFormat()
				Else
					path = System.IO.Path.Combine(Application.StartupPath, "ChartExport.xaml")
					imageFormat = New NXamlImageFormat()
				End If

				Dim animationTheme As New NAnimationTheme()

				animationTheme.AnimateSeriesSequentially = AnimateSeriesSequentiallyCheck.Checked
				animationTheme.AnimateDataPointsSequentially = AnimateDataPointsSequentiallyCheckBox.Checked
				animationTheme.AnimateChartsSequentially = AnimateChartsSequentiallyCheckBox.Checked
				animationTheme.AnimatePanelsSequentially = AnimatePanelsSequentiallyCheckBox.Checked
				animationTheme.AnimateGaugesSequentially = AnimateGaugesSequentiallyCheckBox.Checked

				animationTheme.WallsAnimationDuration = CSng(WallsAnimationDurationUpDown.Value)
				animationTheme.AxesAnimationDuration = CSng(AxesAnimationDurationUpDown.Value)
				animationTheme.SeriesAnimationDuration = CSng(SeriesAnimationDurationUpDown.Value)
				animationTheme.IndicatorsAnimationDuration = CSng(IndicatorsAnimationDurationUpDown.Value)

				animationTheme.AnimationThemeType = CType(AnimationThemeTypeComboBox.SelectedIndex, AnimationThemeType)
				animationTheme.Apply(nChartControl1.Document)

				nChartControl1.ImageExporter.SaveToFile(path, imageFormat)

				Process.Start(path)
			Catch x As Exception
				MessageBox.Show(x.Message)
			End Try
		End Sub


		#End Region

		#Region "Designer Fields"

		Private m_Series1 As NSeries
		Private m_Series2 As NSeries
		Private m_Series3 As NSeries
		Private label5 As System.Windows.Forms.Label
		Private WithEvents GenerateNewDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChartTypeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents AggregationComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private WithEvents btnExportToSwf As Nevron.UI.WinForm.Controls.NButton
		Private AnimateSeriesSequentiallyCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private AnimateDataPointsSequentiallyCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private SeriesAnimationDurationUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label9 As Label
		Private WallsAnimationDurationUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label4 As Label
		Private AxesAnimationDurationUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label7 As Label
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private AnimateChartsSequentiallyCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private AnimatePanelsSequentiallyCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private AnimateGaugesSequentiallyCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label2 As Label
		Private IndicatorsAnimationDurationUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label3 As Label
		Private AnimationThemeTypeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing

		#End Region
		Private WithEvents btnExportToXaml As Nevron.UI.WinForm.Controls.NButton

		#Region "Static"

		Private Const categoriesCount As Integer = 6

		#End Region
	End Class
End Namespace
