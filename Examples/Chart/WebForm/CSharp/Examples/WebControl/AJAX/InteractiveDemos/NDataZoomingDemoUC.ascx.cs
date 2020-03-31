using System;
using System.Drawing;
using System.Web;
using Nevron.Chart;
using Nevron.Chart.View;
using Nevron.Chart.WebForm;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NDataZoomingDemoUC : NExampleUC
	{
		//	sample data, imitating the results of a query
		static int waveDataLenth = 5000;
		static double waveDataWave1Factor = 100;
		static double waveDataWave1Length = 10;

		static double waveDataWave2Factor = 0.9;
		static double waveDataWave2Length = 77;
		static double waveDataWave2Phase = 10;

		static double waveDataWave3Factor = 1.1;
		static double waveDataWave3Length = 178;
		static double waveDataWave3Phase = 50;

		static double[] waveData;

		//	configuration
		static double defaultDataWindowWidth = 750;

		//	initialize the sample data
		static NDataZoomingDemoUC()
		{
			waveData = new double[waveDataLenth];
			for (int i = 0; i < waveDataLenth; i++)
			{
				waveData[i] = Math.Sin(i / waveDataWave1Length) * waveDataWave1Factor;
				waveData[i] *= Math.Sin((i - waveDataWave2Phase) / waveDataWave2Length) * waveDataWave2Factor;
				waveData[i] *= Math.Sin((i - waveDataWave3Phase) / waveDataWave3Length) * waveDataWave3Factor;
			}
		}

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
			//	create the full data preview
			CreatePreviewChart();
			//	create the data zoom chart
			CreateZoomChart();
		}

		#region Preview Chart

		class PreviewHttpHandlerCallback : NHttpHandlerCallback
		{
			public override void OnAsyncClick(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackMouseEventArgs args)
			{
				NPointF ptViewPoint = new NPointF((float)args.Point.X, 0);
				UpdateDataWindow(webControlId, context, state, ptViewPoint);
			}

			public override void OnAsyncCustomCommand(string webControlId, System.Web.HttpContext context, NStateObject state, NCallbackCustomCommandArgs args)
			{
				switch (args.Command.Name)
				{
					case "setDataWindowWidth":
						NPointF ptViewPoint = new NPointF(float.Parse(args.Command.Arguments["x"] as string), 0f);
						DataWindowWidth = double.Parse(args.Command.Arguments["width"] as string);
						UpdateDataWindow(webControlId, context, state, ptViewPoint);
						break;
				}
			}

			void UpdateDataWindow(string webControlId, System.Web.HttpContext context, NStateObject state, NPointF ptViewPoint)
			{
				NChartSessionStateObject chartState = state as NChartSessionStateObject;
				NRootPanel rootPanel = chartState.Document.RootPanel;
				NCartesianChart chart = rootPanel.Charts[0] as NCartesianChart;
				NVector2DD vecScalePoint = new NVector2DD();
				NAxis xAxis = chart.Axis(StandardAxis.PrimaryX);
				NAxis yAxis = chart.Axis(StandardAxis.PrimaryY);

				using (NChartRasterView view = new NChartRasterView(chartState.Document, chartState.Size, NResolution.ScreenResolution))
				{
					view.RecalcLayout();

					NViewToScale2DTransformation viewToScale = new NViewToScale2DTransformation(
						view.Context,
						chart,
						(int)StandardAxis.PrimaryX,
						(int)StandardAxis.PrimaryY
						);

					if (viewToScale.Transform(ptViewPoint, ref vecScalePoint))
					{
						double rangeMin = vecScalePoint.X - DataWindowWidth / 2;
						rangeMin = xAxis.Scale.ViewRange.GetValueInRange(rangeMin);

						double rangeMax = rangeMin + DataWindowWidth;
						rangeMax = xAxis.Scale.ViewRange.GetValueInRange(rangeMax);

						rangeMin = rangeMax - DataWindowWidth;

						NRangeSelection selection = chart.RangeSelections[0] as NRangeSelection;
						selection.HorizontalAxisRange = new NRange1DD(rangeMin, rangeMax);
						selection.VerticalAxisRange = new NRange1DD(-waveDataWave1Factor, waveDataWave1Factor);
					}
				}
			}

			double DataWindowWidth
			{
				get
				{
					if (HttpContext.Current.Session["DataWindowWidth"] == null)
						return defaultDataWindowWidth;
					return (double)HttpContext.Current.Session["DataWindowWidth"];
				}
				set
				{
					HttpContext.Current.Session["DataWindowWidth"] = value;
				}
			}
		}

		void CreatePreviewChart()
		{
			nChartControl1.HttpHandlerCallback = new PreviewHttpHandlerCallback();

			if (nChartControl1.RequiresInitialization)
			{
				nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
				nChartControl1.Legends.Clear();

				// set a chart title
				NLabel header = nChartControl1.Labels.AddHeader("Wave Preview");
				header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
				header.ContentAlignment = ContentAlignment.BottomRight;
				header.Location = new NPointL(
					new NLength(3, NRelativeUnit.ParentPercentage),
					new NLength(3, NRelativeUnit.ParentPercentage));

				// setup a Smooth Line chart
				NCartesianChart chart = nChartControl1.Charts[0] as NCartesianChart;
				chart.BoundsMode = BoundsMode.Stretch;
				chart.Location = new NPointL(
					new NLength(4, NRelativeUnit.ParentPercentage),
					new NLength(25, NRelativeUnit.ParentPercentage));
				chart.Size = new NSizeL(
					new NLength(88, NRelativeUnit.ParentPercentage),
					new NLength(75, NRelativeUnit.ParentPercentage));

				// setup X axis
				NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

				// setup Y axis
				NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
				scaleY.InnerMajorTickStyle.Visible = false;

				// add interlace stripe to the Y axis
				NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(0xfe, 0xed, 0xe2)), null, true, 0, 0, 1, 1);
				stripStyle.Interlaced = true;
				stripStyle.SetShowAtWall(ChartWallType.Back, true);
				stripStyle.SetShowAtWall(ChartWallType.Left, true);
				scaleY.StripStyles.Add(stripStyle);

				// add the line
				NSmoothLineSeries line = (NSmoothLineSeries)chart.Series.Add(SeriesType.SmoothLine);
				line.Name = "Wave";
				line.Legend.Mode = SeriesLegendMode.None;
				line.UseXValues = false;
				line.UseZValues = false;
				line.InflateMargins = true;
				line.DataLabelStyle.Visible = false;
				line.MarkerStyle.Visible = false;
				line.BorderStyle.Width = new NLength(1, NGraphicsUnit.Pixel);

				// initialize data points
				for (int i = 0; i < waveDataLenth; i++)
				{
					line.Values.Add(waveData[i]);
				}

				// apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
				styleSheet.Apply(nChartControl1.Document);

				// select a default window
				NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);
				Color selectionBorderColor = palette.SeriesColors[2];
				Color selectionFillColor = Color.FromArgb(64, palette.SeriesColors[1]);

				NRangeSelection selection = new NRangeSelection((int)StandardAxis.PrimaryX, (int)StandardAxis.PrimaryY);
				selection.BorderStyle = new NStrokeStyle(1, selectionBorderColor);
				selection.FillStyle = new NColorFillStyle(selectionFillColor);
				selection.HorizontalAxisRange = new NRange1DD(0, defaultDataWindowWidth);
				selection.VerticalAxisRange = new NRange1DD(-waveDataWave1Factor, waveDataWave1Factor);
				selection.Visible = true;
				chart.RangeSelections.Add(selection);
			}
		}

		protected void nChartControl1_QueryAjaxTools(object sender, EventArgs e)
		{
			nChartControl1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true));
		}

		#endregion

		#region Zoom Chart

		void CreateZoomChart()
		{
			if (nChartControl2.RequiresInitialization)
			{
				//	reset the data window width
				HttpContext.Current.Session["DataWindowWidth"] = defaultDataWindowWidth;

				// set up the chart control
				nChartControl2.BackgroundStyle.FrameStyle.Visible = false;
				nChartControl2.Legends.Clear();

				// set a chart title
				NLabel header = nChartControl2.Labels.AddHeader("Wave Details");
				header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
				header.ContentAlignment = ContentAlignment.BottomRight;
				header.Location = new NPointL(
					new NLength(3, NRelativeUnit.ParentPercentage),
					new NLength(3, NRelativeUnit.ParentPercentage));

				// setup a Smooth Line chart
				NCartesianChart chart = nChartControl2.Charts[0] as NCartesianChart;
				chart.BoundsMode = BoundsMode.Stretch;
				chart.Location = new NPointL(
					new NLength(4, NRelativeUnit.ParentPercentage),
					new NLength(25, NRelativeUnit.ParentPercentage));
				chart.Size = new NSizeL(
					new NLength(88, NRelativeUnit.ParentPercentage),
					new NLength(75, NRelativeUnit.ParentPercentage));

				// setup X axis
				NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;
				scaleX.RoundToTickMin = false;
				scaleX.RoundToTickMax = false;

				// setup Y axis
				NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
				scaleY.InnerMajorTickStyle.Visible = false;

				// add interlace stripe to the Y axis
				NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(0xfe, 0xed, 0xe2)), null, true, 0, 0, 1, 1);
				stripStyle.Interlaced = true;
				stripStyle.SetShowAtWall(ChartWallType.Back, true);
				stripStyle.SetShowAtWall(ChartWallType.Left, true);
				scaleY.StripStyles.Add(stripStyle);

				// add the line
				NSmoothLineSeries line = (NSmoothLineSeries)chart.Series.Add(SeriesType.SmoothLine);
				line.Name = "Wave";
				line.Legend.Mode = SeriesLegendMode.None;
				line.UseXValues = true;
				line.InflateMargins = true;
				line.DataLabelStyle.Visible = false;
				line.MarkerStyle.Visible = false;
				line.BorderStyle.Width = new NLength(1, NGraphicsUnit.Pixel);

				// initialize data points
				for (int i = 0; i < defaultDataWindowWidth; i++)
				{
					line.XValues.Add(i);
					line.Values.Add(waveData[i]);
				}

				// apply style sheet
				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
				styleSheet.Apply(nChartControl2.Document);
			}
		}

		protected void nChartControl2_AsyncCustomCommand(object sender, EventArgs e)
		{
			NCallbackCustomCommandArgs args = e as NCallbackCustomCommandArgs;
			switch (args.Command.Name)
			{
				case "displayDataWindow":
					double dataWindowWidth = double.Parse(args.Command.Arguments["width"] as string);

					NCartesianChart zoomChart = nChartControl2.Charts[0] as NCartesianChart;
					NSmoothLineSeries zoomLine = zoomChart.Series[0] as NSmoothLineSeries;

					NCartesianChart previewChart = nChartControl1.Charts[0] as NCartesianChart;
					NAxis previewXAxis = previewChart.Axis(StandardAxis.PrimaryX);

					NPointF ptViewPoint = new NPointF(float.Parse(args.Command.Arguments["x"] as string), 0);
					NVector2DD vecScalePoint = new NVector2DD();

					using (NChartRasterView view = new NChartRasterView(nChartControl1.Document, nChartControl1.Dimensions, NResolution.ScreenResolution))
					{
						view.RecalcLayout();

						NViewToScale2DTransformation viewToScale = new NViewToScale2DTransformation(
							view.Context,
							previewChart,
							(int)StandardAxis.PrimaryX,
							(int)StandardAxis.PrimaryY
							);

						if (viewToScale.Transform(ptViewPoint, ref vecScalePoint))
						{
							double rangeMin = vecScalePoint.X - dataWindowWidth / 2;
							rangeMin = previewXAxis.Scale.ViewRange.GetValueInRange(rangeMin);

							double rangeMax = rangeMin + dataWindowWidth;
							rangeMax = previewXAxis.Scale.ViewRange.GetValueInRange(rangeMax);

							rangeMin = rangeMax - dataWindowWidth;

							// reinitialize data points
							zoomLine.XValues.Clear();
							zoomLine.Values.Clear();
							for (int i = (int)rangeMin; i <= (int)rangeMax; i++)
							{
								zoomLine.XValues.Add(i);
								zoomLine.Values.Add(waveData[i]);
							}
						}
					}
					break;
			}
		}

		protected void nChartControl2_AsyncQueryCommandResult(object sender, EventArgs e)
		{
			NCallbackQueryCommandResultArgs args = e as NCallbackQueryCommandResultArgs;
			switch (args.Command.Name)
			{
				case "displayDataWindow":
					if (!args.ResultBuilder.ContainsRedrawDataSection())
						args.ResultBuilder.AddRedrawDataSection(nChartControl2);
					break;
			}
		}

		#endregion
	}
}
