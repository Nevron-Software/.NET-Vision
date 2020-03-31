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
	public class NMeshIntersectedUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NMeshSurfaceSeries m_Surface1;
		private NMeshSurfaceSeries m_Surface2;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NHScrollBar transparencyScroll1;
		private Nevron.UI.WinForm.Controls.NCheckBox showFrameCheck1;
		private Nevron.UI.WinForm.Controls.NCheckBox showFrameCheck2;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothPaletteCheck1;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothPaletteCheck2;
		private System.ComponentModel.Container components = null;

		public NMeshIntersectedUC()
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
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.smoothPaletteCheck1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.showFrameCheck1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.transparencyScroll1 = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.smoothPaletteCheck2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.showFrameCheck2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.smoothPaletteCheck1);
			this.groupBox1.Controls.Add(this.showFrameCheck1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.transparencyScroll1);
			this.groupBox1.Location = new System.Drawing.Point(4, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(170, 123);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Surface 1";
			// 
			// smoothPaletteCheck1
			// 
			this.smoothPaletteCheck1.ButtonProperties.BorderOffset = 2;
			this.smoothPaletteCheck1.Checked = true;
			this.smoothPaletteCheck1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.smoothPaletteCheck1.Location = new System.Drawing.Point(7, 44);
			this.smoothPaletteCheck1.Name = "smoothPaletteCheck1";
			this.smoothPaletteCheck1.Size = new System.Drawing.Size(149, 19);
			this.smoothPaletteCheck1.TabIndex = 1;
			this.smoothPaletteCheck1.Text = "Smooth Palette";
			this.smoothPaletteCheck1.CheckedChanged += new System.EventHandler(this.smoothPaletteCheck1_CheckedChanged);
			// 
			// showFrameCheck1
			// 
			this.showFrameCheck1.ButtonProperties.BorderOffset = 2;
			this.showFrameCheck1.Checked = true;
			this.showFrameCheck1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showFrameCheck1.Location = new System.Drawing.Point(7, 20);
			this.showFrameCheck1.Name = "showFrameCheck1";
			this.showFrameCheck1.Size = new System.Drawing.Size(149, 21);
			this.showFrameCheck1.TabIndex = 0;
			this.showFrameCheck1.Text = "Show Frame";
			this.showFrameCheck1.CheckedChanged += new System.EventHandler(this.showFrameCheck1_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(7, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(149, 17);
			this.label4.TabIndex = 2;
			this.label4.Text = "Filling Transparency:";
			// 
			// transparencyScroll1
			// 
			this.transparencyScroll1.LargeChange = 1;
			this.transparencyScroll1.Location = new System.Drawing.Point(7, 92);
			this.transparencyScroll1.MinimumSize = new System.Drawing.Size(32, 16);
			this.transparencyScroll1.Name = "transparencyScroll1";
			this.transparencyScroll1.Size = new System.Drawing.Size(149, 17);
			this.transparencyScroll1.TabIndex = 3;
			this.transparencyScroll1.Value = 50;
			this.transparencyScroll1.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.transparencyScroll1_Scroll);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.smoothPaletteCheck2);
			this.groupBox2.Controls.Add(this.showFrameCheck2);
			this.groupBox2.Location = new System.Drawing.Point(4, 140);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(170, 76);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Surface 2";
			// 
			// smoothPaletteCheck2
			// 
			this.smoothPaletteCheck2.ButtonProperties.BorderOffset = 2;
			this.smoothPaletteCheck2.Checked = true;
			this.smoothPaletteCheck2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.smoothPaletteCheck2.Location = new System.Drawing.Point(7, 42);
			this.smoothPaletteCheck2.Name = "smoothPaletteCheck2";
			this.smoothPaletteCheck2.Size = new System.Drawing.Size(149, 19);
			this.smoothPaletteCheck2.TabIndex = 1;
			this.smoothPaletteCheck2.Text = "Smooth Palette";
			this.smoothPaletteCheck2.CheckedChanged += new System.EventHandler(this.smoothPaletteCheck2_CheckedChanged);
			// 
			// showFrameCheck2
			// 
			this.showFrameCheck2.ButtonProperties.BorderOffset = 2;
			this.showFrameCheck2.Checked = true;
			this.showFrameCheck2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showFrameCheck2.Location = new System.Drawing.Point(7, 19);
			this.showFrameCheck2.Name = "showFrameCheck2";
			this.showFrameCheck2.Size = new System.Drawing.Size(149, 21);
			this.showFrameCheck2.TabIndex = 0;
			this.showFrameCheck2.Text = "Show Frame";
			this.showFrameCheck2.CheckedChanged += new System.EventHandler(this.showFrameCheck2_CheckedChanged);
			// 
			// NMeshIntersectedUC
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NMeshIntersectedUC";
			this.Size = new System.Drawing.Size(180, 271);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
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
			NLabel title = nChartControl1.Labels.AddHeader("Intersected Surfaces");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Width = 60.0f;
			m_Chart.Depth = 60.0f;
			m_Chart.Height = 30.0f;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			NAxis axisY = m_Chart.Axis(StandardAxis.PrimaryY);
			NStandardScaleConfigurator scaleConfiguratorY = (NStandardScaleConfigurator)axisY.ScaleConfigurator;
			scaleConfiguratorY.MinTickDistance = new NLength(10, NGraphicsUnit.Point);

			// setup axes
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.RoundToTickMax = false;
			linearScale.RoundToTickMin = false;

			// setup surface series 1
			m_Surface1 = (NMeshSurfaceSeries)m_Chart.Series.Add(SeriesType.MeshSurface);
			m_Surface1.Name = "Surface 1";
			m_Surface1.FillMode = SurfaceFillMode.Zone;
			m_Surface1.FrameMode = SurfaceFrameMode.MeshContour;
			m_Surface1.FrameColorMode = SurfaceFrameColorMode.Zone;
			m_Surface1.SmoothPalette = true;
			m_Surface1.ShadingMode = ShadingMode.Smooth;
			m_Surface1.FillStyle.SetTransparencyPercent(50);
			m_Surface1.Data.SetGridSize(20, 20);
			m_Surface1.SyncPaletteWithAxisScale = true;
			FillData1();

			// setup surface series 2
			m_Surface2 = (NMeshSurfaceSeries)m_Chart.Series.Add(SeriesType.MeshSurface);
			m_Surface2.Name = "Surface 2";
			m_Surface2.FillMode = SurfaceFillMode.Zone;
			m_Surface2.FrameMode = SurfaceFrameMode.MeshContour;
			m_Surface2.FrameColorMode = SurfaceFrameColorMode.Zone;
			m_Surface2.SmoothPalette = true;
			m_Surface2.ShadingMode = ShadingMode.Smooth;
			m_Surface2.Data.SetGridSize(20, 20);
			m_Surface2.SyncPaletteWithAxisScale = true;
			FillData2();

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);
		}

		private void FillData1()
		{
			double y, x, z;
			int nCountX = (int)m_Surface1.Data.GridSizeX;
			int nCountZ = (int)m_Surface1.Data.GridSizeZ;

			const double dIntervalX = 20.0;
			const double dIntervalZ = 20.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for(int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for(int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = Math.Sqrt((x * x) + (z * z) + 2);
					y -= 0.08 * Math.Sqrt( Math.Abs(Math.Sinh(x)) );

					if(x < 0)
					{
						y += 0.11 * x * x;
					}

					m_Surface1.Data.SetValue(i, j, y, x, z);
				}
			}
		}

		private void FillData2()
		{
			double y, x, z;
			int nCountX = (int)m_Surface2.Data.GridSizeX;
			int nCountZ = (int)m_Surface2.Data.GridSizeZ;

			const double dIntervalX = 20.0;
			const double dIntervalZ = 20.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for(int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for(int i = 0; i < nCountX; i++, x += dIncrementX)	
				{
					if((x > 0) && (x < 10) && (z > -7) && (z < 7))
					{
						y = 15 * Math.Abs(Math.Sin(x / 4) * Math.Cos(z / 4));
					}
					else
					{
						y = 2 * Math.Sin(x / 2) * Math.Cos(z / 2);
					}

					m_Surface2.Data.SetValue(i, j, y, x, z);
				}
			}
		}


		private void showFrameCheck1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			if(showFrameCheck1.Checked)
			{
				m_Surface1.FrameMode = SurfaceFrameMode.MeshContour;
			}
			else
			{
				m_Surface1.FrameMode = SurfaceFrameMode.None;
			}

			nChartControl1.Refresh();
		}

		private void showFrameCheck2_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			if(showFrameCheck2.Checked)
			{
				m_Surface2.FrameMode = SurfaceFrameMode.MeshContour;
			}
			else
			{
				m_Surface2.FrameMode = SurfaceFrameMode.None;
			}

			nChartControl1.Refresh();
		}

		private void smoothPaletteCheck1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Surface1.SmoothPalette = smoothPaletteCheck1.Checked;
			nChartControl1.Refresh();
		}

		private void smoothPaletteCheck2_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Surface2.SmoothPalette = smoothPaletteCheck2.Checked;
			nChartControl1.Refresh();
		}

		private void transparencyScroll1_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			if (nChartControl1 == null)
				return;

			m_Surface1.FillStyle.SetTransparencyPercent(transparencyScroll1.Value);
			nChartControl1.Refresh();
		}
	}
}