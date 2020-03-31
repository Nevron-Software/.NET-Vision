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
	public class NXYZScatterStackUC : NExampleBaseUC
	{
		private System.ComponentModel.IContainer components = null;
		private Nevron.UI.WinForm.Controls.NButton btnNewData;
		private const int nItemsCount = 6;

		public NXYZScatterStackUC()
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
			this.btnNewData = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// btnNewData
			// 
			this.btnNewData.Location = new System.Drawing.Point(8, 8);
			this.btnNewData.Name = "btnNewData";
			this.btnNewData.Size = new System.Drawing.Size(164, 32);
			this.btnNewData.TabIndex = 1;
			this.btnNewData.Text = "New Data";
			this.btnNewData.Click += new System.EventHandler(this.btnNewData_Click);
			// 
			// NXYZScatterStackUC
			// 
			this.Controls.Add(this.btnNewData);
			this.Name = "NXYZScatterStackUC";
			this.Size = new System.Drawing.Size(180, 150);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			NChart chart = nChartControl1.Charts[0];

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Stack Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // set predefined projection and lighting
            chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight);
			chart.Width = 50;
			chart.Height = 35;
			chart.Depth = 50;
			chart.Enable3D = true;

			// configure the axes
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);

			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

            // add interlace stripes to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

			AddBarSeries(chart, MultiBarMode.Series);
			AddBarSeries(chart, MultiBarMode.Stacked);
			AddBarSeries(chart, MultiBarMode.Stacked);
			AddBarSeries(chart, MultiBarMode.Stacked);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

			GenerateData();
		}

		private void btnNewData_Click(object sender, System.EventArgs e)
		{
			GenerateData();
			nChartControl1.Refresh();
		}


		void AddBarSeries(NChart chart, MultiBarMode mode)
		{
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.MultiBarMode = mode;
			bar.UseXValues = true;
			bar.UseZValues = true;
			bar.DataLabelStyle.Visible = false;
			bar.InflateMargins = true;
		}

		void GenerateData()
		{
			NChart chart = nChartControl1.Charts[0];

			for(int i = 0; i < chart.Series.Count; i++)
			{
				NBarSeries bar = (NBarSeries)chart.Series[i];

				if(i == 0)
				{
					// the master series needs Y, X and Z values
					GenerateXYZData(bar);
				}
				else
				{
					// the other series need only Y values
					GenerateYData(bar);
				}
			}
		}

		void GenerateXYZData(NBarSeries bar)
		{
			bar.Values.Clear();
			bar.XValues.Clear();
			bar.ZValues.Clear();

			for(int i = 0; i < nItemsCount; i++)
			{
				bar.Values.Add(Random.NextDouble());
				bar.XValues.Add(Random.NextDouble() * 5);
				bar.ZValues.Add(Random.NextDouble() * 5);
			}
		}

		void GenerateYData(NBarSeries bar)
		{
			bar.Values.Clear();

			for(int i = 0; i < nItemsCount; i++)
			{
				bar.Values.Add(Random.NextDouble());
			}
		}
	}
}

