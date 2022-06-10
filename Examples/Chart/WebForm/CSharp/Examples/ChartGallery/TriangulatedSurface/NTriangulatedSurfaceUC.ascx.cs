using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;
using System.IO;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NTriangulatedSurfaceUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!Page.IsPostBack)
            {
                //Setup dropdown lists and check boxes states.
                fillDropDownList.Items.Add("None");
                fillDropDownList.Items.Add("Uniform");
                fillDropDownList.Items.Add("Zone");
                fillDropDownList.SelectedIndex = 2;

                frameModeDropDownList.Items.Add("None");
                frameModeDropDownList.Items.Add("Mesh");
                frameModeDropDownList.Items.Add("Contour");
                frameModeDropDownList.Items.Add("Mesh-Contour");
                frameModeDropDownList.Items.Add("Dots");
                frameModeDropDownList.SelectedIndex = 0;

                frameColorModeDropDownList.Items.Add("Uniform");
                frameColorModeDropDownList.Items.Add("Zone");
                frameColorModeDropDownList.SelectedIndex = 0;

                positionModeDropDownList.Items.Add("Axis Begin");
                positionModeDropDownList.Items.Add("Axis End");
                positionModeDropDownList.Items.Add("Custom Value");
                positionModeDropDownList.SelectedIndex = 0;

                WebExamplesUtilities.FillComboWithValues(customValueDropDownList, 0, 250, 50);

                smoothShadingCheck.Checked = true;
                smoothPaletteCheck.Checked = true;
            }

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Triangulated Surface Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.Data.MarkSize = new NSizeL(5, 5);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 10.0f;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.Projection.Elevation = 30;

			NLinearScaleConfigurator yScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			yScale.OuterMajorTickStyle.Visible = false;
			yScale.InnerMajorTickStyle.Visible = false;
			yScale.AutoLabels = false;
			yScale.InnerMajorTickStyle.Visible = false;
			yScale.InnerMinorTickStyle.Visible = false;

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.RoundToTickMax = false;
			scaleY.RoundToTickMin = false;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Back };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMax = false;
			scaleX.RoundToTickMin = false;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.RoundToTickMax = false;
			scaleZ.RoundToTickMin = false;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Left };
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;

			// add the surface series
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series.Add(SeriesType.TriangulatedSurface);
			surface.Name = "Surface";
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			surface.PositionValue = 10.0;
			surface.SyncPaletteWithAxisScale = false;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);

			FillData();

			switch(fillDropDownList.SelectedIndex)
			{
				case 0:
					surface.FillMode = SurfaceFillMode.None;
					smoothShadingCheck.Enabled = false;
					break;

				case 1:
					surface.FillMode = SurfaceFillMode.Uniform;
					smoothShadingCheck.Enabled = true;
					break;

				case 2:
					surface.FillMode = SurfaceFillMode.Zone;
					smoothShadingCheck.Enabled = true;
					break;
			}

			if(smoothPaletteCheck.Checked)
			{
				surface.SmoothPalette = true;
				surface.PaletteSteps = 7;
				surface.Legend.Format = "<zone_value>";
			}
			else
			{
				surface.SmoothPalette = false;
				surface.PaletteSteps = 8;
				surface.Legend.Format = "<zone_begin> - <zone_end>";
			}

			surface.DrawFlat = drawFlatCheck.Checked;
			positionModeDropDownList.Enabled = drawFlatCheck.Checked;
			customValueDropDownList.Enabled = drawFlatCheck.Checked;
			surface.FrameMode = (SurfaceFrameMode)frameModeDropDownList.SelectedIndex;
			frameColorModeDropDownList.Enabled = (surface.FrameMode != SurfaceFrameMode.None);
			surface.PositionMode = (SurfacePositionMode)positionModeDropDownList.SelectedIndex;
			surface.PositionValue = Convert.ToDouble(customValueDropDownList.SelectedValue);

			switch(frameColorModeDropDownList.SelectedIndex)
			{
				case 0:
					surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
					break;

				case 1:
					surface.FrameColorMode = SurfaceFrameColorMode.Zone;
					break;
			}

			if(smoothShadingCheck.Checked)
			{
				surface.ShadingMode = ShadingMode.Smooth;
			}
			else
			{
				surface.ShadingMode = ShadingMode.Flat;
			}

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, legend);
		}

		private void FillData()
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			Stream stream = null;
			BinaryReader reader = null;

			try
			{
				
				// fill the XYZ data from a binary resource
				string path = MapPathSecure(TemplateSourceDirectory) + "\\DataXYZ.bin";
				stream = new FileStream(path, FileMode.Open, FileAccess.Read);
				reader = new BinaryReader(stream);

				int nDataPointsCount = (int)stream.Length / 12;

				//surface.Data.SetCapacity(nDataPointsCount);
				NVector3DF[] data = new NVector3DF[nDataPointsCount];

				// fill Y values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					data[i].Y = reader.ReadSingle();
				}

				// fill X values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					data[i].X = reader.ReadSingle();
				}

				// fill Z values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					data[i].Z = reader.ReadSingle();
				}

				surface.Data.Clear();
				surface.Data.AddValues(data);
			}
			finally
			{
				if(reader != null)
					reader.Close();

				if(stream != null)
					stream.Close();
			}
		}
	}
}
