using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NWavesUC : NExampleBaseUC
	{
		private List<Oscillator> m_Oscillators = new List<Oscillator>();
		private System.Windows.Forms.Timer m_Timer;
		private Nevron.UI.WinForm.Controls.NButton AddWaveButton;
		private System.Windows.Forms.Label IndicatorLabel;
		private Nevron.UI.WinForm.Controls.NCheckBox RenderToWindowCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox SemiTransparentCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothShadingCheck;
		private System.ComponentModel.IContainer components = null;

		public class Oscillator
		{
			public int m_nFrame;
			public double m_dCenterX;
			public double m_dCenterZ;

			public double m_dTime;
			public double m_dAmplitude;
		}

		public NWavesUC()
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
			this.components = new System.ComponentModel.Container();
			this.m_Timer = new System.Windows.Forms.Timer(this.components);
			this.AddWaveButton = new Nevron.UI.WinForm.Controls.NButton();
			this.IndicatorLabel = new System.Windows.Forms.Label();
			this.RenderToWindowCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SemiTransparentCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.smoothShadingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.m_Timer.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// AddWaveButton
			// 
			this.AddWaveButton.Location = new System.Drawing.Point(7, 7);
			this.AddWaveButton.Name = "AddWaveButton";
			this.AddWaveButton.Size = new System.Drawing.Size(122, 23);
			this.AddWaveButton.TabIndex = 0;
			this.AddWaveButton.Text = "Add Wave";
			this.AddWaveButton.Click += new System.EventHandler(this.AddWaveButton_Click);
			// 
			// IndicatorLabel
			// 
			this.IndicatorLabel.BackColor = System.Drawing.Color.Green;
			this.IndicatorLabel.Location = new System.Drawing.Point(135, 7);
			this.IndicatorLabel.Name = "IndicatorLabel";
			this.IndicatorLabel.Size = new System.Drawing.Size(23, 23);
			this.IndicatorLabel.TabIndex = 1;
			// 
			// RenderToWindowCheck
			// 
			this.RenderToWindowCheck.ButtonProperties.BorderOffset = 2;
			this.RenderToWindowCheck.Location = new System.Drawing.Point(7, 68);
			this.RenderToWindowCheck.Name = "RenderToWindowCheck";
			this.RenderToWindowCheck.Size = new System.Drawing.Size(149, 20);
			this.RenderToWindowCheck.TabIndex = 3;
			this.RenderToWindowCheck.Text = "Render to window";
			this.RenderToWindowCheck.CheckedChanged += new System.EventHandler(this.RenderToWindowCheck_CheckedChanged);
			// 
			// SemiTransparentCheck
			// 
			this.SemiTransparentCheck.ButtonProperties.BorderOffset = 2;
			this.SemiTransparentCheck.Location = new System.Drawing.Point(7, 96);
			this.SemiTransparentCheck.Name = "SemiTransparentCheck";
			this.SemiTransparentCheck.Size = new System.Drawing.Size(175, 20);
			this.SemiTransparentCheck.TabIndex = 4;
			this.SemiTransparentCheck.Text = "Semi transparent surface";
			this.SemiTransparentCheck.CheckedChanged += new System.EventHandler(this.SemiTransparentCheck_CheckedChanged);
			// 
			// smoothShadingCheck
			// 
			this.smoothShadingCheck.ButtonProperties.BorderOffset = 2;
			this.smoothShadingCheck.Location = new System.Drawing.Point(7, 39);
			this.smoothShadingCheck.Name = "smoothShadingCheck";
			this.smoothShadingCheck.Size = new System.Drawing.Size(152, 20);
			this.smoothShadingCheck.TabIndex = 2;
			this.smoothShadingCheck.Text = "Smooth Shading";
			this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			// 
			// NWavesUC
			// 
			this.Controls.Add(this.smoothShadingCheck);
			this.Controls.Add(this.SemiTransparentCheck);
			this.Controls.Add(this.RenderToWindowCheck);
			this.Controls.Add(this.IndicatorLabel);
			this.Controls.Add(this.AddWaveButton);
			this.Name = "NWavesUC";
			this.Size = new System.Drawing.Size(180, 216);
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
			NLabel title = nChartControl1.Labels.AddHeader("Waves");
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
			chart.Height = 20.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup axes
			chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(-2, 2), true, true);

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
			surface.FillMode = SurfaceFillMode.Uniform;
			surface.FillStyle = new NColorFillStyle(Color.FromArgb(120, 175, 240));
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.Diagonal1;
			surface.Data.SetGridSize(60, 60);

			FillSurfaceWithValue(0);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			smoothShadingCheck.Checked = true;
			IndicatorLabel.BackColor = Color.Green;
		}

		private void FillSurfaceWithValue(double dValue)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			for(int j = 0; j < nCountZ; j++)
			{
				for(int i = 0; i < nCountX; i++)
				{
					surface.Data.SetValue(i, j, 0.0);
				}
			}
		}

		private void GenerateWaves()
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 30.0;
			const double dIntervalZ = 30.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for(int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x =  -(dIntervalX / 2);

				for(int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = CalulateWavesAtPoint(x, z);

					surface.Data.SetValue(i, j, y);
				}
			}
		}

		private void GenerateAmplitudes()
		{
			for(int i = m_Oscillators.Count - 1; i >= 0; i--)
			{
				Oscillator osc = m_Oscillators[i];

				osc.m_dTime = osc.m_nFrame * 0.5;
				osc.m_nFrame++;

				osc.m_dAmplitude = osc.m_dTime * 0.5;

				if(osc.m_dAmplitude >= 1)
				{
					osc.m_dAmplitude = 1 * Math.Exp(- osc.m_dTime * 0.08);

					if(osc.m_dAmplitude <= 0.001)
					{
						m_Oscillators.RemoveAt(i);
					}
				}
			}
		}

		private double CalulateWavesAtPoint(double x, double z)
		{
			double dValue = 0;

			for(int i = 0; i < m_Oscillators.Count; i++)
			{
				Oscillator osc = m_Oscillators[i];

				double distX = x - osc.m_dCenterX;
				double distZ = z - osc.m_dCenterZ;
				double dist = Math.Sqrt(distX * distX + distZ * distZ);

				dValue += osc.m_dAmplitude * Math.Sin(dist - osc.m_dTime) * Math.Exp(-dist * 0.05);
			}

			return dValue;
		}

		private void AddWaveButton_Click(object sender, System.EventArgs e)
		{
			if (m_Timer.Enabled == false)
			{
				Debug.Assert(m_Oscillators.Count == 0);
				m_Timer.Interval = 50;
				m_Timer.Start();
				IndicatorLabel.BackColor = Color.Red;
			}

			Oscillator osc = new Oscillator();
			osc.m_nFrame = 0;
			osc.m_dCenterX = 10.0 - Random.NextDouble() * 20;
			osc.m_dCenterZ = 10.0 - Random.NextDouble() * 20;

			m_Oscillators.Add(osc);
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			GenerateAmplitudes();

			if(m_Oscillators.Count == 0)
			{
				m_Timer.Stop();
				IndicatorLabel.BackColor = Color.Green;
			}
			else
			{
				GenerateWaves();
				nChartControl1.Refresh();
			}
		}

		private void RenderToWindowCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(RenderToWindowCheck.Checked)
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			}
			else
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
			}
		}

		private void SemiTransparentCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			float fPercent = SemiTransparentCheck.Checked ? 20 : 0;

			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];
			surface.FillStyle.SetTransparencyPercent(fPercent);

			if (m_Timer.Enabled == false)
			{
				nChartControl1.Refresh();
			}
		}

		private void SmoothShadingCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

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
	}
}

