using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NReliabilityUC : NExampleUC
	{
		#region Event Handlers

		protected void Page_Load(object sender, System.EventArgs e)
		{
			//	decrease the session timeout to the lowest value to allow quick simulation
			//	of an expired session state
			this.Session.Timeout = 1;

			if (NevronInstantCallbackMode)
			{
				//	initialize the Nevron Instant Callback mode
				nChartControl1.HttpHandlerCallback = new CustomHttpHandlerCallback();
			}

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
		}

		protected void nChartControl1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			nChartControl1.AjaxTools.Add(new NAjaxMouseMoveCallbackTool(true));
		}

		protected void ajaxModeRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
		{
			//	apply the client side controls state to the chart control at server side

			//	select the default enabled state of the mouse move tool
			nChartControl1.AjaxTools.GetToolByType(typeof(NAjaxMouseMoveCallbackTool)).DefaultEnabled = (Request["mouseMoveCheckbox"] != null);

			//	select the default enabled state of the auto refresh service
			nChartControl1.AsyncAutoRefreshEnabled = (Request["autoRefreshCheckbox"] != null);

			NevronInstantCallbackMode = (ajaxModeRadioButtonList.SelectedValue != "microsoftAJAXCallback");
		}

		protected void nChartControl1_AsyncCustomCommand(object sender, EventArgs e)
		{
			//	this method is called when the web control operates in the standard Microsoft AJAX mode
			NCallbackCustomCommandArgs args = e as NCallbackCustomCommandArgs;
			switch (args.Command.Name)
			{
				case "restartApplication":
					try
					{
						System.Web.HttpRuntime.UnloadAppDomain();
					}
					catch(Exception ex)
					{
						System.Diagnostics.Debug.WriteLine("nChartControl1_AsyncCustomCommand, restartApplication: " + ex.Message);
					}
					break;
				case "enforceResponseDelay":
					try
					{
						SimulateResponseDelay = true;
					}
					catch (Exception ex)
					{
						System.Diagnostics.Debug.WriteLine("nChartControl1_AsyncCustomCommand, changeResponseDelay: " + ex.Message);
					}
					break;
			}
		}

		protected void nChartControl1_AsyncMouseMove(object sender, EventArgs e)
		{
			//	this method is called when the web control operates in the standard Microsoft AJAX mode
			DoSimulateResponseDelay();

			NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;
			ExplodePieSegment(args, 5);
		}
		
		protected void nChartControl1_AsyncRefresh(object sender, EventArgs e)
		{
			//	this method is called when the web control operates in the standard Microsoft AJAX mode
			DoSimulateResponseDelay();

			NRootPanel rootPanel = nChartControl1.Document.RootPanel;
			NPieChart pieChart = nChartControl1.Charts[0] as NPieChart;
			pieChart.BeginAngle += 1;
			if (pieChart.BeginAngle >= 360)
				pieChart.BeginAngle = 0;
		}

		#endregion

		#region Nested Classes

		[Serializable]
		public class CustomHttpHandlerCallback : NHttpHandlerCallback
		{
			#region INHttpHandlerCallback Members

			public override void OnAsyncCustomCommand(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackCustomCommandArgs args)
			{
				//	this method is called when the web control operates in the Nevron Instant Callback mode
				switch (args.Command.Name)
				{
					case "restartApplication":
						try
						{
							System.Web.HttpRuntime.UnloadAppDomain();
						}
						catch (Exception ex)
						{
							System.Diagnostics.Debug.WriteLine("OnAsyncCustomCommand, restartApplication: " + ex.Message);
						}
						break;
					case "enforceResponseDelay":
						try
						{
							SimulateResponseDelay = true;
						}
						catch (Exception ex)
						{
							System.Diagnostics.Debug.WriteLine("OnAsyncCustomCommand, changeResponseDelay: " + ex.Message);
						}
						break;
				}
			}

            public override void OnAsyncMouseMove(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				//	this method is called when the web control operates in the Nevron Instant Callback mode
				DoSimulateResponseDelay();

				ExplodePieSegment(state, args, 5);
			}

            public override void OnAsyncRefresh(string webControlId, System.Web.HttpContext context, NStateObject state, EventArgs args)
			{
				//	this method is called when the web control operates in the Nevron Instant Callback mode
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

			private void DoSimulateResponseDelay()
			{
				if (!SimulateResponseDelay)
					return;

				SimulateResponseDelay = false;
				System.Threading.Thread.Sleep(6000);
			}

			#endregion

			#region Properties

			public bool SimulateResponseDelay
			{
				get
				{
					if (System.Web.HttpContext.Current.Session["SimulateResponseDelay"] != null)
						return (bool)System.Web.HttpContext.Current.Session["SimulateResponseDelay"];
					return false;
				}
				set
				{
					System.Web.HttpContext.Current.Session["SimulateResponseDelay"] = value;
				}
			}

			#endregion
		}

		#endregion

		#region Implementation

		private void ExplodePieSegment(EventArgs e, int offset)
		{
			//	this method is called when the web control operates in the standard Microsoft AJAX mode
			NCallbackMouseEventArgs args = e as NCallbackMouseEventArgs;
			NHitTestResult result = nChartControl1.HitTest(args);
			NRootPanel rootPanel = nChartControl1.Document.RootPanel;

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

		private void DoSimulateResponseDelay()
		{
			if (!SimulateResponseDelay)
				return;

			SimulateResponseDelay = false;
			System.Threading.Thread.Sleep(6000);
		}

		#endregion

		#region Properties

		public bool SimulateResponseDelay
		{
			get
			{
				if (Session["SimulateResponseDelay"] != null)
					return (bool)Session["SimulateResponseDelay"];
				return false;
			}
			set
			{
				Session["SimulateResponseDelay"] = value;
			}
		}

		public bool NevronInstantCallbackMode
		{
			get
			{
				if (Session["NevronInstantCallbackMode"] != null)
					return (bool)Session["NevronInstantCallbackMode"];
				return true;
			}
			set
			{
				Session["NevronInstantCallbackMode"] = value;
			}
		}

		#endregion
	}
}
