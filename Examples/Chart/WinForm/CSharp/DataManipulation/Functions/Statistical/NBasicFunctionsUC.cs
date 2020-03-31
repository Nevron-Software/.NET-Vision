using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NBasicFunctionsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NLineSeries m_Line;
		private NBarSeries m_Bar1;
		private NBarSeries m_Bar2;
		private NFunctionCalculator m_FuncCalculator;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NButton m_BtnNewData;
		private Nevron.UI.WinForm.Controls.NComboBox m_ExpressionCombo;
		private System.ComponentModel.Container components = null;

		public NBasicFunctionsUC()
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
			this.label1 = new System.Windows.Forms.Label();
			this.m_ExpressionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_BtnNewData = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(164, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Function Expression:";
			// 
			// m_ExpressionCombo
			// 
			this.m_ExpressionCombo.ListProperties.CheckBoxDataMember = "";
			this.m_ExpressionCombo.ListProperties.DataSource = null;
			this.m_ExpressionCombo.ListProperties.DisplayMember = "";
			this.m_ExpressionCombo.Location = new System.Drawing.Point(8, 24);
			this.m_ExpressionCombo.Name = "m_ExpressionCombo";
			this.m_ExpressionCombo.Size = new System.Drawing.Size(164, 21);
			this.m_ExpressionCombo.TabIndex = 2;
			this.m_ExpressionCombo.SelectedIndexChanged += new System.EventHandler(this.ExpressionCombo_SelectedIndexChanged);
			// 
			// m_BtnNewData
			// 
			this.m_BtnNewData.Location = new System.Drawing.Point(8, 71);
			this.m_BtnNewData.Name = "m_BtnNewData";
			this.m_BtnNewData.Size = new System.Drawing.Size(164, 24);
			this.m_BtnNewData.TabIndex = 3;
			this.m_BtnNewData.Text = "New Data";
			this.m_BtnNewData.Click += new System.EventHandler(this.BtnNewData_Click);
			// 
			// NBasicFunctionsUC
			// 
			this.Controls.Add(this.m_BtnNewData);
			this.Controls.Add(this.m_ExpressionCombo);
			this.Controls.Add(this.label1);
			this.Name = "NBasicFunctionsUC";
			this.Size = new System.Drawing.Size(180, 153);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Basic Functions");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			m_Chart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(67, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));

			// add a line series for the function
			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.Name = "Function";
			m_Line.DataLabelStyle.Format = "<value>";
			m_Line.Legend.Mode = SeriesLegendMode.Series;
			m_Line.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			m_Line.BorderStyle.Color = Color.Red;
			m_Line.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			m_Line.MarkerStyle.Visible = true;
			m_Line.MarkerStyle.BorderStyle.Color = Color.Red;
			m_Line.MarkerStyle.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line.MarkerStyle.FillStyle = new NColorFillStyle(Color.Gold);
			m_Line.MarkerStyle.Width = new NLength(2, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.Height = new NLength(2, NRelativeUnit.ParentPercentage);
			m_Line.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_Line.ShadowStyle.Offset = new NPointL(2, 2);
			m_Line.ShadowStyle.Color = Color.FromArgb(88, 0, 0, 0);
			m_Line.ShadowStyle.FadeLength = new NLength(5);

			// add the first bar
			m_Bar1 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar1.Name = "Bar1";
			m_Bar1.Values.Name = "Green";
			m_Bar1.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			m_Bar1.MultiBarMode = MultiBarMode.Series;
			m_Bar1.DataLabelStyle.Visible = false;
			m_Bar1.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bar1.FillStyle = new NColorFillStyle(Color.FromArgb(80, Color.SeaGreen));
			m_Bar1.BorderStyle.Width = new NLength(1, NGraphicsUnit.Pixel);
			m_Bar1.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_Bar1.ShadowStyle.Offset = new NPointL(3, 3);
			m_Bar1.ShadowStyle.Color = Color.FromArgb(88, 0, 0, 0);
			m_Bar1.ShadowStyle.FadeLength = new NLength(3);

			// add the second bar
			m_Bar2 = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar2.Name = "Bar2";
			m_Bar2.Values.Name = "Blue";
			m_Bar2.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			m_Bar2.MultiBarMode = MultiBarMode.Clustered;
			m_Bar2.DataLabelStyle.Visible = false;
			m_Bar2.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bar2.FillStyle = new NColorFillStyle(Color.FromArgb(80, Color.CornflowerBlue));
			m_Bar2.BorderStyle.Width = new NLength(1, NGraphicsUnit.Pixel);
			m_Bar2.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_Bar2.ShadowStyle.Offset = new NPointL(3, 3);
			m_Bar2.ShadowStyle.Color = Color.FromArgb(88, 0, 0, 0);
			m_Bar2.ShadowStyle.FadeLength = new NLength(3);

			// fill with random data
			FillDataSeries(m_Bar1.Values, 5);
			FillDataSeries(m_Bar2.Values, 5);

			// form controls
			m_ExpressionCombo.Items.Add("ADD(Green; Blue)");
			m_ExpressionCombo.Items.Add("SUB(Green; Blue)");
			m_ExpressionCombo.Items.Add("MUL(Green; Blue)");
			m_ExpressionCombo.Items.Add("DIV(Green; Blue)");
			m_ExpressionCombo.Items.Add("HIGH(Green; Blue)");
			m_ExpressionCombo.Items.Add("LOW(Green; Blue)");
			m_ExpressionCombo.SelectedIndex = 0;
		}


		private void FillDataSeries(NDataSeriesDouble ds, int nCount)
		{
			ds.Clear();

			for(int i = 0; i < nCount; i++)
			{
				ds.Add(Random.NextDouble() * 3);
			}
		}

		private void UpdateFunctionLine()
		{
            NDataSeriesDouble ds = m_FuncCalculator.Calculate();

			if(ds == null)
			{
				m_Line.Values.Clear();
			}
			else
			{
				m_Line.Values = ds;
				m_Line.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			}

			nChartControl1.Refresh();
		}

		private void ExpressionCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_FuncCalculator.Arguments.Clear();
			m_FuncCalculator.Arguments.Add(m_Bar1.Values);
			m_FuncCalculator.Arguments.Add(m_Bar2.Values);
			m_FuncCalculator.Expression = (string)m_ExpressionCombo.SelectedItem;

			UpdateFunctionLine();
		}

		private void BtnNewData_Click(object sender, System.EventArgs e)
		{
			FillDataSeries(m_Bar1.Values, 5);
			FillDataSeries(m_Bar2.Values, 5);

			UpdateFunctionLine();
		}
	}
}