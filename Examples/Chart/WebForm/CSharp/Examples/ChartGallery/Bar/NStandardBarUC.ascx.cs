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
	public partial class NStandardBarUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(ShapeCombo, typeof(BarShape));
				ShapeCombo.SelectedIndex = 0;

				ShowDataLabelsCheck.Checked = false;
				UseOriginCheck.Checked = true;
				DifferentColorsCheckBox.Checked = true;
				OriginTextBox.Text = "0";
			}

            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("3D Bar Chart");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

            // configure chart
            NChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.Enable3D = true;
            chart.Axis(StandardAxis.Depth).Visible = false;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlace stripe
            NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

            // add bar and change bar color
			NBarSeries barSeries = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            barSeries.Name = "Bar Series";
			barSeries.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			barSeries.DataLabelStyle.Format = "<value>";

			// add some data to the bar series
			barSeries.AddDataPoint(new NDataPoint(18, "Silverlight"));
			barSeries.AddDataPoint(new NDataPoint(15, "Ajax"));
			barSeries.AddDataPoint(new NDataPoint(21, "JackBe"));
			barSeries.AddDataPoint(new NDataPoint(23, "Laszlo"));
			barSeries.AddDataPoint(new NDataPoint(28, "Java FX"));
			barSeries.AddDataPoint(new NDataPoint(29, "Flex"));

			UpdateFillStyles(barSeries);

			if (ShowDataLabelsCheck.Checked)
			{
				barSeries.DataLabelStyle.Visible = true;
			}
			else
			{
				barSeries.DataLabelStyle.Visible = false;
				barSeries.DataLabelStyles.Clear();
			}

			barSeries.BarShape = (BarShape)ShapeCombo.SelectedIndex;

			if (UseOriginCheck.Checked == true)
			{
				OriginTextBox.Enabled = true;
				barSeries.OriginMode = SeriesOriginMode.CustomOrigin;

				try
				{
					barSeries.Origin = Int32.Parse(OriginTextBox.Text);
				}
				catch
				{
				}
			}
			else
			{
				OriginTextBox.Enabled = false;
				barSeries.OriginMode = SeriesOriginMode.MinValue;
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}

		private void UpdateFillStyles(NBarSeries barSeries)
		{
			if (DifferentColorsCheckBox.Checked)
			{
				barSeries.Legend.Mode = SeriesLegendMode.DataPoints;

                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
                styleSheet.Apply(nChartControl1.Document);
			}
			else
			{
				barSeries.Legend.Mode = SeriesLegendMode.Series;

                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
                styleSheet.Apply(nChartControl1.Document);
			}
		}
	}
}
