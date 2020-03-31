using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	/// <summary>
	///		
	/// </summary>
	public partial class NFinancialDashboardUC : NExampleUC
	{
		private NStockSeries m_Stock;
		private NRadialGaugePanel m_MinRadialGauge;
		private NRadialGaugePanel m_MaxRadialGauge;
		private NRadialGaugePanel m_AvgRadialGauge;
		private NNeedleValueIndicator m_MinIndicator;
		private NNeedleValueIndicator m_MaxIndicator;
		private NNeedleValueIndicator m_AvgIndicator;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.Panels.Clear();
            nChartControl1.BackgroundStyle.FillStyle = new NGradientFillStyle(Color.White, Color.Black);

            // set a chart title
            NLabel header = nChartControl1.Labels.AddFooter("Financial Dashboard");
            header.BackgroundFillStyle = new NColorFillStyle(Color.FromArgb(125, Color.White));
            header.DockMode = PanelDockMode.Top;
            header.TextStyle.ShadowStyle.Type = ShadowType.Solid;
            header.TextStyle.ShadowStyle.Color = Color.White;
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 13, FontStyle.Italic);
            header.TextStyle.FillStyle = new NColorFillStyle(Color.MidnightBlue);
            header.DockMargins = new NMarginsL(5, 5, 5, 0);

            // setup Stock chart
            nChartControl1.Panels.Add(CreateStockChart());

            NDockPanel gaugeContainerPanel = new NDockPanel();
            gaugeContainerPanel.DockMode = PanelDockMode.Fill;
            gaugeContainerPanel.Margins = new NMarginsL(5, 0, 5, 5);
            gaugeContainerPanel.PositionChildPanelsInContentBounds = true;
            nChartControl1.Panels.Add(gaugeContainerPanel);

            m_MinRadialGauge = CreateGaugePanel("Minimum");
            m_MinRadialGauge.Location = new NPointL(new NLength(0, NRelativeUnit.ParentPercentage), new NLength(0, NRelativeUnit.ParentPercentage));
            m_MinIndicator = CreateIndicator();

            DecorateGaugeAxis(m_MinRadialGauge, new NRange1DD(0, 100), Color.Blue, Color.DarkBlue);
            m_MinRadialGauge.Indicators.Add(m_MinIndicator);
            gaugeContainerPanel.ChildPanels.Add(m_MinRadialGauge);

            m_MaxRadialGauge = CreateGaugePanel("Maximum");
            m_MaxRadialGauge.Location = new NPointL(new NLength(34, NRelativeUnit.ParentPercentage), new NLength(0, NRelativeUnit.ParentPercentage));
            DecorateGaugeAxis(m_MaxRadialGauge, new NRange1DD(300, 400), Color.Red, Color.DarkRed);
            m_MaxIndicator = CreateIndicator();
            m_MaxRadialGauge.Indicators.Add(m_MaxIndicator);
            gaugeContainerPanel.ChildPanels.Add(m_MaxRadialGauge);

            m_AvgRadialGauge = CreateGaugePanel("Average");
            m_AvgRadialGauge.Location = new NPointL(new NLength(68, NRelativeUnit.ParentPercentage), new NLength(0, NRelativeUnit.ParentPercentage));
            DecorateGaugeAxis(m_AvgRadialGauge, new NRange1DD(100, 300), Color.Green, Color.DarkGreen);
            m_AvgIndicator = CreateIndicator();
            m_AvgRadialGauge.Indicators.Add(m_AvgIndicator);
            gaugeContainerPanel.ChildPanels.Add(m_AvgRadialGauge);

            // generate some data
            GenerateData();
        }

        private void GenerateData()
        {
            WebExamplesUtilities.GenerateOHLCData(m_Stock, 100, 200, new NRange1DD(50, 350));

            double min = (double)m_Stock.LowValues[m_Stock.LowValues.FindMinValue()];
            double max = (double)m_Stock.HighValues[m_Stock.HighValues.FindMaxValue()];

            m_MinIndicator.Value = min;
            m_MaxIndicator.Value = max;

            int count = m_Stock.CloseValues.Count;
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += (double)m_Stock.CloseValues[i];
            }

            if (count > 0)
            {
                m_AvgIndicator.Value = sum / count;
            }
            else
            {
                m_AvgIndicator.Value = 0;
            }
        }

        private NLabel CreateGaugeLabel(string text)
        {
            NLabel label = new NLabel(text);

            label.DockMode = PanelDockMode.Bottom;
            label.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            label.TextStyle.FontStyle.EmSize = new NLength(9);
            label.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));
            label.ContentAlignment = ContentAlignment.TopCenter;
            label.BoundsMode = BoundsMode.None;
            label.Padding = new NMarginsL(2, 2, 2, 2);
            label.BackgroundFillStyle = new NColorFillStyle(Color.FromArgb(125, Color.White));

            return label;
        }

        private NRadialGaugePanel CreateGaugePanel(string labelText)
        {
            // create the radial gauge
            NRadialGaugePanel radialGauge = new NRadialGaugePanel();
            radialGauge.Size = new NSizeL(new NLength(32, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));
            radialGauge.BoundsMode = BoundsMode.Fit;
            radialGauge.BeginAngle = -180;
            radialGauge.SweepAngle = 180;
            radialGauge.ContentAlignment = ContentAlignment.BottomRight;
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            radialGauge.AutoBorder = RadialGaugeAutoBorder.CutCircle;
            radialGauge.BackgroundFillStyle = new NColorFillStyle(Color.FromArgb(125, Color.White));

            // apply effects
            NGelEffectStyle gelEffect = new NGelEffectStyle(PaintEffectShape.RoundedRect);
            gelEffect.CornerRounding = new NLength(10);
            gelEffect.Margins = new NMarginsL(new NLength(0), new NLength(0), new NLength(0), new NLength(60, NRelativeUnit.ParentPercentage));
            radialGauge.PaintEffect = gelEffect;

            // apply margins in order to leave room for the label
            radialGauge.Margins = new NMarginsL(2, 2, 2, 20);

            NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];

            // apply anchor
            NDockGaugeAxisAnchor anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, false);
            anchor.RulerOrientation = RulerOrientation.Right;
            anchor.SynchronizeRulerOrientation = false;
            axis.Anchor = anchor;

            axis.Range = new NRange1DD(0, 400);

            NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;
            scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation);
            scale.LabelFitModes = new LabelFitMode[0];
            scale.MinorTickCount = 2;
            scale.RulerStyle.BorderStyle.Width = new NLength(0);
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.LightGray));
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 6, FontStyle.Bold);

            radialGauge.ChildPanels.Add(CreateGaugeLabel(labelText));

            return radialGauge;
        }

        private NCartesianChart CreateStockChart()
        {
            NCartesianChart chart = new NCartesianChart();
            chart.DockMode = PanelDockMode.Top;
            chart.Size = new NSizeL(new NLength(0), new NLength(55, NRelativeUnit.ParentPercentage));
            chart.Margins = new NMarginsL(5, 5, 5, 0);
            chart.BackgroundFillStyle = new NColorFillStyle(Color.FromArgb(125, Color.White));
            chart.BoundsMode = BoundsMode.Stretch;
            chart.Padding = new NMarginsL(5, 5, 5, 0);

            // setup X axis
            NAxis axis = chart.Axis(StandardAxis.PrimaryX);
            NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)axis.ScaleConfigurator;
            ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, false);
            ordinalScale.InnerMajorTickStyle.Length = new NLength(0);

            // setup Y axis
            axis = chart.Axis(StandardAxis.PrimaryY);
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
            linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);
            linearScale.InnerMajorTickStyle.Length = new NLength(0);

            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            linearScale.StripStyles.Add(stripStyle);

            // setup the stock series
            m_Stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
            m_Stock.Name = "Price";
            m_Stock.Legend.Mode = SeriesLegendMode.None;
            m_Stock.DataLabelStyle.Visible = false;
            m_Stock.CandleStyle = CandleStyle.Stick;
            m_Stock.UpStrokeStyle.Color = Color.RoyalBlue;
            m_Stock.OpenValues.Name = "open";
            m_Stock.HighValues.Name = "high";
            m_Stock.LowValues.Name = "low";
            m_Stock.CloseValues.Name = "close";
            m_Stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);

            return chart;
        }

        private NNeedleValueIndicator CreateIndicator()
        {
            NNeedleValueIndicator indicator = new NNeedleValueIndicator();

			indicator.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleBegin;
			indicator.OffsetFromScale = new NLength(5);
            indicator.Shape.FillStyle = new NGradientFillStyle(Color.White, Color.Red);

            return indicator;
        }

        private void DecorateGaugeAxis(NRadialGaugePanel panel, NRange1DD range, Color colorLight, Color colorDark)
        {
            NGaugeAxis axis = (NGaugeAxis)panel.Axes[0];
            NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

            // create a range indicator
            NRangeIndicator rangeIndicator = new NRangeIndicator();
            rangeIndicator.OriginMode = OriginMode.Custom;
            rangeIndicator.Value = range.Begin;
            rangeIndicator.Origin = range.End;
            rangeIndicator.BeginWidth = new NLength(10);
            rangeIndicator.EndWidth = new NLength(10);

            rangeIndicator.FillStyle = new NColorFillStyle(Color.FromArgb(100, colorLight));
            rangeIndicator.StrokeStyle.Color = colorLight;
            panel.Indicators.Add(rangeIndicator);

            // create a scale section
            NScaleSectionStyle scaleSection = new NScaleSectionStyle();
            scaleSection.Range = range;
            scaleSection.MajorTickStrokeStyle = new NStrokeStyle(colorLight);
            scaleSection.MinorTickStrokeStyle = new NStrokeStyle(1, colorLight, LinePattern.Dot, 0, 2);

            NTextStyle labelStyle = new NTextStyle();
            labelStyle.FillStyle = new NGradientFillStyle(colorLight, colorDark);
            labelStyle.FontStyle = new NFontStyle("Arial", 6, FontStyle.Bold);
            scaleSection.LabelTextStyle = labelStyle;

            scale.Sections.Add(scaleSection);
        }
    }
}
