using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.UI;
using System.IO;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NGridSurfaceHorizontalCrossSectionUC : NExampleBaseUC
	{
		NLineSeries m_ContourLineSeries;
		NAxisConstLine m_CrossSectionPlane;

		public NGridSurfaceHorizontalCrossSectionUC()
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
				return "Grid Surface Horizontal Crosss Section";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates how to get the cross section of a grid surface at specified Y value. Change the horizontal plane value on the left. The cross section will be displayed both as an isoline and projected contour at the top of the chart.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Surface Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(Color.Gray);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 25.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			// setup axes
			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			chart.Axis(StandardAxis.SecondaryY).Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 100.0f, 100.0f);
			chart.Axis(StandardAxis.SecondaryY).Visible = false;

			m_ContourLineSeries = new NLineSeries();
			chart.Series.Add(m_ContourLineSeries);

			m_ContourLineSeries.UseXValues = true;
			m_ContourLineSeries.UseZValues = true;
			m_ContourLineSeries.BorderStyle.Width = new NLength(2);
			m_ContourLineSeries.BorderStyle.Color = Color.Red;

			m_ContourLineSeries.DataLabelStyle.Visible = false;
			m_ContourLineSeries.DisplayOnAxis((int)StandardAxis.PrimaryY, false);
			m_ContourLineSeries.DisplayOnAxis((int)StandardAxis.SecondaryY, true);
			m_ContourLineSeries.Legend.Mode = SeriesLegendMode.None;

			m_CrossSectionPlane = new NAxisConstLine();
			m_CrossSectionPlane.Mode = ConstLineMode.Plane;
			m_CrossSectionPlane.FillStyle = new NColorFillStyle(Color.FromArgb(25, Color.Blue));
			chart.Axis(StandardAxis.PrimaryY).ConstLines.Add(m_CrossSectionPlane);

			// add the surface series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Surface";
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.PositionValue = 10.0;
			surface.Data.SetGridSize(31, 32);
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 8;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);
			surface.Isolines.Add(new NSurfaceIsoline(10, new NStrokeStyle(2.0f, Color.Blue)));
			surface.FrameColorMode = SurfaceFrameColorMode.Uniform;

			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			CrossSectionValue.Value = 10;
		}

		private void FillData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 10.0;
			const double dIntervalZ = 10.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = 10 - Math.Sqrt((x * x) + (z * z) + 2);
					y += 3.0 * Math.Sin(x) * Math.Cos(z);

					surface.Data.SetValue(i, j, y);
				}
			}
		}

		private void CrossSectionValue_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			double value = (double)CrossSectionValue.Value;
			NGridSurfaceSeries surface = nChartControl1.Charts[0].Series[1] as NGridSurfaceSeries;

			if (surface.Isolines.Count > 0)
			{
				surface.Isolines[0].Value = value;
			}

			m_CrossSectionPlane.Value = value;

			NLevelPath path = surface.GetContourForValue(value);

			m_ContourLineSeries.XValues.Clear();
			m_ContourLineSeries.ZValues.Clear();
			m_ContourLineSeries.Values.Clear();

			foreach (NLevelContour contour in path)
			{
				if (contour.Count > 0)
				{
					int index = m_ContourLineSeries.XValues.Count + 1;
					int pointCount = contour.Count;
					for (int i = 0; i < pointCount; i++)
					{
						NPointD point = contour[i];
						m_ContourLineSeries.XValues.Add(point.X);
						m_ContourLineSeries.ZValues.Add(point.Y);
						m_ContourLineSeries.Values.Add(0);
					}

					m_ContourLineSeries.XValues.Add(m_ContourLineSeries.XValues[index]);
					m_ContourLineSeries.ZValues.Add(m_ContourLineSeries.ZValues[index]);
					m_ContourLineSeries.Values.Add(0);

					m_ContourLineSeries.XValues.Add(double.NaN);
					m_ContourLineSeries.ZValues.Add(double.NaN);
					m_ContourLineSeries.Values.Add(double.NaN);
				}
			}

			nChartControl1.Refresh();
		}
	}
}
