using System;
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
	/// Summary description for NPrimitive1DShapesUC.
	/// </summary>
	public class NPrimitive1DShapesUC : NDiagramExampleUC
	{
		#region Constructor

		public NPrimitive1DShapesUC(NMainForm form) : base(form)
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
			this.randomEllipticalArcButton = new Nevron.UI.WinForm.Controls.NButton();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pointsCountNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.randomLineButton = new Nevron.UI.WinForm.Controls.NButton();
			this.randomCircularArcButton = new Nevron.UI.WinForm.Controls.NButton();
			this.randomPolylineButton = new Nevron.UI.WinForm.Controls.NButton();
			this.randomBezierButton = new Nevron.UI.WinForm.Controls.NButton();
			this.randomCurveButton = new Nevron.UI.WinForm.Controls.NButton();
			this.selectedShapeStyleGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.editStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.editStartArrowheadButton = new Nevron.UI.WinForm.Controls.NButton();
			this.editEndArrowheadButton = new Nevron.UI.WinForm.Controls.NButton();
			this.documentStylesGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.editDocumentShadowStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.editDocumentStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.editDocumentStartArrowheadStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.editDocumentEndArrowheadStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.addRandomGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pointsCountNumericUpDown)).BeginInit();
			this.selectedShapeStyleGroup.SuspendLayout();
			this.documentStylesGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// addRandomGroupBox
			// 
			this.addRandomGroupBox.Controls.Add(this.randomEllipticalArcButton);
			this.addRandomGroupBox.Controls.Add(this.nGroupBox1);
			this.addRandomGroupBox.Controls.Add(this.label2);
			this.addRandomGroupBox.Controls.Add(this.pointsCountNumericUpDown);
			this.addRandomGroupBox.Controls.Add(this.randomLineButton);
			this.addRandomGroupBox.Controls.Add(this.randomCircularArcButton);
			this.addRandomGroupBox.Controls.Add(this.randomPolylineButton);
			this.addRandomGroupBox.Controls.Add(this.randomBezierButton);
			this.addRandomGroupBox.Controls.Add(this.randomCurveButton);
			this.addRandomGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.addRandomGroupBox.ImageIndex = 0;
			this.addRandomGroupBox.Location = new System.Drawing.Point(0, 0);
			this.addRandomGroupBox.Name = "addRandomGroupBox";
			this.addRandomGroupBox.Size = new System.Drawing.Size(250, 240);
			this.addRandomGroupBox.TabIndex = 0;
			this.addRandomGroupBox.TabStop = false;
			this.addRandomGroupBox.Text = "Add Random Strokes";
			// 
			// randomEllipticalArcButton
			// 
			this.randomEllipticalArcButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.randomEllipticalArcButton.Location = new System.Drawing.Point(104, 88);
			this.randomEllipticalArcButton.Name = "randomEllipticalArcButton";
			this.randomEllipticalArcButton.Size = new System.Drawing.Size(138, 23);
			this.randomEllipticalArcButton.TabIndex = 2;
			this.randomEllipticalArcButton.Text = "Random Elliptical Arc";
			this.randomEllipticalArcButton.Click += new System.EventHandler(this.randomEllipticalArcButton_Click);
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(8, 152);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(232, 8);
			this.nGroupBox1.TabIndex = 4;
			this.nGroupBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 168);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Points count:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pointsCountNumericUpDown
			// 
			this.pointsCountNumericUpDown.Location = new System.Drawing.Point(8, 200);
			this.pointsCountNumericUpDown.Name = "pointsCountNumericUpDown";
			this.pointsCountNumericUpDown.Size = new System.Drawing.Size(80, 22);
			this.pointsCountNumericUpDown.TabIndex = 6;
			this.pointsCountNumericUpDown.Value = new System.Decimal(new int[] {
																				   5,
																				   0,
																				   0,
																				   0});
			// 
			// randomLineButton
			// 
			this.randomLineButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.randomLineButton.Location = new System.Drawing.Point(104, 24);
			this.randomLineButton.Name = "randomLineButton";
			this.randomLineButton.Size = new System.Drawing.Size(138, 23);
			this.randomLineButton.TabIndex = 0;
			this.randomLineButton.Text = "Random Line";
			this.randomLineButton.Click += new System.EventHandler(this.randomLineButton_Click);
			// 
			// randomCircularArcButton
			// 
			this.randomCircularArcButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.randomCircularArcButton.Location = new System.Drawing.Point(104, 56);
			this.randomCircularArcButton.Name = "randomCircularArcButton";
			this.randomCircularArcButton.Size = new System.Drawing.Size(138, 23);
			this.randomCircularArcButton.TabIndex = 1;
			this.randomCircularArcButton.Text = "Random Circular Arc";
			this.randomCircularArcButton.Click += new System.EventHandler(this.randomCircularArcButton_Click);
			// 
			// randomPolylineButton
			// 
			this.randomPolylineButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.randomPolylineButton.Location = new System.Drawing.Point(104, 168);
			this.randomPolylineButton.Name = "randomPolylineButton";
			this.randomPolylineButton.Size = new System.Drawing.Size(138, 23);
			this.randomPolylineButton.TabIndex = 7;
			this.randomPolylineButton.Text = "Random Polyline";
			this.randomPolylineButton.Click += new System.EventHandler(this.randomPolylineButton_Click);
			// 
			// randomBezierButton
			// 
			this.randomBezierButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.randomBezierButton.Location = new System.Drawing.Point(104, 120);
			this.randomBezierButton.Name = "randomBezierButton";
			this.randomBezierButton.Size = new System.Drawing.Size(138, 23);
			this.randomBezierButton.TabIndex = 3;
			this.randomBezierButton.Text = "Random Bezier";
			this.randomBezierButton.Click += new System.EventHandler(this.randomBezierButton_Click);
			// 
			// randomCurveButton
			// 
			this.randomCurveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.randomCurveButton.Location = new System.Drawing.Point(104, 200);
			this.randomCurveButton.Name = "randomCurveButton";
			this.randomCurveButton.Size = new System.Drawing.Size(138, 23);
			this.randomCurveButton.TabIndex = 8;
			this.randomCurveButton.Text = "Random Curve";
			this.randomCurveButton.Click += new System.EventHandler(this.randomCurveButton_Click);
			// 
			// selectedShapeStyleGroup
			// 
			this.selectedShapeStyleGroup.Controls.Add(this.editStrokeStyleButton);
			this.selectedShapeStyleGroup.Controls.Add(this.editStartArrowheadButton);
			this.selectedShapeStyleGroup.Controls.Add(this.editEndArrowheadButton);
			this.selectedShapeStyleGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.selectedShapeStyleGroup.Enabled = false;
			this.selectedShapeStyleGroup.ImageIndex = 0;
			this.selectedShapeStyleGroup.Location = new System.Drawing.Point(0, 240);
			this.selectedShapeStyleGroup.Name = "selectedShapeStyleGroup";
			this.selectedShapeStyleGroup.Size = new System.Drawing.Size(250, 128);
			this.selectedShapeStyleGroup.TabIndex = 1;
			this.selectedShapeStyleGroup.TabStop = false;
			this.selectedShapeStyleGroup.Text = "Selected Shape Styles";
			// 
			// editStrokeStyleButton
			// 
			this.editStrokeStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editStrokeStyleButton.Location = new System.Drawing.Point(8, 88);
			this.editStrokeStyleButton.Name = "editStrokeStyleButton";
			this.editStrokeStyleButton.Size = new System.Drawing.Size(234, 23);
			this.editStrokeStyleButton.TabIndex = 2;
			this.editStrokeStyleButton.Text = "Stroke Style ...";
			this.editStrokeStyleButton.Click += new System.EventHandler(this.editStrokeStyleButton_Click);
			// 
			// editStartArrowheadButton
			// 
			this.editStartArrowheadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editStartArrowheadButton.Location = new System.Drawing.Point(8, 24);
			this.editStartArrowheadButton.Name = "editStartArrowheadButton";
			this.editStartArrowheadButton.Size = new System.Drawing.Size(234, 23);
			this.editStartArrowheadButton.TabIndex = 0;
			this.editStartArrowheadButton.Text = "Start Arrowhead Style...";
			this.editStartArrowheadButton.Click += new System.EventHandler(this.editStartArrowheadButton_Click);
			// 
			// editEndArrowheadButton
			// 
			this.editEndArrowheadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editEndArrowheadButton.Location = new System.Drawing.Point(8, 56);
			this.editEndArrowheadButton.Name = "editEndArrowheadButton";
			this.editEndArrowheadButton.Size = new System.Drawing.Size(234, 23);
			this.editEndArrowheadButton.TabIndex = 1;
			this.editEndArrowheadButton.Text = "End Arrowhead Style...";
			this.editEndArrowheadButton.Click += new System.EventHandler(this.editEndArrowheadButton_Click);
			// 
			// documentStylesGroupBox
			// 
			this.documentStylesGroupBox.Controls.Add(this.editDocumentShadowStyleButton);
			this.documentStylesGroupBox.Controls.Add(this.editDocumentStrokeStyleButton);
			this.documentStylesGroupBox.Controls.Add(this.editDocumentStartArrowheadStyleButton);
			this.documentStylesGroupBox.Controls.Add(this.editDocumentEndArrowheadStyleButton);
			this.documentStylesGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.documentStylesGroupBox.ImageIndex = 0;
			this.documentStylesGroupBox.Location = new System.Drawing.Point(0, 368);
			this.documentStylesGroupBox.Name = "documentStylesGroupBox";
			this.documentStylesGroupBox.Size = new System.Drawing.Size(250, 144);
			this.documentStylesGroupBox.TabIndex = 2;
			this.documentStylesGroupBox.TabStop = false;
			this.documentStylesGroupBox.Text = "Document Styles";
			// 
			// editDocumentShadowStyleButton
			// 
			this.editDocumentShadowStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editDocumentShadowStyleButton.Location = new System.Drawing.Point(8, 111);
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
			this.editDocumentStrokeStyleButton.Location = new System.Drawing.Point(8, 81);
			this.editDocumentStrokeStyleButton.Name = "editDocumentStrokeStyleButton";
			this.editDocumentStrokeStyleButton.Size = new System.Drawing.Size(234, 23);
			this.editDocumentStrokeStyleButton.TabIndex = 2;
			this.editDocumentStrokeStyleButton.Text = "Stroke Style ...";
			this.editDocumentStrokeStyleButton.Click += new System.EventHandler(this.editDocumentStrokeStyleButton_Click);
			// 
			// editDocumentStartArrowheadStyleButton
			// 
			this.editDocumentStartArrowheadStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editDocumentStartArrowheadStyleButton.Location = new System.Drawing.Point(8, 21);
			this.editDocumentStartArrowheadStyleButton.Name = "editDocumentStartArrowheadStyleButton";
			this.editDocumentStartArrowheadStyleButton.Size = new System.Drawing.Size(234, 23);
			this.editDocumentStartArrowheadStyleButton.TabIndex = 0;
			this.editDocumentStartArrowheadStyleButton.Text = "Start Arrowhead Style...";
			this.editDocumentStartArrowheadStyleButton.Click += new System.EventHandler(this.editDocumentStartArrowheadStyleButton_Click);
			// 
			// editDocumentEndArrowheadStyleButton
			// 
			this.editDocumentEndArrowheadStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editDocumentEndArrowheadStyleButton.Location = new System.Drawing.Point(8, 51);
			this.editDocumentEndArrowheadStyleButton.Name = "editDocumentEndArrowheadStyleButton";
			this.editDocumentEndArrowheadStyleButton.Size = new System.Drawing.Size(234, 23);
			this.editDocumentEndArrowheadStyleButton.TabIndex = 1;
			this.editDocumentEndArrowheadStyleButton.Text = "End Arrowhead Style...";
			this.editDocumentEndArrowheadStyleButton.Click += new System.EventHandler(this.editDocumentEndArrowheadStyleButton_Click);
			// 
			// NPrimitive1DShapesUC
			// 
			this.Controls.Add(this.documentStylesGroupBox);
			this.Controls.Add(this.selectedShapeStyleGroup);
			this.Controls.Add(this.addRandomGroupBox);
			this.Name = "NPrimitive1DShapesUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.addRandomGroupBox, 0);
			this.Controls.SetChildIndex(this.selectedShapeStyleGroup, 0);
			this.Controls.SetChildIndex(this.documentStylesGroupBox, 0);
			this.addRandomGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pointsCountNumericUpDown)).EndInit();
			this.selectedShapeStyleGroup.ResumeLayout(false);
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
			view.Selection.Mode = DiagramSelectionMode.Single;
			view.Grid.Visible = false;

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

			selectedShapeStyleGroup.Enabled = false;

			ResumeEventsHandling();
		}
		
		private void InitDocument()
		{
			// by default display everything with shadow
			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur;
			document.Style.ShadowStyle.Offset = new NPointL(5, 5);

			// by default do not display arrowheads
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None;
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None;
			document.Style.StrokeStyle.Color = Color.DarkCyan;

			document.Style.TextStyle.FontStyle = new NFontStyle(new Font("Arial", 8));

			CreateLineShape(0, 0);
			CreateCircularArcShape(0, 1);
			CreateEllipticalArcShape(0, 2);
			CreatePolylineShape(2, 0);
			CreateBezierShape(2, 1);
			CreateCurveShape(2, 2);
		}

		
		private void CreateLineShape(int row, int col)
		{
			// create line
			NRectangleF cell = GetGridCell(row, col);
			Color color = GetPredefinedColor(0);

			NLineShape line = new NLineShape(cell.X, cell.Y, cell.Right, cell.Bottom);
			
			// set stroke style
			line.Style.StrokeStyle = new NStrokeStyle(1, color, LinePattern.Dash);

			// set arrowheads style
			NArrowheadStyle arrowheadStyle = new NArrowheadStyle(
				ArrowheadShape.Circle, 
				"",
				new NSizeL(12, 12), 
				new NColorFillStyle(color),
				new NStrokeStyle(1, Color.Black));

			line.Style.StartArrowheadStyle = arrowheadStyle;

			arrowheadStyle = new NArrowheadStyle(
				ArrowheadShape.Arrow, 
				"", 
				new NSizeL(12, 12), 
				new NColorFillStyle(color),
				new NStrokeStyle(1, Color.Black));

			line.Style.EndArrowheadStyle = arrowheadStyle;

			// add to the active layer
			document.ActiveLayer.AddChild(line); 
			
			// add description
			cell = GetGridCell(row + 1, col);
			NTextShape text = new NTextShape("Line with dash style and Circle and Arrow arrowheads", cell);
			document.ActiveLayer.AddChild(text);
		}

		private void CreateCircularArcShape(int row, int col)
		{
			NRectangleF cell = GetGridCell(row, col);
			Color color = GetPredefinedColor(1);

			// create circular arc
			NCircularArcShape arc = new NCircularArcShape(new NPointF(cell.X, cell.Y), new NPointF(cell.Right, cell.Y), new NPointF(cell.Right, cell.Bottom));
			
			// set stroke style
			arc.Style.StrokeStyle = new NStrokeStyle(2, color, LinePattern.Dot);

			// set arrowheads style
			NArrowheadStyle arrowheadStyle = new NArrowheadStyle(
				ArrowheadShape.ClosedFork, 
				"", 
				new NSizeL(12, 12), 
				new NColorFillStyle(color),
				new NStrokeStyle(1, Color.Black));
			arc.Style.StartArrowheadStyle = arrowheadStyle;

			arrowheadStyle = new NArrowheadStyle(
				ArrowheadShape.DoubleArrow, 
				"", 
				new NSizeL(12, 12), 
				new NColorFillStyle(color),
				new NStrokeStyle(1, Color.Black));
			arc.Style.EndArrowheadStyle = arrowheadStyle;

			// add to the active layer
			document.ActiveLayer.AddChild(arc); 
			
			// add description
			cell = GetGridCell(row + 1, col);
			NTextShape text = new NTextShape("Circular arc with dots style and ClosedFork and DoubleArrow arrowheads", cell);
			document.ActiveLayer.AddChild(text);
		}

		private void CreateEllipticalArcShape(int row, int col)
		{
			NRectangleF cell = GetGridCell(row, col);
			Color color = GetPredefinedColor(2);

			// create arc
			NEllipticalArcShape arc = new NEllipticalArcShape(new NPointF(cell.X, cell.Y), new NPointF(cell.Right, cell.Bottom));
			
			// set stroke style
			arc.Style.StrokeStyle = new NStrokeStyle(2, color, LinePattern.Dot);

			// set arrowheads style
			NArrowheadStyle arrowheadStyle = new NArrowheadStyle(
				ArrowheadShape.ClosedFork, 
				"", 
				new NSizeL(12, 12), 
				new NColorFillStyle(color),
				new NStrokeStyle(1, Color.Black));

			arc.Style.StartArrowheadStyle = arrowheadStyle;

			arrowheadStyle = new NArrowheadStyle(
				ArrowheadShape.DoubleArrow, 
				"", 
				new NSizeL(12, 12), 
				new NColorFillStyle(color),
				new NStrokeStyle(1, Color.Black));

			arc.Style.EndArrowheadStyle = arrowheadStyle;

			// add to the active layer
			document.ActiveLayer.AddChild(arc); 
			
			// add description
			cell = GetGridCell(row + 1, col);
			NTextShape text = new NTextShape("Elliptical arc with dots style and ClosedFork and DoubleArrow arrowheads", cell);
			document.ActiveLayer.AddChild(text);
		}

		private void CreatePolylineShape(int row, int col)
		{
			NRectangleF cell = GetGridCell(row, col);
			Color color = GetPredefinedColor(3);

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
			
			// create polyline
			NPolylineShape polyline = new NPolylineShape(points);
			
			// set stroke style
			polyline.Style.StrokeStyle = new NStrokeStyle(2, color, LinePattern.DashDot);

			// set arrowheads style
			NArrowheadStyle arrowheadStyle = new NArrowheadStyle(
				ArrowheadShape.Fork, 
				"", 
				new NSizeL(12, 12), 
				new NColorFillStyle(color),
				new NStrokeStyle(1, Color.Black));

			polyline.Style.StartArrowheadStyle = arrowheadStyle;

			arrowheadStyle = new NArrowheadStyle(
				ArrowheadShape.Losangle, 
				"", 
				new NSizeL(12, 12), 
				new NColorFillStyle(color),
				new NStrokeStyle(1, Color.Black));

			polyline.Style.EndArrowheadStyle = arrowheadStyle;

			// add to the active layer
			document.ActiveLayer.AddChild(polyline); 
			
			// add description
			cell = GetGridCell(row + 1, col);
			NTextShape text = new NTextShape("Polyline with dash-dot style and Fork and Losangle arrowheads", cell);
			document.ActiveLayer.AddChild(text);
		}
		
		private void CreateBezierShape(int row, int col)
		{
			NRectangleF cell = GetGridCell(row, col);
			Color color = GetPredefinedColor(4);

			// create bezier
			NBezierCurveShape bezier = new NBezierCurveShape(cell.Location, new NPointF(cell.Right, cell.Bottom));
			
			// set stroke style
			bezier.Style.StrokeStyle = new NStrokeStyle(2, color, LinePattern.Solid);

			// set arrowheads style
			NArrowheadStyle arrowheadStyle = new NArrowheadStyle(
				ArrowheadShape.ManyOptional, 
				"", 
				new NSizeL(12, 12), 
				new NColorFillStyle(color),
				new NStrokeStyle(1, Color.Black));

			bezier.Style.StartArrowheadStyle = arrowheadStyle;

			arrowheadStyle = new NArrowheadStyle(
				ArrowheadShape.Many, 
				"", 
				new NSizeL(12, 12), 
				new NColorFillStyle(color),
				new NStrokeStyle(1, Color.Black));

			bezier.Style.EndArrowheadStyle = arrowheadStyle;

			// add to the active layer
			document.ActiveLayer.AddChild(bezier); 
			
			// add description
			cell = GetGridCell(row + 1, col);
			NTextShape text = new NTextShape("Bezier curve with solid style and ManyOptional and Many arrowheads", cell);
			document.ActiveLayer.AddChild(text);
		}

		private void CreateCurveShape(int row, int col)
		{
			NRectangleF cell = GetGridCell(row, col);
			Color color = GetPredefinedColor(5);

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
			
			// create curve
			NCurveShape curve = new NCurveShape(points, 1);
			
			// set stroke style
			curve.Style.StrokeStyle = new NStrokeStyle(2, color, LinePattern.DashDotDot);

			// set arrowheads style
			NArrowheadStyle arrowheadStyle = new NArrowheadStyle(
				ArrowheadShape.QuillArrow, 
				"", 
				new NSizeL(12, 12), 
				new NColorFillStyle(color),
				new NStrokeStyle(1, Color.Black));

			curve.Style.StartArrowheadStyle = arrowheadStyle;

			arrowheadStyle = new NArrowheadStyle(
				ArrowheadShape.SunkenArrow, 
				"", 
				new NSizeL(12, 12), 
				new NColorFillStyle(color),
				new NStrokeStyle(1, Color.Black));

			curve.Style.EndArrowheadStyle = arrowheadStyle;

			// add to the active layer
			document.ActiveLayer.AddChild(curve); 
			
			// add description
			cell = GetGridCell(row + 1, col);
			NTextShape text = new NTextShape("Curve with dash-dot-dot style and QuillArrow and SunkenArrow arrowheads", cell);
			document.ActiveLayer.AddChild(text);
		}

		
		#endregion

		#region Event Handlers

		private void randomLineButton_Click(object sender, System.EventArgs e)
		{
			// create shape
			NLineShape shape = null;
			try
			{
				shape = new NLineShape(base.GetRandomPoint(view.Viewport), base.GetRandomPoint(view.Viewport));
			}
			catch
			{
				return;
			}

			// add to active layer
			document.ActiveLayer.AddChild(shape);
			document.SmartRefreshAllViews();
		}

		private void randomCircularArcButton_Click(object sender, System.EventArgs e)
		{
			// create shape
			NPointF start = base.GetRandomPoint(view.Viewport);
			NPointF end = base.GetRandomPoint(view.Viewport);
			
			NEllipticalArcShape shape = null;
			try
			{
				shape = new NEllipticalArcShape(start, end);
			}
			catch
			{
				return;
			}

			// add to active layer
			document.ActiveLayer.AddChild(shape);
			document.SmartRefreshAllViews();
		}

		private void randomEllipticalArcButton_Click(object sender, System.EventArgs e)
		{
			// create shape
			NPointF start = base.GetRandomPoint(view.Viewport);
			NPointF end = base.GetRandomPoint(view.Viewport);
			NPointF control = base.GetRandomPoint(view.Viewport);
			
			NCircularArcShape shape = null;
			try
			{
				shape = new NCircularArcShape(start, end, control);
			}
			catch
			{
				return;
			}

			// add to active layer
			document.ActiveLayer.AddChild(shape);
			document.SmartRefreshAllViews();		
		}

		private void randomPolylineButton_Click(object sender, System.EventArgs e)
		{
			// create shape
			NPolylineShape shape = null;
			try
			{
				shape = new NPolylineShape(base.GetRandomPoints(view.Viewport, (int) pointsCountNumericUpDown.Value));
			}
			catch 
			{
				return;
			}

			// add to active layer
			document.ActiveLayer.AddChild(shape);
			document.SmartRefreshAllViews();
		}

		private void randomBezierButton_Click(object sender, System.EventArgs e)
		{
			// create shape
			NPointF start = base.GetRandomPoint(view.Viewport);
			NPointF firstControl = base.GetRandomPoint(view.Viewport); 
			NPointF secondControl = base.GetRandomPoint(view.Viewport); 
			NPointF end = base.GetRandomPoint(view.Viewport);

			NBezierCurveShape shape = null;
			try
			{
				shape = new NBezierCurveShape(start, firstControl, secondControl, end);
			}
			catch 
			{
				return;
			}

			// add to active layer
			document.ActiveLayer.AddChild(shape);
			document.SmartRefreshAllViews();
		}

		private void randomCurveButton_Click(object sender, System.EventArgs e)
		{
			// create shape
			NCurveShape shape = null;
			try
			{
				shape = new NCurveShape(base.GetRandomPoints(view.Viewport, (int) pointsCountNumericUpDown.Value), 1);
			}
			catch 
			{
				return;
			}

			// add to active layer
			document.ActiveLayer.AddChild(shape);
			document.SmartRefreshAllViews();
		}


		private void editStartArrowheadButton_Click(object sender, System.EventArgs e)
		{
			base.ShowStartArrowheadStyleEditor(view.Selection.AnchorNode as NShape);
		}

		private void editEndArrowheadButton_Click(object sender, System.EventArgs e)
		{
			base.ShowEndArrowheadStyleEditor(view.Selection.AnchorNode as NShape);
		}

		private void editStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			base.ShowStrokeStyleEditor(view.Selection.AnchorNode as NShape);
		}


		private void editDocumentStartArrowheadStyleButton_Click(object sender, System.EventArgs e)
		{
			base.ShowStartArrowheadStyleEditor(document);
		}

		private void editDocumentEndArrowheadStyleButton_Click(object sender, System.EventArgs e)
		{
			base.ShowEndArrowheadStyleEditor(document);
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
				selectedShapeStyleGroup.Enabled = true;
			}
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			selectedShapeStyleGroup.Enabled = false;
		}


		#endregion

		#region Designer Fields

		private Nevron.UI.WinForm.Controls.NButton editStartArrowheadButton;
		private Nevron.UI.WinForm.Controls.NButton editEndArrowheadButton;
		private Nevron.UI.WinForm.Controls.NGroupBox addRandomGroupBox;
		private Nevron.UI.WinForm.Controls.NButton randomLineButton;
		private Nevron.UI.WinForm.Controls.NButton randomPolylineButton;
		private Nevron.UI.WinForm.Controls.NButton randomBezierButton;
		private Nevron.UI.WinForm.Controls.NButton randomCurveButton;
		private Nevron.UI.WinForm.Controls.NNumericUpDown pointsCountNumericUpDown;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NButton editStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NButton editDocumentStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NButton editDocumentStartArrowheadStyleButton;
		private Nevron.UI.WinForm.Controls.NButton editDocumentEndArrowheadStyleButton;
		private Nevron.UI.WinForm.Controls.NButton editDocumentShadowStyleButton;
		private Nevron.UI.WinForm.Controls.NGroupBox selectedShapeStyleGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox documentStylesGroupBox;
		private Nevron.UI.WinForm.Controls.NButton randomCircularArcButton;
		private Nevron.UI.WinForm.Controls.NButton randomEllipticalArcButton;
		private System.ComponentModel.Container components = null;
		
		#endregion
	}
}
