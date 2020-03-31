using System;
using System.Drawing;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.Maps;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using System.IO;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NWorldMapUC.
    /// </summary>
    public class NWorldPopulationUC : NDiagramExampleUC
    {
        #region Constructors

        public NWorldPopulationUC(NMainForm form)
            : base(form)
		{
			m_DataGrouping = new NDataGroupingOptimal();
			m_DataGrouping.RoundedRanges = true;

            InitializeComponent();
		}

        #endregion

        #region Component Designer Generated Code

        private void InitializeComponent()
        {
			this.ShowDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.zoomScrollbar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.lblZoomFactor = new System.Windows.Forms.Label();
			this.btnRecreateMap = new Nevron.UI.WinForm.Controls.NButton();
			this.rbOptimal = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.rbEqualInterval = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.rbEqualDistribution = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.chkRoundedRanges = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ShowDataButton
			// 
			this.ShowDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ShowDataButton.Location = new System.Drawing.Point(7, 67);
			this.ShowDataButton.Name = "ShowDataButton";
			this.ShowDataButton.Size = new System.Drawing.Size(244, 23);
			this.ShowDataButton.TabIndex = 3;
			this.ShowDataButton.Text = "Show DBF Data";
			this.ShowDataButton.UseVisualStyleBackColor = true;
			this.ShowDataButton.Click += new System.EventHandler(this.ShowDataButton_Click);
			// 
			// zoomScrollbar
			// 
			this.zoomScrollbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.zoomScrollbar.Location = new System.Drawing.Point(7, 36);
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
			this.lblZoomFactor.Location = new System.Drawing.Point(5, 17);
			this.lblZoomFactor.Name = "lblZoomFactor";
			this.lblZoomFactor.Size = new System.Drawing.Size(94, 13);
			this.lblZoomFactor.TabIndex = 9;
			this.lblZoomFactor.Text = "Zoom factor: {0:P}";
			this.lblZoomFactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRecreateMap
			// 
			this.btnRecreateMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.btnRecreateMap.Location = new System.Drawing.Point(7, 275);
			this.btnRecreateMap.Name = "btnRecreateMap";
			this.btnRecreateMap.Size = new System.Drawing.Size(244, 23);
			this.btnRecreateMap.TabIndex = 21;
			this.btnRecreateMap.Text = "Recreate Map";
			this.btnRecreateMap.UseVisualStyleBackColor = true;
			this.btnRecreateMap.Click += new System.EventHandler(this.btnRecreateMap_Click);
			// 
			// rbOptimal
			// 
			this.rbOptimal.AutoSize = true;
			this.rbOptimal.ButtonProperties.BorderOffset = 2;
			this.rbOptimal.Checked = true;
			this.rbOptimal.Location = new System.Drawing.Point(8, 246);
			this.rbOptimal.Name = "rbOptimal";
			this.rbOptimal.Size = new System.Drawing.Size(60, 17);
			this.rbOptimal.TabIndex = 20;
			this.rbOptimal.TabStop = true;
			this.rbOptimal.Text = "Optimal";
			this.rbOptimal.UseVisualStyleBackColor = true;
			// 
			// rbEqualInterval
			// 
			this.rbEqualInterval.AutoSize = true;
			this.rbEqualInterval.ButtonProperties.BorderOffset = 2;
			this.rbEqualInterval.Location = new System.Drawing.Point(8, 223);
			this.rbEqualInterval.Name = "rbEqualInterval";
			this.rbEqualInterval.Size = new System.Drawing.Size(90, 17);
			this.rbEqualInterval.TabIndex = 19;
			this.rbEqualInterval.Text = "Equal Interval";
			this.rbEqualInterval.UseVisualStyleBackColor = true;
			// 
			// rbEqualDistribution
			// 
			this.rbEqualDistribution.AutoSize = true;
			this.rbEqualDistribution.ButtonProperties.BorderOffset = 2;
			this.rbEqualDistribution.Location = new System.Drawing.Point(7, 200);
			this.rbEqualDistribution.Name = "rbEqualDistribution";
			this.rbEqualDistribution.Size = new System.Drawing.Size(107, 17);
			this.rbEqualDistribution.TabIndex = 18;
			this.rbEqualDistribution.Text = "Equal Distribution";
			this.rbEqualDistribution.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.MediumBlue;
			this.label1.Location = new System.Drawing.Point(5, 171);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 16);
			this.label1.TabIndex = 17;
			this.label1.Tag = "";
			this.label1.Text = "Data Grouping:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkRoundRanges
			// 
			this.chkRoundedRanges.AutoSize = true;
			this.chkRoundedRanges.Location = new System.Drawing.Point(8, 141);
			this.chkRoundedRanges.Name = "chkRoundRanges";
			this.chkRoundedRanges.Size = new System.Drawing.Size(98, 17);
			this.chkRoundedRanges.TabIndex = 22;
			this.chkRoundedRanges.Text = "Rounded Ranges";
			this.chkRoundedRanges.UseVisualStyleBackColor = true;
			this.chkRoundedRanges.Checked = true;
			// 
			// NWorldPopulationUC
			// 
			this.Controls.Add(this.chkRoundedRanges);
			this.Controls.Add(this.btnRecreateMap);
			this.Controls.Add(this.rbOptimal);
			this.Controls.Add(this.rbEqualInterval);
			this.Controls.Add(this.rbEqualDistribution);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblZoomFactor);
			this.Controls.Add(this.zoomScrollbar);
			this.Controls.Add(this.ShowDataButton);
			this.Name = "NWorldPopulationUC";
			this.Controls.SetChildIndex(this.ShowDataButton, 0);
			this.Controls.SetChildIndex(this.zoomScrollbar, 0);
			this.Controls.SetChildIndex(this.lblZoomFactor, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.rbEqualDistribution, 0);
			this.Controls.SetChildIndex(this.rbEqualInterval, 0);
			this.Controls.SetChildIndex(this.rbOptimal, 0);
			this.Controls.SetChildIndex(this.btnRecreateMap, 0);
			this.Controls.SetChildIndex(this.chkRoundedRanges, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // init form fields
            view.BeginInit();

            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.GlobalVisibility.ShowArrowheads = false;
            view.VerticalRuler.Visible = false;
            view.HorizontalRuler.Visible = false;

            // init document
            document.BeginInit();
            InitDocument();
            document.SizeToContent(new NSizeF(0, 0), new Nevron.Diagram.NMargins(0));
            document.EndInit();

            // init form controls
            InitFormControls();

            // end view init
            float widthFactor = view.ClientSize.Width / document.Width;
            float heightFactor = view.ClientSize.Height / document.Height;
            float zoomFactor = widthFactor < heightFactor ? widthFactor : heightFactor;

            view.Zoom(zoomFactor);
            zoomScrollbar.Value = (int)NMath.Round(zoomFactor * 100);
            view.EndInit();
        }

        protected override void AttachToEvents()
        {
            base.AttachToEvents();
            view.EventSinkService.TransformationsChanged += new EventHandler(EventSinkService_TransformationsChanged);
        }

        protected override void DetachFromEvents()
        {
            base.DetachFromEvents();
            view.EventSinkService.TransformationsChanged -= EventSinkService_TransformationsChanged;
        }

        #endregion

        #region Implementation

        private void InitFormControls()
        {
            PauseEventsHandling();

            view.Controller.Tools.DisableTools(new string[] { Nevron.Diagram.WinForm.NDWFR.ToolSelector });

            float zoomFactor = zoomScrollbar.Value / 100.0f;
            lblZoomFactor.Text = String.Format(ZoomLabel, zoomFactor);

            ResumeEventsHandling();
        }
        private void InitDocument()
        {
            document.Layers.RemoveAllChildren();

			// Configure the drawing document
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            document.RoutingManager.Enabled = false;
            document.BridgeManager.Enabled = false;
            document.Bounds = new NRectangleF(0, 0, 10000, 10000);
            document.BackgroundStyle.FillStyle = new NColorFillStyle(Color.LightBlue);

			// Add a style sheet
			NStyleSheet styleSheet = new NStyleSheet(WhiteTextStyleSheetName);
			NTextStyle textStyle = (NTextStyle)document.ComposeTextStyle().Clone();
			textStyle.FillStyle = new NColorFillStyle(KnownArgbColorValue.White);
			NStyle.SetTextStyle(styleSheet, textStyle);
			document.StyleSheets.AddChild(styleSheet);

			// Create a map importer
            m_MapImporter = new NEsriMapImporter();
            m_MapImporter.MapBounds = NMapBounds.World;

			// Add a shapefile
            NEsriShapefile countries = new NEsriShapefile(Path.Combine(Application.StartupPath, Countries));
            countries.NameColumn = "CNTRY_NAME";
            countries.TextColumn = "CNTRY_NAME";
			m_MapImporter.AddLayer(countries);

			// Read the map data
            m_MapImporter.Read();

			// Create a fill rule
            NMapFillRuleRange fillRule = new NMapFillRuleRange("POP_CNTRY", Color.White, Color.Black, 12);
            fillRule.DataGrouping = m_DataGrouping;
			countries.FillRule = fillRule;

			// Associate a shape created listener and import the map data
			m_MapImporter.ShapeCreatedListener = new NCustomShapeCreatedListener();
            m_MapImporter.Import(document, document.Bounds);

            // Generate a legend
            NMapLegendRange mapLegend = (NMapLegendRange)m_MapImporter.GetLegend(fillRule);
            mapLegend.Title = "Population";
            mapLegend.RangeFormatString = "{0:N0} - {1:N0} people";
            mapLegend.LastFormatString = "{0:N0} people and more";

            if (pMapLegend == null)
            {
                pMapLegend = new Panel();
                pMapLegend.Location = new Point(btnRecreateMap.Left, btnRecreateMap.Bottom + 10);
                pMapLegend.Width = btnRecreateMap.Width;
                pMapLegend.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                this.Controls.Add(pMapLegend);
            }

            mapLegend.Create(pMapLegend);
        }

        #endregion

        #region EventHandlers

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
        private void EventSinkService_TransformationsChanged(object sender, EventArgs e)
        {
            float zoomFactor = (view.ScaleX + view.ScaleY) / 2;
            int value = (int)NMath.Round(zoomFactor * 100);

            if (value != zoomScrollbar.Value)
            {
                zoomScrollbar.Value = value;
            }
        }
        private void zoomScrollbar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
        {
            float zoomFactor = (view.ScaleX + view.ScaleY) / 2;
            float scrollFactor = e.ScrollBar.Value / 100.0f;
            if (zoomFactor != scrollFactor)
            {
                view.Zoom(scrollFactor);
            }

            lblZoomFactor.Text = String.Format(ZoomLabel, scrollFactor);
        }
        private void btnRecreateMap_Click(object sender, EventArgs e)
        {
			if (rbEqualDistribution.Checked)
			{
				m_DataGrouping = new NDataGroupingEqualDistribution();
			}
			else if (rbEqualInterval.Checked)
			{
				m_DataGrouping = new NDataGroupingEqualInterval();
			}
			else
			{
				m_DataGrouping = new NDataGroupingOptimal();
			}

			m_DataGrouping.RoundedRanges = chkRoundedRanges.Checked;
            ResetExample();
        }

        #endregion

        #region Fields

        private NDataGrouping m_DataGrouping;

        private Nevron.UI.WinForm.Controls.NButton ShowDataButton;
        private NEsriMapImporter m_MapImporter;
        private Nevron.UI.WinForm.Controls.NHScrollBar zoomScrollbar;
        private Nevron.UI.WinForm.Controls.NButton btnRecreateMap;
        private Nevron.UI.WinForm.Controls.NRadioButton rbOptimal;
        private Nevron.UI.WinForm.Controls.NRadioButton rbEqualInterval;
        private Nevron.UI.WinForm.Controls.NRadioButton rbEqualDistribution;
		private Nevron.UI.WinForm.Controls.NCheckBox chkRoundedRanges;
        private Label label1;
        private Label lblZoomFactor;
        private Panel pMapLegend;

        #endregion

        #region Nested Types

        private class NCustomShapeCreatedListener : NShapeCreatedListener
		{
			#region INShapeCreatedListener

			public override bool OnPolygonCreated(NDiagramElement element, NMapFeature mapFeature)
            {
                NShape shape = element as NShape;
                if (shape == null)
                    return true;

                string name = mapFeature.GetAttributeValue("CNTRY_NAME").ToString();
                int population = Int32.Parse(mapFeature.GetAttributeValue("POP_CNTRY").ToString());

                NInteractivityStyle interactivityStyle = new NInteractivityStyle(String.Format("{0}'{1} population: {2:N0}", name,
                    name.EndsWith("s") ? String.Empty : "s", population));
				NStyle.SetInteractivityStyle(shape, interactivityStyle);

                return true;
            }
			public override bool OnMultiPolygonCreated(NDiagramElement element, NMapFeature mapFeature)
            {
                return OnPolygonCreated(element, mapFeature);
            }
			public override bool OnPolygonLabelCreated(NMapPolygonLabel polygonLabel, NMapFeature mapFeature)
			{
				NStyleableElement master = (NStyleableElement)polygonLabel.MasterElement;
				Color color = master.ComposeFillStyle().GetPrimaryColor().ToColor();

				if (color.R < 128)
				{
					// Make the text of dark shape labels white
					polygonLabel.StyleSheetName = WhiteTextStyleSheetName;
				}

				return true;
			}

            #endregion
        }

        #endregion

        #region Constants

        private const string ZoomLabel = @"Zoom factor: {0:P}";
		private const string Countries = @"..\..\Resources\Maps\countries.shp";
		private const string WhiteTextStyleSheetName = "WhiteText";

        #endregion
    }
}