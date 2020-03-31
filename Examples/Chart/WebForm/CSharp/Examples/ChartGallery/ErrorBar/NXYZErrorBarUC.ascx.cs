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
	public partial class NXYZErrorBarUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Error Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Depth = 55.0f;
			chart.Width = 55.0f;
			chart.Height = 55.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup Y axis
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleConfigurator.RoundToTickMin = RoundToTickCheck.Checked;
			linearScaleConfigurator.RoundToTickMax = RoundToTickCheck.Checked;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScaleConfigurator.StripStyles.Add(stripStyle);

			// setup X axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.RoundToTickMin = RoundToTickCheck.Checked;
			linearScaleConfigurator.RoundToTickMax = RoundToTickCheck.Checked;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Floor };
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator;

			// setup Z axis
			linearScaleConfigurator = new NLinearScaleConfigurator();
			linearScaleConfigurator.RoundToTickMin = RoundToTickCheck.Checked;
			linearScaleConfigurator.RoundToTickMax = RoundToTickCheck.Checked;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Floor };
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator;

			// add an error bar series
			NErrorBarSeries series = (NErrorBarSeries)chart.Series.Add(SeriesType.ErrorBar);
			series.DataLabelStyle.Visible = false;
			series.BorderStyle = new NStrokeStyle(GreyBlue);
			series.MarkerStyle.Visible = true;
			series.MarkerStyle.AutoDepth = false;
			series.MarkerStyle.FillStyle = new NColorFillStyle(DarkOrange);
			series.MarkerStyle.BorderStyle = new NStrokeStyle(GreyBlue);
			series.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			series.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			series.MarkerStyle.Depth = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			series.UseXValues = true;
			series.UseZValues = true;

			GenerateData(series);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			if (!IsPostBack)
			{
				ShowUpperXErrorCheck.Checked = series.ShowUpperErrorX;
				ShowLowerXErrorCheck.Checked = series.ShowLowerErrorX;
				ShowUpperYErrorCheck.Checked = series.ShowUpperErrorY;
				ShowLowerYErrorCheck.Checked = series.ShowLowerErrorY;
				ShowUpperZErrorCheck.Checked = series.ShowUpperErrorZ;
				ShowLowerZErrorCheck.Checked = series.ShowLowerErrorZ;
				InflateMarginsCheck.Checked = series.InflateMargins;
			}
			else
			{
				series.ShowUpperErrorX = ShowUpperXErrorCheck.Checked;
				series.ShowLowerErrorX = ShowLowerXErrorCheck.Checked;
				series.ShowUpperErrorY = ShowUpperYErrorCheck.Checked;
				series.ShowLowerErrorY = ShowLowerYErrorCheck.Checked;
				series.ShowUpperErrorZ = ShowUpperZErrorCheck.Checked;
				series.ShowLowerErrorZ = ShowLowerZErrorCheck.Checked;
				series.InflateMargins = InflateMarginsCheck.Checked;
			}
		}

		private void GenerateData(NErrorBarSeries series)
		{
			series.ClearDataPoints();

			NVector3DF v = new NVector3DF();
			Random randrom = new Random();

			for(int i = 0; i < 10; i++)
			{
				v.X = (float)(0.5 - randrom.NextDouble());
				v.Y = (float)(0.5 - randrom.NextDouble());
				v.Z = (float)(0.5 - randrom.NextDouble());

				v.Normalize(40.0f);

				series.Values.Add(v.X);
				series.XValues.Add(v.Y);
				series.ZValues.Add(v.Z);

				series.LowerErrorsX.Add(3 + 5 * randrom.NextDouble());
				series.UpperErrorsX.Add(3 + 5 * randrom.NextDouble());
				series.LowerErrorsY.Add(3 + 5 * randrom.NextDouble());
				series.UpperErrorsY.Add(3 + 5 * randrom.NextDouble());
				series.LowerErrorsZ.Add(3 + 5 * randrom.NextDouble());
				series.UpperErrorsZ.Add(3 + 5 * randrom.NextDouble());
			}
		}
	}
}
