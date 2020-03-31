using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Examples.Framework.WebForm;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDateTimeSmoothAreaUC : NExampleUC
	{
		private const int nValuesCount = 5;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Date/Time Smooth Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;
			dateTimeScale.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
            linearScale.StripStyles.Add(stripStyle);

			// add the area series
			NSmoothAreaSeries area = (NSmoothAreaSeries)chart.Series.Add(SeriesType.SmoothArea);
			area.FillStyle = new NColorFillStyle(Color.LightSteelBlue);
			area.BorderStyle.Color = Color.MidnightBlue;
			area.DataLabelStyle.Visible = false;
			area.MarkerStyle.Visible = true;
			area.MarkerStyle.PointShape = PointShape.Cylinder;
			area.MarkerStyle.BorderStyle.Color = Color.MidnightBlue;
			area.MarkerStyle.AutoDepth = false;
			area.MarkerStyle.Width = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			area.MarkerStyle.Height = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			area.MarkerStyle.Depth = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			area.UseXValues = true;

			GenreateYValues(nValuesCount);
			GenreateXValues(nValuesCount);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			if(!Page.IsPostBack)
			{
				ShowMarkersCheck.Checked = true;
				RoundToTickCheck.Checked = true;
				ShowDropLinesCheck.Checked = false;

				WebExamplesUtilities.FillComboWithEnumValues(AreaOriginModeCombo, typeof(SeriesOriginMode));
				AreaOriginModeCombo.SelectedIndex = 0;
				OriginValueTextBox.Text = "0";
			}

			area.MarkerStyle.Visible = ShowMarkersCheck.Checked;
			area.DropLines = ShowDropLinesCheck.Checked;

			area.OriginMode = (SeriesOriginMode)AreaOriginModeCombo.SelectedIndex;

			try
			{
				area.Origin = Double.Parse(OriginValueTextBox.Text);
			}
			catch
			{
			}

			dateTimeScale.RoundToTickMin = RoundToTickCheck.Checked;
			dateTimeScale.RoundToTickMax = RoundToTickCheck.Checked;

			linearScale.RoundToTickMin = RoundToTickCheck.Checked;
			linearScale.RoundToTickMax = RoundToTickCheck.Checked;
		}

		private void GenreateYValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries series = (NSeries)chart.Series[0];

			series.Values.Clear();

			for(int i = 0; i < nCount; i++)
			{
				series.Values.Add(5 + Random.NextDouble() * 10);
			}
		}

		private void GenreateXValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NXYScatterSeries series = (NXYScatterSeries)chart.Series[0];

			series.XValues.Clear();

			DateTime dt = new DateTime(2005, 5, 24, 11, 0, 0);

			for(int i = 0; i < nCount; i++)
			{
				dt = dt.AddHours(12 + Random.NextDouble() * 60);

				series.XValues.Add(dt);
			}
		}
	}
}
