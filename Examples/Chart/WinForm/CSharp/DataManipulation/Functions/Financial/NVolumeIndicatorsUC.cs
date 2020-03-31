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
	public class NVolumeIndicatorsUC : NExampleBaseUC
	{
		const int numDataPoits = 200;
		const double prevCloseValue = 100;
		const double prevVolumeValue = 100;
		private NStockSeries m_Stock;
		private NAreaSeries m_Volume;
		private NLineSeries m_Line;
		private NFunctionCalculator m_Function;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NTextBox m_ExpressionLabel;
		private Nevron.UI.WinForm.Controls.NButton m_NewDataBtn;
		private Nevron.UI.WinForm.Controls.NComboBox m_FunctionCombo;
		private Nevron.UI.WinForm.Controls.NTextBox m_ParameterLabel;
		private Nevron.UI.WinForm.Controls.NHScrollBar m_ParameterScroll;
		private System.ComponentModel.Container components = null;

		public NVolumeIndicatorsUC()
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
			this.m_ParameterLabel = new Nevron.UI.WinForm.Controls.NTextBox();
			this.m_ParameterScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
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
			this.m_NewDataBtn.Size = new System.Drawing.Size(169, 22);
			this.m_NewDataBtn.TabIndex = 9;
			this.m_NewDataBtn.Text = "New Data";
			this.m_NewDataBtn.Click += new System.EventHandler(this.NewDataBtn_Click);
			// 
			// m_ParameterLabel
			// 
			this.m_ParameterLabel.Location = new System.Drawing.Point(134, 150);
			this.m_ParameterLabel.Name = "m_ParameterLabel";
			this.m_ParameterLabel.ReadOnly = true;
			this.m_ParameterLabel.Size = new System.Drawing.Size(42, 18);
			this.m_ParameterLabel.TabIndex = 8;
			// 
			// m_ParameterScroll
			// 
			this.m_ParameterScroll.LargeChange = 1;
			this.m_ParameterScroll.Location = new System.Drawing.Point(7, 150);
			this.m_ParameterScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.m_ParameterScroll.Name = "m_ParameterScroll";
			this.m_ParameterScroll.Size = new System.Drawing.Size(121, 18);
			this.m_ParameterScroll.TabIndex = 7;
			this.m_ParameterScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.StartValueScroll_Scroll);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 130);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "Parameter:";
			// 
			// m_ExpressionLabel
			// 
			this.m_ExpressionLabel.Location = new System.Drawing.Point(7, 87);
			this.m_ExpressionLabel.Name = "m_ExpressionLabel";
			this.m_ExpressionLabel.ReadOnly = true;
			this.m_ExpressionLabel.Size = new System.Drawing.Size(169, 18);
			this.m_ExpressionLabel.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(169, 17);
			this.label2.TabIndex = 10;
			this.label2.Text = "Expression:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(169, 16);
			this.label3.TabIndex = 13;
			this.label3.Text = "Function:";
			// 
			// m_FunctionCombo
			// 
			this.m_FunctionCombo.ListProperties.CheckBoxDataMember = "";
			this.m_FunctionCombo.ListProperties.DataSource = null;
			this.m_FunctionCombo.ListProperties.DisplayMember = "";
			this.m_FunctionCombo.Location = new System.Drawing.Point(7, 26);
			this.m_FunctionCombo.Name = "m_FunctionCombo";
			this.m_FunctionCombo.Size = new System.Drawing.Size(169, 21);
			this.m_FunctionCombo.TabIndex = 12;
			this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			// 
			// NVolumeIndicatorsUC
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_FunctionCombo);
			this.Controls.Add(this.m_ExpressionLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_NewDataBtn);
			this.Controls.Add(this.m_ParameterLabel);
			this.Controls.Add(this.m_ParameterScroll);
			this.Controls.Add(this.label1);
			this.Name = "NVolumeIndicatorsUC";
			this.Size = new System.Drawing.Size(180, 235);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Volume Indicators<br/><font size = '10pt'>Demonstrates how to use build in financial functions</font>");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// configure the legend position
			nChartControl1.Legends[0].Location = new NPointL(new NLength(95, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup charts
			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(75, NRelativeUnit.ParentPercentage));

			SetupTimeScale(chart.Axis(StandardAxis.PrimaryX));
			SetupStockChart(chart);
			SetupVolumeChart(chart);
			SetupIndicatorChart(chart);

			// generate data
			GenerateData();

			// form controls
			m_FunctionCombo.Items.Add("Accumulation Distribution");
			m_FunctionCombo.Items.Add("Chaikin Oscillator");
			m_FunctionCombo.Items.Add("Ease of Movement");
			m_FunctionCombo.Items.Add("Money Flow Index");
			m_FunctionCombo.Items.Add("Negative Volume Index");
			m_FunctionCombo.Items.Add("On Balance Volume");
			m_FunctionCombo.Items.Add("Positive Volume Index");
			m_FunctionCombo.Items.Add("Price and Volume Trend");

			m_FunctionCombo.SelectedIndex = 0;
			m_ParameterScroll.Value = 10;
		}

		private void SetupStockChart(NCartesianChart chart)
		{
			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Length = new NLength(0);

			NAxis axisY = chart.Axis(StandardAxis.PrimaryY);
			axisY.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 50, 100);
			axisY.ScaleConfigurator = scaleY;
			axisY.Visible = true;

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

			NAxis axisY = chart.Axis(StandardAxis.SecondaryY);
			axisY.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 25, 45);
			axisY.ScaleConfigurator = scaleY;
			axisY.Visible = true;

			// setup the volume series
			m_Volume = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			m_Volume.Name = "Volume";
			m_Volume.Legend.Mode = SeriesLegendMode.None;
			m_Volume.FillStyle = new NColorFillStyle(Color.YellowGreen);
			m_Volume.DataLabelStyle.Visible = false;
			m_Volume.Values.Name = "volume";
			m_Volume.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_Volume.DisplayOnAxis(axisY.AxisId, true);
			m_Volume.UseXValues = true;
		}
		private void SetupIndicatorChart(NCartesianChart chart)
		{
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Length = new NLength(0);

			NCartesianAxisCollection axes = (NCartesianAxisCollection)chart.Axes;
			NAxis axisY = axes.AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontLeft);
			axisY.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 0, 20);
			axisY.ScaleConfigurator = scaleY;
			axisY.Visible = true;

			// Add line series for function
			m_Line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			m_Line.DataLabelStyle.Visible = false;
			m_Line.BorderStyle.Color = Color.Blue;
			m_Line.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_Line.DisplayOnAxis(axisY.AxisId, true);
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
			int nParam = m_ParameterScroll.Value;
			StringBuilder sb = new StringBuilder();

			m_Function.Arguments.Clear();

			switch(m_FunctionCombo.SelectedIndex)
			{
				case 0:
					m_Function.Arguments.Add(m_Volume.Values);
					m_Function.Arguments.Add(m_Stock.CloseValues);
					m_Function.Arguments.Add(m_Stock.HighValues);
					m_Function.Arguments.Add(m_Stock.LowValues);
					sb.Append("ACCDIST(close; high; low; volume)");
					m_Line.Name = "Accumulation Distribution";
					m_ParameterScroll.Enabled = false;
					m_ParameterLabel.Enabled = false;
					break;

				case 1:
					m_Function.Arguments.Add(m_Volume.Values);
					m_Function.Arguments.Add(m_Stock.CloseValues);
					m_Function.Arguments.Add(m_Stock.HighValues);
					m_Function.Arguments.Add(m_Stock.LowValues);
					sb.Append("CHOSC(close; high; low; volume; 3; 10)");
					m_Line.Name = "Chaikin Oscillator";
					m_ParameterScroll.Enabled = false;
					m_ParameterLabel.Enabled = false;
					break;

				case 2:
					m_Function.Arguments.Add(m_Volume.Values);
					m_Function.Arguments.Add(m_Stock.HighValues);
					m_Function.Arguments.Add(m_Stock.LowValues);
					sb.Append("EMV(high; low; volume)");
					m_Line.Name = "Ease of Movement";
					m_ParameterScroll.Enabled = false;
					m_ParameterLabel.Enabled = false;
					break;

				case 3:
					m_Function.Arguments.Add(m_Volume.Values);
					m_Function.Arguments.Add(m_Stock.CloseValues);
					m_Function.Arguments.Add(m_Stock.HighValues);
					m_Function.Arguments.Add(m_Stock.LowValues);
					sb.AppendFormat("MFI(close; high; low; volume; {0})", nParam);
					m_Line.Name = "Money Flow Index";
					m_ParameterScroll.Enabled = true;
					m_ParameterLabel.Enabled = true;
					break;

				case 4:
					m_Function.Arguments.Add(m_Volume.Values);
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.AppendFormat("NVI(close; volume; {0})", nParam);
					m_Line.Name = "Negative Volume Index";
					m_ParameterScroll.Enabled = true;
					m_ParameterLabel.Enabled = true;
					break;

				case 5:
					m_Function.Arguments.Add(m_Volume.Values);
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.AppendFormat("OBV(close; volume; {0})", prevVolumeValue);
					m_Line.Name = "On Balance Volume";
					m_ParameterScroll.Enabled = false;
					m_ParameterLabel.Enabled = false;
					break;

				case 6:
					m_Function.Arguments.Add(m_Volume.Values);
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.AppendFormat("PVI(close; volume; {0})", nParam);
					m_Line.Name = "Positive Volume Index";
					m_ParameterScroll.Enabled = true;
					m_ParameterLabel.Enabled = true;
					break;

				case 7:
					m_Function.Arguments.Add(m_Volume.Values);
					m_Function.Arguments.Add(m_Stock.CloseValues);
					sb.Append("PVT(close; volume; 0)");
					m_Line.Name = "Price and Volume Trend";
					m_ParameterScroll.Enabled = false;
					m_ParameterLabel.Enabled = false;
					break;

				default:
					Debug.Assert(false);
					return;
			}

			m_Function.Expression = sb.ToString();

			m_ParameterLabel.Text = nParam.ToString();
			m_ExpressionLabel.Text = m_Function.Expression;
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

			for(int i = 0; i < nCount; i++)
			{
				if(dValue <= 0)
					dValue += 15;

				m_Volume.Values.Add(dValue);

				dValue += 10 * (0.5 - Random.NextDouble());
			}
		}

		private void NewDataBtn_Click(object sender, System.EventArgs e)
		{
			GenerateData();
			CalculateFunction();

			nChartControl1.Refresh();
		}
		private void StartValueScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
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