using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NParetoUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(BarShapeDropDownList, typeof(BarShape));
				BarShapeDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Pareto Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

            // setup the X axis
			NAxis axisX = chart.Axis(StandardAxis.PrimaryX);
			NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)axisX.ScaleConfigurator;
			scaleX.InnerMajorTickStyle.Visible = false;

			// setup the primary Y axis
			NAxis axisY1 = chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator scaleY1 = (NLinearScaleConfigurator)axisY1.ScaleConfigurator;
			scaleY1.InnerMajorTickStyle.Visible = false;
			scaleY1.Title.Text = "Number of Occurences";

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleY1.StripStyles.Add(stripStyle);

			// setup the secondary Y axis
			NLinearScaleConfigurator scaleY2 = new NLinearScaleConfigurator();
			scaleY2.LabelValueFormatter = new NNumericValueFormatter("0%");
			scaleY2.InnerMajorTickStyle.Visible = false;
			scaleY2.Title.Text = "Cumulative Percent";
			NAxis axisY2 = chart.Axis(StandardAxis.SecondaryY);
			axisY2.Visible = true;
			axisY2.ScaleConfigurator = scaleY2;
			axisY2.View = new NRangeAxisView(new NRange1DD(0, 1), true, true);

			// add a line series for the cumulative value
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.Name = "Cumulative";
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.DataLabelStyle.Visible = false;
			line.DisplayOnAxis(StandardAxis.PrimaryY, false);
			line.DisplayOnAxis(StandardAxis.SecondaryY, true);

			// add a bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.DataLabelStyle.Visible = false;
			bar.InflateMargins = true;
			bar.BarShape = (BarShape)BarShapeDropDownList.SelectedIndex;

			// fill with random data and sort in descending order
			bar.Values.FillRandom(Random, 10);
			bar.Values.Sort(DataSeriesSortOrder.Descending);

			// calculate cumulative sum of the bar values
			int count = bar.Values.Count;
			double cs = 0;
			double[] arrCumulative = new double[count];

			for (int i = 0; i < count; i++)
			{
				cs += bar.Values.GetDoubleValue(i);
				arrCumulative[i] = cs;
			}

			if (cs > 0)
			{
				for (int i = 0; i < count; i++)
				{
					arrCumulative[i] /= cs;
				}

				line.Values.AddRange(arrCumulative);
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}
