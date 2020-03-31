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
			if (!IsPostBack)
			{
				ExcelFormatDropDown.Items.Add("XLS");
				ExcelFormatDropDown.Items.Add("XLSX");
			}

		
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Import from Excel File");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
				new NLength(2, NRelativeUnit.ParentPercentage),
				new NLength(2, NRelativeUnit.ParentPercentage));

			NCartesianChart chart = new NCartesianChart();

			NBarSeries bar0 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar0.Legend.Mode = SeriesLegendMode.DataPoints;
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.Legend.Mode = SeriesLegendMode.DataPoints;
			bar1.MultiBarMode = MultiBarMode.Clustered;

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			string fileName;

			if (ExcelFormatDropDown.SelectedIndex == 0)
			{
				// Import from XLS
				fileName = this.MapPathSecure(this.TemplateSourceDirectory + "\\Sample.xls");
			}
			else
			{
				// Import from XLSX
				fileName = this.MapPathSecure(this.TemplateSourceDirectory + "\\Sample.xlsx");
			}

			try
			{
				NExcelReader reader = new NExcelReader();
				DataTable dt;

				if (ImportFromRangeCheckBox.Checked)
				{
					// Import range
					dt = reader.ReadRange(fileName, "Sample", "A1:E3").Tables[0];
				}
				else
				{
					// Import whole sheet
					dt = reader.ReadAll(fileName).Tables[0];

				}

				DataColumnCollection columns = dt.Columns;
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", dt, columns[1].ColumnName);
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", dt, columns[0].ColumnName);
				nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", dt, columns[3].ColumnName);

				nChartControl1.DataBindingManager.AddBinding(0, 1, "Values", dt, columns[2].ColumnName);
				nChartControl1.DataBindingManager.AddBinding(0, 1, "Labels", dt, columns[0].ColumnName);
				nChartControl1.DataBindingManager.AddBinding(0, 1, "FillStyles", dt, columns[4].ColumnName);
			}
			catch (Exception)
			{
			}
		}
	}
}
