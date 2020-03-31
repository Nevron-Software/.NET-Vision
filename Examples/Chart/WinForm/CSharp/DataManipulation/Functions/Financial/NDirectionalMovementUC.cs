using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Text;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NDirectionalMovementUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NStockSeries m_Stock;
		private NLineSeries m_LineDIPos;
		private NLineSeries m_LineDINeg;
		private NLineSeries m_LineADX;
		private NFunctionCalculator m_Calc;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NTextBox m_DIPosLabel;
		private Nevron.UI.WinForm.Controls.NTextBox m_DINegLabel;
		private Nevron.UI.WinForm.Controls.NTextBox m_ADXLabel;
		private Nevron.UI.WinForm.Controls.NTextBox m_PeriodLabel;
		private Nevron.UI.WinForm.Controls.NHScrollBar m_PeriodScroll;
		private Nevron.UI.WinForm.Controls.NButton m_NewDataBtn;
		private Nevron.UI.WinForm.Controls.NCheckBox m_ShowPosCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_ShowNegCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_ShowADXCheck;
		private System.ComponentModel.Container components = null;

		public NDirectionalMovementUC()
		{
			InitializeComponent();

			m_Calc = new NFunctionCalculator();
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
			this.m_PeriodScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.m_PeriodLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.m_NewDataBtn = new Nevron.UI.WinForm.Controls.NButton();
			this.m_ShowPosCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_ShowNegCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_ShowADXCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_DIPosLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.m_DINegLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.m_ADXLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Period:";
			// 
			// m_PeriodScroll
			// 
			this.m_PeriodScroll.Location = new System.Drawing.Point(55, 9);
			this.m_PeriodScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.m_PeriodScroll.Name = "m_PeriodScroll";
			this.m_PeriodScroll.Size = new System.Drawing.Size(66, 18);
			this.m_PeriodScroll.TabIndex = 1;
			this.m_PeriodScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PeriodScroll_Scroll);
			// 
			// m_PeriodLabel
			// 
			this.m_PeriodLabel.Location = new System.Drawing.Point(123, 9);
			this.m_PeriodLabel.Name = "m_PeriodLabel";
			this.m_PeriodLabel.ReadOnly = true;
			this.m_PeriodLabel.Size = new System.Drawing.Size(43, 18);
			this.m_PeriodLabel.TabIndex = 4;
			// 
			// m_NewDataBtn
			// 
			this.m_NewDataBtn.Location = new System.Drawing.Point(7, 246);
			this.m_NewDataBtn.Name = "m_NewDataBtn";
			this.m_NewDataBtn.Size = new System.Drawing.Size(161, 22);
			this.m_NewDataBtn.TabIndex = 5;
			this.m_NewDataBtn.Text = "New Data";
			this.m_NewDataBtn.Click += new System.EventHandler(this.NewDataBtn_Click);
			// 
			// m_ShowPosCheck
			// 
			this.m_ShowPosCheck.ButtonProperties.BorderOffset = 2;
			this.m_ShowPosCheck.Location = new System.Drawing.Point(7, 45);
			this.m_ShowPosCheck.Name = "m_ShowPosCheck";
			this.m_ShowPosCheck.Size = new System.Drawing.Size(75, 23);
			this.m_ShowPosCheck.TabIndex = 6;
			this.m_ShowPosCheck.Text = "Show +DI";
			this.m_ShowPosCheck.CheckedChanged += new System.EventHandler(this.ShowPosCheck_CheckedChanged);
			// 
			// m_ShowNegCheck
			// 
			this.m_ShowNegCheck.ButtonProperties.BorderOffset = 2;
			this.m_ShowNegCheck.Location = new System.Drawing.Point(7, 103);
			this.m_ShowNegCheck.Name = "m_ShowNegCheck";
			this.m_ShowNegCheck.Size = new System.Drawing.Size(77, 22);
			this.m_ShowNegCheck.TabIndex = 7;
			this.m_ShowNegCheck.Text = "Show -DI";
			this.m_ShowNegCheck.CheckedChanged += new System.EventHandler(this.ShowNegCheck_CheckedChanged);
			// 
			// m_ShowADXCheck
			// 
			this.m_ShowADXCheck.ButtonProperties.BorderOffset = 2;
			this.m_ShowADXCheck.Location = new System.Drawing.Point(7, 160);
			this.m_ShowADXCheck.Name = "m_ShowADXCheck";
			this.m_ShowADXCheck.Size = new System.Drawing.Size(80, 24);
			this.m_ShowADXCheck.TabIndex = 8;
			this.m_ShowADXCheck.Text = "Show ADX";
			this.m_ShowADXCheck.CheckedChanged += new System.EventHandler(this.ShowADXCheck_CheckedChanged);
			// 
			// m_DIPosLabel
			// 
			this.m_DIPosLabel.Location = new System.Drawing.Point(7, 72);
			this.m_DIPosLabel.Name = "m_DIPosLabel";
			this.m_DIPosLabel.ReadOnly = true;
			this.m_DIPosLabel.Size = new System.Drawing.Size(160, 18);
			this.m_DIPosLabel.TabIndex = 9;
			// 
			// m_DINegLabel
			// 
			this.m_DINegLabel.Location = new System.Drawing.Point(7, 127);
			this.m_DINegLabel.Name = "m_DINegLabel";
			this.m_DINegLabel.ReadOnly = true;
			this.m_DINegLabel.Size = new System.Drawing.Size(159, 18);
			this.m_DINegLabel.TabIndex = 10;
			// 
			// m_ADXLabel
			// 
			this.m_ADXLabel.Location = new System.Drawing.Point(7, 184);
			this.m_ADXLabel.Name = "m_ADXLabel";
			this.m_ADXLabel.ReadOnly = true;
			this.m_ADXLabel.Size = new System.Drawing.Size(161, 18);
			this.m_ADXLabel.TabIndex = 11;
			// 
			// NDirectionalMovementUC
			// 
			this.Controls.Add(this.m_ADXLabel);
			this.Controls.Add(this.m_DINegLabel);
			this.Controls.Add(this.m_DIPosLabel);
			this.Controls.Add(this.m_ShowADXCheck);
			this.Controls.Add(this.m_ShowNegCheck);
			this.Controls.Add(this.m_ShowPosCheck);
			this.Controls.Add(this.m_NewDataBtn);
			this.Controls.Add(this.m_PeriodLabel);
			this.Controls.Add(this.m_PeriodScroll);
			this.Controls.Add(this.label1);
			this.Name = "NDirectionalMovementUC";
			this.Size = new System.Drawing.Size(180, 289);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Directional Movement");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(75, NRelativeUnit.ParentPercentage));

			// setup X axis
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
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup primary Y axis
			NAxis axisY1 = m_Chart.Axis(StandardAxis.PrimaryY);
			axisY1.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 45, 100);

			NLinearScaleConfigurator scaleY1 = (NLinearScaleConfigurator)axisY1.ScaleConfigurator;
			scaleY1.RulerStyle.Height = new NLength(2, NGraphicsUnit.Pixel);
			scaleY1.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY1.InnerMajorTickStyle.LineStyle.Width = new NLength(0);

			// setup secondary Y axis
			NAxis axisY2 = m_Chart.Axis(StandardAxis.SecondaryY);
			axisY2.Visible = true;
			axisY2.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 0, 40);

			NLinearScaleConfigurator scaleY2 = (NLinearScaleConfigurator)axisY2.ScaleConfigurator;
			scaleY2.RulerStyle.Height = new NLength(2, NGraphicsUnit.Pixel);
			scaleY2.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY2.InnerMajorTickStyle.LineStyle.Width = new NLength(0);

			Color color1 = Color.FromArgb(100, 100, 150);
			Color color2 = Color.FromArgb(200, 120, 120);
			Color color3 = Color.FromArgb(100, 150, 100);

			// setup the stock series
			m_Stock = (NStockSeries)m_Chart.Series.Add(SeriesType.Stock);
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Stick;
			m_Stock.UpStrokeStyle.Color = color1;
			m_Stock.DownStrokeStyle.Color = color2;
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);
			m_Stock.UseXValues = true;
			m_Stock.InflateMargins = true;

			// Add line series for ADX
			m_LineADX = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_LineADX.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_LineADX.DisplayOnAxis(StandardAxis.SecondaryY, true);
			m_LineADX.BorderStyle.Color = Color.LimeGreen;
			m_LineADX.Name = "ADX";
			m_LineADX.DataLabelStyle.Visible = false;
			m_LineADX.UseXValues = true;

			// Add line series for +DI
			m_LineDIPos = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_LineDIPos.MultiLineMode = MultiLineMode.Overlapped;
			m_LineDIPos.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_LineDIPos.DisplayOnAxis(StandardAxis.SecondaryY, true);
			m_LineDIPos.BorderStyle.Color = color2;
			m_LineDIPos.Name = "+DI";
			m_LineDIPos.DataLabelStyle.Visible = false;
			m_LineDIPos.UseXValues = true;

			// Add line series for -DI
			m_LineDINeg = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_LineDINeg.MultiLineMode = MultiLineMode.Overlapped;
			m_LineDINeg.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_LineDINeg.DisplayOnAxis(StandardAxis.SecondaryY, true);
			m_LineDINeg.BorderStyle.Color = color1;
			m_LineDINeg.Name = "-DI";
			m_LineDINeg.DataLabelStyle.Visible = false;
			m_LineDINeg.UseXValues = true;

			// add arguments for function calculator
			m_Stock.CloseValues.Name = "close";
			m_Stock.HighValues.Name = "high";
			m_Stock.LowValues.Name = "low";
			m_Calc.Arguments.Add(m_Stock.CloseValues);
			m_Calc.Arguments.Add(m_Stock.HighValues);
			m_Calc.Arguments.Add(m_Stock.LowValues);

			// form controls
			m_PeriodScroll.Value = 14;
			m_ShowPosCheck.Checked = true;
			m_ShowNegCheck.Checked = true;
			m_ShowADXCheck.Checked = true;

			GenerateData();
			UpdateFunctions();
		}

		private void GenerateData()
		{
			const double initialPrice = 100;
			const int numDataPoits = 100;

			GenerateOHLCData(m_Stock, initialPrice, numDataPoits);
			FillStockDates(m_Stock, numDataPoits, new DateTime(2010, 1, 11));
			CopyStockDates();
		}
		private void UpdateFunctions()
		{
			StringBuilder sb = new StringBuilder();
			int nPeriod = m_PeriodScroll.Value;

			sb.AppendFormat("DI_POS(close; high; low; {0})", nPeriod);
			m_Calc.Expression = sb.ToString();
			m_LineDIPos.Values = m_Calc.Calculate();
			m_DIPosLabel.Text = m_Calc.Expression;

			sb.Remove(0, sb.Length);
			sb.AppendFormat("DI_NEG(close; high; low; {0})", nPeriod);
			m_Calc.Expression = sb.ToString();
			m_LineDINeg.Values = m_Calc.Calculate();
			m_DINegLabel.Text = m_Calc.Expression;

			sb.Remove(0, sb.Length);
			sb.AppendFormat("MMA(DMI(close; high; low; {0}); {0})", nPeriod);
			m_Calc.Expression = sb.ToString();
			m_LineADX.Values = m_Calc.Calculate();
			m_ADXLabel.Text = m_Calc.Expression;

			m_PeriodLabel.Text = nPeriod.ToString();
		}
		private void CopyStockDates()
		{
			m_LineADX.XValues.Clear();
			m_LineADX.XValues.AddRange(m_Stock.XValues);

			m_LineDINeg.XValues.Clear();
			m_LineDINeg.XValues.AddRange(m_Stock.XValues);

			m_LineDIPos.XValues.Clear();
			m_LineDIPos.XValues.AddRange(m_Stock.XValues);
		}

		private void NewDataBtn_Click(object sender, System.EventArgs e)
		{
			GenerateData();
			UpdateFunctions();
			nChartControl1.Refresh();
		}
		private void PeriodScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			UpdateFunctions();
			nChartControl1.Refresh();
		}
		private void ShowPosCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_LineDIPos.Visible = m_ShowPosCheck.Checked;
			nChartControl1.Refresh();
		}
		private void ShowNegCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_LineDINeg.Visible = m_ShowNegCheck.Checked;
			nChartControl1.Refresh();
		}
		private void ShowADXCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			m_LineADX.Visible = m_ShowADXCheck.Checked;
			nChartControl1.Refresh();
		}
	}
}