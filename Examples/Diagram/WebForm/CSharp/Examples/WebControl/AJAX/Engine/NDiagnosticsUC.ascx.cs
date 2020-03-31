using System;
using System.IO;
using System.Drawing;
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
	///		Summary description for NDiagnosticsUC.
	/// </summary>
	public partial class NDiagnosticsUC : NDiagramExampleUC
	{
		#region Event Handlers

		protected void Page_Load(object sender, System.EventArgs e)
		{
			//	initialize the Nevron Instant Callback mode
			NDrawingView1.HttpHandlerCallback = new CustomHttpHandlerCallback();

			if (NDrawingView1.RequiresInitialization)
			{
				// begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Normal;
				NDrawingView1.ScaleX = 1;
				NDrawingView1.ScaleY = 1;
				NDrawingView1.ViewportOrigin = new NPointF();

				// init document
				NDrawingView1.Document.HistoryService.Stop();
				NDrawingView1.Document.BeginInit();
				InitDocument();
				NDrawingView1.Document.EndInit();
			}

			if (!IsPostBack)
			{
				int length;
				string[] names;
				int[] values;
				
				consoleModeDropDownList.Items.Clear();
				names = Enum.GetNames(typeof(AjaxDebugConsoleMode));
				values = (int[])Enum.GetValues(typeof(AjaxDebugConsoleMode));
				
                length = names.Length;
				for (int i = 0; i < length; i++)
				{
					consoleModeDropDownList.Items.Add(new ListItem(names[i], values[i].ToString()));
				}
				consoleModeDropDownList.SelectedValue = ((int)NDrawingView1.AjaxDebugConsoleMode).ToString();
			}
		}

		protected void NDrawingView1_QueryAjaxTools(object sender, EventArgs e)
		{
			//configure the client side tools
			NDrawingView1.AjaxTools.Add(new NAjaxMouseMoveCallbackTool(true));
		}

		protected void consoleModeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			NDrawingView1.AjaxDebugConsoleMode = (AjaxDebugConsoleMode)int.Parse(consoleModeDropDownList.SelectedValue);
			hideConsoleButtonPanel.Visible = (NDrawingView1.AjaxDebugConsoleMode == AjaxDebugConsoleMode.Embedded);
		}

		#endregion

		#region Nested Classes

		[Serializable]
		public class CustomHttpHandlerCallback : NHttpHandlerCallback
		{
			#region INHttpHandlerCallback Members

			public override void OnAsyncMouseMove(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;
				NEllipseShape rotatingEllipse = diagramState.Document.ActiveLayer.GetChildByName("RotatingEllipse", 0) as NEllipseShape;
				if (rotatingEllipse == null)
					return;
				NEllipseShape rotatingEllipse2 = diagramState.Document.ActiveLayer.GetChildByName("RotatingEllipse2", 0) as NEllipseShape;
				if (rotatingEllipse2 == null)
					return;
				NEllipseShape centerEllipse = diagramState.Document.ActiveLayer.GetChildByName("CenterEllipse", 0) as NEllipseShape;
				if (centerEllipse == null)
					return;

				rotatingEllipse.Style.StrokeStyle = null;
				rotatingEllipse2.Style.StrokeStyle = null;
				centerEllipse.Style.StrokeStyle = null;

				NEllipseShape ellipse = HitTestEllipse(state, args);
				if (ellipse == null)
					return;

				ellipse.Style.StrokeStyle = new NStrokeStyle(2f, Color.Snow);

				diagramState.Document.RefreshAllViews();
			}

			public override void OnAsyncRefresh(string webControlId, System.Web.HttpContext context, NStateObject state, EventArgs args)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;
				NEllipseShape rotatingEllipse = diagramState.Document.ActiveLayer.GetChildByName("RotatingEllipse", 0) as NEllipseShape;
				if (rotatingEllipse == null)
					return;
				NEllipseShape rotatingEllipse2 = diagramState.Document.ActiveLayer.GetChildByName("RotatingEllipse2", 0) as NEllipseShape;
				if (rotatingEllipse2 == null)
					return;

				rotatingEllipse.Rotate(CoordinateSystem.Scene, 7, rotatingEllipse.PinPoint);
				rotatingEllipse2.Rotate(CoordinateSystem.Scene, -4, rotatingEllipse2.PinPoint);

				diagramState.Document.RefreshAllViews();
			}

			#endregion

			#region Implementation

			protected NEllipseShape HitTestEllipse(NStateObject state, NCallbackMouseEventArgs args)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;
				NNodeList nodes = diagramState.HitTest(args);
				NNodeList shapes = nodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);
				foreach (NShape node in shapes)
				{
					if (!(node is NEllipseShape))
						continue;
					if (!node.Name.Contains("Ellipse"))
						continue;
					return node as NEllipseShape;
				}

				return null;
			}

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
			NDrawingView1.Document.Style.StrokeStyle = new NStrokeStyle(Color.FromArgb(0, Color.Black));

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
			ag1.BackgroundColor = Color.Silver;
			ag1.Points.Add(new NAdvancedGradientPoint(Color.AliceBlue, 50, 50, 0, 79, AGPointShape.Circle));

			NAdvancedGradientFillStyle ag2 = new NAdvancedGradientFillStyle();
			ag2.BackgroundColor = Color.Goldenrod;
			ag2.Points.Add(new NAdvancedGradientPoint(Color.WhiteSmoke, 50, 50, 0, 71, AGPointShape.Circle));

			NAdvancedGradientFillStyle ag3 = new NAdvancedGradientFillStyle();
			ag3.BackgroundColor = Color.Navy;
			ag3.Points.Add(new NAdvancedGradientPoint(Color.Azure, 50, 50, 0, 50, AGPointShape.Circle));

			//	shapes
			NBasicShapesFactory factory = new NBasicShapesFactory(NDrawingView1.Document);

			NEllipseShape centerEllipse = factory.CreateShape((int)BasicShapes.Ellipse) as NEllipseShape;
			centerEllipse.Name = "CenterEllipse";
			centerEllipse.Width = 50f;
			centerEllipse.Height = 50f;
			centerEllipse.Center = new NPointF(210, 160);
			centerEllipse.Style.StrokeStyle = null;
			centerEllipse.Style.FillStyle = ag3;

			NEllipseShape rotatingEllipse = factory.CreateShape((int)BasicShapes.Ellipse) as NEllipseShape;
			rotatingEllipse.Name = "RotatingEllipse";
			rotatingEllipse.Width = 35f;
			rotatingEllipse.Height = 35f;
			rotatingEllipse.Center = new NPointF(centerEllipse.Bounds.X - 100, centerEllipse.Center.Y);
			rotatingEllipse.Style.StrokeStyle = null;
			rotatingEllipse.Style.FillStyle = ag1;
			rotatingEllipse.PinPoint = new NPointF(centerEllipse.Center.X, centerEllipse.Center.Y);

			NEllipseShape rotatingEllipse2 = factory.CreateShape((int)BasicShapes.Ellipse) as NEllipseShape;
			rotatingEllipse2.Name = "RotatingEllipse2";
			rotatingEllipse2.Width = 15f;
			rotatingEllipse2.Height = 15f;
			rotatingEllipse2.Center = new NPointF(centerEllipse.Bounds.Right + 30, centerEllipse.Center.Y);
			rotatingEllipse2.Style.StrokeStyle = null;
			rotatingEllipse2.Style.FillStyle = ag2;
			rotatingEllipse2.PinPoint = new NPointF(centerEllipse.Center.X, centerEllipse.Center.Y);

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
			base.CreateConnector(NDrawingView1.Document, centerEllipse, "MiddleCenter", rotatingEllipse, "MiddleCenter", ConnectorType.Line, "Radius");
		}

		protected NEllipseShape HitTestEllipse(NCallbackMouseEventArgs args)
		{
			NNodeList nodes = NDrawingView1.HitTest(args);
			NNodeList shapes = nodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);
			foreach (NShape node in shapes)
			{
				if (!(node is NEllipseShape))
					continue;
				if (!node.Name.Contains("Ellipse"))
					continue;
				return node as NEllipseShape;
			}

			return null;
		}

		#endregion
	}
}
