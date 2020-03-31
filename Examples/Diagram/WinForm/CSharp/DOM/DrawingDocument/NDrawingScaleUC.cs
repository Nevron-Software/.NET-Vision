using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.UI.WinForm.Controls;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NDrawingScaleUC.
	/// </summary>
	public class NDrawingScaleUC : NDiagramExampleUC
	{
		#region Constructors
		public NDrawingScaleUC(NMainForm form) : base(form)
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
			this.drawingScaleTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.drawingScaleSystemComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.drawingScaleComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.drawingScaleGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.documentMeasurementUnitTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.worldMeasurmentUnitTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.selectionBoundsGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.selectionWidthTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.selectionHeightTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.selectionTopTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.selectionLeftTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.scaleSystemsGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.documentSizeGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.documentWidthTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.documentHeightTextBox = new Nevron.UI.WinForm.Controls.NTextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.drawingScaleGroupBox.SuspendLayout();
			this.selectionBoundsGroupBox.SuspendLayout();
			this.scaleSystemsGroupBox.SuspendLayout();
			this.documentSizeGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// drawingScaleTextBox
			// 
			this.drawingScaleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.drawingScaleTextBox.ErrorMessage = null;
			this.drawingScaleTextBox.Location = new System.Drawing.Point(112, 72);
			this.drawingScaleTextBox.Name = "drawingScaleTextBox";
			this.drawingScaleTextBox.ReadOnly = true;
			this.drawingScaleTextBox.Size = new System.Drawing.Size(120, 20);
			this.drawingScaleTextBox.TabIndex = 5;
			this.drawingScaleTextBox.Text = "1";
			// 
			// drawingScaleSystemComboBox
			// 
			this.drawingScaleSystemComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.drawingScaleSystemComboBox.Location = new System.Drawing.Point(64, 24);
			this.drawingScaleSystemComboBox.Name = "drawingScaleSystemComboBox";
			this.drawingScaleSystemComboBox.Size = new System.Drawing.Size(176, 22);
			this.drawingScaleSystemComboBox.TabIndex = 0;
			this.drawingScaleSystemComboBox.Text = "nComboBox1";
			this.drawingScaleSystemComboBox.SelectedIndexChanged += new System.EventHandler(this.drawingScaleSystemComboBox_SelectedIndexChanged);
			// 
			// drawingScaleComboBox
			// 
			this.drawingScaleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.drawingScaleComboBox.Location = new System.Drawing.Point(64, 56);
			this.drawingScaleComboBox.Name = "drawingScaleComboBox";
			this.drawingScaleComboBox.Size = new System.Drawing.Size(176, 22);
			this.drawingScaleComboBox.TabIndex = 1;
			this.drawingScaleComboBox.Text = "nComboBox1";
			this.drawingScaleComboBox.SelectedIndexChanged += new System.EventHandler(this.drawingScaleComboBox_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 24);
			this.label7.TabIndex = 4;
			this.label7.Text = "Drawing scale:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// drawingScaleGroupBox
			// 
			this.drawingScaleGroupBox.Controls.Add(this.label10);
			this.drawingScaleGroupBox.Controls.Add(this.label11);
			this.drawingScaleGroupBox.Controls.Add(this.label7);
			this.drawingScaleGroupBox.Controls.Add(this.drawingScaleTextBox);
			this.drawingScaleGroupBox.Controls.Add(this.documentMeasurementUnitTextBox);
			this.drawingScaleGroupBox.Controls.Add(this.worldMeasurmentUnitTextBox);
			this.drawingScaleGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.drawingScaleGroupBox.ImageIndex = 0;
			this.drawingScaleGroupBox.Location = new System.Drawing.Point(0, 96);
			this.drawingScaleGroupBox.Name = "drawingScaleGroupBox";
			this.drawingScaleGroupBox.Size = new System.Drawing.Size(250, 104);
			this.drawingScaleGroupBox.TabIndex = 1;
			this.drawingScaleGroupBox.TabStop = false;
			this.drawingScaleGroupBox.Text = "Measurement units and scale";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 24);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(96, 24);
			this.label10.TabIndex = 0;
			this.label10.Text = "Logical MU:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 48);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(96, 24);
			this.label11.TabIndex = 2;
			this.label11.Text = "World MU:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// documentMeasurementUnitTextBox
			// 
			this.documentMeasurementUnitTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.documentMeasurementUnitTextBox.ErrorMessage = null;
			this.documentMeasurementUnitTextBox.Location = new System.Drawing.Point(112, 24);
			this.documentMeasurementUnitTextBox.Name = "documentMeasurementUnitTextBox";
			this.documentMeasurementUnitTextBox.ReadOnly = true;
			this.documentMeasurementUnitTextBox.Size = new System.Drawing.Size(120, 20);
			this.documentMeasurementUnitTextBox.TabIndex = 1;
			// 
			// worldMeasurmentUnitTextBox
			// 
			this.worldMeasurmentUnitTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.worldMeasurmentUnitTextBox.ErrorMessage = null;
			this.worldMeasurmentUnitTextBox.Location = new System.Drawing.Point(112, 48);
			this.worldMeasurmentUnitTextBox.Name = "worldMeasurmentUnitTextBox";
			this.worldMeasurmentUnitTextBox.ReadOnly = true;
			this.worldMeasurmentUnitTextBox.Size = new System.Drawing.Size(120, 20);
			this.worldMeasurmentUnitTextBox.TabIndex = 3;
			// 
			// selectionBoundsGroupBox
			// 
			this.selectionBoundsGroupBox.Controls.Add(this.label3);
			this.selectionBoundsGroupBox.Controls.Add(this.label4);
			this.selectionBoundsGroupBox.Controls.Add(this.label5);
			this.selectionBoundsGroupBox.Controls.Add(this.label6);
			this.selectionBoundsGroupBox.Controls.Add(this.selectionLeftTextBox);
			this.selectionBoundsGroupBox.Controls.Add(this.selectionTopTextBox);
			this.selectionBoundsGroupBox.Controls.Add(this.selectionWidthTextBox);
			this.selectionBoundsGroupBox.Controls.Add(this.selectionHeightTextBox);
			this.selectionBoundsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.selectionBoundsGroupBox.ImageIndex = 0;
			this.selectionBoundsGroupBox.Location = new System.Drawing.Point(0, 200);
			this.selectionBoundsGroupBox.Name = "selectionBoundsGroupBox";
			this.selectionBoundsGroupBox.Size = new System.Drawing.Size(250, 128);
			this.selectionBoundsGroupBox.TabIndex = 2;
			this.selectionBoundsGroupBox.TabStop = false;
			this.selectionBoundsGroupBox.Text = "Selection bounds";
			this.selectionBoundsGroupBox.Visible = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Top:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Left:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 23);
			this.label5.TabIndex = 6;
			this.label5.Text = "Height:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 23);
			this.label6.TabIndex = 4;
			this.label6.Text = "Width:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// selectionWidthTextBox
			// 
			this.selectionWidthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.selectionWidthTextBox.ErrorMessage = null;
			this.selectionWidthTextBox.Location = new System.Drawing.Point(112, 72);
			this.selectionWidthTextBox.Name = "selectionWidthTextBox";
			this.selectionWidthTextBox.ReadOnly = true;
			this.selectionWidthTextBox.Size = new System.Drawing.Size(120, 20);
			this.selectionWidthTextBox.TabIndex = 5;
			// 
			// selectionHeightTextBox
			// 
			this.selectionHeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.selectionHeightTextBox.ErrorMessage = null;
			this.selectionHeightTextBox.Location = new System.Drawing.Point(112, 96);
			this.selectionHeightTextBox.Name = "selectionHeightTextBox";
			this.selectionHeightTextBox.ReadOnly = true;
			this.selectionHeightTextBox.Size = new System.Drawing.Size(120, 20);
			this.selectionHeightTextBox.TabIndex = 7;
			// 
			// selectionTopTextBox
			// 
			this.selectionTopTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.selectionTopTextBox.ErrorMessage = null;
			this.selectionTopTextBox.Location = new System.Drawing.Point(112, 48);
			this.selectionTopTextBox.Name = "selectionTopTextBox";
			this.selectionTopTextBox.ReadOnly = true;
			this.selectionTopTextBox.Size = new System.Drawing.Size(120, 20);
			this.selectionTopTextBox.TabIndex = 3;
			// 
			// selectionLeftTextBox
			// 
			this.selectionLeftTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.selectionLeftTextBox.ErrorMessage = null;
			this.selectionLeftTextBox.Location = new System.Drawing.Point(112, 24);
			this.selectionLeftTextBox.Name = "selectionLeftTextBox";
			this.selectionLeftTextBox.ReadOnly = true;
			this.selectionLeftTextBox.Size = new System.Drawing.Size(120, 20);
			this.selectionLeftTextBox.TabIndex = 1;
			// 
			// scaleSystemsGroupBox
			// 
			this.scaleSystemsGroupBox.Controls.Add(this.label9);
			this.scaleSystemsGroupBox.Controls.Add(this.label8);
			this.scaleSystemsGroupBox.Controls.Add(this.drawingScaleComboBox);
			this.scaleSystemsGroupBox.Controls.Add(this.drawingScaleSystemComboBox);
			this.scaleSystemsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.scaleSystemsGroupBox.ImageIndex = 0;
			this.scaleSystemsGroupBox.Location = new System.Drawing.Point(0, 0);
			this.scaleSystemsGroupBox.Name = "scaleSystemsGroupBox";
			this.scaleSystemsGroupBox.Size = new System.Drawing.Size(250, 96);
			this.scaleSystemsGroupBox.TabIndex = 0;
			this.scaleSystemsGroupBox.TabStop = false;
			this.scaleSystemsGroupBox.Text = "Predefined drawing scale systems";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 56);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 23);
			this.label9.TabIndex = 3;
			this.label9.Text = "Ratio:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 23);
			this.label8.TabIndex = 2;
			this.label8.Text = "System:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// documentSizeGroupBox
			// 
			this.documentSizeGroupBox.Controls.Add(this.label1);
			this.documentSizeGroupBox.Controls.Add(this.label15);
			this.documentSizeGroupBox.Controls.Add(this.documentHeightTextBox);
			this.documentSizeGroupBox.Controls.Add(this.documentWidthTextBox);
			this.documentSizeGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.documentSizeGroupBox.ImageIndex = 0;
			this.documentSizeGroupBox.Location = new System.Drawing.Point(0, 328);
			this.documentSizeGroupBox.Name = "documentSizeGroupBox";
			this.documentSizeGroupBox.Size = new System.Drawing.Size(250, 80);
			this.documentSizeGroupBox.TabIndex = 3;
			this.documentSizeGroupBox.TabStop = false;
			this.documentSizeGroupBox.Text = "Document size in Logical MU";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Width:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 48);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(96, 23);
			this.label15.TabIndex = 6;
			this.label15.Text = "Height:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// documentWidthTextBox
			// 
			this.documentWidthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.documentWidthTextBox.ErrorMessage = null;
			this.documentWidthTextBox.Location = new System.Drawing.Point(112, 24);
			this.documentWidthTextBox.Name = "documentWidthTextBox";
			this.documentWidthTextBox.ReadOnly = true;
			this.documentWidthTextBox.Size = new System.Drawing.Size(120, 20);
			this.documentWidthTextBox.TabIndex = 5;
			// 
			// documentHeightTextBox
			// 
			this.documentHeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.documentHeightTextBox.ErrorMessage = null;
			this.documentHeightTextBox.Location = new System.Drawing.Point(112, 48);
			this.documentHeightTextBox.Name = "documentHeightTextBox";
			this.documentHeightTextBox.ReadOnly = true;
			this.documentHeightTextBox.Size = new System.Drawing.Size(120, 20);
			this.documentHeightTextBox.TabIndex = 7;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(0, 0);
			this.label16.Name = "label16";
			this.label16.TabIndex = 0;
			// 
			// NDrawingScaleUC
			// 
			this.Controls.Add(this.documentSizeGroupBox);
			this.Controls.Add(this.selectionBoundsGroupBox);
			this.Controls.Add(this.drawingScaleGroupBox);
			this.Controls.Add(this.scaleSystemsGroupBox);
			this.Name = "NDrawingScaleUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.scaleSystemsGroupBox, 0);
			this.Controls.SetChildIndex(this.drawingScaleGroupBox, 0);
			this.Controls.SetChildIndex(this.selectionBoundsGroupBox, 0);
			this.Controls.SetChildIndex(this.documentSizeGroupBox, 0);
			this.drawingScaleGroupBox.ResumeLayout(false);
			this.selectionBoundsGroupBox.ResumeLayout(false);
			this.scaleSystemsGroupBox.ResumeLayout(false);
			this.documentSizeGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides
		
		protected override void LoadExample()
		{
			// init view
			view.GlobalVisibility.ShowPorts = false;

			// init form controls
			drawingScaleSystemComboBox.Items.Add(new NDrawingScaleSystem(DrawingScaleSystemType.Architectural));
			drawingScaleSystemComboBox.Items.Add(new NDrawingScaleSystem(DrawingScaleSystemType.CivilEngineering));
			drawingScaleSystemComboBox.Items.Add(new NDrawingScaleSystem(DrawingScaleSystemType.Metric));
			drawingScaleSystemComboBox.Items.Add(new NDrawingScaleSystem(DrawingScaleSystemType.MechanicalEngineering));		
			
			// by default select the Architectural system
			drawingScaleSystemComboBox.SelectedIndex = 0;
		}

		protected override void AttachToEvents()
		{
			document.EventSinkService.NodeBoundsChanged += new NodeEventHandler(EventSinkService_NodeBoundsChanged);
			
			view.EventSinkService.NodeSelected += new NodeEventHandler(EventSinkService_NodeSelected);
			view.EventSinkService.NodeDeselected += new NodeEventHandler(EventSinkService_NodeDeselected);

			base.AttachToEvents();
		}

		protected override void DetachFromEvents()
		{
			document.EventSinkService.NodeBoundsChanged -= new NodeEventHandler(EventSinkService_NodeBoundsChanged);

			view.EventSinkService.NodeSelected -= new NodeEventHandler(EventSinkService_NodeSelected);
			view.EventSinkService.NodeDeselected -= new NodeEventHandler(EventSinkService_NodeDeselected);

			base.DetachFromEvents();
		}
 

		#endregion

		#region Implementation
		
		private void CreateSampleDocument(NDrawingScaleSystem system, NDrawingScale scale)
		{
			// begin init
			document.Reset();
			document.BeginInit();

			// setup drawing scale
			document.DrawingScaleMode = DrawingScaleMode.CustomScale;
			document.MeasurementUnit = scale.MeasurementUnit;
			document.CustomWorldMeasurementUnit = scale.WorldMeasurementUnit;
			document.CustomScale = scale.ScaleFactor;

			// create drawing content
			switch (system.Type)
			{
				case DrawingScaleSystemType.Architectural:
					CreateArchitecturalDocument();
					break;

				case DrawingScaleSystemType.CivilEngineering:
					CreateCivilEngineeringDocument();
					break;

				case DrawingScaleSystemType.Metric:
					CreateMetricDocument();
					break;

				case DrawingScaleSystemType.MechanicalEngineering:
					CreateMechanicalEngineeringDocument();
					break;

				default:
					Debug.Assert(false, "New drawing scale system?");
					break;
			}

			// end init
			document.EndInit();
			document.UpdateAllViews();
		}

		
		private void UpdateDocumentBoundsTextBoxes()
		{
			NMeasurementUnit logicalUnit = document.MeasurementUnit;
			NMeasurementUnit displayUnit = document.CustomWorldMeasurementUnit;

			documentWidthTextBox.Text = document.Width.ToString() + " " + logicalUnit.Abbreviation;
			documentHeightTextBox.Text = document.Height.ToString() + " " + logicalUnit.Abbreviation;
			documentMeasurementUnitTextBox.Text = logicalUnit.Name;

			worldMeasurmentUnitTextBox.Text = displayUnit.Name;
			drawingScaleTextBox.Text = document.CustomScale.ToString();
		}

		private void UpdateSelectionBoundsTextBoxes()
		{
			NShape shape = (view.Selection.AnchorNode as NShape);

			if (shape == null)
			{
				selectionBoundsGroupBox.Visible = false;
				selectionWidthTextBox.Text = "";
				selectionHeightTextBox.Text = "";
				selectionTopTextBox.Text = "";
				selectionLeftTextBox.Text = "";
				return;
			}

			string abbreviation = document.MeasurementUnit.Abbreviation;

			selectionBoundsGroupBox.Visible = true;
			selectionWidthTextBox.Text = shape.Width + " " + abbreviation;
			selectionHeightTextBox.Text = shape.Height + " " + abbreviation;
			selectionTopTextBox.Text = shape.Location.Y + " " + abbreviation;
			selectionLeftTextBox.Text = shape.Location.X + " " + abbreviation;
		}
		
	
		private void CreateArchitecturalDocument()
		{
			// set global document styles
			document.Style.TextStyle = new NTextStyle(new Font("Arial", 8.25f));
			document.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
			document.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Center;

			// create the rim rect
			NRectangleShape rimRect = new NRectangleShape(new NRectangleF(0, 0, 5, 7));
			rimRect.Style.FillStyle = new NColorFillStyle(Color.FromArgb(0, Color.White));
			document.ActiveLayer.AddChild(rimRect);
			
			// create the room rects
			NRectangleShape roomRect1 = new NRectangleShape(new NRectangleF(0, 0, 2, 3));
			roomRect1.Text = "Room 1";
			document.ActiveLayer.AddChild(roomRect1);

			NRectangleShape roomRect2 = new NRectangleShape(new NRectangleF(3, 0, 2, 3));
			roomRect2.Text = "Room 2";
			document.ActiveLayer.AddChild(roomRect2);

			NRectangleShape roomRect3 = new NRectangleShape(new NRectangleF(0, 4, 2, 3));
			roomRect3.Text = "Room 3";
			document.ActiveLayer.AddChild(roomRect3);
			
			// create the stairs case
			NCompositeShape stairCase = new NCompositeShape();

			float stepXSize = 0.7f;
			float stepYSize = 0.25f;
			for (int i = 0; i < 9; i ++)
			{
				NRectanglePath step = new NRectanglePath(0, stepYSize * i, stepXSize, stepYSize);
				stairCase.Primitives.AddChild(step);
			}

			stairCase.UpdateModelBounds();
			stairCase.Bounds = new NRectangleF(4, 4, 1, 3);

			stairCase.Text = "Stairs";
			NTextStyle textStyle = (document.Style.TextStyle.Clone() as NTextStyle);
			textStyle.Orientation = 90;
			stairCase.Style.TextStyle = textStyle;			

			document.ActiveLayer.AddChild(stairCase);

			// update the drawing bounds to size to content with some margins
			document.AutoBoundsMinSize = new NSizeF(1, 1);
			document.AutoBoundsPadding = new Nevron.Diagram.NMargins(0.5f);
			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent;
		}

		private void CreateCivilEngineeringDocument()
		{
			// set global document styles
			document.Style.TextStyle = new NTextStyle(new Font("Arial", 8.25f));
			document.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
			document.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Center;

			// create the rim rect
			NRectangleShape rimRect = new NRectangleShape(0, 0, 150, 90);
			rimRect.Style.FillStyle = new NColorFillStyle(Color.Green);
			document.ActiveLayer.AddChild(rimRect);

			// create house rect
			NRectangleShape houseRect = new NRectangleShape(3, 3, 52, 32);
			houseRect.Style.FillStyle = new NColorFillStyle(Color.Firebrick);
			houseRect.Text = "House";
			document.ActiveLayer.AddChild(houseRect);
			
			// create garage rect
			NRectangleShape garageRect = new NRectangleShape(new NRectangleF(3, 35, 26, 13));
			garageRect.Style.FillStyle = new NColorFillStyle(Color.Firebrick);
			garageRect.Text = "Garage";
			document.ActiveLayer.AddChild(garageRect);

			// create the pool ellipse
			NEllipseShape poolEllipse = new NEllipseShape(new NRectangleF(60, 3, 75, 75));
			poolEllipse.Style.FillStyle = new NColorFillStyle(Color.LightBlue);
			poolEllipse.Labels.DefaultLabel.Text = "Pool";
			document.ActiveLayer.AddChild(poolEllipse);

			// update the drawing bounds to size to content with some margins
			document.AutoBoundsMinSize = new NSizeF(1, 1);
			document.AutoBoundsPadding = new Nevron.Diagram.NMargins(1.5f);
			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent;
		}
		
		private void CreateMetricDocument()
		{
			// set global document styles
			document.Style.TextStyle = new NTextStyle(new Font("Arial", 8.25f));
			document.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
			document.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Center;

			// create the rim rect
			NRectangleShape rimRect = new NRectangleShape(0, 0, 140, 140);
			rimRect.Style.FillStyle = new NColorFillStyle(Color.Gray);
			document.ActiveLayer.AddChild(rimRect);

			// create block 1
			NRectangleShape block1 = new NRectangleShape(new NRectangleF(0, 0, 68, 68));
			block1.Style.FillStyle = new NColorFillStyle(Color.Firebrick);
			block1.Text = "Block 1";
			document.ActiveLayer.AddChild(block1);

			// create block 2
			NRectangleShape block2 = new NRectangleShape(new NRectangleF(72, 0, 68, 68));
			block2.Style.FillStyle = new NColorFillStyle(Color.Firebrick);
			block2.Text = "Block 2";
			document.ActiveLayer.AddChild(block2);

			// create block 3
			NRectangleShape block3 = new NRectangleShape(new NRectangleF(0, 72, 68, 68));
			block3.Style.FillStyle = new NColorFillStyle(Color.Firebrick);
			block3.Text = "Block 3";
			document.ActiveLayer.AddChild(block3);

			// create block 3
			NRectangleShape block4 = new NRectangleShape( new NRectangleF(72, 72, 68, 68));
			block4.Style.FillStyle = new NColorFillStyle(Color.Firebrick);
			block4.Text = "Block 4";
			document.ActiveLayer.AddChild(block4);
			
			// update the drawing bounds to size to content with some margins
			document.AutoBoundsMinSize = new NSizeF(1, 1);
			document.AutoBoundsPadding = new Nevron.Diagram.NMargins(5f);
			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent;
		}

		private void CreateMechanicalEngineeringDocument()
		{
			// create the key shape
			NCompositeShape key = new NCompositeShape();
			
			NRectanglePath keyRect = new NRectanglePath(new NRectangleF(12.5f, 30, 5f, 50));
			key.Primitives.AddChild(keyRect);

			NEllipsePath keyCircle = new NEllipsePath(new NRectangleF(0, 0, 30, 30));
			key.Primitives.AddChild(keyCircle);

			NEllipsePath keyHole = new NEllipsePath(new NRectangleF(13f, 2f, 4f, 4f));
			NStyle.SetFillStyle(keyHole, new NColorFillStyle(Color.White));
			NStyle.SetStrokeStyle(keyHole, new NStrokeStyle(0, Color.Black));
			key.Primitives.AddChild(keyHole);

			key.UpdateModelBounds();
			key.Style.FillStyle = new NColorFillStyle(Color.DarkGray);
			key.Style.StrokeStyle = new NStrokeStyle(0, Color.Black);

			document.ActiveLayer.AddChild(key);
		
			// create the octagram
			NBasicShapesFactory factory = new NBasicShapesFactory(document);
			NShape octagram = factory.CreateShape((int)BasicShapes.Octagram);

			octagram.Bounds = new NRectangleF(40, 0, 40, 40);
			octagram.Style.FillStyle = new NColorFillStyle(Color.DarkGray);
			octagram.Style.StrokeStyle = new NStrokeStyle(0, Color.Black);			

			document.ActiveLayer.AddChild(octagram);
			
			// update the drawing bounds to size to content with some margins
			document.AutoBoundsMinSize = new NSizeF(1, 1);
			document.AutoBoundsPadding = new Nevron.Diagram.NMargins(5f);
			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent;
		}

		
		#endregion

		#region Event Handlers
		
		private void drawingScaleSystemComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();

			// get the current system
			NDrawingScaleSystem system = (drawingScaleSystemComboBox.SelectedItem as NDrawingScaleSystem);

			// refill the drawing scale combo
			drawingScaleComboBox.Items.Clear();
			foreach (NDrawingScale drawingScale in system.DrawingScales)
			{
				drawingScaleComboBox.Items.Add(drawingScale);
			}

			// select the default drawing scale
			NDrawingScale scale = system.DefaultDrawingScale;
			drawingScaleComboBox.SelectedItem = scale;

			// create sample document
			view.Selection.DeselectAll(); 
			CreateSampleDocument(system, scale);

			// update the document bounds text boxes
			UpdateDocumentBoundsTextBoxes();

			// update the selection bounds text boxes
			UpdateSelectionBoundsTextBoxes();

			ResumeEventsHandling();
		}

		private void drawingScaleComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();

			NDrawingScale scale = (drawingScaleComboBox.SelectedItem as NDrawingScale);

			// update the drawing scale
			document.MeasurementUnit = scale.MeasurementUnit;
			document.CustomWorldMeasurementUnit = scale.WorldMeasurementUnit;
			document.CustomScale = scale.ScaleFactor;

			// update the document bounds text boxes
			UpdateDocumentBoundsTextBoxes();

			// update the selection bounds text boxes
			UpdateSelectionBoundsTextBoxes();

			ResumeEventsHandling();
		}


		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			UpdateSelectionBoundsTextBoxes(); 
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			UpdateSelectionBoundsTextBoxes(); 
		}

		private void EventSinkService_NodeBoundsChanged(NNodeEventArgs args)
		{
			UpdateSelectionBoundsTextBoxes(); 
		}

		
		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label7;
		private Nevron.UI.WinForm.Controls.NTextBox drawingScaleTextBox;
		private Nevron.UI.WinForm.Controls.NComboBox drawingScaleSystemComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox drawingScaleComboBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NTextBox selectionWidthTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox selectionHeightTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox selectionTopTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox selectionLeftTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NTextBox documentMeasurementUnitTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox worldMeasurmentUnitTextBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private Nevron.UI.WinForm.Controls.NTextBox documentWidthTextBox;
		private Nevron.UI.WinForm.Controls.NTextBox documentHeightTextBox;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NGroupBox drawingScaleGroupBox;
		private Nevron.UI.WinForm.Controls.NGroupBox selectionBoundsGroupBox;
		private Nevron.UI.WinForm.Controls.NGroupBox scaleSystemsGroupBox;
		private Nevron.UI.WinForm.Controls.NGroupBox documentSizeGroupBox;

		#endregion
	}

	/// <summary>
	/// Enumerates the predefined drawing scale systems
	/// </summary>
	public enum DrawingScaleSystemType
	{
		Architectural,
		CivilEngineering,
		Metric,
		MechanicalEngineering,
	}

	/// <summary>
	/// Summary description for NDrawingScaleSystem.
	/// </summary>
	public class NDrawingScaleSystem
	{
		#region Constructors

		/// <summary>
		/// Initializer constructor
		/// </summary>
		/// <param name="system"></param>
		public NDrawingScaleSystem(DrawingScaleSystemType systemType)
		{
			Type = systemType;

			switch (systemType)
			{
				case DrawingScaleSystemType.Architectural:
					InitArchitectural();
					break;

				case DrawingScaleSystemType.CivilEngineering:
					InitCivilEngineering();
					break;

				case DrawingScaleSystemType.Metric:
					InitMetric();
					break;

				case DrawingScaleSystemType.MechanicalEngineering:
					InitMechanicalEngineering();
					break;

				default:
					Debug.Assert(false, "New drawing scale system?");
					break;
			}
		}


		#endregion

		#region Protected

		private void InitArchitectural()
		{
			Name = "Architectural";

			DrawingScales = new NDrawingScale[]
			{
				new NDrawingScale("3/32\" = 1\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.09375f, false),
				new NDrawingScale("1/8\" = 1\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.125f, false),
				new NDrawingScale("3/16\" = 1\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.1875f, false),
				new NDrawingScale("1/4\" = 1\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.25f, false),
				new NDrawingScale("3/8\" = 1\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.375f, false),
				new NDrawingScale("1/2\" = 1\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.5f, true),
				new NDrawingScale("3/4\" = 1\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.75f, false),
				new NDrawingScale("1\" = 1\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 1f, false),
				new NDrawingScale("1 1/2\" = 1\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 1.5f, false),
				new NDrawingScale("3\" = 1\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 3f, false),
				new NDrawingScale("1\' = 1\'0\"", NEnglishUnit.Foot, NEnglishUnit.Foot, 1f, false)
			};
		}
		
		private void InitCivilEngineering()
		{
			Name = "Civil Engineering";

			DrawingScales = new NDrawingScale[]
			{
				new NDrawingScale("1\" = 100\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.01f, false),
				new NDrawingScale("1\" = 90\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.0111111111f, false),
				new NDrawingScale("1\" = 80\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.0125f, false),
				new NDrawingScale("1\" = 70\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.0142857143f, false),
				new NDrawingScale("1\" = 60\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.01666666667f, false),
				new NDrawingScale("1\" = 50\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.02f, false),
				new NDrawingScale("1\" = 40\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.025f, false),
				new NDrawingScale("1\" = 30\'0\"", NEnglishUnit.Inch, NEnglishUnit.Foot, 0.03333333333f, true),
				new NDrawingScale("1\" = 20\'0\"",  NEnglishUnit.Inch, NEnglishUnit.Foot, 0.05f, false),
				new NDrawingScale("1\" = 10\'0\"",  NEnglishUnit.Inch, NEnglishUnit.Foot, 0.1f, false),
				new NDrawingScale("1\" = 1\"",  NEnglishUnit.Inch, NEnglishUnit.Foot, 12, false)
			};
		}
		
		private void InitMetric()
		{
			Name = "Metric";

			DrawingScales = new NDrawingScale[]
			{
				new NDrawingScale("1:1000", NMetricUnit.Millimeter, NMetricUnit.Meter, 1f, true),
				new NDrawingScale("1:500", NMetricUnit.Millimeter, NMetricUnit.Meter, 2f, false),
				new NDrawingScale("1:200", NMetricUnit.Millimeter, NMetricUnit.Meter, 5f, false),
				new NDrawingScale("1:100", NMetricUnit.Centimeter, NMetricUnit.Meter, 1f, false),
				new NDrawingScale("1:50", NMetricUnit.Centimeter, NMetricUnit.Meter, 2f, false),
				new NDrawingScale("1:25", NMetricUnit.Centimeter, NMetricUnit.Meter, 4f, false),
				new NDrawingScale("1:20", NMetricUnit.Centimeter, NMetricUnit.Meter, 5f, false),
				new NDrawingScale("1:10", NMetricUnit.Centimeter, NMetricUnit.Meter, 10f, false),
				new NDrawingScale("1:5", NMetricUnit.Centimeter, NMetricUnit.Meter, 20f, false),
				new NDrawingScale("1:2.5", NMetricUnit.Centimeter, NMetricUnit.Meter, 40f, false),
				new NDrawingScale("1:2", NMetricUnit.Centimeter, NMetricUnit.Meter, 50f, false),
				new NDrawingScale("1:1", NMetricUnit.Meter, NMetricUnit.Meter, 1f, false),
				new NDrawingScale("10:1", NMetricUnit.Meter, NMetricUnit.Meter, 10f, false),
				new NDrawingScale("20:1", NMetricUnit.Meter, NMetricUnit.Meter, 20f, false),
				new NDrawingScale("50:1", NMetricUnit.Meter, NMetricUnit.Meter, 50f, false),
				new NDrawingScale("100:1", NMetricUnit.Meter, NMetricUnit.Meter, 100f, false),
			};
		}
		
		private void InitMechanicalEngineering()
		{
			Name = "Mechanical Engineering";

			DrawingScales = new NDrawingScale[]
			{
				new NDrawingScale("1/32:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 0.03125f, false),
				new NDrawingScale("1/16:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 0.0625f, false),
				new NDrawingScale("1/8:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 0.125f, false),
				new NDrawingScale("1/4:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 0.25f, false),
				new NDrawingScale("1/2:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 0.5f, false),
				new NDrawingScale("1:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 1.0f, true),
				new NDrawingScale("2:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 2.0f, false),
				new NDrawingScale("4:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 4.0f, false),
				new NDrawingScale("6:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 6.0f, false),
				new NDrawingScale("8:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 8.0f, false),
				new NDrawingScale("10:1", NMetricUnit.Millimeter, NMetricUnit.Millimeter, 10.0f, false),
			};
		}
		

		#endregion

		#region Overrides

		public override string ToString()
		{
			return Name;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the default drawing scale for this system
		/// </summary>
		public NDrawingScale DefaultDrawingScale
		{
			get
			{
				for (int i = 0; i < DrawingScales.Length; i++)
				{
					NDrawingScale drawingScale = DrawingScales[i];
					if (drawingScale.IsDefault)
					{
						return drawingScale;
					}
				}

				return DrawingScales[0];
			}
		}

		
		#endregion

		#region Fields

		/// <summary>
		/// System type
		/// </summary>
		public DrawingScaleSystemType Type;
		/// <summary>
		/// System name
		/// </summary>
		public string Name;
		/// <summary>
		/// Drawing scales
		/// </summary>
		public NDrawingScale[] DrawingScales;

		#endregion
	}

	/// <summary>
	/// The NDrawingScale class represents a drawing scale in the context of a predefined drawing scale system
	/// </summary>
	public class NDrawingScale
	{
		#region Constructors
		
		/// <summary>
		/// Initializer constructor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="worldMeasurementUnit"></param>
		/// <param name="measurementUnit"></param>
		/// <param name="factor"></param>
		/// <param name="isDefault"></param>
		public NDrawingScale(string name, NMeasurementUnit worldMeasurementUnit, NMeasurementUnit measurementUnit, float factor, bool isDefault)
		{
			Name = name;
			MeasurementUnit = measurementUnit;
			WorldMeasurementUnit = worldMeasurementUnit;
			ScaleFactor = factor;
			IsDefault = isDefault;
		}


		#endregion
	
		#region Overrides

		public override string ToString()
		{
			return Name;
		}

		
		#endregion

		#region Fields

		/// <summary>
		/// Name
		/// </summary>
		public string Name;
		/// <summary>
		/// Logical measurement unit
		/// </summary>
		public NMeasurementUnit MeasurementUnit;
		/// <summary>
		/// Display measurement unit
		/// </summary>
		public NMeasurementUnit WorldMeasurementUnit;
		/// <summary>
		/// Scale factor (ratio between logical and display units)
		/// </summary>
		public float ScaleFactor;
		/// <summary>
		/// Whether this is the default scale for the system in which the scale resides
		/// </summary>
		public bool IsDefault;

		#endregion
	}
}
