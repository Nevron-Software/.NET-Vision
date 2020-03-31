using System;
using System.Drawing;
using System.Web.UI;
using Nevron.UI.WebForm.Controls;
using Nevron.Chart.Functions;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NInteractiveTrainSalesPage : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Train Sales");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));
			
			nChartControl1.Legends[0].Mode = LegendMode.Disabled;

			NChart chart = nChartControl1.Charts[0];

			// perform manual stretch
			float fAspect = ((float)nChartControl1.Width.Value / (float)nChartControl1.Height.Value);

			// perform manual stretch
			if (fAspect > 1)
			{
				chart.Width = 86 * fAspect;
				chart.Height = 70;
			}
			else
			{
				chart.Width = 86 ;
				chart.Height = 70 * fAspect;
			}

			chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage),
										new NLength(18, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(86, NRelativeUnit.ParentPercentage),
									new NLength(70, NRelativeUnit.ParentPercentage));

			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.Wall(ChartWallType.Floor).Visible = false;
			chart.Wall(ChartWallType.Left).Visible = false;
			chart.Axis(StandardAxis.Depth).Visible = false;

            chart.Axis(StandardAxis.Depth).Visible = false;
            NOrdinalScaleConfigurator ordinalScaleConfigurator = (NOrdinalScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
            ordinalScaleConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
            ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
            ordinalScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, false);
            ordinalScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            NDockAxisAnchor anchor = new NDockAxisAnchor(AxisDockZone.FrontBottom, false, 5, 95);
            chart.Axis(StandardAxis.PrimaryX).Anchor = anchor;
            NLinearScaleConfigurator linearSclaeConfigurator = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            linearSclaeConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);

			bar.Name = "Bar Series";
			bar.BorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			bar.FillStyle = new NColorFillStyle(Color.MediumPurple);
			bar.DataLabelStyle.Visible = false;
			bar.InflateMargins = true;

			// fill with random data
			Random random = new Random();
            bar.Values.FillRandom(random, 10);

			// generate a data series cumulative sum of the bar values
			NFunctionCalculator fc = new NFunctionCalculator();
			fc.Expression = "CUMSUM(Value)";
			fc.Arguments.Add(bar.Values);

			// display this data series as line
			line.Name = "Cumulative";
			line.Values = fc.Calculate();
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.DataLabelStyle.Visible = false;
			line.DataLabelStyle.ArrowStrokeStyle.Width = new NLength(0, NGraphicsUnit.Pixel);

			bar.BarShape = BarShape.Cylinder;

			for (int i = 0; i < bar.Values.Count; i++)
			{
				bar.FillStyles[i] = new NColorFillStyle(WebExamplesUtilities.RandomColor());
			}
			bar.Legend.Mode = SeriesLegendMode.DataPoints;
			line.Legend.Mode = SeriesLegendMode.None;

			NImageResponse imageResponse = new NImageResponse();
			imageResponse.StreamImageToBrowser = true;
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageResponse;
			nChartControl1.RenderControl(null);
		}
	}
}
