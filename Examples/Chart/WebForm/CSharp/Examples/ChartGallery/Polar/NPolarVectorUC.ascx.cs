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
    public partial class NPolarVectorUC : NExampleUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebExamplesUtilities.FillComboWithValues(BeginAngleDropDownList, 0, 360, 15);
            }

            // disable frame
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Polar Range");
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
            linearScale.ViewRangeInflateMode = ScaleViewRangeInflateMode.MajorTick;
            linearScale.InflateViewRangeBegin = true;
            linearScale.InflateViewRangeEnd = true;

            NScaleStripStyle strip = new NScaleStripStyle();
            strip.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.Beige));
            strip.Interlaced = true;
            strip.SetShowAtWall(ChartWallType.Polar, true);
            linearScale.StripStyles.Add(strip);

            // setup polar angle axis
            NAngularScaleConfigurator angularScale = (NAngularScaleConfigurator)polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator;
            strip = new NScaleStripStyle();
            strip.FillStyle = new NColorFillStyle(Color.FromArgb(125, 192, 192, 192));
            strip.Interlaced = true;
            strip.SetShowAtWall(ChartWallType.Polar, true);
            angularScale.StripStyles.Add(strip);

            // create a polar line series
            NPolarVectorSeries vectorSeries = new NPolarVectorSeries();
            polarChart.Series.Add(vectorSeries);
            vectorSeries.Name = "Series 1";
            vectorSeries.DataLabelStyle.Visible = false;
            vectorSeries.ShadowStyle.Type = ShadowType.LinearBlur;
            vectorSeries.ShadowStyle.Color = Color.Red;

            int dataPointIndex = 0;

            for (int i = 0; i < 360; i += 30)
            {
                for (int j = 10; j <= 100; j += 10)
                {
                    vectorSeries.Angles.Add(i);
                    vectorSeries.Values.Add(j);

                    vectorSeries.X2Values.Add(i + j / 10);
                    vectorSeries.Y2Values.Add(j);

                    vectorSeries.BorderStyles[dataPointIndex] = new NStrokeStyle(1.0f, ColorFromValue(j));
                    dataPointIndex++;
                }
            }

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            // apply settings
            polarChart.BeginAngle = BeginAngleDropDownList.SelectedIndex * 15.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Color ColorFromValue(double value)
        {
            Color color1 = Color.Red;
            Color color2 = Color.Blue;
                
            double factor = value / 100.0;
            double oneMinusFactor = 1 - factor;

            return Color.FromArgb(
                (byte)(color1.A * oneMinusFactor + color2.A * factor),
                (byte)(color1.R * oneMinusFactor + color2.R * factor),
                (byte)(color1.G * oneMinusFactor + color2.G * factor),
                (byte)(color1.B * oneMinusFactor + color2.B * factor));
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
