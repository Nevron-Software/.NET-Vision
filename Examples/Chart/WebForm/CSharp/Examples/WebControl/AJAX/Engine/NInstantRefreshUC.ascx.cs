using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NInstantRefreshUC : NExampleUC
	{
		#region Event Handlers

		protected void Page_Load(object sender, System.EventArgs e)
		{
			nChartControl1.HttpHandlerCallback = new CustomHttpHandlerCallback();

			if (nChartControl1.RequiresInitialization)
			{
                nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
				nChartControl1.Panels.Clear();
				NStandardFrameStyle frame = nChartControl1.BackgroundStyle.FrameStyle as NStandardFrameStyle;
				frame.InnerBorderWidth = new NLength(0);

				// set a chart title
				NLabel header = nChartControl1.Labels.AddFooter("Instant Auto Refresh");
				header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                header.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(60, 90, 108));
				header.ContentAlignment = ContentAlignment.BottomRight;
				header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

				// setup Line chart
				NCartesianChart chart = new NCartesianChart();

                chart.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage), new NLength(3, NRelativeUnit.ParentPercentage));
                chart.Size = new NSizeL(new NLength(100, NRelativeUnit.ParentPercentage), new NLength(65, NRelativeUnit.ParentPercentage));
                chart.BoundsMode = BoundsMode.Stretch;

				chart.Margins = new NMarginsL(5, 10, 5, 10);
				SetupLineChart(chart);

                nChartControl1.Panels.Add(chart);

				NRadialGaugePanel minRadialGauge = CreateGaugePanel();
                minRadialGauge.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage), new NLength(35, NRelativeUnit.ParentPercentage));
                minRadialGauge.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage), new NLength(63, NRelativeUnit.ParentPercentage));
				NNeedleValueIndicator minIndicator = CreateIndicator();
				DecorateGaugeAxis(minRadialGauge, new NRange1DD(0, 100), Color.Blue, Color.DarkBlue);
				minRadialGauge.Indicators.Add(minIndicator);
                minRadialGauge.ChildPanels.Add(CreateGaugeLabel("Min"));
                nChartControl1.Panels.Add(minRadialGauge);

				NRadialGaugePanel maxRadialGauge = CreateGaugePanel();
                maxRadialGauge.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage), new NLength(35, NRelativeUnit.ParentPercentage));
                maxRadialGauge.Location = new NPointL(new NLength(35, NRelativeUnit.ParentPercentage), new NLength(63, NRelativeUnit.ParentPercentage));
				DecorateGaugeAxis(maxRadialGauge, new NRange1DD(300, 400), Color.Red, Color.DarkRed);
				NNeedleValueIndicator maxIndicator = CreateIndicator();
				maxRadialGauge.Indicators.Add(maxIndicator);
                maxRadialGauge.ChildPanels.Add(CreateGaugeLabel("Max"));
                nChartControl1.Panels.Add(maxRadialGauge);

				NRadialGaugePanel avgRadialGauge = CreateGaugePanel();
                avgRadialGauge.Size = new NSizeL(new NLength(30, NRelativeUnit.ParentPercentage), new NLength(35, NRelativeUnit.ParentPercentage));
                avgRadialGauge.Location = new NPointL(new NLength(68, NRelativeUnit.ParentPercentage), new NLength(63, NRelativeUnit.ParentPercentage));
				DecorateGaugeAxis(avgRadialGauge, new NRange1DD(100, 300), Color.Green, Color.DarkGreen);
				NNeedleValueIndicator avgIndicator = CreateIndicator();
				avgRadialGauge.Indicators.Add(avgIndicator);
                avgRadialGauge.ChildPanels.Add(CreateGaugeLabel("Avg"));
                nChartControl1.Panels.Add(avgRadialGauge);

				// generate some data
				GenerateNewData();
			}
		}

		#endregion

		#region Implementation

		private void GenerateNewData()
		{
			NLineSeries line = (NLineSeries)nChartControl1.Charts[0].Series[0];
			GenerateDateTimeData(line, 100);
			UpdateIndicators(nChartControl1.Document);
		}

		private void GenerateDateTimeData(NLineSeries s, int nCount)
		{
			s.ClearDataPoints();
			DateTime dateTime = DateTime.Now.AddMilliseconds(-nCount * nChartControl1.AsyncRefreshInterval);
			double dPrev = 100;
			double value;
			NDataPoint dataPoint;
			for (int i = 0; i < nCount; i++)
			{
				GenerateDataPoint(dPrev, new NRange1DD(50, 350), out value);
				dataPoint = new NDataPoint(value);
				s.AddDataPoint(dataPoint);
				dPrev = (double)s.Values[s.Values.Count - 1];
				dateTime = dateTime.AddMilliseconds(nChartControl1.AsyncRefreshInterval);
				s.XValues.Add(dateTime);
			}
		}

		protected static void UpdateIndicators(NDocument document)
		{
			NLineSeries line = (NLineSeries)document.RootPanel.Charts[0].Series[0];

			double min = (double)line.Values[line.Values.FindMinValue()];
			double max = (double)line.Values[line.Values.FindMaxValue()];

            NGaugePanel panel1 = document.RootPanel.ChildPanels[2] as NGaugePanel;
            NGaugePanel panel2 = document.RootPanel.ChildPanels[3] as NGaugePanel;
            NGaugePanel panel3 = document.RootPanel.ChildPanels[4] as NGaugePanel;

			NNeedleValueIndicator minIndicator = panel1.Indicators[1] as NNeedleValueIndicator;
			NNeedleValueIndicator maxIndicator = panel2.Indicators[1] as NNeedleValueIndicator;
			NNeedleValueIndicator avgIndicator = panel3.Indicators[1] as NNeedleValueIndicator;

			 minIndicator.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleBegin;
			 maxIndicator.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleBegin;
			 avgIndicator.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleBegin;

			minIndicator.Value = min;
			maxIndicator.Value = max;

			int count = line.Values.Count;
			double sum = 0;

			for (int i = 0; i < count; i++)
			{
				sum += (double)line.Values[i];
			}

			if (count > 0)
			{
				avgIndicator.Value = sum / count;
			}
			else
			{
				avgIndicator.Value = 0;
			}
		}

		protected NLabel CreateGaugeLabel(string text)
		{
			NLabel label = new NLabel(text);

			label.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			label.TextStyle.FontStyle.EmSize = new NLength(8);
			label.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			label.ContentAlignment = ContentAlignment.TopCenter;
			label.BoundsMode = BoundsMode.Fit;

			return label;
		}

		protected NNeedleValueIndicator CreateIndicator()
		{
			NNeedleValueIndicator indicator = new NNeedleValueIndicator();

			indicator.Shape.FillStyle = new NGradientFillStyle(Color.White, Color.Red);
            indicator.OffsetFromScale = new NLength(4);

			return indicator;
		}

		protected void DecorateGaugeAxis(NRadialGaugePanel panel, NRange1DD range, Color colorLight, Color colorDark)
		{
			NGaugeAxis axis = (NGaugeAxis)panel.Axes[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

			NRangeIndicator rangeIndicator = new NRangeIndicator();
			rangeIndicator.OriginMode = OriginMode.Custom;
            rangeIndicator.OffsetFromScale = new NLength(10);
			rangeIndicator.Value = range.Begin;
			rangeIndicator.Origin = range.End;

			rangeIndicator.FillStyle =  new NColorFillStyle(Color.FromArgb(30, colorLight));
            rangeIndicator.StrokeStyle.Width = new NLength(0);
			panel.Indicators.Add(rangeIndicator);

			NScaleSectionStyle scaleSection = new NScaleSectionStyle();
			scaleSection.Range = range;
			scaleSection.MajorTickFillStyle = new NColorFillStyle(colorLight);
            scaleSection.MinorTickFillStyle = new NColorFillStyle(colorLight);

			NTextStyle labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NColorFillStyle(colorDark);
			labelStyle.FontStyle.Style = FontStyle.Bold;
			labelStyle.FontStyle.EmSize = new NLength(6);
			scaleSection.LabelTextStyle = labelStyle;

			scale.Sections.Add(scaleSection);
		}

		protected NRadialGaugePanel CreateGaugePanel()
		{
			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();
			radialGauge.ContentAlignment = ContentAlignment.BottomRight;
            radialGauge.BackgroundFillStyle = new NAdvancedGradientFillStyle(AdvancedGradientScheme.WhiteOnBlack, 0);
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            radialGauge.PaintEffect = new NGlassEffectStyle();
			
			NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
            axis.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, RulerOrientation.Right, 0, 100);
			axis.Range = new NRange1DD(0, 400);

			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
            scale.LabelFitModes = new LabelFitMode[0];
			scale.MinorTickCount = 4;
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.WhiteSmoke));
			scale.LabelStyle.TextStyle.FontStyle.EmSize = new NLength(6);
			scale.MinTickDistance = new NLength(15);

			radialGauge.BeginAngle = -240;
			radialGauge.SweepAngle = 300;

			return radialGauge;
		}

		protected NBackgroundDecoratorPanel CreateBackgroundPanel()
		{
			NBackgroundStyle backroundStyle = new NBackgroundStyle();
			backroundStyle.FillStyle = new NColorFillStyle(Color.Transparent);
			NImageFrameStyle frameStyle = new NImageFrameStyle();
			frameStyle.BackgroundColor = Color.Transparent;
			frameStyle.Type = ImageFrameType.Raised;
			frameStyle.BorderStyle.Width = new NLength(0);
			backroundStyle.FrameStyle = frameStyle;

			NBackgroundDecoratorPanel backgroundPanel = new NBackgroundDecoratorPanel();
			backgroundPanel.DockMargins = new NMarginsL(new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point), new NLength(5, NGraphicsUnit.Point));
			backgroundPanel.BackgroundStyle = (NBackgroundStyle)backroundStyle.Clone();

			return backgroundPanel;
		}

		private void SetupLineChart(NCartesianChart chart)
		{
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.LightModel.EnableLighting = false;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Wall(ChartWallType.Floor).Visible = false;
			chart.Wall(ChartWallType.Left).Visible = false;
			chart.DockMargins = new NMarginsL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(10, NRelativeUnit.ParentPercentage),
				new NLength(10, NRelativeUnit.ParentPercentage),
				new NLength(5, NRelativeUnit.ParentPercentage));
			chart.BoundsMode = BoundsMode.Stretch;

			// setup X axis
			NAxis axis = chart.Axis(StandardAxis.PrimaryX);
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			dateTimeScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			dateTimeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			dateTimeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, false);
			dateTimeScale.InnerMajorTickStyle.Length = new NLength(0);
			dateTimeScale.MaxTickCount = 8;
			dateTimeScale.MajorTickMode = MajorTickMode.AutoMaxCount;
			dateTimeScale.AutoDateTimeUnits = new NDateTimeUnit[] { NDateTimeUnit.Second };
			dateTimeScale.RoundToTickMin = false;
			dateTimeScale.RoundToTickMax = false;
			dateTimeScale.EnableUnitSensitiveFormatting = false;
			dateTimeScale.LabelValueFormatter = new NDateTimeValueFormatter("T");
			axis.ScaleConfigurator = dateTimeScale;

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

			// setup the line series
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.Name = "Price";
			line.Legend.Mode = SeriesLegendMode.None;
			line.DataLabelStyle.Visible = false;
			line.FillStyle = new NColorFillStyle(Color.RoyalBlue);
			line.UseXValues = true;
		}

		protected static void GenerateDataPoint(double dPrev, NRange1DD range, out double value)
		{
			value = dPrev;
			bool upward = false;
			if (dPrev <= range.Begin)
			{
				upward = true;
			}
			else
			{
				if (dPrev >= range.End)
				{
					upward = false;
				}
				else
				{
					upward = WebExamplesUtilities.rand.NextDouble() > 0.5;
				}
			}
			if (upward)
			{
				// upward value change
				value = value + (2 + (WebExamplesUtilities.rand.NextDouble() * 10));
			}
			else
			{
				// downward value change
				value = value - (2 + (WebExamplesUtilities.rand.NextDouble() * 10));
			}
		}

		#endregion

		#region Nested Classes

		[Serializable]
		public class CustomHttpHandlerCallback : NHttpHandlerCallback
		{
			#region INHttpHandlerCallback Members

			public override void OnAsyncRefresh(string webControlId, System.Web.HttpContext context, NStateObject state, EventArgs args)
			{
				NChartSessionStateObject chartState = state as NChartSessionStateObject;
				NRootPanel rootPanel = chartState.Document.RootPanel;
				NLineSeries line = (NLineSeries)chartState.Document.RootPanel.Charts[0].Series[0];

				if (line == null)
					return;

				if (line.Values.Count == 0)
					return;

				double dPrev = (double)line.Values[line.Values.Count - 1];

				double value;
				GenerateDataPoint(dPrev, new NRange1DD(50, 350), out value);
				line.Values.RemoveAt(0);
				line.XValues.RemoveAt(0);

				line.Values.Add(value);

				int nLast = (line.XValues.Count > 0 ? line.XValues.Count - 1 : 0);

				double dLastValue = (double)line.XValues[nLast];
				line.XValues.Add(DateTime.Now);
				UpdateIndicators(chartState.Document);
			}

			#endregion
		}

		#endregion
	}
}
