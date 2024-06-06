using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.GraphicsCore.Nurbs;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Nevron.Examples.Chart.WinForm
{
    [ToolboxItem(false)]
    public class NMeshSurfaceHitTestingUC : NExampleBaseUC
    {
        private System.ComponentModel.Container components = null;
        NPointSeries m_PointSeries;
        NLineSeries m_LineSeries;

        public NMeshSurfaceHitTestingUC()
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
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "NTriangulatedSurfaceHitTestingUC";
            this.Size = new System.Drawing.Size(180, 300);
            this.ResumeLayout(false);

        }
        #endregion

        public override void Initialize()
        {
            base.Initialize();

            NChart chart = nChartControl1.Charts[0];
            chart.Width = chart.Height = chart.Depth = 50;
            chart.Enable3D = true;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

            NMeshSurfaceSeries surface = new NMeshSurfaceSeries();

            surface.FrameMode = SurfaceFrameMode.Dots;
            surface.FrameStrokeStyle.Width = new NLength(3);
            surface.FillStyle.SetTransparencyPercent(50.0f);

            chart.Series.Add(surface);

            m_PointSeries = new NPointSeries();
            m_PointSeries.UseXValues = true;
            m_PointSeries.UseZValues = true;
            m_PointSeries.Size = new NLength(5);
            m_PointSeries.BorderStyle.Width = new NLength(0);
            m_PointSeries.DataLabelStyle.Visible = false;
            chart.Series.Add(m_PointSeries);

            m_LineSeries = new NLineSeries();
            m_LineSeries.UseXValues = true;
            m_LineSeries.UseZValues = true;
            m_LineSeries.DataLabelStyle.Visible = false;
            chart.Series.Add(m_LineSeries);

            nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
            nChartControl1.Controller.Tools.Add(new NTrackballTool());

            nChartControl1.MouseMove += NChartControl1_MouseMove;

            FillSurfaceData(surface);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="surface"></param>
        private void FillSurfaceData(NMeshSurfaceSeries surface)
        {
            // NURBS surface parameters
            NVector4DD[,] controlPoints = new NVector4DD[,]
            {
                {
                    new NVector4DD(-200, 100, -200, 1),
                    new NVector4DD(-200, -200, -100, 1),
                    new NVector4DD(-200, 250, 100, 1),
                    new NVector4DD(-200, -100, 200, 1),
                },

                {
                    new NVector4DD(0, 0, -200, 1),
                    new NVector4DD(0, -100, -100, 5),
                    new NVector4DD(0, 150, 100, 5),
                    new NVector4DD(0, 0, 200, 1),
                },

                {
                    new NVector4DD(200, -100, -200, 1),
                    new NVector4DD(200, 200, -100, 1),
                    new NVector4DD(200, -250, 100, 1),
                    new NVector4DD(200, 100, 200, 1)
                }
            };

            int degree1 = 2;
            int degree2 = 3;
            double[] knots1 = new double[] { 0, 0, 0, 1, 1, 1 };
            double[] knots2 = new double[] { 0, 0, 0, 0, 1, 1, 1, 1 };
            NNurbsSurface nurbsSurface = new NNurbsSurface(degree1, degree2, knots1, knots2, controlPoints);

            surface.Data.FillFromNurbsSurface(nurbsSurface, 5, 5, new NVector3DD());
        }

        /// <summary>
        /// Creates a view to scale transformation
        /// </summary>
        /// <param name="surface"></param>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="pointC"></param>
        /// <param name="pointView"></param>
        /// <param name="pointScale"></param>
        /// <returns></returns>
        private bool ViewToScale(NMeshSurfaceSeries surface, NPoint pointA, NPoint pointB, NPoint pointC, NPointF pointView, ref NVector3DD pointScale)
        {
            NLine3DF lineViewPoint;
            if (!((NCartesianChart)surface.Chart).GetModelLineFromViewPoint(pointView, (int)StandardAxis.PrimaryX, (int)StandardAxis.PrimaryY, (int)StandardAxis.Depth, out lineViewPoint))
                return false;

            NScale3DToModel3DTransformation scale2Model = new NScale3DToModel3DTransformation(surface.Chart, surface.HorizontalAxis.AxisId, surface.VerticalAxis.AxisId, surface.DepthAxis.AxisId);

            NVector3DF modelPoint0 = new NVector3DF();
            NVector3DF modelPoint1 = new NVector3DF();
            NVector3DF modelPoint2 = new NVector3DF();

            scale2Model.Transform(new NVector3DD(surface.Data[pointA.X, pointA.Y]), ref modelPoint0);
            scale2Model.Transform(new NVector3DD(surface.Data[pointB.X, pointB.Y]), ref modelPoint1);
            scale2Model.Transform(new NVector3DD(surface.Data[pointC.X, pointC.Y]), ref modelPoint2);

            NPlane3D modelPlane = new NPlane3D(modelPoint0, modelPoint1, modelPoint2);
            NVector3DF pointModel = new NVector3DF();

            if (modelPlane.Intersect(ref lineViewPoint, ref pointModel) == false)
            {
                Debug.Assert(false);
                return false;
            }

            // go back to scale coordinates
            pointScale.X = surface.HorizontalAxis.TransformModelToScale(pointModel.X, false);
            pointScale.Y = surface.VerticalAxis.TransformModelToScale(pointModel.Y, false);
            pointScale.Z = surface.DepthAxis.TransformModelToScale(pointModel.Z, false);

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NChartControl1_MouseMove(object sender, MouseEventArgs e)
        {
            NHitTestResult result = nChartControl1.HitTest(e.X, e.Y);
            NMeshSurfaceSeries surface = result.Series as NMeshSurfaceSeries;

            if (surface == null)
                return;

            // this gets the three indices forming the index
            NPoint[] indices = new NPoint[] { result.SurfacePointA, result.SurfacePointB, result.SurfacePointC };

            NPoint minDistancePointIndices = new NPoint(-1, -1);
            float minDistance = float.MaxValue;
            NScale3DToViewTransformation scale2View = new NScale3DToViewTransformation(surface.Chart, surface.HorizontalAxis.AxisId, surface.VerticalAxis.AxisId, surface.DepthAxis.AxisId);

            for (int x = 0; x < surface.Data.ColumnCount; x++)
            {
                for (int y = 0; y < surface.Data.RowCount; y++)
                {
                    NVector3DF pointScale = surface.Data[x, y];

                    NPointF pointView = new NPointF();
                    scale2View.Transform(new NVector3DD(pointScale), ref pointView);

                    float dx = (float)(pointView.X - e.X);
                    float dy = (float)(pointView.Y - e.Y);

                    float distance = (float)Math.Sqrt(dx * dx + dy * dy);

                    if (distance < minDistance)
                    {
                        minDistancePointIndices = new NPoint(x, y);
                        minDistance = distance;
                    }
                }
            }

            if (minDistancePointIndices.X != -1 && minDistancePointIndices.Y != -1)
            {
                m_PointSeries.Values.Clear();
                m_PointSeries.XValues.Clear();
                m_PointSeries.ZValues.Clear();
                m_PointSeries.FillStyles.Clear();

                m_LineSeries.Values.Clear();
                m_LineSeries.XValues.Clear();
                m_LineSeries.ZValues.Clear();


                // add the intersection point
                NVector3DD pointScaleIntersection = new NVector3DD();
                if (ViewToScale(surface, indices[0], indices[1], indices[2], new NPointF(e.X, e.Y), ref pointScaleIntersection))
                {
                    m_PointSeries.XValues.Add(pointScaleIntersection.X);
                    m_PointSeries.Values.Add(pointScaleIntersection.Y);
                    m_PointSeries.ZValues.Add(pointScaleIntersection.Z);
                    m_PointSeries.FillStyles.Add(m_PointSeries.FillStyles.Count, new NColorFillStyle(Color.Green));
                }

                // add the points forming the triangle as well as the min distance point
                NVector3DF triPoint;

                for (int i = 0; i < indices.Length; i++)
                {
                    if (minDistancePointIndices != indices[i])
                    {
                        AddPointFromIndex(surface, indices[i], Color.Blue);
                    }

                    triPoint = surface.Data[indices[i].X, indices[i].Y];
                    m_LineSeries.XValues.Add(triPoint.X);
                    m_LineSeries.Values.Add(triPoint.Y);
                    m_LineSeries.ZValues.Add(triPoint.Z);
                }

                // close the triangle
                triPoint = surface.Data[indices[0].X, indices[0].Y];
                m_LineSeries.XValues.Add(triPoint.X);
                m_LineSeries.Values.Add(triPoint.Y);
                m_LineSeries.ZValues.Add(triPoint.Z);

                AddPointFromIndex(surface, minDistancePointIndices, Color.Red);

                nChartControl1.Refresh();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="surface"></param>
        /// <param name="dataPointIndex"></param>
        /// <param name="color"></param>
        private void AddPointFromIndex(NMeshSurfaceSeries surface, NPoint dataPointIndex, Color color)
        {
            NVector3DF point = surface.Data[dataPointIndex.X, dataPointIndex.Y];

            m_PointSeries.Values.Add(point.Y);
            m_PointSeries.XValues.Add(point.X);
            m_PointSeries.ZValues.Add(point.Z);
            m_PointSeries.FillStyles.Add(m_PointSeries.FillStyles.Count, new NColorFillStyle(color));
        }
    }
}
