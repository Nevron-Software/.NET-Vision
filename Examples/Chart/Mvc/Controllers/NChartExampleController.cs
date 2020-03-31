using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Mvc
{
    public abstract class NChartExampleController : NChartController
    {
        public NChartExampleController()
        {

        }

        public static Color RandomColor()
        {
            return Color.FromArgb(m_Rand.Next(255), m_Rand.Next(255), m_Rand.Next(255));
        }

        public static Random m_Rand = new Random((int)DateTime.Now.Ticks);

        protected void ApplyLayoutTemplate(int template, INChartControl control, NChart chart, NLabel title, NLegend legend)
        {
            control.Panels.Clear();

            if (title != null)
            {
                control.Panels.Add(title);

                title.DockMode = PanelDockMode.Top;
                title.Padding = new NMarginsL(4, 6, 4, 6);
            }

            if (legend != null)
            {
                control.Panels.Add(legend);

                legend.DockMode = PanelDockMode.Right;
                legend.Padding = new NMarginsL(1, 1, 3, 3);
            }

            if (chart != null)
            {
                control.Panels.Add(chart);

                float topPad = (title == null) ? 3 : 3;
                float rightPad = (legend == null) ? 3 : 3;

                if (chart.BoundsMode == BoundsMode.None)
                {
                    if (chart.Enable3D || !(chart is NCartesianChart))
                    {
                        chart.BoundsMode = BoundsMode.Fit;
                    }
                    else
                    {
                        chart.BoundsMode = BoundsMode.Stretch;
                    }
                }

                chart.DockMode = PanelDockMode.Fill;

                // fit axes if chart is Cartesian 3D
                NCartesianChart cartesianChart = chart as NCartesianChart;
                if (cartesianChart != null)
                {
                    cartesianChart.Fit3DAxisContent = true;
                }

                chart.Padding = new NMarginsL(
                    new NLength(3, NRelativeUnit.ParentPercentage),
                    new NLength(topPad, NRelativeUnit.ParentPercentage),
                    new NLength(rightPad, NRelativeUnit.ParentPercentage),
                    new NLength(3, NRelativeUnit.ParentPercentage));
            }
        }

        protected static readonly Color NevronColor1 = Color.FromArgb(236, 96, 49);
        protected static readonly Color NevronColor2 = Color.FromArgb(162, 173, 182);
        protected static readonly Color NevronColor3 = Color.FromArgb(251, 203, 156);
        protected static readonly Color NevronColor4 = Color.FromArgb(120, 133, 133);
        protected static readonly Color NevronColor5 = Color.FromArgb(247, 150, 56);
        protected static readonly Color NevronColor6 = Color.FromArgb(68, 90, 108);
    }
}