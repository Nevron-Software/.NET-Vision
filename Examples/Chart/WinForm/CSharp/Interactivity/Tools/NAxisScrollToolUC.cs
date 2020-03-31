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
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAxisScrollToolUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;
		private NCartesianChart m_ChartStockValues;
		private NCartesianChart m_ChartStockVolumes;
		private NStockSeries m_Stock;
		private NBarSeries m_Volume;
		private NDataZoomTool m_DataZoomTool;
		private NAxisScrollTool m_AxisScrollTool;

		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NCheckBox AnimateZoomingCheckBox;
		private Nevron.UI.WinForm.Controls.NComboBox PagingViewResetModeComboBox;

		public NAxisScrollToolUC()
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
			this.PagingViewResetModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.AnimateZoomingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Paging View Reset Mode:";
			// 
			// PagingViewResetModeComboBox
			// 
			this.PagingViewResetModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.PagingViewResetModeComboBox.ListProperties.DataSource = null;
			this.PagingViewResetModeComboBox.ListProperties.DisplayMember = "";
			this.PagingViewResetModeComboBox.Location = new System.Drawing.Point(8, 26);
			this.PagingViewResetModeComboBox.Name = "PagingViewResetModeComboBox";
			this.PagingViewResetModeComboBox.Size = new System.Drawing.Size(160, 21);
			this.PagingViewResetModeComboBox.TabIndex = 1;
			this.PagingViewResetModeComboBox.SelectedIndexChanged += new System.EventHandler(this.PagingViewResetModeComboBox_SelectedIndexChanged);
			// 
			// AnimateZoomingCheckBox
			// 
			this.AnimateZoomingCheckBox.ButtonProperties.BorderOffset = 2;
			this.AnimateZoomingCheckBox.Location = new System.Drawing.Point(11, 53);
			this.AnimateZoomingCheckBox.Name = "AnimateZoomingCheckBox";
			this.AnimateZoomingCheckBox.Size = new System.Drawing.Size(141, 24);
			this.AnimateZoomingCheckBox.TabIndex = 12;
			this.AnimateZoomingCheckBox.Text = "Animate Zooming";
			this.AnimateZoomingCheckBox.CheckedChanged += new System.EventHandler(this.AnimateZoomingCheckBox_CheckedChanged);
			// 
			// NAxisScrollToolUC
			// 
			this.Controls.Add(this.AnimateZoomingCheckBox);
			this.Controls.Add(this.PagingViewResetModeComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NAxisScrollToolUC";
			this.Size = new System.Drawing.Size(180, 200);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// disable the legend
			nChartControl1.Legends[0].Mode = LegendMode.Disabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Axis Scroll Tool");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// configure stock and volume charts
			ConfigureStockValuesChart();
			ConfigureStockVolumesChart();

			// Configure axes
			ConfigureAxes();

			// configure cursors
			ConfigureAxisCursors();

			// configure range selections
			ConfigureRangeSelections();

			// add a guide line on the left
			NSideGuideline guideLine = new NSideGuideline(PanelSide.Left);

			guideLine.Targets.Add(m_ChartStockValues);
			guideLine.Targets.Add(m_ChartStockVolumes);

			nChartControl1.Document.RootPanel.Guidelines.Add(guideLine);

			// configure interactivity
			m_DataZoomTool = new NDataZoomTool();
			m_DataZoomTool.AlwaysZoomIn = false;

			m_AxisScrollTool = new NAxisScrollTool();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NDataCursorTool());
			nChartControl1.Controller.Tools.Add(m_AxisScrollTool);
			nChartControl1.Controller.Tools.Add(m_DataZoomTool);

			PagingViewResetModeComboBox.FillFromEnum(typeof(PagingViewResetMode));
			PagingViewResetModeComboBox.SelectedIndex = 0;
		}

		private void ConfigureStockValuesChart()
		{
			m_ChartStockValues = (NCartesianChart)nChartControl1.Charts[0];

			m_ChartStockValues.Location = new NPointL(new NLength(7, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_ChartStockValues.Size = new NSizeL(new NLength(84, NRelativeUnit.ParentPercentage), new NLength(35, NRelativeUnit.ParentPercentage));
			m_ChartStockValues.BoundsMode = BoundsMode.Stretch;
            m_ChartStockValues.Wall(ChartWallType.Back).FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.FromArgb(230, 230, 230));

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Visible = false;
			m_ChartStockValues.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

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
			m_ChartStockValues.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// create stock series
			m_Stock = (NStockSeries)m_ChartStockValues.Series.Add(SeriesType.Stock);
			m_Stock.Name = "Stock Prices";
			m_Stock.UpFillStyle = new NColorFillStyle(Color.FromArgb(149, 171, 238));
			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue;
			m_Stock.DownFillStyle = new NColorFillStyle(Color.White);
			m_Stock.DownStrokeStyle.Color = Color.RoyalBlue;
			m_Stock.HighLowStrokeStyle.Color = Color.RoyalBlue;
			m_Stock.InflateMargins = true;
			m_Stock.UseXValues = true;
			m_Stock.CandleWidth = new NLength(1.6f, NRelativeUnit.ParentPercentage);

            // show the date time value in the legend
            m_Stock.Legend.Format = "<xvalue>";
			m_Stock.XValues.ValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			m_Stock.Legend.Mode = SeriesLegendMode.DataPoints;

			// configure data labels 
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.DataLabelStyle.Format = "<xvalue>";
			m_Stock.DataLabelStyle.VertAlign = VertAlign.Center;

			// add stock date time values
			GenerateOHLCData(m_Stock, 150, 12 * 4);

			// add stock date time values
			for (int nMonth = 1; nMonth <= 12; nMonth++)
			{
				for (int nDay = 1; nDay <= 28; nDay += 7)
				{
					m_Stock.XValues.Add(new DateTime(2003, nMonth, nDay).ToOADate());
				}
			}
		}

		protected void ConfigureStockVolumesChart()
		{
			m_ChartStockVolumes = new NCartesianChart();
			nChartControl1.Panels.Add(m_ChartStockVolumes);

			m_ChartStockVolumes.Location = new NPointL(new NLength(7, NRelativeUnit.ParentPercentage), new NLength(55, NRelativeUnit.ParentPercentage));
			m_ChartStockVolumes.Size = new NSizeL(new NLength(84, NRelativeUnit.ParentPercentage), new NLength(35, NRelativeUnit.ParentPercentage));
			m_ChartStockVolumes.BoundsMode = BoundsMode.Stretch;
            m_ChartStockVolumes.Wall(ChartWallType.Back).FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.White, Color.FromArgb(230, 230, 230));

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Visible = false;
			m_ChartStockVolumes.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

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
			m_ChartStockVolumes.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// enable paging and scrollbar
			m_ChartStockVolumes.Axis(StandardAxis.PrimaryX).PagingView = new NDateTimeAxisPagingView();
			m_ChartStockVolumes.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
			
			// add a Bar series for the Volume values
			m_Volume = (NBarSeries)m_ChartStockVolumes.Series.Add(SeriesType.Bar);
			m_Volume.Name = "Volume";
			m_Volume.DataLabelStyle.Visible = false;
			m_Volume.DataLabelStyle.Format = "<xvalue>";
			m_Volume.DataLabelStyle.VertAlign = VertAlign.Center;
			m_Volume.UseXValues = true;
			m_Volume.InflateMargins = true;
			m_Volume.FillStyle = new NColorFillStyle(Color.FromArgb(119, 208, 151));

            // add some stock items
            for (int i = 0; i < m_Stock.Values.Count; i++)
			{
				m_Volume.Values.Add(100 + Random.Next(1000));
				m_Volume.XValues.Add(m_Stock.XValues[i]);
			}
		}

		private void ConfigureAxes()
		{
			NAxis primaryStockVolumesXAxis = m_ChartStockVolumes.Axis(StandardAxis.PrimaryX);
			NAxis primaryStockValuesXAxis = m_ChartStockValues.Axis(StandardAxis.PrimaryX);

			primaryStockVolumesXAxis.Slaves.Add(primaryStockValuesXAxis);
			primaryStockValuesXAxis.Slaves.Add(primaryStockVolumesXAxis);
        }

		private void ConfigureAxisCursors()
		{
			NAxisCursor stockValueAxisCursor = new NAxisCursor();
			NAxisCursor stockVolumeAxisCursor = new NAxisCursor();

			stockValueAxisCursor.BeginEndAxis = (int)StandardAxis.PrimaryY;
			stockVolumeAxisCursor.BeginEndAxis = (int)StandardAxis.PrimaryY;

			// each cursor is master of the other. When the users click on one of the 
			// charts this will result in an automatic update of the other cursor
			stockValueAxisCursor.Slaves.Add(stockVolumeAxisCursor);
			stockVolumeAxisCursor.Slaves.Add(stockValueAxisCursor);

			m_ChartStockValues.Axis(StandardAxis.PrimaryX).Cursors.Add(stockValueAxisCursor);
			m_ChartStockVolumes.Axis(StandardAxis.PrimaryX).Cursors.Add(stockVolumeAxisCursor);
		}

		private void ConfigureRangeSelections()
		{
			NRangeSelection stockValueRangeSelection = new NRangeSelection();
			NRangeSelection stockVolumeRangeSelection = new NRangeSelection();

			stockValueRangeSelection.VerticalValueSnapper  = new NAxisRulerMinMaxSnapper();
			stockVolumeRangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();

			// each range selection is master of the other. When the users click on one of the 
			// charts this will result in an automatic update of the other range selection.
			stockValueRangeSelection.Slaves.Add(stockVolumeRangeSelection);
			stockVolumeRangeSelection.Slaves.Add(stockValueRangeSelection);

			m_ChartStockValues.RangeSelections.Add(stockValueRangeSelection);
			m_ChartStockVolumes.RangeSelections.Add(stockVolumeRangeSelection);
		}

		private void PagingViewResetModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PagingViewResetMode resetMode = (PagingViewResetMode)PagingViewResetModeComboBox.SelectedIndex;

            m_ChartStockValues.Axis(StandardAxis.PrimaryX).PagingView.ResetMode = resetMode;
			m_ChartStockVolumes.Axis(StandardAxis.PrimaryX).PagingView.ResetMode = resetMode;
		}

		private void AnimateZoomingCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_DataZoomTool.AnimateZooming = AnimateZoomingCheckBox.Checked;
		}
	}
}
