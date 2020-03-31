using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;


namespace Nevron.Examples.Chart.WebForm
{
	public partial class NBindingToDataAdapterUC : NExampleUC
	{
		protected System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected System.Data.OleDb.OleDbConnection oleDbConnection1;
		protected Nevron.Examples.Chart.WebForm.dsTable dsTable1;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // add header
            NLabel header = nChartControl1.Labels.AddHeader("Bind to Data Adapter");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

            nChartControl1.DataBindingManager.EnableDataBinding = CheckBoxEnableDatabindig.Checked;

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Width = 100.0f;
			chart.Height = 65.0f;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(80, NRelativeUnit.ParentPercentage));

			// add the bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar";
			bar.Legend.Format = "<label>";
			bar.DataLabelStyle.Format = "<label>";
			bar.BarShape = BarShape.SmoothEdgeBar;
			bar.Legend.Mode = SeriesLegendMode.DataPoints;

			

			// binding chart
			BindingChartToData();

			// fill data set
			oleDbDataAdapter1.Fill(dsTable1);

			// if not post back bind data grid
			if (!IsPostBack)
				DataGrid1.DataBind();

			// set "id" column as read-only
			dsTable1.MyTable.columnid.ReadOnly = true;

			
		}

		private void BindingChartToData()
		{
			// connection string with relative path
			string fileName = this.MapPathSecure(this.TemplateSourceDirectory + "\\Data.mdb");
			this.oleDbConnection1.ConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName;

			// add data source to chart control
			nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", oleDbDataAdapter1, "values");
			nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", oleDbDataAdapter1, "colors");
			nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", oleDbDataAdapter1, "colors");

			nChartControl1.DataBindingManager.UpdateChartControl();
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsTable1 = new Nevron.Examples.Chart.WebForm.dsTable();
			((System.ComponentModel.ISupportInitialize)(this.dsTable1)).BeginInit();
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "MyTable", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("colors", "colors"),
																																																				   new System.Data.Common.DataColumnMapping("id", "id"),
																																																				   new System.Data.Common.DataColumnMapping("values", "values")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM MyTable WHERE (id = ?) AND (colors = ? OR ? IS NULL AND colors IS NUL" +
				"L) AND ([values] = ? OR ? IS NULL AND [values] IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_colors", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "colors", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_colors1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "colors", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_values", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "values", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_values1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "values", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""D:\Inetpub\wwwroot\NChartServerExamples\DataManipulation\Binding\Data.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO MyTable(colors, [values]) VALUES (?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("colors", System.Data.OleDb.OleDbType.VarWChar, 50, "colors"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("values", System.Data.OleDb.OleDbType.Integer, 0, "values"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT colors, id, [values] FROM MyTable";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE MyTable SET colors = ?, [values] = ? WHERE (id = ?) AND (colors = ? OR ? I" +
				"S NULL AND colors IS NULL) AND ([values] = ? OR ? IS NULL AND [values] IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("colors", System.Data.OleDb.OleDbType.VarWChar, 50, "colors"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("values", System.Data.OleDb.OleDbType.Integer, 0, "values"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_colors", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "colors", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_colors1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "colors", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_values", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "values", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_values1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "values", System.Data.DataRowVersion.Original, null));
			// 
			// dsTable1
			// 
			this.dsTable1.DataSetName = "dsCategories";
			this.dsTable1.Locale = new System.Globalization.CultureInfo("bg-BG");
			((System.ComponentModel.ISupportInitialize)(this.dsTable1)).EndInit();

		}
		#endregion
	
		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = e.Item.ItemIndex;
			DataGrid1.DataBind();
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = -1;
			DataGrid1.DataBind();
		}

		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string color, sValue;

			// Gets the value of the key field of the row being updated
			string key = DataGrid1.DataKeys[e.Item.ItemIndex].ToString();

			// Gets get the value of the controls (textboxes) that the user
			// updated. The DataGrid columns are exposed as the Cells collection.
			// Each cell has a collection of controls. In this case, there is only    one 
			// control in each cell -- a TextBox control. To get its value,
			// you copy the TextBox to a local instance (which requires casting)
			// and extract its Text property.
			//
			// The first column -- Cells(0) -- contains the Update and Cancel buttons.
			TextBox tb;

			// Gets the value
			tb = (TextBox)(e.Item.Cells[2].Controls[0]);
			color = tb.Text;

			// Gets the value
			tb = (TextBox)(e.Item.Cells[3].Controls[0]);
			sValue = tb.Text;

			// Finds the row in the dataset table that matches the 
			// one the user updated in the grid. This example uses a 
			// special Find method defined for the typed dataset, which
			// returns a reference to the row.
			dsTable.MyTableRow r;
			r = dsTable1.MyTable.FindByid(int.Parse(key));

			// Updates the dataset table.
			r.colors = color;
			r.values = int.Parse(sValue);

			// Calls a SQL statement to update the database from the dataset
			oleDbDataAdapter1.Update(dsTable1);

			// Takes the DataGrid row out of editing mode
			DataGrid1.EditItemIndex = -1;

			// Refreshes the grid
			DataGrid1.DataBind();
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.Cells[2].Controls != null && e.Item.Cells[2].Controls.Count > 0)
			{
				TextBox tb;
				tb = (TextBox)(e.Item.Cells[2].Controls[0]);
				tb.Width = new Unit(100, System.Web.UI.WebControls.UnitType.Pixel);

				tb = (TextBox)(e.Item.Cells[3].Controls[0]);
				tb.Width = new Unit(50, System.Web.UI.WebControls.UnitType.Pixel);
			}
		}
	}
}
