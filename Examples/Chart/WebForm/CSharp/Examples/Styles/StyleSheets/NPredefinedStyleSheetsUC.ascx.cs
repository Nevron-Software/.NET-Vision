using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NPredefinedStyleSheetsUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(PredefinedStyleSheetDropDownList, typeof(PredefinedStyleSheet));
                PredefinedStyleSheetDropDownList.SelectedIndex = 0;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Predefined Style Sheets");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60;
			chart.Height = 25;
			chart.Depth = 45;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] {ChartWallType.Floor, ChartWallType.Back};

			// add the first bar
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.MultiBarMode = MultiBarMode.Series;
			bar1.Name = "Bar1";
			bar1.DataLabelStyle.Visible = true;
			bar1.DataLabelStyle.Format = "<value>";
			bar1.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);

			// add the second bar
			NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar2.MultiBarMode = MultiBarMode.Series;
			bar2.Name = "Bar2";
			bar2.DataLabelStyle.Visible = true;
			bar2.DataLabelStyle.Format = "<value>";
			bar2.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);

			// add the third bar
			NBarSeries bar3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar3.MultiBarMode = MultiBarMode.Series;
			bar3.Name = "Bar3";
			bar3.DataLabelStyle.Visible = true;
			bar3.DataLabelStyle.Format = "<value>";
			bar3.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);

			// fill with random data
			int barCount = 6;
			bar1.Values.FillRandomRange(Random, barCount, 10, 40);
			bar2.Values.FillRandomRange(Random, barCount, 30, 60);
			bar3.Values.FillRandomRange(Random, barCount, 50, 80);

			// apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet((PredefinedStyleSheet)PredefinedStyleSheetDropDownList.SelectedIndex);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}