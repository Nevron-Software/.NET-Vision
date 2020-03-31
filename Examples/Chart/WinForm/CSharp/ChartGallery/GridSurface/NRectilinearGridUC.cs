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
	public class NRectilinearGridUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox smoothShadingCheck;
		private UI.WinForm.Controls.NButton GenerateDataButton;
		private System.ComponentModel.Container components = null;

		public NRectilinearGridUC()
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
			this.smoothShadingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.GenerateDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// smoothShadingCheck
			// 
			this.smoothShadingCheck.ButtonProperties.BorderOffset = 2;
			this.smoothShadingCheck.Location = new System.Drawing.Point(9, 48);
			this.smoothShadingCheck.Name = "smoothShadingCheck";
			this.smoothShadingCheck.Size = new System.Drawing.Size(158, 20);
			this.smoothShadingCheck.TabIndex = 3;
			this.smoothShadingCheck.Text = "Smooth Shading";
			this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(9, 9);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(158, 23);
			this.GenerateDataButton.TabIndex = 4;
			this.GenerateDataButton.Text = "Generate Data";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// NRectilinearGridUC
			// 
			this.Controls.Add(this.GenerateDataButton);
			this.Controls.Add(this.smoothShadingCheck);
			this.Name = "NRectilinearGridUC";
			this.Size = new System.Drawing.Size(176, 151);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = new NLabel("Rectilinear Grid Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 30.0f;
			chart.Height = 2.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftCameraLight);

			// setup axes
			NDateTimeScaleConfigurator scaleX = new NDateTimeScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Back };
			scaleX.InflateViewRangeBegin = false;
			scaleX.InflateViewRangeEnd = false;

			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Left };
			scaleZ.InflateViewRangeBegin = false;
			scaleZ.InflateViewRangeEnd = false;

			// add the surface series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Surface";
			surface.PositionValue = 10.0;
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 8;
			surface.ValueFormatter.FormatSpecifier = "0.000";
			surface.FillMode = SurfaceFillMode.Uniform;
			surface.FrameMode = SurfaceFrameMode.Mesh;
			surface.ShadingMode = ShadingMode.Flat;
			surface.FillStyle = new NColorFillStyle(Color.FromArgb(190, 210, 230));

			// specify that the surface should use custom X and Z values
			surface.XValuesMode = GridSurfaceValuesMode.CustomValues;
			surface.ZValuesMode = GridSurfaceValuesMode.CustomValues;

			surface.Data.SetGridSize(40, 20);

			GenerateXValues(surface);
			GenerateZValues(surface);
			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			smoothShadingCheck.Checked = true;
		}

		private void GenerateXValues(NGridSurfaceSeries surface)
		{
			int sizeX = surface.Data.GridSizeX;

			DateTime dtX = DateTime.Now;

			surface.XValues.Clear();

			for (int i = 0; i < sizeX; i++)
			{
				surface.XValues.Add(dtX.ToOADate());
				dtX = dtX.AddMinutes(Random.Next(5, 20));
			}
		}
		private void GenerateZValues(NGridSurfaceSeries surface)
		{
			int sizeZ = surface.Data.GridSizeZ;

			double z = 7;

			surface.ZValues.Clear();

			for (int i = 0; i < sizeZ; i++)
			{
				surface.ZValues.Add(z);
				z += 0.1 + Random.NextDouble();
			}
		}
		private void FillData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 8.0;
			const double dIntervalZ = 8.0;

			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = 0;

			for(int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for(int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = Math.Sin(x * 1.2) * Math.Sin(z * 1.2);

					if (y < 0)
						y = -y;

					surface.Data.SetValue(i, j, y);
				}
			}
		}

		private void SmoothShadingCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			if (smoothShadingCheck.Checked)
			{
				surface.ShadingMode = ShadingMode.Smooth;
			}
			else
			{
				surface.ShadingMode = ShadingMode.Flat;
			}

			nChartControl1.Refresh();
		}

		private void GenerateDataButton_Click(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			GenerateXValues(surface);
			GenerateZValues(surface);

			nChartControl1.Refresh();
		}
	}
}