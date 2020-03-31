using System;
using System.Collections.Generic;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;
using Nevron.Diagram.Extensions;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
    /// Summary description for NWorldCup2006RenderPage.
	/// </summary>
	public partial class NPuzzleAnimationRenderPage : NDrawingViewHostPage
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NPuzzleAnimationRenderPage()
		{
			DrawingView = new NDrawingView();
			DrawingView.ViewLayout = CanvasLayout.Stretch;

            NImageResponse swfResponse = new NImageResponse();
            swfResponse.ImageFormat = new NSwfImageFormat();
            swfResponse.StreamImageToBrowser = true;
            DrawingView.ServerSettings.BrowserResponseSettings.DefaultResponse = swfResponse;

			// init document
			CreateScene();

			this.DrawingView.SizeToContent();
        }

        #endregion

        #region Private Methods

        private void CreateScene()
		{
            NPersistencyManager manager = new NPersistencyManager();
            NDrawingDocument document = manager.LoadDrawingFromFile(Server.MapPath("~\\App_Data\\FlowDiagram.ndx"));

            DrawingView.Document = document;
            document.BeginInit();
            CreateAnimatedGrid(5, 5, 1);
            document.EndInit();
        }
        private void CreateAnimatedGrid(int rows, int columns, float cellFadeDuration)
        {
            NDrawingDocument document = DrawingView.Document;

            // Create the grid layer
            NLayer grid = new NLayer();
            grid.Name = "grid";
            document.Layers.AddChild(grid);

            // Create the cells style sheet
            NStyleSheet style = new NStyleSheet("gridCell");
            NStyle.SetFillStyle(style, new NColorFillStyle(KnownArgbColorValue.White));
            NStyle.SetStrokeStyle(style, new NStrokeStyle(1, KnownArgbColorValue.Black));
            document.StyleSheets.AddChild(style);

            int i, j, count;
            float x, y, time = 0;
            float cellWidth = document.Width / rows;
            float cellHeight = document.Height / columns;

            NFadeAnimation fade;
            NRectangleShape rect;
            List<NRectangleShape> cells = new List<NRectangleShape>();

            // Create the shapes
            for (i = 0, y = 0; i < rows; i++, y += cellHeight)
            {
                for (j = 0, x = 0; j < columns; j++, x += cellWidth)
                {
                    rect = new NRectangleShape(x, y, cellWidth, cellHeight);
                    cells.Add(rect);
                    grid.AddChild(rect);
                    rect.StyleSheetName = style.Name;
                }
            }

            // Create the fade animations
            count = cells.Count;
            Random random = new Random();

            int counter = 1;
            while (count > 0)
            {
                i = random.Next(count);
                rect = cells[i];
                rect.Style.AnimationsStyle = new NAnimationsStyle();

                if (time > 0)
                {
                    fade = new NFadeAnimation(0, time);
                    fade.StartAlpha = 1;
                    fade.EndAlpha = 1;
                    rect.Style.AnimationsStyle.AddAnimation(fade);
                }

                fade = new NFadeAnimation(time, cellFadeDuration);
                fade.StartAlpha = 1;
                fade.EndAlpha = 0;
                rect.Style.AnimationsStyle.AddAnimation(fade);

                if (counter == 3)
                {
                    // Show 3 cells at a time
                    time += cellFadeDuration;
                    counter = 1;
                }
                else
                {
                    counter++;
                }

                cells.RemoveAt(i);
                count--;
            }
        }

        #endregion
	}
}