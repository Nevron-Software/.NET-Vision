using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NXYScatterBubbleUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(BubbleShapeDropDownList, typeof(PointShape));
				BubbleShapeDropDownList.SelectedIndex = 7;

				WebExamplesUtilities.FillComboWithValues(MinBubbleSizeDropDownList, 0, 20, 2);
				MinBubbleSizeDropDownList.SelectedIndex = 2;
				WebExamplesUtilities.FillComboWithValues(MaxBubbleSizeDropDownList, 0, 20, 2);
				MaxBubbleSizeDropDownList.SelectedIndex = 9;

				LightingFilterCheckBox.Checked = true;
				InflateMarginsCheckBox.Checked = true;
				AxesRoundToTickCheckBox.Checked = false;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Scatter Bubble Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			linearScale.RoundToTickMin = AxesRoundToTickCheckBox.Checked;
			linearScale.RoundToTickMax = AxesRoundToTickCheckBox.Checked;
			linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.RoundToTickMin = AxesRoundToTickCheckBox.Checked;
			linearScale.RoundToTickMax = AxesRoundToTickCheckBox.Checked;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// setup bubble series
			NBubbleSeries bubble = (NBubbleSeries)chart.Series.Add(SeriesType.Bubble);
			bubble.BubbleShape = (PointShape)BubbleShapeDropDownList.SelectedIndex;
			bubble.InflateMargins = InflateMarginsCheckBox.Checked;
			bubble.UseXValues = true;
			bubble.DataLabelStyle.Visible = false;
			bubble.BorderStyle.Width = new NLength(0);
			bubble.Legend.Format = "<label>";
			bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			bubble.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			bubble.ShadowStyle.Type = ShadowType.GaussianBlur;
			bubble.ShadowStyle.Offset = new NPointL(new NLength(1, NGraphicsUnit.Pixel), new NLength(1, NGraphicsUnit.Pixel));
			bubble.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0);

			bubble.MinSize = new NLength(MinBubbleSizeDropDownList.SelectedIndex * 2, NRelativeUnit.ParentPercentage);
			bubble.MaxSize = new NLength(MaxBubbleSizeDropDownList.SelectedIndex * 2, NRelativeUnit.ParentPercentage);

			AddDataPoints(bubble);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);
		}

		private void AddDataPoints(NBubbleSeries bubble)
		{
            NChartPalette palette = new NChartPalette();
            palette.SetPredefinedPalette(ChartPredefinedPalette.Dark);

            NColorFillStyle fs0 = new NColorFillStyle(palette.SeriesColors[0]);
            NColorFillStyle fs1 = new NColorFillStyle(palette.SeriesColors[1]);
            NColorFillStyle fs2 = new NColorFillStyle(palette.SeriesColors[2]);
            NColorFillStyle fs3 = new NColorFillStyle(palette.SeriesColors[3]);
			NColorFillStyle fs4 = new NColorFillStyle(palette.SeriesColors[4]);
			NColorFillStyle fs5 = new NColorFillStyle(palette.SeriesColors[5]);

			if (LightingFilterCheckBox.Checked)
			{
				fs0.ImageFiltersStyle.Filters.Add(CreateLightingImageFilter());
				fs1.ImageFiltersStyle.Filters.Add(CreateLightingImageFilter());
				fs2.ImageFiltersStyle.Filters.Add(CreateLightingImageFilter());
				fs3.ImageFiltersStyle.Filters.Add(CreateLightingImageFilter());
				fs4.ImageFiltersStyle.Filters.Add(CreateLightingImageFilter());
				fs5.ImageFiltersStyle.Filters.Add(CreateLightingImageFilter());
			}

			bubble.AddDataPoint(new NBubbleDataPoint(27, 51, 1147995904, "India", fs0));
			bubble.AddDataPoint(new NBubbleDataPoint(50, 67, 1321851888, "China", fs1));
			bubble.AddDataPoint(new NBubbleDataPoint(76, 22, 109955400, "Mexico", fs2));
			bubble.AddDataPoint(new NBubbleDataPoint(210, 9, 142008838, "Russia", fs3));
			bubble.AddDataPoint(new NBubbleDataPoint(360, 4, 305843000, "USA", fs4));
			bubble.AddDataPoint(new NBubbleDataPoint(470, 5, 33560000, "Canada", fs5));
		}

		private NLightingImageFilter CreateLightingImageFilter()
		{
			NLightingImageFilter lightingFilter = new NLightingImageFilter();
			lightingFilter.BevelDepth = new NLength(5, NGraphicsUnit.Pixel);
			lightingFilter.BlurType = BlurType.Gaussian;
			lightingFilter.DiffuseColor = Color.FromArgb(125, 100, 100, 100);
			lightingFilter.SpecularColor = Color.FromArgb(125, Color.Yellow);

			return lightingFilter;
		}
	}
}
