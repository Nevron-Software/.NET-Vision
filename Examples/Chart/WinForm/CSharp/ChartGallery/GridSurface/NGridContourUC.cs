using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGridContourUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox PaletteFrameCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox SmoothPaletteCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowFrameCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowFillingCheck;
        private UI.WinForm.Controls.NCheckBox DrawContourBorderCheckBox;
		private System.ComponentModel.Container components = null;

		public NGridContourUC()
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
            this.PaletteFrameCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SmoothPaletteCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ShowFrameCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ShowFillingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.DrawContourBorderCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // paletteFrameCheck
            // 
            this.PaletteFrameCheck.ButtonProperties.BorderOffset = 2;
            this.PaletteFrameCheck.Location = new System.Drawing.Point(10, 73);
            this.PaletteFrameCheck.Name = "paletteFrameCheck";
            this.PaletteFrameCheck.Size = new System.Drawing.Size(160, 19);
            this.PaletteFrameCheck.TabIndex = 2;
            this.PaletteFrameCheck.Text = "Palette Frame";
            this.PaletteFrameCheck.CheckedChanged += new System.EventHandler(this.paletteFrameCheck_CheckedChanged);
            // 
            // smoothPaletteCheck
            // 
            this.SmoothPaletteCheck.ButtonProperties.BorderOffset = 2;
            this.SmoothPaletteCheck.Location = new System.Drawing.Point(10, 99);
            this.SmoothPaletteCheck.Name = "smoothPaletteCheck";
            this.SmoothPaletteCheck.Size = new System.Drawing.Size(160, 19);
            this.SmoothPaletteCheck.TabIndex = 3;
            this.SmoothPaletteCheck.Text = "Smooth Palette";
            this.SmoothPaletteCheck.CheckedChanged += new System.EventHandler(this.smoothPaletteCheck_CheckedChanged);
            // 
            // showFrameCheck
            // 
            this.ShowFrameCheck.ButtonProperties.BorderOffset = 2;
            this.ShowFrameCheck.Location = new System.Drawing.Point(10, 36);
            this.ShowFrameCheck.Name = "showFrameCheck";
            this.ShowFrameCheck.Size = new System.Drawing.Size(160, 19);
            this.ShowFrameCheck.TabIndex = 1;
            this.ShowFrameCheck.Text = "Show Frame";
            this.ShowFrameCheck.CheckedChanged += new System.EventHandler(this.showFrameCheck_CheckedChanged);
            // 
            // showFillingCheck
            // 
            this.ShowFillingCheck.ButtonProperties.BorderOffset = 2;
            this.ShowFillingCheck.Location = new System.Drawing.Point(10, 10);
            this.ShowFillingCheck.Name = "showFillingCheck";
            this.ShowFillingCheck.Size = new System.Drawing.Size(160, 20);
            this.ShowFillingCheck.TabIndex = 0;
            this.ShowFillingCheck.Text = "Show Filling";
            this.ShowFillingCheck.CheckedChanged += new System.EventHandler(this.showFillingCheck_CheckedChanged);
            // 
            // DrawContourBorderCheckBox
            // 
            this.DrawContourBorderCheckBox.ButtonProperties.BorderOffset = 2;
            this.DrawContourBorderCheckBox.Location = new System.Drawing.Point(10, 139);
            this.DrawContourBorderCheckBox.Name = "DrawContourBorderCheckBox";
            this.DrawContourBorderCheckBox.Size = new System.Drawing.Size(160, 19);
            this.DrawContourBorderCheckBox.TabIndex = 4;
            this.DrawContourBorderCheckBox.Text = "Draw Contour Border";
            this.DrawContourBorderCheckBox.CheckedChanged += new System.EventHandler(this.DrawContourBorderCheckBox_CheckedChanged);
            // 
            // NGridContourUC
            // 
            this.Controls.Add(this.DrawContourBorderCheckBox);
            this.Controls.Add(this.ShowFillingCheck);
            this.Controls.Add(this.ShowFrameCheck);
            this.Controls.Add(this.PaletteFrameCheck);
            this.Controls.Add(this.SmoothPaletteCheck);
            this.Name = "NGridContourUC";
            this.Size = new System.Drawing.Size(180, 231);
            this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// Enable GPU acceleration
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;

			// set a chart title
			NLabel title = new NLabel("Contour Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 70.0f;
			chart.Depth = 70.0f;
			chart.Height = 0.1f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalTop);
			chart.LightModel.EnableLighting = false;

			// hide chart walls
			chart.Wall(ChartWallType.Back).Visible = false;
			chart.Wall(ChartWallType.Left).Visible = false;
			chart.Wall(ChartWallType.Floor).Visible = false;

			// setup Y axis
			chart.Axis(StandardAxis.PrimaryY).Visible = false;

			// setup X axis
			NAxis axisX = chart.Axis(StandardAxis.PrimaryX);
			axisX.Anchor = new NDockAxisAnchor(AxisDockZone.FrontTop);
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.InnerMajorTickStyle.Visible = false;
			scaleX.RoundToTickMin = false;
			scaleX.RoundToTickMax = false;
			axisX.ScaleConfigurator = scaleX;

			// setup Z axis
			NAxis axisZ = chart.Axis(StandardAxis.Depth);
			axisZ.Anchor = new NDockAxisAnchor(AxisDockZone.TopRight);
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.InnerMajorTickStyle.Visible = false;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[0];
			scaleZ.RoundToTickMin = false;
			scaleZ.RoundToTickMax = false;
			axisZ.ScaleConfigurator = scaleZ;

			// add a surface series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Contour";
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.ValueFormatter = new NNumericValueFormatter("0.0");
			surface.FillMode = SurfaceFillMode.Zone;
			surface.FrameMode = SurfaceFrameMode.Contour;
			surface.ShadingMode = ShadingMode.Flat;
			surface.DrawFlat = true;
			surface.Data.SetGridSize(31, 31);

			// setup a custom palette
			surface.AutomaticPalette = false;
			surface.Palette.Clear();

			surface.Palette.Add(0.0, Color.Purple);
			surface.Palette.Add(1.5, Color.MediumSlateBlue);
			surface.Palette.Add(3.0, Color.CornflowerBlue);
			surface.Palette.Add(4.5, Color.LimeGreen);
			surface.Palette.Add(6.0, Color.LightGreen);
			surface.Palette.Add(7.5, Color.Yellow);
			surface.Palette.Add(9.0, Color.Orange);
			surface.Palette.Add(10.5, Color.Red);
			surface.Palette.Add(100, Color.Red);

			// fill the surface with data
			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// setup form controls
			ShowFillingCheck.Checked = true;
			ShowFrameCheck.Checked = true;
			PaletteFrameCheck.Checked = true;
			SmoothPaletteCheck.Checked = true;
            DrawContourBorderCheckBox.Checked = true;
		}

		private void FillData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 10.0;
			const double dIntervalZ = 10.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for(int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for(int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = 10 - Math.Sqrt((x * x) + (z * z) + 2);
					y += 3.0 * Math.Sin(x) * Math.Cos(z);

					surface.Data.SetValue(i, j, y);
				}
			}
		}

		private void paletteFrameCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			if(PaletteFrameCheck.Checked)
			{
				surface.FrameColorMode = SurfaceFrameColorMode.Zone;
			}
			else
			{
				surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
			}

			nChartControl1.Refresh();
		}
		private void smoothPaletteCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			if(SmoothPaletteCheck.Checked)
			{
				surface.SmoothPalette = true;
				surface.Legend.Format = "<zone_value>";
			}
			else
			{
				surface.SmoothPalette = false;
				surface.Legend.Format = "<zone_begin> - <zone_end>";
			}

			nChartControl1.Refresh();
		}
		private void showFillingCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			if(ShowFillingCheck.Checked)
			{
				surface.FillMode = SurfaceFillMode.Zone;
			}
			else
			{
				surface.FillMode = SurfaceFillMode.None;
			}

			nChartControl1.Refresh();
		}
		private void showFrameCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];

			if(ShowFrameCheck.Checked)
			{
				surface.FrameMode = SurfaceFrameMode.Contour;
				PaletteFrameCheck.Enabled = true;
                DrawContourBorderCheckBox.Enabled = true;
			}
			else
			{
				surface.FrameMode = SurfaceFrameMode.None;
				PaletteFrameCheck.Enabled = false;
                DrawContourBorderCheckBox.Enabled = false;
			}

			nChartControl1.Refresh();
		}

        private void DrawContourBorderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NGridSurfaceSeries surface = (NGridSurfaceSeries)nChartControl1.Charts[0].Series[0];
            surface.DrawContourBorder = DrawContourBorderCheckBox.Checked;

            nChartControl1.Refresh();
        }
	}
}