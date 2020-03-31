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
	public class NRealTimeSurfaceUC : NRealTimeExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox smoothPaletteCheck;
		private Nevron.UI.WinForm.Controls.NComboBox paletteStepsCombo;
		private Nevron.UI.WinForm.Controls.NComboBox paletteModeCombo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.Container components = null;
		private UI.WinForm.Controls.NButton StartStopTimerButton;
		DateTime startTime;

		public NRealTimeSurfaceUC()
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
			this.StartStopTimerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// smoothPaletteCheck
			// 
			this.smoothPaletteCheck.ButtonProperties.BorderOffset = 2;
			this.smoothPaletteCheck.Location = new System.Drawing.Point(5, 168);
			this.smoothPaletteCheck.Name = "smoothPaletteCheck";
			this.smoothPaletteCheck.Size = new System.Drawing.Size(168, 21);
			this.smoothPaletteCheck.TabIndex = 4;
			this.smoothPaletteCheck.Text = "Smooth Palette";
			this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(5, 106);
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
			this.paletteStepsCombo.Location = new System.Drawing.Point(5, 122);
			this.paletteStepsCombo.Name = "paletteStepsCombo";
			this.paletteStepsCombo.Size = new System.Drawing.Size(168, 21);
			this.paletteStepsCombo.TabIndex = 3;
			this.paletteStepsCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteStepsCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 49);
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
			this.paletteModeCombo.Location = new System.Drawing.Point(5, 65);
			this.paletteModeCombo.Name = "paletteModeCombo";
			this.paletteModeCombo.Size = new System.Drawing.Size(168, 21);
			this.paletteModeCombo.TabIndex = 1;
			this.paletteModeCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteModeCombo_SelectedIndexChanged);
			// 
			// StartStopTimerButton
			// 
			this.StartStopTimerButton.Location = new System.Drawing.Point(5, 11);
			this.StartStopTimerButton.Name = "StopStartTimerButton";
			this.StartStopTimerButton.Size = new System.Drawing.Size(168, 23);
			this.StartStopTimerButton.TabIndex = 5;
			this.StartStopTimerButton.Text = "Stop Timer";
			this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
			// 
			// NRealTimeSurfaceUC
			// 
			this.Controls.Add(this.StartStopTimerButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.smoothPaletteCheck);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.paletteStepsCombo);
			this.Controls.Add(this.paletteModeCombo);
			this.Name = "NRealTimeSurfaceUC";
			this.Size = new System.Drawing.Size(180, 227);
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
			NLabel title = nChartControl1.Labels.AddHeader("Real Time Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 5.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

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
			surface.SmoothPalette = true;
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.MaxSum;
			surface.Data.SetGridSize(100, 100);

			// define a custom palette
			surface.Palette.Clear();
			surface.Palette.Add(-1, DarkOrange);
			surface.Palette.Add(-0.5, LightOrange);
			surface.Palette.Add(-0.25, LightGreen);
			surface.Palette.Add(0, Turqoise);
			surface.Palette.Add(0.25, Blue);
			surface.Palette.Add(0.5, Purple);
			surface.Palette.Add(1, BeautifulRed);

			// generate initial data
			startTime = DateTime.Now;
			UpdateSurfaceData();

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// form controls
			paletteModeCombo.SelectedIndex = 0;
			paletteStepsCombo.SelectedIndex = 6;
			smoothPaletteCheck.Checked = true;

			StartTimer();
		}

		protected override void OnTimerTick(object sender, EventArgs e)
		{
			base.OnTimerTick(sender, e);

			UpdateSurfaceData();

			nChartControl1.Refresh();
		}
		protected override void UpdateTitle(bool working, float cpuUsage)
		{
			string title = "Real Time Surface";

			if (working)
			{
				title += " [CPU Usage - " + cpuUsage.ToString("0.") + "%]";
			}

			nChartControl1.Labels[0].Text = title;
		}

		private void UpdateSurfaceData()
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			TimeSpan span = startTime - DateTime.Now;
			double t = 0.002 * span.TotalMilliseconds;

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
					y = - Math.Sin(t + x * z * 0.04) * Math.Cos(t + x * 0.4);

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
		private void StartStopTimerButton_Click(object sender, EventArgs e)
		{
			ToggleTimer();

			if (IsTimerRunning())
			{
				StartStopTimerButton.Text = "Stop Timer";
			}
			else
			{
				StartStopTimerButton.Text = "Start Timer";
			}
		}
	}
}