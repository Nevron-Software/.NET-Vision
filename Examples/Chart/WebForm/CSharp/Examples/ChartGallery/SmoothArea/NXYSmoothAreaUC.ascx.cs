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
using Nevron.Chart.WebForm;
using Nevron.Examples.Framework.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NXYSmoothAreaUC : NExampleUC
	{
		private const int nValuesCount = 6;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Smooth Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Axis(StandardAxis.Depth).Visible = false;
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);

			NLinearScaleConfigurator linearScaleX = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleX;

			NLinearScaleConfigurator linearScaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleY.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

            // add interlace stripe
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Back, ChartWallType.Left };
            linearScaleY.StripStyles.Add(stripStyle);

			// add the area series
			NSmoothAreaSeries area = (NSmoothAreaSeries)chart.Series.Add(SeriesType.SmoothArea);
			area.DataLabelStyle.Visible = false;
			area.MarkerStyle.Visible = true;
			area.MarkerStyle.PointShape = PointShape.Cylinder;
			area.MarkerStyle.BorderStyle.Color = Color.MidnightBlue;
			area.MarkerStyle.AutoDepth = true;
			area.MarkerStyle.Width = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			area.MarkerStyle.Height = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			area.UseXValues = true;

			GenreateYValues(nValuesCount);
			GenreateXValues(nValuesCount);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

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

			linearScaleX.RoundToTickMin = RoundToTickCheck.Checked;
			linearScaleX.RoundToTickMax = RoundToTickCheck.Checked;

			linearScaleY.RoundToTickMin = RoundToTickCheck.Checked;
			linearScaleY.RoundToTickMax = RoundToTickCheck.Checked;
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

			double x = 120;

			for(int i = 0; i < nCount; i++)
			{
				x += 10 + Random.NextDouble() * 10;

				series.XValues.Add(x);
			}
		}
	}
}
