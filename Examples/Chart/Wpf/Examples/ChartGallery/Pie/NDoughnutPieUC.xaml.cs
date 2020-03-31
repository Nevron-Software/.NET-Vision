using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.GraphicsCore;
using System.Diagnostics;
using System;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NDoughnutPieUC : NExampleBaseUC
	{
		private NPieChart m_PieChart;

		public NDoughnutPieUC()
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
				return "Doughnut Pie";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates how to create a doughnut pie.";
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
			NLabel title = nChartControl1.Labels.AddHeader("Doughnut Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			m_PieChart = new NPieChart();
			m_PieChart.Enable3D = true;
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_PieChart);

			m_PieChart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
			m_PieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);

			m_PieChart.DisplayOnLegend = nChartControl1.Legends[0];
			m_PieChart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			m_PieChart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));
			m_PieChart.InnerRadius = new NLength(10, NRelativeUnit.ParentPercentage);

			Random random = new Random();
			string[] labels = new string[] { "Ships", "Trains", "Automobiles", "Airplanes" };

			for (int i = 0; i < 4; i++)
			{
				NPieSeries pieSeries = new NPieSeries();

				// create a small detachment between pie rings
				pieSeries.BeginRadiusPercent = 10;
				pieSeries.PieStyle = PieStyle.Ring;

				m_PieChart.Series.Add(pieSeries);

				pieSeries.DataLabelStyle.ArrowLength = new NLength(0);
				pieSeries.DataLabelStyle.ArrowPointerLength = new NLength(0);
				pieSeries.DataLabelStyle.Format = "<percent>";

				if (i == 0)
				{
					pieSeries.Legend.Mode = SeriesLegendMode.DataPoints;
					pieSeries.Legend.Format = "<label>";
				}
				else
				{
					pieSeries.Legend.Mode = SeriesLegendMode.None;
				}

				pieSeries.LabelMode = PieLabelMode.Center;

				for (int j = 0; j < labels.Length; j++)
				{
					pieSeries.Values.Add(20 + random.Next(100));
					pieSeries.Labels.Add(labels[j]);
				}
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Refresh();
		}

		private void ChangeDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			foreach (NPieSeries pie in m_PieChart.Series)
			{
				pie.Values.FillRandomRange(Random, 4, 1, 60);
			}

			nChartControl1.Refresh();
		}
	}
}
