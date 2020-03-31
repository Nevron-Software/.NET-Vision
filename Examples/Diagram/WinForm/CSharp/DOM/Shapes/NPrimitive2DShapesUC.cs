using System;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.Editors;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NPrimitive2DShapesUC.
	/// </summary>
	public class NPrimitive2DShapesUC : NDiagramExampleUC
	{
		#region Constructor

		public NPrimitive2DShapesUC(NMainForm form) : base(form)
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
			this.selectedShapeStylesGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.editStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.editFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.addRandomGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pointsCountNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.randomRectButton = new Nevron.UI.WinForm.Controls.NButton();
			this.randomEllipseButton = new Nevron.UI.WinForm.Controls.NButton();
			this.randomPolygonButton = new Nevron.UI.WinForm.Controls.NButton();
			this.randomClosedCurveButton = new Nevron.UI.WinForm.Controls.NButton();
			this.documentStylesGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.editDocumentShadowStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.editDocumentStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.editDocumentFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.selectedShapeStylesGroup.SuspendLayout();
			this.addRandomGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pointsCountNumericUpDown)).BeginInit();
			this.documentStylesGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// selectedShapeStylesGroup
			// 
			this.selectedShapeStylesGroup.Controls.Add(this.editStrokeStyleButton);
			this.selectedShapeStylesGroup.Controls.Add(this.editFillStyleButton);
			this.selectedShapeStylesGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.selectedShapeStylesGroup.Enabled = false;
			this.selectedShapeStylesGroup.ImageIndex = 0;
			this.selectedShapeStylesGroup.Location = new System.Drawing.Point(0, 176);
			this.selectedShapeStylesGroup.Name = "selectedShapeStylesGroup";
			this.selectedShapeStylesGroup.Size = new System.Drawing.Size(250, 96);
			this.selectedShapeStylesGroup.TabIndex = 34;
			this.selectedShapeStylesGroup.TabStop = false;
			this.selectedShapeStylesGroup.Text = "Selected Shape Styles";
			// 
			// editStrokeStyleButton
			// 
			this.editStrokeStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editStrokeStyleButton.Location = new System.Drawing.Point(8, 24);
			this.editStrokeStyleButton.Name = "editStrokeStyleButton";
			this.editStrokeStyleButton.Size = new System.Drawing.Size(234, 23);
			this.editStrokeStyleButton.TabIndex = 13;
			this.editStrokeStyleButton.Text = "Stroke Style ...";
			this.editStrokeStyleButton.Click += new System.EventHandler(this.editStrokeStyleButton_Click);
			// 
			// editFillStyleButton
			// 
			this.editFillStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editFillStyleButton.Location = new System.Drawing.Point(8, 56);
			this.editFillStyleButton.Name = "editFillStyleButton";
			this.editFillStyleButton.Size = new System.Drawing.Size(234, 23);
			this.editFillStyleButton.TabIndex = 12;
			this.editFillStyleButton.Text = "Fill Style ...";
			this.editFillStyleButton.Click += new System.EventHandler(this.editFillStyleButton_Click);
			// 
			// addRandomGroupBox
			// 
			this.addRandomGroupBox.Controls.Add(this.nGroupBox1);
			this.addRandomGroupBox.Controls.Add(this.label2);
			this.addRandomGroupBox.Controls.Add(this.pointsCountNumericUpDown);
			this.addRandomGroupBox.Controls.Add(this.randomRectButton);
			this.addRandomGroupBox.Controls.Add(this.randomEllipseButton);
			this.addRandomGroupBox.Controls.Add(this.randomPolygonButton);
			this.addRandomGroupBox.Controls.Add(this.randomClosedCurveButton);
			this.addRandomGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.addRandomGroupBox.ImageIndex = 0;
			this.addRandomGroupBox.Location = new System.Drawing.Point(0, 0);
			this.addRandomGroupBox.Name = "addRandomGroupBox";
			this.addRandomGroupBox.Size = new System.Drawing.Size(250, 176);
			this.addRandomGroupBox.TabIndex = 33;
			this.addRandomGroupBox.TabStop = false;
			this.addRandomGroupBox.Text = "Add Random 2D Shapes";
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 88);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(234, 8);
			this.nGroupBox1.TabIndex = 31;
			this.nGroupBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 28;
			this.label2.Text = "Points count:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pointsCountNumericUpDown
			// 
			this.pointsCountNumericUpDown.Location = new System.Drawing.Point(8, 136);
			this.pointsCountNumericUpDown.Name = "pointsCountNumericUpDown";
			this.pointsCountNumericUpDown.Size = new System.Drawing.Size(80, 22);
			this.pointsCountNumericUpDown.TabIndex = 13;
			this.pointsCountNumericUpDown.Value = new System.Decimal(new int[] {
																				   5,
																				   0,
																				   0,
																				   0});
			// 
			// randomRectButton
			// 
			this.randomRectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.randomRectButton.Location = new System.Drawing.Point(104, 24);
			this.randomRectButton.Name = "randomRectButton";
			this.randomRectButton.Size = new System.Drawing.Size(138, 23);
			this.randomRectButton.TabIndex = 12;
			this.randomRectButton.Text = "Random Rectangle";
			this.randomRectButton.Click += new System.EventHandler(this.randomRectButton_Click);
			// 
			// randomEllipseButton
			// 
			this.randomEllipseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.randomEllipseButton.Location = new System.Drawing.Point(104, 56);
			this.randomEllipseButton.Name = "randomEllipseButton";
			this.randomEllipseButton.Size = new System.Drawing.Size(138, 23);
			this.randomEllipseButton.TabIndex = 12;
			this.randomEllipseButton.Text = "Random Ellipse";
			this.randomEllipseButton.Click += new System.EventHandler(this.randomEllipseButton_Click);
			// 
			// randomPolygonButton
			// 
			this.randomPolygonButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.randomPolygonButton.Location = new System.Drawing.Point(104, 136);
			this.randomPolygonButton.Name = "randomPolygonButton";
			this.randomPolygonButton.Size = new System.Drawing.Size(138, 23);
			this.randomPolygonButton.TabIndex = 12;
			this.randomPolygonButton.Text = "Random Polygon";
			this.randomPolygonButton.Click += new System.EventHandler(this.randomPolygonButton_Click);
			// 
			// randomClosedCurveButton
			// 
			this.randomClosedCurveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.randomClosedCurveButton.Location = new System.Drawing.Point(104, 104);
			this.randomClosedCurveButton.Name = "randomClosedCurveButton";
			this.randomClosedCurveButton.Size = new System.Drawing.Size(138, 23);
			this.randomClosedCurveButton.TabIndex = 12;
			this.randomClosedCurveButton.Text = "Random Closed Curve";
			this.randomClosedCurveButton.Click += new System.EventHandler(this.randomClosedCurveButton_Click);
			// 
			// documentStylesGroupBox
			// 
			this.documentStylesGroupBox.Controls.Add(this.editDocumentShadowStyleButton);
			this.documentStylesGroupBox.Controls.Add(this.editDocumentStrokeStyleButton);
			this.documentStylesGroupBox.Controls.Add(this.editDocumentFillStyleButton);
			this.documentStylesGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.documentStylesGroupBox.ImageIndex = 0;
			this.documentStylesGroupBox.Location = new System.Drawing.Point(0, 272);
			this.documentStylesGroupBox.Name = "documentStylesGroupBox";
			this.documentStylesGroupBox.Size = new System.Drawing.Size(250, 120);
			this.documentStylesGroupBox.TabIndex = 35;
			this.documentStylesGroupBox.TabStop = false;
			this.documentStylesGroupBox.Text = "Document Styles";
			// 
			// editDocumentShadowStyleButton
			// 
			this.editDocumentShadowStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editDocumentShadowStyleButton.Location = new System.Drawing.Point(8, 88);
			this.editDocumentShadowStyleButton.Name = "editDocumentShadowStyleButton";
			this.editDocumentShadowStyleButton.Size = new System.Drawing.Size(234, 23);
			this.editDocumentShadowStyleButton.TabIndex = 3;
			this.editDocumentShadowStyleButton.Text = "Shadow Style ...";
			this.editDocumentShadowStyleButton.Click += new System.EventHandler(this.editDocumentShadowStyleButton_Click);
			// 
			// editDocumentStrokeStyleButton
			// 
			this.editDocumentStrokeStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editDocumentStrokeStyleButton.Location = new System.Drawing.Point(8, 56);
			this.editDocumentStrokeStyleButton.Name = "editDocumentStrokeStyleButton";
			this.editDocumentStrokeStyleButton.Size = new System.Drawing.Size(234, 23);
			this.editDocumentStrokeStyleButton.TabIndex = 2;
			this.editDocumentStrokeStyleButton.Text = "Stroke Style ...";
			this.editDocumentStrokeStyleButton.Click += new System.EventHandler(this.editDocumentStrokeStyleButton_Click);
			// 
			// editDocumentFillStyleButton
			// 
			this.editDocumentFillStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editDocumentFillStyleButton.Location = new System.Drawing.Point(8, 24);
			this.editDocumentFillStyleButton.Name = "editDocumentFillStyleButton";
			this.editDocumentFillStyleButton.Size = new System.Drawing.Size(234, 23);
			this.editDocumentFillStyleButton.TabIndex = 1;
			this.editDocumentFillStyleButton.Text = "Fill Style...";
			this.editDocumentFillStyleButton.Click += new System.EventHandler(this.editDocumentFillStyleButton_Click);
			// 
			// NPrimitive2DShapesUC
			// 
			this.Controls.Add(this.documentStylesGroupBox);
			this.Controls.Add(this.selectedShapeStylesGroup);
			this.Controls.Add(this.addRandomGroupBox);
			this.Name = "NPrimitive2DShapesUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.addRandomGroupBox, 0);
			this.Controls.SetChildIndex(this.selectedShapeStylesGroup, 0);
			this.Controls.SetChildIndex(this.documentStylesGroupBox, 0);
			this.selectedShapeStylesGroup.ResumeLayout(false);
			this.addRandomGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pointsCountNumericUpDown)).EndInit();
			this.documentStylesGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			// init view
			view.Grid.Visible = false;
			view.Selection.Mode = DiagramSelectionMode.Single;

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();

			// init form controls
			InitFormControls();

			// end view init
			view.EndInit();
		}

		protected override void AttachToEvents()
		{
			view.EventSinkService.NodeSelected += new NodeEventHandler(EventSinkService_NodeSelected);
			view.EventSinkService.NodeDeselected += new NodeEventHandler(EventSinkService_NodeDeselected);
			
			base.AttachToEvents();
		}

		protected override void DetachFromEvents()
		{
			view.EventSinkService.NodeSelected -= new NodeEventHandler(EventSinkService_NodeSelected);
			view.EventSinkService.NodeDeselected -= new NodeEventHandler(EventSinkService_NodeDeselected);

			base.DetachFromEvents();
		}


		#endregion

		#region Implementation
		
		private void InitFormControls()
		{
			PauseEventsHandling();

			selectedShapeStylesGroup.Enabled = false;

			ResumeEventsHandling();
		}

		private void InitDocument()
		{
			document.Style.TextStyle.FontStyle = new NFontStyle(new Font("Arial", 8));
			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur;
			document.Style.ShadowStyle.Offset = new NPointL(5, 5);
			
			CreateRect();
			CreateEllipse();
			CreatePolygon();
			CreateClosedCurve();
		}
		
		private void CreateRect()
		{
			// create rect
			NRectangleF cell = GetGridCell(0, 0);
			NRectangleShape rect = new NRectangleShape(cell);
			
			// set fill and stroke styles
			rect.Style.FillStyle = new NColorFillStyle(GetPredefinedColor(0));
			rect.Style.StrokeStyle = new NStrokeStyle(1, Color.Black);

			// add to active layer
			document.ActiveLayer.AddChild(rect); 
			
			// add description
			cell = GetGridCell(1, 0);
			NTextShape text = new NTextShape("Rectangle with color fill style and solid stroke style", cell);
			document.ActiveLayer.AddChild(text);
		}

		private void CreateEllipse()
		{
			// create ellipse
			NRectangleF cell = GetGridCell(0, 1);
			NEllipseShape ellipse = new NEllipseShape(cell);
			
			// set fill and stroke styles
			ellipse.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, GetPredefinedColor(1), Color.LightGreen);
			ellipse.Style.StrokeStyle = new NStrokeStyle(1, Color.Black, LinePattern.Dash);

			// add to active layer
			document.ActiveLayer.AddChild(ellipse); 
			
			// add description
			cell = GetGridCell(1, 1);
			NTextShape text = new NTextShape("Ellipse with gradient fill style and dash stroke style", cell);
			document.ActiveLayer.AddChild(text);
		}

		private void CreatePolygon()
		{
			// create polygon
			NRectangleF cell = GetGridCell(0, 2);
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
			polygon.Style.FillStyle = new NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, GetPredefinedColor(2), Color.Yellow);
			polygon.Style.StrokeStyle = new NStrokeStyle(1, Color.Black, LinePattern.DashDot);

			// add to active layer
			document.ActiveLayer.AddChild(polygon); 
			
			// add description
			cell = GetGridCell(1, 2);
			NTextShape text = new NTextShape("Polygon with gradient fill style and dash-dot stroke style", cell);
			document.ActiveLayer.AddChild(text);
		}

		private void CreateClosedCurve()
		{
			// create curve
			NRectangleF cell = GetGridCell(0, 3);
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
			curve.Style.FillStyle = new NHatchFillStyle(HatchStyle.SmallGrid, Color.LightSalmon, GetPredefinedColor(3));
			curve.Style.StrokeStyle = new NStrokeStyle(1, Color.Black, LinePattern.DashDotDot);

			// add to active layer
			document.ActiveLayer.AddChild(curve); 
			
			// add description
			cell = GetGridCell(1, 3);
			NTextShape text = new NTextShape("Closed curve with hatch fill style and dash-dot-dot stroke style", cell);
			document.ActiveLayer.AddChild(text);
		}


		#endregion

		#region Event Handlers

		private void randomRectButton_Click(object sender, System.EventArgs e)
		{
			// create shape
			NRectangleShape shape = null;
			try
			{
				shape = new NRectangleShape(base.GetRandomPoint(view.Viewport), base.GetRandomPoint(view.Viewport));
			}
			catch
			{
				return;
			}
			
			// add to active layer
			document.ActiveLayer.AddChild(shape);
			document.SmartRefreshAllViews(); 
		}

		private void randomEllipseButton_Click(object sender, System.EventArgs e)
		{
			// create shape
			NEllipseShape shape = null;

			try
			{
				shape = new NEllipseShape(base.GetRandomPoint(view.Viewport), base.GetRandomPoint(view.Viewport));
			}
			catch
			{
				return;
			}
			
			// add to active layer
			document.ActiveLayer.AddChild(shape);
			document.SmartRefreshAllViews();
		}

		private void randomPolygonButton_Click(object sender, System.EventArgs e)
		{
			// create shape
			NPolygonShape shape = null;
			try
			{
				shape = new NPolygonShape(base.GetRandomPoints(view.Viewport, (int)pointsCountNumericUpDown.Value));
			}
			catch
			{
				return;
			}

			// add to active layer
			document.ActiveLayer.AddChild(shape);
			document.SmartRefreshAllViews();
		}

		private void randomClosedCurveButton_Click(object sender, System.EventArgs e)
		{
			// create shape
			NClosedCurveShape shape = null;
			try
			{
				shape = new NClosedCurveShape(base.GetRandomPoints(view.Viewport, (int)pointsCountNumericUpDown.Value), 1);
			}
			catch
			{
				return;
			}

			// add to active layer
			document.ActiveLayer.AddChild(shape);
			document.SmartRefreshAllViews();
		}


		private void editFillStyleButton_Click(object sender, System.EventArgs e)
		{
			base.ShowFillStyleEditor(view.Selection.AnchorNode as NShape);
		}

		private void editStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			base.ShowFillStyleEditor(view.Selection.AnchorNode as NShape);
		}


		private void editDocumentFillStyleButton_Click(object sender, System.EventArgs e)
		{
			base.ShowFillStyleEditor(document);		
		}

		private void editDocumentStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			base.ShowStrokeStyleEditor(document);
		}

		private void editDocumentShadowStyleButton_Click(object sender, System.EventArgs e)
		{
			base.ShowShadowStyleEditor(document);
		}

		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			if (args.Node is NShape)
			{
				selectedShapeStylesGroup.Enabled = true;
			}
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			selectedShapeStylesGroup.Enabled = false;
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NGroupBox addRandomGroupBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown pointsCountNumericUpDown;
		private Nevron.UI.WinForm.Controls.NButton randomRectButton;
		private Nevron.UI.WinForm.Controls.NButton randomEllipseButton;
		private Nevron.UI.WinForm.Controls.NButton randomPolygonButton;
		private Nevron.UI.WinForm.Controls.NButton randomClosedCurveButton;
		private Nevron.UI.WinForm.Controls.NButton editFillStyleButton;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox documentStylesGroupBox;
		private Nevron.UI.WinForm.Controls.NButton editDocumentShadowStyleButton;
		private Nevron.UI.WinForm.Controls.NButton editDocumentStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NGroupBox selectedShapeStylesGroup;
		private Nevron.UI.WinForm.Controls.NButton editDocumentFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton editStrokeStyleButton;

		#endregion
	}
}