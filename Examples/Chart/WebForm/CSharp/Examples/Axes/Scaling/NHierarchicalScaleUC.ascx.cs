using System;

using System.Drawing;

using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NHierarchicalScaleUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			if (!IsPostBack)
			{
				// init form controls
				ShowLevelSeparatorsCheckBox.Checked = true;
				Show2007DataCheckBox.Checked = true;
			}

			// set a chart title
			NLabel header = new NLabel("Quarterly Company Sales<br/><font size = '9pt'>Demonstrates how to use hierarchical scale configurators</font>");
			header.DockMode = PanelDockMode.Top;
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			header.TextStyle.TextFormat = TextFormat.XML;
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
			header.FitAlignment = ContentAlignment.MiddleLeft;
			header.Margins = new NMarginsL(5, 0, 10, 10);
			nChartControl1.Panels.Add(header);

			NCartesianChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);

			NLegend legend = new NLegend();
			legend.Margins = new NMarginsL(10, 0, 10, 0);
			legend.DockMode = PanelDockMode.Right;
			legend.FitAlignment = ContentAlignment.TopCenter;
			legend.Data.ExpandMode = LegendExpandMode.ColsOnly;
			legend.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.White));
			legend.HorizontalBorderStyle.Width = new NLength(0);
			legend.VerticalBorderStyle.Width = new NLength(0);
			legend.OuterTopBorderStyle.Width = new NLength(0);
			legend.OuterLeftBorderStyle.Width = new NLength(0);
			legend.OuterBottomBorderStyle.Width = new NLength(0);
			legend.OuterRightBorderStyle.Width = new NLength(0);
			chart.ChildPanels.Add(legend);

			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			chart.RangeSelections.Add(rangeSelection);

			chart.DisplayOnLegend = legend;
			chart.DockMode = PanelDockMode.Fill;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Margins = new NMarginsL(5, 0, 5, 10);
			chart.Axis(StandardAxis.Depth).Visible = false;

			// first determine how many months we will show
			int monthCount = 12;
			if (Show2007DataCheckBox.Checked)
				monthCount += 12;

			// add the first bar
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.Name = "Coca Cola";
			bar1.MultiBarMode = MultiBarMode.Series;
			bar1.DataLabelStyle.Visible = false;

			bar1.Values.FillRandomRange(Random, monthCount, 10, 200);

			// add the second bar
			NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar2.Name = "Pepsi";
			bar2.MultiBarMode = MultiBarMode.Clustered;
			bar2.DataLabelStyle.Visible = false;

			// fill with random data
			bar2.Values.FillRandomRange(Random, monthCount, 10, 300);

			NAxis xAxis = chart.Axis(StandardAxis.PrimaryX);
			xAxis.ScrollBar.Visible = true;

			// add custom labels to the Y axis
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			UpdateScale();
		}

		private void UpdateScale()
		{
			// add custom labels to the X axis
			NHierarchicalScaleConfigurator hirarchicalScale = new NHierarchicalScaleConfigurator();
			NHierarchicalScaleNodeCollection nodes = hirarchicalScale.Nodes; ;

			string[] months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
			RangeLabelTickMode labelTickMode = RangeLabelTickMode.Separators;

			for (int i = 0; i < 2; i++)
			{
				if (!Show2007DataCheckBox.Checked && i == 0)
					continue;

				NHierarchicalScaleNode yearNode = new NHierarchicalScaleNode(0, (i + 2007).ToString());
				yearNode.LabelStyle.TickMode = labelTickMode;
				nodes.AddChild(yearNode);

				for (int j = 0; j < 4; j++)
				{
					NHierarchicalScaleNode quarterNode = new NHierarchicalScaleNode(3, "Q" + (j + 1).ToString());
					quarterNode.LabelStyle.TickMode = labelTickMode;
					yearNode.ChildNodes.AddChild(quarterNode);

					for (int k = 0; k < 3; k++)
					{
						NHierarchicalScaleNode monthNode = new NHierarchicalScaleNode(1, months[j * 3 + k]);
						monthNode.LabelStyle.Angle = new NScaleLabelAngle(90);
						monthNode.LabelStyle.TickMode = labelTickMode;
						monthNode.LabelStyle.Offset = new NLength(1);
						quarterNode.ChildNodes.AddChild(monthNode);
					}
				}
			}

			hirarchicalScale.CreateSeparatorForEachLevel = ShowLevelSeparatorsCheckBox.Checked;

			nChartControl1.Charts[0].Axis(StandardAxis.PrimaryX).ScaleConfigurator = hirarchicalScale;
		}
	}
}
