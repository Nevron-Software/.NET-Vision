using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLargeMeshSurfaceUC : NExampleBaseUC
	{
		private UI.WinForm.Controls.NCheckBox useHardwareAccelerationCheck;
		private System.ComponentModel.Container components = null;

		public NLargeMeshSurfaceUC()
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
			this.useHardwareAccelerationCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// useHardwareAccelerationCheck
			// 
			this.useHardwareAccelerationCheck.ButtonProperties.BorderOffset = 2;
			this.useHardwareAccelerationCheck.Location = new System.Drawing.Point(5, 7);
			this.useHardwareAccelerationCheck.Name = "useHardwareAccelerationCheck";
			this.useHardwareAccelerationCheck.Size = new System.Drawing.Size(171, 20);
			this.useHardwareAccelerationCheck.TabIndex = 5;
			this.useHardwareAccelerationCheck.Text = "Use Hardware Acceleration";
			this.useHardwareAccelerationCheck.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheck_CheckedChanged);
			// 
			// NLargeMeshSurfaceUC
			// 
			this.Controls.Add(this.useHardwareAccelerationCheck);
			this.Name = "NLargeMeshSurfaceUC";
			this.Size = new System.Drawing.Size(180, 88);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed;

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface with 1000000 Data Points");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 50.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

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
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series.Add(SeriesType.MeshSurface);
			surface.Name = "Surface";
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 8;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.CellTriangulationMode = MeshSurfaceCellTriangulationMode.Diagonal1;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.FillMode = SurfaceFillMode.ZoneTexture;
			surface.ShadingMode = ShadingMode.Smooth;
			surface.SmoothPalette = true;

			surface.Data.SetGridSize(1000, 1000);

			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			useHardwareAccelerationCheck.Checked = true;
		}

		private void FillData(NMeshSurfaceSeries surface)
		{
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			double x, y, z;
			double dAngle = 0;
			double dRadius = 100.0;
			double dElevation = 0;

			for (int j = 0; j < nCountZ; j++)			
			{
				for (int i = 0; i < nCountX; i++)	
				{
					x = dRadius * Math.Cos(dAngle) * (1 + i);
					z = dRadius * Math.Sin(dAngle) * (1 + i);
					y = dElevation + Math.Sin(i * 0.1) + Math.Sin(i * 0.004) * 5;

					surface.Data.SetValue(i, j, y, x, z);
				}

				if (j < 700)
					dRadius -= 0.1;
				else
					dRadius += 0.1;

				dElevation += 0.2;
				dAngle += 0.008 * Math.PI;
			}
		}

		private void UseHardwareAccelerationCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (useHardwareAccelerationCheck.Checked)
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			}
			else
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
			}
		}
	}
}