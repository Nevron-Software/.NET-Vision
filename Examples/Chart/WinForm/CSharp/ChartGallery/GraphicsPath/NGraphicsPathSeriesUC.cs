using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public partial class NGraphicsPathSeriesUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;

        public NGraphicsPathSeriesUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}

			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		private void InitializeComponent()
		{
            this.SuspendLayout();
            this.Name = "NHeatMapUC";
            this.Size = new System.Drawing.Size(186, 321);
            this.ResumeLayout(false);

		}

		#endregion
		
		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Graphics Path Series");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

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
                                    path.StartFigure(   xcenter + Math.Cos(angle) * radius,
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

            ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

            nChartControl1.Controller.Tools.Add(new NTooltipTool());

            

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}
	}
}
