using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Maps;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NProjectionsUC.
    /// </summary>
    public class NMapProjectionsUC : NDiagramExampleUC
    {
        #region Constructors

        public NMapProjectionsUC(NMainForm form)
            : base(form)
		{
            InitializeComponent();
		}

        #endregion

        #region Component Designer Generated Code

        private void InitializeComponent()
        {
			this.ShowDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.cbProjection = new Nevron.UI.WinForm.Controls.NComboBox();
			this.zoomScrollbar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.lblZoomFactor = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblSetting = new System.Windows.Forms.Label();
			this.nudSetting = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblLattitude = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lblLongitude = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblY = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblX = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbParallelRenderMode = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbMeridianRenderMode = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.cbLabelRenderMode = new Nevron.UI.WinForm.Controls.NComboBox();
			((System.ComponentModel.ISupportInitialize)(this.nudSetting)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ShowDataButton
			// 
			this.ShowDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ShowDataButton.Location = new System.Drawing.Point(8, 78);
			this.ShowDataButton.Name = "ShowDataButton";
			this.ShowDataButton.Size = new System.Drawing.Size(243, 23);
			this.ShowDataButton.TabIndex = 3;
			this.ShowDataButton.Text = "Show DBF Data";
			this.ShowDataButton.UseVisualStyleBackColor = true;
			this.ShowDataButton.Click += new System.EventHandler(this.ShowDataButton_Click);
			// 
			// cbProjection
			// 
			this.cbProjection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbProjection.DropDownItems = 50;
			this.cbProjection.ListProperties.CheckBoxDataMember = "";
			this.cbProjection.ListProperties.DataSource = null;
			this.cbProjection.ListProperties.DisplayMember = "";
			this.cbProjection.Location = new System.Drawing.Point(8, 39);
			this.cbProjection.Name = "cbProjection";
			this.cbProjection.Size = new System.Drawing.Size(243, 21);
			this.cbProjection.TabIndex = 4;
			this.cbProjection.SelectedIndexChanged += new System.EventHandler(this.cbProjection_SelectedIndexChanged);
			// 
			// zoomScrollbar
			// 
			this.zoomScrollbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.zoomScrollbar.Location = new System.Drawing.Point(7, 136);
			this.zoomScrollbar.Maximum = 600;
			this.zoomScrollbar.Minimum = 1;
			this.zoomScrollbar.MinimumSize = new System.Drawing.Size(34, 17);
			this.zoomScrollbar.Name = "zoomScrollbar";
			this.zoomScrollbar.Size = new System.Drawing.Size(244, 17);
			this.zoomScrollbar.TabIndex = 8;
			this.zoomScrollbar.Value = 7;
			this.zoomScrollbar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.zoomScrollbar_ValueChanged);
			// 
			// lblZoomFactor
			// 
			this.lblZoomFactor.AutoSize = true;
			this.lblZoomFactor.Location = new System.Drawing.Point(5, 118);
			this.lblZoomFactor.Name = "lblZoomFactor";
			this.lblZoomFactor.Size = new System.Drawing.Size(94, 13);
			this.lblZoomFactor.TabIndex = 9;
			this.lblZoomFactor.Tag = "Zoom factor: {0:P}";
			this.lblZoomFactor.Text = "Zoom factor: {0:P}";
			this.lblZoomFactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.MediumBlue;
			this.label1.Location = new System.Drawing.Point(6, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 16);
			this.label1.TabIndex = 10;
			this.label1.Tag = "";
			this.label1.Text = "Projection:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblSetting
			// 
			this.lblSetting.Location = new System.Drawing.Point(3, 178);
			this.lblSetting.Name = "lblSetting";
			this.lblSetting.Size = new System.Drawing.Size(123, 13);
			this.lblSetting.TabIndex = 12;
			this.lblSetting.Tag = "";
			this.lblSetting.Text = "Projection:";
			this.lblSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblSetting.Visible = false;
			// 
			// nudSetting
			// 
			this.nudSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.nudSetting.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.nudSetting.Location = new System.Drawing.Point(132, 176);
			this.nudSetting.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
			this.nudSetting.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
			this.nudSetting.Name = "nudSetting";
			this.nudSetting.Size = new System.Drawing.Size(113, 20);
			this.nudSetting.TabIndex = 13;
			this.nudSetting.ValueChanged += new System.EventHandler(this.nudSetting_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.MediumBlue;
			this.label2.Location = new System.Drawing.Point(6, 318);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 16);
			this.label2.TabIndex = 16;
			this.label2.Tag = "";
			this.label2.Text = "Mouse position:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.lblLattitude, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblLongitude, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblY, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblX, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 342);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 94);
			this.tableLayoutPanel1.TabIndex = 17;
			// 
			// lblLattitude
			// 
			this.lblLattitude.AutoSize = true;
			this.lblLattitude.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLattitude.Location = new System.Drawing.Point(66, 69);
			this.lblLattitude.Name = "lblLattitude";
			this.lblLattitude.Size = new System.Drawing.Size(174, 25);
			this.lblLattitude.TabIndex = 7;
			this.lblLattitude.Text = "0";
			this.lblLattitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label9.Location = new System.Drawing.Point(3, 69);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(57, 25);
			this.label9.TabIndex = 6;
			this.label9.Text = "Lattitude:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblLongitude
			// 
			this.lblLongitude.AutoSize = true;
			this.lblLongitude.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLongitude.Location = new System.Drawing.Point(66, 46);
			this.lblLongitude.Name = "lblLongitude";
			this.lblLongitude.Size = new System.Drawing.Size(174, 23);
			this.lblLongitude.TabIndex = 5;
			this.lblLongitude.Text = "0";
			this.lblLongitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label7.Location = new System.Drawing.Point(3, 46);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(57, 23);
			this.label7.TabIndex = 4;
			this.label7.Text = "Longitude:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblY
			// 
			this.lblY.AutoSize = true;
			this.lblY.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblY.Location = new System.Drawing.Point(66, 23);
			this.lblY.Name = "lblY";
			this.lblY.Size = new System.Drawing.Size(174, 23);
			this.lblY.TabIndex = 3;
			this.lblY.Text = "0";
			this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Location = new System.Drawing.Point(3, 23);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "Y:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblX
			// 
			this.lblX.AutoSize = true;
			this.lblX.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblX.Location = new System.Drawing.Point(66, 0);
			this.lblX.Name = "lblX";
			this.lblX.Size = new System.Drawing.Size(174, 23);
			this.lblX.TabIndex = 1;
			this.lblX.Text = "0";
			this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "X:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbParallelRenderMode
			// 
			this.cbParallelRenderMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbParallelRenderMode.DropDownItems = 50;
			this.cbParallelRenderMode.ListProperties.CheckBoxDataMember = "";
			this.cbParallelRenderMode.ListProperties.DataSource = null;
			this.cbParallelRenderMode.ListProperties.DisplayMember = "";
			this.cbParallelRenderMode.Location = new System.Drawing.Point(132, 202);
			this.cbParallelRenderMode.Name = "cbParallelRenderMode";
			this.cbParallelRenderMode.Size = new System.Drawing.Size(113, 18);
			this.cbParallelRenderMode.TabIndex = 20;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(9, 204);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 13);
			this.label4.TabIndex = 22;
			this.label4.Tag = "";
			this.label4.Text = "Parallel render mode:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbMeridianRenderMode
			// 
			this.cbMeridianRenderMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbMeridianRenderMode.DropDownItems = 50;
			this.cbMeridianRenderMode.ListProperties.CheckBoxDataMember = "";
			this.cbMeridianRenderMode.ListProperties.DataSource = null;
			this.cbMeridianRenderMode.ListProperties.DisplayMember = "";
			this.cbMeridianRenderMode.Location = new System.Drawing.Point(132, 226);
			this.cbMeridianRenderMode.Name = "cbMeridianRenderMode";
			this.cbMeridianRenderMode.Size = new System.Drawing.Size(113, 18);
			this.cbMeridianRenderMode.TabIndex = 22;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(3, 228);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(123, 13);
			this.label6.TabIndex = 24;
			this.label6.Tag = "";
			this.label6.Text = "Meridian render mode:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(3, 252);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(123, 13);
			this.label8.TabIndex = 26;
			this.label8.Tag = "";
			this.label8.Text = "Label render mode:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbLabelRenderMode
			// 
			this.cbLabelRenderMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbLabelRenderMode.DropDownItems = 50;
			this.cbLabelRenderMode.ListProperties.CheckBoxDataMember = "";
			this.cbLabelRenderMode.ListProperties.DataSource = null;
			this.cbLabelRenderMode.ListProperties.DisplayMember = "";
			this.cbLabelRenderMode.Location = new System.Drawing.Point(132, 250);
			this.cbLabelRenderMode.Name = "cbLabelRenderMode";
			this.cbLabelRenderMode.Size = new System.Drawing.Size(113, 18);
			this.cbLabelRenderMode.TabIndex = 25;
			// 
			// NMapProjectionsUC
			// 
			this.Controls.Add(this.label8);
			this.Controls.Add(this.cbLabelRenderMode);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.cbMeridianRenderMode);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cbParallelRenderMode);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblZoomFactor);
			this.Controls.Add(this.nudSetting);
			this.Controls.Add(this.lblSetting);
			this.Controls.Add(this.zoomScrollbar);
			this.Controls.Add(this.cbProjection);
			this.Controls.Add(this.ShowDataButton);
			this.Controls.Add(this.label1);
			this.Name = "NMapProjectionsUC";
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.ShowDataButton, 0);
			this.Controls.SetChildIndex(this.cbProjection, 0);
			this.Controls.SetChildIndex(this.zoomScrollbar, 0);
			this.Controls.SetChildIndex(this.lblSetting, 0);
			this.Controls.SetChildIndex(this.nudSetting, 0);
			this.Controls.SetChildIndex(this.lblZoomFactor, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.cbParallelRenderMode, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.cbMeridianRenderMode, 0);
			this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
			this.Controls.SetChildIndex(this.label6, 0);
			this.Controls.SetChildIndex(this.cbLabelRenderMode, 0);
			this.Controls.SetChildIndex(this.label8, 0);
			((System.ComponentModel.ISupportInitialize)(this.nudSetting)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // init form fields
            view.BeginInit();

			view.ViewLayout = ViewLayout.Fit;
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.GlobalVisibility.ShowArrowheads = false;
            view.VerticalRuler.Visible = false;
            view.HorizontalRuler.Visible = false;

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
            document.EventSinkService.NodeMouseEnter += new NodeViewEventHandler(EventSinkService_NodeMouseEnter);
            document.EventSinkService.NodeMouseLeave += new NodeViewEventHandler(EventSinkService_NodeMouseLeave);
            document.MouseMove += new NodeMouseEventHandler(document_MouseMove);
            base.AttachToEvents();
        }
        protected override void DetachFromEvents()
        {
            document.EventSinkService.NodeMouseEnter -= EventSinkService_NodeMouseEnter;
            document.EventSinkService.NodeMouseLeave -= EventSinkService_NodeMouseLeave;
            document.MouseMove -= document_MouseMove;
            base.DetachFromEvents();
        }

        #endregion

        #region Implementation

        private void InitFormControls()
        {
            PauseEventsHandling();

            m_bZoomWorkedOut = true;
            view.EventSinkService.TransformationsChanged += new EventHandler(EventSinkService_TransformationsChanged);
            view.Controller.Tools.DisableTools(new string[] { Nevron.Diagram.WinForm.NDWFR.ToolSelector });

            float zoomFactor = zoomScrollbar.Value / 100.0f;
            lblZoomFactor.Text = string.Format(lblZoomFactor.Tag.ToString(), zoomFactor);

            cbProjection.Items.Clear();
            cbProjection.Items.Add(new NAitoffProjection());
            cbProjection.Items.Add(new NBonneProjection());

            cbProjection.Items.Add(new NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Lambert));
            cbProjection.Items.Add(new NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Behrmann));
            cbProjection.Items.Add(new NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.TristanEdwards));
            cbProjection.Items.Add(new NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Peters));
            cbProjection.Items.Add(new NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Gall));
            cbProjection.Items.Add(new NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Balthasart));

            cbProjection.Items.Add(new NEckertIVProjection());
            cbProjection.Items.Add(new NEckertVIProjection());
            cbProjection.Items.Add(new NEquirectangularProjection());
            cbProjection.Items.Add(new NHammerProjection());
            cbProjection.Items.Add(new NKavrayskiyVIIProjection());
            cbProjection.Items.Add(new NMercatorProjection());
            cbProjection.Items.Add(new NMillerCylindricalProjection());
            cbProjection.Items.Add(new NMollweideProjection());
            cbProjection.Items.Add(new NOrthographicProjection());
            cbProjection.Items.Add(new NRobinsonProjection());
            cbProjection.Items.Add(new NStereographicProjection());
            cbProjection.Items.Add(new NVanDerGrintenProjection());
            cbProjection.Items.Add(new NWagnerVIProjection());
            cbProjection.Items.Add(new NWinkelTripelProjection());

            cbProjection.SelectedIndex = 16;

			cbMeridianRenderMode.FillFromEnum(typeof(ArcRenderMode));
			cbMeridianRenderMode.SelectedItem = m_MapImporter.Meridians.ArcRenderMode;
			cbMeridianRenderMode.SelectedIndexChanged += new EventHandler(cbMeridianRenderMode_SelectedIndexChanged);

			cbParallelRenderMode.FillFromEnum(typeof(ArcRenderMode));
			cbParallelRenderMode.SelectedItem = m_MapImporter.Parallels.ArcRenderMode;
			cbParallelRenderMode.SelectedIndexChanged += new EventHandler(cbParallelRenderMode_SelectedIndexChanged);

			cbLabelRenderMode.FillFromEnum(typeof(ArcLabelRenderMode));
			cbLabelRenderMode.SelectedItem = m_MapImporter.Parallels.LabelRenderMode;
			cbLabelRenderMode.SelectedIndexChanged += new EventHandler(cbLabelRenderMode_SelectedIndexChanged);

            ResumeEventsHandling();
        }
        private void InitDocument()
        {
            document.Layers.RemoveAllChildren();
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            document.RoutingManager.Enabled = false;
            document.BridgeManager.Enabled = false;
            document.Bounds = new NRectangleF(0, 0, 10000, 10000);
            document.BackgroundStyle.FillStyle = new NColorFillStyle(Color.LightBlue);
            CreateStyleSheets();

            m_MapImporter = new NEsriMapImporter();
            m_MapImporter.MapBounds = NMapBounds.World;

			NEsriShapefile countries = new NEsriShapefile(Path.Combine(Application.StartupPath, COUNTRIES));
            countries.NameColumn = "CNTRY_NAME";
			m_MapImporter.AddLayer(countries);

            m_MapImporter.Read();

 			m_MapImporter.ShapeCreatedListener = new NCustomShapeCreatedListener();
			m_MapImporter.Parallels.ArcRenderMode = ArcRenderMode.Normal;
			m_MapImporter.Meridians.ArcRenderMode = ArcRenderMode.Normal;
        }
        private void CreateStyleSheets()
        {
            Color[] COLORS = new Color[]{
                Color.Tomato,
                Color.PaleGreen,
                Color.Gold,
                Color.PaleGoldenrod,
                Color.Tan,
                Color.Khaki,
                Color.OldLace,
                Color.Orange
            };

            NStyleSheet ss1, ss2;
            int i, count = COLORS.Length;
            for (i = 0; i < count; i++)
            {
                ss1 = new NStyleSheet();
                ss1.Name = COLORS[i].Name;
                ss1.Style.FillStyle = new NColorFillStyle(COLORS[i]);
                document.StyleSheets.AddChild(ss1);

                ss2 = new NStyleSheet();
                ss2.Name = COLORS[i].Name + "2";
                ss2.Style.FillStyle = new NColorFillStyle(NColorF.ChangeColorBrightness(COLORS[i], -0.3f));
                document.StyleSheets.AddChild(ss2);
            }
        }
        private void ImportMap()
        {
            document.Layers.RemoveAllChildren();

			// Import the map data
            m_MapImporter.Import(document, document.Bounds);
            m_Countries = (NLayer)document.Layers.GetChildByName("countries");

			view.Refresh();
        }

        #endregion

        #region Event Handlers

        private void EventSinkService_NodeMouseLeave(NNodeViewEventArgs args)
        {
			NShape shape = args.Node as NShape;
			if (shape == null || shape is NMapArcsShape)
				return;

            shape.StyleSheetName = shape.StyleSheetName.Remove(shape.StyleSheetName.Length - 1);
        }
        private void EventSinkService_NodeMouseEnter(NNodeViewEventArgs args)
        {
			NShape shape = args.Node as NShape;
			if (shape == null || shape is NMapArcsShape)
				return;

            shape.StyleSheetName = shape.StyleSheetName + "2";
        }
        private void EventSinkService_TransformationsChanged(object sender, EventArgs e)
        {
            if (m_bZoomWorkedOut)
            {
                m_bZoomWorkedOut = false;
                return;
            }

            float zoomFactor = (view.ScaleX + view.ScaleY) / 2;
			if (lblZoomFactor.Tag != null)
			{
				lblZoomFactor.Text = String.Format(lblZoomFactor.Tag.ToString(), zoomFactor);
			}

            zoomScrollbar.Value = (int)(Math.Round(zoomFactor * 100));
        }

        private void ShowDataButton_Click(object sender, EventArgs e)
        {
            Nevron.UI.WinForm.Controls.NForm f = new Nevron.UI.WinForm.Controls.NForm();
            f.SuspendLayout();

            //Create the data grid view
            NDataGridView dg = new NDataGridView();
            dg.Dock = DockStyle.Fill;
            dg.AllowUserToAddRows = false;
            dg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg.RowHeadersVisible = false;
            dg.ReadOnly = true;
            dg.DataSource = m_MapImporter.GetLayerAt(0).DataTable;
            f.Controls.Add(dg);

            //Init the form
            f.Icon = this.Form.Icon;
            f.WindowState = FormWindowState.Maximized;
            f.Text = string.Format("DBF data for '{0}'", m_MapImporter.GetLayerAt(0).Name);

            f.ResumeLayout();
            f.ShowDialog();
        }
        private void zoomScrollbar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
        {
            float zoomFactor = (view.ScaleX + view.ScaleY) / 2;
            float scrollFactor = e.ScrollBar.Value / 100.0f;
			if (zoomFactor != scrollFactor)
			{
				if (view.ViewLayout != ViewLayout.Normal)
				{
					view.ViewLayout = ViewLayout.Normal;
				}

				view.Zoom(scrollFactor);
			}

			if (lblZoomFactor.Tag != null)
			{
				lblZoomFactor.Text = String.Format(lblZoomFactor.Tag.ToString(), scrollFactor);
			}
        }
        private void cbProjection_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_MapImporter.Projection = (NMapProjection)cbProjection.SelectedItem;
            if (m_MapImporter.Projection is NOrthographicProjection)
            {
                lblSetting.Text = "Central Meridian:";
                nudSetting.Value = (decimal)((NOrthographicProjection)m_MapImporter.Projection).CentralMeridian;
                lblSetting.Visible = true;
                nudSetting.Visible = true;
				nudSetting.Minimum = -180;
				nudSetting.Maximum = 180;
            }
            else if (m_MapImporter.Projection is NBonneProjection)
            {
                lblSetting.Text = "Standard Parallel:";
                nudSetting.Value = (decimal)((NBonneProjection)m_MapImporter.Projection).StandardParallel;
                lblSetting.Visible = true;
                nudSetting.Visible = true;
				nudSetting.Minimum = -90;
				nudSetting.Maximum = 90;
            }
            else
            {
                lblSetting.Visible = false;
                nudSetting.Visible = false;
            }

            zoomScrollbar.Focus();
            ImportMap();
        }
		private void cbParallelRenderMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			ArcRenderMode arcRenderMode = (ArcRenderMode)((NComboBox)sender).SelectedItem;
			m_MapImporter.Parallels.ArcRenderMode = arcRenderMode;
			NMapArcsShape.Find(document, ArcType.Parallel).ArcRenderMode = arcRenderMode;

			document.SmartRefreshAllViews();
		}
		private void cbMeridianRenderMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			ArcRenderMode arcRenderMode = (ArcRenderMode)((NComboBox)sender).SelectedItem;
			m_MapImporter.Meridians.ArcRenderMode = arcRenderMode;
			NMapArcsShape.Find(document, ArcType.Meridian).ArcRenderMode = arcRenderMode;

			document.SmartRefreshAllViews();
		}
		private void cbLabelRenderMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			ArcLabelRenderMode labelRenderMode = (ArcLabelRenderMode)cbLabelRenderMode.SelectedItem;
			m_MapImporter.Meridians.LabelRenderMode = labelRenderMode;
			m_MapImporter.Parallels.LabelRenderMode = labelRenderMode;

			NMapArcsShape.Find(document, ArcType.Parallel).LabelRenderMode = labelRenderMode;
			NMapArcsShape.Find(document, ArcType.Meridian).LabelRenderMode = labelRenderMode;

			document.SmartRefreshAllViews();
		}
		private void nudSetting_ValueChanged(object sender, EventArgs e)
		{
			NNumericUpDown nud = (NNumericUpDown)sender;
			if (m_MapImporter.Projection is NOrthographicProjection)
			{
				((NOrthographicProjection)m_MapImporter.Projection).CentralMeridian = (float)nud.Value;
			}
			else if (m_MapImporter.Projection is NBonneProjection)
			{
				((NBonneProjection)m_MapImporter.Projection).StandardParallel = (float)nud.Value;
			}
			else
			{
				return;
			}

			ImportMap();
		}

        private void document_MouseMove(NNodeMouseEventArgs args)
        {
            NPointF point = args.ScenePoint;
            lblX.Text = point.X.ToString();
            lblY.Text = point.Y.ToString();

            try
            {
                // Get the inverted point for the current projection
                point = m_MapImporter.Projection.DeprojectPoint(point);
            }
            catch
            {
                lblLongitude.Text = "Not Available";
                lblLattitude.Text = "Not Available";
                return;
            }

            // Check if the longitude or the lattitude are out of bounds
            if (point.X < -180)
                point.X = -180;
            else if (point.X > 180)
                point.X = 180;

            if (point.Y < -90)
                point.Y = -90;
            else if (point.Y > 90)
                point.Y = 90;

            lblLongitude.Text = point.X.ToString("F3");
            lblLattitude.Text = point.Y.ToString("F3");
        }

        #endregion

        #region Designer Fields

        private Nevron.UI.WinForm.Controls.NButton ShowDataButton;
		private Nevron.UI.WinForm.Controls.NComboBox cbProjection;
        private Nevron.UI.WinForm.Controls.NHScrollBar zoomScrollbar;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nudSetting;
        private Label label1;
		private Label label4;
		private Label label6;
        private Label lblZoomFactor;
		private Label lblSetting;
		private NComboBox cbParallelRenderMode;
		private NComboBox cbMeridianRenderMode;
		private Label label8;
		private NComboBox cbLabelRenderMode;

        #endregion

        #region Fields

        private NEsriMapImporter m_MapImporter;
        private bool m_bZoomWorkedOut;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblLattitude;
        private Label label9;
        private Label lblLongitude;
        private Label label7;
        private Label lblY;
        private Label label5;
        private Label lblX;
        private Label label3;
        private NLayer m_Countries;

        #endregion

		#region Constants

		private const string COUNTRIES = @"..\..\Resources\Maps\countries.shp";

		#endregion

		#region Nested Types

		private class NCustomShapeCreatedListener : NShapeCreatedListener
        {
            #region Constructors

            public NCustomShapeCreatedListener()
            {
            }

            #endregion

            #region INShapeCreatedListener

			public override bool OnPolygonCreated(NDiagramElement element, NMapFeature mapFeature)
            {
                NShape shape = element as NShape;
                if (shape == null)
                    return true;

                string name = mapFeature.GetAttributeValue("CNTRY_NAME").ToString();
                float population = float.Parse(mapFeature.GetAttributeValue("POP_CNTRY").ToString());
                float landArea = float.Parse(mapFeature.GetAttributeValue("SQKM").ToString());
                NInteractivityStyle interactivityStyle = new NInteractivityStyle(
                    string.Format("{1}{0}======================{0}Land Area: {2:N} km2{0}Population: {3:N0} people{0}Pop. Density: {4:N} people/km2",
                    Environment.NewLine, name, landArea, population, population / landArea));
                shape.Style.InteractivityStyle = interactivityStyle;

                int colorIndex = int.Parse(mapFeature.GetAttributeValue("COLOR_MAP").ToString()) - 1;
                shape.StyleSheetName = COLORS[colorIndex];

                return true;
            }
			public override bool OnMultiPolygonCreated(NDiagramElement element, NMapFeature mapFeature)
            {
                return OnPolygonCreated(element, mapFeature);
            }

            #endregion

            #region Static

            private static readonly NSizeF TEXT_SIZE = new NSizeF(150, 30);
            private static readonly string[] COLORS = new string[]{
                "Tomato", "PaleGreen", "Gold", "PaleGoldenrod", "Tan", "Khaki", "OldLace", "Orange"
            };

            #endregion
        }

        #endregion
    }
}