using System;
using System.Drawing;
using System.Web.UI.WebControls;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDiagnosticsUC : NExampleUC
	{
		#region Event Handlers

		protected void Page_Load(object sender, System.EventArgs e)
		{
			//	initialize the Nevron Instant Callback mode
			nChartControl1.HttpHandlerCallback = new CustomHttpHandlerCallback();

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

				for (int i = 0; i < arrCustomColors3.Length; i++)
				{
					pieSeries.Values.Add(arrData[i]);
					pieSeries.Labels.Add(arrLabels[i]);
					pieSeries.FillStyles[i] = new NColorFillStyle(arrCustomColors3[i]);
					pieSeries.BorderStyles[i] = new NStrokeStyle(1, arrCustomColors3[i]);

					pieSeries.Detachments.Add(i == 5 ? 5 : 0);
				}
			}

			if (!IsPostBack)
			{
				int length;
				string[] names;
				int[] values;

				consoleModeDropDownList.Items.Clear();
				names = Enum.GetNames(typeof(AjaxDebugConsoleMode));
				values = (int[])Enum.GetValues(typeof(AjaxDebugConsoleMode));
				length = names.Length;
				for (int i = 0; i < length; i++)
				{
					consoleModeDropDownList.Items.Add(new ListItem(names[i], values[i].ToString()));
				}
				consoleModeDropDownList.SelectedValue = ((int)nChartControl1.AjaxDebugConsoleMode).ToString();
			}
		}

		protected void nChartControl1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			nChartControl1.AjaxTools.Add(new NAjaxMouseMoveCallbackTool(true));
		}

		protected void consoleModeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			nChartControl1.AjaxDebugConsoleMode = (AjaxDebugConsoleMode)int.Parse(consoleModeDropDownList.SelectedValue);
			hideConsoleButtonPanel.Visible = (nChartControl1.AjaxDebugConsoleMode == AjaxDebugConsoleMode.Embedded);
		}

		#endregion

		#region Nested Classes

		[Serializable]
		public class CustomHttpHandlerCallback : NHttpHandlerCallback
		{
			#region INHttpHandlerCallback Members

            public override void OnAsyncMouseMove(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				ExplodePieSegment(state, args, 5);
			}

            public override void OnAsyncRefresh(string webControlId, System.Web.HttpContext context, NStateObject state, EventArgs args)
			{
				NChartSessionStateObject chartState = state as NChartSessionStateObject;
				NRootPanel rootPanel = chartState.Document.RootPanel;
				NPieChart pieChart = rootPanel.Charts[0] as NPieChart;
				pieChart.BeginAngle += 1;
				if (pieChart.BeginAngle >= 360)
					pieChart.BeginAngle = 0;
			}

			#endregion

			#region Implementation

			private void ExplodePieSegment(NStateObject state, EventArgs e, int offset)
			{
				//	this method is called when the web control operates in the Nevron Instant Callback mode
				NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;
				NChartSessionStateObject chartState = state as NChartSessionStateObject;
				NHitTestResult result = chartState.HitTest(args);
				NRootPanel rootPanel = chartState.Document.RootPanel;

				if (result.ChartElement == ChartElement.DataPoint)
				{
					NPieSeries pieSeries = result.Series as NPieSeries;
					pieSeries.Detachments.Clear();
					for (int i = 0; i < pieSeries.Values.Count; i++)
					{
						if (i == result.DataPointIndex)
							pieSeries.Detachments.Add(offset);
						else
							pieSeries.Detachments.Add(0);
					}
				}
			}

			#endregion
		}

		#endregion
	}
}
