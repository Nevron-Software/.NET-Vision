using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.Chart.Windows;
using Nevron.Dom;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NNonoverlappingLabelsUC : NExampleBaseUC
	{
		private NPieChart m_PieChart;
		private NPieSeries m_PieSeries;

		public NNonoverlappingLabelsUC()
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
				return "Non-overlapping Labels";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates the nonoverlapping pie labels feature. The pie chart labels are automatically positioned in a manner that doesn't allow them to overlap with each other. The label layout is similar to the spider mode.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Controller.Tools.Clear();
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Nonoverlapping Pie Labels");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(
				new NLength(50, NRelativeUnit.ParentPercentage),
				new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_PieChart = new NPieChart();
			m_PieChart.Enable3D = true;
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(m_PieChart);
			m_PieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
			m_PieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);
			m_PieChart.Location = new NPointL(
				new NLength(15, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			m_PieChart.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(70, NRelativeUnit.ParentPercentage));

			// setup pie series
			m_PieSeries = (NPieSeries)m_PieChart.Series.Add(SeriesType.Pie);
			m_PieSeries.LabelMode = PieLabelMode.SpiderNoOverlap;
			m_PieSeries.DataLabelStyle.Format = "<label>\n<percent>";
			m_PieSeries.Values.ValueFormatter = new NNumericValueFormatter("0.##");

			double[] arrValues =
			{
				4.17, 7.19, 5.62, 7.91, 15.28, 
				0.97, 1.3, 1.12, 8.54, 9.84, 
				2.05, 5.02, 1.42, 0.63, 3.01 
			};

			for (int i = 0; i < arrValues.Length; i++)
			{
				m_PieSeries.Values.Add(arrValues[i]);
			}

			SetTexts();

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			NExampleHelpers.FillComboWithEnumValues(PieStyleComboBox, typeof(PieStyle));
			PieStyleComboBox.SelectedIndex = 2;
			PieStyleComboBox_SelectionChanged(null, null);
		}

		private void GenerateRandomValues(int count)
		{
			m_PieSeries.Values.Clear();

			for (int i = 0; i < count; i++)
			{
				m_PieSeries.Values.Add(Random.NextDouble() * 10);
			}
		}
		private void SetTexts()
		{
			string[] arrTexts =
			{
				"Athletics",
				"Basketball",
				"Boxing",
				"Cycling",
				"Football",
				"Golf",
				"Handball",
				"Ice Hockey",
				"Motorsports",
				"Rugby",
				"Sailing",
				"Snooker",
				"Swimming",
				"Tennis",
				"Volleyball"
			};

			for (int i = 0; i < arrTexts.Length; i++)
			{
				m_PieSeries.Labels.Add(arrTexts[i]);
			}
		}

		private void ClockWiseCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			m_PieChart.ClockwiseDirection = (bool)ClockWiseCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void PieStyleComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_PieSeries.PieStyle = (PieStyle)PieStyleComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void ChangeDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GenerateRandomValues(15);
			nChartControl1.Refresh();
		}
	}
}
