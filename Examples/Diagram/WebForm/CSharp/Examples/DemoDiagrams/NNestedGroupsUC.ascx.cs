using System;
using System.Drawing.Drawing2D;

using Nevron.Diagram;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.Filters;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NNestedGroupsUC.
	/// </summary>
	public partial class NNestedGroupsUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (NThinDiagramControl1.Initialized == false)
			{
				// Configure the controller
				NServerMouseEventTool serverMouseEventTool = new NServerMouseEventTool();
				NThinDiagramControl1.Controller.Tools.Add(serverMouseEventTool);
				serverMouseEventTool.MouseDown = new NMouseDownEventCallback();

				// Init the document
				NDrawingDocument document = NThinDiagramControl1.Document;
				document.BeginInit();
				InitDocument(document);
				document.EndInit();
			}
		}

		#region Implementation

		private void InitDocument(NDrawingDocument document)
		{
			document.Width = 650;
			document.Height = 650;

			// Create the A group
			NGroup groupA = CreateGroup("A");
			groupA.Location = new NPointF(10, 10);
			document.ActiveLayer.AddChild(groupA);

			// Create the B group
			NGroup groupB = CreateGroup("B");
			groupB.Location = new NPointF(10, 350);
			document.ActiveLayer.AddChild(groupB);

			// Connect some shapes
			NGroup subgroupA1 = (NGroup)groupA.Shapes.GetChildAt(0);
			NShape shapeA1a = (NShape)subgroupA1.Shapes.GetChildAt(0);
			NGroup subgroupA2 = (NGroup)groupA.Shapes.GetChildAt(1);
			NShape shapeA2a = (NShape)subgroupA2.Shapes.GetChildAt(0);
			Connect(shapeA1a, shapeA2a);

			NGroup subgroupB2 = (NGroup)groupB.Shapes.GetChildAt(1);
			NShape shapeB2a = (NShape)subgroupB2.Shapes.GetChildAt(0);
			Connect(shapeA2a, shapeB2a);
		}

		private NGroup CreateGroup(string name)
		{
			NGroup group = new NGroup();
			group.Name = name;

			// Create 2 subgroups
			NGroup subGroup1 = CreateSubgroup(name + "1");
			subGroup1.Location = new NPointF(20, 0);
			group.Shapes.AddChild(subGroup1);

			NGroup subGroup2 = CreateSubgroup(name + "2");
			subGroup2.Location = new NPointF(260, 0);
			group.Shapes.AddChild(subGroup2);

			// Create the decorators
			CreateDecorators(group, group.Name + " Group");

			// Update the model bounds so that the subgroups are inside the specified padding
			group.Padding = new Nevron.Diagram.NMargins(5, 5, 30, 5);
			group.UpdateModelBounds();
			group.AutoUpdateModelBounds = true;

			return group;
		}
		private NGroup CreateSubgroup(string name)
		{
			NGroup subgroup = new NGroup();
			subgroup.Name = name;

			// Create 2 shapes
			NShape shape1 = CreateShape(name + "a");
			shape1.Location = new NPointF(0, 0);
			subgroup.Shapes.AddChild(shape1);

			NShape shape2 = CreateShape(name + "b");
			shape2.Location = new NPointF(110, 110);
			subgroup.Shapes.AddChild(shape2);

			// Create the decorators
			CreateDecorators(subgroup, subgroup.Name + " Subgroup");

			// Update the model bounds so that the shapes are inside the specified padding
			subgroup.Padding = new Nevron.Diagram.NMargins(5, 5, 30, 5);
			subgroup.UpdateModelBounds();

			return subgroup;
		}
		private NShape CreateShape(string name)
		{
			NShape shape = new NRectangleShape(0, 0, 100, 100);
			shape.Name = name;
			shape.Text = name + " Node";

			// Create a center port
			shape.CreateShapeElements(ShapeElementsMask.Ports);
			NDynamicPort port = new NDynamicPort(new NContentAlignment(0, 0), DynamicPortGlueMode.GlueToContour);
			shape.Ports.AddChild(port);

			return shape;
		}
		private void CreateDecorators(NShape shape, string decoratorText)
		{
			// Create the decorators
			shape.CreateShapeElements(ShapeElementsMask.Decorators);

			// Create a frame decorator
			// We want the user to be able to select the shape when the frame is hit
			NFrameDecorator frameDecorator = new NFrameDecorator();
			frameDecorator.ShapeHitTestable = true;
			frameDecorator.Header.Margins = new Nevron.Diagram.NMargins(20, 0, 0, 0);
			frameDecorator.Header.Text = decoratorText;
			shape.Decorators.AddChild(frameDecorator);

			// Create an expand/collapse decorator
			NExpandCollapseDecorator decorator = new NExpandCollapseDecorator();
			shape.Decorators.AddChild(decorator);
		}
		private void Connect(NShape shape1, NShape shape2)
		{
			NDrawingDocument document = (NDrawingDocument)shape1.Document;

			NLineShape line = new NLineShape();
			document.ActiveLayer.AddChild(line);
			line.StyleSheetName = "Connectors";
			line.FromShape = shape1;
			line.ToShape = shape2;
		}

		#endregion

		#region Constants

		private static readonly NFilter ExpandCollapseDecoratorFilter = new NInstanceOfTypeFilter(typeof(NExpandCollapseDecorator));

		#endregion

		#region Nested Types

		[Serializable]
		class NMouseDownEventCallback : INMouseEventCallback
		{
			#region INMouseEventCallback Members

			void INMouseEventCallback.OnMouseEvent(NAspNetThinWebControl control, NBrowserMouseEventArgs e)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NNodeList nodes = diagramControl.HitTest(new NPointF(e.X, e.Y));
				NNodeList decorators = nodes.Filter(ExpandCollapseDecoratorFilter);

				if (decorators.Count > 0)
				{
					((NExpandCollapseDecorator)decorators[0]).ToggleState();
					diagramControl.UpdateView();
				}
			}

			#endregion
		}

		#endregion
	}
}