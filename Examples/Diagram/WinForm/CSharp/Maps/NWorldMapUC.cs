using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Maps;
using Nevron.GraphicsCore;
using Nevron.Dom;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NWorldMapUC.
    /// </summary>
    public class NWorldMapUC : NDiagramExampleUC
    {
        #region Constructors

        public NWorldMapUC(NMainForm form)
            : base(form)
        {
            InitializeComponent();
            m_ZoomedCity = null;
        }

        #endregion

        #region Component Designer Generated Code

        private void InitializeComponent()
        {
            this.ShowDataButton = new Nevron.UI.WinForm.Controls.NButton();
            this.cbFile = new System.Windows.Forms.ComboBox();
            this.cbCity = new System.Windows.Forms.ComboBox();
            this.NavigateToButton = new Nevron.UI.WinForm.Controls.NButton();
            this.zoomScrollbar = new Nevron.UI.WinForm.Controls.NHScrollBar();
            this.lblZoomFactor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ShowDataButton
            // 
            this.ShowDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowDataButton.Location = new System.Drawing.Point(155, 11);
            this.ShowDataButton.Name = "ShowDataButton";
            this.ShowDataButton.Size = new System.Drawing.Size(97, 23);
            this.ShowDataButton.TabIndex = 3;
            this.ShowDataButton.Text = "Show DBF Data";
            this.ShowDataButton.UseVisualStyleBackColor = true;
            this.ShowDataButton.Click += new System.EventHandler(this.ShowDataButton_Click);
            // 
            // cbFile
            // 
            this.cbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFile.FormattingEnabled = true;
            this.cbFile.Location = new System.Drawing.Point(8, 12);
            this.cbFile.Name = "cbFile";
            this.cbFile.Size = new System.Drawing.Size(140, 21);
            this.cbFile.TabIndex = 4;
            // 
            // cbCity
            // 
            this.cbCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCity.FormattingEnabled = true;
            this.cbCity.Location = new System.Drawing.Point(8, 53);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(140, 21);
            this.cbCity.Sorted = true;
            this.cbCity.TabIndex = 6;
            // 
            // NavigateToButton
            // 
            this.NavigateToButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NavigateToButton.Location = new System.Drawing.Point(154, 52);
            this.NavigateToButton.Name = "NavigateToButton";
            this.NavigateToButton.Size = new System.Drawing.Size(97, 23);
            this.NavigateToButton.TabIndex = 7;
            this.NavigateToButton.Text = "Navigate To";
            this.NavigateToButton.UseVisualStyleBackColor = true;
            this.NavigateToButton.Click += new System.EventHandler(this.NavigateToButton_Click);
            // 
            // zoomScrollbar
            // 
            this.zoomScrollbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomScrollbar.Location = new System.Drawing.Point(7, 123);
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
            this.lblZoomFactor.Location = new System.Drawing.Point(5, 104);
            this.lblZoomFactor.Name = "lblZoomFactor";
            this.lblZoomFactor.Size = new System.Drawing.Size(94, 13);
            this.lblZoomFactor.TabIndex = 9;
            this.lblZoomFactor.Tag = "Zoom factor: {0:P}";
            this.lblZoomFactor.Text = "Zoom factor: {0:P}";
            this.lblZoomFactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NWorldMapUC
            // 
            this.Controls.Add(this.lblZoomFactor);
            this.Controls.Add(this.zoomScrollbar);
            this.Controls.Add(this.NavigateToButton);
            this.Controls.Add(this.cbCity);
            this.Controls.Add(this.cbFile);
            this.Controls.Add(this.ShowDataButton);
            this.Name = "NWorldMapUC";
            this.Controls.SetChildIndex(this.ShowDataButton, 0);
            this.Controls.SetChildIndex(this.cbFile, 0);
            this.Controls.SetChildIndex(this.cbCity, 0);
            this.Controls.SetChildIndex(this.NavigateToButton, 0);
            this.Controls.SetChildIndex(this.zoomScrollbar, 0);
            this.Controls.SetChildIndex(this.lblZoomFactor, 0);
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
            view.EndInit();
        }
        protected override void AttachToEvents()
        {
            base.AttachToEvents();

			document.EventSinkService.NodeClick += new NodeViewEventHandler(EventSinkService_NodeClick);
        }
        protected override void DetachFromEvents()
        {
            base.DetachFromEvents();

			document.EventSinkService.NodeClick -= new NodeViewEventHandler(EventSinkService_NodeClick);
		}

        #endregion

        #region Implementation
        
        private void InitDocument()
        {
            document.Layers.RemoveAllChildren();

            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            document.RoutingManager.Enabled = false;
            document.BridgeManager.Enabled = false;
            document.Bounds = new NRectangleF(0, 0, 10000, 10000);
            document.BackgroundStyle.FillStyle = new NColorFillStyle(Color.LightBlue);

            CreateStyleSheets();
            CreateStarPointShape();

            m_MapImporter = new NEsriMapImporter();
			m_MapImporter.MapBounds = NMapBounds.World;

            // Create the COUNTRIES shapefile
            NEsriShapefile countries = new NEsriShapefile(Path.Combine(Application.StartupPath, CountriesFileName));
            countries.NameColumn = "CNTRY_NAME";
            countries.TextColumn = "CNTRY_NAME";
            countries.MaxTextShowZoomFactor = 0.99f;			
			countries.FillRule = new NMapFillRuleValue("COLOR_MAP", Colors);
			m_MapImporter.AddLayer(countries);

            // Create the CITIES shapefile
            NEsriShapefile cities = new NEsriShapefile(Path.Combine(Application.StartupPath, CitiesFileName));
            cities.NameColumn = "NAME";
            cities.TextColumn = "NAME";
            cities.MinShowZoomFactor = 1.0f;

			cities.PointSizeColumn = "POPULATION";
			cities.MinPointShapeSize = new NSizeF(10, 10);
			cities.MaxPointShapeSize = new NSizeF(40, 40);

			m_MapImporter.AddLayer(cities);

			// Read the map data
            m_MapImporter.Read();

			// Import the map data to the drawing document
            m_MapImporter.ShapeCreatedListener = new NCustomShapeCreatedListener();
            m_MapImporter.Import(document, document.Bounds);
        }
        private void InitFormControls()
        {
            PauseEventsHandling();

            int i, count = m_MapImporter.LayerCount;
            for (i = 0; i < count; i++)
            {
                cbFile.Items.Add(m_MapImporter.GetLayerAt(i).Name);
            }

            cbFile.SelectedIndex = 0;
            cbCity.DataSource = m_MapImporter.GetLayerAt(1).DataTable;
            cbCity.ValueMember = "NAME";
            cbCity.DisplayMember = "NAME";
            m_ZoomWorkedOut = true;

            view.EventSinkService.TransformationsChanged += new EventHandler(EventSinkService_TransformationsChanged);
            view.Controller.Tools.DisableTools(new string[] { Nevron.Diagram.WinForm.NDWFR.ToolSelector });

            float zoomFactor = zoomScrollbar.Value / 100.0f;
            lblZoomFactor.Text = string.Format(lblZoomFactor.Tag.ToString(), zoomFactor);

            ResumeEventsHandling();
        }

        private void CreateStyleSheets()
        {
            // Create the zoomed city style sheet
            NStyleSheet zoomedCity = new NStyleSheet();
            zoomedCity.Name = "Zoomed City";
            zoomedCity.Style.FillStyle = new NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.DarkRed, Color.Red);
            document.StyleSheets.AddChild(zoomedCity);
        }
        private void CreateStarPointShape()
        {
            // create the graphics path representing the point shape
            NRectangleF modelBounds = new NRectangleF(-1, -1, 2, 2);
            GraphicsPath path = new GraphicsPath();
            CreateNGramPath(path, modelBounds, 5, -NMath.PIHalf, 0.5f);

            // wrap it in a model and name it
            NCustomPath customPath = new NCustomPath(path, PathType.ClosedFigure);
            customPath.Name = "Star";

            // add it to the stencil
            document.PointShapeStencil.AddChild(customPath);
        }
        private void CreateNGramPath(GraphicsPath path, NRectangleF rect, int edgeCount, float startAngle, float innerRadius)
        {
            float halfWidth = rect.Width / 2.0f;
            float halfHeight = rect.Height / 2.0f;
            float centerX = rect.X + halfWidth;
            float centerY = rect.Y + halfHeight;
            float incAngle = NMath.PI2 / edgeCount;
            float innerOffsetAngle = NMath.PI / edgeCount;

            PointF[] outer = new PointF[edgeCount];
            PointF[] inner = new PointF[edgeCount];

            for (int i = 0; i < edgeCount; i++)
            {
                float angle = startAngle + i * incAngle;
                outer[i].X = (float)Math.Round(centerX + Math.Cos(angle) * halfWidth, 1);
                outer[i].Y = (float)Math.Round(centerY + Math.Sin(angle) * halfHeight, 1);

                angle += innerOffsetAngle;
                inner[i].X = (float)Math.Round(centerX + Math.Cos(angle) * innerRadius, 1);
                inner[i].Y = (float)Math.Round(centerY + Math.Sin(angle) * innerRadius, 1);
            }

            for (int i = 0; i < (edgeCount - 1); i++)
            {
                path.AddLine(outer[i], inner[i]);
                path.AddLine(inner[i], outer[i + 1]);
            }

            path.AddLine(outer[edgeCount - 1], inner[edgeCount - 1]);
            path.CloseAllFigures();
        }

        #endregion

        #region Event Handlers

		private void zoomScrollbar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
        {
            float zoomFactor = (view.ScaleX + view.ScaleY) / 2;
            float scrollFactor = e.ScrollBar.Value / 100.0f;
			if (zoomFactor != scrollFactor)
			{
				view.Zoom(scrollFactor);
			}

            if (lblZoomFactor.Tag != null)
            {
                lblZoomFactor.Text = string.Format(lblZoomFactor.Tag.ToString(), scrollFactor);
            }
        }
        private void ShowDataButton_Click(object sender, EventArgs e)
        {
            Nevron.UI.WinForm.Controls.NForm f = new Nevron.UI.WinForm.Controls.NForm();
            f.SuspendLayout();

            //Create the data grid view
            Nevron.UI.WinForm.Controls.NDataGridView dg = new Nevron.UI.WinForm.Controls.NDataGridView();
            dg.Dock = DockStyle.Fill;
            dg.AllowUserToAddRows = false;
            dg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg.RowHeadersVisible = false;
            dg.ReadOnly = true;
            dg.DataSource = m_MapImporter.GetLayerAt(cbFile.SelectedIndex).DataTable;
            f.Controls.Add(dg);

            //Init the form
            f.Icon = this.Form.Icon;
            f.WindowState = FormWindowState.Maximized;
            f.Text = string.Format("DBF data for '{0}'", m_MapImporter.GetLayerAt(cbFile.SelectedIndex).Name);

            f.ResumeLayout();
            f.ShowDialog();
        }
		private void NavigateToButton_Click(object sender, EventArgs e)
		{
			if (cbCity.SelectedIndex == -1)
				return;

			// Find the map point label corresponding to the selected city
			NLayer citiesLayer = (NLayer)document.Layers.GetChildByName("cities");
			NMapLabelsShape mapLabelsShape = (NMapLabelsShape)citiesLayer.GetChildAt(0);
			NMapPointLabel pointLabel = (NMapPointLabel)mapLabelsShape.MapLabels.GetChildByName(cbCity.Text);

			if (pointLabel == null)
				return;

			view.Zoom(2.0f, pointLabel.PinPoint, true);
			if (m_ZoomedCity != null)
			{
				m_ZoomedCity.StyleSheetName = String.Empty;
			}

			pointLabel.StyleSheetName = "Zoomed City";
			m_ZoomedCity = pointLabel;
		}
        private void EventSinkService_TransformationsChanged(object sender, EventArgs e)
        {
            if (m_ZoomWorkedOut)
            {
                m_ZoomWorkedOut = false;
                return;
            }

            float zoomFactor = (view.ScaleX + view.ScaleY) / 2;
            if (lblZoomFactor.Tag != null)
            {
                lblZoomFactor.Text = string.Format(lblZoomFactor.Tag.ToString(), zoomFactor);
            }
            zoomScrollbar.Value = (int)(Math.Round(zoomFactor * 100));
        }
		private void EventSinkService_NodeClick(NNodeViewEventArgs args)
		{
			NShape shape = args.Node as NShape;
			if (shape == null)
				return;

			MessageBox.Show(shape.Name, "Country clicked:", MessageBoxButtons.OK, MessageBoxIcon.None);
			args.Handled = true;
		}
 
        #endregion

        #region Fields

        private bool m_ZoomWorkedOut;
        private NEsriMapImporter m_MapImporter;
        private NMapPointLabel m_ZoomedCity;

        #endregion

        #region Designer Fields

        private Nevron.UI.WinForm.Controls.NButton ShowDataButton;
        private Nevron.UI.WinForm.Controls.NButton NavigateToButton;
        private Nevron.UI.WinForm.Controls.NHScrollBar zoomScrollbar;
        private Label lblZoomFactor;
        private ComboBox cbFile;
        private ComboBox cbCity;

        #endregion

        #region Constants

		private const string CountriesFileName = @"..\..\Resources\Maps\countries.shp";
		private const string CitiesFileName = @"..\..\Resources\Maps\cities.shp";

        /// <summary>
        /// The colors used to fill the countries.
        /// </summary>
        private static readonly Color[] Colors = new Color[] {
            Color.Tomato,
            Color.PaleGreen,
            Color.Gold,
            Color.PaleGoldenrod,
            Color.Tan,
            Color.Khaki,
            Color.OldLace,
            Color.Orange
        };

        #endregion

        #region Nested Types

        private class NCustomShapeCreatedListener : NShapeCreatedListener
		{
			#region INShapeCreatedListener Overrides

			public override bool OnPolygonCreated(NDiagramElement element, NMapFeature mapFeature)
            {
                NShape shape = element as NShape;
                if (shape == null)
                    return true;

                string name = mapFeature.GetAttributeValue("CNTRY_NAME").ToString();
                float population = Single.Parse(mapFeature.GetAttributeValue("POP_CNTRY").ToString());
                float landArea = Single.Parse(mapFeature.GetAttributeValue("SQKM").ToString());

                // add a tooltip to the shape
                NInteractivityStyle interactivityStyle = new NInteractivityStyle(
                    string.Format("{1}{0}======================{0}Land Area: {2:N} km2{0}Population: {3:N0} people{0}Pop. Density: {4:N} people/km2",
                    Environment.NewLine, name, landArea, population, population / landArea));

                shape.Style.InteractivityStyle = interactivityStyle;
                return true;
            }
			public override bool OnMultiPolygonCreated(NDiagramElement element, NMapFeature mapFeature)
            {
                return OnPolygonCreated(element, mapFeature);
            }
			public override bool OnPointCreated(NMapPointLabel pointLabel, NMapFeature mapFeature)
            {
                if (mapFeature.GetAttributeValue("CAPITAL").Equals("Y"))
                {
					pointLabel.ShapeType = PointShape.Custom;
					pointLabel.CustomShapeName = "Star";
                }

                return true;
            }

            #endregion

            #region Constants

            private static readonly float[,] POP = new float[,]{
                {1000000, 1.3f},
                {2000000, 1.6f},
                {5000000, 2.0f},
                {10000000, 2.5f},
                {20000000, 3.0f}
            };
            
            #endregion
        }

        #endregion
    }
}