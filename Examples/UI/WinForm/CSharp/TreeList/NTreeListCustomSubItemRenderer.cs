using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
    public class NTreeListCustomSubItemRenderer : NTreeListSubItemRenderer
    {
        #region Constructor

        public NTreeListCustomSubItemRenderer()
        {
        }

        #endregion

        #region Overrides

        public override void PrePaintItem(NTreeListNodeSubItem item, NTreeListPaintContext context)
        {
            Rectangle bounds = context.TreeList.GetSubItemRect(item).ToRectangle();
            Rectangle brushRect = bounds;
            brushRect.Inflate(1, 1);

            switch (item.ItemType)
            {
                case TreeListNodeSubItemType.String:
                    if (item.Owner.IsEven)
                    {
                        context.Graphics.FillEllipse(Brushes.Cyan, bounds);
                    }
                    else
                    {
                        context.Graphics.FillEllipse(Brushes.Coral, bounds);
                    }
                    return;
                case TreeListNodeSubItemType.DateTime:
                    Color c1;
                    Color c2;

                    if (item.Owner.IsEven)
                    {
                        c1 = Color.White;
                        c2 = Color.YellowGreen;
                    }
                    else
                    {
                        c1 = Color.Wheat;
                        c2 = Color.Silver;
                    }

                    LinearGradientBrush br = new LinearGradientBrush(brushRect, c1, c2, 0F);
                    context.Graphics.FillRectangle(br, bounds);
                    br.Dispose();
                    return;
            }

            base.PrePaintItem(item, context);
        }
        public override void PostPaintItem(NTreeListNodeSubItem item, NTreeListPaintContext context)
        {
            Font orig = context.Font;
            Font newFont = null;

            NRectangle bounds = context.TreeList.GetSubItemRect(item);

            switch (item.ItemType)
            {
                case TreeListNodeSubItemType.String:
                    if (item.Owner.IsEven)
                    {
                        newFont = new Font(orig, FontStyle.Strikeout);
                    }
                    else
                    {
                        newFont = new Font(orig, FontStyle.Italic);
                    }
                    break;
                case TreeListNodeSubItemType.Numeric:
                case TreeListNodeSubItemType.DateTime:
                    if (item.Owner.IsEven == false)
                    {
                        newFont = new Font(orig, FontStyle.Strikeout);
                    }
                    else
                    {
                        newFont = new Font(orig, FontStyle.Italic);
                    }
                    break;
            }

            if (newFont != null)
            {
                context.Font = newFont;
            }

            base.PostPaintItem(item, context);

            if (newFont != null)
            {
                newFont.Dispose();
            }

            context.Font = orig;
        }

        #endregion
    }
}
