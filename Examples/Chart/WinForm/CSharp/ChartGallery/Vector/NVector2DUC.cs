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
	public class NVector2DUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;

		public NVector2DUC()
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
			// NVector2DUC
			// 
			this.Name = "NVector2DUC";
			this.Size = new System.Drawing.Size(180, 128);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("2D Vector Field");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = false;
			chart.Width = 55.0f;
			chart.Height = 55.0f;

			// setup X axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };
			linearScale.InnerMajorTickStyle.Visible = false;

			// setup Y axis
			linearScale = new NLinearScaleConfigurator();
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;
			linearScale.RoundToTickMin = false;
			linearScale.RoundToTickMax = false;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { };
			linearScale.InnerMajorTickStyle.Visible = false;

			// setup shape series
			NVectorSeries vectorSeries = (NVectorSeries)chart.Series.Add(SeriesType.Vector);
			vectorSeries.FillStyle = new NColorFillStyle(Color.Red);
			vectorSeries.BorderStyle.Color = Color.DarkRed;
			vectorSeries.DataLabelStyle.Visible = false;
			vectorSeries.InflateMargins = true;
			vectorSeries.UseXValues = true;
			vectorSeries.MinArrowHeadSize = new NSizeL(2, 3);
			vectorSeries.MaxArrowHeadSize = new NSizeL(4, 6);

			// fill data
			FillData(vectorSeries);

			// apply layout
			ConfigureStandardLayout(chart, title, null);
		}

		private void FillData(NVectorSeries vectorSeries)
		{
			double x = 0, y = 0;
			int k = 0;

			for (int i = 0; i < 10; i++)
			{
				x = 1;
				y += 1;

				for (int j = 0; j < 10; j++)
				{
					x += 1;

					double dx = Math.Sin(x / 3.0) * Math.Cos((x - y) / 4.0);
					double dy = Math.Cos(y / 8.0) * Math.Cos(y / 4.0);

					vectorSeries.XValues.Add(x);
					vectorSeries.Values.Add(y);
					vectorSeries.X2Values.Add(x + dx);
					vectorSeries.Y2Values.Add(y + dy);

					vectorSeries.BorderStyles[k] = new NStrokeStyle(1, ColorFromVector(dx, dy));
					k++;
				}
			}		
		}
		private Color ColorFromVector(double dx, double dy)
		{
			double length = Math.Sqrt(dx * dx + dy * dy);

			double sq2 = Math.Sqrt(2);

			int r = (int)((255 / sq2) * length);
			int g = 20;
			int b = (int)((255 / sq2) * (sq2 - length));

			return Color.FromArgb(r, g, b);
		}
	}
}
