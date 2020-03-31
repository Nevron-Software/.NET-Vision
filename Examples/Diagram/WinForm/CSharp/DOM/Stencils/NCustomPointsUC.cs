using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.Dom;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NCustomPointsUC.
	/// </summary>
	public class NCustomPointsUC : NDiagramExampleUC
	{
		#region Constructor

		public NCustomPointsUC(NMainForm form) : base(form)
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
			this.selectedPointGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.customShapeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.selectedPointGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// commonControlsPanel
			// 
			this.commonControlsPanel.Name = "commonControlsPanel";
			this.commonControlsPanel.Size = new System.Drawing.Size(250, 80);
			// 
			// selectedPointGroup
			// 
			this.selectedPointGroup.Controls.Add(this.label2);
			this.selectedPointGroup.Controls.Add(this.customShapeComboBox);
			this.selectedPointGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.selectedPointGroup.Enabled = false;
			this.selectedPointGroup.ImageIndex = 0;
			this.selectedPointGroup.Location = new System.Drawing.Point(0, 0);
			this.selectedPointGroup.Name = "selectedPointGroup";
			this.selectedPointGroup.Size = new System.Drawing.Size(250, 120);
			this.selectedPointGroup.TabIndex = 0;
			this.selectedPointGroup.TabStop = false;
			this.selectedPointGroup.Text = "Apply Custom Point Shape";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Port shape:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// customShapeComboBox
			// 
			this.customShapeComboBox.Location = new System.Drawing.Point(8, 48);
			this.customShapeComboBox.Name = "customShapeComboBox";
			this.customShapeComboBox.Size = new System.Drawing.Size(232, 22);
			this.customShapeComboBox.TabIndex = 1;
			this.customShapeComboBox.Text = "nComboBox1";
			this.customShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.customShapeComboBox_SelectedIndexChanged);
			// 
			// NCustomPointsUC
			// 
			this.Controls.Add(this.selectedPointGroup);
			this.Name = "NCustomPointsUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.commonControlsPanel, 0);
			this.Controls.SetChildIndex(this.selectedPointGroup, 0);
			this.selectedPointGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			view.Grid.Visible = false;
			view.Selection.Mode = DiagramSelectionMode.Single;

			// init document
			document.BeginInit();

			CreateTrianglePointShape();
			CreateStarPointShape();
			CreateCompositePointShape();
			CreatePoints();

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

			customShapeComboBox.Items.Clear();
			customShapeComboBox.Items.Add("Triangle");
			customShapeComboBox.Items.Add("Star");
			customShapeComboBox.Items.Add("Composite Point");

			ResumeEventsHandling();
		}

		private void CreateTrianglePointShape()
		{
			// create the graphics path representing the point shape
			NRectangleF modelBounds = new NRectangleF(-1, -1, 2, 2);
			GraphicsPath path = new GraphicsPath();
			CreateNGonPath(path, modelBounds, 3, - (float)Math.PI / 2);

			// wrap it in a model and name it
			NCustomPath customPath = new NCustomPath(path, PathType.ClosedFigure);
			customPath.Name = "Triangle";

			// add it to the stencil
			document.PointShapeStencil.AddChild(customPath);
		}

		private void CreateStarPointShape()
		{
			// create the graphics path representing the point shape
			NRectangleF modelBounds = new NRectangleF(-1, -1, 2, 2);
			GraphicsPath path = new GraphicsPath();
			CreateNGramPath(path, modelBounds, 5, -(float)Math.PI / 2, 0.5f);

			// wrap it in amodel and name it
			NCustomPath customPath = new NCustomPath(path, PathType.ClosedFigure);
			customPath.Name = "Star";

			// add it to the stencil
			document.PointShapeStencil.AddChild(customPath);
		}

		private void CreateCompositePointShape()
		{
			NRectangleF modelBounds = new NRectangleF(-1, -1, 2, 2);
			float centerX = 0;			

			// create composite geometry model
			NCompositeGeometry composite = new NCompositeGeometry();
			composite.Name = "Composite Point";

			// add ellipse
			composite.AddChild(new NEllipsePath(new NRectangleF(modelBounds.X, modelBounds.Y, modelBounds.Width / 2, modelBounds.Height)));

			// add cross
			GraphicsPath path = new GraphicsPath();
			path.AddLine(centerX, modelBounds.Y, modelBounds.Right, modelBounds.Bottom);	
			path.StartFigure();
			path.AddLine(modelBounds.Right, modelBounds.Y, centerX, modelBounds.Bottom);	
			composite.AddChild(new NCustomPath(path, PathType.OpenFigure));

			// update the model bounds of the composite
			composite.UpdateModelBounds();

			// add it to the point shape stencil
			document.PointShapeStencil.AddChild(composite);
		}

		private void CreatePoints()
		{
			int row = 0, col = 0;
			
			for (int i = 0; i < document.PointShapeStencil.ChildrenCount(null); i++)
			{
				if (col > 3)
				{
					col = 0;
					row++;
				}

				NRectangleF cell = base.GetGridCell(row, col);
				NPointF location = new NPointF(cell.X + cell.Width / 2, cell.Y + cell.Height / 2);
				string customShapeName = (document.PointShapeStencil.GetChildAt(i) as INDiagramElement).Name;

				NPointElement point = new NPointElement(location, new NSizeF(30, 30), PointShape.Custom, customShapeName);
				document.ActiveLayer.AddChild(point);

				col++;
			}
		}


		private void CreateNGonPath(GraphicsPath path, NRectangleF rect, int edgeCount, float startAngle)
		{
			float angle;
			float fRadiusX = rect.Width / 2.0f;
			float fRadiusY = rect.Height / 2.0f;
			float centerX = rect.X + fRadiusX;
			float centerY = rect.Y + fRadiusY;
			float incAngle = (float)((2 * Math.PI) / edgeCount);

			PointF[] pnt = new PointF[edgeCount];

			for(int i = 0; i < edgeCount; i++)
			{
				angle = startAngle + i * incAngle;
				pnt[i].X = centerX + (float)Math.Cos(angle) * fRadiusX;
				pnt[i].Y = centerY + (float)Math.Sin(angle) * fRadiusY;
			}

			path.AddLines(pnt);
			path.CloseAllFigures();
		}

		private void CreateNGramPath(GraphicsPath path, NRectangleF rect, int edgeCount, float startAngle, float innerRadius)
		{
			int i;
			float angle;
			float halfWidth = rect.Width / 2.0f;
			float halfHeight = rect.Height / 2.0f;
			float centerX = rect.X + halfWidth;
			float centerY = rect.Y + halfHeight;
			float incAngle = (float)(2 * Math.PI / edgeCount);
			float innerOffsetAngle = (float)(Math.PI / edgeCount);

			PointF[] outer = new PointF[edgeCount];
			PointF[] inner = new PointF[edgeCount];

			for(i = 0; i < edgeCount; i++)
			{
				angle = startAngle + i * incAngle;
				outer[i].X = (float)Math.Round(centerX + Math.Cos(angle) * halfWidth, 1);
				outer[i].Y = (float)Math.Round(centerY + Math.Sin(angle) * halfHeight, 1);

				angle += innerOffsetAngle;
				inner[i].X = (float)Math.Round(centerX + Math.Cos(angle) * innerRadius, 1);
				inner[i].Y = (float)Math.Round(centerY + Math.Sin(angle) * innerRadius, 1);
			}

			for(i = 0; i < (edgeCount - 1); i++)
			{
				path.AddLine(outer[i], inner[i]);
				path.AddLine(inner[i], outer[i + 1]);
			}

			path.AddLine(outer[i], inner[i]);
			path.CloseAllFigures();
		}


		#endregion

		#region Event Handlers

		private void customShapeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			if (customShapeComboBox.SelectedIndex == -1)
				return;

			// get the selected point
			NPointElement point = (view.Selection.AnchorNode as NPointElement);
			if (point == null)
				return;

			PauseEventsHandling();
			
			// change the point custom shape name
			point.CustomShapeName = customShapeComboBox.SelectedItem.ToString();
			
			ResumeEventsHandling();
			document.SmartRefreshAllViews();
		}

		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			// get the selected point
			NPointElement point = (args.Node as NPointElement);
			if (point == null)
			{
				selectedPointGroup.Enabled = false;
				return;
			}

			PauseEventsHandling();

			// update the point shape combo index
			selectedPointGroup.Enabled = true;
			customShapeComboBox.SelectedItem = point.CustomShapeName;

			ResumeEventsHandling();
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			selectedPointGroup.Enabled = false;
		}


		#endregion

		#region Designer Fields

		private Nevron.UI.WinForm.Controls.NComboBox customShapeComboBox;
		private Nevron.UI.WinForm.Controls.NGroupBox selectedPointGroup;
		private System.Windows.Forms.Label label2;

		private System.ComponentModel.Container components = null;

		#endregion
	}
}