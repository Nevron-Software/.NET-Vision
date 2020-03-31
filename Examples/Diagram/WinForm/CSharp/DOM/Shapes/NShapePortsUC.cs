using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.Editors;
using Nevron.Filters;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NShapePortsUC.
	/// </summary>
	public class NShapePortsUC : NDiagramExampleUC
	{
		#region Constructor

		public NShapePortsUC(NMainForm form) : base(form)
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
			this.portOperationsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.disconnectPortButton = new Nevron.UI.WinForm.Controls.NButton();
			this.portPropertiesGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.anchorIdComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.portOffsetYNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.portOffsetXNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.percentPositionNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.alignmentComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dynamicPortGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.dynamicPortGlueModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.boundsPortGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.pointPortGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.customPointIndexNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.portIndexModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.logicalLinePortGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.portOperationsGroup.SuspendLayout();
			this.portPropertiesGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.portOffsetYNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.portOffsetXNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.percentPositionNumeric)).BeginInit();
			this.dynamicPortGroup.SuspendLayout();
			this.boundsPortGroup.SuspendLayout();
			this.pointPortGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.customPointIndexNumeric)).BeginInit();
			this.logicalLinePortGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// portOperationsGroup
			// 
			this.portOperationsGroup.Controls.Add(this.disconnectPortButton);
			this.portOperationsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.portOperationsGroup.Enabled = false;
			this.portOperationsGroup.ImageIndex = 0;
			this.portOperationsGroup.Location = new System.Drawing.Point(0, 0);
			this.portOperationsGroup.Name = "portOperationsGroup";
			this.portOperationsGroup.Size = new System.Drawing.Size(250, 64);
			this.portOperationsGroup.TabIndex = 0;
			this.portOperationsGroup.TabStop = false;
			this.portOperationsGroup.Text = "Port operations";
			// 
			// disconnectPortButton
			// 
			this.disconnectPortButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.disconnectPortButton.Location = new System.Drawing.Point(8, 24);
			this.disconnectPortButton.Name = "disconnectPortButton";
			this.disconnectPortButton.Size = new System.Drawing.Size(234, 24);
			this.disconnectPortButton.TabIndex = 0;
			this.disconnectPortButton.Text = "Disconnect All Plugs";
			this.disconnectPortButton.Click += new System.EventHandler(this.disconnectPortButton_Click);
			// 
			// portPropertiesGroup
			// 
			this.portPropertiesGroup.Controls.Add(this.label3);
			this.portPropertiesGroup.Controls.Add(this.anchorIdComboBox);
			this.portPropertiesGroup.Controls.Add(this.portOffsetYNumeric);
			this.portPropertiesGroup.Controls.Add(this.label7);
			this.portPropertiesGroup.Controls.Add(this.label8);
			this.portPropertiesGroup.Controls.Add(this.portOffsetXNumeric);
			this.portPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.portPropertiesGroup.Enabled = false;
			this.portPropertiesGroup.ImageIndex = 0;
			this.portPropertiesGroup.Location = new System.Drawing.Point(0, 64);
			this.portPropertiesGroup.Name = "portPropertiesGroup";
			this.portPropertiesGroup.Size = new System.Drawing.Size(250, 112);
			this.portPropertiesGroup.TabIndex = 1;
			this.portPropertiesGroup.TabStop = false;
			this.portPropertiesGroup.Text = "Common port properties";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Port anchor:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// anchorIdComboBox
			// 
			this.anchorIdComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.anchorIdComboBox.Location = new System.Drawing.Point(80, 24);
			this.anchorIdComboBox.Name = "anchorIdComboBox";
			this.anchorIdComboBox.Size = new System.Drawing.Size(160, 22);
			this.anchorIdComboBox.TabIndex = 1;
			this.anchorIdComboBox.Text = "nComboBox1";
			this.anchorIdComboBox.SelectedIndexChanged += new System.EventHandler(this.anchorIdComboBox_SelectedIndexChanged);
			// 
			// portOffsetYNumeric
			// 
			this.portOffsetYNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.portOffsetYNumeric.Location = new System.Drawing.Point(150, 80);
			this.portOffsetYNumeric.Maximum = new System.Decimal(new int[] {
																			   10000,
																			   0,
																			   0,
																			   0});
			this.portOffsetYNumeric.Minimum = new System.Decimal(new int[] {
																			   10000,
																			   0,
																			   0,
																			   -2147483648});
			this.portOffsetYNumeric.Name = "portOffsetYNumeric";
			this.portOffsetYNumeric.Size = new System.Drawing.Size(90, 22);
			this.portOffsetYNumeric.TabIndex = 6;
			this.portOffsetYNumeric.ValueChanged += new System.EventHandler(this.portOffsetYNumeric_ValueChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(80, 80);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 23);
			this.label7.TabIndex = 5;
			this.label7.Text = "Offset Y:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(80, 56);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 23);
			this.label8.TabIndex = 3;
			this.label8.Text = "Offset X:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// portOffsetXNumeric
			// 
			this.portOffsetXNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.portOffsetXNumeric.Location = new System.Drawing.Point(150, 56);
			this.portOffsetXNumeric.Maximum = new System.Decimal(new int[] {
																			   10000,
																			   0,
																			   0,
																			   0});
			this.portOffsetXNumeric.Minimum = new System.Decimal(new int[] {
																			   10000,
																			   0,
																			   0,
																			   -2147483648});
			this.portOffsetXNumeric.Name = "portOffsetXNumeric";
			this.portOffsetXNumeric.Size = new System.Drawing.Size(90, 22);
			this.portOffsetXNumeric.TabIndex = 4;
			this.portOffsetXNumeric.ValueChanged += new System.EventHandler(this.portOffsetXNumeric_ValueChanged);
			// 
			// percentPositionNumeric
			// 
			this.percentPositionNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.percentPositionNumeric.Location = new System.Drawing.Point(112, 24);
			this.percentPositionNumeric.Name = "percentPositionNumeric";
			this.percentPositionNumeric.Size = new System.Drawing.Size(128, 22);
			this.percentPositionNumeric.TabIndex = 1;
			this.percentPositionNumeric.ValueChanged += new System.EventHandler(this.percentPositionNumeric_ValueChanged);
			// 
			// alignmentComboBox
			// 
			this.alignmentComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.alignmentComboBox.Location = new System.Drawing.Point(80, 24);
			this.alignmentComboBox.Name = "alignmentComboBox";
			this.alignmentComboBox.Size = new System.Drawing.Size(160, 22);
			this.alignmentComboBox.TabIndex = 1;
			this.alignmentComboBox.Text = "nComboBox1";
			this.alignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.alignmentComboBox_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Alignment:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 23);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "Percent position:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dynamicPortGroup
			// 
			this.dynamicPortGroup.Controls.Add(this.label6);
			this.dynamicPortGroup.Controls.Add(this.dynamicPortGlueModeCombo);
			this.dynamicPortGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.dynamicPortGroup.ImageIndex = 0;
			this.dynamicPortGroup.Location = new System.Drawing.Point(0, 176);
			this.dynamicPortGroup.Name = "dynamicPortGroup";
			this.dynamicPortGroup.Size = new System.Drawing.Size(250, 64);
			this.dynamicPortGroup.TabIndex = 2;
			this.dynamicPortGroup.TabStop = false;
			this.dynamicPortGroup.Text = "Dynamic port properties";
			this.dynamicPortGroup.Visible = false;
			// 
			// dynamicPortGlueModeCombo
			// 
			this.dynamicPortGlueModeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dynamicPortGlueModeCombo.Location = new System.Drawing.Point(80, 24);
			this.dynamicPortGlueModeCombo.Name = "dynamicPortGlueModeCombo";
			this.dynamicPortGlueModeCombo.Size = new System.Drawing.Size(160, 22);
			this.dynamicPortGlueModeCombo.TabIndex = 1;
			this.dynamicPortGlueModeCombo.Text = "Glue To Countour";
			this.dynamicPortGlueModeCombo.SelectedIndexChanged += new System.EventHandler(this.dynamicPortGlueModeCombo_SelectedIndexChanged);
			// 
			// boundsPortGroup
			// 
			this.boundsPortGroup.Controls.Add(this.label4);
			this.boundsPortGroup.Controls.Add(this.alignmentComboBox);
			this.boundsPortGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.boundsPortGroup.ImageIndex = 0;
			this.boundsPortGroup.Location = new System.Drawing.Point(0, 240);
			this.boundsPortGroup.Name = "boundsPortGroup";
			this.boundsPortGroup.Size = new System.Drawing.Size(250, 64);
			this.boundsPortGroup.TabIndex = 3;
			this.boundsPortGroup.TabStop = false;
			this.boundsPortGroup.Text = "Bounds/rotated bounds port properties";
			this.boundsPortGroup.Visible = false;
			// 
			// pointPortGroup
			// 
			this.pointPortGroup.Controls.Add(this.customPointIndexNumeric);
			this.pointPortGroup.Controls.Add(this.portIndexModeComboBox);
			this.pointPortGroup.Controls.Add(this.label1);
			this.pointPortGroup.Controls.Add(this.label2);
			this.pointPortGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.pointPortGroup.ImageIndex = 0;
			this.pointPortGroup.Location = new System.Drawing.Point(0, 304);
			this.pointPortGroup.Name = "pointPortGroup";
			this.pointPortGroup.Size = new System.Drawing.Size(250, 88);
			this.pointPortGroup.TabIndex = 4;
			this.pointPortGroup.TabStop = false;
			this.pointPortGroup.Text = "Point port properties";
			this.pointPortGroup.Visible = false;
			// 
			// customPointIndexNumeric
			// 
			this.customPointIndexNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.customPointIndexNumeric.Location = new System.Drawing.Point(112, 56);
			this.customPointIndexNumeric.Maximum = new System.Decimal(new int[] {
																					10000,
																					0,
																					0,
																					0});
			this.customPointIndexNumeric.Minimum = new System.Decimal(new int[] {
																					1,
																					0,
																					0,
																					-2147483648});
			this.customPointIndexNumeric.Name = "customPointIndexNumeric";
			this.customPointIndexNumeric.Size = new System.Drawing.Size(128, 22);
			this.customPointIndexNumeric.TabIndex = 3;
			this.customPointIndexNumeric.ValueChanged += new System.EventHandler(this.customPointIndexNumeric_ValueChanged);
			// 
			// portIndexModeComboBox
			// 
			this.portIndexModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.portIndexModeComboBox.Location = new System.Drawing.Point(112, 24);
			this.portIndexModeComboBox.Name = "portIndexModeComboBox";
			this.portIndexModeComboBox.Size = new System.Drawing.Size(128, 22);
			this.portIndexModeComboBox.TabIndex = 1;
			this.portIndexModeComboBox.Text = "nComboBox1";
			this.portIndexModeComboBox.SelectedIndexChanged += new System.EventHandler(this.portIndexModeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Port index mode:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Custom point index:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// logicalLinePortGroup
			// 
			this.logicalLinePortGroup.Controls.Add(this.percentPositionNumeric);
			this.logicalLinePortGroup.Controls.Add(this.label5);
			this.logicalLinePortGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.logicalLinePortGroup.ImageIndex = 0;
			this.logicalLinePortGroup.Location = new System.Drawing.Point(0, 392);
			this.logicalLinePortGroup.Name = "logicalLinePortGroup";
			this.logicalLinePortGroup.Size = new System.Drawing.Size(250, 56);
			this.logicalLinePortGroup.TabIndex = 5;
			this.logicalLinePortGroup.TabStop = false;
			this.logicalLinePortGroup.Text = "Logical line port properties";
			this.logicalLinePortGroup.Visible = false;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 2;
			this.label6.Text = "Glue mode:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NShapePortsUC
			// 
			this.Controls.Add(this.logicalLinePortGroup);
			this.Controls.Add(this.pointPortGroup);
			this.Controls.Add(this.boundsPortGroup);
			this.Controls.Add(this.dynamicPortGroup);
			this.Controls.Add(this.portPropertiesGroup);
			this.Controls.Add(this.portOperationsGroup);
			this.Name = "NShapePortsUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.portOperationsGroup, 0);
			this.Controls.SetChildIndex(this.portPropertiesGroup, 0);
			this.Controls.SetChildIndex(this.dynamicPortGroup, 0);
			this.Controls.SetChildIndex(this.boundsPortGroup, 0);
			this.Controls.SetChildIndex(this.pointPortGroup, 0);
			this.Controls.SetChildIndex(this.logicalLinePortGroup, 0);
			this.portOperationsGroup.ResumeLayout(false);
			this.portPropertiesGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.portOffsetYNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.portOffsetXNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.percentPositionNumeric)).EndInit();
			this.dynamicPortGroup.ResumeLayout(false);
			this.boundsPortGroup.ResumeLayout(false);
			this.pointPortGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.customPointIndexNumeric)).EndInit();
			this.logicalLinePortGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			base.DefaultGridOrigin = new NPointF(30, 30);
			base.DefaultGridCellSize = new NSizeF(70, 70);
			base.DefaultGridSpacing = new NSizeF(50, 10);

			// begin view init
			view.BeginInit();

			// init view
			view.Grid.Visible = false;

			NSizeF handlesSize = new NSizeF(5, 5);
			view.TrackersAppearance.RotatedBoundsHandlesStyle.Size = handlesSize;
			view.TrackersAppearance.RotatorHandlesStyle.Size = handlesSize;
			view.TrackersAppearance.PinHandlesStyle.Size = handlesSize;
			view.TrackersAppearance.GeometryBasePointHandlesStyle.Size = handlesSize;
			view.TrackersAppearance.GeometryMidPointHandlesStyle.Size = handlesSize;
			view.TrackersAppearance.ShapeControlPointHandlesStyle.Size = handlesSize;
			view.TrackersAppearance.ShapeStartPlugHandlesStyle.Size = handlesSize;
			view.TrackersAppearance.ShapeEndPlugHandlesStyle.Size = handlesSize;

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

			alignmentComboBox.FillFromEnum(typeof(ContentAlignment));
			alignmentComboBox.SelectedItem = ContentAlignment.TopLeft;

			portIndexModeComboBox.FillFromEnum(typeof(PointIndexMode));
			portIndexModeComboBox.SelectedItem = PointIndexMode.First;

			dynamicPortGlueModeCombo.FillFromEnum(typeof(DynamicPortGlueMode));
			dynamicPortGlueModeCombo.SelectedItem = DynamicPortGlueMode.GlueToContour;

			ResumeEventsHandling();
		}

		private void InitDocument()
		{
			// change the document style
			NStyle style = document.Style;
			style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 0x66, 0x66, 0));
			style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(0x11, 0x11, 0));
			style.TextStyle.FontStyle = new NFontStyle(new Font("Arial", 9));
			style.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(0x2a, 0x20, 0x00));
			style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
			style.StartArrowheadStyle.StrokeStyle = document.Style.StrokeStyle.Clone() as NStrokeStyle;
			style.EndArrowheadStyle.StrokeStyle = document.Style.StrokeStyle.Clone() as NStrokeStyle;

			// create the shapes
			CreateCenterShape();
			CreateShapeWithDynamicPort();
			CreateShapeWithBoundsPort();
			CreateShapeWithRotatedBoundsPort();
			CreateShapeWithPointPort();
			CreateShapeWithLogicalLinePort();
			CreateArrowShapeWithLogicalLinePort();
		}


		private void CreateCenterShape()
		{
			// create the center shape to which all other shapes connect
			NRectangleF cell = base.GetGridCell(3, 0);
			cell.Inflate(-5, -5);

			NEllipseShape shape = new NEllipseShape(cell);
			shape.Name = "Center shape";
			
			shape.Style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 0, 0xbb, 0));
			shape.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(0, 0xbb, 0));

			shape.CreateShapeElements(ShapeElementsMask.Ports);

			NDynamicPort port = new NDynamicPort(shape.UniqueId, ContentAlignment.MiddleCenter, DynamicPortGlueMode.GlueToContour);
			shape.Ports.AddChild(port);
			shape.Ports.DefaultInwardPortUniqueId = port.UniqueId;

			// add it to the active layer and store for reuse
			document.ActiveLayer.AddChild(shape);
			centerShape = shape;
		}

		private void CreateShapeWithDynamicPort()
		{
			// NOTE: the triangle shape is by default created with one dynamic port (the default one) and 
			// three rotated bounds ports located at the triangle vertices).
			NBasicShapesFactory factory = new NBasicShapesFactory(document);
			NShape shape = factory.CreateShape((int)BasicShapes.Triangle);
			shape.Name = "Shape with Dynamic Port";
			shape.Bounds = base.GetGridCell(0, 1);
		
			// connect it with the center shape
			document.ActiveLayer.AddChild(shape);
			ConnectShapes(centerShape, shape);

			// describe it
			NTextShape text = new NTextShape("Shape with Dynamic Port", base.GetGridCell(0, 2, 0, 1));
			document.ActiveLayer.AddChild(text);
		}

		private void CreateShapeWithBoundsPort()
		{
			// create a shape with one bounds port
			NRectangleShape shape = new NRectangleShape(base.GetGridCell(1, 1));
			shape.Name = "Shape with Bounds Port";
			
			shape.CreateShapeElements(ShapeElementsMask.Ports);

			NBoundsPort port = new NBoundsPort(shape.UniqueId, ContentAlignment.TopLeft);
			shape.Ports.AddChild(port);
			shape.Ports.DefaultInwardPortUniqueId = port.UniqueId;
			
			// connect it with the center shape
			document.ActiveLayer.AddChild(shape);
			ConnectShapes(centerShape, shape);
		
			// describe it
			NTextShape text = new NTextShape("Shape with Bounds Port", base.GetGridCell(1, 2, 0, 1));
			document.ActiveLayer.AddChild(text);
		}

		private void CreateShapeWithRotatedBoundsPort()
		{
			// create a shape with one rotated bounds port
			NRectangleShape shape = new NRectangleShape(base.GetGridCell(2, 1));
			shape.Name = "Shape with Rotated Bounds Port";
			
			shape.CreateShapeElements(ShapeElementsMask.Ports);

			NRotatedBoundsPort port = new NRotatedBoundsPort(shape.UniqueId, ContentAlignment.TopLeft);
			shape.Ports.AddChild(port);
			shape.Ports.DefaultInwardPortUniqueId = port.UniqueId;
			
			// connect it with the center shape
			document.ActiveLayer.AddChild(shape);
			ConnectShapes(centerShape, shape);

			// describe it
			NTextShape text = new NTextShape("Shape with Rotated Bounds Port", base.GetGridCell(2, 2, 0, 1));
			document.ActiveLayer.AddChild(text);
		}

		private void CreateShapeWithPointPort()
		{
			// create a shape with one point port
			NBasicShapesFactory factory = new NBasicShapesFactory(document);
			NShape shape = factory.CreateShape((int)BasicShapes.Pentagram);
			
			shape.Name = "Shape with a Point Port";
			shape.Bounds = base.GetGridCell(4, 1);
			
			NPointPort port = new NPointPort(shape.UniqueId, PointIndexMode.Second, -1);

			shape.Ports.RemoveAllChildren();
			shape.Ports.AddChild(port);
			shape.Ports.DefaultInwardPortUniqueId = port.UniqueId;
			
			// connect it with the center shape
			document.ActiveLayer.AddChild(shape);
			ConnectShapes(centerShape, shape);

			// describe it
			NTextShape text = new NTextShape("Shape with Point Port", base.GetGridCell(4, 2, 0, 1));
			document.ActiveLayer.AddChild(text);
		}

		private void CreateShapeWithLogicalLinePort()
		{
			NPointF[] points = new NPointF[]{	new NPointF(151, 291),
													new NPointF(151, 316),
													new NPointF(123, 336),
													new NPointF(151, 350),
													new NPointF(158, 319),
													new NPointF(180, 312)};
			
			// create a polyline shape with a logical line port
			NPolylineShape shape = new NPolylineShape(points);
			shape.Name = "Shape with a Logical Line Port";
			shape.Bounds = base.GetGridCell(5, 1);

			// create the ports
			shape.CreateShapeElements(ShapeElementsMask.Ports); 

			NLogicalLinePort port = new NLogicalLinePort(shape.UniqueId, 30);
			shape.Ports.RemoveAllChildren();
			shape.Ports.AddChild(port);
			shape.Ports.DefaultInwardPortUniqueId = port.UniqueId;
			
			// connect it with the center shape
			document.ActiveLayer.AddChild(shape);
			ConnectShapes(centerShape, shape);

			// descibte it
			NTextShape text = new NTextShape("Shape with Logical Line Port", base.GetGridCell(5, 2, 0, 1));
			document.ActiveLayer.AddChild(text);
		}

		private void CreateArrowShapeWithLogicalLinePort()
		{
			// create a filled graph connector with one logical line port
			NArrowShape shape = new NArrowShape(ArrowType.DoubleArrow, new NPointF(15, 380), new NPointF(55, 420), 10, 45, 30);
			shape.Bounds = base.GetGridCell(6, 1);
			shape.Name = "Filled shape with Stroke Port";

			// create the ports
			shape.CreateShapeElements(ShapeElementsMask.Ports);

			NLogicalLinePort port = new NLogicalLinePort(shape.UniqueId, 30);
			shape.Ports.RemoveAllChildren();
			shape.Ports.AddChild(port);
			shape.Ports.DefaultInwardPortUniqueId = port.UniqueId;
			
			// connect it with the center shape
			document.ActiveLayer.AddChild(shape);
			ConnectShapes(centerShape, shape);

			// descibte it
			NTextShape text = new NTextShape("Shape with Logical Line Port", base.GetGridCell(6, 2, 0, 1));
			document.ActiveLayer.AddChild(text);
		}


		private void ConnectShapes(NShape shape1, NShape shape2)
		{
			NStep2Connector connector = new NStep2Connector(true);
			connector.StyleSheetName = NDR.NameConnectorsStyleSheet;
			document.ActiveLayer.AddChild(connector);

			connector.FromShape = shape1;
			connector.ToShape = shape2;
		}

		private void UpdateControlsState()
		{
			// only single selection is processed
			if (view.Selection.Nodes.Count != 1)
			{
				DisablePortControls();
				return;
			}

			// check to see if the selected node is a shape and its defualt port is valid
			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null || shape.Ports == null || shape.Ports.DefaultInwardPort == null)
			{
				DisablePortControls();
				return;
			}

			// enable the common operations and properties groups
			portOperationsGroup.Enabled = true;
			portPropertiesGroup.Enabled = true;

			// get the shape default port
			NPort defaultPort = shape.Ports.DefaultInwardPort;

			// update the general port properties
			UpdatePortGeneralPropertiesControls(defaultPort);

			// update dynamic port specific
			if (defaultPort is NDynamicPort)
			{
				dynamicPortGroup.Visible = true;
				NDynamicPort port = defaultPort as NDynamicPort;
				dynamicPortGlueModeCombo.SelectedItem  = port.GlueMode;
			}
			else
			{
				dynamicPortGroup.Visible = false;
			}

			// update bounds port specific
			if (defaultPort is NBoundsPort || defaultPort is NRotatedBoundsPort)
			{
				boundsPortGroup.Visible = true;
				if (defaultPort is NBoundsPort)
				{
					alignmentComboBox.SelectedItem = (defaultPort as NBoundsPort).Alignment;
				}
				else
				{
					alignmentComboBox.SelectedItem = (defaultPort as NRotatedBoundsPort).Alignment;
				}
			}
			else
			{
				boundsPortGroup.Visible = false;
			}

			// update point port specific
			if (defaultPort is NPointPort)
			{
				pointPortGroup.Visible = true;
				portIndexModeComboBox.SelectedItem = (defaultPort as NPointPort).PointIndexMode;
				customPointIndexNumeric.Value = (defaultPort as NPointPort).CustomPointIndex;
			}
			else
			{
				pointPortGroup.Visible = false;
			}

			// update logical line port specific
			if (defaultPort is NLogicalLinePort)
			{
				logicalLinePortGroup.Visible = true;
				percentPositionNumeric.Value = (decimal)(defaultPort as NLogicalLinePort).Percent;
			}
			else
			{
				logicalLinePortGroup.Visible = false;
			}
		}

		private void UpdatePortGeneralPropertiesControls(NPort port)
		{
			// can only disconnect the port if it is connected to any plugs
			disconnectPortButton.Enabled = (port.Plugs.Count != 0);

			// update port offset
			NSizeF offset = port.Offset;
			portOffsetXNumeric.Value = (decimal)offset.Width;
			portOffsetYNumeric.Value = (decimal)offset.Height;

			// populate the combo with available anchors
			INDiagramElementContainer searchRoot = port.GetRootForReferenceProperty("AnchorUniqueId");
			NFilter filter = port.GetFilterForReferenceProperty("AnchorUniqueId");

			NNodeList anchors = searchRoot.Descendants(null, -1);
			anchors.Insert(0, searchRoot);
			anchors = anchors.Filter(filter);

			anchorIdComboBox.Items.Clear();
			anchorIdComboBox.Items.AddRange((object[])(anchors.ToArray(typeof(object))));
			
			// select the currently chosen anchor
			for (int i = 0; i < anchorIdComboBox.Items.Count; i ++)
			{
				Guid elemendGuid = (anchorIdComboBox.Items[i].Tag as INDiagramElement).UniqueId;
				if (elemendGuid.Equals(port.AnchorUniqueId))
				{
					anchorIdComboBox.SelectedIndex = i;
					break;
				}
			}
		}

		private void DisablePortControls()
		{
			portOperationsGroup.Enabled = false;
			portPropertiesGroup.Enabled = false;
			
			dynamicPortGroup.Visible = false;
			boundsPortGroup.Visible = false;
			logicalLinePortGroup.Visible = false;
			pointPortGroup.Visible = false;
		}


		#endregion

		#region Form Event Handlers

		private void disconnectPortButton_Click(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected shape
			NShape shape = view.Selection.AnchorNode as NShape;
			if (shape == null || shape.Ports == null || shape.Ports.DefaultInwardPort == null)
				return;

			PauseEventsHandling();
			
			// disconnect the default port
			shape.Ports.DefaultInwardPort.Disconnect();
			disconnectPortButton.Enabled = false;
			
			ResumeEventsHandling();
			document.SmartRefreshAllViews();
		}

		private void anchorIdComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected shape
			NShape shape = view.Selection.AnchorNode as NShape;
			if (shape == null || shape.Ports == null || shape.Ports.DefaultInwardPort == null)
				return;

			PauseEventsHandling();
			
			// anchor the default port to the selected element
			NPort port = shape.Ports.DefaultInwardPort as NPort;
			if (anchorIdComboBox.SelectedIndex == -1)
			{
				port.AnchorUniqueId = Guid.Empty;
			}
			else
			{
				port.AnchorUniqueId = (anchorIdComboBox.SelectedItem as NDiagramElement).UniqueId;
			}
			
			ResumeEventsHandling();
			document.SmartRefreshAllViews();
		}

		private void portOffsetXNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected shape
			NShape shape = view.Selection.AnchorNode as NShape;
			if (shape == null || shape.Ports == null || shape.Ports.DefaultInwardPort == null)
				return;

			PauseEventsHandling();
			
			// change the port X offset
			NPort port = shape.Ports.DefaultInwardPort as NPort;
			port.Offset = new NSizeF((float)portOffsetXNumeric.Value, port.Offset.Height);

			ResumeEventsHandling();
			document.SmartRefreshAllViews();
		}

		private void portOffsetYNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected shape
			NShape shape = view.Selection.AnchorNode as NShape;
			if (shape == null || shape.Ports == null || shape.Ports.DefaultInwardPort == null)
				return;

			PauseEventsHandling();
			
			// change the port Y offset
			NPort port = shape.Ports.DefaultInwardPort as NPort;
			port.Offset = new NSizeF(port.Offset.Width, (float)portOffsetYNumeric.Value);

			ResumeEventsHandling();
			document.SmartRefreshAllViews();
		}

		private void dynamicPortGlueModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected shape
			NShape shape = view.Selection.AnchorNode as NShape;
			if (shape == null || shape.Ports == null)
				return;

			// get a dynamic port
			NDynamicPort port = shape.Ports.DefaultInwardPort as NDynamicPort;
			if (port == null)
				return;

			PauseEventsHandling();
			
			// change the port glue mode
			port.GlueMode = (DynamicPortGlueMode)dynamicPortGlueModeCombo.SelectedItem;

			ResumeEventsHandling();
			document.SmartRefreshAllViews();
		}

		private void alignmentComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (alignmentComboBox.SelectedItem == null)
				return;

			if (EventsHandlingPaused)
				return;

			// get the selected shape
			NShape shape = view.Selection.AnchorNode as NShape;
			if (shape == null || shape.Ports == null)
				return;

			PauseEventsHandling();
			
			// alter the alignment of a bounds or rotated bounds port
			NBoundsPort boundsPort = shape.Ports.DefaultInwardPort as NBoundsPort;
			if (boundsPort != null)
			{
				boundsPort.Alignment = new NContentAlignment((ContentAlignment)alignmentComboBox.SelectedItem);
			}
			else 
			{
				NRotatedBoundsPort rotatedBoundsPort = (shape.Ports.DefaultInwardPort as NRotatedBoundsPort);
				if (rotatedBoundsPort != null)
				{
					rotatedBoundsPort.Alignment = new NContentAlignment((ContentAlignment)alignmentComboBox.SelectedItem);
				}
			}

			ResumeEventsHandling();
			document.SmartRefreshAllViews();
		}

		private void portIndexModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (portIndexModeComboBox.SelectedItem == null)
				return;
			
			if (EventsHandlingPaused)
				return;

			// get the selected shape
			NShape shape = view.Selection.AnchorNode as NShape;
			if (shape == null || shape.Ports == null)
				return;

			// get a point port
			NPointPort port = (shape.Ports.DefaultInwardPort as NPointPort);
			if (port == null)
				return;

			PauseEventsHandling();

			// change the point index mode of a point port
			port.PointIndexMode = (PointIndexMode)portIndexModeComboBox.SelectedItem;

			ResumeEventsHandling();
			document.SmartRefreshAllViews();
		}

		private void customPointIndexNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			if (EventsHandlingPaused)
				return;

			// get the selected shape
			NShape shape = view.Selection.AnchorNode as NShape;
			if (shape == null || shape.Ports == null)
				return;

			// get a point port
			NPointPort port = (shape.Ports.DefaultInwardPort as NPointPort);
			if (port == null)
				return;

			PauseEventsHandling();
		
			// change the custom point index of a point port
			port.CustomPointIndex = (int)customPointIndexNumeric.Value;
			
			ResumeEventsHandling();
			document.SmartRefreshAllViews();
		}

		private void percentPositionNumeric_ValueChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected shape
			NShape shape = view.Selection.AnchorNode as NShape;
			if (shape == null || shape.Ports == null)
				return;

			// get a logical line port
			NLogicalLinePort port = (shape.Ports.DefaultInwardPort as NLogicalLinePort);
			if (port == null)
				return;

			PauseEventsHandling();

            // change the percent position of a logical line port
			port.Percent = (float)percentPositionNumeric.Value;
			
			ResumeEventsHandling();
			document.SmartRefreshAllViews();
		}


		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();
			UpdateControlsState();
			ResumeEventsHandling();
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();
			UpdateControlsState();
			ResumeEventsHandling();
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		
		private Nevron.UI.WinForm.Controls.NButton disconnectPortButton;
		private Nevron.UI.WinForm.Controls.NNumericUpDown customPointIndexNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown percentPositionNumeric;
		private Nevron.UI.WinForm.Controls.NComboBox dynamicPortGlueModeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox portIndexModeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox anchorIdComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox alignmentComboBox;

		private Nevron.UI.WinForm.Controls.NGroupBox dynamicPortGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox boundsPortGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox pointPortGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox logicalLinePortGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox portOperationsGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox portPropertiesGroup;

		private Nevron.UI.WinForm.Controls.NNumericUpDown portOffsetYNumeric;
		private Nevron.UI.WinForm.Controls.NNumericUpDown portOffsetXNumeric;
		private System.Windows.Forms.Label label6;

		#endregion
		
		#region Fields

		private NShape centerShape = null;

		#endregion
	}
}