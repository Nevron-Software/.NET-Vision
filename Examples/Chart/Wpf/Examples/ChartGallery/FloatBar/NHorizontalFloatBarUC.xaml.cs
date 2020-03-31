using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using Nevron.Dom;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NHorizontalFloatBarUC : NExampleBaseUC
	{
		public NHorizontalFloatBarUC()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Horizontal Float Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a horizontal Floating Bar chart. The component has built -in functionality for automatic configuration of left and right horizontally oriented charts.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("Gantt");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Projection.ViewerRotation = 270;
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup the value axis
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			dateTimeScale.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			dateTimeScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			stripStyle.Interlaced = true;
			dateTimeScale.StripStyles.Add(stripStyle);

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = dateTimeScale;
			chart.Axis(StandardAxis.PrimaryY).Anchor = new NDockAxisAnchor(AxisDockZone.FrontRight, true, 0, 100);

			// label the X axis
			NOrdinalScaleConfigurator ordinalScale = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.AutoLabels = false;
			ordinalScale.Labels.Add("Market Research");
			ordinalScale.Labels.Add("Specifications");
			ordinalScale.Labels.Add("Architecture");
			ordinalScale.Labels.Add("Project Planning");
			ordinalScale.Labels.Add("Detailed Design");
			ordinalScale.Labels.Add("Development");
			ordinalScale.Labels.Add("Test Plan");
			ordinalScale.Labels.Add("Testing and QA");
			ordinalScale.Labels.Add("Documentation");

			// create a floatbar series
			NFloatBarSeries floatBar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatBar.BeginValues.ValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			floatBar.EndValues.ValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			floatBar.DataLabelStyle.Visible = false;

			AddDataPoint(floatBar, new DateTime(2009, 2, 2), new DateTime(2009, 2, 16));
			AddDataPoint(floatBar, new DateTime(2009, 2, 16), new DateTime(2009, 3, 2));
			AddDataPoint(floatBar, new DateTime(2009, 3, 2), new DateTime(2009, 3, 16));
			AddDataPoint(floatBar, new DateTime(2009, 3, 9), new DateTime(2009, 3, 23));
			AddDataPoint(floatBar, new DateTime(2009, 3, 16), new DateTime(2009, 3, 30));
			AddDataPoint(floatBar, new DateTime(2009, 3, 23), new DateTime(2009, 4, 27));
			AddDataPoint(floatBar, new DateTime(2009, 4, 13), new DateTime(2009, 4, 27));
			AddDataPoint(floatBar, new DateTime(2009, 4, 20), new DateTime(2009, 5, 4));
			AddDataPoint(floatBar, new DateTime(2009, 4, 27), new DateTime(2009, 5, 4));

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);
		}


		private void AddDataPoint(NFloatBarSeries floatBar, DateTime dtBegin, DateTime dtEnd)
		{
			floatBar.BeginValues.Add(dtBegin.ToOADate());
			floatBar.EndValues.Add(dtEnd.ToOADate());
		}

	}
}
