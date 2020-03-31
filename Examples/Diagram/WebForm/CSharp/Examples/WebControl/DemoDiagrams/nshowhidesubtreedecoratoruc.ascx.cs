using System;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Templates;
using Nevron.Dom;
using Nevron.Filters;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
    /// <summary>
	///	Summary description for NShowHideSubtreeDecoratorUC.
    /// </summary>
    public partial class NShowHideSubtreeDecoratorUC : NDiagramExampleUC
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (NDrawingView1.RequiresInitialization)
            {
                // begin view init
                NDrawingView1.ViewLayout = CanvasLayout.Normal;

                // init document
                NDrawingView1.Document.BeginInit();
                InitDocument();
                NDrawingView1.Document.EndInit();
            }
        }

        #region Implementation

        private void InitDocument()
        {
            NDrawingDocument document = NDrawingView1.Document;

            // remove the standard frame
            document.BackgroundStyle.FrameStyle.Visible = false;

            // set up visual formatting
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            // create a stylesheet for the edges
            NStyleSheet sheet = new NStyleSheet("edges");
            sheet.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle);
            sheet.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle);
            document.StyleSheets.AddChild(sheet);

            // generate a simple tree
            NGenericTreeTemplate tree = new NGenericTreeTemplate();
            tree.VerticesSize = new NSizeF(80, 80);
            tree.EdgesStyleSheetName = "edges";
            tree.Create(document);

            // create a show/hide decorator for all shapes that have children
            NNodeList shapes = document.ActiveLayer.Descendants(NFilters.Shape2D, -1);
            int i, count = shapes.Count;
            for (i = 0; i < count; i++)
            {
                NShape shape = (NShape)shapes[i];
                if (shape.GetOutgoingShapes().Count == 0)
                    continue;

                shape.CreateShapeElements(ShapeElementsMask.Decorators);
                NShowHideSubtreeDecorator decorator = new NShowHideSubtreeDecorator();
                decorator.Name = "ShowHideSubtree";
                shape.Decorators.AddChild(new NShowHideSubtreeDecorator());
            }

            // size the document to the content
            document.SizeToContent();
        }

        #endregion

        #region Event Handlers

        protected void NDrawingView1_QueryAjaxTools(object sender, EventArgs e)
        {
            // configure the client side tools
            NDrawingView1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true));
        }
        protected void NDrawingView1_AsyncClick(object sender, EventArgs e)
        {
            NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;
            NNodeList nodes = NDrawingView1.HitTest(args);
            NNodeList decorators = nodes.Filter(DecoratorFilter);
            if (decorators.Count > 0)
            {
                ((NShowHideSubtreeDecorator)decorators[0]).ToggleState();
            }

            NDrawingView1.Document.SmartRefreshAllViews();
        }
        protected void NDrawingView1_AsyncCustomCommand(object sender, EventArgs e)
        {
            NCallbackCustomCommandArgs args = e as NCallbackCustomCommandArgs;
            NCallbackCommand command = args.Command;
            string value = command.Arguments["value"].ToString();

            NNodeList decorators = NDrawingView1.Document.ActiveLayer.Descendants(DecoratorFilter, -1);
            int i, count = decorators.Count;

            switch (command.Name)
            {
                case "background":
                    ToggleDecoratorBackgroundShape background = (ToggleDecoratorBackgroundShape)Enum.Parse(typeof(ToggleDecoratorBackgroundShape), value);
                    for (i = 0; i < count; i++)
                    {
						((NToggleDecorator)decorators[i]).Background.Shape = background;
                    }

                    m_bClientSideRedrawRequired = true;
                    break;

                case "symbol":
                    ToggleDecoratorSymbolShape symbol = (ToggleDecoratorSymbolShape)Enum.Parse(typeof(ToggleDecoratorSymbolShape), value);
                    for (i = 0; i < count; i++)
                    {
						((NToggleDecorator)decorators[i]).Symbol.Shape = symbol;
                    }

                    m_bClientSideRedrawRequired = true;
                    break;

				case "position":
					NContentAlignment alignment;
					NSizeF offset;

					if (value == "Left")
					{
						alignment = new NContentAlignment(ContentAlignment.TopLeft);
						offset = new NSizeF(11, 11);
					}
					else
					{
						alignment = new NContentAlignment(ContentAlignment.TopRight);
						offset = new NSizeF(-11, 11);
					}

					for (i = 0; i < count; i++)
					{
						NToggleDecorator decorator = (NToggleDecorator)decorators[i];
						decorator.Alignment = alignment;
						decorator.Offset = offset;
					}

					m_bClientSideRedrawRequired = true;
					break;
            }
        }
        protected void NDrawingView1_AsyncQueryCommandResult(object sender, EventArgs e)
        {
            NCallbackQueryCommandResultArgs args = e as NCallbackQueryCommandResultArgs;
            NAjaxXmlTransportBuilder resultBuilder = args.ResultBuilder;
            if (m_bClientSideRedrawRequired && !resultBuilder.ContainsRedrawDataSection())
            {
                resultBuilder.AddRedrawDataSection(NDrawingView1);
            }
        }

        #endregion

        #region Fields

        private bool m_bClientSideRedrawRequired = false;

        #endregion

        #region Constants

        private static readonly NFilter DecoratorFilter = new NInstanceOfTypeFilter(typeof(NShowHideSubtreeDecorator));

        #endregion
    }
}