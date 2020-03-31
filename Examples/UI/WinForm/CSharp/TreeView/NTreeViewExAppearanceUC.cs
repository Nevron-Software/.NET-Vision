using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Data;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
    public partial class NTreeViewExAppearanceUC : NExampleUserControl
    {
        #region Constructor

        public NTreeViewExAppearanceUC()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;

            m_Images = new Image[6];
            string path = "Nevron.Examples.UI.WinForm.TreeView.Resources";
            Type t = typeof(NTreeViewExAppearanceUC);

            m_Images[0] = NResourceHelper.BitmapFromResource(t, "TreeView1.png", path);
            m_Images[1] = NResourceHelper.BitmapFromResource(t, "TreeView2.png", path);
            m_Images[2] = NResourceHelper.BitmapFromResource(t, "TreeView3.png", path);
            m_Images[3] = NResourceHelper.BitmapFromResource(t, "TreeView4.png", path);
            m_Images[4] = NResourceHelper.BitmapFromResource(t, "TreeView5.png", path);
            m_Images[5] = NResourceHelper.BitmapFromResource(t, "TreeView6.png", path);
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            expandToRightCheck.Checked = true;
            multiSelectCheck.Checked = true;
            imageHighlightCheck.Checked = true;

            settings1Btn_Click(null, null);
        }

        #endregion

        #region Event Handlers

        private void settings1Btn_Click(object sender, EventArgs e)
        {
            nTreeViewEx1.Suspend();
            nTreeViewEx1.IndicatorStyle = TreeViewIndicatorStyle.OnLeft;

            nTreeViewEx1.NormalState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            nTreeViewEx1.HotState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            nTreeViewEx1.SelectedState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            nTreeViewEx1.HotSelectedState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            nTreeViewEx1.PressedState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            nTreeViewEx1.InactiveSelectedState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            nTreeViewEx1.Nodes.Clear();
            nTreeViewEx1.ItemImageSize = new NSize(32, 32);
            nTreeViewEx1.HotState.Image = m_Images[3];
            nTreeViewEx1.SelectedState.Image = m_Images[4];
            nTreeViewEx1.HotSelectedState.Image = m_Images[5];

            NTreeNode child1, child2, child3;
            string richText = "<font size='10' face='Trebuchet MS' color='Navy'><b>Sample tree-node with rich text formatting</b></font><br/>The rich text however results in slower speed of the tree-view.<br/>You may specify rich text per desired node only to optimize performance.";

            NTooltipInfo info = new NTooltipInfo();
            info.CaptionText = "<font face='Trebuchet MS' size='10'><b>Sample tooltip header.</b></font>";
            info.ContentImage = m_Images[1];
            info.ContentImageSize = new NSize(32, 32);
            info.ContentText = "This is sample tooltip content. It supports rich text and appearance settings per node.<br/>The individual tooltip is with higher priority than the internal one displayed for hidden items.";

            for (int i = 1; i < 21; i++)
            {
                child1 = new NTreeNode();
                child1.TextAlign = ContentAlignment.TopLeft;
                child1.Text = richText;
                child1.Image = m_Images[1];
                child1.TextProcessMode = ItemTextProcessMode.RichText;
                child1.CommonIndicator = (CommonIndicator)i;
                child1.TooltipInfo = info;

                for (int j = 1; j < 21; j++)
                {
                    child2 = new NTreeNode();
                    child2.Text = "Simple Text Node";
                    child2.Image = m_Images[1];
                    child2.CommonIndicator = (CommonIndicator)j;
                    child2.TooltipInfo = info;

                    for (int k = 1; k < 21; k++)
                    {
                        child3 = new NTreeNode();
                        child3.Text = "Simple Text Node";
                        child3.Image = m_Images[1];
                        child3.CommonIndicator = (CommonIndicator)k;
                        child3.TooltipInfo = info;

                        child2.Nodes.Add(child3);
                    }

                    child1.Nodes.Add(child2);
                }

                nTreeViewEx1.Nodes.Add(child1);
            }

            nTreeViewEx1.Resume(true);
            this.nTreeViewEx1.Nodes[0].Expand();
        }
        private void settings2Btn_Click(object sender, EventArgs e)
        {
            nTreeViewEx1.Suspend();
            nTreeViewEx1.Nodes.Clear();

            nTreeViewEx1.NormalState.TextRenderingHint = TextRenderingHint.SystemDefault;
            nTreeViewEx1.HotState.TextRenderingHint = TextRenderingHint.SystemDefault;
            nTreeViewEx1.SelectedState.TextRenderingHint = TextRenderingHint.SystemDefault;
            nTreeViewEx1.HotSelectedState.TextRenderingHint = TextRenderingHint.SystemDefault;
            nTreeViewEx1.PressedState.TextRenderingHint = TextRenderingHint.SystemDefault;
            nTreeViewEx1.InactiveSelectedState.TextRenderingHint = TextRenderingHint.SystemDefault;

            NLightUIItemVisualState normalState = new NLightUIItemVisualState();
            normalState.FillInfo.Gradient1 = Color.Orange;
            normalState.FillInfo.Gradient2 = Color.Yellow;
            normalState.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell;
            normalState.StrokeInfo.SmoothingMode = SmoothingMode.AntiAlias;
            normalState.StrokeInfo.Rounding = 3;
            normalState.StrokeInfo.Color = Color.Black;
            normalState.TextFillInfo.FillStyle = FillStyle.Solid;
            normalState.TextFillInfo.Color = Color.Black;

            NLightUIItemVisualState hotState = new NLightUIItemVisualState();
            hotState.FillInfo.Gradient1 = Color.Yellow;
            hotState.FillInfo.Gradient2 = Color.Orange;
            hotState.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista;
            hotState.StrokeInfo.SmoothingMode = SmoothingMode.AntiAlias;
            hotState.StrokeInfo.PenWidth = 2;
            hotState.StrokeInfo.DashStyle = DashStyle.Dash;
            hotState.StrokeInfo.Color = Color.Black;
            hotState.TextFillInfo.Color = Color.Black;

            NLightUIItemVisualState selectedState = new NLightUIItemVisualState();
            selectedState.FillInfo.Gradient1 = Color.Orange;
            selectedState.FillInfo.Gradient2 = Color.Black;
            selectedState.StrokeInfo.SmoothingMode = SmoothingMode.AntiAlias;
            selectedState.StrokeInfo.Rounding = 3;
            selectedState.StrokeInfo.Color = Color.Black;
            selectedState.TextFillInfo.Color = Color.White;

            nTreeViewEx1.IndicatorStyle = TreeViewIndicatorStyle.OnLeft;
            nTreeViewEx1.ItemImageSize = new NSize(32, 32);
            nTreeViewEx1.HotState.Image = m_Images[3];
            nTreeViewEx1.SelectedState.Image = m_Images[4];
            nTreeViewEx1.HotSelectedState.Image = m_Images[5];
            nTreeViewEx1.TrackHotSelectedState = false;

            NTreeNode child1, child2, child3;

            for (int i = 1; i < 21; i++)
            {
                child1 = new NTreeNode();
                child1.Text = "Tree node with local Hot visual state";
                child1.Image = m_Images[1];
                child1.CommonIndicator = (CommonIndicator)i;
                child1.SetVisualState(hotState, ItemVisualState.Hot);

                for (int j = 1; j < 21; j++)
                {
                    child2 = new NTreeNode();
                    child2.Text = "Tree node with local Normal visual state";
                    child2.Image = m_Images[1];
                    child2.CommonIndicator = (CommonIndicator)j;
                    child2.SetVisualState(normalState, ItemVisualState.Normal);

                    for (int k = 1; k < 21; k++)
                    {
                        child3 = new NTreeNode();
                        child3.Text = "Tree node with local Selected visual state";
                        child3.Image = m_Images[1];
                        child3.CommonIndicator = (CommonIndicator)k;
                        child3.SetVisualState(selectedState, ItemVisualState.Selected);

                        child2.Nodes.Add(child3);
                    }

                    child1.Nodes.Add(child2);
                }

                nTreeViewEx1.Nodes.Add(child1);
            }

            this.nTreeViewEx1.Nodes[0].Expand();
            nTreeViewEx1.Resume(true);
        }
        private void expandAllBtn_Click(object sender, EventArgs e)
        {
            nTreeViewEx1.ExpandAll();
        }
        private void collapseAllBtn_Click(object sender, EventArgs e)
        {
            nTreeViewEx1.CollapseAll();
        }
        private void expandToRightCheck_CheckedChanged(object sender, EventArgs e)
        {
            nTreeViewEx1.ExpandToRight = expandToRightCheck.Checked;
        }
        private void multiSelectCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (multiSelectCheck.Checked)
            {
                nTreeViewEx1.SelectionMode = ItemSelectionMode.MultiExtended;
            }
            else
            {
                nTreeViewEx1.SelectionMode = ItemSelectionMode.Single;
            }
        }
        private void imageHighlightCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (imageHighlightCheck.Checked)
            {
                nTreeViewEx1.ItemBackgroundMode = ItemBackgroundMode.ImageAndText;
            }
            else
            {
                nTreeViewEx1.ItemBackgroundMode = ItemBackgroundMode.Inherit;
            }
        }

        #endregion

        #region Fields

        internal Image[] m_Images;

        #endregion
    }
}
