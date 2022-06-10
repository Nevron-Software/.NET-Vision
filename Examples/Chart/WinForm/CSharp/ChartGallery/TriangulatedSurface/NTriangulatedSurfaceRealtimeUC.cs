using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NTriangulatedSurfaceRealtimeUC : NExampleBaseUC
	{
		private IContainer components;
		private System.Windows.Forms.Timer timer1;
		private UI.WinForm.Controls.NComboBox GridSizeComboBox;
		private System.Windows.Forms.Label label1;
		NTriangulatedSurfaceSeries m_Surface;
		private UI.WinForm.Controls.NButton StartStopTimerButton;
		private System.Windows.Forms.Label label2;
		private UI.WinForm.Controls.NComboBox FrameModeCombo;
		private System.Windows.Forms.Label label3;
		private UI.WinForm.Controls.NComboBox FillModeComboBox;
		private UI.WinForm.Controls.NCheckBox EnableShaderRenderingCheckBox;
		int m_GridSize;

		public NTriangulatedSurfaceRealtimeUC()
		{
			InitializeComponent();

			m_Random = new Random();
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
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.GridSizeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.StartStopTimerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label2 = new System.Windows.Forms.Label();
			this.FrameModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.FillModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.EnableShaderRenderingCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// GridSizeComboBox
			// 
			this.GridSizeComboBox.ListProperties.CheckBoxDataMember = "";
			this.GridSizeComboBox.ListProperties.DataSource = null;
			this.GridSizeComboBox.ListProperties.DisplayMember = "";
			this.GridSizeComboBox.Location = new System.Drawing.Point(19, 29);
			this.GridSizeComboBox.Name = "GridSizeComboBox";
			this.GridSizeComboBox.Size = new System.Drawing.Size(144, 21);
			this.GridSizeComboBox.TabIndex = 2;
			this.GridSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.gridSizeComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Grid size:";
			// 
			// StartStopTimerButton
			// 
			this.StartStopTimerButton.Location = new System.Drawing.Point(19, 257);
			this.StartStopTimerButton.Name = "StartStopTimerButton";
			this.StartStopTimerButton.Size = new System.Drawing.Size(144, 23);
			this.StartStopTimerButton.TabIndex = 5;
			this.StartStopTimerButton.Text = "Stop Timer";
			this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(19, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(131, 14);
			this.label2.TabIndex = 6;
			this.label2.Text = "Frame Mode:";
			// 
			// FrameModeCombo
			// 
			this.FrameModeCombo.ListProperties.CheckBoxDataMember = "";
			this.FrameModeCombo.ListProperties.DataSource = null;
			this.FrameModeCombo.ListProperties.DisplayMember = "";
			this.FrameModeCombo.Location = new System.Drawing.Point(19, 136);
			this.FrameModeCombo.Name = "FrameModeCombo";
			this.FrameModeCombo.Size = new System.Drawing.Size(144, 21);
			this.FrameModeCombo.TabIndex = 7;
			this.FrameModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameModeCombo_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(19, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(131, 14);
			this.label3.TabIndex = 8;
			this.label3.Text = "Fill Mode:";
			// 
			// FillModeComboBox
			// 
			this.FillModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.FillModeComboBox.ListProperties.DataSource = null;
			this.FillModeComboBox.ListProperties.DisplayMember = "";
			this.FillModeComboBox.Location = new System.Drawing.Point(19, 96);
			this.FillModeComboBox.Name = "FillModeComboBox";
			this.FillModeComboBox.Size = new System.Drawing.Size(144, 21);
			this.FillModeComboBox.TabIndex = 9;
			this.FillModeComboBox.SelectedIndexChanged += new System.EventHandler(this.FillModeComboBox_SelectedIndexChanged);
			// 
			// EnableShaderRenderingCheckBox
			// 
			this.EnableShaderRenderingCheckBox.ButtonProperties.BorderOffset = 2;
			this.EnableShaderRenderingCheckBox.Location = new System.Drawing.Point(19, 193);
			this.EnableShaderRenderingCheckBox.Name = "EnableShaderRenderingCheckBox";
			this.EnableShaderRenderingCheckBox.Size = new System.Drawing.Size(140, 20);
			this.EnableShaderRenderingCheckBox.TabIndex = 10;
			this.EnableShaderRenderingCheckBox.Text = "Enable Shader Rendering";
			this.EnableShaderRenderingCheckBox.CheckedChanged += new System.EventHandler(this.EnableShaderRenderingCheckBox_CheckedChanged);
			// 
			// NTriangulatedSurfaceRealtimeUC
			// 
			this.Controls.Add(this.EnableShaderRenderingCheckBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.FillModeComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.FrameModeCombo);
			this.Controls.Add(this.StartStopTimerButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.GridSizeComboBox);
			this.Name = "NTriangulatedSurfaceRealtimeUC";
			this.Size = new System.Drawing.Size(180, 349);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// Enable GPU acceleration
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Realtime Triangulation");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// remove legends
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 50;
			chart.Depth = 50;
			chart.Height = 30;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalTop);

			for (int i = 0; i < chart.Walls.Count; i++)
			{
				((NChartWall)chart.Walls[i]).Visible = false;
			}			

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.RoundToTickMax = false;
			scaleY.RoundToTickMin = false;
			scaleY.MinTickDistance = new NLength(10, NGraphicsUnit.Point);
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Left, ChartWallType.Back };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMax = false;
			scaleX.RoundToTickMin = false;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.RoundToTickMax = false;
			scaleZ.RoundToTickMin = false;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[]{ ChartWallType.Floor, ChartWallType.Left };
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;

			// add the surface series
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series.Add(SeriesType.TriangulatedSurface);
			m_Surface = surface;
			surface.Name = "Surface";
			surface.SyncPaletteWithAxisScale = false;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);
			surface.PaletteSteps = 8;

			surface.FillMode = SurfaceFillMode.Zone;
			surface.FrameMode = SurfaceFrameMode.Mesh;
			surface.ShadingMode = ShadingMode.Flat;

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			EnableShaderRenderingCheckBox.Checked = true;

			FillModeComboBox.FillFromEnum(typeof(SurfaceFillMode));
			FillModeComboBox.SelectedIndex = (int)SurfaceFillMode.ZoneTexture;;

			FrameModeCombo.FillFromEnum(typeof(SurfaceFrameMode));
			FrameModeCombo.SelectedIndex = (int)SurfaceFrameMode.Mesh;

			GridSizeComboBox.Items.Add("10x10");
			GridSizeComboBox.Items.Add("100x100");
			GridSizeComboBox.Items.Add("200x200");
			GridSizeComboBox.Items.Add("500x500");
			GridSizeComboBox.SelectedIndex = 0;

			timer1.Start();
		}

		Random m_Random;
		double[,] m_Phase;
		double[,] m_Radius;

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (m_GridSize == 0)
				return;

			const double phaseStep = Math.PI / 10;

			unsafe
			{
				fixed (byte* pData = &m_Surface.Data.Data[0])
				{
					float* pValues = (float*)pData;
					int itemSize = m_Surface.Data.DataItemSize;
					int count = m_Surface.Data.Count;

					for (int x = 0; x < m_GridSize; x++)
					{
						for (int y = 0; y < m_GridSize; y++)
						{
							// The order of the values is x, y, z. In this case we dynamically modify only x and z.
							pValues[0] = (float)(x + Math.Cos(m_Phase[x, y]) * m_Radius[x, y]);
							pValues[2] = (float)(y + Math.Sin(m_Phase[x, y]) * m_Radius[x, y]);

							m_Phase[x, y] += phaseStep;

							pValues += itemSize;
						}
					}

					m_Surface.Data.OnDataChanged();
				}
			}

			nChartControl1.Refresh();
		}

		private void gridSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_GridSize = 100;

			switch (GridSizeComboBox.SelectedIndex)
			{
				case 0:
					m_GridSize = 10;
					break;
				case 1:
					m_GridSize = 100;
					break;
				case 2:
					m_GridSize = 200;
					break;
				case 3:
					m_GridSize = 500;
					break;
			}

			NTriangulatedSurfaceData data = m_Surface.Data;
			data.Clear();

			const float dIntervalX = 1.0f;
			const float dIntervalZ = 1.0f;

			float dIncrementX = (dIntervalX / m_GridSize);
			float dIncrementZ = (dIntervalZ / m_GridSize);

			m_Radius = new double[m_GridSize, m_GridSize];
			m_Phase = new double[m_GridSize, m_GridSize];

			Random random = new Random();

			float gridPhase = (float)(Math.PI * 5 / m_GridSize);

			for (int x = 0; x < m_GridSize; x++)
			{
				float zVar= -(dIntervalZ / 2) + x * dIncrementZ;

				for (int y = 0; y < m_GridSize; y++)
				{
					float xVar = -(dIncrementX / 2) + y * dIncrementX;

					m_Radius[x, y] = random.NextDouble();
					m_Phase[x, y] = random.NextDouble() * Math.PI * 2;

					float yPos = (float)(Math.Sin(y * gridPhase) + Math.Cos(x * gridPhase));
					float xPos = (float)(x + Math.Cos(m_Phase[x, y]) * m_Radius[x, y]);
					float zPos = (float)(y + Math.Sin(m_Phase[x, y]) * m_Radius[x, y]);

					data.AddValue(new NVector3DF(xPos, yPos, yPos));
				}
			}
		}

		private void StartStopTimerButton_Click(object sender, EventArgs e)
		{
			timer1.Enabled = !timer1.Enabled;

			if (timer1.Enabled)
			{
				StartStopTimerButton.Text = "Stop Timer";
			}
			else
			{
				StartStopTimerButton.Text = "Start Timer";
			}
		}

		private void FillModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.FillMode = (SurfaceFillMode)FillModeComboBox.SelectedIndex;

			nChartControl1.Refresh();
		}

		private void FrameModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.FrameMode = (SurfaceFrameMode)FrameModeCombo.SelectedIndex;

			if (surface.FrameMode == SurfaceFrameMode.Dots)
			{
				surface.FrameStrokeStyle.Width = new NLength(2);
			}
			else
			{
				surface.FrameStrokeStyle.Width = new NLength(0.75f);
			}

			nChartControl1.Refresh();
		}

		private void EnableShaderRenderingCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.EnableShaderRendering = EnableShaderRenderingCheckBox.Checked;

			nChartControl1.Refresh();
		}
	}
}
