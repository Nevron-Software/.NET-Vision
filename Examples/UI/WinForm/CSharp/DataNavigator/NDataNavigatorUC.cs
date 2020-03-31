using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.Interop.Win32;
using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NDataNavigatorUC.
	/// </summary>
	public class NDataNavigatorUC : NExampleUserControl
	{
		#region Constructor

		public NDataNavigatorUC()
		{
			InitializeComponent();

			Dock = DockStyle.Fill;

            CreateDataSources();
			InitDataSourceCombo();
		}


		#endregion

		#region Overrides

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


		#endregion

		#region Implementation

		internal void CreateDataSources()
		{
			m_DataSource1 = new ArrayList();
			for(int i = 0; i < 1000; i++)
			{
				m_DataSource1.Add("Record " + (i + 1).ToString());
			}

			m_DataSource2 = new DataTable();
			m_DataSource2.BeginInit();

			//populate the datatable with sample data
			for(int i = 0; i < 10; i++)
			{
				m_DataSource2.Columns.Add("Sample data column " + (i + 1).ToString());

				for(int j = 0; j < 10; j++)
				{
					m_DataSource2.Rows.Add(new object[] {});
				}
			}

			m_DataSource2.EndInit();
		}

		internal void InitDataSourceCombo()
		{
			NListBoxItem item;

			item = new NListBoxItem("None");
			dataSourceCombo.Items.Add(item);

			item = new NListBoxItem("Array List");
			dataSourceCombo.Items.Add(item);

			item = new NListBoxItem("Data Set");
			dataSourceCombo.Items.Add(item);

			dataSourceCombo.SelectedIndex = 0;
		}


		#endregion

		#region Event Handlers

		private void nNumericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
			if(nDataNavigator1 == null)
				return;

			nDataNavigator1.DataNavigatorElement.DisplayIndex = (int)nNumericUpDown1.Value;
			nDataNavigator2.DataNavigatorElement.DisplayIndex = (int)nNumericUpDown1.Value;
		}

		private void dataSourceCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int index = dataSourceCombo.SelectedIndex;
			object dataSource = null;

			switch(index)
			{
				case 1:
					dataSource = m_DataSource1;
					break;
				case 2:
					dataSource = m_DataSource2;
					break;
			}
			
			nDataNavigator1.DataNavigatorElement.DataSource = dataSource;
			nDataNavigator2.DataNavigatorElement.DataSource = dataSource;
		}

		private void tootipsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			bool enable = tootipsCheck.Checked;

			nDataNavigator1.EnableElementTooltips = enable;
			nDataNavigator2.EnableElementTooltips = enable;
		}

		private void autoRepeatCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			int interval = autoRepeatCheck.Checked ? 10 : 0;

			nDataNavigator1.DataNavigatorElement.RepeatInterval = interval;
			nDataNavigator2.DataNavigatorElement.RepeatInterval = interval;
		}

		private void showDisplayCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			bool show = showDisplayCheck.Checked;

			nDataNavigator1.DataNavigatorElement.ShowDisplay = show;
			nDataNavigator2.DataNavigatorElement.ShowDisplay = show;
		}
		private void borderBtn_Click(object sender, System.EventArgs e)
		{
			nDataNavigator1.Border.ShowEditor();
			nDataNavigator2.Border.Copy(nDataNavigator1.Border);
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nDataNavigator1 = new Nevron.UI.WinForm.Controls.NDataNavigator();
			this.nNumericUpDown1 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.nDataNavigator2 = new Nevron.UI.WinForm.Controls.NDataNavigator();
			this.label2 = new System.Windows.Forms.Label();
			this.dataSourceCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.tootipsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.autoRepeatCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.borderBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.showDisplayCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// nDataNavigator1
			// 
			this.nDataNavigator1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nDataNavigator1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.nDataNavigator1.Location = new System.Drawing.Point(8, 8);
			this.nDataNavigator1.Name = "nDataNavigator1";
			this.nDataNavigator1.Size = new System.Drawing.Size(229, 24);
			this.nDataNavigator1.TabIndex = 0;
			this.nDataNavigator1.Text = "nDataNavigator1";
			// 
			// nNumericUpDown1
			// 
			this.nNumericUpDown1.Location = new System.Drawing.Point(152, 48);
			this.nNumericUpDown1.Maximum = new System.Decimal(new int[] {
																			6,
																			0,
																			0,
																			0});
			this.nNumericUpDown1.Name = "nNumericUpDown1";
			this.nNumericUpDown1.Size = new System.Drawing.Size(64, 20);
			this.nNumericUpDown1.TabIndex = 3;
			this.nNumericUpDown1.ValueChanged += new System.EventHandler(this.nNumericUpDown1_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Label Index:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nDataNavigator2
			// 
			this.nDataNavigator2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.nDataNavigator2.DataNavigatorElement.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.nDataNavigator2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.nDataNavigator2.Location = new System.Drawing.Point(8, 40);
			this.nDataNavigator2.Name = "nDataNavigator2";
			this.nDataNavigator2.Size = new System.Drawing.Size(24, 228);
			this.nDataNavigator2.TabIndex = 1;
			this.nDataNavigator2.Text = "nDataNavigator2";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(48, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 24);
			this.label2.TabIndex = 4;
			this.label2.Text = "Data Source:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dataSourceCombo
			// 
			this.dataSourceCombo.Location = new System.Drawing.Point(152, 80);
			this.dataSourceCombo.Name = "dataSourceCombo";
			this.dataSourceCombo.Size = new System.Drawing.Size(168, 22);
			this.dataSourceCombo.TabIndex = 5;
			this.dataSourceCombo.Text = "nComboBox1";
			this.dataSourceCombo.SelectedIndexChanged += new System.EventHandler(this.dataSourceCombo_SelectedIndexChanged);
			// 
			// tootipsCheck
			// 
			this.tootipsCheck.ButtonProperties.BorderOffset = 2;
			this.tootipsCheck.Checked = true;
			this.tootipsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tootipsCheck.Location = new System.Drawing.Point(152, 136);
			this.tootipsCheck.Name = "tootipsCheck";
			this.tootipsCheck.Size = new System.Drawing.Size(168, 24);
			this.tootipsCheck.TabIndex = 7;
			this.tootipsCheck.Text = "Enable tooltips";
			this.tootipsCheck.CheckedChanged += new System.EventHandler(this.tootipsCheck_CheckedChanged);
			// 
			// autoRepeatCheck
			// 
			this.autoRepeatCheck.ButtonProperties.BorderOffset = 2;
			this.autoRepeatCheck.Checked = true;
			this.autoRepeatCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoRepeatCheck.Location = new System.Drawing.Point(152, 160);
			this.autoRepeatCheck.Name = "autoRepeatCheck";
			this.autoRepeatCheck.Size = new System.Drawing.Size(168, 24);
			this.autoRepeatCheck.TabIndex = 8;
			this.autoRepeatCheck.Text = "Enable auto-repeat";
			this.autoRepeatCheck.CheckedChanged += new System.EventHandler(this.autoRepeatCheck_CheckedChanged);
			// 
			// borderBtn
			// 
			this.borderBtn.Location = new System.Drawing.Point(152, 192);
			this.borderBtn.Name = "borderBtn";
			this.borderBtn.Size = new System.Drawing.Size(88, 24);
			this.borderBtn.TabIndex = 9;
			this.borderBtn.Text = "Border...";
			this.borderBtn.Click += new System.EventHandler(this.borderBtn_Click);
			// 
			// showDisplayCheck
			// 
			this.showDisplayCheck.ButtonProperties.BorderOffset = 2;
			this.showDisplayCheck.Checked = true;
			this.showDisplayCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showDisplayCheck.Location = new System.Drawing.Point(152, 112);
			this.showDisplayCheck.Name = "showDisplayCheck";
			this.showDisplayCheck.Size = new System.Drawing.Size(168, 24);
			this.showDisplayCheck.TabIndex = 6;
			this.showDisplayCheck.Text = "Show Display";
			this.showDisplayCheck.CheckedChanged += new System.EventHandler(this.showDisplayCheck_CheckedChanged);
			// 
			// NDataNavigatorUC
			// 
			this.Controls.Add(this.showDisplayCheck);
			this.Controls.Add(this.borderBtn);
			this.Controls.Add(this.autoRepeatCheck);
			this.Controls.Add(this.tootipsCheck);
			this.Controls.Add(this.dataSourceCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.nDataNavigator2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nNumericUpDown1);
			this.Controls.Add(this.nDataNavigator1);
			this.Name = "NDataNavigatorUC";
			this.Size = new System.Drawing.Size(376, 328);
			((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		internal ArrayList m_DataSource1;
		internal DataTable m_DataSource2;

		private Nevron.UI.WinForm.Controls.NDataNavigator nDataNavigator1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown1;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NDataNavigator nDataNavigator2;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox dataSourceCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox tootipsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox autoRepeatCheck;
		private Nevron.UI.WinForm.Controls.NButton borderBtn;
		private Nevron.UI.WinForm.Controls.NCheckBox showDisplayCheck;
		private System.ComponentModel.Container components = null;

		#endregion
	}
}
