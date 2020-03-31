using System;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Batches;
using Nevron.Diagram.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NInstantMouseEventsUC.
	/// </summary>
	public partial class NInstantMouseEventsUC : NDiagramExampleUC
	{
		#region Event Handlers

		protected void Page_Load(object sender, System.EventArgs e)
		{
			NDrawingView1.HttpHandlerCallback = new CustomHttpHandlerCallback();

			if (NDrawingView1.RequiresInitialization)
			{
				// begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Fit;

				// init document
				NDrawingView1.Document.HistoryService.Stop();
				NDrawingView1.Document.BeginInit();
				InitDocument();
				NDrawingView1.Document.EndInit();
			}
		}

		protected void NDrawingView1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			NDrawingView1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(false));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseDoubleClickCallbackTool(false));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseMoveCallbackTool(true));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseDownCallbackTool(false));
			NDrawingView1.AjaxTools.Add(new NAjaxMouseUpCallbackTool(false));
		}

		protected void simulatePostbackButton_Click(object sender, EventArgs e)
		{
			//	select the default enabled state of the mouse tools
			NDrawingView1.AjaxTools.GetToolByType(typeof(NAjaxMouseClickCallbackTool)).DefaultEnabled = (Request["mouseClickCheckbox"] != null);
			NDrawingView1.AjaxTools.GetToolByType(typeof(NAjaxMouseDoubleClickCallbackTool)).DefaultEnabled = (Request["mouseDoubleClickCheckbox"] != null);
			NDrawingView1.AjaxTools.GetToolByType(typeof(NAjaxMouseMoveCallbackTool)).DefaultEnabled = (Request["mouseMoveCheckbox"] != null);
			NDrawingView1.AjaxTools.GetToolByType(typeof(NAjaxMouseDownCallbackTool)).DefaultEnabled = (Request["mouseDownCheckbox"] != null);
			NDrawingView1.AjaxTools.GetToolByType(typeof(NAjaxMouseUpCallbackTool)).DefaultEnabled = (Request["mouseUpCheckbox"] != null);

			//	select the default enabled state of client side services
			NDrawingView1.AsyncRequestWaitCursorEnabled = (Request["waitCursorCheckbox"] != null);

			simulatePostbackLabel.Text = "Postback simulated!";
		}

		#endregion

		#region Nested Classes

		[Serializable]
		public class CustomHttpHandlerCallback : NHttpHandlerCallback
		{
			#region INHttpHandlerCallback Members

			public override void OnAsyncClick(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				OnMouseEvent(webControlId, context, state, args);
			}

            public override void OnAsyncDoubleClick(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				OnMouseEvent(webControlId, context, state, args);
			}

            public override void OnAsyncMouseDown(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				OnMouseEvent(webControlId, context, state, args);
			}

            public override void OnAsyncMouseMove(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				OnMouseEvent(webControlId, context, state, args);
			}

            public override void OnAsyncMouseUp(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				OnMouseEvent(webControlId, context, state, args);
			}

			#endregion

			#region Implementations

			protected void OnMouseEvent(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				NDiagramSessionStateObject diagramState = state as NDiagramSessionStateObject;

				NNodeList allShapes = diagramState.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D);
				
				NNodeList affectedNodes = diagramState.HitTest(args);
				NNodeList affectedShapes = affectedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D);

				int length;

				length = allShapes.Count;
				for (int i = 0; i < length; i++)
				{
					NShape shape = allShapes[i] as NShape;
					shape.Style.ShadowStyle = null;
					if (shape.Tag != null)
					{
						shape.Style.FillStyle = new NColorFillStyle((Color)shape.Tag);
					}
				}

				length = affectedShapes.Count;
				for (int i = 0; i < length; i++)
				{
					NShape shape = affectedShapes[i] as NShape;
					shape.Style.ShadowStyle = new NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(96, Color.Black), new NPointL(3, 3), 1, new NLength(10));
					NColorFillStyle fs = shape.Style.FillStyle as NColorFillStyle;
					if (fs != null && fs.Color != Color.White)
					{
						shape.Tag = fs.Color;
						shape.Style.FillStyle = new NColorFillStyle(Color.YellowGreen);
					}
				}
			}

			#endregion
		}

		#endregion

		#region Implementation

		protected void InitDocument()
		{
			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = false;
			NDrawingView1.Document.AutoBoundsPadding = new Nevron.Diagram.NMargins(10f, 10f, 10f, 10f);
			NDrawingView1.Document.Style.FillStyle = new NColorFillStyle(Color.White);

			NBasicShapesFactory factory = new NBasicShapesFactory(NDrawingView1.Document);

			NShape outerCircle = factory.CreateShape(BasicShapes.Circle);
			outerCircle.Bounds = new NRectangleF(0f, 0f, 200f, 200f);
			NDrawingView1.Document.ActiveLayer.AddChild(outerCircle);

			NShape rect = factory.CreateShape(BasicShapes.Rectangle);
			rect.Bounds = new NRectangleF(42f, 42f, 50f, 50f);
			rect.Style.FillStyle = new NColorFillStyle(Color.Orange);
			NDrawingView1.Document.ActiveLayer.AddChild(rect);

			NShape triangle = factory.CreateShape(BasicShapes.Triangle);
			triangle.Bounds = new NRectangleF(121f, 57f, 60f, 55f);
			triangle.Style.FillStyle = new NColorFillStyle(Color.LightGray);
			NDrawingView1.Document.ActiveLayer.AddChild(triangle);

			NShape pentagon = factory.CreateShape(BasicShapes.Pentagon);
			pentagon.Bounds = new NRectangleF(60f, 120f, 54f, 50f);
			pentagon.Style.FillStyle = new NColorFillStyle(Color.WhiteSmoke);
			NDrawingView1.Document.ActiveLayer.AddChild(pentagon);

			NDrawingView1.Document.SizeToContent();
		}

		#endregion
	}
}
