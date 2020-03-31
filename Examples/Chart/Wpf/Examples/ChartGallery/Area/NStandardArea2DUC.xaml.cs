using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStandardArea2DUC : NExampleBaseUC
	{
		public NStandardArea2DUC()
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
				return "Area 2D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a standard 2D area chart.\r\n" +
						"Use the controls on the right to modify commonly used properties";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("2D Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// no legend
			nChartControl1.Legends.Clear();

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Axis(StandardAxis.Depth).Visible = false;

			// setup X axis
			NOrdinalScaleConfigurator scaleX = chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator as NOrdinalScaleConfigurator;
			scaleX.AutoLabels = false;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;
			scaleX.DisplayDataPointsBetweenTicks = false;
			for (int i = 0; i < monthLetters.Length; i++)
			{
				scaleX.CustomLabels.Add(new NCustomValueLabel(i, monthLetters[i]));
			}

			// add interlaced stripe for Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };

			NLinearScaleConfigurator scaleY = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			scaleY.StripStyles.Add(stripStyle);

			// setup area series
			NAreaSeries area = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			area.Name = "Area Series";
			area.DataLabelStyle.Visible = false;
			area.DataLabelStyle.Format = "<value>";
			area.ShadowStyle.Type = ShadowType.Solid;
			area.ShadowStyle.Offset = new NPointL(3, 0);
			area.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0);

			area.Values.AddRange(monthValues);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// form controls
			NExampleHelpers.FillComboWithEnumValues(OriginModeComboBox, typeof(OriginMode));
			OriginModeComboBox.SelectedIndex = 0;
			OriginValueTextBox.Text = "0";

		}

		private void OriginModeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NAreaSeries area = (NAreaSeries)nChartControl1.Charts[0].Series[0];
			area.OriginMode = (SeriesOriginMode)OriginModeComboBox.SelectedIndex;

			nChartControl1.Refresh();

			OriginValueTextBox.IsEnabled = (area.OriginMode == SeriesOriginMode.CustomOrigin);
		}
		private void OriginValueTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			try
			{
				NAreaSeries area = (NAreaSeries)nChartControl1.Charts[0].Series[0];
				area.Origin = Double.Parse(OriginValueTextBox.Text);
				nChartControl1.Refresh();
			}
			catch
			{
			}
		}
	}
}
