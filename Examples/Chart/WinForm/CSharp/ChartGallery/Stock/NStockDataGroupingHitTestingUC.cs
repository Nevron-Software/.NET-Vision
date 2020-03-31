using System;
using System.Resources;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Windows;
using System.Text;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStockDataGroupingHitTestingUC : NExampleBaseUC
	{
		private NStockSeries m_Stock;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NTextBox GroupInformationTextBox;
		private UI.WinForm.Controls.NCheckBox ShowHighLowCheckBox;
		private System.ComponentModel.Container components = null;

		public NStockDataGroupingHitTestingUC()
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
			this.GroupInformationTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.ShowHighLowCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Group Information:";
			// 
			// GroupInformationTextBox
			// 
			this.GroupInformationTextBox.Location = new System.Drawing.Point(9, 20);
			this.GroupInformationTextBox.Multiline = true;
			this.GroupInformationTextBox.Name = "GroupInformationTextBox";
			this.GroupInformationTextBox.Size = new System.Drawing.Size(203, 156);
			this.GroupInformationTextBox.TabIndex = 1;
			// 
			// ShowHighLowCheckBox
			// 
			this.ShowHighLowCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowHighLowCheckBox.Location = new System.Drawing.Point(9, 182);
			this.ShowHighLowCheckBox.Name = "ShowHighLowCheckBox";
			this.ShowHighLowCheckBox.Size = new System.Drawing.Size(151, 24);
			this.ShowHighLowCheckBox.TabIndex = 20;
			this.ShowHighLowCheckBox.Text = "Show High Low";
			this.ShowHighLowCheckBox.CheckedChanged += new System.EventHandler(this.ShowHighLowCheckBox_CheckedChanged);
			// 
			// NStockDataGroupingHitTestingUC
			// 
			this.Controls.Add(this.ShowHighLowCheckBox);
			this.Controls.Add(this.GroupInformationTextBox);
			this.Controls.Add(this.label1);
			this.Name = "NStockDataGroupingHitTestingUC";
			this.Size = new System.Drawing.Size(222, 414);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stock Data Grouping - Hit Testing");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			NRangeSelection rs = new NRangeSelection();
			rs.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			chart.RangeSelections.Add(rs);

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
			// set configurator
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.OuterMajorTickStyle.Length = new NLength(3, NGraphicsUnit.Point);
			scaleY.InnerMajorTickStyle.Visible = false;

			NFillStyle stripFill = new NColorFillStyle(Color.FromArgb(234, 233, 237));
			NScaleStripStyle stripStyle = new NScaleStripStyle(stripFill, null, true, 1, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			stripStyle.Interlaced = true;
			scaleY.StripStyles.Add(stripStyle);

			// setup stock series
			m_Stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.UpFillStyle = new NColorFillStyle(Color.White);
			m_Stock.UpStrokeStyle.Color = Color.Black;
			m_Stock.DownFillStyle = new NColorFillStyle(Color.Crimson);
			m_Stock.DownStrokeStyle.Color = Color.Crimson;
			m_Stock.HighLowStrokeStyle.Color = Color.Black;
			m_Stock.CandleWidth = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			m_Stock.UseXValues = true;
			m_Stock.InflateMargins = true;
			m_Stock.GroupingMode = StockGroupingMode.SynchronizeWithMajorTick;

			// add some stock items
			const int numDataPoints = 10000;
			GenerateOHLCData(m_Stock, 100.0, numDataPoints, new NRange1DD(60, 140));
			FillStockDates(m_Stock, numDataPoints, DateTime.Now - new TimeSpan((int)(numDataPoints * 1.2), 0, 0, 0));

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			nChartControl1.MouseMove += new MouseEventHandler(nChartControl1_MouseMove);

			this.ShowHighLowCheckBox.Checked = true;
		}

		void nChartControl1_MouseMove(object sender, MouseEventArgs e)
		{
			NHitTestResult result = nChartControl1.HitTest(e.X, e.Y);

			if (result.ChartElement == ChartElement.StockGroup)
			{
				NStockGroup stockGroup = result.StockGroup;

				StringBuilder stringBuilder = new StringBuilder();

				stringBuilder.AppendLine("Open Value: " + stockGroup.OpenValue.ToString());
				stringBuilder.AppendLine("Open X Value: " + DateTime.FromOADate(stockGroup.OpenXValue).ToString("d"));

				stringBuilder.AppendLine("Close Value: " + stockGroup.CloseValue.ToString());
				stringBuilder.AppendLine("Close X Value: " + DateTime.FromOADate(stockGroup.CloseXValue).ToString("d"));

				stringBuilder.AppendLine("High Value: " + stockGroup.HighValue.ToString());
				stringBuilder.AppendLine("Low Value: " + stockGroup.LowValue.ToString());

				GroupInformationTextBox.Text = stringBuilder.ToString();
			}
			else
			{
				GroupInformationTextBox.Text = string.Empty;
			}
		}

		private void ShowHighLowCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_Stock.ShowHighLow = ShowHighLowCheckBox.Checked;
			nChartControl1.Refresh();
		}
	}
}