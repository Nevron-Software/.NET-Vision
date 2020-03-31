using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NMouseEventsUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (nChartControl1.RequiresInitialization)
			{
				nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

				// set a chart title
				NLabel header = nChartControl1.Labels.AddHeader("Mouse Events");
				header.TextStyle.FontStyle = new NFontStyle("Palatino Linotype", 14, FontStyle.Italic);
				header.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(60, 90, 108));
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
				header.ContentAlignment = ContentAlignment.BottomRight;
				header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

				// clear the legends
				nChartControl1.Legends.Clear();

				// configure stack bar chart
				NChart chart1 = nChartControl1.Charts[0];
				chart1.Tag = "BarChart";
				chart1.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
				chart1.Size = new NSizeL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
				chart1.BoundsMode = BoundsMode.Fit;
				chart1.Axis(StandardAxis.Depth).Visible = false;

				// add the first bar
				NBarSeries bar1 = (NBarSeries)chart1.Series.Add(SeriesType.Bar);
				bar1.Name = "Cars";
				bar1.MultiBarMode = MultiBarMode.Series;
				bar1.DataLabelStyle.Visible = false;

				// add the second bar
				NBarSeries bar2 = (NBarSeries)chart1.Series.Add(SeriesType.Bar);
				bar2.Name = "Airplanes";
				bar2.MultiBarMode = MultiBarMode.Stacked;
				bar2.DataLabelStyle.Visible = false;

				// add the third bar
				NBarSeries bar3 = (NBarSeries)chart1.Series.Add(SeriesType.Bar);
				bar3.Name = "Trains";
				bar3.MultiBarMode = MultiBarMode.Stacked;
				bar3.DataLabelStyle.Visible = false;

				// add the fourth bar
				NBarSeries bar4 = (NBarSeries)chart1.Series.Add(SeriesType.Bar);
				bar4.Name = "Buses";
				bar4.MultiBarMode = MultiBarMode.Stacked;
				bar4.DataLabelStyle.Visible = false;

				// change the color of the second and third bars
				bar1.Values.FillRandomRange(Random, 5, 20, 100);
				bar2.Values.FillRandomRange(Random, 5, 20, 100);
				bar3.Values.FillRandomRange(Random, 5, 20, 100);
				bar4.Values.FillRandomRange(Random, 5, 20, 100);

				// add a pie chart
				NChart chart2 = new NPieChart();
				nChartControl1.Charts.Add(chart2);

				chart2.Tag = "PieChart";
				chart2.Location = new NPointL(new NLength(55, NRelativeUnit.ParentPercentage), new NLength(8, NRelativeUnit.ParentPercentage));
				chart2.Size = new NSizeL(new NLength(45, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
				chart2.BoundsMode = BoundsMode.Fit;
				chart2.Projection.Zoom = 80;

				NPieSeries pie = (NPieSeries)chart2.Series.Add(SeriesType.Pie);
				pie.DataLabelStyle.Visible = false;

				pie.AddDataPoint(new NDataPoint(12));
				pie.AddDataPoint(new NDataPoint(42));
				pie.AddDataPoint(new NDataPoint(56));
				pie.AddDataPoint(new NDataPoint(23));

				// apply style sheet
				NStyleSheet styleSheet1 = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
				styleSheet1.Apply(chart1);

				NStyleSheet styleSheet2 = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
				styleSheet2.Apply(chart2);
			}
		}

		protected void nChartControl1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			nChartControl1.AjaxTools.Add(new NAjaxMouseClickCallbackTool(true));
			nChartControl1.AjaxTools.Add(new NAjaxMouseDoubleClickCallbackTool(false));
			nChartControl1.AjaxTools.Add(new NAjaxMouseMoveCallbackTool(false));
			nChartControl1.AjaxTools.Add(new NAjaxMouseDownCallbackTool(false));
			nChartControl1.AjaxTools.Add(new NAjaxMouseUpCallbackTool(false));
		}

		protected void nChartControl1_AsyncClick(object sender, EventArgs e)
		{
			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);
			ProcessMouseEvent(sender, e, palette.GaugeBackgroundForeColor);
		}

		protected void nChartControl1_AsyncDoubleClick(object sender, EventArgs e)
		{
			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);
			ProcessMouseEvent(sender, e, palette.GaugeBackgroundForeColor);
		}

		protected void nChartControl1_AsyncMouseDown(object sender, EventArgs e)
		{
			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);
			ProcessMouseEvent(sender, e, palette.GaugeBackgroundForeColor);
		}

		protected void nChartControl1_AsyncMouseMove(object sender, EventArgs e)
		{
			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);
			ProcessMouseEvent(sender, e, palette.GaugeBackgroundForeColor);
		}
		
		protected void nChartControl1_AsyncMouseUp(object sender, EventArgs e)
		{
			NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);
			ProcessMouseEvent(sender, e, palette.GaugeBackgroundForeColor);
		}

		protected void simulatePostbackButton_Click(object sender, EventArgs e)
		{
			//	select the default enabled state of the mouse tools
			nChartControl1.AjaxTools.GetToolByType(typeof(NAjaxMouseClickCallbackTool)).DefaultEnabled = (Request["mouseClickCheckbox"] != null);
			nChartControl1.AjaxTools.GetToolByType(typeof(NAjaxMouseDoubleClickCallbackTool)).DefaultEnabled = (Request["mouseDoubleClickCheckbox"] != null);
			nChartControl1.AjaxTools.GetToolByType(typeof(NAjaxMouseMoveCallbackTool)).DefaultEnabled = (Request["mouseMoveCheckbox"] != null);
			nChartControl1.AjaxTools.GetToolByType(typeof(NAjaxMouseDownCallbackTool)).DefaultEnabled = (Request["mouseDownCheckbox"] != null);
			nChartControl1.AjaxTools.GetToolByType(typeof(NAjaxMouseUpCallbackTool)).DefaultEnabled = (Request["mouseUpCheckbox"] != null);

			//	select the default enabled state of client side services
			nChartControl1.AsyncRequestWaitCursorEnabled = (Request["waitCursorCheckbox"] != null);

			simulatePostbackLabel.Text = "Postback simulated!";
		}

		private void ProcessMouseEvent(object sender, EventArgs e, Color c)
		{
			NHitTestResult result = nChartControl1.HitTest(e as NCallbackMouseEventArgs);
			
			if (result.ChartElement == ChartElement.DataPoint)
			{
				switch (result.Chart.Tag.ToString())
				{
					case "BarChart":
						NChartPalette palette = new NChartPalette(ChartPredefinedPalette.Nevron);
						Color highlightColor = palette.SeriesColors[5];

						NBarSeries barSeries = result.Series as NBarSeries;
                        foreach (NBarSeries series in nChartControl1.Charts[0].Series)
                        {
							series.FillStyles.Clear();
							series.BorderStyles.Clear();
						}
						barSeries.FillStyles[result.DataPointIndex] = new NColorFillStyle(c);
						barSeries.BorderStyles[result.DataPointIndex] = new NStrokeStyle(1, c);

                        int nCount = nChartControl1.Panels.Count;
                        for (int i = 0; i < nCount; i++)
                        {
                            if(nChartControl1.Panels[i] is NRoundedRectangularCallout)
                                nChartControl1.Panels.RemoveAt(i);
                        }

						NRoundedRectangularCallout m_RoundedRectangularCallout = new NRoundedRectangularCallout();
						m_RoundedRectangularCallout.ArrowLength = new NLength(10, NRelativeUnit.ParentPercentage);
						m_RoundedRectangularCallout.FillStyle = new NGradientFillStyle(Color.FromArgb(255, Color.White), Color.FromArgb(125, highlightColor));
						m_RoundedRectangularCallout.UseAutomaticSize = true;
						m_RoundedRectangularCallout.Orientation = 45;
						m_RoundedRectangularCallout.Anchor = new NDataPointAnchor(barSeries, result.DataPointIndex, ContentAlignment.TopRight, StringAlignment.Center);
						m_RoundedRectangularCallout.Text = ((NDataPoint)result.Object)[DataPointValue.Y].ToString();
						nChartControl1.Panels.Add(m_RoundedRectangularCallout);


						break;

					case "PieChart":
						NPieSeries pieSeries = result.Series as NPieSeries;
						pieSeries.Detachments.Clear();
						for (int i = 0; i < pieSeries.Values.Count; i++)
						{
							if(i == result.DataPointIndex)
								pieSeries.Detachments.Add(15);
							else
								pieSeries.Detachments.Add(0);
						}
						break;
				}
			}
		}
	}
}
