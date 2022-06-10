using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NGridSurfaceVerticalCrossSectionUC : NExampleBaseUC
	{
		NDragPlane m_DragPlane;
		NDragPlaneTool m_DragPlaneTool;
		NLineSeries m_CrossSection2DSeries;
		NPointSeries m_CrossSection3DSeries;
		NGridSurfaceSeries m_SurfaceSeries;

		public NGridSurfaceVerticalCrossSectionUC()
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
				return "Grid Surface Vertical Crosss Section";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates how to get the cross section of a grid surface given begin and end point on the XY grid. Press the mouse over the red or blue surface end points and begin to drag. On the right side you can control the plane in which the point dragging occurs.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed;

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = new NLabel("Grid Surface Cross Section");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.DockMode = PanelDockMode.Top;
			title.Margins = new NMarginsL(10);
			nChartControl1.Panels.Add(title);

			NDockPanel containerPanel = new NDockPanel();
			containerPanel.PositionChildPanelsInContentBounds = true;
			containerPanel.Margins = new NMarginsL(10, 0, 10, 10);
			containerPanel.DockMode = PanelDockMode.Fill;
			nChartControl1.Panels.Add(containerPanel);

			// configure the chart
			NCartesianChart surfaceChart = new NCartesianChart();
			containerPanel.ChildPanels.Add(surfaceChart);
			surfaceChart.DockMode = PanelDockMode.Top;
			surfaceChart.Size = new NSizeL(new NLength(0.0f), new NLength(70.0f, NRelativeUnit.ParentPercentage));
			surfaceChart.Enable3D = true;
			surfaceChart.Width = 60.0f;
			surfaceChart.Depth = 60.0f;
			surfaceChart.Height = 15.0f;
			surfaceChart.BoundsMode = BoundsMode.Fit;
			surfaceChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			surfaceChart.Projection.Elevation = 22;
			surfaceChart.Projection.Rotation = -68;
			surfaceChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			// setup axes
			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)surfaceChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			ordinalScale = (NOrdinalScaleConfigurator)surfaceChart.Axis(StandardAxis.Depth).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			// add the surface series
			m_SurfaceSeries = new NGridSurfaceSeries();
			surfaceChart.Series.Add(m_SurfaceSeries);
			m_SurfaceSeries.Name = "Surface";
			m_SurfaceSeries.Legend.Mode = SeriesLegendMode.SeriesLogic;
			m_SurfaceSeries.PositionValue = 10.0;
			m_SurfaceSeries.Data.SetGridSize(1000, 1000);
			m_SurfaceSeries.SyncPaletteWithAxisScale = false;
			m_SurfaceSeries.PaletteSteps = 8;
			m_SurfaceSeries.ValueFormatter.FormatSpecifier = "0.00";
			m_SurfaceSeries.FillStyle = new NColorFillStyle(Color.YellowGreen);
			m_SurfaceSeries.ShadingMode = ShadingMode.Smooth;
			m_SurfaceSeries.FrameMode = SurfaceFrameMode.None;
			m_SurfaceSeries.FillMode = SurfaceFillMode.ZoneTexture;

			// add the cross section line series
			m_CrossSection3DSeries = new NPointSeries();
			surfaceChart.Series.Add(m_CrossSection3DSeries);
			m_CrossSection3DSeries.Size = new NLength(10);
			m_CrossSection3DSeries.PointShape = PointShape.Sphere;
			m_CrossSection3DSeries.FillStyle = new NColorFillStyle(Color.Red);
			m_CrossSection3DSeries.DataLabelStyle.Visible = false;
			m_CrossSection3DSeries.UseXValues = true;
			m_CrossSection3DSeries.UseZValues = true;

			FillData(m_SurfaceSeries);

			NCartesianChart crossSectionChart = new NCartesianChart();

			crossSectionChart.BoundsMode = BoundsMode.Stretch;
			crossSectionChart.DockMode = PanelDockMode.Fill;
			crossSectionChart.Margins = new NMarginsL(0, 10, 0, 0);

			crossSectionChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();
			crossSectionChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.Title.Text = "Distance";
			crossSectionChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Title.Text = "Value";

			m_CrossSection2DSeries = new NLineSeries();
			m_CrossSection2DSeries.DataLabelStyle.Visible = false;
			m_CrossSection2DSeries.UseXValues = true;
			crossSectionChart.Series.Add(m_CrossSection2DSeries);

			containerPanel.ChildPanels.Add(crossSectionChart);

			nChartControl1.View.RecalcLayout();

			NRange1DD xAxisRange = surfaceChart.Axis(StandardAxis.PrimaryX).Scale.RulerRange;
			NRange1DD yAxisRange = surfaceChart.Axis(StandardAxis.PrimaryY).Scale.RulerRange;
			NRange1DD zAxisRange = surfaceChart.Axis(StandardAxis.Depth).Scale.RulerRange;

			m_DragPlane = new NDragPlane(
						new NVector3DD(0, yAxisRange.End, 0),
						new NVector3DD(xAxisRange.End, yAxisRange.End, zAxisRange.End),
						new NVector3DD(xAxisRange.End, 0, zAxisRange.End),
						new NVector3DD(0, 0, 0)
						);

			m_DragPlane.DragPlaneChanged += new EventHandler(OnDragPlaneChanged);
			m_DragPlaneTool = new NDragPlaneTool(m_DragPlane);
			m_DragPlaneTool.DragPlane = DragPlaneSurface.XZ;
			m_DragPlane.AddToChart(surfaceChart);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(m_DragPlaneTool);
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// enable fixed axis ranges
			surfaceChart.Axis(StandardAxis.PrimaryX).View = new NRangeAxisView(xAxisRange, true, true);
			surfaceChart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(yAxisRange, true, true);
			surfaceChart.Axis(StandardAxis.Depth).View = new NRangeAxisView(zAxisRange, true, true);

			// turn off plot box clipping
			surfaceChart.Axis(StandardAxis.PrimaryX).ClipMode = AxisClipMode.Never;
			surfaceChart.Axis(StandardAxis.PrimaryY).ClipMode = AxisClipMode.Never;
			surfaceChart.Axis(StandardAxis.Depth).ClipMode = AxisClipMode.Never;

			// update the cross section
			OnDragPlaneChanged(null, null);
		}

		private void FillData(NGridSurfaceSeries surface)
		{
			Stream stream = null;
			BinaryReader reader = null;

			try
			{
				// fill the XYZ data from a binary resource
				stream = NResourceHelper.GetResourceStream(GetType().Assembly, "DataY.bin", "Nevron.Examples.Chart.Wpf.Resources");
				reader = new BinaryReader(stream);

				int dataPointsCount = (int)(stream.Length / 4);
				int sizeX = (int)Math.Sqrt(dataPointsCount);
				int sizeZ = sizeX;

				surface.Data.SetGridSize(sizeX, sizeZ);

				for (int z = 0; z < sizeZ; z++)
				{
					for (int x = 0; x < sizeX; x++)
					{
						surface.Data.SetValue(x, z, reader.ReadSingle());
					}
				}
			}
			finally
			{
				if (reader != null)
					reader.Close();

				if (stream != null)
					stream.Close();
			}
		}

		void OnDragPlaneChanged(object sender, EventArgs e)
		{
			List<NVector3DD> intersections3D = m_SurfaceSeries.Get3DIntersections(new NPointD(m_DragPlane.PointA.X, m_DragPlane.PointA.Z), new NPointD(m_DragPlane.PointB.X, m_DragPlane.PointB.Z));
			List<NVector2DD> intersections2D = m_SurfaceSeries.Get2DIntersections(new NPointD(m_DragPlane.PointA.X, m_DragPlane.PointA.Z), new NPointD(m_DragPlane.PointB.X, m_DragPlane.PointB.Z));

			m_CrossSection3DSeries.ClearDataPoints();

			for (int i = 0; i < intersections3D.Count; i++)
			{
				NVector3DD intersection3D = intersections3D[i];

				m_CrossSection3DSeries.Values.Add(intersection3D.Z);
				m_CrossSection3DSeries.XValues.Add(intersection3D.X);
				m_CrossSection3DSeries.ZValues.Add(intersection3D.Y);
			}

			m_CrossSection2DSeries.ClearDataPoints();

			for (int i = 0; i < intersections2D.Count; i++)
			{
				NVector2DD intersection2D = intersections2D[i];

				m_CrossSection2DSeries.Values.Add(intersection2D.Y);
				m_CrossSection2DSeries.XValues.Add(intersection2D.X);
			}

			nChartControl1.Refresh();
		}


		public enum DragPlaneSurface
		{
			XY,
			XZ,
			ZY
		}
		[Serializable]
		public class NDragPlaneTool : NDragTool
		{
			#region Constructors

			/// <summary>
			/// Initializer constructor
			/// </summary>
			/// <param name="dragPlane"></param>
			public NDragPlaneTool(NDragPlane dragPlane)
			{
				m_DragPlane = dragPlane;
				m_OriginalPosition = new NVector3DD();
			}

			#endregion

			#region Properties

			/// <summary>
			/// The freedom plane
			/// </summary>
			public DragPlaneSurface DragPlane
			{
				get
				{
					return m_DragPlaneSurface;
				}
				set
				{
					m_DragPlaneSurface = value;
				}
			}

			#endregion

			#region Overrides

			/// <summary>
			/// Return true if dragging can start
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			/// <returns></returns>
			public override bool CanBeginDrag(object sender, Nevron.Chart.Windows.NMouseEventArgs e)
			{
				if (!base.CanBeginDrag(sender, e))
					return false;

				NPoint point = new NPoint(e.X, e.Y);
				NPointSeries pointSeries = m_DragPlane.PointSeries;
				NChart chart = pointSeries.Chart;
				NModel3DToViewTransformation model3DToViewTransformation = new NModel3DToViewTransformation(GetView().Context, chart.Projection);

				float xHotSpotArea = 10;
				float yHotSpotArea = 10;

				int dataPointIndex = -1;

				for (int i = 0; i < pointSeries.Values.Count; i++)
				{
					double x = (double)pointSeries.XValues[i];
					double y = (double)pointSeries.Values[i];
					double z = (double)pointSeries.ZValues[i];

					NVector3DF vecModelPoint;
					vecModelPoint.X = chart.Axis(StandardAxis.PrimaryX).TransformScaleToModel(false, x);
					vecModelPoint.Y = chart.Axis(StandardAxis.PrimaryY).TransformScaleToModel(false, y);
					vecModelPoint.Z = chart.Axis(StandardAxis.Depth).TransformScaleToModel(false, z);

					NPointF viewPoint = NPointF.Empty;
					model3DToViewTransformation.Transform(vecModelPoint, ref viewPoint);

					if (Math.Abs(viewPoint.X - point.X) < xHotSpotArea &&
						Math.Abs(viewPoint.Y - point.Y) < yHotSpotArea)
					{
						dataPointIndex = i;
						break;
					}
				}

				if (dataPointIndex == -1)
					return false;

				m_DataPointIndex = dataPointIndex;
				m_OriginalPosition = m_DragPlane.GetVectorFromPoint(m_DataPointIndex);

				return true;
			}
			/// <summary>
			/// Overriden to perform dragging
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			public override void OnDoDrag(object sender, Nevron.Chart.Windows.NMouseEventArgs e)
			{
				NChart chart = this.GetDocument().Charts[0];

				Trace.WriteLine("X:" + e.X.ToString() + ", Y:" + e.Y.ToString());
				NViewToScale3DTransformation viewToScale;

				switch (m_DragPlaneSurface)
				{
					case DragPlaneSurface.XY:
						viewToScale = new NViewToScale3DTransformation(chart, (int)StandardAxis.PrimaryX, (int)StandardAxis.PrimaryY, (int)StandardAxis.Depth, m_OriginalPosition.Z);
						break;
					case DragPlaneSurface.XZ:
						viewToScale = new NViewToScale3DTransformation(chart, (int)StandardAxis.PrimaryX, (int)StandardAxis.Depth, (int)StandardAxis.PrimaryY, m_OriginalPosition.Y);
						break;
					case DragPlaneSurface.ZY:
						viewToScale = new NViewToScale3DTransformation(chart, (int)StandardAxis.Depth, (int)StandardAxis.PrimaryY, (int)StandardAxis.PrimaryX, m_OriginalPosition.X);
						break;
					default:
						Debug.Assert(false); // new drag plane
						return;
				}

				NVector3DD vecNewPosition = new NVector3DD();
				viewToScale.Transform(new NPointF(e.X, e.Y), ref vecNewPosition);

				m_DragPlane.MovePoint(m_DragPlaneSurface, vecNewPosition, m_DataPointIndex);
				m_DragPlane.PointSeries.Document.Refresh();
			}
			/// <summary>
			/// Overriden to rever the state to the original one if the user presses Esc key
			/// </summary>
			public override void CancelOperation()
			{
				base.CancelOperation();

				m_DragPlane.RestorePoint(m_DataPointIndex, m_OriginalPosition);
				m_DragPlane.PointSeries.Document.Refresh();
			}

			#endregion

			#region Implementation

			/// <summary>
			/// Gets the selected data points
			/// </summary>
			/// <returns></returns>
			protected ArrayList GetSelectedDataPoints()
			{
				NSelection selection = GetSelection();

				if (selection == null)
					return null;

				return selection.GetSelectedObjectsOfType(typeof(NDataPoint));
			}

			#endregion

			#region Fields

			/// <summary>
			/// The original position of the point
			/// </summary>
			protected NVector3DD m_OriginalPosition;
			/// <summary>
			/// The data point index
			/// </summary>
			protected int m_DataPointIndex;
			/// <summary>
			/// The freedom plane
			/// </summary>
			protected DragPlaneSurface m_DragPlaneSurface;
			/// <summary>
			/// 
			/// </summary>
			protected NDragPlane m_DragPlane;

			#endregion
		}
		public class NDragPlane
		{
			#region Constructors

			/// <summary>
			/// Initializer constructor
			/// </summary>
			/// <param name="vecA"></param>
			/// <param name="vecB"></param>
			/// <param name="vecC"></param>
			/// <param name="vecD"></param>
			public NDragPlane(NVector3DD vecA, NVector3DD vecB, NVector3DD vecC, NVector3DD vecD)
			{
				NPointSeries pointSeries = new NPointSeries();

				pointSeries.Tag = (int)1;
				pointSeries.PointShape = PointShape.Sphere;
				pointSeries.UseXValues = true;
				pointSeries.UseZValues = true;
				pointSeries.DataLabelStyle.Visible = false;
				pointSeries.InflateMargins = false;
				pointSeries.Size = new NLength(8);

				pointSeries.Values.Add(vecA.Y);
				pointSeries.XValues.Add(vecA.X);
				pointSeries.ZValues.Add(vecA.Z);
				pointSeries.FillStyles[0] = new NColorFillStyle(Color.Red);

				pointSeries.Values.Add(vecB.Y);
				pointSeries.XValues.Add(vecB.X);
				pointSeries.ZValues.Add(vecB.Z);
				pointSeries.FillStyles[1] = new NColorFillStyle(Color.Blue);

				pointSeries.Values.Add(vecC.Y);
				pointSeries.XValues.Add(vecC.X);
				pointSeries.ZValues.Add(vecC.Z);
				pointSeries.FillStyles[2] = new NColorFillStyle(Color.Red);


				pointSeries.Values.Add(vecD.Y);
				pointSeries.XValues.Add(vecD.X);
				pointSeries.ZValues.Add(vecD.Z);
				pointSeries.FillStyles[3] = new NColorFillStyle(Color.Blue);

				m_PointSeries = pointSeries;

				NMeshSurfaceSeries meshSeries = new NMeshSurfaceSeries();
				meshSeries.Data.SetGridSize(2, 2);

				m_MeshSurface = meshSeries;
				m_MeshSurface.FillMode = SurfaceFillMode.Uniform;
				m_MeshSurface.FrameMode = SurfaceFrameMode.None;
				m_MeshSurface.FillStyle = new NColorFillStyle(Color.Blue);
				m_MeshSurface.FillStyle.SetTransparencyPercent(50.0f);

				UpdateMeshSurface();
			}

			#endregion

			#region Properties

			/// <summary>
			/// Gets the point series
			/// </summary>
			public NPointSeries PointSeries
			{
				get
				{
					return m_PointSeries;
				}
			}
			/// <summary>
			/// Gets the mesh surface
			/// </summary>
			public NMeshSurfaceSeries MeshSurface
			{
				get
				{
					return m_MeshSurface;
				}
			}
			/// <summary>
			/// Gets the A point
			/// </summary>
			public NVector3DD PointA
			{
				get
				{
					return GetVectorFromPoint(0);
				}
			}
			/// <summary>
			/// Gets the B point
			/// </summary>
			public NVector3DD PointB
			{
				get
				{
					return GetVectorFromPoint(1);
				}
			}
			/// <summary>
			/// Gets the C point
			/// </summary>
			public NVector3DD PointC
			{
				get
				{
					return GetVectorFromPoint(2);
				}
			}
			/// <summary>
			/// Gets the D point
			/// </summary>
			public NVector3DD PointD
			{
				get
				{
					return GetVectorFromPoint(3);
				}
			}
			/// <summary>
			/// Gets or sets whether to lock the x coordinate
			/// </summary>
			public bool LockX
			{
				get
				{
					return m_LockX;
				}
				set
				{
					m_LockX = value;
				}
			}
			/// <summary>
			/// Gets or sets whether to lock the z coordinate
			/// </summary>
			public bool LockZ
			{
				get
				{
					return m_LockZ;
				}
				set
				{
					m_LockZ = value;
				}
			}

			#endregion

			#region Methods

			/// <summary>
			/// Adds the plane to the chart
			/// </summary>
			/// <param name="chart"></param>
			public void AddToChart(NChart chart)
			{
				chart.Series.Add(m_MeshSurface);
				chart.Series.Add(m_PointSeries);
			}
			/// <summary>
			/// Drags the specified point
			/// </summary>
			/// <param name="dragPlane"></param>
			/// <param name="vector"></param>
			/// <param name="dataPointIndex"></param>
			public void MovePoint(DragPlaneSurface dragPlane, NVector3DD vector, int dataPointIndex)
			{
				// modify the point coordinates. Don't modify the y coords only x, z or xz
				// take into account the currently selected axes from NViewToScale3DTransformation
				switch (dragPlane)
				{
					case DragPlaneSurface.XY:
						{
							SetXPointCoordinate(dataPointIndex, ClampXCoordinateToRuler(vector.X));
						}
						break;
					case DragPlaneSurface.XZ:
						SetXPointCoordinate(dataPointIndex, ClampXCoordinateToRuler(vector.X));
						SetZPointCoordinate(dataPointIndex, ClampZCoordinateToRuler(vector.Y));
						break;
					case DragPlaneSurface.ZY:
						SetZPointCoordinate(dataPointIndex, ClampXCoordinateToRuler(vector.X));
						break;
				}

				SynchronizePoints(dataPointIndex);
				UpdateMeshSurface();

				FireDragPlaneChanged();
			}
			/// <summary>
			/// Restores the position of the point
			/// </summary>
			/// <param name="dataPointIndex"></param>
			/// <param name="vector"></param>
			public void RestorePoint(int dataPointIndex, NVector3DD vector)
			{
				SetVectorToPoint(dataPointIndex, vector);

				SynchronizePoints(dataPointIndex);
				UpdateMeshSurface();

				FireDragPlaneChanged();
			}
			/// <summary>
			/// Gets the vector from the currently selected point
			/// </summary>
			/// <param name="dataPointIndex"></param>
			/// <returns></returns>
			public NVector3DD GetVectorFromPoint(int dataPointIndex)
			{
				NVector3DD vector;

				vector.X = (double)m_PointSeries.XValues[dataPointIndex];
				vector.Y = (double)m_PointSeries.Values[dataPointIndex];
				vector.Z = (double)m_PointSeries.ZValues[dataPointIndex];

				return vector;
			}

			#endregion

			#region Events

			/// <summary>
			/// Occurs when the drag plane has changed
			/// </summary>
			[field: NonSerialized]
			public event EventHandler DragPlaneChanged;

			/// <summary>
			/// Raises the drag plane changed event
			/// </summary>
			internal void FireDragPlaneChanged()
			{
				if (m_DragPlaneChanged)
				{
					m_DragPlaneChanged = false;

					if (DragPlaneChanged != null)
					{
						DragPlaneChanged(this, new EventArgs());
					}
				}
			}

			#endregion

			#region Implementation

			/// <summary>
			/// Clamps the passed x coordinate to the x axis range
			/// </summary>
			/// <param name="x"></param>
			/// <returns></returns>
			private double ClampXCoordinateToRuler(double x)
			{
				return m_PointSeries.Chart.Axis(StandardAxis.PrimaryX).Scale.RulerRange.GetValueInRange(x);
			}
			/// <summary>
			/// Clamps the passed z coordinate to the x axis range
			/// </summary>
			/// <param name="z"></param>
			/// <returns></returns>
			private double ClampZCoordinateToRuler(double z)
			{
				return m_PointSeries.Chart.Axis(StandardAxis.Depth).Scale.RulerRange.GetValueInRange(z);
			}
			/// <summary>
			/// Synchronizes the points so that they are coplanar
			/// </summary>
			/// <param name="modifiedPointIndex"></param>
			private void SynchronizePoints(int modifiedPointIndex)
			{
				// then align points depending on which point is being dragged
				NVector3DD vecA = GetVectorFromPoint(0);
				NVector3DD vecB = GetVectorFromPoint(1);
				NVector3DD vecC = GetVectorFromPoint(2);
				NVector3DD vecD = GetVectorFromPoint(3);

				switch (modifiedPointIndex)
				{
					case 0: // left top
							// sync point 3 (left bottom)
						{
							NVector3DD vecCB = new NVector3DD();
							vecCB.Subtract(ref vecC, ref vecB);

							vecD.Add(ref vecA, ref vecCB);

							SetVectorToPoint(3, vecD);
						}
						break;
					case 1: // right top
						{
							// sync point 2 (right bottom)
							NVector3DD vecDA = new NVector3DD();
							vecDA.Subtract(ref vecD, ref vecA);

							vecC.Add(ref vecB, ref vecDA);

							SetVectorToPoint(2, vecC);
						}
						break;
					case 2: // right bottom
						{
							// sync point 1 (right top)
							NVector3DD vecAD = new NVector3DD();
							vecAD.Subtract(ref vecA, ref vecD);

							vecB.Add(ref vecC, ref vecAD);

							SetVectorToPoint(1, vecB);
						}
						break;
					case 3: // left bottom
						{
							// sync point 0 (left top)
							NVector3DD vecCB = new NVector3DD();
							vecCB.Subtract(ref vecB, ref vecC);

							vecA.Add(ref vecD, ref vecCB);

							SetVectorToPoint(0, vecA);
						}
						break;
				}

				// handle x / z locking
				if (m_LockX)
				{
					double x = GetVectorFromPoint(modifiedPointIndex).X;
					for (int i = 0; i < 4; i++)
					{
						if (i != modifiedPointIndex)
						{
							SetXPointCoordinate(i, x);
						}
					}
				}

				if (m_LockZ)
				{
					double z = GetVectorFromPoint(modifiedPointIndex).Z;

					for (int i = 0; i < 4; i++)
					{
						if (i != modifiedPointIndex)
						{
							SetZPointCoordinate(i, z);
						}
					}
				}
			}
			/// <summary>
			/// Sets the vector to the specified point
			/// </summary>
			/// <param name="dataPointIndex"></param>
			/// <param name="vector"></param>
			private void SetVectorToPoint(int dataPointIndex, NVector3DD vector)
			{
				SetXPointCoordinate(dataPointIndex, vector.X);
				SetYPointCoordinate(dataPointIndex, vector.Y);
				SetZPointCoordinate(dataPointIndex, vector.Z);
			}
			/// <summary>
			/// Sets an x point coordinate
			/// </summary>
			/// <param name="dataPointIndex"></param>
			/// <param name="x"></param>
			private void SetXPointCoordinate(int dataPointIndex, double x)
			{
				if ((double)m_PointSeries.XValues[dataPointIndex] != x)
				{
					m_DragPlaneChanged = true;
					m_PointSeries.XValues[dataPointIndex] = x;
				}
			}
			/// <summary>
			/// Sets an y point coordinate
			/// </summary>
			/// <param name="dataPointIndex"></param>
			/// <param name="x"></param>
			private void SetYPointCoordinate(int dataPointIndex, double y)
			{
				if ((double)m_PointSeries.XValues[dataPointIndex] != y)
				{
					m_DragPlaneChanged = true;
					m_PointSeries.Values[dataPointIndex] = y;
				}
			}
			/// <summary>
			/// Sets an y point coordinate
			/// </summary>
			/// <param name="dataPointIndex"></param>
			/// <param name="x"></param>
			private void SetZPointCoordinate(int dataPointIndex, double z)
			{
				if ((double)m_PointSeries.XValues[dataPointIndex] != z)
				{
					m_DragPlaneChanged = true;
					m_PointSeries.ZValues[dataPointIndex] = z;
				}
			}
			/// <summary>
			/// Updates the mesh surface from the point series
			/// </summary>
			private void UpdateMeshSurface()
			{
				NVector3DD vecA = GetVectorFromPoint(0);
				NVector3DD vecB = GetVectorFromPoint(1);
				NVector3DD vecC = GetVectorFromPoint(2);
				NVector3DD vecD = GetVectorFromPoint(3);

				m_MeshSurface.Data.SetValue(0, 0, vecA.Y, vecA.X, vecA.Z);
				m_MeshSurface.Data.SetValue(0, 1, vecB.Y, vecB.X, vecB.Z);
				m_MeshSurface.Data.SetValue(1, 1, vecC.Y, vecC.X, vecC.Z);
				m_MeshSurface.Data.SetValue(1, 0, vecD.Y, vecD.X, vecD.Z);
			}

			#endregion

			#region Fields

			NPointSeries m_PointSeries;
			NMeshSurfaceSeries m_MeshSurface;

			bool m_LockX;
			bool m_LockZ;

			bool m_DragPlaneChanged;

			#endregion
		}

	}
}
