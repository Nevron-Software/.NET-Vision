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
	public partial class NXYZScatterPointClusterUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// init form controls
				WebExamplesUtilities.FillComboWithEnumValues(ClusterModeDropDownList, typeof(ClusterMode));
				ClusterModeDropDownList.SelectedIndex = (int)ClusterMode.Enabled;

				for (int i = 0; i < 9; i++)
				{
					ClusterDistanceFactorDropDownList.Items.Add("0.0" + (i + 1).ToString());
				}

				WebExamplesUtilities.FillComboWithValues(NumberOfPointGroupsDropDownList, 1, 10, 1);
				NumberOfPointGroupsDropDownList.SelectedIndex = 2;

				WebExamplesUtilities.FillComboWithValues(NumberOfPointsInGroupDropDownList, 5000, 15000, 5000);
				NumberOfPointsInGroupDropDownList.SelectedIndex = 0;
			}

			// switch to OpenGL rendering
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Scatter Point Cluster Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 50;
			chart.Depth = 50;
			chart.Height = 50;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

			// setup Y axis
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			// setup X axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Floor };

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;

			// setup Z axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Floor };
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator;

			// setup point series
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.Name = "Point1";
			point.DataLabelStyle.Visible = false;
			point.MarkerStyle.Visible = false;
			point.Legend.Mode = SeriesLegendMode.None;
			point.PointShape = PointShape.Bar;
			point.BorderStyle.Width = new NLength(0);
			point.Size = new NLength(1);
			point.UseXValues = true;
			point.UseZValues = true;

			// update cluster settings
			point.ClusterMode = (ClusterMode)ClusterModeDropDownList.SelectedIndex;
			point.ClusterDistanceFactor = (ClusterDistanceFactorDropDownList.SelectedIndex + 1) * 0.01;

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init the chart with some random values
			GenerateXYZData(point);

			NumberOfDataPointsLabel.Text = "Number of Data Points:" + (point.Values.Count / 1000).ToString() + "K";

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}


		private void GenerateXYZData(NPointSeries point)
		{
			point.ClearDataPoints();

			int numberOfGroups = NumberOfPointGroupsDropDownList.SelectedIndex + 1;
			int numberOfPointsInGroup = (NumberOfPointsInGroupDropDownList.SelectedIndex + 1) * 5000;

			for (int i = 0; i < numberOfGroups; i++)
			{
				AddPointGroup(point, numberOfPointsInGroup);
			}

		}

		private void AddPointGroup(NPointSeries point, int count)
		{
			Random rand = new Random();

			double[] xValues = new double[count];
			double[] yValues = new double[count];
			double[] zValues = new double[count];

			double centerX = rand.Next(20);
			double centerY = rand.Next(20);
			double centerZ = rand.Next(20);

			for (int i = 0; i < count; i++)
			{
				double u1 = rand.NextDouble();
				double u2 = rand.NextDouble();
				double u3 = rand.NextDouble();

				if (u1 == 0)
					u1 += 0.0001;

				if (u2 == 0)
					u2 += 0.0001;

				if (u3 == 0)
					u3 += 0.0001;

				double z0 = centerX + Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
				double z1 = centerY + Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);
				double z2 = centerZ + Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u3);

				xValues[i] = z0;
				yValues[i] = z1;
				zValues[i] = z2;
			}

			point.XValues.AddRange(xValues);
			point.Values.AddRange(yValues);
			point.ZValues.AddRange(zValues);
		}
	}
}
