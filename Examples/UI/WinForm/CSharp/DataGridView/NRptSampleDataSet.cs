using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Nevron.Examples.UI.WinForm
{
	class NRptSampleDataSet : DataSet
	{
		public static DataTable GetDataTable(string tableName)
		{
			DataTable dataTable = new DataTable(tableName);
			using (OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\..\..\DataGridView\RptSampl.mdb"))
			{
				conn.Open();

				// Create the DataTable "Orders" in the Dataset and the OrdersDataAdapter
				OleDbDataAdapter dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM " + tableName, conn));
				dataAdapter.FillSchema(dataTable, SchemaType.Source);
				dataAdapter.Fill(dataTable);
			}

			return dataTable;
		}
	}
}
