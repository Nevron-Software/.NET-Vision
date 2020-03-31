using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web.UI;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NImportFromDatabaseUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            NLegend legend = nChartControl1.Legends[0];
            legend.FillStyle.SetTransparencyPercent(50);
            legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom);
            legend.Data.ExpandMode = LegendExpandMode.RowsFixed;
            legend.Data.RowCount = 2;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Import from Data Reader");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Width = 100.0f;
			chart.Height = 65.0f;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(10, NRelativeUnit.ParentPercentage),
				new NLength(20, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(80, NRelativeUnit.ParentPercentage),
				new NLength(58, NRelativeUnit.ParentPercentage));

			// create a bar chart
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.DataLabelStyle.Visible = false;
			bar.Legend.Mode = SeriesLegendMode.DataPoints;

			OleDbConnection myConnection = null;
			OleDbDataReader myReader = null;

			try
			{
				// create a database connection object using the connection string 
				myConnection = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.MapPathSecure(this.TemplateSourceDirectory + "\\DataBinding.mdb"));

				// create a database command on the connection using query 
				OleDbCommand myCommand = new OleDbCommand("select * from Sales", myConnection);

				// import the SalesAmount and ProductName into the bar Values and Labels
				myCommand.Connection.Open();
				myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

				NDataSeriesCollection arrSeries = bar.GetDataSeries(DataSeriesMask.Values | DataSeriesMask.Labels, DataSeriesMask.None, false);
				string[] arrCollumns = { "SalesAmount", "ProductName" };

				arrSeries.FillFromDataReader(myReader, arrCollumns);
			}
			finally
			{
				if (myReader != null)
					myReader.Close();

				if (myConnection != null)
					myConnection.Close();
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);
		}
	}
}
