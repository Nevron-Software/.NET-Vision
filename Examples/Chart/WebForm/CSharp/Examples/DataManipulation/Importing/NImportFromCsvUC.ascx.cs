using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web.UI;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.Chart.CSVReader;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NImportFromDatabaseUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			nChartControl1.Panels.Clear();

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Import from CSV File");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			NCartesianChart chart = new NCartesianChart();

			NBarSeries bar0 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar0.Legend.Mode = SeriesLegendMode.DataPoints;
			//bar0.FillStyle = new NColorFillStyle(Color.Aquamarine);
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.Legend.Mode = SeriesLegendMode.DataPoints;
			//bar0.FillStyle = new NColorFillStyle(Color.BurlyWood);
			bar1.MultiBarMode = MultiBarMode.Clustered;

			string csvFile = this.MapPathSecure(this.TemplateSourceDirectory + "\\Sample.csv");

			NCsvReader reader = new NCsvReader();
			reader.CellSeparator = ',';
			reader.LineSeparators = new char[] { '\r', '\n' };
			reader.HasHeader = false;
			reader.EscapeCharacter = '\\';
			reader.TrimCell = true;

			reader.Columns.Add(new NStringCsvColumn("String Column"));
			reader.Columns.Add(new NDoubleCsvColumn("Double Column"));
			reader.Columns.Add(new NDecimalCsvColumn("Decimal Column"));
			reader.Columns.Add(new NColorCsvColumn("Color0 Column"));
			reader.Columns.Add(new NColorCsvColumn("Color1 Column"));

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			// import
			try
			{
				DataTable dt = reader.LoadDataTableFromFile(csvFile);
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", dt, "Double Column");
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", dt, "String Column");
				nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", dt, "Color0 Column");

				nChartControl1.DataBindingManager.AddBinding(0, 1, "Values", dt, "Decimal Column");
				nChartControl1.DataBindingManager.AddBinding(0, 1, "Labels", dt, "String Column");
				nChartControl1.DataBindingManager.AddBinding(0, 1, "FillStyles", dt, "Color1 Column");
			}
			catch (Exception)
			{

			}
		}
	}
}
