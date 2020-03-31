using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Nevron.GraphicsCore;

using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WebForm;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NCustomCommandsUC.
	/// </summary>
	public partial class NCustomCommandsUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
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

		protected void NDrawingView1_AsyncCustomCommand(object sender, EventArgs e)
		{
			NCallbackCustomCommandArgs args = e as NCallbackCustomCommandArgs;
			NCallbackCommand command = args.Command;

			switch (command.Name)
			{
				case "changeColor":
					string idText = command.Arguments["id"] as string;
					if (idText == null)
						break;

					NElementAtomIdentifier id = new NElementAtomIdentifier(idText);
					NEllipsePath path = id.FindInDocument(NDrawingView1.Document) as NEllipsePath;
					if (path == null)
						break;

					NShape shape = NSceneTree.FirstAncestor(path, NFilters.TypeNShape) as NShape;

					Color c = Color.Red;
                    if (command.Arguments["color"].ToString() == "blue")
                    {
                        c = Color.Blue;
                    }

					NColorFillStyle fs = shape.Style.FillStyle as NColorFillStyle;
					shape.Style.FillStyle = new NColorFillStyle(c);

					clientSideRedrawRequired = (fs == null || fs.Color != c);
					break;

				case "rotate10Degrees":
					IterateRotatingEllipse(true);
					break;
			}
		}

		protected void NDrawingView1_AsyncQueryCommandResult(object sender, EventArgs e)
		{
			NCallbackQueryCommandResultArgs args = e as NCallbackQueryCommandResultArgs;
			NCallbackCommand command = args.Command;
			NAjaxXmlTransportBuilder resultBuilder = args.ResultBuilder;

			switch (command.Name)
			{
				case "queryPosition":
					//	build a custom response data section
					NEllipseShape rotatingEllipse = NDrawingView1.Document.ActiveLayer.GetChildByName("RotatingEllipse", 0) as NEllipseShape;
                    if (rotatingEllipse != null)
                    {
                        NAjaxXmlDataSection dataSection = new NAjaxXmlDataSection("position");
                        dataSection.Data = rotatingEllipse.Center.ToString();
                        resultBuilder.AddDataSection(dataSection);
                    }
					break;

				case "changeColor":
					//	add a built-in data section that will enforce full image refresh at the client
                    if (clientSideRedrawRequired && !resultBuilder.ContainsRedrawDataSection())
                    {
                        resultBuilder.AddRedrawDataSection(NDrawingView1);
                    }
					break;

				case "rotate10Degrees":
                    if (resultBuilder.ContainsRedrawDataSection() == false)
                    {
                        resultBuilder.AddRedrawDataSection(NDrawingView1);
                    }
					break;
			}
		}

		protected void NDrawingView1_AsyncRefresh(object sender, EventArgs e)
		{
			IterateRotatingEllipse(false);
		}

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

		protected void IterateRotatingEllipse(bool boost)
		{
			NEllipseShape rotatingEllipse = NDrawingView1.Document.ActiveLayer.GetChildByName("RotatingEllipse", 0) as NEllipseShape;
			if (rotatingEllipse == null)
				return;

			NEllipseShape rotatingEllipse2 = NDrawingView1.Document.ActiveLayer.GetChildByName("RotatingEllipse2", 0) as NEllipseShape;
			if (rotatingEllipse2 == null)
				return;

			if (!boost)
			{
				rotatingEllipse.Rotate(CoordinateSystem.Scene, 7, rotatingEllipse.PinPoint);
				rotatingEllipse2.Rotate(CoordinateSystem.Scene, -4, rotatingEllipse2.PinPoint);
			}
			else
			{
				rotatingEllipse.Rotate(CoordinateSystem.Scene, 27, rotatingEllipse.PinPoint);
				rotatingEllipse2.Rotate(CoordinateSystem.Scene, -14, rotatingEllipse2.PinPoint);
			}

			NDrawingView1.Document.RefreshAllViews();
		}
		
		#endregion

		#region Fields

		private bool clientSideRedrawRequired = false;

		#endregion
	}
}
