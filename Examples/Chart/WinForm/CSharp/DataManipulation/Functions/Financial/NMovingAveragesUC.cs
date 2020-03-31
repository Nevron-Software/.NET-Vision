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
	public class NMovingAveragesUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NComboBox m_FunctionCombo;
		private Nevron.UI.WinForm.Controls.NComboBox m_ApplyToCombo;
		private Nevron.UI.WinForm.Controls.NTextBox m_ExpressionLabel;
		private Nevron.UI.WinForm.Controls.NButton m_NewDataBtn;
		private Nevron.UI.WinForm.Controls.NTextBox m_PeriodLabel;
		private Nevron.UI.WinForm.Controls.NHScrollBar m_PeriodScroll;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private NChart m_Chart;
		private NStockSeries m_Stock;
		private NLineSeries m_Line;
		private NFunctionCalculator m_Function;
		private bool m_bSkipUpdate;

		public NMovingAveragesUC()
		{
			InitializeComponent();

			m_Function = new NFunctionCalculator();

			m_ApplyToCombo.Items.Add("Open Values");
			m_ApplyToCombo.Items.Add("High Values");
			m_ApplyToCombo.Items.Add("Low Values");
			m_ApplyToCombo.Items.Add("Close Values");
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
			this.m_PeriodLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.m_PeriodScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.m_ApplyToCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
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
			this.m_ExpressionLabel.Location = new System.Drawing.Point(6, 140);
			this.m_ExpressionLabel.Name = "m_ExpressionLabel";
			this.m_ExpressionLabel.ReadOnly = true;
			this.m_ExpressionLabel.Size = new System.Drawing.Size(169, 18);
			this.m_ExpressionLabel.TabIndex = 19;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 116);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(169, 16);
			this.label2.TabIndex = 18;
			this.label2.Text = "Expression:";
			// 
			// m_NewDataBtn
			// 
			this.m_NewDataBtn.Location = new System.Drawing.Point(6, 242);
			this.m_NewDataBtn.Name = "m_NewDataBtn";
			this.m_NewDataBtn.Size = new System.Drawing.Size(169, 22);
			this.m_NewDataBtn.TabIndex = 17;
			this.m_NewDataBtn.Text = "New Data";
			this.m_NewDataBtn.Click += new System.EventHandler(this.NewDataBtn_Click);
			// 
			// m_PeriodLabel
			// 
			this.m_PeriodLabel.Location = new System.Drawing.Point(126, 198);
			this.m_PeriodLabel.Name = "m_PeriodLabel";
			this.m_PeriodLabel.ReadOnly = true;
			this.m_PeriodLabel.Size = new System.Drawing.Size(49, 18);
			this.m_PeriodLabel.TabIndex = 16;
			// 
			// m_PeriodScroll
			// 
			this.m_PeriodScroll.LargeChange = 1;
			this.m_PeriodScroll.Location = new System.Drawing.Point(6, 198);
			this.m_PeriodScroll.Maximum = 50;
			this.m_PeriodScroll.Minimum = 1;
			this.m_PeriodScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.m_PeriodScroll.Name = "m_PeriodScroll";
			this.m_PeriodScroll.Size = new System.Drawing.Size(124, 18);
			this.m_PeriodScroll.TabIndex = 15;
			this.m_PeriodScroll.Value = 10;
			this.m_PeriodScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PeriodScroll_Scroll);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 178);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 14);
			this.label1.TabIndex = 14;
			this.label1.Text = "Period:";
			// 
			// m_ApplyToCombo
			// 
			this.m_ApplyToCombo.ListProperties.CheckBoxDataMember = "";
			this.m_ApplyToCombo.ListProperties.DataSource = null;
			this.m_ApplyToCombo.ListProperties.DisplayMember = "";
			this.m_ApplyToCombo.Location = new System.Drawing.Point(6, 83);
			this.m_ApplyToCombo.Name = "m_ApplyToCombo";
			this.m_ApplyToCombo.Size = new System.Drawing.Size(169, 21);
			this.m_ApplyToCombo.TabIndex = 22;
			this.m_ApplyToCombo.SelectedIndexChanged += new System.EventHandler(this.ApplyToCombo_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 63);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(169, 16);
			this.label4.TabIndex = 23;
			this.label4.Text = "Apply Function To:";
			// 
			// NMovingAveragesUC
			// 
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_ApplyToCombo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_FunctionCombo);
			this.Controls.Add(this.m_ExpressionLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_NewDataBtn);
			this.Controls.Add(this.m_PeriodLabel);
			this.Controls.Add(this.m_PeriodScroll);
			this.Controls.Add(this.label1);
			this.Name = "NMovingAveragesUC";
			this.Size = new System.Drawing.Size(180, 306);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Moving Averages");
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
			m_Line.BorderStyle.Color = Color.Crimson;
			m_Line.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			m_Line.UseXValues = true;

			Color customColor = Color.FromArgb(100, 100, 150);

			// setup the stock series
			m_Stock = (NStockSeries)m_Chart.Series.Add(SeriesType.Stock);
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Bar;
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

			// form controls
			m_bSkipUpdate = true;
			m_ApplyToCombo.SelectedIndex = 3;
			m_bSkipUpdate = false;

			m_FunctionCombo.Items.Add("Simple Moving Average");
			m_FunctionCombo.Items.Add("Weighted Moving Average");
			m_FunctionCombo.Items.Add("Exponential Moving Average");
			m_FunctionCombo.Items.Add("Modified Moving Average");
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
            NDataSeriesDouble arg;
			StringBuilder sb = new StringBuilder();
			int nPeriod = m_PeriodScroll.Value;

			switch(m_ApplyToCombo.SelectedIndex)
			{
				case 0:
					arg = m_Stock.OpenValues;
					break;

				case 1:
					arg = m_Stock.HighValues;
					break;

				case 2:
					arg = m_Stock.LowValues;
					break;

				case 3:
					arg = m_Stock.CloseValues;
					break;

				default:
					Debug.Assert(false);
					return;
			}

			switch(m_FunctionCombo.SelectedIndex)
			{
				case 0:
					sb.AppendFormat("SMA({0}; {1})", arg.Name, nPeriod);
					m_Line.Name = "Simple Moving Average";
					break;

				case 1:
					sb.AppendFormat("WMA({0}; {1})", arg.Name, nPeriod);
					m_Line.Name = "Weighted Moving Average";
					break;

				case 2:
					sb.AppendFormat("EMA({0}; {1})", arg.Name, nPeriod);
					m_Line.Name = "Exponential Moving Average";
					break;

				case 3:
					sb.AppendFormat("MMA({0}; {1})", arg.Name, nPeriod);
					m_Line.Name = "Modified Moving Average";
					break;

				default:
					Debug.Assert(false);
					return;
			}

			m_Function.Arguments.Clear();
			m_Function.Arguments.Add(arg);
			m_Function.Expression = sb.ToString();

			// form controls
			m_ExpressionLabel.Text = m_Function.Expression;
			m_PeriodLabel.Text = nPeriod.ToString();
		}

		private void FunctionCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			UpdateFunctionLine();
			nChartControl1.Refresh();
		}

		private void ApplyToCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			if(m_bSkipUpdate)
				return;

			UpdateFunctionLine();
			nChartControl1.Refresh();
		}

		private void PeriodScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (nChartControl1 == null)
				return;

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