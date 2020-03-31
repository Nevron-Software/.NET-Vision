using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAxisViewRangeInflateUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(ViewRangeInflateModeDropDownList, typeof(ScaleViewRangeInflateMode));
				ViewRangeInflateModeDropDownList.SelectedIndex = (int)ScaleViewRangeInflateMode.MajorTick;

				InflateMinCheckBox.Checked = true;
				InflateMaxCheckBox.Checked = true;

				WebExamplesUtilities.FillComboWithValues(LogicalInflateMinMaxDropDownList, 0, 200, 10);
				WebExamplesUtilities.FillComboWithValues(AbsoluteInflateMinMaxDropDownList, 0, 20, 2);
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Volume Change vs. Last Year<br/> <font size = '9pt'>Demonstrates different view range modes</font>");
			header.TextStyle.TextFormat = TextFormat.XML;
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			header.DockMode = PanelDockMode.Top;
			header.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center;
			header.Margins = new NMarginsL(10, 2, 10, 10);
			nChartControl1.Panels.Add(header);

			// add some data to the control
			NCartesianChart chart = new NCartesianChart();
			chart.DockMode = PanelDockMode.Fill;
			chart.BoundsMode = BoundsMode.Stretch;

			NBarSeries bar = new NBarSeries();
			bar.DataLabelStyle.Visible = false;

			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);

			bar.Values.Add(100);
			bar.FillStyles[0] = new NColorFillStyle(palette.SeriesColors[0]);

			bar.Values.Add(200);
			bar.FillStyles[1] = new NColorFillStyle(palette.SeriesColors[0]);

			bar.Values.Add(-180);
			bar.FillStyles[3] = new NColorFillStyle(palette.SeriesColors[1]);

			bar.Values.Add(200);
			bar.FillStyles[4] = new NColorFillStyle(palette.SeriesColors[1]);

			bar.Values.Add(400);
			bar.FillStyles[5] = new NColorFillStyle(palette.SeriesColors[1]);

			chart.Series.Add(bar);

			chart.Margins = new NMarginsL(10, 0, 10, 10);

			// configure y axis
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// configure the x axis
			NHierarchicalScaleConfigurator hierarchicalScale = new NHierarchicalScaleConfigurator();
			hierarchicalScale.CreateSeparatorForEachLevel = false;

			// create utilization group
			NHierarchicalScaleNode utilization = new NHierarchicalScaleNode(0, "Cash Utilisation");

			utilization.LabelStyle.TickMode = RangeLabelTickMode.Separators;
			utilization.LabelStyle.TextStyle.FontStyle.EmSize = new NLength(11);
			utilization.LabelStyle.TextStyle.FontStyle.Style = FontStyle.Bold;

			utilization.ChildNodes.Add(CreateSubScaleNode("Cash at ATM", true, false));
			utilization.ChildNodes.Add(CreateSubScaleNode("Cash at desk", true, false));
			hierarchicalScale.Nodes.Add(utilization);

			// create payments group
			NHierarchicalScaleNode payments = new NHierarchicalScaleNode(0, "Payments");

			payments.LabelStyle.TickMode = RangeLabelTickMode.Separators;
			payments.LabelStyle.TextStyle.FontStyle.EmSize = new NLength(11);
			payments.LabelStyle.TextStyle.FontStyle.Style = FontStyle.Bold;

			payments.ChildNodes.Add(CreateSubScaleNode("Cheque", true, false));
			payments.ChildNodes.Add(CreateSubScaleNode("Direct debit", true, false));
			payments.ChildNodes.Add(CreateSubScaleNode("Wire transfer", true, true));
			hierarchicalScale.Nodes.Add(payments);

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = hierarchicalScale;
			nChartControl1.Panels.Add(chart);

			// update form controls			
			NAxis yAxis = nChartControl1.Charts[0].Axis(StandardAxis.PrimaryY);
			NNumericScaleConfigurator scale = (NNumericScaleConfigurator)yAxis.ScaleConfigurator;
			scale.Title.Text = "Volume in Thousands USD";

			scale.ViewRangeInflateMode = (ScaleViewRangeInflateMode)ViewRangeInflateModeDropDownList.SelectedIndex;
			scale.InflateViewRangeBegin = InflateMinCheckBox.Checked;
			scale.InflateViewRangeEnd = InflateMaxCheckBox.Checked;

			switch (scale.ViewRangeInflateMode)
			{
				case ScaleViewRangeInflateMode.MajorTick:
					break;
				case ScaleViewRangeInflateMode.Logical:
					double logicalInflate = LogicalInflateMinMaxDropDownList.SelectedIndex * 10;
					scale.LogicalInflate = new NRange1DD(logicalInflate, logicalInflate);
					break;
				case ScaleViewRangeInflateMode.Absolute:
					float absoluteInflate = AbsoluteInflateMinMaxDropDownList.SelectedIndex * 2;
					scale.AbsoluteInflate = new NRange1DL(new NLength(absoluteInflate, NGraphicsUnit.Point),
															new NLength(absoluteInflate, NGraphicsUnit.Point));
					break;
			}

			// assign scale configurator to y axis
			yAxis.ScaleConfigurator = scale;

			// update controls state
			LogicalInflateMinMaxDropDownList.Enabled = scale.ViewRangeInflateMode == ScaleViewRangeInflateMode.Logical;
			AbsoluteInflateMinMaxDropDownList.Enabled = scale.ViewRangeInflateMode == ScaleViewRangeInflateMode.Absolute;
		}

		private NHierarchicalScaleNode CreateSubScaleNode(string text, bool beginSeparator, bool endSeparator)
		{
			NHierarchicalScaleNode node = new NHierarchicalScaleNode(1, text);

			if (beginSeparator && endSeparator)
			{
				node.LabelStyle.TickMode = RangeLabelTickMode.Separators;
			}
			else if (beginSeparator)
			{
				node.LabelStyle.TickMode = RangeLabelTickMode.BeginSeparator;
			}
			else if (endSeparator)
			{
				node.LabelStyle.TickMode = RangeLabelTickMode.EndSeparator;
			}

			return node;
		}
	}
}
