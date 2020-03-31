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
	public class NEvaluatingDataUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
		private NDataSeriesSubset m_Subset;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox3;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox4;
		private Nevron.UI.WinForm.Controls.NComboBox FunctionCombo;
		private Nevron.UI.WinForm.Controls.NButton AddRange;
		private Nevron.UI.WinForm.Controls.NButton AddIndex;
		private Nevron.UI.WinForm.Controls.NButton RemoveIndex;
		private Nevron.UI.WinForm.Controls.NButton RemoveRange;
		private Nevron.UI.WinForm.Controls.NButton Evaluate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NTextBox Index;
		private Nevron.UI.WinForm.Controls.NTextBox Subset;
		private Nevron.UI.WinForm.Controls.NTextBox Result;
		private Nevron.UI.WinForm.Controls.NTextBox From;
		private Nevron.UI.WinForm.Controls.NTextBox To;
		private System.ComponentModel.Container components = null;

		public NEvaluatingDataUC()
		{
			InitializeComponent();

			m_Subset = new NDataSeriesSubset();

			FunctionCombo.Items.Add("MIN");
			FunctionCombo.Items.Add("MAX");
			FunctionCombo.Items.Add("AVE");
			FunctionCombo.Items.Add("SUM");
			FunctionCombo.Items.Add("ABSSUM");
			FunctionCombo.Items.Add("FIRST");
			FunctionCombo.Items.Add("LAST");
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
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.Subset = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.RemoveRange = new Nevron.UI.WinForm.Controls.NButton();
			this.RemoveIndex = new Nevron.UI.WinForm.Controls.NButton();
			this.AddIndex = new Nevron.UI.WinForm.Controls.NButton();
			this.label3 = new System.Windows.Forms.Label();
			this.To = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.From = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.AddRange = new Nevron.UI.WinForm.Controls.NButton();
			this.Index = new Nevron.UI.WinForm.Controls.NTextBox();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.Result = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.Evaluate = new Nevron.UI.WinForm.Controls.NButton();
			this.FunctionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox4 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.Subset);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(226, 225);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Subset";
			// 
			// Subset
			// 
			this.Subset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Subset.Location = new System.Drawing.Point(5, 193);
			this.Subset.Name = "Subset";
			this.Subset.ReadOnly = true;
			this.Subset.Size = new System.Drawing.Size(215, 20);
			this.Subset.TabIndex = 11;
			this.Subset.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 174);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "Current Subset:";
			// 
			// RemoveRange
			// 
			this.RemoveRange.Location = new System.Drawing.Point(106, 40);
			this.RemoveRange.Name = "RemoveRange";
			this.RemoveRange.Size = new System.Drawing.Size(99, 23);
			this.RemoveRange.TabIndex = 9;
			this.RemoveRange.Text = "Remove Range";
			this.RemoveRange.Click += new System.EventHandler(this.RemoveRange_Click);
			// 
			// RemoveIndex
			// 
			this.RemoveIndex.Location = new System.Drawing.Point(106, 43);
			this.RemoveIndex.Name = "RemoveIndex";
			this.RemoveIndex.Size = new System.Drawing.Size(99, 23);
			this.RemoveIndex.TabIndex = 8;
			this.RemoveIndex.Text = "Remove Index";
			this.RemoveIndex.Click += new System.EventHandler(this.RemoveIndex_Click);
			// 
			// AddIndex
			// 
			this.AddIndex.Location = new System.Drawing.Point(106, 14);
			this.AddIndex.Name = "AddIndex";
			this.AddIndex.Size = new System.Drawing.Size(99, 23);
			this.AddIndex.TabIndex = 7;
			this.AddIndex.Text = "Add Index";
			this.AddIndex.Click += new System.EventHandler(this.AddIndex_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "To:";
			// 
			// To
			// 
			this.To.Location = new System.Drawing.Point(51, 41);
			this.To.Name = "To";
			this.To.Size = new System.Drawing.Size(50, 20);
			this.To.TabIndex = 5;
			this.To.Text = "1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "From:";
			// 
			// From
			// 
			this.From.Location = new System.Drawing.Point(51, 15);
			this.From.Name = "From";
			this.From.Size = new System.Drawing.Size(50, 20);
			this.From.TabIndex = 3;
			this.From.Text = "0";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Index:";
			// 
			// AddRange
			// 
			this.AddRange.Location = new System.Drawing.Point(106, 14);
			this.AddRange.Name = "AddRange";
			this.AddRange.Size = new System.Drawing.Size(99, 23);
			this.AddRange.TabIndex = 1;
			this.AddRange.Text = "Add Range";
			this.AddRange.Click += new System.EventHandler(this.AddRange_Click);
			// 
			// Index
			// 
			this.Index.Location = new System.Drawing.Point(52, 15);
			this.Index.Name = "Index";
			this.Index.Size = new System.Drawing.Size(50, 20);
			this.Index.TabIndex = 0;
			this.Index.Text = "0";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.Result);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.Evaluate);
			this.groupBox2.Controls.Add(this.FunctionCombo);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(8, 253);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(226, 178);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Subset Evaluation";
			// 
			// Result
			// 
			this.Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Result.Location = new System.Drawing.Point(8, 120);
			this.Result.Name = "Result";
			this.Result.ReadOnly = true;
			this.Result.Size = new System.Drawing.Size(136, 20);
			this.Result.TabIndex = 4;
			this.Result.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 96);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 3;
			this.label6.Text = "Result:";
			// 
			// Evaluate
			// 
			this.Evaluate.Location = new System.Drawing.Point(8, 64);
			this.Evaluate.Name = "Evaluate";
			this.Evaluate.Size = new System.Drawing.Size(136, 23);
			this.Evaluate.TabIndex = 2;
			this.Evaluate.Text = "Evaluate";
			this.Evaluate.Click += new System.EventHandler(this.Evaluate_Click);
			// 
			// FunctionCombo
			// 
			this.FunctionCombo.Location = new System.Drawing.Point(8, 32);
			this.FunctionCombo.Name = "FunctionCombo";
			this.FunctionCombo.Size = new System.Drawing.Size(136, 21);
			this.FunctionCombo.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Function:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.RemoveRange);
			this.groupBox3.Controls.Add(this.AddRange);
			this.groupBox3.Controls.Add(this.From);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.To);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Location = new System.Drawing.Point(5, 95);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(215, 71);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.RemoveIndex);
			this.groupBox4.Controls.Add(this.AddIndex);
			this.groupBox4.Controls.Add(this.Index);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Location = new System.Drawing.Point(5, 13);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(215, 75);
			this.groupBox4.TabIndex = 13;
			this.groupBox4.TabStop = false;
			// 
			// NEvaluatingDataUC
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NEvaluatingDataUC";
			this.Size = new System.Drawing.Size(242, 443);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			m_Bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar.Values.FillRandom(Random, 10);
			m_Bar.Legend.Mode = SeriesLegendMode.None;

			m_Subset.AddRange(0, 9);
			Subset.Text = m_Subset.ToString();
			FunctionCombo.SelectedIndex = 0;

			ApplyColorToSubset();

			// add a label
			NLabel title = nChartControl1.Labels.AddHeader("Evaluating data");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(Color.MidnightBlue);
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid;
			title.TextStyle.ShadowStyle.Color = Color.White;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
		}

		private void AddIndex_Click(object sender, System.EventArgs e)
		{
			int nIndex = 0;

			try
			{
				nIndex = Int32.Parse(Index.Text);
			}
			catch
			{
				return;
			}

			m_Subset.AddIndex(nIndex);
			Subset.Text = m_Subset.ToString();

			ApplyColorToSubset();
		}

		private void RemoveIndex_Click(object sender, System.EventArgs e)
		{
			int nIndex = 0;

			try
			{
				nIndex = Int32.Parse(Index.Text);
			}
			catch
			{
				return;
			}

			m_Subset.RemoveIndex(nIndex);
			Subset.Text = m_Subset.ToString();

			ApplyColorToSubset();
		}

		private void AddRange_Click(object sender, System.EventArgs e)
		{
			int nFrom = 0;
			int nTo = 0;

			try
			{
				nFrom = Int32.Parse(From.Text);
				nTo = Int32.Parse(To.Text);
			}
			catch
			{
				return;
			}

			m_Subset.AddRange(nFrom, nTo);
			Subset.Text = m_Subset.ToString();

			ApplyColorToSubset();
		}

		private void RemoveRange_Click(object sender, System.EventArgs e)
		{
			int nFrom = 0;
			int nTo = 0;

			try
			{
				nFrom = Int32.Parse(From.Text);
				nTo = Int32.Parse(To.Text);
			}
			catch
			{
				return;
			}

			m_Subset.RemoveRange(nFrom, nTo);
			Subset.Text = m_Subset.ToString();

			ApplyColorToSubset();		
		}

		private void Evaluate_Click(object sender, System.EventArgs e)
		{
			double dResult = m_Bar.Values.Evaluate(FunctionCombo.Text, m_Subset);
			Result.Text = dResult.ToString();
		}

		private void ApplyColorToSubset()
		{
			for (int i = 0; i < 10; i++)
			{
				m_Bar.FillStyles[i] = new NColorFillStyle(Color.Blue);
			}

			foreach (int subsetIndex in m_Subset)
			{
				m_Bar.FillStyles[subsetIndex] = new NColorFillStyle(Color.Red);
			}

			nChartControl1.Refresh();
		}
	}
}