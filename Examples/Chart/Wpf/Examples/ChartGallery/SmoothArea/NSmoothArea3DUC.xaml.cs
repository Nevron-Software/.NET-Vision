using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NSmoothArea3DUC : NExampleBaseUC
	{
		private const int nValuesCount = 6;

		public NSmoothArea3DUC()
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
				return "Smooth Area 3D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates a 3D Smooth Area chart.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("3D Smooth Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legends
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// add interlaced stripe
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// add the area series
			NSmoothAreaSeries area = (NSmoothAreaSeries)chart.Series.Add(SeriesType.SmoothArea);
			area.DataLabelStyle.Visible = false;
			area.MarkerStyle.Visible = true;
			area.MarkerStyle.PointShape = PointShape.Cylinder;
			area.MarkerStyle.AutoDepth = true;
			area.MarkerStyle.Width = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			area.MarkerStyle.Height = new NLength(1.4f, NRelativeUnit.ParentPercentage);

			GenreateYValues(nValuesCount);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// configure interactivity
			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// init form controls
			ShowMarkersCheckBox.IsChecked = true;
			ShowDropLinesCheckBox.IsChecked = false;
			NExampleHelpers.FillComboWithEnumValues(AreaOriginModeComboBox, typeof(SeriesOriginMode));
			AreaOriginModeComboBox.SelectedIndex = 0;
			OriginValueTextBox.Text = "0";
		}

		private void GenreateYValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries series = (NSeries)chart.Series[0];

			series.Values.Clear();

			for (int i = 0; i < nCount; i++)
			{
				series.Values.Add(5 + Random.NextDouble() * 10);
			}
		}
		private void GenreateXValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NXYScatterSeries series = (NXYScatterSeries)chart.Series[0];

			series.XValues.Clear();

			DateTime dt = new DateTime(2005, 5, 24, 11, 0, 0);

			for (int i = 0; i < nCount; i++)
			{
				dt = dt.AddHours(12 + Random.NextDouble() * 60);

				series.XValues.Add(dt);
			}
		}

		private void ShowMarkersCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries series = (NSeries)chart.Series[0];

			series.MarkerStyle.Visible = (bool)ShowMarkersCheckBox.IsChecked;

			nChartControl1.Refresh();
		}

		private void ShowDropLinesCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothAreaSeries area = (NSmoothAreaSeries)chart.Series[0];

			area.DropLines = (bool)ShowDropLinesCheckBox.IsChecked;

			nChartControl1.Refresh();
		}

		private void AreaOriginModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothAreaSeries area = (NSmoothAreaSeries)chart.Series[0];

			area.OriginMode = (SeriesOriginMode)AreaOriginModeComboBox.SelectedIndex;

			nChartControl1.Refresh();

			OriginValueTextBox.IsEnabled = (area.OriginMode == SeriesOriginMode.CustomOrigin);
		}

		private void OriginValueTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothAreaSeries area = (NSmoothAreaSeries)chart.Series[0];

			try
			{
				area.Origin = Double.Parse(OriginValueTextBox.Text);
				nChartControl1.Refresh();
			}
			catch
			{
			}
		}
	}
}
