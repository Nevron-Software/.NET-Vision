using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NLargeSurfaceUC : NExampleUC
	{
		protected Label Label3;
		protected CheckBox DrawFlatCheckBoxBox;
		protected CheckBox ShowFillingCheckBox;
		protected CheckBox ShowFrameCheckBox;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				FillModeDropDownList.Items.Add("Uniform");
				FillModeDropDownList.Items.Add("Zone Texture");
				FillModeDropDownList.Items.Add("Zone Texture - Smooth");

				FillModeDropDownList.SelectedIndex = 1;
			}

			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Disabled;

			// setup the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Large Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 55.0f;
			chart.Depth = 55.0f;
			chart.Height = 4.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft);

			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.AutoLabels = false;
			scaleY.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleY.MaxTickCount = 5;

			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.AutoLabels = false;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			ordinalScale.AutoLabels = false;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			// add the surface series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Surface";
			surface.FrameMode = SurfaceFrameMode.None;
			surface.FillMode = SurfaceFillMode.Uniform;
			surface.PositionValue = 10.0;
			surface.ShadingMode = ShadingMode.Smooth;
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.Diagonal1;

			NColorFillStyle fill = new NColorFillStyle();
			fill.MaterialStyle.Ambient = Color.FromArgb(100, 100, 90);
			fill.MaterialStyle.Diffuse = Color.FromArgb(100, 100, 90);
			fill.MaterialStyle.Specular = Color.DimGray;
			surface.FillStyle = fill;

			using (Bitmap bitmap = new Bitmap(this.MapPathSecure("~\\Images\\HeightMap0500.png")))
			{
				surface.Data.InitFromBitmap(bitmap);
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends[0]);


			switch (FillModeDropDownList.SelectedIndex)
			{
				case 0:
					surface.FillMode = SurfaceFillMode.Uniform;
					break;

				case 1:
					surface.FillMode = SurfaceFillMode.ZoneTexture;
					surface.SmoothPalette = false;
					surface.PaletteSteps = 8;
					break;

				case 2:
					surface.FillMode = SurfaceFillMode.ZoneTexture;
					surface.SmoothPalette = true;
					surface.PaletteSteps = 7;
					break;
			}
		}
	}
}
