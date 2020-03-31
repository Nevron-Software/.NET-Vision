using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

using Nevron.Diagram;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Dom;
using Nevron.Filters;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NMindMapDiagramUC.
	/// </summary>
	public partial class NMindMapDiagramUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// begin view init
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(100, 50);
			base.DefaultGridSpacing = new NSizeF(50, 40);

			// begin view init
			NDrawingView1.ViewLayout = CanvasLayout.Normal;
			NDrawingView1.ScaleX = 0.75f;
			NDrawingView1.ScaleY = 0.75f;

			// init document
			NDrawingView1.Document.BeginInit();
			InitDocument();
			NDrawingView1.Document.EndInit();
		}

		#region Implementation

		private void InitDocument()
		{
			NDrawingDocument document = NDrawingView1.Document;

			document.GraphicsSettings.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			document.GraphicsSettings.SmoothingMode = SmoothingMode.HighQuality;
			document.GraphicsSettings.PixelOffsetMode = PixelOffsetMode.HighQuality;

			// set up visual formatting
			document.Style.FillStyle = new NColorFillStyle(Color.Linen);
			document.BackgroundStyle.FrameStyle.Visible = false;

			// Create the shapes
			NGroup startElement = CreateStartElement("Alcohol Induced Persisting Dementia");
			NGroup element1 = CreateElement("Prevalence: 7% with ETOH Dependence");
			NGroup element2 = CreateElement("Presentation");
			NGroup element3 = CreateElement("Physical Etiology");

			NGroup element21 = CreateElement("Less likely to demonstrate aphasia");
			NGroup element22 = CreateElement("Visuospatial Deficits");
			NGroup element23 = CreateElement("Executive Dysfunction");
			NGroup element24 = CreateElement("Memory impairment");
			NGroup element25 = CreateElement("Similar to Dementia due to GMC");

			NGroup element31 = CreateElement("liver cirrhosis");
			NGroup element32 = CreateElement("Wernicke's Encephalopathy");
			NGroup element33 = CreateElement("Trauma (head trauma)");
			NGroup element34 = CreateElement("vitamin deficiency (Thiamine)");
			NGroup element35 = CreateElement("malnutrition");
			NGroup element36 = CreateElement("Frontal lobe atrophy");

			// Connect the shapes
			ConnectElements(startElement, element1);
			ConnectElements(startElement, element2);
			ConnectElements(startElement, element3);

			ConnectElements(element2, element21);
			ConnectElements(element2, element22);
			ConnectElements(element2, element23);
			ConnectElements(element2, element24);
			ConnectElements(element2, element25);
			AddShowHideSubtree(element2);

			ConnectElements(element3, element31);
			ConnectElements(element3, element32);
			ConnectElements(element3, element33);
			ConnectElements(element3, element34);
			ConnectElements(element3, element35);
			ConnectElements(element3, element36);
			AddShowHideSubtree(element3);

			// Layout the shapes
			DoLayout();
		}

		private void SetProtections(NGroup group)
		{
			// Set the protections of the group
			NAbilities protection = group.Protection;
			protection.Ungroup = true;
			group.Protection = protection;

			// Get all shapes in the group
			NNodeList shapes = group.Shapes.Children(null);

			// Set the protections of the shapes
			for (int i = 0, count = shapes.Count; i < count; i++)
			{
				NShape shape = (NShape)shapes[i];
				protection = shape.Protection;
				protection.Select = true;
				protection.InplaceEdit = true;
				shape.Protection = protection;
			}
		}
		private void CreatePorts(NGroup group, NShape anchorShape)
		{
			group.CreateShapeElements(ShapeElementsMask.Ports);
			NDynamicPort leftPort = new NDynamicPort(new NContentAlignment(ContentAlignment.MiddleLeft),
				DynamicPortGlueMode.GlueToLocation);
			leftPort.AnchorUniqueId = anchorShape.UniqueId;
			leftPort.Name = "LeftPort";
			group.Ports.AddChild(leftPort);

			group.CreateShapeElements(ShapeElementsMask.Ports);
			NDynamicPort rightPort = new NDynamicPort(new NContentAlignment(ContentAlignment.MiddleRight),
				DynamicPortGlueMode.GlueToLocation);
			rightPort.AnchorUniqueId = anchorShape.UniqueId;
			rightPort.Name = "RightPort";
			group.Ports.AddChild(rightPort);
		}

		private NGroup CreateStartElement(string text)
		{
			NGroup group = new NGroup();
			NDrawingView1.Document.ActiveLayer.AddChild(group);

			// Create the ellipse shape
			NShape ellipseShape = new NEllipseShape(0, 0, 1, 1);
			group.Shapes.AddChild(ellipseShape);
			ellipseShape.Text = text;
			ellipseShape.SizeToText(new NMarginsF(100, 18, 10, 18));
			ellipseShape.Location = new NPointF(0, 0);

			// Create the check shape
			NBrainstormingShapesFactory brainstormingFactory = new NBrainstormingShapesFactory(NDrawingView1.Document);
			NShape checkShape = brainstormingFactory.CreateShape(BrainstormingShapes.Check);
			checkShape.Bounds = new NRectangleF(26, 12, 24, 23);
			group.Shapes.AddChild(checkShape);

			// Create the ports
			CreatePorts(group, ellipseShape);

			// Set the protections
			SetProtections(group);
			group.UpdateModelBounds();

			return group;
		}
		private NGroup CreateElement(string text)
		{
			NGroup group = new NGroup();
			NDrawingView1.Document.ActiveLayer.AddChild(group);

			// Create the text shape
			NTextShape textShape = new NTextShape(text, 0, 0, 1, 1);
			group.Shapes.AddChild(textShape);
			textShape.SizeToText(new NMarginsF(10, 2, 10, 2));

			// Create the line shape under the text
			NRectangleF rect = textShape.Bounds;
			NLineShape lineShape = new NLineShape(rect.X, rect.Bottom, rect.Right, rect.Bottom);
			group.Shapes.AddChild(lineShape);

			// Create the ports
			CreatePorts(group, lineShape);

			// Set the protections
			SetProtections(group);
			group.UpdateModelBounds();

			return group;
		}
		private void AddShowHideSubtree(NGroup group)
		{
			group.CreateShapeElements(ShapeElementsMask.Decorators);
			NShowHideSubtreeDecorator decorator = new NShowHideSubtreeDecorator();
			decorator.Offset = new NSizeF(group.Width - decorator.Size.Width / 2, -group.Height / 2);
			decorator.Background.Shape = ToggleDecoratorBackgroundShape.Ellipse;
			group.Decorators.AddChild(decorator);
		}

		private NRoutableConnector ConnectElements(NGroup from, NGroup to)
		{
			NRoutableConnector line = new NRoutableConnector();
			NDrawingView1.Document.ActiveLayer.AddChild(line);

			NPort fromPort = (NPort)from.Ports.GetChildByName("RightPort");
			NPort toPort = (NPort)to.Ports.GetChildByName("LeftPort");

			line.StartPlug.Connect(fromPort);
			line.EndPlug.Connect(toPort);

			return line;
		}
		private void DoLayout()
		{
			NDrawingDocument document = NDrawingView1.Document;

			NLayoutContext context = new NLayoutContext();
			context.GraphAdapter = new NShapeGraphAdapter(true);
			context.BodyAdapter = new NShapeBodyAdapter(document);
			context.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);

			NLayeredGraphLayout layout = new NLayeredGraphLayout();
			layout.Direction = LayoutDirection.LeftToRight;
			layout.EdgeRouting = LayeredLayoutEdgeRouting.Polyline;
			layout.PlugSpacing.Mode = PlugSpacingMode.None;

			NNodeList shapesToLayout = document.ActiveLayer.Children(NFilters.Shape2D);
			layout.Layout(shapesToLayout, context);

			// size to visible shapes
			document.SizeToContent(document.AutoBoundsMinSize, document.AutoBoundsPadding, NFilters.Visible);
		}

		#endregion

		#region Event Handlers

		protected void NDrawingView1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			NDrawingView1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true));
		}
		protected void NDrawingView1_AsyncClick(object sender, EventArgs e)
		{
			NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;

			NNodeList nodes = NDrawingView1.HitTest(args);
			NNodeList decorators = nodes.Filter(DECORATOR_FILTER);
			if (decorators.Count > 0)
			{
				((NShowHideSubtreeDecorator)decorators[0]).ToggleState();
				DoLayout();
			}
		}

		#endregion

		#region Static

		private static readonly NFilter GROUP_FILTER = new NInstanceOfTypeFilter(typeof(NGroup));
		private static readonly NFilter DECORATOR_FILTER = new NInstanceOfTypeFilter(typeof(NShowHideSubtreeDecorator));

		#endregion
	}
}