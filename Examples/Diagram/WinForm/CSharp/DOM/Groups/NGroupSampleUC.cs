using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Templates;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.WinForm.Commands;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NGroupSampleUC.
	/// </summary>
	public class NGroupSampleUC : NDiagramExampleUC
	{
		#region Constructor

		public NGroupSampleUC(NMainForm form) : base(form)
		{
			InitializeComponent();
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// NGroupSampleUC
			// 
			this.Name = "NGroupSampleUC";
			this.Size = new System.Drawing.Size(248, 456);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			m_NodeSize = new NSizeF(25, 25);
			m_Layout = new NSpringLayout();

			// begin view init
			view.BeginInit();

			view.Grid.Visible = false;
			view.HorizontalRuler.Visible = false;
			view.VerticalRuler.Visible = false;

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();

			// end view init
			view.EndInit();
		}
		
		#endregion

		#region Implementation

		private void InitDocument()
		{
			// create networks
			NGroup network1 = CreateNetwork(new NPointF(200, 20), "Network 1");
			NGroup network2 = CreateNetwork(new NPointF(400, 250), "Network 2");
			NGroup network3 = CreateNetwork(new NPointF(20, 250), "Network 3");
			NGroup network4 = CreateNetwork(new NPointF(200, 400), "Network 4");

			// connect networks
			ConnectNetworks(network1, network2);
			ConnectNetworks(network1, network3);
			ConnectNetworks(network1, network4);
		}
		
		protected NGroup CreateNetwork(NPointF location, string labelText)
		{
			NGroup group = new NGroup();
			document.ActiveLayer.AddChild(group);
		
			// create computer1
			NCompositeShape computer1 = CreateComputer();
			computer1.Location = new NPointF(0, 0);
			group.Shapes.AddChild(computer1);
			
			// create computer2
			NCompositeShape computer2 = CreateComputer();
			computer2.Location = new NPointF(200, 0);
			group.Shapes.AddChild(computer2);

			// create computer3
			NCompositeShape computer3 = CreateComputer();
			computer3.Location = new NPointF(100, 180);
			group.Shapes.AddChild(computer3);

			// connect the computers in the network
			ConnectComputers(computer1, computer2, group);
			ConnectComputers(computer2, computer3, group);
			ConnectComputers(computer3, computer1, group);

			// update the group model bounds
			group.UpdateModelBounds(); 

			// insert a frame
			NRectangleShape frame = new NRectangleShape(group.ModelBounds);
			frame.Protection = new NAbilities(AbilitiesMask.Select | AbilitiesMask.InplaceEdit);
			group.Shapes.InsertChild(0, frame);

			// change group fill style
			group.Style.FillStyle = new NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant2, Color.Gainsboro, Color.White);

			// reposition and resize the group
			group.Location = location;
			group.Width = 155;
			group.Height = 155;

			// add a dynamic port to the group
			group.CreateShapeElements(ShapeElementsMask.Ports);
			
			NDynamicPort port = new NDynamicPort(group.UniqueId, ContentAlignment.MiddleCenter, DynamicPortGlueMode.GlueToContour);
			group.Ports.AddChild(port);
			group.Ports.DefaultInwardPortUniqueId = port.UniqueId;

			// modify the margins and text of the default label
			group.CreateShapeElements(ShapeElementsMask.Labels);

			NRotatedBoundsLabel label = new NRotatedBoundsLabel(labelText, group.UniqueId, new Nevron.Diagram.NMargins(0, 0, -10, 100));
			group.Labels.AddChild(label);
			group.Labels.DefaultLabelUniqueId = label.UniqueId;

			return group;
		}

		protected NCompositeShape CreateComputer()
		{
			NCompositeShape computer = new NCompositeShape();
			
			// create the frame
			NEllipsePath frame = new NEllipsePath(-28, -28, 140, 140);
			NStyle.SetFillStyle(frame, new NColorFillStyle(Color.WhiteSmoke));
			computer.Primitives.AddChild(frame);
			
			// create display 1
			computer.Primitives.AddChild(new NRectanglePath(0, 0, 57, 47));	

			// create display 2
			computer.Primitives.AddChild(new NRectanglePath(6, 4, 47, 39));	
			
			// create the keyboard
			computer.Primitives.AddChild(new NRectanglePath(-21, 53, 60, 14));	

			// create the tower case
            computer.Primitives.AddChild(new NRectanglePath(65, 0, 32, 66));	

			// create floppy 1
			computer.Primitives.AddChild(new NRectanglePath(70, 5, 20, 3.75f));

			// create floppy 2
			computer.Primitives.AddChild(new NRectanglePath(70, 15, 20, 3.75f));

			// create floppy 3
			computer.Primitives.AddChild(new NRectanglePath(70, 25, 20, 3.75f));
			
			// create the mouse tail
			computer.Primitives.AddChild(new NBezierCurvePath(new NPointF(38, 82), new NPointF(61, 74), new NPointF(27, 57), new NPointF(63, 54)));

			// create the mouse
			NEllipsePath mouse = new NEllipsePath(26, 79, 11, 19);
			mouse.Rotate(CoordinateSystem.Scene, 42, new NPointF(36.5f, 88.5f));
			computer.Primitives.AddChild(mouse);

			// update the model bounds to fit the primitives
			computer.UpdateModelBounds();

			// the default fill style is dold
			computer.Style.FillStyle = new NColorFillStyle(Color.Gold);

			// create the computer ports
			computer.CreateShapeElements(ShapeElementsMask.Ports);

			// create a dynamic port anchored to the center of the frame
			NDynamicPort port = new NDynamicPort(frame.UniqueId, ContentAlignment.MiddleCenter, DynamicPortGlueMode.GlueToContour);
			port.Name = "port";

			// make the new port the one and default port of the computer
			computer.Ports.RemoveAllChildren();
			computer.Ports.AddChild(port);
			computer.Ports.DefaultInwardPortUniqueId = port.UniqueId;
			
			return computer;
		}


		private void ConnectNetworks(NGroup fromNetwork, NGroup toNetwork)
		{
			NLineShape line = new NLineShape();
			document.ActiveLayer.AddChild(line);

			line.FromShape = fromNetwork;
			line.ToShape = toNetwork;
		}

		private void ConnectComputers(NShape fromComputer, NShape toComputer, NGroup group)
		{
			NLineShape line = new NLineShape();
			group.Shapes.AddChild(line);

			line.FromShape = fromComputer;
			line.ToShape = toComputer;
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;

		#endregion

		#region Fields
		
		private NSizeF m_NodeSize;
		private NForceDirectedLayout m_Layout;

		#endregion
	}
}
