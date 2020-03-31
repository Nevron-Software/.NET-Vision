using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NParetoUC : NExampleBaseUC
	{
		private NChart m_Chart;
		private NBarSeries m_Bar;
		private NLineSeries m_Line;

		public NParetoUC()
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
				return "Pareto";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a pareto chart.\r\n" + 
						"The pareto chart consists of two elements:\r\n" +
						"1. Bar series with descending values\r\n" +
						"2. Line series which represents the accumulation of the bar values";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Pareto Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// setup the X axis
			NAxis axisX = m_Chart.Axis(StandardAxis.PrimaryX);
			NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)axisX.ScaleConfigurator;
			scaleX.InnerMajorTickStyle.Visible = false;

			// Setup the primary Y axis
			NAxis axisY1 = m_Chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator scaleY1 = (NLinearScaleConfigurator)axisY1.ScaleConfigurator;
			scaleY1.InnerMajorTickStyle.Visible = false;
			scaleY1.Title.Text = "Number of Occurences";

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			scaleY1.StripStyles.Add(stripStyle);

			// Setup the secondary Y axis
			NLinearScaleConfigurator scaleY2 = new NLinearScaleConfigurator();
			scaleY2.LabelValueFormatter = new NNumericValueFormatter("0%");
			scaleY2.InnerMajorTickStyle.Visible = false;
			scaleY2.Title.Text = "Cumulative Percent";
			NAxis axisY2 = m_Chart.Axis(StandardAxis.SecondaryY);
			axisY2.Visible = true;
			axisY2.ScaleConfigurator = scaleY2;
			axisY2.View = new NRangeAxisView(new NRange1DD(0, 1), true, true);

			// add the line series
			m_Line = (NLineSeries)m_Chart.Series.Add(SeriesType.Line);
			m_Line.Name = "Cumulative %";
			m_Line.DataLabelStyle.Visible = false;
			m_Line.MarkerStyle.Visible = true;
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder;
			m_Line.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			m_Line.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_Line.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			m_Line.ShadowStyle.Offset = new NPointL(2, 2);
			m_Line.ShadowStyle.FadeLength = new NLength(4);
			m_Line.DisplayOnAxis(StandardAxis.PrimaryY, false);
			m_Line.DisplayOnAxis(StandardAxis.SecondaryY, true);

			// add the bar series
			m_Bar = (NBarSeries)m_Chart.Series.Add(SeriesType.Bar);
			m_Bar.Name = "Bar Series";
			m_Bar.DataLabelStyle.Visible = false;
			m_Bar.ShadowStyle.Type = ShadowType.GaussianBlur;
			m_Bar.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0);
			m_Bar.ShadowStyle.Offset = new NPointL(3, 3);
			m_Bar.ShadowStyle.FadeLength = new NLength(4);

			// fill with random data and sort in descending order
			m_Bar.Values.FillRandomRange(Random, 10, 100, 700);
			m_Bar.Values.Sort(DataSeriesSortOrder.Descending);

			// calculate cumulative sum of the bar values
			int count = m_Bar.Values.Count;
			double cs = 0;
			double[] arrCumulative = new double[count];

			for (int i = 0; i < count; i++)
			{
				cs += m_Bar.Values.GetDoubleValue(i);
				arrCumulative[i] = cs;
			}

			if (cs > 0)
			{
				for (int i = 0; i < count; i++)
				{
					arrCumulative[i] /= cs;
				}

				m_Line.Values.AddRange(arrCumulative);
			}

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			NExampleHelpers.FillComboWithEnumValues(BarStyleComboBox, typeof(BarShape));
			BarStyleComboBox.SelectedIndex = 0;

			WidthPercentScrollBar.Value = m_Bar.WidthPercent / 100f;
		}

		private void BarStyleComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_Bar.BarShape = (BarShape)BarStyleComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void WidthPercentScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			m_Bar.WidthPercent = (float)WidthPercentScrollBar.Value * 100f;
			nChartControl1.Refresh();
		}

		private void DifferentFillStylesCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			if ((bool)DifferentFillStylesCheckBox.IsChecked)
			{
				Random random = new Random();
				for (int i = 0; i < m_Bar.Values.Count; i++)
				{
					m_Bar.FillStyles[i] = new NColorFillStyle(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
				}

				m_Bar.Legend.Mode = SeriesLegendMode.DataPoints;
			}
			else
			{
				m_Bar.FillStyles.Clear();
				m_Bar.Legend.Mode = SeriesLegendMode.Series;
			}

			nChartControl1.Refresh();
		}
/*
		private void StyleCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Bar.BarShape = (BarShape)StyleCombo.SelectedIndex;
			nChartControl1.Refresh();
		}
		private void DifferentFillStyles_CheckedChanged(object sender, System.EventArgs e)
		{

		}
		private void WidthScroll_Scroll(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_Bar.WidthPercent = WidthScroll.Value;
			nChartControl1.Refresh();
		}
		private void BarFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Bar.FillStyle, out fillStyleResult))
			{
				m_Bar.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void BarBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Bar.BorderStyle, out strokeStyleResult))
			{
				m_Bar.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void LineStyleButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Line.BorderStyle, out strokeStyleResult))
			{
				m_Line.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void MarkersFillButton_Click(object sender, System.EventArgs e)
		{
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(m_Line.MarkerStyle.FillStyle, out fillStyleResult))
			{
				m_Line.MarkerStyle.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}
		private void MarkersBorderButton_Click(object sender, System.EventArgs e)
		{
			NStrokeStyle strokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(m_Line.MarkerStyle.BorderStyle, out strokeStyleResult))
			{
				m_Line.MarkerStyle.BorderStyle = strokeStyleResult;
				nChartControl1.Refresh();
			}
		}
*/
	}
}
