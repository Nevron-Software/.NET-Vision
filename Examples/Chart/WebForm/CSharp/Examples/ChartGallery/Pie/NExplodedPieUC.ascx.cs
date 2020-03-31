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
	public partial class NExplodedPieUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ExplodeModeDropDownList.Items.Add("No exploded pies");
				ExplodeModeDropDownList.Items.Add("Explode biggest");
				ExplodeModeDropDownList.Items.Add("Explode smallest");

				ExplodeModeDropDownList.SelectedIndex = 2;
			}

            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Exploded Pie Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup legend
			NLegend legend = nChartControl1.Legends[0];
			legend.FillStyle.SetTransparencyPercent(50);
			legend.Data.ExpandMode = LegendExpandMode.RowsFixed;
			legend.Data.RowCount = 2;
			legend.ContentAlignment = ContentAlignment.TopLeft;
			legend.Location = new NPointL(
				new NLength(99, NRelativeUnit.ParentPercentage),
				new NLength(99, NRelativeUnit.ParentPercentage));

			// by default the control contains a Cartesian chart -> remove it and create a Pie chart
            NChart chart = new NPieChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			// configure the chart
			chart.Enable3D = true;
			chart.DisplayOnLegend = nChartControl1.Legends[0];
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(
				new NLength(12, NRelativeUnit.ParentPercentage),
				new NLength(12, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(76, NRelativeUnit.ParentPercentage),
				new NLength(68, NRelativeUnit.ParentPercentage));

			// add a pie serires
            NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
            pie.PieStyle = PieStyle.SmoothEdgePie;
            pie.PieEdgePercent = 50;
			pie.DataLabelStyle.Visible = false;
			pie.Legend.Mode = SeriesLegendMode.DataPoints;
			pie.Legend.Format = "<label> <percent>";
			pie.Legend.TextStyle.FontStyle = new NFontStyle("Arial", 8);

			pie.AddDataPoint(new NDataPoint(0, "Ships"));
			pie.AddDataPoint(new NDataPoint(0, "Trains"));
			pie.AddDataPoint(new NDataPoint(0, "Cars"));
			pie.AddDataPoint(new NDataPoint(0, "Buses"));
			pie.AddDataPoint(new NDataPoint(0, "Airplanes"));

			pie.Values.FillRandomRange(Random, pie.Values.Count, 1, 20);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			switch (ExplodeModeDropDownList.SelectedIndex)
			{
				case 0:
					break;

				case 1:
					SetDetachments(pie.Values.FindMaxValue(), pie);
					break;

				case 2:
					SetDetachments(pie.Values.FindMinValue(), pie);
					break;
			}
		}

		private void SetDetachments(int nExplodedIndex, NPieSeries pieSeries)
		{
			int nCount = pieSeries.Values.Count;

			for(int i = 0; i < nCount; i++)
			{
				if(i == nExplodedIndex)
				{
					pieSeries.Detachments.Add(5.0f);
				}
				else
				{
					pieSeries.Detachments.Add(0.0f);
				}
			}
		}
	}
}
