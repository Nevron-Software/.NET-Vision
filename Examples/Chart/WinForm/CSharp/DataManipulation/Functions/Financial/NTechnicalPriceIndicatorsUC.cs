using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NTechnicalPriceIndicatorsUC : NExampleBaseUC
	{
		private NStockSeries m_Stock;
		private NLineSeries m_Line;
		private NFunctionCalculator m_Function;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NTextBox m_PeriodLabel;
		private Nevron.UI.WinForm.Controls.NTextBox m_ExpressionLabel;
		private Nevron.UI.WinForm.Controls.NButton m_NewDataBtn;
		private Nevron.UI.WinForm.Controls.NHScrollBar m_PeriodScroll;
		private Nevron.UI.WinForm.Controls.NComboBox m_FunctionCombo;
		private System.ComponentModel.Container components = null;

		public NTechnicalPriceIndicatorsUC()
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
			this.m_NewDataBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.m_PeriodLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.m_PeriodScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.m_ExpressionLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_FunctionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// m_NewDataBtn
			// 
			this.m_NewDataBtn.Location = new System.Drawing.Point(7, 200);
			this.m_NewDataBtn.Name = "m_NewDataBtn";
			this.m_NewDataBtn.Size = new System.Drawing.Size(170, 22);
			this.m_NewDataBtn.TabIndex = 9;
			this.m_NewDataBtn.Text = "New Data";
			this.m_NewDataBtn.Click += new System.EventHandler(this.NewDataBtn_Click);
			// 
			// m_PeriodLabel
			// 
			this.m_PeriodLabel.Location = new System.Drawing.Point(134, 150);
			this.m_PeriodLabel.Name = "m_PeriodLabel";
			this.m_PeriodLabel.ReadOnly = true;
			this.m_PeriodLabel.Size = new System.Drawing.Size(42, 18);
			this.m_PeriodLabel.TabIndex = 8;
			// 
			// m_PeriodScroll
			// 
			this.m_PeriodScroll.LargeChange = 1;
			this.m_PeriodScroll.Location = new System.Drawing.Point(7, 150);
			this.m_PeriodScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.m_PeriodScroll.Name = "m_PeriodScroll";
			this.m_PeriodScroll.Size = new System.Drawing.Size(121, 18);
			this.m_PeriodScroll.TabIndex = 7;
			this.m_PeriodScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PeriodScroll_Scroll);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 130);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 14);
			this.label1.TabIndex = 6;
			this.label1.Text = "Period:";
			// 
			// m_ExpressionLabel
			// 
			this.m_ExpressionLabel.Location = new System.Drawing.Point(7, 87);
			this.m_ExpressionLabel.Name = "m_ExpressionLabel";
			this.m_ExpressionLabel.ReadOnly = true;
			this.m_ExpressionLabel.Size = new System.Drawing.Size(170, 18);
			this.m_ExpressionLabel.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(170, 16);
			this.label2.TabIndex = 10;
			this.label2.Text = "Expression:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(170, 16);
			this.label3.TabIndex = 13;
			this.label3.Text = "Function:";
			// 
			// m_FunctionCombo
			// 
			this.m_FunctionCombo.ListProperties.CheckBoxDataMember = "";
			this.m_FunctionCombo.ListProperties.DataSource = null;
			this.m_FunctionCombo.ListProperties.DisplayMember = "";
			this.m_FunctionCombo.Location = new System.Drawing.Point(7, 27);
			this.m_FunctionCombo.Name = "m_FunctionCombo";
			this.m_FunctionCombo.Size = new System.Drawing.Size(170, 21);
			this.m_FunctionCombo.TabIndex = 12;
			this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			// 
			// NTechnicalPriceIndicatorsUC
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_FunctionCombo);
			this.Controls.Add(this.m_ExpressionLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_NewDataBtn);
			this.Controls.Add(this.m_PeriodLabel);
			this.Controls.Add(this.m_PeriodScroll);
			this.Controls.Add(this.label1);
			this.Name = "NTechnicalPriceIndicatorsUC";
			this.Size = new System.Drawing.Size(180, 241);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Technical Price Indicators");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// configure the legend position
			nChartControl1.Legends[0].Location = new NPointL(new NLength(95, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup Stock chart
			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(75, NRelativeUnit.ParentPercentage));

			SetupTimeScale(chart.Axis(StandardAxis.PrimaryX));
			SetupStockChart(chart);
			SetupIndicatorChart(chart);

			// generate data
			GenerateData();

			// form controls
			m_FunctionCombo.Items.Add("Average True Range");
			m_FunctionCombo.Items.Add("Chaikin's Volatility");
			m_FunctionCombo.Items.Add("Commodity Channel Index");
			m_FunctionCombo.Items.Add("Detrended Price Oscillator");
			m_FunctionCombo.Items.Add("MACD");
			m_FunctionCombo.Items.Add("Mass Index");
			m_FunctionCombo.Items.Add("Momentum");
			m_FunctionCombo.Items.Add("Momentum Div");
			m_FunctionCombo.Items.Add("Performance");
			m_FunctionCombo.Items.Add("Rate Of Change");
			m_FunctionCombo.Items.Add("Relative Strength Index");
			m_FunctionCombo.Items.Add("Standard Deviation");
			m_FunctionCombo.Items.Add("Stochastic");
			m_FunctionCombo.Items.Add("TRIX");
			m_FunctionCombo.Items.Add("William's %R");

			m_FunctionCombo.SelectedIndex = 0;
			m_PeriodScroll.Value = 10;
		}

		private void SetupStockChart(NCartesianChart chart)
		{
			// setup Y axis
			NAxis axisY = chart.Axis(StandardAxis.PrimaryY);
			axisY.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 40, 100);

			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)axisY.ScaleConfigurator;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Length = new NLength(0);

			Color color1 = Color.FromArgb(100, 100, 150);
			Color color2 = Color.FromArgb(200, 120, 120);

			// setup the stock series
			m_Stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			m_Stock.Name = "Price";
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Bar;
			m_Stock.HighLowStrokeStyle.Color = color1;
			m_Stock.UpStrokeStyle.Color = color1;
			m_Stock.DownStrokeStyle.Color = color2;
			m_Stock.UpFillStyle = new NColorFillStyle(color1);
			m_Stock.DownFillStyle = new NColorFillStyle(color2);
			m_Stock.OpenValues.Name = "open";
			m_Stock.HighValues.Name = "high";
			m_Stock.LowValues.Name = "low";
			m_Stock.CloseValues.Name = "close";
			m_Stock.CandleWidth = new NLength(0.4f, NRelativeUnit.ParentPercentage);
			m_Stock.UseXValues = true;
			m_Stock.InflateMargins = true;
		}
		private void SetupIndicatorChart(NCartesianChart chart)
		{
			// setup Y axis
			NAxis axisY2 = chart.Axis(StandardAxis.SecondaryY);
			axisY2.Visible = true;
			axisY2.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 0, 35);

			NLinearScaleConfigurator scaleY2 = (NLinearScaleConfigurator)axisY2.ScaleConfigurator;
			scaleY2.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY2.InnerMajorTickStyle.Length = new NLength(0);

			// Add line series for function
			m_Line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			m_Line.DataLabelStyle.Visible = false;
			m_Line.BorderStyle.Color = Color.Blue;
			m_Line.UseXValues = true;
			m_Line.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_Line.DisplayOnAxis(StandardAxis.SecondaryY, true);
		}
		private void SetupTimeScale(NAxis axis)
		{
			NValueTimelineScaleConfigurator scaleX = new NValueTimelineScaleConfigurator();
			scaleX.FirstRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.FirstRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(225, 225, 225));
			scaleX.FirstRow.UseGridStyle = true;
			scaleX.FirstRow.InnerTickStyle.Visible = false;
			scaleX.SecondRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.SecondRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(215, 215, 215));
			scaleX.SecondRow.UseGridStyle = true;
			scaleX.SecondRow.InnerTickStyle.Visible = false;
			scaleX.ThirdRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.ThirdRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(205, 205, 205));
			scaleX.ThirdRow.UseGridStyle = true;
			scaleX.ThirdRow.InnerTickStyle.Visible = false;
			// calendar
			NWeekDayRule wdr = new NWeekDayRule(WeekDayBit.All);
			wdr.Saturday = false;
			wdr.Sunday = false;
			scaleX.Calendar.Rules.Add(wdr);
			scaleX.EnableCalendar = true;

			axis.ScaleConfigurator = scaleX;
		}
		private void GenerateData()
		{
			const double initialPrice = 100;
			const int numDataPoits = 200;

			GenerateOHLCData(m_Stock, initialPrice, numDataPoits);
			FillStockDates(m_Stock, numDataPoits, new DateTime(2010, 1, 11));

			m_Line.XValues.Clear();
			m_Line.XValues.AddRange(m_Stock.XValues);
		}
		private void UpdateExpression()
		{
			int nPeriod = m_PeriodScroll.Value;
			StringBuilder sb = new StringBuilder();

			m_Function.Arguments.Clear();

			switch(m_FunctionCombo.SelectedIndex)
			{
				case 0: // Average True Range
					m_Function.Arguments.Add(m_Stock.CloseValues);
					m_Function.Arguments.Add(m_Stock.HighValues);
					m_Function.Arguments.Add(m_Stock.LowValues);
					sb.AppendFormat("MMA(TR(close; high; low); {0})", nPeriod);
					m_Line.Name = "Average True Range";
					m_PeriodScroll.Enabled = true;
					break;

				case 1: // Chaikin's Volatility
					m_Function.Arguments.Add(m_Stock.HighValues);
					m_Function.Arguments.Add(m_Stock.LowValues);
					sb.AppendFormat("CHV(high; low; 10; {0})", nPeriod);
					m_Line.Name = "Chaikin's Volatility";
					m_PeriodScroll.Enabled = true;
					break;

				case 2: // Commodity Channel Index
					m_Function.Arguments.Add(m_Stock.CloseValues);
					m_Function.Arguments.Add(m_Stock.HighValues);
					m_Function.Arguments.Add(m_Stock.LowValues);
					sb.AppendFormat("CCI(close; high; low; {0})", nPeriod);
					m_Line.Name = "Commodity Channel Index";
					m_PeriodScroll.Enabled = true;
					break;

				case 3: // Detrended Price Oscillator
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.AppendFormat("DPO(close; {0})", nPeriod);
					m_Line.Name = "Detrended Price Oscillator";
					m_PeriodScroll.Enabled = true;
					break;

				case 4: // Moving Average Convergence Divergence
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.Append("SUB( EMA(close;12) ; EMA(close;26) )");
					m_Line.Name = "MACD";
					m_PeriodScroll.Enabled = false;
					break;

				case 5: // Mass Index
					m_Function.Arguments.Add(m_Stock.HighValues);
					m_Function.Arguments.Add(m_Stock.LowValues);
					sb.AppendFormat("MI(high; low; 15; {0})", nPeriod);
					m_Line.Name = "Mass Index";
					m_PeriodScroll.Enabled = true;
					break;

				case 6: // Momentum
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.AppendFormat("MOMENTUM(close; {0})", nPeriod);
					m_Line.Name = "Momentum";
					m_PeriodScroll.Enabled = true;
					break;

				case 7: // Momentum Div
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.AppendFormat("MOMENTUMDIV(close; {0})", nPeriod);
					m_Line.Name = "Momentum Div";
					m_PeriodScroll.Enabled = true;
					break;

				case 8: // Performance
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.AppendFormat("PERFORMANCE(close)");
					m_Line.Name = "Performance";
					m_PeriodScroll.Enabled = false;
					break;

				case 9: // Rate Of Change
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.AppendFormat("ROC(close; {0})", nPeriod);
					m_Line.Name = "Rate Of Change";
					m_PeriodScroll.Enabled = true;
					break;

				case 10: // Relative Strength Index
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.AppendFormat("RSI(close; {0})", nPeriod);
					m_Line.Name = "Relative Strength Index";
					m_PeriodScroll.Enabled = true;
					break;

				case 11: // Standard Deviation
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.AppendFormat("STDDEV(close; {0})", nPeriod);
					m_Line.Name = "Standard Deviation";
					m_PeriodScroll.Enabled = true;
					break;

				case 12: // Stochastic Oscillator
					m_Function.Arguments.Add(m_Stock.CloseValues);
					m_Function.Arguments.Add(m_Stock.HighValues);
					m_Function.Arguments.Add(m_Stock.LowValues);
					sb.AppendFormat("STOCHASTIC(close; high; low; {0})", nPeriod);
					m_Line.Name = "Stochastic Oscillator";
					m_PeriodScroll.Enabled = true;
					break;

				case 13: // TRIX
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.AppendFormat("TRIX(close; {0})", nPeriod);
					m_Line.Name = "TRIX";
					m_PeriodScroll.Enabled = true;
					break;

				case 14: // William's %R
					m_Function.Arguments.Add(m_Stock.CloseValues);
					m_Function.Arguments.Add(m_Stock.HighValues);
					m_Function.Arguments.Add(m_Stock.LowValues);
					sb.AppendFormat("WILLIAMSR(close; high; low; {0})", nPeriod);
					m_Line.Name = "William's %R";
					m_PeriodScroll.Enabled = true;
					break;

				default:
					Debug.Assert(false);
					return;
			}

			m_Function.Expression = sb.ToString();

			m_PeriodLabel.Text = nPeriod.ToString();
			m_ExpressionLabel.Text = m_Function.Expression;
		}
		private void CalculateFunction()
		{
			m_Line.Values = m_Function.Calculate();
		}

		private void NewDataBtn_Click(object sender, System.EventArgs e)
		{
			GenerateData();
			CalculateFunction();

			nChartControl1.Refresh();
		}
		private void PeriodScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			UpdateExpression();
			CalculateFunction();

			nChartControl1.Refresh();
		}
		private void FunctionCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateExpression();
			CalculateFunction();

			nChartControl1.Refresh();
		}
	}
}