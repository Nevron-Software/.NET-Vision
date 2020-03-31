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
    public class NTreeListCustomHeaderRenderer : NTreeListHeaderRenderer
    {
        #region Constructor

        public NTreeListCustomHeaderRenderer()
        {
        }

        #endregion

        #region Overrides

        public override void PaintColumnHeaderItem(NTreeListPaintContext context, NTreeListColumnHeader item)
        {
            PaintCustomBackground(context, item);

            item.PaintContent(context);
            PaintSortGlyph(context, item);
        }

        #endregion

        #region Implementation

        void PaintCustomBackground(NTreeListPaintContext context, NTreeListColumnHeader item)
        {
            NRectangle bounds = context.PaintBounds;
            bounds.Inflate(0, -1);

            Rectangle gdiRect = bounds.ToRectangle();

            Color c1 = Color.Empty;
            Color c2 = Color.Empty;

            switch(item.VisualState)
            {
                case ItemVisualState.Normal:
                    c1 = Color.FloralWhite;
                    c2 = Color.Chocolate;
                    break;
                case ItemVisualState.Hot:
                    c1 = Color.Orange;
                    c2 = Color.Red;
                    break;
                case ItemVisualState.Pressed:
                    c1 = Color.Red;
                    c2 = Color.Orange;
                    break;
            }

            LinearGradientBrush br = new LinearGradientBrush(gdiRect, c1, c2, 90F);

            context.Graphics.FillRectangle(br, gdiRect);

            br.Dispose();

            if (item.Owner.VisibleIndex == 0)
            {
                return;
            }

            Pen p = new Pen(Color.Black);

            context.Graphics.DrawLine(p, bounds.X - 1, bounds.Y + 3, bounds.X - 1, bounds.Bottom - 4);
            p.Color = Color.Wheat;
            context.Graphics.DrawLine(p, bounds.X, bounds.Y + 4, bounds.X, bounds.Bottom - 3);

            p.Dispose();
        }

        #endregion
    }
}
