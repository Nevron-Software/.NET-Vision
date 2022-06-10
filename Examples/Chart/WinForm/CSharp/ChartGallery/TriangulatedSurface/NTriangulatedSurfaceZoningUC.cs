using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Nevron.UI;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NTriangulatedSurfaceZoningUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox smoothPaletteCheck;
		private Nevron.UI.WinForm.Controls.NComboBox paletteStepsCombo;
		private Nevron.UI.WinForm.Controls.NComboBox paletteModeCombo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.Container components = null;

		public NTriangulatedSurfaceZoningUC()
		{
			InitializeComponent();

			paletteModeCombo.Items.Add("Use Fixed Number of Zones");
			paletteModeCombo.Items.Add("Synchronize Palette Zones with Y Axis");
			paletteModeCombo.Items.Add("Use Custom Palette");

			paletteStepsCombo.Items.Add("2");
			paletteStepsCombo.Items.Add("3");
			paletteStepsCombo.Items.Add("4");
			paletteStepsCombo.Items.Add("5");
			paletteStepsCombo.Items.Add("6");
			paletteStepsCombo.Items.Add("7");
			paletteStepsCombo.Items.Add("8");
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
			this.smoothPaletteCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.paletteStepsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.paletteModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// smoothPaletteCheck
			// 
			this.smoothPaletteCheck.ButtonProperties.BorderOffset = 2;
			this.smoothPaletteCheck.Location = new System.Drawing.Point(3, 135);
			this.smoothPaletteCheck.Name = "smoothPaletteCheck";
			this.smoothPaletteCheck.Size = new System.Drawing.Size(174, 21);
			this.smoothPaletteCheck.TabIndex = 4;
			this.smoothPaletteCheck.Text = "Smooth Palette";
			this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			// 
			// paletteStepsCombo
			// 
			this.paletteStepsCombo.ListProperties.CheckBoxDataMember = "";
			this.paletteStepsCombo.ListProperties.DataSource = null;
			this.paletteStepsCombo.ListProperties.DisplayMember = "";
			this.paletteStepsCombo.Location = new System.Drawing.Point(3, 89);
			this.paletteStepsCombo.Name = "paletteStepsCombo";
			this.paletteStepsCombo.Size = new System.Drawing.Size(174, 21);
			this.paletteStepsCombo.TabIndex = 3;
			this.paletteStepsCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteStepsCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(174, 14);
			this.label2.TabIndex = 2;
			this.label2.Text = "Palette Steps:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(3, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(174, 14);
			this.label4.TabIndex = 0;
			this.label4.Text = "Palette Mode:";
			// 
			// paletteModeCombo
			// 
			this.paletteModeCombo.ListProperties.CheckBoxDataMember = "";
			this.paletteModeCombo.ListProperties.DataSource = null;
			this.paletteModeCombo.ListProperties.DisplayMember = "";
			this.paletteModeCombo.Location = new System.Drawing.Point(3, 32);
			this.paletteModeCombo.Name = "paletteModeCombo";
			this.paletteModeCombo.Size = new System.Drawing.Size(174, 21);
			this.paletteModeCombo.TabIndex = 1;
			this.paletteModeCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteModeCombo_SelectedIndexChanged);
			// 
			// NTriangulatedSurfaceZoningUC
			// 
			this.Controls.Add(this.smoothPaletteCheck);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.paletteModeCombo);
			this.Controls.Add(this.paletteStepsCombo);
			this.Name = "NTriangulatedSurfaceZoningUC";
			this.Size = new System.Drawing.Size(180, 300);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// Enable GPU acceleration
			nChartControl1.Settings.RenderSurface = RenderSurface.Window;

			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Triangulated Surface Zoning");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.BoundsMode = BoundsMode.Fit;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 10.0f;
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
			NTriangulatedSurfaceSeries surface = new NTriangulatedSurfaceSeries();
			chart.Series.Add(surface);
			surface.ShadingMode = ShadingMode.Smooth;
			surface.FillMode = SurfaceFillMode.ZoneTexture;
			surface.FrameMode = SurfaceFrameMode.None;

			// define a custom palette
			surface.Palette.Clear();
			surface.Palette.Add(0, DarkOrange);
			surface.Palette.Add(60, LightOrange);
			surface.Palette.Add(100, LightGreen);
			surface.Palette.Add(140, Turqoise);
			surface.Palette.Add(180, Blue);
			surface.Palette.Add(220, Purple);
			surface.Palette.Add(250, BeautifulRed);

			FillSurfaceData();

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// form controls
			paletteModeCombo.SelectedIndex = 0;
			paletteStepsCombo.SelectedIndex = 6;
			smoothPaletteCheck.Checked = false;
		}
		private void FillSurfaceData()
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

				//surface.Data.SetCapacity(nDataPointsCount);
				NVector3DF[] data = new NVector3DF[nDataPointsCount];

				// fill Y values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					data[i].Y = reader.ReadSingle();
				}

				// fill X values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					data[i].X = reader.ReadSingle();
				}

				// fill Z values
				for (int i = 0; i < nDataPointsCount; i++)
				{
					data[i].Z = reader.ReadSingle();
				}

				for (int i = 0; i < nDataPointsCount; i++)
				{
					surface.Data.AddValue(data[i]);
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
		private void UpdateSurface()
		{
			NTriangulatedSurfaceSeries surface = (NTriangulatedSurfaceSeries)nChartControl1.Charts[0].Series[0];

			switch (paletteModeCombo.SelectedIndex)
			{
				case 0:
					surface.AutomaticPalette = true;
					surface.SyncPaletteWithAxisScale = false;
					paletteStepsCombo.Enabled = true;
					break;

				case 1:
					surface.AutomaticPalette = true;
					surface.SyncPaletteWithAxisScale = true;
					paletteStepsCombo.Enabled = false;
					break;

				case 2:
					surface.AutomaticPalette = false;
					paletteStepsCombo.Enabled = false;
					break;
			}

			if (smoothPaletteCheck.Checked)
			{
				surface.SmoothPalette = true;
				surface.PaletteSteps = paletteStepsCombo.SelectedIndex + 1;
			}
			else
			{
				surface.SmoothPalette = false;
				surface.PaletteSteps = paletteStepsCombo.SelectedIndex + 2;
			}
		}

		private void PaletteModeCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateSurface();

			nChartControl1.Refresh();
		}
		private void PaletteStepsCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateSurface();

			nChartControl1.Refresh();
		}
		private void SmoothPaletteCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateSurface();

			nChartControl1.Refresh();
		}

	}
}
