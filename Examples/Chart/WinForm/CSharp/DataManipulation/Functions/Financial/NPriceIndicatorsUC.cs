using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.Diagnostics;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPriceIndicatorsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NStockSeries m_Stock;
		private NLineSeries m_Line;
		private NFunctionCalculator m_Function;
		private Nevron.UI.WinForm.Controls.NComboBox m_FunctionCombo;
		private Nevron.UI.WinForm.Controls.NTextBox m_ExpressionLabel;
		private Nevron.UI.WinForm.Controls.NButton m_NewDataBtn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.ComponentModel.Container components = null;

		public NPriceIndicatorsUC()
		{
			InitializeComponent();

			m_Function = new NFunctionCalculator();
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
			this.m_FunctionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_ExpressionLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_NewDataBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(169, 16);
			this.label3.TabIndex = 21;
			this.label3.Text = "Function:";
			// 
			// m_FunctionCombo
			// 
			this.m_FunctionCombo.ListProperties.CheckBoxDataMember = "";
			this.m_FunctionCombo.ListProperties.DataSource = null;
			this.m_FunctionCombo.ListProperties.DisplayMember = "";
			this.m_FunctionCombo.Location = new System.Drawing.Point(6, 30);
			this.m_FunctionCombo.Name = "m_FunctionCombo";
			this.m_FunctionCombo.Size = new System.Drawing.Size(169, 21);
			this.m_FunctionCombo.TabIndex = 20;
			this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			// 
			// m_ExpressionLabel
			// 
			this.m_ExpressionLabel.Location = new System.Drawing.Point(6, 93);
			this.m_ExpressionLabel.Name = "m_ExpressionLabel";
			this.m_ExpressionLabel.ReadOnly = true;
			this.m_ExpressionLabel.Size = new System.Drawing.Size(169, 18);
			this.m_ExpressionLabel.TabIndex = 19;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(169, 16);
			this.label2.TabIndex = 18;
			this.label2.Text = "Expression:";
			// 
			// m_NewDataBtn
			// 
			this.m_NewDataBtn.Location = new System.Drawing.Point(6, 144);
			this.m_NewDataBtn.Name = "m_NewDataBtn";
			this.m_NewDataBtn.Size = new System.Drawing.Size(169, 22);
			this.m_NewDataBtn.TabIndex = 17;
			this.m_NewDataBtn.Text = "New Data";
			this.m_NewDataBtn.Click += new System.EventHandler(this.NewDataBtn_Click);
			// 
			// NPriceIndicatorsUC
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_FunctionCombo);
			this.Controls.Add(this.m_ExpressionLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_NewDataBtn);
			this.Name = "NPriceIndicatorsUC";
			this.Size = new System.Drawing.Size(180, 190);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Price Indicators");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(75, NRelativeUnit.ParentPercentage));

			// setup X axis
			NRangeTimelineScaleConfigurator scaleX = new NRangeTimelineScaleConfigurator();
			scaleX.FirstRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.FirstRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(225, 225, 225));
			scaleX.FirstRow.UseGridStyle = true;
			scaleX.SecondRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.SecondRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(215, 215, 215));
			scaleX.SecondRow.UseGridStyle = true;
			scaleX.ThirdRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.ThirdRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(205, 205, 205));
			scaleX.ThirdRow.UseGridStyle = true;
			// calendar
			NWeekDayRule wdr = new NWeekDayRule(WeekDayBit.All);
			wdr.Saturday = false;
			wdr.Sunday = false;
			scaleX.Calendar.Rules.Add(wdr);
			scaleX.EnableCalendar = true;
			// set configurator
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Y axis
			NAxis axis = m_Chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			linearScale.InnerMajorTickStyle.Length = new NLength(0);

			// line series for the function
			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.DataLabelStyle.Visible = false;
			m_Line.BorderStyle.Color = Color.Red;
			m_Line.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			m_Line.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_Line.UseXValues = true;

			Color customColor = Color.FromArgb(100, 100, 150);

			// setup the stock series
			m_Stock = (NStockSeries)m_Chart.Series.Add(SeriesType.Stock);
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Stick;
			m_Stock.HighLowStrokeStyle.Color = customColor;
			m_Stock.UpStrokeStyle.Color = customColor;
			m_Stock.DownStrokeStyle.Color = customColor;
			m_Stock.UpFillStyle = new NColorFillStyle(Color.White);
			m_Stock.DownFillStyle = new NColorFillStyle(customColor);
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.OpenValues.Name = "open";
			m_Stock.HighValues.Name = "high";
			m_Stock.LowValues.Name = "low";
			m_Stock.CloseValues.Name = "close";
			m_Stock.CandleWidth = new NLength(1, NRelativeUnit.ParentPercentage);
			m_Stock.InflateMargins = true;
			m_Stock.UseXValues = true;

			GenerateData();

			m_FunctionCombo.Items.Add("Median Price");
			m_FunctionCombo.Items.Add("Typical Price");
			m_FunctionCombo.Items.Add("Weighted Close");
			m_FunctionCombo.SelectedIndex = 0;
		}

		private void GenerateData()
		{
			const double initialPrice = 100;
			const int numDataPoits = 50;

			GenerateOHLCData(m_Stock, initialPrice, numDataPoits);
			FillStockDates(m_Stock, numDataPoits, new DateTime(2010, 1, 11));
		}

		private void UpdateFunctionLine()
		{
			BuildExpression();
			m_Line.Values = m_Function.Calculate();
			m_Line.XValues.Clear();
			m_Line.XValues.AddRange(m_Stock.XValues);
		}

		private void BuildExpression()
		{
			StringBuilder sb = new StringBuilder();

			m_Function.Arguments.Clear();

			switch(m_FunctionCombo.SelectedIndex)
			{
				case 0:
					sb.AppendFormat("MEDIANPRICE({0}; {1})", m_Stock.HighValues.Name, m_Stock.LowValues.Name);
					m_Line.Name = "Median Price";
					break;

				case 1:
					sb.AppendFormat("TYPICALPRICE({0}; {1}; {2})", m_Stock.CloseValues.Name, m_Stock.HighValues.Name, m_Stock.LowValues.Name);
					m_Line.Name = "Typical Price";
					break;

				case 2:
					sb.AppendFormat("WEIGHTEDCLOSE({0}; {1}; {2})", m_Stock.CloseValues.Name, m_Stock.HighValues.Name, m_Stock.LowValues.Name);
					m_Line.Name = "Weighted Close";
					break;

				default:
					Debug.Assert(false);
					return;
			}

			m_Function.Expression = sb.ToString();
			m_Function.Arguments.Clear();
			m_Function.Arguments.Add(m_Stock.CloseValues);
			m_Function.Arguments.Add(m_Stock.HighValues);
			m_Function.Arguments.Add(m_Stock.LowValues);

			// form controls
			m_ExpressionLabel.Text = m_Function.Expression;
		}

		private void FunctionCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateFunctionLine();
			nChartControl1.Refresh();
		}

		private void NewDataBtn_Click(object sender, System.EventArgs e)
		{
			GenerateData();
			UpdateFunctionLine();
			nChartControl1.Refresh();
		}
	}
}