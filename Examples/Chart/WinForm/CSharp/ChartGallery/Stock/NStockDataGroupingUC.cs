using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NStockDataGroupingUC : NExampleBaseUC
	{
		private NStockSeries m_Stock;
		private UI.WinForm.Controls.NComboBox GroupingModeComboBox;
		private Label label2;
		private Label label1;
		private UI.WinForm.Controls.NNumericUpDown MinGroupDistanceUpDown;
		private Label label3;
		private UI.WinForm.Controls.NComboBox CustomDateTimeSpanComboBox;
		private UI.WinForm.Controls.NNumericUpDown GroupPercentWidthNumericUpDown;
		private Label label4;
		private UI.WinForm.Controls.NCheckBox ShowHighLowCheckBox;
		private UI.WinForm.Controls.NCheckBox ShowOpenCheckBox;
		private UI.WinForm.Controls.NCheckBox ShowCloseCheckBox;
		private UI.WinForm.Controls.NCheckBox ShowAsStickCheckBox;
		private UI.WinForm.Controls.NCheckBox ShowDataLabelsCheckBox;
		private System.ComponentModel.Container components = null;

		public NStockDataGroupingUC()
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
			this.GroupingModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.MinGroupDistanceUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.CustomDateTimeSpanComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.GroupPercentWidthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.ShowHighLowCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowOpenCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowCloseCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowAsStickCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowDataLabelsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.MinGroupDistanceUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GroupPercentWidthNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// GroupingModeComboBox
			// 
			this.GroupingModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.GroupingModeComboBox.ListProperties.DataSource = null;
			this.GroupingModeComboBox.ListProperties.DisplayMember = "";
			this.GroupingModeComboBox.Location = new System.Drawing.Point(11, 29);
			this.GroupingModeComboBox.Name = "GroupingModeComboBox";
			this.GroupingModeComboBox.Size = new System.Drawing.Size(151, 21);
			this.GroupingModeComboBox.TabIndex = 1;
			this.GroupingModeComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupingModeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Grouping Mode:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Min Group Distance:";
			// 
			// MinGroupDistanceUpDown
			// 
			this.MinGroupDistanceUpDown.Location = new System.Drawing.Point(11, 74);
			this.MinGroupDistanceUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.MinGroupDistanceUpDown.Name = "MinGroupDistanceUpDown";
			this.MinGroupDistanceUpDown.Size = new System.Drawing.Size(151, 20);
			this.MinGroupDistanceUpDown.TabIndex = 3;
			this.MinGroupDistanceUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.MinGroupDistanceUpDown.ValueChanged += new System.EventHandler(this.MinGroupDistanceUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(125, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Custom Date Time Span:";
			// 
			// CustomDateTimeSpanComboBox
			// 
			this.CustomDateTimeSpanComboBox.ListProperties.CheckBoxDataMember = "";
			this.CustomDateTimeSpanComboBox.ListProperties.DataSource = null;
			this.CustomDateTimeSpanComboBox.ListProperties.DisplayMember = "";
			this.CustomDateTimeSpanComboBox.Location = new System.Drawing.Point(11, 118);
			this.CustomDateTimeSpanComboBox.Name = "CustomDateTimeSpanComboBox";
			this.CustomDateTimeSpanComboBox.Size = new System.Drawing.Size(151, 21);
			this.CustomDateTimeSpanComboBox.TabIndex = 5;
			this.CustomDateTimeSpanComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomDateTimeSpanComboBox_SelectedIndexChanged);
			// 
			// GroupPercentWidthNumericUpDown
			// 
			this.GroupPercentWidthNumericUpDown.Location = new System.Drawing.Point(11, 163);
			this.GroupPercentWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.GroupPercentWidthNumericUpDown.Name = "GroupPercentWidthNumericUpDown";
			this.GroupPercentWidthNumericUpDown.Size = new System.Drawing.Size(151, 20);
			this.GroupPercentWidthNumericUpDown.TabIndex = 7;
			this.GroupPercentWidthNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.GroupPercentWidthNumericUpDown.ValueChanged += new System.EventHandler(this.GroupPercentWidthNumericUpDown_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 146);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Group Percent Width:";
			// 
			// ShowHighLowCheckBox
			// 
			this.ShowHighLowCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowHighLowCheckBox.Location = new System.Drawing.Point(11, 237);
			this.ShowHighLowCheckBox.Name = "ShowHighLowCheckBox";
			this.ShowHighLowCheckBox.Size = new System.Drawing.Size(151, 24);
			this.ShowHighLowCheckBox.TabIndex = 9;
			this.ShowHighLowCheckBox.Text = "Show High Low";
			this.ShowHighLowCheckBox.CheckedChanged += new System.EventHandler(this.ShowHighLowCheckBox_CheckedChanged);
			// 
			// ShowOpenCheckBox
			// 
			this.ShowOpenCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowOpenCheckBox.Location = new System.Drawing.Point(11, 261);
			this.ShowOpenCheckBox.Name = "ShowOpenCheckBox";
			this.ShowOpenCheckBox.Size = new System.Drawing.Size(151, 24);
			this.ShowOpenCheckBox.TabIndex = 10;
			this.ShowOpenCheckBox.Text = "Show Open";
			this.ShowOpenCheckBox.CheckedChanged += new System.EventHandler(this.ShowOpenCheckBox_CheckedChanged);
			// 
			// ShowCloseCheckBox
			// 
			this.ShowCloseCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowCloseCheckBox.Location = new System.Drawing.Point(11, 285);
			this.ShowCloseCheckBox.Name = "ShowCloseCheckBox";
			this.ShowCloseCheckBox.Size = new System.Drawing.Size(151, 24);
			this.ShowCloseCheckBox.TabIndex = 11;
			this.ShowCloseCheckBox.Text = "Show Close";
			this.ShowCloseCheckBox.CheckedChanged += new System.EventHandler(this.ShowCloseCheckBox_CheckedChanged);
			// 
			// ShowAsStickCheckBox
			// 
			this.ShowAsStickCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowAsStickCheckBox.Location = new System.Drawing.Point(11, 213);
			this.ShowAsStickCheckBox.Name = "ShowAsStickCheckBox";
			this.ShowAsStickCheckBox.Size = new System.Drawing.Size(151, 24);
			this.ShowAsStickCheckBox.TabIndex = 8;
			this.ShowAsStickCheckBox.Text = "Draw as Stick";
			this.ShowAsStickCheckBox.CheckedChanged += new System.EventHandler(this.ShowAsStickCheckBox_CheckedChanged);
			// 
			// ShowDataLabelsCheckBox
			// 
			this.ShowDataLabelsCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowDataLabelsCheckBox.Location = new System.Drawing.Point(11, 189);
			this.ShowDataLabelsCheckBox.Name = "ShowDataLabelsCheckBox";
			this.ShowDataLabelsCheckBox.Size = new System.Drawing.Size(151, 24);
			this.ShowDataLabelsCheckBox.TabIndex = 12;
			this.ShowDataLabelsCheckBox.Text = "Show Data Labels";
			this.ShowDataLabelsCheckBox.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheckBox_CheckedChanged);
			// 
			// NStockDataGroupingUC
			// 
			this.Controls.Add(this.ShowDataLabelsCheckBox);
			this.Controls.Add(this.ShowAsStickCheckBox);
			this.Controls.Add(this.ShowCloseCheckBox);
			this.Controls.Add(this.ShowOpenCheckBox);
			this.Controls.Add(this.ShowHighLowCheckBox);
			this.Controls.Add(this.GroupPercentWidthNumericUpDown);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.CustomDateTimeSpanComboBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.MinGroupDistanceUpDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.GroupingModeComboBox);
			this.Controls.Add(this.label2);
			this.Name = "NStockDataGroupingUC";
			this.Size = new System.Drawing.Size(176, 376);
			((System.ComponentModel.ISupportInitialize)(this.MinGroupDistanceUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GroupPercentWidthNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Stock Data Grouping");
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
			m_Stock.DataLabelStyle.Format = "open - <open>\r\nclose - <close>";

			// add some stock items
			const int numDataPoints = 10000;
			GenerateOHLCData(m_Stock, 100.0, numDataPoints, new NRange1DD(60, 140));
			FillStockDates(m_Stock, numDataPoints, DateTime.Now - new TimeSpan((int)(numDataPoints * 1.2), 0, 0, 0));

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// update form controls
			CustomDateTimeSpanComboBox.Items.Add("1 Week");
			CustomDateTimeSpanComboBox.Items.Add("2 Weeks");
			CustomDateTimeSpanComboBox.Items.Add("1 Month");
			CustomDateTimeSpanComboBox.Items.Add("3 Months");

			GroupingModeComboBox.FillFromEnum(typeof(StockGroupingMode));

			CustomDateTimeSpanComboBox.SelectedIndex = 2;
			GroupingModeComboBox.SelectedIndex = (int)StockGroupingMode.AutoDateTimeSpan;

			ShowHighLowCheckBox.Checked = true;
			ShowOpenCheckBox.Checked = true;
			ShowCloseCheckBox.Checked = true;
			ShowAsStickCheckBox.Checked = false;
			ShowOpenCheckBox.Enabled = false;
			ShowCloseCheckBox.Enabled = false;
		}

		private void GroupingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_Stock == null)
				return;

			MinGroupDistanceUpDown.Enabled = false;
			CustomDateTimeSpanComboBox.Enabled = false;
			GroupPercentWidthNumericUpDown.Enabled = true;

			switch (GroupingModeComboBox.SelectedIndex)
			{
				case (int)StockGroupingMode.None:
					m_Stock.GroupingMode = StockGroupingMode.None;
					GroupPercentWidthNumericUpDown.Enabled = false;
					break;
				case (int)StockGroupingMode.AutoDateTimeSpan:
					m_Stock.GroupingMode = StockGroupingMode.AutoDateTimeSpan;
					MinGroupDistanceUpDown.Enabled = true;
					break;
				case (int)StockGroupingMode.CustomDateTimeSpan:
					m_Stock.GroupingMode = StockGroupingMode.CustomDateTimeSpan;
					CustomDateTimeSpanComboBox.Enabled = true;
					break;
				case (int)StockGroupingMode.SynchronizeWithMajorTick:
					m_Stock.GroupingMode = StockGroupingMode.SynchronizeWithMajorTick;
					break;
				default:
					break;
			}

			nChartControl1.Refresh();
		}

		private void MinGroupDistanceUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (m_Stock == null)
				return;

			m_Stock.MinAutoGroupLength = new NLength((float)MinGroupDistanceUpDown.Value, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}

		private void CustomDateTimeSpanComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_Stock == null)
				return;

			switch (CustomDateTimeSpanComboBox.SelectedIndex)
			{
				case 0: // 1 Week
					m_Stock.CustomGroupStep = new NDateTimeSpan(1, NDateTimeUnit.Week);
					break;
				case 1: // 2 Weeks
					m_Stock.CustomGroupStep = new NDateTimeSpan(2, NDateTimeUnit.Week);
					break;
				case 2: // 1 Month
					m_Stock.CustomGroupStep = new NDateTimeSpan(1, NDateTimeUnit.Month);
					break;
				case 3: // 3 Months
					m_Stock.CustomGroupStep = new NDateTimeSpan(3, NDateTimeUnit.Month);
					break;
			}

			nChartControl1.Refresh();
		}

		private void GroupPercentWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (m_Stock == null)
				return;

			m_Stock.GroupPercentWidth = (float)GroupPercentWidthNumericUpDown.Value;
			nChartControl1.Refresh();
		}

		private void ShowHighLowCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (m_Stock == null)
				return;

			m_Stock.ShowHighLow = ShowHighLowCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void ShowOpenCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (m_Stock == null)
				return;

			m_Stock.ShowOpen = ShowOpenCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void ShowCloseCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (m_Stock == null)
				return;

			m_Stock.ShowClose = ShowCloseCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void ShowAsStickCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (m_Stock == null)
				return;

			m_Stock.CandleStyle = ShowAsStickCheckBox.Checked ? CandleStyle.Stick : CandleStyle.Bar;
			nChartControl1.Refresh();

			ShowOpenCheckBox.Enabled = ShowAsStickCheckBox.Checked;
			ShowCloseCheckBox.Enabled = ShowAsStickCheckBox.Checked;
		}

		private void ShowDataLabelsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (m_Stock == null)
				return;

			m_Stock.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked;
			nChartControl1.Refresh();
		}
	}
}