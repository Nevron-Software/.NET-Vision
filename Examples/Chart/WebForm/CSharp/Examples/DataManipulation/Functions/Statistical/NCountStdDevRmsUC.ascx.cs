using System;
using System.Drawing;
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
	public partial class NCountStdDevRmsUC : NExampleUC
	{
		private NChart nChart;
		private NFunctionCalculator nFuncCalculator;
		private NBarSeries nBar;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// form controls
				FunctionDropDownList.Items.Add("Count");
				FunctionDropDownList.Items.Add("Standard Deviation");
				FunctionDropDownList.Items.Add("Root Mean Square");
				FunctionDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // add header
            NLabel header = nChartControl1.Labels.AddHeader("Functions");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

            // align the legend
            NLegend legend = nChartControl1.Legends[0];
            legend.Location = new NPointL(legend.Location.X, new NLength(15, NRelativeUnit.ParentPercentage));
            legend.Data.MarkSize = new NSizeL(5, 5);

			nFuncCalculator = new NFunctionCalculator();

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

			// add a constline to diplay the function result
			NAxisConstLine cl = nChart.Axis(StandardAxis.PrimaryY).ConstLines.Add();
			cl.StrokeStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			cl.StrokeStyle.Color = Color.Red;
			cl.Value = 0;

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
			nBar.FillStyle = new NColorFillStyle(Color.DarkSeaGreen);
			nBar.Values.FillRandomRange(Random, 10, 0, 20);
			nBar.Legend.TextStyle = new NTextStyle(new NFontStyle("Arial", 7));

			// add argument
			nFuncCalculator.Arguments.Add(nBar.Values);
			nBar.Values.FillRandomRange(Random, 10, 0, 20);

			
			BuildExpression();
			CalculateFunction();
		}

		private void BuildExpression()
		{
			switch(FunctionDropDownList.SelectedIndex)
			{
				case 0:
					nFuncCalculator.Expression = "COUNT(values)";
					break;
				case 1:
					nFuncCalculator.Expression = "STDDEV(values)";
					break;
				case 2:
					nFuncCalculator.Expression = "POW(AVERAGE(POW(values; 2)); 0.5)";
					break;
			}

			ExpressionTextBox.Text = nFuncCalculator.Expression;
		}

		private void CalculateFunction()
		{
			NAxisConstLine cl = nChart.Axis(StandardAxis.PrimaryY).ConstLines[0];

            NDataSeriesDouble ds = nFuncCalculator.Calculate();

			cl.Value = (double)ds.GetValueForIndex(0);

			ResultTextBox.Text = cl.Value.ToString();
		}
	}
}
