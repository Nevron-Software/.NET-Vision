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
	public class NAverageMedianMinMaxUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
		private NLineSeries m_Line;
		private NFunctionCalculator m_FuncCalculator;
		private bool m_bSkipUpdate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NTextBox m_ExpressionLabel;
		private Nevron.UI.WinForm.Controls.NButton m_BtnPosData;
		private Nevron.UI.WinForm.Controls.NButton m_BtnPosNegData;
		private Nevron.UI.WinForm.Controls.NComboBox m_GroupingCombo;
		private Nevron.UI.WinForm.Controls.NComboBox m_FunctionCombo;
		private System.ComponentModel.Container components = null;

		public NAverageMedianMinMaxUC()
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
			this.m_FunctionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_ExpressionLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.m_BtnPosData = new Nevron.UI.WinForm.Controls.NButton();
			this.m_BtnPosNegData = new Nevron.UI.WinForm.Controls.NButton();
			this.m_GroupingCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_FunctionCombo
			// 
			this.m_FunctionCombo.ListProperties.CheckBoxDataMember = "";
			this.m_FunctionCombo.ListProperties.DataSource = null;
			this.m_FunctionCombo.ListProperties.DisplayMember = "";
			this.m_FunctionCombo.Location = new System.Drawing.Point(4, 26);
			this.m_FunctionCombo.Name = "m_FunctionCombo";
			this.m_FunctionCombo.Size = new System.Drawing.Size(170, 21);
			this.m_FunctionCombo.TabIndex = 0;
			this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.m_FunctionCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(170, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Function:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(170, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Expression:";
			// 
			// m_ExpressionLabel
			// 
			this.m_ExpressionLabel.Location = new System.Drawing.Point(4, 122);
			this.m_ExpressionLabel.Name = "m_ExpressionLabel";
			this.m_ExpressionLabel.ReadOnly = true;
			this.m_ExpressionLabel.Size = new System.Drawing.Size(170, 18);
			this.m_ExpressionLabel.TabIndex = 3;
			// 
			// m_BtnPosData
			// 
			this.m_BtnPosData.Location = new System.Drawing.Point(4, 162);
			this.m_BtnPosData.Name = "m_BtnPosData";
			this.m_BtnPosData.Size = new System.Drawing.Size(170, 24);
			this.m_BtnPosData.TabIndex = 4;
			this.m_BtnPosData.Text = "Positive Data";
			this.m_BtnPosData.Click += new System.EventHandler(this.m_BtnPosData_Click);
			// 
			// m_BtnPosNegData
			// 
			this.m_BtnPosNegData.ButtonProperties.WrapText = true;
			this.m_BtnPosNegData.Location = new System.Drawing.Point(4, 194);
			this.m_BtnPosNegData.Name = "m_BtnPosNegData";
			this.m_BtnPosNegData.Size = new System.Drawing.Size(170, 24);
			this.m_BtnPosNegData.TabIndex = 5;
			this.m_BtnPosNegData.Text = "Positive && Negative Data";
			this.m_BtnPosNegData.Click += new System.EventHandler(this.m_BtnPosNegData_Click);
			// 
			// m_GroupingCombo
			// 
			this.m_GroupingCombo.ListProperties.CheckBoxDataMember = "";
			this.m_GroupingCombo.ListProperties.DataSource = null;
			this.m_GroupingCombo.ListProperties.DisplayMember = "";
			this.m_GroupingCombo.Location = new System.Drawing.Point(4, 74);
			this.m_GroupingCombo.Name = "m_GroupingCombo";
			this.m_GroupingCombo.Size = new System.Drawing.Size(170, 21);
			this.m_GroupingCombo.TabIndex = 6;
			this.m_GroupingCombo.SelectedIndexChanged += new System.EventHandler(this.m_GroupingCombo_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(170, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Grouping:";
			// 
			// NAverageMedianMinMaxUC
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_GroupingCombo);
			this.Controls.Add(this.m_BtnPosNegData);
			this.Controls.Add(this.m_BtnPosData);
			this.Controls.Add(this.m_ExpressionLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_FunctionCombo);
			this.Name = "NAverageMedianMinMaxUC";
			this.Size = new System.Drawing.Size(180, 232);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Average, Median, Min, Max");
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
			m_Line.MarkerStyle.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_Line.MarkerStyle.FillStyle = new NColorFillStyle(Color.Crimson);
			m_Line.BorderStyle.Color = Color.Red;
			m_Line.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			m_Line.Legend.Mode = SeriesLegendMode.None;
			m_Line.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			m_Line.DisplayOnAxis(StandardAxis.PrimaryX, false);
			m_Line.DisplayOnAxis(StandardAxis.SecondaryX, true);

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
			m_Bar.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.LightSteelBlue, Color.MidnightBlue);
			m_Bar.Values.FillRandomRange(Random, 12, 0, 50);

			// form controls
			m_bSkipUpdate = true;
			m_FunctionCombo.Items.Add("Average");
			m_FunctionCombo.Items.Add("Median");
			m_FunctionCombo.Items.Add("Min");
			m_FunctionCombo.Items.Add("Max");
			m_FunctionCombo.SelectedIndex = 0;

			m_GroupingCombo.Items.Add("Do not group");
			m_GroupingCombo.Items.Add("Group by every 2 values");
			m_GroupingCombo.Items.Add("Group by every 3 values");
			m_GroupingCombo.Items.Add("Group by every 4 values");
			m_GroupingCombo.SelectedIndex = 0;
			m_bSkipUpdate = false;

			m_FunctionCombo_SelectedIndexChanged(null, null);
		}

		private void BuildExpression()
		{
			StringBuilder expr = new StringBuilder();

			// set the beginning of the expression according to the selected function
			switch(m_FunctionCombo.SelectedIndex)
			{
				case 0:
					expr.Append("AVERAGE(");
					break;
				case 1:
					expr.Append("MEDIAN(");
					break;
				case 2:
					expr.Append("MIN(");
					break;
				case 3:
					expr.Append("MAX(");
					break;
				default:
					Debug.Assert(false);
					return;
			}

			// append the first parameter
			expr.Append(m_Bar.Values.Name);

			// append the second parameter if needed
			switch(m_GroupingCombo.SelectedIndex)
			{
				case 0:
					expr.Append(")");
					break;
				case 1:
					expr.Append("; 2)");
					break;
				case 2:
					expr.Append("; 3)");
					break;
				case 3:
					expr.Append("; 4)");
					break;
				default:
					Debug.Assert(false);
					return;
			}

			m_ExpressionLabel.Text = expr.ToString();

			// update the function calculator
			m_FuncCalculator.Arguments.Clear();
			m_FuncCalculator.Arguments.Add(m_Bar.Values);
			m_FuncCalculator.Expression = m_ExpressionLabel.Text;
		}

		private void CalcFunction()
		{
            NDataSeriesDouble ds = m_FuncCalculator.Calculate();

			if(ds == null)
				return;

			m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Clear();
			m_Line.Visible = false;

			if(m_GroupingCombo.SelectedIndex == 0)
			{
				// add a constline if there is no grouping
				NAxisConstLine cl = m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add();
				cl.StrokeStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
				cl.StrokeStyle.Color = Color.Red;
				cl.Value = (double)ds.GetValueForIndex(0);
			}
			else
			{
				m_Line.Visible = true;
				m_Line.Values = ds;
				m_Line.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			}

			nChartControl1.Refresh();
		}

		private void m_FunctionCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			BuildExpression();
			CalcFunction();
		}

		private void m_GroupingCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_bSkipUpdate)
				return;

			BuildExpression();
			CalcFunction();
		}
		
		private void m_BtnPosData_Click(object sender, System.EventArgs e)
		{
			m_Bar.Values.FillRandomRange(Random, 12, 0, 50);

			CalcFunction();
		}

		private void m_BtnPosNegData_Click(object sender, System.EventArgs e)
		{
			m_Bar.Values.FillRandomRange(Random, 12, -25, 25);

			CalcFunction();
		}
	}
}