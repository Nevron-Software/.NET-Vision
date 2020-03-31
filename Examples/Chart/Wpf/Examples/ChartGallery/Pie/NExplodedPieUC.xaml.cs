using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System.Diagnostics;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NExplodedPieUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NPieSeries m_Pie;

		public NExplodedPieUC()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Exploded Pie";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates an Exploded Pie Chart.\r\n" +
						"The Change Data button changes the pie values.\r\n" +
						"The Explode Smallest button explodes the smallest pie segment.\r\n" +
						"The Explode Biggest button explodes the largest pie segments.\r\n" +
						"The Remove Explosions button removes all explosions.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Exploded Pie Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_Chart = new NPieChart();
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

			m_Pie.AddDataPoint(new NDataPoint(12, "Ships"));
			m_Pie.AddDataPoint(new NDataPoint(42, "Trains"));
			m_Pie.AddDataPoint(new NDataPoint(56, "Cars"));
			m_Pie.AddDataPoint(new NDataPoint(23, "Buses"));
			m_Pie.AddDataPoint(new NDataPoint(18, "Airplanes"));

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			FillDetachments();
		}

		void FillDetachments()
		{
			m_Pie.Detachments.Clear();

			for (int i = 0; i < m_Pie.Values.Count; i++)
			{
				m_Pie.Detachments.Add(0.0);
			}
		}

		private void RemoveExplosionsButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// set all pie detachments to 0
			for (int i = 0; i < m_Pie.Detachments.Count; i++)
			{
				m_Pie.Detachments[i] = 0.0;
			}

			nChartControl1.Refresh();
		}

		private void ExplodeSmallestButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			int nIndex = m_Pie.Values.FindMinValue();
			m_Pie.Detachments[nIndex] = 5.0f;
			nChartControl1.Refresh();
		}

		private void ExplodeBiggestButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			int nIndex = m_Pie.Values.FindMaxValue();
			m_Pie.Detachments[nIndex] = 5.0f;
			nChartControl1.Refresh();
		}

		private void ChangeDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_Pie.Values.FillRandomRange(Random, 5, 1, 60);
			FillDetachments();

			nChartControl1.Refresh();
		}
	}
}
