using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NPersistentServerControlUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// the control will save its state in the temp directory along with the
			// temporary image files
			nChartControl1.ServerSettings.ControlStateSettings.PersistControlState = true;

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            nChartControl1.Settings.JitterMode = JitterMode.Enabled;
            nChartControl1.Settings.JitteringSteps = 4;

			if (!IsPostBack)
			{
                // set a chart title
				NLabel title = nChartControl1.Labels.AddHeader("Persistent server control");
				title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
				title.ContentAlignment = ContentAlignment.BottomCenter;
				title.Location = new NPointL(
					new NLength(50, NRelativeUnit.ParentPercentage),
					new NLength(2, NRelativeUnit.ParentPercentage));

				// no legend
				nChartControl1.Legends.Clear();

				// setup a pie chart
				NPieChart chart = new NPieChart();
				nChartControl1.Charts.Clear();
				nChartControl1.Charts.Add(chart);

				chart.Enable3D = true;
				chart.LightModel.EnableLighting = true;
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre);
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
                chart.Location = new NPointL(
					new NLength(10, NRelativeUnit.ParentPercentage),
                    new NLength(20, NRelativeUnit.ParentPercentage));
                chart.Size = new NSizeL(
					new NLength(80, NRelativeUnit.ParentPercentage),
                    new NLength(65, NRelativeUnit.ParentPercentage));

				// add a pie series
				NPieSeries pieSeries = (NPieSeries)chart.Series.Add(SeriesType.Pie);
				pieSeries.PieStyle = PieStyle.SmoothEdgePie;
				pieSeries.LabelMode = PieLabelMode.SpiderNoOverlap;

				// show a hand when over a pie slice
				pieSeries.InteractivityStyle.Cursor.Type = CursorType.Hand;

                pieSeries.AddDataPoint(new NDataPoint(8, "Pie 1"));
                pieSeries.AddDataPoint(new NDataPoint(4, "Pie 2"));
                pieSeries.AddDataPoint(new NDataPoint(7, "Pie 3"));
                pieSeries.AddDataPoint(new NDataPoint(9, "Pie 4"));

				for (int i = 0; i < pieSeries.Values.Count; i++)
				{
					pieSeries.FillStyles[i] = new NColorFillStyle(WebExamplesUtilities.RandomColor());
				}
			}

			this.AddPieButton.Click += new EventHandler(this.AddPieButton_Click);
			this.DeleteLastPieButton.Click += new EventHandler(this.DeleteLastPieButton_Click);
		}

		private void AddPieButton_Click(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NPieSeries pieSeries = (NPieSeries)chart.Series[0];

			double value = Convert.ToDouble(PieValueTextBox.Text);
			String text = "Pie " + Convert.ToString(pieSeries.Values.Count + 1);
			NFillStyle fill = new NColorFillStyle(WebExamplesUtilities.RandomColor());

			pieSeries.AddDataPoint(new NDataPoint(value, text, fill));
		}

		private void DeleteLastPieButton_Click(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NPieSeries pieSeries = (NPieSeries)chart.Series[0];

			if (pieSeries.Values.Count == 0)
				return;

			int nLastIndex = pieSeries.Values.Count - 1;

			pieSeries.Values.RemoveAt(nLastIndex);
		}
	}
}
