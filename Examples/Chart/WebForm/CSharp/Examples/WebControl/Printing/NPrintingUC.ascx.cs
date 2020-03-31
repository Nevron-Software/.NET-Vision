using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;

using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NPrintingUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.StateManager = new NChartBatonSessionStateManager(Context, "Nevron.Examples.Chart.WebForm.NPrintingUC");
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			if (nChartControl1.RequiresInitialization)
			{
				// enable jittering (full scene antialiasing)
				nChartControl1.Settings.JitterMode = JitterMode.Enabled;

				// set a chart title
				NLabel title = nChartControl1.Labels.AddHeader("Welcome to Nevron Chart for .NET");
				title.TextStyle.BackplaneStyle.Visible = false;
				title.TextStyle.FillStyle = new NColorFillStyle(Color.Navy);
				title.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur;
				title.ContentAlignment = ContentAlignment.BottomRight;
				title.Location = new NPointL(
					new NLength(2, NRelativeUnit.ParentPercentage),
					new NLength(2, NRelativeUnit.ParentPercentage));

				// setup the legend
				NLegend legend = nChartControl1.Legends[0];
				legend.FillStyle.SetTransparencyPercent(50);
				legend.OuterBottomBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
				legend.OuterLeftBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
				legend.OuterRightBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
				legend.OuterTopBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
				legend.HorizontalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
				legend.VerticalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);

				// setup the chart
				NChart chart = nChartControl1.Charts[0];
				chart.Enable3D = true;
				chart.Axis(StandardAxis.Depth).Visible = false;
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
				chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);
				chart.BoundsMode = BoundsMode.Stretch;
				chart.Location = new NPointL(
					new NLength(10, NRelativeUnit.ParentPercentage),
					new NLength(17, NRelativeUnit.ParentPercentage));
				chart.Size = new NSizeL(
					new NLength(60, NRelativeUnit.ParentPercentage),
					new NLength(73, NRelativeUnit.ParentPercentage));

				// add a bar series
				NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
				bar.Name = "Simple Bar Chart";
				bar.BarShape = BarShape.SmoothEdgeBar;
				bar.Legend.Mode = SeriesLegendMode.DataPoints;
				bar.DataLabelStyle.Format = "<value> <label>";

				bar.AddDataPoint(new NDataPoint(16, "Agriculture"));
				bar.AddDataPoint(new NDataPoint(42, "Construction"));
				bar.AddDataPoint(new NDataPoint(56, "Manufacturing"));
				bar.AddDataPoint(new NDataPoint(23, "Services"));
				bar.AddDataPoint(new NDataPoint(47, "Healthcare"));
				bar.AddDataPoint(new NDataPoint(38, "Finance"));

				// apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor);
				styleSheet.Apply(nChartControl1.Document);
			}
		}
	}
}

