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
	public partial class NHeatMapCrossSectionUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;

		NHeatMapSeries m_HeatMap;
        NPointSeries m_BeginEndPointSeries;
        NLineSeries m_BeginEndLineSeries;
        NLineSeries m_CrossLineSeries;
        int m_GridSizeX = 500;
        int m_GridSizeY = 500;
        private UI.WinForm.Controls.NTextBox ValueTextBox;
        private Label label4;
		



        public NHeatMapCrossSectionUC()
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
            this.ValueTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(3, 35);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.ReadOnly = true;
            this.ValueTextBox.Size = new System.Drawing.Size(169, 18);
            this.ValueTextBox.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Value:";
            // 
            // NHeatMapCrossSectionUC
            // 
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.label4);
            this.Name = "NHeatMapCrossSectionUC";
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
                heatMapChart.Margins = new NMarginsL(10);
                heatMapChart.BoundsMode = BoundsMode.Stretch;
                heatMapChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();

                m_BeginEndPointSeries = new NPointSeries();

                m_BeginEndPointSeries.Legend.Mode = SeriesLegendMode.None;
                m_BeginEndPointSeries.UseXValues = true;
                m_BeginEndPointSeries.DataLabelStyle.Visible = false;
                m_BeginEndPointSeries.MarkerStyle.Visible = false;
                m_BeginEndPointSeries.Size = new NLength(8);
                m_BeginEndPointSeries.PointShape = PointShape.Ellipse;
                m_BeginEndPointSeries.BorderStyle.Width = new NLength(0);

                m_BeginEndPointSeries.Values.Add(m_GridSizeY / 4);
                m_BeginEndPointSeries.XValues.Add(m_GridSizeX / 4);
                m_BeginEndPointSeries.FillStyles.Add(0, new NColorFillStyle(Color.Red));

                m_BeginEndPointSeries.Values.Add(m_GridSizeY * 3 / 4);
                m_BeginEndPointSeries.XValues.Add(m_GridSizeX * 3 / 4);
                m_BeginEndPointSeries.FillStyles.Add(1, new NColorFillStyle(Color.Blue));

                heatMapChart.Series.Add(m_BeginEndPointSeries);

                m_BeginEndLineSeries = new NLineSeries();
                m_BeginEndLineSeries.UseXValues = true;
                m_BeginEndLineSeries.DataLabelStyle.Visible = false;
                heatMapChart.Series.Add(m_BeginEndLineSeries);

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
                m_HeatMap.InterpolateImage = false;

                m_HeatMap.ContourDisplayMode = ContourDisplayMode.None;
                m_HeatMap.Legend.Mode = SeriesLegendMode.SeriesLogic;
                m_HeatMap.Legend.Format = "<zone_value>";

                GenerateData();
            }

            {
                NCartesianChart crossSectionLineChart = new NCartesianChart();
                
                nChartControl1.Panels.Add(crossSectionLineChart);

                crossSectionLineChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
                crossSectionLineChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.Title.Text = "Distance";
                crossSectionLineChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Title.Text = "Value";

                crossSectionLineChart.DockMode = PanelDockMode.Left;
                crossSectionLineChart.Size = new NSizeL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(0));
                crossSectionLineChart.Margins = new NMarginsL(10);
                crossSectionLineChart.BoundsMode = BoundsMode.Stretch;

                m_CrossLineSeries = new NLineSeries();
                m_CrossLineSeries.DataLabelStyle.Visible = false;
                m_CrossLineSeries.UseXValues = true;
                crossSectionLineChart.Series.Add(m_CrossLineSeries);
            }

            nChartControl1.Controller.Tools.Add(new NSelectorTool());

            nChartControl1.MouseMove += new MouseEventHandler(nChartControl1_MouseMove);

            NDataPointDragTool dataPointDragTool = new NDataPointDragTool();

            dataPointDragTool.DataPointChanged += new EventHandler(OnDataPointDragToolDataPointChanged);
            dataPointDragTool.DragOutsideAxisRangeMode = DragOutsideAxisRangeMode.Disabled;
            nChartControl1.Controller.Tools.Add(dataPointDragTool);

            OnDataPointDragToolDataPointChanged(null, null);
        }

        void nChartControl1_MouseMove(object sender, MouseEventArgs e)
        {
            NViewToScale2DTransformation view2Scale = new NViewToScale2DTransformation(nChartControl1.Charts[0], (int)StandardAxis.PrimaryX, (int)StandardAxis.PrimaryY);

            NVector2DD pointScale = new NVector2DD();
            view2Scale.Transform(new NPointF(e.X, e.Y), ref pointScale);

            this.ValueTextBox.Text = m_HeatMap.GetValueFromPosition(new NPointD(pointScale.X, pointScale.Y)).ToString();
        }

        void OnDataPointDragToolDataPointChanged(object sender, EventArgs e)
        {
            // copy the point values to the line series
            m_BeginEndLineSeries.Values.Clear();
            m_BeginEndLineSeries.XValues.Clear();

            for (int i = 0; i < m_BeginEndPointSeries.Values.Count; i++)
            {
                m_BeginEndLineSeries.Values.Add(m_BeginEndPointSeries.Values[i]);
                m_BeginEndLineSeries.XValues.Add(m_BeginEndPointSeries.XValues[i]);
            }

            List<NVector2DD> intersections = m_HeatMap.Get2DIntersections(  new NPointD((double)m_BeginEndPointSeries.XValues[0], (double)m_BeginEndPointSeries.Values[0]),
                                                                            new NPointD((double)m_BeginEndPointSeries.XValues[1], (double)m_BeginEndPointSeries.Values[1]));

            int count = intersections.Count; 

            m_CrossLineSeries.Values.Clear();
            m_CrossLineSeries.XValues.Clear();

            for (int i = 0; i < count; i++)
            {
                NVector2DD intersection = intersections[i];

                m_CrossLineSeries.Values.Add(intersection.Y);
                m_CrossLineSeries.XValues.Add(intersection.X);
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
