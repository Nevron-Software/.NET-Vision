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
	public class NFilteringDataUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
		private NDataSeriesSubset m_SubsetAll;
		private NDataSeriesSubset m_SubsetFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NTextBox Value;
		private Nevron.UI.WinForm.Controls.NTextBox CurrentFilter;
		private Nevron.UI.WinForm.Controls.NListBox OperationList;
		private Nevron.UI.WinForm.Controls.NComboBox compareMethodCombo;
		private Nevron.UI.WinForm.Controls.NComboBox subsetOperationCombo;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NButton btnApplyFilter;
		private Nevron.UI.WinForm.Controls.NButton btnResetFilter;
		private Nevron.UI.WinForm.Controls.NButton btnChangeData;
		private Nevron.UI.WinForm.Controls.NButton btnExtractSubset;
		private Nevron.UI.WinForm.Controls.NButton btnRemoveSubset;
		private System.ComponentModel.Container components = null;

		public NFilteringDataUC()
		{
			InitializeComponent();

			m_SubsetAll = new NDataSeriesSubset();
			m_SubsetFilter = new NDataSeriesSubset();

			compareMethodCombo.FillFromEnum(typeof(Nevron.Chart.CompareMethod));

			subsetOperationCombo.Items.Add("Replace");
			subsetOperationCombo.Items.Add("Combine");
			subsetOperationCombo.Items.Add("Intersect");
			subsetOperationCombo.Items.Add("Subtract");
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NFilteringDataUC));
			this.label1 = new System.Windows.Forms.Label();
			this.compareMethodCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Value = new Nevron.UI.WinForm.Controls.NTextBox();
			this.btnApplyFilter = new Nevron.UI.WinForm.Controls.NButton();
			this.btnResetFilter = new Nevron.UI.WinForm.Controls.NButton();
			this.label3 = new System.Windows.Forms.Label();
			this.subsetOperationCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.btnChangeData = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.CurrentFilter = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.OperationList = new Nevron.UI.WinForm.Controls.NListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.btnRemoveSubset = new Nevron.UI.WinForm.Controls.NButton();
			this.btnExtractSubset = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Compare Method:";
			// 
			// compareMethodCombo
			// 
			this.compareMethodCombo.Location = new System.Drawing.Point(82, 79);
			this.compareMethodCombo.Name = "compareMethodCombo";
			this.compareMethodCombo.Size = new System.Drawing.Size(96, 21);
			this.compareMethodCombo.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Value:";
			// 
			// Value
			// 
			this.Value.Location = new System.Drawing.Point(82, 52);
			this.Value.Name = "Value";
			this.Value.Size = new System.Drawing.Size(96, 20);
			this.Value.TabIndex = 3;
			this.Value.Text = "50";
			// 
			// btnApplyFilter
			// 
			this.btnApplyFilter.Location = new System.Drawing.Point(10, 137);
			this.btnApplyFilter.Name = "btnApplyFilter";
			this.btnApplyFilter.Size = new System.Drawing.Size(168, 24);
			this.btnApplyFilter.TabIndex = 4;
			this.btnApplyFilter.Text = "Apply Filter";
			this.btnApplyFilter.Click += new System.EventHandler(this.ApplyFilter_Click);
			// 
			// btnResetFilter
			// 
			this.btnResetFilter.Location = new System.Drawing.Point(10, 21);
			this.btnResetFilter.Name = "btnResetFilter";
			this.btnResetFilter.Size = new System.Drawing.Size(167, 23);
			this.btnResetFilter.TabIndex = 5;
			this.btnResetFilter.Text = "Reset Filter";
			this.btnResetFilter.Click += new System.EventHandler(this.ResetFilter_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 32);
			this.label3.TabIndex = 6;
			this.label3.Text = "Subset Operation:";
			// 
			// subsetOperationCombo
			// 
			this.subsetOperationCombo.Location = new System.Drawing.Point(82, 107);
			this.subsetOperationCombo.Name = "subsetOperationCombo";
			this.subsetOperationCombo.Size = new System.Drawing.Size(96, 21);
			this.subsetOperationCombo.TabIndex = 7;
			// 
			// btnChangeData
			// 
			this.btnChangeData.Location = new System.Drawing.Point(10, 22);
			this.btnChangeData.Name = "btnChangeData";
			this.btnChangeData.Size = new System.Drawing.Size(168, 23);
			this.btnChangeData.TabIndex = 1;
			this.btnChangeData.Text = "Change Data";
			this.btnChangeData.Click += new System.EventHandler(this.ChangeData_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CurrentFilter);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.OperationList);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.compareMethodCombo);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.Value);
			this.groupBox1.Controls.Add(this.btnApplyFilter);
			this.groupBox1.Controls.Add(this.btnResetFilter);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.subsetOperationCombo);
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(7, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(190, 345);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filter Operations";
			// 
			// CurrentFilter
			// 
			this.CurrentFilter.Location = new System.Drawing.Point(10, 283);
			this.CurrentFilter.Multiline = true;
			this.CurrentFilter.Name = "CurrentFilter";
			this.CurrentFilter.Size = new System.Drawing.Size(168, 51);
			this.CurrentFilter.TabIndex = 3;
			this.CurrentFilter.Text = "textBox1";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(10, 265);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(168, 16);
			this.label5.TabIndex = 2;
			this.label5.Text = "Current Filter:";
			// 
			// OperationList
			// 
			this.OperationList.Location = new System.Drawing.Point(10, 185);
			this.OperationList.Name = "OperationList";
			this.OperationList.Size = new System.Drawing.Size(168, 69);
			this.OperationList.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(10, 169);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(168, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "Operation List:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnRemoveSubset);
			this.groupBox2.Controls.Add(this.btnExtractSubset);
			this.groupBox2.Controls.Add(this.btnChangeData);
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(7, 359);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(190, 120);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Data Series Operations";
			// 
			// btnRemoveSubset
			// 
			this.btnRemoveSubset.Location = new System.Drawing.Point(10, 86);
			this.btnRemoveSubset.Name = "btnRemoveSubset";
			this.btnRemoveSubset.Size = new System.Drawing.Size(168, 23);
			this.btnRemoveSubset.TabIndex = 0;
			this.btnRemoveSubset.Text = "Remove Subset";
			this.btnRemoveSubset.Click += new System.EventHandler(this.RemoveSubset_Click);
			// 
			// btnExtractSubset
			// 
			this.btnExtractSubset.Location = new System.Drawing.Point(10, 54);
			this.btnExtractSubset.Name = "btnExtractSubset";
			this.btnExtractSubset.Size = new System.Drawing.Size(168, 23);
			this.btnExtractSubset.TabIndex = 0;
			this.btnExtractSubset.Text = "Extract Subset";
			this.btnExtractSubset.Click += new System.EventHandler(this.ExtractSubset_Click);
			// 
			// NFilteringDataUC
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "NFilteringDataUC";
			this.Size = new System.Drawing.Size(207, 490);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// add a label
			NLabel title = nChartControl1.Labels.AddHeader("Filtering Data");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid;
			title.TextStyle.ShadowStyle.Color = Color.White;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			m_Bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar.Legend.Mode = SeriesLegendMode.None;
			m_Bar.DataLabelStyle.Format = "<value>";
			m_Bar.Values.FillRandom(Random, 10);

			ResetFilter();

			compareMethodCombo.SelectedIndex = 0;
			subsetOperationCombo.SelectedIndex = 0;
		}

		private void ResetFilter()
		{
			m_SubsetAll.Clear();
			m_SubsetFilter.Clear();

			if (m_Bar.Values.Count > 0)
			{
				m_SubsetAll.AddRange(0, m_Bar.Values.Count - 1);
				m_SubsetFilter.AddRange(0, m_Bar.Values.Count - 1);
			}

			OperationList.Items.Clear();
			OperationList.Items.Add("f = all");
			CurrentFilter.Text = m_SubsetFilter.ToString();

			ApplyColorToSubset(m_SubsetFilter, Color.Red);
		}

		private void ApplyColorToSubset(NDataSeriesSubset subset, Color color)
		{
			m_Bar.FillStyles.Clear();

			foreach (int index in subset)
			{
				m_Bar.FillStyles[index] = new NColorFillStyle(color);
			}
		}

		private void ResetFilter_Click(object sender, System.EventArgs e)
		{
			ResetFilter();

			nChartControl1.Refresh();
		}

		private void ApplyFilter_Click(object sender, System.EventArgs e)
		{
			double dValue;
			string sFilter = "";
			string sOperation = "";

			// make all colors blue
			ApplyColorToSubset(m_SubsetAll, Color.Blue);

			try
			{
				dValue = Double.Parse(Value.Text);		
			}
			catch
			{
				return;
			}

			Nevron.Chart.CompareMethod compareMethod = (Nevron.Chart.CompareMethod)compareMethodCombo.SelectedIndex;

			NDataSeriesSubset subset = m_Bar.Values.Filter(compareMethod, dValue);

			switch (compareMethodCombo.SelectedIndex)
			{
				case 0:
					sFilter = "(> " + dValue.ToString() + ")";
					break;
				case 1:
					sFilter = "(< " + dValue.ToString() + ")";
					break;
				case 2:
					sFilter = "(==" + dValue.ToString() + ")";
					break;
				case 3:
					sFilter = "(>=" + dValue.ToString() + ")";
					break;
				case 4:
					sFilter = "(<=" + dValue.ToString() + ")";
					break;
				case 5:
					sFilter = "(!=" + dValue.ToString() + ")";
					break;
			}

			switch (subsetOperationCombo.SelectedIndex)
			{
				case 0: // replace
					m_SubsetFilter = subset;
					OperationList.Items.Clear();
					sOperation = "f = ";
					break;

				case 1: // combine
					m_SubsetFilter.Combine(subset);
					sOperation = "f = f combine ";
					break;
				case 2: // intersect
					m_SubsetFilter.Intersect(subset);
					sOperation = "f = f intersect ";
					break;
				case 3: // subtract
					m_SubsetFilter.Subtract(subset);
					sOperation = "f = f subtract ";
					break;
			}

			OperationList.Items.Add(sOperation + sFilter);
			CurrentFilter.Text = m_SubsetFilter.ToString();

			// apply red color only on the bars in the filter subset
			ApplyColorToSubset(m_SubsetFilter, Color.Red);

			nChartControl1.Refresh();
		}

		private void ChangeData_Click(object sender, System.EventArgs e)
		{
			m_Bar.Values.FillRandom(Random, 10);

			ResetFilter();

			nChartControl1.Refresh();
		}

		private void ExtractSubset_Click(object sender, System.EventArgs e)
		{
			m_Bar.Values.ExtractSubset(m_SubsetFilter);

			ResetFilter();

			nChartControl1.Refresh();
		}

		private void RemoveSubset_Click(object sender, System.EventArgs e)
		{
			m_Bar.Values.RemoveSubset(m_SubsetFilter);

			ResetFilter();

			nChartControl1.Refresh();
		}

	}
} 