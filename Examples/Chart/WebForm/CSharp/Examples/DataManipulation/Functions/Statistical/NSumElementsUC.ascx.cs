using System;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart.Functions;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NSumElementsUC : NExampleUC
	{

		private NChart nChart;
		private NFunctionCalculator nFuncCalculator;
		private NBarSeries nBar;
		private NLineSeries nLine;
	
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // add header
            NLabel header = nChartControl1.Labels.AddHeader("Sum of Data Points");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

            // setup legend
            NLegend legend = nChartControl1.Legends[0];
            legend.Location = new NPointL(legend.Location.X, new NLength(15, NRelativeUnit.ParentPercentage));
            legend.Data.MarkSize = new NSizeL(5, 5);

			nChart = nChartControl1.Charts[0];
			nChart.Enable3D = true;
			nFuncCalculator = new NFunctionCalculator();

			if (!IsPostBack)
			{
				// form controls
				GroupingDropDownList.Items.Add("Do not group");
				GroupingDropDownList.Items.Add("Group by every 2 values");
				GroupingDropDownList.Items.Add("Group by every 3 values");
				GroupingDropDownList.Items.Add("Group by every 4 values");
				GroupingDropDownList.SelectedIndex = 0;

				DataDropDownList.Items.Add("Positive");
				DataDropDownList.Items.Add("Positive and Negative");
				DataDropDownList.SelectedIndex = 0;
			}

			
			// setup chart
			nChart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			nChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
			nChart.BoundsMode = BoundsMode.Stretch;
			nChart.Location = new NPointL(
				new NLength(10, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			nChart.Size = new NSizeL(
				new NLength(70, NRelativeUnit.ParentPercentage),
				new NLength(75, NRelativeUnit.ParentPercentage));

			nChart.Axis(StandardAxis.Depth).Visible = false;
			nChart.Wall(ChartWallType.Left).Visible = false;
			nChart.Wall(ChartWallType.Floor).Visible = false;

			// setup X axis
			NOrdinalScaleConfigurator ordinalScale = (NOrdinalScaleConfigurator)nChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			ordinalScale.DisplayDataPointsBetweenTicks = false;

			// add a line series for the function
			nLine = (NLineSeries)nChart.Series.Add(SeriesType.Line);
			nLine.MarkerStyle.Visible = true;
			nLine.MarkerStyle.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			nLine.MarkerStyle.FillStyle = new NColorFillStyle(Color.Crimson);
			nLine.BorderStyle.Color = Color.Red;
			nLine.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			nLine.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			nLine.DisplayOnAxis(StandardAxis.PrimaryX, false);
			nLine.DisplayOnAxis(StandardAxis.SecondaryX, true);
			nLine.Legend.Mode = SeriesLegendMode.None;
			nLine.Legend.TextStyle = new NTextStyle(new NFontStyle("Arial", 7));

			// add the bar series
			nBar = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			nBar.Name = "Bar1";
			nBar.Values.Name = "values";
			nBar.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			nBar.MultiBarMode = MultiBarMode.Series;
			nBar.DataLabelStyle.Visible = false;
			nBar.Legend.Mode = SeriesLegendMode.DataPoints;
			nBar.BarShape = BarShape.SmoothEdgeBar;
			nBar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			nBar.FillStyle = new NColorFillStyle(Color.Orange);
			nBar.Legend.TextStyle = new NTextStyle(new NFontStyle("Arial", 7));

			if (DataDropDownList.SelectedIndex == 0)
			{
				nBar.Values.FillRandomRange(Random, 12, 0, 50);
			}
			else
			{
				nBar.Values.FillRandomRange(Random, 12, -25, 25);
			}

			
			// set the function argument
			nFuncCalculator.Arguments.Add(nBar.Values);
			CalcFunction();
		}

		private void CalcFunction()
		{
			StringBuilder sb = new StringBuilder("SUM(values");

			switch(GroupingDropDownList.SelectedIndex)
			{
				case 0:
					sb.Append(")");
					break;
				case 1:
					sb.Append("; 2)");
					break;
				case 2:
					sb.Append("; 3)");
					break;
				case 3:
					sb.Append("; 4)");
					break;
			}

			nFuncCalculator.Expression = sb.ToString();
			ExpressionTextBox.Text = nFuncCalculator.Expression;

			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			if(GroupingDropDownList.SelectedIndex == 0)
			{
				// draw a constline if there is no grouping
				SetConstline();
			}
			else
			{
				// otherwise use the line series
				nChart.Axis(StandardAxis.PrimaryY).ConstLines.Clear();

				nLine.Values = nFuncCalculator.Calculate();
				nLine.Values.ValueFormatter = new NNumericValueFormatter("0.00");
				nLine.Visible = true;

				SumTextBox.Text = "";
			}
		}

		private void SetConstline()
		{
			NAxis axis = nChart.Axis(StandardAxis.PrimaryY);

			// add a constline if necessary
			if(axis.ConstLines.Count == 0)
			{
				axis.ConstLines.Add();
			}

			// the line series won't be used
			nLine.Visible = false;

			// calc the sum of the elements
            NDataSeriesDouble ds = nFuncCalculator.Calculate();

			// add a new constline
			NAxisConstLine cl = axis.ConstLines[0];
			cl.StrokeStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			cl.StrokeStyle.Color = Color.Red;
			cl.Value = (double)ds.GetValueForIndex(0);

			SumTextBox.Text = cl.Value.ToString();

			// set proper range for the axis, so that it includes the constline
			if(cl.Value >= 0)
			{
				// if the sum is positive - compare it to the largest value
				nFuncCalculator.Expression = "MAX(values)";
				ds = nFuncCalculator.Calculate();

				double dMax = (double)ds.GetValueForIndex(0);

				if(cl.Value > dMax)
					dMax = cl.Value;

				axis.View = new NRangeAxisView(new NRange1DD(0, dMax), false, true);
			}
			else
			{
				// if the sum is negative - compare it to the smallest value
				nFuncCalculator.Expression = "MIN(values)";
				ds = nFuncCalculator.Calculate();

				double dMin = (double)ds.GetValueForIndex(0);

				if(cl.Value < dMin)
					dMin = cl.Value;

				axis.View = new NRangeAxisView(new NRange1DD(dMin, 0), true, false);
			}
		}
	}
}
