using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.Chart.Functions;


namespace Nevron.Examples.Chart.WebForm
{
	public partial class NBasicFunctionsUC : NExampleUC
	{
		private NFunctionCalculator funcCalculator;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// form controls
				ExpressionDropDownList.Items.Add("ADD(Green; Blue)");
				ExpressionDropDownList.Items.Add("SUB(Green; Blue)");
				ExpressionDropDownList.Items.Add("MUL(Green; Blue)");
				ExpressionDropDownList.Items.Add("DIV(Green; Blue)");
				ExpressionDropDownList.Items.Add("HIGH(Green; Blue)");
				ExpressionDropDownList.Items.Add("LOW(Green; Blue)");
				ExpressionDropDownList.SelectedIndex = 0;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// add header
			NLabel header = nChartControl1.Labels.AddHeader("Basic functions");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup legend
			NLegend legend = nChartControl1.Legends[0];
			legend.Location = new NPointL(legend.Location.X, new NLength(15, NRelativeUnit.ParentPercentage));
			legend.Data.MarkSize = new NSizeL(5,5);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal); 
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(8, NRelativeUnit.ParentPercentage),
				new NLength(17, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(75, NRelativeUnit.ParentPercentage),
				new NLength(75, NRelativeUnit.ParentPercentage));

			chart.Wall(ChartWallType.Left).Visible = false;
			chart.Wall(ChartWallType.Floor).Visible = false;
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add a line series for the function
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.Name = "Function";
			line.DataLabelStyle.Format = "<value>";
			line.MarkerStyle.PointShape = PointShape.Sphere;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			line.MarkerStyle.FillStyle = new NColorFillStyle(Color.Crimson);
			line.Legend.Mode = SeriesLegendMode.None;
			line.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			line.Legend.TextStyle = new NTextStyle(new NFontStyle("Arial", 7));

			// add the first bar
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.Name = "Bar1";
			bar1.Values.Name = "Green";
			bar1.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			bar1.MultiBarMode = MultiBarMode.Series;
			bar1.DataLabelStyle.Visible = false;
			bar1.Legend.Mode = SeriesLegendMode.DataPoints;
			bar1.FillStyle = new NColorFillStyle(Color.SeaGreen);
			bar1.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar1.BarShape = BarShape.CutEdgeBar;
			bar1.Legend.TextStyle = new NTextStyle(new NFontStyle("Arial", 7));

			// add the second bar
			NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar2.Name = "Bar2";
			bar2.Values.Name = "Blue";
			bar2.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			bar2.MultiBarMode = MultiBarMode.Clustered;
			bar2.DataLabelStyle.Visible = false;
			bar2.Legend.Mode = SeriesLegendMode.DataPoints;
			bar2.FillStyle = new NColorFillStyle(Color.CornflowerBlue);
			bar2.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar2.BarShape = BarShape.CutEdgeBar;
			bar2.Legend.TextStyle = new NTextStyle(new NFontStyle("Arial", 7));

			// fill with random data
			FillDataSeries(bar1.Values, 5);
			FillDataSeries(bar2.Values, 5);

			funcCalculator = new NFunctionCalculator();
			funcCalculator.Arguments.Clear();
			funcCalculator.Arguments.Add(bar1.Values);
			funcCalculator.Arguments.Add(bar2.Values);
			funcCalculator.Expression = ExpressionDropDownList.SelectedItem.Text;

            NDataSeriesDouble ds = funcCalculator.Calculate();

			if(ds == null)
			{
				line.Values.Clear();
			}
			else
			{
				line.Values = ds;
				line.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			}
		}

        private void FillDataSeries(NDataSeriesDouble ds, int nCount)
		{
			ds.Clear();

			for(int i = 0; i < nCount; i++)
			{
				ds.Add(Random.NextDouble() * 3);
			}
		}
	}
}
