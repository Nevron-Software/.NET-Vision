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
    public class NPredefinedStyleSheetsUC : NExampleBaseUC
    {
        public NPredefinedStyleSheetsUC()
        {
            InitializeComponent();
        }

        private Nevron.UI.WinForm.Controls.NComboBox PredefinedStyleSheetComboBox;
        private Label label1;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PredefinedStyleSheetComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PredefinedStyleSheetComboBox
            // 
            this.PredefinedStyleSheetComboBox.Location = new System.Drawing.Point(12, 42);
            this.PredefinedStyleSheetComboBox.Name = "PredefinedStyleSheetComboBox";
            this.PredefinedStyleSheetComboBox.Size = new System.Drawing.Size(150, 21);
            this.PredefinedStyleSheetComboBox.TabIndex = 0;
            this.PredefinedStyleSheetComboBox.SelectedIndexChanged += new System.EventHandler(this.PredefinedStyleSheetComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Predefined Style Sheet";
            // 
            // NPredefinedStyleSheetsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PredefinedStyleSheetComboBox);
            this.Name = "NPredefinedStyleSheetsUC";
            this.Size = new System.Drawing.Size(175, 288);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public override void Initialize()
        {
            base.Initialize();

            // configure device and interactivity
            nChartControl1.Panels.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Predefined Style Sheets");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
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
            chart.Location = new NPointL(5, 0);
            chart.Size = new NSizeL(new NLength(60, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));
            chart.BoundsMode = BoundsMode.Fit;

            dockPanel.ChildPanels.Add(chart);
            NRadialGaugePanel gauge = CreateRadialGauge();
            dockPanel.ChildPanels.Add(gauge);
            gauge.Location = new NPointL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
            gauge.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage), new NLength(40, NRelativeUnit.ParentPercentage));

            gauge = CreateRadialGauge();
            dockPanel.ChildPanels.Add(gauge);
            gauge.Location = new NPointL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
            gauge.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage), new NLength(40, NRelativeUnit.ParentPercentage));

            PredefinedStyleSheetComboBox.FillFromEnum(typeof(PredefinedStyleSheet));

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
			scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0, false);

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
            rangeIndicator.BeginWidth = new NLength(2);
            rangeIndicator.EndWidth = new NLength(10);
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

        private void PredefinedStyleSheetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet((PredefinedStyleSheet)PredefinedStyleSheetComboBox.SelectedIndex);
            styleSheet.Apply(nChartControl1.Document);

            nChartControl1.Refresh();
        }
    }
}
