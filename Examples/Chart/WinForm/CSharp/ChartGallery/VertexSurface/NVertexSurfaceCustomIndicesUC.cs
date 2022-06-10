using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
    [ToolboxItem(false)]
	public class NVertexSurfaceCustomIndicesUC : NExampleBaseUC
    {
        private System.ComponentModel.Container components = null;

		public NVertexSurfaceCustomIndicesUC()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // NVertexSurfaceCustomIndicesUC
            // 
            this.Name = "NVertexSurfaceCustomIndicesUC";
            this.Size = new System.Drawing.Size(180, 956);
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed;
			nChartControl1.Settings.JitterMode = JitterMode.Disabled;
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Vertex Surface Series<br/><font size='10pt'>Used to draw a pyramid that reuses vertex data to draw the side triangles.</font>");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 50.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

			// turn off lighting to improve performance
			chart.LightModel.EnableLighting = false;

			// setup axes
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleY.MaxTickCount = 5;

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;

			linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;

			// setup surface series
			NVertexSurfaceSeries surface = new NVertexSurfaceSeries();
			chart.Series.Add(surface);

			surface.Name = "Surface";
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 8;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FillMode = SurfaceFillMode.CustomColors;
			surface.UseIndices = true;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.VertexPrimitive = VertexPrimitive.Triangles;
			surface.Data.UseColors = true;

			// top
			surface.Data.AddValueColor(new NVector3DD(0.5, 1, 0.5), Color.Red);
			surface.Data.AddValueColor(new NVector3DD(0, 0, 0), Color.Green);
			surface.Data.AddValueColor(new NVector3DD(1, 0, 0), Color.Green); 
			surface.Data.AddValueColor(new NVector3DD(1, 0, 1), Color.Blue);
			surface.Data.AddValueColor(new NVector3DD(0, 0, 1), Color.Blue);

			// first triangle
			surface.Indices.Add(0);
			surface.Indices.Add(1);
			surface.Indices.Add(2);

			// second triangle
			surface.Indices.Add(0);
			surface.Indices.Add(2);
			surface.Indices.Add(3);

			// third triangle
			surface.Indices.Add(0);
			surface.Indices.Add(3);
			surface.Indices.Add(4);

			// fourth triangle
			surface.Indices.Add(0);
			surface.Indices.Add(4);
			surface.Indices.Add(1);



			// apply layout
			ConfigureStandardLayout(chart, title, null);
		}
    }
}