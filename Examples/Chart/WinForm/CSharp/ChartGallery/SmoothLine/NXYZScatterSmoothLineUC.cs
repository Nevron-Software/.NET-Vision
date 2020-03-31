using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NXYZScatterSmoothLineUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton btnChangeData;
		private Nevron.UI.WinForm.Controls.NCheckBox checkShowMarkers;
		private Nevron.UI.WinForm.Controls.NCheckBox checkRoundToTick;
		private System.ComponentModel.IContainer components = null;

		public NXYZScatterSmoothLineUC()
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnChangeData = new Nevron.UI.WinForm.Controls.NButton();
			this.checkShowMarkers = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.checkRoundToTick = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// btnChangeData
			// 
			this.btnChangeData.Location = new System.Drawing.Point(5, 8);
			this.btnChangeData.Name = "btnChangeData";
			this.btnChangeData.Size = new System.Drawing.Size(170, 32);
			this.btnChangeData.TabIndex = 0;
			this.btnChangeData.Text = "Change Data";
			this.btnChangeData.Click += new System.EventHandler(this.btnChangeData_Click);
			// 
			// checkShowMarkers
			// 
			this.checkShowMarkers.ButtonProperties.BorderOffset = 2;
			this.checkShowMarkers.Location = new System.Drawing.Point(5, 56);
			this.checkShowMarkers.Name = "checkShowMarkers";
			this.checkShowMarkers.Size = new System.Drawing.Size(170, 24);
			this.checkShowMarkers.TabIndex = 1;
			this.checkShowMarkers.Text = "Show Markers";
			this.checkShowMarkers.CheckedChanged += new System.EventHandler(this.checkShowMarkers_CheckedChanged);
			// 
			// checkRoundToTick
			// 
			this.checkRoundToTick.ButtonProperties.BorderOffset = 2;
			this.checkRoundToTick.Location = new System.Drawing.Point(5, 96);
			this.checkRoundToTick.Name = "checkRoundToTick";
			this.checkRoundToTick.Size = new System.Drawing.Size(170, 24);
			this.checkRoundToTick.TabIndex = 2;
			this.checkRoundToTick.Text = "Axis Round To Tick ";
			this.checkRoundToTick.CheckedChanged += new System.EventHandler(this.checkRoundToTick_CheckedChanged);
			// 
			// NXYZScatterSmoothLineUC
			// 
			this.Controls.Add(this.checkRoundToTick);
			this.Controls.Add(this.checkShowMarkers);
			this.Controls.Add(this.btnChangeData);
			this.Name = "NXYZScatterSmoothLineUC";
			this.Size = new System.Drawing.Size(180, 150);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			NChart chart = nChartControl1.Charts[0];

			nChartControl1.Controller.Selection.Add(chart);
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = new NLabel("XYZ Smooth Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			chart.Enable3D = true;
			chart.Depth = 55.0f;
			chart.Width = 55.0f;
			chart.Height = 55.0f;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// setup axes
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).Visible = true;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add the smooth line
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series.Add(SeriesType.SmoothLine);
			line.Name = "Smooth Line";
			line.InflateMargins = true;
			line.Legend.Mode = SeriesLegendMode.Series;
			line.BorderStyle.Color = Color.Indigo;
			line.BorderStyle.Width = new NLength(1, NGraphicsUnit.Pixel);
			line.DataLabelStyle.Visible = false;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Sphere;
			line.MarkerStyle.AutoDepth = false;
			line.MarkerStyle.Width = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Depth = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.UseXValues = true;
			line.UseZValues = true;

			ChangeData();

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			checkShowMarkers.Checked = true;
			checkRoundToTick.Checked = true;
		}

		private void ChangeData()
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series[0];

			float fSpringHeight = 10;
			int nWindings = (int)3;
			int nComplexity = (int)4;

			double dCurrentAngle = 0;
			double dCurrentHeight = 0;
			double dCurrentRadius = 5;
			double dX = 0, dY = 0, dZ = 0;

			float fHeightStep = fSpringHeight / (nWindings * nComplexity);
			float fAngleStepRad = (float)(((360 / nComplexity) * 3.1415926535f) / 180.0f);

			line.Values.Clear();
			line.XValues.Clear();
			line.ZValues.Clear();

			while (nWindings > 0)
			{
				for (int i = 0; i < nComplexity; i++)
				{
					dX = Math.Cos(dCurrentAngle) * dCurrentRadius;
					dZ = Math.Sin(dCurrentAngle) * dCurrentRadius;
					dY = dCurrentHeight;

					line.Values.Add(dY);
					line.XValues.Add(dX);
					line.ZValues.Add(dZ);

					dCurrentAngle += fAngleStepRad;
					dCurrentHeight += fHeightStep;
					dCurrentRadius = 2 + Random.NextDouble() * 5;
				}

				nWindings--;
			}
		}

		private void btnChangeData_Click(object sender, System.EventArgs e)
		{
			ChangeData();
			nChartControl1.Refresh();
		}

		private void checkShowMarkers_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series[0];

			line.MarkerStyle.Visible = checkShowMarkers.Checked;

			nChartControl1.Refresh();
		}

		private void checkRoundToTick_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			bool bRoundToTick = checkRoundToTick.Checked;

			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			standardScale.RoundToTickMin = bRoundToTick;
			standardScale.RoundToTickMax = bRoundToTick;

			standardScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			standardScale.RoundToTickMin = bRoundToTick;
			standardScale.RoundToTickMax = bRoundToTick;

			standardScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.Depth).ScaleConfigurator;
			standardScale.RoundToTickMin = bRoundToTick;
			standardScale.RoundToTickMax = bRoundToTick;

			nChartControl1.Refresh();
		}
	}
}

