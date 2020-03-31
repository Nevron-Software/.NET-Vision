using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NGraphicsPathUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Graphics Path Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup legend
			NLegend legend = nChartControl1.Legends[0];
            legend.Visible = false;

            NChart chart = nChartControl1.Charts[0];

            chart.BoundsMode = BoundsMode.Stretch;

            int shapeIndex = 0;
            double cellSize = 100;
            double shapePadding = 10;
            NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);

            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    NGraphicsPathSeries graphicsPathSeries = new NGraphicsPathSeries();

                    double xmin = x * cellSize + shapePadding;
                    double ymin = y * cellSize + shapePadding;

                    double xmax = xmin + cellSize - shapePadding;
                    double ymax = ymin + cellSize - shapePadding;
                    double shapeSize = cellSize - 2 * shapePadding;

                    NGraphicsPath path = new NGraphicsPath();

                    switch (shapeIndex)
                    {
                        case 0:
                            // rectangle
                            graphicsPathSeries.Name = "Rectangle";
                            path.AddRectangle(xmin, ymin, xmax - xmin, ymax - ymin);
                            graphicsPathSeries.InteractivityStyle = new NInteractivityStyle("Rectangle");
                            break;

                        case 1:
                            // ellipse
                            graphicsPathSeries.Name = "Ellipse";
                            path.AddEllipse(xmin, ymin, xmax - xmin, ymax - ymin);
                            graphicsPathSeries.InteractivityStyle = new NInteractivityStyle("Ellipse");
                            break;

                        case 2:
                            // triangle
                            graphicsPathSeries.Name = "Triangle";
                            graphicsPathSeries.InteractivityStyle = new NInteractivityStyle("Triangle");
                            path.StartFigure((xmin + xmax) / 2.0, ymin);
                            path.LineTo(xmin, ymax);
                            path.LineTo(xmax, ymax);
                            path.CloseFigure();

                            break;

                        case 3:
                            // polygon
                            graphicsPathSeries.Name = "Polygon";
                            graphicsPathSeries.InteractivityStyle = new NInteractivityStyle("Polygon");
                            double xcenter = (xmin + xmax) / 2.0;
                            double ycenter = (ymin + ymax) / 2.0;

                            int count = 8;
                            double radius = shapeSize / 2;

                            for (int i = 0; i < count; i++)
                            {
                                double angle = Math.PI * 2 * (double)i / (double)count;


                                if (i == 0)
                                {
                                    path.StartFigure(xcenter + Math.Cos(angle) * radius,
                                                        ycenter + Math.Sin(angle) * radius);
                                }
                                else
                                {
                                    path.LineTo(xcenter + Math.Cos(angle) * radius,
                                                ycenter + Math.Sin(angle) * radius);
                                }
                            }

                            path.CloseFigure();
                            break;
                    }

                    graphicsPathSeries.FillStyle = new NColorFillStyle(palette.SeriesColors[shapeIndex]);
                    graphicsPathSeries.GraphicsPath = path;

                    chart.Series.Add(graphicsPathSeries);

                    shapeIndex++;
                }
            }

            // apply layout
            ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Nevron);
            styleSheet.Apply(nChartControl1.Document);
		}
	}
}
