using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Drawing;
using Nevron.Dom;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NCustomRadarAxisAnglesUC : NExampleBaseUC
	{
        public NCustomRadarAxisAnglesUC()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Custom Radar Axis Angles";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
                return "The example demonstrates how to set custom radar axis angles.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
            nChartControl1.Panels.Clear();

            // set a chart title
            NLabel title = new NLabel("Montana County Comparison<br/><font size = '9pt'>Demonstrates how to create a multi measure radar chart</font>");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
            title.TextStyle.TextFormat = TextFormat.XML;
            title.ContentAlignment = ContentAlignment.BottomRight;
            title.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            title.DockMode = PanelDockMode.Top;
            title.Margins = new NMarginsL(0, 5, 0, 5);
            nChartControl1.Panels.Add(title);

            NLegend legend = new NLegend();
            legend.DockMode = PanelDockMode.Right;
            legend.Margins = new NMarginsL(5, 0, 5, 0);
            nChartControl1.Panels.Add(legend);

            // setup chart
            NRadarChart radarChart = new NRadarChart();
            radarChart.Margins = new NMarginsL(5, 0, 0, 5);
            nChartControl1.Panels.Add(radarChart);
            radarChart.DisplayOnLegend = legend;
            radarChart.DockMode = PanelDockMode.Fill;
            radarChart.RadarMode = RadarMode.MultiMeasure;
            radarChart.InnerRadius = new NLength(10, NRelativeUnit.ParentPercentage);

            // set some axis labels
            AddAxis(radarChart, "Population", true);
            AddAxis(radarChart, "Housing Units", true);
            AddAxis(radarChart, "Water", false);
            AddAxis(radarChart, "Land", true);
            AddAxis(radarChart, "Population\r\nDensity", false);
            AddAxis(radarChart, "Housing\r\nDensity", false);

            float angleStep = 180.0f / (radarChart.Axes.Count - 1);

            for (int i = 0; i < radarChart.Axes.Count; i++)
            {
                NRadarAxis radarAxis = (NRadarAxis)radarChart.Axes[i];

                ((NRadarAxisAnchor)radarAxis.Anchor).UseCustomAngle = true;
                ((NRadarAxisAnchor)radarAxis.Anchor).CustomAngle = i * angleStep;
            }

            // sample data
            object[] data = new object[]{ 
				"Cascade County", 80357, 35225, 13.75, 2697.90, 29.8, 13.1,
				"Custer County", 11696, 5360, 10.09, 3783.13, 3.1, 1.4,
				"Dawson County", 9059, 4168, 9.99, 2373.14, 3.8, 1.8,
				"Jefferson County", 10049, 4199, 2.19, 1656.64, 6.1, 2.5,
				"Missoula County", 95802, 41319, 20.37, 2597.97, 36.9, 15.9,
				"Powell County", 7180, 2930, 6.74, 2325.94, 3.1, 1.3 };

            for (int i = 0; i < 6; i++)
            {
                NRadarLineSeries radarLine = new NRadarLineSeries();
                radarChart.Series.Add(radarLine);

                int baseIndex = i * 7;
                radarLine.Name = data[baseIndex].ToString();
                baseIndex = baseIndex + 1;

                for (int j = 0; j < 6; j++)
                {
                    radarLine.Values.Add(System.Convert.ToDouble(data[baseIndex]));
                    baseIndex = baseIndex + 1;
                }

                radarLine.DataLabelStyle.Visible = false;
                radarLine.MarkerStyle.Width = new NLength(4);
                radarLine.MarkerStyle.Height = new NLength(4);
                radarLine.MarkerStyle.Visible = true;
                radarLine.BorderStyle.Width = new NLength(2);
                //radarLine.CloseContour = false;
            }

            // apply style sheet
            NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
		}


        private void AddAxis(NRadarChart radar, string title, bool applyKFormatting)
        {
            NRadarAxis axis = new NRadarAxis();

            // set title
            axis.Title = title;
            radar.Axes.Add(axis);

            if (applyKFormatting)
            {
                NLinearScaleConfigurator linearScale = axis.ScaleConfigurator as NLinearScaleConfigurator;
                linearScale.LabelValueFormatter = new NNumericValueFormatter("0,K");
            }
        }
	}
}
