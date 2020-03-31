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
	public class NBindingToDataAdapterUC : NExampleBaseUC
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private Nevron.UI.WinForm.Controls.NCheckBox checkBoxEnableDatabinding;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.DataSet dataSet1;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.Label label1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.ComponentModel.Container components = null;

		public NBindingToDataAdapterUC()
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NBindingToDataAdapterUC));
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataView1 = new System.Data.DataView();
			this.dataSet1 = new System.Data.DataSet();
			this.checkBoxEnableDatabinding = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.AllowSorting = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dataView1;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 32);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.RowHeadersVisible = false;
			this.dataGrid1.Size = new System.Drawing.Size(216, 264);
			this.dataGrid1.TabIndex = 0;
			// 
			// dataView1
			// 
			this.dataView1.AllowDelete = false;
			this.dataView1.AllowNew = false;
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			this.dataSet1.Locale = new System.Globalization.CultureInfo("bg-BG");
			// 
			// checkBoxEnableDatabinding
			// 
			this.checkBoxEnableDatabinding.ButtonProperties.BorderOffset = 2;
			this.checkBoxEnableDatabinding.Checked = true;
			this.checkBoxEnableDatabinding.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxEnableDatabinding.Location = new System.Drawing.Point(8, 304);
			this.checkBoxEnableDatabinding.Name = "checkBoxEnableDatabinding";
			this.checkBoxEnableDatabinding.Size = new System.Drawing.Size(216, 24);
			this.checkBoxEnableDatabinding.TabIndex = 1;
			this.checkBoxEnableDatabinding.Text = "Enable Data Binding";
			this.checkBoxEnableDatabinding.CheckedChanged += new System.EventHandler(this.checkBoxEnableDatabinding_CheckedChanged);
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
			this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_colors", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "colors", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_colors1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "colors", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_values", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "values", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_values1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "values", System.Data.DataRowVersion.Original, null)});
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = resources.GetString("oleDbConnection1.ConnectionString");
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO MyTable(colors, [values]) VALUES (?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("colors", System.Data.OleDb.OleDbType.VarWChar, 50, "colors"),
            new System.Data.OleDb.OleDbParameter("values", System.Data.OleDb.OleDbType.Integer, 0, "values")});
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
			this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("colors", System.Data.OleDb.OleDbType.VarWChar, 50, "colors"),
            new System.Data.OleDb.OleDbParameter("values", System.Data.OleDb.OleDbType.Integer, 0, "values"),
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_colors", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "colors", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_colors1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "colors", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_values", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "values", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_values1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "values", System.Data.DataRowVersion.Original, null)});
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Data:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NBindingToDataAdapterUC
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkBoxEnableDatabinding);
			this.Controls.Add(this.dataGrid1);
			this.Name = "NBindingToDataAdapterUC";
			this.Size = new System.Drawing.Size(237, 392);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// add a label
			NLabel title = nChartControl1.Labels.AddHeader("Binding to DataAdapter");

			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NChart chart = nChartControl1.Charts[0];

			// add the bar series
			NBarSeries bar = new NBarSeries();
			chart.Series.Add(bar);
			bar.Name = "Bar";
			bar.Legend.Format = "<label>";
			bar.DataLabelStyle.Format = "<label>";
			bar.BarShape = BarShape.SmoothEdgeBar;
			bar.Legend.Mode = SeriesLegendMode.DataPoints;

			// connection string with relative path
			this.oleDbConnection1.ConnectionString = @"Data Source=""" + Application.StartupPath + @"\..\..\DataManipulation\DataBinding\Data.mdb"";Provider=""Microsoft.Jet.OLEDB.4.0"";";

			try
			{
				NDataBindingManager dataBindingManager = nChartControl1.DataBindingManager;

				dataBindingManager.AddBinding(0, 0, "Values", oleDbDataAdapter1, "values");
				dataBindingManager.AddBinding(0, 0, "Labels", oleDbDataAdapter1, "colors");
				dataBindingManager.AddBinding(0, 0, "FillStyles", oleDbDataAdapter1, "colors");
				dataBindingManager.UpdateChartControl();

				oleDbDataAdapter1.Fill(dataSet1);

				DataTable dataTable = dataSet1.Tables[0];
				dataTable.Columns["id"].ReadOnly = true;
				dataTable.RowChanged += new DataRowChangeEventHandler(dataTable_RowChanged);

				dataView1.Table = dataTable;
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message);
			}
		}

		private void dataTable_RowChanged(object sender, DataRowChangeEventArgs e)
		{
            try
            {
                oleDbDataAdapter1.Update(dataSet1);
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
		}

		private void checkBoxEnableDatabinding_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			NDataBindingManager dataBindingManager = nChartControl1.DataBindingManager;

			dataBindingManager.EnableDataBinding = checkBoxEnableDatabinding.Checked;
			dataBindingManager.UpdateChartControl();
		}
	}
}