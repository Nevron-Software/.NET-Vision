using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.SmartShapes;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NSeriesCustomMarkerShapeUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;

		public NSeriesCustomMarkerShapeUC()
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
			// NSeriesCustomMarkerShapeUC
			// 
			this.Name = "NSeriesCustomMarkerShapeUC";
			this.Size = new System.Drawing.Size(180, 437);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Series Marker Attribute");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
            NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

            // add interlaced stripe to the Y axis
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            stripStyle.Interlaced = true;
            ((NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator).StripStyles.Add(stripStyle);

            chart.Axis(StandardAxis.Depth).Visible = false;

			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.LineSegmentShape = LineSegmentShape.Tape;
			line.InflateMargins = true;
			line.DepthPercent = 50;
			line.Legend.Mode = SeriesLegendMode.DataPoints;
			line.Name = "Line Series";
			line.Values.FillRandom(Random, 6);
			line.DataLabelStyle.Visible = false;
			line.ShadowStyle.Type = ShadowType.GaussianBlur;
			line.ShadowStyle.Offset = new NPointL(2, 2);
			line.ShadowStyle.Color = Color.FromArgb(88, 0, 0, 0);
			line.ShadowStyle.FadeLength = new NLength(5);
			line.MarkerStyle.Visible = true;

			NMarkerStyle marker = new NMarkerStyle();
			marker.FillStyle = new NColorFillStyle(Color.Red);
			marker.PointShape = PointShape.Custom;

			// Create a custom shape for this marker
			N2DSmartShapeFactory factory = new N2DSmartShapeFactory(new NColorFillStyle(Color.Red), new NStrokeStyle(1.0f, Color.Black), null);
			marker.CustomShape = factory.CreateShape(SmartShape2D.Trapezoid);
			marker.Visible = true;
			line.MarkerStyles[3] = marker;

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);
		}
	}
}
