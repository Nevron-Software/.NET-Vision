using System;
using System.Diagnostics;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NAnnotationsGeneralUC : NExampleUC
	{
		private NChart nChart;
		private NLegend nLegend;
		private NBarSeries nBar;
		private NLineSeries nLine;
		private NRectangularCallout nRectangularCallout;
		private NRoundedRectangularCallout nRoundedRectangularCallout;
		private NCutEdgeRectangularCallout nCutEdgeRectangularCallout;
		private NOvalCallout nOvalCallout;
		private NArrowAnnotation nArrowAnnotation;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			ConfigureChart();
			ConfigureAnnotations();
		}

		private void ConfigureChart()
		{
			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Annotations");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomCenter;
            header.Location = new NPointL(
                new NLength(50, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			nLegend = nChartControl1.Legends[0];

			// setup the chart
			nChart = nChartControl1.Charts[0];
			nChart.Enable3D = true;
			nChart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			nChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);
			nChart.Axis(StandardAxis.Depth).Visible = false;

			NOrdinalScaleConfigurator scaleX = (NOrdinalScaleConfigurator)nChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount;

			// add the line series
			nLine = (NLineSeries)nChart.Series.Add(SeriesType.Line);
			nLine.Name = "Cumulative";
			nLine.DataLabelStyle.Visible = false;
			nLine.BorderStyle = new NStrokeStyle(GreyBlue);
			nLine.MarkerStyle.Visible = true;
			nLine.MarkerStyle.PointShape = PointShape.Cylinder;
			nLine.MarkerStyle.FillStyle = new NColorFillStyle(Green);
			nLine.MarkerStyle.BorderStyle = new NStrokeStyle(GreyBlue);
			nLine.MarkerStyle.Width = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			nLine.MarkerStyle.Height = new NLength(1.5f, NRelativeUnit.ParentPercentage);
			nLine.ShadowStyle.Type = ShadowType.GaussianBlur;
			nLine.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			nLine.ShadowStyle.Offset = new NPointL(2, 2);
			nLine.ShadowStyle.FadeLength = new NLength(4);

			// add the bar series
			nBar = (NBarSeries)nChart.Series.Add(SeriesType.Bar);
			nBar.Name = "Bar Series";
			nBar.DataLabelStyle.Visible = false;
			nBar.BorderStyle = new NStrokeStyle(DarkOrange);
			nBar.FillStyle = new NColorFillStyle(DarkOrange);
			nBar.ShadowStyle.Type = ShadowType.GaussianBlur;
			nBar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0);
			nBar.ShadowStyle.Offset = new NPointL(3, 3);
			nBar.ShadowStyle.FadeLength = new NLength(4);

			// fill with random data and sort in descending order
			nBar.Values.FillRandom(Random, 10);
			nBar.Values.Sort(DataSeriesSortOrder.Descending);

			// generate a data series cumulative sum of the bar values
			NFunctionCalculator fc = new NFunctionCalculator();
			fc.Expression = "CUMSUM(Value)";
			fc.Arguments.Add(nBar.Values);
			nLine.Values = fc.Calculate();
		}

		private void ConfigureAnnotations()
		{
            if(rectPanelCheck.Checked)
            {
			    nRectangularCallout = new NRectangularCallout();
			    nRectangularCallout.ArrowLength = new NLength(15, NRelativeUnit.ParentPercentage);
			    nRectangularCallout.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.CadetBlue));
			    nRectangularCallout.UseAutomaticSize = true;
			    nRectangularCallout.Orientation = 225;
			    nRectangularCallout.Anchor = new NDataPointAnchor(nBar, 2, ContentAlignment.MiddleCenter, StringAlignment.Center);
			    nRectangularCallout.Text = GetTextForAnnotation(nRectangularCallout);
			    nRectangularCallout.TextStyle.FontStyle.EmSize = new NLength(8);
                nChartControl1.Panels.Add(nRectangularCallout);
            }

            if (roundRectCalloutCheck.Checked)
            {
                nRoundedRectangularCallout = new NRoundedRectangularCallout();
                nRoundedRectangularCallout.ArrowLength = new NLength(15, NRelativeUnit.ParentPercentage);
                nRoundedRectangularCallout.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.LightGreen));
                nRoundedRectangularCallout.UseAutomaticSize = true;
                nRoundedRectangularCallout.Orientation = 135;
                nRoundedRectangularCallout.Anchor = new NModelPointAnchor(nChart, new NVector3DF(0, 0, 0));
                nRoundedRectangularCallout.Text = GetTextForAnnotation(nRoundedRectangularCallout);
                nRoundedRectangularCallout.TextStyle.FontStyle.EmSize = new NLength(8);
                nChartControl1.Panels.Add(nRoundedRectangularCallout);
            }

            if (cutedgeRectPanelCheck.Checked)
            {
                nCutEdgeRectangularCallout = new NCutEdgeRectangularCallout();
                nCutEdgeRectangularCallout.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.LightBlue));
                nCutEdgeRectangularCallout.ArrowLength = new NLength(40, NRelativeUnit.ParentPercentage);
                nCutEdgeRectangularCallout.UseAutomaticSize = true;
                nCutEdgeRectangularCallout.Orientation = 190;
                nCutEdgeRectangularCallout.Anchor = new NLegendDataItemAnchor(nLegend, 1);
                nCutEdgeRectangularCallout.Text = GetTextForAnnotation(nCutEdgeRectangularCallout);
                nCutEdgeRectangularCallout.TextStyle.FontStyle.EmSize = new NLength(8);
                nChartControl1.Panels.Add(nCutEdgeRectangularCallout);
            }

            if (ovalPanelCheck.Checked)
            {
                nOvalCallout = new NOvalCallout();
                nOvalCallout.FillStyle = new NColorFillStyle(Color.FromArgb(200, Color.AliceBlue));
                nOvalCallout.ArrowLength = new NLength(15, NRelativeUnit.ParentPercentage);
                nOvalCallout.UseAutomaticSize = true;
                nOvalCallout.Orientation = 315;
                nOvalCallout.Anchor = new NScalePointAnchor(nChart,
                    (int)StandardAxis.PrimaryX,
                    (int)StandardAxis.PrimaryY,
                    (int)StandardAxis.Depth,
					AxisValueAnchorMode.Clip,
                    new NVector3DD(7, 100, 0));
                nOvalCallout.Text = GetTextForAnnotation(nOvalCallout);
                nOvalCallout.TextStyle.FontStyle.EmSize = new NLength(8);
                nChartControl1.Panels.Add(nOvalCallout);
            }

            if (arrowCheck.Checked)
            {
                nArrowAnnotation = new NArrowAnnotation();
                nArrowAnnotation.UseAutomaticSize = true;
                nArrowAnnotation.ArrowHeadWidthPercent = 30;
                nArrowAnnotation.TextStyle.FontStyle.EmSize = new NLength(11, NGraphicsUnit.Point);
                nArrowAnnotation.TextStyle.FontStyle.Style |= FontStyle.Bold;
                nArrowAnnotation.Orientation = 45;
                nArrowAnnotation.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.Orange));
                nArrowAnnotation.Anchor = new NDataPointAnchor(nBar, 4, ContentAlignment.MiddleCenter, StringAlignment.Center);
                nArrowAnnotation.Text = GetTextForAnnotation(nArrowAnnotation);
                nArrowAnnotation.TextStyle.FontStyle.EmSize = new NLength(8);
                nChartControl1.Panels.Add(nArrowAnnotation);
            }
		}
 
		private String GetTextForAnnotation(NAnchorPanel annotation)
		{
			String sText = "";

			if (annotation is NRectangularCallout)
			{
				sText = "This is a rectangular callout panel \r\n";
			}
			else if (annotation is NRoundedRectangularCallout)
			{
				sText = "This is a rounded rectangular callout panel \r\n";
			}
			else if (annotation is NCutEdgeRectangularCallout)
			{
				sText = "This is a cut edge rectangular callout panel \r\n";
			}
			else if (annotation is NOvalCallout)
			{
				sText = "This is an oval callout panel \r\n";
			}
			else if (annotation is NArrowAnnotation)
			{
				sText = "This is an arrow annotation \r\n";
			}
			else 
			{
				Debug.Assert(false);
			}

			return sText + GetTextForAnchor(annotation.Anchor);
		}

		private string GetTextForAnchor(NAnchor anchor)
		{
			String sText = "attached to ";

			if (anchor is NAxisValueAnchor)
			{
				sText += "an axis value.";
			}
			else if (anchor is NDataPointAnchor)
			{
				sText += "a chart data point.";
			}
			else if (anchor is NLegendDataItemAnchor)
			{
				sText += "a legend data point.";
			}
			else if (anchor is NModelPointAnchor)
			{
				sText += "a model point.";
			}
			else if (anchor is NScalePointAnchor)
			{
				sText += "a scale point.";
			}
			else 
			{
				Debug.Assert(false);
			}

			return sText;
		}
	}
}
