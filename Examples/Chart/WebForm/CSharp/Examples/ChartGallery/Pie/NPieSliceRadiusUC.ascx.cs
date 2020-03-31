using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;
using System.Web.UI.WebControls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStandardPieUC : NExampleUC
	{
		protected Label Label5;

		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
            nChartControl1.Settings.JitterMode = JitterMode.Enabled;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Pie Slice Radius");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup legend
			NLegend legend = nChartControl1.Legends[0];
			legend.FillStyle = new NColorFillStyle(Color.FromArgb(124, 255, 255, 255));
			legend.HorizontalBorderStyle.Width = new NLength(0);
			legend.VerticalBorderStyle.Width = new NLength(0);
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom);
			legend.Data.ExpandMode = LegendExpandMode.RowsFixed;
			legend.Data.RowCount = 2;
			legend.Data.CellMargins = new NMarginsL(
				new NLength(6, NGraphicsUnit.Pixel),
				new NLength(3, NGraphicsUnit.Pixel),
				new NLength(6, NGraphicsUnit.Pixel),
				new NLength(3, NGraphicsUnit.Pixel));
			legend.Data.MarkSize = new NSizeL(
				new NLength(7, NGraphicsUnit.Pixel),
				new NLength(7, NGraphicsUnit.Pixel));

			// by default the control contains a Cartesian chart -> remove it and create a Pie chart
			NPieChart pieChart = new NPieChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(pieChart);

			pieChart.Enable3D = true;
			pieChart.InnerRadius = new NLength(0);
			pieChart.DisplayOnLegend = nChartControl1.Legends[0];
			pieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
			pieChart.BoundsMode = BoundsMode.Fit;
			pieChart.Location = new NPointL(
				new NLength(12, NRelativeUnit.ParentPercentage),
				new NLength(12, NRelativeUnit.ParentPercentage));
			pieChart.Size = new NSizeL(
				new NLength(76, NRelativeUnit.ParentPercentage),
				new NLength(68, NRelativeUnit.ParentPercentage));

			NPieSeries pieSeries = new NPieSeries();
			pieChart.Series.Add(pieSeries);
			pieSeries.PieEdgePercent = 30;
			pieSeries.PieStyle = PieStyle.SmoothEdgePie;
			pieSeries.Legend.Mode = SeriesLegendMode.DataPoints;
			pieSeries.Legend.Format = "<label> <percent>";
			pieSeries.UseBeginEndWidthPercents = true;

			for (int i = 0; i < 9; i++)
			{
				pieSeries.Values.Add(10 + i * 10);
				pieSeries.BeginWidthPercents.Add(0);
				pieSeries.EndWidthPercents.Add(10 + i * 10);
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);
		}
	}
}
