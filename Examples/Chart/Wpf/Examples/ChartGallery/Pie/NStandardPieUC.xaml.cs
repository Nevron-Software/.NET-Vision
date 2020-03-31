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
	public partial class NStandardPieUC : NExampleBaseUC
	{
		public NStandardPieUC()
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
				return "Pie";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return	"This example demonstrates a 3D Pie Chart.\r\n" +
						"Use the controls on the right to modify some commonly used properties.";
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
			NLabel title = nChartControl1.Labels.AddHeader("3D Pie Chart Shapes");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.BottomRight);

			NPieChart pieChart = new NPieChart();
			pieChart.Enable3D = true;

			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(pieChart);

			NPointLightSource ls = new NPointLightSource();
			ls.CoordinateMode = LightSourceCoordinateMode.Camera;
			ls.Position = new NVector3DF(0, 0, 50);
			ls.Ambient = Color.FromArgb(30, 30, 30);
			ls.Diffuse = Color.FromArgb(180, 180, 180);
			ls.Specular = Color.FromArgb(100, 100, 100);

			pieChart.LightModel.LightSources.Clear();
			pieChart.LightModel.LightSources.Add(ls);

			pieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
			pieChart.Depth = 10;
			pieChart.DisplayOnLegend = nChartControl1.Legends[0];
			pieChart.Location = new NPointL(new NLength(20, NRelativeUnit.ParentPercentage), new NLength(20, NRelativeUnit.ParentPercentage));
			pieChart.Size = new NSizeL(new NLength(60, NRelativeUnit.ParentPercentage), new NLength(60, NRelativeUnit.ParentPercentage));
			pieChart.InnerRadius = new NLength(20, NRelativeUnit.ParentPercentage);

			NPieSeries pieSeries = (NPieSeries)pieChart.Series.Add(SeriesType.Pie);
			pieSeries.BorderStyle.Color = Color.LemonChiffon;
			pieSeries.DataLabelStyle.ArrowLength = new NLength(10, NGraphicsUnit.Point);
			pieSeries.DataLabelStyle.ArrowPointerLength = new NLength(0, NGraphicsUnit.Point);

			pieSeries.Legend.Mode = SeriesLegendMode.DataPoints;
			pieSeries.Legend.Format = "<label> <percent>";

			pieSeries.AddDataPoint(new NDataPoint(24, "Cars", new NColorFillStyle(Color.FromArgb(169, 121, 11))));
			pieSeries.AddDataPoint(new NDataPoint(18, "Airplanes", new NColorFillStyle(Color.FromArgb(157, 157, 92))));
			pieSeries.AddDataPoint(new NDataPoint(32, "Trains", new NColorFillStyle(Color.FromArgb(98, 152, 92))));
			pieSeries.AddDataPoint(new NDataPoint(23, "Ships", new NColorFillStyle(Color.FromArgb(111, 134, 181))));
			pieSeries.AddDataPoint(new NDataPoint(19, "Buses", new NColorFillStyle(Color.FromArgb(179, 63, 92))));

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor);
			styleSheet.Apply(nChartControl1.Document);

			// init controls
			NExampleHelpers.FillComboWithEnumValues(PieShapeComboBox, typeof(PieStyle));
			PieShapeComboBox.SelectedIndex = (int)PieStyle.Ring;

			NExampleHelpers.FillComboWithEnumValues(LabelModeComboBox, typeof(PieLabelMode));
			LabelModeComboBox.SelectedIndex = 0;

			EdgePercentScrollBar.Value = pieSeries.PieEdgePercent / 100.0f;
			OuterRadiusScrollBar.Value = pieChart.Radius.Value / 100.0f;
			InnerRadiusScrollBar.Value = pieChart.InnerRadius.Value / 100.0f;

			ArrowLengthScrollBar.Value = pieSeries.DataLabelStyle.ArrowLength.Value / 100.0f;
			ArrowPointerLengthScrollBar.Value = pieSeries.DataLabelStyle.ArrowPointerLength.Value / 100.0f;
			LabelConnectorLengthScrollBar.Value = pieSeries.ConnectorLength.Value / 100.0f;
			LeadOffArrowLengthScrollBar.Value = pieSeries.LeadOffArrowLength.Value / 100.0f;

			BeginAngleScrollBar.Value = pieChart.BeginAngle / 360.0;
			TotalAngleScrollBar.Value = pieChart.TotalAngle / 360.0;
		}

		private void PieShapeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];

			pie.PieStyle = (PieStyle)PieShapeComboBox.SelectedIndex;

			switch (pie.PieStyle)
			{
				case PieStyle.Pie:
				case PieStyle.Ring:
				case PieStyle.Torus:
					EdgePercentScrollBar.IsEnabled = false;
					break;

				case PieStyle.SmoothEdgePie:
				case PieStyle.SmoothEdgeRing:
				case PieStyle.CutEdgePie:
				case PieStyle.CutEdgeRing:
					EdgePercentScrollBar.IsEnabled = true;
					break;

				default:
					Debug.Assert(false);
					break;
			}

			switch (pie.PieStyle)
			{
				case PieStyle.Pie:
				case PieStyle.SmoothEdgePie:
				case PieStyle.CutEdgePie:
					InnerRadiusScrollBar.IsEnabled = false;
					break;

				case PieStyle.Ring:
				case PieStyle.Torus:
				case PieStyle.SmoothEdgeRing:
				case PieStyle.CutEdgeRing:
					InnerRadiusScrollBar.IsEnabled = true;
					break;

				default:
					Debug.Assert(false);
					break;
			}

			nChartControl1.Refresh();
		}

		private void EdgePercentScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];
			pie.PieEdgePercent = (float)EdgePercentScrollBar.Value * 100.0f;
			nChartControl1.Refresh();
		}

		private void OuterRadiusScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NPieChart pie = (NPieChart)nChartControl1.Charts[0];
			pie.Radius = new NLength((float)OuterRadiusScrollBar.Value * 100.0f, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}

		private void InnerRadiusScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NPieChart pie = (NPieChart)nChartControl1.Charts[0];
			pie.InnerRadius = new NLength((float)InnerRadiusScrollBar.Value * 100.0f, NRelativeUnit.ParentPercentage);
			nChartControl1.Refresh();
		}

		private void LabelModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];

			pie.LabelMode = (PieLabelMode)LabelModeComboBox.SelectedIndex;

			switch (pie.LabelMode)
			{
				case PieLabelMode.Center:
					ArrowLengthScrollBar.IsEnabled = false;
					ArrowPointerLengthScrollBar.IsEnabled = false;
					LabelConnectorLengthScrollBar.IsEnabled = false;
					LeadOffArrowLengthScrollBar.IsEnabled = false;
					break;

				case PieLabelMode.Rim:
				case PieLabelMode.Spider:
					ArrowLengthScrollBar.IsEnabled = true;
					ArrowPointerLengthScrollBar.IsEnabled = true;
					LabelConnectorLengthScrollBar.IsEnabled = false;
					LeadOffArrowLengthScrollBar.IsEnabled = false;
					break;

				case PieLabelMode.SpiderNoOverlap:
					ArrowLengthScrollBar.IsEnabled = false;
					ArrowPointerLengthScrollBar.IsEnabled = false;
					LabelConnectorLengthScrollBar.IsEnabled = true;
					LeadOffArrowLengthScrollBar.IsEnabled = true;
					break;
			}

			nChartControl1.Refresh();

		}

		private void ArrowLengthScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];
			pie.DataLabelStyle.ArrowLength = new NLength((float)ArrowLengthScrollBar.Value * 100.0f, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}

		private void PointerLengthScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];
			pie.DataLabelStyle.ArrowPointerLength = new NLength((float)ArrowPointerLengthScrollBar.Value * 100.0f, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}

		private void LabelConnectorLengthScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];
			pie.ConnectorLength = new NLength((float)LabelConnectorLengthScrollBar.Value * 100.0f, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}

		private void LeadOffArrowLengthScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NPieSeries pie = (NPieSeries)nChartControl1.Charts[0].Series[0];
			pie.LeadOffArrowLength = new NLength((float)LeadOffArrowLengthScrollBar.Value * 100.0f, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}

		private void BeginAngleScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NPieChart pie = (NPieChart)nChartControl1.Charts[0];
			pie.BeginAngle = (float)BeginAngleScrollBar.Value * 360.0f;
			nChartControl1.Refresh();
		}

		private void TotalAngleScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NPieChart pie = (NPieChart)nChartControl1.Charts[0];
			pie.TotalAngle = (float)TotalAngleScrollBar.Value * 360.0f;
			nChartControl1.Refresh();

		}
	}
}
