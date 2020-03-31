using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDynamicImageMapUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (nChartControl1.RequiresInitialization)
			{
                nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
                nChartControl1.Settings.JitterMode = JitterMode.Enabled;
				nChartControl1.Charts.Clear();
				nChartControl1.AsyncMouseMoveEventQueueLength = 1;

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
					pieSeries.InteractivityStyles.Add(i, new NInteractivityStyle(true, string.Format("{0}: {1}, {2}", i, arrLabels[i], arrData[i])));
				}
			}
		}

		protected void nChartControl1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			nChartControl1.AjaxTools.Add(new NAjaxMouseOverCallbackTool(true));
			nChartControl1.AjaxTools.Add(new NAjaxMouseOutCallbackTool(true));
		}

		protected void nChartControl1_AsyncRefresh(object sender, EventArgs e)
		{
			NRootPanel rootPanel = nChartControl1.Document.RootPanel;
			NPieChart pieChart = rootPanel.Charts[0] as NPieChart;
			pieChart.BeginAngle += 1;
			if (pieChart.BeginAngle >= 360)
				pieChart.BeginAngle = 0;
		}
		
		protected void nChartControl1_AsyncMouseOver(object sender, EventArgs e)
		{
			NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;
			if (args.ItemId == null)
			{
				return;
			}

			NElementAtomIdentifier id = new NElementAtomIdentifier(args.ItemId);
			NDataPoint dataPoint = id.FindInDocument(nChartControl1.Document) as NDataPoint;
			if (dataPoint == null)
			{
				return;
			}

			NRootPanel rootPanel = nChartControl1.Document.RootPanel;
			NPieSeries pieSeries = rootPanel.Charts[0].Series[0] as NPieSeries;
			pieSeries.FillStyles[dataPoint.IndexInSeries] = new NColorFillStyle(Color.White);
		}

		protected void nChartControl1_AsyncMouseOut(object sender, EventArgs e)
		{
			NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;
			if (args.ItemId == null)
			{
				return;
			}

			NElementAtomIdentifier id = new NElementAtomIdentifier(args.ItemId);
			NDataPoint dataPoint = id.FindInDocument(nChartControl1.Document) as NDataPoint;
			if (dataPoint == null)
			{
				return;
			}

			NRootPanel rootPanel = nChartControl1.Document.RootPanel;
			NPieSeries pieSeries = rootPanel.Charts[0].Series[0] as NPieSeries;

			int colorIndex = dataPoint.IndexInSeries % arrCustomColors2.Length;

			pieSeries.FillStyles[dataPoint.IndexInSeries] = arrCustomColors2[colorIndex];
		}
	}
}
