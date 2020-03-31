using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.ThinWeb;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WebForm
{
    public partial class NPanelDragToolUC : NExampleUC
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!NThinChartControl1.Initialized)
            {
                // get the default chart 
                NThinChartControl1.Panels.Clear();
                NThinChartControl1.BackgroundStyle.FrameStyle.Visible = false;
                NThinChartControl1.Settings.EnableJittering = true;

                // set a chart title
                NLabel title = NThinChartControl1.Labels.AddHeader("Panel Drag Tool");
                title.TextStyle.TextFormat = GraphicsCore.TextFormat.XML;
                title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
                title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;


                // create the first pie chart
                NPieChart pieChart1 = CreatePieChart();
                pieChart1.Location = new NPointL(new NLength(0), new NLength(10, NRelativeUnit.ParentPercentage));
                pieChart1.Size = new NSizeL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(60, NRelativeUnit.ParentPercentage));
                NThinChartControl1.Panels.Add(pieChart1);

                // create the second pie chart
                NPieChart pieChart2 = CreatePieChart();
				pieChart1.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
				pieChart2.Size = new NSizeL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(60, NRelativeUnit.ParentPercentage));
				NThinChartControl1.Panels.Add(pieChart2);


                // apply style sheet
                NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor);
                styleSheet.Apply(NThinChartControl1.Document);

                // add panel selector and trackball tools
                NPanelSelectorTool panelSelectorTool = new NPanelSelectorTool();
				panelSelectorTool.ActivatePanelCallback = new ActivatePanelCallback();
				NThinChartControl1.Controller.Tools.Add(panelSelectorTool);
                NThinChartControl1.Controller.Tools.Add(new NPanelDragTool());
            }
        }

        private NPieChart CreatePieChart()
        {
            NPieChart pieChart = new NPieChart();
            pieChart.Enable3D = true;
            pieChart.Margins = new NMarginsL(10, 10, 10, 10);
            pieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
            pieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);

            NPieSeries pieSeries = new NPieSeries();
            pieSeries.LabelMode = PieLabelMode.Center;
            pieSeries.PieStyle = PieStyle.SmoothEdgePie;
            pieChart.Series.Add(pieSeries);

            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                pieSeries.Values.Add(rand.Next(100) + 10);
            }

            return pieChart;
        }

        [Serializable]
        public class ActivatePanelCallback : INActivatePanelCallback
        {
            #region INActivatePanelCallback Members

            void INActivatePanelCallback.OnActivatePanel(NThinChartControl control, NContentPanel newActivePanel, NContentPanel oldActivePanel)
            {
                // when the currently active panel changes, change its border to prompt the user
                if (oldActivePanel != null)
                {
                    oldActivePanel.BorderStyle = null;
                }

                if (newActivePanel != null)
                {
                    NStrokeBorderStyle border = new NStrokeBorderStyle(BorderShape.RoundedRect);
                    border.StrokeStyle.Color = Color.Red;
                    newActivePanel.BorderStyle = border;
                }

                control.UpdateView();
            }

            #endregion
        }
    }
}
