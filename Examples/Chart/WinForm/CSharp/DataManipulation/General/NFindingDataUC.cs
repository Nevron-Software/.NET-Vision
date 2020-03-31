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
	public class NFindingDataUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
		private Nevron.UI.WinForm.Controls.NButton FindMinValue;
		private Nevron.UI.WinForm.Controls.NButton FindMaxValue;
		private Nevron.UI.WinForm.Controls.NButton FindValue;
		private Nevron.UI.WinForm.Controls.NButton FindString;
		private Nevron.UI.WinForm.Controls.NButton ChangeData;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NTextBox ValueEdit;
		private Nevron.UI.WinForm.Controls.NTextBox StringEdit;
		private System.ComponentModel.Container components = null;

		public NFindingDataUC()
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
			this.FindMinValue = new Nevron.UI.WinForm.Controls.NButton();
			this.FindMaxValue = new Nevron.UI.WinForm.Controls.NButton();
			this.FindValue = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.ValueEdit = new Nevron.UI.WinForm.Controls.NTextBox();
			this.StringEdit = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.FindString = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeData = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// FindMinValue
			// 
			this.FindMinValue.Location = new System.Drawing.Point(8, 61);
			this.FindMinValue.Name = "FindMinValue";
			this.FindMinValue.Size = new System.Drawing.Size(199, 23);
			this.FindMinValue.TabIndex = 0;
			this.FindMinValue.Text = "Find Min Value";
			this.FindMinValue.Click += new System.EventHandler(this.FindMinValue_Click);
			// 
			// FindMaxValue
			// 
			this.FindMaxValue.Location = new System.Drawing.Point(8, 93);
			this.FindMaxValue.Name = "FindMaxValue";
			this.FindMaxValue.Size = new System.Drawing.Size(199, 23);
			this.FindMaxValue.TabIndex = 1;
			this.FindMaxValue.Text = "Find Max Value";
			this.FindMaxValue.Click += new System.EventHandler(this.FindMaxValue_Click);
			// 
			// FindValue
			// 
			this.FindValue.Location = new System.Drawing.Point(132, 128);
			this.FindValue.Name = "FindValue";
			this.FindValue.Size = new System.Drawing.Size(75, 20);
			this.FindValue.TabIndex = 2;
			this.FindValue.Text = "Find Value";
			this.FindValue.Click += new System.EventHandler(this.FindValue_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 131);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Value:";
			// 
			// ValueEdit
			// 
			this.ValueEdit.Location = new System.Drawing.Point(47, 128);
			this.ValueEdit.Name = "ValueEdit";
			this.ValueEdit.Size = new System.Drawing.Size(79, 20);
			this.ValueEdit.TabIndex = 4;
			this.ValueEdit.Text = "12";
			// 
			// StringEdit
			// 
			this.StringEdit.Location = new System.Drawing.Point(47, 160);
			this.StringEdit.Name = "StringEdit";
			this.StringEdit.Size = new System.Drawing.Size(79, 20);
			this.StringEdit.TabIndex = 7;
			this.StringEdit.Text = "str1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 163);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "String:";
			// 
			// FindString
			// 
			this.FindString.Location = new System.Drawing.Point(132, 160);
			this.FindString.Name = "FindString";
			this.FindString.Size = new System.Drawing.Size(75, 20);
			this.FindString.TabIndex = 5;
			this.FindString.Text = "Find String";
			this.FindString.Click += new System.EventHandler(this.FindString_Click);
			// 
			// ChangeData
			// 
			this.ChangeData.Location = new System.Drawing.Point(8, 8);
			this.ChangeData.Name = "ChangeData";
			this.ChangeData.Size = new System.Drawing.Size(199, 23);
			this.ChangeData.TabIndex = 8;
			this.ChangeData.Text = "Change Data";
			this.ChangeData.Click += new System.EventHandler(this.ChangeData_Click);
			// 
			// NFindingDataUC
			// 
			this.Controls.Add(this.ChangeData);
			this.Controls.Add(this.StringEdit);
			this.Controls.Add(this.FindString);
			this.Controls.Add(this.ValueEdit);
			this.Controls.Add(this.FindValue);
			this.Controls.Add(this.FindMaxValue);
			this.Controls.Add(this.FindMinValue);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Name = "NFindingDataUC";
			this.Size = new System.Drawing.Size(215, 201);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// add a label
			NLabel title = nChartControl1.Labels.AddHeader("Finding Data");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid;
			title.TextStyle.ShadowStyle.Color = Color.White;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// create a bar chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// setup bar series
			m_Bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar.Legend.Mode = SeriesLegendMode.None;

			// generate random values and labels
			GenerateValues(6);
			m_Bar.Labels.FillRandom(Random, 6);

			// init form controls
			ValueEdit.Text = m_Bar.Values[3].ToString();
			StringEdit.Text = (string)m_Bar.Labels[4];
		}

		void GenerateValues(int count)
		{
			m_Bar.Values.Clear();

			for (int i = 0; i < count; i++)
			{
				double value = 1 + Random.NextDouble() * 99;
				value = Math.Round(value, 2);
				m_Bar.Values.Add(value);
			}
		}

		private void ChangeData_Click(object sender, System.EventArgs e)
		{
			// generate random values and labels
			GenerateValues(6);
			m_Bar.Labels.FillRandom(Random, 6);

			// all bars must be filled with the default color
			m_Bar.FillStyles.Clear();

			nChartControl1.Refresh();
		}

		private void FindMinValue_Click(object sender, System.EventArgs e)
		{
			int index = m_Bar.Values.FindMinValue();

			m_Bar.FillStyles.Clear();
			m_Bar.FillStyles[index] = new NColorFillStyle(Color.Red);

			nChartControl1.Refresh();
		}

		private void FindMaxValue_Click(object sender, System.EventArgs e)
		{
			int index = m_Bar.Values.FindMaxValue();

			m_Bar.FillStyles.Clear();
			m_Bar.FillStyles[index] = new NColorFillStyle(Color.Red);

			nChartControl1.Refresh();
		}

		private void FindValue_Click(object sender, System.EventArgs e)
		{
			double dValue;

			try
			{
				dValue = Double.Parse(ValueEdit.Text);
			}
			catch
			{
				return;
			}

			int index = m_Bar.Values.FindValue(dValue);
			if (index == -1)
			{
				MessageBox.Show("The specified value was not found in the bar Values series");
				return;
			}

			m_Bar.FillStyles.Clear();
			m_Bar.FillStyles[index] = new NColorFillStyle(Color.Red);

			nChartControl1.Refresh();
		}

		private void FindString_Click(object sender, System.EventArgs e)
		{
			int index = m_Bar.Labels.FindString(StringEdit.Text);
			if (index == -1)
			{
				MessageBox.Show("The specified string was not found in the bar Labels series");
				return;
			}

			m_Bar.FillStyles.Clear();
			m_Bar.FillStyles[index] = new NColorFillStyle(Color.Red);
			nChartControl1.Refresh();
		}

	}
}