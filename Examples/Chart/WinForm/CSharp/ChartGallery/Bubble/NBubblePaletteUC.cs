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
	public class NBubblePaletteUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBubbleSeries m_Bubble;
		private System.ComponentModel.Container components = null;

		public NBubblePaletteUC()
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
			// NBubblePaletteUC
			// 
			this.Name = "NBubblePaletteUC";
			this.Size = new System.Drawing.Size(180, 389);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Bubble Palette");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

            // add interlace stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            stripStyle.SetShowAtWall(ChartWallType.Left, true);
            linearScale.StripStyles.Add(stripStyle);

			NOrdinalScaleConfigurator ordinalScale = m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add a bubble series
			m_Bubble = (NBubbleSeries)m_Chart.Series.Add(SeriesType.Bubble);
			m_Bubble.DataLabelStyle.VertAlign = VertAlign.Center;
			m_Bubble.DataLabelStyle.Visible = false;
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Bubble.Legend.Format = "Size <size>, Value <value>";
			m_Bubble.MinSize = new NLength(7.0f, NRelativeUnit.ParentPercentage);
			m_Bubble.MaxSize = new NLength(16.0f, NRelativeUnit.ParentPercentage);

			for (int i = 0; i < 10; i++)
			{
				m_Bubble.Values.Add(i);
				m_Bubble.Sizes.Add(i * 10 + 10);
			}

			m_Bubble.InflateMargins = true;

			NPalette palette = new NPalette();
			palette.SmoothPalette = true;
			palette.Clear();
			palette.Add(0, Color.Green);
			palette.Add(60, Color.Yellow);
			palette.Add(120, Color.Red);

			m_Bubble.Palette = palette;

			// apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends[0]);

		}
	}
}
