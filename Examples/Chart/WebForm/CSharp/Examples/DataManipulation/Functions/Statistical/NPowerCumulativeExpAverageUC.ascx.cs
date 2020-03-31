using System;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Nevron.Examples.Framework.WebForm;
using Nevron.Chart.Functions;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NPowerCumulativeExpAverageUC : NExampleUC
	{
		private NChart nChart;
		private NFunctionCalculator nFuncCalculator;
		private NBarSeries nBar;
		private NLineSeries nLine;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// form controls
				FunctionDropDownList.Items.Add("Power");
				FunctionDropDownList.Items.Add("Cumulative");
				FunctionDropDownList.Items.Add("Exponential Average");
				FunctionDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithFloatValues(PowerDropDownList, -3, 3, 0.5f);
				PowerDropDownList.SelectedIndex = 10;

				WebExamplesUtilities.FillComboWithFloatValues(ExponentialWeightDropDownList, 0, 1, 0.1f);
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
			nLine.DataLabelStyle.Format = "<value>";
			nLine.DataLabelStyle.TextStyle.FontStyle.EmSize = new NLength(7, NGraphicsUnit.Point);
			nLine.MarkerStyle.Visible = true;
			nLine.MarkerStyle.Width = new NLength(0.08f, NRelativeUnit.ParentPercentage);
			nLine.MarkerStyle.Height = new NLength(0.08f, NRelativeUnit.ParentPercentage);
			nLine.MarkerStyle.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			nLine.MarkerStyle.FillStyle = new NColorFillStyle(Color.Crimson);
			nLine.BorderStyle.Color = Color.Red;
			nLine.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			nLine.Legend.Mode = SeriesLegendMode.None;
			nLine.Legend.TextStyle = new NTextStyle(new NFontStyle("Arial", 7));
			nLine.Values.ValueFormatter = new NNumericValueFormatter("0.00");

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
			nBar.FillStyle = new NColorFillStyle(Color.CornflowerBlue);
			nBar.Values.FillRandomRange(Random, 10, 0, 10);
			nBar.Legend.TextStyle = new NTextStyle(new NFontStyle("Arial", 7));

			nFuncCalculator.Arguments.Add(nBar.Values);
			nBar.Values.FillRandomRange(Random, 10, 0, 10);

			
			BuildExpression();
			CalculateFunction();
		}

		private void BuildExpression()
		{
			StringBuilder sb = new StringBuilder();

			switch(FunctionDropDownList.SelectedIndex)
			{
				case 0:
					PowerDropDownList.Enabled = true;
					ExponentialWeightDropDownList.Enabled = false;
					sb.AppendFormat(CultureInfo.InvariantCulture, "POW(values; {0})",  -3 + ((double)PowerDropDownList.SelectedIndex * 0.5f));
					break;
				case 1:
					PowerDropDownList.Enabled = false;
					ExponentialWeightDropDownList.Enabled = false;
					sb.Append("CUMSUM(values)");
					break;
				case 2:
					PowerDropDownList.Enabled = false;
					ExponentialWeightDropDownList.Enabled = true;
					sb.AppendFormat(CultureInfo.InvariantCulture, "EXPAVG(values; {0})", ((double)ExponentialWeightDropDownList.SelectedIndex) / 10);
					break;
			}

			nFuncCalculator.Expression = sb.ToString();
			ExpressionTextBox.Text = nFuncCalculator.Expression;
		}

		private void CalculateFunction()
		{
			nLine.Values = nFuncCalculator.Calculate();
			nLine.Values.ValueFormatter = new NNumericValueFormatter("0.00");
		}
	}
}
