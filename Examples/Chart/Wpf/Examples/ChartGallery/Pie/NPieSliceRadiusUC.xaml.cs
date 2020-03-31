using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NPieSliceRadiusUC : NExampleBaseUC
	{
		public NPieSliceRadiusUC()
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
				return "Pie Slice Radius";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates how to create a pie chart where each pie segment has a different radius (specified as percentage of the pie total radius).";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Pie Slice Radius");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NPieChart pieChart = new NPieChart();
			pieChart.InnerRadius = new NLength(0);
			pieChart.Enable3D = true;
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(pieChart);

			pieChart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
			pieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);

			pieChart.DisplayOnLegend = nChartControl1.Legends[0];
			pieChart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			pieChart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));

			NPieSeries pieSeries = (NPieSeries)pieChart.Series.Add(SeriesType.Pie);
			pieSeries.PieEdgePercent = 30;
			pieSeries.PieStyle = PieStyle.SmoothEdgePie;
			pieSeries.Legend.Mode = SeriesLegendMode.DataPoints;
			pieSeries.Legend.Format = "<label> <percent>";
			pieSeries.UseBeginEndWidthPercents = true;

			for (int i = 0; i < 9; i++)
			{
				pieSeries.Values.Add(10 + i * 10);
				pieSeries.BeginWidthPercents.Add(0);
				pieSeries.EndWidthPercents.Add(10 + i * 10);
			}

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);
		}
	}
}
