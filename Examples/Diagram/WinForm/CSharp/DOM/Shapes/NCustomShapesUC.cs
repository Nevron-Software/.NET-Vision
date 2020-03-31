using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NSymbolsUC.
	/// </summary>
	public class NCustomShapesUC : NDiagramExampleUC
	{
		#region Constructor

		public NCustomShapesUC(NMainForm form) : base(form)
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
			this.addRandomGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.addShapeButton = new Nevron.UI.WinForm.Controls.NButton();
			this.addRandomGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// commonControlsPanel
			// 
			this.commonControlsPanel.Name = "commonControlsPanel";
			this.commonControlsPanel.Size = new System.Drawing.Size(250, 80);
			// 
			// addRandomGroupBox
			// 
			this.addRandomGroupBox.Controls.Add(this.addShapeButton);
			this.addRandomGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.addRandomGroupBox.ImageIndex = 0;
			this.addRandomGroupBox.Location = new System.Drawing.Point(0, 0);
			this.addRandomGroupBox.Name = "addRandomGroupBox";
			this.addRandomGroupBox.Size = new System.Drawing.Size(250, 64);
			this.addRandomGroupBox.TabIndex = 31;
			this.addRandomGroupBox.TabStop = false;
			this.addRandomGroupBox.Text = "Add custom shapes";
			// 
			// addShapeButton
			// 
			this.addShapeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.addShapeButton.Location = new System.Drawing.Point(16, 24);
			this.addShapeButton.Name = "addShapeButton";
			this.addShapeButton.Size = new System.Drawing.Size(224, 24);
			this.addShapeButton.TabIndex = 20;
			this.addShapeButton.Text = "Add Coffee Cup";
			this.addShapeButton.Click += new System.EventHandler(this.addShapeButton_Click);
			// 
			// NCustomShapesUC
			// 
			this.Controls.Add(this.addRandomGroupBox);
			this.Name = "NCustomShapesUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.commonControlsPanel, 0);
			this.Controls.SetChildIndex(this.addRandomGroupBox, 0);
			this.addRandomGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();
			view.Grid.Visible = false;

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
			document.Style.ShadowStyle = new NShadowStyle(
				ShadowType.GaussianBlur, 
				Color.BurlyWood, 
				new NPointL(4, 4), 1, 
				new NLength(2));

			document.ShadowsZOrder = ShadowsZOrder.BehindLayer;

			NCompositeShape coffeeCup1 = CreateCoffeeCupShape(new NPointF(10, 10), 0.5f);
			NCompositeShape coffeeCup2 = CreateCoffeeCupShape(new NPointF(200, 10), 0.75f);
			NCompositeShape coffeeCup3 = CreateCoffeeCupShape(new NPointF(400, 10), 1f);

			document.ActiveLayer.AddChild(coffeeCup1);
			document.ActiveLayer.AddChild(coffeeCup2);
			document.ActiveLayer.AddChild(coffeeCup3);

			ConnectCoffeeCups(coffeeCup1.Ports.GetChildAt(1) as NPort, coffeeCup2.Ports.GetChildAt(0) as NPort);
			ConnectCoffeeCups(coffeeCup2.Ports.GetChildAt(1) as NPort, coffeeCup3.Ports.GetChildAt(0) as NPort);
		}

		protected NCompositeShape CreateCoffeeCupShape(NPointF location, float scale)
		{
			NCompositeShape shape = new NCompositeShape();

			// create the cup as a polygon path
			NPolygonPath cup = new NPolygonPath(new NPointF[]{	new NPointF(45, 268),
																new NPointF(63, 331),
																new NPointF(121, 331),
																new NPointF(140, 268)});
			shape.Primitives.AddChild(cup);

			// create the cup hangle as a closed curve path
			NClosedCurvePath handle = new NClosedCurvePath(new NPointF[]{	new NPointF(175, 295),
																			new NPointF(171, 278),
																			new NPointF(140, 283),
																			new NPointF(170, 290),
																			new NPointF(128, 323)}, 1);
			NStyle.SetFillStyle(handle, new NColorFillStyle(Color.LightSalmon));
			shape.Primitives.AddChild(handle);

			// create the steam as a custom filled path
			GraphicsPath path = new GraphicsPath();
			path.AddBeziers(new PointF[]{	new PointF(92, 258),
											new PointF(53, 163),
											new PointF(145, 160),
											new PointF(86, 50),
											new PointF(138, 194),
											new PointF(45, 145),
											new PointF(92, 258)});
			path.CloseAllFigures();

			NCustomPath steam = new NCustomPath(path, PathType.ClosedFigure);
			NStyle.SetFillStyle(steam, new NColorFillStyle(Color.FromArgb(50, 122, 122, 122)));
			shape.Primitives.AddChild(steam);
		
			// update the shape model bounds to fit the primitives it contains
			shape.UpdateModelBounds();

			// create the shape ports
			shape.CreateShapeElements(ShapeElementsMask.Ports); 

			// create dynamic port anchored to the cup center
			NDynamicPort dynamicPort = new NDynamicPort(cup.UniqueId, ContentAlignment.MiddleCenter, DynamicPortGlueMode.GlueToContour);
			shape.Ports.AddChild(dynamicPort);

			// create rotated bounds port anchored to the middle right side of the handle
			NRotatedBoundsPort rotatedBoundsPort = new NRotatedBoundsPort(handle.UniqueId, ContentAlignment.MiddleRight);
			shape.Ports.AddChild(rotatedBoundsPort);

			// apply style to the shape
			shape.Style.FillStyle = new NColorFillStyle(Color.LightCoral);
			
			// position it and scale the shape
			shape.Location = location;
			shape.Width = shape.Width * scale;
			shape.Height = shape.Height * scale;

			return shape;
		}

		private void ConnectCoffeeCups(NPort port1, NPort port2)
		{
			NLineShape line = new NLineShape();
			document.ActiveLayer.AddChild(line);
			
			line.StartPlug.Connect(port1);
			line.EndPlug.Connect(port2);
		}


		#endregion

		#region Event Handlers

		private void addShapeButton_Click(object sender, System.EventArgs e)
		{
			// create a coffee cup with random location and scale
			NCompositeShape coffeeCup = CreateCoffeeCupShape(base.GetRandomPoint(view.Viewport), (float)Random.NextDouble() + 0.1f);
		
			// add to active layer and smart refresh all views
			document.ActiveLayer.AddChild(coffeeCup);
			document.SmartRefreshAllViews();
		}

		#endregion

		#region Designer Fields

		private Nevron.UI.WinForm.Controls.NGroupBox addRandomGroupBox;
		private Nevron.UI.WinForm.Controls.NButton addShapeButton;
		
		private System.ComponentModel.Container components = null;

		#endregion
	}
}
