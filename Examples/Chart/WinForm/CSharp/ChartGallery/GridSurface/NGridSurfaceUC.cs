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
	public class NGridSurfaceUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothPaletteCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothShadingCheck;
		private Nevron.UI.WinForm.Controls.NComboBox fillModeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox frameColorModeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox frameModeCombo;
		private Nevron.UI.WinForm.Controls.NHScrollBar customValueScroll;
		private Nevron.UI.WinForm.Controls.NComboBox positionModeCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox drawFlatCheck;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox4;
		private UI.WinForm.Controls.NComboBox PaletteLegendModeComboBox;
		private System.ComponentModel.Container components = null;

		public NGridSurfaceUC()
		{
			InitializeComponent();

			fillModeCombo.Items.Add("None");
			fillModeCombo.Items.Add("Uniform");
			fillModeCombo.Items.Add("Zone");

			frameModeCombo.Items.Add("None");
			frameModeCombo.Items.Add("Mesh");
			frameModeCombo.Items.Add("Contour");
			frameModeCombo.Items.Add("Mesh-Contour");
			frameModeCombo.Items.Add("Dots");

			frameColorModeCombo.Items.Add("Uniform");
			frameColorModeCombo.Items.Add("Zone");

			positionModeCombo.Items.Add("Axis Begin");
			positionModeCombo.Items.Add("Axis End");
			positionModeCombo.Items.Add("Custom Value");

			PaletteLegendModeComboBox.FillFromEnum(typeof(PaletteLegendMode));
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.smoothPaletteCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.smoothShadingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.fillModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.frameColorModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.frameModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox4 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.customValueScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.positionModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.drawFlatCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.PaletteLegendModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox3.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// nGroupBox3
			// 
			this.nGroupBox3.Controls.Add(this.PaletteLegendModeComboBox);
			this.nGroupBox3.Controls.Add(this.smoothPaletteCheck);
			this.nGroupBox3.ImageIndex = 0;
			this.nGroupBox3.Location = new System.Drawing.Point(1, 253);
			this.nGroupBox3.Name = "nGroupBox3";
			this.nGroupBox3.Size = new System.Drawing.Size(171, 98);
			this.nGroupBox3.TabIndex = 6;
			this.nGroupBox3.TabStop = false;
			this.nGroupBox3.Text = "Palette";
			// 
			// smoothPaletteCheck
			// 
			this.smoothPaletteCheck.ButtonProperties.BorderOffset = 2;
			this.smoothPaletteCheck.Location = new System.Drawing.Point(17, 29);
			this.smoothPaletteCheck.Name = "smoothPaletteCheck";
			this.smoothPaletteCheck.Size = new System.Drawing.Size(142, 21);
			this.smoothPaletteCheck.TabIndex = 0;
			this.smoothPaletteCheck.Text = "Smooth Palette";
			this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.smoothShadingCheck);
			this.nGroupBox2.Controls.Add(this.label4);
			this.nGroupBox2.Controls.Add(this.fillModeCombo);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(1, 5);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(174, 96);
			this.nGroupBox2.TabIndex = 4;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Surface Filling";
			// 
			// smoothShadingCheck
			// 
			this.smoothShadingCheck.ButtonProperties.BorderOffset = 2;
			this.smoothShadingCheck.Location = new System.Drawing.Point(17, 69);
			this.smoothShadingCheck.Name = "smoothShadingCheck";
			this.smoothShadingCheck.Size = new System.Drawing.Size(158, 20);
			this.smoothShadingCheck.TabIndex = 2;
			this.smoothShadingCheck.Text = "Smooth Shading";
			this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(142, 14);
			this.label4.TabIndex = 0;
			this.label4.Text = "Fill Mode:";
			// 
			// fillModeCombo
			// 
			this.fillModeCombo.ListProperties.CheckBoxDataMember = "";
			this.fillModeCombo.ListProperties.DataSource = null;
			this.fillModeCombo.ListProperties.DisplayMember = "";
			this.fillModeCombo.Location = new System.Drawing.Point(17, 37);
			this.fillModeCombo.Name = "fillModeCombo";
			this.fillModeCombo.Size = new System.Drawing.Size(142, 21);
			this.fillModeCombo.TabIndex = 1;
			this.fillModeCombo.SelectedIndexChanged += new System.EventHandler(this.FillModeCombo_SelectedIndexChanged);
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.label5);
			this.nGroupBox1.Controls.Add(this.frameColorModeCombo);
			this.nGroupBox1.Controls.Add(this.label2);
			this.nGroupBox1.Controls.Add(this.frameModeCombo);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(1, 117);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(174, 120);
			this.nGroupBox1.TabIndex = 5;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Surface Frame";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(17, 69);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(142, 14);
			this.label5.TabIndex = 2;
			this.label5.Text = "Frame Color Mode:";
			// 
			// frameColorModeCombo
			// 
			this.frameColorModeCombo.ListProperties.CheckBoxDataMember = "";
			this.frameColorModeCombo.ListProperties.DataSource = null;
			this.frameColorModeCombo.ListProperties.DisplayMember = "";
			this.frameColorModeCombo.Location = new System.Drawing.Point(17, 85);
			this.frameColorModeCombo.Name = "frameColorModeCombo";
			this.frameColorModeCombo.Size = new System.Drawing.Size(142, 21);
			this.frameColorModeCombo.TabIndex = 3;
			this.frameColorModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameColorModeCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(17, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(142, 14);
			this.label2.TabIndex = 0;
			this.label2.Text = "Frame Mode:";
			// 
			// frameModeCombo
			// 
			this.frameModeCombo.ListProperties.CheckBoxDataMember = "";
			this.frameModeCombo.ListProperties.DataSource = null;
			this.frameModeCombo.ListProperties.DisplayMember = "";
			this.frameModeCombo.Location = new System.Drawing.Point(17, 37);
			this.frameModeCombo.Name = "frameModeCombo";
			this.frameModeCombo.Size = new System.Drawing.Size(142, 21);
			this.frameModeCombo.TabIndex = 1;
			this.frameModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameModeCombo_SelectedIndexChanged);
			// 
			// nGroupBox4
			// 
			this.nGroupBox4.Controls.Add(this.label3);
			this.nGroupBox4.Controls.Add(this.customValueScroll);
			this.nGroupBox4.Controls.Add(this.label1);
			this.nGroupBox4.Controls.Add(this.positionModeCombo);
			this.nGroupBox4.Controls.Add(this.drawFlatCheck);
			this.nGroupBox4.ImageIndex = 0;
			this.nGroupBox4.Location = new System.Drawing.Point(1, 357);
			this.nGroupBox4.Name = "nGroupBox4";
			this.nGroupBox4.Size = new System.Drawing.Size(174, 136);
			this.nGroupBox4.TabIndex = 7;
			this.nGroupBox4.TabStop = false;
			this.nGroupBox4.Text = "Flat Mode";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(17, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(152, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "Custom Value:";
			// 
			// customValueScroll
			// 
			this.customValueScroll.Enabled = false;
			this.customValueScroll.LargeChange = 1;
			this.customValueScroll.Location = new System.Drawing.Point(17, 109);
			this.customValueScroll.Maximum = 20;
			this.customValueScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.customValueScroll.Name = "customValueScroll";
			this.customValueScroll.Size = new System.Drawing.Size(142, 17);
			this.customValueScroll.TabIndex = 4;
			this.customValueScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.CustomValueScroll_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Position Mode:";
			// 
			// positionModeCombo
			// 
			this.positionModeCombo.Enabled = false;
			this.positionModeCombo.ListProperties.CheckBoxDataMember = "";
			this.positionModeCombo.ListProperties.DataSource = null;
			this.positionModeCombo.ListProperties.DisplayMember = "";
			this.positionModeCombo.Location = new System.Drawing.Point(17, 61);
			this.positionModeCombo.Name = "positionModeCombo";
			this.positionModeCombo.Size = new System.Drawing.Size(142, 21);
			this.positionModeCombo.TabIndex = 2;
			this.positionModeCombo.SelectedIndexChanged += new System.EventHandler(this.PositionModeCombo_SelectedIndexChanged);
			// 
			// drawFlatCheck
			// 
			this.drawFlatCheck.ButtonProperties.BorderOffset = 2;
			this.drawFlatCheck.Location = new System.Drawing.Point(17, 21);
			this.drawFlatCheck.Name = "drawFlatCheck";
			this.drawFlatCheck.Size = new System.Drawing.Size(152, 20);
			this.drawFlatCheck.TabIndex = 0;
			this.drawFlatCheck.Text = "Draw Flat";
			this.drawFlatCheck.CheckedChanged += new System.EventHandler(this.DrawFlatCheck_CheckedChanged);
			// 
			// PaletteLegendModeComboBox
			// 
			this.PaletteLegendModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.PaletteLegendModeComboBox.ListProperties.DataSource = null;
			this.PaletteLegendModeComboBox.ListProperties.DisplayMember = "";
			this.PaletteLegendModeComboBox.Location = new System.Drawing.Point(17, 56);
			this.PaletteLegendModeComboBox.Name = "PaletteLegendModeComboBox";
			this.PaletteLegendModeComboBox.Size = new System.Drawing.Size(142, 21);
			this.PaletteLegendModeComboBox.TabIndex = 4;
			this.PaletteLegendModeComboBox.SelectedIndexChanged += new System.EventHandler(this.PaletteLegendModeComboBox_SelectedIndexChanged);
			// 
			// NGridSurfaceUC
			// 
			this.Controls.Add(this.nGroupBox3);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.nGroupBox4);
			this.Name = "NGridSurfaceUC";
			this.Size = new System.Drawing.Size(180, 496);
			this.nGroupBox3.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox4.ResumeLayout(false);
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
			NLabel title = nChartControl1.Labels.AddHeader("Surface Chart");
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
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Surface";
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.PositionValue = 10.0;
			surface.Data.SetGridSize(31, 32);
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 8;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);

			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// form controls
			fillModeCombo.SelectedIndex = 2;
			smoothShadingCheck.Checked = true;
			frameModeCombo.SelectedIndex = 2;
			frameColorModeCombo.SelectedIndex = 0;
			smoothPaletteCheck.Checked = false;
			positionModeCombo.SelectedIndex = 0;
			customValueScroll.Value = 10;
			PaletteLegendModeComboBox.SelectedIndex = (int)PaletteLegendMode.GradientAxis;
		}

		private void FillData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 30.0;
			const double dIntervalZ = 30.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = (x * z / 64.0) - Math.Sin(z / 2.4) * Math.Cos(x / 2.4);
					y = 10 * Math.Sqrt(Math.Abs(y));

					if (y <= 0)
					{
						y = 1 + Math.Cos(x / 2.4);
					}

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
		private void FillModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			switch (fillModeCombo.SelectedIndex)
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

			nChartControl1.Refresh();
		}
		private void FrameModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			surface.FrameMode = (SurfaceFrameMode)frameModeCombo.SelectedIndex;
			nChartControl1.Refresh();

			// form controls
			frameColorModeCombo.Enabled = (surface.FrameMode != SurfaceFrameMode.None);
		}
		private void FrameColorModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			switch (frameColorModeCombo.SelectedIndex)
			{
				case 0:
					surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
					break;

				case 1:
					surface.FrameColorMode = SurfaceFrameColorMode.Zone;
					break;
			}

			nChartControl1.Refresh();
		}
		private void SmoothPaletteCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			if (smoothPaletteCheck.Checked)
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

			nChartControl1.Refresh();
		}
		private void DrawFlatCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			surface.DrawFlat = drawFlatCheck.Checked;
			nChartControl1.Refresh();

			// form controls
			positionModeCombo.Enabled = drawFlatCheck.Checked;
			customValueScroll.Enabled = drawFlatCheck.Checked;
		}
		private void PositionModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			surface.PositionMode = (SurfacePositionMode)positionModeCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void CustomValueScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			surface.PositionValue = customValueScroll.Value;
			nChartControl1.Refresh();
		}

		private void PaletteLegendModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			surface.Legend.PaletteLegendMode = (PaletteLegendMode)PaletteLegendModeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}
	}
}