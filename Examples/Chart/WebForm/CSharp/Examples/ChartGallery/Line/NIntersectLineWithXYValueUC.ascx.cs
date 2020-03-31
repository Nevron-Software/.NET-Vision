using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using System.Collections.Generic;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NIntersectLineWithXYValueUC : NExampleUC
	{
		//protected NChart nChart;
		//protected NLineSeries nLine;

		protected CheckBox LightsCheckBoxBox;
		protected CheckBox InflateMarginsCheckBoxBox;
		protected CheckBox LeftAxisRoundToTickCheckBoxBox;
		protected CheckBox ShowMarkersCheckBoxBox;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// fill the combo
				WebExamplesUtilities.FillComboWithValues(XValueDropDownList, 10, 90, 10);
				WebExamplesUtilities.FillComboWithValues(YValueDropDownList, 10, 90, 10);
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Intersect Line With X/Y Value");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            NChart chart = nChartControl1.Charts[0];

			// 2D line chart
			chart.BoundsMode = BoundsMode.Stretch;

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = GetScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = GetScaleConfigurator();
			chart.Axis(StandardAxis.Depth).Visible = false;

			NAxisCollection axes = chart.Axes;

			// add point series
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.UseXValues = true;
			point.FillStyle = new NColorFillStyle(Color.Red);
			point.DataLabelStyle.Visible = false;
			point.Size = new NLength(2);

			NLineSeries line = new NLineSeries();
			chart.Series.Add(line);

			line.Name = "Point 1";
			line.FillStyle = new NColorFillStyle(Color.Red);
			line.BorderStyle.Color = Color.Pink;
			line.DataLabelStyle.Visible = false;
			line.UseXValues = true;
			line.InflateMargins = true;

			// fill with data
			Random rand = new Random();
			double radius = 0;
			double angle = 0;

			int dataPointCount = 1000;
			double rStep = 50.0 / dataPointCount;
			double aStep = 10.0;

			for (int i = 0; i < dataPointCount; i++)
			{
				double y = Math.Sin(angle * 0.0174533f) * radius;
				double x = Math.Cos(angle * 0.0174533f) * radius;

				line.XValues.Add(50.0 + x);
				line.Values.Add(50.0 + y);

				radius += rStep;
				angle += aStep;
			}

			point.XValues.Clear();
			point.Values.Clear();

			NAxisConstLine horizontalAxisCursor = new NAxisConstLine();
			NAxisConstLine verticalAxisCursor = new NAxisConstLine();

			chart.Axis(StandardAxis.PrimaryX).ConstLines.Add(horizontalAxisCursor);
			chart.Axis(StandardAxis.PrimaryY).ConstLines.Add(verticalAxisCursor);

			double xValue = (XValueDropDownList.SelectedIndex + 1) * 10;
			double yValue = (YValueDropDownList.SelectedIndex + 1) * 10;

			horizontalAxisCursor.Value = xValue;

			List<double> intersections = line.IntersectWithXValue(xValue);

			for (int i = 0; i < intersections.Count; i++)
			{
				point.XValues.Add(xValue);
				point.Values.Add(intersections[i]);
			}

			verticalAxisCursor.Value = yValue;
			intersections = line.IntersectWithYValue(yValue);

			for (int i = 0; i < intersections.Count; i++)
			{
				point.XValues.Add(intersections[i]);
				point.Values.Add(yValue);
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);			
		}

		private NLinearScaleConfigurator GetScaleConfigurator()
		{
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();

			linearScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);
			linearScale.MinorTickCount = 4;

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			return linearScale;
		}
	}
}