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
	public class NSumElementsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
		private NLineSeries m_Line;
		private NFunctionCalculator m_FuncCalculator;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NButton m_BtnPosNegData;
		private Nevron.UI.WinForm.Controls.NButton m_BtnPosData;
		private Nevron.UI.WinForm.Controls.NTextBox m_ExpressionLabel;
		private Nevron.UI.WinForm.Controls.NComboBox m_GroupingCombo;
		private Nevron.UI.WinForm.Controls.NTextBox m_LabelSum;
		private System.ComponentModel.Container components = null;

		public NSumElementsUC()
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
			this.label3 = new System.Windows.Forms.Label();
			this.m_GroupingCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_BtnPosNegData = new Nevron.UI.WinForm.Controls.NButton();
			this.m_BtnPosData = new Nevron.UI.WinForm.Controls.NButton();
			this.m_ExpressionLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_LabelSum = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(165, 16);
			this.label3.TabIndex = 15;
			this.label3.Text = "Grouping:";
			// 
			// m_GroupingCombo
			// 
			this.m_GroupingCombo.ListProperties.CheckBoxDataMember = "";
			this.m_GroupingCombo.ListProperties.DataSource = null;
			this.m_GroupingCombo.ListProperties.DisplayMember = "";
			this.m_GroupingCombo.Location = new System.Drawing.Point(7, 27);
			this.m_GroupingCombo.Name = "m_GroupingCombo";
			this.m_GroupingCombo.Size = new System.Drawing.Size(165, 21);
			this.m_GroupingCombo.TabIndex = 14;
			this.m_GroupingCombo.SelectedIndexChanged += new System.EventHandler(this.GroupingCombo_SelectedIndexChanged);
			// 
			// m_BtnPosNegData
			// 
			this.m_BtnPosNegData.ButtonProperties.WrapText = true;
			this.m_BtnPosNegData.Location = new System.Drawing.Point(7, 226);
			this.m_BtnPosNegData.Name = "m_BtnPosNegData";
			this.m_BtnPosNegData.Size = new System.Drawing.Size(165, 24);
			this.m_BtnPosNegData.TabIndex = 13;
			this.m_BtnPosNegData.Text = "Positive && Negative Data";
			this.m_BtnPosNegData.Click += new System.EventHandler(this.BtnPosNegData_Click);
			// 
			// m_BtnPosData
			// 
			this.m_BtnPosData.Location = new System.Drawing.Point(7, 195);
			this.m_BtnPosData.Name = "m_BtnPosData";
			this.m_BtnPosData.Size = new System.Drawing.Size(165, 24);
			this.m_BtnPosData.TabIndex = 12;
			this.m_BtnPosData.Text = "Positive Data";
			this.m_BtnPosData.Click += new System.EventHandler(this.BtnPosData_Click);
			// 
			// m_ExpressionLabel
			// 
			this.m_ExpressionLabel.Location = new System.Drawing.Point(7, 82);
			this.m_ExpressionLabel.Name = "m_ExpressionLabel";
			this.m_ExpressionLabel.ReadOnly = true;
			this.m_ExpressionLabel.Size = new System.Drawing.Size(165, 18);
			this.m_ExpressionLabel.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(165, 16);
			this.label2.TabIndex = 10;
			this.label2.Text = "Expression:";
			// 
			// m_LabelSum
			// 
			this.m_LabelSum.Location = new System.Drawing.Point(7, 137);
			this.m_LabelSum.Name = "m_LabelSum";
			this.m_LabelSum.ReadOnly = true;
			this.m_LabelSum.Size = new System.Drawing.Size(165, 18);
			this.m_LabelSum.TabIndex = 16;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(165, 16);
			this.label1.TabIndex = 17;
			this.label1.Text = "Sum:";
			// 
			// NSumElementsUC
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_LabelSum);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_GroupingCombo);
			this.Controls.Add(this.m_BtnPosNegData);
			this.Controls.Add(this.m_BtnPosData);
			this.Controls.Add(this.m_ExpressionLabel);
			this.Controls.Add(this.label2);
			this.Name = "NSumElementsUC";
			this.Size = new System.Drawing.Size(180, 270);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();


			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Sum");
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
			m_Bar.BarShape = BarShape.SmoothEdgeBar;
			m_Bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);;
			m_Bar.FillStyle = new NColorFillStyle(Color.Orange);
			m_Bar.Values.FillRandomRange(Random, 12, 0, 50);

			// set the function argument
			m_FuncCalculator.Arguments.Add(m_Bar.Values);

			// form controls
			m_GroupingCombo.Items.Add("Do not group");
			m_GroupingCombo.Items.Add("Group by every 2 values");
			m_GroupingCombo.Items.Add("Group by every 3 values");
			m_GroupingCombo.Items.Add("Group by every 4 values");
			m_GroupingCombo.SelectedIndex = 0;
		}

		private void CalcFunction()
		{
			StringBuilder sb = new StringBuilder("SUM(values");

			switch(m_GroupingCombo.SelectedIndex)
			{
				case 0:
					sb.Append(")");
					break;
				case 1:
					sb.Append("; 2)");
					break;
				case 2:
					sb.Append("; 3)");
					break;
				case 3:
					sb.Append("; 4)");
					break;
				default:
					Debug.Assert(false);
					return;
			}

			m_FuncCalculator.Expression = sb.ToString();
			m_ExpressionLabel.Text = m_FuncCalculator.Expression;

			if(m_GroupingCombo.SelectedIndex == 0)
			{
				// draw a constline if there is no grouping
				SetConstline();
			}
			else
			{
				// otherwise use the line series
				m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Clear();

				m_Line.Values = m_FuncCalculator.Calculate();
				m_Line.Values.ValueFormatter = new NNumericValueFormatter("0.00");
				m_Line.Visible = true;

				m_LabelSum.Text = "";
			}

			nChartControl1.Refresh();
		}

		private void SetConstline()
		{
			NAxis axis = m_Chart.Axis(StandardAxis.PrimaryY);

			// add a constline if necessary
			if(axis.ConstLines.Count == 0)
			{
				axis.ConstLines.Add();
			}

			// the line series won't be used
			m_Line.Visible = false;

			// calc the sum of the elements
			NDataSeriesDouble ds = m_FuncCalculator.Calculate();

			// add a new constline
			NAxisConstLine cl = (NAxisConstLine)axis.ConstLines[0];
			cl.StrokeStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			cl.StrokeStyle.Color = Color.Red;
			cl.Value = (double)ds.GetValueForIndex(0);

			m_LabelSum.Text = cl.Value.ToString();

			// set proper scale for the axis, so that it includes the constline
			if(cl.Value >= 0)
			{
				// if the sum is positive - compare it to the largest value
				m_FuncCalculator.Expression = "MAX(values)";
				ds = m_FuncCalculator.Calculate();

				double dMax = (double)ds.GetValueForIndex(0);

				if(cl.Value > dMax)
					dMax = cl.Value;

				axis.View = new NRangeAxisView(new NRange1DD(0, dMax), false, true);
			}
			else
			{
				// if the sum is negative - compare it to the smallest value
				m_FuncCalculator.Expression = "MIN(values)";
				ds = m_FuncCalculator.Calculate();

				double dMin = (double)ds.GetValueForIndex(0);

				if(cl.Value < dMin)
					dMin = cl.Value;

				axis.View = new NRangeAxisView(new NRange1DD(dMin, 0), true, false);
			}
		}

		private void GroupingCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CalcFunction();
		}

		private void BtnPosData_Click(object sender, System.EventArgs e)
		{
			m_Bar.Values.FillRandomRange(Random, 12, 0, 50);

			CalcFunction();
		}

		private void BtnPosNegData_Click(object sender, System.EventArgs e)
		{
			m_Bar.Values.FillRandomRange(Random, 12, -25, 25);

			CalcFunction();		
		}
	}
}