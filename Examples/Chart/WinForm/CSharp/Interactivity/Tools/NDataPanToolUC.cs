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
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NDataPanToolUC : NExampleBaseUC
	{
		private NDataPanTool m_DataPanTool;
		private Nevron.UI.WinForm.Controls.NCheckBox RepaintChartWhileDraggingCheckBox;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown XAxisPageSizeNumericUpDown;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown YAxisPageSizeNumericUpDown;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowScrollbarSlidersCheckBox;
		private System.ComponentModel.Container components = null;
		private bool m_Update;

		public NDataPanToolUC()
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
			this.RepaintChartWhileDraggingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.XAxisPageSizeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.YAxisPageSizeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ShowScrollbarSlidersCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.XAxisPageSizeNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.YAxisPageSizeNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// RepaintChartWhileDraggingCheckBox
			// 
			this.RepaintChartWhileDraggingCheckBox.ButtonProperties.BorderOffset = 2;
			this.RepaintChartWhileDraggingCheckBox.Location = new System.Drawing.Point(8, 8);
			this.RepaintChartWhileDraggingCheckBox.Name = "RepaintChartWhileDraggingCheckBox";
			this.RepaintChartWhileDraggingCheckBox.Size = new System.Drawing.Size(163, 34);
			this.RepaintChartWhileDraggingCheckBox.TabIndex = 0;
			this.RepaintChartWhileDraggingCheckBox.Text = "Repaint Chart while Dragging";
			this.RepaintChartWhileDraggingCheckBox.CheckedChanged += new System.EventHandler(this.RepaintChartWhileDraggingCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "X axis page size:";
			// 
			// XAxisPageSizeNumericUpDown
			// 
			this.XAxisPageSizeNumericUpDown.Location = new System.Drawing.Point(8, 102);
			this.XAxisPageSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.XAxisPageSizeNumericUpDown.Name = "XAxisPageSizeNumericUpDown";
			this.XAxisPageSizeNumericUpDown.Size = new System.Drawing.Size(89, 20);
			this.XAxisPageSizeNumericUpDown.TabIndex = 2;
			this.XAxisPageSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.XAxisPageSizeNumericUpDown.ValueChanged += new System.EventHandler(this.XAxisPageSizeNumericUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 126);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Y axis page size:";
			// 
			// YAxisPageSizeNumericUpDown
			// 
			this.YAxisPageSizeNumericUpDown.Location = new System.Drawing.Point(8, 145);
			this.YAxisPageSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.YAxisPageSizeNumericUpDown.Name = "YAxisPageSizeNumericUpDown";
			this.YAxisPageSizeNumericUpDown.Size = new System.Drawing.Size(89, 20);
			this.YAxisPageSizeNumericUpDown.TabIndex = 4;
			this.YAxisPageSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.YAxisPageSizeNumericUpDown.ValueChanged += new System.EventHandler(this.YAxisPageSizeNumericUpDown_ValueChanged);
			// 
			// ShowScrollbarSlidersCheckBox
			// 
			this.ShowScrollbarSlidersCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowScrollbarSlidersCheckBox.Location = new System.Drawing.Point(8, 33);
			this.ShowScrollbarSlidersCheckBox.Name = "ShowScrollbarSlidersCheckBox";
			this.ShowScrollbarSlidersCheckBox.Size = new System.Drawing.Size(163, 34);
			this.ShowScrollbarSlidersCheckBox.TabIndex = 5;
			this.ShowScrollbarSlidersCheckBox.Text = "Show Scrollbar Sliders";
			this.ShowScrollbarSlidersCheckBox.CheckedChanged += new System.EventHandler(this.ShowScrollbarSlidersCheckBox_CheckedChanged);
			// 
			// NDataPanToolUC
			// 
			this.Controls.Add(this.ShowScrollbarSlidersCheckBox);
			this.Controls.Add(this.YAxisPageSizeNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.XAxisPageSizeNumericUpDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.RepaintChartWhileDraggingCheckBox);
			this.Name = "NDataPanToolUC";
			this.Size = new System.Drawing.Size(180, 424);
			((System.ComponentModel.ISupportInitialize)(this.XAxisPageSizeNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.YAxisPageSizeNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Data Pan Tool<br/><font size = '12pt'>Demonstrates how to configure scrollbars with sliders and to enable data panning</font>");
			header.DockMode = PanelDockMode.Top;
			header.Margins = new NMarginsL(10, 10, 10, 10);
			header.TextStyle.TextFormat = TextFormat.XML;
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			nChartControl1.Panels.Add(header);

			// configure the chart
			NCartesianChart chart = new NCartesianChart();
			chart.DockMode = PanelDockMode.Fill;
			chart.Margins = new NMarginsL(10, 0, 10, 10);
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.BoundsMode = BoundsMode.Stretch;
			nChartControl1.Panels.Add(chart);

			// add some dummy data
			NPointSeries pointSeries = (NPointSeries)chart.Series.Add(SeriesType.Point);
			pointSeries.UseXValues = true;
			pointSeries.Name = "Point Series";
			pointSeries.BorderStyle.Width = new NLength(1, NGraphicsUnit.Pixel); ;
			pointSeries.BorderStyle.Color = Color.DarkRed;
			pointSeries.DataLabelStyle.Visible = false;
			pointSeries.Size = new NLength(5, NGraphicsUnit.Point);

			NDataPoint dp = new NDataPoint();

			// add xy values
			for (int i = 0; i < 200; i++)
			{
				dp[DataPointValue.X] = Random.Next(100);
				dp[DataPointValue.Y] = Random.Next(100);
				dp[DataPointValue.Label] = "Item" + i.ToString();
				pointSeries.AddDataPoint(dp);
			}

			// configure chart axes
			// set the primary X axis in FixedPageSize mode
			double pageSize = 10;
			NAxis primaryX = chart.Axis(StandardAxis.PrimaryX);

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add an interlaced strip to the Y axis
			NScaleStripStyle xInterlacedStrip = new NScaleStripStyle();
			xInterlacedStrip.SetShowAtWall(ChartWallType.Back, true);
			xInterlacedStrip.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.LightGray));
			linearScale.StripStyles.Add(xInterlacedStrip);

			primaryX.ScaleConfigurator = linearScale;
			NNumericAxisPagingView xPagingView = new NNumericAxisPagingView(new NRange1DD(0, pageSize));
			xPagingView.MinPageLength = 1.0;
			primaryX.PagingView = xPagingView;
			primaryX.ScrollBar.Visible = true;
			primaryX.ScrollBar.ViewRangeChanged += new EventHandler(OnXViewRangeChanged);

			// set the primary Y axis in FixedPageSize mode
			NAxis primaryY = chart.Axis(StandardAxis.PrimaryY);
			linearScale = new NLinearScaleConfigurator();
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			// add an interlaced strip to the Y axis
			NScaleStripStyle yInterlacedStrip = new NScaleStripStyle();
			yInterlacedStrip.SetShowAtWall(ChartWallType.Back, true);
			yInterlacedStrip.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.LightGray));
			linearScale.StripStyles.Add(yInterlacedStrip);

			primaryY.ScaleConfigurator = linearScale;
			NNumericAxisPagingView yPagingView = new NNumericAxisPagingView(new NRange1DD(0, pageSize));
			yPagingView.MinPageLength = 1.0;
			primaryY.PagingView = yPagingView;
			primaryY.ScrollBar.Visible = true;
			primaryY.ScrollBar.ViewRangeChanged += new EventHandler(OnYViewRangeChanged);

			// disable the reset button
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.ResetButton.Visible = false;
			chart.Axis(StandardAxis.PrimaryY).ScrollBar.ResetButton.Visible = false;

			m_DataPanTool = new NDataPanTool();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(m_DataPanTool);
			nChartControl1.Controller.Tools.Add(new NAxisScrollTool());

			m_DataPanTool.Cancel += new EventHandler(OnCancel);

			// init form controls
			XAxisPageSizeNumericUpDown.Value = (decimal)10;
			YAxisPageSizeNumericUpDown.Value = (decimal)10;
			ShowScrollbarSlidersCheckBox.Checked = true;

			RepaintChartWhileDraggingCheckBox.Checked = m_DataPanTool.RepaintChartWhileDragging;
		}

		private void RepaintChartWhileDraggingCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			m_DataPanTool.RepaintChartWhileDragging = RepaintChartWhileDraggingCheckBox.Checked;
		}

		private void OnXViewRangeChanged(object sender, EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			NCartesianChart chart = nChartControl1.Charts[0] as NCartesianChart;
			if (chart != null)
			{
				m_Update = true;
				XAxisPageSizeNumericUpDown.Value = (decimal)chart.Axis(StandardAxis.PrimaryX).ScrollBar.ViewRange.GetLength();
				m_Update = false;
			}
		}

		private void OnYViewRangeChanged(object sender, EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			NCartesianChart chart = nChartControl1.Charts[0] as NCartesianChart;
			if (chart != null)
			{
				m_Update = true;
				YAxisPageSizeNumericUpDown.Value = (decimal)chart.Axis(StandardAxis.PrimaryY).ScrollBar.ViewRange.GetLength();
				m_Update = false;
			}
		}

		private void ShowScrollbarSlidersCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			NCartesianChart chart = nChartControl1.Charts[0] as NCartesianChart;
			if (chart != null)
			{
				chart.Axis(StandardAxis.PrimaryX).ScrollBar.ShowSliders = ShowScrollbarSlidersCheckBox.Checked;
				chart.Axis(StandardAxis.PrimaryY).ScrollBar.ShowSliders = ShowScrollbarSlidersCheckBox.Checked;

				nChartControl1.Refresh();
			}
		}

		private void XAxisPageSizeNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null || m_Update)
				return;

			NCartesianChart chart = nChartControl1.Charts[0] as NCartesianChart;
			if (chart != null)
			{
				NNumericAxisPagingView pagingView = chart.Axis(StandardAxis.PrimaryX).PagingView as NNumericAxisPagingView;
				pagingView.Length = (double)XAxisPageSizeNumericUpDown.Value;

				nChartControl1.Refresh();
			}
		}

		private void YAxisPageSizeNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null || m_Update)
				return;

			NCartesianChart chart = nChartControl1.Charts[0] as NCartesianChart;
			if (chart != null)
			{
				NNumericAxisPagingView pagingView = chart.Axis(StandardAxis.PrimaryY).PagingView as NNumericAxisPagingView;
				pagingView.Length = (double)YAxisPageSizeNumericUpDown.Value;

				nChartControl1.Refresh();
			}
		}

		private void OnCancel(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			nChartControl1.Refresh();
		}
	}
}
