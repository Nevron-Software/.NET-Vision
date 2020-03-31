using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Windows.Forms;

using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NCustomArrowheadsUC.
	/// </summary>
	public class NCustomArrowheadsUC : NDiagramExampleUC
	{
		#region Constructor

		public NCustomArrowheadsUC(NMainForm form) : base(form)
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
			this.selectedShapeGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.endArrowheadComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.startArrowheadComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.selectedShapeGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// commonControlsPanel
			// 
			this.commonControlsPanel.Name = "commonControlsPanel";
			this.commonControlsPanel.Size = new System.Drawing.Size(250, 80);
			// 
			// selectedShapeGroup
			// 
			this.selectedShapeGroup.Controls.Add(this.endArrowheadComboBox);
			this.selectedShapeGroup.Controls.Add(this.startArrowheadComboBox);
			this.selectedShapeGroup.Controls.Add(this.label2);
			this.selectedShapeGroup.Controls.Add(this.label1);
			this.selectedShapeGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.selectedShapeGroup.Enabled = false;
			this.selectedShapeGroup.ImageIndex = 0;
			this.selectedShapeGroup.Location = new System.Drawing.Point(0, 0);
			this.selectedShapeGroup.Name = "selectedShapeGroup";
			this.selectedShapeGroup.Size = new System.Drawing.Size(250, 136);
			this.selectedShapeGroup.TabIndex = 0;
			this.selectedShapeGroup.TabStop = false;
			this.selectedShapeGroup.Text = "Apply Custom Arrowhead Shapes";
			// 
			// endArrowheadComboBox
			// 
			this.endArrowheadComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.endArrowheadComboBox.Location = new System.Drawing.Point(8, 104);
			this.endArrowheadComboBox.Name = "endArrowheadComboBox";
			this.endArrowheadComboBox.Size = new System.Drawing.Size(232, 22);
			this.endArrowheadComboBox.TabIndex = 3;
			this.endArrowheadComboBox.Text = "nComboBox1";
			this.endArrowheadComboBox.SelectedIndexChanged += new System.EventHandler(this.endArrowheadComboBox_SelectedIndexChanged);
			// 
			// startArrowheadComboBox
			// 
			this.startArrowheadComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.startArrowheadComboBox.Location = new System.Drawing.Point(8, 48);
			this.startArrowheadComboBox.Name = "startArrowheadComboBox";
			this.startArrowheadComboBox.Size = new System.Drawing.Size(232, 22);
			this.startArrowheadComboBox.TabIndex = 1;
			this.startArrowheadComboBox.Text = "nComboBox1";
			this.startArrowheadComboBox.SelectedIndexChanged += new System.EventHandler(this.startArrowheadComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Start arrowhead shape:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "End arrowhead shape:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NCustomArrowheadsUC
			// 
			this.Controls.Add(this.selectedShapeGroup);
			this.Name = "NCustomArrowheadsUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.selectedShapeGroup, 0);
			this.Controls.SetChildIndex(this.commonControlsPanel, 0);
			this.selectedShapeGroup.ResumeLayout(false);
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

			// start document initialization
			document.BeginInit();

			CreateDoubleOpenedArrowShape();
			CreateRectangleArrowShape();
			CreateCompositeArrowheadShape();
			CreateStroke();

			// end document initialization
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

			startArrowheadComboBox.Items.Clear();
			startArrowheadComboBox.Items.Add("Double Opened Arrow");
			startArrowheadComboBox.Items.Add("Rectangle");
			startArrowheadComboBox.Items.Add("Composite Arrowhead");

			endArrowheadComboBox.Items.Clear();
			endArrowheadComboBox.Items.Add("Double Opened Arrow");
			endArrowheadComboBox.Items.Add("Rectangle");
			endArrowheadComboBox.Items.Add("Composite Arrowhead");

			ResumeEventsHandling();
		}

		
		private void CreateDoubleOpenedArrowShape()
		{
			NRectangleF modelBounds = new NRectangleF(0, -1, 2, 2);
			
			float fXCenter = modelBounds.X + modelBounds.Width / 2;
			float fYCenter = modelBounds.Y + modelBounds.Height / 2;

			PointF[] lines = new PointF[3];
			GraphicsPath path = new GraphicsPath();

			// arrow1
			lines[0] = new PointF(fXCenter, modelBounds.Y);
			lines[1] = new PointF(modelBounds.X, fYCenter);
			lines[2] = new PointF(fXCenter, modelBounds.Bottom);
			path.AddLines(lines);

			// arrow2
			path.StartFigure();
			lines[0] = new PointF(modelBounds.Right, modelBounds.Y);
			lines[1] = new PointF(fXCenter, fYCenter);
			lines[2] = new PointF(modelBounds.Right, modelBounds.Bottom);
			path.AddLines(lines);

			/// create a custom open figure and name it
			NCustomPath strokePath = new NCustomPath(path, PathType.OpenFigure);
			strokePath.Name = "Double Opened Arrow";

			// add it to the arrowhead shape stencil
			document.ArrowheadShapeStencil.AddChild(strokePath);
		}

		private void CreateRectangleArrowShape()
		{
			/// create a simple rect and name it
			NRectangleF modelBounds = new NRectangleF(0, -1, 2, 2);
			NRectanglePath rect = new NRectanglePath(modelBounds);
			rect.Name = "Rectangle";

			// add it to the arrowhead shape stencil
			document.ArrowheadShapeStencil.AddChild(rect);
		}

		private void CreateCompositeArrowheadShape()
		{
			NRectangleF modelBounds = new NRectangleF(0, -1, 2, 2);
			
			// create composite geometry and name it
			NCompositeGeometry geometry = new NCompositeGeometry();
			geometry.Name = "Composite Arrowhead";

			// add rect
			geometry.AddChild(new NRectanglePath(	new NRectangleF(	modelBounds.X, 
																		modelBounds.Y, 
																		modelBounds.Width / 2, 
																		modelBounds.Height)));

			// add slash 1
			float x = modelBounds.X + (modelBounds.Width * 3) / 4;
			geometry.AddChild(new NLinePath(	new NPointF(x, modelBounds.Y),
												new NPointF(x, modelBounds.Bottom)));

			// add slash 2
			geometry.AddChild(new NLinePath(	new NPointF(modelBounds.Right, modelBounds.Y),
												new NPointF(modelBounds.Right, modelBounds.Bottom)));

			geometry.UpdateModelBounds();

			// add it to the arrowhead shape stencil
			document.ArrowheadShapeStencil.AddChild(geometry);
		}

		private void CreateStroke()
		{
			// create an arrow head style which uses a custom shape
			NArrowheadStyle defaultStyle = new NArrowheadStyle(
				ArrowheadShape.Custom, 
				"Double Opened Arrow",
				new NSizeL(13, 13),
				new NColorFillStyle(Color.OrangeRed),
				new NStrokeStyle(1, Color.Black));

			// create a polyline which uses this arrowhead style
			NPointF[] points = new NPointF[]{
				new NPointF(290, 50),
				new NPointF(207, 199),
				new NPointF(40,  50),
				new NPointF(234, 95),
				new NPointF(94,  184)};
			
			NPolylineShape polyline = new NPolylineShape(points);
			
			polyline.Style.StartArrowheadStyle = defaultStyle.Clone() as NArrowheadStyle;
			polyline.Style.EndArrowheadStyle = defaultStyle.Clone() as NArrowheadStyle;

			document.ActiveLayer.AddChild(polyline);
		}

		private void CreateNGonPath(GraphicsPath path, ref NRectangleF rect, int nEdgeCount, float fStartAngle)
		{
			float fAngle;
			float fRadiusX = rect.Width / 2.0f;
			float fRadiusY = rect.Height / 2.0f;
			float fCenterX = rect.X + fRadiusX;
			float fCenterY = rect.Y + fRadiusY;
			float fIncrementAngle = (float)((2 * Math.PI) / nEdgeCount);

			PointF[] pnt = new PointF[nEdgeCount];

			for(int i = 0; i < nEdgeCount; i++)
			{
				fAngle = fStartAngle + i * fIncrementAngle;
				pnt[i].X = fCenterX + (float)Math.Cos(fAngle) * fRadiusX;
				pnt[i].Y = fCenterY + (float)Math.Sin(fAngle) * fRadiusY;
			}

			path.AddLines(pnt);
			path.CloseAllFigures();
		}


		#endregion

		#region Event Handlers

		private void startArrowheadComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			if (startArrowheadComboBox.SelectedIndex == -1)
				return;

			// get the selected shape
			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
				return;

			PauseEventsHandling();

			// change the shape start arrowhead style to use the selected custom shape
			shape.Style.StartArrowheadStyle = new NArrowheadStyle(	
				ArrowheadShape.Custom, 
				startArrowheadComboBox.SelectedItem.ToString(),
				new NSizeL(13, 13), 
				new NColorFillStyle(Color.OrangeRed), 
				new NStrokeStyle(1, Color.Black));

			document.SmartRefreshAllViews();
			ResumeEventsHandling();
		}

		private void endArrowheadComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			if (endArrowheadComboBox.SelectedIndex == -1)
				return;

			// get the selected shape
			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
				return;

			PauseEventsHandling();

			// change the shape start arrowhead style to use the selected custom shape
			shape.Style.EndArrowheadStyle = new NArrowheadStyle(	
				ArrowheadShape.Custom, 
				endArrowheadComboBox.SelectedItem.ToString(),
				new NSizeL(13, 13), 
				new NColorFillStyle(Color.OrangeRed), 
				new NStrokeStyle(1, Color.Black));

			document.SmartRefreshAllViews();
			ResumeEventsHandling();
		}

		
		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();
			
			// get the selected shape
			NShape shape = (view.Selection.AnchorNode as NShape);

			// update the form controls
			if (shape != null)
			{
				selectedShapeGroup.Enabled = true;
				
				startArrowheadComboBox.SelectedIndex = -1;
				if (shape.Style.StartArrowheadStyle != null)
					startArrowheadComboBox.SelectedItem = shape.Style.StartArrowheadStyle.CustomShapeName;

				endArrowheadComboBox.SelectedIndex = -1;
				if (shape.Style.EndArrowheadStyle != null)
					endArrowheadComboBox.SelectedItem = shape.Style.EndArrowheadStyle.CustomShapeName;
			}
			else
			{
				selectedShapeGroup.Enabled = false;
			}

			ResumeEventsHandling();
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			selectedShapeGroup.Enabled = false;
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NGroupBox selectedShapeGroup;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox startArrowheadComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox endArrowheadComboBox;

		#endregion
	}
}