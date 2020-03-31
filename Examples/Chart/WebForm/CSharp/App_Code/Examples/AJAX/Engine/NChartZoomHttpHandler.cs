using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Dom;

using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public class NChartZoomHttpHandler : IHttpHandler
	{
		public NChartZoomHttpHandler()
		{
		}

		#region IHttpHandler Implementation

		void IHttpHandler.ProcessRequest(HttpContext context)
		{
			int populationDataId;
			int dataPointId;
			if (context.Request["id"] == null)
				return;

			string[] tokens = context.Request["id"].Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries);
			if (tokens.Length != 2)
				return;

			if (!int.TryParse(tokens[0], out populationDataId))
				return;
			if (!int.TryParse(tokens[1], out dataPointId))
				return;

			NCustomToolsData.NData data = NCustomToolsData.Read();

			MemoryStream ms = new MemoryStream();
			NSize chartSize = new NSize(500, 200);
			NDocument document = CreateDocument(chartSize, data, populationDataId, dataPointId);
			NPngImageFormat imageFormat = new NPngImageFormat();
			using (INImage image = CreateImage(document, chartSize, imageFormat))
			{
				document.Refresh();
				image.SaveToStream(ms, imageFormat);
			}

			byte[] bytes = ms.GetBuffer();
			context.Response.ContentType = "image/png";
			context.Response.OutputStream.Write(bytes, 0, bytes.Length);
			context.Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
		}

		bool IHttpHandler.IsReusable
		{
			get
			{
				return true;
			}
		}

		#endregion

		NDocument CreateDocument(NSize chartSize, NCustomToolsData.NData data, int populationDataId, int dataPointId)
		{
			NDocument document = new NDocument();
			document.RootPanel.Charts.Clear();

			// set a chart title
			string sex;
			string total;
			if (populationDataId == data.TotalFemaleData.Id)
			{
				sex = "Female";
				total = string.Format("{0:0,#} +/-{1:0,#}", data.TotalFemaleData.Rows[dataPointId].Value, data.TotalFemaleData.Rows[dataPointId].Error);
			}
			else
			{
				sex = "Male";
				total = string.Format("{0:0,#} +/-{1:0,#}", data.TotalMaleData.Rows[dataPointId].Value, data.TotalMaleData.Rows[dataPointId].Error);
			}
			NLabel header = document.RootPanel.Labels.AddHeader(string.Format("{0}, {1}, Population Data per Race<br/><font size='9pt'>Total of All Races: {2}</font>", sex, data.AgeRanges[dataPointId].Title, total));
			header.TextStyle.TextFormat = TextFormat.XML;
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 13, FontStyle.Italic);
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(
				new NLength(3, NRelativeUnit.ParentPercentage),
				new NLength(3, NRelativeUnit.ParentPercentage));

			// add the chart
			NCartesianChart chart = new NCartesianChart();
			document.RootPanel.Charts.Add(chart);

			chart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft);
			chart.Margins = new NMarginsL(9, 40, 9, 9);
			chart.Location = new NPointL(
				new NLength(0, NRelativeUnit.ParentPercentage),
				new NLength(0, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(100, NRelativeUnit.ParentPercentage),
				new NLength(100, NRelativeUnit.ParentPercentage));
			chart.Width = chartSize.Width + 180;
			chart.Height = chartSize.Height;

			NLinearScaleConfigurator scaleY = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			scaleY.LabelValueFormatter = new NNumericValueFormatter("0,,.#M");

			NOrdinalScaleConfigurator scaleX = new NOrdinalScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
			scaleX.AutoLabels = false;
			scaleX.MajorTickMode = MajorTickMode.CustomTicks;
			scaleX.CustomLabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };
			scaleX.CustomLabelsLevelOffset = new NLength(4);

			NBarSeries barSeries = chart.Series.Add(SeriesType.Bar) as NBarSeries;
			barSeries.DataLabelStyle.Visible = false;

			int length = data.Races.Count;
			for (int i = 0; i < length; i++)
			{
				NCustomToolsData.NRace race = data.Races[i];
				double value;
				if (populationDataId == race.MaleData.Id)
				{
					value = race.MaleData.Rows[dataPointId].Value;
				}
				else
				{
					value = race.FemaleData.Rows[dataPointId].Value;
				}
				barSeries.Values.Add(value);
				NCustomValueLabel vl = new NCustomValueLabel(i, race.Title);
				vl.Style.ContentAlignment = ContentAlignment.MiddleRight;
				scaleX.CustomLabels.Add(vl);
			}

			return document;
		}

		protected INImage CreateImage(NDocument document, NSize size, NPngImageFormat imageFormat)
		{
			INImageFormatProvider imageFormatProvider = new NChartRasterImageFormatProvider(document);
			return imageFormatProvider.ProvideImage(size, NResolution.ScreenResolution, imageFormat);
		}
	}
}
