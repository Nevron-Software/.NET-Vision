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
    public partial class NPolarPointUC : NExampleUC
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
			NLabel title = nChartControl1.Labels.AddHeader("Polar Point");
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
            polarChart.DisplayOnLegend = nChartControl1.Legends[0];
			polarChart.DisplayAxesOnTop = true;
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

            // create three polar point series
            NSeries s1 = CreatePolarPointSeries("Sample 1", PointShape.Sphere);
            NSeries s2 = CreatePolarPointSeries("Sample 2", PointShape.Bar);
            NSeries s3 = CreatePolarPointSeries("Sample 3", PointShape.Pyramid);

            // add the series to the chart
            polarChart.Series.Add(s1);
            polarChart.Series.Add(s2);
            polarChart.Series.Add(s3);

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

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

        private NSeries CreatePolarPointSeries(string name, PointShape shape)
        {
            NPolarPointSeries series = new NPolarPointSeries();
            series.Name = name;
            series.Angles.ValueFormatter = new NNumericValueFormatter("0.00");
            series.DataLabelStyle.Visible = false;
            series.DataLabelStyle.Format = "<value> - <angle_in_degrees>";
            series.PointShape = shape;
            series.Size = new NLength(1.5f, NRelativeUnit.ParentPercentage);

            // add data
            series.Values.FillRandomRange(Random, 10, 0, 100);
            series.Angles.FillRandomRange(Random, 10, 0, 360);

            return series;
        }
    }
}
