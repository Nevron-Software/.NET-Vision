using System;

using System.Drawing;

using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NCustomRangeLabelsUC : NExampleUC
	{
		NBarSeries m_Bar1;
		NBarSeries m_Bar2;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ShowNorthAmericaCheckBox.Checked = true;
				ShowEuropeCheckBox.Checked = true;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Company Sales by Region<br/><font size = '9pt'>Demonstrates how to use custom range labels to denote ranges on a scale</font>");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			header.TextStyle.TextFormat = TextFormat.XML;
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
			header.DockMode = PanelDockMode.Top;
			header.FitAlignment = ContentAlignment.MiddleLeft;
			header.Margins = new NMarginsL(5, 0, 10, 10);
			header.Location = new NPointL(new NLength(3, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			NCartesianChart chart = new NCartesianChart();
			nChartControl1.Panels.Add(chart);

			// configure the legend and add it as child panel of the chart
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

			chart.DisplayOnLegend = legend;
			chart.DockMode = PanelDockMode.Fill;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Margins = new NMarginsL(2, 0, 2, 2);
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add range selection
			NRangeSelection rangeSelection = new NRangeSelection();
			rangeSelection.VerticalValueSnapper = new NAxisRulerMinMaxSnapper();
			chart.RangeSelections.Add(rangeSelection);

			// add the first bar
			m_Bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			m_Bar1.Name = "Coca Cola";
			m_Bar1.MultiBarMode = MultiBarMode.Series;
			m_Bar1.DataLabelStyle.Format = "<value>";

			// add the second bar
			m_Bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			m_Bar2.Name = "Pepsi";
			m_Bar2.MultiBarMode = MultiBarMode.Clustered;
			m_Bar2.DataLabelStyle.Format = "<value>";

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// add custom labels to the X axis
			NAxis xAxis = chart.Axis(StandardAxis.PrimaryX);
			xAxis.ScrollBar.Visible = true;
			NOrdinalScaleConfigurator ordinalScale = xAxis.ScaleConfigurator as NOrdinalScaleConfigurator;

			ordinalScale.AutoLabels = false;
			ordinalScale.OuterMajorTickStyle.Visible = false;
			ordinalScale.InnerMajorTickStyle.Visible = false;

			// add custom labels to the Y axis
			chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(0, 320));
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.RoundToTickMax = false;
			NCustomRangeLabel rangeLabel = new NCustomRangeLabel(new NRange1DD(240, 320), "Target Volume");
			rangeLabel.Style.TickMode = RangeLabelTickMode.Center;
			rangeLabel.Style.WrapText = true;
			rangeLabel.Style.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			linearScale.CustomLabels.Add(rangeLabel);

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			UpdateRegions();
		}

		private void UpdateRegions()
		{
			m_Bar1.Values.Clear();
			m_Bar2.Values.Clear();

			// add custom labels to the X axis
			NChart chart = nChartControl1.Charts[0];
			NOrdinalScaleConfigurator ordinalScale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.Labels.Clear();
			ordinalScale.CustomLabels.Clear();

			if (ShowNorthAmericaCheckBox.Checked)
			{
				ordinalScale.Labels.Add("USA");
				ordinalScale.Labels.Add("Canada");
				ordinalScale.Labels.Add("Mexico");

				NCustomRangeLabel rangeLabel = new NCustomRangeLabel();
				rangeLabel.Text = "Sales for North America";
				rangeLabel.Range = new NRange1DD(0, 2);
				ordinalScale.CustomLabels.Add(rangeLabel);

				m_Bar1.Values.Add(Random.Next(10, 300));
				m_Bar1.Values.Add(Random.Next(10, 300));
				m_Bar1.Values.Add(Random.Next(10, 300));

				m_Bar2.Values.Add(Random.Next(10, 300));
				m_Bar2.Values.Add(Random.Next(10, 300));
				m_Bar2.Values.Add(Random.Next(10, 300));
			}

			if (ShowEuropeCheckBox.Checked)
			{
				ordinalScale.Labels.Add("Germany");
				ordinalScale.Labels.Add("UK");
				ordinalScale.Labels.Add("France");

				NCustomRangeLabel rangeLabel = new NCustomRangeLabel();
				rangeLabel.Text = "Sales for Europe";
				rangeLabel.Range = new NRange1DD(m_Bar1.Values.Count, m_Bar1.Values.Count + 2);
				ordinalScale.CustomLabels.Add(rangeLabel);

				m_Bar1.Values.Add(Random.Next(10, 300));
				m_Bar1.Values.Add(Random.Next(10, 300));
				m_Bar1.Values.Add(Random.Next(10, 300));

				m_Bar2.Values.Add(Random.Next(10, 300));
				m_Bar2.Values.Add(Random.Next(10, 300));
				m_Bar2.Values.Add(Random.Next(10, 300));
			}
		}
	}
}
