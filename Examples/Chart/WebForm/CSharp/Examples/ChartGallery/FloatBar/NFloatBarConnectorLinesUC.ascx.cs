using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NFloatBarConnectorLinesUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Float Bar Connector Lines");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;
			for (int i = 0; i < monthLetters.Length; i++)
			{
				scaleX.CustomLabels.Add(new NCustomValueLabel(i, monthLetters[i]));
			}

			// add interlaced stripe to the Y axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			// create the float bar series
			NFloatBarSeries floatBar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatBar.DataLabelStyle.Visible = false;
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center;
			floatBar.DataLabelStyle.Format = "<begin> - <end>";

			// add bars
			floatBar.AddDataPoint(new NFloatBarDataPoint(2, 10));
			floatBar.NextTasks.Add(0, new uint[] { 1 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(5, 16));
			floatBar.NextTasks.Add(1, new uint[] { 2 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(9, 17));
			floatBar.NextTasks.Add(2, new uint[] { 3 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(12, 21));
			floatBar.NextTasks.Add(3, new uint[] { 4 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(8, 18));
			floatBar.NextTasks.Add(4, new uint[] { 5 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(7, 18));
			floatBar.NextTasks.Add(5, new uint[] { 6 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(3, 11));
			floatBar.NextTasks.Add(6, new uint[] { 7 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(5, 12));
			floatBar.NextTasks.Add(7, new uint[] { 8 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(8, 17));
			floatBar.NextTasks.Add(8, new uint[] { 9 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(6, 15));
			floatBar.NextTasks.Add(9, new uint[] { 10 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(3, 10));
			floatBar.NextTasks.Add(10, new uint[] { 11 });

			floatBar.AddDataPoint(new NFloatBarDataPoint(1, 7));

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			floatBar.ShowConnectorLines = ShowConnectorLinesCheckBox.Checked;
			floatBar.ShowGanttConnectorLines = ShowGanttConnectorLinesCheckBox.Checked;
		}
	}
}
