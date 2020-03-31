using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Resources;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NMeshFillStyleUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton FillStyleButton;
		private Nevron.UI.WinForm.Controls.NCheckBox smoothShadingCheck;
		private System.ComponentModel.Container components = null;

		public NMeshFillStyleUC()
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
			this.FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.smoothShadingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// FillStyleButton
			// 
			this.FillStyleButton.Location = new System.Drawing.Point(4, 10);
			this.FillStyleButton.Name = "FillStyleButton";
			this.FillStyleButton.Size = new System.Drawing.Size(171, 27);
			this.FillStyleButton.TabIndex = 1;
			this.FillStyleButton.Text = "Surface Fill Style...";
			this.FillStyleButton.Click += new System.EventHandler(this.FillStyleButton_Click);
			// 
			// smoothShadingCheck
			// 
			this.smoothShadingCheck.ButtonProperties.BorderOffset = 2;
			this.smoothShadingCheck.Location = new System.Drawing.Point(4, 45);
			this.smoothShadingCheck.Name = "smoothShadingCheck";
			this.smoothShadingCheck.Size = new System.Drawing.Size(163, 20);
			this.smoothShadingCheck.TabIndex = 5;
			this.smoothShadingCheck.Text = "Smooth Shading";
			this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			// 
			// NMeshFillStyleUC
			// 
			this.Controls.Add(this.smoothShadingCheck);
			this.Controls.Add(this.FillStyleButton);
			this.Name = "NMeshFillStyleUC";
			this.Size = new System.Drawing.Size(180, 164);
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
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface With Texture");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
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

			// setup surface
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series.Add(SeriesType.MeshSurface);
			surface.Name = "Surface";
			surface.FrameMode = SurfaceFrameMode.None;
			surface.FillMode = SurfaceFillMode.Uniform;
			surface.Data.SetGridSize(50, 50);

			FillData(surface);

			NImageFillStyle imageFillStyle = new NImageFillStyle(NResourceHelper.BitmapFromResource(this.GetType(), "Marble.jpg", "Nevron.Examples.Chart.WinForm.Resources"));
			imageFillStyle.TextureMappingStyle.MapLayout = MapLayout.Tiled;
			imageFillStyle.TextureMappingStyle.HorizontalScale = 0.1f;
			imageFillStyle.TextureMappingStyle.VerticalScale = 0.1f;

			surface.FillStyle = imageFillStyle;

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// form controls
			smoothShadingCheck.Checked = true;
		}

		private void FillStyleButton_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NMeshSurfaceSeries surface = (NMeshSurfaceSeries)chart.Series[0];

			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(surface.FillStyle, out fillStyleResult))
			{
				surface.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		void FillData(NMeshSurfaceSeries surface)
		{
			double x, y, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 4.4;
			const double dIntervalZ = 4.4;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			for(int j = 0; j < nCountZ; j++)
			{
				for(int i = 0; i < nCountX; i++)
				{
					x = -(dIntervalX * 0.5) + (i * dIncrementX);
					z = -(dIntervalZ * 0.5) + (j * dIncrementZ);

					y = 8 * Math.Cos(x * x) + 5 * Math.Sin(z * z);

					x += Math.Sin(j * 0.25) * 0.25;
					z += Math.Cos(i * 0.25) * 0.25;

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
	}
}