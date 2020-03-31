using System;
using System.IO;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.Extensions;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NFlashRedirectUC.
	/// </summary>
	public class NFlashRedirectUC : NExportBaseUC
	{
		#region Constructors

		public NFlashRedirectUC(NMainForm form)
			: base(form)
		{
			btnExport.Text = "Export to SWF";
		}

		#endregion

		#region Overrides

		protected override void CreateDiagram()
		{
			// Initialize the default document style
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None;
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None;
			document.Style.FillStyle = new NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant1,
				new NArgbColor(155, 184, 209), new NArgbColor(83, 138, 179));

			// Create the shapes
			NShape vision = CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(0, 0, 100, 50), "Nevron Vision", String.Empty);
			NInteractivityStyle iStyle = new NInteractivityStyle();
			iStyle.UrlLink = new NUrlLinkAttribute("http://www.nevron.com", true);
			NStyle.SetInteractivityStyle(vision, iStyle);

			NShape chart = CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(0, 0, 100, 50), "Nevron Chart", String.Empty);
			iStyle = new NInteractivityStyle();
			iStyle.UrlLink = new NUrlLinkAttribute("http://nevron.com/Products.ChartFor.NET.Overview.aspx", true);
			NStyle.SetInteractivityStyle(chart, iStyle);

			NShape diagram = CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(0, 0, 100, 50), "Nevron Diagram", String.Empty);
			iStyle = new NInteractivityStyle();
			iStyle.UrlLink = new NUrlLinkAttribute("http://nevron.com/Products.DiagramFor.NET.Overview.aspx", true);
			NStyle.SetInteractivityStyle(diagram, iStyle);

			NShape ui = CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(0, 0, 100, 50), "Nevron User Interface", String.Empty);
			iStyle = new NInteractivityStyle();
			iStyle.UrlLink = new NUrlLinkAttribute("http://nevron.com/Products.UserInterfaceFor.NET.Overview.aspx", true);
			NStyle.SetInteractivityStyle(ui, iStyle);

			// Create the connectors
			Connect(vision, chart);
			Connect(vision, diagram);
			Connect(vision, ui);

			// Layout the shapes
			NLayeredGraphLayout layout = new NLayeredGraphLayout();
			layout.Direction = LayoutDirection.LeftToRight;
			NNodeList shapes = document.ActiveLayer.Children(null);
			layout.Layout(shapes, new NDrawingLayoutContext(document));
		}
		protected override string ErrorMessage
		{
			get
			{
				return "The generated SWF file failed to open. May be you do not have a Flash player installed.";
			}
		} 
		protected override string Export()
		{
			NFlashExporter exporter = new NFlashExporter(document);
			string fileName = Path.Combine(Application.StartupPath, "test.swf");
			exporter.SaveToFile(fileName);
			return fileName;
		}

		#endregion

		#region Implementation

		private void Connect(NShape shape1, NShape shape2)
		{
			NRoutableConnector connector = new NRoutableConnector();
			document.ActiveLayer.AddChild(connector);
			connector.StyleSheetName = "Connectors";
			connector.FromShape = shape1;
			connector.ToShape = shape2;
		}

		#endregion
	}
}