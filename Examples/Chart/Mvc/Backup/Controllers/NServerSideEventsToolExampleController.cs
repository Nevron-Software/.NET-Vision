using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.Mvc
{
    public class NServerSideEventsToolExampleController : NChartExampleController
    {
        public NServerSideEventsToolExampleController()
        {
        }

        public override void Initialize(NThinChartControl control)
        {
            NServerMouseEventTool serverMouseEventTool;

            // enable jittering (full scene antialiasing)
            control.Settings.JitterMode = JitterMode.Enabled;
            control.BackgroundStyle.FrameStyle.Visible = false;

            // set a chart title
            NLabel title = control.Labels.AddHeader("Exploded Pie Chart");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            title.ContentAlignment = ContentAlignment.BottomRight;
            title.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

            // setup legend
            NLegend legend = control.Legends[0];
            legend.FillStyle.SetTransparencyPercent(50);
            legend.Data.ExpandMode = LegendExpandMode.RowsFixed;
            legend.Data.RowCount = 2;
            legend.ContentAlignment = ContentAlignment.TopLeft;
            legend.Location = new NPointL(
                new NLength(99, NRelativeUnit.ParentPercentage),
                new NLength(99, NRelativeUnit.ParentPercentage));

            // by default the control contains a Cartesian chart -> remove it and create a Pie chart
            NChart chart = new NPieChart();
            control.Charts.Clear();
            control.Charts.Add(chart);

            // configure the chart
            chart.Enable3D = true;
            chart.DisplayOnLegend = control.Legends[0];
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
            chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
            chart.BoundsMode = BoundsMode.Fit;
            chart.Location = new NPointL(
                new NLength(12, NRelativeUnit.ParentPercentage),
                new NLength(12, NRelativeUnit.ParentPercentage));
            chart.Size = new NSizeL(
                new NLength(76, NRelativeUnit.ParentPercentage),
                new NLength(68, NRelativeUnit.ParentPercentage));

            // add a pie serires
            NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
            pie.PieStyle = PieStyle.SmoothEdgePie;
            pie.PieEdgePercent = 50;
            pie.DataLabelStyle.Visible = false;
            pie.Legend.Mode = SeriesLegendMode.DataPoints;
            pie.Legend.Format = "<label> <percent>";
            pie.Legend.TextStyle.FontStyle = new NFontStyle("Arial", 8);

            pie.AddDataPoint(new NDataPoint(0, "Ships"));
            pie.AddDataPoint(new NDataPoint(0, "Trains"));
            pie.AddDataPoint(new NDataPoint(0, "Cars"));
            pie.AddDataPoint(new NDataPoint(0, "Buses"));
            pie.AddDataPoint(new NDataPoint(0, "Airplanes"));

            pie.Values.FillRandomRange(new Random(), pie.Values.Count, 1, 20);
            for (int i = 0; i < pie.Values.Count; i++)
            {
                pie.Detachments.Add(0);
            }

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.NevronMultiColor);
            styleSheet.Apply(control.Document);

            // configure the controller
            serverMouseEventTool = new NServerMouseEventTool();
            control.Controller.Tools.Add(serverMouseEventTool);

            serverMouseEventTool.MouseDown = new NDetachPieSliceMouseEventCallback();
        }

        [Serializable]
        class NDetachPieSliceMouseEventCallback : INMouseEventCallback
        {
            #region INMouseEventCallback Members

            public void OnMouseEvent(NAspNetThinWebControl control, NBrowserMouseEventArgs e)
            {
                NThinChartControl chartControl = (NThinChartControl)control;

                NPieChart pieChart = (NPieChart)chartControl.Charts[0];
                NHitTestResult hitTestResult = chartControl.HitTest(e.X, e.Y);

                int dataPointIndex = hitTestResult.DataPointIndex;

                // collapse all pie slices
                NPieSeries pieSeries = (NPieSeries)pieChart.Series[0];
                for (int i = 0; i < pieSeries.Values.Count; i++)
                {
                    pieSeries.Detachments[i] = 0;
                }

                // expand the one that's hit
                if (dataPointIndex != -1)
                {
                    pieSeries.Detachments[dataPointIndex] = 5.0f;
                }

                chartControl.UpdateView();
            }

            #endregion
        }
    }
}