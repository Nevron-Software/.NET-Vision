using System;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.Functions;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAverageMinMaxUC : NExampleUC
	{
		protected NBarSeries nBar;
		protected NLineSeries nLine;
		private NFunctionCalculator nFuncCalculator;
		protected NChart nChart;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				FunctionDropDownList.Items.Add("Average");
				FunctionDropDownList.Items.Add("Min");
				FunctionDropDownList.Items.Add("Max");
				FunctionDropDownList.SelectedIndex = 0;

				GroupingDropDownList.Items.Add("Do not group");
				GroupingDropDownList.Items.Add("Group by every 2 values");
				GroupingDropDownList.Items.Add("Group by every 3 values");
				GroupingDropDownList.Items.Add("Group by every 4 values");
				GroupingDropDownList.SelectedIndex = 0;

				DataDropDownList.Items.Add("Positive");
				DataDropDownList.Items.Add("Positive and Negative");
				DataDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // add header
            NLabel header = nChartControl1.Labels.AddHeader("Average, Min, Max");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			nFuncCalculator = new NFunctionCalculator();

			// setup legend
			NLegend legend = nChartControl1.Legends[0];
			legend.Location = new NPointL(legend.Location.X, new NLength(15, NRelativeUnit.ParentPercentage));
			legend.Data.MarkSize = new NSizeL(5,5);

			// setup chart
			nChart = nChartControl1.Charts[0];
			nChart.Enable3D = true;
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
			nLine.Legend.Mode = SeriesLegendMode.None;
			nLine.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			nLine.DisplayOnAxis(StandardAxis.PrimaryX, false);
			nLine.DisplayOnAxis(StandardAxis.SecondaryX, true);
			nLine.Legend.TextStyle = new NTextStyle(new NFontStyle("Arial", 7));

			// add the bar series
			nBar = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			nBar.Name = "Bar1";
			nBar.Values.Name = "values";
			nBar.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			nBar.MultiBarMode = MultiBarMode.Series;
			nBar.DataLabelStyle.Visible = false;
			nBar.Legend.Mode = SeriesLegendMode.DataPoints;
			nBar.BarShape = BarShape.Cylinder;
			nBar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			nBar.FillStyle = new NColorFillStyle(Color.DarkSalmon);
			nBar.Values.FillRandomRange(Random, 12, 0, 50);
			nBar.Legend.TextStyle = new NTextStyle(new NFontStyle("Arial", 7));

			if (DataDropDownList.SelectedIndex == 0)
				nBar.Values.FillRandomRange(Random, 12, 0, 50);
			else
				nBar.Values.FillRandomRange(Random, 12, -25, 25);
			
			BuildExpression();
			CalcFunction();
		}

		private void BuildExpression()
		{
			StringBuilder expr = new StringBuilder();

			// set the beginning of the expression according to the selected function
			switch(FunctionDropDownList.SelectedIndex)
			{
				case 0:
					expr.Append("AVERAGE(");
					break;
				case 1:
					expr.Append("MIN(");
					break;
				case 2:
					expr.Append("MAX(");
					break;
			}

			// append the first parameter
			expr.Append(nBar.Values.Name);

			// append the second parameter if needed
			switch(GroupingDropDownList.SelectedIndex)
			{
				case 0:
					expr.Append(")");
					break;
				case 1:
					expr.Append("; 2)");
					break;
				case 2:
					expr.Append("; 3)");
					break;
				case 3:
					expr.Append("; 4)");
					break;
			}

			ExpressionTextBox.Text = expr.ToString();

			// update the function calculator
			nFuncCalculator.Arguments.Clear();
			nFuncCalculator.Arguments.Add(nBar.Values);
			nFuncCalculator.Expression = ExpressionTextBox.Text;
		}

		private void CalcFunction()
		{
            NDataSeriesDouble ds = nFuncCalculator.Calculate();

			if(ds == null)
				return;

			nChart.Axis(StandardAxis.PrimaryY).ConstLines.Clear();
			nLine.Visible = false;

			if(GroupingDropDownList.SelectedIndex == 0)
			{
				// add a constline if there is no grouping
				NAxisConstLine cl = nChart.Axis(StandardAxis.PrimaryY).ConstLines.Add();
				cl.StrokeStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
				cl.StrokeStyle.Color = Color.Red;
				cl.Value = (double)ds.GetValueForIndex(0);
			}
			else
			{
				nLine.Visible = true;
				nLine.Values = ds;
				nLine.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			}
		}
	}
}
