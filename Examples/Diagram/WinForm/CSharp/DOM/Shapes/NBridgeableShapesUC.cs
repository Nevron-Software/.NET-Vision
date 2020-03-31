using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Editors;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NBridgeableStrokeShapesUC.
	/// </summary>
	public class NBridgeableShapesUC : NDiagramExampleUC
	{
		#region Constructor

		public NBridgeableShapesUC(NMainForm form) : base(form)
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
			this.pointsCountNumeric = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.addRandomPolylineButton = new Nevron.UI.WinForm.Controls.NButton();
			this.bridgeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.randomNodesGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.addLineButton = new Nevron.UI.WinForm.Controls.NButton();
			this.selectedBridgeableStrokeGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.bridgeTargetsComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.enableBridgeManagerCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pointsCountNumeric)).BeginInit();
			this.randomNodesGroup.SuspendLayout();
			this.selectedBridgeableStrokeGroup.SuspendLayout();
			this.nGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pointsCountNumeric
			// 
			this.pointsCountNumeric.Location = new System.Drawing.Point(8, 57);
			this.pointsCountNumeric.Minimum = new System.Decimal(new int[] {
																			   2,
																			   0,
																			   0,
																			   0});
			this.pointsCountNumeric.Name = "pointsCountNumeric";
			this.pointsCountNumeric.Size = new System.Drawing.Size(72, 22);
			this.pointsCountNumeric.TabIndex = 23;
			this.pointsCountNumeric.Value = new System.Decimal(new int[] {
																			 3,
																			 0,
																			 0,
																			 0});
			// 
			// addRandomPolylineButton
			// 
			this.addRandomPolylineButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.addRandomPolylineButton.Location = new System.Drawing.Point(104, 24);
			this.addRandomPolylineButton.Name = "addRandomPolylineButton";
			this.addRandomPolylineButton.Size = new System.Drawing.Size(138, 23);
			this.addRandomPolylineButton.TabIndex = 20;
			this.addRandomPolylineButton.Text = "Add Polyline";
			this.addRandomPolylineButton.Click += new System.EventHandler(this.addRandomPolylineButton_Click);
			// 
			// bridgeStyleButton
			// 
			this.bridgeStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.bridgeStyleButton.Location = new System.Drawing.Point(8, 64);
			this.bridgeStyleButton.Name = "bridgeStyleButton";
			this.bridgeStyleButton.Size = new System.Drawing.Size(234, 23);
			this.bridgeStyleButton.TabIndex = 26;
			this.bridgeStyleButton.Text = "Bridge Style...";
			this.bridgeStyleButton.Click += new System.EventHandler(this.bridgeStyleButton_Click);
			// 
			// randomNodesGroup
			// 
			this.randomNodesGroup.Controls.Add(this.label1);
			this.randomNodesGroup.Controls.Add(this.pointsCountNumeric);
			this.randomNodesGroup.Controls.Add(this.addRandomPolylineButton);
			this.randomNodesGroup.Controls.Add(this.addLineButton);
			this.randomNodesGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.randomNodesGroup.ImageIndex = 0;
			this.randomNodesGroup.Location = new System.Drawing.Point(0, 0);
			this.randomNodesGroup.Name = "randomNodesGroup";
			this.randomNodesGroup.Size = new System.Drawing.Size(250, 96);
			this.randomNodesGroup.TabIndex = 28;
			this.randomNodesGroup.TabStop = false;
			this.randomNodesGroup.Text = "Add Random Bridgeable Shape";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 24;
			this.label1.Text = "Points count:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// addLineButton
			// 
			this.addLineButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.addLineButton.Location = new System.Drawing.Point(104, 56);
			this.addLineButton.Name = "addLineButton";
			this.addLineButton.Size = new System.Drawing.Size(138, 23);
			this.addLineButton.TabIndex = 22;
			this.addLineButton.Text = "Add Line";
			this.addLineButton.Click += new System.EventHandler(this.addLineButton_Click);
			// 
			// selectedBridgeableStrokeGroup
			// 
			this.selectedBridgeableStrokeGroup.Controls.Add(this.bridgeTargetsComboBox);
			this.selectedBridgeableStrokeGroup.Controls.Add(this.label2);
			this.selectedBridgeableStrokeGroup.Controls.Add(this.bridgeStyleButton);
			this.selectedBridgeableStrokeGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.selectedBridgeableStrokeGroup.Enabled = false;
			this.selectedBridgeableStrokeGroup.ImageIndex = 0;
			this.selectedBridgeableStrokeGroup.Location = new System.Drawing.Point(0, 96);
			this.selectedBridgeableStrokeGroup.Name = "selectedBridgeableStrokeGroup";
			this.selectedBridgeableStrokeGroup.Size = new System.Drawing.Size(250, 96);
			this.selectedBridgeableStrokeGroup.TabIndex = 29;
			this.selectedBridgeableStrokeGroup.TabStop = false;
			this.selectedBridgeableStrokeGroup.Text = "Selected Bridgeable Shape";
			// 
			// bridgeTargetsComboBox
			// 
			this.bridgeTargetsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.bridgeTargetsComboBox.Location = new System.Drawing.Point(104, 29);
			this.bridgeTargetsComboBox.Name = "bridgeTargetsComboBox";
			this.bridgeTargetsComboBox.Size = new System.Drawing.Size(138, 22);
			this.bridgeTargetsComboBox.TabIndex = 28;
			this.bridgeTargetsComboBox.Text = "nComboBox1";
			this.bridgeTargetsComboBox.SelectedIndexChanged += new System.EventHandler(this.bridgeTargetsComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 27;
			this.label2.Text = "Bridge Targets:";
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.enableBridgeManagerCheckBox);
			this.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(0, 192);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(250, 64);
			this.nGroupBox1.TabIndex = 30;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Bridge Manager";
			// 
			// enableBridgeManagerCheckBox
			// 
			this.enableBridgeManagerCheckBox.Location = new System.Drawing.Point(8, 24);
			this.enableBridgeManagerCheckBox.Name = "enableBridgeManagerCheckBox";
			this.enableBridgeManagerCheckBox.TabIndex = 0;
			this.enableBridgeManagerCheckBox.Text = "Enabled";
			this.enableBridgeManagerCheckBox.CheckedChanged += new System.EventHandler(this.enableBridgeManagerCheckBox_CheckedChanged);
			// 
			// NBridgeableShapesUC
			// 
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.selectedBridgeableStrokeGroup);
			this.Controls.Add(this.randomNodesGroup);
			this.Name = "NBridgeableShapesUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.randomNodesGroup, 0);
			this.Controls.SetChildIndex(this.selectedBridgeableStrokeGroup, 0);
			this.Controls.SetChildIndex(this.nGroupBox1, 0);
			((System.ComponentModel.ISupportInitialize)(this.pointsCountNumeric)).EndInit();
			this.randomNodesGroup.ResumeLayout(false);
			this.selectedBridgeableStrokeGroup.ResumeLayout(false);
			this.nGroupBox1.ResumeLayout(false);
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

			selectedBridgeableStrokeGroup.Enabled = false;
			bridgeTargetsComboBox.FillFromEnum(typeof(BridgeTargets));
			bridgeTargetsComboBox.SelectedItem = BridgeTargets.SelfAndOther;
			enableBridgeManagerCheckBox.Checked = document.BridgeManager.Enabled;

			ResumeEventsHandling();
		}

		private void InitDocument()
		{
			// change the document shadow 
			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur;
			document.Style.ShadowStyle.Offset = new NPointL(5, 5);

			// change the document bridge style
			document.Style.BridgeStyle = new NBridgeStyle(BridgeShape.Arc, new NSizeL(5, 5));

			// create the bridgeable shapes
			CreateSampleLine1();
			CreateSamplePolyline1();
			CreateSamplePolyline2();
			CreateSampleLine2();
			CreateSampleLineDoubleBridge();
		}

		private void CreateSampleLine1()
		{
			NLineShape line = new NLineShape(new NPointF(10, 130), new NPointF(250, 130));
			document.ActiveLayer.AddChild(line);

			line.Style = line.ComposeStyle().Clone() as NStyle;
			line.Style.StrokeStyle.Color = Color.BlueViolet;
			line.Style.StartArrowheadStyle.StrokeStyle.Color = Color.BlueViolet;
			line.Style.EndArrowheadStyle.StrokeStyle.Color = Color.BlueViolet;
			line.Style.BridgeStyle.Shape = BridgeShape.Square;
		}

		private void CreateSampleLine2()
		{
			NLineShape line = new NLineShape(new NPointF(10, 75), new NPointF(280, 75));
			document.ActiveLayer.AddChild(line);

			line.Style = line.ComposeStyle().Clone() as NStyle;
			line.Style.StrokeStyle.Color = Color.Orange;
			line.Style.StartArrowheadStyle.StrokeStyle.Color = Color.Orange;
			line.Style.EndArrowheadStyle.StrokeStyle.Color = Color.Orange;
			line.Style.BridgeStyle.Shape = BridgeShape.Square;
		}

		private void CreateSamplePolyline1()
		{
			NPointF[] points = new NPointF[]
				{
					new NPointF(10, 210),
					new NPointF(75, 10),
					new NPointF(75, 10),
					new NPointF(75, 175),
					new NPointF(145, 175),
					new NPointF(145, 10),
					new NPointF(210, 75),
					new NPointF(210, 210),
					new NPointF(105, 210),
					new NPointF(105, 105),
				};
			
			NPolylineShape line = new NPolylineShape(points);
			line.BridgeTargets = BridgeTargets.Self;
			document.ActiveLayer.AddChild(line);
		}
		
		private void CreateSamplePolyline2()
		{
			NPointF[] points = new NPointF[]
				{
					new NPointF(212, 250),
					new NPointF(174, 250),
					new NPointF(174, 169),
					new NPointF(242, 169),
					new NPointF(242, 208),
				};
			
			NPolylineShape hvPolyline = new NPolylineShape(points);
			document.ActiveLayer.AddChild(hvPolyline);

			hvPolyline.Style = hvPolyline.ComposeStyle().Clone() as NStyle;
			hvPolyline.Style.StrokeStyle.Color = Color.OrangeRed;
			hvPolyline.Style.StartArrowheadStyle.StrokeStyle.Color = Color.OrangeRed;
			hvPolyline.Style.EndArrowheadStyle.StrokeStyle.Color = Color.OrangeRed;
			hvPolyline.Style.BridgeStyle.Shape = BridgeShape.Sides2;
		}
		
		private void CreateSampleLineDoubleBridge()
		{
			NLineShape line = new NLineShape(new NPointF(50, 300), new NPointF(206, 14));
			document.ActiveLayer.AddChild(line);

			line.Style = line.ComposeStyle().Clone() as NStyle;
			line.Style.StrokeStyle.Color = Color.Green;
			line.Style.StartArrowheadStyle.StrokeStyle.Color = Color.Green;
			line.Style.EndArrowheadStyle.StrokeStyle.Color = Color.Green;
			line.Style.BridgeStyle.Shape = BridgeShape.Sides3;
		}


		#endregion

		#region Event Handlers

		private void addRandomPolylineButton_Click(object sender, System.EventArgs e)
		{
			NRectangleF bounds = view.Viewport;
			int count = (int)pointsCountNumeric.Value;

			NPolylineShape path = new NPolylineShape(base.GetRandomPoints(bounds, count));
			document.ActiveLayer.AddChild(path);
			
			path.Style = path.ComposeStyle().Clone() as NStyle;
			path.Style.StrokeStyle.Color = Color.DarkCyan;
			path.Style.StartArrowheadStyle.StrokeStyle.Color = Color.DarkCyan;
			path.Style.EndArrowheadStyle.StrokeStyle.Color = Color.DarkCyan;

			view.Selection.SingleSelect(path);

			view.SmartRefresh();
		}

		private void addLineButton_Click(object sender, System.EventArgs e)
		{
			NRectangleF bounds = view.Viewport;

			NPointF[] points = base.GetRandomPoints(bounds, 2);
			NLineShape path = new NLineShape(points[0], points[1]);

			document.ActiveLayer.AddChild(path);

			path.Style = path.ComposeStyle().Clone() as NStyle;
			path.Style.StrokeStyle.Color = Color.DarkCyan;
			path.Style.StartArrowheadStyle.StrokeStyle.Color = Color.DarkCyan;
			path.Style.EndArrowheadStyle.StrokeStyle.Color = Color.DarkCyan;

			view.Selection.SingleSelect(path);

			view.SmartRefresh();
		}

		private void bridgeStyleButton_Click(object sender, System.EventArgs e)
		{
			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
				return;

			base.ShowBridgeStyleEditor(shape); 
		}
		
		private void bridgeTargetsComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			if (bridgeTargetsComboBox.SelectedIndex == -1)
				return;

			// get the selection anchor as bridgeable
			INBridgeableShape bridgeable = (view.Selection.AnchorNode as INBridgeableShape);
			if (bridgeable == null)
				return;

			// change the bridge targes
			bridgeable.BridgeTargets = (BridgeTargets)bridgeTargetsComboBox.SelectedItem;

			// refresh the document views
			document.SmartRefreshAllViews();
		}

		private void enableBridgeManagerCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			document.BridgeManager.Enabled = enableBridgeManagerCheckBox.Checked;

			// refresh the document views
			document.SmartRefreshAllViews();
		}
				
		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			INBridgeableShape bridgeable = (args.Node as INBridgeableShape);
			if (bridgeable == null)
				return;
			
			selectedBridgeableStrokeGroup.Enabled = true;
			bridgeTargetsComboBox.SelectedItem = bridgeable.BridgeTargets;
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			selectedBridgeableStrokeGroup.Enabled = false;
		}

		
		#endregion

		#region Designer Fields
		
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton addLineButton;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox bridgeTargetsComboBox;

		private Nevron.UI.WinForm.Controls.NGroupBox randomNodesGroup;
		private Nevron.UI.WinForm.Controls.NButton addRandomPolylineButton;
		private Nevron.UI.WinForm.Controls.NGroupBox selectedBridgeableStrokeGroup;
		private Nevron.UI.WinForm.Controls.NNumericUpDown pointsCountNumeric;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox enableBridgeManagerCheckBox;
		private Nevron.UI.WinForm.Controls.NButton bridgeStyleButton;

		#endregion
	}
}
