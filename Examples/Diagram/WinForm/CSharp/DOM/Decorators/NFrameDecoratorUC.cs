using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Filters;
using Nevron.Editors;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Batches;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Templates;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.WinForm.Commands;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NFrameDecoratorUC.
	/// </summary>
	public class NFrameDecoratorUC : NDiagramExampleUC
	{
		#region Constructor

		public NFrameDecoratorUC(NMainForm form) : base(form)
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
            this.HeaderFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.HeaderStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.BackgroundStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.BackgroundFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.ShapeHitTestableCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.HitTestHeaderCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.HitTestBackgroundCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.HitTestFrameCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.HeaderSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.HeaderTextStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.ShowHeaderCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ShowBackgroundCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderFillStyleButton
            // 
            this.HeaderFillStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HeaderFillStyleButton.Location = new System.Drawing.Point(6, 217);
            this.HeaderFillStyleButton.Name = "HeaderFillStyleButton";
            this.HeaderFillStyleButton.Size = new System.Drawing.Size(232, 23);
            this.HeaderFillStyleButton.TabIndex = 8;
            this.HeaderFillStyleButton.Text = "Header Fill Style...";
            this.HeaderFillStyleButton.UseVisualStyleBackColor = true;
            this.HeaderFillStyleButton.Click += new System.EventHandler(this.HeaderFillStyleButton_Click);
            // 
            // HeaderStrokeStyleButton
            // 
            this.HeaderStrokeStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HeaderStrokeStyleButton.Location = new System.Drawing.Point(6, 246);
            this.HeaderStrokeStyleButton.Name = "HeaderStrokeStyleButton";
            this.HeaderStrokeStyleButton.Size = new System.Drawing.Size(232, 23);
            this.HeaderStrokeStyleButton.TabIndex = 9;
            this.HeaderStrokeStyleButton.Text = "Header Stroke Style...";
            this.HeaderStrokeStyleButton.UseVisualStyleBackColor = true;
            this.HeaderStrokeStyleButton.Click += new System.EventHandler(this.HeaderStrokeStyleButton_Click);
            // 
            // BackgroundStrokeStyleButton
            // 
            this.BackgroundStrokeStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundStrokeStyleButton.Location = new System.Drawing.Point(6, 316);
            this.BackgroundStrokeStyleButton.Name = "BackgroundStrokeStyleButton";
            this.BackgroundStrokeStyleButton.Size = new System.Drawing.Size(232, 23);
            this.BackgroundStrokeStyleButton.TabIndex = 11;
            this.BackgroundStrokeStyleButton.Text = "Background Stroke Style...";
            this.BackgroundStrokeStyleButton.UseVisualStyleBackColor = true;
            this.BackgroundStrokeStyleButton.Click += new System.EventHandler(this.BackgroundStrokeStyleButton_Click);
            // 
            // BackgroundFillStyleButton
            // 
            this.BackgroundFillStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundFillStyleButton.Location = new System.Drawing.Point(6, 287);
            this.BackgroundFillStyleButton.Name = "BackgroundFillStyleButton";
            this.BackgroundFillStyleButton.Size = new System.Drawing.Size(232, 23);
            this.BackgroundFillStyleButton.TabIndex = 10;
            this.BackgroundFillStyleButton.Text = "Background Fill Style...";
            this.BackgroundFillStyleButton.UseVisualStyleBackColor = true;
            this.BackgroundFillStyleButton.Click += new System.EventHandler(this.BackgroundFillStyleButton_Click);
            // 
            // ShapeHitTestableCheck
            // 
            this.ShapeHitTestableCheck.AutoSize = true;
            this.ShapeHitTestableCheck.ButtonProperties.BorderOffset = 2;
            this.ShapeHitTestableCheck.Location = new System.Drawing.Point(6, 51);
            this.ShapeHitTestableCheck.Name = "ShapeHitTestableCheck";
            this.ShapeHitTestableCheck.Size = new System.Drawing.Size(117, 17);
            this.ShapeHitTestableCheck.TabIndex = 12;
            this.ShapeHitTestableCheck.Text = "Shape Hit Testable";
            this.ShapeHitTestableCheck.UseVisualStyleBackColor = true;
            this.ShapeHitTestableCheck.CheckedChanged += new System.EventHandler(this.ShapeHitTestableCheck_CheckedChanged);
            // 
            // HitTestHeaderCheck
            // 
            this.HitTestHeaderCheck.AutoSize = true;
            this.HitTestHeaderCheck.ButtonProperties.BorderOffset = 2;
            this.HitTestHeaderCheck.Location = new System.Drawing.Point(17, 74);
            this.HitTestHeaderCheck.Name = "HitTestHeaderCheck";
            this.HitTestHeaderCheck.Size = new System.Drawing.Size(101, 17);
            this.HitTestHeaderCheck.TabIndex = 13;
            this.HitTestHeaderCheck.Text = "Hit Test Header";
            this.HitTestHeaderCheck.UseVisualStyleBackColor = true;
            this.HitTestHeaderCheck.CheckedChanged += new System.EventHandler(this.HitTestHeaderCheck_CheckedChanged);
            // 
            // HitTestBackgroundCheck
            // 
            this.HitTestBackgroundCheck.AutoSize = true;
            this.HitTestBackgroundCheck.ButtonProperties.BorderOffset = 2;
            this.HitTestBackgroundCheck.Location = new System.Drawing.Point(17, 97);
            this.HitTestBackgroundCheck.Name = "HitTestBackgroundCheck";
            this.HitTestBackgroundCheck.Size = new System.Drawing.Size(124, 17);
            this.HitTestBackgroundCheck.TabIndex = 14;
            this.HitTestBackgroundCheck.Text = "Hit Test Background";
            this.HitTestBackgroundCheck.UseVisualStyleBackColor = true;
            this.HitTestBackgroundCheck.CheckedChanged += new System.EventHandler(this.HitTestBackgroundCheck_CheckedChanged);
            // 
            // HitTestFrameCheck
            // 
            this.HitTestFrameCheck.AutoSize = true;
            this.HitTestFrameCheck.ButtonProperties.BorderOffset = 2;
            this.HitTestFrameCheck.Location = new System.Drawing.Point(17, 120);
            this.HitTestFrameCheck.Name = "HitTestFrameCheck";
            this.HitTestFrameCheck.Size = new System.Drawing.Size(120, 17);
            this.HitTestFrameCheck.TabIndex = 15;
            this.HitTestFrameCheck.Text = "HitTestFrameCheck";
            this.HitTestFrameCheck.UseVisualStyleBackColor = true;
            this.HitTestFrameCheck.CheckedChanged += new System.EventHandler(this.HitTestFrameCheck_CheckedChanged);
            // 
            // HeaderSizeUpDown
            // 
            this.HeaderSizeUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HeaderSizeUpDown.AutoSize = true;
            this.HeaderSizeUpDown.Location = new System.Drawing.Point(79, 144);
            this.HeaderSizeUpDown.Name = "HeaderSizeUpDown";
            this.HeaderSizeUpDown.Size = new System.Drawing.Size(158, 20);
            this.HeaderSizeUpDown.TabIndex = 16;
            this.HeaderSizeUpDown.ValueChanged += new System.EventHandler(this.HeaderSizeUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Header Size:";
            // 
            // HeaderTextStyleButton
            // 
            this.HeaderTextStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HeaderTextStyleButton.Location = new System.Drawing.Point(6, 188);
            this.HeaderTextStyleButton.Name = "HeaderTextStyleButton";
            this.HeaderTextStyleButton.Size = new System.Drawing.Size(232, 23);
            this.HeaderTextStyleButton.TabIndex = 18;
            this.HeaderTextStyleButton.Text = "Header Text Style...";
            this.HeaderTextStyleButton.UseVisualStyleBackColor = true;
            this.HeaderTextStyleButton.Click += new System.EventHandler(this.HeaderTextStyleButton_Click);
            // 
            // ShowHeaderCheck
            // 
            this.ShowHeaderCheck.AutoSize = true;
            this.ShowHeaderCheck.ButtonProperties.BorderOffset = 2;
            this.ShowHeaderCheck.Location = new System.Drawing.Point(6, 5);
            this.ShowHeaderCheck.Name = "ShowHeaderCheck";
            this.ShowHeaderCheck.Size = new System.Drawing.Size(91, 17);
            this.ShowHeaderCheck.TabIndex = 19;
            this.ShowHeaderCheck.Text = "Show Header";
            this.ShowHeaderCheck.UseVisualStyleBackColor = true;
            this.ShowHeaderCheck.CheckedChanged += new System.EventHandler(this.ShowHeaderCheck_CheckedChanged);
            // 
            // ShowBackgroundCheck
            // 
            this.ShowBackgroundCheck.AutoSize = true;
            this.ShowBackgroundCheck.ButtonProperties.BorderOffset = 2;
            this.ShowBackgroundCheck.Location = new System.Drawing.Point(6, 28);
            this.ShowBackgroundCheck.Name = "ShowBackgroundCheck";
            this.ShowBackgroundCheck.Size = new System.Drawing.Size(114, 17);
            this.ShowBackgroundCheck.TabIndex = 20;
            this.ShowBackgroundCheck.Text = "Show Background";
            this.ShowBackgroundCheck.UseVisualStyleBackColor = true;
            this.ShowBackgroundCheck.CheckedChanged += new System.EventHandler(this.ShowBackgroundCheck_CheckedChanged);
            // 
            // NFrameDecoratorUC
            // 
            this.Controls.Add(this.ShowBackgroundCheck);
            this.Controls.Add(this.ShowHeaderCheck);
            this.Controls.Add(this.HeaderTextStyleButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HeaderSizeUpDown);
            this.Controls.Add(this.HitTestFrameCheck);
            this.Controls.Add(this.HitTestBackgroundCheck);
            this.Controls.Add(this.HitTestHeaderCheck);
            this.Controls.Add(this.ShapeHitTestableCheck);
            this.Controls.Add(this.BackgroundStrokeStyleButton);
            this.Controls.Add(this.BackgroundFillStyleButton);
            this.Controls.Add(this.HeaderStrokeStyleButton);
            this.Controls.Add(this.HeaderFillStyleButton);
            this.Name = "NFrameDecoratorUC";
            this.Size = new System.Drawing.Size(248, 501);
            this.Controls.SetChildIndex(this.HeaderFillStyleButton, 0);
            this.Controls.SetChildIndex(this.HeaderStrokeStyleButton, 0);
            this.Controls.SetChildIndex(this.BackgroundFillStyleButton, 0);
            this.Controls.SetChildIndex(this.BackgroundStrokeStyleButton, 0);
            this.Controls.SetChildIndex(this.ShapeHitTestableCheck, 0);
            this.Controls.SetChildIndex(this.HitTestHeaderCheck, 0);
            this.Controls.SetChildIndex(this.HitTestBackgroundCheck, 0);
            this.Controls.SetChildIndex(this.HitTestFrameCheck, 0);
            this.Controls.SetChildIndex(this.HeaderSizeUpDown, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.HeaderTextStyleButton, 0);
            this.Controls.SetChildIndex(this.ShowHeaderCheck, 0);
            this.Controls.SetChildIndex(this.ShowBackgroundCheck, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderSizeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

            view.ViewLayout = ViewLayout.Fit;
			view.Grid.Visible = false;
			view.HorizontalRuler.Visible = false;
			view.VerticalRuler.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.TrackersManager.Enabled = false; 

			// init document
			document.BeginInit();
			InitDocument();
			document.EndInit();

			// end view init
			view.EndInit();

            // init the form controls
            PauseEventsHandling();
            InitFormControls();
            ResumeEventsHandling();
		}
		
		#endregion

		#region Implementation

		private void InitDocument()
		{
            NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
            basicShapesFactory.DefaultSize = new NSizeF(100, 100);

            // create groups and apply a frame decorator to each one of them
            for (int i = 0; i < 4; i++)
            {
                NShape shape1 = basicShapesFactory.CreateShape(BasicShapes.Octagon);
                shape1.Bounds = new NRectangleF(0, 0, 80, 80);

                NShape shape2 = basicShapesFactory.CreateShape(BasicShapes.Ellipse);
                shape2.Bounds = new NRectangleF(100, 100, 80, 80);

                NGroup group = new NGroup();
                group.Shapes.AddChild(shape1);
                group.Shapes.AddChild(shape2);
                group.Padding = new Nevron.Diagram.NMargins(30);
                group.UpdateModelBounds();

                NFrameDecorator frameDecorator = new NFrameDecorator();
                frameDecorator.StyleSheetName = "Decorators";
                frameDecorator.ShapeHitTestable = true;
                frameDecorator.Header.Text = "Header";

                group.CreateShapeElements(ShapeElementsMask.Decorators);
                group.Decorators.AddChild(frameDecorator);

                document.ActiveLayer.AddChild(group);
            }

            // layout them with a table layout
            NTableLayout layout = new NTableLayout();
            layout.ConstrainMode = CellConstrainMode.Ordinal;
            layout.MaxOrdinal = 2;
            layout.HorizontalSpacing = 20;
            layout.VerticalSpacing = 20;
            layout.Layout(document.ActiveLayer.Children(null), new NDrawingLayoutContext(document));

            // size document to content
            document.SizeToContent(NSizeF.Empty, document.AutoBoundsPadding);
		}
        private void InitFormControls()
        {
            ShapeHitTestableCheck.Checked = false;
            HitTestFrameCheck.Checked = true;
            HitTestHeaderCheck.Checked = true;
            HitTestBackgroundCheck.Checked = true;
            HeaderSizeUpDown.Value = 20;
            HeaderSizeUpDown.Minimum = 1;
        }

		#endregion

        #region Event Handlers

        private void ShowHeaderCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            foreach (NFrameDecorator decorator in document.Descendants(new NInstanceOfTypeFilter(typeof(NFrameDecorator)), -1))
            {
                decorator.Header.Visible = ShowHeaderCheck.Checked; 
            }

            document.SmartRefreshAllViews();
        }
        private void ShowBackgroundCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            foreach (NFrameDecorator decorator in document.Descendants(new NInstanceOfTypeFilter(typeof(NFrameDecorator)), -1))
            {
                decorator.Background.Visible = ShowBackgroundCheck.Checked;
            }

            document.SmartRefreshAllViews();
        }
        private void ShapeHitTestableCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            foreach (NFrameDecorator decorator in document.Descendants(new NInstanceOfTypeFilter(typeof(NFrameDecorator)), -1))
            {
                decorator.ShapeHitTestable = ShapeHitTestableCheck.Checked; 
            }
        }
        private void HitTestHeaderCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            foreach (NFrameDecorator decorator in document.Descendants(new NInstanceOfTypeFilter(typeof(NFrameDecorator)), -1))
            {
                decorator.HitTestHeader = HitTestHeaderCheck.Checked; 
            }
        }
        private void HitTestBackgroundCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            foreach (NFrameDecorator decorator in document.Descendants(new NInstanceOfTypeFilter(typeof(NFrameDecorator)), -1))
            {
                decorator.HitTestBackground = HitTestBackgroundCheck.Checked;
            }
        }
        private void HitTestFrameCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            foreach (NFrameDecorator decorator in document.Descendants(new NInstanceOfTypeFilter(typeof(NFrameDecorator)), -1))
            {
                decorator.HitTestFrame = HitTestFrameCheck.Checked;
            }
        }
        private void HeaderSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            foreach (NFrameDecorator decorator in document.Descendants(new NInstanceOfTypeFilter(typeof(NFrameDecorator)), -1))
            {
                decorator.Header.Size = (float)HeaderSizeUpDown.Value;
            }

            document.SmartRefreshAllViews(); 
        }
        private void HeaderTextStyleButton_Click(object sender, EventArgs e)
        {
            NStyleSheet styleSheet = (NStyleSheet)document.StyleSheets.GetChildByName(NDR.NameFrameDecoratorHeadersStyleSheet);

            NTextStyle textStyle;
            if (NTextStyleTypeEditor.Edit(styleSheet.Style.TextStyle, out textStyle))
            {
                styleSheet.Style.TextStyle = textStyle;
                document.SmartRefreshAllViews();
            }
        }
        private void HeaderFillStyleButton_Click(object sender, EventArgs e)
        {
            NStyleSheet styleSheet = (NStyleSheet)document.StyleSheets.GetChildByName(NDR.NameFrameDecoratorHeadersStyleSheet);

            NFillStyle fillStyle;
            if (NFillStyleTypeEditor.Edit(styleSheet.Style.FillStyle, out fillStyle))
            {
                styleSheet.Style.FillStyle = fillStyle;
                document.SmartRefreshAllViews();
            }
        }
        private void HeaderStrokeStyleButton_Click(object sender, EventArgs e)
        {
            NStyleSheet styleSheet = (NStyleSheet)document.StyleSheets.GetChildByName(NDR.NameFrameDecoratorHeadersStyleSheet);

            NStrokeStyle strokeStyle;
            if (NStrokeStyleTypeEditor.Edit(styleSheet.Style.StrokeStyle, out strokeStyle))
            {
                styleSheet.Style.StrokeStyle = strokeStyle;
                document.SmartRefreshAllViews();
            }
        }
        private void BackgroundFillStyleButton_Click(object sender, EventArgs e)
        {
            NStyleSheet styleSheet = (NStyleSheet)document.StyleSheets.GetChildByName(NDR.NameFrameDecoratorBackgroundsStyleSheet);

            NFillStyle fillStyle;
            if (NFillStyleTypeEditor.Edit(styleSheet.Style.FillStyle, out fillStyle))
            {
                styleSheet.Style.FillStyle = fillStyle;
                document.SmartRefreshAllViews();
            }
        }
        private void BackgroundStrokeStyleButton_Click(object sender, EventArgs e)
        {
            NStyleSheet styleSheet = (NStyleSheet)document.StyleSheets.GetChildByName(NDR.NameFrameDecoratorBackgroundsStyleSheet);

            NStrokeStyle strokeStyle;
            if (NStrokeStyleTypeEditor.Edit(styleSheet.Style.StrokeStyle, out strokeStyle))
            {
                styleSheet.Style.StrokeStyle = strokeStyle;
                document.SmartRefreshAllViews();
            }
        }

        #endregion

        #region Designer Fields

        private Nevron.UI.WinForm.Controls.NButton HeaderFillStyleButton;
        private Nevron.UI.WinForm.Controls.NButton HeaderStrokeStyleButton;
        private Nevron.UI.WinForm.Controls.NButton BackgroundStrokeStyleButton;
        private Nevron.UI.WinForm.Controls.NButton BackgroundFillStyleButton;
        private Nevron.UI.WinForm.Controls.NCheckBox ShapeHitTestableCheck;
        private Nevron.UI.WinForm.Controls.NCheckBox HitTestHeaderCheck;
        private Nevron.UI.WinForm.Controls.NCheckBox HitTestBackgroundCheck;
        private Nevron.UI.WinForm.Controls.NCheckBox HitTestFrameCheck;
        private System.Windows.Forms.NumericUpDown HeaderSizeUpDown;
        private Label label1;
        private Nevron.UI.WinForm.Controls.NButton HeaderTextStyleButton;
        private Nevron.UI.WinForm.Controls.NCheckBox ShowHeaderCheck;
        private Nevron.UI.WinForm.Controls.NCheckBox ShowBackgroundCheck;
		private System.ComponentModel.Container components = null;

		#endregion
	}
}