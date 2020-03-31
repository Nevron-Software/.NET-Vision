using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NBindingToDataTableUC : NExampleBaseUC
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.ComponentModel.IContainer components = null;
		private DataTable dataTable;

		public NBindingToDataTableUC()
		{
			InitializeComponent();

			// create the data table
			dataTable = new DataTable("Table");
			dataTable.Columns.Add("ValueY1", typeof(double));
			dataTable.Columns.Add("ValueY2", typeof(double));
			dataTable.Rows.Add(new object[]{ 10.1,  5.33 });
			dataTable.Rows.Add(new object[]{  7.2,  6.55 });
			dataTable.Rows.Add(new object[]{  9.6,  8.97 });
			dataTable.Rows.Add(new object[]{ 11.2,  9.48 });
			dataTable.Rows.Add(new object[]{  4.9, 11.17 });
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 8);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(232, 376);
			this.dataGrid1.TabIndex = 0;
			// 
			// NBindingToDataTableUC
			// 
			this.Controls.Add(this.dataGrid1);
			this.Name = "NBindingToDataTableUC";
			this.Size = new System.Drawing.Size(248, 400);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// setup background

			// add a label
			NLabel title = nChartControl1.Labels.AddHeader("Binding to DataTable");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            
            
            NChart chart = nChartControl1.Charts[0];

			// add bar series 1
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.Name = "Bar 1";
			bar1.DataLabelStyle.Format = "<value>";

			// add bar series 2
			NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar2.MultiBarMode = MultiBarMode.Clustered;
			bar2.FillStyle = new NColorFillStyle(Color.Violet);
			bar2.Name = "Bar 2";
			bar2.DataLabelStyle.Format = "<value>";

			NDataBindingManager dataBindingManager = nChartControl1.DataBindingManager;

			dataBindingManager.AddBinding(0, 0, "Values", dataTable, "ValueY1");
			dataBindingManager.AddBinding(0, 1, "Values", dataTable, "ValueY2");

			dataGrid1.SetDataBinding(dataTable, null);
		}
	}
}

