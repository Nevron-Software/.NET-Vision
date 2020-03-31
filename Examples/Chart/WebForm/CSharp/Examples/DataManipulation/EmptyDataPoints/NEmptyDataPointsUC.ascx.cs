using System;
using System.Collections;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NEmptyDataPointsUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// init form controls
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, typeof(PointShape));
				MarkerShapeDropDownList.SelectedIndex = 0;

				ChartTypeDropDownList.Items.Add("Bar");
				ChartTypeDropDownList.Items.Add("Line");
				ChartTypeDropDownList.Items.Add("Area");
				ChartTypeDropDownList.Items.Add("SmoothLine");
				ChartTypeDropDownList.Items.Add("Point");

				EmptyDataPointsValueModeDropDownList.Items.Add("Skip");
				EmptyDataPointsValueModeDropDownList.Items.Add("Average");
				EmptyDataPointsValueModeDropDownList.Items.Add("CustomValue");
				EmptyDataPointsValueModeDropDownList.SelectedIndex = 0;

				EmptyDataPointsAppearanceDropDownList.Items.Add("None");
				EmptyDataPointsAppearanceDropDownList.Items.Add("Normal");
				EmptyDataPointsAppearanceDropDownList.Items.Add("Special");
				EmptyDataPointsAppearanceDropDownList.SelectedIndex = 0;

				EmptyDataPointsMarkerModeDropDown.Items.Add("Normal Marker");
				EmptyDataPointsMarkerModeDropDown.Items.Add("Special Marker");

				WebExamplesUtilities.FillComboWithColorNames(EmptyDataPointsColorDropDownList, KnownColor.OrangeRed);
				WebExamplesUtilities.FillComboWithColorNames(MarkerColorDropDownList, KnownColor.OrangeRed);

				ShowMarkersCheckBox.Checked = false;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// add header
			NLabel header = nChartControl1.Labels.AddHeader("Empty Data Points");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 80.0f;
			chart.Height = 70.0f;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(10, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(75, NRelativeUnit.ParentPercentage));

			// configure the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.FillStyle = new NColorFillStyle(Color.FromArgb(125, 255, 255, 255));

			// turn off legend grid lines
			legend.OuterBottomBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterLeftBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterRightBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterTopBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.VerticalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.ContentAlignment = ContentAlignment.TopCenter;
			legend.Location = new NPointL(
				new NLength(88, NRelativeUnit.ParentPercentage),
				new NLength(70, NRelativeUnit.ParentPercentage));

			UpdateSeriesType();

			NSeries series = (NSeries)chart.Series[0];
			series.MarkerStyle.Visible = ShowMarkersCheckBox.Checked;

			// update EDP value mode
			series.Values.EmptyDataPoints.ValueMode = (EmptyDataPointsValueMode)EmptyDataPointsValueModeDropDownList.SelectedIndex;
			series.Values.EmptyDataPoints.CustomValue = 0;

			// update EDP appearance mode
			series.EmptyDataPointsAppearance.AppearanceMode = (EmptyDataPointsAppearanceMode)EmptyDataPointsAppearanceDropDownList.SelectedIndex;

			// update EDP marker mode
			series.EmptyDataPointsAppearance.MarkerMode = (EmptyDataPointsMarkerMode)EmptyDataPointsMarkerModeDropDown.SelectedIndex;

			series.EmptyDataPointsAppearance.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(EmptyDataPointsColorDropDownList));
			series.EmptyDataPointsAppearance.MarkerStyle.Visible = true;
			series.EmptyDataPointsAppearance.MarkerStyle.PointShape = (PointShape)MarkerShapeDropDownList.SelectedIndex;
			series.EmptyDataPointsAppearance.MarkerStyle.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(MarkerColorDropDownList));
			series.EmptyDataPointsAppearance.MarkerStyle.Width = new NLength(2f, NRelativeUnit.ParentPercentage);
			series.EmptyDataPointsAppearance.MarkerStyle.Depth = new NLength(2f, NRelativeUnit.ParentPercentage);
			series.EmptyDataPointsAppearance.MarkerStyle.Height = new NLength(2f, NRelativeUnit.ParentPercentage);
			series.EmptyDataPointsAppearance.MarkerStyle.AutoDepth = true;
		}

		private void UpdateSeriesType()
		{
			SeriesType seriesType = SeriesType.Bar;

			switch(ChartTypeDropDownList.SelectedIndex)
			{
				case 0:
					seriesType = SeriesType.Bar;
					break;
				case 1:
					seriesType = SeriesType.Line;
					break;
				case 2:
					seriesType = SeriesType.Area;
					break;
				case 3:
					seriesType = SeriesType.SmoothLine;
					break;
				case 4:
					seriesType = SeriesType.Point;
					break;
			}

			NChart chart = nChartControl1.Charts[0];

			chart.Series.Clear();

			NSeries series = (NSeries)chart.Series.Add(seriesType);
			series.Values.ValueFormatter = new NNumericValueFormatter("0.0");
			series.Legend.Mode = SeriesLegendMode.DataPoints;

			GenerateData(series, 10, 3);
		}

		private void GenerateData(NSeries series, int nTotalCount, int nMaxEmptyCount)
		{
			SortedList arrEmptyIndices = new SortedList();

			for(int i = 0; i < nMaxEmptyCount; i++)
			{
				int nEmptyIndex = Random.Next(0, nTotalCount);
				arrEmptyIndices[nEmptyIndex] = null;
			}

			for(int k = 0; k < nTotalCount; k++)
			{
				if(arrEmptyIndices.ContainsKey(k))
				{
					series.Values.Add(DBNull.Value);
				}
				else
				{
					series.Values.Add(Random.NextDouble() * 10);
				}
			}
		}
	}
}
