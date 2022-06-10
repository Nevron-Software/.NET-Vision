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
	public class NGridSurfaceHorizontalCrossSectionUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;
		private NumericUpDown PlaneValueNumericUpDown;
		private Label label1;

		NLineSeries m_ContourLineSeries;
		NAxisConstLine m_CrossSectionPlane;

		public NGridSurfaceHorizontalCrossSectionUC()
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
			this.PlaneValueNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.PlaneValueNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// PlaneValueNumericUpDown
			// 
			this.PlaneValueNumericUpDown.Location = new System.Drawing.Point(12, 29);
			this.PlaneValueNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.PlaneValueNumericUpDown.Name = "PlaneValueNumericUpDown";
			this.PlaneValueNumericUpDown.Size = new System.Drawing.Size(120, 20);
			this.PlaneValueNumericUpDown.TabIndex = 7;
			this.PlaneValueNumericUpDown.ValueChanged += new System.EventHandler(this.PlaneValueNumericUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Horizontal Plane Value:";
			// 
			// NGridSurfaceHorizontalCrossSectionUC
			// 
			this.Controls.Add(this.PlaneValueNumericUpDown);
			this.Controls.Add(this.label1);
			this.Name = "NGridSurfaceHorizontalCrossSectionUC";
			this.Size = new System.Drawing.Size(180, 396);
			((System.ComponentModel.ISupportInitialize)(this.PlaneValueNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

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
			NLabel title = nChartControl1.Labels.AddHeader("Surface Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(Color.Gray);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 60.0f;
			chart.Depth = 60.0f;
			chart.Height = 25.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft);

			// setup axes
			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			ordinalScale = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			chart.Axis(StandardAxis.SecondaryY).Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 100.0f, 100.0f);
			chart.Axis(StandardAxis.SecondaryY).Visible = false;

			m_ContourLineSeries = new NLineSeries();
			chart.Series.Add(m_ContourLineSeries);

			m_ContourLineSeries.UseXValues = true;
			m_ContourLineSeries.UseZValues = true;
			m_ContourLineSeries.BorderStyle.Width = new NLength(2);
			m_ContourLineSeries.BorderStyle.Color = Color.Red;

			m_ContourLineSeries.DataLabelStyle.Visible = false;
			m_ContourLineSeries.DisplayOnAxis((int)StandardAxis.PrimaryY, false);
			m_ContourLineSeries.DisplayOnAxis((int)StandardAxis.SecondaryY, true);
			m_ContourLineSeries.Legend.Mode = SeriesLegendMode.None;

			m_CrossSectionPlane = new NAxisConstLine();
			m_CrossSectionPlane.Mode = ConstLineMode.Plane;
			m_CrossSectionPlane.FillStyle = new NColorFillStyle(Color.FromArgb(25, Color.Blue));
			chart.Axis(StandardAxis.PrimaryY).ConstLines.Add(m_CrossSectionPlane);

 			// add the surface series
			NGridSurfaceSeries surface = (NGridSurfaceSeries)chart.Series.Add(SeriesType.GridSurface);
			surface.Name = "Surface";
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic;
			surface.PositionValue = 10.0;
			surface.Data.SetGridSize(31, 32);
			surface.SyncPaletteWithAxisScale = false;
			surface.PaletteSteps = 8;
			surface.ValueFormatter.FormatSpecifier = "0.00";
			surface.FillStyle = new NColorFillStyle(Color.YellowGreen);
			surface.Isolines.Add(new NSurfaceIsoline(10, new NStrokeStyle(2.0f, Color.Blue)));
			surface.FrameColorMode = SurfaceFrameColorMode.Uniform;

			FillData(surface);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			PlaneValueNumericUpDown.Value = 10;
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
					y = 10 - Math.Sqrt((x * x) + (z * z) + 2);
					y += 3.0 * Math.Sin(x) * Math.Cos(z);

					surface.Data.SetValue(i, j, y);
				}
			}
		}

		private void PlaneValueNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			double value = (double)PlaneValueNumericUpDown.Value;
			NGridSurfaceSeries surface = nChartControl1.Charts[0].Series[1] as NGridSurfaceSeries;

			if (surface.Isolines.Count > 0)
			{
				surface.Isolines[0].Value = value;
			}

			m_CrossSectionPlane.Value = value;

			NLevelPath path = surface.GetContourForValue(value);

			m_ContourLineSeries.XValues.Clear();
			m_ContourLineSeries.ZValues.Clear();
			m_ContourLineSeries.Values.Clear();

			foreach (NLevelContour contour in path)
			{
				if (contour.Count > 0)
				{
					int index = m_ContourLineSeries.XValues.Count + 1;
					int pointCount = contour.Count;
					for (int i = 0; i < pointCount; i++)
					{
						NPointD point = contour[i];
						m_ContourLineSeries.XValues.Add(point.X);
						m_ContourLineSeries.ZValues.Add(point.Y);
						m_ContourLineSeries.Values.Add(0);
					}

					m_ContourLineSeries.XValues.Add(m_ContourLineSeries.XValues[index]);
					m_ContourLineSeries.ZValues.Add(m_ContourLineSeries.ZValues[index]);
					m_ContourLineSeries.Values.Add(0);

					m_ContourLineSeries.XValues.Add(double.NaN);
					m_ContourLineSeries.ZValues.Add(double.NaN);
					m_ContourLineSeries.Values.Add(double.NaN);
				}
			}

			nChartControl1.Refresh();
		}
	}
}