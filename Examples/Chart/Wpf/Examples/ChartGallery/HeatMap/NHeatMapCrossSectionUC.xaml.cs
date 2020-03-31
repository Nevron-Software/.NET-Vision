using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NHeatMapCrossSectionUC : NExampleBaseUC
	{
		NHeatMapSeries m_HeatMap;
		NPointSeries m_BeginEndPointSeries;
		NLineSeries m_BeginEndLineSeries;
		NLineSeries m_CrossLineSeries;
		int m_GridSizeX = 500;
		int m_GridSizeY = 500;

		public NHeatMapCrossSectionUC()
		{
			InitializeComponent();
		}
		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Heat Map Cross Section";
			}
		}
		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
                return "The example demonstrates how to create a cross section of the heat map based on artbitraty begin and end point. Press the mouse over the red or blue point and begin to drag. The cross section will change depending on the currently crossed heatmap values.";
			}
		}
		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Panels.Clear();	

			// set a chart title
			NLabel title = new NLabel("Heat Map Cross Section");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
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

			NDataPointDragTool dataPointDragTool = new NDataPointDragTool();

			dataPointDragTool.DataPointChanged += new EventHandler(OnDataPointDragToolDataPointChanged);
			dataPointDragTool.DragOutsideAxisRangeMode = DragOutsideAxisRangeMode.Disabled;
			nChartControl1.Controller.Tools.Add(dataPointDragTool);

			OnDataPointDragToolDataPointChanged(null, null);

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

			List<NVector2DD> intersections = m_HeatMap.Get2DIntersections(new NPointD((double)m_BeginEndPointSeries.XValues[0], (double)m_BeginEndPointSeries.Values[0]),
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
