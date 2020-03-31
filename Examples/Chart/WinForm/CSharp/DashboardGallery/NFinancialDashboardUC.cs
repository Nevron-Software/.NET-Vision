using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NFinancialDashboardUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton NewDataButton;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private NStockSeries m_Stock;
		private NRadialGaugePanel m_MinRadialGauge;
		private NRadialGaugePanel m_MaxRadialGauge;
		private NRadialGaugePanel m_AvgRadialGauge;
		private NNeedleValueIndicator m_MinIndicator;
		private NNeedleValueIndicator m_MaxIndicator;
		private NNeedleValueIndicator m_AvgIndicator;

		public NFinancialDashboardUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();
            nChartControl1.BackgroundStyle.FillStyle = new NGradientFillStyle(Color.White, Color.Black);

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Financial Dashboard");
			title.BackgroundFillStyle = new NColorFillStyle(Color.FromArgb(125, Color.White));
			title.DockMode = PanelDockMode.Top;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(Color.MidnightBlue);
			title.DockMargins = new NMarginsL(10, 10, 10, 0);

			// setup Stock chart
            nChartControl1.Panels.Add(CreateStockChart());

            NDockPanel gaugeContainerPanel = new NDockPanel();
            gaugeContainerPanel.DockMode = PanelDockMode.Fill;
            gaugeContainerPanel.Margins = new NMarginsL(10, 0, 10, 10);
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
			NewDataButton_Click(null, null);
		}

		private NLabel CreateGaugeLabel(string text)
		{
			NLabel label = new NLabel(text);

            label.DockMode = PanelDockMode.Bottom;
			label.TextStyle.FillStyle = new NColorFillStyle(Color.White);
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
            radialGauge.AutoBorder = RadialGaugeAutoBorder.RoundedOutline;
            radialGauge.BackgroundFillStyle = new NColorFillStyle(Color.FromArgb(125, Color.White));

            // apply effects
            NGelEffectStyle gelEffect = new NGelEffectStyle(PaintEffectShape.RoundedRect);
            gelEffect.CornerRounding = new NLength(10);
            gelEffect.Margins = new NMarginsL(new NLength(0), new NLength(0), new NLength(0), new NLength(60, NRelativeUnit.ParentPercentage));
            radialGauge.PaintEffect = gelEffect;

            // apply padding in order to leave room for the axis labels that touch the border
            radialGauge.Padding = new NMarginsL(2, 2, 2, 2);

            // apply margins in order to leave room for the label
            radialGauge.Margins = new NMarginsL(2, 2, 2, 30);

            NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
            axis.Range = new NRange1DD(0, 400);

            NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;
            scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation);
            scale.LabelFitModes = new LabelFitMode[0];
            scale.MinorTickCount = 2;
            scale.RulerStyle.BorderStyle.Width = new NLength(0);
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.LightGray));
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);

            radialGauge.ChildPanels.Add(CreateGaugeLabel(labelText));

            return radialGauge;
        }

        private NCartesianChart CreateStockChart()
        {
            NCartesianChart chart = new NCartesianChart();
            chart.DockMode = PanelDockMode.Top;
            chart.Size = new NSizeL(new NLength(0), new NLength(60, NRelativeUnit.ParentPercentage));
            chart.DockMargins = new NMarginsL(10, 10, 10, 10);
            chart.BackgroundFillStyle = new NColorFillStyle(Color.FromArgb(125, Color.White));
            chart.BoundsMode = BoundsMode.Stretch;
            chart.Padding = new NMarginsL(10, 10, 10, 10);

			// setup X axis
			NRangeTimelineScaleConfigurator scaleX = new NRangeTimelineScaleConfigurator();
			scaleX.FirstRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.FirstRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(225, 225, 225));
			scaleX.FirstRow.UseGridStyle = true;
			scaleX.SecondRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.SecondRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(215, 215, 215));
			scaleX.SecondRow.UseGridStyle = true;
			scaleX.ThirdRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.ThirdRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(205, 205, 205));
			scaleX.ThirdRow.UseGridStyle = true;
			// calendar
			NWeekDayRule wdr = new NWeekDayRule(WeekDayBit.All);
			wdr.Saturday = false;
			wdr.Sunday = false;
			scaleX.Calendar.Rules.Add(wdr);
			scaleX.EnableCalendar = true;
			// set configurator
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

            // setup Y axis
            NAxis axis = chart.Axis(StandardAxis.PrimaryY);
            NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleY.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);
			scaleY.InnerMajorTickStyle.Length = new NLength(0);

            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
			scaleY.StripStyles.Add(stripStyle);

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
			m_Stock.UseXValues = true;
			m_Stock.InflateMargins = true;

            return chart;
        }

		private NNeedleValueIndicator CreateIndicator()
		{
			NNeedleValueIndicator indicator = new NNeedleValueIndicator();

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
            labelStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);
			scaleSection.LabelTextStyle = labelStyle;

			scale.Sections.Add(scaleSection);
		}

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.NewDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// NewDataButton
			// 
			this.NewDataButton.Location = new System.Drawing.Point(5, 24);
			this.NewDataButton.Name = "NewDataButton";
			this.NewDataButton.Size = new System.Drawing.Size(171, 23);
			this.NewDataButton.TabIndex = 0;
			this.NewDataButton.Text = "Generate New Data";
			this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			// 
			// NFinancialDashboardUC
			// 
			this.Controls.Add(this.NewDataButton);
			this.Name = "NFinancialDashboardUC";
			this.Size = new System.Drawing.Size(180, 150);
			this.ResumeLayout(false);

		}
		#endregion

		private void NewDataButton_Click(object sender, System.EventArgs e)
		{
			const int count = 200;

			GenerateOHLCData(m_Stock, 100, count, new NRange1DD(50, 350));
			FillStockDates(m_Stock, count);

			double min = (double)m_Stock.LowValues[m_Stock.LowValues.FindMinValue()];
			double max = (double)m_Stock.HighValues[m_Stock.HighValues.FindMaxValue()];

			m_MinIndicator.Value = min;
			m_MaxIndicator.Value = max;

			double sum = 0;

			for (int i = 0; i < count; i++)
			{
				sum += (double)m_Stock.CloseValues[i];
			}

			if (count > 0)
			{
				m_AvgIndicator.Value = sum / count;
			}

			nChartControl1.Refresh();
		}
	}
}
