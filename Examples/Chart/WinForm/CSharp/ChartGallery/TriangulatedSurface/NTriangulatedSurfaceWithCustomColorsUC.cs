using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using Nevron.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NTriangulatedSurfaceWithCustomColorsUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private System.Windows.Forms.Label label4;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothShadingCheck;
		private Nevron.UI.WinForm.Controls.NComboBox fillModeCombo;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox frameColorModeCombo;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox frameModeCombo;
		private System.ComponentModel.Container components = null;

		public NTriangulatedSurfaceWithCustomColorsUC()
		{
			InitializeComponent();

			fillModeCombo.Items.Add("None");
			fillModeCombo.Items.Add("Uniform");
			fillModeCombo.Items.Add("Custom Colors");

			frameModeCombo.Items.Add("None");
			frameModeCombo.Items.Add("Mesh");
			frameModeCombo.Items.Add("Contour");
			frameModeCombo.Items.Add("Mesh-Contour");
			frameModeCombo.Items.Add("Dots");

			frameColorModeCombo.Items.Add("Uniform");
			frameColorModeCombo.Items.Add("Custom Colors");
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
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.smoothShadingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.fillModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.frameColorModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.frameModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox2.SuspendLayout();
			this.nGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.smoothShadingCheck);
			this.nGroupBox2.Controls.Add(this.label4);
			this.nGroupBox2.Controls.Add(this.fillModeCombo);
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(4, 3);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(176, 96);
			this.nGroupBox2.TabIndex = 0;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Surface Filling";
			// 
			// smoothShadingCheck
			// 
			this.smoothShadingCheck.ButtonProperties.BorderOffset = 2;
			this.smoothShadingCheck.Location = new System.Drawing.Point(15, 72);
			this.smoothShadingCheck.Name = "smoothShadingCheck";
			this.smoothShadingCheck.Size = new System.Drawing.Size(116, 20);
			this.smoothShadingCheck.TabIndex = 2;
			this.smoothShadingCheck.Text = "Smooth Shading";
			this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(15, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(116, 14);
			this.label4.TabIndex = 0;
			this.label4.Text = "Fill Mode:";
			// 
			// fillModeCombo
			// 
			this.fillModeCombo.ListProperties.CheckBoxDataMember = "";
			this.fillModeCombo.ListProperties.DataSource = null;
			this.fillModeCombo.ListProperties.DisplayMember = "";
			this.fillModeCombo.Location = new System.Drawing.Point(15, 40);
			this.fillModeCombo.Name = "fillModeCombo";
			this.fillModeCombo.Size = new System.Drawing.Size(132, 21);
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
			this.nGroupBox1.Location = new System.Drawing.Point(4, 115);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(177, 120);
			this.nGroupBox1.TabIndex = 1;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Surface Frame";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(15, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(131, 14);
			this.label5.TabIndex = 2;
			this.label5.Text = "Frame Color Mode:";
			// 
			// frameColorModeCombo
			// 
			this.frameColorModeCombo.ListProperties.CheckBoxDataMember = "";
			this.frameColorModeCombo.ListProperties.DataSource = null;
			this.frameColorModeCombo.ListProperties.DisplayMember = "";
			this.frameColorModeCombo.Location = new System.Drawing.Point(15, 88);
			this.frameColorModeCombo.Name = "frameColorModeCombo";
			this.frameColorModeCombo.Size = new System.Drawing.Size(131, 21);
			this.frameColorModeCombo.TabIndex = 3;
			this.frameColorModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameColorModeCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(131, 14);
			this.label2.TabIndex = 0;
			this.label2.Text = "Frame Mode:";
			// 
			// frameModeCombo
			// 
			this.frameModeCombo.ListProperties.CheckBoxDataMember = "";
			this.frameModeCombo.ListProperties.DataSource = null;
			this.frameModeCombo.ListProperties.DisplayMember = "";
			this.frameModeCombo.Location = new System.Drawing.Point(15, 40);
			this.frameModeCombo.Name = "frameModeCombo";
			this.frameModeCombo.Size = new System.Drawing.Size(131, 21);
			this.frameModeCombo.TabIndex = 1;
			this.frameModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameModeCombo_SelectedIndexChanged);
			// 
			// NTriangulatedSurfaceWithCustomColorsUC
			// 
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.nGroupBox2);
			this.Name = "NTriangulatedSurfaceWithCustomColorsUC";
			this.Size = new System.Drawing.Size(180, 264);
			this.nGroupBox2.ResumeLayout(false);
			this.nGroupBox1.ResumeLayout(false);
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
			NLabel title = nChartControl1.Labels.AddHeader("Triangulated Surface with Custom Colors");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// remove legends
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 10.0f;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.Projection.Elevation = 45;
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

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
			surface.Name = "Surface";
			surface.SyncPaletteWithAxisScale = false;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);
			surface.PaletteSteps = 8;

			surface.FillMode = SurfaceFillMode.CustomColors;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.FrameColorMode = SurfaceFrameColorMode.CustomColors;
			surface.ShadingMode = ShadingMode.Smooth;

			FillData();

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// form controls
			smoothShadingCheck.Checked = true;
			fillModeCombo.SelectedIndex = 2;
			frameModeCombo.SelectedIndex = 0;
			frameColorModeCombo.SelectedIndex = 0;
		}

		private void FillData()
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			Stream stream = null;
			BinaryReader reader = null;

			try
			{
				// fill the XYZ data from a binary resource
				stream = NResourceHelper.GetResourceStream(GetType().Assembly, "DataXYZ.bin", "Nevron.Examples.Chart.WinForm.Resources");
				reader = new BinaryReader(stream);

				int nDataPointsCount = (int)stream.Length / 12;

				NTriangulatedSurfaceData surfaceData = surface.Data;
				surfaceData.SetCount(nDataPointsCount);

				surfaceData.UseColors = true;

				// fill Y values and colors
				for (int i = 0; i < nDataPointsCount; i++)
				{
					float y = 300 - reader.ReadSingle();

					surfaceData.SetYValue(i, y);
					surfaceData.SetColor(i, GetColorFromValue(y));
				}

				// fill X values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					surfaceData.SetXValue(i, reader.ReadSingle());
				}

				// fill Z values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					surfaceData.SetZValue(i, reader.ReadSingle());
				}
			}
			finally
			{
				if(reader != null)
					reader.Close();

				if(stream != null)
					stream.Close();
			}
		}
		private Color GetColorFromValue(float y)
		{
			Color color = Color.Black;

			if(y < 100)
			{
				color = Color.FromArgb(20, 30, 180);
			}
			else if(y < 150)
			{
				color = Color.FromArgb(20, 100, 100);
			}
			else if(y < 200)
			{
				color = Color.FromArgb(20, 140, 80);
			}
			else if(y < 250)
			{
				color = Color.FromArgb(80, 140, 60);
			}
			else if(y < 300)
			{
				color = Color.FromArgb(140, 140, 40);
			}

			return Color.FromArgb(
				color.R + (int)(Random.NextDouble() * 50),
				color.G + (int)(Random.NextDouble() * 50),
				color.B + (int)(Random.NextDouble() * 50));
		}

		private void SmoothShadingCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

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
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

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
					surface.FillMode = SurfaceFillMode.CustomColors;
					smoothShadingCheck.Enabled = true;
					break;
			}

			nChartControl1.Refresh();
		}
		private void FrameModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			surface.FrameMode = (SurfaceFrameMode)frameModeCombo.SelectedIndex;
			nChartControl1.Refresh();

			// form controls
			frameColorModeCombo.Enabled = (surface.FrameMode != SurfaceFrameMode.None);
		}
		private void FrameColorModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)chart.Series[0];

			switch(frameColorModeCombo.SelectedIndex)
			{
				case 0:
					surface.FrameColorMode = SurfaceFrameColorMode.Uniform;
					break;

				case 1:
					surface.FrameColorMode = SurfaceFrameColorMode.CustomColors;
					break;
			}

			nChartControl1.Refresh();
		}
	}
}
