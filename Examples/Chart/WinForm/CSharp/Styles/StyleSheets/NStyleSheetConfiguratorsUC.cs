using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
    public class NStyleSheetConfiguratorsUC : NExampleBaseUC
    {
        public NStyleSheetConfiguratorsUC()
        {
            InitializeComponent();
        }

        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Nevron.UI.WinForm.Controls.NCheckBox MultiColorSeriesCheckBox;
        private Nevron.UI.WinForm.Controls.NComboBox BackgroundFillTemplateComboBox;
        private Nevron.UI.WinForm.Controls.NComboBox LabelsFillTemplateComboBox;
        private Nevron.UI.WinForm.Controls.NComboBox WallsFillTemplateComboBox;
        private Nevron.UI.WinForm.Controls.NComboBox SeriesFillTemplateComboBox;
        private Nevron.UI.WinForm.Controls.NComboBox IndicatorsFillTemplateComboBox;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Nevron.UI.WinForm.Controls.NComboBox LabelsStrokeTemplateComboBox;
        private Nevron.UI.WinForm.Controls.NComboBox IndicatorsStrokeTemplateComboBox;
        private Nevron.UI.WinForm.Controls.NCheckBox MultiColorSeriesStrokeCheckBox;
        private Nevron.UI.WinForm.Controls.NComboBox RulerStrokeTemplateComboBox;
        private Nevron.UI.WinForm.Controls.NComboBox SeriesStrokeTemplateComboBox;
        private Nevron.UI.WinForm.Controls.NCheckBox ApplyToDataLabelsCheckBox;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PaletteComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MultiColorSeriesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BackgroundFillTemplateComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.LabelsFillTemplateComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.WallsFillTemplateComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SeriesFillTemplateComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.IndicatorsFillTemplateComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ApplyToDataLabelsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.LabelsStrokeTemplateComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.IndicatorsStrokeTemplateComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.MultiColorSeriesStrokeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.RulerStrokeTemplateComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SeriesStrokeTemplateComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PaletteComboBox
            // 
            this.PaletteComboBox.Location = new System.Drawing.Point(12, 29);
            this.PaletteComboBox.Name = "PaletteComboBox";
            this.PaletteComboBox.Size = new System.Drawing.Size(181, 21);
            this.PaletteComboBox.TabIndex = 1;
            this.PaletteComboBox.SelectedIndexChanged += new System.EventHandler(this.PaletteComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Palette:";
            // 
            // MultiColorSeriesCheckBox
            // 
            this.MultiColorSeriesCheckBox.AutoSize = true;
            this.MultiColorSeriesCheckBox.ButtonProperties.BorderOffset = 2;
            this.MultiColorSeriesCheckBox.Location = new System.Drawing.Point(15, 189);
            this.MultiColorSeriesCheckBox.Name = "MultiColorSeriesCheckBox";
            this.MultiColorSeriesCheckBox.Size = new System.Drawing.Size(107, 17);
            this.MultiColorSeriesCheckBox.TabIndex = 8;
            this.MultiColorSeriesCheckBox.Text = "Multi Color Series";
            this.MultiColorSeriesCheckBox.UseVisualStyleBackColor = true;
            this.MultiColorSeriesCheckBox.CheckedChanged += new System.EventHandler(this.MultiColorSeriesCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Background Template";
            // 
            // BackgroundFillTemplateComboBox
            // 
            this.BackgroundFillTemplateComboBox.Location = new System.Drawing.Point(15, 41);
            this.BackgroundFillTemplateComboBox.Name = "BackgroundFillTemplateComboBox";
            this.BackgroundFillTemplateComboBox.Size = new System.Drawing.Size(149, 21);
            this.BackgroundFillTemplateComboBox.TabIndex = 1;
            this.BackgroundFillTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.BackgroundFillTemplateComboBox_SelectedIndexChanged);
            // 
            // LabelsFillTemplateComboBox
            // 
            this.LabelsFillTemplateComboBox.Location = new System.Drawing.Point(15, 82);
            this.LabelsFillTemplateComboBox.Name = "LabelsFillTemplateComboBox";
            this.LabelsFillTemplateComboBox.Size = new System.Drawing.Size(149, 21);
            this.LabelsFillTemplateComboBox.TabIndex = 3;
            this.LabelsFillTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelsFillTemplateComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Labels Template";
            // 
            // WallsFillTemplateComboBox
            // 
            this.WallsFillTemplateComboBox.Location = new System.Drawing.Point(15, 123);
            this.WallsFillTemplateComboBox.Name = "WallsFillTemplateComboBox";
            this.WallsFillTemplateComboBox.Size = new System.Drawing.Size(149, 21);
            this.WallsFillTemplateComboBox.TabIndex = 5;
            this.WallsFillTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.WallsFillTemplateComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Walls Template";
            // 
            // SeriesFillTemplateComboBox
            // 
            this.SeriesFillTemplateComboBox.Location = new System.Drawing.Point(15, 164);
            this.SeriesFillTemplateComboBox.Name = "SeriesFillTemplateComboBox";
            this.SeriesFillTemplateComboBox.Size = new System.Drawing.Size(149, 21);
            this.SeriesFillTemplateComboBox.TabIndex = 7;
            this.SeriesFillTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.SeriesFillTemplateComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Series Template";
            // 
            // IndicatorsFillTemplateComboBox
            // 
            this.IndicatorsFillTemplateComboBox.Location = new System.Drawing.Point(15, 226);
            this.IndicatorsFillTemplateComboBox.Name = "IndicatorsFillTemplateComboBox";
            this.IndicatorsFillTemplateComboBox.Size = new System.Drawing.Size(149, 21);
            this.IndicatorsFillTemplateComboBox.TabIndex = 10;
            this.IndicatorsFillTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.IndicatorsFillTemplateComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Indicators Template";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LabelsFillTemplateComboBox);
            this.groupBox1.Controls.Add(this.IndicatorsFillTemplateComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.MultiColorSeriesCheckBox);
            this.groupBox1.Controls.Add(this.BackgroundFillTemplateComboBox);
            this.groupBox1.Controls.Add(this.WallsFillTemplateComboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.SeriesFillTemplateComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 271);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fill Style Sheet";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ApplyToDataLabelsCheckBox);
            this.groupBox2.Controls.Add(this.LabelsStrokeTemplateComboBox);
            this.groupBox2.Controls.Add(this.IndicatorsStrokeTemplateComboBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.MultiColorSeriesStrokeCheckBox);
            this.groupBox2.Controls.Add(this.RulerStrokeTemplateComboBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.SeriesStrokeTemplateComboBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(12, 333);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 246);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stroke Style Sheet";
            // 
            // ApplyToDataLabelsCheckBox
            // 
            this.ApplyToDataLabelsCheckBox.AutoSize = true;
            this.ApplyToDataLabelsCheckBox.ButtonProperties.BorderOffset = 2;
            this.ApplyToDataLabelsCheckBox.Location = new System.Drawing.Point(15, 152);
            this.ApplyToDataLabelsCheckBox.Name = "ApplyToDataLabelsCheckBox";
            this.ApplyToDataLabelsCheckBox.Size = new System.Drawing.Size(124, 17);
            this.ApplyToDataLabelsCheckBox.TabIndex = 7;
            this.ApplyToDataLabelsCheckBox.Text = "Apply to Data Labels";
            this.ApplyToDataLabelsCheckBox.UseVisualStyleBackColor = true;
            this.ApplyToDataLabelsCheckBox.CheckedChanged += new System.EventHandler(this.ApplyToDataLabelsCheckBox_CheckedChanged);
            // 
            // LabelsStrokeTemplateComboBox
            // 
            this.LabelsStrokeTemplateComboBox.Location = new System.Drawing.Point(15, 41);
            this.LabelsStrokeTemplateComboBox.Name = "LabelsStrokeTemplateComboBox";
            this.LabelsStrokeTemplateComboBox.Size = new System.Drawing.Size(149, 21);
            this.LabelsStrokeTemplateComboBox.TabIndex = 1;
            this.LabelsStrokeTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelsStrokeTemplateComboBox_SelectedIndexChanged);
            // 
            // IndicatorsStrokeTemplateComboBox
            // 
            this.IndicatorsStrokeTemplateComboBox.Location = new System.Drawing.Point(15, 211);
            this.IndicatorsStrokeTemplateComboBox.Name = "IndicatorsStrokeTemplateComboBox";
            this.IndicatorsStrokeTemplateComboBox.Size = new System.Drawing.Size(149, 21);
            this.IndicatorsStrokeTemplateComboBox.TabIndex = 10;
            this.IndicatorsStrokeTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.IndicatorsStrokeTemplateComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Series Template";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Labels Template";
            // 
            // MultiColorSeriesStrokeCheckBox
            // 
            this.MultiColorSeriesStrokeCheckBox.AutoSize = true;
            this.MultiColorSeriesStrokeCheckBox.ButtonProperties.BorderOffset = 2;
            this.MultiColorSeriesStrokeCheckBox.Location = new System.Drawing.Point(15, 175);
            this.MultiColorSeriesStrokeCheckBox.Name = "MultiColorSeriesStrokeCheckBox";
            this.MultiColorSeriesStrokeCheckBox.Size = new System.Drawing.Size(107, 17);
            this.MultiColorSeriesStrokeCheckBox.TabIndex = 8;
            this.MultiColorSeriesStrokeCheckBox.Text = "Multi Color Series";
            this.MultiColorSeriesStrokeCheckBox.UseVisualStyleBackColor = true;
            this.MultiColorSeriesStrokeCheckBox.CheckedChanged += new System.EventHandler(this.MultiColorSeriesStrokeCheckBox_CheckedChanged);
            // 
            // RulerStrokeTemplateComboBox
            // 
            this.RulerStrokeTemplateComboBox.Location = new System.Drawing.Point(15, 82);
            this.RulerStrokeTemplateComboBox.Name = "RulerStrokeTemplateComboBox";
            this.RulerStrokeTemplateComboBox.Size = new System.Drawing.Size(149, 21);
            this.RulerStrokeTemplateComboBox.TabIndex = 3;
            this.RulerStrokeTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.RulerStrokeTemplateComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Indicators Template";
            // 
            // SeriesStrokeTemplateComboBox
            // 
            this.SeriesStrokeTemplateComboBox.Location = new System.Drawing.Point(15, 123);
            this.SeriesStrokeTemplateComboBox.Name = "SeriesStrokeTemplateComboBox";
            this.SeriesStrokeTemplateComboBox.Size = new System.Drawing.Size(149, 21);
            this.SeriesStrokeTemplateComboBox.TabIndex = 5;
            this.SeriesStrokeTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.SeriesStrokeTemplateComboBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Ruler Template";
            // 
            // NStyleSheetConfiguratorsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PaletteComboBox);
            this.Name = "NStyleSheetConfiguratorsUC";
            this.Size = new System.Drawing.Size(202, 611);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NComboBox PaletteComboBox;
        private System.Windows.Forms.Label label1;


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public override void Initialize()
        {
            base.Initialize();

            // configure device and interactivity
            nChartControl1.Panels.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Style Sheet Configurators");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.FitAlignment = ContentAlignment.MiddleLeft;
			title.Margins = new NMarginsL(10, 10, 0, 0);
			title.DockMode = PanelDockMode.Top;

            NDockPanel dockPanel = new NDockPanel();
            dockPanel.DockMode = PanelDockMode.Fill;
            dockPanel.DockMargins = new NMarginsL(20, 5, 15, 10);
            dockPanel.PositionChildPanelsInContentBounds = true;
            nChartControl1.Panels.Add(dockPanel);

            NChart chart = CreateBarChart();
			chart.Enable3D = true;
            chart.BoundsMode = BoundsMode.Fit;
            chart.Location = new NPointL(5, 0);
            chart.Size = new NSizeL(new NLength(60, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));

            dockPanel.ChildPanels.Add(chart);
            NRadialGaugePanel gauge = CreateRadialGauge();
            dockPanel.ChildPanels.Add(gauge);
            gauge.Location = new NPointL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
            gauge.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage), new NLength(40, NRelativeUnit.ParentPercentage));

            gauge = CreateRadialGauge();
            dockPanel.ChildPanels.Add(gauge);
            gauge.Location = new NPointL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
            gauge.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage), new NLength(40, NRelativeUnit.ParentPercentage));

            // init form controls
            PaletteComboBox.FillFromEnum(typeof(ChartPredefinedPalette));
            PaletteComboBox.SelectedIndex = 0;

            // init form controls
            PopulateFillTemplateCombo(BackgroundFillTemplateComboBox);
            PopulateFillTemplateCombo(LabelsFillTemplateComboBox);
            PopulateFillTemplateCombo(WallsFillTemplateComboBox);
            PopulateFillTemplateCombo(SeriesFillTemplateComboBox);
            PopulateFillTemplateCombo(IndicatorsFillTemplateComboBox);

            PopulateStrokeTemplateCombo(LabelsStrokeTemplateComboBox, 0);
            PopulateStrokeTemplateCombo(IndicatorsStrokeTemplateComboBox);
            PopulateStrokeTemplateCombo(RulerStrokeTemplateComboBox);
            PopulateStrokeTemplateCombo(SeriesStrokeTemplateComboBox);
        }

        private NChart CreateBarChart()
        {
            // setup chart
            NChart chart = new NCartesianChart();
            chart.Width = 60;
            chart.Height = 25;
            chart.Depth = 45;
            chart.BoundsMode = BoundsMode.Fit;
            chart.ContentAlignment = ContentAlignment.BottomRight;
            chart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
            chart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));

            chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            chart.Projection.Elevation += 10;

            // add axis labels
            NOrdinalScaleConfigurator ordinalScale = chart.Axis(StandardAxis.Depth).ScaleConfigurator as NOrdinalScaleConfigurator;

            ordinalScale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

            // add the first bar
            NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar1.MultiBarMode = MultiBarMode.Series;
            bar1.Name = "Bar1";
            bar1.DataLabelStyle.Visible = true;
            bar1.DataLabelStyle.Format = "<value>";
            bar1.FillStyle = new NColorFillStyle(Color.FromArgb(56, 89, 150));
            bar1.BorderStyle.Color = Color.FromArgb(210, 210, 255);

            // add the second bar
            NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar2.MultiBarMode = MultiBarMode.Series;
            bar2.Name = "Bar2";
            bar2.DataLabelStyle.Visible = true;
            bar2.DataLabelStyle.Format = "<value>";
            bar2.FillStyle = new NColorFillStyle(Color.DarkGreen);
            bar2.BorderStyle.Color = Color.FromArgb(210, 255, 210);

            // add the third bar
            NBarSeries bar3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar3.MultiBarMode = MultiBarMode.Series;
            bar3.Name = "Bar3";
            bar3.DataLabelStyle.Visible = true;
            bar3.DataLabelStyle.Format = "<value>";
            bar3.FillStyle = new NColorFillStyle(Color.DarkGoldenrod);
            bar3.BorderStyle.Color = Color.FromArgb(255, 255, 210);

            // fill with random data
            int barCount = 6;
            bar1.Values.FillRandomRange(Random, barCount, 10, 40);
            bar2.Values.FillRandomRange(Random, barCount, 30, 60);
            bar3.Values.FillRandomRange(Random, barCount, 50, 80);

            return chart;
        }



        private NRadialGaugePanel CreateRadialGauge()
        {
            // create the radial gauge
            NRadialGaugePanel radialGauge = new NRadialGaugePanel();
            radialGauge.PaintEffect = new NGlassEffectStyle();
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            radialGauge.ContentAlignment = ContentAlignment.BottomCenter;

            NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
            axis.Range = new NRange1DD(0, 250);

            NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;
            scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation);
            scale.MinorTickCount = 4;
            scale.RulerStyle.BorderStyle.Width = new NLength(0);
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGray);

            NScaleSectionStyle scaleSection = new NScaleSectionStyle();
            scaleSection.Range = new NRange1DD(220, 260);
            scaleSection.MajorTickStrokeStyle = new NStrokeStyle(Color.Red);
            scaleSection.MinorTickStrokeStyle = new NStrokeStyle(1, Color.Red, LinePattern.Dot, 0, 2);

            NTextStyle labelStyle = new NTextStyle();
            labelStyle.FillStyle = new NGradientFillStyle(Color.Red, Color.DarkRed);
            labelStyle.FontStyle.Style = FontStyle.Bold;
            scaleSection.LabelTextStyle = labelStyle;

            scale.Sections.Add(scaleSection);

            NRangeIndicator rangeIndicator = new NRangeIndicator();
            rangeIndicator.Value = 220;
            rangeIndicator.OriginMode = OriginMode.ScaleMax;
            rangeIndicator.FillStyle = new NColorFillStyle(Color.Red);
            rangeIndicator.StrokeStyle.Width = new NLength(0);
            rangeIndicator.BeginWidth = new NLength(-2);
            rangeIndicator.EndWidth = new NLength(-10);
            radialGauge.Indicators.Add(rangeIndicator);

            NMarkerValueIndicator markerIndicator = new NMarkerValueIndicator();
            markerIndicator.Value = 90;
            radialGauge.Indicators.Add(markerIndicator);

            NNeedleValueIndicator needleIndictor = new NNeedleValueIndicator();
            needleIndictor.Value = 0;
            needleIndictor.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
            needleIndictor.Shape.StrokeStyle.Color = Color.Red;
            radialGauge.Indicators.Add(needleIndictor);

            radialGauge.BeginAngle = -240;
            radialGauge.SweepAngle = 300;

            return radialGauge;
        }

        private void UpdateSheet()
        {
            NFillStyleSheetConfigurator fillStyleSheet = new NFillStyleSheetConfigurator();
            fillStyleSheet.Palette.SetPredefinedPalette((ChartPredefinedPalette)PaletteComboBox.SelectedIndex);

            fillStyleSheet.ControlBackgroundFillTemplate = CreateFillTemplateFromCombo(BackgroundFillTemplateComboBox);
            fillStyleSheet.LabelFillTemplate = CreateFillTemplateFromCombo(LabelsFillTemplateComboBox);
            fillStyleSheet.WallFillTemplate = CreateFillTemplateFromCombo(WallsFillTemplateComboBox);
            fillStyleSheet.SeriesFillTemplate = CreateFillTemplateFromCombo(SeriesFillTemplateComboBox);
            fillStyleSheet.IndicatorFillTemplate = CreateFillTemplateFromCombo(IndicatorsFillTemplateComboBox);
            fillStyleSheet.MultiColorSeries = MultiColorSeriesCheckBox.Checked;

            NStrokeStyleSheetConfigurator strokeStyleSheet = new NStrokeStyleSheetConfigurator();
            strokeStyleSheet.Palette.SetPredefinedPalette((ChartPredefinedPalette)PaletteComboBox.SelectedIndex);

            strokeStyleSheet.LabelStrokeTemplate = CreateStrokeTemplateFromCombo(LabelsStrokeTemplateComboBox);
            strokeStyleSheet.IndicatorStrokeTemplate = CreateStrokeTemplateFromCombo(IndicatorsStrokeTemplateComboBox);
            strokeStyleSheet.MultiColorSeries= MultiColorSeriesStrokeCheckBox.Checked;
            strokeStyleSheet.RulerStrokeTemplate = CreateStrokeTemplateFromCombo(RulerStrokeTemplateComboBox);
            strokeStyleSheet.SeriesStrokeTemplate = CreateStrokeTemplateFromCombo(SeriesStrokeTemplateComboBox);
            strokeStyleSheet.ApplyToDataLabels = ApplyToDataLabelsCheckBox.Checked;

            NStyleSheet sheet = new NStyleSheet();
            fillStyleSheet.ConfigureSheet(sheet);
            strokeStyleSheet.ConfigureSheet(sheet);

            sheet.Apply(nChartControl1.Document);

            nChartControl1.Refresh();
        }

        private static NFillStyleTemplate CreateFillTemplateFromCombo(Nevron.UI.WinForm.Controls.NComboBox comboBox)
        {
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    return null;
                case 1:
                    return new NColorFillStyleTemplate();
                case 2:
                    return new NGradientFillStyleTemplate();
                case 3:
                    return new NHatchFillStyleTemplate();
            }

            return null;
        }

        private static NStrokeStyleTemplate CreateStrokeTemplateFromCombo(Nevron.UI.WinForm.Controls.NComboBox comboBox)
        {
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    return new NStrokeStyleTemplate(new NLength(0), LinePattern.Solid);
                case 1:
                    return new NStrokeStyleTemplate(new NLength(1.0f), LinePattern.Solid);
                case 2:
                    return new NStrokeStyleTemplate(new NLength(1.0f), LinePattern.Dash);
                case 3:
                    return new NStrokeStyleTemplate(new NLength(2), LinePattern.Solid);
                case 4:
                    return new NStrokeStyleTemplate(new NLength(2), LinePattern.Dash);
            }

            return null;
        }

        private static void PopulateFillTemplateCombo(Nevron.UI.WinForm.Controls.NComboBox comboBox)
        {
            comboBox.Items.Add("None");
            comboBox.Items.Add("Solid Fill");
            comboBox.Items.Add("Gradient Fill");
            comboBox.Items.Add("Hatch Fill");
            comboBox.SelectedIndex = 1;
        }

        private static void PopulateStrokeTemplateCombo(Nevron.UI.WinForm.Controls.NComboBox comboBox, int selectedIndex)
        {
            comboBox.Items.Add("None");
            comboBox.Items.Add("Solid Stroke");
            comboBox.Items.Add("Dash Stroke");
            comboBox.Items.Add("Solid Stroke 2pt");
            comboBox.Items.Add("Dash Stroke 2pt");
            comboBox.SelectedIndex = selectedIndex;
        }

        private static void PopulateStrokeTemplateCombo(Nevron.UI.WinForm.Controls.NComboBox comboBox)
        {
            PopulateStrokeTemplateCombo(comboBox, 0);
        }

        private void PaletteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }

        private void BackgroundFillTemplateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }

        private void LabelsFillTemplateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }

        private void WallsFillTemplateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }

        private void SeriesFillTemplateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }

        private void MultiColorSeriesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }

        private void IndicatorsFillTemplateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }

        private void LabelsStrokeTemplateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }

        private void RulerStrokeTemplateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }

        private void SeriesStrokeTemplateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }

        private void ApplyToDataLabelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }

        private void MultiColorSeriesStrokeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }

        private void IndicatorsStrokeTemplateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSheet();
        }
    }
}
