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
	public class NMeshSurfaceIsolinesUC : NExampleBaseUC
	{
		private NumericUpDown BlueIsolineValueNumericUpDown;
		private Label label2;
		private NumericUpDown RedIsolineValueNumericUpDown;
		private Label label1;
		private System.ComponentModel.Container components = null;

		private NSurfaceIsoline m_RedIsoline;
		private NSurfaceIsoline m_BlueIsoline;

		public NMeshSurfaceIsolinesUC()
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
			this.BlueIsolineValueNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.RedIsolineValueNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.BlueIsolineValueNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RedIsolineValueNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// BlueIsolineValueNumericUpDown
			// 
			this.BlueIsolineValueNumericUpDown.Location = new System.Drawing.Point(13, 73);
			this.BlueIsolineValueNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.BlueIsolineValueNumericUpDown.Name = "BlueIsolineValueNumericUpDown";
			this.BlueIsolineValueNumericUpDown.Size = new System.Drawing.Size(120, 20);
			this.BlueIsolineValueNumericUpDown.TabIndex = 7;
			this.BlueIsolineValueNumericUpDown.ValueChanged += new System.EventHandler(this.BlueIsolineValueNumericUpDown_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Blue Isoline Value:";
			// 
			// RedIsolineValueNumericUpDown
			// 
			this.RedIsolineValueNumericUpDown.Location = new System.Drawing.Point(13, 27);
			this.RedIsolineValueNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.RedIsolineValueNumericUpDown.Name = "RedIsolineValueNumericUpDown";
			this.RedIsolineValueNumericUpDown.Size = new System.Drawing.Size(120, 20);
			this.RedIsolineValueNumericUpDown.TabIndex = 5;
			this.RedIsolineValueNumericUpDown.ValueChanged += new System.EventHandler(this.RedIsolineValueNumericUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Red Isoline Value:";
			// 
			// NMeshSurfaceIsolinesUC
			// 
			this.Controls.Add(this.BlueIsolineValueNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.RedIsolineValueNumericUpDown);
			this.Controls.Add(this.label1);
			this.Name = "NMeshSurfaceIsolinesUC";
			this.Size = new System.Drawing.Size(180, 300);
			((System.ComponentModel.ISupportInitialize)(this.BlueIsolineValueNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RedIsolineValueNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Settings.RenderSurface = RenderSurface.Window;
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;
			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface Isolines");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 25.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

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

			// setup surface series
			NMeshSurfaceSeries surface = new NMeshSurfaceSeries();
			chart.Series.Add(surface);
			surface.ShadingMode = ShadingMode.Smooth;
			surface.FillMode = SurfaceFillMode.ZoneTexture;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.Data.SetGridSize(100, 100);
			surface.Palette.SmoothPalette = true;

			// generate data
			GenerateSurfaceData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			m_RedIsoline = new NSurfaceIsoline();
			m_RedIsoline.StrokeStyle = new NStrokeStyle(2.0f, Color.Red);
			surface.Isolines.Add(m_RedIsoline);

			m_BlueIsoline = new NSurfaceIsoline();
			m_BlueIsoline.StrokeStyle = new NStrokeStyle(2.0f, Color.Blue);
			surface.Isolines.Add(m_BlueIsoline);

			RedIsolineValueNumericUpDown.Value = 100;
			BlueIsolineValueNumericUpDown.Value = 50;
		}

		private void GenerateSurfaceData(NMeshSurfaceSeries surface)
		{
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 20.0;
			const double dIntervalZ = 20.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			double pz = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, pz += dIncrementZ)
			{
				double px = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, px += dIncrementX)
				{
					double x = px + Math.Sin(pz) * 0.4;
					double z = pz + Math.Cos(px) * 0.4;
					double y = Math.Sin(px * 0.33) * Math.Sin(pz * 0.33) * 200;

					if (y < 0)
					{
						y = - y * 0.7;
					}

					double tmp = (1 - x * x - z * z);
					y -= tmp * tmp * 0.000001;

					surface.Data.SetValue(i, j, y, x, z);
				}
			}
		}

		private void RedIsolineValueNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_RedIsoline.Value = (double)RedIsolineValueNumericUpDown.Value;
			nChartControl1.Refresh();
		}

		private void BlueIsolineValueNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_BlueIsoline.Value = (double)BlueIsolineValueNumericUpDown.Value;
			nChartControl1.Refresh();
		}

	}
}