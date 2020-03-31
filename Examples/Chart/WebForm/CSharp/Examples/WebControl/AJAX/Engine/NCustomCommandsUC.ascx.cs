using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NCustomCommandsUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (nChartControl1.RequiresInitialization)
			{
                nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
                nChartControl1.Settings.JitterMode = JitterMode.Enabled;
				nChartControl1.Charts.Clear();

				NPieChart pieChart = new NPieChart();
				nChartControl1.Panels.Add(pieChart);

				pieChart.Enable3D = true;
				pieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
				pieChart.Projection.Elevation = 312;
				pieChart.BoundsMode = BoundsMode.Fit;
				pieChart.Location = new NPointL(
					new NLength(10, NRelativeUnit.ParentPercentage),
					new NLength(10, NRelativeUnit.ParentPercentage));
				pieChart.Size = new NSizeL(
					new NLength(80, NRelativeUnit.ParentPercentage),
					new NLength(80, NRelativeUnit.ParentPercentage));

				pieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);
				pieChart.LightModel.LightSources[0].Specular = Color.FromArgb(64, 64, 64);
				pieChart.LightModel.LightSources[1].Specular = Color.FromArgb(64, 64, 64);
				pieChart.LightModel.LightSources[2].Specular = Color.FromArgb(64, 64, 64);
				pieChart.Radius = new NLength(48, NRelativeUnit.ParentPercentage);
				pieChart.InnerRadius = new NLength(31, NRelativeUnit.ParentPercentage);

				NPieSeries pieSeries = (NPieSeries)pieChart.Series.Add(SeriesType.Pie);
				pieSeries.BorderStyle = new NStrokeStyle(new NLength(5), Color.White);
				pieSeries.PieStyle = PieStyle.Torus;

				string[] arrLabels = new string[]
				{
					"Cars",
					"Trains",
					"Airplanes",
					"Buses",
					"Bikes",
					"Motorcycles",
					"Shuttles",
					"Rollers",
					"Ski",
					"Surf"
				};

				double[] arrData = new double[10] { 98, 80, 57, 98, 96, 84, 54, 73, 40, 53 };

				for (int i = 0; i < arrCustomColors2.Length; i++)
				{
					pieSeries.Values.Add(arrData[i]);
					pieSeries.Labels.Add(arrLabels[i]);
					pieSeries.FillStyles[i] = new NColorFillStyle(arrCustomColors2[i]);
					pieSeries.BorderStyles[i] = new NStrokeStyle(1, arrCustomColors2[i]);

					if (i == 5)
					{
						pieSeries.Detachments.Add(5);
					}
					else
					{
						pieSeries.Detachments.Add(0);
						pieSeries.InteractivityStyles.Add(i, new NInteractivityStyle(true, string.Format("{0} ({1})", arrLabels[i], arrData[i])));
					}
				}
			}
		}

		protected void nChartControl1_AsyncCustomCommand(object sender, EventArgs e)
		{
			NCallbackCustomCommandArgs args = e as NCallbackCustomCommandArgs;
			NCallbackCommand command = args.Command;

			NPieSeries pieSeries;
			switch (command.Name)
			{
				case "changeColor":
					string idText = command.Arguments["id"] as string;
					if (idText == null)
						break;

					NElementAtomIdentifier id = new NElementAtomIdentifier(idText);
					NChartNode node = id.FindInDocument(nChartControl1.Document) as NChartNode;
					if (node == null)
						break;
					NHitTestResult hitTestResult = new NHitTestResult(node);
					if (hitTestResult.ChartElement != ChartElement.DataPoint)
						break;
					pieSeries = hitTestResult.Series as NPieSeries;
					if (pieSeries == null)
						break;

					Color c = Color.Red;
					if (command.Arguments["color"].ToString() == "blue")
						c = Color.Blue;
					NColorFillStyle fs = pieSeries.FillStyles[hitTestResult.DataPointIndex] as NColorFillStyle;
					if (fs == null)
						break;

					pieSeries.FillStyles[hitTestResult.DataPointIndex] = new NColorFillStyle(c);

					clientSideRedrawRequired = (fs.Color != c);
					break;
				case "rotate10Degrees":
					NRootPanel rootPanel = nChartControl1.Document.RootPanel;
					NPieChart pieChart = nChartControl1.Charts[0] as NPieChart;
					pieChart.BeginAngle += 10;
					if (pieChart.BeginAngle >= 360)
						pieChart.BeginAngle = pieChart.BeginAngle - 360;
					break;
			}
		}

		protected void nChartControl1_AsyncQueryCommandResult(object sender, EventArgs e)
		{
			NCallbackQueryCommandResultArgs args = e as NCallbackQueryCommandResultArgs;
			NCallbackCommand command = args.Command;
			NAjaxXmlTransportBuilder resultBuilder = args.ResultBuilder;

			switch(command.Name)
			{
				case "queryCurrentAngle":
					//	build a custom response data section
					NRootPanel rootPanel = nChartControl1.Document.RootPanel;
					NPieChart pieChart = nChartControl1.Charts[0] as NPieChart;

					NAjaxXmlDataSection dataSection = new NAjaxXmlDataSection("angle");
					dataSection.Data = pieChart.BeginAngle.ToString();
					resultBuilder.AddDataSection(dataSection);
					break;

				case "changeColor":
					//	add a built-in data section that will enforce full image refresh at the client
					if (clientSideRedrawRequired && !resultBuilder.ContainsRedrawDataSection())
						resultBuilder.AddRedrawDataSection(nChartControl1);
					break;

				case "rotate10Degrees":
					if (!resultBuilder.ContainsRedrawDataSection())
						resultBuilder.AddRedrawDataSection(nChartControl1);
					break;
			}
		}

		protected void nChartControl1_AsyncRefresh(object sender, EventArgs e)
		{
			NRootPanel rootPanel = nChartControl1.Document.RootPanel;
			NPieChart pieChart = nChartControl1.Charts[0] as NPieChart;
			pieChart.BeginAngle += 1;
			if (pieChart.BeginAngle >= 360)
				pieChart.BeginAngle = 0;
		}

		#region Fields

		private bool clientSideRedrawRequired = false;

		#endregion
	}
}
