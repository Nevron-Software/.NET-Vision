using System;
using System.Diagnostics;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NExampleUC.
	/// </summary>
	public partial class NDiagramExampleUC : System.Web.UI.UserControl
	{
        #region Properties

        /// <summary>
        /// Determines whether event handling is paused
        /// </summary>
        protected bool EventsHandlingPaused
        {
            get
            {
                return (eventHandlingPauseCounter != 0);
            }
        }
        /// <summary>
        /// Gets/sets the default grid cell size
        /// </summary>
        protected NSizeF DefaultGridCellSize
        {
            get
            {
                return defaultGridCellSize;
            }
            set
            {
                defaultGridCellSize = value;
            }
        }
        /// <summary>
        /// Gets/sets the default grid origin
        /// </summary>
        protected NPointF DefaultGridOrigin
        {
            get
            {
                return defaultGridOrigin;
            }
            set
            {
                defaultGridOrigin = value;
            }
        }
        /// <summary>
        /// Gets/sets the default grid spacing
        /// </summary>
        protected NSizeF DefaultGridSpacing
        {
            get
            {
                return defaultGridSpacing;
            }
            set
            {
                defaultGridSpacing = value;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Gets a predefined color
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected Color GetPredefinedColor(int index)
        {
            index = index % 6;

            switch (index)
            {
                case 0:
                    return Color.Magenta;
                case 1:
                    return Color.Blue;
                case 2:
                    return Color.Green;
                case 3:
                    return Color.Chocolate;
                case 4:
                    return Color.Coral;
                case 5:
                    return Color.Orange;
            };

            return Color.Black;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        protected NRectangleF GetGridCell(int row, int col)
        {
            return GetGridCell(row, col, defaultGridOrigin, defaultGridCellSize, defaultGridSpacing);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="rowSpan"></param>
        /// <param name="colSpan"></param>
        /// <returns></returns>
        protected NRectangleF GetGridCell(int row, int col, int rowSpan, int colSpan)
        {
            NRectangleF cell1 = GetGridCell(row, col, defaultGridOrigin, defaultGridCellSize, defaultGridSpacing);
            NRectangleF cell2 = GetGridCell(row + rowSpan, col + colSpan, defaultGridOrigin, defaultGridCellSize, defaultGridSpacing);
            return NRectangleF.Union(cell1, cell2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="origin"></param>
        /// <param name="size"></param>
        /// <param name="spacing"></param>
        /// <returns></returns>
        protected NRectangleF GetGridCell(int row, int col, NPointF origin, NSizeF size, NSizeF spacing)
        {
            return new NRectangleF(origin.X + col * (size.Width + spacing.Width),
                origin.Y + row * (size.Height + spacing.Height),
                size.Width, size.Height);
        }

        /// <summary>
        /// Gets a random set of points constrained in the specified bounds
        /// </summary>
        /// <param name="bounds"></param>
        /// <param name="pointsCount"></param>
        /// <returns></returns>
        protected NPointF[] GetRandomPoints(NRectangleF bounds, int pointsCount)
        {
            NPointF[] points = new NPointF[pointsCount];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = GetRandomPoint(bounds);
            }

            return points;
        }
        /// <summary>
        /// Gets a random point constrained in the specified bounds
        /// </summary>
        /// <param name="bounds"></param>
        /// <returns></returns>
        protected NPointF GetRandomPoint(NRectangleF bounds)
        {
            return new NPointF(
                bounds.X + ((float)Random.NextDouble() * bounds.Width),
                bounds.Y + ((float)Random.NextDouble() * bounds.Height));
        }
        /// <summary>
        /// Gets a random size in [minSize, maxSize] range
        /// </summary>
        /// <param name="minSize"></param>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        protected NSizeF GetRandomSize(NSizeF minSize, NSizeF maxSize)
        {
            float width = (float)(Random.Next(100) * Math.Abs(maxSize.Width - minSize.Width) / 100.0f + Math.Min(maxSize.Width, minSize.Width));
            float height = (float)(Random.Next(100) * Math.Abs(maxSize.Height - minSize.Height) / 100.0f + Math.Min(maxSize.Height, minSize.Height));

            return new NSizeF(width, height);
        }

        /// <summary>
        /// Creates a predefined basic shape
        /// </summary>
        /// <param name="basicShape">basic shape</param>
        /// <param name="bounds">bounds</param>
        /// <param name="text">default label text</param>
        /// <param name="styleSheetName">name of the stylesheet from which to inherit styles</param>
        /// <returns>new basic shape</returns>
        protected NShape CreateBasicShape(NDrawingDocument document, BasicShapes basicShape, NRectangleF bounds, string text, string styleSheetName)
        {
            NBasicShapesFactory factory = new NBasicShapesFactory(document);
            NShape shape = factory.CreateShape((int)basicShape);

            shape.Bounds = bounds;
            shape.Text = text;
            shape.StyleSheetName = styleSheetName;

            document.ActiveLayer.AddChild(shape);
            return shape;
        }
        /// <summary>
        /// Creates a predefined flow charting shape
        /// </summary>
        /// <param name="flowChartShape">flow charting shape</param>
        /// <param name="bounds">bounds</param>
        /// <param name="text">default label text</param>
        /// <param name="styleSheetName">name of the stylesheet from which to inherit styles</param>
        /// <returns>new basic shape</returns>
        protected NShape CreateFlowChartingShape(NDrawingDocument document, FlowChartingShapes flowChartShape, NRectangleF bounds, string text, string styleSheetName)
        {
            NFlowChartingShapesFactory factory = new NFlowChartingShapesFactory(document);
            NShape shape = factory.CreateShape((int)flowChartShape);

            shape.Bounds = bounds;
            shape.Text = text;
            shape.StyleSheetName = styleSheetName;

            document.ActiveLayer.AddChild(shape);
            return shape;
        }
        /// <summary>
        /// Creates a new connector, which connects the specified shapes
        /// </summary>
        /// <param name="fromShape"></param>
        /// <param name="fromPortName"></param>
        /// <param name="toShape"></param>
        /// <param name="toPortName"></param>
        /// <param name="connectorType"></param>
        /// <param name="text"></param>
        /// <returns>new 1D shapes</returns>
        protected NShape CreateConnector(NDrawingDocument document, NShape fromShape, string fromPortName, NShape toShape, string toPortName, ConnectorType connectorType, string text)
        {
            // check arguments
            if (fromShape == null)
                throw new ArgumentNullException("fromShape");

            if (toShape == null)
                throw new ArgumentNullException("toShape");

            NPort fromPort = (fromShape.Ports.GetChildByName(fromPortName, 0) as NPort);
            if (fromPort == null)
                throw new ArgumentException("Was not able to find fromPortName in the ports collection of the fromShape", "fromPortName");

            NPort toPort = (toShape.Ports.GetChildByName(toPortName, 0) as NPort);
            if (toPort == null)
                throw new ArgumentException("Was not able to find toPortName in the ports collection of the toShape", "toPortName");

            // create the connector
            NShape connector = null;
            switch (connectorType)
            {
                case ConnectorType.Line:
                    connector = new NLineShape();
                    break;

                case ConnectorType.Bezier:
                    connector = new NBezierCurveShape();
                    break;

                case ConnectorType.SingleArrow:
                    connector = new NArrowShape(ArrowType.SingleArrow);
                    break;

                case ConnectorType.DoubleArrow:
                    connector = new NArrowShape(ArrowType.DoubleArrow);
                    break;

                case ConnectorType.SideToTopBottom:
                    connector = new NStep2Connector(false);
                    break;

                case ConnectorType.TopBottomToSide:
                    connector = new NStep2Connector(true);
                    break;

                case ConnectorType.SideToSide:
                    connector = new NStep3Connector(false, 50, 0, true);
                    break;

                case ConnectorType.TopToBottom:
                    connector = new NStep3Connector(true, 50, 0, true);
                    break;

                case ConnectorType.DynamicHV:
                    connector = new NRoutableConnector(RoutableConnectorType.DynamicHV);
                    break;

                case ConnectorType.DynamicPolyline:
                    connector = new NRoutableConnector(RoutableConnectorType.DynamicPolyline);
                    break;

                case ConnectorType.DynamicCurve:
                    connector = new NRoutableConnector(RoutableConnectorType.DynamicCurve);
                    break;

                default:
                    Debug.Assert(false, "New graph connector type?");
                    break;
            }

            // the connector must be added to the document prior to connecting it
            document.ActiveLayer.AddChild(connector);

            // change the default label text
            connector.Text = text;

            // connectors by default inherit styles from the connectors stylesheet
            connector.StyleSheetName = NDR.NameConnectorsStyleSheet;

            // connect the connector to the specified ports
            connector.StartPlug.Connect(fromPort);
			connector.EndPlug.Connect(toPort);

            // modify the connector text style
            connector.Style.TextStyle = (connector.ComposeTextStyle().Clone() as NTextStyle);
            connector.Style.TextStyle.Offset = new NPointL(0, -7);

            return connector;
        }

        #endregion

		#region Fields

		protected static Random Random = new Random();

        private int eventHandlingPauseCounter = 0;
        private NSizeF defaultGridCellSize;
        private NPointF defaultGridOrigin;
        private NSizeF defaultGridSpacing;

		#endregion
	}
}