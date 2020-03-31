using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStandardStepLine2DUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				RoundToTickCheck.Checked = true;
				InflateMarginsCheck.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Step Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.BoundsMode = BoundsMode.Stretch;

			// setup axes
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.RoundToTickMin = RoundToTickCheck.Checked;
			scaleY.RoundToTickMax = RoundToTickCheck.Checked;

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.StripStyles.Add(stripStyle);

			// add a step line series
			NStepLineSeries stepLine = (NStepLineSeries)chart.Series.Add(SeriesType.StepLine);
			stepLine.Name = "Series 1";
			stepLine.Legend.Mode = SeriesLegendMode.None;
			stepLine.DataLabelStyle.VertAlign = VertAlign.Center;
			stepLine.DataLabelStyle.Visible = false;
			stepLine.MarkerStyle.Visible = true;
			stepLine.MarkerStyle.PointShape = PointShape.Cylinder;
			stepLine.MarkerStyle.Width = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			stepLine.MarkerStyle.Height = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			stepLine.ShadowStyle.Type = ShadowType.GaussianBlur;
			stepLine.ShadowStyle.Offset = new NPointL(3, 3);
			stepLine.ShadowStyle.FadeLength = new NLength(5);
			stepLine.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0);
			stepLine.InflateMargins = InflateMarginsCheck.Checked;

			// fill some random data
			Random random = new Random();
			stepLine.Values.FillRandom(random, 8);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
