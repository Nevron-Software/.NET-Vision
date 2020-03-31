using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAutoLabelsXYPointUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				EnableInitialPositioningCheckBox.Checked = true;
				RemoveOverlappedLabelsCheckBox.Checked = false;
				EnableLabelAdjustmentCheckBox.Checked = true;
				EnableDataPointSafeguardCheckBox.Checked = true;

				WebExamplesUtilities.FillComboWithValues(SafeguardSizeDropDownList, 0, 20, 1);
				SafeguardSizeDropDownList.SelectedIndex = 12;

				HiddenField1.Value = Random.Next().ToString();
			}

            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];

			// configure X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// configure Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// add interlaced stripe for Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.StripStyles.Add(stripStyle);

			// point series 1
			NPointSeries series1 = (NPointSeries)chart.Series.Add(SeriesType.Point);
			series1.Name = "Point 1";
			series1.PointShape = PointShape.Ellipse;
			series1.Size = new NLength(1.7f, NRelativeUnit.ParentPercentage);
			series1.UseXValues = true;
			series1.InflateMargins = true;
			series1.FillStyle = new NColorFillStyle(DarkOrange);
			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Center;
			series1.DataLabelStyle.ArrowLength = new NLength(10);
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange;
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange;
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);

			// point series 2
			NPointSeries series2 = (NPointSeries)chart.Series.Add(SeriesType.Point);
			series2.Name = "Point 2";
			series2.PointShape = PointShape.Ellipse;
			series2.Size = new NLength(1.7f, NRelativeUnit.ParentPercentage);
			series2.UseXValues = true;
			series2.InflateMargins = true;
			series2.FillStyle = new NColorFillStyle(Green);
			series2.DataLabelStyle.Visible = true;
			series2.DataLabelStyle.VertAlign = VertAlign.Center;
			series2.DataLabelStyle.ArrowLength = new NLength(10);
			series2.DataLabelStyle.ArrowStrokeStyle.Color = Green;
			series2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Green;
			series2.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);

			// label layout settings
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked;
			chart.LabelLayout.RemoveOverlappedLabels = RemoveOverlappedLabelsCheckBox.Checked;
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked;

			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series1.LabelLayout.InvertLocationsIfIgnored = true;
			series2.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series2.LabelLayout.InvertLocationsIfIgnored = true;

			// enable / disable data point safeguard size for both series
			series1.LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheckBox.Checked;
			series2.LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheckBox.Checked;

			// set data point safeguard size for both series
			float sizeValue = (float)SafeguardSizeDropDownList.SelectedIndex;
			NSizeL size = new NSizeL(new NLength(sizeValue, NGraphicsUnit.Point), new NLength(sizeValue, NGraphicsUnit.Point));
			series1.LabelLayout.DataPointSafeguardSize = size;
			series2.LabelLayout.DataPointSafeguardSize = size;

			// fill with random data 
			GenerateData(chart);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

		}

		void GenerateData(NChart chart)
		{
			int randSeed = int.Parse(HiddenField1.Value);
			Random rand = new Random(randSeed);

			NPointSeries series0 = (NPointSeries)chart.Series[0];
			NPointSeries series1 = (NPointSeries)chart.Series[1];

			const int count = 12;

			series0.Values.FillRandomRange(rand, count, 0, 50);
			series0.XValues.FillRandomRange(rand, count, 0, 50);

			series1.Values.FillRandomRange(rand, count, 25, 75);
			series1.XValues.FillRandomRange(rand, count, 25, 75);
		}

	}
}
