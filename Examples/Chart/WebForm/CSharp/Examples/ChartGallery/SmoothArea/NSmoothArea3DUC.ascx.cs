using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.GraphicsCore;
using Nevron.Examples.Framework.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NSmoothArea3DUC : NExampleUC
	{
		private const int nValuesCount = 6;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Smooth Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Axis(StandardAxis.Depth).Visible = false;
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

            // add interlace stripe
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
            linearScale.StripStyles.Add(stripStyle);

			// add the area series
			NSmoothAreaSeries area = (NSmoothAreaSeries)chart.Series.Add(SeriesType.SmoothArea);
			area.DataLabelStyle.Visible = false;
			area.MarkerStyle.Visible = false;
			area.MarkerStyle.PointShape = PointShape.Cylinder;
			area.MarkerStyle.BorderStyle.Color = Color.MidnightBlue;
			area.MarkerStyle.AutoDepth = true;
			area.MarkerStyle.Width = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			area.MarkerStyle.Height = new NLength(1.4f, NRelativeUnit.ParentPercentage);

			GenreateYValues(nValuesCount);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);

			if(!Page.IsPostBack)
			{
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
		}

		private void GenreateYValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries series = (NSeries)chart.Series[0];

			series.Values.Clear();

			for(int i = 0; i < nCount; i++)
			{
				series.Values.Add( 5 + Random.NextDouble() * 10);
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
