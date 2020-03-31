using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
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
	public class NPanelZoomToolUC : NExampleBaseUC
	{
		private NPanelZoomTool m_PanelZoomTool;
		private Nevron.UI.WinForm.Controls.NButton ZoomInFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton ZoomOutFillStyleButton;
		private Nevron.UI.WinForm.Controls.NCheckBox PreserveAspectRatioCheckBox;
		private UI.WinForm.Controls.NCheckBox ZoomInBoundsOnlyCheckBox;
		private System.ComponentModel.Container components = null;

		public NPanelZoomToolUC()
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
			this.ZoomInFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ZoomOutFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.PreserveAspectRatioCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ZoomInBoundsOnlyCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ZoomInFillStyleButton
			// 
			this.ZoomInFillStyleButton.Location = new System.Drawing.Point(7, 11);
			this.ZoomInFillStyleButton.Name = "ZoomInFillStyleButton";
			this.ZoomInFillStyleButton.Size = new System.Drawing.Size(160, 23);
			this.ZoomInFillStyleButton.TabIndex = 0;
			this.ZoomInFillStyleButton.Text = "Zoom In Fill Style...";
			this.ZoomInFillStyleButton.Click += new System.EventHandler(this.ZoomInFillStyleButton_Click);
			// 
			// ZoomOutFillStyleButton
			// 
			this.ZoomOutFillStyleButton.Location = new System.Drawing.Point(7, 43);
			this.ZoomOutFillStyleButton.Name = "ZoomOutFillStyleButton";
			this.ZoomOutFillStyleButton.Size = new System.Drawing.Size(160, 23);
			this.ZoomOutFillStyleButton.TabIndex = 1;
			this.ZoomOutFillStyleButton.Text = "Zoom Out Fill Style...";
			this.ZoomOutFillStyleButton.Click += new System.EventHandler(this.ZoomOutFillStyleButton_Click);
			// 
			// PreserveAspectRatioCheckBox
			// 
			this.PreserveAspectRatioCheckBox.ButtonProperties.BorderOffset = 2;
			this.PreserveAspectRatioCheckBox.Location = new System.Drawing.Point(7, 70);
			this.PreserveAspectRatioCheckBox.Name = "PreserveAspectRatioCheckBox";
			this.PreserveAspectRatioCheckBox.Size = new System.Drawing.Size(152, 24);
			this.PreserveAspectRatioCheckBox.TabIndex = 2;
			this.PreserveAspectRatioCheckBox.Text = "Preserve Aspect Ratio";
			this.PreserveAspectRatioCheckBox.CheckedChanged += new System.EventHandler(this.PreserveAspectRatioCheckBox_CheckedChanged);
			// 
			// ZoomInBoundsOnlyCheckBox
			// 
			this.ZoomInBoundsOnlyCheckBox.ButtonProperties.BorderOffset = 2;
			this.ZoomInBoundsOnlyCheckBox.Location = new System.Drawing.Point(7, 94);
			this.ZoomInBoundsOnlyCheckBox.Name = "ZoomInBoundsOnlyCheckBox";
			this.ZoomInBoundsOnlyCheckBox.Size = new System.Drawing.Size(152, 24);
			this.ZoomInBoundsOnlyCheckBox.TabIndex = 3;
			this.ZoomInBoundsOnlyCheckBox.Text = "Zoom In Bounds Only";
			this.ZoomInBoundsOnlyCheckBox.CheckedChanged += new System.EventHandler(this.ZoomInBoundsOnlyCheckBox_CheckedChanged);
			// 
			// NPanelZoomToolUC
			// 
			this.Controls.Add(this.ZoomInBoundsOnlyCheckBox);
			this.Controls.Add(this.PreserveAspectRatioCheckBox);
			this.Controls.Add(this.ZoomOutFillStyleButton);
			this.Controls.Add(this.ZoomInFillStyleButton);
			this.Name = "NPanelZoomToolUC";
			this.Size = new System.Drawing.Size(180, 664);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Panel Zoom Tool");
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
			surface.FillMode = SurfaceFillMode.None;
			surface.FrameMode = SurfaceFrameMode.Mesh;
			surface.Data.SetGridSize(30, 30);
			surface.SyncPaletteWithAxisScale = false;
			surface.ValueFormatter.FormatSpecifier = "0.00";

			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			m_PanelZoomTool = new NPanelZoomTool();
			nChartControl1.Controller.Selection.SelectedObjects.Add(chart);
			nChartControl1.Controller.Tools.Add(m_PanelZoomTool);

			PreserveAspectRatioCheckBox.Checked = true;
			ZoomInBoundsOnlyCheckBox.Checked = true;
		}

		private void FillData(NGridSurfaceSeries surface)
		{
			double y, x, z;
			int nCountX = surface.Data.GridSizeX;
			int nCountZ = surface.Data.GridSizeZ;

			const double dIntervalX = 30.0;
			const double dIntervalZ = 30.0;
			double dIncrementX = (dIntervalX / nCountX);
			double dIncrementZ = (dIntervalZ / nCountZ);

			z = -(dIntervalZ / 2);

			for (int j = 0; j < nCountZ; j++, z += dIncrementZ)
			{
				x = -(dIntervalX / 2);

				for (int i = 0; i < nCountX; i++, x += dIncrementX)
				{
					y = (x * x) - (z * z);
					y += 200 * Math.Sin(x / 4.0) * Math.Cos(z / 4.0);

					surface.Data.SetValue(i, j, y);
				}
			}
		}

		private void ZoomInFillStyleButton_Click(object sender, EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_PanelZoomTool.ZoomInFillStyle, out fillStyleResult))
			{
				m_PanelZoomTool.ZoomInFillStyle = fillStyleResult;
			}
		}

		private void ZoomOutFillStyleButton_Click(object sender, EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_PanelZoomTool.ZoomOutFillStyle, out fillStyleResult))
			{
				m_PanelZoomTool.ZoomOutFillStyle = fillStyleResult;
			}
		}

		private void PreserveAspectRatioCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (m_PanelZoomTool != null)
			{
				m_PanelZoomTool.PreserveAspect = PreserveAspectRatioCheckBox.Checked;
			}
		}

		private void ZoomInBoundsOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (m_PanelZoomTool != null)
			{
				m_PanelZoomTool.ZoomInBoundsOnly = ZoomInBoundsOnlyCheckBox.Checked;
			}
		}
	}
}
