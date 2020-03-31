using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Functions;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NCountStdDevRmsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
		private NFunctionCalculator m_FuncCalculator;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NTextBox m_LabelResult;
		private Nevron.UI.WinForm.Controls.NTextBox m_ExpressionLabel;
		private Nevron.UI.WinForm.Controls.NButton m_BtnData;
		private Nevron.UI.WinForm.Controls.NComboBox m_FunctionCombo;
		private System.ComponentModel.Container components = null;

		public NCountStdDevRmsUC()
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
			this.m_BtnData = new Nevron.UI.WinForm.Controls.NButton();
			this.m_ExpressionLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_FunctionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_LabelResult = new Nevron.UI.WinForm.Controls.NTextBox();
			this.SuspendLayout();
			// 
			// m_BtnData
			// 
			this.m_BtnData.Location = new System.Drawing.Point(9, 200);
			this.m_BtnData.Name = "m_BtnData";
			this.m_BtnData.Size = new System.Drawing.Size(161, 24);
			this.m_BtnData.TabIndex = 13;
			this.m_BtnData.Text = "New Data";
			this.m_BtnData.Click += new System.EventHandler(this.BtnData_Click);
			// 
			// m_ExpressionLabel
			// 
			this.m_ExpressionLabel.Location = new System.Drawing.Point(9, 92);
			this.m_ExpressionLabel.Name = "m_ExpressionLabel";
			this.m_ExpressionLabel.ReadOnly = true;
			this.m_ExpressionLabel.Size = new System.Drawing.Size(161, 18);
			this.m_ExpressionLabel.TabIndex = 12;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(161, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Expression:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(161, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "Function:";
			// 
			// m_FunctionCombo
			// 
			this.m_FunctionCombo.ListProperties.CheckBoxDataMember = "";
			this.m_FunctionCombo.ListProperties.DataSource = null;
			this.m_FunctionCombo.ListProperties.DisplayMember = "";
			this.m_FunctionCombo.Location = new System.Drawing.Point(9, 32);
			this.m_FunctionCombo.Name = "m_FunctionCombo";
			this.m_FunctionCombo.Size = new System.Drawing.Size(161, 21);
			this.m_FunctionCombo.TabIndex = 9;
			this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 133);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(161, 16);
			this.label3.TabIndex = 19;
			this.label3.Text = "Result:";
			// 
			// m_LabelResult
			// 
			this.m_LabelResult.Location = new System.Drawing.Point(9, 152);
			this.m_LabelResult.Name = "m_LabelResult";
			this.m_LabelResult.ReadOnly = true;
			this.m_LabelResult.Size = new System.Drawing.Size(161, 18);
			this.m_LabelResult.TabIndex = 18;
			// 
			// NCountStdDevRmsUC
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_LabelResult);
			this.Controls.Add(this.m_BtnData);
			this.Controls.Add(this.m_ExpressionLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_FunctionCombo);
			this.Name = "NCountStdDevRmsUC";
			this.Size = new System.Drawing.Size(180, 243);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Count, Standard Deviation, RMS");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(75, NRelativeUnit.ParentPercentage));

			// add a constline to diplay the function result
			NAxisConstLine cl = m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add();
			cl.StrokeStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			cl.StrokeStyle.Color = Color.Red;
			cl.Value = 0;

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
			m_Bar.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.DarkSeaGreen, Color.DarkGreen);
			m_Bar.Values.FillRandomRange(Random, 10, 0, 20);

			// add argument
			m_FuncCalculator.Arguments.Add(m_Bar.Values);

			// form controls
			m_FunctionCombo.Items.Add("Count");
			m_FunctionCombo.Items.Add("Standard Deviation");
			m_FunctionCombo.Items.Add("Root Mean Square");
			m_FunctionCombo.SelectedIndex = 0;
		}

		private void BuildExpression()
		{
			switch(m_FunctionCombo.SelectedIndex)
			{
				case 0:
					m_FuncCalculator.Expression = "COUNT(values)";
					break;

				case 1:
					m_FuncCalculator.Expression = "STDDEV(values)";
					break;

				case 2:
					m_FuncCalculator.Expression = "POW(AVERAGE(POW(values; 2)); 0.5)";
					break;

				default:
					Debug.Assert(false);
					return;
			}

			m_ExpressionLabel.Text = m_FuncCalculator.Expression;
		}

		private void CalculateFunction()
		{
			NAxisConstLine cl = (NAxisConstLine)m_Chart.Axis(StandardAxis.PrimaryY).ConstLines[0];
            NDataSeriesDouble ds = m_FuncCalculator.Calculate();

			cl.Value = (double)ds.GetValueForIndex(0);

			m_LabelResult.Text = cl.Value.ToString();
		}

		private void FunctionCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BuildExpression();
			CalculateFunction();
			nChartControl1.Refresh();
		}

		private void BtnData_Click(object sender, System.EventArgs e)
		{
			m_Bar.Values.FillRandomRange(Random, 10, 0, 20);
			CalculateFunction();
			nChartControl1.Refresh();
		}
	}
}