using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLegendCustomItemsUC : NExampleBaseUC
    {
		private System.ComponentModel.Container components = null;

		public NLegendCustomItemsUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// NLegendCustomItemsUC
			// 
			this.Name = "NLegendCustomItemsUC";
			this.Size = new System.Drawing.Size(180, 680);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
        {
            base.Initialize();

            // confgigure chart
            nChartControl1.Panels.Clear();

            // set a chart title
            NLabel header = new NLabel("Legend Custom Items");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            header.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
            header.DockMode = PanelDockMode.Top;
            header.Margins = new NMarginsL(0, 10, 0, 10);
            nChartControl1.Panels.Add(header);

            NDockPanel container = new NDockPanel();
            container.DockMode = PanelDockMode.Fill;
            container.Margins = new NMarginsL(10, 10, 10, 10);
            container.PositionChildPanelsInContentBounds = true;
            nChartControl1.Panels.Add(container);

            // configure the legend
			CreateCustomLegend1(container);
			CreateCustomLegend2(container);
			CreateCustomLegend3(container);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
        }

		private void CreateCustomLegend1(NDockPanel container)
		{
			NLegend markShapesLegend = CreateLegend(container, "Mark Shapes");

			Array markShapes = Enum.GetValues(typeof(LegendMarkShape));
			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);

			for (int i = 0; i < markShapes.Length; i++)
			{
				NLegendItemCellData licd = new NLegendItemCellData();
				LegendMarkShape markShape = (LegendMarkShape)markShapes.GetValue(i);

				licd.Text = markShape.ToString();
				licd.MarkShape = markShape;
				licd.MarkFillStyle = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);

				markShapesLegend.Data.Items.Add(licd);
			}

		}

		private void CreateCustomLegend2(NDockPanel container)
		{
			NLegend markShapesNoStroke = CreateLegend(container, "Mark Shapes (No stroke)");

			Array markShapes = Enum.GetValues(typeof(LegendMarkShape));
			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);

			for (int i = 0; i < markShapes.Length; i++)
			{
				NLegendItemCellData licd = new NLegendItemCellData();
				LegendMarkShape markShape = (LegendMarkShape)markShapes.GetValue(i);

				licd.Text = markShape.ToString();
				licd.MarkShape = markShape;
				licd.MarkFillStyle = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);
				licd.MarkBorderStyle.Width = new NLength(0);
				licd.MarkLineStyle.Width = new NLength(0);

				markShapesNoStroke.Data.Items.Add(licd);
			}

		}

		private void CreateCustomLegend3(NDockPanel container)
		{
			NLegend markShapesBackground = CreateLegend(container, "Mark Shapes (Margins, Background)");

			Array markShapes = Enum.GetValues(typeof(LegendMarkShape));
			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Fresh);

			for (int i = 0; i < markShapes.Length; i++)
			{
				NLegendItemCellData licd = new NLegendItemCellData();
				LegendMarkShape markShape = (LegendMarkShape)markShapes.GetValue(i);

				licd.Text = markShape.ToString();
				licd.TextStyle.FillStyle = new NColorFillStyle(Color.White);
				licd.TextStyle.FontStyle.EmSize = new NLength(10 + i);
				licd.MarkShape = markShape;
				licd.MarkFillStyle = new NColorFillStyle(Color.White);
				licd.MarkBorderStyle.Width = new NLength(0);
				licd.MarkLineStyle.Width = new NLength(0);
				licd.BackgroundFillStyle = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);

				markShapesBackground.Data.Items.Add(licd);
			}

			// increase teh margins around each cell
			markShapesBackground.Data.CellMargins = new NMarginsL(10, 10, 10, 10);
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
