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
using System.Text;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NSideGuidelineUC : NExampleBaseUC
	{
		const int numDataPoits = 200;
		const double prevCloseValue = 100;
		const double prevVolumeValue = 100;
		private NStockSeries m_Stock;
		private NAreaSeries m_Volume;
		private NLineSeries m_Line;
		private NFunctionCalculator m_Function;
		private NCartesianChart m_StockChart;
		private NCartesianChart m_VolumeChart;
		private NCartesianChart m_IndicatorChart;
		private System.ComponentModel.Container components = null;
		private UI.WinForm.Controls.NCheckBox AlignLeftSidesCheckBox;
		private UI.WinForm.Controls.NCheckBox AlignRightSidesCheckBox;
		private UI.WinForm.Controls.NButton ChangeDataButton;
		private NLabel m_Header;
		
		public NSideGuidelineUC()
		{
			m_Function = new NFunctionCalculator();
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
			this.AlignLeftSidesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AlignRightSidesCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ChangeDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// AlignLeftSidesCheckBox
			// 
			this.AlignLeftSidesCheckBox.ButtonProperties.BorderOffset = 2;
			this.AlignLeftSidesCheckBox.Location = new System.Drawing.Point(5, 17);
			this.AlignLeftSidesCheckBox.Name = "AlignLeftSidesCheckBox";
			this.AlignLeftSidesCheckBox.Size = new System.Drawing.Size(170, 21);
			this.AlignLeftSidesCheckBox.TabIndex = 7;
			this.AlignLeftSidesCheckBox.Text = "Align Left Sides";
			this.AlignLeftSidesCheckBox.CheckedChanged += new System.EventHandler(this.AlignLeftSidesCheckBox_CheckedChanged);
			// 
			// AlignRightSidesCheckBox
			// 
			this.AlignRightSidesCheckBox.ButtonProperties.BorderOffset = 2;
			this.AlignRightSidesCheckBox.Location = new System.Drawing.Point(5, 44);
			this.AlignRightSidesCheckBox.Name = "AlignRightSidesCheckBox";
			this.AlignRightSidesCheckBox.Size = new System.Drawing.Size(170, 21);
			this.AlignRightSidesCheckBox.TabIndex = 8;
			this.AlignRightSidesCheckBox.Text = "Align Right Sides";
			this.AlignRightSidesCheckBox.CheckedChanged += new System.EventHandler(this.AlignRightSidesCheckBox_CheckedChanged);
			// 
			// ChangeDataButton
			// 
			this.ChangeDataButton.Location = new System.Drawing.Point(5, 82);
			this.ChangeDataButton.Name = "ChangeDataButton";
			this.ChangeDataButton.Size = new System.Drawing.Size(170, 23);
			this.ChangeDataButton.TabIndex = 9;
			this.ChangeDataButton.Text = "Change Data";
			this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			// 
			// NSideGuidelineUC
			// 
			this.Controls.Add(this.ChangeDataButton);
			this.Controls.Add(this.AlignRightSidesCheckBox);
			this.Controls.Add(this.AlignLeftSidesCheckBox);
			this.Name = "NSideGuidelineUC";
			this.Size = new System.Drawing.Size(180, 542);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();


			nChartControl1.Panels.Clear();

			// set a chart title
			m_Header = nChartControl1.Labels.AddHeader("Volume Indicators<br/><font size = '10pt'>Demonstrates how to align panels</font>");
			m_Header.TextStyle.TextFormat = TextFormat.XML;
			m_Header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			m_Header.ContentAlignment = ContentAlignment.BottomCenter;
			m_Header.Margins = new NMarginsL(10, 10, 10, 10);
			m_Header.DockMode = PanelDockMode.Top;

			NDockPanel containerPanel = new NDockPanel();
			containerPanel.DockMode = PanelDockMode.Fill;
			containerPanel.Margins = new NMarginsL(10, 0, 10, 10);
			nChartControl1.Panels.Add(containerPanel);

			m_StockChart = new NCartesianChart();
			m_StockChart.Axis(StandardAxis.PrimaryX).Visible = false;
			m_StockChart.DockMode = PanelDockMode.Top;
			m_StockChart.BoundsMode = BoundsMode.Stretch;
			m_StockChart.Size = new NSizeL(new NLength(0), new NLength(33, NRelativeUnit.ParentPercentage));
			m_StockChart.Margins = new NMarginsL(10, 0, 10, 10);
			containerPanel.ChildPanels.Add(m_StockChart);
			
			m_VolumeChart = new NCartesianChart();
			m_VolumeChart.Axis(StandardAxis.PrimaryX).Visible = false;
			m_VolumeChart.DockMode = PanelDockMode.Top;
			m_VolumeChart.BoundsMode = BoundsMode.Stretch;
			m_VolumeChart.Size = new NSizeL(new NLength(0), new NLength(33, NRelativeUnit.ParentPercentage));
			m_VolumeChart.Margins = new NMarginsL(10, 0, 10, 10);
			containerPanel.ChildPanels.Add(m_VolumeChart);

			m_IndicatorChart = new NCartesianChart();
			m_IndicatorChart.DockMode = PanelDockMode.Top;
			m_IndicatorChart.BoundsMode = BoundsMode.Stretch;
			m_IndicatorChart.Size = new NSizeL(new NLength(0), new NLength(33, NRelativeUnit.ParentPercentage));
			m_IndicatorChart.Margins = new NMarginsL(10, 0, 10, 10);
			containerPanel.ChildPanels.Add(m_IndicatorChart);

			// setup charts
			SetupTimeScale(m_IndicatorChart.Axis(StandardAxis.PrimaryX));
			SetupStockChart(m_StockChart);
			SetupVolumeChart(m_VolumeChart);
			SetupIndicatorChart(m_IndicatorChart);

			// generate data
			UpdateExpression();
			GenerateData();
			CalculateFunction();

			AlignLeftSidesCheckBox.Checked = true;
			AlignRightSidesCheckBox.Checked = true;
		}

		private void SetupStockChart(NCartesianChart chart)
		{
			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Length = new NLength(0);

			NAxis axisY = chart.Axis(StandardAxis.PrimaryY);
			axisY.ScaleConfigurator = scaleY;

			// setup the stock series
			m_Stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			m_Stock.Name = "Price";
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Stick;

			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue;
			m_Stock.OpenValues.Name = "open";
			m_Stock.HighValues.Name = "high";
			m_Stock.LowValues.Name = "low";
			m_Stock.CloseValues.Name = "close";
			m_Stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);
			m_Stock.UseXValues = true;
			m_Stock.InflateMargins = true;
		}
		private void SetupVolumeChart(NCartesianChart chart)
		{
			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Length = new NLength(0);
			chart.Axis(StandardAxis.SecondaryY).ScaleConfigurator = scaleY;
			chart.Axis(StandardAxis.SecondaryY).Visible = true;

			// setup the volume series
			m_Volume = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			m_Volume.Name = "Volume";
			m_Volume.Legend.Mode = SeriesLegendMode.None;
			m_Volume.FillStyle = new NColorFillStyle(Color.YellowGreen);
			m_Volume.DataLabelStyle.Visible = false;
			m_Volume.Values.Name = "volume";
			m_Volume.UseXValues = true;
			m_Volume.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_Volume.DisplayOnAxis(StandardAxis.SecondaryY, true);
		}
		private void SetupIndicatorChart(NCartesianChart chart)
		{
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Length = new NLength(0);
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// Add line series for function
			m_Line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			m_Line.DataLabelStyle.Visible = false;
			m_Line.BorderStyle.Color = Color.Blue;
			m_Line.UseXValues = true;
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

		private void UpdateExpression()
		{
			StringBuilder sb = new StringBuilder();

			m_Function.Arguments.Clear();

			m_Function.Arguments.Add(m_Volume.Values);
			m_Function.Arguments.Add(m_Stock.CloseValues);
			m_Function.Arguments.Add(m_Stock.HighValues);
			m_Function.Arguments.Add(m_Stock.LowValues);
			sb.Append("ACCDIST(close; high; low; volume)");
			m_Line.Name = "Accumulation Distribution";

			m_Function.Expression = sb.ToString();
		}
		private void CalculateFunction()
		{
			m_Line.Values = m_Function.Calculate();
		}
		private void GenerateData()
		{
			GenerateOHLCData(m_Stock, prevCloseValue, numDataPoits);
			FillStockDates(m_Stock, numDataPoits, new DateTime(2010, 1, 11));
			GenerateVolumeData(m_Volume, prevVolumeValue, numDataPoits);

			m_Volume.XValues.Clear();
			m_Volume.XValues.AddRange(m_Stock.XValues);

			m_Line.XValues.Clear();
			m_Line.XValues.AddRange(m_Stock.XValues);
		}
		private void GenerateVolumeData(NSeries series, double dValue, int nCount)
		{
			m_Volume.ClearDataPoints();

			for (int i = 0; i < nCount; i++)
			{
				if (dValue <= 0)
					dValue += 15;

				m_Volume.Values.Add(dValue);

				dValue += 10 * (0.5 - Random.NextDouble());
			}
		}

		private void UpdateGuidelines()
		{
			if (nChartControl1 == null)
				return;

			nChartControl1.Document.RootPanel.Guidelines.Clear();

			if (AlignLeftSidesCheckBox.Checked) 
			{
				NSideGuideline leftSideGuideline = new NSideGuideline(PanelSide.Left);

				leftSideGuideline.Targets.Add(m_StockChart);
				leftSideGuideline.Targets.Add(m_VolumeChart);
				leftSideGuideline.Targets.Add(m_IndicatorChart);

				nChartControl1.Document.RootPanel.Guidelines.Add(leftSideGuideline);
			}

			if (AlignRightSidesCheckBox.Checked)
			{
				NSideGuideline rightSideGuideline = new NSideGuideline(PanelSide.Right);

				rightSideGuideline.Targets.Add(m_StockChart);
				rightSideGuideline.Targets.Add(m_VolumeChart);
				rightSideGuideline.Targets.Add(m_IndicatorChart);

				nChartControl1.Document.RootPanel.Guidelines.Add(rightSideGuideline);
			}

			nChartControl1.Refresh();
		}

		private void AlignLeftSidesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateGuidelines();
		}

		private void AlignRightSidesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateGuidelines();
		}

		private void ChangeDataButton_Click(object sender, EventArgs e)
		{
			GenerateData();
			CalculateFunction();

			nChartControl1.Refresh();
		}
	}
}
