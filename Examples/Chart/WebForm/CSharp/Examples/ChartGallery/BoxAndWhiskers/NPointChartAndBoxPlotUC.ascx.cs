using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NPointChartAndBoxPlotUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = new NLabel("Data Distribution");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Margins = new NMarginsL(5, 5, 5, 5);
			title.DockMode = PanelDockMode.Top;
			title.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// create box and whiskers chart
			NChart boxChart = new NCartesianChart();
			boxChart.Margins = new NMarginsL(5, 0, 5, 5);
			boxChart.BoundsMode = BoundsMode.Stretch;
			boxChart.DockMode = PanelDockMode.Right;
			boxChart.Size = new NSizeL(new NLength(20, NRelativeUnit.ParentPercentage), new NLength(100, NRelativeUnit.ParentPercentage));

			// create point chart
			NChart pointChart = new NCartesianChart();
			pointChart.Margins = new NMarginsL(5, 0, 0, 5);
			pointChart.BoundsMode = BoundsMode.Stretch;
			pointChart.DockMode = PanelDockMode.Fill;

			// create a guide line to align the chart bottoms
			NSideGuideline bottomChartGuideline = new NSideGuideline(PanelSide.Bottom);
			nChartControl1.Document.RootPanel.Guidelines.Add(bottomChartGuideline);
			bottomChartGuideline.Targets.Add(pointChart);
			bottomChartGuideline.Targets.Add(boxChart);

			// arrange panels
			nChartControl1.Panels.Add(title);
			nChartControl1.Panels.Add(boxChart);
			nChartControl1.Panels.Add(pointChart);

			SetupCharts(pointChart, boxChart);

			bool showAverage = ShowAverageCheckBox.Checked;
			bool showOutliers = ShowOutliersCheckBox.Checked;

			NPointSeries pointSeries = (NPointSeries)pointChart.Series[0];
			NBoxAndWhiskersSeries boxSeries = (NBoxAndWhiskersSeries)boxChart.Series[0];

			NBoxAndWhiskersDataPoint bwdp = new NBoxAndWhiskersDataPoint(pointSeries.Values, showAverage, showOutliers);
			boxSeries.ClearDataPoints();
			boxSeries.AddDataPoint(bwdp);
		}

		private void SetupCharts(NChart pointChart, NChart boxChart)
		{
			// data
			double[] arrValues = {	204.5, 190.6, 199.7, 131.8, 143.4,
									215.1, 228.0, 209.2, 183.8, 169.5,
									212.0, 254.9, 222.3, 201.0, 215.4,
									191.3, 181.5, 207.0, 199.0, 210.0 };

			// setup point chart
			NStandardScaleConfigurator scaleY1 = (NStandardScaleConfigurator)pointChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY1.InnerMajorTickStyle.Visible = false;
			scaleY1.MajorGridStyle.ShowAtWalls = new ChartWallType[0];

			NOrdinalScaleConfigurator scaleX1 = (NOrdinalScaleConfigurator)pointChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleX1.InnerMajorTickStyle.Visible = false;
			scaleX1.DisplayDataPointsBetweenTicks = false;

			// setup point series
			NPointSeries point = (NPointSeries)pointChart.Series.Add(SeriesType.Point);
			point.InflateMargins = true;
			point.DataLabelStyle.Visible = false;
			point.Size = new NLength(1.5f, NRelativeUnit.RootPercentage);
			point.PointShape = PointShape.Ellipse;
			point.FillStyle = new NColorFillStyle(DarkOrange);
			point.BorderStyle = new NStrokeStyle(DarkOrange);
			point.Values.AddRange(arrValues);

			// setup box and whiskers chart
			boxChart.Width = 10;
			boxChart.Axis(StandardAxis.PrimaryY).Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, false);
			NStandardScaleConfigurator scaleY2 = (NStandardScaleConfigurator)boxChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY2.InnerMajorTickStyle.Visible = false;
			scaleY2.MajorGridStyle.ShowAtWalls = new ChartWallType[0];

			boxChart.Axis(StandardAxis.PrimaryX).Visible = false;

			// setup box and whiskers series
			NBoxAndWhiskersSeries boxSeries = (NBoxAndWhiskersSeries)boxChart.Series.Add(SeriesType.BoxAndWhiskers);
			boxSeries.InflateMargins = true;
			boxSeries.DataLabelStyle.Visible = false;
			boxSeries.FillStyle = new NColorFillStyle(Red);
			boxSeries.OutliersFillStyle = new NColorFillStyle(DarkOrange);
			boxSeries.OutliersBorderStyle = new NStrokeStyle(DarkOrange);
			boxSeries.OutliersSize = new NLength(1.5f, NRelativeUnit.RootPercentage);
			boxSeries.MedianStrokeStyle = new NStrokeStyle(Color.Indigo);
			boxSeries.AverageStrokeStyle = new NStrokeStyle(1, Color.DarkRed, LinePattern.Dot);

			// create a box and whiskers data point and initialize it from the point series
			NBoxAndWhiskersDataPoint bwdp = new NBoxAndWhiskersDataPoint(point.Values, true, true);
			boxSeries.AddDataPoint(bwdp);

			// synchronize axes
			NAxis axis1 = pointChart.Axis(StandardAxis.PrimaryY);
			NAxis axis2 = boxChart.Axis(StandardAxis.PrimaryY);
			axis1.Slaves.Add(axis2);
			axis2.Slaves.Add(axis1);

			// set an axis stripe for the interquartile range
			double dQ1 = (double)bwdp[DataPointValue.LowerBoxValue];
			double dQ3 = (double)bwdp[DataPointValue.UpperBoxValue];
			NAxisStripe boxStripe = axis1.Stripes.Add(dQ1, dQ3);
			boxStripe.FillStyle = new NColorFillStyle(Color.FromArgb(50, GreyBlue));

			// set an axis stripe for the min / max range
			double dMin = (double)bwdp[DataPointValue.LowerWhiskerValue];
			double dMax = (double)bwdp[DataPointValue.UpperWhiskerValue];
			NAxisStripe whiskersStripe = axis1.Stripes.Add(dMin, dMax);
			whiskersStripe.FillStyle = new NColorFillStyle(Color.FromArgb(30, GreyBlue));
		}
	}
}
