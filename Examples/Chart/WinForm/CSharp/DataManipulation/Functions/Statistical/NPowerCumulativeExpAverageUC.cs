using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Globalization;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Functions;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPowerCumulativeExpAverageUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
		private NLineSeries m_Line;
		private NFunctionCalculator m_FuncCalculator;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NTextBox m_ExpressionLabel;
		private Nevron.UI.WinForm.Controls.NComboBox m_FunctionCombo;
		private Nevron.UI.WinForm.Controls.NButton m_BtnData;
		private Nevron.UI.WinForm.Controls.NHScrollBar m_PowerScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar m_ExpWeightScroll;
		private System.ComponentModel.Container components = null;

		public NPowerCumulativeExpAverageUC()
		{
			InitializeComponent();

			m_FuncCalculator = new NFunctionCalculator();
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
			this.m_ExpressionLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_FunctionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_BtnData = new Nevron.UI.WinForm.Controls.NButton();
			this.m_PowerScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.m_ExpWeightScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_ExpressionLabel
			// 
			this.m_ExpressionLabel.Location = new System.Drawing.Point(6, 88);
			this.m_ExpressionLabel.Name = "m_ExpressionLabel";
			this.m_ExpressionLabel.ReadOnly = true;
			this.m_ExpressionLabel.Size = new System.Drawing.Size(167, 18);
			this.m_ExpressionLabel.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(167, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Expression:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Function:";
			// 
			// m_FunctionCombo
			// 
			this.m_FunctionCombo.ListProperties.CheckBoxDataMember = "";
			this.m_FunctionCombo.ListProperties.DataSource = null;
			this.m_FunctionCombo.ListProperties.DisplayMember = "";
			this.m_FunctionCombo.Location = new System.Drawing.Point(6, 37);
			this.m_FunctionCombo.Name = "m_FunctionCombo";
			this.m_FunctionCombo.Size = new System.Drawing.Size(167, 21);
			this.m_FunctionCombo.TabIndex = 4;
			this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			// 
			// m_BtnData
			// 
			this.m_BtnData.Location = new System.Drawing.Point(6, 240);
			this.m_BtnData.Name = "m_BtnData";
			this.m_BtnData.Size = new System.Drawing.Size(167, 24);
			this.m_BtnData.TabIndex = 8;
			this.m_BtnData.Text = "New Data";
			this.m_BtnData.Click += new System.EventHandler(this.BtnData_Click);
			// 
			// m_PowerScroll
			// 
			this.m_PowerScroll.LargeChange = 1;
			this.m_PowerScroll.Location = new System.Drawing.Point(6, 144);
			this.m_PowerScroll.Maximum = 30;
			this.m_PowerScroll.Minimum = -30;
			this.m_PowerScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.m_PowerScroll.Name = "m_PowerScroll";
			this.m_PowerScroll.Size = new System.Drawing.Size(167, 17);
			this.m_PowerScroll.TabIndex = 9;
			this.m_PowerScroll.Value = 20;
			this.m_PowerScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PowerScroll_Scroll);
			// 
			// m_ExpWeightScroll
			// 
			this.m_ExpWeightScroll.LargeChange = 1;
			this.m_ExpWeightScroll.Location = new System.Drawing.Point(6, 200);
			this.m_ExpWeightScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.m_ExpWeightScroll.Name = "m_ExpWeightScroll";
			this.m_ExpWeightScroll.Size = new System.Drawing.Size(167, 17);
			this.m_ExpWeightScroll.TabIndex = 10;
			this.m_ExpWeightScroll.Value = 50;
			this.m_ExpWeightScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ExpWeightScroll_Scroll);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(167, 16);
			this.label3.TabIndex = 11;
			this.label3.Text = "Power:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 176);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(167, 14);
			this.label4.TabIndex = 12;
			this.label4.Text = "Exponential Weight:";
			// 
			// NPowerCumulativeExpAverageUC
			// 
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_ExpWeightScroll);
			this.Controls.Add(this.m_PowerScroll);
			this.Controls.Add(this.m_BtnData);
			this.Controls.Add(this.m_ExpressionLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_FunctionCombo);
			this.Name = "NPowerCumulativeExpAverageUC";
			this.Size = new System.Drawing.Size(180, 282);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();


			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Power, Cumulative, Exponential Average");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            
			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(75, NRelativeUnit.ParentPercentage));

			// add a line series for the function
			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.MarkerStyle.Visible = true;
			m_Line.MarkerStyle.BorderStyle.Color = Color.DarkGreen;
			m_Line.MarkerStyle.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			m_Line.MarkerStyle.Width = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.Height = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line.MarkerStyle.FillStyle = new NColorFillStyle(Color.Gold);
			m_Line.BorderStyle.Color = Color.DarkGreen;
			m_Line.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			m_Line.Legend.Mode = SeriesLegendMode.None;
			m_Line.DataLabelStyle.Format = "<value>";
			m_Line.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			m_Line.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_Line.ShadowStyle.Offset = new NPointL(2, 2);
			m_Line.ShadowStyle.Color = Color.FromArgb(120, 0, 0, 0);
			m_Line.ShadowStyle.FadeLength = new NLength(5);

			// add the bar series
			m_Bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar.Name = "Bar1";
			m_Bar.Values.Name = "values";
			m_Bar.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			m_Bar.MultiBarMode = MultiBarMode.Series;
			m_Bar.DataLabelStyle.Visible = false;
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bar.BarShape = BarShape.Cylinder;
			m_Bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Bar.FillStyle = new NColorFillStyle(Color.DarkKhaki);
			m_Bar.ShadowStyle.Type = ShadowType.Solid;
			m_Bar.ShadowStyle.Offset = new NPointL(2, 2);
			m_Bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			m_Bar.Values.FillRandomRange(Random, 10, 0, 10);

			m_FuncCalculator.Arguments.Add(m_Bar.Values);

			// form controls
			m_FunctionCombo.Items.Add("Power");
			m_FunctionCombo.Items.Add("Cumulative");
			m_FunctionCombo.Items.Add("Exponential Average");
			m_FunctionCombo.SelectedIndex = 0;
		}

		private void BuildExpression()
		{
			StringBuilder sb = new StringBuilder();

			switch (m_FunctionCombo.SelectedIndex)
			{
				case 0:
					m_PowerScroll.Enabled = true;
					m_ExpWeightScroll.Enabled = false;
					sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "POW(values; {0})",  ((double)m_PowerScroll.Value) / 10);
					break;

				case 1:
					m_PowerScroll.Enabled = false;
					m_ExpWeightScroll.Enabled = false;
					sb.Append("CUMSUM(values)");
					break;

				case 2:
					m_PowerScroll.Enabled = false;
					m_ExpWeightScroll.Enabled = true;
					sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "EXPAVG(values; {0})", ((double)m_ExpWeightScroll.Value) / 100);
					break;
			}

			m_FuncCalculator.Expression = sb.ToString();
			m_ExpressionLabel.Text = m_FuncCalculator.Expression;
		}

		private void CalculateFunction()
		{
			m_Line.Values = m_FuncCalculator.Calculate();
			m_Line.Values.ValueFormatter = new NNumericValueFormatter("0.00");
		}

		private void FunctionCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			BuildExpression();
			CalculateFunction();
			nChartControl1.Refresh();
		}

		private void BtnData_Click(object sender, System.EventArgs e)
		{
			m_Bar.Values.FillRandomRange(Random, 10, 0, 10);

			CalculateFunction();

			nChartControl1.Refresh();
		}

		private void PowerScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			BuildExpression();
			CalculateFunction();
			nChartControl1.Refresh();
		}

		private void ExpWeightScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			BuildExpression();
			CalculateFunction();
			nChartControl1.Refresh();
		}
	}
}