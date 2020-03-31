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
    public partial class NPolarAreaUC : NExampleUC
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
			NLabel title = nChartControl1.Labels.AddHeader("Polar Area");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(60, 90, 108));
			title.ContentAlignment = ContentAlignment.BottomRight;
			title.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));	

            // setup chart
            NPolarChart polarChart = new NPolarChart();
            nChartControl1.Charts.Clear();
            nChartControl1.Charts.Add(polarChart);
            polarChart.DisplayOnLegend = nChartControl1.Legends[0];
			polarChart.DisplayAxesOnTop = true;
            polarChart.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(5, NRelativeUnit.ParentPercentage));
            polarChart.Size = new NSizeL(new NLength(90, NRelativeUnit.ParentPercentage), new NLength(90, NRelativeUnit.ParentPercentage));

            // setup polar axis
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)polarChart.Axis(StandardAxis.Polar).ScaleConfigurator;
            linearScale.RoundToTickMax = true;
            linearScale.RoundToTickMin = true;
            linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

            // setup polar angle axis
            NAngularScaleConfigurator angularScale = (NAngularScaleConfigurator)polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator;
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);
			NScaleStripStyle strip = new NScaleStripStyle();
			strip.FillStyle = new NColorFillStyle(Color.FromArgb(64, 192, 192, 192));
            strip.Interlaced = true;
			strip.SetShowAtWall(ChartWallType.Polar, true);
            angularScale.StripStyles.Add(strip);

            // polar area series 1
            NPolarAreaSeries series1 = new NPolarAreaSeries();
            polarChart.Series.Add(series1);
            series1.Name = "Theoretical";
            series1.DataLabelStyle.Visible = false;
            GenerateData(series1, 100, 15.0);

            // polar area series 2
            NPolarAreaSeries series2 = new NPolarAreaSeries();
            polarChart.Series.Add(series2);
            series2.Name = "Experimental";
            series2.DataLabelStyle.Visible = false;
            GenerateData(series2, 100, 10.0);

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

        private void GenerateData(NPolarSeries series, int count, double scale)
        {
            series.Values.Clear();
            series.Angles.Clear();

            double angleStep = 2 * Math.PI / count;

            for (int i = 0; i < count; i++)
            {
                double angle = i * angleStep;
                double c1 = 1.0 * Math.Sin(angle * 3);
                double c2 = 0.3 * Math.Sin(angle * 1.5);
                double c3 = 0.05 * Math.Cos(angle * 26);
                double c4 = 0.05 * (0.5 - Random.NextDouble());
                double value = scale * (Math.Abs(c1 + c2 + c3) + c4);

                if (value < 0)
                    value = 0;

                series.Values.Add(value);
                series.Angles.Add(angle * 180 / Math.PI);
            }
        }
    }
}
