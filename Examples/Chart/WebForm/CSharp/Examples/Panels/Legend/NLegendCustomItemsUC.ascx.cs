using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NLegendCustomItemsUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// confgigure chart
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = new NLabel("Legend Custom Items");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.DockMode = PanelDockMode.Top;
			title.Margins = new NMarginsL(0, 10, 0, 10);
			nChartControl1.Panels.Add(title);

			NDockPanel container = new NDockPanel();
			container.DockMode = PanelDockMode.Fill;
			container.Margins = new NMarginsL(5, 5, 5, 5);
			container.PositionChildPanelsInContentBounds = true;
			nChartControl1.Panels.Add(container);

			{
				NLegend markShapesNoStroke = CreateLegend(container, "Mark Shapes, Margins, Background");

				Array markShapes = Enum.GetValues(typeof(LegendMarkShape));
				NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);

				for (int i = 0; i < markShapes.Length; i++)
				{
					NLegendItemCellData licd = new NLegendItemCellData();
					LegendMarkShape markShape = (LegendMarkShape)markShapes.GetValue(i);

					licd.Text = markShape.ToString();
					licd.TextStyle.FillStyle = new NColorFillStyle(Color.White);
					licd.TextStyle.FontStyle.EmSize = new NLength(8);
					licd.MarkShape = markShape;
					licd.MarkFillStyle = new NColorFillStyle(Color.White);
					licd.MarkBorderStyle.Width = new NLength(0);
					licd.MarkLineStyle.Width = new NLength(0);
					licd.BackgroundFillStyle = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);

					markShapesNoStroke.Data.Items.Add(licd);
				}

				// increase teh margins around each cell
				markShapesNoStroke.Data.CellMargins = new NMarginsL(5, 5, 5, 5);
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);
		}

		private NLegend CreateLegend(NDockPanel container, string title)
		{
			// configure the legend
			NLegend legend = new NLegend();
			legend.Header.Text = title;
			legend.Mode = LegendMode.Manual;
			legend.Data.ExpandMode = LegendExpandMode.HorzWrap;
			legend.DockMode = PanelDockMode.Top;
			legend.Margins = new NMarginsL(20, 20, 20, 20);
			container.ChildPanels.Add(legend);

			return legend;
		}
	}
}
