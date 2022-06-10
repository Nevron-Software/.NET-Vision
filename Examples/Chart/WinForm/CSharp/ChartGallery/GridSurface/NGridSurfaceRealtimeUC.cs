using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGridSurfaceRealtimeUC : NExampleBaseUC
	{
		private System.Windows.Forms.Timer m_Timer;
		private Nevron.UI.WinForm.Controls.NButton StartStopTimerButton;
		private Nevron.UI.WinForm.Controls.NCheckBox RenderToWindowCheck;
		private System.Windows.Forms.Label label1;
		private UI.WinForm.Controls.NComboBox GridSizeComboBox;
		private UI.WinForm.Controls.NCheckBox EnableShaderRenderingCheckBox;
		private System.ComponentModel.IContainer components = null;

		public NGridSurfaceRealtimeUC()
		{
			InitializeComponent();
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


		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_Timer = new System.Windows.Forms.Timer(this.components);
			this.StartStopTimerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.RenderToWindowCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.GridSizeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.EnableShaderRenderingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// m_Timer
			// 
			this.m_Timer.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// StartStopTimerButton
			// 
			this.StartStopTimerButton.Location = new System.Drawing.Point(6, 123);
			this.StartStopTimerButton.Name = "StartStopTimerButton";
			this.StartStopTimerButton.Size = new System.Drawing.Size(160, 23);
			this.StartStopTimerButton.TabIndex = 1;
			this.StartStopTimerButton.Text = "Stop Timer";
			this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
			// 
			// RenderToWindowCheck
			// 
			this.RenderToWindowCheck.ButtonProperties.BorderOffset = 2;
			this.RenderToWindowCheck.Location = new System.Drawing.Point(6, 46);
			this.RenderToWindowCheck.Name = "RenderToWindowCheck";
			this.RenderToWindowCheck.Size = new System.Drawing.Size(149, 20);
			this.RenderToWindowCheck.TabIndex = 0;
			this.RenderToWindowCheck.Text = "Render to window";
			this.RenderToWindowCheck.CheckedChanged += new System.EventHandler(this.RenderToWindowCheck_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Grid Size:";
			// 
			// GridSizeComboBox
			// 
			this.GridSizeComboBox.ListProperties.CheckBoxDataMember = "";
			this.GridSizeComboBox.ListProperties.DataSource = null;
			this.GridSizeComboBox.ListProperties.DisplayMember = "";
			this.GridSizeComboBox.Location = new System.Drawing.Point(6, 22);
			this.GridSizeComboBox.Name = "GridSizeComboBox";
			this.GridSizeComboBox.Size = new System.Drawing.Size(156, 21);
			this.GridSizeComboBox.TabIndex = 8;
			this.GridSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.GridSizeComboBox_SelectedIndexChanged);
			// 
			// EnableShaderRenderingCheckBox
			// 
			this.EnableShaderRenderingCheckBox.ButtonProperties.BorderOffset = 2;
			this.EnableShaderRenderingCheckBox.Location = new System.Drawing.Point(6, 72);
			this.EnableShaderRenderingCheckBox.Name = "EnableShaderRenderingCheckBox";
			this.EnableShaderRenderingCheckBox.Size = new System.Drawing.Size(149, 20);
			this.EnableShaderRenderingCheckBox.TabIndex = 9;
			this.EnableShaderRenderingCheckBox.Text = "Enable Shader Rendering";
			this.EnableShaderRenderingCheckBox.CheckedChanged += new System.EventHandler(this.EnableGPURenderingCheckBox_CheckedChanged);
			// 
			// NGridSurfaceRealtimeUC
			// 
			this.Controls.Add(this.EnableShaderRenderingCheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.GridSizeComboBox);
			this.Controls.Add(this.RenderToWindowCheck);
			this.Controls.Add(this.StartStopTimerButton);
			this.Name = "NGridSurfaceRealtimeUC";
			this.Size = new System.Drawing.Size(174, 216);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// Enable GPU acceleration
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Realtime Grid Surface");
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
			chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(-3, 3), true, true);

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
			surface.FillStyle = new NColorFillStyle(Color.FromArgb(0, 0, 240));
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.Diagonal1;
			surface.Data.SetGridSize(500, 500);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			RenderToWindowCheck.Checked = true;
			EnableShaderRenderingCheckBox.Checked = true;
			m_Timer.Enabled = true;

			GridSizeComboBox.Items.Add("250x250");
			GridSizeComboBox.Items.Add("500x500");
			GridSizeComboBox.Items.Add("1000x1000");
			GridSizeComboBox.SelectedIndex = 1;
		}

		double phase = 0;
		Random random = new Random();

		private void GenerateWaves()
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			double step = Math.PI * 10 / nCountX;

			unsafe
			{
				fixed (byte* pData = &surface.Data.Data[0])
				{
					float* pValue = (float*)pData + 1;
					int itemSize = surface.Data.DataItemSize;

					double randomAmplitude = Math.Sin(phase) * 2 + random.NextDouble();

					for (int z = 0; z < nCountZ; z++)
					{
						for (int x = 0; x < nCountX; x++)
						{
							float zVal = (float)(randomAmplitude * Math.Sin(phase + x * step) * Math.Cos(phase + z * step));

							*pValue = zVal;

							pValue += itemSize;
						}
					}

					surface.Data.OnDataChanged();
				}
			}

			phase += 3 * step;
			nChartControl1.Refresh();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			GenerateWaves();
			nChartControl1.Refresh();
		}

		private void RenderToWindowCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (RenderToWindowCheck.Checked)
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Window;
				EnableShaderRenderingCheckBox.Enabled = true;
			}
			else
			{
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap;
				EnableShaderRenderingCheckBox.Enabled = false;
			}
		}

		private void StartStopTimerButton_Click(object sender, EventArgs e)
		{
			m_Timer.Enabled = !m_Timer.Enabled;

			if (this.m_Timer.Enabled)
			{
				StartStopTimerButton.Text = "Stop Timer";
			}
			else
			{
				StartStopTimerButton.Text = "Start Timer";
			}
		}

		private void EnableGPURenderingCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			surface.EnableShaderRendering = EnableShaderRenderingCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void GridSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int gridSize = 0;
			switch (GridSizeComboBox.SelectedIndex)
			{
				case 0:
					gridSize = 250;
					break;
				case 1:
					gridSize = 500;
					break;
				case 2:
					gridSize = 1000;
					break;
			}

			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			surface.Data.SetSize(gridSize, gridSize);
			GenerateWaves();
		}
	}
}

