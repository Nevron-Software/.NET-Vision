using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using System.Diagnostics;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NSeriesZOrderUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// init form controls
				ZOrderModeCombo.Items.Add("123");
				ZOrderModeCombo.Items.Add("321");
				ZOrderModeCombo.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = new NLabel("Series Z Order");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			nChartControl1.Panels.Add(title);
            
			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add the first bar
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.WidthPercent = 80;
			bar1.Name = "Bar1";

			// add the second bar
			NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar2.WidthPercent = 60;
			bar2.Name = "Bar2";

			// add the third bar
			NBarSeries bar3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar3.WidthPercent = 40;
			bar3.Name = "Bar3";

			// position data labels in the center of the bars
			bar1.DataLabelStyle.Visible = false;
			bar2.DataLabelStyle.Visible = false;
			bar3.DataLabelStyle.Visible = false;

			// fill some random data
			bar1.Values.FillRandomRange(Random, 6, 20, 100);
			bar2.Values.FillRandomRange(Random, 6, 20, 100);
			bar3.Values.FillRandomRange(Random, 6, 20, 100);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);

			switch (ZOrderModeCombo.SelectedIndex)
			{
				case 0:
					bar1.ZOrder = 1;
					bar2.ZOrder = 2;
					bar3.ZOrder = 3;
					break;
				case 1:
					bar1.ZOrder = 3;
					bar2.ZOrder = 2;
					bar3.ZOrder = 1;
					break;
				default:
					Debug.Assert(false);
					break;
			}
		}
	}
}
