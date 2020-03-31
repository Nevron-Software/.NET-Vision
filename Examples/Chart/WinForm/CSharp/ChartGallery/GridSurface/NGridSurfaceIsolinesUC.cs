using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGridSurfaceIsolinesUC : NExampleBaseUC
	{
		private NumericUpDown BlueIsolineValueNumericUpDown;
		private Label label2;
		private NumericUpDown RedIsolineValueNumericUpDown;
		private Label label1;
		private System.ComponentModel.Container components = null;

		private NSurfaceIsoline m_RedIsoline;
		private NSurfaceIsoline m_BlueIsoline;

		public NGridSurfaceIsolinesUC()
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
			this.BlueIsolineValueNumericUpDown.Location = new System.Drawing.Point(12, 74);
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
			this.label2.Location = new System.Drawing.Point(9, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Blue Isoline Value:";
			// 
			// RedIsolineValueNumericUpDown
			// 
			this.RedIsolineValueNumericUpDown.Location = new System.Drawing.Point(12, 28);
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
			this.label1.Location = new System.Drawing.Point(9, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Red Isoline Value:";
			// 
			// NGridSurfaceIsolinesUC
			// 
			this.Controls.Add(this.BlueIsolineValueNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.RedIsolineValueNumericUpDown);
			this.Controls.Add(this.label1);
			this.Name = "NGridSurfaceIsolinesUC";
			this.Size = new System.Drawing.Size(180, 231);
			((System.ComponentModel.ISupportInitialize)(this.BlueIsolineValueNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RedIsolineValueNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed;

			// set a chart title
			NLabel title = new NLabel("Grid Surface Isolines");
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

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.RoundToTickMax = false;
			scaleY.RoundToTickMin = false;
			scaleY.MinTickDistance = new NLength(10, NGraphicsUnit.Point);
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Left, ChartWallType.Back };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMax = false;
			scaleX.RoundToTickMin = false;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.RoundToTickMax = false;
			scaleZ.RoundToTickMin = false;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Left };
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;

			// add a surface series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Contour";
			surface.Legend.Mode = SeriesLegendMode.None;
			surface.ValueFormatter = new NNumericValueFormatter("0.0");
			surface.FillMode = SurfaceFillMode.ZoneTexture;
			surface.FrameMode = SurfaceFrameMode.None;
			surface.ShadingMode = ShadingMode.Smooth;
			surface.Palette.SmoothPalette = true;
			surface.Data.SetGridSize(31, 31);

			// fill the surface with data
			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

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

		private void FillData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 10.0;
			const double dIntervalZ = 10.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for(int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for(int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = 100 - Math.Sqrt((x * x) + (z * z) + 2);
					y += 100 * Math.Sin(x) * Math.Cos(z);

					surface.Data.SetValue(i, j, y);
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