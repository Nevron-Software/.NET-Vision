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

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRange2DUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;

		public NRange2DUC()
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
			// NRange2DUC
			// 
			this.Name = "NRange2DUC";
			this.Size = new System.Drawing.Size(180, 86);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("2D Range Series");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup X axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.InnerMajorTickStyle.Visible = false;

			// setup Y axis
			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.InnerMajorTickStyle.Visible = false;

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            linearScale.StripStyles.Add(stripStyle);

			// setup shape series
			NRangeSeries rangeSeries = (NRangeSeries)chart.Series.Add(SeriesType.Range);
			rangeSeries.DataLabelStyle.Visible = false;
			rangeSeries.UseXValues = true;
			rangeSeries.FillStyle = new NColorFillStyle(DarkOrange);
			rangeSeries.BorderStyle.Color = Color.DarkRed;

            // fill data
			FillData(rangeSeries);

			// apply layout
			ConfigureStandardLayout(chart, title, null);
		}

		private static void FillData(NRangeSeries rangeSeries)
		{
			double[] arrIntervals = new double[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 15, 30, 60 };
			double[] arrValues = new double[] { 4180, 13687, 18618, 19634, 17981, 7190, 16369, 3212, 4122, 9200, 6461, 3435 };

			int count = Math.Min(arrIntervals.Length, arrValues.Length);
			double x = 0;

			for (int i = 0; i < count; i++)
			{
				double dInterval = arrIntervals[i];
				double dValue = arrValues[i];

				rangeSeries.Values.Add(0);
				rangeSeries.XValues.Add(x);

				x += dInterval;

				rangeSeries.Y2Values.Add(dValue / dInterval);
				rangeSeries.X2Values.Add(x);
			}
		}
	}
}
