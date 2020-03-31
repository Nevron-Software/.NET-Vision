using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NImportingFromDataReaderUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton ClearChart;
		private Nevron.UI.WinForm.Controls.NButton ImportFromDatabase;
		private System.ComponentModel.Container components = null;

		public NImportingFromDataReaderUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ClearChart = new Nevron.UI.WinForm.Controls.NButton();
			this.ImportFromDatabase = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// ClearChart
			// 
			this.ClearChart.Location = new System.Drawing.Point(3, 8);
			this.ClearChart.Name = "ClearChart";
			this.ClearChart.Size = new System.Drawing.Size(174, 24);
			this.ClearChart.TabIndex = 0;
			this.ClearChart.Text = "Clear Chart";
			this.ClearChart.Click += new System.EventHandler(this.ClearChart_Click);
			// 
			// ImportFromDatabase
			// 
			this.ImportFromDatabase.Location = new System.Drawing.Point(3, 40);
			this.ImportFromDatabase.Name = "ImportFromDatabase";
			this.ImportFromDatabase.Size = new System.Drawing.Size(174, 23);
			this.ImportFromDatabase.TabIndex = 1;
			this.ImportFromDatabase.Text = "Import From Database";
			this.ImportFromDatabase.Click += new System.EventHandler(this.ImportFromDatabase_Click);
			// 
			// NImportingFromDataReaderUC
			// 
			this.Controls.Add(this.ImportFromDatabase);
			this.Controls.Add(this.ClearChart);
			this.Name = "NImportingFromDataReaderUC";
			this.Size = new System.Drawing.Size(180, 112);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			InitTitleAndBackground();
		}

		private void InitTitleAndBackground()
		{
			// add a title
			NLabel title = nChartControl1.Labels.AddHeader("Import from Data Reader");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid;
			title.TextStyle.ShadowStyle.Color = Color.White;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
		}

		private void ImportFromDatabase_Click(object sender, System.EventArgs e)
		{
			nChartControl1.Clear();

			InitTitleAndBackground();

			OleDbConnection myConnection = null;
			OleDbDataReader myReader = null;

			try
			{
				// create a database connection object using the connection string 
				myConnection = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\..\\..\\DataManipulation\\Importing\\DataBinding.mdb");

				// create a database command on the connection using query 
				OleDbCommand myCommand = new OleDbCommand("select * from Sales", myConnection);

				// create a bar chart
				NChart chart = nChartControl1.Charts[0];
				NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
				bar.Legend.Mode = SeriesLegendMode.DataPoints;

				// import the SalesAmount and ProductName into the bar Values and Labels
				myCommand.Connection.Open();
				myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

				NDataSeriesCollection arrSeries = bar.GetDataSeries(DataSeriesMask.Values | DataSeriesMask.Labels, DataSeriesMask.None, false);
				string[] arrCollumns = { "SalesAmount", "ProductName" };

				arrSeries.FillFromDataReader(myReader, arrCollumns);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				if (myReader != null)
					myReader.Close();

				if (myConnection != null)
					myConnection.Close();
			}

			nChartControl1.Refresh();
		}

		private void ClearChart_Click(object sender, System.EventArgs e)
		{
			nChartControl1.Clear();
			InitTitleAndBackground();
			nChartControl1.Refresh();
		}
	}
}
