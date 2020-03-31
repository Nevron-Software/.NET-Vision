using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.UI;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NLargeSurfaceUC : NExampleBaseUC
	{
		private Label label1;
		private Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox surfaceSizeCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox useHardwareAccelerationCheck;
		private UI.WinForm.Controls.NComboBox fillModeCombo;
		private System.ComponentModel.IContainer components = null;

		public NLargeSurfaceUC()
		{
			InitializeComponent();

			surfaceSizeCombo.Items.Add("500 x 500");
			surfaceSizeCombo.Items.Add("1024 x 1024");

			fillModeCombo.Items.Add("Uniform");
			fillModeCombo.Items.Add("Zone Texture");
			fillModeCombo.Items.Add("Zone Texture - Smooth");
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.surfaceSizeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.useHardwareAccelerationCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.fillModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// surfaceSizeCombo
			// 
			this.surfaceSizeCombo.ListProperties.CheckBoxDataMember = "";
			this.surfaceSizeCombo.ListProperties.DataSource = null;
			this.surfaceSizeCombo.ListProperties.DisplayMember = "";
			this.surfaceSizeCombo.Location = new System.Drawing.Point(6, 67);
			this.surfaceSizeCombo.Name = "surfaceSizeCombo";
			this.surfaceSizeCombo.Size = new System.Drawing.Size(168, 21);
			this.surfaceSizeCombo.TabIndex = 2;
			this.surfaceSizeCombo.SelectedIndexChanged += new System.EventHandler(this.SurfaceSizeCombo_SelectedIndexChanged);
			// 
			// useHardwareAccelerationCheck
			// 
			this.useHardwareAccelerationCheck.ButtonProperties.BorderOffset = 2;
			this.useHardwareAccelerationCheck.Location = new System.Drawing.Point(6, 13);
			this.useHardwareAccelerationCheck.Name = "useHardwareAccelerationCheck";
			this.useHardwareAccelerationCheck.Size = new System.Drawing.Size(171, 20);
			this.useHardwareAccelerationCheck.TabIndex = 0;
			this.useHardwareAccelerationCheck.Text = "Use Hardware Acceleration";
			this.useHardwareAccelerationCheck.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheck_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Surface Size:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 103);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Fill Mode:";
			// 
			// fillModeCombo
			// 
			this.fillModeCombo.ListProperties.CheckBoxDataMember = "";
			this.fillModeCombo.ListProperties.DataSource = null;
			this.fillModeCombo.ListProperties.DisplayMember = "";
			this.fillModeCombo.Location = new System.Drawing.Point(6, 120);
			this.fillModeCombo.Name = "fillModeCombo";
			this.fillModeCombo.Size = new System.Drawing.Size(168, 21);
			this.fillModeCombo.TabIndex = 4;
			this.fillModeCombo.SelectedIndexChanged += new System.EventHandler(this.FillModeCombo_SelectedIndexChanged);
			// 
			// NLargeSurfaceUC
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.fillModeCombo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.surfaceSizeCombo);
			this.Controls.Add(this.useHardwareAccelerationCheck);
			this.Name = "NLargeSurfaceUC";
			this.Size = new System.Drawing.Size(180, 203);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;

			// add a trackball tool so that the user can rotate the chart
			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.Cache = true;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 55.0f;
			chart.Depth = 55.0f;
			chart.Height = 4.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.AutoLabels = false;
			scaleY.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleY.MaxTickCount = 5;

			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			// add the surface series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Surface";
			surface.FrameMode = SurfaceFrameMode.None;
			surface.ShadingMode = ShadingMode.Smooth;
			surface.AutomaticPalette = true;
			surface.SyncPaletteWithAxisScale = false;

			// NOTE: Cell triangulation mode is important for performance. Use Diagonal1 or Diagonal2 for faster rendering.
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.Diagonal1;

			NColorFillStyle fill = new NColorFillStyle();
			fill.MaterialStyle.Ambient = Color.FromArgb(122, 125, 110);
			fill.MaterialStyle.Diffuse = Color.FromArgb(122, 125, 110);
			fill.MaterialStyle.Specular = Color.DimGray;
			surface.FillStyle = fill;

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			useHardwareAccelerationCheck.Checked = true;
			surfaceSizeCombo.SelectedIndex = 0;
			fillModeCombo.SelectedIndex = 1;
		}

		private void UseHardwareAccelerationCheck_CheckedChanged(object sender, System.EventArgs e)
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
		private void SurfaceSizeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			string heightMapName = "";

			switch (surfaceSizeCombo.SelectedIndex)
			{
				case 0:
					heightMapName = "HeightMap0500.png";
					break;

				case 1:
					heightMapName = "HeightMap1024.png";
					break;

				default:
					return;
			}

			Bitmap bitmap = NResourceHelper.BitmapFromResource(this.GetType(), heightMapName, "Nevron.Examples.Chart.WinForm.Resources");
			surface.Data.InitFromBitmap(bitmap);
			bitmap.Dispose();

			nChartControl1.Refresh();
		}
		private void FillModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			switch (fillModeCombo.SelectedIndex)
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

			nChartControl1.Refresh();
		}
	}
}

