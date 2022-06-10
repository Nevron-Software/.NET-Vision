using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Resources;
using System.Windows.Forms;
using System.IO;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGridFillStyleUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton FillStyleButton;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothShadingCheck;		
		private Nevron.UI.WinForm.Controls.NComboBox texturePlaneCombo;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.Container components = null;

		public NGridFillStyleUC()
		{
			InitializeComponent();

			texturePlaneCombo.Items.Add("XZ");
			texturePlaneCombo.Items.Add("XY");
			texturePlaneCombo.Items.Add("ZY");
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
			this.FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.smoothShadingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.texturePlaneCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// FillStyleButton
			// 
			this.FillStyleButton.Location = new System.Drawing.Point(10, 10);
			this.FillStyleButton.Name = "FillStyleButton";
			this.FillStyleButton.Size = new System.Drawing.Size(151, 27);
			this.FillStyleButton.TabIndex = 0;
			this.FillStyleButton.Text = "Surface Fill Style...";
			this.FillStyleButton.Click += new System.EventHandler(this.FillStyleButton_Click);
			// 
			// smoothShadingCheck
			// 
			this.smoothShadingCheck.ButtonProperties.BorderOffset = 2;
			this.smoothShadingCheck.Location = new System.Drawing.Point(10, 45);
			this.smoothShadingCheck.Name = "smoothShadingCheck";
			this.smoothShadingCheck.Size = new System.Drawing.Size(143, 20);
			this.smoothShadingCheck.TabIndex = 1;
			this.smoothShadingCheck.Text = "Smooth Shading";
			this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(10, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(131, 14);
			this.label4.TabIndex = 2;
			this.label4.Text = "Texture Plane:";
			// 
			// texturePlaneCombo
			// 
			this.texturePlaneCombo.ListProperties.CheckBoxDataMember = "";
			this.texturePlaneCombo.ListProperties.DataSource = null;
			this.texturePlaneCombo.ListProperties.DisplayMember = "";
			this.texturePlaneCombo.Location = new System.Drawing.Point(10, 103);
			this.texturePlaneCombo.Name = "texturePlaneCombo";
			this.texturePlaneCombo.Size = new System.Drawing.Size(151, 21);
			this.texturePlaneCombo.TabIndex = 3;
			this.texturePlaneCombo.SelectedIndexChanged += new System.EventHandler(this.TexturePlaneCombo_SelectedIndexChanged);
			// 
			// NGridFillStyleUC
			// 
			this.Controls.Add(this.label4);
			this.Controls.Add(this.texturePlaneCombo);
			this.Controls.Add(this.smoothShadingCheck);
			this.Controls.Add(this.FillStyleButton);
			this.Name = "NGridFillStyleUC";
			this.Size = new System.Drawing.Size(180, 211);
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
			NLabel title = new NLabel("Surface With Texture");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// no legends
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 15.0f;
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
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Surface";
			surface.FrameMode = SurfaceFrameMode.None;
			surface.FillMode = SurfaceFillMode.Uniform;
			surface.Data.SetGridSize(60, 60);

			FillData();

			Bitmap bitmap = NResourceHelper.BitmapFromResource(this.GetType(), "Marble.jpg", "Nevron.Examples.Chart.WinForm.Resources");

			NImageFillStyle imageFillStyle = new NImageFillStyle(bitmap);
			imageFillStyle.TextureMappingStyle.MapLayout = MapLayout.Tiled;
			imageFillStyle.TextureMappingStyle.HorizontalScale = 0.1f;
			imageFillStyle.TextureMappingStyle.VerticalScale = 0.1f;

			imageFillStyle.MaterialStyle.Diffuse = Color.FromArgb(204, 204, 0);
			imageFillStyle.MaterialStyle.Ambient = Color.FromArgb(51, 102, 153);
			imageFillStyle.MaterialStyle.Specular = Color.DarkGray;

			surface.FillStyle = imageFillStyle;

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// form controls
			smoothShadingCheck.Checked = true;
			texturePlaneCombo.SelectedIndex = 0;
		}

		private void FillData()
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			Stream stream = null;
			BinaryReader reader = null;

			try
			{
				// fill the XYZ data from a binary resource
				stream = NResourceHelper.GetResourceStream(GetType().Assembly, "DataY.bin", "Nevron.Examples.Chart.WinForm.Resources");
				reader = new BinaryReader(stream);

				int dataPointsCount = (int)(stream.Length / 4);
				int sizeX = (int)Math.Sqrt(dataPointsCount);
				int sizeZ = sizeX;

				surface.Data.SetGridSize(sizeX, sizeZ);

				for(int z = 0; z < sizeZ; z++)
				{
					for(int x = 0; x < sizeX; x++)
					{
						surface.Data.SetValue(x, z, reader.ReadSingle());
					}
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

		private void FillStyleButton_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(surface.FillStyle, out fillStyleResult))
			{
				surface.FillStyle = fillStyleResult;
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

		private void TexturePlaneCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series[0];

			switch(texturePlaneCombo.SelectedIndex)
			{
				case 0:
					surface.TexturePlaneMode = SurfaceTexturePlaneMode.XZ;
					break;

				case 1:
					surface.TexturePlaneMode = SurfaceTexturePlaneMode.XY;
					break;

				case 2:
					surface.TexturePlaneMode = SurfaceTexturePlaneMode.ZY;
					break;
			}

			nChartControl1.Refresh();
		}
	}
}