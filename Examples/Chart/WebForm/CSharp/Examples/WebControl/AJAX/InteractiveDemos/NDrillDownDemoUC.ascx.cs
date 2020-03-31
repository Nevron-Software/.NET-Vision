using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDrillDownDemoUC : NExampleUC
	{
		//	sample data, imitating the results of a query
		static DateTime startDate = new DateTime(2008, 11, 01);
		static string[] regionNames = new string[] { "Africa", "America", "Asia", "Europe", "Oceania" };
		static int[][] hitsPerDayPerRegion = new int[][]
		{
			new int[] {658, 8467, 8327, 7403, 1836},
			new int[] {467, 9658, 7740, 8363, 2273},
			new int[] {865, 7846, 7832, 9700, 3186},
			new int[] {568, 6867, 3827, 7483, 2227},
			new int[] {566, 8682, 6737, 8223, 3277},
		};

		//	stores the index of the currently selected bar series data point
		int SelectedDataPointIndex
		{
			get
			{
				if (Session["SelectedDataPointIndex"] == null)
					return -1;

				return (int)Session["SelectedDataPointIndex"];
			}
			set
			{
				Session["SelectedDataPointIndex"] = value;
			}
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			//	create a chart that displays the total hits per day
			LoadBarChart();
			//	create a chart that displays the hits hits per region for the selected day
			LoadPieChart();
		}

		#region Bar Chart

		void LoadBarChart()
		{
			if (nChartControl1.RequiresInitialization)
			{
				nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
				nChartControl1.Legends.Clear();

				// set a chart title
				NLabel header = nChartControl1.Labels.AddHeader("Total Web Site Hits per Day");
				header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
				header.ContentAlignment = ContentAlignment.BottomRight;
				header.Location = new NPointL(
					new NLength(3, NRelativeUnit.ParentPercentage),
					new NLength(3, NRelativeUnit.ParentPercentage));

				// setup a Bar chart
				NChart chart = nChartControl1.Charts[0];
				chart.Enable3D = false;
				chart.BoundsMode = BoundsMode.Stretch;
				chart.Location = new NPointL(
					new NLength(4, NRelativeUnit.ParentPercentage),
					new NLength(25, NRelativeUnit.ParentPercentage));
				chart.Size = new NSizeL(
					new NLength(88, NRelativeUnit.ParentPercentage),
					new NLength(75, NRelativeUnit.ParentPercentage));

				// setup Y axis
				NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
				linearScale.InnerMajorTickStyle.Visible = false;

				// add interlace stripe to the Y axis
				NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(0xfe, 0xed, 0xe2)), null, true, 0, 0, 1, 1);
				stripStyle.Interlaced = true;
				stripStyle.SetShowAtWall(ChartWallType.Back, true);
				stripStyle.SetShowAtWall(ChartWallType.Left, true);
				linearScale.StripStyles.Add(stripStyle);

				// setup X axis
				NDateTimeScaleConfigurator timeScale = new NDateTimeScaleConfigurator();
				timeScale.EnableUnitSensitiveFormatting = true;
				timeScale.DateTimeUnitFormatterPairs.Clear();
				timeScale.DateTimeUnitFormatterPairs.Add(new NDateTimeUnitFormatterPair(NDateTimeUnit.Day, new NDateTimeValueFormatter("d/MM/yy")));
				timeScale.LabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };
				timeScale.MajorTickMode = MajorTickMode.CustomStep;
				timeScale.CustomStep = new NDateTimeSpan(1, NDateTimeUnit.Day);
				timeScale.InnerMajorTickStyle.Visible = false;
				timeScale.RoundToTickMin = false;
				timeScale.RoundToTickMax = false;
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeScale;

				// setup bar series
				NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
				bar.Name = "Total Web Site Hits per Day";
				bar.DataLabelStyle.Format = "<value>";
				bar.DataLabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8);
				bar.BarWidth = new NLength(10, NRelativeUnit.ParentPercentage);
				bar.InflateMargins = true;
				bar.UseXValues = true;
				bar.UseZValues = false;

				// initialize data points
				DateTime date = startDate;
				int lengthDays = hitsPerDayPerRegion.Length;
				for (int i = 0; i < lengthDays; i++)
				{
					int totalHits = 0;
					int lengthRegions = hitsPerDayPerRegion[i].Length;
					for (int j = 0; j < lengthRegions; j++)
					{
						totalHits += hitsPerDayPerRegion[i][j];
					}

					bar.XValues.Add(date);
					bar.Values.Add(totalHits);

					if (i > 0)
					{
						bar.InteractivityStyles.Add(i, new NInteractivityStyle(true, i.ToString(), string.Format("{0}: {1}", date.ToString("dd/MMM/yyyy"), totalHits), CursorType.Hand));
					}

					date = date.AddDays(1);
				}

				// apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
				styleSheet.Apply(nChartControl1.Document);

				// select the first bar
				NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);
				bar.FillStyles[0] = new NColorFillStyle(palette.SeriesColors[1]);
			}
		}

		protected void nChartControl1_QueryAjaxTools(object sender, EventArgs e)
		{
			nChartControl1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true, false));
			nChartControl1.AjaxTools.Add(new NAjaxTooltipTool(true));
			nChartControl1.AjaxTools.Add(new NAjaxDynamicCursorTool(true));
		}

		protected void nChartControl1_AsyncClick(object sender, EventArgs e)
		{
			NHitTestResult result = nChartControl1.HitTest(e as NCallbackMouseEventArgs);
			if (result.ChartElement == ChartElement.DataPoint)
			{
				NBarSeries barSeries = result.Series as NBarSeries;
				barSeries.FillStyles.Clear();
				NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);
				barSeries.FillStyles[result.DataPointIndex] = new NColorFillStyle(palette.SeriesColors[1]);

				SelectedDataPointIndex = result.DataPointIndex;

				DateTime date = startDate;
				barSeries.InteractivityStyles.Clear();
				int lengthDays = hitsPerDayPerRegion.Length;
				for (int i = 0; i < lengthDays; i++)
				{
					int totalHits = 0;
					int lengthRegions = hitsPerDayPerRegion[i].Length;
					for (int j = 0; j < lengthRegions; j++)
					{
						totalHits += hitsPerDayPerRegion[i][j];
					}

					if (SelectedDataPointIndex != i)
						barSeries.InteractivityStyles.Add(i, new NInteractivityStyle(true, i.ToString(), string.Format("{0}: {1}", date.ToString("dd/MMM/yyyy"), totalHits), CursorType.Hand));
					
					date = date.AddDays(1);
				}
			}
		}

		#endregion

		#region Pie Chart

		class PieChartHttpHandlerCallback : NHttpHandlerCallback
		{
			public override void OnAsyncCustomCommand(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackCustomCommandArgs args)
			{
				switch (args.Command.Name)
				{
					case "displayHitsForDate":
						NChartSessionStateObject chartState = state as NChartSessionStateObject;
						NRootPanel rootPanel = chartState.Document.RootPanel;
						NPieSeries pieSeries = rootPanel.Charts[0].Series[0] as NPieSeries;
						
						int dataPointIndex = int.Parse(args.Command.Arguments["dataPointIndex"] as string);
						int[] data = NDrillDownDemoUC.hitsPerDayPerRegion[dataPointIndex];

						pieSeries.Values.Clear();
						pieSeries.Labels.Clear();
						int length = hitsPerDayPerRegion[0].Length;
						for (int i = 0; i < length; i++)
						{
							pieSeries.Values.Add(data[i]);
							pieSeries.Labels.Add(NDrillDownDemoUC.regionNames[i]);
						}

						DateTime selectedDate = NDrillDownDemoUC.startDate.AddDays(dataPointIndex);
						NLabel header = rootPanel.Labels[0];
						header.Text = selectedDate.ToString("dd/MMM/yyyy") + ", Hits per Region";

						break;
				}
			}
		}

		void LoadPieChart()
		{
			nChartControl2.HttpHandlerCallback = new PieChartHttpHandlerCallback();

			if (nChartControl2.RequiresInitialization)
			{
				nChartControl2.BackgroundStyle.FrameStyle.Visible = false;
				nChartControl2.Settings.JitterMode = JitterMode.Enabled;
				nChartControl2.Legends.Clear();
				nChartControl2.Charts.Clear();

				// read the selected bar data point info
				NChart barChart = nChartControl1.Charts[0];
				NBarSeries bar = (NBarSeries)barChart.Series[0];
				if (bar.XValues.Count == 0)
					return;

				DateTime selectedDate = DateTime.FromOADate((double)bar.XValues[0]);
				
				// set a chart title
				NLabel header = new NLabel(selectedDate.ToString("dd/MMM/yyyy") + ", Hits per Region");
				header.TextStyle.FontStyle = new NFontStyle("Verdana", 10, FontStyle.Regular);
				header.DockMode = PanelDockMode.Top;
				nChartControl2.Panels.Add(header);

				// setup a Pie chart
				NPieChart pieChart = new NPieChart();
				pieChart.DockMode = PanelDockMode.Fill;
				nChartControl2.Panels.Add(pieChart);

				pieChart.Enable3D = true;
				pieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated);
				pieChart.Projection.Elevation = 312;
				pieChart.BoundsMode = BoundsMode.Fit;
				pieChart.Location = new NPointL(
					new NLength(20, NRelativeUnit.ParentPercentage),
					new NLength(35, NRelativeUnit.ParentPercentage));
				pieChart.Size = new NSizeL(
					new NLength(53, NRelativeUnit.ParentPercentage),
					new NLength(53, NRelativeUnit.ParentPercentage));

				pieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);
				pieChart.LightModel.LightSources[0].Specular = Color.FromArgb(64, 64, 64);
				pieChart.LightModel.LightSources[1].Specular = Color.FromArgb(64, 64, 64);
				pieChart.LightModel.LightSources[2].Specular = Color.FromArgb(64, 64, 64);
				pieChart.Radius = new NLength(48, NRelativeUnit.ParentPercentage);
				pieChart.InnerRadius = new NLength(31, NRelativeUnit.ParentPercentage);

				// setup a Pie series
				NPieSeries pieSeries = (NPieSeries)pieChart.Series.Add(SeriesType.Pie);
				pieSeries.BorderStyle = new NStrokeStyle(new NLength(5), Color.White);
				pieSeries.LabelMode = PieLabelMode.SpiderNoOverlap;
				pieSeries.PieStyle = PieStyle.Torus;

				int length = hitsPerDayPerRegion[0].Length;
				for (int i = 0; i < length; i++)
				{
					pieSeries.Values.Add(hitsPerDayPerRegion[0][i]);
					pieSeries.Labels.Add(regionNames[i]);
				}

				// apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
				styleSheet.Apply(nChartControl2.Document);
			}
		}

		#endregion
	}
}
