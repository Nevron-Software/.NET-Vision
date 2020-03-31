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
	public class NXYScatterSmoothLineUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton btnChangeData;
		private System.ComponentModel.IContainer components = null;

		public NXYScatterSmoothLineUC()
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
			this.SuspendLayout();
			// 
			// btnChangeData
			// 
			this.btnChangeData.Location = new System.Drawing.Point(5, 8);
			this.btnChangeData.Name = "btnChangeData";
			this.btnChangeData.Size = new System.Drawing.Size(170, 32);
			this.btnChangeData.TabIndex = 1;
			this.btnChangeData.Text = "Change Data";
			this.btnChangeData.Click += new System.EventHandler(this.btnChangeData_Click);
			// 
			// NXYScatterSmoothLineUC
			// 
			this.Controls.Add(this.btnChangeData);
			this.Name = "NXYScatterSmoothLineUC";
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
			NLabel title = new NLabel("XY Smooth Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			chart.Enable3D = true;
			chart.Width = 70;
			chart.Height = 70;
			chart.Depth = 15;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// configure axes
			chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			// add the line
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series.Add(SeriesType.SmoothLine);
			line.Name = "Smooth Line";
			line.InflateMargins = true;
			line.Legend.Mode = SeriesLegendMode.Series;
			line.DataLabelStyle.Visible = false;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.AutoDepth = false;
			line.MarkerStyle.Width = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Depth = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.UseXValues = true;
			line.UseZValues = false;
			line.Use1DInterpolationForXYScatter = false;

			ChangeData();

			// apply layout
			ConfigureStandardLayout(chart, title, null);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}

		private void ChangeData()
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series[0];

			line.Values.Clear();
			line.XValues.Clear();
			line.ZValues.Clear();

			double r = 5;

			for(int i = 0; i < 10; i++)
			{
				double dY = r * Math.Sin(i) + Random.NextDouble();
				double dX = r * Math.Cos(i) + Random.NextDouble();;

				line.Values.Add(dY);
				line.XValues.Add(dX);

				r -= 0.3;
			}
		}

		private void btnChangeData_Click(object sender, System.EventArgs e)
		{
			ChangeData();
			nChartControl1.Refresh();
		}
	}
}

