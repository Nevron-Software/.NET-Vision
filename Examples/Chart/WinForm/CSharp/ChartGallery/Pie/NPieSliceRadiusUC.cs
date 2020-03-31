using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPieSliceRadiusUC : NExampleBaseUC
	{
		private NPieChart m_Chart;
		private NPieSeries m_Pie;
		private System.ComponentModel.Container components = null;

		public NPieSliceRadiusUC()
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
			// NPieSliceRadiusUC
			// 
			this.Name = "NPieSliceRadiusUC";
			this.Size = new System.Drawing.Size(180, 213);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Pie Slice Radius");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_Chart = new NPieChart();
			m_Chart.InnerRadius = new NLength(0);
			m_Chart.Enable3D = true;
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_Chart);

			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);

			m_Chart.DisplayOnLegend = nChartControl1.Legends[0];
			m_Chart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_Chart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));

			m_Pie = (NPieSeries)m_Chart.Series.Add(SeriesType.Pie);
			m_Pie.PieEdgePercent = 30;
			m_Pie.PieStyle = PieStyle.SmoothEdgePie;
			m_Pie.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Pie.Legend.Format = "<label> <percent>";
			m_Pie.UseBeginEndWidthPercents = true;

			for (int i = 0; i < 9; i++)
			{
				m_Pie.Values.Add(10 + i * 10);
				m_Pie.BeginWidthPercents.Add(0);
				m_Pie.EndWidthPercents.Add(10 + i * 10);
			}

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);
		}
	}
}