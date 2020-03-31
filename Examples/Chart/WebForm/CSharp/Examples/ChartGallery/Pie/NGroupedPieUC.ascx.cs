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
	public partial class NGroupedPieUC : NExampleUC
	{
		static readonly string[] arrLabels = new string[]
		{
			"Cars",
			"Trains",
			"Airplanes",
			"Buses",
			"Bikes",
			"Motorcycles",
			"Shuttles",
			"Rollers",
			"Ski",
			"Surf"
		};
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithColorNames(GroupedPieColorDropDownList);
				GroupedPieColorDropDownList.SelectedIndex = 20;

				// init form controls
				ThresholdValueTextBox.Text = "34";
				GroupedPieLabelTextBox.Text = "Other";
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Grouped Pie Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup legend
			NLegend legend = nChartControl1.Legends[0];
			legend.OuterBottomBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterLeftBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterRightBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.OuterTopBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.FillStyle.SetTransparencyPercent(70);
			legend.HorizontalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.VerticalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);

			// by default the control contains a Cartesian chart -> remove it and create a Pie chart
			NChart chart = new NPieChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			chart.Enable3D = true;
			chart.DisplayOnLegend = nChartControl1.Legends[0];
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(
				new NLength(20, NRelativeUnit.ParentPercentage),
				new NLength(20, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(60, NRelativeUnit.ParentPercentage),
                new NLength(60, NRelativeUnit.ParentPercentage));

			// setup pie series
			NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
			pie.Legend.Mode = SeriesLegendMode.None;
            pie.PieStyle = PieStyle.SmoothEdgePie;

			int count = 10;
			pie.Values.FillRandomRange(Random, count, 1, 100);

			for (int i = 0; i < count; i++)
			{
				pie.Detachments.Add(0);
				pie.Labels.Add(arrLabels[i]);
				pie.FillStyles[i] = arrCustomColors2[i % arrCustomColors2.Length];
			}

			if (GroupPiesCheckBox.Checked == true)
			{
				try
				{
					Color groupColor = WebExamplesUtilities.ColorFromDropDownList(GroupedPieColorDropDownList);
					double dGroupValue = Int32.Parse(ThresholdValueTextBox.Text);

					// get a subset containing the pies which are smaller than the specified value
					NDataSeriesSubset smallerThanValue = pie.Values.Filter(Nevron.Chart.CompareMethod.Less, dGroupValue);

					// determine the sum of the filtered pies
					double dOtherSliceValue = pie.Values.Evaluate("SUM", smallerThanValue);

					// remove the data points contained in the 
					for(int i = pie.GetDataPointCount(); i >= 0; i--)
					{
						if(smallerThanValue.Contains(i))
							pie.RemoveDataPointAt(i);
					}

					// add a detached pie with the specified group label and color
					NDataPoint dp = new NDataPoint(dOtherSliceValue, GroupedPieLabelTextBox.Text);
					dp[DataPointValue.PieDetachment] = 1.0;
					dp[DataPointValue.FillStyle] = new NColorFillStyle(groupColor);
					dp[DataPointValue.StrokeStyle] = new NStrokeStyle(1, groupColor);
					pie.AddDataPoint(dp);
				}
				catch
				{
				}
			}
			else
			{
			}
		}
	}
}
