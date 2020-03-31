using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
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
	public class NXYZMultiSeriesPointUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NPointSeries m_Point1;
		private NPointSeries m_Point2;
		private NPointSeries m_Point3;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowPoint1;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowPoint2;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowPoint3;
		private System.ComponentModel.Container components = null;

		public NXYZMultiSeriesPointUC()
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
			this.ShowPoint1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowPoint2 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowPoint3 = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// ShowPoint1
			// 
			this.ShowPoint1.ButtonProperties.BorderOffset = 2;
			this.ShowPoint1.Location = new System.Drawing.Point(10, 10);
			this.ShowPoint1.Name = "ShowPoint1";
			this.ShowPoint1.Size = new System.Drawing.Size(132, 24);
			this.ShowPoint1.TabIndex = 0;
			this.ShowPoint1.Text = "Show Point 1";
			this.ShowPoint1.CheckedChanged += new System.EventHandler(this.ShowPoint1_CheckedChanged);
			// 
			// ShowPoint2
			// 
			this.ShowPoint2.ButtonProperties.BorderOffset = 2;
			this.ShowPoint2.Location = new System.Drawing.Point(10, 37);
			this.ShowPoint2.Name = "ShowPoint2";
			this.ShowPoint2.Size = new System.Drawing.Size(132, 24);
			this.ShowPoint2.TabIndex = 1;
			this.ShowPoint2.Text = "Show Point 2";
			this.ShowPoint2.CheckedChanged += new System.EventHandler(this.ShowPoint2_CheckedChanged);
			// 
			// ShowPoint3
			// 
			this.ShowPoint3.ButtonProperties.BorderOffset = 2;
			this.ShowPoint3.Location = new System.Drawing.Point(10, 64);
			this.ShowPoint3.Name = "ShowPoint3";
			this.ShowPoint3.Size = new System.Drawing.Size(132, 24);
			this.ShowPoint3.TabIndex = 2;
			this.ShowPoint3.Text = "Show Point 3";
			this.ShowPoint3.CheckedChanged += new System.EventHandler(this.ShowPoint3_CheckedChanged);
			// 
			// NXYZMultiSeriesPointUC
			// 
			this.Controls.Add(this.ShowPoint3);
			this.Controls.Add(this.ShowPoint2);
			this.Controls.Add(this.ShowPoint1);
			this.Name = "NXYZMultiSeriesPointUC";
			this.Size = new System.Drawing.Size(180, 115);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Multiple XYZ Scatter Point Series");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Enable3D = true;
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Depth = 55.0f;
			m_Chart.Width = 55.0f;
			m_Chart.Height = 55.0f;

			// Configure all axes to use linear scale
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			linearScale = new NLinearScaleConfigurator();
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

			// add point series
			m_Point1 = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			m_Point1.Name = "Point 1";
			m_Point1.PointShape = PointShape.Bar;
			m_Point1.Size = new NLength(2.4f, NRelativeUnit.ParentPercentage);
			m_Point1.DataLabelStyle.Visible = false;
			m_Point1.UseXValues = true;
			m_Point1.UseZValues = true;
			m_Point1.InflateMargins = true;

			m_Point2 = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			m_Point2.Name = "Point 2";
			m_Point2.PointShape = PointShape.Bar;
			m_Point2.Size = new NLength(2.4f, NRelativeUnit.ParentPercentage);
			m_Point2.DataLabelStyle.Visible = false;
			m_Point2.UseXValues = true;
			m_Point2.UseZValues = true;
			m_Point2.InflateMargins = true;

			m_Point3 = (NPointSeries)m_Chart.Series.Add(SeriesType.Point);
			m_Point3.Name = "Point 3";
			m_Point3.PointShape = PointShape.Bar;
			m_Point3.Size = new NLength(2.4f, NRelativeUnit.ParentPercentage);
			m_Point3.DataLabelStyle.Visible = false;
			m_Point3.UseXValues = true;
			m_Point3.UseZValues = true;
			m_Point3.InflateMargins = true;

			// fill with random data 
			m_Point1.Values.FillRandomRange(Random, 10, 0, 50);
			m_Point1.XValues.FillRandomRange(Random, 10, 0, 50);
			m_Point1.ZValues.FillRandomRange(Random, 10, 0, 50);

			m_Point2.Values.FillRandomRange(Random, 10, 25, 75);
			m_Point2.XValues.FillRandomRange(Random, 10, 25, 75);
			m_Point2.ZValues.FillRandomRange(Random, 10, 25, 75);

			m_Point3.Values.FillRandomRange(Random, 10, 75, 125);
			m_Point3.XValues.FillRandomRange(Random, 10, 75, 125);
			m_Point3.ZValues.FillRandomRange(Random, 10, 75, 125);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			ShowPoint1.Checked = true;
			ShowPoint2.Checked = true;
			ShowPoint3.Checked = true;
		}

		private void ShowPoint1_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Point1.Visible = ShowPoint1.Checked;
			nChartControl1.Refresh();
		}
		private void ShowPoint2_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Point2.Visible = ShowPoint2.Checked;
			nChartControl1.Refresh();
		}
		private void ShowPoint3_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Point3.Visible = ShowPoint3.Checked;
			nChartControl1.Refresh();
		}
	}
}
