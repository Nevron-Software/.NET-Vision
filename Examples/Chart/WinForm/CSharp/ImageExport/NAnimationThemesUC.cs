using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using System.IO;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAnimationThemesUC : NExampleBaseUC
    {
        #region Constructors

        public NAnimationThemesUC()
		{
			InitializeComponent();
        }

        #endregion

        #region Component Designer generated code

        /// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.GenerateNewDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label5 = new System.Windows.Forms.Label();
			this.ChartTypeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.AggregationComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnExportToSwf = new Nevron.UI.WinForm.Controls.NButton();
			this.AnimateSeriesSequentiallyCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AnimateDataPointsSequentiallyCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SeriesAnimationDurationUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.WallsAnimationDurationUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.AxesAnimationDurationUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.IndicatorsAnimationDurationUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.AnimateGaugesSequentiallyCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AnimatePanelsSequentiallyCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AnimateChartsSequentiallyCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.AnimationThemeTypeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.btnExportToXaml = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.SeriesAnimationDurationUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WallsAnimationDurationUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AxesAnimationDurationUpDown)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.IndicatorsAnimationDurationUpDown)).BeginInit();
			this.nGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// GenerateNewDataButton
			// 
			this.GenerateNewDataButton.Location = new System.Drawing.Point(4, 98);
			this.GenerateNewDataButton.Name = "GenerateNewDataButton";
			this.GenerateNewDataButton.Size = new System.Drawing.Size(168, 32);
			this.GenerateNewDataButton.TabIndex = 4;
			this.GenerateNewDataButton.Text = "Generate New Data";
			this.GenerateNewDataButton.Click += new System.EventHandler(this.GenerateNewDataButton_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(4, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(168, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Chart Type:";
			// 
			// ChartTypeCombo
			// 
			this.ChartTypeCombo.ListProperties.CheckBoxDataMember = "";
			this.ChartTypeCombo.ListProperties.DataSource = null;
			this.ChartTypeCombo.ListProperties.DisplayMember = "";
			this.ChartTypeCombo.Location = new System.Drawing.Point(4, 24);
			this.ChartTypeCombo.Name = "ChartTypeCombo";
			this.ChartTypeCombo.Size = new System.Drawing.Size(168, 21);
			this.ChartTypeCombo.TabIndex = 1;
			this.ChartTypeCombo.SelectedIndexChanged += new System.EventHandler(this.ChartTypeCombo_SelectedIndexChanged);
			// 
			// AggregationComboBox
			// 
			this.AggregationComboBox.ListProperties.CheckBoxDataMember = "";
			this.AggregationComboBox.ListProperties.DataSource = null;
			this.AggregationComboBox.ListProperties.DisplayMember = "";
			this.AggregationComboBox.Location = new System.Drawing.Point(4, 67);
			this.AggregationComboBox.Name = "AggregationComboBox";
			this.AggregationComboBox.Size = new System.Drawing.Size(168, 21);
			this.AggregationComboBox.TabIndex = 3;
			this.AggregationComboBox.SelectedIndexChanged += new System.EventHandler(this.AggregationComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Aggregation Mode:";
			// 
			// btnExportToSwf
			// 
			this.btnExportToSwf.Location = new System.Drawing.Point(7, 536);
			this.btnExportToSwf.Name = "btnExportToSwf";
			this.btnExportToSwf.Size = new System.Drawing.Size(168, 32);
			this.btnExportToSwf.TabIndex = 8;
			this.btnExportToSwf.Text = "Export to SWF...";
			this.btnExportToSwf.Click += new System.EventHandler(this.ExportButton_Click);
			// 
			// AnimateSeriesSequentiallyCheck
			// 
			this.AnimateSeriesSequentiallyCheck.ButtonProperties.BorderOffset = 2;
			this.AnimateSeriesSequentiallyCheck.Location = new System.Drawing.Point(2, 63);
			this.AnimateSeriesSequentiallyCheck.Name = "AnimateSeriesSequentiallyCheck";
			this.AnimateSeriesSequentiallyCheck.Size = new System.Drawing.Size(154, 21);
			this.AnimateSeriesSequentiallyCheck.TabIndex = 2;
			this.AnimateSeriesSequentiallyCheck.Text = "Sequential Series";
			// 
			// AnimateDataPointsSequentiallyCheckBox
			// 
			this.AnimateDataPointsSequentiallyCheckBox.ButtonProperties.BorderOffset = 2;
			this.AnimateDataPointsSequentiallyCheckBox.Location = new System.Drawing.Point(2, 83);
			this.AnimateDataPointsSequentiallyCheckBox.Name = "AnimateDataPointsSequentiallyCheckBox";
			this.AnimateDataPointsSequentiallyCheckBox.Size = new System.Drawing.Size(154, 21);
			this.AnimateDataPointsSequentiallyCheckBox.TabIndex = 3;
			this.AnimateDataPointsSequentiallyCheckBox.Text = "Sequential DataPoints";
			// 
			// SeriesAnimationDurationUpDown
			// 
			this.SeriesAnimationDurationUpDown.Location = new System.Drawing.Point(67, 69);
			this.SeriesAnimationDurationUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.SeriesAnimationDurationUpDown.Name = "SeriesAnimationDurationUpDown";
			this.SeriesAnimationDurationUpDown.Size = new System.Drawing.Size(93, 20);
			this.SeriesAnimationDurationUpDown.TabIndex = 5;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(4, 69);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(47, 20);
			this.label9.TabIndex = 4;
			this.label9.Text = "Series:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// WallsAnimationDurationUpDown
			// 
			this.WallsAnimationDurationUpDown.Location = new System.Drawing.Point(67, 45);
			this.WallsAnimationDurationUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.WallsAnimationDurationUpDown.Name = "WallsAnimationDurationUpDown";
			this.WallsAnimationDurationUpDown.Size = new System.Drawing.Size(93, 20);
			this.WallsAnimationDurationUpDown.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 20);
			this.label4.TabIndex = 2;
			this.label4.Text = "Walls:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AxesAnimationDurationUpDown
			// 
			this.AxesAnimationDurationUpDown.Location = new System.Drawing.Point(67, 21);
			this.AxesAnimationDurationUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.AxesAnimationDurationUpDown.Name = "AxesAnimationDurationUpDown";
			this.AxesAnimationDurationUpDown.Size = new System.Drawing.Size(93, 20);
			this.AxesAnimationDurationUpDown.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(4, 21);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(47, 20);
			this.label7.TabIndex = 0;
			this.label7.Text = "Axes:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.IndicatorsAnimationDurationUpDown);
			this.groupBox1.Controls.Add(this.AxesAnimationDurationUpDown);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.SeriesAnimationDurationUpDown);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.WallsAnimationDurationUpDown);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(7, 261);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 126);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Animations Duration (seconds)";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 93);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Indicators:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// IndicatorsAnimationDurationUpDown
			// 
			this.IndicatorsAnimationDurationUpDown.Location = new System.Drawing.Point(67, 93);
			this.IndicatorsAnimationDurationUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.IndicatorsAnimationDurationUpDown.Name = "IndicatorsAnimationDurationUpDown";
			this.IndicatorsAnimationDurationUpDown.Size = new System.Drawing.Size(93, 20);
			this.IndicatorsAnimationDurationUpDown.TabIndex = 7;
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.AnimateGaugesSequentiallyCheckBox);
			this.nGroupBox1.Controls.Add(this.AnimatePanelsSequentiallyCheckBox);
			this.nGroupBox1.Controls.Add(this.AnimateChartsSequentiallyCheckBox);
			this.nGroupBox1.Controls.Add(this.AnimateSeriesSequentiallyCheck);
			this.nGroupBox1.Controls.Add(this.AnimateDataPointsSequentiallyCheckBox);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(7, 393);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(168, 137);
			this.nGroupBox1.TabIndex = 7;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Animations Sequence";
			// 
			// AnimateGaugesSequentiallyCheckBox
			// 
			this.AnimateGaugesSequentiallyCheckBox.ButtonProperties.BorderOffset = 2;
			this.AnimateGaugesSequentiallyCheckBox.Location = new System.Drawing.Point(2, 103);
			this.AnimateGaugesSequentiallyCheckBox.Name = "AnimateGaugesSequentiallyCheckBox";
			this.AnimateGaugesSequentiallyCheckBox.Size = new System.Drawing.Size(154, 21);
			this.AnimateGaugesSequentiallyCheckBox.TabIndex = 4;
			this.AnimateGaugesSequentiallyCheckBox.Text = "Sequential Gauges";
			// 
			// AnimatePanelsSequentiallyCheckBox
			// 
			this.AnimatePanelsSequentiallyCheckBox.ButtonProperties.BorderOffset = 2;
			this.AnimatePanelsSequentiallyCheckBox.Location = new System.Drawing.Point(2, 23);
			this.AnimatePanelsSequentiallyCheckBox.Name = "AnimatePanelsSequentiallyCheckBox";
			this.AnimatePanelsSequentiallyCheckBox.Size = new System.Drawing.Size(154, 21);
			this.AnimatePanelsSequentiallyCheckBox.TabIndex = 0;
			this.AnimatePanelsSequentiallyCheckBox.Text = "Sequential Panels";
			// 
			// AnimateChartsSequentiallyCheckBox
			// 
			this.AnimateChartsSequentiallyCheckBox.ButtonProperties.BorderOffset = 2;
			this.AnimateChartsSequentiallyCheckBox.Location = new System.Drawing.Point(2, 43);
			this.AnimateChartsSequentiallyCheckBox.Name = "AnimateChartsSequentiallyCheckBox";
			this.AnimateChartsSequentiallyCheckBox.Size = new System.Drawing.Size(154, 21);
			this.AnimateChartsSequentiallyCheckBox.TabIndex = 1;
			this.AnimateChartsSequentiallyCheckBox.Text = "Sequential Charts";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 206);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "Animations Theme Type:";
			// 
			// AnimationThemeTypeComboBox
			// 
			this.AnimationThemeTypeComboBox.ListProperties.CheckBoxDataMember = "";
			this.AnimationThemeTypeComboBox.ListProperties.DataSource = null;
			this.AnimationThemeTypeComboBox.ListProperties.DisplayMember = "";
			this.AnimationThemeTypeComboBox.Location = new System.Drawing.Point(7, 225);
			this.AnimationThemeTypeComboBox.Name = "AnimationThemeTypeComboBox";
			this.AnimationThemeTypeComboBox.Size = new System.Drawing.Size(168, 21);
			this.AnimationThemeTypeComboBox.TabIndex = 10;
			// 
			// btnExportToXaml
			// 
			this.btnExportToXaml.Location = new System.Drawing.Point(7, 574);
			this.btnExportToXaml.Name = "btnExportToXaml";
			this.btnExportToXaml.Size = new System.Drawing.Size(168, 32);
			this.btnExportToXaml.TabIndex = 11;
			this.btnExportToXaml.Text = "Export to XAML...";
			this.btnExportToXaml.Click += new System.EventHandler(this.ExportButton_Click);
			// 
			// NAnimationThemesUC
			// 
			this.Controls.Add(this.btnExportToXaml);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.AnimationThemeTypeComboBox);
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnExportToSwf);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.AggregationComboBox);
			this.Controls.Add(this.ChartTypeCombo);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.GenerateNewDataButton);
			this.Name = "NAnimationThemesUC";
			this.Size = new System.Drawing.Size(180, 794);
			((System.ComponentModel.ISupportInitialize)(this.SeriesAnimationDurationUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WallsAnimationDurationUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AxesAnimationDurationUpDown)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.IndicatorsAnimationDurationUpDown)).EndInit();
			this.nGroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

        #region Overrides

        /// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = new NLabel("Animation Themes");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.DockMode = PanelDockMode.Top;
			title.Margins = new NMarginsL(0, 10, 0, 0);
			nChartControl1.Panels.Add(title);

			NDockPanel contentPanel = new NDockPanel();
			nChartControl1.Panels.Add(contentPanel);

			contentPanel.DockMode = PanelDockMode.Fill;

			// configure the chart
			NCartesianChart chart = new NCartesianChart();
			contentPanel.ChildPanels.Add(chart);
			chart.Location = new NPointL(0, 0);
			chart.Size = new NSizeL(new NLength(100, NRelativeUnit.ParentPercentage),
									new NLength(60, NRelativeUnit.ParentPercentage));
			chart.Enable3D = false;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);
			chart.Margins = new NMarginsL(10, 10, 10, 10);
			chart.BoundsMode = BoundsMode.Stretch;
			chart.DockMode = PanelDockMode.Top;

			// configure the legend
			NLegend legend = new NLegend();
			chart.ChildPanels.Add(legend);
			chart.DisplayOnLegend = legend;
			chart.PositionChildPanelsInContentBounds = true;
			legend.DockMode = PanelDockMode.Top;
			legend.FitAlignment = ContentAlignment.BottomRight;
			legend.Location = new NPointL(new NLength(100, NRelativeUnit.ParentPercentage), new NLength(0));
			legend.Margins = new NMarginsL(0, 5, 5, 0);
			legend.OuterLeftBorderStyle.Width = new NLength(0);
			legend.OuterRightBorderStyle.Width = new NLength(0);
			legend.OuterTopBorderStyle.Width = new NLength(0);
			legend.OuterBottomBorderStyle.Width = new NLength(0);
			legend.VerticalBorderStyle.Width = new NLength(0);
			legend.FillStyle.SetTransparencyPercent(50);

			// configure axes
			NOrdinalScaleConfigurator ordinalScale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.AutoLabels = false;
			ordinalScale.Labels.Add("2004");
			ordinalScale.Labels.Add("2005");
			ordinalScale.Labels.Add("2006");
			ordinalScale.Labels.Add("2007");
			ordinalScale.Labels.Add("2008");
			ordinalScale.Labels.Add("2009");

			// add interlace stripe
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.Title.Text = "Sales in Thousands USD";
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			NDockPanel gaugesPanel = new NDockPanel();
			gaugesPanel.DockMode = PanelDockMode.Fill;
			gaugesPanel.Margins = new NMarginsL(20, 0, 10, 0);
			gaugesPanel.PositionChildPanelsInContentBounds = true;
			contentPanel.ChildPanels.Add(gaugesPanel);

			string[] companyNames = new string[] { "Company A", "Company B", "Company C" };

			for (int i = 0; i < 3; i++)
			{
				NDockPanel gaugeContainer = new NDockPanel();
				gaugeContainer.Location = new NPointL(new NLength(i * 35, NRelativeUnit.ParentPercentage),
								   new NLength(0));
				gaugeContainer.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage),
												new NLength(100, NRelativeUnit.ParentPercentage));

				gaugeContainer.ChildPanels.Add(CreateGaugeLabel(companyNames[i]));
				gaugeContainer.ChildPanels.Add(CreateGauge());

				gaugesPanel.ChildPanels.Add(gaugeContainer);
			}

			// init form controls
			ChartTypeCombo.Items.Add("Bar");
			ChartTypeCombo.Items.Add("Line");
			ChartTypeCombo.Items.Add("Area");
			ChartTypeCombo.SelectedIndex = 0;

			AggregationComboBox.Items.Add("None");
			AggregationComboBox.Items.Add("Stacked");
			AggregationComboBox.Items.Add("Clustered");
			AggregationComboBox.SelectedIndex = 1;

			AnimationThemeTypeComboBox.FillFromEnum(typeof(AnimationThemeType));
			AnimationThemeTypeComboBox.SelectedIndex = (int)AnimationThemeType.ScaleAndFade;

			AxesAnimationDurationUpDown.Value = (decimal)3;
			WallsAnimationDurationUpDown.Value = (decimal)3;
			SeriesAnimationDurationUpDown.Value = (decimal)3;
			IndicatorsAnimationDurationUpDown.Value = (decimal)3;

			GenerateNewDataButton_Click(null, null);

			CalculateIndicatorValues();
        }

        #endregion

        #region Private Methods

        private NRadialGaugePanel CreateGauge()
		{
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();

			// create gauge panel
			radialGauge.AutoBorder = RadialGaugeAutoBorder.Circle;
			radialGauge.BeginAngle = 130;
			radialGauge.SweepAngle = 280;
			radialGauge.DockMode = PanelDockMode.Fill;

			// apply paint effects
			radialGauge.PaintEffect = new NGlassEffectStyle();
			radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);

			// Configure the axis
			NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation);
			scale.LabelFitModes = new LabelFitMode[0];
			scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0, false);
			scale.MinorTickCount = 2;
			scale.RulerStyle.BorderStyle.Width = new NLength(0);
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.LightGray));
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);

			// add needle value indicator
			radialGauge.Indicators.Add(new NNeedleValueIndicator());

			return radialGauge;
		}
		private NLabel CreateGaugeLabel(string text)
		{
			NLabel label = new NLabel(text);

			label.DockMode = PanelDockMode.Bottom;
			label.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			label.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));
			label.ContentAlignment = ContentAlignment.TopCenter;
			label.BoundsMode = BoundsMode.None;
			label.Padding = new NMarginsL(2, 2, 2, 10);
			label.BackgroundFillStyle = new NColorFillStyle(Color.FromArgb(125, Color.White));

			return label;
		}
		private double CalculateIndicatorValue(NSeries series)
		{
			double sum = 0;
			double total = 0;

			for (int i = 0; i < series.Values.Count; i++)
			{
				sum += (double)series.Values[i];
				total += 100;
			}

			return (sum / total) * 100;
		}
		private void CalculateIndicatorValue(NGaugePanel gauge, NSeries series)
		{
			NNeedleValueIndicator needle = gauge.Indicators[0] as NNeedleValueIndicator;
			needle.Value = 50;// CalculateIndicatorValue(series);
		}
		private void CalculateIndicatorValues()
		{
			CalculateIndicatorValue(nChartControl1.Gauges[0], m_Series1);
			CalculateIndicatorValue(nChartControl1.Gauges[1], m_Series2);
			CalculateIndicatorValue(nChartControl1.Gauges[2], m_Series2);

        }

        #endregion

        #region Event Handlers

		private void GenerateNewDataButton_Click(object sender, System.EventArgs e)
		{
			m_Series1.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Series2.Values.FillRandomRange(Random, categoriesCount, 10, 100);
			m_Series3.Values.FillRandomRange(Random, categoriesCount, 10, 100);

			CalculateIndicatorValues();

			nChartControl1.Refresh();
		}
		private void AggregationComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (ChartTypeCombo.SelectedIndex)
			{
				case 0: // Bar
					switch (AggregationComboBox.SelectedIndex)
					{ 
						case 0: // None
							((NBarSeries)m_Series1).MultiBarMode = MultiBarMode.Series;
							((NBarSeries)m_Series2).MultiBarMode = MultiBarMode.Series;
							((NBarSeries)m_Series3).MultiBarMode = MultiBarMode.Series;
							break;
						case 1: // Stacked
							((NBarSeries)m_Series1).MultiBarMode = MultiBarMode.Stacked;
							((NBarSeries)m_Series2).MultiBarMode = MultiBarMode.Stacked;
							((NBarSeries)m_Series3).MultiBarMode = MultiBarMode.Stacked;
							break;
						case 2: // Cluster
							((NBarSeries)m_Series1).MultiBarMode = MultiBarMode.Clustered;
							((NBarSeries)m_Series2).MultiBarMode = MultiBarMode.Clustered;
							((NBarSeries)m_Series3).MultiBarMode = MultiBarMode.Clustered;
							break;
					}
					break;
				case 1: // Line
					switch (AggregationComboBox.SelectedIndex)
					{
						case 0: // None
							((NLineSeries)m_Series1).MultiLineMode = MultiLineMode.Series;
							((NLineSeries)m_Series2).MultiLineMode = MultiLineMode.Series;
							((NLineSeries)m_Series3).MultiLineMode = MultiLineMode.Series;
							break;
						case 1: // Stacked
							((NLineSeries)m_Series1).MultiLineMode = MultiLineMode.Stacked;
							((NLineSeries)m_Series2).MultiLineMode = MultiLineMode.Stacked;
							((NLineSeries)m_Series3).MultiLineMode = MultiLineMode.Stacked;
							break;
					}
					break;
				case 2: // Area
					switch (AggregationComboBox.SelectedIndex)
					{
						case 0: // None
							((NAreaSeries)m_Series1).MultiAreaMode = MultiAreaMode.Series;
							((NAreaSeries)m_Series2).MultiAreaMode = MultiAreaMode.Series;
							((NAreaSeries)m_Series3).MultiAreaMode = MultiAreaMode.Series;
							break;
						case 1: // Stacked
							((NAreaSeries)m_Series1).MultiAreaMode = MultiAreaMode.Stacked;
							((NAreaSeries)m_Series2).MultiAreaMode = MultiAreaMode.Stacked;
							((NAreaSeries)m_Series3).MultiAreaMode = MultiAreaMode.Stacked;
							break;
					}
					break;
			}

			nChartControl1.Refresh();
		}
		private void ChartTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.Series.Clear();

			SeriesType seriesType = SeriesType.Bar;
			switch (ChartTypeCombo.SelectedIndex)
			{
				case 0: // Bar
					seriesType = SeriesType.Bar;
					break;
				case 1: // Line
					seriesType = SeriesType.Line;
					break;
				case 2: // Area
					seriesType = SeriesType.Area;
					break;
			}

			// add the first bar
			m_Series1 = (NSeries)chart.Series.Add(seriesType);
			m_Series1.Name = "Company A";
			m_Series1.DataLabelStyle.Visible = false;

			// add the second bar
			m_Series2 = (NSeries)chart.Series.Add(seriesType);
			m_Series2.Name = "Company B";
			m_Series2.DataLabelStyle.Visible = false;

			// add the third bar
			m_Series3 = (NSeries)chart.Series.Add(seriesType);
			m_Series3.Name = "Company C";
			m_Series3.DataLabelStyle.Visible = false;

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply image filters
			NBevelAndEmbossImageFilter filter1 = new NBevelAndEmbossImageFilter();
			filter1.Depth = new NLength(2);
			m_Series1.FillStyle.ImageFiltersStyle.Filters.Add(filter1);

			NBevelAndEmbossImageFilter filter2 = new NBevelAndEmbossImageFilter();
			filter2.Depth = new NLength(2);
			m_Series2.FillStyle.ImageFiltersStyle.Filters.Add(filter2);

			NBevelAndEmbossImageFilter filter3 = new NBevelAndEmbossImageFilter();
			filter3.Depth = new NLength(2);
			m_Series3.FillStyle.ImageFiltersStyle.Filters.Add(filter3);

			GenerateNewDataButton_Click(null, null);
			AggregationComboBox_SelectedIndexChanged(null, null);
		}
		private void ExportButton_Click(object sender, EventArgs e)
		{
			try
			{
                string path;
                NImageFormat imageFormat;

                if (sender == btnExportToSwf)
                {
                    path = System.IO.Path.Combine(Application.StartupPath, "ChartExport.swf");
                    imageFormat = new NSwfImageFormat();
                }
                else
                {
                    path = System.IO.Path.Combine(Application.StartupPath, "ChartExport.xaml");
                    imageFormat = new NXamlImageFormat();
                }

				NAnimationTheme animationTheme = new NAnimationTheme();

				animationTheme.AnimateSeriesSequentially = AnimateSeriesSequentiallyCheck.Checked;
				animationTheme.AnimateDataPointsSequentially = AnimateDataPointsSequentiallyCheckBox.Checked;
				animationTheme.AnimateChartsSequentially = AnimateChartsSequentiallyCheckBox.Checked;
				animationTheme.AnimatePanelsSequentially = AnimatePanelsSequentiallyCheckBox.Checked;
				animationTheme.AnimateGaugesSequentially = AnimateGaugesSequentiallyCheckBox.Checked;

				animationTheme.WallsAnimationDuration = (float)WallsAnimationDurationUpDown.Value;
				animationTheme.AxesAnimationDuration = (float)AxesAnimationDurationUpDown.Value;
				animationTheme.SeriesAnimationDuration = (float)SeriesAnimationDurationUpDown.Value;
				animationTheme.IndicatorsAnimationDuration = (float)IndicatorsAnimationDurationUpDown.Value;

				animationTheme.AnimationThemeType = (AnimationThemeType)AnimationThemeTypeComboBox.SelectedIndex;
				animationTheme.Apply(nChartControl1.Document);

				nChartControl1.ImageExporter.SaveToFile(path, imageFormat);

				Process.Start(path);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}
		}


        #endregion

        #region Designer Fields

        private NSeries m_Series1;
		private NSeries m_Series2;
		private NSeries m_Series3;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NButton GenerateNewDataButton;
		private Nevron.UI.WinForm.Controls.NComboBox ChartTypeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox AggregationComboBox;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NButton btnExportToSwf;
		private Nevron.UI.WinForm.Controls.NCheckBox AnimateSeriesSequentiallyCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox AnimateDataPointsSequentiallyCheckBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown SeriesAnimationDurationUpDown;
		private Label label9;
		private Nevron.UI.WinForm.Controls.NNumericUpDown WallsAnimationDurationUpDown;
		private Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown AxesAnimationDurationUpDown;
		private Label label7;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox AnimateChartsSequentiallyCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox AnimatePanelsSequentiallyCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox AnimateGaugesSequentiallyCheckBox;
		private Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown IndicatorsAnimationDurationUpDown;
		private Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox AnimationThemeTypeComboBox;
		private System.ComponentModel.Container components = null;

        #endregion
        private Nevron.UI.WinForm.Controls.NButton btnExportToXaml;

        #region Static

		private const int categoriesCount = 6;

        #endregion
    }
}
