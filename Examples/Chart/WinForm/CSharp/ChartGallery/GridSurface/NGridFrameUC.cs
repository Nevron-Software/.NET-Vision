using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.Editors;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGridFrameUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NGridSurfaceSeries m_Surface;
		private Nevron.UI.WinForm.Controls.NCheckBox paletteFrameCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothPaletteCheck;
		private Nevron.UI.WinForm.Controls.NButton lineStyleButton;
		private Nevron.UI.WinForm.Controls.NCheckBox antialiasCheck;
		private System.ComponentModel.Container components = null;

		public NGridFrameUC()
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
			this.paletteFrameCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.smoothPaletteCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.antialiasCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.lineStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// paletteFrameCheck
			// 
			this.paletteFrameCheck.ButtonProperties.BorderOffset = 2;
			this.paletteFrameCheck.Location = new System.Drawing.Point(10, 10);
			this.paletteFrameCheck.Name = "paletteFrameCheck";
			this.paletteFrameCheck.Size = new System.Drawing.Size(157, 20);
			this.paletteFrameCheck.TabIndex = 0;
			this.paletteFrameCheck.Text = "Palette Frame";
			this.paletteFrameCheck.CheckedChanged += new System.EventHandler(this.paletteFrameCheck_CheckedChanged);
			// 
			// smoothPaletteCheck
			// 
			this.smoothPaletteCheck.ButtonProperties.BorderOffset = 2;
			this.smoothPaletteCheck.Enabled = false;
			this.smoothPaletteCheck.Location = new System.Drawing.Point(10, 39);
			this.smoothPaletteCheck.Name = "smoothPaletteCheck";
			this.smoothPaletteCheck.Size = new System.Drawing.Size(157, 20);
			this.smoothPaletteCheck.TabIndex = 1;
			this.smoothPaletteCheck.Text = "Smooth Palette";
			this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.smoothPaletteCheck_CheckedChanged);
			// 
			// antialiasCheck
			// 
			this.antialiasCheck.ButtonProperties.BorderOffset = 2;
			this.antialiasCheck.Location = new System.Drawing.Point(10, 68);
			this.antialiasCheck.Name = "antialiasCheck";
			this.antialiasCheck.Size = new System.Drawing.Size(157, 21);
			this.antialiasCheck.TabIndex = 2;
			this.antialiasCheck.Text = "Antialiasing";
			this.antialiasCheck.CheckedChanged += new System.EventHandler(this.antialiasCheck_CheckedChanged);
			// 
			// lineStyleButton
			// 
			this.lineStyleButton.Location = new System.Drawing.Point(10, 100);
			this.lineStyleButton.Name = "lineStyleButton";
			this.lineStyleButton.Size = new System.Drawing.Size(157, 27);
			this.lineStyleButton.TabIndex = 3;
			this.lineStyleButton.Text = "Line Style...";
			this.lineStyleButton.Click += new System.EventHandler(this.lineStyleButton_Click);
			// 
			// NGridFrameUC
			// 
			this.Controls.Add(this.lineStyleButton);
			this.Controls.Add(this.antialiasCheck);
			this.Controls.Add(this.paletteFrameCheck);
			this.Controls.Add(this.smoothPaletteCheck);
			this.Name = "NGridFrameUC";
			this.Size = new System.Drawing.Size(180, 150);
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Wireframe Surface");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			
			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Width = 60.0f;
			m_Chart.Depth = 60.0f;
			m_Chart.Height = 25.0f;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// setup axes
			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			ordinalScale = (NOrdinalScaleConfigurator)m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			// add the surface series
			m_Surface = (NGridSurfaceSeries)m_Chart.Series.Add(SeriesType.GridSurface);
			m_Surface.Name = "Surface";
			m_Surface.FillMode = SurfaceFillMode.None;
			m_Surface.FrameMode = SurfaceFrameMode.Mesh;
			m_Surface.Data.SetGridSize(30, 30);
			m_Surface.SyncPaletteWithAxisScale = false;
			m_Surface.ValueFormatter.FormatSpecifier = "0.00";

			FillData();

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

			// inti form controls
			smoothPaletteCheck.Checked = true;
			paletteFrameCheck.Checked = true;
			antialiasCheck.Checked = true;
		}

		private void FillData()
		{
			double y, x, z;
			int nCountX = m_Surface.Data.GridSizeX;
			int nCountZ = m_Surface.Data.GridSizeZ;

			const double dIntervalX = 30.0;
			const double dIntervalZ = 30.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for(int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for(int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = (x * x) - (z * z);
					y += 200 * Math.Sin(x / 4.0) * Math.Cos(z / 4.0);

					m_Surface.Data.SetValue(i, j, y);
				}
			}
		}


		private void paletteFrameCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(paletteFrameCheck.Checked)
			{
				m_Surface.FrameColorMode = SurfaceFrameColorMode.Zone;
				m_Surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			}
			else
			{
				m_Surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
				m_Surface.Legend.Mode = SeriesLegendMode.Series;
			}

			nChartControl1.Refresh();

			smoothPaletteCheck.Enabled = paletteFrameCheck.Checked;
		}

		private void smoothPaletteCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(smoothPaletteCheck.Checked)
			{
				m_Surface.SmoothPalette = true;
				m_Surface.PaletteSteps = 7;
				m_Surface.Legend.Format = "<zone_value>";
			}
			else
			{
				m_Surface.SmoothPalette = false;
				m_Surface.PaletteSteps = 8;
				m_Surface.Legend.Format = "<zone_begin> - <zone_end>";
			}

			nChartControl1.Refresh();
		}

		private void antialiasCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Settings.ShapeRenderingMode = antialiasCheck.Checked ? ShapeRenderingMode.AntiAlias : ShapeRenderingMode.None;
			nChartControl1.Refresh();
		}

		private void lineStyleButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Surface.FrameStrokeStyle, out strokeStyleResult))
			{
				m_Surface.FrameStrokeStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
	}
}