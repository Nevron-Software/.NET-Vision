using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Collections;

using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using System.Collections.Generic;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDateTimeScaleUC : NExampleUC
	{

		private NChart m_Chart;
		private NDateTimeScaleConfigurator m_DateTimeScale;
	
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Date Time Scale");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			m_Chart = nChartControl1.Charts[0];
			m_Chart.BoundsMode = BoundsMode.Stretch;

            // add a strip line style
            NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
            NScaleStripStyle stripStyle = new NScaleStripStyle();
            stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);
            m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;

			// create line serie and dispay them on vertical axis
			NLineSeries line1 = CreateLineSeries(Color.Red, Color.DarkRed);

			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();

			m_DateTimeScale = dateTimeScale;
			m_DateTimeScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 90);
			m_DateTimeScale.LabelStyle.ContentAlignment = ContentAlignment.MiddleLeft; 
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;

			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(
				new NLength(85, NRelativeUnit.ParentPercentage),
				new NLength(80, NRelativeUnit.ParentPercentage));

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
			
			if(!IsPostBack)
			{
				//set the begin date to today;
				StartDateCalendar.SelectedDate = DateTime.Today;
				
				//set the end date to a date two years from now
				EndDateCalendar.VisibleDate = CultureInfo.CurrentCulture.Calendar.AddYears(StartDateCalendar.SelectedDate, 2);
				EndDateCalendar.SelectedDate = CultureInfo.CurrentCulture.Calendar.AddYears(StartDateCalendar.SelectedDate, 2);
				EnableUnitSensitiveFormattingCheckBox.Checked = true;
			}

			UpdateDateTimeScale();
			UpdateTimeSpan();

		}

		private void UpdateDateTimeScale()
		{
			if (m_DateTimeScale == null)
			{
				return;
			}

			List<NDateTimeUnit> dateTimeUnits = new List<NDateTimeUnit>();
			dateTimeUnits.Add(NDateTimeUnit.Day);
			dateTimeUnits.Add(NDateTimeUnit.Week);
			dateTimeUnits.Add(NDateTimeUnit.Month);
			dateTimeUnits.Add(NDateTimeUnit.Quarter);
			dateTimeUnits.Add(NDateTimeUnit.Year);

			m_DateTimeScale.EnableUnitSensitiveFormatting = EnableUnitSensitiveFormattingCheckBox.Checked;
			m_DateTimeScale.AutoDateTimeUnits = dateTimeUnits.ToArray();
		}

		private NLineSeries CreateLineSeries(Color lightColor, Color darkColor)
		{
			NLineSeries line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);

			line.UseXValues = true;

			line.Name = "Line 1";
			line.BorderStyle.Color = darkColor;
			line.DataLabelStyle.Visible = false;
			line.InflateMargins = true;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.BorderStyle.Color = darkColor;
			line.MarkerStyle.FillStyle = new NColorFillStyle(lightColor);
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.Width = new NLength(2, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(2, NRelativeUnit.ParentPercentage);

			return line;
		}

		private void UpdateTimeSpan()
		{
			DateTime startDate = StartDateCalendar.SelectedDate;
			DateTime endDate = EndDateCalendar.SelectedDate;

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

		protected void StartDateCalendar_SelectionChanged(object sender, System.EventArgs e)
		{
			UpdateTimeSpan();
		}

		protected void EndDateCalendar_SelectionChanged(object sender, System.EventArgs e)
		{
			UpdateTimeSpan();
		}
	}
}
