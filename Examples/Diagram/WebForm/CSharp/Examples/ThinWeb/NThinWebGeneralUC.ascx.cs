using System;
using System.Diagnostics;
using System.Drawing;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NThinWebGeneral.
	/// </summary>
	public partial class NThinWebGeneralUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// begin view init
			base.DefaultGridOrigin = new NPointF(-100, 0);
			base.DefaultGridCellSize = new NSizeF(100, 50);
			base.DefaultGridSpacing = new NSizeF(50, 40);

			if (!NThinDiagramControl1.Initialized)
			{
				// begin view init
				NDrawingDocument document = NThinDiagramControl1.Document;

				NThinDiagramControl1.Controller.Tools.Add(new NTooltipTool());
				NThinDiagramControl1.Controller.Tools.Add(new NCursorTool());
				NThinDiagramControl1.Controller.Tools.Add(new NRectZoomTool());
				NPanTool panTool = new NPanTool();
				panTool.Enabled = false;
				NThinDiagramControl1.Controller.Tools.Add(panTool);

				// configure the toolbar
				NThinDiagramControl1.Toolbar.Visible = true;
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NSaveStateAction("DiagramState.ndx", Serialization.PersistencyFormat.XML)));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NSaveImageAction("DiagramPDF", new NPdfImageFormat(), true, new NSize(), 300)));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NSaveImageAction("DiagramPNG", new NPngImageFormat(), true, new NSize(), 96)));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarSeparator());
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NZoomInAction()));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NZoomOutAction()));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarSeparator());
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NTogglePanToolAction()));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleRectZoomToolAction()));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarSeparator());
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleTooltipToolAction()));
				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleCursorToolAction()));

				NThinDiagramControl1.Toolbar.Items.Add(new NToolbarSeparator());

				Array values = Enum.GetValues(typeof(CanvasLayout));
				for (int i = 0; i < values.Length; i++)
				{
					NThinDiagramControl1.Toolbar.Items.Add(new NToolbarButton(new NToggleViewLayoutAction((CanvasLayout)values.GetValue(i))));
				}


				// init NDrawingView1.Document.
				document.BeginInit();
				InitDocument(document);
				document.SizeToContent();
				document.EndInit();

//                NThinDiagramControl1.View.Layout = CanvasLayout.Fit;
				NThinDiagramControl1.View.ZoomFactor = 2;
				NThinDiagramControl1.View.MinZoomFactor = 1;
				NThinDiagramControl1.View.MaxZoomFactor = 10;
				NThinDiagramControl1.View.ZoomPercent = 50;
//				NThinDiagramControl1.View.ViewportOrigin = document.Location;
			}
		}

		#region Implementation

		private NInteractivityStyle CreateInteractivityStyle(string text)
		{
			NInteractivityStyle interactivityStyle = new NInteractivityStyle();
			interactivityStyle.Tooltip.Text = text;
			interactivityStyle.Cursor = new NCursorAttribute(CursorType.Hand);

			return interactivityStyle;
		}

		private void InitDocument(NDrawingDocument document)
		{
			// setup default NDrawingView1.Document. fill style, background style and shadow style
			Color color1 = Color.FromArgb(225, 232, 232);
			Color color2 = Color.FromArgb(32, 136, 178);

			NLightingImageFilter lightingFilter = new NLightingImageFilter();
			lightingFilter.SpecularColor = Color.Black;
			lightingFilter.DiffuseColor = Color.White;
			lightingFilter.LightSourceType = LightSourceType.Positional;
			lightingFilter.Position = new NVector3DF(1, 1, 1);
			lightingFilter.BevelDepth = new NLength(8, NGraphicsUnit.Pixel);

			document.Style.FillStyle = new NColorFillStyle(color1);
			document.Style.FillStyle.ImageFiltersStyle.Filters.Add(lightingFilter);

			document.BackgroundStyle.FillStyle = new NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant1, Color.LightBlue, color2);

			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur;
			document.Style.ShadowStyle.Offset = new NPointL(5, 5);

			document.ShadowsZOrder = ShadowsZOrder.BehindDocument;

			// create title
			NTextShape title = new NTextShape("Bubble Sort", GetGridCell(0, 1, 2, 1));
			title.Style.TextStyle = new NTextStyle();
			title.Style.TextStyle.FillStyle = (document.Style.FillStyle.Clone() as NFillStyle);
			title.Style.TextStyle.ShadowStyle = new NShadowStyle();
			title.Style.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur;
			title.Style.TextStyle.FontStyle = new NFontStyle(new Font("Arial", 40, FontStyle.Bold));

			title.Style.InteractivityStyle = CreateInteractivityStyle("Bubble Sort");

			document.ActiveLayer.AddChild(title);



			// begin shape
			NShape shapeBegin = CreateFlowChartingShape(document, FlowChartingShapes.Termination, GetGridCell(0, 0), "BEGIN", "");

			// get array item shape
			NShape shapeGetItem = CreateFlowChartingShape(document, FlowChartingShapes.Data, GetGridCell(1, 0), "Get array item [1...n]", "");
			NRotatedBoundsLabel rotatedBoundsLabel = (NRotatedBoundsLabel)shapeGetItem.Labels.DefaultLabel;
			rotatedBoundsLabel.Margins = new Nevron.Diagram.NMargins(20, 20, 0, 0);

			// i = 1 shape
			NShape shapeI1 = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(2, 0), "i = 1", "");

			// j = n shape
			NShape shapeJEN = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(3, 0), "j = n", "");

			// less comparison shape
			NShape shapeLess = CreateFlowChartingShape(document, FlowChartingShapes.Decision, GetGridCell(4, 0), "item[i] < item[j - 1]?", "");
			rotatedBoundsLabel = (NRotatedBoundsLabel)shapeLess.Labels.DefaultLabel;
			rotatedBoundsLabel.Margins = new Nevron.Diagram.NMargins(15, 15, 0, 0);

			// swap shape
			NShape shapeSwap = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(4, 1), "Swap item[i] and item[j-1]", "");

			// j > i + 1? shape
			NShape shapeJQ = CreateFlowChartingShape(document, FlowChartingShapes.Decision, GetGridCell(5, 0), "j = (i + 1)?", "");

			// dec j shape
			NShape shapeDecJ = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(5, 1), "j = j - 1", "");

			// i > n - 1? shape
			NShape shapeIQ = CreateFlowChartingShape(document, FlowChartingShapes.Decision, GetGridCell(6, 0), "i = (n - 1)?", "");

			// inc i shape
			NShape shapeIncI = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(6, 1), "i = i + 1", "");

			// end shape
			NShape shapeEnd = CreateFlowChartingShape(document, FlowChartingShapes.Termination, GetGridCell(7, 0), "END", "");

			// connect begin with get array item
			NLineShape connector1 = new NLineShape();
			connector1.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector1);
			connector1.FromShape = shapeBegin;
			connector1.ToShape = shapeGetItem;

			// connect get array item with i = 1
			NLineShape connector2 = new NLineShape();
			connector2.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector2);

			connector2.FromShape = shapeGetItem;
			connector2.ToShape = shapeI1;

			// connect i = 1 and j = n
			NLineShape connector3 = new NLineShape();
			connector3.StyleSheetName = NDR.NameConnectorsStyleSheet;

			connector3.CreateShapeElements(ShapeElementsMask.Ports);
			connector3.Ports.AddChild(new NLogicalLinePort(connector3.UniqueId, 50));
			connector3.Ports.DefaultInwardPortUniqueId = (connector3.Ports.GetChildAt(0) as INDiagramElement).UniqueId;
			document.ActiveLayer.AddChild(connector3);

			connector3.FromShape = shapeI1;
			connector3.ToShape = shapeJEN;

			// connect j = n and item[i] < item[j-1]?
			NLineShape connector4 = new NLineShape();
			connector4.StyleSheetName = NDR.NameConnectorsStyleSheet;

			connector4.CreateShapeElements(ShapeElementsMask.Ports);
			connector4.Ports.AddChild(new NLogicalLinePort(connector4.UniqueId, 50));
			connector4.Ports.DefaultInwardPortUniqueId = (connector4.Ports.GetChildAt(0) as INDiagramElement).UniqueId;
			document.ActiveLayer.AddChild(connector4);

			connector4.FromShape = shapeJEN;
			connector4.ToShape = shapeLess;

			// connect item[i] < item[j-1]? and j = (i + 1)? 
			NLineShape connector5 = new NLineShape();
			connector5.StyleSheetName = NDR.NameConnectorsStyleSheet;
			connector5.Text = "No";
			connector5.Style.TextStyle = new NTextStyle();
			connector5.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Top;

			connector5.CreateShapeElements(ShapeElementsMask.Ports);
			connector5.Ports.AddChild(new NLogicalLinePort(connector5.UniqueId, 50));
			connector5.Ports.DefaultInwardPortUniqueId = (connector5.Ports.GetChildAt(0) as INDiagramElement).UniqueId;
			document.ActiveLayer.AddChild(connector5);

			connector5.FromShape = shapeLess;
			connector5.ToShape = shapeJQ;

			// connect j = (i + 1)? and i = (n - 1)?
			NLineShape connector6 = new NLineShape();
			connector6.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector6);

			connector6.FromShape = shapeJQ;
			connector6.ToShape = shapeIQ;

			// connect i = (n - 1) and END
			NLineShape connector7 = new NLineShape();
			connector7.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector7);
			connector7.FromShape = shapeIQ;
			connector7.ToShape = shapeEnd;

			// connect item[i] < item[j-1]? and Swap
			NLineShape connector8 = new NLineShape();
			connector8.StyleSheetName = NDR.NameConnectorsStyleSheet;
			connector8.Text = "Yes";
			connector8.Style.TextStyle = new NTextStyle();
			connector8.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Bottom;
			document.ActiveLayer.AddChild(connector8);

			connector8.FromShape = shapeLess;
			connector8.ToShape = shapeSwap;

			// connect j = (i + 1)? and j = (j - 1)
			NLineShape connector9 = new NLineShape();
			connector9.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector9);

			connector9.FromShape = shapeJQ;
			connector9.ToShape = shapeDecJ;

			// connect i = (n - 1)? and i = (i + 1)
			NLineShape connector10 = new NLineShape();
			connector10.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector10);

			connector10.FromShape = shapeIQ;
			connector10.ToShape = shapeIncI;

			// connect Swap to No connector
			NStep2Connector connector11 = new NStep2Connector(true);
			connector11.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector11);

			connector11.FromShape = shapeSwap;
			connector11.ToShape = connector5;

			// connect i = i + 1 to connector3
			NStep3Connector connector12 = new NStep3Connector(false, 50, 60, false);
			connector12.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector12);

			connector12.StartPlug.Connect(shapeIncI.Ports.GetChildByName("Right", 0) as NPort);
			connector12.EndPlug.Connect(connector3.Ports.DefaultInwardPort);

			// connect j = j - 1 to connector4
			NStep3Connector connector13 = new NStep3Connector(false, 50, 30, false);
			connector13.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector13);

			connector13.StartPlug.Connect(shapeDecJ.Ports.GetChildByName("Right", 0) as NPort);
			connector13.EndPlug.Connect(connector4.Ports.DefaultInwardPort);
		}
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
			return GetGridCell(row, col, this.DefaultGridOrigin, DefaultGridCellSize, DefaultGridSpacing);
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
			NRectangleF cell1 = GetGridCell(row, col, DefaultGridOrigin, DefaultGridCellSize, DefaultGridSpacing);
			NRectangleF cell2 = GetGridCell(row + rowSpan, col + colSpan, DefaultGridOrigin, DefaultGridCellSize, DefaultGridSpacing);
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
			Random rand = new Random();
			return new NPointF(
				bounds.X + ((float)rand.NextDouble() * bounds.Width),
				bounds.Y + ((float)rand.NextDouble() * bounds.Height));
		}
		/// <summary>
		/// Gets a random size in [minSize, maxSize] range
		/// </summary>
		/// <param name="minSize"></param>
		/// <param name="maxSize"></param>
		/// <returns></returns>
		protected NSizeF GetRandomSize(NSizeF minSize, NSizeF maxSize)
		{
			Random rand = new Random();
			float width = (float)(rand.Next(100) * Math.Abs(maxSize.Width - minSize.Width) / 100.0f + Math.Min(maxSize.Width, minSize.Width));
			float height = (float)(rand.Next(100) * Math.Abs(maxSize.Height - minSize.Height) / 100.0f + Math.Min(maxSize.Height, minSize.Height));

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
			shape.Style.InteractivityStyle = CreateInteractivityStyle(text);

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
	}
}