using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Functions;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRealTimeStockUC : NRealTimeExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox UseHardwareAccelerationCheckBox;
		private Nevron.UI.WinForm.Controls.NButton StopStartTimerButton;
		private Nevron.UI.WinForm.Controls.NButton ResetButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.ComponentModel.IContainer components;

		NLineSeries m_LineSMA;
		NCartesianChart m_Chart;
		NStockSeries m_Stock;
		double m_PrevClose = 300.0;
		DateTime m_Start = DateTime.Now;

		double[] m_OpenValues;
		double[] m_HighValues;
		double[] m_LowValues;
		double[] m_CloseValues;
		private UI.WinForm.Controls.NComboBox NumberOfDataPointsComboBox;
		double[] m_XValues;

		public NRealTimeStockUC()
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
			this.label1 = new System.Windows.Forms.Label();
			this.ResetButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.StopStartTimerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.UseHardwareAccelerationCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.NumberOfDataPointsComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 103);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(170, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Number of Data Points:";
			// 
			// ResetButton
			// 
			this.ResetButton.Location = new System.Drawing.Point(7, 71);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(153, 23);
			this.ResetButton.TabIndex = 2;
			this.ResetButton.Text = "Reset";
			this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 132);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Bottom:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Right:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Top:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Left:";
			// 
			// StopStartTimerButton
			// 
			this.StopStartTimerButton.Location = new System.Drawing.Point(7, 42);
			this.StopStartTimerButton.Name = "StopStartTimerButton";
			this.StopStartTimerButton.Size = new System.Drawing.Size(153, 23);
			this.StopStartTimerButton.TabIndex = 1;
			this.StopStartTimerButton.Text = "Stop Timer";
			this.StopStartTimerButton.Click += new System.EventHandler(this.StopStartTimerButton_Click);
			// 
			// UseHardwareAccelerationCheckBox
			// 
			this.UseHardwareAccelerationCheckBox.ButtonProperties.BorderOffset = 2;
			this.UseHardwareAccelerationCheckBox.Location = new System.Drawing.Point(7, 12);
			this.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox";
			this.UseHardwareAccelerationCheckBox.Size = new System.Drawing.Size(170, 24);
			this.UseHardwareAccelerationCheckBox.TabIndex = 0;
			this.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration";
			this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
			// 
			// NumberOfDataPointsComboBox
			// 
			this.NumberOfDataPointsComboBox.ListProperties.CheckBoxDataMember = "";
			this.NumberOfDataPointsComboBox.ListProperties.DataSource = null;
			this.NumberOfDataPointsComboBox.ListProperties.DisplayMember = "";
			this.NumberOfDataPointsComboBox.Location = new System.Drawing.Point(10, 122);
			this.NumberOfDataPointsComboBox.Name = "NumberOfDataPointsComboBox";
			this.NumberOfDataPointsComboBox.Size = new System.Drawing.Size(153, 21);
			this.NumberOfDataPointsComboBox.TabIndex = 4;
			this.NumberOfDataPointsComboBox.Text = "comboBox2";
			this.NumberOfDataPointsComboBox.SelectedIndexChanged += new System.EventHandler(this.NumberOfDataPointsComboBox_SelectedIndexChanged);
			// 
			// NRealTimeStockUC
			// 
			this.Controls.Add(this.NumberOfDataPointsComboBox);
			this.Controls.Add(this.UseHardwareAccelerationCheckBox);
			this.Controls.Add(this.StopStartTimerButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ResetButton);
			this.Name = "NRealTimeStockUC";
			this.Size = new System.Drawing.Size(183, 442);
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();
			// set a chart title
			NLabel title = new NLabel("Real Time Stock");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			nChartControl1.Panels.Add(title);

			m_Chart = (NCartesianChart)nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

			// add interlace stripes
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			linearScale.StripStyles.Add(stripStyle);

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NRangeTimelineScaleConfigurator();

			// enable range selection
			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			m_Chart.RangeSelections.Add(rangeSelection);

			// enable zooming and scrolling
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = new NDateTimeAxisPagingView();

			m_LineSMA = new NLineSeries();

			// create a line series for the simple moving average
			m_Chart.Series.Add(m_LineSMA);

			m_LineSMA.Name = "SMA(20)";
			m_LineSMA.DataLabelStyle.Visible = false;
			m_LineSMA.BorderStyle.Color = Color.DarkOrange;
			m_LineSMA.UseXValues = true;

			// create the stock series
			m_Stock = new NStockSeries();
			m_Chart.Series.Add(m_Stock);
			m_Stock.DisplayOnAxis(StandardAxis.PrimaryX, true);

			m_Stock.Name = "Stock Data";
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Bar;
			m_Stock.CandleWidth = new NLength(0.8f, NRelativeUnit.ParentPercentage);
			m_Stock.InflateMargins = true;
			m_Stock.UseXValues = true;
			m_Stock.UpFillStyle = new NColorFillStyle(LightOrange);
			m_Stock.UpStrokeStyle.Color = Color.Black;
			m_Stock.DownFillStyle = new NColorFillStyle(DarkOrange);
			m_Stock.DownStrokeStyle.Color = Color.Black;
			m_Stock.OpenValues.Name = "open";
			m_Stock.CloseValues.Name = "close";
			m_Stock.HighValues.Name = "high";
			m_Stock.LowValues.Name = "low";
		
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());
			nChartControl1.Controller.Tools.Add(new NDataPanTool());

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			NumberOfDataPointsComboBox.Items.Add("1000");
			NumberOfDataPointsComboBox.Items.Add("5000");
			NumberOfDataPointsComboBox.Items.Add("10000");
			NumberOfDataPointsComboBox.SelectedIndex = 1;

			AddData();

			UseHardwareAccelerationCheckBox.Checked = true;
			StartTimer();
		}

		private void AddData()
		{
			int nCount = 200;
			NStockSeries s = m_Stock;
			double open, high, low, close;

			if (m_OpenValues == null || m_OpenValues.Length < nCount)
			{
				m_OpenValues = new double[nCount];
				m_HighValues = new double[nCount];
				m_LowValues = new double[nCount];
				m_CloseValues = new double[nCount];
				m_XValues = new double[nCount];
			}

			for (int index = 0; index < nCount; index++)
			{
				open = m_PrevClose;

				if (m_PrevClose < 25 || Random.NextDouble() > 0.5)
				{
					// upward price change
					close = open + (2 + (Random.NextDouble() * 20));
					high = close + (Random.NextDouble() * 10);
					low = open - (Random.NextDouble() * 10);
				}
				else
				{
					// downward price change
					close = open - (2 + (Random.NextDouble() * 20));
					high = open + (Random.NextDouble() * 10);
					low = close - (Random.NextDouble() * 10);
				}

				if (low < 1)
				{
					low = 1;
				}

				m_PrevClose = close;

				m_OpenValues[index] = open;
				m_HighValues[index] = high;
				m_LowValues[index] = low;
				m_CloseValues[index] = close;
				m_XValues[index] = m_Start.ToOADate();

				// advance to next working day
				m_Start = m_Start.AddDays(1);
			}

			s.OpenValues.AddRange(m_OpenValues, 0, nCount);
			s.HighValues.AddRange(m_HighValues, 0, nCount);
			s.LowValues.AddRange(m_LowValues, 0, nCount);
			s.CloseValues.AddRange(m_CloseValues, 0, nCount);
			s.XValues.AddRange(m_XValues, 0, nCount);

			int period = 20;

			// create a function calculator
			NFunctionCalculator fc = new NFunctionCalculator();
			fc.Arguments.Add(m_Stock.CloseValues);

			// calculate the simple moving average
			fc.Expression = "SMA(close; " + period.ToString() + ")";
			m_LineSMA.Values = fc.Calculate();
			m_LineSMA.XValues.AddRange(m_XValues, 0, nCount);

			int numberOfDataPoints = 1000;

			switch (NumberOfDataPointsComboBox.SelectedIndex)
			{
				case 0:
					numberOfDataPoints = 1000;
					break;
				case 1:
					numberOfDataPoints = 5000;
					break;
				case 2:
					numberOfDataPoints = 10000;
					break;
			}

			if (s.Values.Count > numberOfDataPoints)
			{
				s.OpenValues.RemoveRange(0, nCount);
				s.HighValues.RemoveRange(0, nCount);
				s.LowValues.RemoveRange(0, nCount);
				s.CloseValues.RemoveRange(0, nCount);
				s.XValues.RemoveRange(0, nCount);

				m_LineSMA.Values.RemoveRange(0, nCount);
				m_LineSMA.XValues.RemoveRange(0, nCount);
			}
		}

		protected override void UpdateTitle(bool working, float cpuUsage)
		{
			string title = "Real Time Stock";

			if (working)
			{
				title += " [CPU Usage - " + cpuUsage.ToString("0.") + "%]";
			}

			nChartControl1.Labels[0].Text = title;
		}

		private void ResetButton_Click(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_PrevClose = 300;
			m_Start = DateTime.Now;

			m_Stock.OpenValues.Clear();
			m_Stock.HighValues.Clear();
			m_Stock.LowValues.Clear();
			m_Stock.CloseValues.Clear();
			m_Stock.XValues.Clear();

			m_LineSMA.Values.Clear();
			m_LineSMA.XValues.Clear();
		}

		protected override void  OnTimerTick(object sender, EventArgs e)
		{
 			base.OnTimerTick(sender, e);

			AddData();

			nChartControl1.Refresh();
		}

		private void UseHardwareAccelerationCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if(UseHardwareAccelerationCheckBox.Checked)
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			}
			else
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
			}
		}

		private void StopStartTimerButton_Click(object sender, EventArgs e)
		{
			ToggleTimer();

			if (IsTimerRunning())
			{
				StopStartTimerButton.Text = "Stop Timer";
			}
			else
			{
				StopStartTimerButton.Text = "Start Timer";
			}
		}

		private void NumberOfDataPointsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ResetButton_Click(null, null);
		}
	}
}
