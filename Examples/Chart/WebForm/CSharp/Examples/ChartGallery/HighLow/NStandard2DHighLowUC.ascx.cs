using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Nevron.Dom;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStandard2DHighLowUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				DataLabelFormatDropDownList.Items.Add("high");
				DataLabelFormatDropDownList.Items.Add("low");
				DataLabelFormatDropDownList.Items.Add("high low");
				DataLabelFormatDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, typeof(PointShape));
				MarkerShapeDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithColorNames(HighAreaColorDropDownList, KnownColor.LightSlateGray);
				WebExamplesUtilities.FillComboWithColorNames(LowAreaColorDropDownList, KnownColor.DarkOrange);
				WebExamplesUtilities.FillComboWithValues(MarkerSizeDropDownList, 0, 5, 1);
				MarkerSizeDropDownList.SelectedIndex = 2;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("2D High-Low Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup X axis
			NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleX.DisplayDataPointsBetweenTicks = false;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorGridStyle.LineStyle.Color = Color.LightGray;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.StripStyles.Add(stripStyle);

			NHighLowSeries highLow = (NHighLowSeries)chart.Series.Add(SeriesType.HighLow);
			highLow.Name = "High-Low Series";
			highLow.InflateMargins = true;
			highLow.Legend.Mode = SeriesLegendMode.SeriesLogic;
			highLow.MarkerStyle.FillStyle = new NColorFillStyle(Red);
			highLow.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7);
			highLow.LowValues.ValueFormatter = new NNumericValueFormatter("0.#");
			highLow.HighValues.ValueFormatter = new NNumericValueFormatter("0.#");

			highLow.HighFillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(HighAreaColorDropDownList));
			highLow.LowFillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(LowAreaColorDropDownList));

			highLow.DropLines = ShowDropLinesCheckBox.Checked;
			highLow.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked;

			switch (DataLabelFormatDropDownList.SelectedIndex)
			{
				case 0:
					highLow.DataLabelStyle.Format = "<high_value>";
					break;
				case 1:
					highLow.DataLabelStyle.Format = "<low_value>";
					break;
				case 2:
					highLow.DataLabelStyle.Format = "<high_value> - <low_value>";
					break;
			}

			MarkerShapeDropDownList.Enabled = ShowMarkersCheckBox.Checked;
			MarkerSizeDropDownList.Enabled = ShowMarkersCheckBox.Checked;

			highLow.MarkerStyle.Visible = ShowMarkersCheckBox.Checked;
			highLow.MarkerStyle.PointShape = (PointShape)MarkerShapeDropDownList.SelectedIndex;
			highLow.MarkerStyle.Width = new NLength((float)MarkerSizeDropDownList.SelectedIndex, NRelativeUnit.ParentPercentage);
			highLow.MarkerStyle.Height = new NLength((float)MarkerSizeDropDownList.SelectedIndex,NRelativeUnit.ParentPercentage);

			GenerateData(highLow);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}

		private void GenerateData(NHighLowSeries highLow)
		{
			highLow.ClearDataPoints();

			for (int i = 0; i < 21; i++)
			{
				double d1 = Math.Log(i + 1) + 0.1 * Random.NextDouble();
				double d2 = d1 + Math.Cos(0.33 * i) + 0.1 * Random.NextDouble();

				highLow.HighValues.Add(d1);
				highLow.LowValues.Add(d2);
			}
		}
	}
}
