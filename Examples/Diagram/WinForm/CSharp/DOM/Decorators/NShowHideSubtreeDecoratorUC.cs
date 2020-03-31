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
using Nevron.Diagram.Filters;
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
	/// Summary description for NShowHideSubtreeDecoratorUC.
	/// </summary>
	public class NShowHideSubtreeDecoratorUC : NDiagramExampleUC
	{
		#region Constructor

		public NShowHideSubtreeDecoratorUC(NMainForm form) : base(form)
		{
			InitializeComponent();
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(OnTimerTick);
		}        

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.SymbolCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.BackgroundCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LeftRadio = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.RightRadio = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SymbolFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.SymbolStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.BackgroundStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.BackgroundFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.ShowChildrenOnlyCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // SymbolCombo
            // 
            this.SymbolCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SymbolCombo.Location = new System.Drawing.Point(8, 31);
            this.SymbolCombo.Name = "SymbolCombo";
            this.SymbolCombo.Size = new System.Drawing.Size(232, 21);
            this.SymbolCombo.TabIndex = 1;
            this.SymbolCombo.SelectedIndexChanged += new System.EventHandler(this.SymbolCombo_SelectedIndexChanged);
            // 
            // BackgroundCombo
            // 
            this.BackgroundCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundCombo.Location = new System.Drawing.Point(8, 83);
            this.BackgroundCombo.Name = "BackgroundCombo";
            this.BackgroundCombo.Size = new System.Drawing.Size(232, 21);
            this.BackgroundCombo.TabIndex = 2;
            this.BackgroundCombo.SelectedIndexChanged += new System.EventHandler(this.BackgroundCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Symbol Shape:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Background Shape:";
            // 
            // LeftRadio
            // 
            this.LeftRadio.AutoSize = true;
            this.LeftRadio.ButtonProperties.BorderOffset = 2;
            this.LeftRadio.Checked = true;
            this.LeftRadio.Location = new System.Drawing.Point(11, 164);
            this.LeftRadio.Name = "LeftRadio";
            this.LeftRadio.Size = new System.Drawing.Size(43, 17);
            this.LeftRadio.TabIndex = 5;
            this.LeftRadio.TabStop = true;
            this.LeftRadio.Text = "Left";
            this.LeftRadio.UseVisualStyleBackColor = true;
            this.LeftRadio.CheckedChanged += new System.EventHandler(this.LeftRadio_CheckedChanged);
            // 
            // RightRadio
            // 
            this.RightRadio.AutoSize = true;
            this.RightRadio.ButtonProperties.BorderOffset = 2;
            this.RightRadio.Location = new System.Drawing.Point(11, 187);
            this.RightRadio.Name = "RightRadio";
            this.RightRadio.Size = new System.Drawing.Size(50, 17);
            this.RightRadio.TabIndex = 6;
            this.RightRadio.Text = "Right";
            this.RightRadio.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Position:";
            // 
            // SymbolFillStyleButton
            // 
            this.SymbolFillStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SymbolFillStyleButton.Location = new System.Drawing.Point(8, 211);
            this.SymbolFillStyleButton.Name = "SymbolFillStyleButton";
            this.SymbolFillStyleButton.Size = new System.Drawing.Size(232, 23);
            this.SymbolFillStyleButton.TabIndex = 8;
            this.SymbolFillStyleButton.Text = "Symbol Fill Style...";
            this.SymbolFillStyleButton.UseVisualStyleBackColor = true;
            this.SymbolFillStyleButton.Click += new System.EventHandler(this.SymbolFillStyleButton_Click);
            // 
            // SymbolStrokeStyleButton
            // 
            this.SymbolStrokeStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SymbolStrokeStyleButton.Location = new System.Drawing.Point(8, 240);
            this.SymbolStrokeStyleButton.Name = "SymbolStrokeStyleButton";
            this.SymbolStrokeStyleButton.Size = new System.Drawing.Size(232, 23);
            this.SymbolStrokeStyleButton.TabIndex = 9;
            this.SymbolStrokeStyleButton.Text = "Symbol Stroke Style...";
            this.SymbolStrokeStyleButton.UseVisualStyleBackColor = true;
            this.SymbolStrokeStyleButton.Click += new System.EventHandler(this.SymbolStrokeStyleButton_Click);
            // 
            // BackgroundStrokeStyleButton
            // 
            this.BackgroundStrokeStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundStrokeStyleButton.Location = new System.Drawing.Point(8, 305);
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
            this.BackgroundFillStyleButton.Location = new System.Drawing.Point(8, 276);
            this.BackgroundFillStyleButton.Name = "BackgroundFillStyleButton";
            this.BackgroundFillStyleButton.Size = new System.Drawing.Size(232, 23);
            this.BackgroundFillStyleButton.TabIndex = 10;
            this.BackgroundFillStyleButton.Text = "Background Fill Style...";
            this.BackgroundFillStyleButton.UseVisualStyleBackColor = true;
            this.BackgroundFillStyleButton.Click += new System.EventHandler(this.BackgroundFillStyleButton_Click);
            // 
            // ShowChildrenOnlyCheck
            // 
            this.ShowChildrenOnlyCheck.AutoSize = true;
            this.ShowChildrenOnlyCheck.Location = new System.Drawing.Point(8, 111);
            this.ShowChildrenOnlyCheck.Name = "ShowChildrenOnlyCheck";
            this.ShowChildrenOnlyCheck.Size = new System.Drawing.Size(118, 17);
            this.ShowChildrenOnlyCheck.TabIndex = 12;
            this.ShowChildrenOnlyCheck.Text = "Show Children Only";
            this.ShowChildrenOnlyCheck.UseVisualStyleBackColor = true;
            this.ShowChildrenOnlyCheck.CheckedChanged += new System.EventHandler(this.ShowChildrenOnlyCheck_CheckedChanged);
            // 
            // NShowHideSubtreeDecoratorUC
            // 
            this.Controls.Add(this.ShowChildrenOnlyCheck);
            this.Controls.Add(this.BackgroundStrokeStyleButton);
            this.Controls.Add(this.BackgroundFillStyleButton);
            this.Controls.Add(this.SymbolStrokeStyleButton);
            this.Controls.Add(this.SymbolFillStyleButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RightRadio);
            this.Controls.Add(this.LeftRadio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BackgroundCombo);
            this.Controls.Add(this.SymbolCombo);
            this.Name = "NShowHideSubtreeDecoratorUC";
            this.Size = new System.Drawing.Size(248, 456);
            this.Controls.SetChildIndex(this.SymbolCombo, 0);
            this.Controls.SetChildIndex(this.BackgroundCombo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.LeftRadio, 0);
            this.Controls.SetChildIndex(this.RightRadio, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.SymbolFillStyleButton, 0);
            this.Controls.SetChildIndex(this.SymbolStrokeStyleButton, 0);
            this.Controls.SetChildIndex(this.BackgroundFillStyleButton, 0);
            this.Controls.SetChildIndex(this.BackgroundStrokeStyleButton, 0);
            this.Controls.SetChildIndex(this.ShowChildrenOnlyCheck, 0);
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
        protected override void AttachToEvents()
        {
            base.AttachToEvents();
            document.EventSinkService.NodePropertyChanged += new NodePropertyEventHandler(EventSinkService_NodePropertyChanged);
        }
        protected override void DetachFromEvents()
        {
            base.DetachFromEvents();
            document.EventSinkService.NodePropertyChanged -= new NodePropertyEventHandler(EventSinkService_NodePropertyChanged);
        }
		
		#endregion

        #region Implementation

        private void InitDocument()
		{
            // create a random tree
            NGenericTreeTemplate treeTemplate = new NGenericTreeTemplate();
            treeTemplate.BranchNodes = 3;
            treeTemplate.VerticesSize = new NSizeF(90, 90);
            treeTemplate.Balanced = false;
            treeTemplate.Levels = 5;
            treeTemplate.Create(document);
            
            // add show-hide subtree decorator for each shape that has children
            foreach (NShape shape in document.ActiveLayer.Children(NFilters.Shape2D))
            {
                if (shape.GetOutgoingShapes().Count == 0)
                    continue;

                // create the decorators collection
                shape.CreateShapeElements(ShapeElementsMask.Decorators);

                NShowHideSubtreeDecorator decorator = new NShowHideSubtreeDecorator();
                decorator.Offset = new NSizeF(-11, 11);
                decorator.Alignment = new NContentAlignment(ContentAlignment.TopLeft);
                shape.Decorators.AddChild(decorator);
            }

            document.AutoBoundsMinSize = new NSizeF(400, 400);

            DoLayout();    
		}
        private void DoLayout()
        {
            // layout with a layered tree layout
            NLayoutContext context = new NLayoutContext();
            context.GraphAdapter = new NShapeGraphAdapter(true);
            context.BodyAdapter = new NShapeBodyAdapter(document);
            context.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);

            NLayeredTreeLayout layout = new NLayeredTreeLayout();
            layout.VertexSpacing = 50;
            layout.LayerSpacing = 50;
            layout.Layout(document.ActiveLayer.Children(null), context);

            // size to visible shapes
            document.SizeToContent(document.AutoBoundsMinSize, document.AutoBoundsPadding, NFilters.Visible);
        }
        private void InitFormControls()
        {
            // fill the expand-collapse symbol combo
            SymbolCombo.Items.Clear();
            foreach (object member in Enum.GetValues(typeof(ToggleDecoratorSymbolShape)))
            {
                SymbolCombo.Items.Add(member);
            }
            SymbolCombo.SelectedItem = ToggleDecoratorSymbolShape.PlusMinus;

            // fill the expand-collapse background combo
            BackgroundCombo.Items.Clear();
            foreach (object member in Enum.GetValues(typeof(ToggleDecoratorBackgroundShape)))
            {
                BackgroundCombo.Items.Add(member);
            }
            BackgroundCombo.SelectedItem = ToggleDecoratorBackgroundShape.Rectangle;
        }

		#endregion

        #region Event Handlers

        private void EventSinkService_NodePropertyChanged(NNodePropertyEventArgs args)
        {
            if (args.PropertyName == "Visible" && args.Node is NShape)
            {
                timer.Start();
                if (view.LockRefresh == false)
                {
                    view.LockRefresh = true;
                }
            }
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            timer.Stop();

            DoLayout();

            if (view.LockRefresh)
            {
                view.LockRefresh = false;
            }
        }
        private void SymbolCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            ToggleDecoratorSymbolShape shape = (ToggleDecoratorSymbolShape)SymbolCombo.SelectedItem;  
            foreach (NShowHideSubtreeDecorator decorator in document.Descendants(new NInstanceOfTypeFilter(typeof(NShowHideSubtreeDecorator)), -1))
            {
                decorator.Symbol.Shape = shape;
            }

            document.SmartRefreshAllViews();
        }
        private void BackgroundCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            ToggleDecoratorBackgroundShape shape = (ToggleDecoratorBackgroundShape)BackgroundCombo.SelectedItem;
            foreach (NShowHideSubtreeDecorator decorator in document.Descendants(new NInstanceOfTypeFilter(typeof(NShowHideSubtreeDecorator)), -1))
            {
                decorator.Background.Shape = shape;
            }

            document.SmartRefreshAllViews();
        }
        private void ShowChildrenOnlyCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            ToggleDecoratorSymbolShape shape = (ToggleDecoratorSymbolShape)SymbolCombo.SelectedItem;
            foreach (NShowHideSubtreeDecorator decorator in document.Descendants(new NInstanceOfTypeFilter(typeof(NShowHideSubtreeDecorator)), -1))
            {
                decorator.ShowChildrenOnly = ShowChildrenOnlyCheck.Checked;
            }

            document.SmartRefreshAllViews();
        }
        private void LeftRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            ToggleDecoratorSymbolShape shape = (ToggleDecoratorSymbolShape)SymbolCombo.SelectedItem;
            foreach (NShowHideSubtreeDecorator decorator in document.Descendants(new NInstanceOfTypeFilter(typeof(NShowHideSubtreeDecorator)), -1))
            {
                if (LeftRadio.Checked)
                {
                    decorator.Offset = new NSizeF(-11, 11);
                    decorator.Alignment = new NContentAlignment(ContentAlignment.TopLeft);
                }
                else
                {
                    decorator.Offset = new NSizeF(11, 11);
                    decorator.Alignment = new NContentAlignment(ContentAlignment.TopRight);
                }
            }

            document.SmartRefreshAllViews();
        }
        private void SymbolFillStyleButton_Click(object sender, EventArgs e)
        {
            NStyleSheet styleSheet = (NStyleSheet)document.StyleSheets.GetChildByName(NDR.NameToggleDecoratorSymbolsStyleSheet);

            NFillStyle fillStyle;
            if (NFillStyleTypeEditor.Edit(styleSheet.Style.FillStyle, out fillStyle))
            {
                styleSheet.Style.FillStyle = fillStyle;
                document.SmartRefreshAllViews();
            }
        }
        private void SymbolStrokeStyleButton_Click(object sender, EventArgs e)
        {
            NStyleSheet styleSheet = (NStyleSheet)document.StyleSheets.GetChildByName(NDR.NameToggleDecoratorSymbolsStyleSheet);

            NStrokeStyle strokeStyle;
            if (NStrokeStyleTypeEditor.Edit(styleSheet.Style.StrokeStyle, out strokeStyle))
            {
                styleSheet.Style.StrokeStyle = strokeStyle;
                document.SmartRefreshAllViews();
            }
        }
        private void BackgroundFillStyleButton_Click(object sender, EventArgs e)
        {
            NStyleSheet styleSheet = (NStyleSheet)document.StyleSheets.GetChildByName(NDR.NameToggleDecoratorBackgroundsStyleSheet);

            NFillStyle fillStyle;
            if (NFillStyleTypeEditor.Edit(styleSheet.Style.FillStyle, out fillStyle))
            {
                styleSheet.Style.FillStyle = fillStyle;
                document.SmartRefreshAllViews();
            }
        }
        private void BackgroundStrokeStyleButton_Click(object sender, EventArgs e)
        {
            NStyleSheet styleSheet = (NStyleSheet)document.StyleSheets.GetChildByName(NDR.NameToggleDecoratorBackgroundsStyleSheet);

            NStrokeStyle strokeStyle;
            if (NStrokeStyleTypeEditor.Edit(styleSheet.Style.StrokeStyle, out strokeStyle))
            {
                styleSheet.Style.StrokeStyle = strokeStyle;
                document.SmartRefreshAllViews();
            }
        }       

        #endregion

        #region Designer Fields

        private Nevron.UI.WinForm.Controls.NComboBox SymbolCombo;
        private Nevron.UI.WinForm.Controls.NComboBox BackgroundCombo;
        private Label label1;
        private Label label2;
        private Nevron.UI.WinForm.Controls.NRadioButton LeftRadio;
        private Nevron.UI.WinForm.Controls.NRadioButton RightRadio;
        private Label label3;
        private Nevron.UI.WinForm.Controls.NButton SymbolFillStyleButton;
        private Nevron.UI.WinForm.Controls.NButton SymbolStrokeStyleButton;
        private Nevron.UI.WinForm.Controls.NButton BackgroundStrokeStyleButton;
        private Nevron.UI.WinForm.Controls.NButton BackgroundFillStyleButton;
		private System.ComponentModel.Container components = null;
        private Nevron.UI.WinForm.Controls.NCheckBox ShowChildrenOnlyCheck;

		#endregion

        #region Fields

        Timer timer;

        #endregion
    }
}
