using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Dom;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NHorizontalFloatBarUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithPercents(WidthPercentDropDownList, 10);
				WidthPercentDropDownList.SelectedIndex = 7;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Gantt");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup legend
			NLegend legend = nChartControl1.Legends[0];
			legend.HorizontalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			legend.VerticalBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Projection.ViewerRotation = 270;

			// setup the value axis
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			dateTimeScale.EnableUnitSensitiveFormatting = false;
			dateTimeScale.LabelValueFormatter = new NDateTimeValueFormatter("d MMM");
			dateTimeScale.MajorTickMode  = MajorTickMode.CustomStep;
			dateTimeScale.CustomStep = new NDateTimeSpan(1, NDateTimeUnit.Week);
			dateTimeScale.LabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);
			dateTimeScale.LabelStyle.Angle = new NScaleLabelAngle(90);
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
			ordinalScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			ordinalScale.LabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);
			ordinalScale.MajorTickMode = MajorTickMode.AutoMaxCount;
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

			floatBar.WidthPercent = WidthPercentDropDownList.SelectedIndex * 10;

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void AddDataPoint(NFloatBarSeries floatBar, DateTime dtBegin, DateTime dtEnd)
		{
			floatBar.BeginValues.Add(dtBegin.ToOADate());
			floatBar.EndValues.Add(dtEnd.ToOADate());
		}
	}
}
