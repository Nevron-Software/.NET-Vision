using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NSampledLine3DUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// Init Form controls
				WebExamplesUtilities.FillComboWithValues(SampleDistanceDropDownList, 1, 10, 1);
				SampleDistanceDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(NumberOfTurnsDropDownList, 3, 20, 1);
				NumberOfTurnsDropDownList.SelectedIndex = 2;

				WebExamplesUtilities.FillComboWithValues(NumberOfPointsInTurnDropDownList, 10000, 30000, 10000);
				NumberOfPointsInTurnDropDownList.SelectedIndex = 1;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Sampled Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 50;
			chart.Height = 50;
			chart.Depth = 50;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup Y axis
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			// setup X axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Floor };
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;

			// setup Z axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Floor };
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator;

			// add the line
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.DataLabelStyle.Visible = false;
			line.BorderStyle.Color = DarkOrange;
			line.MarkerStyle.Visible = false;
			line.Name = "Line Series";
			line.Legend.Mode = SeriesLegendMode.None;

			// update sampling parameters
			line.SamplingMode = SeriesSamplingMode.Enabled;
			line.SampleDistance = new NLength((float)SampleDistanceDropDownList.SelectedIndex + 1, NGraphicsUnit.Pixel);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			GenerateXYZData(line);
			NumberOfDataPointsLabel.Text = "Number of Data Points:" + (line.Values.Count / 1000).ToString() + "K";

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void GenerateXYZData(NLineSeries line)
		{
			int numberOfTurns = NumberOfTurnsDropDownList.SelectedIndex + 3;
			int numberOfPointsInTurn = (NumberOfPointsInTurnDropDownList.SelectedIndex + 1) * 10000;
			for (int i = 0; i < numberOfTurns; i++)
			{
				AddTurn(line, numberOfPointsInTurn);
			}
		}

		private void AddTurn(NLineSeries line, int count)
		{
			Random rand = new Random();
			double prevYVal = 0;
			double prevXVal = 0;
			double prevZVal = 0;

			double angle = 0;
			double phase = (Math.PI * 2 * rand.NextDouble()) / count + 0.0001;
			double magnitude = rand.NextDouble() * 5;

			double[] xValues = new double[count];
			double[] yValues = new double[count];
			double[] zValues = new double[count];

			int valueCount = line.Values.Count;
			if (valueCount > 0)
			{
				prevYVal = (double)line.Values[valueCount - 1];
				prevXVal = (double)line.XValues[valueCount - 1];
				prevZVal = (double)line.ZValues[valueCount - 1];
			}

			for (int i = 0; i < count; i++)
			{
				double yStep = Math.Cos(angle) + Math.Sin(angle) * magnitude;
				double xStep = Math.Cos(angle) * magnitude;
				double zStep = Math.Sin(angle) * magnitude;

				if (xStep < 0)
				{
					xStep = 0;
				}

				angle += phase;

				yValues[i] = prevYVal + yStep;
				xValues[i] = prevXVal + xStep;
				zValues[i] = prevZVal + zStep;

				prevXVal = xValues[i];
				prevYVal = yValues[i];
				prevZVal = zValues[i];
			}

			line.Values.AddRange(yValues);
			line.XValues.AddRange(xValues);
			line.ZValues.AddRange(zValues);
		}
	}
}
