using System;
using System.Drawing;
using System.Drawing.Drawing2D;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WinForm;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NRoutableConnectorsUC.
	/// </summary>
	public class NRoutableConnectorsUC : NDiagramExampleUC
	{
		#region Constructor
		public NRoutableConnectorsUC(NMainForm form) : base(form)
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
			this.obstacleTypeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.obstacleGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.routeGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.rerouteButton = new Nevron.UI.WinForm.Controls.NButton();
			this.routeModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.reverseButton = new Nevron.UI.WinForm.Controls.NButton();
			this.routeTypeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.managerGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.routingMeshTypeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.routingGridTypeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.managerEnabledCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.obstacleGroup.SuspendLayout();
			this.routeGroup.SuspendLayout();
			this.managerGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// obstacleTypeCombo
			// 
			this.obstacleTypeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.obstacleTypeCombo.Location = new System.Drawing.Point(104, 24);
			this.obstacleTypeCombo.Name = "obstacleTypeCombo";
			this.obstacleTypeCombo.Size = new System.Drawing.Size(136, 21);
			this.obstacleTypeCombo.TabIndex = 1;
			this.obstacleTypeCombo.SelectedIndexChanged += new System.EventHandler(this.obstacleTypeCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Obstacle type:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// obstacleGroup
			// 
			this.obstacleGroup.Controls.Add(this.obstacleTypeCombo);
			this.obstacleGroup.Controls.Add(this.label2);
			this.obstacleGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.obstacleGroup.ImageIndex = 0;
			this.obstacleGroup.Location = new System.Drawing.Point(0, 0);
			this.obstacleGroup.Name = "obstacleGroup";
			this.obstacleGroup.Size = new System.Drawing.Size(250, 56);
			this.obstacleGroup.TabIndex = 0;
			this.obstacleGroup.TabStop = false;
			this.obstacleGroup.Text = "2D shape obstacle properties";
			// 
			// routeGroup
			// 
			this.routeGroup.Controls.Add(this.rerouteButton);
			this.routeGroup.Controls.Add(this.routeModeCombo);
			this.routeGroup.Controls.Add(this.label3);
			this.routeGroup.Controls.Add(this.reverseButton);
			this.routeGroup.Controls.Add(this.routeTypeCombo);
			this.routeGroup.Controls.Add(this.label1);
			this.routeGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.routeGroup.ImageIndex = 0;
			this.routeGroup.Location = new System.Drawing.Point(0, 56);
			this.routeGroup.Name = "routeGroup";
			this.routeGroup.Size = new System.Drawing.Size(250, 152);
			this.routeGroup.TabIndex = 1;
			this.routeGroup.TabStop = false;
			this.routeGroup.Text = "Routable connector properties";
			// 
			// rerouteButton
			// 
			this.rerouteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.rerouteButton.Location = new System.Drawing.Point(8, 112);
			this.rerouteButton.Name = "rerouteButton";
			this.rerouteButton.Size = new System.Drawing.Size(232, 23);
			this.rerouteButton.TabIndex = 5;
			this.rerouteButton.Text = "Reroute";
			this.rerouteButton.Click += new System.EventHandler(this.rerouteButton_Click);
			// 
			// routeModeCombo
			// 
			this.routeModeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.routeModeCombo.Location = new System.Drawing.Point(104, 48);
			this.routeModeCombo.Name = "routeModeCombo";
			this.routeModeCombo.Size = new System.Drawing.Size(136, 21);
			this.routeModeCombo.TabIndex = 3;
			this.routeModeCombo.SelectedIndexChanged += new System.EventHandler(this.routeModeCombo_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Auto reroute:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// reverseButton
			// 
			this.reverseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.reverseButton.Location = new System.Drawing.Point(8, 80);
			this.reverseButton.Name = "reverseButton";
			this.reverseButton.Size = new System.Drawing.Size(232, 23);
			this.reverseButton.TabIndex = 4;
			this.reverseButton.Text = "Reverse";
			this.reverseButton.Click += new System.EventHandler(this.reverseButton_Click);
			// 
			// routeTypeCombo
			// 
			this.routeTypeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.routeTypeCombo.Location = new System.Drawing.Point(104, 16);
			this.routeTypeCombo.Name = "routeTypeCombo";
			this.routeTypeCombo.Size = new System.Drawing.Size(136, 21);
			this.routeTypeCombo.TabIndex = 1;
			this.routeTypeCombo.SelectedIndexChanged += new System.EventHandler(this.routeTypeCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Type:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// managerGroup
			// 
			this.managerGroup.Controls.Add(this.routingMeshTypeCombo);
			this.managerGroup.Controls.Add(this.label6);
			this.managerGroup.Controls.Add(this.routingGridTypeCombo);
			this.managerGroup.Controls.Add(this.label4);
			this.managerGroup.Controls.Add(this.managerEnabledCheck);
			this.managerGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.managerGroup.ImageIndex = 0;
			this.managerGroup.Location = new System.Drawing.Point(0, 208);
			this.managerGroup.Name = "managerGroup";
			this.managerGroup.Size = new System.Drawing.Size(250, 112);
			this.managerGroup.TabIndex = 2;
			this.managerGroup.TabStop = false;
			this.managerGroup.Text = "Routing Manager";
			// 
			// routingMeshTypeCombo
			// 
			this.routingMeshTypeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.routingMeshTypeCombo.Location = new System.Drawing.Point(104, 80);
			this.routingMeshTypeCombo.Name = "routingMeshTypeCombo";
			this.routingMeshTypeCombo.Size = new System.Drawing.Size(136, 21);
			this.routingMeshTypeCombo.TabIndex = 5;
			this.routingMeshTypeCombo.SelectedIndexChanged += new System.EventHandler(this.routingMeshTypeCombo_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 82);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 4;
			this.label6.Text = "Mesh type:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// routingGridTypeCombo
			// 
			this.routingGridTypeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.routingGridTypeCombo.Location = new System.Drawing.Point(104, 48);
			this.routingGridTypeCombo.Name = "routingGridTypeCombo";
			this.routingGridTypeCombo.Size = new System.Drawing.Size(136, 21);
			this.routingGridTypeCombo.TabIndex = 3;
			this.routingGridTypeCombo.SelectedIndexChanged += new System.EventHandler(this.routingGridTypeCombo_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 50);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Grid type:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// managerEnabledCheck
			// 
			this.managerEnabledCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.managerEnabledCheck.Location = new System.Drawing.Point(8, 16);
			this.managerEnabledCheck.Name = "managerEnabledCheck";
			this.managerEnabledCheck.Size = new System.Drawing.Size(136, 21);
			this.managerEnabledCheck.TabIndex = 1;
			this.managerEnabledCheck.Text = "Enabled";
			this.managerEnabledCheck.CheckedChanged += new System.EventHandler(this.managerEnabledCheck_CheckedChanged);
			// 
			// NRoutableConnectorsUC
			// 
			this.Controls.Add(this.managerGroup);
			this.Controls.Add(this.routeGroup);
			this.Controls.Add(this.obstacleGroup);
			this.Name = "NRoutableConnectorsUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.obstacleGroup, 0);
			this.Controls.SetChildIndex(this.routeGroup, 0);
			this.Controls.SetChildIndex(this.managerGroup, 0);
			this.obstacleGroup.ResumeLayout(false);
			this.routeGroup.ResumeLayout(false);
			this.managerGroup.ResumeLayout(false);
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
			view.ViewLayout = ViewLayout.Fit; 
			view.GlobalVisibility.ShowPorts = false;

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

			obstacleGroup.Visible = false;
			routeGroup.Visible = false;

			obstacleTypeCombo.FillFromEnum(typeof(RouteObstacleType));
			obstacleTypeCombo.SelectedIndex = 0;

			routeModeCombo.FillFromEnum(typeof(RerouteAutomatically));
			routeModeCombo.SelectedIndex = 0;

			routeTypeCombo.FillFromEnum(typeof(RoutableConnectorType));
			routeTypeCombo.SelectedIndex = 0;

			managerEnabledCheck.Checked = document.RoutingManager.Enabled;

			routingGridTypeCombo.FillFromEnum(typeof(RoutingGridType));
			routingGridTypeCombo.SelectedIndex = (int)document.RoutingManager.RoutingGridType;

			routingMeshTypeCombo.FillFromEnum(typeof(RoutingMeshType));
			routingMeshTypeCombo.SelectedIndex = (int)document.RoutingManager.RoutingMeshType;

			ResumeEventsHandling();
		}

		private void InitDocument()
		{
			// create a stylesheet for the first type of bricks
			NStyleSheet styleSheet = new NStyleSheet("BRICK1");
			styleSheet.Style.FillStyle = new NHatchFillStyle(HatchStyle.HorizontalBrick, Color.DarkOrange, Color.Gold);
			document.StyleSheets.AddChild(styleSheet);

			// create a stylesheet for the second type of bricks
			styleSheet = new NStyleSheet("BRICK2");
			styleSheet.Style.FillStyle = new NHatchFillStyle(HatchStyle.HorizontalBrick, Color.DarkRed, Color.Gold);
			document.StyleSheets.AddChild(styleSheet);

			// create a stylesheet for the start shapes
			styleSheet = new NStyleSheet("START");
			styleSheet.Style.FillStyle = new NColorFillStyle(Color.Red);
			document.StyleSheets.AddChild(styleSheet);

			// create a stylesheet for the end shapes
			styleSheet = new NStyleSheet("END");
			styleSheet.Style.FillStyle = new NColorFillStyle(Color.Green);
			document.StyleSheets.AddChild(styleSheet);

			// create the maze frame
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(50, 0, 700, 50), "", "BRICK1");
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(750, 0, 50, 800), "", "BRICK1");
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(50, 750, 700, 50), "", "BRICK1");
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(0, 0, 50, 800), "", "BRICK1");

			// create the maze obstacles
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(100, 200, 200, 50), "", "BRICK2");
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(300, 50, 50, 200), "", "BRICK2");
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(450, 50, 50, 200), "", "BRICK2");
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(500, 200, 200, 50), "", "BRICK2");			

			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(50, 300, 250, 50), "", "BRICK2");
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(500, 300, 250, 50), "", "BRICK2");

			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(350, 350, 100, 100), "", "BRICK2");

			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(50, 450, 250, 50), "", "BRICK2");
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(500, 450, 250, 50), "", "BRICK2");

			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(100, 550, 200, 50), "", "BRICK2");
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(300, 550, 50, 200), "", "BRICK2");
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(450, 550, 50, 200), "", "BRICK2");
			base.CreateBasicShape(BasicShapes.Rectangle, new NRectangleF(500, 550, 200, 50), "", "BRICK2");

			// create the first set of start/end shapes
            NShape start = base.CreateBasicShape(BasicShapes.Ellipse, new NRectangleF(100, 100, 50, 50), "", "START");
			NShape end = base.CreateBasicShape(BasicShapes.Ellipse, new NRectangleF(650, 650, 50, 50), "", "END");

			// connect them with a dynamic HV routable connector, 
			// which is rerouted whenever the obstacles have changed
			NRoutableConnector routableConnector = new NRoutableConnector(RoutableConnectorType.DynamicHV, RerouteAutomatically.Always);
			routableConnector.StyleSheetName = NDR.NameConnectorsStyleSheet;
			routableConnector.Style.StrokeStyle = new NStrokeStyle(3, Color.Blue);
			document.ActiveLayer.AddChild(routableConnector);

			routableConnector.FromShape = start;
			routableConnector.ToShape = end;
			routableConnector.Reroute();

			// create the second set of start/end shapes 
			start = base.CreateBasicShape(BasicShapes.Ellipse, new NRectangleF(600, 100, 50, 50), "", "END");
			end = base.CreateBasicShape(BasicShapes.Ellipse, new NRectangleF(100, 650, 50, 50), "", "END");

			// connect them with a dynamic Polyline routable connector, 
			// which is rerouted whenever the obstacles have changed
			routableConnector = new NRoutableConnector(RoutableConnectorType.DynamicPolyline, RerouteAutomatically.Always); 
			routableConnector.StyleSheetName = NDR.NameConnectorsStyleSheet;
			routableConnector.Style.StrokeStyle = new NStrokeStyle(3, Color.Magenta);
			document.ActiveLayer.AddChild(routableConnector);

			routableConnector.FromShape = start;
			routableConnector.ToShape = end;
			routableConnector.Reroute();

			// size document to fit the maze
			document.SizeToContent(); 
		}


		#endregion

		#region Event Handlers

		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			PauseEventsHandling();

			if (view.Selection.AnchorNode is NRoutableConnector)
			{
				obstacleGroup.Visible = false;
				routeGroup.Visible = true;

				NRoutableConnector routableConnector = (view.Selection.AnchorNode as NRoutableConnector);
                routeTypeCombo.SelectedIndex = (int)routableConnector.ConnectorType;
				routeModeCombo.SelectedIndex = (int)routableConnector.RerouteAutomatically;
			}
			else if (NFilters.Shape2D.Filter(view.Selection.AnchorNode))
			{
				obstacleGroup.Visible = true;
				routeGroup.Visible = false;

				NShape obstacle = (view.Selection.AnchorNode as NShape);
				obstacleTypeCombo.SelectedIndex = (int)obstacle.RouteObstacleType;
			}
			else
			{
				obstacleGroup.Visible = false;
				routeGroup.Visible = false;
			}

			ResumeEventsHandling();
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			obstacleGroup.Visible = false;
			routeGroup.Visible = false;
		}

		private void obstacleTypeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null || shape.ShapeType != ShapeType.Shape1D)
				return;
			
			shape.RouteObstacleType = (RouteObstacleType)obstacleTypeCombo.SelectedIndex;
		}

		private void routeTypeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NRoutableConnector connector = (view.Selection.AnchorNode as NRoutableConnector);
			if (connector == null)
				return;

			connector.ConnectorType = (RoutableConnectorType)routeTypeCombo.SelectedIndex;
		}

		private void routeModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NRoutableConnector connector = (view.Selection.AnchorNode as NRoutableConnector);
			if (connector == null)
				return;

			connector.RerouteAutomatically = (RerouteAutomatically)routeModeCombo.SelectedIndex;
		}

		private void reverseButton_Click(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NRoutableConnector connector = (view.Selection.AnchorNode as NRoutableConnector);
			if (connector == null)
				return;

			connector.Reverse();
			document.SmartRefreshAllViews(); 
		}

		private void rerouteButton_Click(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NRoutableConnector connector = (view.Selection.AnchorNode as NRoutableConnector);
			if (connector == null)
				return;

			connector.Reroute();
			document.SmartRefreshAllViews();
		}

		private void managerEnabledCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
		
			document.RoutingManager.Enabled = managerEnabledCheck.Checked;
		}

		private void routingGridTypeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			document.RoutingManager.RoutingGridType = (RoutingGridType)routingGridTypeCombo.SelectedIndex;
		}

		private void routingMeshTypeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;		

			document.RoutingManager.RoutingMeshType = (RoutingMeshType)routingMeshTypeCombo.SelectedIndex;
		}


		#endregion

		#region Designer Fields
		
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox obstacleTypeCombo;
		private Nevron.UI.WinForm.Controls.NGroupBox obstacleGroup;
		private Nevron.UI.WinForm.Controls.NGroupBox routeGroup;
		private Nevron.UI.WinForm.Controls.NButton reverseButton;
		private Nevron.UI.WinForm.Controls.NComboBox routeTypeCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NComboBox routeModeCombo;
		private Nevron.UI.WinForm.Controls.NGroupBox managerGroup;
		private Nevron.UI.WinForm.Controls.NComboBox routingGridTypeCombo;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NCheckBox managerEnabledCheck;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NComboBox routingMeshTypeCombo;
		private Nevron.UI.WinForm.Controls.NButton rerouteButton;

		private System.ComponentModel.Container components = null;

		#endregion
	}
}