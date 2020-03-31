using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Dom;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAxisStripLinesUC : NExampleUC
	{

		private NChart m_Chart;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				HighLightRangeDropDownList.Items.Add("Weekdays");
				HighLightRangeDropDownList.Items.Add("Weekends");
				HighLightRangeDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Strip Lines");
			header.TextStyle.TextFormat = TextFormat.XML;
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// configure chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(
				new NLength(2, NRelativeUnit.ParentPercentage),
				new NLength(13, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(94, NRelativeUnit.ParentPercentage),
				new NLength(85, NRelativeUnit.ParentPercentage));

			// Add a line series
			NLineSeries line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			line.UseXValues = true;
			line.BorderStyle.Color = Color.DarkRed;
			line.DataLabelStyle.Visible = false;
			line.InflateMargins = true;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.BorderStyle.Color = Color.DarkRed;
			line.MarkerStyle.FillStyle = new NColorFillStyle(Color.Red);
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.Width = new NLength(2, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(2, NRelativeUnit.ParentPercentage);
			line.Legend.Mode = SeriesLegendMode.None;

			// create a date time scale
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();

			dateTimeScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 90);
			dateTimeScale.LabelStyle.ContentAlignment = ContentAlignment.MiddleLeft; 
			dateTimeScale.EnableUnitSensitiveFormatting = false;
			dateTimeScale.MajorTickMode = MajorTickMode.CustomStep;
			dateTimeScale.CustomStep = new NDateTimeSpan(1, NDateTimeUnit.Day);
			dateTimeScale.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.WeekDayShortName);

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;

			// create a strip line highlighting the working days
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(125, Color.Orange)), null, true, 0, 0, 2, 5);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);

			NDateTimeRangeSamplerProvider provider = new NDateTimeRangeSamplerProvider();
			provider.SamplingMode = SamplingMode.CustomStep;
			provider.UseOrigin = true;
			provider.Origin = new DateTime(2007, 2, 19);
			provider.CustomStep = new NDateTimeSpan(1, NDateTimeUnit.Day);
			stripStyle.RangeSamplerProvider = provider;

			// configure the x axis to use date time paging 
			NDateTimeAxisPagingView dateTimePagingView = new NDateTimeAxisPagingView(DateTime.Now, new NDateTimeSpan(10, NDateTimeUnit.Day));
			dateTimePagingView.Enabled = true;
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = dateTimePagingView;

			GenerateData(null, null);

			if(!Page.IsPostBack)
			{
				HighLightRangeDropDownList.SelectedIndex = 0;
			}

			UpdateHighlightRange();
		}

		private void GenerateData(object sender, System.EventArgs e)
		{
			DateTime startDate = DateTime.Now;
			DateTime endDate = DateTime.Now.Add(new TimeSpan(30, 0, 0, 0, 0));

			if (startDate > endDate)
			{
				DateTime temp = startDate;

				startDate = endDate;
				endDate = temp;
			}

			// Get the line series from the chart
			NLineSeries line = (NLineSeries)m_Chart.Series[0];

			TimeSpan span = endDate - startDate;
			span = new TimeSpan(span.Ticks / 30);

			line.Values.Clear();
			line.XValues.Clear();

			if (span.Ticks > 0)
			{
				while (startDate < endDate)
				{
					line.XValues.Add(startDate);
					startDate += span;

					line.Values.Add(Random.Next(100));
				}
			}
		}

		private void UpdateHighlightRange()
		{
			NScaleStripStyle stripStyle;
			DateTime origin;

			// create a strip line highlighting the working days
			if (HighLightRangeDropDownList.SelectedIndex == 0)
			{
				origin = new DateTime(2007, 2, 19);
				stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.SkyBlue), null, true, 0, 0, 2, 5);
			}
			else
			{
				origin = new DateTime(2007, 2, 17);
				stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.LightSeaGreen), null, true, 0, 0, 5, 2);
			}

			stripStyle.SetShowAtWall(ChartWallType.Back, true);

			NStandardScaleConfigurator scaleConfigurator = (NStandardScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleConfigurator.StripStyles.Clear();
			scaleConfigurator.StripStyles.Add(stripStyle);

			NDateTimeRangeSamplerProvider provider = new NDateTimeRangeSamplerProvider();
			provider.SamplingMode = SamplingMode.CustomStep;
			provider.UseOrigin = true;
			provider.Origin = origin;
			provider.CustomStep = new NDateTimeSpan(1, NDateTimeUnit.Day);
			stripStyle.RangeSamplerProvider = provider;
		}
	}
}
