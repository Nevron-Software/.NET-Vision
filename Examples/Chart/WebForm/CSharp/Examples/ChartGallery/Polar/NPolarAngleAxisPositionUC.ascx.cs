using System;
using System.Collections;
using System.Configuration;
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
    public partial class NPolarAngleAxisPositionUC : NExampleUC
    {
        int m_CustomAxisId;

        protected void Page_Load(object sender, EventArgs e)
        {
			nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithValues(BeginAngleDropDownList, 0, 360, 15);
				DockDegreeAxisCheckBox.Checked = true;
				DockGradAxisCheckBox.Checked = false; 
			}

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Polar Angle Axis Position");
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
			polarChart.Size = new NSizeL(new NLength(90, NRelativeUnit.ParentPercentage), new NLength(87, NRelativeUnit.ParentPercentage));

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

            // setup polar axis
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)polarChart.Axis(StandardAxis.Polar).ScaleConfigurator;
            linearScale.RoundToTickMax = true;
            linearScale.RoundToTickMin = true;
            linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

            NScaleStripStyle strip = new NScaleStripStyle();
            strip.FillStyle = new NColorFillStyle(Color.Beige);
            strip.Interlaced = true;
			strip.SetShowAtWall(ChartWallType.Polar, true);
            linearScale.StripStyles.Add(strip);

            // setup polar angle axis
            NAngularScaleConfigurator degreeScale = (NAngularScaleConfigurator)polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator;
			degreeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);
            degreeScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
            degreeScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);

            // add a second value axes
            NPolarAxis valueAxis = (NPolarAxis)polarChart.Axis(StandardAxis.Polar);

            NPolarAxis degreeAxis = (NPolarAxis)polarChart.Axis(StandardAxis.PolarAngle);
            NPolarAxis gradAxis = ((NPolarAxisCollection)polarChart.Axes).AddCustomAxis(PolarAxisOrientation.Angle);

            NAngularScaleConfigurator gradScale = new NAngularScaleConfigurator();
            gradScale.AngleUnit = NAngleUnit.Grad;
            gradScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
            gradScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);
			gradAxis.ScaleConfigurator = gradScale;
			m_CustomAxisId = gradAxis.AxisId;

            NCrossPolarAxisAnchor secondaryAnchor = new NCrossPolarAxisAnchor(PolarAxisOrientation.Angle);
            secondaryAnchor.Crossings.Add(new NValueAxisCrossing(valueAxis, 10));

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            // color code the axes and series after the stylesheet is applied
            ApplyColorToAxis(degreeAxis, Color.Red);
            ApplyColorToAxis(gradAxis, Color.Green);

            series1.BorderStyle.Width = new NLength(2);
            series2.BorderStyle.Width = new NLength(2);

			// set the begin angle
			polarChart.BeginAngle = BeginAngleDropDownList.SelectedIndex * 15;

			// configure axis docking / crossing
            if (DockDegreeAxisCheckBox.Checked)
            {
                degreeAxis.Anchor = new NDockPolarAxisAnchor();
			}
            else
            {
                degreeAxis.Anchor = new NCrossPolarAxisAnchor(PolarAxisOrientation.Angle, new NValueAxisCrossing(valueAxis, 0.0));
            }

            if (DockGradAxisCheckBox.Checked)
            {
                gradAxis.Anchor = new NDockPolarAxisAnchor();
            }
            else
            {
                gradAxis.Anchor = new NCrossPolarAxisAnchor(PolarAxisOrientation.Angle, new NValueAxisCrossing(valueAxis, 100.0));
            }
        }

        private void ApplyColorToAxis(NAxis axis, Color color)
        {
            NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

            scale.RulerStyle.BorderStyle.Color = color;
            scale.OuterMajorTickStyle.LineStyle.Color = color;
            scale.OuterMinorTickStyle.LineStyle.Color = color;
            scale.InnerMajorTickStyle.LineStyle.Color = color;
            scale.InnerMinorTickStyle.LineStyle.Color = color;
            scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(color);

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
                double radius = 100 * Math.Cos(angle);

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
                double radius = 33 + 100 * Math.Sin(2 * angle) + 1.7 * Math.Cos(2 * angle);

                radius = Math.Abs(radius);

                series.Values.Add(radius);
                series.Angles.Add(angle * 180 / Math.PI);
            }
        }
    }
}
