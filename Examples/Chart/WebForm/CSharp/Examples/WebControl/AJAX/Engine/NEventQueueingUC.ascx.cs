using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NEventQueueingUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
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

				for (int i = 0; i < arrCustomColors2.Length; i++)
				{
					pieSeries.Values.Add(arrData[i]);
					pieSeries.Labels.Add(arrLabels[i]);
					pieSeries.FillStyles[i] = new NColorFillStyle(arrCustomColors2[i]);
					pieSeries.BorderStyles[i] = new NStrokeStyle(1, arrCustomColors2[i]);

					pieSeries.Detachments.Add(i == 5 ? 5 : 0);
				}
			}
		}

		protected void nChartControl1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			nChartControl1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true));
			nChartControl1.AjaxTools.Add(new NAjaxMouseDoubleClickCallbackTool(true));
			nChartControl1.AjaxTools.Add(new NAjaxMouseMoveCallbackTool(true));
			nChartControl1.AjaxTools.Add(new NAjaxMouseDownCallbackTool(true));
			nChartControl1.AjaxTools.Add(new NAjaxMouseUpCallbackTool(true));
		}

		protected void addResponseDelayCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			//	select the default enabled state of the mouse tools
			nChartControl1.AjaxTools.GetToolByType(typeof(NAjaxMouseClickCallbackTool)).DefaultEnabled = (Request["mouseClickCheckbox"] != null);
			nChartControl1.AjaxTools.GetToolByType(typeof(NAjaxMouseDoubleClickCallbackTool)).DefaultEnabled = (Request["mouseDoubleClickCheckbox"] != null);
			nChartControl1.AjaxTools.GetToolByType(typeof(NAjaxMouseMoveCallbackTool)).DefaultEnabled = (Request["mouseMoveCheckbox"] != null);
			nChartControl1.AjaxTools.GetToolByType(typeof(NAjaxMouseDownCallbackTool)).DefaultEnabled = (Request["mouseDownCheckbox"] != null);
			nChartControl1.AjaxTools.GetToolByType(typeof(NAjaxMouseUpCallbackTool)).DefaultEnabled = (Request["mouseUpCheckbox"] != null);

			//	select the default enabled state of client side services
			nChartControl1.AsyncAutoRefreshEnabled = (Request["autoRefreshCheckbox"] != null);
			nChartControl1.AsyncRequestWaitCursorEnabled = (Request["waitCursorCheckbox"] != null);

			int val;

			if(int.TryParse(Request["autoRefreshIntervalCombo"], out val))
				nChartControl1.AsyncRefreshInterval = val;

			if(int.TryParse(Request["mouseClickPriorityCombo"], out val))
				nChartControl1.AsyncClickEventPriority = val;

			if (int.TryParse(Request["mouseClickQueueLengthCombo"], out val))
				nChartControl1.AsyncClickEventQueueLength = val;

			if (int.TryParse(Request["mouseDoubleClickPriorityCombo"], out val))
				nChartControl1.AsyncDoubleClickEventPriority = val;

			if (int.TryParse(Request["mouseDoubleClickQueueLengthCombo"], out val))
				nChartControl1.AsyncDoubleClickEventQueueLength = val;

			if (int.TryParse(Request["mouseMovePriorityCombo"], out val))
				nChartControl1.AsyncMouseMoveEventPriority = val;

			if (int.TryParse(Request["mouseMoveQueueLengthCombo"], out val))
				nChartControl1.AsyncMouseMoveEventQueueLength = val;

			if (int.TryParse(Request["mouseDownPriorityCombo"], out val))
				nChartControl1.AsyncMouseDownEventPriority = val;

			if (int.TryParse(Request["mouseDownQueueLengthCombo"], out val))
				nChartControl1.AsyncMouseDownEventQueueLength = val;

			if (int.TryParse(Request["mouseUpPriorityCombo"], out val))
				nChartControl1.AsyncMouseUpEventPriority = val;
			
			if (int.TryParse(Request["mouseUpQueueLengthCombo"], out val))
				nChartControl1.AsyncMouseUpEventQueueLength = val;

			if (int.TryParse(Request["refreshPriorityCombo"], out val))
				nChartControl1.AsyncRefreshPriority = val;

			if (int.TryParse(Request["refreshQueueLengthCombo"], out val))
				nChartControl1.AsyncRefreshQueueLength = val;

			CustomHttpHandlerCallback httpHandlerCallback = nChartControl1.HttpHandlerCallback as CustomHttpHandlerCallback;
			httpHandlerCallback.SimulateResponseDelay = addResponseDelayCheckBox.Checked;
		}

		#region Nested Classes

		[Serializable]
		public class CustomHttpHandlerCallback : NHttpHandlerCallback
		{
			#region INHttpHandlerCallback Members

			public override void OnAsyncClick(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				DoSimulateResponseDelay();
				ColorPieSegment(state, args, Color.White);
			}

            public override void OnAsyncDoubleClick(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				DoSimulateResponseDelay();
				ExplodePieSegment(state, args, -10);
			}

            public override void OnAsyncMouseDown(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				DoSimulateResponseDelay();
				ColorPieSegment(state, args, Color.Violet);
			}

            public override void OnAsyncMouseMove(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				DoSimulateResponseDelay();
				ExplodePieSegment(state, args, 5);
			}

            public override void OnAsyncMouseUp(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				DoSimulateResponseDelay();
				ColorPieSegment(state, args, Color.Pink);
			}

            public override void OnAsyncRefresh(string webControlId, System.Web.HttpContext context, NStateObject state, EventArgs args)
			{
				DoSimulateResponseDelay();
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
				NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;
				NChartSessionStateObject chartState = state as NChartSessionStateObject;
				NHitTestResult result = chartState.HitTest(args);

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

			private void ColorPieSegment(NStateObject state, EventArgs e, Color c)
			{
				NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;
				NChartSessionStateObject chartState = state as NChartSessionStateObject;
				NHitTestResult result = chartState.HitTest(args);
				NRootPanel rootPanel = chartState.Document.RootPanel;

				if (result.ChartElement == ChartElement.DataPoint)
				{
					NPieSeries pieSeries = result.Series as NPieSeries;
					for (int i = 0; i < pieSeries.Values.Count; i++)
					{
						if (i == result.DataPointIndex)
						{
							pieSeries.FillStyles[i] = new NColorFillStyle(c);
							pieSeries.BorderStyles[i] = new NStrokeStyle(1, Color.White);
						}
						else
						{
							int colorIndex = i % NExampleUC.arrCustomColors2.Length;
							Color color = NExampleUC.arrCustomColors2[colorIndex];

							pieSeries.FillStyles[i] = new NColorFillStyle(color);
							pieSeries.BorderStyles[i] = new NStrokeStyle(1, color);
						}
					}
				}
			}

			private void DoSimulateResponseDelay()
			{
				if (!SimulateResponseDelay)
					return;

				System.Threading.Thread.Sleep(600);
			}
				
			#endregion

			#region Fields

			public bool SimulateResponseDelay = false;

			#endregion
		}

		#endregion
	}
}
