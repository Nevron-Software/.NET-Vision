using System;
using System.Resources;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NValueTimelineScaleUC : NExampleBaseUC
	{
		private NCartesianChart m_Chart;
		private NStockSeries m_Stock;

		private Nevron.UI.WinForm.Controls.NButton DailyDataButton;
		private Nevron.UI.WinForm.Controls.NButton WeeklyDataButton;
		private Nevron.UI.WinForm.Controls.NButton MonthlyDataButton;
		private Nevron.UI.WinForm.Controls.NButton YearyDataButton;
		private Nevron.UI.WinForm.Controls.NCheckBox FirstRowVisibleCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox SecondRowVisibleCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox ThirdRowVisibleCheckBox;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public NValueTimelineScaleUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DailyDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.WeeklyDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MonthlyDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.YearyDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.FirstRowVisibleCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SecondRowVisibleCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ThirdRowVisibleCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// DailyDataButton
			// 
			this.DailyDataButton.Location = new System.Drawing.Point(13, 100);
			this.DailyDataButton.Name = "DailyDataButton";
			this.DailyDataButton.Size = new System.Drawing.Size(153, 23);
			this.DailyDataButton.TabIndex = 4;
			this.DailyDataButton.Text = "Daily Data";
			this.DailyDataButton.UseVisualStyleBackColor = true;
			this.DailyDataButton.Click += new System.EventHandler(this.DailyDataButton_Click);
			// 
			// WeeklyDataButton
			// 
			this.WeeklyDataButton.Location = new System.Drawing.Point(13, 129);
			this.WeeklyDataButton.Name = "WeeklyDataButton";
			this.WeeklyDataButton.Size = new System.Drawing.Size(153, 23);
			this.WeeklyDataButton.TabIndex = 6;
			this.WeeklyDataButton.Text = "Weekly Data";
			this.WeeklyDataButton.UseVisualStyleBackColor = true;
			this.WeeklyDataButton.Click += new System.EventHandler(this.WeeklyDataButton_Click);
			// 
			// MonthlyDataButton
			// 
			this.MonthlyDataButton.Location = new System.Drawing.Point(13, 158);
			this.MonthlyDataButton.Name = "MonthlyDataButton";
			this.MonthlyDataButton.Size = new System.Drawing.Size(153, 23);
			this.MonthlyDataButton.TabIndex = 7;
			this.MonthlyDataButton.Text = "Monthly Data";
			this.MonthlyDataButton.UseVisualStyleBackColor = true;
			this.MonthlyDataButton.Click += new System.EventHandler(this.MonthlyDataButton_Click);
			// 
			// YearyDataButton
			// 
			this.YearyDataButton.Location = new System.Drawing.Point(13, 187);
			this.YearyDataButton.Name = "YearyDataButton";
			this.YearyDataButton.Size = new System.Drawing.Size(153, 23);
			this.YearyDataButton.TabIndex = 8;
			this.YearyDataButton.Text = "Yearly Data";
			this.YearyDataButton.UseVisualStyleBackColor = true;
			this.YearyDataButton.Click += new System.EventHandler(this.YearyDataButton_Click);
			// 
			// FirstRowVisibleCheckBox
			// 
			this.FirstRowVisibleCheckBox.AutoSize = true;
			this.FirstRowVisibleCheckBox.ButtonProperties.BorderOffset = 2;
			this.FirstRowVisibleCheckBox.Location = new System.Drawing.Point(13, 10);
			this.FirstRowVisibleCheckBox.Name = "FirstRowVisibleCheckBox";
			this.FirstRowVisibleCheckBox.Size = new System.Drawing.Size(103, 17);
			this.FirstRowVisibleCheckBox.TabIndex = 19;
			this.FirstRowVisibleCheckBox.Text = "First Row Visible";
			this.FirstRowVisibleCheckBox.UseVisualStyleBackColor = true;
			this.FirstRowVisibleCheckBox.CheckedChanged += new System.EventHandler(this.FirstRowVisibleCheckBox_CheckedChanged);
			// 
			// SecondRowVisibleCheckBox
			// 
			this.SecondRowVisibleCheckBox.AutoSize = true;
			this.SecondRowVisibleCheckBox.ButtonProperties.BorderOffset = 2;
			this.SecondRowVisibleCheckBox.Location = new System.Drawing.Point(13, 33);
			this.SecondRowVisibleCheckBox.Name = "SecondRowVisibleCheckBox";
			this.SecondRowVisibleCheckBox.Size = new System.Drawing.Size(121, 17);
			this.SecondRowVisibleCheckBox.TabIndex = 18;
			this.SecondRowVisibleCheckBox.Text = "Second Row Visible";
			this.SecondRowVisibleCheckBox.UseVisualStyleBackColor = true;
			this.SecondRowVisibleCheckBox.CheckedChanged += new System.EventHandler(this.SecondRowVisibleCheckBox_CheckedChanged);
			// 
			// ThirdRowVisibleCheckBox
			// 
			this.ThirdRowVisibleCheckBox.AutoSize = true;
			this.ThirdRowVisibleCheckBox.ButtonProperties.BorderOffset = 2;
			this.ThirdRowVisibleCheckBox.Location = new System.Drawing.Point(13, 56);
			this.ThirdRowVisibleCheckBox.Name = "ThirdRowVisibleCheckBox";
			this.ThirdRowVisibleCheckBox.Size = new System.Drawing.Size(108, 17);
			this.ThirdRowVisibleCheckBox.TabIndex = 17;
			this.ThirdRowVisibleCheckBox.Text = "Third Row Visible";
			this.ThirdRowVisibleCheckBox.UseVisualStyleBackColor = true;
			this.ThirdRowVisibleCheckBox.CheckedChanged += new System.EventHandler(this.ThirdRowVisibleCheckBox_CheckedChanged);
			// 
			// NValueTimelineScaleUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.FirstRowVisibleCheckBox);
			this.Controls.Add(this.SecondRowVisibleCheckBox);
			this.Controls.Add(this.ThirdRowVisibleCheckBox);
			this.Controls.Add(this.YearyDataButton);
			this.Controls.Add(this.MonthlyDataButton);
			this.Controls.Add(this.WeeklyDataButton);
			this.Controls.Add(this.DailyDataButton);
			this.Name = "NValueTimelineScaleUC";
			this.Size = new System.Drawing.Size(178, 232);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Value Timeline Scale<br/><font size = '9pt'>Demonstrates how to use a timeline scale to show date/time information on the X axis</font>");
			header.DockMode = PanelDockMode.Top;
			header.Margins = new NMarginsL(0, 10, 0, 10);
			header.TextStyle.TextFormat = TextFormat.XML;
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			nChartControl1.Panels.Add(header);

			// setup chart
			m_Chart = new NCartesianChart();
			nChartControl1.Panels.Add(m_Chart);
			m_Chart.DockMode = PanelDockMode.Fill;
			m_Chart.Margins = new NMarginsL(10, 0, 10, 10);
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.LightModel.EnableLighting = false;
			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.Wall(ChartWallType.Floor).Visible = false;
			m_Chart.Wall(ChartWallType.Left).Visible = false;
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Height = 40;

			m_Chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(75, NRelativeUnit.ParentPercentage));

			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			m_Chart.RangeSelections.Add(rangeSelection);

			// setup X axis
			NAxis axis = m_Chart.Axis(StandardAxis.PrimaryX);
			axis.ScrollBar.Visible = true;
			NValueTimelineScaleConfigurator timeLineScale = new NValueTimelineScaleConfigurator();
			timeLineScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			timeLineScale.SecondRow.GridStyle.SetShowAtWall(ChartWallType.Back, true);
			timeLineScale.ThirdRow.GridStyle.SetShowAtWall(ChartWallType.Back, true);
			axis.ScaleConfigurator = timeLineScale;

			// setup primary Y axis
			axis = m_Chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;

			// configure ticks and grid lines
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.InnerMajorTickStyle.Length = new NLength(0);

			// add interlaced stripe 
			NScaleStripStyle stripStyle = new NScaleStripStyle();
			stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			// Setup the stock series
			m_Stock = (NStockSeries)m_Chart.Series.Add(SeriesType.Stock);
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Stick;
			m_Stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);
			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue;
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.CloseValues.Name = "close";
			m_Stock.UseXValues = true;

			// configure interactivity
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());

			// update form controls
			FirstRowVisibleCheckBox.Checked = true;
			SecondRowVisibleCheckBox.Checked = true;
			ThirdRowVisibleCheckBox.Checked = true;

			// generate some data
			MonthlyDataButton_Click(null, null);
		}

		private void UpdateScale()
		{
			NValueTimelineScaleConfigurator timelineScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NValueTimelineScaleConfigurator;

			timelineScale.FirstRow.Visible = FirstRowVisibleCheckBox.Checked;
			timelineScale.SecondRow.Visible = SecondRowVisibleCheckBox.Checked;
			timelineScale.ThirdRow.Visible = ThirdRowVisibleCheckBox.Checked;

			nChartControl1.Refresh();
		}

		private void GenerateData(DateTime dtStart, DateTime dtEnd, NDateTimeSpan span)
		{
			long count = span.GetSpanCountInRange(new NDateTimeRange(dtStart, dtEnd));

			GenerateOHLCData(m_Stock, 100, (int)count);
			m_Stock.XValues.Clear();

			DateTime dtNow = dtStart;

			for (int i = 0; i < m_Stock.Values.Count; i++)
			{
				m_Stock.XValues.Add(dtNow.ToOADate());
				dtNow = span.Add(dtNow);
			}

			m_Chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = false;

			nChartControl1.Refresh();
		}

		private void DailyDataButton_Click(object sender, EventArgs e)
		{
			// generate data for 30 days
			DateTime dtNow = DateTime.Now;
			DateTime dtEnd  = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 17, 0, 0, 0);
			DateTime dtStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0);

			GenerateData(dtStart, dtEnd, new NDateTimeSpan(5, NDateTimeUnit.Minute));
		}

		private void WeeklyDataButton_Click(object sender, EventArgs e)
		{
			// generate data for 30 weeks
			DateTime dtNow = DateTime.Now;
			DateTime dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0);
			DateTime dtStart = NDateTimeUnit.Week.Add(dtEnd, -30);

			GenerateData(dtStart, dtEnd, new NDateTimeSpan(1, NDateTimeUnit.Day));
		}

		private void MonthlyDataButton_Click(object sender, EventArgs e)
		{
			// generate data for 30 months 
			DateTime dtNow = DateTime.Now;
			DateTime dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0);
			DateTime dtStart = NDateTimeUnit.Month.Add(dtEnd, -30);

			GenerateData(dtStart, dtEnd, new NDateTimeSpan(1, NDateTimeUnit.Week));
		}

		private void YearyDataButton_Click(object sender, EventArgs e)
		{
			// generate data for 30 years
			DateTime dtNow = DateTime.Now;
			DateTime dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0);
			DateTime dtStart = NDateTimeUnit.Year.Add(dtEnd, -30);

			GenerateData(dtStart, dtEnd, new NDateTimeSpan(1, NDateTimeUnit.Month));
		}

		private void FirstRowVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void SecondRowVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void ThirdRowVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}
	}
}
