using System;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Batches;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Dom;
using Nevron.Filters;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NExpandCollapseDecoratorUC.
	/// </summary>
	public partial class NExpandCollapseDecoratorUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// begin view init
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(100, 50);
			base.DefaultGridSpacing = new NSizeF(50, 40);

			// begin view init
			NDrawingView1.ViewLayout = CanvasLayout.Fit;

			// init document
			NDrawingView1.Document.BeginInit();
			InitDocument();
			NDrawingView1.Document.EndInit();
		}

		#region Implementation

		private void InitDocument()
		{
			NDrawingDocument document = NDrawingView1.Document;

			NSimpleNetworkShapesFactory networkShapes = new NSimpleNetworkShapesFactory();
			networkShapes.DefaultSize = new NSizeF(50, 50);
			int i;

			// create computers
			for (i = 0; i < 9; i++)
			{
				NShape computer = networkShapes.CreateShape(SimpleNetworkShapes.Computer);
				switch (i % 3)
				{
					case 0:
						computer.Location = new NPointF(10, 10);
						break;
					case 1:
						computer.Location = new NPointF(110, 10);
						break;
					case 2:
						computer.Location = new NPointF(75, 110);
						break;
				}

				document.ActiveLayer.AddChild(computer);
			}

			// link the computers
			for (i = 0; i < 3; i++)
			{
				NLineShape link = new NLineShape();
				link.StyleSheetName = NDR.NameConnectorsStyleSheet;
				document.ActiveLayer.AddChild(link);

				if (i == 0)
				{
					link.FromShape = (NShape)document.ActiveLayer.GetChildAt(8);
					link.ToShape = (NShape)document.ActiveLayer.GetChildAt(0);
				}
				else
				{
					link.FromShape = (NShape)document.ActiveLayer.GetChildAt(i * 3 - 1);
					link.ToShape = (NShape)document.ActiveLayer.GetChildAt(i * 3);
				}
			}

			// create three groups
			NNodeList groupNodes1 = new NNodeList();
			NBatchGroup batchGroup1 = new NBatchGroup(document);
			groupNodes1.Add(document.ActiveLayer.GetChildAt(0));
			groupNodes1.Add(document.ActiveLayer.GetChildAt(1));
			groupNodes1.Add(document.ActiveLayer.GetChildAt(2));
			batchGroup1.Build(groupNodes1);

			NNodeList groupNodes2 = new NNodeList();
			NBatchGroup batchGroup2 = new NBatchGroup(document);
			groupNodes2.Add(document.ActiveLayer.GetChildAt(3));
			groupNodes2.Add(document.ActiveLayer.GetChildAt(4));
			groupNodes2.Add(document.ActiveLayer.GetChildAt(5));
			batchGroup2.Build(groupNodes2);

			NNodeList groupNodes3 = new NNodeList();
			NBatchGroup batchGroup3 = new NBatchGroup(document);
			groupNodes3.Add(document.ActiveLayer.GetChildAt(6));
			groupNodes3.Add(document.ActiveLayer.GetChildAt(7));
			groupNodes3.Add(document.ActiveLayer.GetChildAt(8));
			batchGroup3.Build(groupNodes3);

			NGroup[] groups = new NGroup[3];
			batchGroup1.Group(document.ActiveLayer, false, out groups[0]);
			batchGroup2.Group(document.ActiveLayer, false, out groups[1]);
			batchGroup3.Group(document.ActiveLayer, false, out groups[2]);

			// add expand-collapse decorator and frame decorator to each group
			for (i = 0; i < groups.Length; i++)
			{
				NGroup group = groups[i];

				// because groups are created after the link we want to ensure
				// that they are behind so that the links are not obscured
				group.SendToBack();

				// create the decorators collection
				group.CreateShapeElements(ShapeElementsMask.Decorators);

				// create a frame decorator
				// we want the user to be able to select the shape when the frame is hit
				NFrameDecorator frameDecorator = new NFrameDecorator();
				frameDecorator.ShapeHitTestable = true;
				frameDecorator.Header.Text = "Network " + i.ToString();
				group.Decorators.AddChild(frameDecorator);

				// create an expand collapse decorator
				NExpandCollapseDecorator expandCollapseDecorator = new NExpandCollapseDecorator();
				group.Decorators.AddChild(expandCollapseDecorator);

				// update the model bounds so that the computeres 
				// are inside the specified padding
				group.Padding = new Nevron.Diagram.NMargins(5, 5, 30, 5);
				group.UpdateModelBounds();
				group.AutoUpdateModelBounds = true;
			}

			// layout them with a table layout
			NLayoutContext context = new NLayoutContext();
			context.GraphAdapter = new NShapeGraphAdapter();
			context.BodyAdapter = new NShapeBodyAdapter(document);
			context.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);

			NTableLayout layout = new NTableLayout();
			layout.ConstrainMode = CellConstrainMode.Ordinal;
			layout.MaxOrdinal = 2;
			layout.HorizontalSpacing = 50;
			layout.VerticalSpacing = 50;
			layout.Layout(document.ActiveLayer.Children(null), context);

			document.SizeToContent(NSizeF.Empty, document.AutoBoundsPadding);
			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent;
		}

		#endregion

		#region Event Handlers

		protected void NDrawingView1_QueryAjaxTools(object sender, EventArgs e)
		{
			// Configure the client side tools
			NDrawingView1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true));
		}
		protected void NDrawingView1_AsyncClick(object sender, EventArgs e)
		{
			NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;

			NNodeList nodes = NDrawingView1.HitTest(args);
			NNodeList decorators = nodes.Filter(DecoratorFilter);
			if (decorators.Count > 0)
			{
				((NExpandCollapseDecorator)decorators[0]).ToggleState();
			}

			NDrawingView1.Document.SmartRefreshAllViews();
		}
		protected void NDrawingView1_AsyncCustomCommand(object sender, EventArgs e)
		{
			NCallbackCustomCommandArgs args = e as NCallbackCustomCommandArgs;
			NCallbackCommand command = args.Command;
			string value = command.Arguments["value"].ToString();

			NNodeList decorators = NDrawingView1.Document.ActiveLayer.Descendants(DecoratorFilter, -1);
			int i, count = decorators.Count;

			switch (command.Name)
			{
				case "background":
					ToggleDecoratorBackgroundShape background = (ToggleDecoratorBackgroundShape)Enum.Parse(typeof(ToggleDecoratorBackgroundShape), value);
					for (i = 0; i < count; i++)
					{
						((NToggleDecorator)decorators[i]).Background.Shape = background;
					}

					m_bClientSideRedrawRequired = true;
					break;

				case "symbol":
					ToggleDecoratorSymbolShape symbol = (ToggleDecoratorSymbolShape)Enum.Parse(typeof(ToggleDecoratorSymbolShape), value);
					for (i = 0; i < count; i++)
					{
						((NToggleDecorator)decorators[i]).Symbol.Shape = symbol;
					}

					m_bClientSideRedrawRequired = true;
					break;

				case "position":
					NContentAlignment alignment;
					NSizeF offset;

					if (value == "Left")
					{
						alignment = new NContentAlignment(ContentAlignment.TopLeft);
						offset = new NSizeF(11, 11);
					}
					else
					{
						alignment = new NContentAlignment(ContentAlignment.TopRight);
						offset = new NSizeF(-11, 11);
					}

					for (i = 0; i < count; i++)
					{
						NToggleDecorator decorator = (NToggleDecorator)decorators[i];
						decorator.Alignment = alignment;
						decorator.Offset = offset;
					}

					m_bClientSideRedrawRequired = true;
					break;
			}
		}
		protected void NDrawingView1_AsyncQueryCommandResult(object sender, EventArgs e)
		{
			NCallbackQueryCommandResultArgs args = e as NCallbackQueryCommandResultArgs;
			NAjaxXmlTransportBuilder resultBuilder = args.ResultBuilder;
			if (m_bClientSideRedrawRequired && !resultBuilder.ContainsRedrawDataSection())
			{
				resultBuilder.AddRedrawDataSection(NDrawingView1);
			}
		}

		#endregion

		#region Fields

		private bool m_bClientSideRedrawRequired = false;

		#endregion

		#region Constants

		private static readonly NFilter DecoratorFilter = new NInstanceOfTypeFilter(typeof(NExpandCollapseDecorator));

		#endregion
	}
}