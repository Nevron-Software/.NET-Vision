using System;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Templates;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.Filters;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
    /// <summary>
	///	Summary description for NShowHideSubtreeDecoratorUC.
    /// </summary>
	public partial class NShowHideSubtreeDecoratorUC : NDiagramExampleUC
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
			if (NThinDiagramControl1.Initialized == false)
			{
				// Init the thin diagram control
				NThinDiagramControl1.CustomRequestCallback = new CustomRequestCallback();

				// Set manual ID so that it can be referenced in JavaScript
				NThinDiagramControl1.StateId = "Diagram1";

				// Configure the controller
				NServerMouseEventTool serverMouseEventTool = new NServerMouseEventTool();
				NThinDiagramControl1.Controller.Tools.Add(serverMouseEventTool);
				serverMouseEventTool.MouseDown = new NMouseDownEventCallback();

				// Init the document
				NDrawingDocument document = NThinDiagramControl1.Document;
				document.BeginInit();
				InitDocument(document);
				document.EndInit();
			}
        }

        #region Implementation

        private void InitDocument(NDrawingDocument document)
        {
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

        #region Fields

        private bool m_bClientSideRedrawRequired = false;

        #endregion

        #region Constants

        private static readonly NFilter ShowHideSubtreeDecoratorFilter = new NInstanceOfTypeFilter(typeof(NShowHideSubtreeDecorator));

        #endregion

		#region Nested Types

		[Serializable]
		class NMouseDownEventCallback : INMouseEventCallback
		{
			#region INMouseEventCallback Members

			void INMouseEventCallback.OnMouseEvent(NAspNetThinWebControl control, NBrowserMouseEventArgs e)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NNodeList nodes = diagramControl.HitTest(new NPointF(e.X, e.Y));
				NNodeList decorators = nodes.Filter(ShowHideSubtreeDecoratorFilter);

				if (decorators.Count > 0)
				{
					((NShowHideSubtreeDecorator)decorators[0]).ToggleState();
					diagramControl.UpdateView();
				}
			}

			#endregion
		}

		[Serializable]
		class CustomRequestCallback : INCustomRequestCallback
		{
			#region INCustomRequestCallback Members

			void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NNodeList decorators = diagramControl.Document.ActiveLayer.Descendants(ShowHideSubtreeDecoratorFilter, -1);

				int i, count = decorators.Count;
				string[] data = argument.Split('=');
				string name = data[0];
				string value = data[1];

				switch (name)
				{
					case "background":
						ToggleDecoratorBackgroundShape background = (ToggleDecoratorBackgroundShape)Enum.Parse(typeof(ToggleDecoratorBackgroundShape), value);
						for (i = 0; i < count; i++)
						{
							((NToggleDecorator)decorators[i]).Background.Shape = background;
						}
						break;

					case "symbol":
						ToggleDecoratorSymbolShape symbol = (ToggleDecoratorSymbolShape)Enum.Parse(typeof(ToggleDecoratorSymbolShape), value);
						for (i = 0; i < count; i++)
						{
							((NToggleDecorator)decorators[i]).Symbol.Shape = symbol;
						}
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
						break;
				}

				control.UpdateView();
			}

			#endregion
		}

		#endregion
	}
}