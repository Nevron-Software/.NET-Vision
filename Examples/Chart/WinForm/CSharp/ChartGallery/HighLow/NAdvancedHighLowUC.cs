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
	public class NAdvancedHighLowUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NHighLowSeries m_HighLow;
		private Nevron.UI.WinForm.Controls.NTextBox HighLabel;
		private Nevron.UI.WinForm.Controls.NTextBox LowLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NButton ChangeValues;
		private Nevron.UI.WinForm.Controls.NButton ChangeXValues;
		private Nevron.UI.WinForm.Controls.NCheckBox DropLinesCheck;
		private System.ComponentModel.Container components = null;

		public NAdvancedHighLowUC()
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
			this.ChangeValues = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeXValues = new Nevron.UI.WinForm.Controls.NButton();
			this.HighLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.LowLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.DropLinesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ChangeValues
			// 
			this.ChangeValues.Location = new System.Drawing.Point(8, 8);
			this.ChangeValues.Name = "ChangeValues";
			this.ChangeValues.Size = new System.Drawing.Size(163, 27);
			this.ChangeValues.TabIndex = 0;
			this.ChangeValues.Text = "Change Values";
			this.ChangeValues.Click += new System.EventHandler(this.ChangeValues_Click);
			// 
			// ChangeXValues
			// 
			this.ChangeXValues.Location = new System.Drawing.Point(8, 41);
			this.ChangeXValues.Name = "ChangeXValues";
			this.ChangeXValues.Size = new System.Drawing.Size(163, 27);
			this.ChangeXValues.TabIndex = 1;
			this.ChangeXValues.Text = "Change X Values";
			this.ChangeXValues.Click += new System.EventHandler(this.ChangeXValues_Click);
			// 
			// HighLabel
			// 
			this.HighLabel.Location = new System.Drawing.Point(8, 102);
			this.HighLabel.Name = "HighLabel";
			this.HighLabel.Size = new System.Drawing.Size(163, 18);
			this.HighLabel.TabIndex = 2;
			this.HighLabel.Text = "high";
			this.HighLabel.TextChanged += new System.EventHandler(this.HighLabel_TextChanged);
			// 
			// LowLabel
			// 
			this.LowLabel.Location = new System.Drawing.Point(8, 158);
			this.LowLabel.Name = "LowLabel";
			this.LowLabel.Size = new System.Drawing.Size(163, 18);
			this.LowLabel.TabIndex = 3;
			this.LowLabel.Text = "low";
			this.LowLabel.TextChanged += new System.EventHandler(this.LowLabel_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(163, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "High Label:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 140);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(163, 15);
			this.label2.TabIndex = 5;
			this.label2.Text = "Low Label:";
			// 
			// DropLinesCheck
			// 
			this.DropLinesCheck.ButtonProperties.BorderOffset = 2;
			this.DropLinesCheck.Location = new System.Drawing.Point(8, 209);
			this.DropLinesCheck.Name = "DropLinesCheck";
			this.DropLinesCheck.Size = new System.Drawing.Size(163, 21);
			this.DropLinesCheck.TabIndex = 41;
			this.DropLinesCheck.Text = "Drop Lines";
			this.DropLinesCheck.CheckedChanged += new System.EventHandler(this.DropLinesCheck_CheckedChanged);
			// 
			// NAdvancedHighLowUC
			// 
			this.Controls.Add(this.DropLinesCheck);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LowLabel);
			this.Controls.Add(this.HighLabel);
			this.Controls.Add(this.ChangeXValues);
			this.Controls.Add(this.ChangeValues);
			this.Name = "NAdvancedHighLowUC";
			this.Size = new System.Drawing.Size(180, 252);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Advanced High Low Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// create the series
			m_HighLow = (NHighLowSeries)m_Chart.Series.Add(SeriesType.HighLow);
			m_HighLow.Name = "High-Low Series";
			m_HighLow.HighFillStyle = new NColorFillStyle(GreyBlue);
			m_HighLow.LowFillStyle = new NColorFillStyle(DarkOrange);
			m_HighLow.UseXValues = true;
			m_HighLow.DataLabelStyle.Format = "<high_label><low_label>";
			m_HighLow.Legend.Mode = SeriesLegendMode.SeriesLogic; 

			// fill with values
			GenerateValuesY(8);
			GenerateValuesX(8);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);
		}

		private void GenerateValuesY(int nCount)
		{
			double dPhase1 = Random.Next(5);
			double dPhase2 = dPhase1 + 1;

			m_HighLow.HighValues.Clear();
			m_HighLow.LowValues.Clear();

			for(int i = 0; i < nCount; i++)
			{
				double d1 = 10 + Math.Sin(dPhase1 + 0.8 * i) + 0.5 * Random.NextDouble();
				double d2 = 10 + Math.Cos(dPhase2 + 0.8 * i) + 0.5 * Random.NextDouble();

				m_HighLow.HighValues.Add(d1);
				m_HighLow.LowValues.Add(d2);
			}
		}
		private void GenerateValuesX(int nCount)
		{
			m_HighLow.XValues.Clear();

			double dValue = (double)Random.Next(100);

			for(int i = 0; i < nCount; i++)
			{
				m_HighLow.XValues.Add(dValue);
				
				dValue = dValue + Random.Next(5, 10);
			}
		}

		private void ChangeValues_Click(object sender, System.EventArgs e)
		{
			GenerateValuesY(8);

			nChartControl1.Refresh();
		}
		private void ChangeXValues_Click(object sender, System.EventArgs e)
		{
			GenerateValuesX(8);

			nChartControl1.Refresh();
		}
		private void HighLabel_TextChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_HighLow.HighLabel = HighLabel.Text;
			nChartControl1.Refresh();
		}
		private void LowLabel_TextChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_HighLow.LowLabel = LowLabel.Text;
			nChartControl1.Refresh();
		}
		private void DropLinesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_HighLow.DropLines = DropLinesCheck.Checked;
			nChartControl1.Refresh();
		}
	}
}
