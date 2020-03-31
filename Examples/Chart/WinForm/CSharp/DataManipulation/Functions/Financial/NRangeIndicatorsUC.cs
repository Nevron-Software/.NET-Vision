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
	public class NRangeIndicatorsUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NStockSeries m_Stock;
		private NLineSeries m_LineUpper;
		private NLineSeries m_LineLower;
		private NLineSeries m_LineSMA;
		private NFunctionCalculator m_UpperCalculator;
		private NFunctionCalculator m_LowerCalculator;
		private NFunctionCalculator m_SMACalculator;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NTextBox  m_PeriodLabel;
		private Nevron.UI.WinForm.Controls.NTextBox m_DeviationLabel;
		private Nevron.UI.WinForm.Controls.NButton m_NewDataBtn;
		private Nevron.UI.WinForm.Controls.NCheckBox m_ShowAverageCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_ShowPricesCheck;
		private Nevron.UI.WinForm.Controls.NHScrollBar m_DeviationScroll;
		private Nevron.UI.WinForm.Controls.NHScrollBar m_PeriodScroll;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox m_FunctionCombo;
		private System.ComponentModel.Container components = null;
		private bool m_Updating;

		public NRangeIndicatorsUC()
		{
			m_UpperCalculator = new NFunctionCalculator();
			m_LowerCalculator = new NFunctionCalculator();
			m_SMACalculator = new NFunctionCalculator();

			m_Updating = true;
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
			this.m_PeriodLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.m_PeriodScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.m_NewDataBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.m_DeviationScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.m_DeviationLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.m_ShowPricesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_ShowAverageCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_FunctionCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// m_PeriodLabel
			// 
			this.m_PeriodLabel.Location = new System.Drawing.Point(145, 74);
			this.m_PeriodLabel.Name = "m_PeriodLabel";
			this.m_PeriodLabel.ReadOnly = true;
			this.m_PeriodLabel.Size = new System.Drawing.Size(31, 18);
			this.m_PeriodLabel.TabIndex = 11;
			// 
			// m_PeriodScroll
			// 
			this.m_PeriodScroll.LargeChange = 1;
			this.m_PeriodScroll.Location = new System.Drawing.Point(4, 74);
			this.m_PeriodScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.m_PeriodScroll.Name = "m_PeriodScroll";
			this.m_PeriodScroll.Size = new System.Drawing.Size(137, 18);
			this.m_PeriodScroll.TabIndex = 10;
			this.m_PeriodScroll.Value = 20;
			this.m_PeriodScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PeriodScroll_Scroll);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 14);
			this.label1.TabIndex = 9;
			this.label1.Text = "Period:";
			// 
			// m_NewDataBtn
			// 
			this.m_NewDataBtn.Location = new System.Drawing.Point(4, 214);
			this.m_NewDataBtn.Name = "m_NewDataBtn";
			this.m_NewDataBtn.Size = new System.Drawing.Size(172, 25);
			this.m_NewDataBtn.TabIndex = 12;
			this.m_NewDataBtn.Text = "New Data";
			this.m_NewDataBtn.Click += new System.EventHandler(this.NewDataBtn_Click);
			// 
			// m_DeviationScroll
			// 
			this.m_DeviationScroll.LargeChange = 1;
			this.m_DeviationScroll.Location = new System.Drawing.Point(4, 125);
			this.m_DeviationScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.m_DeviationScroll.Name = "m_DeviationScroll";
			this.m_DeviationScroll.Size = new System.Drawing.Size(137, 18);
			this.m_DeviationScroll.TabIndex = 13;
			this.m_DeviationScroll.Value = 2;
			this.m_DeviationScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DeviationScroll_Scroll);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 105);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 16);
			this.label2.TabIndex = 14;
			this.label2.Text = "Deviation / Shift:";
			// 
			// m_DeviationLabel
			// 
			this.m_DeviationLabel.Location = new System.Drawing.Point(145, 125);
			this.m_DeviationLabel.Name = "m_DeviationLabel";
			this.m_DeviationLabel.ReadOnly = true;
			this.m_DeviationLabel.Size = new System.Drawing.Size(31, 18);
			this.m_DeviationLabel.TabIndex = 15;
			// 
			// m_ShowPricesCheck
			// 
			this.m_ShowPricesCheck.ButtonProperties.BorderOffset = 2;
			this.m_ShowPricesCheck.Location = new System.Drawing.Point(4, 156);
			this.m_ShowPricesCheck.Name = "m_ShowPricesCheck";
			this.m_ShowPricesCheck.Size = new System.Drawing.Size(172, 20);
			this.m_ShowPricesCheck.TabIndex = 16;
			this.m_ShowPricesCheck.Text = "Show Prices";
			this.m_ShowPricesCheck.CheckedChanged += new System.EventHandler(this.ShowPricesCheck_CheckedChanged);
			// 
			// m_ShowAverageCheck
			// 
			this.m_ShowAverageCheck.ButtonProperties.BorderOffset = 2;
			this.m_ShowAverageCheck.Location = new System.Drawing.Point(4, 181);
			this.m_ShowAverageCheck.Name = "m_ShowAverageCheck";
			this.m_ShowAverageCheck.Size = new System.Drawing.Size(172, 22);
			this.m_ShowAverageCheck.TabIndex = 17;
			this.m_ShowAverageCheck.Text = "Show Moving Average";
			this.m_ShowAverageCheck.CheckedChanged += new System.EventHandler(this.ShowAverageCheck_CheckedChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(187, 16);
			this.label3.TabIndex = 19;
			this.label3.Text = "Function:";
			// 
			// m_FunctionCombo
			// 
			this.m_FunctionCombo.ListProperties.CheckBoxDataMember = "";
			this.m_FunctionCombo.ListProperties.DataSource = null;
			this.m_FunctionCombo.ListProperties.DisplayMember = "";
			this.m_FunctionCombo.Location = new System.Drawing.Point(4, 24);
			this.m_FunctionCombo.Name = "m_FunctionCombo";
			this.m_FunctionCombo.Size = new System.Drawing.Size(174, 23);
			this.m_FunctionCombo.TabIndex = 20;
			this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			// 
			// NRangeIndicatorsUC
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_FunctionCombo);
			this.Controls.Add(this.m_ShowAverageCheck);
			this.Controls.Add(this.m_ShowPricesCheck);
			this.Controls.Add(this.m_DeviationLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_DeviationScroll);
			this.Controls.Add(this.m_NewDataBtn);
			this.Controls.Add(this.m_PeriodLabel);
			this.Controls.Add(this.m_PeriodScroll);
			this.Controls.Add(this.label1);
			this.Name = "NRangeIndicatorsUC";
			this.Size = new System.Drawing.Size(180, 267);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Bollinger Bands / Envelopes");
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

			// Add line series for the upper band
			m_LineUpper = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_LineUpper.DataLabelStyle.Visible = false;
			m_LineUpper.BorderStyle.Color = Color.Green;
			m_LineUpper.UseXValues = true;

			// Add line series for lower band
			m_LineLower = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_LineLower.DataLabelStyle.Visible = false;
			m_LineLower.BorderStyle.Color = Color.Green;
			m_LineLower.UseXValues = true;

			// Add line series for Simple Moving Average
			m_LineSMA = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_LineSMA.DataLabelStyle.Visible = false;
			m_LineSMA.BorderStyle.Color = Color.Orange;
			m_LineSMA.Name = "Simple Moving Average";
			m_LineSMA.UseXValues = true;

			Color color1 = Color.FromArgb(100, 100, 150);
			Color color2 = Color.FromArgb(200, 120, 120);

			// Setup the stock series
			m_Stock = (NStockSeries)m_Chart.Series.Add(SeriesType.Stock);
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Stick;
			m_Stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);
			m_Stock.UpStrokeStyle.Color = color1;
			m_Stock.DownStrokeStyle.Color = color2;
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.CloseValues.Name = "close";
			m_Stock.UseXValues = true;
			m_Stock.InflateMargins = true;

			// Add arguments
			m_UpperCalculator.Arguments.Add(m_Stock.CloseValues);
			m_LowerCalculator.Arguments.Add(m_Stock.CloseValues);
			m_SMACalculator.Arguments.Add(m_Stock.CloseValues);

			GenerateData();

			// form controls
			m_FunctionCombo.Items.Add("Bollinger Bands");
			m_FunctionCombo.Items.Add("Envelopes");

			m_Updating = false;

			m_FunctionCombo.SelectedIndex = 0;
			m_ShowPricesCheck.Checked = true;
			m_ShowAverageCheck.Checked = true;
		}

		private void GenerateData()
		{
			const double initialPrice = 500;
			const int numDataPoits = 200;

			GenerateOHLCData(m_Stock, initialPrice, numDataPoits);
			FillStockDates(m_Stock, numDataPoits, new DateTime(2010, 1, 11));
			CopyStockDates();
		}
		private void UpdateExpressions()
		{
			if (m_Updating)
				return;

			int nPeriod = m_PeriodScroll.Value;
			int nDeviation = m_DeviationScroll.Value;

			m_SMACalculator.Expression = String.Format("SMA(close; {0})", nPeriod);

			if(m_FunctionCombo.SelectedIndex == 0)
			{
				m_LineUpper.Name = "Bollinger Band - Upper";
				m_LineLower.Name = "Bollinger Band - Lower";

				m_UpperCalculator.Expression = String.Format("BOLLINGER(close; {0}; {1})", nPeriod, nDeviation);
				m_LowerCalculator.Expression = String.Format("BOLLINGER(close; {0}; {1})", nPeriod, -nDeviation);
			}
			else
			{
				m_LineUpper.Name = "Envelopes - Upper Line";
				m_LineLower.Name = "Envelopes - Lower Line";

				m_UpperCalculator.Expression = String.Format("ENV(close; {0}; {1})", nPeriod, nDeviation);
				m_LowerCalculator.Expression = String.Format("ENV(close; {0}; {1})", nPeriod, -nDeviation);
			}

			// form controls
			m_PeriodLabel.Text = nPeriod.ToString();
			m_DeviationLabel.Text = nDeviation.ToString();
		}
		private void CalculateFunctions()
		{
			m_LineUpper.Values = m_UpperCalculator.Calculate();
			m_LineLower.Values = m_LowerCalculator.Calculate();
			m_LineSMA.Values = m_SMACalculator.Calculate();
		}
		private void CopyStockDates()
		{
			m_LineUpper.XValues.Clear();
			m_LineUpper.XValues.AddRange(m_Stock.XValues);

			m_LineLower.XValues.Clear();
			m_LineLower.XValues.AddRange(m_Stock.XValues);

			m_LineSMA.XValues.Clear();
			m_LineSMA.XValues.AddRange(m_Stock.XValues);
		}

		private void FunctionCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 != null)
			{
				UpdateExpressions();
				CalculateFunctions();
				nChartControl1.Refresh();
			}
		}
		private void PeriodScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (nChartControl1 != null)
			{
				UpdateExpressions();
				CalculateFunctions();
				nChartControl1.Refresh();
			}
		}
		private void DeviationScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (nChartControl1 != null)
			{
				UpdateExpressions();
				CalculateFunctions();
				nChartControl1.Refresh();
			}
		}
		private void NewDataBtn_Click(object sender, System.EventArgs e)
		{
			if (nChartControl1 != null)
			{
				GenerateData();
				CalculateFunctions();
				nChartControl1.Refresh();
			}
		}
		private void ShowPricesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 != null)
			{
				m_Stock.Visible = m_ShowPricesCheck.Checked;
				nChartControl1.Refresh();
			}
		}
		private void ShowAverageCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 != null)
			{
				m_LineSMA.Visible = m_ShowAverageCheck.Checked;
				nChartControl1.Refresh();
			}
		}
	}
}