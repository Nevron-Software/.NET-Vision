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
	public class NMeshSurfaceTextureZoningUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NComboBox paletteModeCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothPaletteCheck;
		private Nevron.UI.WinForm.Controls.NComboBox paletteStepsCombo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.ComponentModel.Container components = null;

		public NMeshSurfaceTextureZoningUC()
		{
			InitializeComponent();

			paletteModeCombo.Items.Add("Use Fixed Number of Zones");
			paletteModeCombo.Items.Add("Synchronize Palette Zones with Y Axis");
			paletteModeCombo.Items.Add("Use Custom Palette");

			paletteStepsCombo.Items.Add("2");
			paletteStepsCombo.Items.Add("3");
			paletteStepsCombo.Items.Add("4");
			paletteStepsCombo.Items.Add("5");
			paletteStepsCombo.Items.Add("6");
			paletteStepsCombo.Items.Add("7");
			paletteStepsCombo.Items.Add("8");
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
			this.label4 = new System.Windows.Forms.Label();
			this.paletteModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.smoothPaletteCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.paletteStepsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(169, 14);
			this.label4.TabIndex = 0;
			this.label4.Text = "Palette Mode:";
			// 
			// paletteModeCombo
			// 
			this.paletteModeCombo.ListProperties.CheckBoxDataMember = "";
			this.paletteModeCombo.ListProperties.DataSource = null;
			this.paletteModeCombo.ListProperties.DisplayMember = "";
			this.paletteModeCombo.Location = new System.Drawing.Point(6, 32);
			this.paletteModeCombo.Name = "paletteModeCombo";
			this.paletteModeCombo.Size = new System.Drawing.Size(169, 21);
			this.paletteModeCombo.TabIndex = 1;
			this.paletteModeCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteModeCombo_SelectedIndexChanged);
			// 
			// smoothPaletteCheck
			// 
			this.smoothPaletteCheck.ButtonProperties.BorderOffset = 2;
			this.smoothPaletteCheck.Location = new System.Drawing.Point(6, 135);
			this.smoothPaletteCheck.Name = "smoothPaletteCheck";
			this.smoothPaletteCheck.Size = new System.Drawing.Size(169, 21);
			this.smoothPaletteCheck.TabIndex = 4;
			this.smoothPaletteCheck.Text = "Smooth Palette";
			this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 73);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(169, 14);
			this.label5.TabIndex = 2;
			this.label5.Text = "Palette Steps:";
			// 
			// paletteStepsCombo
			// 
			this.paletteStepsCombo.ListProperties.CheckBoxDataMember = "";
			this.paletteStepsCombo.ListProperties.DataSource = null;
			this.paletteStepsCombo.ListProperties.DisplayMember = "";
			this.paletteStepsCombo.Location = new System.Drawing.Point(6, 89);
			this.paletteStepsCombo.Name = "paletteStepsCombo";
			this.paletteStepsCombo.Size = new System.Drawing.Size(169, 21);
			this.paletteStepsCombo.TabIndex = 3;
			this.paletteStepsCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteStepsCombo_SelectedIndexChanged);
			// 
			// NMeshSurfaceTextureZoningUC
			// 
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.paletteStepsCombo);
			this.Controls.Add(this.paletteModeCombo);
			this.Controls.Add(this.smoothPaletteCheck);
			this.Name = "NMeshSurfaceTextureZoningUC";
			this.Size = new System.Drawing.Size(180, 300);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 25.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			// setup axes
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
			NMeshSurfaceSeries surface = new NMeshSurfaceSeries();
			chart.Series.Add(surface);
			surface.ShadingMode = ShadingMode.Smooth;
			surface.FillMode = SurfaceFillMode.ZoneTexture;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.Data.SetGridSize(100, 100);

			// define a custom palette
			surface.Palette.Clear();
			surface.Palette.Add(-0.8, DarkOrange);
			surface.Palette.Add(-0.4, LightOrange);
			surface.Palette.Add(-0.2, LightGreen);
			surface.Palette.Add(0, Turqoise);
			surface.Palette.Add(0.4, Blue);
			surface.Palette.Add(0.8, Purple);
			surface.Palette.Add(1, BeautifulRed);

			// generate data
			GenerateSurfaceData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// form controls
			paletteModeCombo.SelectedIndex = 0;
			paletteStepsCombo.SelectedIndex = 6;
			smoothPaletteCheck.Checked = false;
		}

		private void GenerateSurfaceData(NMeshSurfaceSeries surface)
		{
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 40.0;
			const double dIntervalZ = 40.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			double pz = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, pz += dIncrementZ)
			{
				double px = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, px += dIncrementX)
				{
					double x = px + Math.Sin(pz) * 0.4;
					double z = pz + Math.Cos(px) * 0.4;
					double y = Math.Sin(px * 0.33) * Math.Sin(pz * 0.33);

					if (y < 0)
					{
						y = - y * 0.7;
					}

					double tmp = (1 - x * x - z * z);
					y -= tmp * tmp * 0.000001;

					surface.Data.SetValue(i, j, y, x, z);
				}
			}
		}
		private void UpdateSurface()
		{
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)nChartControl1.Charts[0].Series[0];

			switch (paletteModeCombo.SelectedIndex)
			{
				case 0:
					surface.AutomaticPalette = true;
					surface.SyncPaletteWithAxisScale = false;
					paletteStepsCombo.Enabled = true;
					break;

				case 1:
					surface.AutomaticPalette = true;
					surface.SyncPaletteWithAxisScale = true;
					paletteStepsCombo.Enabled = false;
					break;

				case 2:
					surface.AutomaticPalette = false;
					paletteStepsCombo.Enabled = false;
					break;
			}

			if (smoothPaletteCheck.Checked)
			{
				surface.SmoothPalette = true;
				surface.PaletteSteps = paletteStepsCombo.SelectedIndex + 1;
			}
			else
			{
				surface.SmoothPalette = false;
				surface.PaletteSteps = paletteStepsCombo.SelectedIndex + 2;
			}
		}

		private void PaletteModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateSurface();

			nChartControl1.Refresh();
		}
		private void PaletteStepsCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateSurface();

			nChartControl1.Refresh();
		}
		private void SmoothPaletteCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateSurface();

			nChartControl1.Refresh();
		}
	}
}