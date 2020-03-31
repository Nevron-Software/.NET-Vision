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
	public partial class NSampledArea2DUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// Init Form controls
				WebExamplesUtilities.FillComboWithValues(SampleDistanceDropDownList, 1, 10, 1);
				SampleDistanceDropDownList.SelectedIndex = 0;

				UseXValuesCheckBox.Checked = true;

				WebExamplesUtilities.FillComboWithValues(NumberOfTurnsDropDownList, 3, 20, 1);
				NumberOfTurnsDropDownList.SelectedIndex = 2;

				WebExamplesUtilities.FillComboWithValues(NumberOfPointsInTurnDropDownList, 10000, 30000, 10000);
				NumberOfPointsInTurnDropDownList.SelectedIndex = 1;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Sampled Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Floor };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleX.StripStyles.Add(stripStyle);

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// add the line
			NAreaSeries area = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area.Name = "Area Series";
			area.DataLabelStyle.Visible = false;
			area.MarkerStyle.Visible = false;
			area.Legend.Mode = SeriesLegendMode.None;
			// instruct the series to use X values
			area.UseXValues = UseXValuesCheckBox.Checked;

			// update sampling parameters
			area.SamplingMode = SeriesSamplingMode.Enabled;
			area.SampleDistance = new NLength((float)SampleDistanceDropDownList.SelectedIndex + 1, NGraphicsUnit.Pixel);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			GenerateXYData(area);

			NumberOfDataPointsLabel.Text = "Number of Data Points:" + (area.Values.Count / 1000).ToString() + "K";

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void GenerateXYData(NAreaSeries area)
		{
			int numberOfTurns = NumberOfTurnsDropDownList.SelectedIndex + 3;
			int numberOfPointsInTurn = (NumberOfPointsInTurnDropDownList.SelectedIndex + 1) * 10000;
			for (int i = 0; i < numberOfTurns; i++)
			{
				AddTurn(area, numberOfPointsInTurn);
			}
		}

		private void AddTurn(NAreaSeries area, int count)
		{
			Random rand = new Random();
			double prevYVal = 2;
			double prevXVal = 2;

			double angle = 0;
			double phase = (Math.PI * 2 * rand.NextDouble()) / count + 0.0001;
			double magnitude = rand.NextDouble() * 5;

			double[] xValues = new double[count];
			double[] yValues = new double[count];

			int valueCount = area.Values.Count;
			if (valueCount > 0)
			{
				prevYVal = (double)area.Values[valueCount - 1];
				prevXVal = (double)area.XValues[valueCount - 1];
			}

			for (int i = 0; i < count; i++)
			{
				double yStep = Math.Sin(angle) * magnitude;
				double xStep = rand.NextDouble() * magnitude;

				if (xStep < 0)
				{
					xStep = 0;
				}

				angle += phase;
				prevXVal += xStep;

				yValues[i] = prevYVal + yStep;
				xValues[i] = prevXVal;
			}

			area.Values.AddRange(yValues);
			area.XValues.AddRange(xValues);
		}
	}
}
