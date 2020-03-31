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
    public class NMapDataBindingUC : NDiagramExampleUC
    {
        #region Constructors

        public NMapDataBindingUC(NMainForm form)
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
			this.label1 = new System.Windows.Forms.Label();
			this.rbEqualDistribution = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.rbEqualInterval = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.rbOptimal = new Nevron.UI.WinForm.Controls.NRadioButton();
			this.btnRecreateMap = new Nevron.UI.WinForm.Controls.NButton();
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
			this.zoomScrollbar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ZoomScrollbar_ValueChanged);
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.MediumBlue;
			this.label1.Location = new System.Drawing.Point(5, 171);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 16);
			this.label1.TabIndex = 12;
			this.label1.Tag = "";
			this.label1.Text = "Data Grouping:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rbEqualDistribution
			// 
			this.rbEqualDistribution.AutoSize = true;
			this.rbEqualDistribution.ButtonProperties.BorderOffset = 2;
			this.rbEqualDistribution.Location = new System.Drawing.Point(7, 200);
			this.rbEqualDistribution.Name = "rbEqualDistribution";
			this.rbEqualDistribution.Size = new System.Drawing.Size(107, 17);
			this.rbEqualDistribution.TabIndex = 13;
			this.rbEqualDistribution.Text = "Equal Distribution";
			this.rbEqualDistribution.UseVisualStyleBackColor = true;
			// 
			// rbEqualInterval
			// 
			this.rbEqualInterval.AutoSize = true;
			this.rbEqualInterval.ButtonProperties.BorderOffset = 2;
			this.rbEqualInterval.Location = new System.Drawing.Point(8, 223);
			this.rbEqualInterval.Name = "rbEqualInterval";
			this.rbEqualInterval.Size = new System.Drawing.Size(90, 17);
			this.rbEqualInterval.TabIndex = 14;
			this.rbEqualInterval.Text = "Equal Interval";
			this.rbEqualInterval.UseVisualStyleBackColor = true;
			// 
			// rbOptimal
			// 
			this.rbOptimal.AutoSize = true;
			this.rbOptimal.ButtonProperties.BorderOffset = 2;
			this.rbOptimal.Checked = true;
			this.rbOptimal.Location = new System.Drawing.Point(8, 246);
			this.rbOptimal.Name = "rbOptimal";
			this.rbOptimal.Size = new System.Drawing.Size(60, 17);
			this.rbOptimal.TabIndex = 15;
			this.rbOptimal.TabStop = true;
			this.rbOptimal.Text = "Optimal";
			this.rbOptimal.UseVisualStyleBackColor = true;
			// 
			// btnRecreateMap
			// 
			this.btnRecreateMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.btnRecreateMap.Location = new System.Drawing.Point(7, 275);
			this.btnRecreateMap.Name = "btnRecreateMap";
			this.btnRecreateMap.Size = new System.Drawing.Size(244, 23);
			this.btnRecreateMap.TabIndex = 16;
			this.btnRecreateMap.Text = "Recreate Map";
			this.btnRecreateMap.UseVisualStyleBackColor = true;
			this.btnRecreateMap.Click += new System.EventHandler(this.btnRecreateMap_Click);
			// 
			// chkRoundRanges
			// 
			this.chkRoundedRanges.AutoSize = true;
			this.chkRoundedRanges.ButtonProperties.BorderOffset = 2;
			this.chkRoundedRanges.Checked = true;
			this.chkRoundedRanges.Location = new System.Drawing.Point(8, 141);
			this.chkRoundedRanges.Name = "chkRoundRanges";
			this.chkRoundedRanges.Size = new System.Drawing.Size(98, 17);
			this.chkRoundedRanges.TabIndex = 23;
			this.chkRoundedRanges.Text = "Rounded Ranges";
			this.chkRoundedRanges.UseVisualStyleBackColor = true;
			// 
			// NMapDataBindingUC
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
			this.Name = "NMapDataBindingUC";
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

            m_bZoomWorkedOut = true;

            view.Controller.Tools.DisableTools(new string[] { Nevron.Diagram.WinForm.NDWFR.ToolSelector });

            float zoomFactor = zoomScrollbar.Value / 100.0f;
            lblZoomFactor.Text = String.Format(ZOOM_LABEL, zoomFactor);

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

            m_MapImporter = new NEsriMapImporter();
            m_MapImporter.MapBounds = NMapBounds.World;

			// Configure and add a shapefile
			NEsriShapefile countries = new NEsriShapefile(Path.Combine(Application.StartupPath, COUNTRIES));
            countries.NameColumn = "CNTRY_NAME";
            countries.TextColumn = "CNTRY_NAME";
			m_MapImporter.AddLayer(countries);

			// Read the map data
            m_MapImporter.Read();
            
            // Create a data binding source
			NMapOleDbDataBindingSource source = new NMapOleDbDataBindingSource(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\..\..\..\Resources\Maps\Sales.mdb");
			source.SelectQuery = "SELECT * FROM Sales";

			// Create a data binding context
            NMapDataBindingContext context = new NMapDataBindingContext();
			context.AddColumnMatching("CNTRY_NAME", "Country");
			context.ColumnsToImport.Add("Sales");

            // Perform the data binding
            countries.DataBind(source, context);

            // Create and apply a fill rule
            NMapFillRuleRange fillRule = new NMapFillRuleRange("Sales", Color.White, Color.DarkGreen, 8);
            fillRule.DataGrouping = m_DataGrouping;
			countries.FillRule = fillRule;

            m_MapImporter.ShapeCreatedListener = new NCustomShapeCreatedListener();
            m_MapImporter.ShapeImporter.ImportInMultipleLayers = true;
            m_MapImporter.Import(document, document.Bounds);

            // Generate the legend
            NMapLegendRange mapLegend = (NMapLegendRange)m_MapImporter.GetLegend(fillRule);
            mapLegend.Title = "Sales";
            mapLegend.RangeFormatString = "{0:N0} - {1:N0} million dollars";
            mapLegend.LastFormatString = "{0:N0} million dollars and more";

            if (pMapLegend == null)
            {
                pMapLegend = new Panel();
                pMapLegend.Location = new Point(btnRecreateMap.Left, btnRecreateMap.Bottom + 10);
                pMapLegend.Width = btnRecreateMap.Width;
                pMapLegend.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                this.Controls.Add(pMapLegend);
            }

            mapLegend.Create(pMapLegend);

            // Size document to content
            document.SizeToContent(new NSizeF(0, 0), new Nevron.Diagram.NMargins(0));
        }

        #endregion

        #region Event Handlers

        private void ShowDataButton_Click(object sender, EventArgs e)
        {
            Nevron.UI.WinForm.Controls.NForm f = new Nevron.UI.WinForm.Controls.NForm();
            f.SuspendLayout();

            // Create the data grid view
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
            int value = (int)Math.Round(zoomFactor * 100);

			if (value != zoomScrollbar.Value)
			{
                zoomScrollbar.Value = value;
			}
        }
        private void ZoomScrollbar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
        {
            float zoomFactor = (view.ScaleX + view.ScaleY) / 2;
            float scrollFactor = e.ScrollBar.Value / 100.0f;
            if (zoomFactor != scrollFactor)
            {
                view.Zoom(scrollFactor);
            }

            lblZoomFactor.Text = String.Format(ZOOM_LABEL, scrollFactor);
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

        private bool m_bZoomWorkedOut;
        private NDataGrouping m_DataGrouping;

        private NButton ShowDataButton;
        private NEsriMapImporter m_MapImporter;
        private NHScrollBar zoomScrollbar;
        private Label label1;
        private NRadioButton rbEqualDistribution;
        private NRadioButton rbEqualInterval;
        private NRadioButton rbOptimal;
        private NButton btnRecreateMap;
        private Label lblZoomFactor;
        private Panel pMapLegend;
		private NCheckBox chkRoundedRanges;

        #endregion

        #region Constants

        private const string ZOOM_LABEL = @"Zoom factor: {0:P}";
        private const string COUNTRIES = @"..\..\Resources\Maps\countries.shp";

        #endregion

        #region Nested Types

        private class NCustomShapeCreatedListener : NShapeCreatedListener
		{
			#region NCustomShapeCreatedListener

			public override bool OnPolygonCreated(NDiagramElement element, NMapFeature mapFeature)
            {
                NShape shape = element as NShape;
                if (shape == null)
                    return true;

                string name = mapFeature.GetAttributeValue("CNTRY_NAME").ToString();

				decimal sales = (decimal)mapFeature.GetAttributeValue("Sales");
                NInteractivityStyle interactivityStyle = new NInteractivityStyle(String.Format("Sales value in {0}: {1:N0} million dollars", name, sales));
                shape.Style.InteractivityStyle = interactivityStyle;

                return true;
            }
			public override bool OnMultiPolygonCreated(NDiagramElement element, NMapFeature mapFeature)
            {
                return OnPolygonCreated(element, mapFeature);
            }

            #endregion
        }

        #endregion
    }
}