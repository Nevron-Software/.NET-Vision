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
	public partial class NSortedPieUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				SortDropDownList.Items.Add("Ascending");
				SortDropDownList.Items.Add("Descending");
				SortDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Sorted Pie Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup legend
			NLegend legend = nChartControl1.Legends[0];
			legend.Visible = false;
			legend.HorizontalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.VerticalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.Location = new NPointL(
				new NLength(100, NRelativeUnit.ParentPercentage),
				new NLength(0, NRelativeUnit.ParentPercentage));

			// by default the control contains a Cartesian chart -> remove it and create a Pie chart
			NChart chart = new NPieChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			chart.Enable3D = false;
			chart.DisplayOnLegend = nChartControl1.Legends[0];
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(
				new NLength(15, NRelativeUnit.ParentPercentage),
				new NLength(16, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(70, NRelativeUnit.ParentPercentage));


			NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
            pie.PieStyle = PieStyle.SmoothEdgePie;
			pie.Legend.Mode = SeriesLegendMode.DataPoints;
			pie.Legend.Format = "<label> <percent>";

			pie.AddDataPoint(new NDataPoint(0, "Cars"));
			pie.AddDataPoint(new NDataPoint(0, "Trains"));
			pie.AddDataPoint(new NDataPoint(0, "Buses"));
			pie.AddDataPoint(new NDataPoint(0, "Airplanes"));
			pie.AddDataPoint(new NDataPoint(0, "Ships"));
			pie.Values.FillRandomRange(Random, 5, 1, 40);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			DataSeriesMask included = DataSeriesMask.RandomAccess;
			DataSeriesMask excluded = DataSeriesMask.PieDetachments;
			NDataSeriesCollection arr = pie.GetDataSeries(included, excluded, false);

			int masterDataSeries = arr.FindByMask(DataSeriesMask.Values);

			if (SortDropDownList.SelectedIndex == 0)
			{
				arr.Sort(masterDataSeries, DataSeriesSortOrder.Ascending);
			}
			else
			{
				arr.Sort(masterDataSeries, DataSeriesSortOrder.Descending);
			}
		}
	}
}