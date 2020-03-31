using System;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Batches;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NEventQueueingUC.
	/// </summary>
	public partial class NEventQueueingUC : NDiagramExampleUC
	{
		#region Event Handlers

		protected void Page_Load(object sender, System.EventArgs e)
		{
			NDrawingView1.HttpHandlerCallback = new CustomHttpHandlerCallback();

			if (NDrawingView1.RequiresInitialization)
			{
				// begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Fit;
				NDrawingView1.DocumentPadding = new Nevron.Diagram.NMargins(10);

				// init document
				NDrawingView1.Document.BeginInit();
				InitDocument();
				NDrawingView1.Document.EndInit();
			}
		}

		protected void NDrawingView1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			NDrawingView1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseDoubleClickCallbackTool(true));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseMoveCallbackTool(true));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseDownCallbackTool(false));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseUpCallbackTool(false));
		}

		protected void addResponseDelayCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			//	select the default enabled state of the mouse tools
			NDrawingView1.AjaxTools.GetToolByType(typeof(NAjaxMouseClickCallbackTool)).DefaultEnabled = (Request["mouseClickCheckbox"] != null);
			NDrawingView1.AjaxTools.GetToolByType(typeof(NAjaxMouseDoubleClickCallbackTool)).DefaultEnabled = (Request["mouseDoubleClickCheckbox"] != null);
			NDrawingView1.AjaxTools.GetToolByType(typeof(NAjaxMouseMoveCallbackTool)).DefaultEnabled = (Request["mouseMoveCheckbox"] != null);
			NDrawingView1.AjaxTools.GetToolByType(typeof(NAjaxMouseDownCallbackTool)).DefaultEnabled = (Request["mouseDownCheckbox"] != null);
			NDrawingView1.AjaxTools.GetToolByType(typeof(NAjaxMouseUpCallbackTool)).DefaultEnabled = (Request["mouseUpCheckbox"] != null);

			//	select the default enabled state of client side services
			NDrawingView1.AsyncAutoRefreshEnabled = (Request["autoRefreshCheckbox"] != null);
			NDrawingView1.AsyncRequestWaitCursorEnabled = (Request["waitCursorCheckbox"] != null);

			int val;

			if(int.TryParse(Request["autoRefreshIntervalCombo"], out val))
				NDrawingView1.AsyncRefreshInterval = val;

			if(int.TryParse(Request["mouseClickPriorityCombo"], out val))
				NDrawingView1.AsyncClickEventPriority = val;

			if (int.TryParse(Request["mouseClickQueueLengthCombo"], out val))
				NDrawingView1.AsyncClickEventQueueLength = val;

			if (int.TryParse(Request["mouseDoubleClickPriorityCombo"], out val))
				NDrawingView1.AsyncDoubleClickEventPriority = val;

			if (int.TryParse(Request["mouseDoubleClickQueueLengthCombo"], out val))
				NDrawingView1.AsyncDoubleClickEventQueueLength = val;

			if (int.TryParse(Request["mouseMovePriorityCombo"], out val))
				NDrawingView1.AsyncMouseMoveEventPriority = val;

			if (int.TryParse(Request["mouseMoveQueueLengthCombo"], out val))
				NDrawingView1.AsyncMouseMoveEventQueueLength = val;

			if (int.TryParse(Request["mouseDownPriorityCombo"], out val))
				NDrawingView1.AsyncMouseDownEventPriority = val;

			if (int.TryParse(Request["mouseDownQueueLengthCombo"], out val))
				NDrawingView1.AsyncMouseDownEventQueueLength = val;

			if (int.TryParse(Request["mouseUpPriorityCombo"], out val))
				NDrawingView1.AsyncMouseUpEventPriority = val;
			
			if (int.TryParse(Request["mouseUpQueueLengthCombo"], out val))
				NDrawingView1.AsyncMouseUpEventQueueLength = val;

			if (int.TryParse(Request["refreshPriorityCombo"], out val))
				NDrawingView1.AsyncRefreshPriority = val;

			if (int.TryParse(Request["refreshQueueLengthCombo"], out val))
				NDrawingView1.AsyncRefreshQueueLength = val;

			CustomHttpHandlerCallback httpHandlerCallback = NDrawingView1.HttpHandlerCallback as CustomHttpHandlerCallback;
			httpHandlerCallback.SimulateResponseDelay = addResponseDelayCheckBox.Checked;
		}

		#endregion

		#region Nested Classes

		[Serializable]
		public class CustomHttpHandlerCallback : NHttpHandlerCallback
		{
			#region INHttpHandlerCallback Members

			public override void OnAsyncClick(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				DoSimulateResponseDelay();
				ChangeCurrentShapeColor(webControlId, context, state, args, Color.YellowGreen);
			}

            public override void OnAsyncDoubleClick(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				DoSimulateResponseDelay();
				ChangeCurrentShapeColor(webControlId, context, state, args, Color.Red);
			}

            public override void OnAsyncMouseDown(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				DoSimulateResponseDelay();
				ChangeCurrentShapeColor(webControlId, context, state, args, Color.Yellow);
			}

            public override void OnAsyncMouseUp(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				DoSimulateResponseDelay();
				ChangeCurrentShapeColor(webControlId, context, state, args, Color.BlueViolet);
			}

            public override void OnAsyncMouseMove(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				DoSimulateResponseDelay();
				ChangeCurrentShapeShadow(webControlId, context, state, args);
			}

            public override void OnAsyncRefresh(string webControlId, System.Web.HttpContext context, NStateObject state, EventArgs args)
			{
				DoSimulateResponseDelay();

				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;

				NEllipseShape rotatingEllipse = diagramState.Document.ActiveLayer.GetChildByName("RotatingEllipse", 0) as NEllipseShape;
				if (rotatingEllipse == null)
					return;
				NEllipseShape rotatingEllipse2 = diagramState.Document.ActiveLayer.GetChildByName("RotatingEllipse2", 0) as NEllipseShape;
				if (rotatingEllipse2 == null)
					return;

				rotatingEllipse.Rotate(CoordinateSystem.Scene, 7, rotatingEllipse.PinPoint);
				rotatingEllipse2.Rotate(CoordinateSystem.Scene, -4, rotatingEllipse2.PinPoint);
			}

			#endregion

			#region Implementation

			protected void DoSimulateResponseDelay()
			{
				if (!SimulateResponseDelay)
					return;

				System.Threading.Thread.Sleep(600);
			}

			protected void ChangeCurrentShapeColor(string webControlId, System.Web.HttpContext context, NStateObject state, EventArgs args, Color c)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;

				NNodeList allShapes = diagramState.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D);

				NNodeList affectedNodes = diagramState.HitTest(args as NCallbackMouseEventArgs);
				NNodeList affectedShapes = affectedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);

				int length;
				NShape shape;

				length = allShapes.Count;
				for (int i = 0; i < length; i++)
				{
					shape = allShapes[i] as NShape;
					if (shape.Tag != null)
					{
						shape.Style.FillStyle = shape.Tag as NAdvancedGradientFillStyle;
					}
				}

				if (affectedShapes.Count == 0)
					return;

				shape = affectedShapes[affectedShapes.Count - 1] as NShape;
				NAdvancedGradientFillStyle fs = shape.Style.FillStyle as NAdvancedGradientFillStyle;
				if (fs != null)
				{
					shape.Tag = fs;
					shape.Style.FillStyle = new NColorFillStyle(c);
				}
			}

			protected void ChangeCurrentShapeShadow(string webControlId, System.Web.HttpContext context, NStateObject state, EventArgs args)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;

				NNodeList allShapes = diagramState.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D);

				NNodeList affectedNodes = diagramState.HitTest(args as NCallbackMouseEventArgs);
				NNodeList affectedShapes = affectedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);

				int length;
				NShape shape;

				length = allShapes.Count;
				for (int i = 0; i < length; i++)
				{
					shape = allShapes[i] as NShape;
					shape.Style.ShadowStyle = null;
				}

				if (affectedShapes.Count == 0)
					return;

				shape = affectedShapes[affectedShapes.Count - 1] as NShape;
				if (shape.Style.StrokeStyle == null)
				{
					shape.Style.ShadowStyle = new NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(96, Color.Black), new NPointL(3, 3), 1, new NLength(10));
				}
			}

			#endregion

			#region Fields

			public bool SimulateResponseDelay = false;

			#endregion
		}

		#endregion

		#region Implementation

		private void InitDocument()
		{
			// modify the connectors style sheet
			NStyleSheet styleSheet = (NDrawingView1.Document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1) as NStyleSheet);

			NTextStyle textStyle = new NTextStyle();
			textStyle.BackplaneStyle.Visible = true;
			textStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = new NLength(0);
			textStyle.BackplaneStyle.FillStyle = new NColorFillStyle(Color.FromArgb(200, Color.White));
			styleSheet.Style.TextStyle = textStyle;

			styleSheet.Style.StrokeStyle = new NStrokeStyle(1, Color.Black);
			styleSheet.Style.StartArrowheadStyle.StrokeStyle = new NStrokeStyle(Color.FromArgb(0, Color.Black));
			styleSheet.Style.StartArrowheadStyle.FillStyle = new NColorFillStyle(Color.FromArgb(0, Color.White));
			styleSheet.Style.EndArrowheadStyle.StrokeStyle = new NStrokeStyle(1, Color.Black);

			// modify default stroke style
			NDrawingView1.Document.Style.StrokeStyle = new NStrokeStyle(Color.FromArgb(0, Color.White));

			// configure the document
			NDrawingView1.Document.Bounds = new NRectangleF(0, 0, 420, 320);
			NDrawingView1.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			NDrawingView1.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			NDrawingView1.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
			NDrawingView1.Document.MeasurementUnit = NGraphicsUnit.Pixel;
			NDrawingView1.Document.DrawingScaleMode = DrawingScaleMode.NoScale;

			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = false;

			//	predefined styles
			NAdvancedGradientFillStyle ag1 = new NAdvancedGradientFillStyle();
			ag1.BackgroundColor = Color.Navy;
			ag1.Points.Add(new NAdvancedGradientPoint(Color.SkyBlue, 50, 50, 0, 79, AGPointShape.Circle));

			NAdvancedGradientFillStyle ag2 = new NAdvancedGradientFillStyle();
			ag2.BackgroundColor = Color.DarkRed;
			ag2.Points.Add(new NAdvancedGradientPoint(Color.Red, 50, 50, 0, 71, AGPointShape.Circle));

			NAdvancedGradientFillStyle ag3 = new NAdvancedGradientFillStyle();
			ag3.BackgroundColor = Color.Orange;
			ag3.Points.Add(new NAdvancedGradientPoint(Color.Yellow, 50, 50, 0, 50, AGPointShape.Circle));

			//	shapes
			NBasicShapesFactory factory = new NBasicShapesFactory(NDrawingView1.Document);

			NEllipseShape centerEllipse = factory.CreateShape((int)BasicShapes.Ellipse) as NEllipseShape;
			centerEllipse.Name = "CenterEllipse";
			centerEllipse.Width = 50f;
			centerEllipse.Height = 50f;
			centerEllipse.Center = new NPointF(210, 160);
			centerEllipse.Style.StrokeStyle = null;
			centerEllipse.Style.FillStyle = ag3;
			centerEllipse.Style.InteractivityStyle = new NInteractivityStyle(true, centerEllipse.Name);

			NEllipseShape rotatingEllipse = factory.CreateShape((int)BasicShapes.Ellipse) as NEllipseShape;
			rotatingEllipse.Name = "RotatingEllipse";
			rotatingEllipse.Width = 35f;
			rotatingEllipse.Height = 35f;
			rotatingEllipse.Center = new NPointF(centerEllipse.Bounds.X - 100, centerEllipse.Center.Y);
			rotatingEllipse.Style.StrokeStyle = null;
			rotatingEllipse.Style.FillStyle = ag1;
			rotatingEllipse.PinPoint = new NPointF(centerEllipse.Center.X, centerEllipse.Center.Y);
			rotatingEllipse.Style.InteractivityStyle = new NInteractivityStyle(true, rotatingEllipse.Name);

			NEllipseShape rotatingEllipse2 = factory.CreateShape((int)BasicShapes.Ellipse) as NEllipseShape;
			rotatingEllipse2.Name = "RotatingEllipse2";
			rotatingEllipse2.Width = 15f;
			rotatingEllipse2.Height = 15f;
			rotatingEllipse2.Center = new NPointF(centerEllipse.Bounds.Right + 30, centerEllipse.Center.Y);
			rotatingEllipse2.Style.StrokeStyle = null;
			rotatingEllipse2.Style.FillStyle = ag2;
			rotatingEllipse2.PinPoint = new NPointF(centerEllipse.Center.X, centerEllipse.Center.Y);
			rotatingEllipse2.Style.InteractivityStyle = new NInteractivityStyle(true, rotatingEllipse2.Name);

			NEllipseShape orbit1 = factory.CreateShape((int)BasicShapes.Ellipse) as NEllipseShape;
			orbit1.Name = "orbit1";
			orbit1.Width = 2 * (centerEllipse.Center.X - rotatingEllipse.Center.X);
			orbit1.Height = orbit1.Width;
			orbit1.Center = new NPointF(centerEllipse.Center.X, centerEllipse.Center.Y);
			orbit1.Style.StrokeStyle = new NStrokeStyle(Color.Black);
			orbit1.Style.StrokeStyle.Pattern = LinePattern.Dot;
			orbit1.Style.StrokeStyle.Factor = 2;
			orbit1.Style.FillStyle = new NColorFillStyle(Color.FromArgb(0, Color.White));

			NEllipseShape orbit2 = factory.CreateShape((int)BasicShapes.Ellipse) as NEllipseShape;
			orbit2.Name = "orbit2";
			orbit2.Width = 2 * (centerEllipse.Center.X - rotatingEllipse2.Center.X);
			orbit2.Height = orbit2.Width;
			orbit2.Center = new NPointF(centerEllipse.Center.X, centerEllipse.Center.Y);
			orbit2.Style.StrokeStyle = new NStrokeStyle(Color.Black);
			orbit2.Style.StrokeStyle.Pattern = LinePattern.Dot;
			orbit2.Style.StrokeStyle.Factor = 2;
			orbit2.Style.FillStyle = new NColorFillStyle(Color.FromArgb(0, Color.White));

			NDrawingView1.Document.ActiveLayer.AddChild(orbit1);
			NDrawingView1.Document.ActiveLayer.AddChild(orbit2);
			NDrawingView1.Document.ActiveLayer.AddChild(centerEllipse);
			NDrawingView1.Document.ActiveLayer.AddChild(rotatingEllipse);
			NDrawingView1.Document.ActiveLayer.AddChild(rotatingEllipse2);

			// some shapes need to have extra ports
			NRotatedBoundsPort port = new NRotatedBoundsPort(centerEllipse.UniqueId, ContentAlignment.MiddleCenter);
			port.Name = "MiddleCenter";
			centerEllipse.Ports.AddChild(port);

			port = new NRotatedBoundsPort(rotatingEllipse.UniqueId, ContentAlignment.MiddleCenter);
			port.Name = "MiddleCenter";
			rotatingEllipse.Ports.AddChild(port);

			// connect shapes in levels
			NShape connector = base.CreateConnector(NDrawingView1.Document, centerEllipse, "MiddleCenter", rotatingEllipse, "MiddleCenter", ConnectorType.Line, "Radius");
			NInteractivityStyle istyle = connector.ComposeInteractivityStyle();
		}

		#endregion
	}
}
