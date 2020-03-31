using System;
using System.Collections.Generic;
using System.Drawing;

using Nevron.Diagram.Layout;
using Nevron.Diagram;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NSpringLayoutUC.
    /// </summary>
    public class NStackLayoutUC : NDiagramExampleUC
    {
        #region Constructor

        public NStackLayoutUC(NMainForm form)
            : base(form)
		{
			InitializeComponent();
		}

		#endregion

        #region Component Designer Generated Code

        private void InitializeComponent()
        {
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.LayoutButton = new Nevron.UI.WinForm.Controls.NButton();
            this.label1 = new System.Windows.Forms.Label();
            this.widthScrollbar = new Nevron.UI.WinForm.Controls.NHScrollBar();
            this.heightScrollbar = new Nevron.UI.WinForm.Controls.NHScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.ShowDesiredSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(8, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid1.Size = new System.Drawing.Size(244, 362);
            this.propertyGrid1.TabIndex = 1;
            // 
            // LayoutButton
            // 
            this.LayoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutButton.Location = new System.Drawing.Point(8, 491);
            this.LayoutButton.Name = "LayoutButton";
            this.LayoutButton.Size = new System.Drawing.Size(244, 23);
            this.LayoutButton.TabIndex = 2;
            this.LayoutButton.Text = "Layout";
            this.LayoutButton.UseVisualStyleBackColor = true;
            this.LayoutButton.Click += new System.EventHandler(this.LayoutButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(3, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Drawing width:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // widthScrollbar
            // 
            this.widthScrollbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.widthScrollbar.Location = new System.Drawing.Point(8, 415);
            this.widthScrollbar.Maximum = 1000;
            this.widthScrollbar.Minimum = 200;
            this.widthScrollbar.MinimumSize = new System.Drawing.Size(34, 17);
            this.widthScrollbar.Name = "widthScrollbar";
            this.widthScrollbar.Size = new System.Drawing.Size(244, 17);
            this.widthScrollbar.TabIndex = 4;
            this.widthScrollbar.Value = 400;
            this.widthScrollbar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.WidthScrollbar_Scroll);
            // 
            // heightScrollbar
            // 
            this.heightScrollbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.heightScrollbar.Location = new System.Drawing.Point(8, 457);
            this.heightScrollbar.Maximum = 1000;
            this.heightScrollbar.Minimum = 200;
            this.heightScrollbar.MinimumSize = new System.Drawing.Size(34, 17);
            this.heightScrollbar.Name = "heightScrollbar";
            this.heightScrollbar.Size = new System.Drawing.Size(244, 17);
            this.heightScrollbar.TabIndex = 6;
            this.heightScrollbar.Value = 200;
            this.heightScrollbar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.HeightScrollbar_Scroll);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(3, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Drawing height:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ShowDesiredSizeCheckBox
            // 
            this.ShowDesiredSizeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowDesiredSizeCheckBox.Location = new System.Drawing.Point(8, 371);
            this.ShowDesiredSizeCheckBox.Name = "ShowDesiredSizeCheckBox";
            this.ShowDesiredSizeCheckBox.Size = new System.Drawing.Size(244, 17);
            this.ShowDesiredSizeCheckBox.TabIndex = 7;
            this.ShowDesiredSizeCheckBox.Text = "Show desired size";
            this.ShowDesiredSizeCheckBox.UseVisualStyleBackColor = true;
            this.ShowDesiredSizeCheckBox.CheckedChanged += new System.EventHandler(this.ShowDesiredSizeCheckBox_CheckedChanged);
            // 
            // NStackLayoutUC
            // 
            this.Controls.Add(this.ShowDesiredSizeCheckBox);
            this.Controls.Add(this.heightScrollbar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.widthScrollbar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LayoutButton);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "NStackLayoutUC";
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.Controls.SetChildIndex(this.LayoutButton, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.widthScrollbar, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.heightScrollbar, 0);
            this.Controls.SetChildIndex(this.ShowDesiredSizeCheckBox, 0);
            this.ResumeLayout(false);

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // init layout
            m_Layout = new NStackLayout();

            // cells occupy the entire space of the available slots
            m_Layout.HorizontalContentPlacement = ContentPlacement.Fit;
            m_Layout.VerticalContentPlacement = ContentPlacement.Fit;

            propertyGrid1.SelectedObject = m_Layout;

            view.BeginInit();
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.ViewLayout = ViewLayout.Fit;

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
            base.AttachToEvents();
        }

        protected override void DetachFromEvents()
        {
            base.DetachFromEvents();
        }

        #endregion

        #region Implementation

        private void CreateDiagram()
        {
            const int min = 100, max = 200;

            int i;
            NShape shape;
            Random random = new Random();
            NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory(document);

            for (i = 0; i < 5; i++)
            {
                Color[] shapeLightColors = new Color[] {Color.FromArgb(236, 97, 49),
                                                    Color.FromArgb(68, 90, 108),
                                                    Color.FromArgb(247, 150, 56),
                                                    Color.FromArgb(129, 133, 133),
                                                    Color.FromArgb(255, 165, 109)};

                Color[] shapeDarkColors = new Color[] {Color.FromArgb(246, 176, 152),
                                                    Color.FromArgb(162, 173, 182),
                                                    Color.FromArgb(251, 203, 156),
                                                    Color.FromArgb(192, 194, 194),
                                                    Color.FromArgb(255, 210, 182)};

                shape = basicShapesFactory.CreateShape((int)BasicShapes.Rectangle);
                shape.Style.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant3, shapeLightColors[i], shapeDarkColors[i]);
                shape.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
                shape.Text = i.ToString();

                // generate random width and height
                float width = random.Next(min, max);
                float height = random.Next(min, max);

                // instruct the layouts to use fixed, uses specified desired width and desired height
                shape.LayoutData.UseShapeWidth = false;
                shape.LayoutData.DesiredWidth = width;

                shape.LayoutData.UseShapeHeight = false;
                shape.LayoutData.DesiredHeight = height;

                shape.Bounds = new NRectangleF(0, 0, width, height);
                document.ActiveLayer.AddChild(shape);
            }
        }

        private void InitFormControls()
        {
            PauseEventsHandling();

            widthScrollbar.Value = (int)document.Width;
            heightScrollbar.Value = (int)document.Height;

            ResumeEventsHandling();
        }

        private void InitDocument()
        {
            // we do not need history for this example
            document.HistoryService.Pause();

            // create a layer which to host the desired size rect shape
            NLayer layer = new NLayer();
            document.Layers.AddChild(layer);

            // create the desired size rect shape
            m_DesiredSizeShape = new NRectangleShape(0, 0, 1, 1);
            m_DesiredSizeShape.Style.FillStyle = new NColorFillStyle(System.Drawing.Color.FromArgb(200, 128, 128, 128));
            m_DesiredSizeShape.Style.StrokeStyle = new NStrokeStyle(1, KnownArgbColorValue.Red);
            m_DesiredSizeShape.Visible = ShowDesiredSizeCheckBox.Checked;
            layer.AddChild(m_DesiredSizeShape);

            // create a sample diagram
            CreateDiagram();

            // layout it
            LayoutButton.PerformClick();
        }

        private void LayoutButton_Click(object sender, EventArgs e)
        {
            // get the shapes to layout
            NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

            // create a layout context
            NLayoutContext layoutContext = new NLayoutContext();
            layoutContext.GraphAdapter = new NShapeGraphAdapter();
            layoutContext.BodyAdapter = new NShapeBodyAdapter(document);
            layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);

            if (m_Layout != null)
            {
                // update the desired size
                NSizeF desiredSize = m_Layout.GetDesiredLayoutSize(shapes, layoutContext);
                NRectangleF desiredLayoutArea = new NRectangleF(layoutContext.BodyContainerAdapter.GetLayoutArea().Location, desiredSize);
                m_DesiredSizeShape.Bounds = desiredLayoutArea;

                // layout the shapes
                m_Layout.Layout(shapes, layoutContext);
            }
        }

        private void WidthScrollbar_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            document.Width = widthScrollbar.Value;
            LayoutButton.PerformClick();
        }

        private void HeightScrollbar_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            document.Height = heightScrollbar.Value;
            LayoutButton.PerformClick();
        }

        private void ShowDesiredSizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (m_DesiredSizeShape == null)
                return;

            m_DesiredSizeShape.Visible = ShowDesiredSizeCheckBox.Checked;
            document.SmartRefreshAllViews();
        }

        #endregion

        #region Designer Fields

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Nevron.UI.WinForm.Controls.NButton LayoutButton;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NHScrollBar widthScrollbar;
        private Nevron.UI.WinForm.Controls.NHScrollBar heightScrollbar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ShowDesiredSizeCheckBox;

        #endregion
      
        #region Fields

        private NStackLayout m_Layout;
        private NRectangleShape m_DesiredSizeShape;

        #endregion
    }
}