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
	public class NRange3DUC : NExampleBaseUC
	{
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox ShapeCombo;
		private System.ComponentModel.Container components = null;

		public NRange3DUC()
		{
			InitializeComponent();

			ShapeCombo.FillFromEnum(typeof(BarShape));
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
			this.label1 = new System.Windows.Forms.Label();
			this.ShapeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Shape:";
			// 
			// ShapeCombo
			// 
			this.ShapeCombo.ListProperties.CheckBoxDataMember = "";
			this.ShapeCombo.ListProperties.DataSource = null;
			this.ShapeCombo.ListProperties.DisplayMember = "";
			this.ShapeCombo.Location = new System.Drawing.Point(5, 27);
			this.ShapeCombo.Name = "ShapeCombo";
			this.ShapeCombo.Size = new System.Drawing.Size(169, 21);
			this.ShapeCombo.TabIndex = 3;
			this.ShapeCombo.SelectedIndexChanged += new System.EventHandler(this.ShapeCombo_SelectedIndexChanged);
			// 
			// NRange3DUC
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ShapeCombo);
			this.Name = "NRange3DUC";
			this.Size = new System.Drawing.Size(180, 364);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = new NLabel("3D Range Series");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Projection.Type = ProjectionType.Perspective;
			chart.Projection.Rotation = -18;
			chart.Projection.Elevation = 13;
			chart.Depth = 55.0f;
			chart.Width = 55.0f;
			chart.Height = 55.0f;

			// setup X axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			chart.Axis(StandardAxis.PrimaryX).View = new NRangeAxisView(new NRange1DD(0, 20), true, true);

			// setup Y axis
			linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(0, 20), true, true);

			// setup Depth axis
			linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			chart.Axis(StandardAxis.Depth).View = new NRangeAxisView(new NRange1DD(0, 20), true, true);

			// setup shape series
			NRangeSeries rangeSeries = (NRangeSeries)chart.Series.Add(SeriesType.Range);
			rangeSeries.FillStyle = new NColorFillStyle(Color.Red);
			rangeSeries.BorderStyle.Color = Color.DarkRed;
			rangeSeries.Legend.Mode = SeriesLegendMode.None;
			rangeSeries.DataLabelStyle.Visible = false;
			rangeSeries.UseXValues = true;
			rangeSeries.UseZValues = true;

            // add data
			AddDataPoint(rangeSeries, 1, 5, 11, 17, 5, 9);
			AddDataPoint(rangeSeries, 4, 7, 15, 19, 16, 19);
			AddDataPoint(rangeSeries, 5, 15, 6, 11, 12, 18);
			AddDataPoint(rangeSeries, 9, 14, 2, 5, 3, 5);
			AddDataPoint(rangeSeries, 15, 19, 2, 5, 3, 5);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			ShapeCombo.SelectedIndex = 0;
		}

		private void AddDataPoint(NRangeSeries series, double x1, double x2, double y1, double y2, double z1, double z2)
		{
			series.XValues.Add(x1);
			series.X2Values.Add(x2);
			series.Values.Add(y1);
			series.Y2Values.Add(y2);
			series.ZValues.Add(z1);
			series.Z2Values.Add(z2);
		}

		private void ShapeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NRangeSeries rangeSeries = (NRangeSeries)nChartControl1.Charts[0].Series[0];
			rangeSeries.Shape = (BarShape)ShapeCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
	}
}
