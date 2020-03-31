using System;
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
	public partial class NAutoUpdateUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// begin view init
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(100, 50);
			base.DefaultGridSpacing = new NSizeF(50, 40);

            if (!NThinDiagramControl1.Initialized)
            {
				// begin view init
				NThinDiagramControl1.View.Layout = CanvasLayout.Fit;

				// init document
				NThinDiagramControl1.Document.BeginInit();
				InitDocument();
				NThinDiagramControl1.Document.EndInit();

                // register the auto update callback
                NThinDiagramControl1.AutoUpdateCallback = new NAutoUpdateCallback();

                NThinDiagramControl1.ServerSettings.AutoUpdateInterval = 200;
                NThinDiagramControl1.ServerSettings.EnableAutoUpdate = true;
			}
		}

		#region Nested Classes

		[Serializable]
        public class NAutoUpdateCallback : INAutoUpdateCallback
		{
			#region INAutoUpdateCallback Members

			void INAutoUpdateCallback.OnAutoUpdate(NAspNetThinWebControl control)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;

				NDrawingDocument document = diagramControl.Document;

				NEllipseShape rotatingEllipse = document.ActiveLayer.GetChildByName("RotatingEllipse", 0) as NEllipseShape;
				if (rotatingEllipse == null)
					return;

				NEllipseShape rotatingEllipse2 = document.ActiveLayer.GetChildByName("RotatingEllipse2", 0) as NEllipseShape;
				if (rotatingEllipse2 == null)
					return;

				rotatingEllipse.Rotate(CoordinateSystem.Scene, 7, rotatingEllipse.PinPoint);
				rotatingEllipse2.Rotate(CoordinateSystem.Scene, -4, rotatingEllipse2.PinPoint);

				diagramControl.UpdateView();
			}

			void INAutoUpdateCallback.OnAutoUpdateStateChanged(NAspNetThinWebControl control)
			{
				throw new NotImplementedException();
			}

			#endregion
		}

		#endregion

		#region Implementation

		private void InitDocument()
		{
			// modify the connectors style sheet
			NStyleSheet styleSheet = (NThinDiagramControl1.Document.StyleSheets.GetChildByName(NDR.NameConnectorsStyleSheet, -1) as NStyleSheet);

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
			NThinDiagramControl1.Document.Style.StrokeStyle = new NStrokeStyle(Color.FromArgb(0, Color.Black));

			// configure the document
			NThinDiagramControl1.Document.Bounds = new NRectangleF(0, 0, 420, 320);
			NThinDiagramControl1.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			NThinDiagramControl1.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			NThinDiagramControl1.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
			NThinDiagramControl1.Document.MeasurementUnit = NGraphicsUnit.Pixel;
			NThinDiagramControl1.Document.DrawingScaleMode = DrawingScaleMode.NoScale;

			NThinDiagramControl1.Document.BackgroundStyle.FrameStyle.Visible = false;

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
			NBasicShapesFactory factory = new NBasicShapesFactory(NThinDiagramControl1.Document);

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

			NThinDiagramControl1.Document.ActiveLayer.AddChild(orbit1);
			NThinDiagramControl1.Document.ActiveLayer.AddChild(orbit2);
			NThinDiagramControl1.Document.ActiveLayer.AddChild(centerEllipse);
			NThinDiagramControl1.Document.ActiveLayer.AddChild(rotatingEllipse);
			NThinDiagramControl1.Document.ActiveLayer.AddChild(rotatingEllipse2);

			// some shapes need to have extra ports
			NRotatedBoundsPort port = new NRotatedBoundsPort(centerEllipse.UniqueId, ContentAlignment.MiddleCenter);
			port.Name = "MiddleCenter";
			centerEllipse.Ports.AddChild(port);

			port = new NRotatedBoundsPort(rotatingEllipse.UniqueId, ContentAlignment.MiddleCenter);
			port.Name = "MiddleCenter";
			rotatingEllipse.Ports.AddChild(port);

			// connect shapes in levels
			base.CreateConnector(NThinDiagramControl1.Document, centerEllipse, "MiddleCenter", rotatingEllipse, "MiddleCenter", ConnectorType.Line, "Radius");
		}

		#endregion
	}
}