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
	public class NMeshSurfaceCustomColorsUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox smoothShadingCheck;
		private System.ComponentModel.Container components = null;

		public NMeshSurfaceCustomColorsUC()
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
			this.smoothShadingCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// smoothShadingCheck
			// 
			this.smoothShadingCheck.ButtonProperties.BorderOffset = 2;
			this.smoothShadingCheck.Location = new System.Drawing.Point(3, 12);
			this.smoothShadingCheck.Name = "smoothShadingCheck";
			this.smoothShadingCheck.Size = new System.Drawing.Size(163, 20);
			this.smoothShadingCheck.TabIndex = 5;
			this.smoothShadingCheck.Text = "Smooth Shading";
			this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			// 
			// NMeshSurfaceCustomColorsUC
			// 
			this.Controls.Add(this.smoothShadingCheck);
			this.Name = "NMeshSurfaceCustomColorsUC";
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
			NLabel title = nChartControl1.Labels.AddHeader("Mesh Surface With Custom Colors");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 55.0f;
			chart.Depth = 55.0f;
			chart.Height = 55.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);

			chart.Axis(StandardAxis.PrimaryX).View = new NRangeAxisView(new NRange1DD(-120, 120), true, true);
			chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(-120, 120), true, true);
			chart.Axis(StandardAxis.Depth).View = new NRangeAxisView(new NRange1DD(-120, 120), true, true);

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
			surface.FillMode = SurfaceFillMode.CustomColors;
			surface.Data.SetGridSize(50, 50);

			FillData(surface);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// form controls
			smoothShadingCheck.Checked = true;
		}

		void FillData(NMeshSurfaceSeries surface)
		{
			int m = 200;
			int n = 100;

			int lastM = m - 1;
			int lastN = n - 1;

			double centerX = 0;
			double centerZ = 0;
			double centerY = 0;

			double radius1 = 100.0;
			double radius2 = 10.0;

			double beginAlpha = 0;
			double endAlpha = NMath.PI2;
			double alphaStep = 2 * NMath.PI2 / m;

			double beginBeta = 0;
			double endBeta = NMath.PI2;
			double betaStep = NMath.PI2 / n;

			NVector2DD[] arrPrecomputedData = new NVector2DD[m];

			for (int i = 0; i < m; i++)
			{
				// calculate the current angle, its cos and sin
				double alpha = (i == lastM) ? (endAlpha) : (beginAlpha + i * alphaStep);

				arrPrecomputedData[i].X = Math.Cos(alpha);
				arrPrecomputedData[i].Y = Math.Sin(alpha);
			}

			int vertexIndex = 0;

			surface.Data.UseColors = true;
			surface.Data.SetGridSize(m, n);

			Color beginColor = Color.Red;
			Color endColor = Color.Blue;

			float offset = -100;

			for (int j = 0; j < n; j++)
			{
				// calculate the current beta angle
				double beta = (j == lastN) ? (endBeta) : (beginBeta + j * betaStep);
				double fCosBeta = (float)Math.Cos(beta);
				double fSinBeta = (float)Math.Sin(beta);

				offset = -100;

				for (int i = 0; i < m; i++)
				{
					double fCosAlpha = arrPrecomputedData[i].X;
					double fSinAlpha = arrPrecomputedData[i].Y;

					double fx = fCosBeta * radius2 + radius1;

					double dx = fx * fCosAlpha;
					double dz = fx * fSinAlpha;
					double dy = -(fSinBeta * radius2);

					double x = centerX + dx;
					double y = centerY + dy + offset;
					double z = centerZ + dz;

					offset++;

					surface.Data.SetValue(i, j, y, x, z);
					
					double length = Math.Sqrt(dx * dx + dz * dz + dy * dy);
					surface.Data.SetColor(i, j, InterpolateColors(beginColor, endColor, (float)i / (float)100));//(length - (radius1 - radius2)) / radius2));

					vertexIndex++;
				}
			}
		}

		public static Color InterpolateColors(Color color1, Color color2, double factor)
		{
			if (factor > 1.0f)
				factor = 1.0f;

			int num1 = ((int)color1.R);
			int num2 = ((int)color1.G);
			int num3 = ((int)color1.B);

			int num4 = ((int)color2.R);
			int num5 = ((int)color2.G);
			int num6 = ((int)color2.B);

			byte num7 = (byte)((((float)num1) + (((float)(num4 - num1)) * factor)));
			byte num8 = (byte)((((float)num2) + (((float)(num5 - num2)) * factor)));
			byte num9 = (byte)((((float)num3) + (((float)(num6 - num3)) * factor)));

			return Color.FromArgb(num7, num8, num9);
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