using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.Editors;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public partial class NHeatMapCrossSectionXYUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;

		NHeatMapSeries m_HeatMap;
        NLineSeries m_XCrossLineSeries;
        NLineSeries m_YCrossLineSeries;
        NAxisCursor m_XCursor;
        NAxisCursor m_YCursor;
        int m_GridSizeX = 500;
        int m_GridSizeY = 500;

        public NHeatMapCrossSectionXYUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}

			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // NHeatMapCrossSectionXYUC
            // 
            this.Name = "NHeatMapCrossSectionXYUC";
            this.Size = new System.Drawing.Size(179, 516);
            this.ResumeLayout(false);

		}

		#endregion
		
		public override void Initialize()
        {
            base.Initialize();

            nChartControl1.Panels.Clear();

            // set a chart title
            NLabel title = new NLabel("Heat Map Cross Section");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
            title.DockMode = PanelDockMode.Top;
            nChartControl1.Panels.Add(title);

            {
                NCartesianChart heatMapChart = new NCartesianChart();
                nChartControl1.Panels.Add(heatMapChart);

                heatMapChart.DockMode = PanelDockMode.Left;
                heatMapChart.Size = new NSizeL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(0));
                heatMapChart.BoundsMode = BoundsMode.Stretch;
                heatMapChart.Margins = new NMarginsL(10);
                heatMapChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
                heatMapChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.Title.Text = "X Value";
                heatMapChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Title.Text = "Y Value";

                // create the heat map 
                m_HeatMap = new NHeatMapSeries();
                heatMapChart.Series.Add(m_HeatMap);

                m_HeatMap.Palette.Add(0.0, Color.Purple);
                m_HeatMap.Palette.Add(1.5, Color.MediumSlateBlue);
                m_HeatMap.Palette.Add(3.0, Color.CornflowerBlue);
                m_HeatMap.Palette.Add(4.5, Color.LimeGreen);
                m_HeatMap.Palette.Add(6.0, Color.LightGreen);
                m_HeatMap.Palette.Add(7.5, Color.Yellow);
                m_HeatMap.Palette.Add(9.0, Color.Orange);
                m_HeatMap.Palette.Add(10.5, Color.Red);
                m_HeatMap.XValuesMode = HeatMapValuesMode.OriginAndStep;
                m_HeatMap.YValuesMode = HeatMapValuesMode.OriginAndStep;
                m_HeatMap.InterpolateImage = true;

                m_HeatMap.ContourDisplayMode = ContourDisplayMode.None;
                m_HeatMap.Legend.Mode = SeriesLegendMode.SeriesLogic;
                m_HeatMap.Legend.Format = "<zone_value>";

                m_XCursor = new NAxisCursor();
                m_XCursor.BeginEndAxis = (int)StandardAxis.PrimaryY;
                m_XCursor.StrokeStyle.Width = new NLength(2);
                heatMapChart.Axis(StandardAxis.PrimaryX).Cursors.Add(m_XCursor);
                m_XCursor.ValueChanged += new EventHandler(OnXCursorValueChanged);

                m_YCursor = new NAxisCursor();
                m_YCursor.BeginEndAxis = (int)StandardAxis.PrimaryX;
                m_YCursor.StrokeStyle.Width = new NLength(2);
                heatMapChart.Axis(StandardAxis.PrimaryY).Cursors.Add(m_YCursor);
                m_YCursor.ValueChanged += new EventHandler(OnYCursorValueChanged);

                GenerateData();
            }

            {
                NDockPanel dockPanel = new NDockPanel();
                dockPanel.DockMode = PanelDockMode.Fill;
                dockPanel.PositionChildPanelsInContentBounds = true;
                dockPanel.Margins = new NMarginsL(10);

                NCartesianChart xCrossSectionChart;
                CreateCrossSectionChart(out xCrossSectionChart, out m_XCrossLineSeries);
                xCrossSectionChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.Title.Text = "X Value";
                xCrossSectionChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Title.Text = "Value";
                dockPanel.ChildPanels.Add(xCrossSectionChart);

                NCartesianChart yCrossSectionChart;
                CreateCrossSectionChart(out yCrossSectionChart, out m_YCrossLineSeries);
                yCrossSectionChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.Title.Text = "Y Value";
                yCrossSectionChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Title.Text = "Value";
                dockPanel.ChildPanels.Add(yCrossSectionChart);

                nChartControl1.Panels.Add(dockPanel);

                // align the two charts
                NSideGuideline guideline = new NSideGuideline(PanelSide.Left);

                guideline.Targets.Add(xCrossSectionChart);
                guideline.Targets.Add(yCrossSectionChart);

                nChartControl1.Document.RootPanel.Guidelines.Add(guideline);
            }

            m_XCursor.Value = m_GridSizeX / 2.0;
            m_YCursor.Value = m_GridSizeY / 2.0;

            nChartControl1.Controller.Tools.Add(new NSelectorTool());
            nChartControl1.Controller.Tools.Add(new NAxisCursorDragTool());
        }

        private void CreateCrossSectionChart(out NCartesianChart chart, out NLineSeries lineSeries)
        {
            chart = new NCartesianChart();
            chart.DockMode = PanelDockMode.Top;
            chart.Size = new NSizeL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
            chart.BoundsMode = BoundsMode.Stretch;

            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
            lineSeries = new NLineSeries();
            lineSeries.DataLabelStyle.Visible = false;
            lineSeries.UseXValues = true;
            chart.Series.Add(lineSeries);
        }

        void OnYCursorValueChanged(object sender, EventArgs e)
        {
            NAxisCursor yCursor = (NAxisCursor)sender;

            List<NVector2DD> intersections = m_HeatMap.Get2DIntersections(new NPointD(0, yCursor.Value), new NPointD(m_HeatMap.Data.GridSizeX, yCursor.Value));

            m_YCrossLineSeries.Values.Clear();
            m_YCrossLineSeries.XValues.Clear();

            for (int i = 0; i < intersections.Count; i++)
            {
                m_YCrossLineSeries.Values.Add(intersections[i].Y);
                m_YCrossLineSeries.XValues.Add(intersections[i].X);
            }

            nChartControl1.Refresh();            
        }

        void OnXCursorValueChanged(object sender, EventArgs e)
        {
            NAxisCursor xCursor = (NAxisCursor)sender;

            List<NVector2DD> intersections = m_HeatMap.Get2DIntersections(new NPointD(xCursor.Value, 0), new NPointD(xCursor.Value, m_HeatMap.Data.GridSizeY));

            m_XCrossLineSeries.Values.Clear();
            m_XCrossLineSeries.XValues.Clear();

            for (int i = 0; i < intersections.Count; i++)
            {
                m_XCrossLineSeries.Values.Add(intersections[i].Y);
                m_XCrossLineSeries.XValues.Add(intersections[i].X);
            }

            nChartControl1.Refresh();
        }
        
        private void GenerateData()
        {
            NHeatMapData data = m_HeatMap.Data;
            data.SetGridSize(m_GridSizeX, m_GridSizeY);

            const double dIntervalX = 10.0;
            const double dIntervalZ = 10.0;
            double dIncrementX = (dIntervalX / m_GridSizeX);
            double dIncrementZ = (dIntervalZ / m_GridSizeY);

            double y, x, z;

            z = -(dIntervalZ / 2);

            for (int col = 0; col < m_GridSizeX; col++, z += dIncrementZ)
            {
                x = -(dIntervalX / 2);

                for (int row = 0; row < m_GridSizeY; row++, x += dIncrementX)
                {
                    y = 10 - Math.Sqrt((x * x) + (z * z) + 2);
                    y += 3.0 * Math.Sin(x) * Math.Cos(z);

                    double value = y;

                    data.SetValue(row, col, value);
                }
            }
        }
	}
}
