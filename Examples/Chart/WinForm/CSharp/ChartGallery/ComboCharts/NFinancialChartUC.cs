using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Functions;
using Nevron.Chart.Windows; 


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NFinancialChartUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NStockSeries m_Stock;
		private NHighLowSeries m_HighLow;
		private NLineSeries m_LineSMA;
		private Nevron.UI.WinForm.Controls.NComboBox CandleStyleCombo;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowSMA;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowBB;
		private System.ComponentModel.Container components = null;

		public NFinancialChartUC()
		{
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
			this.CandleStyleCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ShowBB = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowSMA = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// CandleStyleCombo
			// 
			this.CandleStyleCombo.ListProperties.CheckBoxDataMember = "";
			this.CandleStyleCombo.ListProperties.DataSource = null;
			this.CandleStyleCombo.ListProperties.DisplayMember = "";
			this.CandleStyleCombo.Location = new System.Drawing.Point(7, 36);
			this.CandleStyleCombo.Name = "CandleStyleCombo";
			this.CandleStyleCombo.Size = new System.Drawing.Size(164, 21);
			this.CandleStyleCombo.TabIndex = 1;
			this.CandleStyleCombo.SelectedIndexChanged += new System.EventHandler(this.CandleStyleCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "Candle Style:";
			// 
			// ShowBB
			// 
			this.ShowBB.ButtonProperties.BorderOffset = 2;
			this.ShowBB.ButtonProperties.WrapText = true;
			this.ShowBB.Checked = true;
			this.ShowBB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ShowBB.Location = new System.Drawing.Point(7, 115);
			this.ShowBB.Name = "ShowBB";
			this.ShowBB.Size = new System.Drawing.Size(162, 35);
			this.ShowBB.TabIndex = 3;
			this.ShowBB.Text = "Show Bollinger Bands";
			this.ShowBB.CheckedChanged += new System.EventHandler(this.ShowBB_CheckedChanged);
			// 
			// ShowSMA
			// 
			this.ShowSMA.ButtonProperties.BorderOffset = 2;
			this.ShowSMA.ButtonProperties.WrapText = true;
			this.ShowSMA.Checked = true;
			this.ShowSMA.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ShowSMA.Location = new System.Drawing.Point(7, 70);
			this.ShowSMA.Name = "ShowSMA";
			this.ShowSMA.Size = new System.Drawing.Size(162, 37);
			this.ShowSMA.TabIndex = 2;
			this.ShowSMA.Text = "Show Simple Moving Average";
			this.ShowSMA.CheckedChanged += new System.EventHandler(this.ShowSMA_CheckedChanged);
			// 
			// NFinancialChartUC
			// 
			this.Controls.Add(this.CandleStyleCombo);
			this.Controls.Add(this.ShowBB);
			this.Controls.Add(this.ShowSMA);
			this.Controls.Add(this.label1);
			this.Name = "NFinancialChartUC";
			this.Size = new System.Drawing.Size(180, 177);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			const int nNumberOfWeeks = 20;
			const int nWorkDaysInWeek = 5;
			const int nDaysInWeek = 7;
			const int nTotalWorkDays = nNumberOfWeeks * nWorkDaysInWeek;
			const int nTotalDays = nNumberOfWeeks * nDaysInWeek;
			const int nHistoricalDays = 20;

			NLabel title = nChartControl1.Labels.AddHeader("Financial Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;

			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Fit;

			m_Chart.Location = new NPointL(new NLength(7, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(86, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));

			m_Chart.Height = 30;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.Wall(ChartWallType.Floor).Visible = false;
			m_Chart.Wall(ChartWallType.Left).Visible = false;
			m_Chart.Wall(ChartWallType.Back).Width = 0;
			m_Chart.Wall(ChartWallType.Back).FillStyle = new NColorFillStyle(Color.FromArgb(239, 245, 239));
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// setup y axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.LineStyle.Color = Color.Gray;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);

			// setup x axis
			NAxis axisX1 = m_Chart.Axis(StandardAxis.PrimaryX);

			linearScale = new NLinearScaleConfigurator();
			axisX1.ScaleConfigurator = linearScale;

			linearScale.AutoLabels = false;

			linearScale.MinorTickCount = 4;
			linearScale.MajorTickMode = MajorTickMode.CustomStep;
			linearScale.CustomStep = 5;
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			linearScale.OuterMajorTickStyle.Length = new NLength(4, NGraphicsUnit.Point);
			linearScale.InnerMajorTickStyle.Length = new NLength(0, NGraphicsUnit.Point);
			linearScale.InnerMinorTickStyle.Length = new NLength(0, NGraphicsUnit.Point);
			linearScale.OuterMinorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);
			linearScale.OuterMinorTickStyle.LineStyle.Color = Color.Brown;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, false);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.LabelStyle.ValueScale = 0.2;

			// create a line series for the simple moving average
			m_LineSMA = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_LineSMA.Name = "SMA(20)";
			m_LineSMA.DataLabelStyle.Visible = false;
			m_LineSMA.BorderStyle.Color = Color.DarkOrange;

			// create the stock series
			m_Stock = (NStockSeries)m_Chart.Series.Add(SeriesType.Stock);
			m_Stock.Name = "Stock Data";
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Bar;
			m_Stock.CandleWidth = new NLength(5, NGraphicsUnit.Point);
			m_Stock.InflateMargins = false;
			m_Stock.UpFillStyle = new NColorFillStyle(LightOrange);
			m_Stock.UpStrokeStyle.Color = Color.Black;
			m_Stock.DownFillStyle = new NColorFillStyle(DarkOrange);
			m_Stock.DownStrokeStyle.Color = Color.Black;
			m_Stock.DisplayOnAxis(StandardAxis.PrimaryX, true);
			m_Stock.InflateMargins = true;
			m_Stock.OpenValues.Name = "open";
			m_Stock.CloseValues.Name = "close";
			m_Stock.HighValues.Name = "high";
			m_Stock.LowValues.Name = "low";

			// add the bollinger bands as high low area
			m_HighLow = (NHighLowSeries)m_Chart.Series.Add(SeriesType.HighLow);
			m_HighLow.Name = "BB(20, 2)";
			m_HighLow.DataLabelStyle.Visible = false;
			m_HighLow.HighFillStyle = new NColorFillStyle(Color.FromArgb(80, 130, 134, 168));
			m_HighLow.HighBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			m_HighLow.DisplayOnAxis(StandardAxis.SecondaryX, true);

			// generate some stock data
			GenerateOHLCData(m_Stock, 300, nTotalWorkDays + nHistoricalDays);

			// create a function calculator
			NFunctionCalculator fc = new NFunctionCalculator();
			fc.Arguments.Add(m_Stock.CloseValues);

			// calculate the bollinger bands
			fc.Expression = "BOLLINGER(close; 20; 2)";
			m_HighLow.HighValues = fc.Calculate();
			m_HighLow.HighValues.Name = "BollingerUpper";

			fc.Expression = "BOLLINGER(close; 20; -2)";
			m_HighLow.LowValues = fc.Calculate();
			m_HighLow.LowValues.Name = "BollingerLower";

			// calculate the simple moving average
			fc.Expression = "SMA(close; 20)";
			m_LineSMA.Values = fc.Calculate();

			// remove data that won't be charted
			m_Stock.HighValues.RemoveRange(0, nHistoricalDays);
			m_Stock.LowValues.RemoveRange(0, nHistoricalDays);
			m_Stock.OpenValues.RemoveRange(0, nHistoricalDays);
			m_Stock.CloseValues.RemoveRange(0, nHistoricalDays);
			m_HighLow.HighValues.RemoveRange(0, nHistoricalDays);
			m_HighLow.LowValues.RemoveRange(0, nHistoricalDays);
			m_LineSMA.Values.RemoveRange(0, nHistoricalDays);

			GenerateDateLabels(nTotalDays);

			CandleStyleCombo.Items.Add("Candle");
			CandleStyleCombo.Items.Add("Stick");
			CandleStyleCombo.SelectedIndex = 0;

			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			((NCartesianChart)m_Chart).RangeSelections.Add(rangeSelection);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());
			nChartControl1.Controller.Tools.Add(new NDataPanTool());
		}

		private void GenerateDateLabels(int nTotalDays)
		{
			// the chart starts with the first monday of june 2003
			DateTime dt = new DateTime(2003, 6, 2);
			TimeSpan daySpan = new TimeSpan(1, 0, 0, 0);
			NFontStyle labelFont = new NFontStyle("Arial", 9, FontStyle.Bold);
			NAxis axisX1 = m_Chart.Axis(StandardAxis.PrimaryX);
			NLinearScaleConfigurator linearScale = axisX1.ScaleConfigurator as NLinearScaleConfigurator;
			int nCurCategory = 0;
			m_Chart.ChildPanels.Clear();

			for(int i = 0; i < nTotalDays; i++)
			{
				// add a custom label for the first work day of the month
				if( (dt.Day == 1) ||
					((dt.DayOfWeek == DayOfWeek.Monday) && (dt.Day == 2 || dt.Day == 3)))
				{
					NRectangularCallout callout = new NRectangularCallout();
					callout.Anchor = new NAxisValueAnchor(axisX1, AxisValueAnchorMode.Clamp, nCurCategory);
					callout.Orientation = 270;

					callout.TextStyle.FontStyle = labelFont;
					callout.Text = dt.ToString("MMM yyyy");
					callout.StrokeStyle.Color = Color.DarkSeaGreen;
                    callout.StrokeStyle.Pattern = LinePattern.Dot;
					callout.ArrowBasePercent = 0;
					callout.UseAutomaticSize = true;

					m_Chart.ChildPanels.Add(callout);

					NAxisConstLine cl = axisX1.ConstLines.Add();
					cl.Value = nCurCategory;
					cl.StrokeStyle.Color = Color.DarkSeaGreen;
				}

				if(dt.DayOfWeek == DayOfWeek.Monday)
				{
					if((dt.Day == 1) || (dt.Day == 2) || (dt.Day == 3))
					{
						linearScale.Labels.Add("");
						nCurCategory++;
					}
					else
					{
						linearScale.Labels.Add(dt.Day.ToString());
						nCurCategory++;
					}
				}
				else if(dt.DayOfWeek == DayOfWeek.Saturday)
				{
				}
				else if(dt.DayOfWeek == DayOfWeek.Sunday)
				{
				}
				else
				{
					nCurCategory++;
				}

				dt += daySpan;
			}
		}

		private void CandleStyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Stock.CandleStyle = (CandleStyle)CandleStyleCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void ShowSMA_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_LineSMA.Visible = ShowSMA.Checked;
			nChartControl1.Refresh();
		}
		private void ShowBB_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_HighLow.Visible = ShowBB.Checked;
			nChartControl1.Refresh();
		}
	}
}