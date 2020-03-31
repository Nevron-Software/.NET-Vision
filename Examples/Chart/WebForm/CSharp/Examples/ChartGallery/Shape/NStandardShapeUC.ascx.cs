using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStandardShapeUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithEnumValues(ShapeStyleDropDownList, typeof(BarShape));
				ShapeStyleDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithColorNames(ShapesColorDropDownList, KnownColor.DarkOrange);

				WebExamplesUtilities.FillComboWithPredefinedProjections(ProjectionDropDownList);
				ProjectionDropDownList.SelectedIndex = (int)PredefinedProjection.PerspectiveTilted;
            }

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Shape Series");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Depth = 50;
			chart.Projection.SetPredefinedProjection((PredefinedProjection)ProjectionDropDownList.SelectedIndex);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Floor };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			stripStyle.Interlaced = true;
			scaleY.StripStyles.Add(stripStyle);

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Left, ChartWallType.Floor };
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// setup shape series
			NShapeSeries shape = (NShapeSeries)chart.Series.Add(SeriesType.Shape);
			shape.Name = "Shape Series";
			shape.DataLabelStyle.Visible = false;

			// populate with random data
			shape.Values.FillRandomRange(Random, 10, -100, 100);
			shape.XValues.FillRandomRange(Random, 10, -100, 100);
			shape.ZValues.FillRandomRange(Random, 10, -100, 100);
			shape.YSizes.FillRandomRange(Random, 10, 5, 20);
			shape.XSizes.FillRandomRange(Random, 10, 5, 20);
			shape.ZSizes.FillRandomRange(Random, 10, 5, 20);

			shape.Shape = (BarShape)ShapeStyleDropDownList.SelectedIndex;
			shape.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(ShapesColorDropDownList));

			shape.UseXValues = UseXValueCheckBox.Checked;
			shape.UseZValues = UseZValueCheckBox.Checked;

			if (DifferentColorsCheckBox.Checked)
			{
				ShapesColorDropDownList.Enabled = false;

				NChartPalette palette = new NChartPalette();
				palette.SetPredefinedPalette(ChartPredefinedPalette.Nevron);

				for (int i = 0; i < shape.Values.Count; i++)
				{
					shape.FillStyles[i] = new NColorFillStyle(palette.SeriesColors[i % palette.SeriesColors.Count]);
				}
			}
			else
			{
				ShapesColorDropDownList.Enabled = true;
				shape.FillStyles.Clear();
				shape.FillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(ShapesColorDropDownList));
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}
	}
}