using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
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
	public class NRangeSelectionMoveResizeToolUC : NExampleBaseUC
    {
		private System.ComponentModel.Container components = null;

        NCartesianChart m_Chart1;
        NCartesianChart m_Chart2;

		public NRangeSelectionMoveResizeToolUC()
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
            this.SuspendLayout();
            // 
            // NRangeSelectionMoveResizeToolUC
            // 
            this.Name = "NRangeSelectionMoveResizeToolUC";
            this.Size = new System.Drawing.Size(180, 664);
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Range Selection Resize and Panning");
            title.DockMode = PanelDockMode.Top;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            nChartControl1.Panels.Add(title);

			// configure chart
            NDockPanel dockPanel = new NDockPanel();
            dockPanel.Margins = new NMarginsL(10);
            dockPanel.DockMode = PanelDockMode.Fill;
            nChartControl1.Panels.Add(dockPanel);

            m_Chart1 = new NCartesianChart();
            m_Chart1.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NValueTimelineScaleConfigurator();
            m_Chart1.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
			m_Chart1.Axis(StandardAxis.PrimaryX).ScrollBar.ResetButton.Visible = false;
            m_Chart1.Size = new NSizeL(new NLength(0), new NLength(50, NRelativeUnit.ParentPercentage));
            m_Chart1.DockMode = PanelDockMode.Top;
            m_Chart1.BoundsMode = BoundsMode.Stretch;
            dockPanel.ChildPanels.Add(m_Chart1);
            NAreaSeries area1 = new NAreaSeries();
            area1.UseXValues = true;
            area1.DataLabelStyle.Visible = false;
            m_Chart1.Series.Add(area1);

            m_Chart2 = new NCartesianChart();
            m_Chart2.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NValueTimelineScaleConfigurator();
            m_Chart2.Size = new NSizeL(new NLength(0), new NLength(50, NRelativeUnit.ParentPercentage));
            m_Chart2.DockMode = PanelDockMode.Top;
            m_Chart2.BoundsMode = BoundsMode.Stretch;
            dockPanel.ChildPanels.Add(m_Chart2);
            NAreaSeries area2 = new NAreaSeries();
            area2.UseXValues = true;
            area2.DataLabelStyle.Visible = false;
            m_Chart2.Series.Add(area2);

            NRangeSelection rangeSelection = new NRangeSelection();
            rangeSelection.Visible = true;
            rangeSelection.PaintInverted = true;
            rangeSelection.ShowGrippers = true;
            rangeSelection.AllowVerticalResize = false;
            rangeSelection.AllowHorizontalResize = true;
            rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
            rangeSelection.GripperSize = new NSizeL(5, 20);
            m_Chart2.RangeSelections.Add(rangeSelection);

            GenerateOHLCData(area1, 100, 1000);
            area2.Values = (NDataSeriesDouble)area1.Values.Clone();
            area2.XValues = (NDataSeriesDouble)area1.XValues.Clone();

            nChartControl1.Controller.Tools.Add(new NAxisScrollTool());
            nChartControl1.Controller.Tools.Add(new NRangeSelectionMoveResizeTool());

            nChartControl1.RecalcLayout();

            // link the x axes of the charts
            m_Chart1.Axis(StandardAxis.PrimaryX).Scale.RulerRangeChanged += new EventHandler(Scale_RulerRangeChanged);
            rangeSelection.HorizontalAxisRangeChanged += new EventHandler(rangeSelection_HorizontalAxisRangeChanged);
            rangeSelection.HorizontalAxisRange = new NRange1DD((double)area2.XValues[0], (double)area2.XValues[100]);
		}

        void Scale_RulerRangeChanged(object sender, EventArgs e)
        {
            ((NRangeSelection)m_Chart2.RangeSelections[0]).HorizontalAxisRange = m_Chart1.Axis(StandardAxis.PrimaryX).Scale.RulerRange;
        }

        void rangeSelection_HorizontalAxisRangeChanged(object sender, EventArgs e)
        {
            m_Chart1.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(((NRangeSelection)m_Chart2.RangeSelections[0]).HorizontalAxisRange, 0.1);
        }

        internal void GenerateOHLCData(NAreaSeries areaSeries, double prevValue, int nCount)
        {
            double value, open;
            DateTime dt = DateTime.Now;
            NRange1DD range = new NRange1DD(10, 1000);

            for (int nIndex = 0; nIndex < nCount; nIndex++)
            {
                open = prevValue;
                bool upward = false;

                if (range.Begin > prevValue)
                {
                    upward = true;
                }
                else if (range.End < prevValue)
                {
                    upward = false;
                }
                else
                {
                    upward = Random.NextDouble() > 0.5;
                }

                if (upward)
                {
                    // upward price change
                    value = open + (2 + (Random.NextDouble() * 20));
                }
                else
                {
                    // downward price change
                    value = open - (2 + (Random.NextDouble() * 20));
                }

                if (value < 1)
                    value = 1;

                prevValue = value;

                areaSeries.Values.Add(value);

                while (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    dt = dt.AddDays(1);
                }

                areaSeries.XValues.Add(nIndex);
//                areaSeries.XValues.Add(dt.ToOADate());
                dt = dt.AddDays(1);
            }
        }
	}
}
