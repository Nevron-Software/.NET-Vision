using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDynamicAxisRangeUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			if (!IsPostBack)
			{
				nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

				// set a chart title
				NLabel title = nChartControl1.Labels.AddHeader("Dynamic Axis Range");
				title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

				// no legend
				nChartControl1.Legends.Clear();

				// setup chart
				chart.BoundsMode = BoundsMode.Stretch;

				NLineSeries line = new NLineSeries();
				line.DataLabelStyle.Visible = false;
				line.VerticalAxisRangeMode = AxisRangeMode.ViewRange;

				GenerateData(line, 100.0, 100, new NRange1DD(60, 140));
				chart.Series.Add(line);
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();

				WebExamplesUtilities.FillComboWithEnumNames(VerticalAxisRangeModeDropDownList, typeof(AxisRangeMode));
				VerticalAxisRangeModeDropDownList.SelectedIndex = (int)AxisRangeMode.ViewRange;

				int step = 10;

				for (int beginValue = 0; beginValue < 100; beginValue += step)
				{
					IntervalDropDownList.Items.Add(beginValue.ToString() + " - " + (beginValue + step).ToString());
				}
			}

			{
				double start = IntervalDropDownList.SelectedIndex * 10;

				// assign new range
				chart.Axis(StandardAxis.PrimaryX).View = new NRangeAxisView(new NRange1DD(start, start + 10), true, true);

				// assign the range mode
				chart.Series[0].VerticalAxisRangeMode = (AxisRangeMode)VerticalAxisRangeModeDropDownList.SelectedIndex;
			}
		}

		public static void GenerateData(NXYScatterSeries xyScatterSeries, double value, int nCount, NRange1DD range)
		{
			xyScatterSeries.ClearDataPoints();
			DateTime dt = new DateTime(2009, 1, 5);

			for (int nIndex = 0; nIndex < nCount; nIndex++)
			{
				bool upward = false;

				if (range.Begin > value)
				{
					upward = true;
				}
				else if (range.End < value)
				{
					upward = false;
				}
				else
				{
					upward = Random.NextDouble() > 0.5;
				}

				xyScatterSeries.Values.Add(value);

				if (upward)
				{
					value += (2 + (Random.NextDouble() * 20));
				}
				else
				{
					value -= (2 + (Random.NextDouble() * 20));
				}

				xyScatterSeries.XValues.Add(nIndex);
			}
		}
	}
}
