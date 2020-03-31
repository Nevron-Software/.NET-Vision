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
	public class NMeshSurfaceUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox4;
		private Nevron.UI.WinForm.Controls.NHScrollBar customValueScroll;
		private Nevron.UI.WinForm.Controls.NComboBox positionModeCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox drawFlatCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothShadingCheck;
		private Nevron.UI.WinForm.Controls.NComboBox fillModeCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothPaletteCheck;
		private Nevron.UI.WinForm.Controls.NComboBox frameColorModeCombo;
		private Nevron.UI.WinForm.Controls.NComboBox frameModeCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.ComponentModel.Container components = null;

		public NMeshSurfaceUC()
		{
			InitializeComponent();

			fillModeCombo.Items.Add("None");
			fillModeCombo.Items.Add("Uniform");
			fillModeCombo.Items.Add("Zone");
			fillModeCombo.Items.Add("Zone Texture");

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
			this.nGroupBox4 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.customValueScroll = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.positionModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.drawFlatCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.smoothShadingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.fillModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.smoothPaletteCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.frameColorModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.frameModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox4.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.nGroupBox3.SuspendLayout();
			this.nGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// nGroupBox4
			// 
			this.nGroupBox4.Controls.Add(this.label3);
			this.nGroupBox4.Controls.Add(this.customValueScroll);
			this.nGroupBox4.Controls.Add(this.label1);
			this.nGroupBox4.Controls.Add(this.positionModeCombo);
			this.nGroupBox4.Controls.Add(this.drawFlatCheck);
			this.nGroupBox4.ImageIndex = 0;
			this.nGroupBox4.Location = new System.Drawing.Point(3, 336);
			this.nGroupBox4.Name = "nGroupBox4";
			this.nGroupBox4.Size = new System.Drawing.Size(174, 136);
			this.nGroupBox4.TabIndex = 3;
			this.nGroupBox4.TabStop = false;
			this.nGroupBox4.Text = "Flat Mode";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "Custom Value:";
			// 
			// customValueScroll
			// 
			this.customValueScroll.Enabled = false;
			this.customValueScroll.LargeChange = 1;
			this.customValueScroll.Location = new System.Drawing.Point(11, 109);
			this.customValueScroll.Maximum = 20;
			this.customValueScroll.MinimumSize = new System.Drawing.Size(32, 16);
			this.customValueScroll.Name = "customValueScroll";
			this.customValueScroll.Size = new System.Drawing.Size(151, 17);
			this.customValueScroll.TabIndex = 4;
			this.customValueScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.CustomValueScroll_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Position Mode:";
			// 
			// positionModeCombo
			// 
			this.positionModeCombo.Enabled = false;
			this.positionModeCombo.ListProperties.CheckBoxDataMember = "";
			this.positionModeCombo.ListProperties.DataSource = null;
			this.positionModeCombo.ListProperties.DisplayMember = "";
			this.positionModeCombo.Location = new System.Drawing.Point(11, 61);
			this.positionModeCombo.Name = "positionModeCombo";
			this.positionModeCombo.Size = new System.Drawing.Size(151, 21);
			this.positionModeCombo.TabIndex = 2;
			this.positionModeCombo.SelectedIndexChanged += new System.EventHandler(this.PositionModeCombo_SelectedIndexChanged);
			// 
			// drawFlatCheck
			// 
			this.drawFlatCheck.ButtonProperties.BorderOffset = 2;
			this.drawFlatCheck.Location = new System.Drawing.Point(11, 21);
			this.drawFlatCheck.Name = "drawFlatCheck";
			this.drawFlatCheck.Size = new System.Drawing.Size(129, 20);
			this.drawFlatCheck.TabIndex = 0;
			this.drawFlatCheck.Text = "Draw Flat";
			this.drawFlatCheck.CheckedChanged += new System.EventHandler(this.DrawFlatCheck_CheckedChanged);
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.smoothShadingCheck);
			this.nGroupBox2.Controls.Add(this.label4);
			this.nGroupBox2.Controls.Add(this.fillModeCombo);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(3, 8);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(174, 96);
			this.nGroupBox2.TabIndex = 0;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Surface Filling";
			// 
			// smoothShadingCheck
			// 
			this.smoothShadingCheck.ButtonProperties.BorderOffset = 2;
			this.smoothShadingCheck.Location = new System.Drawing.Point(11, 69);
			this.smoothShadingCheck.Name = "smoothShadingCheck";
			this.smoothShadingCheck.Size = new System.Drawing.Size(135, 20);
			this.smoothShadingCheck.TabIndex = 2;
			this.smoothShadingCheck.Text = "Smooth Shading";
			this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(11, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(135, 14);
			this.label4.TabIndex = 0;
			this.label4.Text = "Fill Mode:";
			// 
			// fillModeCombo
			// 
			this.fillModeCombo.ListProperties.CheckBoxDataMember = "";
			this.fillModeCombo.ListProperties.DataSource = null;
			this.fillModeCombo.ListProperties.DisplayMember = "";
			this.fillModeCombo.Location = new System.Drawing.Point(11, 37);
			this.fillModeCombo.Name = "fillModeCombo";
			this.fillModeCombo.Size = new System.Drawing.Size(151, 21);
			this.fillModeCombo.TabIndex = 1;
			this.fillModeCombo.SelectedIndexChanged += new System.EventHandler(this.FillModeCombo_SelectedIndexChanged);
			// 
			// nGroupBox3
			// 
			this.nGroupBox3.Controls.Add(this.smoothPaletteCheck);
			this.nGroupBox3.ImageIndex = 0;
			this.nGroupBox3.Location = new System.Drawing.Point(3, 256);
			this.nGroupBox3.Name = "nGroupBox3";
			this.nGroupBox3.Size = new System.Drawing.Size(174, 64);
			this.nGroupBox3.TabIndex = 2;
			this.nGroupBox3.TabStop = false;
			this.nGroupBox3.Text = "Palette";
			// 
			// smoothPaletteCheck
			// 
			this.smoothPaletteCheck.ButtonProperties.BorderOffset = 2;
			this.smoothPaletteCheck.Location = new System.Drawing.Point(11, 29);
			this.smoothPaletteCheck.Name = "smoothPaletteCheck";
			this.smoothPaletteCheck.Size = new System.Drawing.Size(119, 21);
			this.smoothPaletteCheck.TabIndex = 0;
			this.smoothPaletteCheck.Text = "Smooth Palette";
			this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.label5);
			this.nGroupBox1.Controls.Add(this.frameColorModeCombo);
			this.nGroupBox1.Controls.Add(this.label2);
			this.nGroupBox1.Controls.Add(this.frameModeCombo);
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(3, 120);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(174, 120);
			this.nGroupBox1.TabIndex = 1;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Surface Frame";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(11, 69);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(150, 14);
			this.label5.TabIndex = 2;
			this.label5.Text = "Frame Color Mode:";
			// 
			// frameColorModeCombo
			// 
			this.frameColorModeCombo.ListProperties.CheckBoxDataMember = "";
			this.frameColorModeCombo.ListProperties.DataSource = null;
			this.frameColorModeCombo.ListProperties.DisplayMember = "";
			this.frameColorModeCombo.Location = new System.Drawing.Point(11, 85);
			this.frameColorModeCombo.Name = "frameColorModeCombo";
			this.frameColorModeCombo.Size = new System.Drawing.Size(150, 21);
			this.frameColorModeCombo.TabIndex = 3;
			this.frameColorModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameColorModeCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(150, 14);
			this.label2.TabIndex = 0;
			this.label2.Text = "Frame Mode:";
			// 
			// frameModeCombo
			// 
			this.frameModeCombo.ListProperties.CheckBoxDataMember = "";
			this.frameModeCombo.ListProperties.DataSource = null;
			this.frameModeCombo.ListProperties.DisplayMember = "";
			this.frameModeCombo.Location = new System.Drawing.Point(11, 37);
			this.frameModeCombo.Name = "frameModeCombo";
			this.frameModeCombo.Size = new System.Drawing.Size(150, 21);
			this.frameModeCombo.TabIndex = 1;
			this.frameModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameModeCombo_SelectedIndexChanged);
			// 
			// NMeshSurfaceUC
			// 
			this.Controls.Add(this.nGroupBox4);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.nGroupBox3);
			this.Controls.Add(this.nGroupBox1);
			this.Name = "NMeshSurfaceUC";
			this.Size = new System.Drawing.Size(180, 487);
			this.nGroupBox4.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.nGroupBox3.ResumeLayout(false);
			this.nGroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Add(new NSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 25.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

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
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series.Add(SeriesType.MeshSurface);
			surface.Name = "Surface";
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.FillMode = SurfaceFillMode.Zone;
			surface.PositionValue = 0.5;
			surface.Data.SetGridSize(20, 20);
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
		}

		private void FillData(NMeshSurfaceSeries surface)
		{
			double x, y, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			for(int j = 0; j < nCountZ; j++)
			{
				for(int i = 0; i < nCountX; i++)
				{
					x = 2 + i + Math.Sin(j / 4.0) * 2;
					z = 1 + j + Math.Cos(i / 4.0);

					y = Math.Sin(i / 3.0) * Math.Sin(j / 3.0);

					if(y < 0)
					{
						y = Math.Abs( y / 2.0 );
					}

					surface.Data.SetValue(i, j, y, x, z);
				}
			}
		}

		private void SmoothShadingCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			if(smoothShadingCheck.Checked)
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
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			switch(fillModeCombo.SelectedIndex)
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

				case 3:
					surface.FillMode = SurfaceFillMode.ZoneTexture;
					smoothShadingCheck.Enabled = true;
					break;
			}

			nChartControl1.Refresh();
		}
		private void FrameModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			surface.FrameMode = (SurfaceFrameMode)frameModeCombo.SelectedIndex;
			nChartControl1.Refresh();

			// form controls
			frameColorModeCombo.Enabled = (surface.FrameMode != SurfaceFrameMode.None);
		}
		private void FrameColorModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			switch(frameColorModeCombo.SelectedIndex)
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
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

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

			nChartControl1.Refresh();
		}
		private void DrawFlatCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			surface.DrawFlat = drawFlatCheck.Checked;
			nChartControl1.Refresh();

			// form controls
			positionModeCombo.Enabled = drawFlatCheck.Checked;
			customValueScroll.Enabled = drawFlatCheck.Checked;
		}
		private void PositionModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			surface.PositionMode = (SurfacePositionMode)positionModeCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void CustomValueScroll_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			surface.PositionValue = customValueScroll.Value / 20.0f;
			nChartControl1.Refresh();
		}
	}
}