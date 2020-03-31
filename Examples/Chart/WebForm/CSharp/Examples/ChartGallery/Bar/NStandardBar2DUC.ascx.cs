using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStandardBar2DUC : NExampleUC
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

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

            // add interlace stripe
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			NBarSeries barSeries = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			barSeries.Name = "Bar Series";
			barSeries.DataLabelStyle.Format = "<value>";
			barSeries.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			barSeries.ShadowStyle.Type = ShadowType.GaussianBlur;
			barSeries.ShadowStyle.Offset = new NPointL(new NLength(3, NGraphicsUnit.Pixel), new NLength(3, NGraphicsUnit.Pixel));
			barSeries.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			barSeries.ShadowStyle.FadeLength = new NLength(5, NGraphicsUnit.Pixel);

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
