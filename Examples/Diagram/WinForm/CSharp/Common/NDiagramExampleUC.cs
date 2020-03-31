using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.IO;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Editors; 
using Nevron.Diagram.WinForm;
using Nevron.Examples.Framework.WinForm;
using Nevron.Diagram.Layout;
using Nevron.Dom;
using Nevron.Diagram.Filters;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// The NDiagramExampleUC class serves as base user control for all diagram examples
	/// </summary>
	public class NDiagramExampleUC : NExampleUserControl
	{
		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public NDiagramExampleUC()
		{
			InitializeComponent();
			
			view = null;
			document = null;

			eventHandlingPauseCounter = 0;

			defaultGridOrigin = new NPointF(15, 15);
			defaultGridCellSize = new NSizeF(100, 100);
			defaultGridSpacing = new NSizeF(20, 20);
		}

		/// <summary>
		/// Initializer constructor
		/// </summary>
		/// <param name="form">main application form</param>
		public NDiagramExampleUC(NMainForm form) 
			: base(form)
		{
			InitializeComponent();

			view = form.View;
			document = form.Document;
			eventHandlingPauseCounter = 0;

			defaultGridOrigin = new NPointF(15, 15);
			defaultGridCellSize = new NSizeF(100, 100);
			defaultGridSpacing = new NSizeF(20, 20);
        }
		
		#endregion

		#region Component Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.GraphicsSettingsButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ResetExampleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.commonControlsPanel = new System.Windows.Forms.Panel();
			this.commonControlsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// GraphicsSettingsButton
			// 
			this.GraphicsSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.GraphicsSettingsButton.Location = new System.Drawing.Point(8, 12);
			this.GraphicsSettingsButton.Name = "GraphicsSettingsButton";
			this.GraphicsSettingsButton.Size = new System.Drawing.Size(244, 24);
			this.GraphicsSettingsButton.TabIndex = 0;
			this.GraphicsSettingsButton.Text = "Graphics settings...";
			this.GraphicsSettingsButton.Click += new System.EventHandler(this.GraphicsSettingsButton_Click);
			// 
			// ResetExampleButton
			// 
			this.ResetExampleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ResetExampleButton.Location = new System.Drawing.Point(8, 44);
			this.ResetExampleButton.Name = "ResetExampleButton";
			this.ResetExampleButton.Size = new System.Drawing.Size(244, 24);
			this.ResetExampleButton.TabIndex = 1;
			this.ResetExampleButton.Text = "Reset example";
			this.ResetExampleButton.Click += new System.EventHandler(this.ResetExampleButton_Click);
			// 
			// commonControlsPanel
			// 
			this.commonControlsPanel.Controls.Add(this.GraphicsSettingsButton);
			this.commonControlsPanel.Controls.Add(this.ResetExampleButton);
			this.commonControlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.commonControlsPanel.Location = new System.Drawing.Point(0, 520);
			this.commonControlsPanel.Name = "commonControlsPanel";
			this.commonControlsPanel.Size = new System.Drawing.Size(260, 80);
			this.commonControlsPanel.TabIndex = 0;
			// 
			// NDiagramExampleUC
			// 
			this.AutoScroll = true;
			this.Controls.Add(this.commonControlsPanel);
			this.Name = "NDiagramExampleUC";
			this.Size = new System.Drawing.Size(260, 600);
			this.commonControlsPanel.ResumeLayout(false);
			this.ResumeLayout(false);
		}
        		
		#endregion

		#region Component Overrides

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}

				DetachFromEvents();
			}

			base.Dispose(disposing);
		}
	

		#endregion

		#region Overrides

		/// <summary>
		/// 
		/// </summary>
		public override void Initialize()
		{
			// synchonize the view and form document
			if (view != null && !object.ReferenceEquals(document, view.Document))
			{
				document = view.Document;
                if (Form != null)
                {
                    Form.Document = view.Document;
                }
			}

			// load the example 
			LoadExample();

			// attach to the view and document events 
			AttachToEvents();

			// dock to fill the docking panel
			Dock = System.Windows.Forms.DockStyle.Fill;
		}

		#endregion

		#region Protected Overridable

		/// <summary>
		/// Called when the example is loaded
		/// </summary>
		protected virtual void LoadExample()
		{
		}
		/// <summary>
		/// Attaches the example to the document and view events
		/// </summary>
		protected virtual void AttachToEvents()
		{
		}
		/// <summary>
		/// Detaches the example to the document and view events
		/// </summary>
		protected virtual void DetachFromEvents()
		{
		}
		/// <summary>
		/// Resets the example to its initial state
		/// </summary>
		protected virtual void ResetExample()
		{
			// update document references in case the document was reloaded
			if (!object.ReferenceEquals(document, view.Document))
			{
				document = view.Document;

				if (Form != null)
				{
					Form.Document = document;
				}
			}

            DetachFromEvents();

			// reset the document
			document.Reset();
			view.Reset();

			LoadExample();
            AttachToEvents();
		}
		/// <summary>
		/// Creates a default flow diagram
		/// </summary>
		protected virtual void CreateDefaultFlowDiagram()
		{
			NRectangleF bounds;

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

			bounds = new NRectangleF(col2, row1, shapeWidth, shapeHeight);
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
			step3Connector.MiddleControlPointOffset = - (vSpacing / 2);

			CreateConnector(haveSerialNumber, "Right", getSerialNumber, "Left", ConnectorType.Line, "No");
			CreateConnector(haveSerialNumber, "Bottom", enterSerialNumber, "Top", ConnectorType.TopToBottom, "Yes");
			CreateConnector(enterSerialNumber, "Right", haveDiskSpace, "Left", ConnectorType.Line, "");

			step3Connector = (NStep3Connector)CreateConnector(freeUpSpace, "Top", haveDiskSpace, "Top", ConnectorType.TopToBottom, "");
			step3Connector.UseMiddleControlPointPercent = false;
			step3Connector.MiddleControlPointOffset = - (vSpacing / 3);

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

		#endregion

		#region Protected

		/// <summary>
		/// Gets a predefined color from a list of 6 predefined colors.
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
		/// Shows the start arrowhead style editor for the specified styleable node
		/// </summary>
		/// <param name="styleable"></param>
        protected void ShowStartArrowheadStyleEditor(INStyleable styleable)
		{
			if (styleable == null)
				return;
			
			NArrowheadStyle arrowheadStyle = styleable.ComposeStartArrowheadStyle();
			NArrowheadStyle newArrowheadStyle = null;

			if (NArrowheadStyleTypeEditor.Edit(arrowheadStyle, out newArrowheadStyle, true, arrowheadStyle != NStyle.GetStartArrowheadStyle(styleable)))
			{
				NStyle.SetStartArrowheadStyle(styleable, newArrowheadStyle);
				document.RefreshAllViews();
			}
		}
		/// <summary>
		/// Shows the end arrowhead style editor for the specified styleable node
		/// </summary>
		/// <param name="styleable"></param>
        protected void ShowEndArrowheadStyleEditor(INStyleable styleable)
		{
			if (styleable == null)
				return;
			
			NArrowheadStyle arrowheadStyle = styleable.ComposeEndArrowheadStyle();
			NArrowheadStyle newArrowheadStyle = null;

			if (NArrowheadStyleTypeEditor.Edit(arrowheadStyle, out newArrowheadStyle, false, arrowheadStyle != NStyle.GetEndArrowheadStyle(styleable)))
			{
				NStyle.SetEndArrowheadStyle(styleable, newArrowheadStyle);
				document.RefreshAllViews();
			}
		}
		/// <summary>
		/// Shows the stroke style editor for the specified styleable node
		/// </summary>
		/// <param name="styleable"></param>
        protected void ShowStrokeStyleEditor(INStyleable styleable)
		{
			if (styleable == null)
				return;

			NStrokeStyle strokeStyle = styleable.ComposeStrokeStyle(); 
			NStrokeStyle newStrokeStyle = null;

			if (NStrokeStyleTypeEditor.Edit(strokeStyle, out newStrokeStyle))
			{
				NStyle.SetStrokeStyle(styleable, newStrokeStyle);
				document.RefreshAllViews();
			}
		}
		/// <summary>
		/// Shows the shadow style editor for the specified styleable node
		/// </summary>
		/// <param name="styleable"></param>
        protected void ShowShadowStyleEditor(INStyleable styleable)
		{
			if (styleable == null)
				return;

			NShadowStyle shadowStyle = styleable.ComposeShadowStyle(); 
			NShadowStyle newShadowStyle = null;

			if (NShadowStyleTypeEditor.Edit(shadowStyle, out newShadowStyle))
			{
				NStyle.SetShadowStyle(styleable, newShadowStyle);
				document.RefreshAllViews();
			}
		}
		/// <summary>
		/// Shows the fill style editor for the specified styleable node
		/// </summary>
		/// <param name="styleable"></param>
        protected void ShowFillStyleEditor(INStyleable styleable)
		{
			if (styleable == null)
				return;

			NFillStyle fillStyle = styleable.ComposeFillStyle(); 
			NFillStyle newFillStyle = null;

			if (NFillStyleTypeEditor.Edit(fillStyle, out newFillStyle))
			{
				NStyle.SetFillStyle(styleable, newFillStyle);
				document.RefreshAllViews();
			}
		}
		/// <summary>
		/// Shows the bridge style edtior for the specified styleable node
		/// </summary>
		/// <param name="styleable"></param>
        protected void ShowBridgeStyleEditor(INStyleable styleable)
		{
			if (styleable == null)
				return;

			NBridgeStyle bridgeStyle = styleable.ComposeBridgeStyle(); 
			NBridgeStyle newBridgeStyle = null;

			if (NBridgeStyleTypeEditor.Edit(bridgeStyle, out newBridgeStyle, bridgeStyle != NStyle.GetBridgeStyle(styleable)))
			{
				NStyle.SetBridgeStyle(styleable, newBridgeStyle);
				document.RefreshAllViews();
			}
		}
		/// <summary>
		/// Shows the text style edtior for the specified styleable node
		/// </summary>
		/// <param name="styleable"></param>
        protected void ShowTextStyleEditor(INStyleable styleable)
		{
			if (styleable == null)
				return;

			NTextStyle textStyle = styleable.ComposeTextStyle();
			NTextStyle newTextStyle = null;
			
			if (NTextStyleTypeEditor.Edit(textStyle, textStyle != NStyle.GetTextStyle(styleable), out newTextStyle))
			{
				NStyle.SetTextStyle(styleable, newTextStyle);
				document.SmartRefreshAllViews();
			}
		}

		/// <summary>
		/// Pauses event handling for form controls. 
		/// </summary>
        protected void PauseEventsHandling()
		{
			eventHandlingPauseCounter++;
		}
		/// <summary>
		/// Resumes event handling for form controls
		/// </summary>
        protected void ResumeEventsHandling()
		{
			if (eventHandlingPauseCounter <= 0)
				throw new InvalidOperationException("The event handling pause counter cannot drop below zero. PauseEventsHandling - ResumeEventsHandling calls must match");

			eventHandlingPauseCounter--;
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
			return new NRectangleF(	origin.X + col * (size.Width + spacing.Width), 
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
		protected NShape CreateBasicShape(BasicShapes basicShape, NRectangleF bounds, string text, string styleSheetName)
		{
			NBasicShapesFactory factory = new NBasicShapesFactory(document);
			factory.DefaultSize = bounds.Size;
			NShape shape = factory.CreateShape((int)basicShape);

			shape.Location = bounds.Location;
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
		protected NShape CreateFlowChartingShape(FlowChartingShapes flowChartShape, NRectangleF bounds, string text, string styleSheetName)
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
		protected NShape CreateConnector(NShape fromShape, string fromPortName, NShape toShape, string toPortName, ConnectorType connectorType, string text)
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

		#region Event Handlers
		
		/// <summary>
        /// Invoked when the Reset Example button is clicked. 
        /// The Reset Example button is present in all examples
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ResetExampleButton_Click(object sender, System.EventArgs e)
		{
			ResetExample();
		}
		/// <summary>
        /// Invoked when the Graphics Settings button is clicked
        /// The Graphics Settings button is present in all examples.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GraphicsSettingsButton_Click(object sender, System.EventArgs e)
		{
            try
            {
                Hashtable hash = new Hashtable();
                NDrawingDocument newDoc = (NDrawingDocument)document.Clone();
                this.view.Document = newDoc;
                return;
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
            }
			
            NGraphicsSettings result = null;
			if (NGraphicsSettingsTypeEditor.Edit(document.GraphicsSettings, out result) == false)
				return;
			
			document.GraphicsSettings = result;
			view.Refresh();
		}

		#endregion

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

		/// <summary>
		/// Obtains a reference to the main form
		/// </summary>
		protected NMainForm Form
		{
			get 
			{
				return base.m_MainForm as NMainForm;
			}
		}

		#endregion

		#region Designer Fields
		
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton GraphicsSettingsButton;
		private Nevron.UI.WinForm.Controls.NButton ResetExampleButton;
		internal System.Windows.Forms.Panel commonControlsPanel;
		
		#endregion

		#region Fields

		protected NDrawingDocument document;
		protected NDrawingView view;
		
		private int eventHandlingPauseCounter = 0;
		private NSizeF defaultGridCellSize;
		private NPointF defaultGridOrigin;
		private NSizeF defaultGridSpacing;

		#endregion
	}
}