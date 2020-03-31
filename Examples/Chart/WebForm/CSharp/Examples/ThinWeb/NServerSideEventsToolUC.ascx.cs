using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NServerSideEventsToolUC : NExampleUC
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            NServerMouseEventTool serverMouseEventTool;

            if (!NThinChartControl1.Initialized)
            {
                // enable jittering (full scene antialiasing)
                NThinChartControl1.Settings.JitterMode = JitterMode.Enabled;
                NThinChartControl1.BackgroundStyle.FrameStyle.Visible = false;

                // set a chart title
                NLabel title = NThinChartControl1.Labels.AddHeader("Server Side Events Tool");
                title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
                title.ContentAlignment = ContentAlignment.BottomRight;
                title.Location = new NPointL(
                    new NLength(2, NRelativeUnit.ParentPercentage),
                    new NLength(2, NRelativeUnit.ParentPercentage));

                // setup legend
                NLegend legend = NThinChartControl1.Legends[0];
                legend.FillStyle.SetTransparencyPercent(50);
                legend.Data.ExpandMode = LegendExpandMode.RowsFixed;
                legend.Data.RowCount = 2;
                legend.ContentAlignment = ContentAlignment.TopLeft;
                legend.Location = new NPointL(
                    new NLength(99, NRelativeUnit.ParentPercentage),
                    new NLength(99, NRelativeUnit.ParentPercentage));

                // by default the control contains a Cartesian chart -> remove it and create a Pie chart
                NChart chart = new NPieChart();
                NThinChartControl1.Charts.Clear();
                NThinChartControl1.Charts.Add(chart);

                // configure the chart
                chart.Enable3D = true;
                chart.DisplayOnLegend = NThinChartControl1.Legends[0];
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

                pie.Values.FillRandomRange(Random, pie.Values.Count, 1, 20);
                for (int i = 0; i < pie.Values.Count; i++)
                {
                    pie.Detachments.Add(0);
                }

                // apply style sheet
                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
                styleSheet.Apply(NThinChartControl1.Document);

                // configure the controller
                serverMouseEventTool = new NServerMouseEventTool();
                NThinChartControl1.Controller.Tools.Add(serverMouseEventTool);
            }
            else
            {
                serverMouseEventTool = NThinChartControl1.Controller.Tools[0] as NServerMouseEventTool;
            }

            // subscribe / unsubscribe to mouse down
            if (MouseDownCheckBox.Checked)
            {
                serverMouseEventTool.MouseDown = new NDetachPieSliceMouseEventCallback();
            }
            else
            {
                serverMouseEventTool.MouseDown = null;
            }

            // subscribe / unsubscribe to mouse move
            if (MouseMoveCheckBox.Checked)
            {
                serverMouseEventTool.MouseMove = new NDetachPieSliceMouseEventCallback();
            }
            else
            {
                serverMouseEventTool.MouseMove = null;
            }

            // subscribe / unsubscribe to mouse up
            if (MouseUpCheckBox.Checked)
            {
                serverMouseEventTool.MouseUp = new NDetachPieSliceMouseEventCallback();
            }
            else
            {
                serverMouseEventTool.MouseUp = null;
            }

            /// // subscribe / unsubscribe to mouse hover
            if (MouseOverCheckBox.Checked)
            {
                serverMouseEventTool.MouseOver = new NDetachPieSliceMouseEventCallback();
            }
            else
            {
                serverMouseEventTool.MouseOver = null; 
            }

            // subscribe / unsubscribe to mouse leave
            if (MouseLeaveCheckBox.Checked)
            {
                serverMouseEventTool.MouseLeave = new NCollapseAllPieSlicesMouseEventCallback();
            }
            else
            {
                serverMouseEventTool.MouseLeave = null;
            }

            // subscribe / unsubscribe to mouse enter
            if (MouseEnterCheckBox.Checked)
            {
                serverMouseEventTool.MouseEnter = new NDetachAllPieSlicesMouseEventCallback();
            }
            else
            {
                serverMouseEventTool.MouseEnter = null;
            }
        }

        [Serializable]
        public class NDetachPieSliceMouseEventCallback : INMouseEventCallback
        {
			#region INMouseEventCallback Members

			void INMouseEventCallback.OnMouseEvent(NAspNetThinWebControl control, NBrowserMouseEventArgs e)
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

        [Serializable]
		public class NDetachAllPieSlicesMouseEventCallback : INMouseEventCallback
        {
			#region INMouseEventCallback Members

			void INMouseEventCallback.OnMouseEvent(NAspNetThinWebControl control, NBrowserMouseEventArgs e)
			{
				NThinChartControl chartControl = (NThinChartControl)control;

				NPieChart pieChart = (NPieChart)chartControl.Charts[0];
				NPieSeries pieSeries = (NPieSeries)pieChart.Series[0];

				for (int i = 0; i < pieSeries.Values.Count; i++)
				{
					pieSeries.Detachments[i] = 5.0f;
				}

				chartControl.UpdateView();
			}

			#endregion
		}

        [Serializable]
		public class NCollapseAllPieSlicesMouseEventCallback : INMouseEventCallback
        {
			#region INMouseEventCallback Members

			void INMouseEventCallback.OnMouseEvent(NAspNetThinWebControl control, NBrowserMouseEventArgs e)
			{
				NThinChartControl chartControl = (NThinChartControl)control;

				NPieChart pieChart = (NPieChart)chartControl.Charts[0];

				NPieSeries pieSeries = (NPieSeries)pieChart.Series[0];

				for (int i = 0; i < pieSeries.Values.Count; i++)
				{
					pieSeries.Detachments[i] = 0;
				}

				chartControl.UpdateView();
			}

			#endregion
		}
    }
}
