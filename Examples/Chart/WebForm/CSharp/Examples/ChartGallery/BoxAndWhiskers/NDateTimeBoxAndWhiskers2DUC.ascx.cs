using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.Collections;
using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDateTimeBoxAndWhiskers2DUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithValues(BoxWidthDropDownList, 0, 100, 10);
				BoxWidthDropDownList.SelectedIndex = 7;

				WebExamplesUtilities.FillComboWithValues(WhiskersWidthDropDownList, 0, 100, 10);
				WhiskersWidthDropDownList.SelectedIndex = 5;

				LeftAxisRoundToTickCheckBox.Checked = true;
				InflateMarginsCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Date Time Box and Whiskers");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

            // add interlaced stripe
            NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.RoundToTickMin = LeftAxisRoundToTickCheckBox.Checked;
			scaleY.RoundToTickMax = LeftAxisRoundToTickCheckBox.Checked;

			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleY.StripStyles.Add(stripStyle);

			NDateTimeScaleConfigurator timeScale = new NDateTimeScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeScale;
			timeScale.LabelGenerationMode = LabelGenerationMode.SingleLevel;
			timeScale.EnableUnitSensitiveFormatting = false;
			timeScale.LabelValueFormatter = new NDateTimeValueFormatter("dd MMM");
			timeScale.LabelFitModes = new LabelFitMode[] { LabelFitMode.Rotate90 };
			
			// setup series
			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)chart.Series.Add(SeriesType.BoxAndWhiskers);
			series.DataLabelStyle.Visible = false;
			series.UseXValues = true;
			series.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant4, Red, DarkOrange);
			series.OutliersSize = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			series.OutliersBorderStyle = new NStrokeStyle(GreyBlue);
			series.OutliersFillStyle = new NColorFillStyle(Red);
			series.MedianStrokeStyle = new NStrokeStyle(Color.Indigo);
			series.AverageStrokeStyle = new NStrokeStyle(1, Color.DarkRed, LinePattern.Dot);
			series.BoxWidth = new NLength(BoxWidthDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
			series.WhiskersWidthPercent = WhiskersWidthDropDownList.SelectedIndex * 10;
			series.InflateMargins = InflateMarginsCheckBox.Checked;

			GenerateData(series, 5);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void GenerateData(NBoxAndWhiskersSeries series, int nCount)
		{
			series.ClearDataPoints();

			DateTime dt = new DateTime(2005, 5, 24, 11, 0, 0);
			Random random = new Random();

			for(int i = 0; i < nCount; i++)
			{
				double boxLower = 1000 + Random.NextDouble() * 200;
				double boxUpper = boxLower + 200 + Random.NextDouble() * 200;
				double whiskersLower = boxLower - (20 + Random.NextDouble() * 300);
				double whiskersUpper = boxUpper + (20 + Random.NextDouble() * 300);

				double IQR = (boxUpper - boxLower);
				double median = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5;
				double average = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5;

				series.UpperBoxValues.Add(boxUpper);
				series.LowerBoxValues.Add(boxLower);
				series.UpperWhiskerValues.Add(whiskersUpper);
				series.LowerWhiskerValues.Add(whiskersLower);
				series.MedianValues.Add(median);
				series.AverageValues.Add(average);

				// generate date time value
				dt = dt.AddHours(12 + Random.NextDouble() * 60);
				series.XValues.Add( dt.ToOADate() );

				// generate outlier values
				int outliersCount = Random.Next(5);

				NDoubleList outliers = new NDoubleList();

				for(int k = 0; k < outliersCount; k++)
				{
					double dOutlier = 0;

					if (Random.NextDouble() > 0.5)
					{
						dOutlier = boxUpper + IQR * 1.5 + Random.NextDouble() * 100;
					}
					else
					{
						dOutlier = boxLower - IQR * 1.5 - Random.NextDouble() * 100;
					}

					outliers.Add(dOutlier);
				}

				series.OutlierValues.Add(outliers);
			}
		}
	}
}
