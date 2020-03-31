using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NXYScatterPointUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton NewDataButton;
		private Nevron.UI.WinForm.Controls.NCheckBox AxesRoundToTick;
		private Nevron.UI.WinForm.Controls.NCheckBox InflateMarginsCheck;
		private System.ComponentModel.Container components = null;

		public NXYScatterPointUC()
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
			this.NewDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.AxesRoundToTick = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.InflateMarginsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// NewDataButton
			// 
			this.NewDataButton.Location = new System.Drawing.Point(8, 8);
			this.NewDataButton.Name = "NewDataButton";
			this.NewDataButton.Size = new System.Drawing.Size(161, 24);
			this.NewDataButton.TabIndex = 0;
			this.NewDataButton.Text = "New Data";
			this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			// 
			// AxesRoundToTick
			// 
			this.AxesRoundToTick.ButtonProperties.BorderOffset = 2;
			this.AxesRoundToTick.Location = new System.Drawing.Point(8, 46);
			this.AxesRoundToTick.Name = "AxesRoundToTick";
			this.AxesRoundToTick.Size = new System.Drawing.Size(161, 19);
			this.AxesRoundToTick.TabIndex = 1;
			this.AxesRoundToTick.Text = "Axes Round To Tick";
			this.AxesRoundToTick.CheckedChanged += new System.EventHandler(this.AxesRoundToTick_CheckedChanged);
			// 
			// InflateMarginsCheck
			// 
			this.InflateMarginsCheck.ButtonProperties.BorderOffset = 2;
			this.InflateMarginsCheck.Location = new System.Drawing.Point(8, 72);
			this.InflateMarginsCheck.Name = "InflateMarginsCheck";
			this.InflateMarginsCheck.Size = new System.Drawing.Size(161, 20);
			this.InflateMarginsCheck.TabIndex = 2;
			this.InflateMarginsCheck.Text = "Inflate Margins";
			this.InflateMarginsCheck.CheckedChanged += new System.EventHandler(this.InflateMarginsCheck_CheckedChanged);
			// 
			// NXYScatterPointUC
			// 
			this.Controls.Add(this.InflateMarginsCheck);
			this.Controls.Add(this.AxesRoundToTick);
			this.Controls.Add(this.NewDataButton);
			this.Name = "NXYScatterPointUC";
			this.Size = new System.Drawing.Size(180, 106);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Scatter Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];

    		// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// add a point series
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.Name = "Point Series";
			point.DataLabelStyle.Visible = false;
			point.FillStyle = new NColorFillStyle(Color.FromArgb(160, DarkOrange));
			point.BorderStyle.Width = new NLength(0);
			point.Size = new NLength(1, NRelativeUnit.ParentPercentage);
			point.PointShape = PointShape.Ellipse;
			point.UseXValues = true;

			GenerateXYData(point);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			AxesRoundToTick.Checked = true;
			InflateMarginsCheck.Checked = true;
		}
		private void GenerateXYData(NPointSeries series)
		{
			series.ClearDataPoints();

			for (int i = 0; i < 1000; i++)
			{
				double u1 = Random.NextDouble();
				double u2 = Random.NextDouble();

				if (u1 == 0)
					u1 += 0.0001;

				if(u2 == 0)
					u2 += 0.0001;

				double z0 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
				double z1 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);

				series.XValues.Add(z0);
				series.Values.Add(z1);
			}
 		}

		private void NewDataButton_Click(object sender, System.EventArgs e)
		{
			NPointSeries point = (NPointSeries)nChartControl1.Charts[0].Series[0];
			GenerateXYData(point);
			nChartControl1.Refresh();		
		}
		private void InflateMarginsCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			series.InflateMargins = InflateMarginsCheck.Checked;
			nChartControl1.Refresh();
		}
		private void AxesRoundToTick_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			NStandardScaleConfigurator linearScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			linearScale.RoundToTickMin = AxesRoundToTick.Checked;
			linearScale.RoundToTickMax = AxesRoundToTick.Checked;

			linearScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.RoundToTickMin = AxesRoundToTick.Checked;
			linearScale.RoundToTickMax = AxesRoundToTick.Checked;

			nChartControl1.Refresh();
		}
	}
}
