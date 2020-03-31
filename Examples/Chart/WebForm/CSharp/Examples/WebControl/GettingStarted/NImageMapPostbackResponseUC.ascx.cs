using System;
using System.Drawing;
using System.Web.UI;
using Nevron.Examples.Framework.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NImageMapPostbackResponseUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
        {
			ConfigureControl(nChartControl1, "HTML Image Map with Postback \r\n(Server Events) in 3D mode");
			nChartControl1.Charts[0].Enable3D = true;

			nChartControl1.Settings.JitterMode = JitterMode.Enabled;
			nChartControl1.Settings.JitteringSteps = 4;

			ConfigureControl(nChartControl2, "HTML Image Map with Postback \r\n(Server Events) in 2D mode");

			this.nChartControl1.Click += new EventHandler(this.NChartControl1_Click);
			this.nChartControl2.Click += new EventHandler(this.NChartControl2_Click);
		}

		private void ConfigureControl(NChartControl control, string sLabel)
		{
			control.BackgroundStyle.FrameStyle.Visible = false;

            // generate image map respones
            NHtmlImageMapResponse imageMapResponse = new NHtmlImageMapResponse();
            control.ServerSettings.BrowserResponseSettings.BrowserResponsePairs.Clear();
            control.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse;

            // set a chart title
			NLabel title = control.Labels.AddHeader(sLabel);
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(2, NRelativeUnit.ParentPercentage));

			NLegend legend = control.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom);
			legend.Data.ExpandMode = LegendExpandMode.ColsFixed;
			legend.Data.ColCount = 2;
			legend.ShadowStyle.Type = ShadowType.GaussianBlur;

			NPieChart chart = new NPieChart();
			control.Charts.Clear();
			control.Charts.Add(chart);
			chart.DisplayOnLegend = legend;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
			chart.BoundsMode = BoundsMode.Fit;
			chart.Location = new NPointL(
				new NLength(15, NRelativeUnit.ParentPercentage),
				new NLength(25, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
                new NLength(50, NRelativeUnit.ParentPercentage));

			NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
			pie.PieStyle = PieStyle.SmoothEdgePie;
			pie.LabelMode = PieLabelMode.Rim;
			pie.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			pie.Legend.Mode = SeriesLegendMode.DataPoints;
			pie.Legend.Format = "<label> <percent>";
			pie.DataLabelStyle.ArrowLength = new NLength(0f, NRelativeUnit.ParentPercentage);
			pie.DataLabelStyle.ArrowPointerLength = new NLength(0f, NRelativeUnit.ParentPercentage);

			pie.AddDataPoint(new NDataPoint(12, "Cars"));
			pie.AddDataPoint(new NDataPoint(42, "Trains"));
			pie.AddDataPoint(new NDataPoint(56, "Airplanes"));
            pie.AddDataPoint(new NDataPoint(23, "Buses"));

			pie.InteractivityStyles.Add(0, new NInteractivityStyle("Cars", CursorType.Hand));
			pie.InteractivityStyles.Add(1, new NInteractivityStyle("Trains", CursorType.Hand));
			pie.InteractivityStyles.Add(2, new NInteractivityStyle("Airplanes", CursorType.Hand));
			pie.InteractivityStyles.Add(3, new NInteractivityStyle("Buses", CursorType.Hand));

			NPostbackAttribute postbackAttribute = new NPostbackAttribute();
			for (int i = 0; i < pie.InteractivityStyles.Count; i++)
			{
				((NInteractivityStyle)pie.InteractivityStyles[i]).InteractivityAttributes.Add(postbackAttribute);
				pie.Detachments.Add(0);
			}

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(control.Document);
		}

		private void NChartControl1_Click(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NPostbackEventArgs eventArgs = (NPostbackEventArgs)e;

			NDataPoint dp = eventArgs.Id.FindInDocument(nChartControl1.Document) as NDataPoint;

			if (dp != null)
			{
				int dataItemID = dp.IndexInSeries;

				NPieSeries pie = (NPieSeries)chart.Series[0];
				pie.Detachments[dataItemID] = 10;
			}
		}

		private void NChartControl2_Click(object sender, EventArgs e)
		{
			NChart chart = nChartControl2.Charts[0];
			NPostbackEventArgs eventArgs = (NPostbackEventArgs)e;

			NDataPoint dp = eventArgs.Id.FindInDocument(nChartControl2.Document) as NDataPoint;

			if (dp != null)
			{
				int dataItemID = dp.IndexInSeries;

				NPieSeries pie = (NPieSeries)chart.Series[0];
				pie.Detachments[dataItemID] = 10;
			}
		}
	}
}
