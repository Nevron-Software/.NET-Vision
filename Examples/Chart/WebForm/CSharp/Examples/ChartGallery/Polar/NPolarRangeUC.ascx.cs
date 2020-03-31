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
    public partial class NPolarRangeUC : NExampleUC
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
            linearScale.RoundToTickMax = true;
            linearScale.RoundToTickMin = true;
            linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

            NOrdinalScaleConfigurator ordinalScale = new NOrdinalScaleConfigurator();

            NScaleStripStyle strip = new NScaleStripStyle();
            strip.FillStyle = new NColorFillStyle(Color.FromArgb(100, Color.DarkGray));
            strip.Interlaced = true;
            strip.SetShowAtWall(ChartWallType.Polar, true);
            ordinalScale.StripStyles.Add(strip);
            ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

            ordinalScale.InflateContentRange = false;
            ordinalScale.MajorTickMode = MajorTickMode.CustomTicks;
            ordinalScale.DisplayDataPointsBetweenTicks = false;

            ordinalScale.MajorTickMode = MajorTickMode.CustomStep;
            ordinalScale.CustomStep = 1;
            string[] labels = new string[] { "E", "NE", "N", "NW", "W", "SW", "S", "SE" };

            ordinalScale.AutoLabels = false;
            ordinalScale.Labels.AddRange(labels);
            ordinalScale.DisplayLastLabel = false;

            polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator = ordinalScale;
            polarChart.Axis(StandardAxis.PolarAngle).View = new NRangeAxisView(new NRange1DD(0, 8));

            NPolarRangeSeries polarRange = new NPolarRangeSeries();
            polarRange.DataLabelStyle.Visible = false;
            polarChart.Series.Add(polarRange);

            Random rand = new Random();

            for (int i = 0; i < 8; i++)
            {
                polarRange.Values.Add(0);
                polarRange.Angles.Add(i - 0.4);

                polarRange.Y2Values.Add(rand.Next(80) + 20.0);
                polarRange.X2Values.Add(i + 0.4);
            }

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            // apply settings
            polarChart.BeginAngle = BeginAngleDropDownList.SelectedIndex * 15.0f;
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
