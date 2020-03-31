using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NBrowserRedirectUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (nChartControl1.RequiresInitialization)
			{
                nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
                nChartControl1.Settings.JitterMode = JitterMode.Enabled;

                // configure legend
				NLegend legend = nChartControl1.Legends[0];
				legend.ShadowStyle.Type = ShadowType.GaussianBlur;
				legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Left);
                legend.DockMode = PanelDockMode.Bottom;
                legend.Margins = new NMarginsL(0, 0, 0, 10);
                legend.Data.ExpandMode = LegendExpandMode.ColsFixed;
                legend.Data.ColCount = 2;

				// set a chart title
				NLabel header = nChartControl1.Labels.AddHeader("Product Analysis");
				header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
				header.ContentAlignment = ContentAlignment.BottomRight;
				header.Location = new NPointL(
					new NLength(3, NRelativeUnit.ParentPercentage),
					new NLength(3, NRelativeUnit.ParentPercentage));

				// by default the chart contains a cartesian chart which cannot display pie series
				NPieChart chart = new NPieChart();
				chart.Enable3D = true;
				nChartControl1.Charts.Clear();
				nChartControl1.Charts.Add(chart);
				chart.DisplayOnLegend = nChartControl1.Legends[0];

				NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);

				pie.AddDataPoint(new NDataPoint(23, ".NET Vision"));
				pie.AddDataPoint(new NDataPoint(56, "Chart"));
				pie.AddDataPoint(new NDataPoint(42, "Diagram"));
				pie.AddDataPoint(new NDataPoint(12, "User Interface"));

				pie.Legend.Mode = SeriesLegendMode.DataPoints;
				pie.Legend.Format = "<label> <percent>";

				pie.PieStyle = PieStyle.SmoothEdgePie;
				pie.LabelMode = PieLabelMode.Spider;

				pie.LabelMode = PieLabelMode.Center;
				pie.DataLabelStyle.ArrowLength = new NLength(0f, NRelativeUnit.ParentPercentage);
				pie.DataLabelStyle.ArrowPointerLength = new NLength(0f, NRelativeUnit.ParentPercentage);

				chart.LightModel.EnableLighting = true;
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
				chart.BoundsMode = BoundsMode.Fit;
				chart.Location = new NPointL(
					new NLength(10, NRelativeUnit.ParentPercentage),
					new NLength(10, NRelativeUnit.ParentPercentage));
				chart.Size = new NSizeL(
					new NLength(80, NRelativeUnit.ParentPercentage),
					new NLength(70, NRelativeUnit.ParentPercentage));

				//	set up client side redirects
				pie.InteractivityStyles.Add(0, new NInteractivityStyle(true, null, null, CursorType.Default, "http://www.nevron.com/Products.Nevron.NETVision.Overview.aspx"));
				pie.InteractivityStyles.Add(1, new NInteractivityStyle(true, null, null, CursorType.Default, "http://www.nevron.com/Products.ChartFor.NET.Overview.aspx"));
				pie.InteractivityStyles.Add(2, new NInteractivityStyle(true, null, null, CursorType.Default, "http://www.nevron.com/Products.DiagramFor.NET.Overview.aspx"));
				pie.InteractivityStyles.Add(3, new NInteractivityStyle(true, null, null, CursorType.Default, "http://www.nevron.com/Products.UserInterfaceFor.NET.Overview.aspx"));

                // apply style sheet
                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
                styleSheet.Apply(nChartControl1.Document);
			}
		}

		protected void nChartControl1_QueryAjaxTools(object sender, EventArgs e)
		{
			nChartControl1.AjaxTools.Add(new NAjaxRedirectTool(true));
		}
	}
}
