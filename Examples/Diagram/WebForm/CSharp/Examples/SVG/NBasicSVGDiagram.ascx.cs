using System;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.UI.WebForm.Controls;
using Nevron.Examples.Framework.WebForm;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NBasicSVGDiagram.
	/// </summary>
	public partial class NBasicSVGDiagram : NDiagramExampleUC
	{
		protected NDrawingDocument Document;
		protected NDrawingDocumentHelper DocumentHelper;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = false;

			NDrawingView1.ViewLayout = CanvasLayout.Normal;
			NDrawingView1.DocumentPadding = new Nevron.Diagram.NMargins(10);

			// start document initialization
			Document = NDrawingView1.Document;
			Document.BeginInit();

			Document.Bounds = new NRectangleF(0, 0, 344, 540);
			Document.MeasurementUnit = NGraphicsUnit.Pixel;
			Document.DrawingScaleMode = DrawingScaleMode.NoScale;

			DocumentHelper = new NDrawingDocumentHelper(Document);
			DocumentHelper.DefaultGridCellSize = new NSizeF(120, 80);
			DocumentHelper.DefaultGridSpacing = new NSizeF(10, 10);
			
			Document.Style.TextStyle.FontStyle = new NFontStyle(new Font("Arial", 8));
			Document.Style.ShadowStyle.Type = ShadowType.GaussianBlur;
			Document.Style.ShadowStyle.Offset = new Nevron.GraphicsCore.NPointL(5, 5);
			
			CreateRect();
			CreateEllipse();
			CreatePolygon();
			CreateClosedCurve();
			CreateSingleArrow();
			CreateDoubleArrow();

			// end document initialization
			Document.EndInit();

			// change the response type to SVG
			NImageResponse response = new NImageResponse();
			response.ImageFormat = new NSvgImageFormat();
			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = response;
			NDrawingView1.SizeToContent();
		}

		#region Implementation
		
		public void CreateRect()
		{
			// create rect
			NRectangleF cell = this.DocumentHelper.GetGridCell(0, 0);
			NRectangleShape rect = new NRectangleShape(cell);
			
			// set fill and stroke styles
			rect.Style.FillStyle = new NColorFillStyle(Color.Magenta);
			rect.Style.StrokeStyle = new NStrokeStyle(1, Color.Black);

			// add to active layer
			Document.ActiveLayer.AddChild(rect); 
			
			// add description
			cell = this.DocumentHelper.GetGridCell(1, 0);
			NTextShape text = new NTextShape("Rectangle with color fill style and solid stroke style", cell);
			Document.ActiveLayer.AddChild(text);
		}

		public void CreateEllipse()
		{
			// create ellipse
			NRectangleF cell = this.DocumentHelper.GetGridCell(0, 1);
			NEllipseShape ellipse = new NEllipseShape(cell);
			
			// set fill and stroke styles
			ellipse.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.Magenta, Color.LightGreen);
			ellipse.Style.StrokeStyle = new NStrokeStyle(1, Color.Black, LinePattern.Dash);

			// add to active layer
			Document.ActiveLayer.AddChild(ellipse); 
			
			// add description
			cell = this.DocumentHelper.GetGridCell(1, 1);
			NTextShape text = new NTextShape("Ellipse with gradient fill style and dash stroke style", cell);
			Document.ActiveLayer.AddChild(text);
		}

		public void CreatePolygon()
		{
			// create polygon
			NRectangleF cell = this.DocumentHelper.GetGridCell(0, 2);
			int xdeviation = (int)cell.Width / 4;
			int ydeviation = (int)cell.Height / 4;

			NPointF[] points = new NPointF[]
			{
				new NPointF(cell.X + Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)),
				new NPointF(cell.Right - Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)),
				new NPointF(cell.Right - Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)),
				new NPointF(cell.X + Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)),
				new NPointF(cell.X + Random.Next((int)cell.Width), cell.Y + Random.Next((int)cell.Height))
			};
			
			NPolygonShape polygon = new NPolygonShape(points);

			// set fill and stroke styles
			polygon.Style.FillStyle = new NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.Green, Color.Yellow);
			polygon.Style.StrokeStyle = new NStrokeStyle(1, Color.Black, LinePattern.DashDot);

			// add to active layer
			Document.ActiveLayer.AddChild(polygon); 
			
			// add description
			cell = this.DocumentHelper.GetGridCell(1, 2);
			NTextShape text = new NTextShape("Polygon with gradient fill style and dash-dot stroke style", cell);
			Document.ActiveLayer.AddChild(text);
		}

		public void CreateClosedCurve()
		{
			// create curve
			NRectangleF cell = this.DocumentHelper.GetGridCell(0, 3);
			int xdeviation = (int)cell.Width / 4;
			int ydeviation = (int)cell.Height / 4;

			NPointF[] points = new NPointF[]
			{
				new NPointF(cell.X + Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)),
				new NPointF(cell.Right - Random.Next(xdeviation), cell.Y + Random.Next(ydeviation)),
				new NPointF(cell.Right - Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)),
				new NPointF(cell.X + Random.Next(xdeviation), cell.Bottom - Random.Next(ydeviation)),
				new NPointF(cell.X + Random.Next((int)cell.Width), cell.Y + Random.Next((int)cell.Height))
			};
			
			NClosedCurveShape curve = new NClosedCurveShape(points, 1);

			// set fill and stroke styles
			curve.Style.FillStyle = new NHatchFillStyle(HatchStyle.SmallGrid, Color.LightSalmon, Color.Chocolate);
			curve.Style.StrokeStyle = new NStrokeStyle(1, Color.Black, LinePattern.DashDotDot);

			// add to active layer
			Document.ActiveLayer.AddChild(curve); 
			
			// add description
			cell = this.DocumentHelper.GetGridCell(1, 3);
			NTextShape text = new NTextShape("Closed curve with hatch fill style and dash-dot-dot stroke style", cell);
			Document.ActiveLayer.AddChild(text);
		}

		public void CreateSingleArrow()
		{
			// create single arrow
			NRectangleF cell = this.DocumentHelper.GetGridCell(2, 0);
			NPointF startPoint = new NPointF(cell.X, cell.Y + cell.Height / 2);
			NPointF endPoint = new NPointF(cell.Right, cell.Y + cell.Height / 2);

			NArrowShape arrow = new NArrowShape(ArrowType.SingleArrow, startPoint, endPoint, 20, 45, 60);
			
			// set styles
			arrow.Style.FillStyle = new NHatchFillStyle(HatchStyle.SmallGrid, Color.Yellow, Color.Coral);
			arrow.Style.StrokeStyle = new NStrokeStyle(1, Color.Black, LinePattern.Dot);

			// add to the active layer
			Document.ActiveLayer.AddChild(arrow); 
			
			// add description
			cell = this.DocumentHelper.GetGridCell(3, 0);
			NTextShape text = new NTextShape("Single arrow with hatch fill style and dot stroke style", cell);
			Document.ActiveLayer.AddChild(text);
		}

		public void CreateDoubleArrow()
		{
			// create double arrow
			NRectangleF cell = this.DocumentHelper.GetGridCell(2, 1);
			NPointF startPoint = new NPointF(cell.X, cell.Y + cell.Height / 2);
			NPointF endPoint = new NPointF(cell.Right, cell.Y + cell.Height / 2);

			NArrowShape arrow = new NArrowShape(ArrowType.DoubleArrow, startPoint, endPoint, 20, 45, 60);
			
			// set styles
			try
			{
				Bitmap bmp = new Bitmap(this.MapPathSecure(this.TemplateSourceDirectory + "\\..\\Images\\ConceptCar2.png"));
				arrow.Style.FillStyle = new NImageFillStyle(bmp, 125);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Failed to load concept car resource. Exception was: " + ex.Message);
			}

			arrow.Style.StrokeStyle = new NStrokeStyle(1, Color.Black, LinePattern.Solid);

			// add to the active layer
			Document.ActiveLayer.AddChild(arrow); 
			
			// add description
			cell = this.DocumentHelper.GetGridCell(3, 1);
			NTextShape text = new NTextShape("Single arrow with semi transparent image fill style and solid stroke style", cell);
			Document.ActiveLayer.AddChild(text);
		}

		#endregion
	}
}
