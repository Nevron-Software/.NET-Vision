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
	public class NGridSurfaceZoningUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox smoothPaletteCheck;
		private Nevron.UI.WinForm.Controls.NComboBox paletteStepsCombo;
		private Nevron.UI.WinForm.Controls.NComboBox paletteModeCombo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.Container components = null;

		public NGridSurfaceZoningUC()
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
			this.smoothPaletteCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.paletteStepsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.paletteModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// smoothPaletteCheck
			// 
			this.smoothPaletteCheck.ButtonProperties.BorderOffset = 2;
			this.smoothPaletteCheck.Location = new System.Drawing.Point(5, 135);
			this.smoothPaletteCheck.Name = "smoothPaletteCheck";
			this.smoothPaletteCheck.Size = new System.Drawing.Size(168, 21);
			this.smoothPaletteCheck.TabIndex = 4;
			this.smoothPaletteCheck.Text = "Smooth Palette";
			this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(5, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(168, 14);
			this.label4.TabIndex = 2;
			this.label4.Text = "Palette Steps:";
			// 
			// paletteStepsCombo
			// 
			this.paletteStepsCombo.ListProperties.CheckBoxDataMember = "";
			this.paletteStepsCombo.ListProperties.DataSource = null;
			this.paletteStepsCombo.ListProperties.DisplayMember = "";
			this.paletteStepsCombo.Location = new System.Drawing.Point(5, 89);
			this.paletteStepsCombo.Name = "paletteStepsCombo";
			this.paletteStepsCombo.Size = new System.Drawing.Size(168, 21);
			this.paletteStepsCombo.TabIndex = 3;
			this.paletteStepsCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteStepsCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 14);
			this.label2.TabIndex = 0;
			this.label2.Text = "Palette Mode:";
			// 
			// paletteModeCombo
			// 
			this.paletteModeCombo.ListProperties.CheckBoxDataMember = "";
			this.paletteModeCombo.ListProperties.DataSource = null;
			this.paletteModeCombo.ListProperties.DisplayMember = "";
			this.paletteModeCombo.Location = new System.Drawing.Point(5, 32);
			this.paletteModeCombo.Name = "paletteModeCombo";
			this.paletteModeCombo.Size = new System.Drawing.Size(168, 21);
			this.paletteModeCombo.TabIndex = 1;
			this.paletteModeCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteModeCombo_SelectedIndexChanged);
			// 
			// NGridSurfaceZoningUC
			// 
			this.Controls.Add(this.label4);
			this.Controls.Add(this.smoothPaletteCheck);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.paletteStepsCombo);
			this.Controls.Add(this.paletteModeCombo);
			this.Name = "NGridSurfaceZoningUC";
			this.Size = new System.Drawing.Size(180, 300);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// Enable GPU acceleration
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Grid Surface");
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
			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			// add the surface series
			NGridSurfaceSeries surface = new NGridSurfaceSeries();
			chart.Series.Add(surface);
			surface.ShadingMode = ShadingMode.Smooth;
			surface.FillMode = SurfaceFillMode.ZoneTexture;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.Data.SetGridSize(200, 200);

			// define a custom palette
			surface.Palette.Clear();
			surface.Palette.Add(-3, DarkOrange);
			surface.Palette.Add(-2.5, LightOrange);
			surface.Palette.Add(-1, LightGreen);
			surface.Palette.Add(0, Turqoise);
			surface.Palette.Add(2, Blue);
			surface.Palette.Add(3, Purple);
			surface.Palette.Add(4, BeautifulRed);

			// generate data
			GenerateSurfaceData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// form controls
			paletteModeCombo.SelectedIndex = 0;
			paletteStepsCombo.SelectedIndex = 6;
			smoothPaletteCheck.Checked = false;
		}

		private void GenerateSurfaceData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 50.0;
			const double dIntervalZ = 50.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = (x * z / 64.0) - Math.Sin(z / 2.4) * Math.Cos(x / 2.4);
					y = Math.Abs(y);
					double tmp = (1 - x * x - z * z);
					y -= tmp * tmp * 0.000006;

					surface.Data.SetValue(i, j, y);
				}
			}
		}
		private void UpdateSurface()
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

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