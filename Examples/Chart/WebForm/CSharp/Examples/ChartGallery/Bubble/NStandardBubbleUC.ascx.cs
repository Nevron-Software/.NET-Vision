using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NStandardBubbleUC : NExampleUC
    {
        protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(BubbleShapeDropDownList, typeof(PointShape));
				BubbleShapeDropDownList.SelectedIndex = 6;

				WebExamplesUtilities.FillComboWithValues(MinBubbleSizeDropDownList, 0, 30, 5);
				WebExamplesUtilities.FillComboWithValues(MaxBubbleSizeDropDownList, 0, 30, 5);

				MinBubbleSizeDropDownList.SelectedIndex = 2;
				MaxBubbleSizeDropDownList.SelectedIndex = 4;
				DifferentColorsCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Bubble Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = false;

			// setup X axis
			NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.DisplayDataPointsBetweenTicks = false;
			scaleX.MajorTickMode = MajorTickMode.CustomTicks;
			scaleX.CustomMajorTicks.AddRange(new long[] { 0, 1, 2, 3, 4, 5 });
			scaleX.CustomLabels.Add(new NCustomValueLabel(0, "A"));
			scaleX.CustomLabels.Add(new NCustomValueLabel(1, "B"));
			scaleX.CustomLabels.Add(new NCustomValueLabel(2, "C"));
			scaleX.CustomLabels.Add(new NCustomValueLabel(3, "D"));
			scaleX.CustomLabels.Add(new NCustomValueLabel(4, "E"));
			scaleX.CustomLabels.Add(new NCustomValueLabel(5, "F"));

            // add interlace stripe
            NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleY.StripStyles.Add(stripStyle);

			NBubbleSeries bubble = (NBubbleSeries)chart.Series.Add(SeriesType.Bubble);
			bubble.InflateMargins = true;
			bubble.DataLabelStyle.Visible = false;
			bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			bubble.Legend.Format = "<size> <label>";

			bubble.AddDataPoint(new NBubbleDataPoint(10, 10, "A"));
			bubble.AddDataPoint(new NBubbleDataPoint(15, 20, "B"));
			bubble.AddDataPoint(new NBubbleDataPoint(12, 25, "C"));
			bubble.AddDataPoint(new NBubbleDataPoint(8, 15, "D"));
			bubble.AddDataPoint(new NBubbleDataPoint(14, 17, "E"));
			bubble.AddDataPoint(new NBubbleDataPoint(11, 12, "F"));

			bubble.BubbleShape = (PointShape)BubbleShapeDropDownList.SelectedIndex;
			bubble.MinSize = new NLength(MinBubbleSizeDropDownList.SelectedIndex * 5, NRelativeUnit.ParentPercentage);
			bubble.MaxSize = new NLength(MaxBubbleSizeDropDownList.SelectedIndex * 5, NRelativeUnit.ParentPercentage);

            if (DifferentColorsCheckBox.Checked)
			{
                // apply style sheet
                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
                styleSheet.Apply(nChartControl1.Document);
			}
			else
			{
                // apply style sheet
                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
                styleSheet.Apply(nChartControl1.Document);
            }

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}
	}
}

