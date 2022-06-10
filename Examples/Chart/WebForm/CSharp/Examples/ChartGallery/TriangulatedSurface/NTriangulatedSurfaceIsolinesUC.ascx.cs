using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;
using System.Drawing;
using System.IO;
using System.Web.UI.WebControls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NTriangulatedSurfaceIsolinesUC : NExampleUC
	{
		protected Label Label3;
		protected CheckBox DrawFlatCheckBoxBox;
		protected CheckBox ShowFillingCheckBox;
		protected CheckBox ShowFrameCheckBox;
	
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
			nChartControl1.Settings.JitterMode = JitterMode.Enabled;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Triangulated Surface Isolines");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 10.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.Projection.Elevation = 45;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.RoundToTickMax = false;
			scaleY.RoundToTickMin = false;
			scaleY.MinTickDistance = new NLength(10, NGraphicsUnit.Point);
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Left, ChartWallType.Back };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMax = false;
			scaleX.RoundToTickMin = false;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.RoundToTickMax = false;
			scaleZ.RoundToTickMin = false;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Left };
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;

			// add the surface series
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series.Add(SeriesType.TriangulatedSurface);
			surface.Name = "Surface";
			surface.Legend.Mode = SeriesLegendMode.None;
			surface.SyncPaletteWithAxisScale = false;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FrameMode = SurfaceFrameMode.None;
			surface.Palette.SmoothPalette = true;
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);

			FillData();

			// add the isolines
			NSurfaceIsoline redIsoline = new NSurfaceIsoline();
			redIsoline.StrokeStyle = new NStrokeStyle(2.0f, Color.Red);
			redIsoline.Value = 100;
			surface.Isolines.Add(redIsoline);

			NSurfaceIsoline blueIsoline = new NSurfaceIsoline();
			blueIsoline.StrokeStyle = new NStrokeStyle(2.0f, Color.Blue);
			blueIsoline.Value = 50;
			surface.Isolines.Add(blueIsoline);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
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
				if (reader != null)
					reader.Close();

				if (stream != null)
					stream.Close();
			}
		}
	}
}
