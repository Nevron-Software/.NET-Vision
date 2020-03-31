using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NPolarValueAxisPositionUC : NExampleUC
    {
        int m_CustomAxisId;

        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithValues(BeginAngleDropDownList, 0, 360, 15);

				DockRedAxisCheckBox.Checked = false;
				PaintReflectionOfRedAxisCheckBox.Checked = false;
				DockGreenAxisCheckBox.Checked = true;
				PaintReflectionOfGreenAxisCheckBox.Checked = true;
			}

			//
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Polar Value Axis Position");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
				new NLength(2, NRelativeUnit.ParentPercentage),
				new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NPolarChart polarChart = new NPolarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(polarChart);
			polarChart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			polarChart.DisplayOnLegend = nChartControl1.Legends[0];
			polarChart.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
			polarChart.Size = new NSizeL(new NLength(95, NRelativeUnit.ParentPercentage), new NLength(87, NRelativeUnit.ParentPercentage)); ;

			// setup polar axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)polarChart.Axis(StandardAxis.Polar).ScaleConfigurator;
			linearScale.RoundToTickMax = true;
			linearScale.RoundToTickMin = true;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

			// setup polar angle axis
			NAngularScaleConfigurator angularScale = (NAngularScaleConfigurator)polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator;
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);
			angularScale.MinTickDistance = new NLength(50);
			angularScale.LabelStyle.TextStyle.FontStyle.EmSize = new NLength(8);
			NScaleStripStyle strip = new NScaleStripStyle();
			strip.FillStyle = new NColorFillStyle(Color.FromArgb(64, 192, 192, 192));
			strip.Interlaced = true;
			strip.SetShowAtWall(ChartWallType.Polar, true);
			angularScale.StripStyles.Add(strip);

			// add a const line
			NAxisConstLine line = polarChart.Axis(StandardAxis.Polar).ConstLines.Add();
			line.Value = 50;
			line.StrokeStyle.Color = Color.SlateBlue;
			line.StrokeStyle.Width = new NLength(1, NGraphicsUnit.Pixel);

			// create a polar line series
			NPolarLineSeries series1 = new NPolarLineSeries();
			polarChart.Series.Add(series1);
			series1.Name = "Series 1";
			series1.CloseContour = true;
			series1.DataLabelStyle.Visible = false;
			series1.MarkerStyle.Visible = false;
			series1.MarkerStyle.Width = new NLength(1, NRelativeUnit.ParentPercentage);
			series1.MarkerStyle.Height = new NLength(1, NRelativeUnit.ParentPercentage);
			Curve1(series1, 50);

			// create a polar line series
			NPolarLineSeries series2 = new NPolarLineSeries();
			polarChart.Series.Add(series2);
			series2.Name = "Series 2";
			series2.CloseContour = true;
			series2.DataLabelStyle.Visible = false;
			series2.MarkerStyle.Visible = false;
			series2.MarkerStyle.Width = new NLength(1, NRelativeUnit.ParentPercentage);
			series2.MarkerStyle.Height = new NLength(1, NRelativeUnit.ParentPercentage);
			Curve2(series2, 100);

			// add a second value axes
			NPolarAxis primaryAxis = (NPolarAxis)polarChart.Axis(StandardAxis.Polar);
			NPolarAxis secondaryAxis = ((NPolarAxisCollection)polarChart.Axes).AddCustomAxis(PolarAxisOrientation.Value);
			m_CustomAxisId = secondaryAxis.AxisId;

			NCrossPolarAxisAnchor secondaryAnchor = secondaryAxis.Anchor as NCrossPolarAxisAnchor;
			secondaryAnchor.Crossings.Clear();
			secondaryAnchor.Crossings.Add(new NValueAxisCrossing(primaryAxis, 90));

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// color code the axes and series after the stylesheet is applied
			ApplyColorToAxis(primaryAxis, Color.Red);
			ApplyColorToAxis(secondaryAxis, Color.Green);

			series1.BorderStyle.Color = Color.DarkRed;
			series1.BorderStyle.Width = new NLength(2);

			series2.BorderStyle.Color = Color.DarkGreen;
			series2.BorderStyle.Width = new NLength(2);

			series2.DisplayOnAxis(StandardAxis.Polar, false);
			series2.DisplayOnAxis(m_CustomAxisId, true);

			// apply the polar orientation
			polarChart.BeginAngle = BeginAngleDropDownList.SelectedIndex * 15;

			// set angle of axis labels
			NAxis angleAxis = polarChart.Axis(StandardAxis.PolarAngle);
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)angleAxis.ScaleConfigurator;
			scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);

			// configure the red axis
			NAxis redAxis = polarChart.Axis(StandardAxis.Polar);
			NPolarAxisAnchor redAnchor;

			if (DockRedAxisCheckBox.Checked)
			{
				redAnchor = new NDockPolarAxisAnchor(PolarAxisDockZone.Bottom);
			}
			else
			{
				NCrossPolarAxisAnchor crossAnchor = new NCrossPolarAxisAnchor();
				crossAnchor.Crossings.Add(new NValueAxisCrossing(angleAxis, 0));
				redAnchor = crossAnchor;
			}

			redAnchor.PaintReflection = PaintReflectionOfRedAxisCheckBox.Checked;
			redAxis.Anchor = redAnchor;

			// configure the green axis
			NAxis greenAxis = polarChart.Axis(m_CustomAxisId);
			NPolarAxisAnchor greenAnchor;

			if (DockGreenAxisCheckBox.Checked)
			{
				NDockPolarAxisAnchor dockAnchor = new NDockPolarAxisAnchor(PolarAxisDockZone.Left);
				greenAnchor = dockAnchor;		
			}
			else
			{
				NCrossPolarAxisAnchor crossAnchor = new NCrossPolarAxisAnchor();
				crossAnchor.Crossings.Add(new NValueAxisCrossing(angleAxis, 90));
				greenAnchor = crossAnchor;
			}

			greenAnchor.PaintReflection = PaintReflectionOfGreenAxisCheckBox.Checked;
			greenAxis.Anchor = greenAnchor;
		}

		private void ApplyColorToAxis(NAxis axis, Color color)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;

			linearScale.RulerStyle.BorderStyle.Color = color;
			linearScale.OuterMajorTickStyle.LineStyle.Color = color;
			linearScale.OuterMinorTickStyle.LineStyle.Color = color;
			linearScale.InnerMajorTickStyle.LineStyle.Color = color;
			linearScale.InnerMinorTickStyle.LineStyle.Color = color;
			linearScale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(color);

			axis.InvalidateScale();
		}

		internal static void Curve1(NPolarSeries series, int count)
		{
			series.Values.Clear();
			series.Angles.Clear();

			double angleStep = 2 * Math.PI / count;

			for (int i = 0; i < count; i++)
			{
				double angle = i * angleStep;
				double radius = 1 + Math.Cos(angle);

				series.Values.Add(radius);
				series.Angles.Add(angle * 180 / Math.PI);
			}
		}
        internal static void Curve2(NPolarSeries series, int count)
        {
            series.Values.Clear();
            series.Angles.Clear();

            double angleStep = 2 * Math.PI / count;

            for (int i = 0; i < count; i++)
            {
                double angle = i * angleStep;
                double radius = 0.2 + 1.7 * Math.Sin(2 * angle) + 1.7 * Math.Cos(2 * angle);

                radius = Math.Abs(radius);

                series.Values.Add(radius);
                series.Angles.Add(angle * 180 / Math.PI);
            }
        }
    }
}