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
    public partial class NPolarLineUC : NExampleUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebExamplesUtilities.FillComboWithValues(BeginAngleDropDownList, 0, 360, 15);
                AngleStepDropDownList.Items.Add("15");
                AngleStepDropDownList.Items.Add("30");
                AngleStepDropDownList.Items.Add("45");
                AngleStepDropDownList.Items.Add("90");
                AngleStepDropDownList.SelectedIndex = 0;
            }

            // disable frame
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Polar Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(60, 90, 108));
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));	

            // setup chart
            NPolarChart polarChart = new NPolarChart();
            nChartControl1.Charts.Clear();
            nChartControl1.Charts.Add(polarChart);
            polarChart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			polarChart.DisplayAxesOnTop = true;
            polarChart.DisplayOnLegend = nChartControl1.Legends[0];
            polarChart.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(5, NRelativeUnit.ParentPercentage));
            polarChart.Size = new NSizeL(new NLength(90, NRelativeUnit.ParentPercentage), new NLength(90, NRelativeUnit.ParentPercentage));

            // setup polar axis
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)polarChart.Axis(StandardAxis.Polar).ScaleConfigurator;
            linearScale.RoundToTickMax = true;
            linearScale.RoundToTickMin = true;

            NScaleStripStyle strip = new NScaleStripStyle();
            strip.FillStyle = new NColorFillStyle(Color.FromArgb(128, Color.Beige));
            strip.Interlaced = true;
			strip.SetShowAtWall(ChartWallType.Polar, true);
            linearScale.StripStyles.Add(strip);

            // setup polar angle axis
            NAngularScaleConfigurator angularScale = (NAngularScaleConfigurator)polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator;
            strip = new NScaleStripStyle();
            strip.FillStyle = new NColorFillStyle(Color.FromArgb(64, 192, 192, 192));
            strip.Interlaced = true;
            strip.SetShowAtWall(ChartWallType.Polar, true);
            angularScale.StripStyles.Add(strip);

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

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Charts[0].Series);

            // apply settings
            polarChart.BeginAngle = BeginAngleDropDownList.SelectedIndex * 15.0f;

            NAngularScaleConfigurator angleScale = polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator as NAngularScaleConfigurator;
            angleScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);

            switch (AngleStepDropDownList.SelectedIndex)
            {
                case 0:
                    angleScale.MajorTickMode = MajorTickMode.CustomStep;
                    angleScale.CustomStep = new NAngle(15, NAngleUnit.Degree);
                    break;

                case 1:
                    angleScale.MajorTickMode = MajorTickMode.CustomStep;
                    angleScale.CustomStep = new NAngle(30, NAngleUnit.Degree);
                    break;

                case 2:
                    angleScale.MajorTickMode = MajorTickMode.CustomStep;
                    angleScale.CustomStep = new NAngle(45, NAngleUnit.Degree);
                    break;

                case 3:
                    angleScale.MajorTickMode = MajorTickMode.CustomStep;
                    angleScale.CustomStep = new NAngle(90, NAngleUnit.Degree);
                    break;
            }
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
