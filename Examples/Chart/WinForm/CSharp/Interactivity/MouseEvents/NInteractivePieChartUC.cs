using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NInteractivePieChartUC : NExampleBaseUC
	{
		private System.ComponentModel.Container components = null;
		private NPieSeries m_Pie;
		private NFillStyle[] m_DefaultFillStyles;

		public NInteractivePieChartUC()
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
			// NInteractivePieChartUC
			// 
			this.Name = "NInteractivePieChartUC";
			this.Size = new System.Drawing.Size(180, 72);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Exploded Pie Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NChart chart = new NPieChart();
			nChartControl1.Panels.Add(chart);

			chart.Enable3D = true;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);

			chart.Size = new NSizeL(new NLength(60, NRelativeUnit.ParentPercentage),
									new NLength(60, NRelativeUnit.ParentPercentage));

			chart.Location = new NPointL(	new NLength(20, NRelativeUnit.ParentPercentage),
											new NLength(20, NRelativeUnit.ParentPercentage));

			m_Pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
			m_Pie.PieEdgePercent = 30;

            m_Pie.AddDataPoint(new NDataPoint(12, "Cars"));
            m_Pie.AddDataPoint(new NDataPoint(42, "Trains"));
            m_Pie.AddDataPoint(new NDataPoint(56, "Airplanes"));
            m_Pie.AddDataPoint(new NDataPoint(23, "Buses"));

            for (int i = 0; i < m_Pie.Values.Count; i++)
            {
                m_Pie.Detachments.Add(0);
            }

            m_DefaultFillStyles = new NFillStyle[4];
            NChartPalette palette = new NChartPalette();
            palette.SetPredefinedPalette(ChartPredefinedPalette.Winter);

            m_DefaultFillStyles[0] = new NColorFillStyle(palette.SeriesColors[0]);
            m_DefaultFillStyles[1] = new NColorFillStyle(palette.SeriesColors[1]);
            m_DefaultFillStyles[2] = new NColorFillStyle(palette.SeriesColors[2]);
            m_DefaultFillStyles[3] = new NColorFillStyle(palette.SeriesColors[3]);

            for (int i = 0; i < m_DefaultFillStyles.Length; i++)
            {
                m_Pie.FillStyles[i] = m_DefaultFillStyles[i];
            }

            SetPieDefaultFillStyles();

            m_Pie.PieStyle = PieStyle.SmoothEdgePie;

            m_Pie.Legend.Mode = SeriesLegendMode.DataPoints;
            m_Pie.Legend.Format = "<label> <percent>";

            // subscribe for control events
            nChartControl1.MouseDown += new MouseEventHandler(ChartControl_MouseDown);
            nChartControl1.MouseMove += new MouseEventHandler(ChartControl_MouseMove);
        }

        private void SetPieDefaultFillStyles()
        {
            for (int i = 0; i < m_Pie.FillStyles.Count; i++)
            {
				if ((double)m_Pie.Detachments[i] <= 0)
				{
					m_Pie.FillStyles[i] = m_DefaultFillStyles[i];
				}
            }
        }

        private void ChartControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            NHitTestResult hitTestResult = nChartControl1.HitTest(e.X, e.Y);

            if (hitTestResult.ChartElement == ChartElement.DataPoint)
            {
                for (int i = 0; i < m_Pie.Detachments.Count; i++)
                {
                    m_Pie.Detachments[i] = 0.0f;
                }

                SetPieDefaultFillStyles();

                m_Pie.FillStyles[hitTestResult.DataPointIndex] = new NColorFillStyle(Color.Red);
                m_Pie.Detachments[hitTestResult.DataPointIndex] = 5.0f;

                nChartControl1.Refresh();
            }
        }

        private void ChartControl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            NHitTestResult hitTestResult = nChartControl1.HitTest(e.X, e.Y);

            if (hitTestResult.ChartElement == ChartElement.DataPoint)
            {
                if ((double)m_Pie.Detachments[hitTestResult.DataPointIndex] > 0)
                    return;

                SetPieDefaultFillStyles();
                m_Pie.FillStyles[hitTestResult.DataPointIndex] = new NColorFillStyle(Color.Orange);
            }
            else
            {
                SetPieDefaultFillStyles();
            }

            nChartControl1.Refresh();
        }
	}
}
