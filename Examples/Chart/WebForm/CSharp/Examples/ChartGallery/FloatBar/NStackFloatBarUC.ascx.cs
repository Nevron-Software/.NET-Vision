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
	public partial class NStackFloatBarUC : NExampleUC
	{
		/// <summary>
		/// Constrols the number of data points
		/// </summary>
		private const int DataPointCount = 8;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stack Float Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup X axis
			NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;

			// add interlaced stripe to the Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			scaleY.StripStyles.Add(stripStyle);

			// setup the floatbar series
			NFloatBarSeries floatbar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatbar.MultiFloatBarMode = MultiFloatBarMode.Series;
			floatbar.Name = "Floatbar";
			floatbar.FillStyle = new NColorFillStyle(Color.SandyBrown);
			floatbar.DataLabelStyle.Visible = false;

			// setup the bar series
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.Name = "Bar 1";
			bar1.MultiBarMode = MultiBarMode.Stacked;
			bar1.FillStyle = new NColorFillStyle(Color.Green);
			bar1.DataLabelStyle.Visible = false;

			// setup the bar series
			NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar2.Name = "Bar 2";
			bar2.MultiBarMode = MultiBarMode.Stacked;
			bar2.FillStyle = new NColorFillStyle(Color.CornflowerBlue);
			bar2.DataLabelStyle.Visible = false;

			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(BarShapeDropDownList, typeof(BarShape));
				BarShapeDropDownList.SelectedIndex = 0;

				DataTypeDropDownList.Items.Add("Positive Data");
				DataTypeDropDownList.Items.Add("Positive and Negative Data");
				DataTypeDropDownList.SelectedIndex = 0;
			}

			BarShape selectedShape = (BarShape)BarShapeDropDownList.SelectedIndex;

			floatbar.BarShape = selectedShape;
			bar1.BarShape = selectedShape;
			bar2.BarShape = selectedShape;

			if (DataTypeDropDownList.SelectedIndex == 0)
			{
				GeneratePosData();
			}
			else
			{
				GeneratePosNegData();
			}

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}

		private double GetRandValue(double min, double max)
		{
			if(max < min)
			{
				double temp = min;
				min = max;
				max = temp;
			}

			return min + Random.NextDouble() * (max - min);
		}

		private double SetRandSign(double val)
		{
			if(Random.NextDouble() > 0.5)
				return val;

			return  -val;
		}


		private void GeneratePosData()
		{
			NFloatBarSeries floatbar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			NBarSeries bar1 = (NBarSeries)nChartControl1.Charts[0].Series[1];
			NBarSeries bar2 = (NBarSeries)nChartControl1.Charts[0].Series[2];

			floatbar.BeginValues.Clear();
			floatbar.EndValues.Clear();
			bar1.Values.Clear();
			bar2.Values.Clear();

			for(int i = 0; i < DataPointCount; i++)
			{
				floatbar.BeginValues.Add(GetRandValue(1, 4));
				floatbar.EndValues.Add(GetRandValue(6, 9));
				bar1.Values.Add(GetRandValue(3, 7));
				bar2.Values.Add(GetRandValue(3, 7));
			}
		}

		private void GeneratePosNegData()
		{
			NFloatBarSeries floatbar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			NBarSeries bar1 = (NBarSeries)nChartControl1.Charts[0].Series[1];
			NBarSeries bar2 = (NBarSeries)nChartControl1.Charts[0].Series[2];

			floatbar.BeginValues.Clear();
			floatbar.EndValues.Clear();
			bar1.Values.Clear();
			bar2.Values.Clear();

			for(int i = 0; i < DataPointCount; i++)
			{
				floatbar.BeginValues.Add(GetRandValue(-10, 10));
				floatbar.EndValues.Add(SetRandSign(GetRandValue(10, 20)));
				bar1.Values.Add(SetRandSign(GetRandValue(5, 10)));
				bar2.Values.Add(SetRandSign(GetRandValue(5, 10)));
			}
		}
	}
}
