using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NRangeTimelineScaleUC : NExampleUC
	{
		NCartesianChart m_Chart;
		NStockSeries m_Stock;

		protected void Page_Load(object sender, EventArgs e)
		{
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Range Timeline Scale");
			header.DockMode = PanelDockMode.Top;
			header.Margins = new NMarginsL(2, 2, 0, 5);
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.FitAlignment = ContentAlignment.MiddleLeft;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			nChartControl1.Panels.Add(header);

			// setup chart
			m_Chart = new NCartesianChart();
			nChartControl1.Panels.Add(m_Chart);
			m_Chart.DockMode = PanelDockMode.Fill;
			m_Chart.Margins = new NMarginsL(2, 0, 2, 2);
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.LightModel.EnableLighting = false;
			m_Chart.Axis(StandardAxis.Depth).Visible = false;
			m_Chart.Wall(ChartWallType.Floor).Visible = false;
			m_Chart.Wall(ChartWallType.Left).Visible = false;
			m_Chart.BoundsMode = BoundsMode.Stretch;
			m_Chart.Height = 40;

			// setup X axis
			NAxis axis = m_Chart.Axis(StandardAxis.PrimaryX);
			axis.ScrollBar.Visible = true;
			NRangeTimelineScaleConfigurator timelineScale = new NRangeTimelineScaleConfigurator();
			timelineScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			timelineScale.SecondRow.GridStyle.SetShowAtWall(ChartWallType.Back, true);
			timelineScale.ThirdRow.GridStyle.SetShowAtWall(ChartWallType.Back, true);
			axis.ScaleConfigurator = timelineScale;

			// setup primary Y axis
			axis = m_Chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);
			linearScale.InnerMajorTickStyle.Length = new NLength(0);

			// add interlaced stripe 
			NScaleStripStyle stripStyle = new NScaleStripStyle();
			stripStyle.FillStyle = new NColorFillStyle(Color.Beige);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			// Setup the stock series
			m_Stock = (NStockSeries)m_Chart.Series.Add(SeriesType.Stock);
			m_Stock.DataLabelStyle.Visible = false;
			m_Stock.CandleStyle = CandleStyle.Stick;
			m_Stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);
			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue;
			m_Stock.Legend.Mode = SeriesLegendMode.None;
			m_Stock.CloseValues.Name = "close";
			m_Stock.UseXValues = true;

			// init form controls
			if (!IsPostBack)
			{
				FirstRowVisibleCheckBox.Checked = true;
				SecondRowVisibleCheckBox.Checked = true;
				ThirdRowVisibleCheckBox.Checked = true;

				RandomDataTypeDropDownList.Items.Add("Daily");
				RandomDataTypeDropDownList.Items.Add("Weekly");
				RandomDataTypeDropDownList.Items.Add("Monthly");
				RandomDataTypeDropDownList.Items.Add("Yearly");
				RandomDataTypeDropDownList.SelectedIndex = 2;
			}

			timelineScale.FirstRow.Visible = FirstRowVisibleCheckBox.Checked;
			timelineScale.SecondRow.Visible = SecondRowVisibleCheckBox.Checked;
			timelineScale.ThirdRow.Visible = ThirdRowVisibleCheckBox.Checked;

			DateTime dtNow = DateTime.Now;
			DateTime dtEnd = dtNow;
			DateTime dtStart = dtNow;
			NDateTimeSpan span = new NDateTimeSpan();

			switch (RandomDataTypeDropDownList.SelectedIndex)
			{
				case 0:
					// generate data for 30 days
					dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 17, 0, 0, 0);
					dtStart = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0);
					span = new NDateTimeSpan(5, NDateTimeUnit.Minute);
					break;
				case 1:
					// generate data for 30 weeks
					dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0);
					dtStart = NDateTimeUnit.Week.Add(dtEnd, -30);
					span = new NDateTimeSpan(1, NDateTimeUnit.Day);
					break;
				case 2:
					// generate data for 30 months 
					dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0);
					dtStart = NDateTimeUnit.Month.Add(dtEnd, -30);
					span = new NDateTimeSpan(1, NDateTimeUnit.Week);
					break;
				case 3:
					// generate data for 30 years
					dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0);
					dtStart = NDateTimeUnit.Year.Add(dtEnd, -30);
					span = new NDateTimeSpan(1, NDateTimeUnit.Month);
					break;
			}

			GenerateData(dtStart, dtEnd, span);

		}
		private void GenerateData(DateTime dtStart, DateTime dtEnd, NDateTimeSpan span)
		{
			long count = span.GetSpanCountInRange(new NDateTimeRange(dtStart, dtEnd));

			WebExamplesUtilities.GenerateOHLCData(m_Stock, 100, (int)count);
			m_Stock.XValues.Clear();

			DateTime dtNow = dtStart;

			for (int i = 0; i < m_Stock.Values.Count; i++)
			{
				m_Stock.XValues.Add(dtNow.ToOADate());
				dtNow = span.Add(dtNow);
			}

			m_Chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = false;
		}
	}
}
