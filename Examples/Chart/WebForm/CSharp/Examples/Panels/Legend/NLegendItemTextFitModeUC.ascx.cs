using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NLegendItemTextFitModeUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// confgigure chart
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = new NLabel("Legend Item Text Fit Mode");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.DockMode = PanelDockMode.Top;
			title.Margins = new NMarginsL(0, 10, 0, 10);
			nChartControl1.Panels.Add(title);

			// configure the legend
			NLegend legend = new NLegend();
			legend.Header.Text = "Maximum Legend Item Text Size";
			legend.Mode = LegendMode.Manual;
			legend.Data.ExpandMode = LegendExpandMode.HorzWrap;
			legend.DockMode = PanelDockMode.Top;
			legend.Margins = new NMarginsL(20, 20, 20, 20);
			nChartControl1.Panels.Add(legend);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init controls

			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumNames(LegendItemTextFitModeDropDownList, typeof(LegendTextFitMode));
				WebExamplesUtilities.FillComboWithValues(LegendItemMaximumWidthDropDownList, 50, 150, 50);
			}

		// Update legend items
			Array markShapes = Enum.GetValues(typeof(LegendMarkShape));
			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);

			for (int i = 0; i < markShapes.Length; i++)
			{
				NLegendItemCellData licd = new NLegendItemCellData();
				LegendMarkShape markShape = (LegendMarkShape)markShapes.GetValue(i);

				licd.Text = "Some very long text about mark shape [" + markShape.ToString() + "]";
				licd.MarkShape = markShape;
				licd.MarkFillStyle = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);

				licd.TextFitMode = (LegendTextFitMode)LegendItemTextFitModeDropDownList.SelectedIndex;
				licd.MaxTextWidth = new NLength((float)(LegendItemMaximumWidthDropDownList.SelectedIndex + 1) * 50);

				legend.Data.Items.Add(licd);
			}
		}
	}
}
