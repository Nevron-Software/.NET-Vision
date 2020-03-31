using System;
using System.Diagnostics;
using System.Drawing;
using System.Web;

using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WebForm;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
    /// Summary description for NPdfExportRenderPage.
	/// </summary>
	public partial class NPdfExportRenderPage : NDrawingViewHostPage
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
		public NPdfExportRenderPage()
		{
			DrawingView = new NDrawingView();
			DrawingView.ViewLayout = CanvasLayout.Normal;
			
			string format = HttpContext.Current.Request.QueryString["format"];
			if (format == "pdf")
			{
				// Create a pdf image format
				NPdfImageFormat imageFormat = new NPdfImageFormat();
				imageFormat.PageSize = new NSizeF(GetSizeInPoints("PageWidth"), GetSizeInPoints("PageHeight"));
				imageFormat.PageMargins = new NMarginsF(GetSizeInPoints("MarginsLeft"), GetSizeInPoints("MarginsTop"),
					GetSizeInPoints("MarginsRight"), GetSizeInPoints("MarginsBottom"));
				imageFormat.ZoomPercent = GetFloat("ZoomPercent");
				if (GetBoolean("FitToPage"))
				{
					imageFormat.Layout = PagedLayout.FitToPages;
				}

				// Override the default response
				NImageResponse imageResponse = new NImageResponse();
				imageResponse.ImageFormat = imageFormat;
				imageResponse.StreamImageToBrowser = true;
				DrawingView.ServerSettings.BrowserResponseSettings.DefaultResponse = imageResponse;
			}

			// init document
			NDrawingDocument document = this.DrawingView.Document;
			document.BeginInit();
			CreateScene(document);
			document.EndInit();

			this.DrawingView.SizeToContent();
        }

        #endregion

        #region Private Methods

		/// <summary>
		/// Creates the diagram.
		/// </summary>
		/// <param name="document"></param>
        private void CreateScene(NDrawingDocument document)
		{
            // create a style sheet for the start and end shapes
            NStyleSheet styleSheet = new NStyleSheet("STARTEND");
            styleSheet.Style.FillStyle = new NGradientFillStyle(
                GradientStyle.Horizontal,
                GradientVariant.Variant1,
                Color.FromArgb(247, 150, 56),
                Color.FromArgb(251, 203, 156));
            document.StyleSheets.AddChild(styleSheet);

            // create a style sheet for the question shapes
            styleSheet = new NStyleSheet("QUESTION");
            styleSheet.Style.FillStyle = new NGradientFillStyle(
                GradientStyle.Horizontal,
                GradientVariant.Variant1,
                Color.FromArgb(129, 133, 133),
                Color.FromArgb(192, 194, 194));
            document.StyleSheets.AddChild(styleSheet);

            // create a style sheet for the action shapes
            styleSheet = new NStyleSheet("ACTION");
            styleSheet.Style.FillStyle = new NGradientFillStyle(
                GradientStyle.Horizontal,
                GradientVariant.Variant1,
                Color.FromArgb(68, 90, 108),
                Color.FromArgb(162, 173, 182));
            document.StyleSheets.AddChild(styleSheet);

            int vSpacing = 35;
            int hSpacing = 45;
            int topMargin = 10;
            int leftMargin = 10;

            int shapeWidth = 90;
            int shapeHeight = 55;

            int col1 = leftMargin;
            int col2 = col1 + shapeWidth + hSpacing;
            int col3 = col2 + shapeWidth + hSpacing;
            int col4 = col3 + shapeWidth + hSpacing;

            int row1 = topMargin;
            int row2 = row1 + shapeHeight + vSpacing;
            int row3 = row2 + shapeHeight + vSpacing;
            int row4 = row3 + shapeHeight + vSpacing;
            int row5 = row4 + shapeHeight + vSpacing;
            int row6 = row5 + shapeHeight + vSpacing;

			NRectangleF bounds = new NRectangleF(col2, row1, shapeWidth, shapeHeight);
            NShape start = CreateFlowChartingShape(FlowChartingShapes.Termination, bounds, "START", "STARTEND");

            // row 2
            bounds = new NRectangleF(col2, row2, shapeWidth, shapeHeight);
            NShape haveSerialNumber = CreateFlowChartingShape(FlowChartingShapes.Decision, bounds, "Have a serial number?", "QUESTION");

            bounds = new NRectangleF(col3, row2, shapeWidth, shapeHeight);
            NShape getSerialNumber = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Get serial number", "ACTION");

            // row 3
            bounds = new NRectangleF(col1, row3, shapeWidth, shapeHeight);
            NShape enterSerialNumber = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Enter serial number", "ACTION");

            bounds = new NRectangleF(col2, row3, shapeWidth, shapeHeight);
            NShape haveDiskSpace = CreateFlowChartingShape(FlowChartingShapes.Decision, bounds, "Have disk space?", "QUESTION");

            bounds = new NRectangleF(col3, row3, shapeWidth, shapeHeight);
            NShape freeUpSpace = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Free up space", "ACTION");

            // row 4
            bounds = new NRectangleF(col1, row4, shapeWidth, shapeHeight);
            NShape runInstallRect = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Run install file", "ACTION");

            bounds = new NRectangleF(col2, row4, shapeWidth, shapeHeight);
            NShape registerNow = CreateFlowChartingShape(FlowChartingShapes.Decision, bounds, "Register now?", "QUESTION");

            bounds = new NRectangleF(col3, row4, shapeWidth, shapeHeight);
            NShape fillForm = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Fill out form", "ACTION");

            bounds = new NRectangleF(col4, row4, shapeWidth, shapeHeight);
            NShape submitForm = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Submit form", "ACTION");

            // row 5
            bounds = new NRectangleF(col1, row5, shapeWidth, shapeHeight);
            NShape finishInstall = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Finish installation", "ACTION");

            bounds = new NRectangleF(col2, row5, shapeWidth, shapeHeight);
            NShape restartNeeded = CreateFlowChartingShape(FlowChartingShapes.Decision, bounds, "Restart needed?", "QUESTION");

            bounds = new NRectangleF(col3, row5, shapeWidth, shapeHeight);
            NShape restart = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "Restart", "ACTION");

            // row 6
            bounds = new NRectangleF(col2, row6, shapeWidth, shapeHeight);
            NShape run = CreateFlowChartingShape(FlowChartingShapes.Process, bounds, "RUN", "STARTEND");

            // create connectors
            CreateConnector(start, "Bottom", haveSerialNumber, "Top", ConnectorType.Line, "");

            NStep3Connector step3Connector = (NStep3Connector)CreateConnector(getSerialNumber, "Top", haveSerialNumber, "Top", ConnectorType.TopToBottom, "");
            step3Connector.UseMiddleControlPointPercent = false;
            step3Connector.MiddleControlPointOffset = -(vSpacing / 2);

            CreateConnector(haveSerialNumber, "Right", getSerialNumber, "Left", ConnectorType.Line, "No");
            CreateConnector(haveSerialNumber, "Bottom", enterSerialNumber, "Top", ConnectorType.TopToBottom, "Yes");
            CreateConnector(enterSerialNumber, "Right", haveDiskSpace, "Left", ConnectorType.Line, "");

            step3Connector = (NStep3Connector)CreateConnector(freeUpSpace, "Top", haveDiskSpace, "Top", ConnectorType.TopToBottom, "");
            step3Connector.UseMiddleControlPointPercent = false;
            step3Connector.MiddleControlPointOffset = -(vSpacing / 3);

            CreateConnector(haveDiskSpace, "Right", freeUpSpace, "Left", ConnectorType.Line, "No");
            CreateConnector(haveDiskSpace, "Bottom", runInstallRect, "Top", ConnectorType.TopToBottom, "Yes");
            CreateConnector(registerNow, "Right", fillForm, "Left", ConnectorType.Line, "Yes");
            CreateConnector(registerNow, "Bottom", finishInstall, "Top", ConnectorType.TopToBottom, "No");
            CreateConnector(fillForm, "Right", submitForm, "Left", ConnectorType.Line, "");
            CreateConnector(submitForm, "Bottom", finishInstall, "Top", ConnectorType.TopToBottom, "");
            CreateConnector(finishInstall, "Right", restartNeeded, "Left", ConnectorType.Line, "");
            CreateConnector(restart, "Bottom", run, "Top", ConnectorType.TopToBottom, "");
            CreateConnector(restartNeeded, "Right", restart, "Left", ConnectorType.Line, "Yes");
            CreateConnector(restartNeeded, "Bottom", run, "Top", ConnectorType.Line, "No");
        }
        /// <summary>
        /// Creates a predefined flow charting shape
        /// </summary>
        /// <param name="flowChartShape">flow charting shape</param>
        /// <param name="bounds">bounds</param>
        /// <param name="text">default label text</param>
        /// <param name="styleSheetName">name of the stylesheet from which to inherit styles</param>
        /// <returns>new basic shape</returns>
		private NShape CreateFlowChartingShape(FlowChartingShapes flowChartShape, NRectangleF bounds, string text, string styleSheetName)
        {
            NFlowChartingShapesFactory factory = new NFlowChartingShapesFactory(DrawingView.Document);
            NShape shape = factory.CreateShape((int)flowChartShape);

            shape.Bounds = bounds;
            shape.Text = text;
            shape.StyleSheetName = styleSheetName;

            DrawingView.Document.ActiveLayer.AddChild(shape);
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
		private NShape CreateConnector(NShape fromShape, string fromPortName, NShape toShape, string toPortName, ConnectorType connectorType, string text)
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
            DrawingView.Document.ActiveLayer.AddChild(connector);

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

		#region Static

		/// <summary>
		/// Reads the parameter with the specified name as boolean.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		private static bool GetBoolean(string name)
		{
			string str = HttpContext.Current.Request[name];
			bool result;
			if (Boolean.TryParse(str, out result) == false)
			{
				result = false;
			}

			return result;
		}
		/// <summary>
		/// Reads the parameter with the specified name as float.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		private static float GetFloat(string name)
		{
			string str = HttpContext.Current.Request[name];
			float result;
			if (Single.TryParse(str, out result) == false)
			{
				if (name.StartsWith("Page"))
					result = 10;
				else if (name.StartsWith("Zoom"))
					result = 1;
				else
					result = 0;
			}

			return result;
		}
		/// <summary>
		/// Reads the parameter with the specified name as float and then
		/// converts it from mm to points.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		private static float GetSizeInPoints(string name)
		{
			float result = GetFloat(name);
			return NMath.Round(result * MmToPoints);
		}

		#endregion

		#region Constants

		private const float MmToPoints = 2.83464567f;

		#endregion
	}
}