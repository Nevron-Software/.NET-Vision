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
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPanelZoomAndDragToolsUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;

		public NPanelZoomAndDragToolsUC()
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
			this.SuspendLayout();
			// 
			// NPanelZoomAndDragToolsUC
			// 
			this.Name = "NPanelZoomAndDragToolsUC";
			this.Size = new System.Drawing.Size(180, 200);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Panel Zoom And Drag Tools");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NPolarChart chart = new NPolarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.DisplayOnLegend = nChartControl1.Legends[0];
			chart.Depth = 5;
			chart.Width = 70.0f;
			chart.Height = 70.0f;

			// setup polar axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.Polar).ScaleConfigurator;
			linearScale.RoundToTickMax = true;
			linearScale.RoundToTickMin = true;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

			NScaleStripStyle strip = new NScaleStripStyle();
			strip.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.Beige));
			strip.Interlaced = true;
			strip.SetShowAtWall(ChartWallType.Polar, true);
			linearScale.StripStyles.Add(strip);

			// setup polar angle axis
			NAngularScaleConfigurator angularScale = (NAngularScaleConfigurator)chart.Axis(StandardAxis.PolarAngle).ScaleConfigurator;
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);
			strip = new NScaleStripStyle();
			strip.FillStyle = new NColorFillStyle(Color.FromArgb(125, 192, 192, 192));
			strip.Interlaced = true;
			strip.SetShowAtWall(ChartWallType.Polar, true);
			angularScale.StripStyles.Add(strip);

			// add a const line
			NAxisConstLine line = chart.Axis(StandardAxis.Polar).ConstLines.Add();
			line.Value = 50;
			line.StrokeStyle.Color = Color.SlateBlue;
			line.StrokeStyle.Width = new NLength(1, NGraphicsUnit.Pixel);

			// create a polar line series
			NPolarLineSeries series1 = new NPolarLineSeries();
			chart.Series.Add(series1);
			series1.Name = "Series 1";
			series1.CloseContour = true;
			series1.DataLabelStyle.Visible = false;
			series1.MarkerStyle.Visible = false;
			series1.MarkerStyle.Width = new NLength(1, NRelativeUnit.ParentPercentage);
			series1.MarkerStyle.Height = new NLength(1, NRelativeUnit.ParentPercentage);
			Curve1(series1, 50);

			// create a polar line series
			NPolarLineSeries series2 = new NPolarLineSeries();
			chart.Series.Add(series2);
			series2.Name = "Series 2";
			series2.CloseContour = true;
			series2.DataLabelStyle.Visible = false;
			series2.MarkerStyle.Visible = false;
			series2.MarkerStyle.Width = new NLength(1, NRelativeUnit.ParentPercentage);
			series2.MarkerStyle.Height = new NLength(1, NRelativeUnit.ParentPercentage);
			Curve2(series2, 100);

			// create a polar line series
			NPolarLineSeries series3 = new NPolarLineSeries();
			chart.Series.Add(series3);
			series3.Name = "Series 3";
			series3.CloseContour = false;
			series3.DataLabelStyle.Visible = false;
			series3.MarkerStyle.Visible = false;
			series3.MarkerStyle.Width = new NLength(1, NRelativeUnit.ParentPercentage);
			series3.MarkerStyle.Height = new NLength(1, NRelativeUnit.ParentPercentage);
			Curve3(series3, 100);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Controller.Selection.Add(chart);

			nChartControl1.Controller.Tools.Add(new NPanelZoomTool());
			nChartControl1.Controller.Tools.Add(new NPanelPanTool());
		}

		internal static void Curve1(NPolarSeries series, int count)
		{
			series.Values.Clear();
			series.Angles.Clear();

			double angleStep = 2 * Math.PI / count;

			for (int i = 0; i < count; i++)
			{
				double angle = i * angleStep;
				double radius = 1 + Math.Cos(angle);

				series.Values.Add(radius);
				series.Angles.Add(angle * 180 / Math.PI);
			}
		}
		internal static void Curve2(NPolarSeries series, int count)
		{
			series.Values.Clear();
			series.Angles.Clear();

			double angleStep = 2 * Math.PI / count;

			for (int i = 0; i < count; i++)
			{
				double angle = i * angleStep;
				double radius = 0.2 + 1.7 * Math.Sin(2 * angle) + 1.7 * Math.Cos(2 * angle);

				radius = Math.Abs(radius);

				series.Values.Add(radius);
				series.Angles.Add(angle * 180 / Math.PI);
			}
		}
		internal static void Curve3(NPolarSeries series, int count)
		{
			series.Values.Clear();
			series.Angles.Clear();

			double angleStep = 4 * Math.PI / count;

			for (int i = 0; i < count; i++)
			{
				double angle = i * angleStep;
				double radius = 0.2 + angle / 5.0;

				series.Values.Add(radius);
				series.Angles.Add(angle * 180 / Math.PI);
			}
		}
	}
}
